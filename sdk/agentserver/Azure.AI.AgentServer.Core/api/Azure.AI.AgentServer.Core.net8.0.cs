namespace Azure.AI.AgentServer.Core.Common
{
    public static partial class AsyncEnumerableExtensions
    {
        public static System.Collections.Generic.IAsyncEnumerable<System.Collections.Generic.IAsyncEnumerable<TSource>> ChunkByKey<TSource, TKey>(this System.Collections.Generic.IAsyncEnumerable<TSource> source, System.Func<TSource, TKey> keySelector, System.Collections.Generic.IEqualityComparer<TKey>? comparer = null, [System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Collections.Generic.IAsyncEnumerable<System.Collections.Generic.IAsyncEnumerable<TSource>> ChunkOnChange<TSource>(this System.Collections.Generic.IAsyncEnumerable<TSource> source, System.Func<TSource?, TSource?, bool>? isChanged = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.ValueTask<(bool HasValue, T First, System.Collections.Generic.IAsyncEnumerable<T> Source)> Peek<T>(this System.Collections.Generic.IAsyncEnumerable<T> source, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CompositeDisposable : System.IDisposable
    {
        public CompositeDisposable(params System.IDisposable?[] disposables) { }
        public void Dispose() { }
    }
    public partial class SingletonOptionsMonitor<TOptions> : Microsoft.Extensions.Options.IOptions<TOptions>, Microsoft.Extensions.Options.IOptionsMonitor<TOptions>, Microsoft.Extensions.Options.IOptionsSnapshot<TOptions> where TOptions : class
    {
        public SingletonOptionsMonitor(TOptions options) { }
        public TOptions CurrentValue { get { throw null; } }
        public TOptions Value { get { throw null; } }
        public TOptions Get(string? name) { throw null; }
        public System.IDisposable? OnChange(System.Action<TOptions, string?> listener) { throw null; }
    }
}
namespace Azure.AI.AgentServer.Core.Common.Http.Json
{
    public static partial class JsonExtensions
    {
        public static readonly System.Text.Json.JsonSerializerOptions DefaultJsonSerializerOptions;
        public static System.Text.Json.JsonSerializerOptions GetDefaultJsonSerializerOptions() { throw null; }
        public static System.Text.Json.JsonSerializerOptions GetJsonSerializerOptions(this Microsoft.AspNetCore.Http.HttpContext ctx) { throw null; }
        public static T? ToObject<T>(this System.BinaryData data, System.Text.Json.JsonSerializerOptions? options = null) where T : class { throw null; }
    }
}
namespace Azure.AI.AgentServer.Core.Common.Http.ServerSentEvent
{
    public partial class SseFrame : System.IEquatable<Azure.AI.AgentServer.Core.Common.Http.ServerSentEvent.SseFrame>
    {
        protected SseFrame(Azure.AI.AgentServer.Core.Common.Http.ServerSentEvent.SseFrame original) { }
        public SseFrame(string? Id = null, string? Name = null, System.Collections.Generic.IList<object>? Data = null, System.Collections.Generic.IList<string>? Comments = null) { }
        public System.Collections.Generic.IList<string>? Comments { get { throw null; } set { } }
        public System.Collections.Generic.IList<object>? Data { get { throw null; } set { } }
        protected virtual System.Type EqualityContract { get { throw null; } }
        public string? Id { get { throw null; } set { } }
        public string? Name { get { throw null; } set { } }
        public void Deconstruct(out string? Id, out string? Name, out System.Collections.Generic.IList<object>? Data, out System.Collections.Generic.IList<string>? Comments) { throw null; }
        public virtual bool Equals(Azure.AI.AgentServer.Core.Common.Http.ServerSentEvent.SseFrame? other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static Azure.AI.AgentServer.Core.Common.Http.ServerSentEvent.SseFrame Of(string? id = null, string? name = null, object? data = null, string? comment = null) { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Core.Common.Http.ServerSentEvent.SseFrame? left, Azure.AI.AgentServer.Core.Common.Http.ServerSentEvent.SseFrame? right) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Core.Common.Http.ServerSentEvent.SseFrame? left, Azure.AI.AgentServer.Core.Common.Http.ServerSentEvent.SseFrame? right) { throw null; }
        protected virtual bool PrintMembers(System.Text.StringBuilder builder) { throw null; }
        public override string ToString() { throw null; }
        public virtual Azure.AI.AgentServer.Core.Common.Http.ServerSentEvent.SseFrame <Clone>$() { throw null; }
    }
    public sealed partial class SseResult : Microsoft.AspNetCore.Http.IContentTypeHttpResult, Microsoft.AspNetCore.Http.IResult, Microsoft.AspNetCore.Http.IStatusCodeHttpResult
    {
        public SseResult(System.Collections.Generic.IAsyncEnumerable<Azure.AI.AgentServer.Core.Common.Http.ServerSentEvent.SseFrame> source, System.TimeSpan? keepAliveInterval = default(System.TimeSpan?)) { }
        public string? ContentType { get { throw null; } }
        public int? StatusCode { get { throw null; } }
        public System.Threading.Tasks.Task ExecuteAsync(Microsoft.AspNetCore.Http.HttpContext ctx) { throw null; }
    }
    public static partial class SseResultExtensions
    {
        public static Azure.AI.AgentServer.Core.Common.Http.ServerSentEvent.SseResult ToSseResult<T>(this System.Collections.Generic.IAsyncEnumerable<T> source, System.Func<T, Azure.AI.AgentServer.Core.Common.Http.ServerSentEvent.SseFrame> frameTransformer, Microsoft.Extensions.Logging.ILogger logger, System.Threading.CancellationToken ct = default(System.Threading.CancellationToken), System.TimeSpan? keepAliveInterval = default(System.TimeSpan?)) { throw null; }
    }
}
namespace Azure.AI.AgentServer.Core.Common.Id
{
    public partial class FoundryIdGenerator : Azure.AI.AgentServer.Core.Common.Id.IIdGenerator
    {
        public FoundryIdGenerator(string? responseId, string? conversationId) { }
        public string? ConversationId { get { throw null; } }
        public string ResponseId { get { throw null; } }
        public static Azure.AI.AgentServer.Core.Common.Id.FoundryIdGenerator From(Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest request) { throw null; }
        public string Generate(string? category = null) { throw null; }
    }
    public static partial class IdGeneratorExtensions
    {
        public static string GenerateFunctionCallId(this Azure.AI.AgentServer.Core.Common.Id.IIdGenerator idGenerator) { throw null; }
        public static string GenerateFunctionOutputId(this Azure.AI.AgentServer.Core.Common.Id.IIdGenerator idGenerator) { throw null; }
        public static string GenerateMessageId(this Azure.AI.AgentServer.Core.Common.Id.IIdGenerator idGenerator) { throw null; }
    }
    public partial interface IIdGenerator
    {
        string Generate(string? category = null);
    }
}
namespace Azure.AI.AgentServer.Core.Context
{
    public static partial class AgentServerApplication
    {
        public static System.Threading.Tasks.Task RunAsync(Azure.AI.AgentServer.Core.Context.ApplicationOptions applicationOptions) { throw null; }
    }
    public partial class AppConfiguration : System.IEquatable<Azure.AI.AgentServer.Core.Context.AppConfiguration>
    {
        public AppConfiguration() { }
        protected AppConfiguration(Azure.AI.AgentServer.Core.Context.AppConfiguration original) { }
        [Microsoft.Extensions.Configuration.ConfigurationKeyNameAttribute("APPLICATIONINSIGHTS_CONNECTION_STRING")]
        public string AppInsightsConnectionString { get { throw null; } set { } }
        [Microsoft.Extensions.Configuration.ConfigurationKeyNameAttribute("AGENT_APP_INSIGHTS_ENABLED")]
        public bool AppInsightsEnabled { get { throw null; } set { } }
        protected virtual System.Type EqualityContract { get { throw null; } }
        [Microsoft.Extensions.Configuration.ConfigurationKeyNameAttribute("AGENT_PROJECT_NAME")]
        public Azure.AI.AgentServer.Core.Context.FoundryProjectInfo? FoundryProjectInfo { get { throw null; } set { } }
        [Microsoft.Extensions.Configuration.ConfigurationKeyNameAttribute("AGENT_LOG_LEVEL")]
        public Microsoft.Extensions.Logging.LogLevel LogLevel { get { throw null; } set { } }
        [Microsoft.Extensions.Configuration.ConfigurationKeyNameAttribute("OTEL_EXPORTER_ENDPOINT")]
        public string OpenTelemetryExporterEndpoint { get { throw null; } set { } }
        [Microsoft.Extensions.Configuration.ConfigurationKeyNameAttribute("DEFAULT_AD_PORT")]
        public int Port { get { throw null; } set { } }
        [Microsoft.Extensions.Configuration.ConfigurationKeyNameAttribute("AGENT_RESOURCE_GROUP")]
        public string ResourceGroup { get { throw null; } set { } }
        [Microsoft.Extensions.Configuration.ConfigurationKeyNameAttribute("AGENT_SUBSCRIPTION_ID")]
        public string SubscriptionId { get { throw null; } set { } }
        [Microsoft.Extensions.Configuration.ConfigurationKeyNameAttribute("AZURE_TENANT_ID")]
        public string TenantId { get { throw null; } set { } }
        public virtual bool Equals(Azure.AI.AgentServer.Core.Context.AppConfiguration? other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Core.Context.AppConfiguration? left, Azure.AI.AgentServer.Core.Context.AppConfiguration? right) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Core.Context.AppConfiguration? left, Azure.AI.AgentServer.Core.Context.AppConfiguration? right) { throw null; }
        protected virtual bool PrintMembers(System.Text.StringBuilder builder) { throw null; }
        public override string ToString() { throw null; }
        public virtual Azure.AI.AgentServer.Core.Context.AppConfiguration <Clone>$() { throw null; }
    }
    public partial class ApplicationOptions : System.IEquatable<Azure.AI.AgentServer.Core.Context.ApplicationOptions>
    {
        protected ApplicationOptions(Azure.AI.AgentServer.Core.Context.ApplicationOptions original) { }
        public ApplicationOptions(System.Action<Microsoft.Extensions.DependencyInjection.IServiceCollection> ConfigureServices, System.Func<Microsoft.Extensions.Logging.ILoggerFactory>? LoggerFactory = null, string TelemetrySourceName = "Agents", Azure.AI.AgentServer.Core.Tools.Runtime.IFoundryToolRuntime? ToolRuntime = null, Azure.AI.AgentServer.Core.Tools.Runtime.User.IUserProvider? UserProvider = null, System.Collections.Generic.IEnumerable<object>? AgentTools = null) { }
        public System.Collections.Generic.IEnumerable<object>? AgentTools { get { throw null; } set { } }
        public System.Action<Microsoft.Extensions.DependencyInjection.IServiceCollection> ConfigureServices { get { throw null; } set { } }
        protected virtual System.Type EqualityContract { get { throw null; } }
        public System.Func<Microsoft.Extensions.Logging.ILoggerFactory>? LoggerFactory { get { throw null; } set { } }
        public string TelemetrySourceName { get { throw null; } set { } }
        public Azure.AI.AgentServer.Core.Tools.Runtime.IFoundryToolRuntime? ToolRuntime { get { throw null; } set { } }
        public Azure.AI.AgentServer.Core.Tools.Runtime.User.IUserProvider? UserProvider { get { throw null; } set { } }
        public void Deconstruct(out System.Action<Microsoft.Extensions.DependencyInjection.IServiceCollection> ConfigureServices, out System.Func<Microsoft.Extensions.Logging.ILoggerFactory>? LoggerFactory, out string TelemetrySourceName, out Azure.AI.AgentServer.Core.Tools.Runtime.IFoundryToolRuntime? ToolRuntime, out Azure.AI.AgentServer.Core.Tools.Runtime.User.IUserProvider? UserProvider, out System.Collections.Generic.IEnumerable<object>? AgentTools) { throw null; }
        public virtual bool Equals(Azure.AI.AgentServer.Core.Context.ApplicationOptions? other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Core.Context.ApplicationOptions? left, Azure.AI.AgentServer.Core.Context.ApplicationOptions? right) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Core.Context.ApplicationOptions? left, Azure.AI.AgentServer.Core.Context.ApplicationOptions? right) { throw null; }
        protected virtual bool PrintMembers(System.Text.StringBuilder builder) { throw null; }
        public override string ToString() { throw null; }
        public virtual Azure.AI.AgentServer.Core.Context.ApplicationOptions <Clone>$() { throw null; }
    }
    public static partial class FoundryProjectEndpointResolver
    {
        public const string ProjectEndpointEnvironmentVariableName = "AZURE_AI_PROJECT_ENDPOINT";
        public static System.Uri ResolveProjectEndpointFromEnvironment() { throw null; }
        public static bool TryResolveProjectEndpointFromEnvironment(out System.Uri? projectEndpoint) { throw null; }
    }
    [System.ComponentModel.TypeConverterAttribute(typeof(Azure.AI.AgentServer.Core.Context.FoundryProjectInfoConverter))]
    public partial class FoundryProjectInfo : System.IEquatable<Azure.AI.AgentServer.Core.Context.FoundryProjectInfo>
    {
        protected FoundryProjectInfo(Azure.AI.AgentServer.Core.Context.FoundryProjectInfo original) { }
        public FoundryProjectInfo(string Account, string Project) { }
        public string Account { get { throw null; } set { } }
        protected virtual System.Type EqualityContract { get { throw null; } }
        public string Project { get { throw null; } set { } }
        public System.Uri ProjectEndpoint { get { throw null; } }
        public void Deconstruct(out string Account, out string Project) { throw null; }
        public virtual bool Equals(Azure.AI.AgentServer.Core.Context.FoundryProjectInfo? other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Core.Context.FoundryProjectInfo? left, Azure.AI.AgentServer.Core.Context.FoundryProjectInfo? right) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Core.Context.FoundryProjectInfo? left, Azure.AI.AgentServer.Core.Context.FoundryProjectInfo? right) { throw null; }
        public static Azure.AI.AgentServer.Core.Context.FoundryProjectInfo? Parse(string? foundryProject) { throw null; }
        protected virtual bool PrintMembers(System.Text.StringBuilder builder) { throw null; }
        public override string ToString() { throw null; }
        public virtual Azure.AI.AgentServer.Core.Context.FoundryProjectInfo <Clone>$() { throw null; }
    }
    public sealed partial class FoundryProjectInfoConverter : System.ComponentModel.TypeConverter
    {
        public FoundryProjectInfoConverter() { }
        public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext? context, System.Type sourceType) { throw null; }
        public override object? ConvertFrom(System.ComponentModel.ITypeDescriptorContext? context, System.Globalization.CultureInfo? culture, object value) { throw null; }
    }
}
namespace Azure.AI.AgentServer.Core.HealthCheck
{
    public static partial class HealthEndpoints
    {
        public static Microsoft.AspNetCore.Routing.IEndpointRouteBuilder MapHealthChecksEndpoints(this Microsoft.AspNetCore.Routing.IEndpointRouteBuilder endpoints) { throw null; }
    }
}
namespace Azure.AI.AgentServer.Core.Responses.Conversations
{
    public partial class ConversationItemsClient
    {
        protected ConversationItemsClient() { }
        public ConversationItemsClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ConversationItemsClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.AgentServer.Core.Responses.Conversations.ConversationItemsClientOptions options) { }
        public virtual System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource> ListItems(string conversationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource>> ListItemsAsync(string conversationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public sealed partial class ConversationItemsClientOptions : Azure.Core.ClientOptions
    {
        public ConversationItemsClientOptions(Azure.AI.AgentServer.Core.Responses.Conversations.ConversationItemsClientOptions.ServiceVersion version = Azure.AI.AgentServer.Core.Responses.Conversations.ConversationItemsClientOptions.ServiceVersion.V2025_11_15_Preview) { }
        public enum ServiceVersion
        {
            V2025_11_15_Preview = 1,
        }
    }
}
namespace Azure.AI.AgentServer.Core.Server
{
    public sealed partial class AgentServerContext : System.IAsyncDisposable
    {
        internal AgentServerContext() { }
        public Azure.AI.AgentServer.Core.Tools.Runtime.IFoundryToolRuntime Tools { get { throw null; } }
        public System.Threading.Tasks.ValueTask DisposeAsync() { throw null; }
        public static Azure.AI.AgentServer.Core.Server.AgentServerContext Get() { throw null; }
    }
}
namespace Azure.AI.AgentServer.Core.Server.Middleware
{
    public partial class AgentRunContextMiddleware
    {
        public AgentRunContextMiddleware(Microsoft.AspNetCore.Http.RequestDelegate next, Microsoft.Extensions.Logging.ILogger<Azure.AI.AgentServer.Core.Server.Middleware.AgentRunContextMiddleware> logger, System.Collections.Generic.IEnumerable<object>? agentTools = null) { }
        public System.Threading.Tasks.Task InvokeAsync(Microsoft.AspNetCore.Http.HttpContext httpContext) { throw null; }
    }
    public static partial class AgentRunContextMiddlewareExtensions
    {
        public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseAgentRunContext(this Microsoft.AspNetCore.Builder.IApplicationBuilder app, System.Collections.Generic.IEnumerable<object>? agentTools = null) { throw null; }
    }
    public partial class UserInfoContextMiddleware
    {
        public UserInfoContextMiddleware(Microsoft.AspNetCore.Http.RequestDelegate next, System.Func<Microsoft.AspNetCore.Http.HttpContext, System.Threading.Tasks.Task<Azure.AI.AgentServer.Core.Tools.Models.UserInfo?>>? userResolver = null) { }
        public System.Threading.Tasks.Task InvokeAsync(Microsoft.AspNetCore.Http.HttpContext httpContext) { throw null; }
    }
    public static partial class UserInfoContextMiddlewareExtensions
    {
        public static Microsoft.AspNetCore.Builder.IApplicationBuilder UseUserInfoContext(this Microsoft.AspNetCore.Builder.IApplicationBuilder app, System.Func<Microsoft.AspNetCore.Http.HttpContext, System.Threading.Tasks.Task<Azure.AI.AgentServer.Core.Tools.Models.UserInfo?>>? userResolver = null) { throw null; }
    }
}
namespace Azure.AI.AgentServer.Core.Telemetry
{
    public static partial class HostedAgentTelemetry
    {
        public static readonly System.Diagnostics.ActivitySource Source;
        public static System.Diagnostics.Activity SetResponsesTag(this System.Diagnostics.Activity activity, string key, object? value) { throw null; }
        public static System.Diagnostics.Activity SetServiceNamespace(this System.Diagnostics.Activity activity, string serviceNamespace) { throw null; }
        public static System.Diagnostics.Activity SetServiceTag(this System.Diagnostics.Activity activity) { throw null; }
    }
    public partial class LogEnrichmentProcessor : OpenTelemetry.BaseProcessor<OpenTelemetry.Logs.LogRecord>
    {
        public LogEnrichmentProcessor() { }
        public override void OnEnd(OpenTelemetry.Logs.LogRecord data) { }
    }
}
namespace Azure.AI.AgentServer.Core.Tools
{
    public partial class FoundryToolClient : System.IAsyncDisposable, System.IDisposable
    {
        protected FoundryToolClient() { }
        public FoundryToolClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.AgentServer.Core.Tools.FoundryToolClientOptions? options = null) { }
        public virtual object? InvokeTool(Azure.AI.AgentServer.Core.Tools.Models.ResolvedFoundryTool tool, System.Collections.Generic.IDictionary<string, object?>? arguments = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual object? InvokeTool(string toolName, System.Collections.Generic.IDictionary<string, object?>? arguments = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<object?> InvokeToolAsync(Azure.AI.AgentServer.Core.Tools.Models.ResolvedFoundryTool tool, System.Collections.Generic.IDictionary<string, object?>? arguments = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<object?> InvokeToolAsync(string toolName, System.Collections.Generic.IDictionary<string, object?>? arguments = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Core.Tools.Models.ResolvedFoundryTool> ListTools(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Core.Tools.Models.ResolvedFoundryTool>> ListToolsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Threading.Tasks.ValueTask System.IAsyncDisposable.DisposeAsync() { throw null; }
        void System.IDisposable.Dispose() { }
    }
    public partial class FoundryToolClientOptions : Azure.Core.ClientOptions
    {
        public FoundryToolClientOptions(Azure.AI.AgentServer.Core.Tools.FoundryToolClientOptions.ServiceVersion version = Azure.AI.AgentServer.Core.Tools.FoundryToolClientOptions.ServiceVersion.V1) { }
        public string AgentName { get { throw null; } set { } }
        public string ApiVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> CredentialScopes { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Core.Tools.Models.FoundryTool> Tools { get { throw null; } set { } }
        public Azure.AI.AgentServer.Core.Tools.Models.UserInfo? User { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V1 = 1,
        }
    }
}
namespace Azure.AI.AgentServer.Core.Tools.Exceptions
{
    public partial class MCPToolApprovalRequiredException : System.Exception
    {
        public MCPToolApprovalRequiredException(string message, System.Collections.Generic.IReadOnlyDictionary<string, object?>? approvalArguments = null, System.Collections.Generic.IReadOnlyDictionary<string, object?>? payload = null) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, object?>? ApprovalArguments { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object?>? Payload { get { throw null; } }
    }
    public partial class OAuthConsentRequiredException : System.Exception
    {
        public OAuthConsentRequiredException(string message, string? consentUrl = null, System.Collections.Generic.IReadOnlyDictionary<string, object?>? payload = null) { }
        public string? ConsentUrl { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object?>? Payload { get { throw null; } }
    }
}
namespace Azure.AI.AgentServer.Core.Tools.Models
{
    public sealed partial class FoundryConnectedTool : Azure.AI.AgentServer.Core.Tools.Models.FoundryTool, System.IEquatable<Azure.AI.AgentServer.Core.Tools.Models.FoundryConnectedTool>
    {
        public FoundryConnectedTool(Azure.AI.AgentServer.Core.Tools.Models.FoundryToolProtocol protocol, string projectConnectionId, System.Collections.Generic.IReadOnlyDictionary<string, object?>? additionalProperties = null) : base (default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        protected override System.Type EqualityContract { get { throw null; } }
        public override string Id { get { throw null; } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public Azure.AI.AgentServer.Core.Tools.Models.FoundryToolProtocol Protocol { get { throw null; } set { } }
        public override Azure.AI.AgentServer.Core.Tools.Models.FoundryToolSource Source { get { throw null; } }
        public string Type { get { throw null; } }
        public static Azure.AI.AgentServer.Core.Tools.Models.FoundryConnectedTool A2a(string projectConnectionId, System.Collections.Generic.IReadOnlyDictionary<string, object?>? additionalProperties = null) { throw null; }
        public bool Equals(Azure.AI.AgentServer.Core.Tools.Models.FoundryConnectedTool? other) { throw null; }
        public sealed override bool Equals(Azure.AI.AgentServer.Core.Tools.Models.FoundryTool? other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static Azure.AI.AgentServer.Core.Tools.Models.FoundryConnectedTool Mcp(string projectConnectionId, System.Collections.Generic.IReadOnlyDictionary<string, object?>? additionalProperties = null) { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Core.Tools.Models.FoundryConnectedTool? left, Azure.AI.AgentServer.Core.Tools.Models.FoundryConnectedTool? right) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Core.Tools.Models.FoundryConnectedTool? left, Azure.AI.AgentServer.Core.Tools.Models.FoundryConnectedTool? right) { throw null; }
        protected override bool PrintMembers(System.Text.StringBuilder builder) { throw null; }
        public override string ToString() { throw null; }
        [System.Runtime.CompilerServices.PreserveBaseOverridesAttribute]
        virtual new Azure.AI.AgentServer.Core.Tools.Models.FoundryConnectedTool <Clone>$() { throw null; }
    }
    public sealed partial class FoundryHostedMcpTool : Azure.AI.AgentServer.Core.Tools.Models.FoundryTool, System.IEquatable<Azure.AI.AgentServer.Core.Tools.Models.FoundryHostedMcpTool>
    {
        public FoundryHostedMcpTool(string name, System.Collections.Generic.IReadOnlyDictionary<string, object?>? additionalProperties = null) : base (default(System.Collections.Generic.IReadOnlyDictionary<string, object>)) { }
        protected override System.Type EqualityContract { get { throw null; } }
        public override string Id { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public override Azure.AI.AgentServer.Core.Tools.Models.FoundryToolSource Source { get { throw null; } }
        public static Azure.AI.AgentServer.Core.Tools.Models.FoundryHostedMcpTool Create(string name, System.Collections.Generic.IReadOnlyDictionary<string, object?>? additionalProperties = null) { throw null; }
        public bool Equals(Azure.AI.AgentServer.Core.Tools.Models.FoundryHostedMcpTool? other) { throw null; }
        public sealed override bool Equals(Azure.AI.AgentServer.Core.Tools.Models.FoundryTool? other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Core.Tools.Models.FoundryHostedMcpTool? left, Azure.AI.AgentServer.Core.Tools.Models.FoundryHostedMcpTool? right) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Core.Tools.Models.FoundryHostedMcpTool? left, Azure.AI.AgentServer.Core.Tools.Models.FoundryHostedMcpTool? right) { throw null; }
        protected override bool PrintMembers(System.Text.StringBuilder builder) { throw null; }
        public override string ToString() { throw null; }
        [System.Runtime.CompilerServices.PreserveBaseOverridesAttribute]
        virtual new Azure.AI.AgentServer.Core.Tools.Models.FoundryHostedMcpTool <Clone>$() { throw null; }
    }
    public abstract partial class FoundryTool : System.IEquatable<Azure.AI.AgentServer.Core.Tools.Models.FoundryTool>
    {
        protected FoundryTool(Azure.AI.AgentServer.Core.Tools.Models.FoundryTool original) { }
        protected FoundryTool(System.Collections.Generic.IReadOnlyDictionary<string, object?>? additionalProperties = null) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, object?>? AdditionalProperties { get { throw null; } set { } }
        protected virtual System.Type EqualityContract { get { throw null; } }
        public abstract string Id { get; }
        public abstract Azure.AI.AgentServer.Core.Tools.Models.FoundryToolSource Source { get; }
        public virtual bool Equals(Azure.AI.AgentServer.Core.Tools.Models.FoundryTool? other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Core.Tools.Models.FoundryTool? left, Azure.AI.AgentServer.Core.Tools.Models.FoundryTool? right) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Core.Tools.Models.FoundryTool? left, Azure.AI.AgentServer.Core.Tools.Models.FoundryTool? right) { throw null; }
        protected virtual bool PrintMembers(System.Text.StringBuilder builder) { throw null; }
        public override string ToString() { throw null; }
        public abstract Azure.AI.AgentServer.Core.Tools.Models.FoundryTool <Clone>$();
    }
    public sealed partial class FoundryToolDetails : System.IEquatable<Azure.AI.AgentServer.Core.Tools.Models.FoundryToolDetails>
    {
        public FoundryToolDetails(string name, string description, System.Collections.Generic.IReadOnlyDictionary<string, object?> metadata, System.Collections.Generic.IReadOnlyDictionary<string, object?>? inputSchema = null) { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object?>? InputSchema { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object?> Metadata { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public bool Equals(Azure.AI.AgentServer.Core.Tools.Models.FoundryToolDetails? other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Core.Tools.Models.FoundryToolDetails? left, Azure.AI.AgentServer.Core.Tools.Models.FoundryToolDetails? right) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Core.Tools.Models.FoundryToolDetails? left, Azure.AI.AgentServer.Core.Tools.Models.FoundryToolDetails? right) { throw null; }
        public override string ToString() { throw null; }
        public Azure.AI.AgentServer.Core.Tools.Models.FoundryToolDetails <Clone>$() { throw null; }
    }
    public enum FoundryToolProtocol
    {
        MCP = 0,
        A2A = 1,
    }
    public enum FoundryToolSource
    {
        HOSTED_MCP = 0,
        CONNECTED = 1,
    }
    [System.Runtime.CompilerServices.RequiredMemberAttribute]
    public partial class ResolvedFoundryTool : System.IEquatable<Azure.AI.AgentServer.Core.Tools.Models.ResolvedFoundryTool>
    {
        [System.ObsoleteAttribute("Constructors of types with required members are not supported in this version of your compiler.", true)]
        [System.Runtime.CompilerServices.CompilerFeatureRequiredAttribute("RequiredMembers")]
        public ResolvedFoundryTool() { }
        [System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
        protected ResolvedFoundryTool(Azure.AI.AgentServer.Core.Tools.Models.ResolvedFoundryTool original) { }
        public System.Func<System.Collections.Generic.IDictionary<string, object?>, System.Threading.Tasks.Task<object?>>? AsyncInvoker { get { throw null; } set { } }
        public Azure.AI.AgentServer.Core.Tools.Models.FoundryTool? Definition { get { throw null; } set { } }
        public string Description { get { throw null; } }
        [System.Runtime.CompilerServices.RequiredMemberAttribute]
        public Azure.AI.AgentServer.Core.Tools.Models.FoundryToolDetails Details { get { throw null; } set { } }
        protected virtual System.Type EqualityContract { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object?>? InputSchema { get { throw null; } }
        public System.Func<System.Collections.Generic.IDictionary<string, object?>, object?>? Invoker { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object?> Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.AgentServer.Core.Tools.Models.FoundryToolSource Source { get { throw null; } }
        public virtual bool Equals(Azure.AI.AgentServer.Core.Tools.Models.ResolvedFoundryTool? other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public object? Invoke(System.Collections.Generic.IDictionary<string, object?>? arguments = null) { throw null; }
        public System.Threading.Tasks.Task<object?> InvokeAsync(System.Collections.Generic.IDictionary<string, object?>? arguments = null) { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Core.Tools.Models.ResolvedFoundryTool? left, Azure.AI.AgentServer.Core.Tools.Models.ResolvedFoundryTool? right) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Core.Tools.Models.ResolvedFoundryTool? left, Azure.AI.AgentServer.Core.Tools.Models.ResolvedFoundryTool? right) { throw null; }
        protected virtual bool PrintMembers(System.Text.StringBuilder builder) { throw null; }
        public override string ToString() { throw null; }
        public virtual Azure.AI.AgentServer.Core.Tools.Models.ResolvedFoundryTool <Clone>$() { throw null; }
    }
    public partial class UserInfo : System.IEquatable<Azure.AI.AgentServer.Core.Tools.Models.UserInfo>
    {
        protected UserInfo(Azure.AI.AgentServer.Core.Tools.Models.UserInfo original) { }
        public UserInfo(string ObjectId, string TenantId) { }
        protected virtual System.Type EqualityContract { get { throw null; } }
        public string ObjectId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Properties { get { throw null; } }
        public string TenantId { get { throw null; } set { } }
        public void Deconstruct(out string ObjectId, out string TenantId) { throw null; }
        public virtual bool Equals(Azure.AI.AgentServer.Core.Tools.Models.UserInfo? other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Core.Tools.Models.UserInfo? left, Azure.AI.AgentServer.Core.Tools.Models.UserInfo? right) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Core.Tools.Models.UserInfo? left, Azure.AI.AgentServer.Core.Tools.Models.UserInfo? right) { throw null; }
        protected virtual bool PrintMembers(System.Text.StringBuilder builder) { throw null; }
        public override string ToString() { throw null; }
        public virtual Azure.AI.AgentServer.Core.Tools.Models.UserInfo <Clone>$() { throw null; }
    }
}
namespace Azure.AI.AgentServer.Core.Tools.Runtime
{
    public partial class FoundryToolRuntime : Azure.AI.AgentServer.Core.Tools.Runtime.IFoundryToolRuntime, System.IAsyncDisposable
    {
        public FoundryToolRuntime(Azure.AI.AgentServer.Core.Tools.FoundryToolClient client, Azure.AI.AgentServer.Core.Tools.Runtime.Catalog.IFoundryToolCatalog catalog, Azure.AI.AgentServer.Core.Tools.Runtime.Invocation.IFoundryToolInvocationResolver invocation) { }
        public FoundryToolRuntime(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.AgentServer.Core.Tools.FoundryToolClientOptions? options = null, Azure.AI.AgentServer.Core.Tools.Runtime.User.IUserProvider? userProvider = null, System.TimeSpan? cacheTtl = default(System.TimeSpan?)) { }
        public Azure.AI.AgentServer.Core.Tools.Runtime.Catalog.IFoundryToolCatalog Catalog { get { throw null; } }
        public Azure.AI.AgentServer.Core.Tools.Runtime.Invocation.IFoundryToolInvocationResolver Invocation { get { throw null; } }
        public System.Threading.Tasks.ValueTask DisposeAsync() { throw null; }
        public System.Threading.Tasks.Task<object?> InvokeAsync(object tool, System.Collections.Generic.IDictionary<string, object?>? arguments = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial interface IFoundryToolRuntime : System.IAsyncDisposable
    {
        Azure.AI.AgentServer.Core.Tools.Runtime.Catalog.IFoundryToolCatalog Catalog { get; }
        Azure.AI.AgentServer.Core.Tools.Runtime.Invocation.IFoundryToolInvocationResolver Invocation { get; }
        System.Threading.Tasks.Task<object?> InvokeAsync(object tool, System.Collections.Generic.IDictionary<string, object?>? arguments = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
}
namespace Azure.AI.AgentServer.Core.Tools.Runtime.Catalog
{
    public abstract partial class CachedFoundryToolCatalog : Azure.AI.AgentServer.Core.Tools.Runtime.Catalog.IFoundryToolCatalog, System.IDisposable
    {
        protected CachedFoundryToolCatalog(System.TimeSpan? cacheTtl = default(System.TimeSpan?), long maxCacheEntries = (long)1024) { }
        public void ClearCache() { }
        public void Dispose() { }
        protected virtual void Dispose(bool disposing) { }
        protected abstract System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Core.Tools.Models.FoundryToolDetails>>> FetchToolsAsync(System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Core.Tools.Models.FoundryTool> tools, Azure.AI.AgentServer.Core.Tools.Models.UserInfo? userInfo, System.Threading.CancellationToken cancellationToken);
        public System.Threading.Tasks.Task<Azure.AI.AgentServer.Core.Tools.Models.ResolvedFoundryTool?> GetAsync(object tool, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        protected virtual System.Threading.Tasks.Task<Azure.AI.AgentServer.Core.Tools.Models.UserInfo?> GetUserContextAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
        public System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Core.Tools.Models.ResolvedFoundryTool>> ListAsync(System.Collections.Generic.IEnumerable<object> tools, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DefaultFoundryToolCatalog : Azure.AI.AgentServer.Core.Tools.Runtime.Catalog.CachedFoundryToolCatalog
    {
        public DefaultFoundryToolCatalog(Azure.AI.AgentServer.Core.Tools.FoundryToolClient client, Azure.AI.AgentServer.Core.Tools.Runtime.User.IUserProvider? userProvider = null, System.TimeSpan? cacheTtl = default(System.TimeSpan?), long maxCacheEntries = (long)1024) : base (default(System.TimeSpan?), default(long)) { }
        protected override System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Core.Tools.Models.FoundryToolDetails>>> FetchToolsAsync(System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Core.Tools.Models.FoundryTool> tools, Azure.AI.AgentServer.Core.Tools.Models.UserInfo? userInfo, System.Threading.CancellationToken cancellationToken) { throw null; }
        protected override System.Threading.Tasks.Task<Azure.AI.AgentServer.Core.Tools.Models.UserInfo?> GetUserContextAsync(System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial interface IFoundryToolCatalog
    {
        System.Threading.Tasks.Task<Azure.AI.AgentServer.Core.Tools.Models.ResolvedFoundryTool?> GetAsync(object tool, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Core.Tools.Models.ResolvedFoundryTool>> ListAsync(System.Collections.Generic.IEnumerable<object> tools, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
}
namespace Azure.AI.AgentServer.Core.Tools.Runtime.Facade
{
    public static partial class FoundryToolFactory
    {
        public static Azure.AI.AgentServer.Core.Tools.Models.FoundryTool Create(Azure.AI.AgentServer.Core.Tools.Models.FoundryTool tool) { throw null; }
        public static Azure.AI.AgentServer.Core.Tools.Models.FoundryTool Create(System.Collections.Generic.IDictionary<string, object?> facade) { throw null; }
        public static Azure.AI.AgentServer.Core.Tools.Models.FoundryTool Create(object tool) { throw null; }
    }
}
namespace Azure.AI.AgentServer.Core.Tools.Runtime.Invocation
{
    public partial class DefaultFoundryToolInvocationResolver : Azure.AI.AgentServer.Core.Tools.Runtime.Invocation.IFoundryToolInvocationResolver
    {
        public DefaultFoundryToolInvocationResolver(Azure.AI.AgentServer.Core.Tools.Runtime.Catalog.IFoundryToolCatalog catalog, Azure.AI.AgentServer.Core.Tools.FoundryToolClient client) { }
        public System.Threading.Tasks.Task<Azure.AI.AgentServer.Core.Tools.Runtime.Invocation.IFoundryToolInvoker> ResolveAsync(object tool, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DefaultFoundryToolInvoker : Azure.AI.AgentServer.Core.Tools.Runtime.Invocation.IFoundryToolInvoker
    {
        public DefaultFoundryToolInvoker(Azure.AI.AgentServer.Core.Tools.Models.ResolvedFoundryTool resolvedTool, Azure.AI.AgentServer.Core.Tools.FoundryToolClient client) { }
        public Azure.AI.AgentServer.Core.Tools.Models.ResolvedFoundryTool ResolvedTool { get { throw null; } }
        public System.Threading.Tasks.Task<object?> InvokeAsync(System.Collections.Generic.IDictionary<string, object?>? arguments = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial interface IFoundryToolInvocationResolver
    {
        System.Threading.Tasks.Task<Azure.AI.AgentServer.Core.Tools.Runtime.Invocation.IFoundryToolInvoker> ResolveAsync(object tool, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
    public partial interface IFoundryToolInvoker
    {
        Azure.AI.AgentServer.Core.Tools.Models.ResolvedFoundryTool ResolvedTool { get; }
        System.Threading.Tasks.Task<object?> InvokeAsync(System.Collections.Generic.IDictionary<string, object?>? arguments = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
}
namespace Azure.AI.AgentServer.Core.Tools.Runtime.User
{
    public partial class AsyncLocalUserProvider : Azure.AI.AgentServer.Core.Tools.Runtime.User.IUserProvider
    {
        public AsyncLocalUserProvider() { }
        public static Azure.AI.AgentServer.Core.Tools.Models.UserInfo? Current { get { throw null; } }
        public System.Threading.Tasks.Task<Azure.AI.AgentServer.Core.Tools.Models.UserInfo?> GetUserAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial interface IUserProvider
    {
        System.Threading.Tasks.Task<Azure.AI.AgentServer.Core.Tools.Models.UserInfo?> GetUserAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
    public static partial class UserResolvers
    {
        public static Azure.AI.AgentServer.Core.Tools.Models.UserInfo? ResolveFromHeaders(Microsoft.AspNetCore.Http.IHeaderDictionary headers, string objectIdHeader = "x-aml-oid", string tenantIdHeader = "x-aml-tid") { throw null; }
    }
}
namespace Azure.AI.AgentServer.Responses.Endpoint
{
    public static partial class AgentRunEndpoints
    {
        public static Microsoft.AspNetCore.Routing.IEndpointRouteBuilder MapAgentRunEndpoints(this Microsoft.AspNetCore.Routing.IEndpointRouteBuilder endpoints) { throw null; }
    }
}
namespace Azure.AI.AgentServer.Responses.Invocation
{
    public abstract partial class AgentInvocationBase : Azure.AI.AgentServer.Responses.Invocation.IAgentInvocation
    {
        protected AgentInvocationBase() { }
        protected abstract System.Threading.Tasks.Task<(Azure.AI.AgentServer.Responses.Invocation.Stream.INestedStreamEventGenerator<Azure.AI.AgentServer.Contracts.Generated.Responses.Response> Generator, System.Func<System.Threading.CancellationToken, System.Threading.Tasks.Task> PostInvoke)> DoInvokeStreamAsync(Azure.AI.AgentServer.Responses.Invocation.AgentRunContext context, System.Threading.CancellationToken cancellationToken);
        public abstract System.Threading.Tasks.Task<Azure.AI.AgentServer.Contracts.Generated.Responses.Response> InvokeAsync(Azure.AI.AgentServer.Responses.Invocation.AgentRunContext context, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        public System.Collections.Generic.IAsyncEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent> InvokeStreamAsync(Azure.AI.AgentServer.Responses.Invocation.AgentRunContext context, [System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.ObsoleteAttribute("AgentInvocationContext is deprecated. Use AgentRunContext from Azure.AI.AgentServer.Responses.Invocation namespace instead. See MIGRATION_GUIDE.md for details.", false)]
    public partial class AgentInvocationContext
    {
        public AgentInvocationContext(Azure.AI.AgentServer.Core.Common.Id.IIdGenerator idGenerator, string responseId, string? conversationId) { }
        public string? ConversationId { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Invocation.AgentInvocationContext? Current { get { throw null; } }
        public Azure.AI.AgentServer.Core.Common.Id.IIdGenerator IdGenerator { get { throw null; } }
        public string ResponseId { get { throw null; } }
    }
    public partial class AgentInvocationException : System.Exception
    {
        public AgentInvocationException(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseError error) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseError Error { get { throw null; } }
    }
    public partial class AgentRunContext
    {
        public AgentRunContext(Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest request, System.Collections.Generic.IReadOnlyDictionary<string, object?>? rawPayload = null, Azure.AI.AgentServer.Core.Tools.Models.UserInfo? userInfo = null, System.Collections.Generic.IReadOnlyList<object>? agentTools = null) { }
        public System.Collections.Generic.IReadOnlyList<object> AgentTools { get { throw null; } }
        public string? ConversationId { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Invocation.AgentRunContext? Current { get { throw null; } }
        public Azure.AI.AgentServer.Core.Common.Id.IIdGenerator IdGenerator { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, object?> RawPayload { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest Request { get { throw null; } }
        public string ResponseId { get { throw null; } }
        public bool Stream { get { throw null; } }
        public Azure.AI.AgentServer.Core.Tools.Models.UserInfo? UserInfo { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.Agents.AgentReference? GetAgentIdObject() { throw null; }
        public Azure.AI.AgentServer.Contracts.Generated.Conversations.ResponseConversation1? GetConversationObject() { throw null; }
        public System.Collections.Generic.IReadOnlyList<object> GetTools() { throw null; }
    }
    public partial interface IAgentInvocation
    {
        System.Threading.Tasks.Task<Azure.AI.AgentServer.Contracts.Generated.Responses.Response> InvokeAsync(Azure.AI.AgentServer.Responses.Invocation.AgentRunContext context, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        System.Collections.Generic.IAsyncEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent> InvokeStreamAsync(Azure.AI.AgentServer.Responses.Invocation.AgentRunContext context, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
    public static partial class ResponsesExtensions
    {
        public static readonly string HumanInTheLoopFunctionName;
        public static string? GetConversationId(this Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest request) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.Agents.AgentId? ToAgentId(this Azure.AI.AgentServer.Contracts.Generated.Agents.AgentReference? agent) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.Responses.Response ToResponse(this Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest request, Azure.AI.AgentServer.Responses.Invocation.AgentRunContext? context = null, System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource>? output = null, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStatus status = Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStatus.Completed, System.DateTimeOffset? createdAt = default(System.DateTimeOffset?), Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsage? usage = null) { throw null; }
    }
}
namespace Azure.AI.AgentServer.Responses.Invocation.Stream
{
    public partial class AtomicSequenceNumber : Azure.AI.AgentServer.Responses.Invocation.Stream.ISequenceNumber
    {
        public AtomicSequenceNumber() { }
        public int Current() { throw null; }
        public int Next() { throw null; }
    }
    public partial class DefaultSequenceNumber : Azure.AI.AgentServer.Responses.Invocation.Stream.ISequenceNumber
    {
        public DefaultSequenceNumber() { }
        public int Current() { throw null; }
        public int Next() { throw null; }
    }
    public partial interface INestedStreamEventGenerator<TAggregate> where TAggregate : class
    {
        System.Collections.Generic.IAsyncEnumerable<Azure.AI.AgentServer.Responses.Invocation.Stream.NestedEventsGroup<TAggregate>> Generate();
    }
    public partial interface ISequenceNumber
    {
        Azure.AI.AgentServer.Responses.Invocation.Stream.ISequenceNumber Atomic { get { throw null; } }
        Azure.AI.AgentServer.Responses.Invocation.Stream.ISequenceNumber Default { get { throw null; } }
        int Current();
        int Next();
    }
    [System.Runtime.CompilerServices.RequiredMemberAttribute]
    public abstract partial class NestedChunkedUpdatingGeneratorBase<TAggregate, TUpdate> : Azure.AI.AgentServer.Responses.Invocation.Stream.NestedStreamEventGeneratorBase<TAggregate> where TAggregate : class
    {
        [System.ObsoleteAttribute("Constructors of types with required members are not supported in this version of your compiler.", true)]
        [System.Runtime.CompilerServices.CompilerFeatureRequiredAttribute("RequiredMembers")]
        protected NestedChunkedUpdatingGeneratorBase() { }
        protected Azure.AI.AgentServer.Responses.Invocation.Stream.ISequenceNumber GroupSeq { get { throw null; } }
        [System.Runtime.CompilerServices.RequiredMemberAttribute]
        public System.Collections.Generic.IAsyncEnumerable<TUpdate> Updates { get { throw null; } set { } }
        protected abstract bool Changed(TUpdate previous, TUpdate current);
        protected abstract Azure.AI.AgentServer.Responses.Invocation.Stream.NestedEventsGroup<TAggregate> CreateGroup(System.Collections.Generic.IAsyncEnumerable<TUpdate> updateGroup);
        public override System.Collections.Generic.IAsyncEnumerable<Azure.AI.AgentServer.Responses.Invocation.Stream.NestedEventsGroup<TAggregate>> Generate() { throw null; }
    }
    [System.Runtime.CompilerServices.RequiredMemberAttribute]
    public partial class NestedEventsGroup<T> where T : class
    {
        [System.ObsoleteAttribute("Constructors of types with required members are not supported in this version of your compiler.", true)]
        [System.Runtime.CompilerServices.CompilerFeatureRequiredAttribute("RequiredMembers")]
        public NestedEventsGroup() { }
        [System.Runtime.CompilerServices.RequiredMemberAttribute]
        public System.Func<T> CreateAggregate { get { throw null; } set { } }
        [System.Runtime.CompilerServices.RequiredMemberAttribute]
        public System.Collections.Generic.IAsyncEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent> Events { get { throw null; } set { } }
    }
    [System.Runtime.CompilerServices.RequiredMemberAttribute]
    public partial class NestedResponseGenerator : Azure.AI.AgentServer.Responses.Invocation.Stream.NestedStreamEventGeneratorBase<Azure.AI.AgentServer.Contracts.Generated.Responses.Response>
    {
        [System.ObsoleteAttribute("Constructors of types with required members are not supported in this version of your compiler.", true)]
        [System.Runtime.CompilerServices.CompilerFeatureRequiredAttribute("RequiredMembers")]
        public NestedResponseGenerator() { }
        [System.Runtime.CompilerServices.RequiredMemberAttribute]
        public Azure.AI.AgentServer.Responses.Invocation.AgentRunContext Context { get { throw null; } set { } }
        [System.Runtime.CompilerServices.RequiredMemberAttribute]
        public Azure.AI.AgentServer.Responses.Invocation.Stream.INestedStreamEventGenerator<System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource>> OutputGenerator { get { throw null; } set { } }
        public System.Action<System.Action<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsage>> SubscribeUsageUpdate { set { } }
        public override System.Collections.Generic.IAsyncEnumerable<Azure.AI.AgentServer.Responses.Invocation.Stream.NestedEventsGroup<Azure.AI.AgentServer.Contracts.Generated.Responses.Response>> Generate() { throw null; }
    }
    [System.Runtime.CompilerServices.RequiredMemberAttribute]
    public abstract partial class NestedStreamEventGeneratorBase<TAggregate> : Azure.AI.AgentServer.Responses.Invocation.Stream.INestedStreamEventGenerator<TAggregate> where TAggregate : class
    {
        [System.ObsoleteAttribute("Constructors of types with required members are not supported in this version of your compiler.", true)]
        [System.Runtime.CompilerServices.CompilerFeatureRequiredAttribute("RequiredMembers")]
        protected NestedStreamEventGeneratorBase() { }
        public System.Threading.CancellationToken CancellationToken { get { throw null; } set { } }
        [System.Runtime.CompilerServices.RequiredMemberAttribute]
        public Azure.AI.AgentServer.Responses.Invocation.Stream.ISequenceNumber Seq { get { throw null; } set { } }
        public abstract System.Collections.Generic.IAsyncEnumerable<Azure.AI.AgentServer.Responses.Invocation.Stream.NestedEventsGroup<TAggregate>> Generate();
    }
}
