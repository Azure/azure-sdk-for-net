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
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public sealed partial class CreateResponsePersistRequest
    {
        public CreateResponsePersistRequest(OpenAI.Responses.ResponseResult response, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem>? inputItems, System.Collections.Generic.IEnumerable<string>? historyItemIds) { }
        public System.Collections.Generic.IEnumerable<string> HistoryItemIds { get { throw null; } }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> InputItems { get { throw null; } }
        public OpenAI.Responses.ResponseResult Response { get { throw null; } }
    }
    public partial class CreateResponseResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.CreateResponseResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.CreateResponseResponse>
    {
        internal CreateResponseResponse() { }
        public Azure.AI.AgentServer.Responses.Models.AgentId Agent { get { throw null; } }
        public Azure.AI.Extensions.OpenAI.AgentReference AgentReference { get { throw null; } }
        public string AgentSessionId { get { throw null; } }
        public bool? Background { get { throw null; } }
        public System.DateTimeOffset? CompletedOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.ContentFilterResult> ContentFilters { get { throw null; } }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public OpenAI.Responses.ResponseConversationOptions Conversation { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public Azure.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.ResponseIncompleteDetails IncompleteDetails { get { throw null; } }
        public System.BinaryData Instructions { get { throw null; } }
        public long? MaxOutputTokens { get { throw null; } }
        public long? MaxToolCalls { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.Metadata Metadata { get { throw null; } }
        public string Model { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.ModelSelectionDetails ModelSelectionDetails { get { throw null; } }
        public string Object { get { throw null; } }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public System.Collections.Generic.IList<OpenAI.Responses.ResponseItem> Output { get { throw null; } }
        public string OutputText { get { throw null; } }
        public bool ParallelToolCalls { get { throw null; } }
        public string PreviousResponseId { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.Prompt Prompt { get { throw null; } }
        public string PromptCacheKey { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.CreateResponseRequestPromptCacheRetention? PromptCacheRetention { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.Reasoning Reasoning { get { throw null; } }
        public string SafetyIdentifier { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.CreateResponseRequestServiceTier? ServiceTier { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.CreateResponseResponseStatus? Status { get { throw null; } }
        public double? Temperature { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.ResponseTextParam Text { get { throw null; } }
        public System.BinaryData ToolChoice { get { throw null; } }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public System.Collections.Generic.IList<OpenAI.Responses.ResponseTool> Tools { get { throw null; } }
        public long? TopLogprobs { get { throw null; } }
        public double? TopP { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.CreateResponseRequestTruncation? Truncation { get { throw null; } }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public OpenAI.Responses.ResponseTokenUsage Usage { get { throw null; } }
        public string User { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.CreateResponseResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.AgentServer.Responses.CreateResponseResponse (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.AgentServer.Responses.CreateResponseResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.CreateResponseResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.CreateResponseResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.CreateResponseResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.CreateResponseResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.CreateResponseResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.CreateResponseResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.CreateResponseResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public partial class OutputItemBuilder<T> where T : OpenAI.Responses.ResponseItem
    {
        protected OutputItemBuilder() { }
        public string ItemId { get { throw null; } }
        public long OutputIndex { get { throw null; } }
        public virtual OpenAI.Responses.StreamingResponseOutputItemAddedUpdate EmitAdded(T item) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputItemDoneUpdate EmitDone(T item) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
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
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public partial class OutputItemCustomToolCallBuilder : Azure.AI.AgentServer.Responses.OutputItemBuilder<Azure.AI.AgentServer.Responses.Models.OutputItemCustomToolCall>
    {
        protected OutputItemCustomToolCallBuilder() { }
        public string CallId { get { throw null; } }
        public string Name { get { throw null; } }
        public virtual OpenAI.Responses.StreamingResponseOutputItemAddedUpdate EmitAdded() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputItemDoneUpdate EmitDone() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseUpdate EmitInputDelta(string delta) { throw null; }
        public virtual OpenAI.Responses.StreamingResponseUpdate EmitInputDone(string input) { throw null; }
        public System.Collections.Generic.IAsyncEnumerable<OpenAI.Responses.StreamingResponseUpdate> Input(System.Collections.Generic.IAsyncEnumerable<string> chunks, [System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> Input(string input) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public partial class OutputItemFileSearchCallBuilder : Azure.AI.AgentServer.Responses.OutputItemBuilder<OpenAI.Responses.FileSearchCallResponseItem>
    {
        protected OutputItemFileSearchCallBuilder() { }
        public virtual OpenAI.Responses.StreamingResponseOutputItemAddedUpdate EmitAdded() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseFileSearchCallCompletedUpdate EmitCompleted() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputItemDoneUpdate EmitDone() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseFileSearchCallInProgressUpdate EmitInProgress() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseFileSearchCallSearchingUpdate EmitSearching() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
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
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
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
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
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
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
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
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
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
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public partial class OutputItemReasoningItemBuilder : Azure.AI.AgentServer.Responses.OutputItemBuilder<OpenAI.Responses.ReasoningResponseItem>
    {
        protected OutputItemReasoningItemBuilder() { }
        public virtual Azure.AI.AgentServer.Responses.ReasoningSummaryPartBuilder AddSummaryPart() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputItemAddedUpdate EmitAdded() { throw null; }
        public virtual OpenAI.Responses.StreamingResponseOutputItemDoneUpdate EmitDone() { throw null; }
        public virtual System.Collections.Generic.IAsyncEnumerable<OpenAI.Responses.StreamingResponseUpdate> SummaryPart(System.Collections.Generic.IAsyncEnumerable<string> chunks, [System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<OpenAI.Responses.StreamingResponseUpdate> SummaryPart(string text) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
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
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
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
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
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
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public partial class ResponseContext
    {
        public ResponseContext(string responseId) { }
        public virtual bool ClientCancelled { get { throw null; } }
        public virtual System.Collections.Generic.IReadOnlyDictionary<string, string> ClientHeaders { get { throw null; } }
        public virtual string ConversationChainId { get { throw null; } }
        public virtual bool IsRecovery { get { throw null; } }
        public bool IsShutdownRequested { get { throw null; } set { } }
        public virtual bool IsSteeredTurn { get { throw null; } }
        public virtual int PendingInputCount { get { throw null; } }
        public virtual OpenAI.Responses.ResponseResult? PersistedResponse { get { throw null; } }
        public virtual Azure.AI.AgentServer.Core.PlatformContext PlatformContext { get { throw null; } }
        public virtual System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Extensions.Primitives.StringValues> QueryParameters { get { throw null; } }
        public virtual System.BinaryData? RawBody { get { throw null; } }
        public string ResponseId { get { throw null; } }
        public virtual System.Threading.CancellationToken Shutdown { get { throw null; } }
        public virtual System.Threading.Tasks.Task ExitForRecoveryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public partial class ResponseEventStream
    {
        protected ResponseEventStream() { }
        public ResponseEventStream(Azure.AI.AgentServer.Responses.ResponseContext context, OpenAI.Responses.CreateResponseOptions request) { }
        public ResponseEventStream(Azure.AI.AgentServer.Responses.ResponseContext context, OpenAI.Responses.ResponseResult persistedResponse) { }
        public virtual System.Collections.Generic.IDictionary<string, string> InternalMetadata { get { throw null; } }
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
        public OpenAI.Responses.StreamingResponseUpdate Checkpoint() { throw null; }
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
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public abstract partial class ResponseHandler
    {
        protected ResponseHandler() { }
        public abstract System.Collections.Generic.IAsyncEnumerable<OpenAI.Responses.StreamingResponseUpdate> CreateAsync(OpenAI.Responses.CreateResponseOptions request, Azure.AI.AgentServer.Responses.ResponseContext context, System.Threading.CancellationToken cancellationToken);
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public static partial class ResponseItemAttributionExtensions
    {
        public static Azure.AI.Extensions.OpenAI.AgentReference? get_AgentReference(OpenAI.Responses.CreateResponseOptions options) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AgentReference? get_AgentReference(OpenAI.Responses.ResponseItem item) { throw null; }
        public static Azure.AI.Extensions.OpenAI.AgentReference? get_AgentReference(OpenAI.Responses.ResponseResult response) { throw null; }
        public static string? get_AgentSessionId(OpenAI.Responses.CreateResponseOptions options) { throw null; }
        public static string? get_AgentSessionId(OpenAI.Responses.ResponseResult response) { throw null; }
        public static string? get_ApprovalRequestId(OpenAI.Responses.McpToolCallItem mcpCall) { throw null; }
        public static System.DateTimeOffset? get_CompletedAt(OpenAI.Responses.ResponseResult response) { throw null; }
        public static System.BinaryData? get_CreatedBy(OpenAI.Responses.ResponseItem item) { throw null; }
        public static string? get_Delta(OpenAI.Responses.StreamingResponseUpdate update) { throw null; }
        public static string? get_Input(OpenAI.Responses.StreamingResponseUpdate update) { throw null; }
        public static string? get_ItemId(OpenAI.Responses.StreamingResponseUpdate update) { throw null; }
        public static int get_OutputIndex(OpenAI.Responses.StreamingResponseUpdate update) { throw null; }
        public static string? get_OutputText(OpenAI.Responses.ResponseResult response) { throw null; }
        public static string? get_ResponseId(OpenAI.Responses.ResponseItem item) { throw null; }
        public static Azure.AI.AgentServer.Responses.Models.MCPToolCallStatus? get_Status(OpenAI.Responses.McpToolCallItem mcpCall) { throw null; }
        public static string? get_Text(OpenAI.Responses.ReasoningSummaryPart part) { throw null; }
        public static void set_AgentReference(OpenAI.Responses.CreateResponseOptions options, Azure.AI.Extensions.OpenAI.AgentReference? value) { }
        public static void set_AgentReference(OpenAI.Responses.ResponseItem item, Azure.AI.Extensions.OpenAI.AgentReference? value) { }
        public static void set_AgentReference(OpenAI.Responses.ResponseResult response, Azure.AI.Extensions.OpenAI.AgentReference? value) { }
        public static void set_AgentSessionId(OpenAI.Responses.CreateResponseOptions options, string? value) { }
        public static void set_AgentSessionId(OpenAI.Responses.ResponseResult response, string? value) { }
        public static void set_ApprovalRequestId(OpenAI.Responses.McpToolCallItem mcpCall, string? value) { }
        public static void set_CompletedAt(OpenAI.Responses.ResponseResult response, System.DateTimeOffset? value) { }
        public static void set_CreatedBy(OpenAI.Responses.ResponseItem item, System.BinaryData? value) { }
        public static void set_Delta(OpenAI.Responses.StreamingResponseUpdate update, string? value) { }
        public static void set_Input(OpenAI.Responses.StreamingResponseUpdate update, string? value) { }
        public static void set_ItemId(OpenAI.Responses.StreamingResponseUpdate update, string? value) { }
        public static void set_OutputIndex(OpenAI.Responses.StreamingResponseUpdate update, int value) { }
        public static void set_ResponseId(OpenAI.Responses.ResponseItem item, string? value) { }
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
            public int OutputIndex { get { throw null; } set { } }
            public static partial class <M>$89F88CE85944EB7F58B3316EF3164959
            {
                public static void <Extension>$(OpenAI.Responses.StreamingResponseUpdate update) { }
            }
        }
        public sealed partial class <G>$F3F0025ADD8FA456F8E93354548ADC99
        {
            internal <G>$F3F0025ADD8FA456F8E93354548ADC99() { }
            public Azure.AI.Extensions.OpenAI.AgentReference? AgentReference { get { throw null; } set { } }
            public System.BinaryData? CreatedBy { get { throw null; } set { } }
            public string? ResponseId { get { throw null; } set { } }
            public static partial class <M>$C05C9E0FD38D230C68A8F70214143831
            {
                public static void <Extension>$(OpenAI.Responses.ResponseItem item) { }
            }
        }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public partial class ResponsesApiException : System.Exception
    {
        public ResponsesApiException(OpenAI.Responses.ResponseError error, int statusCode) { }
        public ResponsesApiException(OpenAI.Responses.ResponseError error, int statusCode, System.Exception innerException) { }
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
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public abstract partial class ResponsesProvider
    {
        protected ResponsesProvider() { }
        public abstract System.Threading.Tasks.Task CreateResponseAsync(Azure.AI.AgentServer.Responses.CreateResponsePersistRequest request, Azure.AI.AgentServer.Core.PlatformContext context, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.Task DeleteResponseAsync(string responseId, Azure.AI.AgentServer.Core.PlatformContext context, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<string>> GetHistoryItemIdsAsync(string? previousResponseId, string? conversationId, int limit, Azure.AI.AgentServer.Core.PlatformContext context, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.Task<Azure.AI.AgentServer.Responses.Models.AgentsPagedResultOutputItem> GetInputItemsAsync(string responseId, Azure.AI.AgentServer.Core.PlatformContext context, int limit = 20, bool ascending = false, string? after = null, string? before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem?>> GetItemsAsync(System.Collections.Generic.IEnumerable<string> itemIds, Azure.AI.AgentServer.Core.PlatformContext context, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public abstract System.Threading.Tasks.Task<OpenAI.Responses.ResponseResult> GetResponseAsync(string responseId, Azure.AI.AgentServer.Core.PlatformContext context, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
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
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public partial class ResponsesServerOptions
    {
        public ResponsesServerOptions() { }
        public int DefaultFetchHistoryCount { get { throw null; } set { } }
        public string? DefaultModel { get { throw null; } set { } }
        public bool ResilientBackground { get { throw null; } set { } }
        public System.Func<OpenAI.Responses.CreateResponseOptions, Azure.AI.AgentServer.Responses.ResponseContext, OpenAI.Responses.ResponseResult>? ResponseAcceptor { get { throw null; } set { } }
        public bool SteerableConversations { get { throw null; } set { } }
    }
    public static partial class ResponsesServerServiceCollectionExtensions
    {
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddResponsesServer(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, System.Action<Azure.AI.AgentServer.Responses.ResponsesServerOptions>? configure = null) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
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
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
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
    public partial class AgentId : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AgentId>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentId>
    {
        internal AgentId() { }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
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
    public partial class AgentsPagedResultOutputItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AgentsPagedResultOutputItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentsPagedResultOutputItem>
    {
        internal AgentsPagedResultOutputItem() { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public System.Collections.Generic.IList<OpenAI.Responses.ResponseItem> Data { get { throw null; } }
        public string FirstId { get { throw null; } }
        public bool HasMore { get { throw null; } }
        public string LastId { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.AgentsPagedResultOutputItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.AgentServer.Responses.Models.AgentsPagedResultOutputItem (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.AgentServer.Responses.Models.AgentsPagedResultOutputItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.AgentsPagedResultOutputItem System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AgentsPagedResultOutputItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AgentsPagedResultOutputItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.AgentsPagedResultOutputItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentsPagedResultOutputItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentsPagedResultOutputItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AgentsPagedResultOutputItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiError : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ApiError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ApiError>
    {
        public ApiError(string code, string message) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalInfo { get { throw null; } }
        public string Code { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> DebugInfo { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.ApiError> Details { get { throw null; } }
        public string Message { get { throw null; } set { } }
        public string Param { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        protected virtual Azure.AI.AgentServer.Responses.Models.ApiError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ApiError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ApiError System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ApiError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ApiError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ApiError System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ApiError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ApiError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ApiError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ApiErrorResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ApiErrorResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ApiErrorResponse>
    {
        public ApiErrorResponse(Azure.AI.AgentServer.Responses.Models.ApiError error) { }
        public Azure.AI.AgentServer.Responses.Models.ApiError Error { get { throw null; } set { } }
        protected virtual Azure.AI.AgentServer.Responses.Models.ApiErrorResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ApiErrorResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ApiErrorResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ApiErrorResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ApiErrorResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ApiErrorResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ApiErrorResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ApiErrorResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ApiErrorResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public ApplyPatchCreateFileOperation(string path, string diff) { }
        public string Diff { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
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
        public ApplyPatchDeleteFileOperation(string path) { }
        public string Path { get { throw null; } set { } }
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
        public ApplyPatchUpdateFileOperation(string path, string diff) { }
        public string Diff { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
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
    public partial class AzureContentFilterBlocklistIdResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterBlocklistIdResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterBlocklistIdResult>
    {
        internal AzureContentFilterBlocklistIdResult() { }
        public bool Filtered { get { throw null; } }
        public string Id { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.AzureContentFilterBlocklistIdResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.AzureContentFilterBlocklistIdResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.AzureContentFilterBlocklistIdResult System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterBlocklistIdResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterBlocklistIdResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.AzureContentFilterBlocklistIdResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterBlocklistIdResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterBlocklistIdResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterBlocklistIdResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureContentFilterBlocklistResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterBlocklistResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterBlocklistResult>
    {
        internal AzureContentFilterBlocklistResult() { }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.AzureContentFilterBlocklistIdResult> Details { get { throw null; } }
        public bool Filtered { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.AzureContentFilterBlocklistResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.AzureContentFilterBlocklistResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.AzureContentFilterBlocklistResult System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterBlocklistResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterBlocklistResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.AzureContentFilterBlocklistResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterBlocklistResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterBlocklistResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterBlocklistResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureContentFilterCitation : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterCitation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterCitation>
    {
        internal AzureContentFilterCitation() { }
        public string License { get { throw null; } }
        public System.Uri Url { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.AzureContentFilterCitation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.AzureContentFilterCitation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.AzureContentFilterCitation System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterCitation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterCitation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.AzureContentFilterCitation System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterCitation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterCitation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterCitation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureContentFilterCompletionTextSpan : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterCompletionTextSpan>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterCompletionTextSpan>
    {
        internal AzureContentFilterCompletionTextSpan() { }
        public int CompletionEndOffset { get { throw null; } }
        public int CompletionStartOffset { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.AzureContentFilterCompletionTextSpan JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.AzureContentFilterCompletionTextSpan PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.AzureContentFilterCompletionTextSpan System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterCompletionTextSpan>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterCompletionTextSpan>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.AzureContentFilterCompletionTextSpan System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterCompletionTextSpan>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterCompletionTextSpan>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterCompletionTextSpan>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureContentFilterCompletionTextSpanDetectionResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterCompletionTextSpanDetectionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterCompletionTextSpanDetectionResult>
    {
        internal AzureContentFilterCompletionTextSpanDetectionResult() { }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.AzureContentFilterCompletionTextSpan> Details { get { throw null; } }
        public bool Detected { get { throw null; } }
        public bool Filtered { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.AzureContentFilterCompletionTextSpanDetectionResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.AzureContentFilterCompletionTextSpanDetectionResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.AzureContentFilterCompletionTextSpanDetectionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterCompletionTextSpanDetectionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterCompletionTextSpanDetectionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.AzureContentFilterCompletionTextSpanDetectionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterCompletionTextSpanDetectionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterCompletionTextSpanDetectionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterCompletionTextSpanDetectionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureContentFilterDetectionResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionResult>
    {
        internal AzureContentFilterDetectionResult() { }
        public bool Detected { get { throw null; } }
        public bool Filtered { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureContentFilterDetectionWithCitationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionWithCitationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionWithCitationResult>
    {
        internal AzureContentFilterDetectionWithCitationResult() { }
        public Azure.AI.AgentServer.Responses.Models.AzureContentFilterCitation Citation { get { throw null; } }
        public bool Detected { get { throw null; } }
        public bool Filtered { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionWithCitationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionWithCitationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionWithCitationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionWithCitationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionWithCitationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionWithCitationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionWithCitationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionWithCitationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionWithCitationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureContentFilterDetectionWithReasonResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionWithReasonResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionWithReasonResult>
    {
        internal AzureContentFilterDetectionWithReasonResult() { }
        public bool Detected { get { throw null; } }
        public bool Filtered { get { throw null; } }
        public string Reason { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionWithReasonResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionWithReasonResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionWithReasonResult System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionWithReasonResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionWithReasonResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionWithReasonResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionWithReasonResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionWithReasonResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionWithReasonResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureContentFilterError : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterError>
    {
        internal AzureContentFilterError() { }
        public int Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.AzureContentFilterError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.AzureContentFilterError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.AzureContentFilterError System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.AzureContentFilterError System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureContentFilterPersonallyIdentifiableInformationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterPersonallyIdentifiableInformationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterPersonallyIdentifiableInformationResult>
    {
        internal AzureContentFilterPersonallyIdentifiableInformationResult() { }
        public bool Detected { get { throw null; } }
        public bool Filtered { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.AzureContentFilterPiiSubCategoryResult> SubCategories { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.AzureContentFilterPersonallyIdentifiableInformationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.AzureContentFilterPersonallyIdentifiableInformationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.AzureContentFilterPersonallyIdentifiableInformationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterPersonallyIdentifiableInformationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterPersonallyIdentifiableInformationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.AzureContentFilterPersonallyIdentifiableInformationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterPersonallyIdentifiableInformationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterPersonallyIdentifiableInformationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterPersonallyIdentifiableInformationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureContentFilterPiiSubCategoryResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterPiiSubCategoryResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterPiiSubCategoryResult>
    {
        internal AzureContentFilterPiiSubCategoryResult() { }
        public bool Detected { get { throw null; } }
        public bool Filtered { get { throw null; } }
        public string SubCategory { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.AzureContentFilterPiiSubCategoryResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.AzureContentFilterPiiSubCategoryResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.AzureContentFilterPiiSubCategoryResult System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterPiiSubCategoryResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterPiiSubCategoryResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.AzureContentFilterPiiSubCategoryResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterPiiSubCategoryResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterPiiSubCategoryResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterPiiSubCategoryResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureContentFilterResultsForResponses : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterResultsForResponses>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterResultsForResponses>
    {
        internal AzureContentFilterResultsForResponses() { }
        public Azure.AI.AgentServer.Responses.Models.AzureContentFilterBlocklistResult CustomBlocklists { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.AzureContentFilterError Error { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.AzureContentFilterSeverityResult Hate { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionResult IndirectAttack { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionResult Jailbreak { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.AzureContentFilterPersonallyIdentifiableInformationResult PersonallyIdentifiableInformation { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionResult Profanity { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionWithCitationResult ProtectedMaterialCode { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionResult ProtectedMaterialText { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.AzureContentFilterSeverityResult SelfHarm { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.AzureContentFilterSeverityResult Sexual { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.AzureContentFilterDetectionWithReasonResult TaskAdherence { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.AzureContentFilterCompletionTextSpanDetectionResult UngroundedMaterial { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.AzureContentFilterSeverityResult Violence { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.AzureContentFilterResultsForResponses JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.AzureContentFilterResultsForResponses PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.AzureContentFilterResultsForResponses System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterResultsForResponses>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterResultsForResponses>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.AzureContentFilterResultsForResponses System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterResultsForResponses>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterResultsForResponses>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterResultsForResponses>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureContentFilterSeverity : System.IEquatable<Azure.AI.AgentServer.Responses.Models.AzureContentFilterSeverity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureContentFilterSeverity(string value) { throw null; }
        public static Azure.AI.AgentServer.Responses.Models.AzureContentFilterSeverity High { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.AzureContentFilterSeverity Low { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.AzureContentFilterSeverity Medium { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.AzureContentFilterSeverity Safe { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Responses.Models.AzureContentFilterSeverity other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Responses.Models.AzureContentFilterSeverity left, Azure.AI.AgentServer.Responses.Models.AzureContentFilterSeverity right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Responses.Models.AzureContentFilterSeverity (string value) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Responses.Models.AzureContentFilterSeverity? (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Responses.Models.AzureContentFilterSeverity left, Azure.AI.AgentServer.Responses.Models.AzureContentFilterSeverity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureContentFilterSeverityResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterSeverityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterSeverityResult>
    {
        internal AzureContentFilterSeverityResult() { }
        public bool Filtered { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.AzureContentFilterSeverity Severity { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.AzureContentFilterSeverityResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.AzureContentFilterSeverityResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.AzureContentFilterSeverityResult System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterSeverityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterSeverityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.AzureContentFilterSeverityResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterSeverityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterSeverityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureContentFilterSeverityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureUserSecurityContext : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureUserSecurityContext>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureUserSecurityContext>
    {
        public AzureUserSecurityContext() { }
        public string ApplicationName { get { throw null; } set { } }
        public string EndUserId { get { throw null; } set { } }
        public string EndUserTenantId { get { throw null; } set { } }
        public string SourceIP { get { throw null; } set { } }
        protected virtual Azure.AI.AgentServer.Responses.Models.AzureUserSecurityContext JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.AzureUserSecurityContext PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.AzureUserSecurityContext System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureUserSecurityContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.AzureUserSecurityContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.AzureUserSecurityContext System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureUserSecurityContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureUserSecurityContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.AzureUserSecurityContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CodeInterpreterOutputImage : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.CodeInterpreterOutputImage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.CodeInterpreterOutputImage>
    {
        public CodeInterpreterOutputImage(System.Uri url) { }
        public string Type { get { throw null; } }
        public System.Uri Url { get { throw null; } set { } }
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
        public CodeInterpreterOutputLogs(string logs) { }
        public string Logs { get { throw null; } set { } }
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
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public string Object { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.ItemField> Output { get { throw null; } }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public OpenAI.Responses.ResponseTokenUsage Usage { get { throw null; } }
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
    public partial class ComputerCallSafetyCheckParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ComputerCallSafetyCheckParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ComputerCallSafetyCheckParam>
    {
        public ComputerCallSafetyCheckParam(string id) { }
        public string Code { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
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
        public ComputerScreenshotContent(System.Uri imageUrl, string fileId, Azure.AI.AgentServer.Responses.Models.ImageDetail detail) { }
        public Azure.AI.AgentServer.Responses.Models.ImageDetail Detail { get { throw null; } set { } }
        public string FileId { get { throw null; } set { } }
        public System.Uri ImageUrl { get { throw null; } set { } }
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
    public partial class ContainerReferenceResource : Azure.AI.AgentServer.Responses.Models.FunctionShellCallEnvironment, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContainerReferenceResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContainerReferenceResource>
    {
        public ContainerReferenceResource(string containerId) { }
        public string ContainerId { get { throw null; } set { } }
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
    public partial class ContentFilterResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContentFilterResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContentFilterResult>
    {
        internal ContentFilterResult() { }
        public bool Blocked { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.AzureContentFilterResultsForResponses ContentFilterResults { get { throw null; } }
        public string SourceType { get { throw null; } }
        public string ToolCallId { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.ContentFilterResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ContentFilterResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ContentFilterResult System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContentFilterResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContentFilterResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ContentFilterResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContentFilterResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContentFilterResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContentFilterResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContextManagementParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContextManagementParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContextManagementParam>
    {
        public ContextManagementParam(string type) { }
        public long? CompactThreshold { get { throw null; } set { } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.ContextManagementParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ContextManagementParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ContextManagementParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContextManagementParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ContextManagementParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ContextManagementParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContextManagementParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContextManagementParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ContextManagementParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ConversationParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ConversationParam>
    {
        public ConversationParam(string id) { }
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
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public static partial class CreateResponseExtensions
    {
        public static Azure.AI.AgentServer.Responses.Models.ConversationParam? GetConversationExpanded(this OpenAI.Responses.CreateResponseOptions request) { throw null; }
        public static string? GetConversationId(this OpenAI.Responses.CreateResponseOptions request) { throw null; }
        public static System.Collections.Generic.List<OpenAI.Responses.ResponseItem> GetInputExpanded(this OpenAI.Responses.CreateResponseOptions request) { throw null; }
        public static System.BinaryData? GetInstructionsBinaryData(this OpenAI.Responses.CreateResponseOptions request) { throw null; }
        public static Azure.AI.AgentServer.Responses.Models.ToolChoiceParam? GetToolChoiceExpanded(this OpenAI.Responses.CreateResponseOptions request) { throw null; }
    }
    public enum CreateResponseRequestPromptCacheRetention
    {
        InMemory = 0,
        _24h = 1,
    }
    public enum CreateResponseRequestReasoningEffort
    {
        None = 0,
        Minimal = 1,
        Low = 2,
        Medium = 3,
        High = 4,
        Xhigh = 5,
    }
    public enum CreateResponseRequestReasoningGenerateSummary
    {
        Auto = 0,
        Concise = 1,
        Detailed = 2,
    }
    public enum CreateResponseRequestReasoningSummary
    {
        Auto = 0,
        Concise = 1,
        Detailed = 2,
    }
    public enum CreateResponseRequestServiceTier
    {
        Auto = 0,
        Default = 1,
        Flex = 2,
        Scale = 3,
        Priority = 4,
    }
    public enum CreateResponseRequestTruncation
    {
        Auto = 0,
        Disabled = 1,
    }
    public enum CreateResponseResponseIncompleteDetailsReason
    {
        MaxOutputTokens = 0,
        ContentFilter = 1,
    }
    public enum CreateResponseResponseStatus
    {
        Completed = 0,
        Failed = 1,
        InProgress = 2,
        Cancelled = 3,
        Queued = 4,
        Incomplete = 5,
    }
    public partial class DeleteResponseResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.DeleteResponseResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.DeleteResponseResult>
    {
        public DeleteResponseResult(string id) { }
        public bool Deleted { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public string Object { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.DeleteResponseResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.AgentServer.Responses.Models.DeleteResponseResult (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.AgentServer.Responses.Models.DeleteResponseResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.DeleteResponseResult System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.DeleteResponseResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.DeleteResponseResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.DeleteResponseResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.DeleteResponseResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.DeleteResponseResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.DeleteResponseResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSearchToolCallResults : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.FileSearchToolCallResults>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.FileSearchToolCallResults>
    {
        public FileSearchToolCallResults() { }
        public Azure.AI.AgentServer.Responses.Models.VectorStoreFileAttributes Attributes { get { throw null; } set { } }
        public string FileId { get { throw null; } set { } }
        public string Filename { get { throw null; } set { } }
        public float? Score { get { throw null; } set { } }
        public string Text { get { throw null; } set { } }
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
        public FunctionShellAction(System.Collections.Generic.IEnumerable<string> commands, long? timeoutMs, long? maxOutputLength) { }
        public System.Collections.Generic.IList<string> Commands { get { throw null; } }
        public long? MaxOutputLength { get { throw null; } set { } }
        public long? TimeoutMs { get { throw null; } set { } }
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
        public FunctionShellCallOutputContent(string stdout, string stderr, Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputOutcome outcome) { }
        public string CreatedBy { get { throw null; } set { } }
        public Azure.AI.AgentServer.Responses.Models.FunctionShellCallOutputOutcome Outcome { get { throw null; } set { } }
        public string Stderr { get { throw null; } set { } }
        public string Stdout { get { throw null; } set { } }
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
        public FunctionShellCallOutputExitOutcome(long exitCode) { }
        public long ExitCode { get { throw null; } set { } }
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
        public FunctionShellCallOutputTimeoutOutcome() { }
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
    public enum ImageDetail
    {
        Low = 0,
        High = 1,
        Auto = 2,
        Original = 3,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IncludeEnum : System.IEquatable<Azure.AI.AgentServer.Responses.Models.IncludeEnum>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IncludeEnum(string value) { throw null; }
        public static Azure.AI.AgentServer.Responses.Models.IncludeEnum CodeInterpreterCallOutputs { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.IncludeEnum ComputerCallOutputOutputImageUri { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.IncludeEnum FileSearchCallResults { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.IncludeEnum MemorySearchCallResults { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.IncludeEnum MessageInputImageImageUri { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.IncludeEnum MessageOutputTextLogprobs { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.IncludeEnum ReasoningEncryptedContent { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.IncludeEnum WebSearchCallActionSources { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.IncludeEnum WebSearchCallResults { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Responses.Models.IncludeEnum other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Responses.Models.IncludeEnum left, Azure.AI.AgentServer.Responses.Models.IncludeEnum right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Responses.Models.IncludeEnum (string value) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Responses.Models.IncludeEnum? (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Responses.Models.IncludeEnum left, Azure.AI.AgentServer.Responses.Models.IncludeEnum right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InputFileContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.InputFileContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InputFileContent>
    {
        public InputFileContent() { }
        public string FileData { get { throw null; } set { } }
        public string FileId { get { throw null; } set { } }
        public string Filename { get { throw null; } set { } }
        public System.Uri FileUrl { get { throw null; } set { } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.InputFileContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.InputFileContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.InputFileContent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.InputFileContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.InputFileContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.InputFileContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InputFileContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InputFileContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InputFileContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InputImageContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.InputImageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InputImageContent>
    {
        public InputImageContent(Azure.AI.AgentServer.Responses.Models.ImageDetail detail) { }
        public Azure.AI.AgentServer.Responses.Models.ImageDetail Detail { get { throw null; } set { } }
        public string FileId { get { throw null; } set { } }
        public System.Uri ImageUrl { get { throw null; } set { } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.InputImageContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.InputImageContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.InputImageContent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.InputImageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.InputImageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.InputImageContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InputImageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InputImageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InputImageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InputTextContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.InputTextContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InputTextContent>
    {
        public InputTextContent(string text) { }
        public string Text { get { throw null; } set { } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.InputTextContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.InputTextContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.InputTextContent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.InputTextContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.InputTextContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.InputTextContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InputTextContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InputTextContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.InputTextContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
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
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public OpenAI.Responses.ComputerCallAction Action { get { throw null; } }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public System.Collections.Generic.IList<OpenAI.Responses.ComputerCallAction> Actions { get { throw null; } }
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
        public Azure.AI.AgentServer.Responses.Models.OutputItemComputerToolCallOutputStatus? Status { get { throw null; } }
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
        public Azure.AI.AgentServer.Responses.Models.OutputItemFunctionToolCallOutputStatus? Status { get { throw null; } }
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
        public Azure.AI.AgentServer.Responses.Models.MessageStatus Status { get { throw null; } }
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
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
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
    public partial class LocalEnvironmentResource : Azure.AI.AgentServer.Responses.Models.FunctionShellCallEnvironment, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.LocalEnvironmentResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.LocalEnvironmentResource>
    {
        public LocalEnvironmentResource() { }
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
        public LocalShellExecAction(System.Collections.Generic.IEnumerable<string> command, System.Collections.Generic.IDictionary<string, string> env) { }
        public System.Collections.Generic.IList<string> Command { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Env { get { throw null; } }
        public long? TimeoutMs { get { throw null; } set { } }
        public string Type { get { throw null; } }
        public string User { get { throw null; } set { } }
        public string WorkingDirectory { get { throw null; } set { } }
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
    public partial class MCPListToolsTool : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MCPListToolsTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MCPListToolsTool>
    {
        public MCPListToolsTool(string name, Azure.AI.AgentServer.Responses.Models.MCPListToolsToolInputSchema inputSchema) { }
        public Azure.AI.AgentServer.Responses.Models.MCPListToolsToolAnnotations Annotations { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.AI.AgentServer.Responses.Models.MCPListToolsToolInputSchema InputSchema { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
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
        public MCPListToolsToolAnnotations() { }
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
        public MCPListToolsToolInputSchema() { }
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
        public string FileData { get { throw null; } set { } }
        public string FileId { get { throw null; } set { } }
        public string Filename { get { throw null; } set { } }
        public System.Uri FileUrl { get { throw null; } set { } }
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
    public partial class MessageContentOutputTextContent : Azure.AI.AgentServer.Responses.Models.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.MessageContentOutputTextContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.MessageContentOutputTextContent>
    {
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
        public MessageContentOutputTextContent(string text, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseMessageAnnotation> annotations) { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
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
    public partial class Metadata : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.Metadata>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.Metadata>
    {
        public Metadata() { }
        public System.Collections.Generic.IDictionary<string, string> AdditionalProperties { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.Metadata JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.Metadata PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.Metadata System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.Metadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.Metadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.Metadata System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.Metadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.Metadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.Metadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ModelRouterAttempt : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ModelRouterAttempt>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ModelRouterAttempt>
    {
        internal ModelRouterAttempt() { }
        public string Model { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.ModelRouterAttemptResult Result { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.ModelRouterAttempt JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ModelRouterAttempt PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ModelRouterAttempt System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ModelRouterAttempt>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ModelRouterAttempt>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ModelRouterAttempt System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ModelRouterAttempt>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ModelRouterAttempt>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ModelRouterAttempt>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ModelRouterAttemptError : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ModelRouterAttemptError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ModelRouterAttemptError>
    {
        internal ModelRouterAttemptError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.ModelRouterAttemptError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ModelRouterAttemptError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ModelRouterAttemptError System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ModelRouterAttemptError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ModelRouterAttemptError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ModelRouterAttemptError System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ModelRouterAttemptError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ModelRouterAttemptError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ModelRouterAttemptError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ModelRouterAttemptResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ModelRouterAttemptResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ModelRouterAttemptResult>
    {
        internal ModelRouterAttemptResult() { }
        public Azure.AI.AgentServer.Responses.Models.ModelRouterAttemptError Error { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Headers { get { throw null; } }
        public int Status { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.ModelRouterAttemptResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ModelRouterAttemptResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ModelRouterAttemptResult System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ModelRouterAttemptResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ModelRouterAttemptResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ModelRouterAttemptResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ModelRouterAttemptResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ModelRouterAttemptResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ModelRouterAttemptResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ModelRouterDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ModelRouterDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ModelRouterDetails>
    {
        internal ModelRouterDetails() { }
        public Azure.AI.AgentServer.Responses.Models.ModelRouterMode Mode { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.RoutingTraceEntry> RoutingTrace { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.ModelRouterDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ModelRouterDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ModelRouterDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ModelRouterDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ModelRouterDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ModelRouterDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ModelRouterDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ModelRouterDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ModelRouterDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ModelRouterMode : System.IEquatable<Azure.AI.AgentServer.Responses.Models.ModelRouterMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ModelRouterMode(string value) { throw null; }
        public static Azure.AI.AgentServer.Responses.Models.ModelRouterMode Balanced { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelRouterMode Cost { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Models.ModelRouterMode Quality { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Responses.Models.ModelRouterMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Responses.Models.ModelRouterMode left, Azure.AI.AgentServer.Responses.Models.ModelRouterMode right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Responses.Models.ModelRouterMode (string value) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Responses.Models.ModelRouterMode? (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Responses.Models.ModelRouterMode left, Azure.AI.AgentServer.Responses.Models.ModelRouterMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ModelSelectionDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ModelSelectionDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ModelSelectionDetails>
    {
        internal ModelSelectionDetails() { }
        public Azure.AI.AgentServer.Responses.Models.ModelRouterDetails ModelRouterDetails { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.ModelSelectionDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ModelSelectionDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ModelSelectionDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ModelSelectionDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ModelSelectionDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ModelSelectionDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ModelSelectionDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ModelSelectionDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ModelSelectionDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum OutputItemComputerToolCallOutputStatus
    {
        InProgress = 0,
        Completed = 1,
        Incomplete = 2,
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public partial class OutputItemCustomToolCall : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.OutputItemCustomToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.OutputItemCustomToolCall>
    {
        public OutputItemCustomToolCall(string callId, string name, string input, OpenAI.Responses.FunctionCallStatus status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string CallId { get { throw null; } }
        public string Input { get { throw null; } }
        public string Name { get { throw null; } }
        public string Namespace { get { throw null; } }
        public OpenAI.Responses.FunctionCallStatus Status { get { throw null; } }
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
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public partial class OutputItemCustomToolCallOutput : OpenAI.Responses.ResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.OutputItemCustomToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.OutputItemCustomToolCallOutput>
    {
        public OutputItemCustomToolCallOutput(string callId, System.BinaryData output, Azure.AI.AgentServer.Responses.Models.FunctionCallOutputStatusEnum status) : base (default(OpenAI.Responses.ResponseItemKind)) { }
        public string CallId { get { throw null; } }
        public System.BinaryData Output { get { throw null; } }
        public Azure.AI.AgentServer.Responses.Models.FunctionCallOutputStatusEnum Status { get { throw null; } }
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
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public static partial class OutputItemExtensions
    {
        public static string GetId(this OpenAI.Responses.ResponseItem item) { throw null; }
    }
    public enum OutputItemFunctionToolCallOutputStatus
    {
        InProgress = 0,
        Completed = 1,
        Incomplete = 2,
    }
    public enum PageOrder
    {
        Asc = 0,
        Desc = 1,
    }
    public partial class Prompt : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.Prompt>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.Prompt>
    {
        public Prompt(string id) { }
        public string Id { get { throw null; } set { } }
        public Azure.AI.AgentServer.Responses.Models.ResponsePromptVariables Variables { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.AI.AgentServer.Responses.Models.Prompt JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.Prompt PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.Prompt System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.Prompt>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.Prompt>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.Prompt System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.Prompt>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.Prompt>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.Prompt>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public RealtimeMCPHTTPError(long code, string message) { }
        public long Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
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
        public RealtimeMCPProtocolError(long code, string message) { }
        public long Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
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
        public RealtimeMCPToolExecutionError(string message) { }
        public string Message { get { throw null; } set { } }
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
        public Azure.AI.AgentServer.Responses.Models.CreateResponseRequestReasoningEffort? Effort { get { throw null; } set { } }
        public Azure.AI.AgentServer.Responses.Models.CreateResponseRequestReasoningGenerateSummary? GenerateSummary { get { throw null; } set { } }
        public Azure.AI.AgentServer.Responses.Models.CreateResponseRequestReasoningSummary? Summary { get { throw null; } set { } }
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
        public ReasoningTextContent(string text) { }
        public string Text { get { throw null; } set { } }
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
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public static partial class ResponseExtensions
    {
        public static System.Collections.Generic.List<OpenAI.Responses.ResponseItem> GetInstructionItems(this OpenAI.Responses.ResponseResult response) { throw null; }
        public static Azure.AI.AgentServer.Responses.Models.ToolChoiceParam? GetToolChoiceExpanded(this OpenAI.Responses.ResponseResult response) { throw null; }
        public static void SetInstructions(this OpenAI.Responses.ResponseResult response, System.Collections.Generic.IList<OpenAI.Responses.ResponseItem> items) { }
        public static void SetInstructions(this OpenAI.Responses.ResponseResult response, string instructions) { }
        public static void SetToolChoice(this OpenAI.Responses.ResponseResult response, Azure.AI.AgentServer.Responses.Models.ToolChoiceOptions toolChoice) { }
        public static void SetToolChoice(this OpenAI.Responses.ResponseResult response, Azure.AI.AgentServer.Responses.Models.ToolChoiceParam toolChoice) { }
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
    public partial class ResponseIncompleteDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ResponseIncompleteDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponseIncompleteDetails>
    {
        internal ResponseIncompleteDetails() { }
        public Azure.AI.AgentServer.Responses.Models.CreateResponseResponseIncompleteDetailsReason? Reason { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.ResponseIncompleteDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ResponseIncompleteDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ResponseIncompleteDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ResponseIncompleteDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ResponseIncompleteDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ResponseIncompleteDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponseIncompleteDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponseIncompleteDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponseIncompleteDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponsePromptVariables : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ResponsePromptVariables>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponsePromptVariables>
    {
        public ResponsePromptVariables() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalBinaryDataProperties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> AdditionalProperties { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.ResponsePromptVariables JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ResponsePromptVariables PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ResponsePromptVariables System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ResponsePromptVariables>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ResponsePromptVariables>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ResponsePromptVariables System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponsePromptVariables>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponsePromptVariables>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponsePromptVariables>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public static partial class ResponsesModelFactory
    {
        public static Azure.AI.AgentServer.Responses.Models.AgentsPagedResultOutputItem AgentsPagedResultOutputItem(System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> data = null, string firstId = null, string lastId = null, bool hasMore = false) { throw null; }
        public static Azure.AI.AgentServer.Responses.Models.DeleteResponseResult DeleteResponseResult(string id = null) { throw null; }
        public static OpenAI.Responses.StreamingResponseCreatedUpdate ResponseCreatedEvent(OpenAI.Responses.ResponseResult response = null, long sequenceNumber = (long)0) { throw null; }
        public static OpenAI.Responses.ResponseError ResponseErrorInfo(OpenAI.Responses.ResponseErrorCode code = default(OpenAI.Responses.ResponseErrorCode), string message = null) { throw null; }
        public static OpenAI.Responses.ResponseResult ResponseObject(string id = null, string model = null, OpenAI.Responses.ResponseStatus? status = default(OpenAI.Responses.ResponseStatus?), System.DateTimeOffset createdAt = default(System.DateTimeOffset), OpenAI.Responses.ResponseError error = null, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> output = null) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("AAIP002")]
    public static partial class ResponseSnapshotExtensions
    {
        public static OpenAI.Responses.ResponseResult Snapshot(this OpenAI.Responses.ResponseResult response) { throw null; }
        public static void SnapshotEmbeddedResponse(this OpenAI.Responses.StreamingResponseUpdate evt, OpenAI.Responses.ResponseResult accumulator) { }
    }
    public partial class ResponseStreamOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ResponseStreamOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponseStreamOptions>
    {
        public ResponseStreamOptions() { }
        public bool? IncludeObfuscation { get { throw null; } set { } }
        protected virtual Azure.AI.AgentServer.Responses.Models.ResponseStreamOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ResponseStreamOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ResponseStreamOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ResponseStreamOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ResponseStreamOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ResponseStreamOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponseStreamOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponseStreamOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponseStreamOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponseTextParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ResponseTextParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponseTextParam>
    {
        public ResponseTextParam() { }
        public Azure.AI.AgentServer.Responses.Models.TextResponseFormatConfiguration Format { get { throw null; } set { } }
        public Azure.AI.AgentServer.Responses.Models.ResponseTextParamVerbosity? Verbosity { get { throw null; } set { } }
        protected virtual Azure.AI.AgentServer.Responses.Models.ResponseTextParam JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.ResponseTextParam PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.ResponseTextParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ResponseTextParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.ResponseTextParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.ResponseTextParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponseTextParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponseTextParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.ResponseTextParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ResponseTextParamVerbosity
    {
        Low = 0,
        Medium = 1,
        High = 2,
    }
    public partial class RoutingTraceEntry : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.RoutingTraceEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.RoutingTraceEntry>
    {
        internal RoutingTraceEntry() { }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Responses.Models.ModelRouterAttempt> Attempts { get { throw null; } }
        public System.TimeSpan LatencyMs { get { throw null; } }
        public string OutputId { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Responses.Models.RoutingTraceEntry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Responses.Models.RoutingTraceEntry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Responses.Models.RoutingTraceEntry System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.RoutingTraceEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.RoutingTraceEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Responses.Models.RoutingTraceEntry System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.RoutingTraceEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.RoutingTraceEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.RoutingTraceEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        public string Name { get { throw null; } set { } }
        public Azure.AI.AgentServer.Responses.Models.ResponseFormatJsonSchemaSchema Schema { get { throw null; } set { } }
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
    public enum ToolSearchExecutionType
    {
        Server = 0,
        Client = 1,
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
    public partial class VectorStoreFileAttributes : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.VectorStoreFileAttributes>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.VectorStoreFileAttributes>
    {
        public VectorStoreFileAttributes() { }
        public System.Collections.Generic.IDictionary<string, bool> AdditionalBooleanProperties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, double> AdditionalDoubleProperties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> AdditionalProperties { get { throw null; } }
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
    public partial class WebSearchActionFind : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Responses.Models.WebSearchActionFind>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Responses.Models.WebSearchActionFind>
    {
        public WebSearchActionFind(System.Uri url, string pattern) { }
        public string Pattern { get { throw null; } set { } }
        public string Type { get { throw null; } }
        public System.Uri Url { get { throw null; } set { } }
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
        public WebSearchActionOpenPage() { }
        public string Type { get { throw null; } }
        public System.Uri Url { get { throw null; } set { } }
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
        public WebSearchActionSearch(string query) { }
        public System.Collections.Generic.IList<string> Queries { get { throw null; } }
        public string Query { get { throw null; } set { } }
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
        public WebSearchActionSearchSources(string url) { }
        public string Type { get { throw null; } }
        public string Url { get { throw null; } set { } }
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
}
