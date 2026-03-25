namespace Azure.AI.AgentServer.Responses
{
    public partial class BadRequestException : System.Exception
    {
        public BadRequestException(string message) { }
        public BadRequestException(string message, System.Exception innerException) { }
        public BadRequestException(string message, string? paramName) { }
        public BadRequestException(string message, string? code, string? paramName) { }
        public string? Code { get { throw null; } }
        public string? ParamName { get { throw null; } }
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
    public partial interface IResponseContext
    {
        System.Collections.Generic.IReadOnlyDictionary<string, string> ClientHeaders { get; }
        bool IsShutdownRequested { get; set; }
        System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Extensions.Primitives.StringValues> QueryParameters { get; }
        System.Text.Json.JsonElement RawBody { get; }
        string ResponseId { get; }
        System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Responses.Models.OutputItem>> GetHistoryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Responses.Models.OutputItem>> GetInputItemsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
    public partial interface IResponseHandler
    {
        System.Collections.Generic.IAsyncEnumerable<Azure.AI.AgentServer.Responses.Models.ResponseStreamEvent> CreateAsync(Azure.AI.AgentServer.Responses.Models.CreateResponse request, Azure.AI.AgentServer.Responses.IResponseContext context, System.Threading.CancellationToken cancellationToken);
    }
    public partial interface IResponsesCancellationSignalProvider
    {
        System.Threading.Tasks.Task CancelResponseAsync(string responseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        System.Threading.Tasks.Task<System.Threading.CancellationToken> GetResponseCancellationTokenAsync(string responseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
    public partial interface IResponsesProvider
    {
        System.Threading.Tasks.Task CreateResponseAsync(Azure.AI.AgentServer.Responses.Models.Response response, System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Responses.Models.OutputItem>? inputItems, System.Collections.Generic.IEnumerable<string>? historyItemIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        System.Threading.Tasks.Task DeleteResponseAsync(string responseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<string>> GetHistoryItemIdsAsync(string? previousResponseId, string? conversationId, int limit, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        System.Threading.Tasks.Task<Azure.AI.AgentServer.Responses.Models.AgentsPagedResultOutputItem> GetInputItemsAsync(string responseId, int limit = 20, bool ascending = false, string? after = null, string? before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Responses.Models.OutputItem?>> GetItemsAsync(System.Collections.Generic.IEnumerable<string> itemIds, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        System.Threading.Tasks.Task<Azure.AI.AgentServer.Responses.Models.Response> GetResponseAsync(string responseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        System.Threading.Tasks.Task UpdateResponseAsync(Azure.AI.AgentServer.Responses.Models.Response response, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
    public partial interface IResponsesStreamProvider
    {
        System.Threading.Tasks.Task<Azure.AI.AgentServer.Responses.IAsyncObserver<Azure.AI.AgentServer.Responses.Models.ResponseStreamEvent>> CreateEventPublisherAsync(string responseId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        System.Threading.Tasks.Task<System.IAsyncDisposable> SubscribeToEventsAsync(string responseId, Azure.AI.AgentServer.Responses.IAsyncObserver<Azure.AI.AgentServer.Responses.Models.ResponseStreamEvent> observer, long? cursor = default(long?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
    public partial class OutputItemBuilder<T> where T : Azure.AI.AgentServer.Responses.Models.OutputItem
    {
        protected OutputItemBuilder() { }
        public string ItemId { get { throw null; } }
        public long OutputIndex { get { throw null; } }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseOutputItemAddedEvent EmitAdded(T item) { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseOutputItemDoneEvent EmitDone(T item) { throw null; }
    }
    public partial class OutputItemCodeInterpreterCallBuilder : Azure.AI.AgentServer.Responses.OutputItemBuilder<Azure.AI.AgentServer.Responses.Models.OutputItemCodeInterpreterToolCall>
    {
        protected OutputItemCodeInterpreterCallBuilder() { }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseOutputItemAddedEvent EmitAdded() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseCodeInterpreterCallCodeDeltaEvent EmitCodeDelta(string delta) { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseCodeInterpreterCallCodeDoneEvent EmitCodeDone(string code) { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseCodeInterpreterCallCompletedEvent EmitCompleted() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseOutputItemDoneEvent EmitDone() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseCodeInterpreterCallInProgressEvent EmitInProgress() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseCodeInterpreterCallInterpretingEvent EmitInterpreting() { throw null; }
    }
    public partial class OutputItemCustomToolCallBuilder : Azure.AI.AgentServer.Responses.OutputItemBuilder<Azure.AI.AgentServer.Responses.Models.OutputItemCustomToolCall>
    {
        protected OutputItemCustomToolCallBuilder() { }
        public string CallId { get { throw null; } }
        public string Name { get { throw null; } }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseOutputItemAddedEvent EmitAdded() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseOutputItemDoneEvent EmitDone() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseCustomToolCallInputDeltaEvent EmitInputDelta(string delta) { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseCustomToolCallInputDoneEvent EmitInputDone(string input) { throw null; }
    }
    public partial class OutputItemFileSearchCallBuilder : Azure.AI.AgentServer.Responses.OutputItemBuilder<Azure.AI.AgentServer.Responses.Models.OutputItemFileSearchToolCall>
    {
        protected OutputItemFileSearchCallBuilder() { }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseOutputItemAddedEvent EmitAdded() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseFileSearchCallCompletedEvent EmitCompleted() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseOutputItemDoneEvent EmitDone() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseFileSearchCallInProgressEvent EmitInProgress() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseFileSearchCallSearchingEvent EmitSearching() { throw null; }
    }
    public partial class OutputItemFunctionCallBuilder : Azure.AI.AgentServer.Responses.OutputItemBuilder<Azure.AI.AgentServer.Responses.Models.OutputItemFunctionToolCall>
    {
        protected OutputItemFunctionCallBuilder() { }
        public string CallId { get { throw null; } }
        public string Name { get { throw null; } }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseOutputItemAddedEvent EmitAdded() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseFunctionCallArgumentsDeltaEvent EmitArgumentsDelta(string delta) { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseFunctionCallArgumentsDoneEvent EmitArgumentsDone(string arguments) { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseOutputItemDoneEvent EmitDone() { throw null; }
    }
    public partial class OutputItemImageGenCallBuilder : Azure.AI.AgentServer.Responses.OutputItemBuilder<Azure.AI.AgentServer.Responses.Models.OutputItemImageGenToolCall>
    {
        protected OutputItemImageGenCallBuilder() { }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseOutputItemAddedEvent EmitAdded() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseImageGenCallCompletedEvent EmitCompleted() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseOutputItemDoneEvent EmitDone() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseImageGenCallGeneratingEvent EmitGenerating() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseImageGenCallInProgressEvent EmitInProgress() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseImageGenCallPartialImageEvent EmitPartialImage(string partialImageB64) { throw null; }
    }
    public partial class OutputItemMcpCallBuilder : Azure.AI.AgentServer.Responses.OutputItemBuilder<Azure.AI.AgentServer.Responses.Models.OutputItemMcpToolCall>
    {
        protected OutputItemMcpCallBuilder() { }
        public string Name { get { throw null; } }
        public string ServerLabel { get { throw null; } }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseOutputItemAddedEvent EmitAdded() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseMCPCallArgumentsDeltaEvent EmitArgumentsDelta(string delta) { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseMCPCallArgumentsDoneEvent EmitArgumentsDone(string arguments) { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseMCPCallCompletedEvent EmitCompleted() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseOutputItemDoneEvent EmitDone() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseMCPCallFailedEvent EmitFailed() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseMCPCallInProgressEvent EmitInProgress() { throw null; }
    }
    public partial class OutputItemMcpListToolsBuilder : Azure.AI.AgentServer.Responses.OutputItemBuilder<Azure.AI.AgentServer.Responses.Models.OutputItemMcpListTools>
    {
        protected OutputItemMcpListToolsBuilder() { }
        public string ServerLabel { get { throw null; } }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseOutputItemAddedEvent EmitAdded() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseMCPListToolsCompletedEvent EmitCompleted() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseOutputItemDoneEvent EmitDone() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseMCPListToolsFailedEvent EmitFailed() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseMCPListToolsInProgressEvent EmitInProgress() { throw null; }
    }
    public partial class OutputItemMessageBuilder : Azure.AI.AgentServer.Responses.OutputItemBuilder<Azure.AI.AgentServer.Responses.Models.OutputItemOutputMessage>
    {
        protected OutputItemMessageBuilder() { }
        public virtual Azure.AI.AgentServer.Responses.RefusalContentBuilder AddRefusalContent() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.TextContentBuilder AddTextContent() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseOutputItemAddedEvent EmitAdded() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseContentPartDoneEvent EmitContentDone(Azure.AI.AgentServer.Responses.RefusalContentBuilder refusalContent) { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseContentPartDoneEvent EmitContentDone(Azure.AI.AgentServer.Responses.TextContentBuilder textContent) { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseOutputItemDoneEvent EmitDone() { throw null; }
    }
    public partial class OutputItemReasoningItemBuilder : Azure.AI.AgentServer.Responses.OutputItemBuilder<Azure.AI.AgentServer.Responses.Models.OutputItemReasoningItem>
    {
        protected OutputItemReasoningItemBuilder() { }
        public virtual Azure.AI.AgentServer.Responses.ReasoningSummaryPartBuilder AddSummaryPart() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseOutputItemAddedEvent EmitAdded() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseOutputItemDoneEvent EmitDone() { throw null; }
        public virtual void EmitSummaryPartDone(Azure.AI.AgentServer.Responses.ReasoningSummaryPartBuilder summaryPart) { }
    }
    public partial class OutputItemWebSearchCallBuilder : Azure.AI.AgentServer.Responses.OutputItemBuilder<Azure.AI.AgentServer.Responses.Models.OutputItemWebSearchToolCall>
    {
        protected OutputItemWebSearchCallBuilder() { }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseOutputItemAddedEvent EmitAdded() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseWebSearchCallCompletedEvent EmitCompleted() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseOutputItemDoneEvent EmitDone() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseWebSearchCallInProgressEvent EmitInProgress() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseWebSearchCallSearchingEvent EmitSearching() { throw null; }
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
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseReasoningSummaryPartAddedEvent EmitAdded() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseReasoningSummaryPartDoneEvent EmitDone() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseReasoningSummaryTextDeltaEvent EmitTextDelta(string text) { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseReasoningSummaryTextDoneEvent EmitTextDone(string finalText) { throw null; }
    }
    public partial class RefusalContentBuilder
    {
        protected RefusalContentBuilder() { }
        public long ContentIndex { get { throw null; } }
        public string? FinalRefusal { get { throw null; } }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseContentPartAddedEvent EmitAdded() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseRefusalDeltaEvent EmitDelta(string text) { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseRefusalDoneEvent EmitDone(string finalRefusal) { throw null; }
    }
    public partial class ResourceNotFoundException : System.Exception
    {
        public ResourceNotFoundException(string message) { }
        public ResourceNotFoundException(string message, System.Exception innerException) { }
    }
    public static partial class ResponseContextExtensions
    {
        public static string NewCodeInterpreterCallItemId(this Azure.AI.AgentServer.Responses.IResponseContext context) { throw null; }
        public static string NewCustomToolCallItemId(this Azure.AI.AgentServer.Responses.IResponseContext context) { throw null; }
        public static string NewFileSearchCallItemId(this Azure.AI.AgentServer.Responses.IResponseContext context) { throw null; }
        public static string NewFunctionCallItemId(this Azure.AI.AgentServer.Responses.IResponseContext context) { throw null; }
        public static string NewImageGenCallItemId(this Azure.AI.AgentServer.Responses.IResponseContext context) { throw null; }
        public static string NewMcpCallItemId(this Azure.AI.AgentServer.Responses.IResponseContext context) { throw null; }
        public static string NewMcpListToolsItemId(this Azure.AI.AgentServer.Responses.IResponseContext context) { throw null; }
        public static string NewMessageItemId(this Azure.AI.AgentServer.Responses.IResponseContext context) { throw null; }
        public static string NewReasoningItemId(this Azure.AI.AgentServer.Responses.IResponseContext context) { throw null; }
        public static string NewWebSearchCallItemId(this Azure.AI.AgentServer.Responses.IResponseContext context) { throw null; }
    }
    public partial class ResponseEventStream
    {
        protected ResponseEventStream() { }
        public ResponseEventStream(Azure.AI.AgentServer.Responses.IResponseContext context, Azure.AI.AgentServer.Responses.Models.CreateResponse request) { }
        public Azure.AI.AgentServer.Responses.Models.Response Response { get { throw null; } }
        public virtual Azure.AI.AgentServer.Responses.OutputItemCodeInterpreterCallBuilder AddOutputItemCodeInterpreterCall() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemCustomToolCallBuilder AddOutputItemCustomToolCall(string callId, string name) { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemFileSearchCallBuilder AddOutputItemFileSearchCall() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemFunctionCallBuilder AddOutputItemFunctionCall(string name, string callId) { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemImageGenCallBuilder AddOutputItemImageGenCall() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemMcpCallBuilder AddOutputItemMcpCall(string serverLabel, string name) { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemMcpListToolsBuilder AddOutputItemMcpListTools(string serverLabel) { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemMessageBuilder AddOutputItemMessage() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemReasoningItemBuilder AddOutputItemReasoningItem() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemWebSearchCallBuilder AddOutputItemWebSearchCall() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.OutputItemBuilder<T> AddOutputItem<T>(string itemId) where T : Azure.AI.AgentServer.Responses.Models.OutputItem { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseCompletedEvent EmitCompleted(Azure.AI.AgentServer.Responses.Models.ResponseUsage? usage = null) { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseCreatedEvent EmitCreated(Azure.AI.AgentServer.Responses.Models.ResponseStatus status = Azure.AI.AgentServer.Responses.Models.ResponseStatus.InProgress) { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseFailedEvent EmitFailed(Azure.AI.AgentServer.Responses.Models.ResponseErrorCode code = Azure.AI.AgentServer.Responses.Models.ResponseErrorCode.ServerError, string message = "An internal server error occurred.", Azure.AI.AgentServer.Responses.Models.ResponseUsage? usage = null) { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseIncompleteEvent EmitIncomplete(Azure.AI.AgentServer.Responses.Models.ResponseIncompleteDetailsReason? reason = default(Azure.AI.AgentServer.Responses.Models.ResponseIncompleteDetailsReason?), Azure.AI.AgentServer.Responses.Models.ResponseUsage? usage = null) { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseInProgressEvent EmitInProgress() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseQueuedEvent EmitQueued() { throw null; }
        public virtual long NextSequenceNumber() { throw null; }
    }
    public partial class ResponsesActivitySource
    {
        public const string DefaultName = "Azure.AI.AgentServer.Responses";
        public const string DefaultProviderName = "AzureAI Hosted Agents";
        public const string DefaultServiceName = "azure.ai.agentserver";
        public ResponsesActivitySource() { }
        protected ResponsesActivitySource(string? name) { }
        public string Name { get { throw null; } }
        protected System.Diagnostics.ActivitySource Source { get { throw null; } }
        public virtual System.Diagnostics.Activity? StartCreateResponseActivity(Azure.AI.AgentServer.Responses.Models.CreateResponse request, string responseId, Microsoft.AspNetCore.Http.IHeaderDictionary headers) { throw null; }
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
        public static Azure.AI.AgentServer.Hosting.AgentHostBuilder AddResponses(this Azure.AI.AgentServer.Hosting.AgentHostBuilder builder, Azure.AI.AgentServer.Responses.IResponseHandler handler, System.Action<Azure.AI.AgentServer.Responses.ResponsesServerOptions>? configure = null) { throw null; }
        public static Azure.AI.AgentServer.Hosting.AgentHostBuilder AddResponses<THandler>(this Azure.AI.AgentServer.Hosting.AgentHostBuilder builder, System.Action<Azure.AI.AgentServer.Responses.ResponsesServerOptions>? configure = null) where THandler : class, Azure.AI.AgentServer.Responses.IResponseHandler { throw null; }
    }
    public static partial class ResponsesServer
    {
        public static void Run<THandler>(string[]? args = null, System.Action<Azure.AI.AgentServer.Hosting.AgentHostBuilder>? configure = null) where THandler : class, Azure.AI.AgentServer.Responses.IResponseHandler { }
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
    public static partial class ResponsesTracingConstants
    {
        public const string OperationName = "create_response";
        public const string ProviderName = "AzureAI Hosted Agents";
        public const string ServiceName = "azure.ai.agentserver";
        public static partial class Baggage
        {
            public const string ConversationId = "azure.ai.agentserver.conversation_id";
            public const string RequestId = "azure.ai.agentserver.x-request-id";
            public const string ResponseId = "azure.ai.agentserver.response_id";
            public const string Streaming = "azure.ai.agentserver.streaming";
        }
        public static partial class LogScope
        {
            public const string ConversationId = "ConversationId";
            public const string ResponseId = "ResponseId";
            public const string Streaming = "Streaming";
        }
        public static partial class Tags
        {
            public const string AgentId = "gen_ai.agent.id";
            public const string AgentName = "gen_ai.agent.name";
            public const string AgentVersion = "gen_ai.agent.version";
            public const string ConversationId = "gen_ai.conversation.id";
            public const string ErrorCode = "azure.ai.agentserver.responses.error.code";
            public const string ErrorMessage = "azure.ai.agentserver.responses.error.message";
            public const string NamespacedConversationId = "azure.ai.agentserver.responses.conversation_id";
            public const string NamespacedResponseId = "azure.ai.agentserver.responses.response_id";
            public const string NamespacedStreaming = "azure.ai.agentserver.responses.streaming";
            public const string OperationName = "gen_ai.operation.name";
            public const string ProviderName = "gen_ai.provider.name";
            public const string RequestModel = "gen_ai.request.model";
            public const string ResponseId = "gen_ai.response.id";
            public const string ServiceName = "service.name";
            public const string System = "gen_ai.system";
        }
    }
    public partial class TextContentBuilder
    {
        protected TextContentBuilder() { }
        public long ContentIndex { get { throw null; } }
        public string? FinalText { get { throw null; } }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseContentPartAddedEvent EmitAdded() { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseOutputTextAnnotationAddedEvent EmitAnnotationAdded(Azure.AI.AgentServer.Responses.Models.Annotation annotation) { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseTextDeltaEvent EmitDelta(string text) { throw null; }
        public virtual Azure.AI.AgentServer.Responses.Models.ResponseTextDoneEvent EmitDone(string finalText) { throw null; }
    }
}
