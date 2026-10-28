namespace Azure.AI.AgentServer.A2A
{
    public static partial class A2AAgentServer
    {
        public static void Run(A2A.AgentCard agentCard, A2A.IA2ARequestHandler requestHandler, string[]? args = null, System.Action<Azure.AI.AgentServer.Core.AgentHostBuilder>? configure = null) { }
        public static void Run<THandler>(A2A.AgentCard agentCard, string[]? args = null, System.Action<Azure.AI.AgentServer.Core.AgentHostBuilder>? configure = null) where THandler : class, A2A.IAgentHandler { }
    }
    public static partial class A2ABuilderExtensions
    {
        public static Azure.AI.AgentServer.Core.AgentHostBuilder AddA2A(this Azure.AI.AgentServer.Core.AgentHostBuilder builder, A2A.AgentCard agentCard, A2A.IA2ARequestHandler requestHandler) { throw null; }
        public static Azure.AI.AgentServer.Core.AgentHostBuilder AddA2A<THandler>(this Azure.AI.AgentServer.Core.AgentHostBuilder builder, A2A.AgentCard agentCard, System.Action<A2A.A2AServerOptions>? configure = null) where THandler : class, A2A.IAgentHandler { throw null; }
    }
    public static partial class FoundryA2AEndpointRouteBuilderExtensions
    {
        public static Microsoft.AspNetCore.Builder.WebApplication MapFoundryA2A(this Microsoft.AspNetCore.Builder.WebApplication app) { throw null; }
        public static Microsoft.AspNetCore.Routing.IEndpointRouteBuilder MapFoundryA2A(this Microsoft.AspNetCore.Routing.IEndpointRouteBuilder endpoints) { throw null; }
    }
    public static partial class FoundryA2AHostingExtensions
    {
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddFoundryA2A(this Microsoft.Extensions.DependencyInjection.IServiceCollection services) { throw null; }
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddFoundryA2A(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, A2A.AgentCard agentCard, A2A.IA2ARequestHandler requestHandler) { throw null; }
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddFoundryA2A<THandler>(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, A2A.AgentCard agentCard, System.Action<A2A.A2AServerOptions>? configure = null) where THandler : class, A2A.IAgentHandler { throw null; }
    }
    public partial class FoundryTaskStore : A2A.ITaskStore, System.IDisposable
    {
        protected FoundryTaskStore() { }
        public FoundryTaskStore(Azure.AI.AgentServer.Core.Storage.FoundryStateStore store) { }
        public FoundryTaskStore(string name, Azure.Core.TokenCredential? credential = null, System.Uri? endpoint = null, int itemTtlSeconds = 2592000) { }
        public virtual System.Threading.Tasks.Task DeleteTaskAsync(string taskId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual void Dispose() { }
        public virtual System.Threading.Tasks.Task<A2A.AgentTask?> GetTaskAsync(string taskId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<A2A.ListTasksResponse> ListTasksAsync(A2A.ListTasksRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task SaveTaskAsync(string taskId, A2A.AgentTask task, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
