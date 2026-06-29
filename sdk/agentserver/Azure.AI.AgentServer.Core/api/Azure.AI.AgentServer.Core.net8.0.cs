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
