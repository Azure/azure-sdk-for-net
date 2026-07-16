namespace Azure.AI.AgentServer.Activity
{
    public static partial class ActivityBuilderExtensions
    {
        public static Azure.AI.AgentServer.Core.AgentHostBuilder AddActivity(this Azure.AI.AgentServer.Core.AgentHostBuilder builder, Microsoft.Agents.Builder.App.AgentApplication agentApp, System.Action<Azure.AI.AgentServer.Activity.ActivityServerOptions>? configure = null) { throw null; }
        public static Azure.AI.AgentServer.Core.AgentHostBuilder AddActivity(this Azure.AI.AgentServer.Core.AgentHostBuilder builder, System.Func<System.IServiceProvider, Microsoft.Agents.Builder.App.AgentApplication> factory, System.Action<Azure.AI.AgentServer.Activity.ActivityServerOptions>? configure = null) { throw null; }
        public static Azure.AI.AgentServer.Core.AgentHostBuilder AddActivity<TAgent>(this Azure.AI.AgentServer.Core.AgentHostBuilder builder, System.Action<Azure.AI.AgentServer.Activity.ActivityServerOptions>? configure = null) where TAgent : Microsoft.Agents.Builder.App.AgentApplication { throw null; }
    }
    public static partial class ActivityEnvironment
    {
        public static System.Collections.Generic.IReadOnlyDictionary<string, string?> GetHostedAgentConfiguration() { throw null; }
        public static System.Collections.Generic.IReadOnlyDictionary<string, string?> GetHostedAgentConfiguration(bool digitalWorker) { throw null; }
    }
    public static partial class ActivityServer
    {
        public static void Run(Microsoft.Agents.Builder.App.AgentApplication agentApp, string[]? args = null, System.Action<Azure.AI.AgentServer.Activity.ActivityServerOptions>? configureOptions = null, System.Action<Azure.AI.AgentServer.Core.AgentHostBuilder>? configure = null) { }
        public static void Run(Microsoft.AspNetCore.Http.RequestDelegate requestHandler, string[]? args = null, System.Action<Azure.AI.AgentServer.Core.AgentHostBuilder>? configure = null) { }
        public static void Run(System.Action<Microsoft.Agents.Builder.App.AgentApplication> configureAgent, string[]? args = null, System.Action<Azure.AI.AgentServer.Activity.ActivityServerOptions>? configureOptions = null, System.Action<Azure.AI.AgentServer.Core.AgentHostBuilder>? configure = null) { }
        public static void Run(System.Func<System.IServiceProvider, Microsoft.Agents.Builder.App.AgentApplication> factory, string[]? args = null, System.Action<Azure.AI.AgentServer.Activity.ActivityServerOptions>? configureOptions = null, System.Action<Azure.AI.AgentServer.Core.AgentHostBuilder>? configure = null) { }
        public static void Run<TAgent>(string[]? args = null, System.Action<Azure.AI.AgentServer.Activity.ActivityServerOptions>? configureOptions = null, System.Action<Azure.AI.AgentServer.Core.AgentHostBuilder>? configure = null) where TAgent : Microsoft.Agents.Builder.App.AgentApplication { }
    }
    public partial class ActivityServerOptions
    {
        public ActivityServerOptions() { }
        public System.Action<Microsoft.Extensions.DependencyInjection.IServiceCollection>? ConfigureServices { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string?>? ConnectionConfiguration { get { throw null; } set { } }
        public Microsoft.Agents.Authentication.IConnections? Connections { get { throw null; } set { } }
        public bool DigitalWorker { get { throw null; } set { } }
        public Microsoft.Agents.Storage.IStorage? Storage { get { throw null; } set { } }
    }
    public static partial class FoundryActivityEndpointRouteBuilderExtensions
    {
        public static Microsoft.AspNetCore.Builder.WebApplication MapActivityServer(this Microsoft.AspNetCore.Builder.WebApplication app) { throw null; }
        public static Microsoft.AspNetCore.Routing.IEndpointRouteBuilder MapActivityServer(this Microsoft.AspNetCore.Routing.IEndpointRouteBuilder endpoints) { throw null; }
        public static Microsoft.AspNetCore.Routing.IEndpointRouteBuilder MapActivityServer(this Microsoft.AspNetCore.Routing.IEndpointRouteBuilder endpoints, Microsoft.AspNetCore.Http.RequestDelegate requestHandler) { throw null; }
        public static Microsoft.AspNetCore.Builder.WebApplication MapFoundryActivity(this Microsoft.AspNetCore.Builder.WebApplication app) { throw null; }
        public static Microsoft.AspNetCore.Routing.IEndpointRouteBuilder MapFoundryActivity(this Microsoft.AspNetCore.Routing.IEndpointRouteBuilder endpoints) { throw null; }
        public static Microsoft.AspNetCore.Routing.IEndpointRouteBuilder MapFoundryActivity(this Microsoft.AspNetCore.Routing.IEndpointRouteBuilder endpoints, Microsoft.AspNetCore.Http.RequestDelegate requestHandler) { throw null; }
    }
    public static partial class FoundryActivityHostingExtensions
    {
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddActivityServer(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, System.Action<Azure.AI.AgentServer.Activity.ActivityServerOptions>? configure = null) { throw null; }
        public static Microsoft.Extensions.Hosting.IHostApplicationBuilder AddActivityServer(this Microsoft.Extensions.Hosting.IHostApplicationBuilder builder, System.Action<Azure.AI.AgentServer.Activity.ActivityServerOptions>? configure = null) { throw null; }
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddFoundryActivity(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, System.Action<Azure.AI.AgentServer.Activity.ActivityServerOptions>? configure = null) { throw null; }
        public static Microsoft.Extensions.Hosting.IHostApplicationBuilder AddFoundryActivity(this Microsoft.Extensions.Hosting.IHostApplicationBuilder builder, System.Action<Azure.AI.AgentServer.Activity.ActivityServerOptions>? configure = null) { throw null; }
    }
}
