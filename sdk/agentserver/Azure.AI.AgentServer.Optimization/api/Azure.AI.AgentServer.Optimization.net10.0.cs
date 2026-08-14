namespace Azure.AI.AgentServer.Optimization
{
    public partial class AgentOptimizationClient
    {
        protected AgentOptimizationClient() { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
        public AgentOptimizationClient(Azure.AI.AgentServer.Optimization.AgentOptimizationClientSettings settings) { }
        public AgentOptimizationClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public AgentOptimizationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.AgentServer.Optimization.AgentOptimizationClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.AgentServer.Optimization.CandidateDeployConfig> ResolveOptions(string candidateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.AgentServer.Optimization.CandidateDeployConfig>> ResolveOptionsAsync(string candidateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public static partial class AgentOptimizationClientHostExtensions
    {
        public static System.ClientModel.Primitives.IClientBuilder AddAgentOptimizationClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddAgentOptimizationClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName, System.Action<Azure.AI.AgentServer.Optimization.AgentOptimizationClientSettings> configureSettings) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedAgentOptimizationClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedAgentOptimizationClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName, System.Action<Azure.AI.AgentServer.Optimization.AgentOptimizationClientSettings> configureSettings) { throw null; }
        public static Microsoft.Extensions.Configuration.IConfigurationBuilder AddOptimizationConfigSource(this Microsoft.Extensions.Configuration.IConfigurationBuilder builder, string sectionName) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
        public static Microsoft.Extensions.Configuration.IConfigurationBuilder AddOptimizationConfigSource(this Microsoft.Extensions.Configuration.IConfigurationBuilder builder, string sectionName, System.Action<Azure.AI.AgentServer.Optimization.AgentOptimizationClientSettings> configureSettings) { throw null; }
        public static Microsoft.Extensions.Configuration.IConfigurationBuilder AddOptimizationConfigSource(this Microsoft.Extensions.Configuration.IConfigurationBuilder builder, string agentKey, string sectionName) { throw null; }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
        public static Microsoft.Extensions.Configuration.IConfigurationBuilder AddOptimizationConfigSource(this Microsoft.Extensions.Configuration.IConfigurationBuilder builder, string agentKey, string sectionName, System.Action<Azure.AI.AgentServer.Optimization.AgentOptimizationClientSettings> configureSettings) { throw null; }
        public static Azure.AI.AgentServer.Optimization.CandidateDeployConfig? GetOptimizationConfig(this Microsoft.Extensions.Configuration.IConfiguration configuration) { throw null; }
        public static Azure.AI.AgentServer.Optimization.CandidateDeployConfig? GetOptimizationConfig(this Microsoft.Extensions.Configuration.IConfiguration configuration, string agentKey) { throw null; }
    }
    public partial class AgentOptimizationClientOptions : Azure.Core.ClientOptions
    {
        public AgentOptimizationClientOptions(Azure.AI.AgentServer.Optimization.AgentOptimizationClientOptions.ServiceVersion version = Azure.AI.AgentServer.Optimization.AgentOptimizationClientOptions.ServiceVersion.V1) { }
        public enum ServiceVersion
        {
            V1 = 1,
        }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public partial class AgentOptimizationClientSettings : System.ClientModel.Primitives.ClientSettings
    {
        public AgentOptimizationClientSettings() { }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.AI.AgentServer.Optimization.AgentOptimizationClientOptions Options { get { throw null; } set { } }
        protected override void BindCore(Microsoft.Extensions.Configuration.IConfigurationSection section) { }
    }
    public static partial class AgentServerOptimizationModelFactory
    {
        public static Azure.AI.AgentServer.Optimization.CandidateDeployConfig CandidateDeployConfig(string instructions = null, string model = null, float? temperature = default(float?)) { throw null; }
    }
    public partial class AzureAIAgentServerOptimizationContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAIAgentServerOptimizationContext() { }
        public static Azure.AI.AgentServer.Optimization.AzureAIAgentServerOptimizationContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class CandidateDeployConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Optimization.CandidateDeployConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Optimization.CandidateDeployConfig>
    {
        internal CandidateDeployConfig() { }
        public string Instructions { get { throw null; } }
        public string Model { get { throw null; } }
        public float? Temperature { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Optimization.CandidateDeployConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.AgentServer.Optimization.CandidateDeployConfig (Azure.Response response) { throw null; }
        protected virtual Azure.AI.AgentServer.Optimization.CandidateDeployConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Optimization.CandidateDeployConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Optimization.CandidateDeployConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Optimization.CandidateDeployConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Optimization.CandidateDeployConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Optimization.CandidateDeployConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Optimization.CandidateDeployConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Optimization.CandidateDeployConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
