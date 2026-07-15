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
namespace Azure.AI.AgentServer.Core.Storage
{
    public partial class AzureAIAgentServerCoreStorageContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAIAgentServerCoreStorageContext() { }
        public static Azure.AI.AgentServer.Core.Storage.AzureAIAgentServerCoreStorageContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class AzureAIAgentServerCoreStorageModelFactory
    {
        public static Azure.AI.AgentServer.Core.Storage.DeletedStateStore DeletedStateStore(string id = null, string name = null, bool deleted = false) { throw null; }
        public static Azure.AI.AgentServer.Core.Storage.DeletedStateStoreItem DeletedStateStoreItem(string id = null, string key = null, bool deleted = false) { throw null; }
        public static Azure.AI.AgentServer.Core.Storage.StateStore StateStore(string id = null, string name = null, bool userIsolation = false, int itemTtlSeconds = 0, string description = null, System.Collections.Generic.IDictionary<string, string> tags = null, long createdAt = (long)0, long updatedAt = (long)0) { throw null; }
        public static Azure.AI.AgentServer.Core.Storage.StateStoreItem StateStoreItem(string id = null, string key = null, System.Collections.Generic.IDictionary<string, System.BinaryData> value = null, System.Collections.Generic.IDictionary<string, string> tags = null, string etag = null, long createdAt = (long)0, long updatedAt = (long)0) { throw null; }
        public static Azure.AI.AgentServer.Core.Storage.StateStoreItemKey StateStoreItemKey(string id = null, string key = null, System.Collections.Generic.IDictionary<string, string> tags = null, string etag = null, long createdAt = (long)0, long updatedAt = (long)0) { throw null; }
        public static Azure.AI.AgentServer.Core.Storage.StateStoreItemRef StateStoreItemRef(string id = null, string key = null, string etag = null, long createdAt = (long)0, long updatedAt = (long)0) { throw null; }
    }
    public partial class DeletedStateStore : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Core.Storage.DeletedStateStore>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Core.Storage.DeletedStateStore>
    {
        internal DeletedStateStore() { }
        public bool Deleted { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Object { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Core.Storage.DeletedStateStore JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.AgentServer.Core.Storage.DeletedStateStore (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.AgentServer.Core.Storage.DeletedStateStore PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Core.Storage.DeletedStateStore System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Core.Storage.DeletedStateStore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Core.Storage.DeletedStateStore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Core.Storage.DeletedStateStore System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Core.Storage.DeletedStateStore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Core.Storage.DeletedStateStore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Core.Storage.DeletedStateStore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeletedStateStoreItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Core.Storage.DeletedStateStoreItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Core.Storage.DeletedStateStoreItem>
    {
        internal DeletedStateStoreItem() { }
        public bool Deleted { get { throw null; } }
        public string Id { get { throw null; } }
        public string Key { get { throw null; } }
        public string Object { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Core.Storage.DeletedStateStoreItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.AgentServer.Core.Storage.DeletedStateStoreItem (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.AgentServer.Core.Storage.DeletedStateStoreItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Core.Storage.DeletedStateStoreItem System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Core.Storage.DeletedStateStoreItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Core.Storage.DeletedStateStoreItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Core.Storage.DeletedStateStoreItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Core.Storage.DeletedStateStoreItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Core.Storage.DeletedStateStoreItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Core.Storage.DeletedStateStoreItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FoundryStateStore
    {
        public const int DefaultItemTtlSeconds = 2592000;
        protected FoundryStateStore() { }
        public virtual string Name { get { throw null; } }
        public virtual System.Threading.Tasks.Task<Azure.AI.AgentServer.Core.Storage.StateStoreItemRef> CreateItemAsync(string key, System.Collections.Generic.IDictionary<string, System.BinaryData> value, System.Collections.Generic.IReadOnlyDictionary<string, string>? tags = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.AgentServer.Core.Storage.DeletedStateStore> DeleteAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.AgentServer.Core.Storage.DeletedStateStoreItem> DeleteItemAsync(string key, string? ifMatch = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.AgentServer.Core.Storage.StateStore?> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.AgentServer.Core.Storage.StateStoreItem?> GetItemAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.AI.AgentServer.Core.Storage.FoundryStateStore> GetOrCreateAsync(string name, Azure.Core.TokenCredential credential, System.Uri? endpoint = null, bool userIsolation = false, int itemTtlSeconds = 2592000, string? description = null, System.Collections.Generic.IReadOnlyDictionary<string, string>? tags = null, string? userId = null, string apiVersion = "v1", System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.AgentServer.Core.Storage.StateStoreItemKeyPage> ListKeysAsync(System.Collections.Generic.IReadOnlyDictionary<string, string>? tags = null, int? limit = default(int?), string? after = null, string? before = null, Azure.AI.AgentServer.Core.Storage.ListRequestOrder order = Azure.AI.AgentServer.Core.Storage.ListRequestOrder.Desc, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.AgentServer.Core.Storage.StateStoreItemRef> SetItemAsync(string key, System.Collections.Generic.IDictionary<string, System.BinaryData> value, System.Collections.Generic.IReadOnlyDictionary<string, string>? tags = null, string? ifMatch = null, bool requireExists = false, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.AI.AgentServer.Core.Storage.StateStore> UpdateAsync(Azure.AI.AgentServer.Core.Storage.StateStoreUpdateOptions update, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FoundryStorageApiException : Azure.AI.AgentServer.Core.Storage.FoundryStorageException
    {
        public FoundryStorageApiException(int status, string message, string? errorCode = null) : base (default(int), default(string), default(string), default(System.Exception)) { }
    }
    public partial class FoundryStorageBadRequestException : Azure.AI.AgentServer.Core.Storage.FoundryStorageException
    {
        public FoundryStorageBadRequestException(string message, string? param = null, int status = 400, string? errorCode = null) : base (default(int), default(string), default(string), default(System.Exception)) { }
        public string? Param { get { throw null; } }
    }
    public partial class FoundryStorageConflictException : Azure.AI.AgentServer.Core.Storage.FoundryStorageBadRequestException
    {
        public FoundryStorageConflictException(string message, string? param = null, string? errorCode = null) : base (default(string), default(string), default(int), default(string)) { }
    }
    public partial class FoundryStorageException : Azure.RequestFailedException
    {
        public FoundryStorageException(int status, string message, string? errorCode = null, System.Exception? innerException = null) : base (default(string)) { }
    }
    public partial class FoundryStorageNotFoundException : Azure.AI.AgentServer.Core.Storage.FoundryStorageException
    {
        public FoundryStorageNotFoundException(string message, string? errorCode = null) : base (default(int), default(string), default(string), default(System.Exception)) { }
    }
    public partial class FoundryStoragePreconditionException : Azure.AI.AgentServer.Core.Storage.FoundryStorageException
    {
        public FoundryStoragePreconditionException(string message, string? currentETag = null, string? errorCode = null) : base (default(int), default(string), default(string), default(System.Exception)) { }
        public string? CurrentETag { get { throw null; } }
    }
    public enum ListRequestOrder
    {
        Asc = 0,
        Desc = 1,
    }
    public partial class StateStore : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Core.Storage.StateStore>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Core.Storage.StateStore>
    {
        internal StateStore() { }
        public long CreatedAt { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public int ItemTtlSeconds { get { throw null; } }
        public string Name { get { throw null; } }
        public string Object { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public long UpdatedAt { get { throw null; } }
        public bool UserIsolation { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Core.Storage.StateStore JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.AgentServer.Core.Storage.StateStore (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.AgentServer.Core.Storage.StateStore PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Core.Storage.StateStore System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Core.Storage.StateStore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Core.Storage.StateStore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Core.Storage.StateStore System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Core.Storage.StateStore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Core.Storage.StateStore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Core.Storage.StateStore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StateStoreItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Core.Storage.StateStoreItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Core.Storage.StateStoreItem>
    {
        internal StateStoreItem() { }
        public long CreatedAt { get { throw null; } }
        public string Etag { get { throw null; } }
        public string Id { get { throw null; } }
        public string Key { get { throw null; } }
        public string Object { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public long UpdatedAt { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Value { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Core.Storage.StateStoreItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.AgentServer.Core.Storage.StateStoreItem (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.AgentServer.Core.Storage.StateStoreItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Core.Storage.StateStoreItem System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Core.Storage.StateStoreItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Core.Storage.StateStoreItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Core.Storage.StateStoreItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Core.Storage.StateStoreItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Core.Storage.StateStoreItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Core.Storage.StateStoreItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StateStoreItemKey : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Core.Storage.StateStoreItemKey>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Core.Storage.StateStoreItemKey>
    {
        internal StateStoreItemKey() { }
        public long CreatedAt { get { throw null; } }
        public string Etag { get { throw null; } }
        public string Id { get { throw null; } }
        public string Key { get { throw null; } }
        public string Object { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public long UpdatedAt { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Core.Storage.StateStoreItemKey JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.AgentServer.Core.Storage.StateStoreItemKey PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Core.Storage.StateStoreItemKey System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Core.Storage.StateStoreItemKey>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Core.Storage.StateStoreItemKey>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Core.Storage.StateStoreItemKey System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Core.Storage.StateStoreItemKey>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Core.Storage.StateStoreItemKey>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Core.Storage.StateStoreItemKey>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public sealed partial class StateStoreItemKeyPage
    {
        internal StateStoreItemKeyPage() { }
        public string? FirstId { get { throw null; } }
        public bool HasMore { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Core.Storage.StateStoreItemKey> Keys { get { throw null; } }
        public string? LastId { get { throw null; } }
    }
    public partial class StateStoreItemRef : System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Core.Storage.StateStoreItemRef>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Core.Storage.StateStoreItemRef>
    {
        internal StateStoreItemRef() { }
        public long CreatedAt { get { throw null; } }
        public string Etag { get { throw null; } }
        public string Id { get { throw null; } }
        public string Key { get { throw null; } }
        public string Object { get { throw null; } }
        public long UpdatedAt { get { throw null; } }
        protected virtual Azure.AI.AgentServer.Core.Storage.StateStoreItemRef JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.AgentServer.Core.Storage.StateStoreItemRef (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.AgentServer.Core.Storage.StateStoreItemRef PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.AgentServer.Core.Storage.StateStoreItemRef System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Core.Storage.StateStoreItemRef>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Core.Storage.StateStoreItemRef>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Core.Storage.StateStoreItemRef System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Core.Storage.StateStoreItemRef>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Core.Storage.StateStoreItemRef>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Core.Storage.StateStoreItemRef>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public sealed partial class StateStoreUpdateOptions
    {
        public StateStoreUpdateOptions() { }
        public string? Description { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string>? Tags { get { throw null; } set { } }
    }
}
