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
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddAgentServerLogging(this Microsoft.Extensions.DependencyInjection.IServiceCollection services) { throw null; }
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddAgentServerVersion(this Microsoft.Extensions.DependencyInjection.IServiceCollection services) { throw null; }
        public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseAgentServerLogging(this Microsoft.AspNetCore.Builder.IApplicationBuilder app) { throw null; }
        public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseAgentServerVersion(this Microsoft.AspNetCore.Builder.IApplicationBuilder app) { throw null; }
    }
    public partial class AgentHostOptions
    {
        public AgentHostOptions() { }
        public string? AdditionalServerIdentity { get { throw null; } set { } }
        public System.TimeSpan ShutdownTimeout { get { throw null; } set { } }
    }
    public static partial class FoundryEnvironment
    {
        public static string? AgentName { get { throw null; } }
        public static string? AgentVersion { get { throw null; } }
        public static string? AppInsightsConnectionString { get { throw null; } }
        public static bool IsHosted { get { throw null; } }
        public static string? OtlpEndpoint { get { throw null; } }
        public static int Port { get { throw null; } }
        public static string? ProjectArmId { get { throw null; } }
        public static string? ProjectEndpoint { get { throw null; } }
        public static string? SessionId { get { throw null; } }
        public static System.TimeSpan SseKeepAliveInterval { get { throw null; } }
    }
    public partial class IsolationContext
    {
        public const string ChatIsolationKeyHeaderName = "x-agent-chat-isolation-key";
        public const string UserIsolationKeyHeaderName = "x-agent-user-isolation-key";
        protected IsolationContext() { }
        public IsolationContext(string? userIsolationKey, string? chatIsolationKey) { }
        public virtual string? ChatIsolationKey { get { throw null; } }
        public static Azure.AI.AgentServer.Core.IsolationContext Empty { get { throw null; } }
        public virtual string? UserIsolationKey { get { throw null; } }
        public static Azure.AI.AgentServer.Core.IsolationContext FromRequest(Microsoft.AspNetCore.Http.HttpRequest request) { throw null; }
    }
    public sealed partial class ServerVersionRegistry
    {
        public ServerVersionRegistry() { }
        public static string BuildIdentityString(string sdkName, System.Reflection.Assembly assembly) { throw null; }
        public System.Collections.Generic.IReadOnlyList<string> GetSegments() { throw null; }
        public void Register(string identity) { }
    }
}
