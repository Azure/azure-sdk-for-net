namespace Azure.AI.AgentServer.Invocations
{
    public sealed partial class InvocationContext
    {
        public InvocationContext(string invocationId, string sessionId, System.Collections.Generic.IReadOnlyDictionary<string, string> clientHeaders, System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Extensions.Primitives.StringValues> queryParameters, Azure.AI.AgentServer.Core.PlatformContext platformContext) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ClientHeaders { get { throw null; } }
        public string InvocationId { get { throw null; } }
        public Azure.AI.AgentServer.Core.PlatformContext PlatformContext { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Extensions.Primitives.StringValues> QueryParameters { get { throw null; } }
        public string SessionId { get { throw null; } }
    }
    public abstract partial class InvocationHandler
    {
        protected InvocationHandler() { }
        public virtual System.Threading.Tasks.Task CancelAsync(string invocationId, Microsoft.AspNetCore.Http.HttpRequest request, Microsoft.AspNetCore.Http.HttpResponse response, Azure.AI.AgentServer.Invocations.InvocationContext context, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task GetAsync(string invocationId, Microsoft.AspNetCore.Http.HttpRequest request, Microsoft.AspNetCore.Http.HttpResponse response, Azure.AI.AgentServer.Invocations.InvocationContext context, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task GetAsyncApiJsonAsync(Microsoft.AspNetCore.Http.HttpRequest request, Microsoft.AspNetCore.Http.HttpResponse response, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task GetAsyncApiYamlAsync(Microsoft.AspNetCore.Http.HttpRequest request, Microsoft.AspNetCore.Http.HttpResponse response, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task GetOpenApiAsync(Microsoft.AspNetCore.Http.HttpRequest request, Microsoft.AspNetCore.Http.HttpResponse response, System.Threading.CancellationToken cancellationToken) { throw null; }
        public abstract System.Threading.Tasks.Task HandleAsync(Microsoft.AspNetCore.Http.HttpRequest request, Microsoft.AspNetCore.Http.HttpResponse response, Azure.AI.AgentServer.Invocations.InvocationContext context, System.Threading.CancellationToken cancellationToken);
    }
    public static partial class InvocationsBuilderExtensions
    {
        public static Azure.AI.AgentServer.Core.AgentHostBuilder AddInvocations(this Azure.AI.AgentServer.Core.AgentHostBuilder builder, Azure.AI.AgentServer.Invocations.InvocationHandler handler, System.Action<Azure.AI.AgentServer.Invocations.InvocationsServerOptions>? configure = null) { throw null; }
        public static Azure.AI.AgentServer.Core.AgentHostBuilder AddInvocations(this Azure.AI.AgentServer.Core.AgentHostBuilder builder, System.Func<System.IServiceProvider, Azure.AI.AgentServer.Invocations.InvocationHandler> factory, System.Action<Azure.AI.AgentServer.Invocations.InvocationsServerOptions>? configure = null) { throw null; }
        public static Azure.AI.AgentServer.Core.AgentHostBuilder AddInvocations<THandler>(this Azure.AI.AgentServer.Core.AgentHostBuilder builder, System.Action<Azure.AI.AgentServer.Invocations.InvocationsServerOptions>? configure = null) where THandler : Azure.AI.AgentServer.Invocations.InvocationHandler { throw null; }
    }
    public static partial class InvocationsServer
    {
        public static void Run(System.Func<System.IServiceProvider, Azure.AI.AgentServer.Invocations.InvocationHandler> factory, string[]? args = null, System.Action<Azure.AI.AgentServer.Core.AgentHostBuilder>? configure = null) { }
        public static void Run<THandler>(string[]? args = null, System.Action<Azure.AI.AgentServer.Core.AgentHostBuilder>? configure = null) where THandler : Azure.AI.AgentServer.Invocations.InvocationHandler { }
    }
    public static partial class InvocationsServerEndpointRouteBuilderExtensions
    {
        public static Microsoft.AspNetCore.Routing.RouteGroupBuilder MapInvocationsServer(this Microsoft.AspNetCore.Routing.IEndpointRouteBuilder endpoints, string? prefix = null) { throw null; }
    }
    public partial class InvocationsServerOptions
    {
        public InvocationsServerOptions() { }
    }
    public static partial class InvocationsServerServiceCollectionExtensions
    {
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddInvocationsServer(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, System.Action<Azure.AI.AgentServer.Invocations.InvocationsServerOptions>? configure = null) { throw null; }
    }
    public abstract partial class InvocationWebSocketHandler : Azure.AI.AgentServer.Invocations.InvocationHandler
    {
        protected InvocationWebSocketHandler() { }
        public override System.Threading.Tasks.Task HandleAsync(Microsoft.AspNetCore.Http.HttpRequest request, Microsoft.AspNetCore.Http.HttpResponse response, Azure.AI.AgentServer.Invocations.InvocationContext context, System.Threading.CancellationToken cancellationToken) { throw null; }
        public abstract System.Threading.Tasks.Task HandleWebSocketAsync(System.Net.WebSockets.WebSocket webSocket, Azure.AI.AgentServer.Invocations.InvocationContext context, System.Threading.CancellationToken cancellationToken);
    }
}
namespace Azure.AI.AgentServer.Invocations.Voice
{
    public sealed partial class VoiceBargeInEvent : Azure.AI.AgentServer.Invocations.Voice.VoiceInboundMessage
    {
        public VoiceBargeInEvent(string id, System.DateTimeOffset timestamp, string responseId, string heardText, string? itemId = null) { }
        public string HeardText { get { throw null; } }
        public string? ItemId { get { throw null; } }
        public string ResponseId { get { throw null; } }
    }
    public sealed partial class VoiceEndCallMessage : Azure.AI.AgentServer.Invocations.Voice.VoiceOutboundMessage
    {
        public VoiceEndCallMessage(string reason, Azure.AI.AgentServer.Invocations.Voice.VoiceEndCallMode mode = Azure.AI.AgentServer.Invocations.Voice.VoiceEndCallMode.Drain, string? id = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?)) { }
        public Azure.AI.AgentServer.Invocations.Voice.VoiceEndCallMode Mode { get { throw null; } }
        public string Reason { get { throw null; } }
    }
    public enum VoiceEndCallMode
    {
        Drain = 0,
        Immediate = 1,
    }
    public sealed partial class VoiceErrorMessage : Azure.AI.AgentServer.Invocations.Voice.VoiceOutboundMessage
    {
        public VoiceErrorMessage(string code, string message, string? responseId = null, string? itemId = null, string? id = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?)) { }
        public string Code { get { throw null; } }
        public string? ItemId { get { throw null; } }
        public string Message { get { throw null; } }
        public string? ResponseId { get { throw null; } }
    }
    public abstract partial class VoiceHandler : Azure.AI.AgentServer.Invocations.InvocationWebSocketHandler
    {
        protected VoiceHandler() { }
        public sealed override System.Threading.Tasks.Task HandleWebSocketAsync(System.Net.WebSockets.WebSocket webSocket, Azure.AI.AgentServer.Invocations.InvocationContext context, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected virtual System.Threading.Tasks.Task OnBargeInAsync(Azure.AI.AgentServer.Invocations.Voice.VoiceSession session, Azure.AI.AgentServer.Invocations.Voice.VoiceBargeInEvent bargeIn, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected virtual void OnConnectionTerminating(Azure.AI.AgentServer.Invocations.Voice.VoiceSession session) { }
        protected virtual System.Threading.Tasks.Task OnResponseAcceptedAsync(Azure.AI.AgentServer.Invocations.Voice.VoiceSession session, Azure.AI.AgentServer.Invocations.Voice.VoiceResponseAcceptedEvent accepted, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected virtual System.Threading.Tasks.Task OnResponseCancelledAsync(Azure.AI.AgentServer.Invocations.Voice.VoiceSession session, Azure.AI.AgentServer.Invocations.Voice.VoiceResponseCancelledEvent cancelled, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected virtual System.Threading.Tasks.Task OnResponseDroppedAsync(Azure.AI.AgentServer.Invocations.Voice.VoiceSession session, Azure.AI.AgentServer.Invocations.Voice.VoiceResponseDroppedEvent dropped, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected virtual System.Threading.Tasks.Task OnResponseTimeoutAsync(Azure.AI.AgentServer.Invocations.Voice.VoiceSession session, Azure.AI.AgentServer.Invocations.Voice.VoiceResponseTimeoutEvent timeout, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected virtual System.Threading.Tasks.Task OnSessionEndAsync(Azure.AI.AgentServer.Invocations.Voice.VoiceSession session, Azure.AI.AgentServer.Invocations.Voice.VoiceSessionEndEvent end, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected virtual System.Threading.Tasks.Task OnSessionStartAsync(Azure.AI.AgentServer.Invocations.Voice.VoiceSession session, Azure.AI.AgentServer.Invocations.Voice.VoiceSessionStartEvent start, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected virtual System.Threading.Tasks.Task OnUserMessageAsync(Azure.AI.AgentServer.Invocations.Voice.VoiceSession session, Azure.AI.AgentServer.Invocations.Voice.VoiceUserMessageEvent message, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected virtual System.Threading.Tasks.Task OnUserNoInputAsync(Azure.AI.AgentServer.Invocations.Voice.VoiceSession session, Azure.AI.AgentServer.Invocations.Voice.VoiceUserNoInputEvent noInput, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected virtual System.Threading.Tasks.Task OnUserSpeechStartedAsync(Azure.AI.AgentServer.Invocations.Voice.VoiceSession session, Azure.AI.AgentServer.Invocations.Voice.VoiceUserSpeechStartedEvent speechStarted, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public static partial class VoiceHostingExtensions
    {
        public static Azure.AI.AgentServer.Core.AgentHostBuilder AddVoice<THandler>(this Azure.AI.AgentServer.Core.AgentHostBuilder builder, System.Action<Azure.AI.AgentServer.Invocations.InvocationsServerOptions>? configure = null) where THandler : Azure.AI.AgentServer.Invocations.Voice.VoiceHandler { throw null; }
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddVoice<THandler>(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, System.Action<Azure.AI.AgentServer.Invocations.InvocationsServerOptions>? configure = null) where THandler : Azure.AI.AgentServer.Invocations.Voice.VoiceHandler { throw null; }
    }
    public static partial class VoiceIds
    {
        public static string CreateItemId() { throw null; }
        public static string CreateMessageId() { throw null; }
        public static string CreateResponseId() { throw null; }
    }
    public abstract partial class VoiceInboundMessage
    {
        internal VoiceInboundMessage() { }
        public string Id { get { throw null; } }
        public string MessageType { get { throw null; } }
        public System.DateTimeOffset Timestamp { get { throw null; } }
        public override string ToString() { throw null; }
    }
    public sealed partial class VoiceInputTextPart
    {
        public VoiceInputTextPart(string text) { }
        public string Text { get { throw null; } }
        public override string ToString() { throw null; }
    }
    public abstract partial class VoiceOutboundMessage
    {
        internal VoiceOutboundMessage() { }
        public string Id { get { throw null; } }
        public string MessageType { get { throw null; } }
        public System.DateTimeOffset Timestamp { get { throw null; } }
        public override string ToString() { throw null; }
    }
    public sealed partial class VoiceResponseAcceptedEvent : Azure.AI.AgentServer.Invocations.Voice.VoiceInboundMessage
    {
        public VoiceResponseAcceptedEvent(string id, System.DateTimeOffset timestamp, string responseId) { }
        public string ResponseId { get { throw null; } }
    }
    public sealed partial class VoiceResponseCancelledEvent : Azure.AI.AgentServer.Invocations.Voice.VoiceInboundMessage
    {
        public VoiceResponseCancelledEvent(string id, System.DateTimeOffset timestamp, string responseId, string heardText, string? itemId = null) { }
        public string HeardText { get { throw null; } }
        public string? ItemId { get { throw null; } }
        public string ResponseId { get { throw null; } }
    }
    public sealed partial class VoiceResponseCancelMessage : Azure.AI.AgentServer.Invocations.Voice.VoiceOutboundMessage
    {
        public VoiceResponseCancelMessage(string responseId, string? reason = null, string? id = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?)) { }
        public string? Reason { get { throw null; } }
        public string ResponseId { get { throw null; } }
    }
    public sealed partial class VoiceResponseCreatedMessage : Azure.AI.AgentServer.Invocations.Voice.VoiceOutboundMessage
    {
        public VoiceResponseCreatedMessage(string responseId, System.Collections.Generic.IEnumerable<string>? inReplyTo = null, int? admissionTimeoutMs = default(int?), string? supersedeKey = null, string? id = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?)) { }
        public int? AdmissionTimeoutMs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string>? InReplyTo { get { throw null; } }
        public string ResponseId { get { throw null; } }
        public string? SupersedeKey { get { throw null; } }
    }
    public sealed partial class VoiceResponseDoneMessage : Azure.AI.AgentServer.Invocations.Voice.VoiceOutboundMessage
    {
        public VoiceResponseDoneMessage(string responseId, string? id = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?)) { }
        public string ResponseId { get { throw null; } }
    }
    public sealed partial class VoiceResponseDroppedEvent : Azure.AI.AgentServer.Invocations.Voice.VoiceInboundMessage
    {
        public VoiceResponseDroppedEvent(string id, System.DateTimeOffset timestamp, string responseId, string reason) { }
        public string Reason { get { throw null; } }
        public string ResponseId { get { throw null; } }
    }
    public sealed partial class VoiceResponseNoneMessage : Azure.AI.AgentServer.Invocations.Voice.VoiceOutboundMessage
    {
        public VoiceResponseNoneMessage(System.Collections.Generic.IEnumerable<string> inReplyTo, string? reason = null, string? id = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?)) { }
        public System.Collections.Generic.IReadOnlyList<string> InReplyTo { get { throw null; } }
        public string? Reason { get { throw null; } }
    }
    public sealed partial class VoiceResponseOutputTextDeltaMessage : Azure.AI.AgentServer.Invocations.Voice.VoiceOutboundMessage
    {
        public VoiceResponseOutputTextDeltaMessage(string responseId, string itemId, string delta, System.BinaryData? voice = null, string? id = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?)) { }
        public string Delta { get { throw null; } }
        public string ItemId { get { throw null; } }
        public string ResponseId { get { throw null; } }
        public System.BinaryData? Voice { get { throw null; } }
    }
    public sealed partial class VoiceResponseOutputTextDoneMessage : Azure.AI.AgentServer.Invocations.Voice.VoiceOutboundMessage
    {
        public VoiceResponseOutputTextDoneMessage(string responseId, string itemId, string text, System.BinaryData? voice = null, string? id = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?)) { }
        public string ItemId { get { throw null; } }
        public string ResponseId { get { throw null; } }
        public string Text { get { throw null; } }
        public System.BinaryData? Voice { get { throw null; } }
    }
    public sealed partial class VoiceResponseTimeoutEvent : Azure.AI.AgentServer.Invocations.Voice.VoiceInboundMessage
    {
        public VoiceResponseTimeoutEvent(string id, System.DateTimeOffset timestamp, string stage, string? responseId = null, System.Collections.Generic.IEnumerable<string>? itemIds = null) { }
        public System.Collections.Generic.IReadOnlyList<string>? ItemIds { get { throw null; } }
        public string? ResponseId { get { throw null; } }
        public string Stage { get { throw null; } }
    }
    public sealed partial class VoiceResponseTimeouts
    {
        public VoiceResponseTimeouts(int firstOutputMs, int idleMs, int maxDurationMs) { }
        public int FirstOutputMs { get { throw null; } }
        public int IdleMs { get { throw null; } }
        public int MaxDurationMs { get { throw null; } }
    }
    public static partial class VoiceServer
    {
        public static void Run<THandler>(string[]? args = null, System.Action<Azure.AI.AgentServer.Core.AgentHostBuilder>? configure = null) where THandler : Azure.AI.AgentServer.Invocations.Voice.VoiceHandler { }
    }
    public partial class VoiceSession
    {
        protected VoiceSession() { }
        protected VoiceSession(Azure.AI.AgentServer.Invocations.InvocationContext invocationContext) { }
        public virtual Azure.AI.AgentServer.Invocations.InvocationContext InvocationContext { get { throw null; } }
        public virtual System.Threading.Tasks.Task SendAsync(Azure.AI.AgentServer.Invocations.Voice.VoiceOutboundMessage message, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public sealed partial class VoiceSessionEndEvent : Azure.AI.AgentServer.Invocations.Voice.VoiceInboundMessage
    {
        public VoiceSessionEndEvent(string id, System.DateTimeOffset timestamp, string reason) { }
        public string Reason { get { throw null; } }
    }
    public sealed partial class VoiceSessionReadyMessage : Azure.AI.AgentServer.Invocations.Voice.VoiceOutboundMessage
    {
        public VoiceSessionReadyMessage(string? id = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?)) { }
    }
    public sealed partial class VoiceSessionRejectedMessage : Azure.AI.AgentServer.Invocations.Voice.VoiceOutboundMessage
    {
        public VoiceSessionRejectedMessage(string code, bool retriable, string? message = null, string? id = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?)) { }
        public string Code { get { throw null; } }
        public string? Message { get { throw null; } }
        public bool Retriable { get { throw null; } }
    }
    public sealed partial class VoiceSessionStartEvent : Azure.AI.AgentServer.Invocations.Voice.VoiceInboundMessage
    {
        public VoiceSessionStartEvent(string id, System.DateTimeOffset timestamp, string protocolVersion, bool reconnect, Azure.AI.AgentServer.Invocations.Voice.VoiceResponseTimeouts responseTimeouts, string? greeting, int? noInputTimeoutMs, System.BinaryData? caller) { }
        public System.BinaryData? Caller { get { throw null; } }
        public string? Greeting { get { throw null; } }
        public int? NoInputTimeoutMs { get { throw null; } }
        public string ProtocolVersion { get { throw null; } }
        public bool Reconnect { get { throw null; } }
        public Azure.AI.AgentServer.Invocations.Voice.VoiceResponseTimeouts ResponseTimeouts { get { throw null; } }
    }
    public sealed partial class VoiceUserMessageEvent : Azure.AI.AgentServer.Invocations.Voice.VoiceInboundMessage
    {
        public VoiceUserMessageEvent(string id, System.DateTimeOffset timestamp, string itemId, System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Invocations.Voice.VoiceInputTextPart> content) { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Invocations.Voice.VoiceInputTextPart> Content { get { throw null; } }
        public string ItemId { get { throw null; } }
    }
    public sealed partial class VoiceUserNoInputEvent : Azure.AI.AgentServer.Invocations.Voice.VoiceInboundMessage
    {
        public VoiceUserNoInputEvent(string id, System.DateTimeOffset timestamp, string itemId, int count) { }
        public int Count { get { throw null; } }
        public string ItemId { get { throw null; } }
    }
    public sealed partial class VoiceUserSpeechStartedEvent : Azure.AI.AgentServer.Invocations.Voice.VoiceInboundMessage
    {
        public VoiceUserSpeechStartedEvent(string id, System.DateTimeOffset timestamp) { }
    }
}
