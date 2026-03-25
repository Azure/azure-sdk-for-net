namespace Azure.AI.AgentServer.Hosting
{
    public static partial class AgentServer
    {
        public static Azure.AI.AgentServer.Hosting.AgentServerBuilder CreateBuilder(string[]? args = null) { throw null; }
        public static void Run<THandler>(string[]? args = null, System.Action<Azure.AI.AgentServer.Hosting.AgentServerBuilder>? configure = null) where THandler : class { }
    }
    public sealed partial class AgentServerApp
    {
        internal AgentServerApp() { }
        public Microsoft.AspNetCore.Builder.WebApplication App { get { throw null; } }
        public void Run() { }
        public System.Threading.Tasks.Task RunAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public sealed partial class AgentServerBuilder
    {
        internal AgentServerBuilder() { }
        public Microsoft.Extensions.Configuration.IConfiguration Configuration { get { throw null; } }
        public Microsoft.Extensions.DependencyInjection.IServiceCollection Services { get { throw null; } }
        public Azure.AI.AgentServer.Hosting.ServerUserAgentRegistry UserAgentRegistry { get { throw null; } }
        public Microsoft.AspNetCore.Builder.WebApplicationBuilder WebApplicationBuilder { get { throw null; } }
        public Azure.AI.AgentServer.Hosting.AgentServerApp Build() { throw null; }
        public Azure.AI.AgentServer.Hosting.AgentServerBuilder Configure(System.Action<Azure.AI.AgentServer.Hosting.AgentServerOptions> configure) { throw null; }
        public Azure.AI.AgentServer.Hosting.AgentServerBuilder ConfigureHealth(System.Action<Microsoft.Extensions.DependencyInjection.IHealthChecksBuilder> configure) { throw null; }
        public Azure.AI.AgentServer.Hosting.AgentServerBuilder ConfigureShutdown(System.TimeSpan timeout) { throw null; }
        public Azure.AI.AgentServer.Hosting.AgentServerBuilder ConfigureTracing(System.Action<OpenTelemetry.Trace.TracerProviderBuilder> configure) { throw null; }
        public void RegisterProtocol(string protocolName, System.Action<Microsoft.AspNetCore.Routing.IEndpointRouteBuilder> endpointMapper) { }
    }
    public static partial class AgentServerMiddlewareExtensions
    {
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddAgentServerUserAgent(this Microsoft.Extensions.DependencyInjection.IServiceCollection services) { throw null; }
        public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseAgentServerUserAgent(this Microsoft.AspNetCore.Builder.IApplicationBuilder app) { throw null; }
    }
    public partial class AgentServerOptions
    {
        public AgentServerOptions() { }
        public string? AdditionalServerIdentity { get { throw null; } set { } }
        public System.TimeSpan ShutdownTimeout { get { throw null; } set { } }
    }
    public static partial class AgentServerTelemetry
    {
        public const string InvocationsMeterName = "Azure.AI.AgentServer.Invocations";
        public const string InvocationsSourceName = "Azure.AI.AgentServer.Invocations";
        public const string ResponsesMeterName = "Azure.AI.AgentServer.Responses";
        public const string ResponsesSourceName = "Azure.AI.AgentServer.Responses";
    }
    public static partial class FoundryEnvironment
    {
        public static string? AgentName { get { throw null; } }
        public static string? AgentVersion { get { throw null; } }
        public static string? AppInsightsConnectionString { get { throw null; } }
        public static string? OtlpEndpoint { get { throw null; } }
        public static int Port { get { throw null; } }
        public static string? ProjectEndpoint { get { throw null; } }
        public static string? SessionId { get { throw null; } }
        public static System.TimeSpan SseKeepAliveInterval { get { throw null; } }
    }
    public sealed partial class ServerUserAgentRegistry
    {
        public ServerUserAgentRegistry() { }
        public static string BuildIdentityString(string sdkName, System.Reflection.Assembly assembly) { throw null; }
        public System.Collections.Generic.IReadOnlyList<string> GetSegments() { throw null; }
        public void Register(string identity) { }
    }
}
