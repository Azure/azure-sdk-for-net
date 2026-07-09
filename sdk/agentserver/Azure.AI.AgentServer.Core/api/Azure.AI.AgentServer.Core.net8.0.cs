namespace Azure.AI.AgentServer.Core
{
    public static partial class AgentHost
    {
        public static Azure.AI.AgentServer.Core.AgentHostBuilder CreateBuilder(string[]? args = null) { throw null; }
    }
    public sealed partial class AgentHostApp
    {
        internal AgentHostApp() { }
        public Microsoft.AspNetCore.Builder.WebApplication App { get { throw null; } }
        public void Run() { }
        public System.Threading.Tasks.Task RunAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public sealed partial class AgentHostBuilder
    {
        internal AgentHostBuilder() { }
        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get { throw null; } }
        public Microsoft.Extensions.DependencyInjection.IServiceCollection Services { get { throw null; } }
        public Azure.AI.AgentServer.Core.ServerVersionRegistry VersionRegistry { get { throw null; } }
        public Microsoft.AspNetCore.Builder.WebApplicationBuilder WebApplicationBuilder { get { throw null; } }
        public Azure.AI.AgentServer.Core.AgentHostApp Build() { throw null; }
        public Azure.AI.AgentServer.Core.AgentHostBuilder Configure(System.Action<Azure.AI.AgentServer.Core.AgentHostOptions> configure) { throw null; }
        public Azure.AI.AgentServer.Core.AgentHostBuilder ConfigureHealth(System.Action<Microsoft.Extensions.DependencyInjection.IHealthChecksBuilder> configure) { throw null; }
        public Azure.AI.AgentServer.Core.AgentHostBuilder ConfigureShutdown(System.TimeSpan timeout) { throw null; }
        public Azure.AI.AgentServer.Core.AgentHostBuilder ConfigureTracing(System.Action<OpenTelemetry.Trace.TracerProviderBuilder> configure) { throw null; }
        public void RegisterProtocol(string protocolName, System.Action<Microsoft.AspNetCore.Routing.IEndpointRouteBuilder> endpointMapper) { }
    }
    public static partial class AgentHostMiddlewareExtensions
    {
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddAgentServerCore(this Microsoft.Extensions.DependencyInjection.IServiceCollection services) { throw null; }
        public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseAgentServerCore(this Microsoft.AspNetCore.Builder.IApplicationBuilder app) { throw null; }
    }
    public partial class AgentHostOptions
    {
        public AgentHostOptions() { }
        public string? AdditionalServerIdentity { get { throw null; } set { } }
        public System.TimeSpan ShutdownTimeout { get { throw null; } set { } }
    }
    public sealed partial class FoundryAgentRequestContext
    {
        public FoundryAgentRequestContext() { }
        public string? CallId { get { throw null; } set { } }
        public static Azure.AI.AgentServer.Core.FoundryAgentRequestContext Current { get { throw null; } }
        public static Azure.AI.AgentServer.Core.FoundryAgentRequestContext Empty { get { throw null; } }
        public string? SessionId { get { throw null; } set { } }
        public string? UserId { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<string, string>> PlatformHeaders() { throw null; }
    }
    public sealed partial class FoundryCallIdHandler : System.Net.Http.DelegatingHandler
    {
        public FoundryCallIdHandler() { }
        public FoundryCallIdHandler(System.Net.Http.HttpMessageHandler innerHandler) { }
        protected override System.Net.Http.HttpResponseMessage Send(System.Net.Http.HttpRequestMessage request, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected override System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage> SendAsync(System.Net.Http.HttpRequestMessage request, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public static partial class FoundryEnvironment
    {
        public static string? AgentBlueprintClientId { get { throw null; } }
        public static string? AgentId { get { throw null; } }
        public static string? AgentInstanceClientId { get { throw null; } }
        public static string? AgentName { get { throw null; } }
        public static string? AgentTenantId { get { throw null; } }
        public static string? AgentVersion { get { throw null; } }
        public static string? AppInsightsConnectionString { get { throw null; } }
        public static bool IsAgent365TracingEnabled { get { throw null; } }
        public static bool IsHosted { get { throw null; } }
        public static string? OtlpEndpoint { get { throw null; } }
        public static int Port { get { throw null; } }
        public static string? ProjectArmId { get { throw null; } }
        public static string? ProjectEndpoint { get { throw null; } }
        public static string? SessionId { get { throw null; } }
        public static System.TimeSpan SseKeepAliveInterval { get { throw null; } }
        public static System.TimeSpan WebSocketKeepAliveInterval { get { throw null; } }
    }
    public partial class PlatformContext
    {
        protected PlatformContext() { }
        public PlatformContext(string? userIdKey, string? callId) { }
        public virtual string? CallId { get { throw null; } }
        public static Azure.AI.AgentServer.Core.PlatformContext Empty { get { throw null; } }
        public virtual string? UserIdKey { get { throw null; } }
        public static Azure.AI.AgentServer.Core.PlatformContext FromRequest(Microsoft.AspNetCore.Http.HttpRequest request) { throw null; }
    }
    public static partial class PlatformHeaders
    {
        public const string ClientHeaderPrefix = "x-client-";
        public const string ClientRequestId = "x-ms-client-request-id";
        public const string ErrorDetail = "x-platform-error-detail";
        public const string ErrorSource = "x-platform-error-source";
        public const string ErrorSourcePlatform = "platform";
        public const string ErrorSourceUpstream = "upstream";
        public const string ErrorSourceUser = "user";
        public const string FoundryCallId = "x-agent-foundry-call-id";
        public const string RequestId = "x-request-id";
        public const string RequestIdItemKey = "AgentServer.RequestId";
        public const string ServerVersion = "x-platform-server";
        public const string SessionId = "x-agent-session-id";
        public const string TraceParent = "traceparent";
        public const string UserId = "x-agent-user-id";
    }
    public sealed partial class ServerVersionRegistry
    {
        public ServerVersionRegistry() { }
        public static string BuildIdentityString(string sdkName, System.Reflection.Assembly assembly) { throw null; }
        public System.Collections.Generic.IReadOnlyList<string> GetSegments() { throw null; }
        public void Register(string identity) { }
    }
    public sealed partial class SseKeepAliveSession : System.IAsyncDisposable
    {
        internal SseKeepAliveSession() { }
        public bool IsKeepAliveActive { get { throw null; } }
        public System.IO.Stream Stream { get { throw null; } }
        public System.Threading.Tasks.ValueTask DisposeAsync() { throw null; }
        public void EnableKeepAlive(System.TimeSpan interval) { }
        public static Azure.AI.AgentServer.Core.SseKeepAliveSession Start(System.IO.Stream output, System.TimeSpan interval, Microsoft.Extensions.Logging.ILogger logger, string contextName) { throw null; }
    }
}
namespace Azure.AI.AgentServer.Core.Streaming
{
    public sealed partial class EventStreamClosedException : Azure.AI.AgentServer.Core.Streaming.EventStreamException
    {
        public EventStreamClosedException() { }
        public EventStreamClosedException(string message) { }
        public EventStreamClosedException(string message, System.Exception innerException) { }
    }
    public partial class EventStreamException : System.Exception
    {
        public EventStreamException() { }
        public EventStreamException(string message) { }
        public EventStreamException(string message, System.Exception innerException) { }
    }
    public sealed partial class EventStreamNotFoundException : Azure.AI.AgentServer.Core.Streaming.EventStreamException
    {
        public EventStreamNotFoundException() { }
        public EventStreamNotFoundException(string message) { }
        public EventStreamNotFoundException(string message, System.Exception innerException) { }
    }
    public sealed partial class EventStreamOptions
    {
        public EventStreamOptions() { }
        public void UseFileBackedReplay(string? storageDirectory = null, System.Func<object, int>? cursor = null, System.TimeSpan? ttl = default(System.TimeSpan?), System.Func<object, byte[]>? serializer = null, System.Func<byte[], object>? deserializer = null) { }
        public void UseFileBackedReplay<TPayload>(System.Func<TPayload, int>? cursor = null, System.TimeSpan? ttl = default(System.TimeSpan?), string? storageDirectory = null) { }
        public void UseInMemoryLive() { }
        public void UseInMemoryReplay(System.Func<object, int>? cursor = null, System.TimeSpan? ttl = default(System.TimeSpan?)) { }
    }
    public static partial class EventStreamServiceCollectionExtensions
    {
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddEventStreams(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, System.Action<Azure.AI.AgentServer.Core.Streaming.EventStreamOptions>? configure = null) { throw null; }
    }
    public partial interface IEventStream
    {
        System.Threading.Tasks.ValueTask CloseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        System.Threading.Tasks.ValueTask EmitAsync(object payload, bool close = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        System.Threading.Tasks.ValueTask<int?> GetLastCursorAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        System.Collections.Generic.IAsyncEnumerable<object> Subscribe(int? after = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
    public partial interface IEventStreamRegistry
    {
        System.Threading.Tasks.ValueTask DeleteAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        System.Threading.Tasks.ValueTask<Azure.AI.AgentServer.Core.Streaming.IEventStream> GetAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        System.Threading.Tasks.ValueTask<Azure.AI.AgentServer.Core.Streaming.IEventStream> GetOrCreateAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
}
namespace Azure.AI.AgentServer.Core.Tasks
{
    public enum EntryMode
    {
        Fresh = 0,
        Resumed = 1,
        Recovered = 2,
    }
    public partial interface IMultiTurnTask
    {
        System.Threading.Tasks.Task DeleteAsync(string taskId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
    public sealed partial class InputTooLargeException : Azure.AI.AgentServer.Core.Tasks.TaskException
    {
        public InputTooLargeException() { }
        public InputTooLargeException(string message) { }
    }
    public partial interface IResilientTaskBuilder
    {
        Azure.AI.AgentServer.Core.Tasks.IResilientTaskBuilder AddMultiTurnTask<TInput, TOutput>(string name, System.Func<Azure.AI.AgentServer.Core.Tasks.TaskContext<TInput>, System.Threading.CancellationToken, System.Threading.Tasks.Task<TOutput>> handler, bool steerable = false, System.Action<Azure.AI.AgentServer.Core.Tasks.TaskRegistrationOptions>? configure = null);
        Azure.AI.AgentServer.Core.Tasks.IResilientTaskBuilder AddMultiTurnTask<TInput, TOutput>(string name, System.Func<System.IServiceProvider, Azure.AI.AgentServer.Core.Tasks.TaskContext<TInput>, System.Threading.CancellationToken, System.Threading.Tasks.Task<TOutput>> handler, bool steerable = false, System.Action<Azure.AI.AgentServer.Core.Tasks.TaskRegistrationOptions>? configure = null);
        Azure.AI.AgentServer.Core.Tasks.IResilientTaskBuilder AddTask<TInput, TOutput>(string name, System.Func<Azure.AI.AgentServer.Core.Tasks.TaskContext<TInput>, System.Threading.CancellationToken, System.Threading.Tasks.Task<TOutput>> handler, System.Action<Azure.AI.AgentServer.Core.Tasks.TaskRegistrationOptions>? configure = null);
        Azure.AI.AgentServer.Core.Tasks.IResilientTaskBuilder AddTask<TInput, TOutput>(string name, System.Func<System.IServiceProvider, Azure.AI.AgentServer.Core.Tasks.TaskContext<TInput>, System.Threading.CancellationToken, System.Threading.Tasks.Task<TOutput>> handler, System.Action<Azure.AI.AgentServer.Core.Tasks.TaskRegistrationOptions>? configure = null);
    }
    public partial interface ITaskInvoker
    {
        System.Threading.Tasks.Task<Azure.AI.AgentServer.Core.Tasks.TaskRun<TOutput>?> GetActiveRunAsync<TOutput>(string name, string taskId, string inputId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        System.Threading.Tasks.Task<Azure.AI.AgentServer.Core.Tasks.TaskRun<TOutput>?> GetActiveRunAsync<TOutput>(string name, string taskId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        System.Threading.Tasks.Task<TOutput> RunAsync<TInput, TOutput>(string name, TInput input, Azure.AI.AgentServer.Core.Tasks.RunOptions? options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        System.Threading.Tasks.Task<Azure.AI.AgentServer.Core.Tasks.TaskRun<TOutput>> StartAsync<TInput, TOutput>(string name, TInput input, Azure.AI.AgentServer.Core.Tasks.RunOptions? options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
    public sealed partial class LastInputIdPreconditionFailedException : Azure.AI.AgentServer.Core.Tasks.TaskException
    {
        public LastInputIdPreconditionFailedException(string? actualLastInputId, string? message = null) { }
        public string? ActualLastInputId { get { throw null; } }
    }
    public static partial class ResilientTaskServiceCollectionExtensions
    {
        public static Azure.AI.AgentServer.Core.Tasks.IResilientTaskBuilder AddResilientTasks(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, Azure.Core.TokenCredential? credential = null) { throw null; }
    }
    public sealed partial class RetryPolicy
    {
        public RetryPolicy() { }
        public double BackoffCoefficient { get { throw null; } set { } }
        public System.TimeSpan InitialDelay { get { throw null; } set { } }
        public bool Jitter { get { throw null; } set { } }
        public int MaxAttempts { get { throw null; } set { } }
        public System.TimeSpan MaxDelay { get { throw null; } set { } }
        public System.Func<System.Exception, bool>? RetryOn { get { throw null; } set { } }
        public static Azure.AI.AgentServer.Core.Tasks.RetryPolicy ExponentialBackoff(int maxAttempts = 3, System.TimeSpan? initialDelay = default(System.TimeSpan?), double backoffCoefficient = 2, System.TimeSpan? maxDelay = default(System.TimeSpan?), bool jitter = true) { throw null; }
        public static Azure.AI.AgentServer.Core.Tasks.RetryPolicy FixedDelay(int maxAttempts = 3, System.TimeSpan? delay = default(System.TimeSpan?), bool jitter = false) { throw null; }
        public static Azure.AI.AgentServer.Core.Tasks.RetryPolicy LinearBackoff(int maxAttempts = 5, System.TimeSpan? initialDelay = default(System.TimeSpan?), System.TimeSpan? increment = default(System.TimeSpan?), System.TimeSpan? maxDelay = default(System.TimeSpan?), bool jitter = false) { throw null; }
        public static Azure.AI.AgentServer.Core.Tasks.RetryPolicy NoRetry() { throw null; }
    }
    public sealed partial class RunOptions
    {
        public RunOptions() { }
        public string? IfLastInputId { get { throw null; } set { } }
        public string? InputId { get { throw null; } set { } }
        public string? TaskId { get { throw null; } set { } }
    }
    public sealed partial class SteeringQueueFullException : Azure.AI.AgentServer.Core.Tasks.TaskException
    {
        public SteeringQueueFullException() { }
        public SteeringQueueFullException(string message) { }
    }
    public sealed partial class TaskCancelledException : Azure.AI.AgentServer.Core.Tasks.TaskException
    {
        public TaskCancelledException() { }
        public TaskCancelledException(string message) { }
    }
    public sealed partial class TaskConflictException : Azure.AI.AgentServer.Core.Tasks.TaskException
    {
        public TaskConflictException(Azure.AI.AgentServer.Core.Tasks.TaskStatus currentStatus, string? message = null, System.Exception? innerException = null) { }
        public Azure.AI.AgentServer.Core.Tasks.TaskStatus CurrentStatus { get { throw null; } }
    }
    public partial class TaskContext<TInput>
    {
        protected TaskContext() { }
        public virtual System.Threading.CancellationToken Cancellation { get { throw null; } }
        public virtual bool CancelRequested { get { throw null; } }
        public virtual Azure.AI.AgentServer.Core.Tasks.EntryMode EntryMode { get { throw null; } }
        public virtual TInput Input { get { throw null; } }
        public virtual string InputId { get { throw null; } }
        public virtual bool IsSteeredTurn { get { throw null; } }
        public virtual Azure.AI.AgentServer.Core.Tasks.TaskMetadata Metadata { get { throw null; } }
        public virtual int PendingInputCount { get { throw null; } }
        public virtual int RecoveryCount { get { throw null; } }
        public virtual int RetryAttempt { get { throw null; } }
        public virtual System.Threading.CancellationToken Shutdown { get { throw null; } }
        public virtual string TaskId { get { throw null; } }
        public virtual bool TimeoutExceeded { get { throw null; } }
        public virtual System.Threading.Tasks.Task ExitForRecoveryAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public sealed partial class TaskDeferredException : Azure.AI.AgentServer.Core.Tasks.TaskException
    {
        public TaskDeferredException() { }
        public TaskDeferredException(string message) { }
    }
    public partial class TaskException : System.Exception
    {
        public TaskException() { }
        public TaskException(string message) { }
        public TaskException(string message, System.Exception? innerException) { }
    }
    public sealed partial class TaskFailedException : Azure.AI.AgentServer.Core.Tasks.TaskException
    {
        public TaskFailedException(Azure.AI.AgentServer.Core.Tasks.TaskFailureDetail error, System.Exception? innerException = null) { }
        public Azure.AI.AgentServer.Core.Tasks.TaskFailureDetail Error { get { throw null; } }
    }
    public sealed partial class TaskFailureDetail
    {
        public TaskFailureDetail(Azure.AI.AgentServer.Core.Tasks.TaskFailureKind kind, string errorType, string message, int? attempts = default(int?), string? lastError = null, string? lastErrorType = null, string? traceback = null) { }
        public int? Attempts { get { throw null; } }
        public string ErrorType { get { throw null; } }
        public Azure.AI.AgentServer.Core.Tasks.TaskFailureKind Kind { get { throw null; } }
        public string? LastError { get { throw null; } }
        public string? LastErrorType { get { throw null; } }
        public string Message { get { throw null; } }
        public string? Traceback { get { throw null; } }
    }
    public enum TaskFailureKind
    {
        HandlerError = 0,
        ExhaustedRetries = 1,
    }
    public partial class TaskMetadata
    {
        protected TaskMetadata() { }
        public virtual System.BinaryData? this[string key] { get { throw null; } set { } }
        public virtual System.Collections.Generic.IEnumerable<string> Keys { get { throw null; } }
        public virtual void Append(string key, System.BinaryData value) { }
        public virtual bool ContainsKey(string key) { throw null; }
        public virtual System.Threading.Tasks.Task FlushAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual void Increment(string key, long delta = (long)1) { }
        public virtual Azure.AI.AgentServer.Core.Tasks.TaskMetadata Namespace(string name) { throw null; }
        public virtual bool Remove(string key) { throw null; }
        public virtual System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> ToDictionary() { throw null; }
        public virtual bool TryGetValue(string key, out System.BinaryData? value) { throw null; }
    }
    public sealed partial class TaskRegistrationOptions
    {
        public TaskRegistrationOptions() { }
        public Azure.AI.AgentServer.Core.Tasks.RetryPolicy? Retry { get { throw null; } set { } }
        public System.TimeSpan? Timeout { get { throw null; } set { } }
        public string? Title { get { throw null; } set { } }
    }
    public partial class TaskRun<TOutput>
    {
        protected TaskRun() { }
        public virtual string InputId { get { throw null; } }
        public virtual bool IsQueued { get { throw null; } }
        public virtual Azure.AI.AgentServer.Core.Tasks.TaskMetadata Metadata { get { throw null; } }
        public virtual string TaskId { get { throw null; } }
        public virtual System.Threading.Tasks.Task CancelAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Runtime.CompilerServices.TaskAwaiter<TOutput> GetAwaiter() { throw null; }
        public virtual System.Threading.Tasks.Task<TOutput> GetResultAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public enum TaskStatus
    {
        Pending = 0,
        InProgress = 1,
        Suspended = 2,
        Completed = 3,
    }
}
