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
    public sealed partial class BargeInEvent
    {
        internal BargeInEvent() { }
        public string HeardText { get { throw null; } }
        public string? ItemId { get { throw null; } }
        public string ResponseId { get { throw null; } }
    }
    public sealed partial class HandoffFailedEvent
    {
        internal HandoffFailedEvent() { }
        public string Code { get { throw null; } }
        public string ItemId { get { throw null; } }
        public string? Message { get { throw null; } }
        public string Target { get { throw null; } }
    }
    public sealed partial class InputImagePart : Azure.AI.AgentServer.Invocations.Voice.VoiceContentPart
    {
        internal InputImagePart() { }
        public string? Alt { get { throw null; } }
        public string ImageRef { get { throw null; } }
        public string MimeType { get { throw null; } }
    }
    public sealed partial class InputTextPart : Azure.AI.AgentServer.Invocations.Voice.VoiceContentPart
    {
        internal InputTextPart() { }
        public string Text { get { throw null; } }
    }
    public sealed partial class ResponseCancellationOutcome
    {
        internal ResponseCancellationOutcome() { }
        public string HeardText { get { throw null; } }
        public string? ItemId { get { throw null; } }
        public string Kind { get { throw null; } }
        public string ResponseId { get { throw null; } }
    }
    public sealed partial class ResponseTimeoutEvent
    {
        internal ResponseTimeoutEvent() { }
        public System.Collections.Generic.IReadOnlyList<string>? ItemIds { get { throw null; } }
        public string? ResponseId { get { throw null; } }
        public string Stage { get { throw null; } }
    }
    public sealed partial class ResponseTimeouts
    {
        internal ResponseTimeouts() { }
        public int FirstOutputMs { get { throw null; } }
        public int IdleMs { get { throw null; } }
        public int MaxDurationMs { get { throw null; } }
    }
    public sealed partial class SessionEndEvent
    {
        internal SessionEndEvent() { }
        public string Reason { get { throw null; } }
    }
    public sealed partial class SessionStartEvent
    {
        internal SessionStartEvent() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, object?>? Caller { get { throw null; } }
        public string? Greeting { get { throw null; } }
        public int? NoInputTimeoutMs { get { throw null; } }
        public string ProtocolVersion { get { throw null; } }
        public bool Reconnect { get { throw null; } }
        public Azure.AI.AgentServer.Invocations.Voice.ResponseTimeouts ResponseTimeouts { get { throw null; } }
    }
    public sealed partial class UserMessageEvent
    {
        internal UserMessageEvent() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Invocations.Voice.VoiceContentPart> Content { get { throw null; } }
        public string ItemId { get { throw null; } }
        public string Text { get { throw null; } }
    }
    public sealed partial class UserNoInputEvent
    {
        internal UserNoInputEvent() { }
        public int Count { get { throw null; } }
        public string ItemId { get { throw null; } }
    }
    public sealed partial class UserSpeechStartedEvent
    {
        internal UserSpeechStartedEvent() { }
    }
    public sealed partial class VoiceBridgeConnectionClosedException : System.InvalidOperationException
    {
        public VoiceBridgeConnectionClosedException(string message) { }
    }
    public sealed partial class VoiceBridgeProtocolException : System.Exception
    {
        public VoiceBridgeProtocolException(string message, int closeCode = 1002) { }
        public int CloseCode { get { throw null; } }
    }
    public static partial class VoiceBuilderExtensions
    {
        public static Azure.AI.AgentServer.Core.AgentHostBuilder AddVoice<THandler>(this Azure.AI.AgentServer.Core.AgentHostBuilder builder, System.Action<Azure.AI.AgentServer.Invocations.InvocationsServerOptions>? configure = null) where THandler : Azure.AI.AgentServer.Invocations.Voice.VoiceHandler { throw null; }
    }
    public abstract partial class VoiceContentPart
    {
        internal VoiceContentPart() { }
    }
    public abstract partial class VoiceHandler : Azure.AI.AgentServer.Invocations.InvocationWebSocketHandler
    {
        protected VoiceHandler() { }
        public sealed override System.Threading.Tasks.Task HandleWebSocketAsync(System.Net.WebSockets.WebSocket webSocket, Azure.AI.AgentServer.Invocations.InvocationContext context, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected virtual System.Threading.Tasks.Task OnBargeInAsync(Azure.AI.AgentServer.Invocations.Voice.VoiceSession session, Azure.AI.AgentServer.Invocations.Voice.BargeInEvent bargeIn, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected virtual System.Threading.Tasks.Task OnHandoffFailedAsync(Azure.AI.AgentServer.Invocations.Voice.VoiceSession session, Azure.AI.AgentServer.Invocations.Voice.HandoffFailedEvent failure, Azure.AI.AgentServer.Invocations.Voice.VoiceResponse response, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected virtual System.Threading.Tasks.Task OnResponseTimeoutAsync(Azure.AI.AgentServer.Invocations.Voice.VoiceSession session, Azure.AI.AgentServer.Invocations.Voice.ResponseTimeoutEvent timeout, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected virtual System.Threading.Tasks.Task OnSessionEndAsync(Azure.AI.AgentServer.Invocations.Voice.VoiceSession session, Azure.AI.AgentServer.Invocations.Voice.SessionEndEvent sessionEnd, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected virtual System.Threading.Tasks.Task OnSessionStartAsync(Azure.AI.AgentServer.Invocations.Voice.VoiceSession session, Azure.AI.AgentServer.Invocations.Voice.SessionStartEvent startEvent, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected abstract System.Threading.Tasks.Task OnUserMessageAsync(Azure.AI.AgentServer.Invocations.Voice.VoiceSession session, Azure.AI.AgentServer.Invocations.Voice.UserMessageEvent message, Azure.AI.AgentServer.Invocations.Voice.VoiceResponse response, System.Threading.CancellationToken cancellationToken);
        protected virtual System.Threading.Tasks.Task OnUserNoInputAsync(Azure.AI.AgentServer.Invocations.Voice.VoiceSession session, Azure.AI.AgentServer.Invocations.Voice.UserNoInputEvent noInput, Azure.AI.AgentServer.Invocations.Voice.VoiceResponse response, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected virtual System.Threading.Tasks.Task OnUserSpeechStartedAsync(Azure.AI.AgentServer.Invocations.Voice.VoiceSession session, Azure.AI.AgentServer.Invocations.Voice.UserSpeechStartedEvent speechStarted, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public static partial class VoiceModelFactory
    {
        public static Azure.AI.AgentServer.Invocations.Voice.BargeInEvent BargeInEvent(string responseId = "r_test", string heardText = "", string? itemId = null) { throw null; }
        public static Azure.AI.AgentServer.Invocations.Voice.HandoffFailedEvent HandoffFailedEvent(string itemId = "in_test", string target = "target-agent", string code = "target_unavailable", string? message = null) { throw null; }
        public static Azure.AI.AgentServer.Invocations.Voice.InputImagePart InputImagePart(string imageRef = "https://example.invalid/image", string mimeType = "image/png", string? alt = null) { throw null; }
        public static Azure.AI.AgentServer.Invocations.Voice.InputTextPart InputTextPart(string text = "") { throw null; }
        public static Azure.AI.AgentServer.Invocations.Voice.ResponseCancellationOutcome ResponseCancellationOutcome(string responseId = "r_test", string kind = "cancelled", string heardText = "", string? itemId = null) { throw null; }
        public static Azure.AI.AgentServer.Invocations.Voice.ResponseTimeoutEvent ResponseTimeoutEvent(string stage = "first_output", string responseId = "r_test") { throw null; }
        public static Azure.AI.AgentServer.Invocations.Voice.ResponseTimeoutEvent ResponseTimeoutEventForItems(System.Collections.Generic.IEnumerable<string> itemIds, string stage = "first_output") { throw null; }
        public static Azure.AI.AgentServer.Invocations.Voice.ResponseTimeouts ResponseTimeouts(int firstOutputMs = 15000, int idleMs = 30000, int maxDurationMs = 120000) { throw null; }
        public static Azure.AI.AgentServer.Invocations.Voice.SessionEndEvent SessionEndEvent(string reason = "caller_hangup") { throw null; }
        public static Azure.AI.AgentServer.Invocations.Voice.SessionStartEvent SessionStartEvent(bool reconnect = false, Azure.AI.AgentServer.Invocations.Voice.ResponseTimeouts? responseTimeouts = null, string? greeting = null, int? noInputTimeoutMs = default(int?), System.Collections.Generic.IReadOnlyDictionary<string, object?>? caller = null) { throw null; }
        public static Azure.AI.AgentServer.Invocations.Voice.UserMessageEvent UserMessageEvent(string itemId = "in_test", System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Invocations.Voice.VoiceContentPart>? content = null) { throw null; }
        public static Azure.AI.AgentServer.Invocations.Voice.UserNoInputEvent UserNoInputEvent(string itemId = "in_test", int count = 1) { throw null; }
        public static Azure.AI.AgentServer.Invocations.Voice.UserSpeechStartedEvent UserSpeechStartedEvent() { throw null; }
    }
    public sealed partial class VoiceProactiveResponseDroppedException : System.InvalidOperationException
    {
        public VoiceProactiveResponseDroppedException(string responseId, string reason) { }
        public string Reason { get { throw null; } }
        public string ResponseId { get { throw null; } }
    }
    public partial class VoiceResponse
    {
        protected VoiceResponse() { }
        public virtual System.Threading.CancellationToken CancellationToken { get { throw null; } }
        public virtual System.Collections.Generic.IReadOnlyList<string>? InReplyTo { get { throw null; } }
        public virtual bool IsCancelPending { get { throw null; } }
        public virtual bool IsTerminal { get { throw null; } }
        public virtual string ResponseId { get { throw null; } }
        public virtual System.Threading.Tasks.Task<Azure.AI.AgentServer.Invocations.Voice.ResponseCancellationOutcome> CancelAsync(string? reason = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task CompleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.AgentServer.Invocations.Voice.VoiceTextItem CreateTextItem() { throw null; }
        public virtual System.Threading.Tasks.Task DeclineAsync(string? reason = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task FailAsync(string code, string message, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task HandoffAsync(string target, string? message = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SendTextAsync(string text, System.Collections.Generic.IReadOnlyDictionary<string, object?>? voice, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SendTextAsync(string text, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SendTextDeltaAsync(string delta, System.Collections.Generic.IReadOnlyDictionary<string, object?>? voice, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SendTextDeltaAsync(string delta, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SendTextDoneAsync(System.Collections.Generic.IReadOnlyDictionary<string, object?>? voice, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SendTextDoneAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class VoiceServer
    {
        public static void Run<THandler>(string[]? args = null, System.Action<Azure.AI.AgentServer.Core.AgentHostBuilder>? configure = null) where THandler : Azure.AI.AgentServer.Invocations.Voice.VoiceHandler { }
    }
    public partial class VoiceSession
    {
        protected VoiceSession() { }
        public virtual System.Collections.Generic.IReadOnlyDictionary<string, object?>? Caller { get { throw null; } }
        public virtual string? Greeting { get { throw null; } }
        public virtual Azure.AI.AgentServer.Invocations.InvocationContext InvocationContext { get { throw null; } }
        public virtual int? NoInputTimeoutMs { get { throw null; } }
        public virtual bool Reconnect { get { throw null; } }
        public virtual Azure.AI.AgentServer.Invocations.Voice.ResponseTimeouts ResponseTimeouts { get { throw null; } }
        public virtual Azure.AI.AgentServer.Invocations.Voice.SessionStartEvent StartEvent { get { throw null; } }
        public virtual System.Threading.Tasks.Task EndCallAsync(string reason, string mode = "drain", System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task ReportErrorAsync(string code, string message, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.AgentServer.Invocations.Voice.VoiceResponse> StartProactiveResponseAsync(int admissionTimeoutMs = 60000, string? supersedeKey = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VoiceTextItem
    {
        protected VoiceTextItem() { }
        public virtual string ItemId { get { throw null; } }
        public virtual System.Threading.Tasks.Task SendTextAsync(string text, System.Collections.Generic.IReadOnlyDictionary<string, object?>? voice, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SendTextAsync(string text, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SendTextDeltaAsync(string delta, System.Collections.Generic.IReadOnlyDictionary<string, object?>? voice, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SendTextDeltaAsync(string delta, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SendTextDoneAsync(System.Collections.Generic.IReadOnlyDictionary<string, object?>? voice, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SendTextDoneAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
