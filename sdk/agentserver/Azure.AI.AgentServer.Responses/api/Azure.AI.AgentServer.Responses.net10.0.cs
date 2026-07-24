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
    public sealed partial class CreateResponseRequest
    {
        public CreateResponseRequest(Azure.AI.AgentServer.Responses.Models.ResponseObject response, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem>? inputItems, System.Collections.Generic.IEnumerable<string>? historyItemIds) { }
        public System.Collections.Generic.IEnumerable<string> HistoryItemIds { get { throw null; } }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> InputItems { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.ResponseObject Response { get { throw null; } }
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
    public partial interface IAsyncObserver<in T>
    {
        System.Threading.Tasks.ValueTask OnCompletedAsync();
        System.Threading.Tasks.ValueTask OnErrorAsync(System.Exception error);
        System.Threading.Tasks.ValueTask OnNextAsync(T value);
    }
    public partial class InMemoryProviderOptions
    {
        public InMemoryProviderOptions() { }
        public System.TimeSpan EventStreamTtl { get { throw null; } set { } }
    }
    public partial class OutputItemBuilder<T> where T : OpenAI.Responses.ResponseItem
    {
        protected OutputItemBuilder() { }
        public string ItemId { get { throw null; } }
        public long OutputIndex { get { throw null; } }
        public virtual OpenAI.Responses.StreamingResponseOutputItemAddedUpdate EmitAdded(T item) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputItemDoneUpdate EmitDone(T item) { throw null; }
    }
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
    public partial class OutputItemCustomToolCallBuilder : Azure.AI.AgentServer.Responses.OutputItemBuilder<OpenAI.Responses.FunctionCallResponseItem>
    {
        protected OutputItemCustomToolCallBuilder() { }
        public string CallId { get { throw null; } }
        public string? FunctionArguments { get { throw null; } }
        public string FunctionName { get { throw null; } }
        public string Name { get { throw null; } }
        public virtual OpenAI.Responses.StreamingResponseOutputItemAddedUpdate EmitAdded() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputItemDoneUpdate EmitDone() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseFunctionCallArgumentsDeltaUpdate EmitInputDelta(string delta) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseFunctionCallArgumentsDoneUpdate EmitInputDone(string input) { throw null; }
        public System.Collections.Generic.IAsyncEnumerable<OpenAI.Responses.StreamingResponseUpdate> Input(System.Collections.Generic.IAsyncEnumerable<string> chunks, [System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> Input(string input) { throw null; }
    }
    public partial class OutputItemFileSearchCallBuilder : Azure.AI.AgentServer.Responses.OutputItemBuilder<OpenAI.Responses.FileSearchCallResponseItem>
    {
        protected OutputItemFileSearchCallBuilder() { }
        public virtual OpenAI.Responses.StreamingResponseOutputItemAddedUpdate EmitAdded() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseFileSearchCallCompletedUpdate EmitCompleted() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputItemDoneUpdate EmitDone() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseFileSearchCallInProgressUpdate EmitInProgress() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseFileSearchCallSearchingUpdate EmitSearching() { throw null; }
    }
    public partial class OutputItemFunctionCallBuilder : Azure.AI.AgentServer.Responses.OutputItemBuilder<OpenAI.Responses.FunctionCallResponseItem>
    {
        protected OutputItemFunctionCallBuilder() { }
        public string CallId { get { throw null; } }
        public string? FunctionArguments { get { throw null; } }
        public string FunctionName { get { throw null; } }
        public string Name { get { throw null; } }
        public virtual System.Collections.Generic.IAsyncEnumerable<OpenAI.Responses.StreamingResponseUpdate> Arguments(System.Collections.Generic.IAsyncEnumerable<string> chunks, [System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> Arguments(string arguments) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputItemAddedUpdate EmitAdded() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseFunctionCallArgumentsDeltaUpdate EmitArgumentsDelta(string delta) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseFunctionCallArgumentsDoneUpdate EmitArgumentsDone(string arguments) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputItemDoneUpdate EmitDone() { throw null; }
    }
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
    public partial class OutputItemMcpCallBuilder : Azure.AI.AgentServer.Responses.OutputItemBuilder<OpenAI.Responses.McpToolCallItem>
    {
        protected OutputItemMcpCallBuilder() { }
        public string? FunctionArguments { get { throw null; } }
        public string Name { get { throw null; } }
        public string ServerLabel { get { throw null; } }
        public string? ToolArguments { get { throw null; } }
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
        public virtual System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> TextContent(string text, System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Responses.Models.Annotation> annotations) { throw null; }
    }
    public partial class OutputItemReasoningItemBuilder : Azure.AI.AgentServer.Responses.OutputItemBuilder<OpenAI.Responses.ReasoningResponseItem>
    {
        protected OutputItemReasoningItemBuilder() { }
        public virtual Azure.AI.AgentServer.Responses.ReasoningSummaryPartBuilder AddSummaryPart() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputItemAddedUpdate EmitAdded() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputItemDoneUpdate EmitDone() { throw null; }
        public virtual System.Collections.Generic.IAsyncEnumerable<OpenAI.Responses.StreamingResponseUpdate> SummaryPart(System.Collections.Generic.IAsyncEnumerable<string> chunks, [System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> SummaryPart(string text) { throw null; }
    }
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
        public virtual System.Collections.Generic.IReadOnlyDictionary<string, string> ClientHeaders { get { throw null; } }
        public virtual string ConversationChainId { get { throw null; } }
        public string Id { get { throw null; } }
        public bool IsShutdownRequested { get { throw null; } set { } }
        public virtual Azure.AI.AgentServer.Core.PlatformContext PlatformContext { get { throw null; } }
        public virtual System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Extensions.Primitives.StringValues> QueryParameters { get { throw null; } }
        public virtual System.BinaryData? RawBody { get { throw null; } }
        public string ResponseId { get { throw null; } }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<OpenAI.Responses.ResponseItem>> GetHistoryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ResponseEventStream
    {
        protected ResponseEventStream() { }
        public ResponseEventStream(Azure.AI.AgentServer.Responses.ResponseContext context, Azure.AI.AgentServer.Responses.Models.CreateResponse request) { }
        public Azure.AI.AgentServer.Responses.Models.ResponseObject Response { get { throw null; } }
        public virtual Azure.AI.AgentServer.Responses.OutputItemBuilder<OpenAI.Responses.ApplyPatchCallItem> AddOutputItemApplyPatchCall() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemBuilder<OpenAI.Responses.ApplyPatchCallOutputItem> AddOutputItemApplyPatchCallOutput() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemCodeInterpreterCallBuilder AddOutputItemCodeInterpreterCall() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemBuilder<Azure.AI.Extensions.OpenAI.OutputItemCompactionBody> AddOutputItemCompaction() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemBuilder<OpenAI.Responses.ComputerCallResponseItem> AddOutputItemComputerCall() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemBuilder<OpenAI.Responses.ComputerCallOutputResponseItem> AddOutputItemComputerCallOutput() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemCustomToolCallBuilder AddOutputItemCustomToolCall(string callId, string name) { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemBuilder<OpenAI.Responses.FunctionCallOutputResponseItem> AddOutputItemCustomToolCallOutput() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemFileSearchCallBuilder AddOutputItemFileSearchCall() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemFunctionCallBuilder AddOutputItemFunctionCall(string name, string callId) { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemBuilder<Azure.AI.Extensions.OpenAI.OutputItemFunctionShellCall> AddOutputItemFunctionShellCall() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemBuilder<Azure.AI.Extensions.OpenAI.OutputItemFunctionShellCallOutput> AddOutputItemFunctionShellCallOutput() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemImageGenCallBuilder AddOutputItemImageGenCall() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemBuilder<Azure.AI.Extensions.OpenAI.OutputItemLocalShellToolCall> AddOutputItemLocalShellCall() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemBuilder<Azure.AI.Extensions.OpenAI.OutputItemLocalShellToolCallOutput> AddOutputItemLocalShellCallOutput() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemBuilder<OpenAI.Responses.McpToolCallApprovalRequestItem> AddOutputItemMcpApprovalRequest() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemBuilder<OpenAI.Responses.McpToolCallApprovalResponseItem> AddOutputItemMcpApprovalResponse() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemMcpCallBuilder AddOutputItemMcpCall(string serverLabel, string name) { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemMcpListToolsBuilder AddOutputItemMcpListTools(string serverLabel) { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemMessageBuilder AddOutputItemMessage() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemReasoningItemBuilder AddOutputItemReasoningItem() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemBuilder<Azure.AI.Extensions.OpenAI.AgentStructuredOutputsResponseItem> AddOutputItemStructuredOutputs() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemWebSearchCallBuilder AddOutputItemWebSearchCall() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemBuilder<T> AddOutputItem<T>(string itemId) where T : OpenAI.Responses.ResponseItem { throw null; }
        public virtual OpenAI.Responses.StreamingResponseCompletedUpdate EmitCompleted(OpenAI.Responses.ResponseTokenUsage? usage = null) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseCreatedUpdate EmitCreated(OpenAI.Responses.ResponseStatus status = OpenAI.Responses.ResponseStatus.InProgress) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseFailedUpdate EmitFailed(OpenAI.Responses.ResponseErrorCode code, string message = "An internal server error occurred.", OpenAI.Responses.ResponseTokenUsage? usage = null) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseFailedUpdate EmitFailed(string message = "An internal server error occurred.", OpenAI.Responses.ResponseTokenUsage? usage = null) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseIncompleteUpdate EmitIncomplete(OpenAI.Responses.ResponseIncompleteStatusReason? reason = default(OpenAI.Responses.ResponseIncompleteStatusReason?), OpenAI.Responses.ResponseTokenUsage? usage = null) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseInProgressUpdate EmitInProgress() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseQueuedUpdate EmitQueued() { throw null; }
        public virtual long NextSequenceNumber() { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemApplyPatchCall(string callId, Azure.AI.AgentServer.Responses.Models.ApplyPatchCallStatus status, Azure.AI.AgentServer.Responses.Models.ApplyPatchFileOperation operation) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemApplyPatchCallOutput(string callId, Azure.AI.AgentServer.Responses.Models.ApplyPatchCallOutputStatus status) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemCompaction(string encryptedContent) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemComputerCall(string callId, Azure.AI.AgentServer.Responses.Models.ComputerAction action, System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Responses.Models.ComputerCallSafetyCheckParam> pendingSafetyChecks, Azure.AI.AgentServer.Responses.Models.ItemComputerToolCallStatus status) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemComputerCallOutput(string callId, Azure.AI.AgentServer.Responses.Models.ComputerScreenshotImage output) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemCustomToolCallOutput(string callId, System.BinaryData output) { throw null; }
        public System.Collections.Generic.IAsyncEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemFunctionCall(string name, string callId, System.Collections.Generic.IAsyncEnumerable<string> chunks, [System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemFunctionCall(string name, string callId, string arguments) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemFunctionCallOutput(string callId, System.BinaryData output) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemFunctionShellCall(string callId, Azure.AI.Extensions.OpenAI.FunctionShellAction action, Azure.AI.Extensions.OpenAI.LocalShellCallStatus status, Azure.AI.Extensions.OpenAI.FunctionShellCallEnvironment environment) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemFunctionShellCallOutput(string callId, Azure.AI.Extensions.OpenAI.LocalShellCallOutputStatusEnum status, System.Collections.Generic.IEnumerable<Azure.AI.Extensions.OpenAI.FunctionShellCallOutputContent> output, long? maxOutputLength = default(long?)) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemImageGenCall(string resultBase64) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemLocalShellCall(string callId, Azure.AI.Extensions.OpenAI.LocalShellExecAction action, Azure.AI.Extensions.OpenAI.ItemLocalShellToolCallStatus status) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemLocalShellCallOutput(string output) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemMcpApprovalRequest(string serverLabel, string name, string arguments) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemMcpApprovalResponse(string approvalRequestId, bool approve) { throw null; }
        public System.Collections.Generic.IAsyncEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemMessage(System.Collections.Generic.IAsyncEnumerable<string> chunks, [System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemMessage(string text) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemMessage(string text, System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Responses.Models.Annotation> annotations) { throw null; }
        public System.Collections.Generic.IAsyncEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemReasoningItem(System.Collections.Generic.IAsyncEnumerable<string> chunks, [System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemReasoningItem(string summaryText) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemStructuredOutputs(System.BinaryData output) { throw null; }
    }
    public abstract partial class ResponseHandler
    {
        protected ResponseHandler() { }
        public abstract System.Collections.Generic.IAsyncEnumerable<OpenAI.Responses.StreamingResponseUpdate> CreateAsync(Azure.AI.AgentServer.Responses.Models.CreateResponse request, Azure.AI.AgentServer.Responses.ResponseContext context, System.Threading.CancellationToken cancellationToken);
    }
    public partial class ResponsesApiException : System.Exception
    {
        public ResponsesApiException(Azure.AI.AgentServer.Responses.Models.Error error, int statusCode) { }
        public ResponsesApiException(Azure.AI.AgentServer.Responses.Models.Error error, int statusCode, System.Exception innerException) { }
        public Azure.AI.AgentServer.Responses.Models.Error Error { get { throw null; } }
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
        public abstract System.Threading.Tasks.Task CreateResponseAsync(Azure.AI.AgentServer.Responses.CreateResponseRequest request, Azure.AI.AgentServer.Core.PlatformContext context, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.Task DeleteResponseAsync(string responseId, Azure.AI.AgentServer.Core.PlatformContext context, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<string>> GetHistoryItemIdsAsync(string? previousResponseId, string? conversationId, int limit, Azure.AI.AgentServer.Core.PlatformContext context, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.Task<Azure.AI.AgentServer.Responses.Models.AgentsPagedResultOutputItem> GetInputItemsAsync(string responseId, Azure.AI.AgentServer.Core.PlatformContext context, int limit = 20, bool ascending = false, string? after = null, string? before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem?>> GetItemsAsync(System.Collections.Generic.IEnumerable<string> itemIds, Azure.AI.AgentServer.Core.PlatformContext context, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.Task<Azure.AI.AgentServer.Responses.Models.ResponseObject> GetResponseAsync(string responseId, Azure.AI.AgentServer.Core.PlatformContext context, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.Task UpdateResponseAsync(Azure.AI.AgentServer.Responses.Models.ResponseObject response, Azure.AI.AgentServer.Core.PlatformContext context, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
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
    public partial class ResponsesServerOptions
    {
        public ResponsesServerOptions() { }
        public int DefaultFetchHistoryCount { get { throw null; } set { } }
        public string? DefaultModel { get { throw null; } set { } }
    }
    public static partial class ResponsesServerServiceCollectionExtensions
    {
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddResponsesServer(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, System.Action<Azure.AI.AgentServer.Responses.ResponsesServerOptions>? configure = null) { throw null; }
    }
    public abstract partial class ResponsesStreamProvider
    {
        protected ResponsesStreamProvider() { }
        public abstract System.Threading.Tasks.Task<Azure.AI.AgentServer.Responses.IAsyncObserver<OpenAI.Responses.StreamingResponseUpdate>> CreateEventPublisherAsync(string responseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public virtual System.Threading.Tasks.Task DeleteEventStreamAsync(string responseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public abstract System.Threading.Tasks.Task<System.IAsyncDisposable> SubscribeToEventsAsync(string responseId, Azure.AI.AgentServer.Responses.IAsyncObserver<OpenAI.Responses.StreamingResponseUpdate> observer, long? cursor = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
    public partial class TextContentBuilder
    {
        protected TextContentBuilder() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Responses.Models.Annotation> Annotations { get { throw null; } }
        public long ContentIndex { get { throw null; } }
        public string? FinalText { get { throw null; } }
        public virtual OpenAI.Responses.StreamingResponseContentPartAddedUpdate EmitAdded() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputTextAnnotationAddedUpdate EmitAnnotationAdded(Azure.AI.AgentServer.Responses.Models.Annotation annotation) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputTextDeltaUpdate EmitDelta(string text) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseContentPartDoneUpdate EmitDone() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputTextDoneUpdate EmitTextDone(string? finalText = null) { throw null; }
    }
    public partial class TextResponse : System.Collections.Generic.IAsyncEnumerable<OpenAI.Responses.StreamingResponseUpdate>
    {
        public TextResponse(Azure.AI.AgentServer.Responses.ResponseContext context, Azure.AI.AgentServer.Responses.Models.CreateResponse request, System.Func<System.Threading.CancellationToken, System.Collections.Generic.IAsyncEnumerable<string>> createTextStream, System.Action<Azure.AI.AgentServer.Responses.Models.ResponseObject>? configure = null) { }
        public TextResponse(Azure.AI.AgentServer.Responses.ResponseContext context, Azure.AI.AgentServer.Responses.Models.CreateResponse request, System.Func<System.Threading.CancellationToken, System.Threading.Tasks.Task<string>> createText, System.Action<Azure.AI.AgentServer.Responses.Models.ResponseObject>? configure = null) { }
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
    public partial class A2AProtocolConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.A2AProtocolConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.A2AProtocolConfiguration>
    {
        public A2AProtocolConfiguration() { }
        protected virtual Azure.AI.AgentServer.Responses.Models.A2AProtocolConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.A2AProtocolConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.A2AProtocolConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.A2AProtocolConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.A2AProtocolConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.A2AProtocolConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.A2AProtocolConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.A2AProtocolConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.A2AProtocolConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ActivityProtocolConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ActivityProtocolConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ActivityProtocolConfiguration>
    {
        public ActivityProtocolConfiguration() { }
        public bool? EnableM365PublicEndpoint { get { throw null; } set { } }
        protected virtual Azure.AI.AgentServer.Responses.Models.ActivityProtocolConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ActivityProtocolConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ActivityProtocolConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ActivityProtocolConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ActivityProtocolConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ActivityProtocolConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ActivityProtocolConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ActivityProtocolConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ActivityProtocolConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AgentBlueprintReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AgentBlueprintReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentBlueprintReference>
    {
        internal AgentBlueprintReference() { }
        protected virtual Azure.AI.AgentServer.Responses.Models.AgentBlueprintReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.AgentBlueprintReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.AgentBlueprintReference System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AgentBlueprintReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AgentBlueprintReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.AgentBlueprintReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentBlueprintReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentBlueprintReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentBlueprintReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentCard : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AgentCard>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentCard>
    {
        public AgentCard(string version, System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Responses.Models.AgentCardSkill> skills) { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.AgentCardSkill> Skills { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.AgentCard JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.AgentCard PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.AgentCard System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AgentCard>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AgentCard>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.AgentCard System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentCard>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentCard>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentCard>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentCardSkill : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AgentCardSkill>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentCardSkill>
    {
        public AgentCardSkill(string id, string name) { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Examples { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IList<string> Tags { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.AgentCardSkill JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.AgentCardSkill PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.AgentCardSkill System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AgentCardSkill>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AgentCardSkill>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.AgentCardSkill System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentCardSkill>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentCardSkill>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentCardSkill>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AgentDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentDefinition>
    {
        internal AgentDefinition() { }
        public Azure.AI.AgentServer.Responses.Models.RaiConfig RaiConfig { get { throw null; } set { } }
        protected virtual Azure.AI.AgentServer.Responses.Models.AgentDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.AgentDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.AgentDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AgentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AgentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.AgentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AgentEndpointAuthorizationScheme : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AgentEndpointAuthorizationScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentEndpointAuthorizationScheme>
    {
        internal AgentEndpointAuthorizationScheme() { }
        protected virtual Azure.AI.AgentServer.Responses.Models.AgentEndpointAuthorizationScheme JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.AgentEndpointAuthorizationScheme PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.AgentEndpointAuthorizationScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AgentEndpointAuthorizationScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AgentEndpointAuthorizationScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.AgentEndpointAuthorizationScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentEndpointAuthorizationScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentEndpointAuthorizationScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentEndpointAuthorizationScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentEndpointConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AgentEndpointConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentEndpointConfig>
    {
        public AgentEndpointConfig() { }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.AgentEndpointAuthorizationScheme> AuthorizationSchemes { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.ProtocolConfiguration ProtocolConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.AgentEndpointProtocol> Protocols { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.VersionSelector VersionSelector { get { throw null; } set { } }
        protected virtual Azure.AI.AgentServer.Responses.Models.AgentEndpointConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.AgentEndpointConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.AgentEndpointConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AgentEndpointConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AgentEndpointConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.AgentEndpointConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentEndpointConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentEndpointConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentEndpointConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentEndpointProtocol : System.IEquatable<Azure.AI.AgentServer.Responses.Models.AgentEndpointProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentEndpointProtocol(string value) { throw null; }
        public static Azure.AI.AgentServer.Responses.Models.AgentEndpointProtocol A2a { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.AgentEndpointProtocol Activity { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.AgentEndpointProtocol Invocations { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.AgentEndpointProtocol InvocationsWs { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.AgentEndpointProtocol Mcp { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.AgentEndpointProtocol Responses { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Responses.Models.AgentEndpointProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Responses.Models.AgentEndpointProtocol left, Azure.AI.AgentServer.Responses.Models.AgentEndpointProtocol right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Responses.Models.AgentEndpointProtocol (string value) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Responses.Models.AgentEndpointProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Responses.Models.AgentEndpointProtocol left, Azure.AI.AgentServer.Responses.Models.AgentEndpointProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentId : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AgentId>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentId>
    {
        internal AgentId() { }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.AgentId JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.AgentId PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.AgentId System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AgentId>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AgentId>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.AgentId System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentId>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentId>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentId>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentsPagedResultOutputItem
    {
        internal AgentsPagedResultOutputItem() { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("data")]
        public System.Collections.Generic.IList<OpenAI.Responses.ResponseItem> Data { get { throw null; } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("first_id")]
        public string FirstId { get { throw null; } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("has_more")]
        public bool HasMore { get { throw null; } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("last_id")]
        public string LastId { get { throw null; } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("object")]
        public string Object { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentState : System.IEquatable<Azure.AI.AgentServer.Responses.Models.AgentState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentState(string value) { throw null; }
        public static Azure.AI.AgentServer.Responses.Models.AgentState Disabled { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.AgentState Enabled { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Responses.Models.AgentState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Responses.Models.AgentState left, Azure.AI.AgentServer.Responses.Models.AgentState right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Responses.Models.AgentState (string value) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Responses.Models.AgentState? (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Responses.Models.AgentState left, Azure.AI.AgentServer.Responses.Models.AgentState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class Annotation : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.Annotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.Annotation>
    {
        internal Annotation() { }
        protected virtual Azure.AI.AgentServer.Responses.Models.Annotation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.Annotation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.Annotation System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.Annotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.Annotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.Annotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.Annotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.Annotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.Annotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiErrorResponse
    {
        public ApiErrorResponse(Azure.AI.AgentServer.Responses.Models.Error error) { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("error")]
        public Azure.AI.AgentServer.Responses.Models.Error Error { get { throw null; } set { } }
    }
    public enum ApplyPatchCallOutputStatus
    {
        Completed = 0,
        Failed = 1,
    }
    public enum ApplyPatchCallStatus
    {
        InProgress = 0,
        Completed = 1,
    }
    public partial class ApplyPatchCreateFileOperation : Azure.AI.AgentServer.Responses.Models.ApplyPatchFileOperation, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ApplyPatchCreateFileOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ApplyPatchCreateFileOperation>
    {
        internal ApplyPatchCreateFileOperation() { }
        public string Diff { get { throw null; } }
        public string Path { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ApplyPatchFileOperation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ApplyPatchFileOperation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ApplyPatchCreateFileOperation System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ApplyPatchCreateFileOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ApplyPatchCreateFileOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ApplyPatchCreateFileOperation System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ApplyPatchCreateFileOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ApplyPatchCreateFileOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ApplyPatchCreateFileOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplyPatchDeleteFileOperation : Azure.AI.AgentServer.Responses.Models.ApplyPatchFileOperation, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ApplyPatchDeleteFileOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ApplyPatchDeleteFileOperation>
    {
        internal ApplyPatchDeleteFileOperation() { }
        public string Path { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ApplyPatchFileOperation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ApplyPatchFileOperation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ApplyPatchDeleteFileOperation System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ApplyPatchDeleteFileOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ApplyPatchDeleteFileOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ApplyPatchDeleteFileOperation System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ApplyPatchDeleteFileOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ApplyPatchDeleteFileOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ApplyPatchDeleteFileOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ApplyPatchFileOperation : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ApplyPatchFileOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ApplyPatchFileOperation>
    {
        internal ApplyPatchFileOperation() { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ApplyPatchFileOperation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ApplyPatchFileOperation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ApplyPatchFileOperation System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ApplyPatchFileOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ApplyPatchFileOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ApplyPatchFileOperation System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ApplyPatchFileOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ApplyPatchFileOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ApplyPatchFileOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApplyPatchUpdateFileOperation : Azure.AI.AgentServer.Responses.Models.ApplyPatchFileOperation, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ApplyPatchUpdateFileOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ApplyPatchUpdateFileOperation>
    {
        internal ApplyPatchUpdateFileOperation() { }
        public string Diff { get { throw null; } }
        public string Path { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ApplyPatchFileOperation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ApplyPatchFileOperation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ApplyPatchUpdateFileOperation System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ApplyPatchUpdateFileOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ApplyPatchUpdateFileOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ApplyPatchUpdateFileOperation System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ApplyPatchUpdateFileOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ApplyPatchUpdateFileOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ApplyPatchUpdateFileOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutoCodeInterpreterToolParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AutoCodeInterpreterToolParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AutoCodeInterpreterToolParam>
    {
        internal AutoCodeInterpreterToolParam() { }
        public System.Collections.Generic.IList<string> FileIds { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.ContainerMemoryLimit? MemoryLimit { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyParam NetworkPolicy { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.AutoCodeInterpreterToolParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.AutoCodeInterpreterToolParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.AutoCodeInterpreterToolParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AutoCodeInterpreterToolParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AutoCodeInterpreterToolParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.AutoCodeInterpreterToolParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AutoCodeInterpreterToolParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AutoCodeInterpreterToolParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AutoCodeInterpreterToolParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BotServiceAuthorizationScheme : Azure.AI.AgentServer.Responses.Models.AgentEndpointAuthorizationScheme, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.BotServiceAuthorizationScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.BotServiceAuthorizationScheme>
    {
        public BotServiceAuthorizationScheme() { }
        protected override Azure.AI.AgentServer.Responses.Models.AgentEndpointAuthorizationScheme JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.AgentEndpointAuthorizationScheme PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.BotServiceAuthorizationScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.BotServiceAuthorizationScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.BotServiceAuthorizationScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.BotServiceAuthorizationScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.BotServiceAuthorizationScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.BotServiceAuthorizationScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.BotServiceAuthorizationScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BotServiceRbacAuthorizationScheme : Azure.AI.AgentServer.Responses.Models.AgentEndpointAuthorizationScheme, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.BotServiceRbacAuthorizationScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.BotServiceRbacAuthorizationScheme>
    {
        public BotServiceRbacAuthorizationScheme() { }
        protected override Azure.AI.AgentServer.Responses.Models.AgentEndpointAuthorizationScheme JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.AgentEndpointAuthorizationScheme PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.BotServiceRbacAuthorizationScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.BotServiceRbacAuthorizationScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.BotServiceRbacAuthorizationScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.BotServiceRbacAuthorizationScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.BotServiceRbacAuthorizationScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.BotServiceRbacAuthorizationScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.BotServiceRbacAuthorizationScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BotServiceTenantAuthorizationScheme : Azure.AI.AgentServer.Responses.Models.AgentEndpointAuthorizationScheme, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.BotServiceTenantAuthorizationScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.BotServiceTenantAuthorizationScheme>
    {
        public BotServiceTenantAuthorizationScheme() { }
        protected override Azure.AI.AgentServer.Responses.Models.AgentEndpointAuthorizationScheme JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.AgentEndpointAuthorizationScheme PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.BotServiceTenantAuthorizationScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.BotServiceTenantAuthorizationScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.BotServiceTenantAuthorizationScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.BotServiceTenantAuthorizationScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.BotServiceTenantAuthorizationScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.BotServiceTenantAuthorizationScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.BotServiceTenantAuthorizationScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ClickButtonType
    {
        Left = 0,
        Right = 1,
        Wheel = 2,
        Back = 3,
        Forward = 4,
    }
    public partial class ClickParam : Azure.AI.AgentServer.Responses.Models.ComputerAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ClickParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ClickParam>
    {
        internal ClickParam() { }
        public Azure.AI.AgentServer.Responses.Models.ClickButtonType Button { get { throw null; } }
        public System.Collections.Generic.IList<string> Keys { get { throw null; } }
        public long X { get { throw null; } }
        public long Y { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ComputerAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ComputerAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ClickParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ClickParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ClickParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ClickParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ClickParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ClickParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ClickParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CodeConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CodeConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CodeConfiguration>
    {
        public CodeConfiguration(string runtime, System.Collections.Generic.IEnumerable<string> entryPoint, Azure.AI.AgentServer.Responses.Models.CodeDependencyResolution dependencyResolution) { }
        public string ContentHash { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.CodeDependencyResolution DependencyResolution { get { throw null; } }
        public System.Collections.Generic.IList<string> EntryPoint { get { throw null; } }
        public string Runtime { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.CodeConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.CodeConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.CodeConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CodeConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CodeConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.CodeConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CodeConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CodeConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CodeConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CodeDependencyResolution : System.IEquatable<Azure.AI.AgentServer.Responses.Models.CodeDependencyResolution>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CodeDependencyResolution(string value) { throw null; }
        public static Azure.AI.AgentServer.Responses.Models.CodeDependencyResolution Bundled { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.CodeDependencyResolution RemoteBuild { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Responses.Models.CodeDependencyResolution other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Responses.Models.CodeDependencyResolution left, Azure.AI.AgentServer.Responses.Models.CodeDependencyResolution right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Responses.Models.CodeDependencyResolution (string value) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Responses.Models.CodeDependencyResolution? (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Responses.Models.CodeDependencyResolution left, Azure.AI.AgentServer.Responses.Models.CodeDependencyResolution right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CodeInterpreterOutputImage : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CodeInterpreterOutputImage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CodeInterpreterOutputImage>
    {
        internal CodeInterpreterOutputImage() { }
        public string Type { get { throw null; } }
        public System.Uri Url { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.CodeInterpreterOutputImage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.CodeInterpreterOutputImage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.CodeInterpreterOutputImage System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CodeInterpreterOutputImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CodeInterpreterOutputImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.CodeInterpreterOutputImage System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CodeInterpreterOutputImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CodeInterpreterOutputImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CodeInterpreterOutputImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CodeInterpreterOutputLogs : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CodeInterpreterOutputLogs>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CodeInterpreterOutputLogs>
    {
        internal CodeInterpreterOutputLogs() { }
        public string Logs { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.CodeInterpreterOutputLogs JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.CodeInterpreterOutputLogs PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.CodeInterpreterOutputLogs System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CodeInterpreterOutputLogs>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CodeInterpreterOutputLogs>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.CodeInterpreterOutputLogs System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CodeInterpreterOutputLogs>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CodeInterpreterOutputLogs>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CodeInterpreterOutputLogs>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CompactResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CompactResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CompactResource>
    {
        internal CompactResource() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public string Object { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.ItemField> Output { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.ResponseUsage Usage { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.CompactResource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.AgentServer.Responses.Models.CompactResource (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.AgentServer.Responses.Models.CompactResource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.CompactResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CompactResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CompactResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.CompactResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CompactResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CompactResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CompactResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComparisonFilter : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ComparisonFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ComparisonFilter>
    {
        internal ComparisonFilter() { }
        public string Key { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.FileSearchToolFiltersType Type { get { throw null; } }
        public System.BinaryData Value { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.ComparisonFilter JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ComparisonFilter PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ComparisonFilter System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ComparisonFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ComparisonFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ComparisonFilter System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ComparisonFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ComparisonFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ComparisonFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CompoundFilter : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CompoundFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CompoundFilter>
    {
        internal CompoundFilter() { }
        public System.Collections.Generic.IList<System.BinaryData> Filters { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.FileSearchToolFiltersType1 Type { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.CompoundFilter JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.CompoundFilter PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.CompoundFilter System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CompoundFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CompoundFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.CompoundFilter System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CompoundFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CompoundFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CompoundFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ComputerAction : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ComputerAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ComputerAction>
    {
        internal ComputerAction() { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ComputerAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ComputerAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ComputerAction System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ComputerAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ComputerAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ComputerAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ComputerAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ComputerAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ComputerAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputerCallSafetyCheckParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ComputerCallSafetyCheckParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ComputerCallSafetyCheckParam>
    {
        internal ComputerCallSafetyCheckParam() { }
        public string Code { get { throw null; } }
        public string Id { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.ComputerCallSafetyCheckParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ComputerCallSafetyCheckParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ComputerCallSafetyCheckParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ComputerCallSafetyCheckParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ComputerCallSafetyCheckParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ComputerCallSafetyCheckParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ComputerCallSafetyCheckParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ComputerCallSafetyCheckParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ComputerCallSafetyCheckParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputerScreenshotContent : Azure.AI.AgentServer.Responses.Models.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ComputerScreenshotContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ComputerScreenshotContent>
    {
        internal ComputerScreenshotContent() { }
        public Azure.AI.AgentServer.Responses.Models.ImageDetail Detail { get { throw null; } }
        public string FileId { get { throw null; } }
        public System.Uri ImageUrl { get { throw null; } }
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
    public partial class ComputerScreenshotImage : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ComputerScreenshotImage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ComputerScreenshotImage>
    {
        internal ComputerScreenshotImage() { }
        public string FileId { get { throw null; } }
        public System.Uri ImageUrl { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.ComputerScreenshotImage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ComputerScreenshotImage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ComputerScreenshotImage System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ComputerScreenshotImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ComputerScreenshotImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ComputerScreenshotImage System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ComputerScreenshotImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ComputerScreenshotImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ComputerScreenshotImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerAppAgentDefinition : Azure.AI.AgentServer.Responses.Models.AgentDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContainerAppAgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerAppAgentDefinition>
    {
        public ContainerAppAgentDefinition(System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Responses.Models.ProtocolVersionRecord> containerProtocolVersions, string containerAppResourceId, string ingressSubdomainSuffix) { }
        public string ContainerAppResourceId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.ProtocolVersionRecord> ContainerProtocolVersions { get { throw null; } }
        public string IngressSubdomainSuffix { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.AgentDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.AgentDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ContainerAppAgentDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContainerAppAgentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContainerAppAgentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ContainerAppAgentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerAppAgentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerAppAgentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerAppAgentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContainerConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerConfiguration>
    {
        public ContainerConfiguration(string image) { }
        public string Image { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.ContainerConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ContainerConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ContainerConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContainerConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContainerConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ContainerConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerFileCitationBody : Azure.AI.AgentServer.Responses.Models.Annotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContainerFileCitationBody>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerFileCitationBody>
    {
        internal ContainerFileCitationBody() { }
        public string ContainerId { get { throw null; } }
        public long EndIndex { get { throw null; } }
        public string FileId { get { throw null; } }
        public string Filename { get { throw null; } }
        public long StartIndex { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.Annotation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.Annotation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ContainerFileCitationBody System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContainerFileCitationBody>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContainerFileCitationBody>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ContainerFileCitationBody System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerFileCitationBody>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerFileCitationBody>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerFileCitationBody>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ContainerMemoryLimit
    {
        _1g = 0,
        _4g = 1,
        _16g = 2,
        _64g = 3,
    }
    public partial class ContainerNetworkPolicyAllowlistParam : Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyParam, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyAllowlistParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyAllowlistParam>
    {
        internal ContainerNetworkPolicyAllowlistParam() { }
        public System.Collections.Generic.IList<string> AllowedDomains { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyDomainSecretParam> DomainSecrets { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyAllowlistParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyAllowlistParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyAllowlistParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyAllowlistParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyAllowlistParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyAllowlistParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyAllowlistParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerNetworkPolicyDisabledParam : Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyParam, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyDisabledParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyDisabledParam>
    {
        internal ContainerNetworkPolicyDisabledParam() { }
        protected override Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyDisabledParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyDisabledParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyDisabledParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyDisabledParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyDisabledParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyDisabledParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyDisabledParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerNetworkPolicyDomainSecretParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyDomainSecretParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyDomainSecretParam>
    {
        internal ContainerNetworkPolicyDomainSecretParam() { }
        public string Domain { get { throw null; } }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyDomainSecretParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyDomainSecretParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyDomainSecretParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyDomainSecretParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyDomainSecretParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyDomainSecretParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyDomainSecretParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyDomainSecretParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyDomainSecretParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerNetworkPolicyParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyParam>
    {
        internal ContainerNetworkPolicyParam() { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerNetworkPolicyParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerReferenceResource : Azure.AI.AgentServer.Responses.Models.FunctionShellCallEnvironment, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContainerReferenceResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerReferenceResource>
    {
        internal ContainerReferenceResource() { }
        public string ContainerId { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.FunctionShellCallEnvironment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.FunctionShellCallEnvironment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ContainerReferenceResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContainerReferenceResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContainerReferenceResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ContainerReferenceResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerReferenceResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerReferenceResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerReferenceResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationParam
    {
        public ConversationParam(string id) { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("id")]
        public string Id { get { throw null; } set { } }
    }
    public partial class CoordParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CoordParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CoordParam>
    {
        internal CoordParam() { }
        public long X { get { throw null; } }
        public long Y { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.CoordParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.CoordParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.CoordParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CoordParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CoordParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.CoordParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CoordParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CoordParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CoordParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateAgentFromManifestRequest : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CreateAgentFromManifestRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CreateAgentFromManifestRequest>
    {
        public CreateAgentFromManifestRequest(string name, string manifestId, System.Collections.Generic.IDictionary<string, System.BinaryData> parameterValues) { }
        public string Description { get { throw null; } set { } }
        public string ManifestId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ParameterValues { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.CreateAgentFromManifestRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.CreateAgentFromManifestRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.CreateAgentFromManifestRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CreateAgentFromManifestRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CreateAgentFromManifestRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.CreateAgentFromManifestRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CreateAgentFromManifestRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CreateAgentFromManifestRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CreateAgentFromManifestRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateAgentRequest : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CreateAgentRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CreateAgentRequest>
    {
        public CreateAgentRequest(string name, Azure.AI.AgentServer.Responses.Models.AgentDefinition definition) { }
        public Azure.AI.AgentServer.Responses.Models.AgentCard AgentCard { get { throw null; } set { } }
        public Azure.AI.AgentServer.Responses.Models.AgentEndpointConfig AgentEndpoint { get { throw null; } set { } }
        public Azure.AI.AgentServer.Responses.Models.AgentBlueprintReference BlueprintReference { get { throw null; } set { } }
        public Azure.AI.AgentServer.Responses.Models.AgentDefinition Definition { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? Draft { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.AgentState? State { get { throw null; } set { } }
        protected virtual Azure.AI.AgentServer.Responses.Models.CreateAgentRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.CreateAgentRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.CreateAgentRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CreateAgentRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CreateAgentRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.CreateAgentRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CreateAgentRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CreateAgentRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CreateAgentRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateAgentVersionFromManifestRequest : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CreateAgentVersionFromManifestRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CreateAgentVersionFromManifestRequest>
    {
        public CreateAgentVersionFromManifestRequest(string manifestId, System.Collections.Generic.IDictionary<string, System.BinaryData> parameterValues) { }
        public string Description { get { throw null; } set { } }
        public string ManifestId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ParameterValues { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.CreateAgentVersionFromManifestRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.CreateAgentVersionFromManifestRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.CreateAgentVersionFromManifestRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CreateAgentVersionFromManifestRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CreateAgentVersionFromManifestRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.CreateAgentVersionFromManifestRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CreateAgentVersionFromManifestRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CreateAgentVersionFromManifestRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CreateAgentVersionFromManifestRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateAgentVersionRequest : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CreateAgentVersionRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CreateAgentVersionRequest>
    {
        public CreateAgentVersionRequest(Azure.AI.AgentServer.Responses.Models.AgentDefinition definition) { }
        public Azure.AI.AgentServer.Responses.Models.AgentBlueprintReference BlueprintReference { get { throw null; } set { } }
        public Azure.AI.AgentServer.Responses.Models.AgentDefinition Definition { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? Draft { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.CreateAgentVersionRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.CreateAgentVersionRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.CreateAgentVersionRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CreateAgentVersionRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CreateAgentVersionRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.CreateAgentVersionRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CreateAgentVersionRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CreateAgentVersionRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CreateAgentVersionRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreatedBy : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CreatedBy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CreatedBy>
    {
        internal CreatedBy() { }
        public Azure.AI.AgentServer.Responses.Models.AgentId Agent { get { throw null; } }
        public string ResponseId { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.CreatedBy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.CreatedBy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.CreatedBy System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CreatedBy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CreatedBy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.CreatedBy System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CreatedBy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CreatedBy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CreatedBy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateResponse : OpenAI.Responses.CreateResponseOptions
    {
        public CreateResponse() { }
        public CreateResponse(string model, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> inputItems) { }
        public Azure.AI.Extensions.OpenAI.AgentReference? AgentReference { get { throw null; } set { } }
        public string? AgentSessionId { get { throw null; } set { } }
        public bool? Background { get { throw null; } set { } }
        public System.BinaryData? Conversation { get { throw null; } set { } }
        public System.BinaryData? FunctionArguments { get { throw null; } set { } }
        public System.BinaryData? Input { get { throw null; } set { } }
        public int? MaxOutputTokens { get { throw null; } set { } }
        public bool? ParallelToolCalls { get { throw null; } set { } }
        public OpenAI.Responses.ResponseReasoningOptions? Reasoning { get { throw null; } set { } }
        public bool? Store { get { throw null; } set { } }
        public bool? Stream { get { throw null; } set { } }
        public System.Collections.Generic.IList<OpenAI.Responses.ResponseTool> ToolDefinitions { get { throw null; } }
        public OpenAI.Responses.ResponseTruncationMode? Truncation { get { throw null; } set { } }
    }
    public static partial class CreateResponseExtensions
    {
        public static Azure.AI.AgentServer.Responses.Models.ConversationParam? GetConversationExpanded(this Azure.AI.AgentServer.Responses.Models.CreateResponse request) { throw null; }
        public static string? GetConversationId(this Azure.AI.AgentServer.Responses.Models.CreateResponse request) { throw null; }
        public static System.Collections.Generic.List<OpenAI.Responses.ResponseItem> GetInputExpanded(this Azure.AI.AgentServer.Responses.Models.CreateResponse request) { throw null; }
        public static System.BinaryData? GetInstructionsBinaryData(this Azure.AI.AgentServer.Responses.Models.CreateResponse request) { throw null; }
        public static Azure.AI.AgentServer.Responses.Models.ToolChoiceParam? GetToolChoiceExpanded(this Azure.AI.AgentServer.Responses.Models.CreateResponse request) { throw null; }
    }
    public partial class CustomGrammarFormatParam : Azure.AI.AgentServer.Responses.Models.CustomToolParamFormat, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CustomGrammarFormatParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CustomGrammarFormatParam>
    {
        internal CustomGrammarFormatParam() { }
        public string Definition { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.GrammarSyntax1 Syntax { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.CustomToolParamFormat JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.CustomToolParamFormat PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.CustomGrammarFormatParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CustomGrammarFormatParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CustomGrammarFormatParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.CustomGrammarFormatParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CustomGrammarFormatParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CustomGrammarFormatParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CustomGrammarFormatParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomTextFormatParam : Azure.AI.AgentServer.Responses.Models.CustomToolParamFormat, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CustomTextFormatParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CustomTextFormatParam>
    {
        internal CustomTextFormatParam() { }
        protected override Azure.AI.AgentServer.Responses.Models.CustomToolParamFormat JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.CustomToolParamFormat PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.CustomTextFormatParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CustomTextFormatParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CustomTextFormatParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.CustomTextFormatParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CustomTextFormatParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CustomTextFormatParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CustomTextFormatParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomToolParam : OpenAI.Responses.ResponseTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CustomToolParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CustomToolParam>
    {
        internal CustomToolParam() : base (default(OpenAI.Responses.ResponseToolKind)) { }
        public bool? DeferLoading { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.CustomToolParamFormat Format { get { throw null; } }
        public string Name { get { throw null; } }
        protected override OpenAI.Responses.ResponseTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override OpenAI.Responses.ResponseTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.CustomToolParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CustomToolParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CustomToolParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.CustomToolParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CustomToolParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CustomToolParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CustomToolParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CustomToolParamFormat : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CustomToolParamFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CustomToolParamFormat>
    {
        internal CustomToolParamFormat() { }
        protected virtual Azure.AI.AgentServer.Responses.Models.CustomToolParamFormat JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.CustomToolParamFormat PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.CustomToolParamFormat System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CustomToolParamFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CustomToolParamFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.CustomToolParamFormat System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CustomToolParamFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CustomToolParamFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CustomToolParamFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum DetailEnum
    {
        Low = 0,
        High = 1,
        Auto = 2,
        Original = 3,
    }
    public partial class DoubleClickAction : Azure.AI.AgentServer.Responses.Models.ComputerAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.DoubleClickAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.DoubleClickAction>
    {
        internal DoubleClickAction() { }
        public System.Collections.Generic.IList<string> Keys { get { throw null; } }
        public long X { get { throw null; } }
        public long Y { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ComputerAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ComputerAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.DoubleClickAction System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.DoubleClickAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.DoubleClickAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.DoubleClickAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.DoubleClickAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.DoubleClickAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.DoubleClickAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DragParam : Azure.AI.AgentServer.Responses.Models.ComputerAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.DragParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.DragParam>
    {
        internal DragParam() { }
        public System.Collections.Generic.IList<string> Keys { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.CoordParam> Path { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ComputerAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ComputerAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.DragParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.DragParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.DragParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.DragParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.DragParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.DragParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.DragParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EmptyModelParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.EmptyModelParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.EmptyModelParam>
    {
        internal EmptyModelParam() { }
        protected virtual Azure.AI.AgentServer.Responses.Models.EmptyModelParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.EmptyModelParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.EmptyModelParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.EmptyModelParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.EmptyModelParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.EmptyModelParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.EmptyModelParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.EmptyModelParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.EmptyModelParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EntraAuthorizationScheme : Azure.AI.AgentServer.Responses.Models.AgentEndpointAuthorizationScheme, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.EntraAuthorizationScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.EntraAuthorizationScheme>
    {
        public EntraAuthorizationScheme() { }
        protected override Azure.AI.AgentServer.Responses.Models.AgentEndpointAuthorizationScheme JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.AgentEndpointAuthorizationScheme PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.EntraAuthorizationScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.EntraAuthorizationScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.EntraAuthorizationScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.EntraAuthorizationScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.EntraAuthorizationScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.EntraAuthorizationScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.EntraAuthorizationScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Error
    {
        public Error(string code, string message) { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("additional_info")]
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalInfo { get { throw null; } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("code")]
        public string Code { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonIgnoreAttribute]
        public System.Collections.Generic.IDictionary<string, System.BinaryData> DebugInfo { get { throw null; } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("details")]
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.Error> Details { get { throw null; } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("message")]
        public string Message { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("param")]
        public string? Param { get { throw null; } set { } }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("type")]
        public string? Type { get { throw null; } set { } }
    }
    public partial class ExternalAgentDefinition : Azure.AI.AgentServer.Responses.Models.AgentDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ExternalAgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ExternalAgentDefinition>
    {
        public ExternalAgentDefinition() { }
        public string OtelAgentId { get { throw null; } set { } }
        protected override Azure.AI.AgentServer.Responses.Models.AgentDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.AgentDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ExternalAgentDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ExternalAgentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ExternalAgentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ExternalAgentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ExternalAgentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ExternalAgentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ExternalAgentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileCitationBody : Azure.AI.AgentServer.Responses.Models.Annotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FileCitationBody>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FileCitationBody>
    {
        internal FileCitationBody() { }
        public string FileId { get { throw null; } }
        public string Filename { get { throw null; } }
        public long Index { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.Annotation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.Annotation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.FileCitationBody System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FileCitationBody>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FileCitationBody>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.FileCitationBody System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FileCitationBody>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FileCitationBody>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FileCitationBody>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FilePath : Azure.AI.AgentServer.Responses.Models.Annotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FilePath>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FilePath>
    {
        internal FilePath() { }
        public string FileId { get { throw null; } }
        public long Index { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.Annotation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.Annotation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.FilePath System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FilePath>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FilePath>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.FilePath System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FilePath>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FilePath>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FilePath>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSearchToolCallResults : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FileSearchToolCallResults>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FileSearchToolCallResults>
    {
        internal FileSearchToolCallResults() { }
        public Azure.AI.AgentServer.Responses.Models.VectorStoreFileAttributes Attributes { get { throw null; } }
        public string FileId { get { throw null; } }
        public string Filename { get { throw null; } }
        public float? Score { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.FileSearchToolCallResults JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.FileSearchToolCallResults PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.FileSearchToolCallResults System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FileSearchToolCallResults>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FileSearchToolCallResults>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.FileSearchToolCallResults System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FileSearchToolCallResults>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FileSearchToolCallResults>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FileSearchToolCallResults>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum FileSearchToolFiltersType
    {
        Eq = 0,
        Ne = 1,
        Gt = 2,
        Gte = 3,
        Lt = 4,
        Lte = 5,
        In = 6,
        Nin = 7,
    }
    public enum FileSearchToolFiltersType1
    {
        And = 0,
        Or = 1,
    }
    public partial class FixedRatioVersionSelectionRule : Azure.AI.AgentServer.Responses.Models.VersionSelectionRule, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FixedRatioVersionSelectionRule>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FixedRatioVersionSelectionRule>
    {
        public FixedRatioVersionSelectionRule(string agentVersion, int trafficPercentage) { }
        public int TrafficPercentage { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.VersionSelectionRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.VersionSelectionRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.FixedRatioVersionSelectionRule System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FixedRatioVersionSelectionRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FixedRatioVersionSelectionRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.FixedRatioVersionSelectionRule System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FixedRatioVersionSelectionRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FixedRatioVersionSelectionRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FixedRatioVersionSelectionRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class FunctionAndCustomToolCallOutput : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutput>
    {
        internal FunctionAndCustomToolCallOutput() { }
        protected virtual Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FunctionAndCustomToolCallOutputInputFileContent : Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutputInputFileContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutputInputFileContent>
    {
        internal FunctionAndCustomToolCallOutputInputFileContent() { }
        public string FileData { get { throw null; } }
        public string FileId { get { throw null; } }
        public string Filename { get { throw null; } }
        public System.Uri FileUrl { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutputInputFileContent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutputInputFileContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutputInputFileContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutputInputFileContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutputInputFileContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutputInputFileContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutputInputFileContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FunctionAndCustomToolCallOutputInputImageContent : Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutputInputImageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutputInputImageContent>
    {
        internal FunctionAndCustomToolCallOutputInputImageContent() { }
        public Azure.AI.AgentServer.Responses.Models.ImageDetail Detail { get { throw null; } }
        public string FileId { get { throw null; } }
        public System.Uri ImageUrl { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutputInputImageContent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutputInputImageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutputInputImageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutputInputImageContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutputInputImageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutputInputImageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutputInputImageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FunctionAndCustomToolCallOutputInputTextContent : Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutputInputTextContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutputInputTextContent>
    {
        internal FunctionAndCustomToolCallOutputInputTextContent() { }
        public string Text { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutputInputTextContent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutputInputTextContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutputInputTextContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutputInputTextContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutputInputTextContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutputInputTextContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionAndCustomToolCallOutputInputTextContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class FunctionShellAction : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionShellAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionShellAction>
    {
        internal FunctionShellAction() { }
        public System.Collections.Generic.IList<string> Commands { get { throw null; } }
        public long? MaxOutputLength { get { throw null; } }
        public long? TimeoutMs { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.FunctionShellAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.FunctionShellAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.FunctionShellAction System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionShellAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionShellAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.FunctionShellAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionShellAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionShellAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionShellAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class FunctionShellCallEnvironment : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallEnvironment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallEnvironment>
    {
        internal FunctionShellCallEnvironment() { }
        protected virtual Azure.AI.AgentServer.Responses.Models.FunctionShellCallEnvironment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.FunctionShellCallEnvironment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.FunctionShellCallEnvironment System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallEnvironment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallEnvironment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.FunctionShellCallEnvironment System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallEnvironment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallEnvironment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallEnvironment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FunctionShellCallOutputContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputContent>
    {
        internal FunctionShellCallOutputContent() { }
        public string CreatedBy { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputOutcome Outcome { get { throw null; } }
        public string Stderr { get { throw null; } }
        public string Stdout { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputContent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FunctionShellCallOutputExitOutcome : Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputOutcome, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputExitOutcome>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputExitOutcome>
    {
        internal FunctionShellCallOutputExitOutcome() { }
        public long ExitCode { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputOutcome JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputOutcome PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputExitOutcome System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputExitOutcome>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputExitOutcome>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputExitOutcome System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputExitOutcome>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputExitOutcome>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputExitOutcome>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class FunctionShellCallOutputOutcome : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputOutcome>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputOutcome>
    {
        internal FunctionShellCallOutputOutcome() { }
        protected virtual Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputOutcome JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputOutcome PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputOutcome System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputOutcome>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputOutcome>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputOutcome System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputOutcome>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputOutcome>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputOutcome>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FunctionShellCallOutputTimeoutOutcome : Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputOutcome, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputTimeoutOutcome>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputTimeoutOutcome>
    {
        internal FunctionShellCallOutputTimeoutOutcome() { }
        protected override Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputOutcome JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputOutcome PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputTimeoutOutcome System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputTimeoutOutcome>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputTimeoutOutcome>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputTimeoutOutcome System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputTimeoutOutcome>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputTimeoutOutcome>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputTimeoutOutcome>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FunctionToolParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionToolParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionToolParam>
    {
        internal FunctionToolParam() { }
        public bool? DeferLoading { get { throw null; } }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.EmptyModelParam Parameters { get { throw null; } }
        public bool? Strict { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.FunctionToolParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.FunctionToolParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.FunctionToolParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionToolParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FunctionToolParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.FunctionToolParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionToolParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionToolParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FunctionToolParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum GrammarSyntax1
    {
        Lark = 0,
        Regex = 1,
    }
    public partial class HeaderTelemetryEndpointAuth : Azure.AI.AgentServer.Responses.Models.TelemetryEndpointAuth, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.HeaderTelemetryEndpointAuth>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.HeaderTelemetryEndpointAuth>
    {
        public HeaderTelemetryEndpointAuth(string headerName, string secretId, string secretKey) { }
        public string HeaderName { get { throw null; } }
        public string SecretId { get { throw null; } }
        public string SecretKey { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.TelemetryEndpointAuth JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.TelemetryEndpointAuth PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.HeaderTelemetryEndpointAuth System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.HeaderTelemetryEndpointAuth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.HeaderTelemetryEndpointAuth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.HeaderTelemetryEndpointAuth System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.HeaderTelemetryEndpointAuth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.HeaderTelemetryEndpointAuth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.HeaderTelemetryEndpointAuth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HostedAgentDefinition : Azure.AI.AgentServer.Responses.Models.AgentDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.HostedAgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.HostedAgentDefinition>
    {
        public HostedAgentDefinition(string cpu, string memory) { }
        public Azure.AI.AgentServer.Responses.Models.CodeConfiguration CodeConfiguration { get { throw null; } set { } }
        public Azure.AI.AgentServer.Responses.Models.ContainerConfiguration ContainerConfiguration { get { throw null; } set { } }
        public string Cpu { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } }
        public string Memory { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.ProtocolVersionRecord> ProtocolVersions { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.TelemetryConfig TelemetryConfig { get { throw null; } set { } }
        protected override Azure.AI.AgentServer.Responses.Models.AgentDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.AgentDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.HostedAgentDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.HostedAgentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.HostedAgentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.HostedAgentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.HostedAgentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.HostedAgentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.HostedAgentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ImageDetail
    {
        Low = 0,
        High = 1,
        Auto = 2,
        Original = 3,
    }
    public partial class InputFileContentParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.InputFileContentParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InputFileContentParam>
    {
        internal InputFileContentParam() { }
        public string FileData { get { throw null; } }
        public string FileId { get { throw null; } }
        public string Filename { get { throw null; } }
        public System.Uri FileUrl { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.InputFileContentParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.InputFileContentParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.InputFileContentParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.InputFileContentParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.InputFileContentParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.InputFileContentParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InputFileContentParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InputFileContentParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InputFileContentParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InputImageContentParamAutoParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.InputImageContentParamAutoParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InputImageContentParamAutoParam>
    {
        internal InputImageContentParamAutoParam() { }
        public Azure.AI.AgentServer.Responses.Models.DetailEnum? Detail { get { throw null; } }
        public string FileId { get { throw null; } }
        public System.Uri ImageUrl { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.InputImageContentParamAutoParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.InputImageContentParamAutoParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.InputImageContentParamAutoParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.InputImageContentParamAutoParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.InputImageContentParamAutoParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.InputImageContentParamAutoParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InputImageContentParamAutoParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InputImageContentParamAutoParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InputImageContentParamAutoParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InputTextContentParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.InputTextContentParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InputTextContentParam>
    {
        internal InputTextContentParam() { }
        public string Text { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.InputTextContentParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.InputTextContentParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.InputTextContentParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.InputTextContentParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.InputTextContentParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.InputTextContentParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InputTextContentParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InputTextContentParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InputTextContentParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InvocationsProtocolConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.InvocationsProtocolConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InvocationsProtocolConfiguration>
    {
        public InvocationsProtocolConfiguration() { }
        protected virtual Azure.AI.AgentServer.Responses.Models.InvocationsProtocolConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.InvocationsProtocolConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.InvocationsProtocolConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.InvocationsProtocolConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.InvocationsProtocolConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.InvocationsProtocolConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InvocationsProtocolConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InvocationsProtocolConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InvocationsProtocolConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InvocationsWsProtocolConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.InvocationsWsProtocolConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InvocationsWsProtocolConfiguration>
    {
        public InvocationsWsProtocolConfiguration() { }
        protected virtual Azure.AI.AgentServer.Responses.Models.InvocationsWsProtocolConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.InvocationsWsProtocolConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.InvocationsWsProtocolConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.InvocationsWsProtocolConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.InvocationsWsProtocolConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.InvocationsWsProtocolConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InvocationsWsProtocolConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InvocationsWsProtocolConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InvocationsWsProtocolConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ItemCodeInterpreterToolCallStatus
    {
        InProgress = 0,
        Completed = 1,
        Incomplete = 2,
        Interpreting = 3,
        Failed = 4,
    }
    public enum ItemComputerToolCallStatus
    {
        InProgress = 0,
        Completed = 1,
        Incomplete = 2,
    }
    public static partial class ItemExtensions
    {
        public static string GetInputText(this System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> items) { throw null; }
    }
    public abstract partial class ItemField : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemField>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemField>
    {
        internal ItemField() { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ItemField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ItemField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ItemField System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemField>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemField>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ItemField System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemField>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemField>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemField>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ItemFieldApplyPatchToolCall : Azure.AI.AgentServer.Responses.Models.ItemField, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldApplyPatchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldApplyPatchToolCall>
    {
        internal ItemFieldApplyPatchToolCall() { }
        public string CallId { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.ApplyPatchFileOperation Operation { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.ApplyPatchCallStatus Status { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ItemFieldApplyPatchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldApplyPatchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldApplyPatchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ItemFieldApplyPatchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldApplyPatchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldApplyPatchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldApplyPatchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ItemFieldApplyPatchToolCallOutput : Azure.AI.AgentServer.Responses.Models.ItemField, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldApplyPatchToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldApplyPatchToolCallOutput>
    {
        internal ItemFieldApplyPatchToolCallOutput() { }
        public string CallId { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public string Id { get { throw null; } }
        public string Output { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.ApplyPatchCallOutputStatus Status { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ItemFieldApplyPatchToolCallOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldApplyPatchToolCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldApplyPatchToolCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ItemFieldApplyPatchToolCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldApplyPatchToolCallOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldApplyPatchToolCallOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldApplyPatchToolCallOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ItemFieldCodeInterpreterToolCall : Azure.AI.AgentServer.Responses.Models.ItemField, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldCodeInterpreterToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldCodeInterpreterToolCall>
    {
        internal ItemFieldCodeInterpreterToolCall() { }
        public string Code { get { throw null; } }
        public string ContainerId { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IList<System.BinaryData> Outputs { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.ItemCodeInterpreterToolCallStatus Status { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ItemFieldCodeInterpreterToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldCodeInterpreterToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldCodeInterpreterToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ItemFieldCodeInterpreterToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldCodeInterpreterToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldCodeInterpreterToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldCodeInterpreterToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ItemFieldCompactionBody : Azure.AI.AgentServer.Responses.Models.ItemField, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldCompactionBody>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldCompactionBody>
    {
        internal ItemFieldCompactionBody() { }
        public string CreatedBy { get { throw null; } }
        public string EncryptedContent { get { throw null; } }
        public string Id { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ItemFieldCompactionBody System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldCompactionBody>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldCompactionBody>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ItemFieldCompactionBody System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldCompactionBody>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldCompactionBody>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldCompactionBody>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ItemFieldComputerToolCall : Azure.AI.AgentServer.Responses.Models.ItemField, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldComputerToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldComputerToolCall>
    {
        internal ItemFieldComputerToolCall() { }
        public Azure.AI.AgentServer.Responses.Models.ComputerAction Action { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.ComputerAction> Actions { get { throw null; } }
        public string CallId { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.ComputerCallSafetyCheckParam> PendingSafetyChecks { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.ItemComputerToolCallStatus Status { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ItemFieldComputerToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldComputerToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldComputerToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ItemFieldComputerToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldComputerToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldComputerToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldComputerToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ItemFieldComputerToolCallOutput : Azure.AI.AgentServer.Responses.Models.ItemField, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldComputerToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldComputerToolCallOutput>
    {
        internal ItemFieldComputerToolCallOutput() { }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.ComputerCallSafetyCheckParam> AcknowledgedSafetyChecks { get { throw null; } }
        public string CallId { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.ComputerScreenshotImage Output { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.ItemFieldComputerToolCallOutputStatus? Status { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ItemFieldComputerToolCallOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldComputerToolCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldComputerToolCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ItemFieldComputerToolCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldComputerToolCallOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldComputerToolCallOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldComputerToolCallOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ItemFieldComputerToolCallOutputStatus
    {
        InProgress = 0,
        Completed = 1,
        Incomplete = 2,
    }
    public partial class ItemFieldCustomToolCall : Azure.AI.AgentServer.Responses.Models.ItemField, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldCustomToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldCustomToolCall>
    {
        internal ItemFieldCustomToolCall() { }
        public string CallId { get { throw null; } }
        public string Id { get { throw null; } }
        public string Input { get { throw null; } }
        public string Name { get { throw null; } }
        public string Namespace { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ItemFieldCustomToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldCustomToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldCustomToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ItemFieldCustomToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldCustomToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldCustomToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldCustomToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ItemFieldCustomToolCallOutput : Azure.AI.AgentServer.Responses.Models.ItemField, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldCustomToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldCustomToolCallOutput>
    {
        internal ItemFieldCustomToolCallOutput() { }
        public string CallId { get { throw null; } }
        public string Id { get { throw null; } }
        public System.BinaryData Output { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ItemFieldCustomToolCallOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldCustomToolCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldCustomToolCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ItemFieldCustomToolCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldCustomToolCallOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldCustomToolCallOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldCustomToolCallOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ItemFieldFileSearchToolCall : Azure.AI.AgentServer.Responses.Models.ItemField, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFileSearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFileSearchToolCall>
    {
        internal ItemFieldFileSearchToolCall() { }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IList<string> Queries { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.FileSearchToolCallResults> Results { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.ItemFileSearchToolCallStatus Status { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ItemFieldFileSearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFileSearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFileSearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ItemFieldFileSearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFileSearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFileSearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFileSearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ItemFieldFunctionShellCall : Azure.AI.AgentServer.Responses.Models.ItemField, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionShellCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionShellCall>
    {
        internal ItemFieldFunctionShellCall() { }
        public Azure.AI.AgentServer.Responses.Models.FunctionShellAction Action { get { throw null; } }
        public string CallId { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.FunctionShellCallEnvironment Environment { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.LocalShellCallStatus Status { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionShellCall System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionShellCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionShellCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionShellCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionShellCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionShellCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionShellCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ItemFieldFunctionShellCallOutput : Azure.AI.AgentServer.Responses.Models.ItemField, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionShellCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionShellCallOutput>
    {
        internal ItemFieldFunctionShellCallOutput() { }
        public string CallId { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public string Id { get { throw null; } }
        public long? MaxOutputLength { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputContent> Output { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.LocalShellCallOutputStatusEnum Status { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionShellCallOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionShellCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionShellCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionShellCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionShellCallOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionShellCallOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionShellCallOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ItemFieldFunctionToolCall : Azure.AI.AgentServer.Responses.Models.ItemField, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionToolCall>
    {
        internal ItemFieldFunctionToolCall() { }
        public string Arguments { get { throw null; } }
        public string CallId { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Namespace { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.ItemFunctionToolCallStatus? Status { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ItemFieldFunctionToolCallOutput : Azure.AI.AgentServer.Responses.Models.ItemField, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionToolCallOutput>
    {
        internal ItemFieldFunctionToolCallOutput() { }
        public string CallId { get { throw null; } }
        public string Id { get { throw null; } }
        public System.BinaryData Output { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionToolCallOutputStatus? Status { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionToolCallOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionToolCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionToolCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionToolCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionToolCallOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionToolCallOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldFunctionToolCallOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ItemFieldFunctionToolCallOutputStatus
    {
        InProgress = 0,
        Completed = 1,
        Incomplete = 2,
    }
    public partial class ItemFieldImageGenToolCall : Azure.AI.AgentServer.Responses.Models.ItemField, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldImageGenToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldImageGenToolCall>
    {
        internal ItemFieldImageGenToolCall() { }
        public string Id { get { throw null; } }
        public string Result { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.ItemImageGenToolCallStatus Status { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ItemFieldImageGenToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldImageGenToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldImageGenToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ItemFieldImageGenToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldImageGenToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldImageGenToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldImageGenToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ItemFieldLocalShellToolCall : Azure.AI.AgentServer.Responses.Models.ItemField, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldLocalShellToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldLocalShellToolCall>
    {
        internal ItemFieldLocalShellToolCall() { }
        public Azure.AI.AgentServer.Responses.Models.LocalShellExecAction Action { get { throw null; } }
        public string CallId { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.ItemLocalShellToolCallStatus Status { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ItemFieldLocalShellToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldLocalShellToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldLocalShellToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ItemFieldLocalShellToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldLocalShellToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldLocalShellToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldLocalShellToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ItemFieldLocalShellToolCallOutput : Azure.AI.AgentServer.Responses.Models.ItemField, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldLocalShellToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldLocalShellToolCallOutput>
    {
        internal ItemFieldLocalShellToolCallOutput() { }
        public string Id { get { throw null; } }
        public string Output { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.ItemLocalShellToolCallOutputStatus? Status { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ItemFieldLocalShellToolCallOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldLocalShellToolCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldLocalShellToolCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ItemFieldLocalShellToolCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldLocalShellToolCallOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldLocalShellToolCallOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldLocalShellToolCallOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ItemFieldMcpApprovalRequest : Azure.AI.AgentServer.Responses.Models.ItemField, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMcpApprovalRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMcpApprovalRequest>
    {
        internal ItemFieldMcpApprovalRequest() { }
        public string Arguments { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string ServerLabel { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ItemFieldMcpApprovalRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMcpApprovalRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMcpApprovalRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ItemFieldMcpApprovalRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMcpApprovalRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMcpApprovalRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMcpApprovalRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ItemFieldMcpApprovalResponseResource : Azure.AI.AgentServer.Responses.Models.ItemField, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMcpApprovalResponseResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMcpApprovalResponseResource>
    {
        internal ItemFieldMcpApprovalResponseResource() { }
        public string ApprovalRequestId { get { throw null; } }
        public bool Approve { get { throw null; } }
        public string Id { get { throw null; } }
        public string Reason { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ItemFieldMcpApprovalResponseResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMcpApprovalResponseResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMcpApprovalResponseResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ItemFieldMcpApprovalResponseResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMcpApprovalResponseResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMcpApprovalResponseResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMcpApprovalResponseResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ItemFieldMcpListTools : Azure.AI.AgentServer.Responses.Models.ItemField, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMcpListTools>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMcpListTools>
    {
        internal ItemFieldMcpListTools() { }
        public Azure.AI.AgentServer.Responses.Models.RealtimeMCPError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string ServerLabel { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.MCPListToolsTool> Tools { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ItemFieldMcpListTools System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMcpListTools>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMcpListTools>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ItemFieldMcpListTools System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMcpListTools>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMcpListTools>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMcpListTools>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ItemFieldMcpToolCall : Azure.AI.AgentServer.Responses.Models.ItemField, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMcpToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMcpToolCall>
    {
        internal ItemFieldMcpToolCall() { }
        public string ApprovalRequestId { get { throw null; } }
        public string Arguments { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Output { get { throw null; } }
        public string ServerLabel { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.MCPToolCallStatus? Status { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ItemFieldMcpToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMcpToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMcpToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ItemFieldMcpToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMcpToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMcpToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMcpToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ItemFieldMessage : Azure.AI.AgentServer.Responses.Models.ItemField, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMessage>
    {
        internal ItemFieldMessage() { }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.MessageContent> Content { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.MessagePhase? Phase { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.MessageRole Role { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.MessageStatus? Status { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ItemFieldMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ItemFieldMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ItemFieldReasoningItem : Azure.AI.AgentServer.Responses.Models.ItemField, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldReasoningItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldReasoningItem>
    {
        internal ItemFieldReasoningItem() { }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.ReasoningTextContent> Content { get { throw null; } }
        public string EncryptedContent { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.ItemReasoningItemStatus? Status { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.SummaryTextContent> Summary { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ItemFieldReasoningItem System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldReasoningItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldReasoningItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ItemFieldReasoningItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldReasoningItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldReasoningItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldReasoningItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ItemFieldToolSearchCall : Azure.AI.AgentServer.Responses.Models.ItemField, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldToolSearchCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldToolSearchCall>
    {
        internal ItemFieldToolSearchCall() { }
        public System.BinaryData Arguments { get { throw null; } }
        public string CallId { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.ToolSearchExecutionType Execution { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.FunctionCallStatus Status { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ItemFieldToolSearchCall System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldToolSearchCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldToolSearchCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ItemFieldToolSearchCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldToolSearchCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldToolSearchCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldToolSearchCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ItemFieldToolSearchOutput : Azure.AI.AgentServer.Responses.Models.ItemField, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldToolSearchOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldToolSearchOutput>
    {
        internal ItemFieldToolSearchOutput() { }
        public string CallId { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.ToolSearchExecutionType Execution { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.FunctionCallOutputStatusEnum Status { get { throw null; } }
        public System.Collections.Generic.IList<OpenAI.Responses.ResponseTool> Tools { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ItemFieldToolSearchOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldToolSearchOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldToolSearchOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ItemFieldToolSearchOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldToolSearchOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldToolSearchOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldToolSearchOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ItemFieldWebSearchToolCall : Azure.AI.AgentServer.Responses.Models.ItemField, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldWebSearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldWebSearchToolCall>
    {
        internal ItemFieldWebSearchToolCall() { }
        public System.BinaryData Action { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.ItemWebSearchToolCallStatus Status { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ItemField PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ItemFieldWebSearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldWebSearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ItemFieldWebSearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ItemFieldWebSearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldWebSearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldWebSearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ItemFieldWebSearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ItemFileSearchToolCallStatus
    {
        InProgress = 0,
        Searching = 1,
        Completed = 2,
        Incomplete = 3,
        Failed = 4,
    }
    public enum ItemFunctionToolCallStatus
    {
        InProgress = 0,
        Completed = 1,
        Incomplete = 2,
    }
    public enum ItemImageGenToolCallStatus
    {
        InProgress = 0,
        Completed = 1,
        Generating = 2,
        Failed = 3,
    }
    public enum ItemLocalShellToolCallOutputStatus
    {
        InProgress = 0,
        Completed = 1,
        Incomplete = 2,
    }
    public enum ItemLocalShellToolCallStatus
    {
        InProgress = 0,
        Completed = 1,
        Incomplete = 2,
    }
    public static partial class ItemMessageExtensions
    {
        public static System.Collections.Generic.List<Azure.AI.AgentServer.Responses.Models.MessageContent> GetContentExpanded(this OpenAI.Responses.MessageResponseItem message) { throw null; }
    }
    public enum ItemReasoningItemStatus
    {
        InProgress = 0,
        Completed = 1,
        Incomplete = 2,
    }
    public enum ItemWebSearchToolCallStatus
    {
        InProgress = 0,
        Searching = 1,
        Completed = 2,
        Failed = 3,
    }
    public partial class KeyPressAction : Azure.AI.AgentServer.Responses.Models.ComputerAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.KeyPressAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.KeyPressAction>
    {
        internal KeyPressAction() { }
        public System.Collections.Generic.IList<string> Keys { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ComputerAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ComputerAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.KeyPressAction System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.KeyPressAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.KeyPressAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.KeyPressAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.KeyPressAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.KeyPressAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.KeyPressAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LocalEnvironmentResource : Azure.AI.AgentServer.Responses.Models.FunctionShellCallEnvironment, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.LocalEnvironmentResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.LocalEnvironmentResource>
    {
        internal LocalEnvironmentResource() { }
        protected override Azure.AI.AgentServer.Responses.Models.FunctionShellCallEnvironment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.FunctionShellCallEnvironment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.LocalEnvironmentResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.LocalEnvironmentResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.LocalEnvironmentResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.LocalEnvironmentResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.LocalEnvironmentResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.LocalEnvironmentResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.LocalEnvironmentResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum LocalShellCallOutputStatusEnum
    {
        InProgress = 0,
        Completed = 1,
        Incomplete = 2,
    }
    public enum LocalShellCallStatus
    {
        InProgress = 0,
        Completed = 1,
        Incomplete = 2,
    }
    public partial class LocalShellExecAction : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.LocalShellExecAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.LocalShellExecAction>
    {
        internal LocalShellExecAction() { }
        public System.Collections.Generic.IList<string> Command { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Env { get { throw null; } }
        public long? TimeoutMs { get { throw null; } }
        public string Type { get { throw null; } }
        public string User { get { throw null; } }
        public string WorkingDirectory { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.LocalShellExecAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.LocalShellExecAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.LocalShellExecAction System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.LocalShellExecAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.LocalShellExecAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.LocalShellExecAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.LocalShellExecAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.LocalShellExecAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.LocalShellExecAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LogProb : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.LogProb>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.LogProb>
    {
        internal LogProb() { }
        public System.Collections.Generic.IList<long> Bytes { get { throw null; } }
        public double Logprob { get { throw null; } }
        public string Token { get { throw null; } }
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
    public partial class ManagedAgentIdentityBlueprintReference : Azure.AI.AgentServer.Responses.Models.AgentBlueprintReference, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ManagedAgentIdentityBlueprintReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ManagedAgentIdentityBlueprintReference>
    {
        public ManagedAgentIdentityBlueprintReference(string blueprintId) { }
        public string BlueprintId { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.AgentBlueprintReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.AgentBlueprintReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ManagedAgentIdentityBlueprintReference System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ManagedAgentIdentityBlueprintReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ManagedAgentIdentityBlueprintReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ManagedAgentIdentityBlueprintReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ManagedAgentIdentityBlueprintReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ManagedAgentIdentityBlueprintReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ManagedAgentIdentityBlueprintReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MCPListToolsTool : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MCPListToolsTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MCPListToolsTool>
    {
        internal MCPListToolsTool() { }
        public Azure.AI.AgentServer.Responses.Models.MCPListToolsToolAnnotations Annotations { get { throw null; } }
        public string Description { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.MCPListToolsToolInputSchema InputSchema { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.MCPListToolsTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.MCPListToolsTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.MCPListToolsTool System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MCPListToolsTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MCPListToolsTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.MCPListToolsTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MCPListToolsTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MCPListToolsTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MCPListToolsTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MCPListToolsToolAnnotations : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MCPListToolsToolAnnotations>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MCPListToolsToolAnnotations>
    {
        internal MCPListToolsToolAnnotations() { }
        protected virtual Azure.AI.AgentServer.Responses.Models.MCPListToolsToolAnnotations JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.MCPListToolsToolAnnotations PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.MCPListToolsToolAnnotations System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MCPListToolsToolAnnotations>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MCPListToolsToolAnnotations>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.MCPListToolsToolAnnotations System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MCPListToolsToolAnnotations>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MCPListToolsToolAnnotations>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MCPListToolsToolAnnotations>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MCPListToolsToolInputSchema : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MCPListToolsToolInputSchema>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MCPListToolsToolInputSchema>
    {
        internal MCPListToolsToolInputSchema() { }
        protected virtual Azure.AI.AgentServer.Responses.Models.MCPListToolsToolInputSchema JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.MCPListToolsToolInputSchema PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.MCPListToolsToolInputSchema System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MCPListToolsToolInputSchema>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MCPListToolsToolInputSchema>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.MCPListToolsToolInputSchema System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MCPListToolsToolInputSchema>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MCPListToolsToolInputSchema>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MCPListToolsToolInputSchema>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class McpProtocolConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.McpProtocolConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.McpProtocolConfiguration>
    {
        public McpProtocolConfiguration() { }
        protected virtual Azure.AI.AgentServer.Responses.Models.McpProtocolConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.McpProtocolConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.McpProtocolConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.McpProtocolConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.McpProtocolConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.McpProtocolConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.McpProtocolConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.McpProtocolConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.McpProtocolConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum MCPToolCallStatus
    {
        InProgress = 0,
        Completed = 1,
        Incomplete = 2,
        Calling = 3,
        Failed = 4,
    }
    public partial class MCPToolFilter : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MCPToolFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MCPToolFilter>
    {
        internal MCPToolFilter() { }
        public bool? ReadOnly { get { throw null; } }
        public System.Collections.Generic.IList<string> ToolNames { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.MCPToolFilter JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.MCPToolFilter PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.MCPToolFilter System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MCPToolFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MCPToolFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.MCPToolFilter System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MCPToolFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MCPToolFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MCPToolFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MCPToolRequireApproval : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MCPToolRequireApproval>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MCPToolRequireApproval>
    {
        internal MCPToolRequireApproval() { }
        public Azure.AI.AgentServer.Responses.Models.MCPToolFilter Always { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.MCPToolFilter Never { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.MCPToolRequireApproval JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.MCPToolRequireApproval PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.MCPToolRequireApproval System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MCPToolRequireApproval>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MCPToolRequireApproval>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.MCPToolRequireApproval System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MCPToolRequireApproval>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MCPToolRequireApproval>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MCPToolRequireApproval>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        internal MessageContentInputFileContent() { }
        public string FileData { get { throw null; } }
        public string FileId { get { throw null; } }
        public string Filename { get { throw null; } }
        public System.Uri FileUrl { get { throw null; } }
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
        internal MessageContentInputImageContent() { }
        public Azure.AI.AgentServer.Responses.Models.ImageDetail Detail { get { throw null; } }
        public string FileId { get { throw null; } }
        public System.Uri ImageUrl { get { throw null; } }
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
        internal MessageContentInputTextContent() { }
        public string Text { get { throw null; } }
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
    public partial class MessageContentOutputTextContent : Azure.AI.AgentServer.Responses.Models.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MessageContentOutputTextContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MessageContentOutputTextContent>
    {
        internal MessageContentOutputTextContent() { }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.Annotation> Annotations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.LogProb> Logprobs { get { throw null; } }
        public string Text { get { throw null; } }
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
        internal MessageContentReasoningTextContent() { }
        public string Text { get { throw null; } }
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
        internal MessageContentRefusalContent() { }
        public string Refusal { get { throw null; } }
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
    public enum MessagePhase
    {
        Commentary = 0,
        FinalAnswer = 1,
    }
    public enum MessageRole
    {
        Unknown = 0,
        User = 1,
        Assistant = 2,
        System = 3,
        Critic = 4,
        Discriminator = 5,
        Developer = 6,
        Tool = 7,
    }
    public enum MessageStatus
    {
        InProgress = 0,
        Completed = 1,
        Incomplete = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ModelIdsCompaction : System.IEquatable<Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ModelIdsCompaction(string value) { throw null; }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Chatgpt4oLatest { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction CodexMiniLatest { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction ComputerUsePreview { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction ComputerUsePreview20250311 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt35Turbo { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt35Turbo0125 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt35Turbo0301 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt35Turbo0613 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt35Turbo1106 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt35Turbo16k { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt35Turbo16k0613 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt4 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt40125Preview { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt40314 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt40613 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt41 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt41106Preview { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt4120250414 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt41Mini { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt41Mini20250414 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt41Nano { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt41Nano20250414 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt432k { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt432k0314 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt432k0613 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt4o { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt4o20240513 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt4o20240806 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt4o20241120 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt4oAudioPreview { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt4oAudioPreview20241001 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt4oAudioPreview20241217 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt4oAudioPreview20250603 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt4oMini { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt4oMini20240718 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt4oMiniAudioPreview { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt4oMiniAudioPreview20241217 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt4oMiniSearchPreview { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt4oMiniSearchPreview20250311 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt4oSearchPreview { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt4oSearchPreview20250311 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt4Turbo { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt4Turbo20240409 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt4TurboPreview { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt4VisionPreview { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt5 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt51 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt5120251113 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt51ChatLatest { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt51Codex { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt51CodexMax { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt51Mini { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt52 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt520250807 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt5220251211 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt52ChatLatest { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt52Pro { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt52Pro20251211 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt53ChatLatest { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt54 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt54Mini { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt54Mini20260317 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt54Nano { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt54Nano20260317 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt5ChatLatest { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt5Codex { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt5Mini { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt5Mini20250807 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt5Nano { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt5Nano20250807 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt5Pro { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction Gpt5Pro20251006 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction O1 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction O120241217 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction O1Mini { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction O1Mini20240912 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction O1Preview { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction O1Preview20240912 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction O1Pro { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction O1Pro20250319 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction O3 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction O320250416 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction O3DeepResearch { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction O3DeepResearch20250626 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction O3Mini { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction O3Mini20250131 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction O3Pro { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction O3Pro20250610 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction O4Mini { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction O4Mini20250416 { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction O4MiniDeepResearch { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction O4MiniDeepResearch20250626 { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction left, Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction (string value) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction? (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction left, Azure.AI.AgentServer.Responses.Models.ModelIdsCompaction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MoveParam : Azure.AI.AgentServer.Responses.Models.ComputerAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MoveParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MoveParam>
    {
        internal MoveParam() { }
        public System.Collections.Generic.IList<string> Keys { get { throw null; } }
        public long X { get { throw null; } }
        public long Y { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ComputerAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ComputerAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.MoveParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MoveParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MoveParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.MoveParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MoveParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MoveParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MoveParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OtlpTelemetryEndpoint : Azure.AI.AgentServer.Responses.Models.TelemetryEndpoint, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.OtlpTelemetryEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.OtlpTelemetryEndpoint>
    {
        public OtlpTelemetryEndpoint(System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Responses.Models.TelemetryDataKind> data, string endpoint, Azure.AI.AgentServer.Responses.Models.TelemetryTransportProtocol protocol) { }
        public string Endpoint { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.TelemetryTransportProtocol Protocol { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.TelemetryEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.TelemetryEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.OtlpTelemetryEndpoint System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.OtlpTelemetryEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.OtlpTelemetryEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.OtlpTelemetryEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.OtlpTelemetryEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.OtlpTelemetryEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.OtlpTelemetryEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class OutputItemExtensions
    {
        public static string GetId(this OpenAI.Responses.ResponseItem item) { throw null; }
    }
    public partial class PromptAgentDefinition : Azure.AI.AgentServer.Responses.Models.AgentDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.PromptAgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.PromptAgentDefinition>
    {
        public PromptAgentDefinition(string model) { }
        public string Instructions { get { throw null; } set { } }
        public string Model { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.Reasoning Reasoning { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.AgentServer.Responses.Models.StructuredInputDefinition> StructuredInputs { get { throw null; } }
        public float? Temperature { get { throw null; } set { } }
        public Azure.AI.AgentServer.Responses.Models.PromptAgentDefinitionTextOptions Text { get { throw null; } set { } }
        public System.BinaryData ToolChoice { get { throw null; } set { } }
        public System.Collections.Generic.IList<OpenAI.Responses.ResponseTool> Tools { get { throw null; } }
        public float? TopP { get { throw null; } set { } }
        protected override Azure.AI.AgentServer.Responses.Models.AgentDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.AgentDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.PromptAgentDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.PromptAgentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.PromptAgentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.PromptAgentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.PromptAgentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.PromptAgentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.PromptAgentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum PromptAgentDefinitionReasoningEffort
    {
        None = 0,
        Minimal = 1,
        Low = 2,
        Medium = 3,
        High = 4,
        Xhigh = 5,
    }
    public enum PromptAgentDefinitionReasoningGenerateSummary
    {
        Auto = 0,
        Concise = 1,
        Detailed = 2,
    }
    public enum PromptAgentDefinitionReasoningSummary
    {
        Auto = 0,
        Concise = 1,
        Detailed = 2,
    }
    public partial class PromptAgentDefinitionTextOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.PromptAgentDefinitionTextOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.PromptAgentDefinitionTextOptions>
    {
        public PromptAgentDefinitionTextOptions() { }
        public Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfiguration Format { get { throw null; } set { } }
        protected virtual Azure.AI.AgentServer.Responses.Models.PromptAgentDefinitionTextOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.PromptAgentDefinitionTextOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.PromptAgentDefinitionTextOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.PromptAgentDefinitionTextOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.PromptAgentDefinitionTextOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.PromptAgentDefinitionTextOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.PromptAgentDefinitionTextOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.PromptAgentDefinitionTextOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.PromptAgentDefinitionTextOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProtocolConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ProtocolConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ProtocolConfiguration>
    {
        public ProtocolConfiguration() { }
        public Azure.AI.AgentServer.Responses.Models.A2AProtocolConfiguration A2a { get { throw null; } set { } }
        public Azure.AI.AgentServer.Responses.Models.ActivityProtocolConfiguration Activity { get { throw null; } set { } }
        public Azure.AI.AgentServer.Responses.Models.InvocationsProtocolConfiguration Invocations { get { throw null; } set { } }
        public Azure.AI.AgentServer.Responses.Models.InvocationsWsProtocolConfiguration InvocationsWs { get { throw null; } set { } }
        public Azure.AI.AgentServer.Responses.Models.McpProtocolConfiguration Mcp { get { throw null; } set { } }
        public Azure.AI.AgentServer.Responses.Models.ResponsesProtocolConfiguration Responses { get { throw null; } set { } }
        protected virtual Azure.AI.AgentServer.Responses.Models.ProtocolConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ProtocolConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ProtocolConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ProtocolConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ProtocolConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ProtocolConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ProtocolConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ProtocolConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ProtocolConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProtocolVersionRecord : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ProtocolVersionRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ProtocolVersionRecord>
    {
        public ProtocolVersionRecord(Azure.AI.AgentServer.Responses.Models.AgentEndpointProtocol protocol, string version) { }
        public Azure.AI.AgentServer.Responses.Models.AgentEndpointProtocol Protocol { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.ProtocolVersionRecord JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ProtocolVersionRecord PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ProtocolVersionRecord System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ProtocolVersionRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ProtocolVersionRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ProtocolVersionRecord System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ProtocolVersionRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ProtocolVersionRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ProtocolVersionRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RaiConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.RaiConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.RaiConfig>
    {
        public RaiConfig(string raiPolicyName) { }
        public string RaiPolicyName { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.RaiConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.RaiConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.RaiConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.RaiConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.RaiConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.RaiConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.RaiConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.RaiConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.RaiConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RealtimeMCPError : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.RealtimeMCPError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.RealtimeMCPError>
    {
        internal RealtimeMCPError() { }
        protected virtual Azure.AI.AgentServer.Responses.Models.RealtimeMCPError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.RealtimeMCPError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.RealtimeMCPError System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.RealtimeMCPError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.RealtimeMCPError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.RealtimeMCPError System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.RealtimeMCPError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.RealtimeMCPError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.RealtimeMCPError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RealtimeMCPHTTPError : Azure.AI.AgentServer.Responses.Models.RealtimeMCPError, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.RealtimeMCPHTTPError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.RealtimeMCPHTTPError>
    {
        internal RealtimeMCPHTTPError() { }
        public long Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.RealtimeMCPError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.RealtimeMCPError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.RealtimeMCPHTTPError System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.RealtimeMCPHTTPError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.RealtimeMCPHTTPError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.RealtimeMCPHTTPError System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.RealtimeMCPHTTPError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.RealtimeMCPHTTPError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.RealtimeMCPHTTPError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RealtimeMCPProtocolError : Azure.AI.AgentServer.Responses.Models.RealtimeMCPError, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.RealtimeMCPProtocolError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.RealtimeMCPProtocolError>
    {
        internal RealtimeMCPProtocolError() { }
        public long Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.RealtimeMCPError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.RealtimeMCPError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.RealtimeMCPProtocolError System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.RealtimeMCPProtocolError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.RealtimeMCPProtocolError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.RealtimeMCPProtocolError System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.RealtimeMCPProtocolError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.RealtimeMCPProtocolError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.RealtimeMCPProtocolError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RealtimeMCPToolExecutionError : Azure.AI.AgentServer.Responses.Models.RealtimeMCPError, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.RealtimeMCPToolExecutionError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.RealtimeMCPToolExecutionError>
    {
        internal RealtimeMCPToolExecutionError() { }
        public string Message { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.RealtimeMCPError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.RealtimeMCPError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.RealtimeMCPToolExecutionError System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.RealtimeMCPToolExecutionError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.RealtimeMCPToolExecutionError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.RealtimeMCPToolExecutionError System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.RealtimeMCPToolExecutionError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.RealtimeMCPToolExecutionError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.RealtimeMCPToolExecutionError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Reasoning : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.Reasoning>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.Reasoning>
    {
        public Reasoning() { }
        public Azure.AI.AgentServer.Responses.Models.PromptAgentDefinitionReasoningEffort? Effort { get { throw null; } set { } }
        public Azure.AI.AgentServer.Responses.Models.PromptAgentDefinitionReasoningGenerateSummary? GenerateSummary { get { throw null; } set { } }
        public Azure.AI.AgentServer.Responses.Models.PromptAgentDefinitionReasoningSummary? Summary { get { throw null; } set { } }
        protected virtual Azure.AI.AgentServer.Responses.Models.Reasoning JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.Reasoning PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.Reasoning System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.Reasoning>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.Reasoning>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.Reasoning System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.Reasoning>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.Reasoning>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.Reasoning>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ReasoningTextContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ReasoningTextContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ReasoningTextContent>
    {
        internal ReasoningTextContent() { }
        public string Text { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.ReasoningTextContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ReasoningTextContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ReasoningTextContent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ReasoningTextContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ReasoningTextContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ReasoningTextContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ReasoningTextContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ReasoningTextContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ReasoningTextContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemoteToolChoiceParam : Azure.AI.AgentServer.Responses.Models.ToolChoiceParam, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.RemoteToolChoiceParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.RemoteToolChoiceParam>
    {
        public RemoteToolChoiceParam(string name) { }
        public string Name { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ToolChoiceParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.RemoteToolChoiceParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.RemoteToolChoiceParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.RemoteToolChoiceParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.RemoteToolChoiceParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.RemoteToolChoiceParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.RemoteToolChoiceParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.RemoteToolChoiceParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ResponseExtensions
    {
        public static System.Collections.Generic.List<OpenAI.Responses.ResponseItem> GetInstructionItems(this Azure.AI.AgentServer.Responses.Models.ResponseObject response) { throw null; }
        public static Azure.AI.AgentServer.Responses.Models.ToolChoiceParam? GetToolChoiceExpanded(this Azure.AI.AgentServer.Responses.Models.ResponseObject response) { throw null; }
        public static void SetInstructions(this Azure.AI.AgentServer.Responses.Models.ResponseObject response, System.Collections.Generic.IList<OpenAI.Responses.ResponseItem> items) { }
        public static void SetInstructions(this Azure.AI.AgentServer.Responses.Models.ResponseObject response, string instructions) { }
        public static void SetToolChoice(this Azure.AI.AgentServer.Responses.Models.ResponseObject response, Azure.AI.AgentServer.Responses.Models.ToolChoiceParam toolChoice) { }
        public static void SetToolChoice(this Azure.AI.AgentServer.Responses.Models.ResponseObject response, OpenAI.Responses.ResponseToolChoice toolChoice) { }
    }
    public partial class ResponseFormatJsonSchemaSchema : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ResponseFormatJsonSchemaSchema>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponseFormatJsonSchemaSchema>
    {
        public ResponseFormatJsonSchemaSchema() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.ResponseFormatJsonSchemaSchema JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ResponseFormatJsonSchemaSchema PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ResponseFormatJsonSchemaSchema System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ResponseFormatJsonSchemaSchema>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ResponseFormatJsonSchemaSchema>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ResponseFormatJsonSchemaSchema System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponseFormatJsonSchemaSchema>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponseFormatJsonSchemaSchema>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponseFormatJsonSchemaSchema>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponseObject : OpenAI.Responses.ResponseResult
    {
        public ResponseObject(string id, string model) { }
        public Azure.AI.Extensions.OpenAI.AgentReference? AgentReference { get { throw null; } set { } }
        public string? AgentSessionId { get { throw null; } set { } }
        public bool? Background { get { throw null; } set { } }
        public System.DateTimeOffset? CompletedAt { get { throw null; } set { } }
        public Azure.AI.AgentServer.Responses.Models.ConversationParam? Conversation { get { throw null; } set { } }
        public OpenAI.Responses.ResponseIncompleteStatusDetails? IncompleteDetails { get { throw null; } set { } }
        public new System.BinaryData? Instructions { get { throw null; } set { } }
        public int? MaxOutputTokens { get { throw null; } set { } }
        public new System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public System.Collections.Generic.IList<OpenAI.Responses.ResponseItem> Output { get { throw null; } }
        public bool ParallelToolCalls { get { throw null; } set { } }
        public new System.BinaryData? ToolChoice { get { throw null; } set { } }
    }
    public static partial class ResponsesModelFactory
    {
        public static Azure.AI.AgentServer.Responses.Models.AgentsPagedResultOutputItem AgentsPagedResultOutputItem(System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> data = null, string firstId = null, string lastId = null, bool hasMore = false) { throw null; }
        public static OpenAI.Responses.ResponseDeletionResult DeleteResponseResult(string id = null) { throw null; }
        public static OpenAI.Responses.StreamingResponseCreatedUpdate ResponseCreatedEvent(Azure.AI.AgentServer.Responses.Models.ResponseObject response = null, long sequenceNumber = (long)0) { throw null; }
        public static OpenAI.Responses.ResponseError ResponseErrorInfo(OpenAI.Responses.ResponseErrorCode code = default(OpenAI.Responses.ResponseErrorCode), string message = null) { throw null; }
        public static Azure.AI.AgentServer.Responses.Models.ResponseObject ResponseObject(string id = null, string model = null, OpenAI.Responses.ResponseStatus? status = default(OpenAI.Responses.ResponseStatus?), System.DateTimeOffset createdAt = default(System.DateTimeOffset), OpenAI.Responses.ResponseError error = null, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> output = null) { throw null; }
    }
    public static partial class ResponseSnapshotExtensions
    {
        public static Azure.AI.AgentServer.Responses.Models.ResponseObject Snapshot(this Azure.AI.AgentServer.Responses.Models.ResponseObject response) { throw null; }
        public static Azure.AI.AgentServer.Responses.Models.ResponseObject Snapshot(this OpenAI.Responses.ResponseResult response) { throw null; }
        public static void SnapshotEmbeddedResponse(this OpenAI.Responses.StreamingResponseUpdate evt, Azure.AI.AgentServer.Responses.Models.ResponseObject accumulator) { }
    }
    public partial class ResponsesProtocolConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ResponsesProtocolConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponsesProtocolConfiguration>
    {
        public ResponsesProtocolConfiguration() { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ResponsesProtocolConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ResponsesProtocolConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ResponsesProtocolConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ResponsesProtocolConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ResponsesProtocolConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ResponsesProtocolConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponsesProtocolConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponsesProtocolConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponsesProtocolConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponseUsage : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ResponseUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponseUsage>
    {
        internal ResponseUsage() { }
        public long InputTokens { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.ResponseUsageInputTokensDetails InputTokensDetails { get { throw null; } }
        public long OutputTokens { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.ResponseUsageOutputTokensDetails OutputTokensDetails { get { throw null; } }
        public long TotalTokens { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.ResponseUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ResponseUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ResponseUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ResponseUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ResponseUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ResponseUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponseUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponseUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponseUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponseUsageInputTokensDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ResponseUsageInputTokensDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponseUsageInputTokensDetails>
    {
        internal ResponseUsageInputTokensDetails() { }
        public long CachedTokens { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.ResponseUsageInputTokensDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ResponseUsageInputTokensDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ResponseUsageInputTokensDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ResponseUsageInputTokensDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ResponseUsageInputTokensDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ResponseUsageInputTokensDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponseUsageInputTokensDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponseUsageInputTokensDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponseUsageInputTokensDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponseUsageOutputTokensDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ResponseUsageOutputTokensDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponseUsageOutputTokensDetails>
    {
        internal ResponseUsageOutputTokensDetails() { }
        public long ReasoningTokens { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.ResponseUsageOutputTokensDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ResponseUsageOutputTokensDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ResponseUsageOutputTokensDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ResponseUsageOutputTokensDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ResponseUsageOutputTokensDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ResponseUsageOutputTokensDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponseUsageOutputTokensDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponseUsageOutputTokensDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponseUsageOutputTokensDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScreenshotParam : Azure.AI.AgentServer.Responses.Models.ComputerAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ScreenshotParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ScreenshotParam>
    {
        internal ScreenshotParam() { }
        protected override Azure.AI.AgentServer.Responses.Models.ComputerAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ComputerAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ScreenshotParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ScreenshotParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ScreenshotParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ScreenshotParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ScreenshotParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ScreenshotParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ScreenshotParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScrollParam : Azure.AI.AgentServer.Responses.Models.ComputerAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ScrollParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ScrollParam>
    {
        internal ScrollParam() { }
        public System.Collections.Generic.IList<string> Keys { get { throw null; } }
        public long ScrollX { get { throw null; } }
        public long ScrollY { get { throw null; } }
        public long X { get { throw null; } }
        public long Y { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ComputerAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ComputerAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ScrollParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ScrollParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ScrollParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ScrollParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ScrollParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ScrollParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ScrollParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class StructuredInputDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.StructuredInputDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.StructuredInputDefinition>
    {
        public StructuredInputDefinition() { }
        public System.BinaryData DefaultValue { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? Required { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Schema { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.StructuredInputDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.StructuredInputDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.StructuredInputDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.StructuredInputDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.StructuredInputDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.StructuredInputDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.StructuredInputDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.StructuredInputDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.StructuredInputDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SummaryTextContent : Azure.AI.AgentServer.Responses.Models.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.SummaryTextContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.SummaryTextContent>
    {
        internal SummaryTextContent() { }
        public string Text { get { throw null; } }
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
    public partial class TelemetryConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TelemetryConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TelemetryConfig>
    {
        public TelemetryConfig(System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Responses.Models.TelemetryEndpoint> endpoints) { }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.TelemetryEndpoint> Endpoints { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.TelemetryConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.TelemetryConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.TelemetryConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TelemetryConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TelemetryConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.TelemetryConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TelemetryConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TelemetryConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TelemetryConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelemetryDataKind : System.IEquatable<Azure.AI.AgentServer.Responses.Models.TelemetryDataKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelemetryDataKind(string value) { throw null; }
        public static Azure.AI.AgentServer.Responses.Models.TelemetryDataKind ContainerOtel { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.TelemetryDataKind ContainerStdoutStderr { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.TelemetryDataKind Metrics { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Responses.Models.TelemetryDataKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Responses.Models.TelemetryDataKind left, Azure.AI.AgentServer.Responses.Models.TelemetryDataKind right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Responses.Models.TelemetryDataKind (string value) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Responses.Models.TelemetryDataKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Responses.Models.TelemetryDataKind left, Azure.AI.AgentServer.Responses.Models.TelemetryDataKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class TelemetryEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TelemetryEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TelemetryEndpoint>
    {
        internal TelemetryEndpoint() { }
        public Azure.AI.AgentServer.Responses.Models.TelemetryEndpointAuth Auth { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.TelemetryDataKind> Data { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.TelemetryEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.TelemetryEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.TelemetryEndpoint System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TelemetryEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TelemetryEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.TelemetryEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TelemetryEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TelemetryEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TelemetryEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class TelemetryEndpointAuth : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TelemetryEndpointAuth>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TelemetryEndpointAuth>
    {
        internal TelemetryEndpointAuth() { }
        protected virtual Azure.AI.AgentServer.Responses.Models.TelemetryEndpointAuth JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.TelemetryEndpointAuth PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.TelemetryEndpointAuth System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TelemetryEndpointAuth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TelemetryEndpointAuth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.TelemetryEndpointAuth System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TelemetryEndpointAuth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TelemetryEndpointAuth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TelemetryEndpointAuth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TelemetryTransportProtocol : System.IEquatable<Azure.AI.AgentServer.Responses.Models.TelemetryTransportProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TelemetryTransportProtocol(string value) { throw null; }
        public static Azure.AI.AgentServer.Responses.Models.TelemetryTransportProtocol Grpc { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.TelemetryTransportProtocol Http { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Responses.Models.TelemetryTransportProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Responses.Models.TelemetryTransportProtocol left, Azure.AI.AgentServer.Responses.Models.TelemetryTransportProtocol right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Responses.Models.TelemetryTransportProtocol (string value) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Responses.Models.TelemetryTransportProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Responses.Models.TelemetryTransportProtocol left, Azure.AI.AgentServer.Responses.Models.TelemetryTransportProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TextContent : Azure.AI.AgentServer.Responses.Models.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TextContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TextContent>
    {
        internal TextContent() { }
        public string Text { get { throw null; } }
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
    public abstract partial class TextResponseFormatConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfiguration>
    {
        internal TextResponseFormatConfiguration() { }
        protected virtual Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextResponseFormatConfigurationResponseFormatJsonObject : Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfigurationResponseFormatJsonObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfigurationResponseFormatJsonObject>
    {
        public TextResponseFormatConfigurationResponseFormatJsonObject() { }
        protected override Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfigurationResponseFormatJsonObject System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfigurationResponseFormatJsonObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfigurationResponseFormatJsonObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfigurationResponseFormatJsonObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfigurationResponseFormatJsonObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfigurationResponseFormatJsonObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfigurationResponseFormatJsonObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextResponseFormatConfigurationResponseFormatText : Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfigurationResponseFormatText>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfigurationResponseFormatText>
    {
        public TextResponseFormatConfigurationResponseFormatText() { }
        protected override Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfigurationResponseFormatText System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfigurationResponseFormatText>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfigurationResponseFormatText>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfigurationResponseFormatText System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfigurationResponseFormatText>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfigurationResponseFormatText>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfigurationResponseFormatText>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextResponseFormatJsonSchema : Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfiguration, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TextResponseFormatJsonSchema>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TextResponseFormatJsonSchema>
    {
        public TextResponseFormatJsonSchema(string name, Azure.AI.AgentServer.Responses.Models.ResponseFormatJsonSchemaSchema schema) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.ResponseFormatJsonSchemaSchema Schema { get { throw null; } }
        public bool? Strict { get { throw null; } set { } }
        protected override Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.TextResponseFormatJsonSchema System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TextResponseFormatJsonSchema>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TextResponseFormatJsonSchema>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.TextResponseFormatJsonSchema System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TextResponseFormatJsonSchema>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TextResponseFormatJsonSchema>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TextResponseFormatJsonSchema>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolChoiceAllowed : Azure.AI.AgentServer.Responses.Models.ToolChoiceParam, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceAllowed>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ToolChoiceAllowed>
    {
        public ToolChoiceAllowed(Azure.AI.AgentServer.Responses.Models.ToolChoiceAllowedMode mode, System.Collections.Generic.IEnumerable<System.Collections.Generic.IDictionary<string, System.BinaryData>> tools) { }
        public Azure.AI.AgentServer.Responses.Models.ToolChoiceAllowedMode Mode { get { throw null; } }
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
        public string Name { get { throw null; } }
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
        public string Name { get { throw null; } }
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
        public string ServerLabel { get { throw null; } }
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
    public enum ToolSearchExecutionType
    {
        Server = 0,
        Client = 1,
    }
    public partial class TopLogProb : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TopLogProb>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TopLogProb>
    {
        internal TopLogProb() { }
        public System.Collections.Generic.IList<long> Bytes { get { throw null; } }
        public double Logprob { get { throw null; } }
        public string Token { get { throw null; } }
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
    public partial class TypeParam : Azure.AI.AgentServer.Responses.Models.ComputerAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TypeParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TypeParam>
    {
        internal TypeParam() { }
        public string Text { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.ComputerAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ComputerAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.TypeParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TypeParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.TypeParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.TypeParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TypeParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TypeParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.TypeParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateAgentFromManifestRequest : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.UpdateAgentFromManifestRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.UpdateAgentFromManifestRequest>
    {
        public UpdateAgentFromManifestRequest(string manifestId, System.Collections.Generic.IDictionary<string, System.BinaryData> parameterValues) { }
        public string Description { get { throw null; } set { } }
        public string ManifestId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ParameterValues { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.UpdateAgentFromManifestRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.UpdateAgentFromManifestRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.UpdateAgentFromManifestRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.UpdateAgentFromManifestRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.UpdateAgentFromManifestRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.UpdateAgentFromManifestRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.UpdateAgentFromManifestRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.UpdateAgentFromManifestRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.UpdateAgentFromManifestRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateAgentRequest : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.UpdateAgentRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.UpdateAgentRequest>
    {
        public UpdateAgentRequest(Azure.AI.AgentServer.Responses.Models.AgentDefinition definition) { }
        public Azure.AI.AgentServer.Responses.Models.AgentBlueprintReference BlueprintReference { get { throw null; } set { } }
        public Azure.AI.AgentServer.Responses.Models.AgentDefinition Definition { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.UpdateAgentRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.UpdateAgentRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.UpdateAgentRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.UpdateAgentRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.UpdateAgentRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.UpdateAgentRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.UpdateAgentRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.UpdateAgentRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.UpdateAgentRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateToolboxRequest : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.UpdateToolboxRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.UpdateToolboxRequest>
    {
        public UpdateToolboxRequest(string name, string defaultVersion) { }
        public string DefaultVersion { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.UpdateToolboxRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.UpdateToolboxRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.UpdateToolboxRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.UpdateToolboxRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.UpdateToolboxRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.UpdateToolboxRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.UpdateToolboxRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.UpdateToolboxRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.UpdateToolboxRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UrlCitationBody : Azure.AI.AgentServer.Responses.Models.Annotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.UrlCitationBody>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.UrlCitationBody>
    {
        internal UrlCitationBody() { }
        public long EndIndex { get { throw null; } }
        public long StartIndex { get { throw null; } }
        public string Title { get { throw null; } }
        public System.Uri Url { get { throw null; } }
        protected override Azure.AI.AgentServer.Responses.Models.Annotation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.Annotation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.UrlCitationBody System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.UrlCitationBody>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.UrlCitationBody>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.UrlCitationBody System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.UrlCitationBody>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.UrlCitationBody>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.UrlCitationBody>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreFileAttributes : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.VectorStoreFileAttributes>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.VectorStoreFileAttributes>
    {
        internal VectorStoreFileAttributes() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, bool> AdditionalBooleanProperties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, double> AdditionalDoubleProperties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> AdditionalProperties { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.VectorStoreFileAttributes JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.VectorStoreFileAttributes PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.VectorStoreFileAttributes System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.VectorStoreFileAttributes>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.VectorStoreFileAttributes>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.VectorStoreFileAttributes System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.VectorStoreFileAttributes>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.VectorStoreFileAttributes>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.VectorStoreFileAttributes>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class VersionSelectionRule : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.VersionSelectionRule>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.VersionSelectionRule>
    {
        internal VersionSelectionRule() { }
        public string AgentVersion { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.VersionSelectionRule JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.VersionSelectionRule PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.VersionSelectionRule System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.VersionSelectionRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.VersionSelectionRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.VersionSelectionRule System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.VersionSelectionRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.VersionSelectionRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.VersionSelectionRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VersionSelector : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.VersionSelector>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.VersionSelector>
    {
        public VersionSelector(System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Responses.Models.VersionSelectionRule> versionSelectionRules) { }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.VersionSelectionRule> VersionSelectionRules { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.VersionSelector JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.VersionSelector PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.VersionSelector System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.VersionSelector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.VersionSelector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.VersionSelector System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.VersionSelector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.VersionSelector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.VersionSelector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WaitParam : Azure.AI.AgentServer.Responses.Models.ComputerAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.WaitParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.WaitParam>
    {
        internal WaitParam() { }
        protected override Azure.AI.AgentServer.Responses.Models.ComputerAction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.ComputerAction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.WaitParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.WaitParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.WaitParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.WaitParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.WaitParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.WaitParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.WaitParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebSearchActionFind : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.WebSearchActionFind>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.WebSearchActionFind>
    {
        internal WebSearchActionFind() { }
        public string Pattern { get { throw null; } }
        public string Type { get { throw null; } }
        public System.Uri Url { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.WebSearchActionFind JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.WebSearchActionFind PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.WebSearchActionFind System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.WebSearchActionFind>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.WebSearchActionFind>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.WebSearchActionFind System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.WebSearchActionFind>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.WebSearchActionFind>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.WebSearchActionFind>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebSearchActionOpenPage : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.WebSearchActionOpenPage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.WebSearchActionOpenPage>
    {
        internal WebSearchActionOpenPage() { }
        public string Type { get { throw null; } }
        public System.Uri Url { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.WebSearchActionOpenPage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.WebSearchActionOpenPage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.WebSearchActionOpenPage System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.WebSearchActionOpenPage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.WebSearchActionOpenPage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.WebSearchActionOpenPage System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.WebSearchActionOpenPage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.WebSearchActionOpenPage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.WebSearchActionOpenPage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebSearchActionSearch : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.WebSearchActionSearch>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.WebSearchActionSearch>
    {
        internal WebSearchActionSearch() { }
        public System.Collections.Generic.IList<string> Queries { get { throw null; } }
        public string Query { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.WebSearchActionSearchSources> Sources { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.WebSearchActionSearch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.WebSearchActionSearch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.WebSearchActionSearch System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.WebSearchActionSearch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.WebSearchActionSearch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.WebSearchActionSearch System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.WebSearchActionSearch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.WebSearchActionSearch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.WebSearchActionSearch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WebSearchActionSearchSources : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.WebSearchActionSearchSources>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.WebSearchActionSearchSources>
    {
        internal WebSearchActionSearchSources() { }
        public string Type { get { throw null; } }
        public string Url { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.WebSearchActionSearchSources JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.WebSearchActionSearchSources PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.WebSearchActionSearchSources System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.WebSearchActionSearchSources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.WebSearchActionSearchSources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.WebSearchActionSearchSources System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.WebSearchActionSearchSources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.WebSearchActionSearchSources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.WebSearchActionSearchSources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkflowAgentDefinition : Azure.AI.AgentServer.Responses.Models.AgentDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.WorkflowAgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.WorkflowAgentDefinition>
    {
        public WorkflowAgentDefinition() { }
        public string Workflow { get { throw null; } set { } }
        protected override Azure.AI.AgentServer.Responses.Models.AgentDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.AgentServer.Responses.Models.AgentDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.WorkflowAgentDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.WorkflowAgentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.WorkflowAgentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.WorkflowAgentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.WorkflowAgentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.WorkflowAgentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.WorkflowAgentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
