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
        public string ConversationId { get { throw null; } }
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
        public ApplicationOptions(System.Action<Microsoft.Extensions.DependencyInjection.IServiceCollection> ConfigureServices, System.Func<Microsoft.Extensions.Logging.ILoggerFactory>? LoggerFactory = null, string TelemetrySourceName = "Agents") { }
        public System.Action<Microsoft.Extensions.DependencyInjection.IServiceCollection> ConfigureServices { get { throw null; } set { } }
        protected virtual System.Type EqualityContract { get { throw null; } }
        public System.Func<Microsoft.Extensions.Logging.ILoggerFactory>? LoggerFactory { get { throw null; } set { } }
        public string TelemetrySourceName { get { throw null; } set { } }
        public void Deconstruct(out System.Action<Microsoft.Extensions.DependencyInjection.IServiceCollection> ConfigureServices, out System.Func<Microsoft.Extensions.Logging.ILoggerFactory>? LoggerFactory, out string TelemetrySourceName) { throw null; }
        public virtual bool Equals(Azure.AI.AgentServer.Core.Context.ApplicationOptions? other) { throw null; }
        public override bool Equals(object? obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Core.Context.ApplicationOptions? left, Azure.AI.AgentServer.Core.Context.ApplicationOptions? right) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Core.Context.ApplicationOptions? left, Azure.AI.AgentServer.Core.Context.ApplicationOptions? right) { throw null; }
        protected virtual bool PrintMembers(System.Text.StringBuilder builder) { throw null; }
        public override string ToString() { throw null; }
        public virtual Azure.AI.AgentServer.Core.Context.ApplicationOptions <Clone>$() { throw null; }
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
namespace Azure.AI.AgentServer.Responses.Endpoint
{
    public static partial class AgentRunEndpoints
    {
        public static Microsoft.AspNetCore.Routing.IEndpointRouteBuilder MapAgentRunEndpoints(this Microsoft.AspNetCore.Routing.IEndpointRouteBuilder endpoints) { throw null; }
    }
    public partial class AgentRunExceptionFilter : Microsoft.AspNetCore.Http.IEndpointFilter
    {
        public AgentRunExceptionFilter() { }
        public System.Threading.Tasks.ValueTask<object?> InvokeAsync(Microsoft.AspNetCore.Http.EndpointFilterInvocationContext ctx, Microsoft.AspNetCore.Http.EndpointFilterDelegate next) { throw null; }
    }
}
namespace Azure.AI.AgentServer.Responses.Invocation
{
    public abstract partial class AgentInvocationBase : Azure.AI.AgentServer.Responses.Invocation.IAgentInvocation
    {
        protected AgentInvocationBase() { }
        protected abstract System.Threading.Tasks.Task<Azure.AI.AgentServer.Contracts.Generated.Responses.Response> DoInvokeAsync(Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest request, Azure.AI.AgentServer.Responses.Invocation.AgentInvocationContext context, System.Threading.CancellationToken cancellationToken);
        protected abstract Azure.AI.AgentServer.Responses.Invocation.Stream.INestedStreamEventGenerator<Azure.AI.AgentServer.Contracts.Generated.Responses.Response> DoInvokeStreamAsync(Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest request, Azure.AI.AgentServer.Responses.Invocation.AgentInvocationContext context, System.Threading.CancellationToken cancellationToken);
        public System.Threading.Tasks.Task<Azure.AI.AgentServer.Contracts.Generated.Responses.Response> InvokeAsync(Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest request, Azure.AI.AgentServer.Responses.Invocation.AgentInvocationContext context, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public System.Collections.Generic.IAsyncEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent> InvokeStreamAsync(Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest request, Azure.AI.AgentServer.Responses.Invocation.AgentInvocationContext context, [System.Runtime.CompilerServices.EnumeratorCancellationAttribute] System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AgentInvocationContext
    {
        public AgentInvocationContext(Azure.AI.AgentServer.Core.Common.Id.IIdGenerator idGenerator, string responseId, string conversationId) { }
        public string ConversationId { get { throw null; } }
        public static Azure.AI.AgentServer.Responses.Invocation.AgentInvocationContext? Current { get { throw null; } }
        public Azure.AI.AgentServer.Core.Common.Id.IIdGenerator IdGenerator { get { throw null; } }
        public string ResponseId { get { throw null; } }
    }
    public partial class AgentInvocationException : System.Exception
    {
        public AgentInvocationException(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseError error) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseError Error { get { throw null; } }
    }
    public partial interface IAgentInvocation
    {
        System.Threading.Tasks.Task<Azure.AI.AgentServer.Contracts.Generated.Responses.Response> InvokeAsync(Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest request, Azure.AI.AgentServer.Responses.Invocation.AgentInvocationContext context, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        System.Collections.Generic.IAsyncEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent> InvokeStreamAsync(Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest request, Azure.AI.AgentServer.Responses.Invocation.AgentInvocationContext context, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }
    public static partial class ResponsesExtensions
    {
        public static string? GetConversationId(this Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest request) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.Agents.AgentId? ToAgentId(this Azure.AI.AgentServer.Contracts.Generated.Agents.AgentReference? agent) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.Responses.Response ToResponse(this Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest request, Azure.AI.AgentServer.Responses.Invocation.AgentInvocationContext? context = null, System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource>? output = null, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStatus status = Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStatus.Completed, System.DateTimeOffset? createdAt = default(System.DateTimeOffset?), Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsage? usage = null) { throw null; }
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
        public Azure.AI.AgentServer.Responses.Invocation.AgentInvocationContext Context { get { throw null; } set { } }
        [System.Runtime.CompilerServices.RequiredMemberAttribute]
        public Azure.AI.AgentServer.Responses.Invocation.Stream.INestedStreamEventGenerator<System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource>> OutputGenerator { get { throw null; } set { } }
        [System.Runtime.CompilerServices.RequiredMemberAttribute]
        public Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest Request { get { throw null; } set { } }
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
