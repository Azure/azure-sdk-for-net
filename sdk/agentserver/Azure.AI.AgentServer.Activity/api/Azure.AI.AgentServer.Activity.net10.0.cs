namespace Azure.AI.AgentServer.Activity
{
    public static partial class ActivityEnvironment
    {
        public static System.Collections.Generic.IReadOnlyDictionary<string, string?> GetHostedAgentConfiguration() { throw null; }
        public static System.Collections.Generic.IReadOnlyDictionary<string, string?> GetHostedAgentConfiguration(bool digitalWorker) { throw null; }
    }
    public static partial class ActivityServer
    {
        public static Azure.AI.AgentServer.Activity.ActivityServerHost Create() { throw null; }
        public static Azure.AI.AgentServer.Activity.ActivityServerHost Create(Microsoft.Agents.Builder.App.AgentApplication agentApp) { throw null; }
        public static Azure.AI.AgentServer.Activity.ActivityServerHost Create(Microsoft.AspNetCore.Http.RequestDelegate requestHandler) { throw null; }
        public static Azure.AI.AgentServer.Activity.ActivityServerHost Create(System.Action<Azure.AI.AgentServer.Activity.ActivityServerOptions>? configureOptions) { throw null; }
    }
    public sealed partial class ActivityServerHost
    {
        internal ActivityServerHost() { }
        public Microsoft.Agents.Builder.App.AgentApplication AgentApp { get { throw null; } }
        public Azure.AI.AgentServer.Activity.ActivityServerHost Configure(System.Action<Azure.AI.AgentServer.Core.AgentHostBuilder> configure) { throw null; }
        public void Run(string[]? args = null) { }
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
    public static partial class ActivityServerServiceCollectionExtensions
    {
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddActivityServer(this Microsoft.Extensions.DependencyInjection.IServiceCollection services, System.Action<Azure.AI.AgentServer.Activity.ActivityServerOptions>? configure = null) { throw null; }
    }
}
