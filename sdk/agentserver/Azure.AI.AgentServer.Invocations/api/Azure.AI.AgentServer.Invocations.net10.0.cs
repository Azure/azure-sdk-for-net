namespace Azure.AI.AgentServer.Invocations
{
    public sealed partial class InvocationContext
    {
        public InvocationContext(string invocationId, string sessionId, System.Collections.Generic.IReadOnlyDictionary<string, string> clientHeaders, System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Extensions.Primitives.StringValues> queryParameters, Azure.AI.AgentServer.Core.IsolationContext isolation) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> ClientHeaders { get { throw null; } }
        public string InvocationId { get { throw null; } }
        public Azure.AI.AgentServer.Core.IsolationContext Isolation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Microsoft.Extensions.Primitives.StringValues> QueryParameters { get { throw null; } }
        public string SessionId { get { throw null; } }
    }
    public abstract partial class InvocationHandler
    {
        protected InvocationHandler() { }
        public virtual System.Threading.Tasks.Task CancelAsync(string invocationId, Microsoft.AspNetCore.Http.HttpRequest request, Microsoft.AspNetCore.Http.HttpResponse response, Azure.AI.AgentServer.Invocations.InvocationContext context, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task GetAsync(string invocationId, Microsoft.AspNetCore.Http.HttpRequest request, Microsoft.AspNetCore.Http.HttpResponse response, Azure.AI.AgentServer.Invocations.InvocationContext context, System.Threading.CancellationToken cancellationToken) { throw null; }
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
}
