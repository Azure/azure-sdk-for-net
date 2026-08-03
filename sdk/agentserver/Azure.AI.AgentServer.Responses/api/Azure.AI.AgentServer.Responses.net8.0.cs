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
        public virtual System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> TextContent(string text, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseMessageAnnotation> annotations) { throw null; }
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
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemApplyPatchCall(string callId, OpenAI.Responses.ApplyPatchCallStatus status, OpenAI.Responses.ApplyPatchOperation operation) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemApplyPatchCallOutput(string callId, OpenAI.Responses.ApplyPatchCallOutputStatus status) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemCompaction(string encryptedContent) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemComputerCall(string callId, OpenAI.Responses.ComputerCallAction action, System.Collections.Generic.IEnumerable<OpenAI.Responses.ComputerCallSafetyCheck> pendingSafetyChecks, OpenAI.Responses.ComputerCallStatus status) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemComputerCallOutput(string callId, OpenAI.Responses.ComputerCallOutput output) { throw null; }
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
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> OutputItemMessage(string text, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseMessageAnnotation> annotations) { throw null; }
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
        public System.Collections.Generic.IReadOnlyList<OpenAI.Responses.ResponseMessageAnnotation> Annotations { get { throw null; } }
        public long ContentIndex { get { throw null; } }
        public string? FinalText { get { throw null; } }
        public virtual OpenAI.Responses.StreamingResponseContentPartAddedUpdate EmitAdded() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputTextAnnotationAddedUpdate EmitAnnotationAdded(OpenAI.Responses.ResponseMessageAnnotation annotation) { throw null; }
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
    public partial class ApiErrorResponse
    {
        public ApiErrorResponse(Azure.AI.AgentServer.Responses.Models.Error error) { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("error")]
        public Azure.AI.AgentServer.Responses.Models.Error Error { get { throw null; } set { } }
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
    public partial class ConversationParam
    {
        public ConversationParam(string id) { }
        [System.Text.Json.Serialization.JsonPropertyNameAttribute("id")]
        public string Id { get { throw null; } set { } }
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
    public static partial class ItemExtensions
    {
        public static string GetInputText(this System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> items) { throw null; }
    }
    public static partial class ItemMessageExtensions
    {
        public static System.Collections.Generic.List<OpenAI.Responses.ResponseContentPart> GetContentExpanded(this OpenAI.Responses.MessageResponseItem message) { throw null; }
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
