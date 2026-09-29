namespace Azure.AI.Discovery
{
    public partial class AzureAIDiscoveryContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAIDiscoveryContext() { }
        public static Azure.AI.Discovery.AzureAIDiscoveryContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class BookshelfClient
    {
        protected BookshelfClient() { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
        public BookshelfClient(Azure.AI.Discovery.BookshelfClientSettings settings) { }
        public BookshelfClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public BookshelfClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Discovery.BookshelfClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.AI.Discovery.KnowledgeBases GetKnowledgeBasesClient() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public static partial class BookshelfClientHostExtensions
    {
        public static System.ClientModel.Primitives.IClientBuilder AddBookshelfClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddBookshelfClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName, System.Action<Azure.AI.Discovery.BookshelfClientSettings> configureSettings) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedBookshelfClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedBookshelfClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName, System.Action<Azure.AI.Discovery.BookshelfClientSettings> configureSettings) { throw null; }
    }
    public partial class BookshelfClientOptions : Azure.Core.ClientOptions
    {
        public BookshelfClientOptions(Azure.AI.Discovery.BookshelfClientOptions.ServiceVersion version = Azure.AI.Discovery.BookshelfClientOptions.ServiceVersion.V2026_06_01) { }
        public enum ServiceVersion
        {
            V2026_06_01 = 1,
        }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public partial class BookshelfClientSettings : System.ClientModel.Primitives.ClientSettings
    {
        public BookshelfClientSettings() { }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.AI.Discovery.BookshelfClientOptions Options { get { throw null; } set { } }
        protected override void BindCore(Microsoft.Extensions.Configuration.IConfigurationSection section) { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CitationType : System.IEquatable<Azure.AI.Discovery.CitationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CitationType(string value) { throw null; }
        public static Azure.AI.Discovery.CitationType FileCitation { get { throw null; } }
        public bool Equals(Azure.AI.Discovery.CitationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Discovery.CitationType left, Azure.AI.Discovery.CitationType right) { throw null; }
        public static implicit operator Azure.AI.Discovery.CitationType (string value) { throw null; }
        public static implicit operator Azure.AI.Discovery.CitationType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Discovery.CitationType left, Azure.AI.Discovery.CitationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputeUsage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.ComputeUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.ComputeUsage>
    {
        internal ComputeUsage() { }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Discovery.SupercomputerUsage> Supercomputers { get { throw null; } }
        protected virtual Azure.AI.Discovery.ComputeUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Discovery.ComputeUsage (Azure.Response response) { throw null; }
        protected virtual Azure.AI.Discovery.ComputeUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.ComputeUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.ComputeUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.ComputeUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.ComputeUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.ComputeUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.ComputeUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.ComputeUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiscoveryActorType : System.IEquatable<Azure.AI.Discovery.DiscoveryActorType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiscoveryActorType(string value) { throw null; }
        public static Azure.AI.Discovery.DiscoveryActorType Application { get { throw null; } }
        public static Azure.AI.Discovery.DiscoveryActorType System { get { throw null; } }
        public static Azure.AI.Discovery.DiscoveryActorType User { get { throw null; } }
        public bool Equals(Azure.AI.Discovery.DiscoveryActorType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Discovery.DiscoveryActorType left, Azure.AI.Discovery.DiscoveryActorType right) { throw null; }
        public static implicit operator Azure.AI.Discovery.DiscoveryActorType (string value) { throw null; }
        public static implicit operator Azure.AI.Discovery.DiscoveryActorType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Discovery.DiscoveryActorType left, Azure.AI.Discovery.DiscoveryActorType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiscoveryCitation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.DiscoveryCitation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.DiscoveryCitation>
    {
        internal DiscoveryCitation() { }
        public int? EndOffset { get { throw null; } }
        public string FileName { get { throw null; } }
        public int? Index { get { throw null; } }
        public int? StartOffset { get { throw null; } }
        public Azure.AI.Discovery.CitationType Type { get { throw null; } }
        protected virtual Azure.AI.Discovery.DiscoveryCitation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Discovery.DiscoveryCitation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.DiscoveryCitation System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.DiscoveryCitation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.DiscoveryCitation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.DiscoveryCitation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.DiscoveryCitation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.DiscoveryCitation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.DiscoveryCitation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryConversation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.DiscoveryConversation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.DiscoveryConversation>
    {
        public DiscoveryConversation() { }
        public string CreatedBy { get { throw null; } set { } }
        public Azure.AI.Discovery.DiscoveryActorType? CreatedByType { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string InvestigationName { get { throw null; } set { } }
        public string LastModifiedBy { get { throw null; } set { } }
        public Azure.AI.Discovery.DiscoveryActorType? LastModifiedByType { get { throw null; } set { } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public string ProjectName { get { throw null; } set { } }
        protected virtual Azure.AI.Discovery.DiscoveryConversation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Discovery.DiscoveryConversation (Azure.Response response) { throw null; }
        protected virtual Azure.AI.Discovery.DiscoveryConversation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.DiscoveryConversation System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.DiscoveryConversation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.DiscoveryConversation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.DiscoveryConversation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.DiscoveryConversation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.DiscoveryConversation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.DiscoveryConversation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryConversationsClient
    {
        protected DiscoveryConversationsClient() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response Create(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Discovery.DiscoveryConversation> Create(string projectName, string investigationName = null, string displayName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Discovery.DiscoveryConversation>> CreateAsync(string projectName, string investigationName = null, string displayName = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Delete(string conversationName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response Delete(string conversationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string conversationName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string conversationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Get(string conversationName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Discovery.DiscoveryConversation> Get(string conversationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetAll(string investigationName, string projectName, System.DateTimeOffset? createdSince, int? top, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Discovery.PagedConversation> GetAll(string investigationName = null, string projectName = null, System.DateTimeOffset? createdSince = default(System.DateTimeOffset?), int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAllAsync(string investigationName, string projectName, System.DateTimeOffset? createdSince, int? top, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Discovery.PagedConversation>> GetAllAsync(string investigationName = null, string projectName = null, System.DateTimeOffset? createdSince = default(System.DateTimeOffset?), int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAsync(string conversationName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Discovery.DiscoveryConversation>> GetAsync(string conversationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StableUpdate(string conversationName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StableUpdateAsync(string conversationName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class DiscoveryEngine : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.DiscoveryEngine>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.DiscoveryEngine>
    {
        internal DiscoveryEngine() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Configuration { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public Azure.AI.Discovery.DiscoveryActorType? CreatedByType { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.AI.Discovery.DiscoveryEngineStatus DiscoveryEngineStatus { get { throw null; } }
        public string LastModifiedBy { get { throw null; } }
        public Azure.AI.Discovery.DiscoveryActorType? LastModifiedByType { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string SystemPrompt { get { throw null; } }
        protected virtual Azure.AI.Discovery.DiscoveryEngine JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Discovery.DiscoveryEngine (Azure.Response response) { throw null; }
        protected virtual Azure.AI.Discovery.DiscoveryEngine PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.DiscoveryEngine System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.DiscoveryEngine>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.DiscoveryEngine>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.DiscoveryEngine System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.DiscoveryEngine>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.DiscoveryEngine>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.DiscoveryEngine>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiscoveryEngineStatus : System.IEquatable<Azure.AI.Discovery.DiscoveryEngineStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiscoveryEngineStatus(string value) { throw null; }
        public static Azure.AI.Discovery.DiscoveryEngineStatus Active { get { throw null; } }
        public static Azure.AI.Discovery.DiscoveryEngineStatus Inactive { get { throw null; } }
        public bool Equals(Azure.AI.Discovery.DiscoveryEngineStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Discovery.DiscoveryEngineStatus left, Azure.AI.Discovery.DiscoveryEngineStatus right) { throw null; }
        public static implicit operator Azure.AI.Discovery.DiscoveryEngineStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Discovery.DiscoveryEngineStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Discovery.DiscoveryEngineStatus left, Azure.AI.Discovery.DiscoveryEngineStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiscoveryInvestigation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.DiscoveryInvestigation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.DiscoveryInvestigation>
    {
        public DiscoveryInvestigation() { }
        public string CreatedBy { get { throw null; } }
        public Azure.AI.Discovery.DiscoveryActorType? CreatedByType { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public string LastModifiedBy { get { throw null; } }
        public Azure.AI.Discovery.DiscoveryActorType? LastModifiedByType { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string Name { get { throw null; } }
        public string ProjectName { get { throw null; } }
        public Azure.AI.Discovery.InvestigationStatus? Status { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Discovery.DiscoveryTag> Tags { get { throw null; } }
        protected virtual Azure.AI.Discovery.DiscoveryInvestigation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Discovery.DiscoveryInvestigation (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.Discovery.DiscoveryInvestigation discoveryInvestigation) { throw null; }
        protected virtual Azure.AI.Discovery.DiscoveryInvestigation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.DiscoveryInvestigation System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.DiscoveryInvestigation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.DiscoveryInvestigation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.DiscoveryInvestigation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.DiscoveryInvestigation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.DiscoveryInvestigation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.DiscoveryInvestigation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryInvestigationsClient
    {
        protected DiscoveryInvestigationsClient() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Discovery.DiscoveryInvestigation> CreateOrReplace(string projectName, string investigationName, Azure.AI.Discovery.DiscoveryInvestigation resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateOrReplace(string projectName, string investigationName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Discovery.DiscoveryInvestigation>> CreateOrReplaceAsync(string projectName, string investigationName, Azure.AI.Discovery.DiscoveryInvestigation resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrReplaceAsync(string projectName, string investigationName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<System.BinaryData> Delete(Azure.WaitUntil waitUntil, string projectName, string investigationName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation<Azure.AI.Discovery.DiscoveryInvestigation> Delete(Azure.WaitUntil waitUntil, string projectName, string investigationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> DeleteAsync(Azure.WaitUntil waitUntil, string projectName, string investigationName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.Discovery.DiscoveryInvestigation>> DeleteAsync(Azure.WaitUntil waitUntil, string projectName, string investigationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Get(string projectName, string investigationName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Discovery.DiscoveryInvestigation> Get(string projectName, string investigationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetAll(string projectName, System.DateTimeOffset? createdSince, int? top, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Discovery.PagedInvestigation> GetAll(string projectName, System.DateTimeOffset? createdSince = default(System.DateTimeOffset?), int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAllAsync(string projectName, System.DateTimeOffset? createdSince, int? top, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Discovery.PagedInvestigation>> GetAllAsync(string projectName, System.DateTimeOffset? createdSince = default(System.DateTimeOffset?), int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAsync(string projectName, string investigationName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Discovery.DiscoveryInvestigation>> GetAsync(string projectName, string investigationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDiscoveryEngine(string projectName, string investigationName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Discovery.DiscoveryEngine> GetDiscoveryEngine(string projectName, string investigationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDiscoveryEngineAsync(string projectName, string investigationName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Discovery.DiscoveryEngine>> GetDiscoveryEngineAsync(string projectName, string investigationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetDiscoveryEngineMemory(string projectName, string investigationName, int? top, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Discovery.PagedWorkingMemoryEntry> GetDiscoveryEngineMemory(string projectName, string investigationName, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetDiscoveryEngineMemoryAsync(string projectName, string investigationName, int? top, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Discovery.PagedWorkingMemoryEntry>> GetDiscoveryEngineMemoryAsync(string projectName, string investigationName, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetOperationStatus(string projectName, string investigationName, string operationId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Discovery.InvestigationOperationStatus> GetOperationStatus(string projectName, string investigationName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetOperationStatusAsync(string projectName, string investigationName, string operationId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Discovery.InvestigationOperationStatus>> GetOperationStatusAsync(string projectName, string investigationName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StartDiscoveryEngine(string projectName, string investigationName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Discovery.DiscoveryEngine> StartDiscoveryEngine(string projectName, string investigationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StartDiscoveryEngineAsync(string projectName, string investigationName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Discovery.DiscoveryEngine>> StartDiscoveryEngineAsync(string projectName, string investigationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StopDiscoveryEngine(string projectName, string investigationName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Discovery.DiscoveryEngine> StopDiscoveryEngine(string projectName, string investigationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StopDiscoveryEngineAsync(string projectName, string investigationName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Discovery.DiscoveryEngine>> StopDiscoveryEngineAsync(string projectName, string investigationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Update(string projectName, string investigationName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(string projectName, string investigationName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UpdateDiscoveryEngine(string projectName, string investigationName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateDiscoveryEngineAsync(string projectName, string investigationName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public static partial class DiscoveryModelFactory
    {
        public static Azure.AI.Discovery.ComputeUsage ComputeUsage(System.Collections.Generic.IDictionary<string, Azure.AI.Discovery.SupercomputerUsage> supercomputers = null) { throw null; }
        public static Azure.AI.Discovery.DiscoveryCitation DiscoveryCitation(Azure.AI.Discovery.CitationType type = default(Azure.AI.Discovery.CitationType), int? index = default(int?), string fileName = null, int? startOffset = default(int?), int? endOffset = default(int?)) { throw null; }
        public static Azure.AI.Discovery.DiscoveryConversation DiscoveryConversation(string name = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string createdBy = null, Azure.AI.Discovery.DiscoveryActorType? createdByType = default(Azure.AI.Discovery.DiscoveryActorType?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string lastModifiedBy = null, Azure.AI.Discovery.DiscoveryActorType? lastModifiedByType = default(Azure.AI.Discovery.DiscoveryActorType?), string displayName = null, string investigationName = null, string projectName = null) { throw null; }
        public static Azure.AI.Discovery.DiscoveryEngine DiscoveryEngine(Azure.AI.Discovery.DiscoveryEngineStatus discoveryEngineStatus = default(Azure.AI.Discovery.DiscoveryEngineStatus), string systemPrompt = null, System.Collections.Generic.IDictionary<string, System.BinaryData> configuration = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string createdBy = null, Azure.AI.Discovery.DiscoveryActorType? createdByType = default(Azure.AI.Discovery.DiscoveryActorType?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string lastModifiedBy = null, Azure.AI.Discovery.DiscoveryActorType? lastModifiedByType = default(Azure.AI.Discovery.DiscoveryActorType?)) { throw null; }
        public static Azure.AI.Discovery.DiscoveryInvestigation DiscoveryInvestigation(string name = null, string projectName = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string createdBy = null, Azure.AI.Discovery.DiscoveryActorType? createdByType = default(Azure.AI.Discovery.DiscoveryActorType?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string lastModifiedBy = null, Azure.AI.Discovery.DiscoveryActorType? lastModifiedByType = default(Azure.AI.Discovery.DiscoveryActorType?), Azure.AI.Discovery.InvestigationStatus? status = default(Azure.AI.Discovery.InvestigationStatus?), string description = null, System.Collections.Generic.IEnumerable<Azure.AI.Discovery.DiscoveryTag> tags = null, string displayName = null) { throw null; }
        public static Azure.AI.Discovery.DiscoveryTag DiscoveryTag(string key = null, string value = null) { throw null; }
        public static Azure.AI.Discovery.DiscoveryTask DiscoveryTask(string name = null, string title = null, Azure.AI.Discovery.TaskPriority? priority = default(Azure.AI.Discovery.TaskPriority?), string description = null, System.Collections.Generic.IEnumerable<string> validationRequirements = null, string parentId = null, System.Collections.Generic.IEnumerable<string> dependsOn = null, System.Collections.Generic.IEnumerable<string> relatedTo = null, Azure.AI.Discovery.TaskAssignee assignedTo = null, System.Collections.Generic.IEnumerable<Azure.AI.Discovery.TaskComment> comments = null, Azure.AI.Discovery.TaskStatus? status = default(Azure.AI.Discovery.TaskStatus?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string createdBy = null, Azure.AI.Discovery.DiscoveryActorType? createdByType = default(Azure.AI.Discovery.DiscoveryActorType?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string lastModifiedBy = null, Azure.AI.Discovery.DiscoveryActorType? lastModifiedByType = default(Azure.AI.Discovery.DiscoveryActorType?), System.Collections.Generic.IEnumerable<Azure.AI.Discovery.ExecutionHistoryEntry> executionHistory = null, string investigationId = null, Azure.AI.Discovery.TaskResult taskResult = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> storageAssetIds = null) { throw null; }
        public static Azure.AI.Discovery.ExecutionHistoryEntry ExecutionHistoryEntry(System.DateTimeOffset createdOn = default(System.DateTimeOffset), string action = null, string createdBy = null, Azure.AI.Discovery.DiscoveryActorType createdByType = default(Azure.AI.Discovery.DiscoveryActorType), string summary = null, string responseMessageText = null, string responseMessageId = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalDetails = null) { throw null; }
        public static Azure.AI.Discovery.IndexingMetrics IndexingMetrics(int documentsProcessed = 0, int documentsFailed = 0, int documentsTotal = 0, int indexingPercentageComplete = 0, System.DateTimeOffset? enrichmentStartTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? enrichmentEndTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? indexingStartTimeUtc = default(System.DateTimeOffset?), System.DateTimeOffset? indexingEndTimeUtc = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Discovery.IndexingOperationResult IndexingOperationResult(string runId = null, Azure.AI.Discovery.IndexingMetrics metrics = null) { throw null; }
        public static Azure.AI.Discovery.InfrastructureOverrides InfrastructureOverrides(string cpu = null, string ram = null, string gpu = null, int? replicaCount = default(int?), string imageUri = null, string maxCpu = null, string maxRam = null, string maxGpu = null) { throw null; }
        public static Azure.AI.Discovery.InlineFile InlineFile(string mountPath = null, string encodedFile = null) { throw null; }
        public static Azure.AI.Discovery.InputDataMount InputDataMount(string storageUri = null, string mountPath = null, Azure.AI.Discovery.StorageMountProtocol? mountProtocol = default(Azure.AI.Discovery.StorageMountProtocol?)) { throw null; }
        public static Azure.AI.Discovery.InvestigationOperationStatus InvestigationOperationStatus(string id = null, Azure.AI.Discovery.OperationState status = default(Azure.AI.Discovery.OperationState), Azure.ResponseError error = null, Azure.AI.Discovery.DiscoveryInvestigation result = null) { throw null; }
        public static Azure.AI.Discovery.KnowledgeBase KnowledgeBase(string name = null, string id = null, string bookshelfName = null, System.Collections.Generic.IEnumerable<Azure.AI.Discovery.StorageAssetReference> storageAssetReferences = null, string knowledgeBaseUrl = null, Azure.AI.Discovery.DiscoveryProvisioningState? provisioningState = default(Azure.AI.Discovery.DiscoveryProvisioningState?), Azure.ResponseError error = null, Azure.AI.Discovery.IndexingStatus? status = default(Azure.AI.Discovery.IndexingStatus?), string createdByApiVersion = null, Azure.AI.Discovery.LastIndexingRun lastIndexingRun = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string createdBy = null, Azure.AI.Discovery.DiscoveryActorType? createdByType = default(Azure.AI.Discovery.DiscoveryActorType?), System.DateTimeOffset? lastModifiedOn = default(System.DateTimeOffset?), string lastModifiedBy = null, Azure.AI.Discovery.DiscoveryActorType? lastModifiedByType = default(Azure.AI.Discovery.DiscoveryActorType?), System.Collections.Generic.IEnumerable<Azure.AI.Discovery.DiscoveryTag> tags = null, string description = null, string copilotInstruction = null) { throw null; }
        public static Azure.AI.Discovery.KnowledgeBaseIndexingOperationResponse KnowledgeBaseIndexingOperationResponse(string id = null, Azure.AI.Discovery.OperationState status = default(Azure.AI.Discovery.OperationState), Azure.ResponseError error = null, Azure.AI.Discovery.IndexingOperationResult indexingResult = null) { throw null; }
        public static Azure.AI.Discovery.KnowledgeBaseOperationResponse KnowledgeBaseOperationResponse(string id = null, Azure.AI.Discovery.OperationState status = default(Azure.AI.Discovery.OperationState), Azure.ResponseError error = null, string operationType = null) { throw null; }
        public static Azure.AI.Discovery.KnowledgeBaseSearchOperationResponse KnowledgeBaseSearchOperationResponse(string id = null, Azure.AI.Discovery.OperationState status = default(Azure.AI.Discovery.OperationState), Azure.ResponseError error = null, Azure.AI.Discovery.SearchResponse searchResult = null) { throw null; }
        public static Azure.AI.Discovery.LastIndexingRun LastIndexingRun(string runId = null, Azure.AI.Discovery.IndexingStatus? status = default(Azure.AI.Discovery.IndexingStatus?), Azure.ResponseError error = null, Azure.AI.Discovery.IndexingMetrics indexingMetrics = null) { throw null; }
        public static Azure.AI.Discovery.NodePoolUsage NodePoolUsage(string reservedCPUs = null, string allocatableCPUs = null, string reservedMemory = null, string allocatableMemory = null, string reservedGPUs = null, string allocatableGPUs = null) { throw null; }
        public static Azure.AI.Discovery.OutputDataMount OutputDataMount(string storageUri = null, string mountPath = null, Azure.AI.Discovery.StorageMountProtocol? mountProtocol = default(Azure.AI.Discovery.StorageMountProtocol?)) { throw null; }
        public static Azure.AI.Discovery.OutputDataUri OutputDataUri(string storageUri = null, string mountPath = null) { throw null; }
        public static Azure.AI.Discovery.PagedConversation PagedConversation(System.Collections.Generic.IEnumerable<Azure.AI.Discovery.DiscoveryConversation> value = null, System.Uri nextLink = null) { throw null; }
        public static Azure.AI.Discovery.PagedInvestigation PagedInvestigation(System.Collections.Generic.IEnumerable<Azure.AI.Discovery.DiscoveryInvestigation> value = null, System.Uri nextLink = null) { throw null; }
        public static Azure.AI.Discovery.PagedOperation PagedOperation(System.Collections.Generic.IEnumerable<Azure.AI.Discovery.WorkspaceOperation> value = null, System.Uri nextLink = null) { throw null; }
        public static Azure.AI.Discovery.PagedWorkingMemoryEntry PagedWorkingMemoryEntry(System.Collections.Generic.IEnumerable<Azure.AI.Discovery.WorkingMemoryEntry> value = null, System.Uri nextLink = null) { throw null; }
        public static Azure.AI.Discovery.RunOperationStatus RunOperationStatus(string id = null, Azure.AI.Discovery.OperationState status = default(Azure.AI.Discovery.OperationState), Azure.ResponseError error = null, Azure.AI.Discovery.RunResult result = null) { throw null; }
        public static Azure.AI.Discovery.RunRequestEnvironmentVariable RunRequestEnvironmentVariable(string name = null, string value = null) { throw null; }
        public static Azure.AI.Discovery.RunResult RunResult(string status = null, string runtimeDetails = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), string createdBy = null, Azure.AI.Discovery.RunResultToolReport toolReport = null, System.Collections.Generic.IEnumerable<Azure.AI.Discovery.OutputDataUri> outputData = null, string debugInfo = null) { throw null; }
        public static Azure.AI.Discovery.RunResultToolReport RunResultToolReport(int percentageComplete = 0, Azure.AI.Discovery.RunResultToolReportStatusInformation statusInformation = null, string logs = null) { throw null; }
        public static Azure.AI.Discovery.RunResultToolReportStatusInformation RunResultToolReportStatusInformation() { throw null; }
        public static Azure.AI.Discovery.SearchRequest SearchRequest(string query = null) { throw null; }
        public static Azure.AI.Discovery.SearchResponse SearchResponse(System.Collections.Generic.IEnumerable<Azure.AI.Discovery.SearchResultItem> searchResults = null) { throw null; }
        public static Azure.AI.Discovery.SearchResultItem SearchResultItem(string text = null, System.Collections.Generic.IEnumerable<Azure.AI.Discovery.DiscoveryCitation> citations = null) { throw null; }
        public static Azure.AI.Discovery.StartTaskRequest StartTaskRequest(Azure.AI.Discovery.TaskAssignee assignee = null) { throw null; }
        public static Azure.AI.Discovery.StorageAssetReference StorageAssetReference(Azure.Core.ResourceIdentifier id = null, Azure.Core.ResourceIdentifier userAssignedIdentity = null) { throw null; }
        public static Azure.AI.Discovery.SupercomputerUsage SupercomputerUsage(long activeJobs = (long)0, long pendingJobs = (long)0, System.Collections.Generic.IDictionary<string, Azure.AI.Discovery.NodePoolUsage> nodePools = null) { throw null; }
        public static Azure.AI.Discovery.TaskAssignee TaskAssignee(string id = null, Azure.AI.Discovery.DiscoveryActorType type = default(Azure.AI.Discovery.DiscoveryActorType)) { throw null; }
        public static Azure.AI.Discovery.TaskComment TaskComment(System.DateTimeOffset? timestamp = default(System.DateTimeOffset?), string createdBy = null, Azure.AI.Discovery.DiscoveryActorType createdByType = default(Azure.AI.Discovery.DiscoveryActorType), string text = null) { throw null; }
        public static Azure.AI.Discovery.TaskResult TaskResult(string text = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> storageAssetIds = null) { throw null; }
        public static Azure.AI.Discovery.WorkingMemoryEntry WorkingMemoryEntry(string content = null, Azure.AI.Discovery.WorkingMemoryEntryType type = default(Azure.AI.Discovery.WorkingMemoryEntryType), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Discovery.WorkspaceOperation WorkspaceOperation(string id = null, string nodepoolId = null, Azure.AI.Discovery.RunStatus status = default(Azure.AI.Discovery.RunStatus), string runtimeDetails = null, System.DateTimeOffset createdOn = default(System.DateTimeOffset), System.DateTimeOffset? completedOn = default(System.DateTimeOffset?), string createdBy = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiscoveryProvisioningState : System.IEquatable<Azure.AI.Discovery.DiscoveryProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiscoveryProvisioningState(string value) { throw null; }
        public static Azure.AI.Discovery.DiscoveryProvisioningState Accepted { get { throw null; } }
        public static Azure.AI.Discovery.DiscoveryProvisioningState Canceled { get { throw null; } }
        public static Azure.AI.Discovery.DiscoveryProvisioningState Deleting { get { throw null; } }
        public static Azure.AI.Discovery.DiscoveryProvisioningState Failed { get { throw null; } }
        public static Azure.AI.Discovery.DiscoveryProvisioningState Provisioning { get { throw null; } }
        public static Azure.AI.Discovery.DiscoveryProvisioningState Succeeded { get { throw null; } }
        public static Azure.AI.Discovery.DiscoveryProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.AI.Discovery.DiscoveryProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Discovery.DiscoveryProvisioningState left, Azure.AI.Discovery.DiscoveryProvisioningState right) { throw null; }
        public static implicit operator Azure.AI.Discovery.DiscoveryProvisioningState (string value) { throw null; }
        public static implicit operator Azure.AI.Discovery.DiscoveryProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Discovery.DiscoveryProvisioningState left, Azure.AI.Discovery.DiscoveryProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiscoveryTag : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.DiscoveryTag>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.DiscoveryTag>
    {
        public DiscoveryTag() { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.AI.Discovery.DiscoveryTag JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Discovery.DiscoveryTag PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.DiscoveryTag System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.DiscoveryTag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.DiscoveryTag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.DiscoveryTag System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.DiscoveryTag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.DiscoveryTag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.DiscoveryTag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryTask : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.DiscoveryTask>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.DiscoveryTask>
    {
        public DiscoveryTask() { }
        public Azure.AI.Discovery.TaskAssignee AssignedTo { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Discovery.TaskComment> Comments { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public Azure.AI.Discovery.DiscoveryActorType? CreatedByType { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Collections.Generic.IList<string> DependsOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Discovery.ExecutionHistoryEntry> ExecutionHistory { get { throw null; } }
        public string InvestigationId { get { throw null; } set { } }
        public string LastModifiedBy { get { throw null; } }
        public Azure.AI.Discovery.DiscoveryActorType? LastModifiedByType { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string Name { get { throw null; } }
        public string ParentId { get { throw null; } set { } }
        public Azure.AI.Discovery.TaskPriority? Priority { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> RelatedTo { get { throw null; } }
        public Azure.AI.Discovery.TaskStatus? Status { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> StorageAssetIds { get { throw null; } }
        public Azure.AI.Discovery.TaskResult TaskResult { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ValidationRequirements { get { throw null; } }
        protected virtual Azure.AI.Discovery.DiscoveryTask JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Discovery.DiscoveryTask (Azure.Response response) { throw null; }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.Discovery.DiscoveryTask discoveryTask) { throw null; }
        protected virtual Azure.AI.Discovery.DiscoveryTask PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.DiscoveryTask System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.DiscoveryTask>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.DiscoveryTask>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.DiscoveryTask System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.DiscoveryTask>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.DiscoveryTask>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.DiscoveryTask>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiscoveryTasksClient
    {
        protected DiscoveryTasksClient() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Discovery.DiscoveryTask> AddComment(string projectName, string investigationName, string taskName, Azure.AI.Discovery.TaskComment body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddComment(string projectName, string investigationName, string taskName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Discovery.DiscoveryTask>> AddCommentAsync(string projectName, string investigationName, string taskName, Azure.AI.Discovery.TaskComment body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddCommentAsync(string projectName, string investigationName, string taskName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Discovery.DiscoveryTask> AddExecutionHistory(string projectName, string investigationName, string taskName, Azure.AI.Discovery.ExecutionHistoryEntry body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddExecutionHistory(string projectName, string investigationName, string taskName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Discovery.DiscoveryTask>> AddExecutionHistoryAsync(string projectName, string investigationName, string taskName, Azure.AI.Discovery.ExecutionHistoryEntry body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddExecutionHistoryAsync(string projectName, string investigationName, string taskName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Discovery.DiscoveryTask> Create(string projectName, string investigationName, Azure.AI.Discovery.DiscoveryTask body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Create(string projectName, string investigationName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Discovery.DiscoveryTask>> CreateAsync(string projectName, string investigationName, Azure.AI.Discovery.DiscoveryTask body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAsync(string projectName, string investigationName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response Delete(string projectName, string investigationName, string taskName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response Delete(string projectName, string investigationName, string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string projectName, string investigationName, string taskName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteAsync(string projectName, string investigationName, string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Get(string projectName, string investigationName, string taskName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Discovery.DiscoveryTask> Get(string projectName, string investigationName, string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAll(string projectName, string investigationName, string filter, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Discovery.DiscoveryTask> GetAll(string projectName, string investigationName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAllAsync(string projectName, string investigationName, string filter, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Discovery.DiscoveryTask> GetAllAsync(string projectName, string investigationName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAsync(string projectName, string investigationName, string taskName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Discovery.DiscoveryTask>> GetAsync(string projectName, string investigationName, string taskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response StableUpdate(string projectName, string investigationName, string taskName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StableUpdateAsync(string projectName, string investigationName, string taskName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Discovery.DiscoveryTask> Start(string projectName, string investigationName, string taskName, Azure.AI.Discovery.StartTaskRequest body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Start(string projectName, string investigationName, string taskName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Discovery.DiscoveryTask>> StartAsync(string projectName, string investigationName, string taskName, Azure.AI.Discovery.StartTaskRequest body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> StartAsync(string projectName, string investigationName, string taskName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class DiscoveryToolsClient
    {
        protected DiscoveryToolsClient() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<System.BinaryData> CancelRunLro(Azure.WaitUntil waitUntil, string projectName, string operationId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation<Azure.AI.Discovery.RunResult> CancelRunLro(Azure.WaitUntil waitUntil, string projectName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CancelRunLroAsync(Azure.WaitUntil waitUntil, string projectName, string operationId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.Discovery.RunResult>> CancelRunLroAsync(Azure.WaitUntil waitUntil, string projectName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetComputeUsage(string projectName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Discovery.ComputeUsage> GetComputeUsage(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetComputeUsageAsync(string projectName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Discovery.ComputeUsage>> GetComputeUsageAsync(string projectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetOperations(string projectName, int? top, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Discovery.PagedOperation> GetOperations(string projectName, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetOperationsAsync(string projectName, int? top, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Discovery.PagedOperation>> GetOperationsAsync(string projectName, int? top = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetRunStatus(string projectName, string operationId, int? logCount, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Discovery.RunOperationStatus> GetRunStatus(string projectName, string operationId, int? logCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRunStatusAsync(string projectName, string operationId, int? logCount, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Discovery.RunOperationStatus>> GetRunStatusAsync(string projectName, string operationId, int? logCount = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> Run(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation<Azure.AI.Discovery.RunResult> Run(Azure.WaitUntil waitUntil, string projectName, Azure.Core.ResourceIdentifier toolId, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> nodePoolIds, string command = null, System.Collections.Generic.IEnumerable<Azure.AI.Discovery.InlineFile> inlineFiles = null, System.Collections.Generic.IEnumerable<Azure.AI.Discovery.InputDataMount> inputData = null, System.Collections.Generic.IEnumerable<Azure.AI.Discovery.OutputDataMount> outputData = null, Azure.AI.Discovery.InfrastructureOverrides infraOverrides = null, System.Collections.Generic.IEnumerable<Azure.AI.Discovery.RunRequestEnvironmentVariable> environmentVariables = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> RunAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.Discovery.RunResult>> RunAsync(Azure.WaitUntil waitUntil, string projectName, Azure.Core.ResourceIdentifier toolId, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> nodePoolIds, string command = null, System.Collections.Generic.IEnumerable<Azure.AI.Discovery.InlineFile> inlineFiles = null, System.Collections.Generic.IEnumerable<Azure.AI.Discovery.InputDataMount> inputData = null, System.Collections.Generic.IEnumerable<Azure.AI.Discovery.OutputDataMount> outputData = null, Azure.AI.Discovery.InfrastructureOverrides infraOverrides = null, System.Collections.Generic.IEnumerable<Azure.AI.Discovery.RunRequestEnvironmentVariable> environmentVariables = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ExecutionHistoryEntry : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.ExecutionHistoryEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.ExecutionHistoryEntry>
    {
        public ExecutionHistoryEntry(System.DateTimeOffset createdOn, string action, string createdBy, Azure.AI.Discovery.DiscoveryActorType createdByType) { }
        public string Action { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalDetails { get { throw null; } }
        public string CreatedBy { get { throw null; } set { } }
        public Azure.AI.Discovery.DiscoveryActorType CreatedByType { get { throw null; } set { } }
        public System.DateTimeOffset CreatedOn { get { throw null; } set { } }
        public string ResponseMessageId { get { throw null; } set { } }
        public string ResponseMessageText { get { throw null; } set { } }
        public string Summary { get { throw null; } set { } }
        protected virtual Azure.AI.Discovery.ExecutionHistoryEntry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.Discovery.ExecutionHistoryEntry executionHistoryEntry) { throw null; }
        protected virtual Azure.AI.Discovery.ExecutionHistoryEntry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.ExecutionHistoryEntry System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.ExecutionHistoryEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.ExecutionHistoryEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.ExecutionHistoryEntry System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.ExecutionHistoryEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.ExecutionHistoryEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.ExecutionHistoryEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IndexingMetrics : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.IndexingMetrics>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.IndexingMetrics>
    {
        internal IndexingMetrics() { }
        public int DocumentsFailed { get { throw null; } }
        public int DocumentsProcessed { get { throw null; } }
        public int DocumentsTotal { get { throw null; } }
        public System.DateTimeOffset? EnrichmentEndTimeUtc { get { throw null; } }
        public System.DateTimeOffset? EnrichmentStartTimeUtc { get { throw null; } }
        public System.DateTimeOffset? IndexingEndTimeUtc { get { throw null; } }
        public int IndexingPercentageComplete { get { throw null; } }
        public System.DateTimeOffset? IndexingStartTimeUtc { get { throw null; } }
        protected virtual Azure.AI.Discovery.IndexingMetrics JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Discovery.IndexingMetrics PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.IndexingMetrics System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.IndexingMetrics>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.IndexingMetrics>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.IndexingMetrics System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.IndexingMetrics>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.IndexingMetrics>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.IndexingMetrics>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IndexingOperationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.IndexingOperationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.IndexingOperationResult>
    {
        internal IndexingOperationResult() { }
        public Azure.AI.Discovery.IndexingMetrics Metrics { get { throw null; } }
        public string RunId { get { throw null; } }
        protected virtual Azure.AI.Discovery.IndexingOperationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Discovery.IndexingOperationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.IndexingOperationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.IndexingOperationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.IndexingOperationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.IndexingOperationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.IndexingOperationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.IndexingOperationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.IndexingOperationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IndexingStatus : System.IEquatable<Azure.AI.Discovery.IndexingStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IndexingStatus(string value) { throw null; }
        public static Azure.AI.Discovery.IndexingStatus Canceled { get { throw null; } }
        public static Azure.AI.Discovery.IndexingStatus Failed { get { throw null; } }
        public static Azure.AI.Discovery.IndexingStatus NotStarted { get { throw null; } }
        public static Azure.AI.Discovery.IndexingStatus Running { get { throw null; } }
        public static Azure.AI.Discovery.IndexingStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.AI.Discovery.IndexingStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Discovery.IndexingStatus left, Azure.AI.Discovery.IndexingStatus right) { throw null; }
        public static implicit operator Azure.AI.Discovery.IndexingStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Discovery.IndexingStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Discovery.IndexingStatus left, Azure.AI.Discovery.IndexingStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InfrastructureOverrides : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.InfrastructureOverrides>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.InfrastructureOverrides>
    {
        public InfrastructureOverrides() { }
        public string Cpu { get { throw null; } set { } }
        public string Gpu { get { throw null; } set { } }
        public string ImageUri { get { throw null; } set { } }
        public string MaxCpu { get { throw null; } set { } }
        public string MaxGpu { get { throw null; } set { } }
        public string MaxRam { get { throw null; } set { } }
        public string Ram { get { throw null; } set { } }
        public int? ReplicaCount { get { throw null; } set { } }
        protected virtual Azure.AI.Discovery.InfrastructureOverrides JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Discovery.InfrastructureOverrides PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.InfrastructureOverrides System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.InfrastructureOverrides>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.InfrastructureOverrides>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.InfrastructureOverrides System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.InfrastructureOverrides>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.InfrastructureOverrides>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.InfrastructureOverrides>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InlineFile : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.InlineFile>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.InlineFile>
    {
        public InlineFile(string mountPath, string encodedFile) { }
        public string EncodedFile { get { throw null; } }
        public string MountPath { get { throw null; } }
        protected virtual Azure.AI.Discovery.InlineFile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Discovery.InlineFile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.InlineFile System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.InlineFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.InlineFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.InlineFile System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.InlineFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.InlineFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.InlineFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InputDataMount : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.InputDataMount>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.InputDataMount>
    {
        public InputDataMount(string storageUri, string mountPath) { }
        public string MountPath { get { throw null; } }
        public Azure.AI.Discovery.StorageMountProtocol? MountProtocol { get { throw null; } set { } }
        public string StorageUri { get { throw null; } }
        protected virtual Azure.AI.Discovery.InputDataMount JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Discovery.InputDataMount PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.InputDataMount System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.InputDataMount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.InputDataMount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.InputDataMount System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.InputDataMount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.InputDataMount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.InputDataMount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InvestigationOperationStatus : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.InvestigationOperationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.InvestigationOperationStatus>
    {
        internal InvestigationOperationStatus() { }
        public Azure.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Discovery.DiscoveryInvestigation Result { get { throw null; } }
        public Azure.AI.Discovery.OperationState Status { get { throw null; } }
        protected virtual Azure.AI.Discovery.InvestigationOperationStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Discovery.InvestigationOperationStatus (Azure.Response response) { throw null; }
        protected virtual Azure.AI.Discovery.InvestigationOperationStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.InvestigationOperationStatus System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.InvestigationOperationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.InvestigationOperationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.InvestigationOperationStatus System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.InvestigationOperationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.InvestigationOperationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.InvestigationOperationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InvestigationStatus : System.IEquatable<Azure.AI.Discovery.InvestigationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InvestigationStatus(string value) { throw null; }
        public static Azure.AI.Discovery.InvestigationStatus Created { get { throw null; } }
        public static Azure.AI.Discovery.InvestigationStatus Failed { get { throw null; } }
        public static Azure.AI.Discovery.InvestigationStatus Validated { get { throw null; } }
        public bool Equals(Azure.AI.Discovery.InvestigationStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Discovery.InvestigationStatus left, Azure.AI.Discovery.InvestigationStatus right) { throw null; }
        public static implicit operator Azure.AI.Discovery.InvestigationStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Discovery.InvestigationStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Discovery.InvestigationStatus left, Azure.AI.Discovery.InvestigationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KnowledgeBase : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.KnowledgeBase>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.KnowledgeBase>
    {
        public KnowledgeBase(string description, string copilotInstruction) { }
        public string BookshelfName { get { throw null; } }
        public string CopilotInstruction { get { throw null; } set { } }
        public string CreatedBy { get { throw null; } }
        public string CreatedByApiVersion { get { throw null; } }
        public Azure.AI.Discovery.DiscoveryActorType? CreatedByType { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public Azure.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public string KnowledgeBaseUrl { get { throw null; } }
        public Azure.AI.Discovery.LastIndexingRun LastIndexingRun { get { throw null; } }
        public string LastModifiedBy { get { throw null; } }
        public Azure.AI.Discovery.DiscoveryActorType? LastModifiedByType { get { throw null; } }
        public System.DateTimeOffset? LastModifiedOn { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Discovery.DiscoveryProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.AI.Discovery.IndexingStatus? Status { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Discovery.StorageAssetReference> StorageAssetReferences { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Discovery.DiscoveryTag> Tags { get { throw null; } }
        protected virtual Azure.AI.Discovery.KnowledgeBase JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Discovery.KnowledgeBase (Azure.Response response) { throw null; }
        protected virtual Azure.AI.Discovery.KnowledgeBase PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.KnowledgeBase System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.KnowledgeBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.KnowledgeBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.KnowledgeBase System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.KnowledgeBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.KnowledgeBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.KnowledgeBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBaseIndexingOperationResponse : Azure.AI.Discovery.KnowledgeBaseOperationResponse, System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.KnowledgeBaseIndexingOperationResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.KnowledgeBaseIndexingOperationResponse>
    {
        internal KnowledgeBaseIndexingOperationResponse() { }
        public Azure.AI.Discovery.IndexingOperationResult IndexingResult { get { throw null; } }
        protected override Azure.AI.Discovery.KnowledgeBaseOperationResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Discovery.KnowledgeBaseOperationResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.KnowledgeBaseIndexingOperationResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.KnowledgeBaseIndexingOperationResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.KnowledgeBaseIndexingOperationResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.KnowledgeBaseIndexingOperationResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.KnowledgeBaseIndexingOperationResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.KnowledgeBaseIndexingOperationResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.KnowledgeBaseIndexingOperationResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class KnowledgeBaseOperationResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.KnowledgeBaseOperationResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.KnowledgeBaseOperationResponse>
    {
        internal KnowledgeBaseOperationResponse() { }
        public Azure.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Discovery.OperationState Status { get { throw null; } }
        protected virtual Azure.AI.Discovery.KnowledgeBaseOperationResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Discovery.KnowledgeBaseOperationResponse (Azure.Response response) { throw null; }
        protected virtual Azure.AI.Discovery.KnowledgeBaseOperationResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.KnowledgeBaseOperationResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.KnowledgeBaseOperationResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.KnowledgeBaseOperationResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.KnowledgeBaseOperationResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.KnowledgeBaseOperationResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.KnowledgeBaseOperationResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.KnowledgeBaseOperationResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KnowledgeBases
    {
        protected KnowledgeBases() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation CancelIndexing(Azure.WaitUntil waitUntil, string knowledgeBaseName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation CancelIndexing(Azure.WaitUntil waitUntil, string knowledgeBaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CancelIndexingAsync(Azure.WaitUntil waitUntil, string knowledgeBaseName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> CancelIndexingAsync(Azure.WaitUntil waitUntil, string knowledgeBaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> CreateOrUpdate(Azure.WaitUntil waitUntil, string knowledgeBaseName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string knowledgeBaseName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation Delete(Azure.WaitUntil waitUntil, string knowledgeBaseName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Operation Delete(Azure.WaitUntil waitUntil, string knowledgeBaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteAsync(Azure.WaitUntil waitUntil, string knowledgeBaseName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> DeleteAsync(Azure.WaitUntil waitUntil, string knowledgeBaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Get(string knowledgeBaseName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Discovery.KnowledgeBase> Get(string knowledgeBaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetAll(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Discovery.KnowledgeBase> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetAllAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Discovery.KnowledgeBase> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAsync(string knowledgeBaseName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Discovery.KnowledgeBase>> GetAsync(string knowledgeBaseName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetOperationStatus(string knowledgeBaseName, string operationId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Discovery.KnowledgeBaseOperationResponse> GetOperationStatus(string knowledgeBaseName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetOperationStatusAsync(string knowledgeBaseName, string operationId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Discovery.KnowledgeBaseOperationResponse>> GetOperationStatusAsync(string knowledgeBaseName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Search(Azure.WaitUntil waitUntil, string knowledgeBaseName, Azure.AI.Discovery.SearchRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation Search(Azure.WaitUntil waitUntil, string knowledgeBaseName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> SearchAsync(Azure.WaitUntil waitUntil, string knowledgeBaseName, Azure.AI.Discovery.SearchRequest body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> SearchAsync(Azure.WaitUntil waitUntil, string knowledgeBaseName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation StartIndexing(Azure.WaitUntil waitUntil, string knowledgeBaseName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Operation StartIndexing(Azure.WaitUntil waitUntil, string knowledgeBaseName, string nodePoolId = null, string projectId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> StartIndexingAsync(Azure.WaitUntil waitUntil, string knowledgeBaseName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation> StartIndexingAsync(Azure.WaitUntil waitUntil, string knowledgeBaseName, string nodePoolId = null, string projectId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class KnowledgeBaseSearchOperationResponse : Azure.AI.Discovery.KnowledgeBaseOperationResponse, System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.KnowledgeBaseSearchOperationResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.KnowledgeBaseSearchOperationResponse>
    {
        internal KnowledgeBaseSearchOperationResponse() { }
        public Azure.AI.Discovery.SearchResponse SearchResult { get { throw null; } }
        protected override Azure.AI.Discovery.KnowledgeBaseOperationResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Discovery.KnowledgeBaseOperationResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.KnowledgeBaseSearchOperationResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.KnowledgeBaseSearchOperationResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.KnowledgeBaseSearchOperationResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.KnowledgeBaseSearchOperationResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.KnowledgeBaseSearchOperationResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.KnowledgeBaseSearchOperationResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.KnowledgeBaseSearchOperationResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LastIndexingRun : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.LastIndexingRun>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.LastIndexingRun>
    {
        internal LastIndexingRun() { }
        public Azure.ResponseError Error { get { throw null; } }
        public Azure.AI.Discovery.IndexingMetrics IndexingMetrics { get { throw null; } }
        public string RunId { get { throw null; } }
        public Azure.AI.Discovery.IndexingStatus? Status { get { throw null; } }
        protected virtual Azure.AI.Discovery.LastIndexingRun JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Discovery.LastIndexingRun PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.LastIndexingRun System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.LastIndexingRun>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.LastIndexingRun>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.LastIndexingRun System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.LastIndexingRun>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.LastIndexingRun>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.LastIndexingRun>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NodePoolUsage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.NodePoolUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.NodePoolUsage>
    {
        internal NodePoolUsage() { }
        public string AllocatableCPUs { get { throw null; } }
        public string AllocatableGPUs { get { throw null; } }
        public string AllocatableMemory { get { throw null; } }
        public string ReservedCPUs { get { throw null; } }
        public string ReservedGPUs { get { throw null; } }
        public string ReservedMemory { get { throw null; } }
        protected virtual Azure.AI.Discovery.NodePoolUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Discovery.NodePoolUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.NodePoolUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.NodePoolUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.NodePoolUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.NodePoolUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.NodePoolUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.NodePoolUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.NodePoolUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationState : System.IEquatable<Azure.AI.Discovery.OperationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationState(string value) { throw null; }
        public static Azure.AI.Discovery.OperationState Canceled { get { throw null; } }
        public static Azure.AI.Discovery.OperationState Failed { get { throw null; } }
        public static Azure.AI.Discovery.OperationState NotStarted { get { throw null; } }
        public static Azure.AI.Discovery.OperationState Running { get { throw null; } }
        public static Azure.AI.Discovery.OperationState Succeeded { get { throw null; } }
        public bool Equals(Azure.AI.Discovery.OperationState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Discovery.OperationState left, Azure.AI.Discovery.OperationState right) { throw null; }
        public static implicit operator Azure.AI.Discovery.OperationState (string value) { throw null; }
        public static implicit operator Azure.AI.Discovery.OperationState? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Discovery.OperationState left, Azure.AI.Discovery.OperationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OutputDataMount : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.OutputDataMount>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.OutputDataMount>
    {
        public OutputDataMount(string storageUri, string mountPath) { }
        public string MountPath { get { throw null; } }
        public Azure.AI.Discovery.StorageMountProtocol? MountProtocol { get { throw null; } set { } }
        public string StorageUri { get { throw null; } }
        protected virtual Azure.AI.Discovery.OutputDataMount JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Discovery.OutputDataMount PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.OutputDataMount System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.OutputDataMount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.OutputDataMount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.OutputDataMount System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.OutputDataMount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.OutputDataMount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.OutputDataMount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OutputDataUri : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.OutputDataUri>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.OutputDataUri>
    {
        internal OutputDataUri() { }
        public string MountPath { get { throw null; } }
        public string StorageUri { get { throw null; } }
        protected virtual Azure.AI.Discovery.OutputDataUri JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Discovery.OutputDataUri PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.OutputDataUri System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.OutputDataUri>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.OutputDataUri>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.OutputDataUri System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.OutputDataUri>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.OutputDataUri>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.OutputDataUri>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PagedConversation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.PagedConversation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.PagedConversation>
    {
        internal PagedConversation() { }
        public System.Uri NextLink { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Discovery.DiscoveryConversation> Value { get { throw null; } }
        protected virtual Azure.AI.Discovery.PagedConversation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Discovery.PagedConversation (Azure.Response response) { throw null; }
        protected virtual Azure.AI.Discovery.PagedConversation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.PagedConversation System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.PagedConversation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.PagedConversation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.PagedConversation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.PagedConversation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.PagedConversation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.PagedConversation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PagedInvestigation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.PagedInvestigation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.PagedInvestigation>
    {
        internal PagedInvestigation() { }
        public System.Uri NextLink { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Discovery.DiscoveryInvestigation> Value { get { throw null; } }
        protected virtual Azure.AI.Discovery.PagedInvestigation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Discovery.PagedInvestigation (Azure.Response response) { throw null; }
        protected virtual Azure.AI.Discovery.PagedInvestigation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.PagedInvestigation System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.PagedInvestigation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.PagedInvestigation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.PagedInvestigation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.PagedInvestigation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.PagedInvestigation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.PagedInvestigation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PagedOperation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.PagedOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.PagedOperation>
    {
        internal PagedOperation() { }
        public System.Uri NextLink { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Discovery.WorkspaceOperation> Value { get { throw null; } }
        protected virtual Azure.AI.Discovery.PagedOperation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Discovery.PagedOperation (Azure.Response response) { throw null; }
        protected virtual Azure.AI.Discovery.PagedOperation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.PagedOperation System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.PagedOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.PagedOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.PagedOperation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.PagedOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.PagedOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.PagedOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PagedWorkingMemoryEntry : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.PagedWorkingMemoryEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.PagedWorkingMemoryEntry>
    {
        internal PagedWorkingMemoryEntry() { }
        public System.Uri NextLink { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Discovery.WorkingMemoryEntry> Value { get { throw null; } }
        protected virtual Azure.AI.Discovery.PagedWorkingMemoryEntry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Discovery.PagedWorkingMemoryEntry (Azure.Response response) { throw null; }
        protected virtual Azure.AI.Discovery.PagedWorkingMemoryEntry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.PagedWorkingMemoryEntry System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.PagedWorkingMemoryEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.PagedWorkingMemoryEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.PagedWorkingMemoryEntry System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.PagedWorkingMemoryEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.PagedWorkingMemoryEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.PagedWorkingMemoryEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunOperationStatus : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.RunOperationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.RunOperationStatus>
    {
        internal RunOperationStatus() { }
        public Azure.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Discovery.RunResult Result { get { throw null; } }
        public Azure.AI.Discovery.OperationState Status { get { throw null; } }
        protected virtual Azure.AI.Discovery.RunOperationStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Discovery.RunOperationStatus (Azure.Response response) { throw null; }
        protected virtual Azure.AI.Discovery.RunOperationStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.RunOperationStatus System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.RunOperationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.RunOperationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.RunOperationStatus System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.RunOperationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.RunOperationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.RunOperationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunRequestEnvironmentVariable : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.RunRequestEnvironmentVariable>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.RunRequestEnvironmentVariable>
    {
        public RunRequestEnvironmentVariable(string name) { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.AI.Discovery.RunRequestEnvironmentVariable JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Discovery.RunRequestEnvironmentVariable PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.RunRequestEnvironmentVariable System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.RunRequestEnvironmentVariable>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.RunRequestEnvironmentVariable>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.RunRequestEnvironmentVariable System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.RunRequestEnvironmentVariable>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.RunRequestEnvironmentVariable>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.RunRequestEnvironmentVariable>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.RunResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.RunResult>
    {
        internal RunResult() { }
        public System.DateTimeOffset? CompletedOn { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string DebugInfo { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Discovery.OutputDataUri> OutputData { get { throw null; } }
        public string RuntimeDetails { get { throw null; } }
        public string Status { get { throw null; } }
        public Azure.AI.Discovery.RunResultToolReport ToolReport { get { throw null; } }
        protected virtual Azure.AI.Discovery.RunResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Discovery.RunResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.RunResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.RunResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.RunResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.RunResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.RunResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.RunResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.RunResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunResultToolReport : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.RunResultToolReport>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.RunResultToolReport>
    {
        internal RunResultToolReport() { }
        public string Logs { get { throw null; } }
        public int PercentageComplete { get { throw null; } }
        public Azure.AI.Discovery.RunResultToolReportStatusInformation StatusInformation { get { throw null; } }
        protected virtual Azure.AI.Discovery.RunResultToolReport JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Discovery.RunResultToolReport PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.RunResultToolReport System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.RunResultToolReport>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.RunResultToolReport>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.RunResultToolReport System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.RunResultToolReport>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.RunResultToolReport>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.RunResultToolReport>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunResultToolReportStatusInformation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.RunResultToolReportStatusInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.RunResultToolReportStatusInformation>
    {
        internal RunResultToolReportStatusInformation() { }
        protected virtual Azure.AI.Discovery.RunResultToolReportStatusInformation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Discovery.RunResultToolReportStatusInformation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.RunResultToolReportStatusInformation System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.RunResultToolReportStatusInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.RunResultToolReportStatusInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.RunResultToolReportStatusInformation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.RunResultToolReportStatusInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.RunResultToolReportStatusInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.RunResultToolReportStatusInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStatus : System.IEquatable<Azure.AI.Discovery.RunStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStatus(string value) { throw null; }
        public static Azure.AI.Discovery.RunStatus Canceled { get { throw null; } }
        public static Azure.AI.Discovery.RunStatus Failed { get { throw null; } }
        public static Azure.AI.Discovery.RunStatus NotStarted { get { throw null; } }
        public static Azure.AI.Discovery.RunStatus Running { get { throw null; } }
        public static Azure.AI.Discovery.RunStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.AI.Discovery.RunStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Discovery.RunStatus left, Azure.AI.Discovery.RunStatus right) { throw null; }
        public static implicit operator Azure.AI.Discovery.RunStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Discovery.RunStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Discovery.RunStatus left, Azure.AI.Discovery.RunStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SearchRequest : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.SearchRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.SearchRequest>
    {
        public SearchRequest(string query) { }
        public string Query { get { throw null; } }
        protected virtual Azure.AI.Discovery.SearchRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.Discovery.SearchRequest searchRequest) { throw null; }
        protected virtual Azure.AI.Discovery.SearchRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.SearchRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.SearchRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.SearchRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.SearchRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.SearchRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.SearchRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.SearchRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.SearchResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.SearchResponse>
    {
        internal SearchResponse() { }
        public System.Collections.Generic.IList<Azure.AI.Discovery.SearchResultItem> SearchResults { get { throw null; } }
        protected virtual Azure.AI.Discovery.SearchResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Discovery.SearchResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.SearchResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.SearchResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.SearchResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.SearchResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.SearchResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.SearchResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.SearchResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SearchResultItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.SearchResultItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.SearchResultItem>
    {
        internal SearchResultItem() { }
        public System.Collections.Generic.IList<Azure.AI.Discovery.DiscoveryCitation> Citations { get { throw null; } }
        public string Text { get { throw null; } }
        protected virtual Azure.AI.Discovery.SearchResultItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Discovery.SearchResultItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.SearchResultItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.SearchResultItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.SearchResultItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.SearchResultItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.SearchResultItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.SearchResultItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.SearchResultItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StartTaskRequest : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.StartTaskRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.StartTaskRequest>
    {
        public StartTaskRequest() { }
        public Azure.AI.Discovery.TaskAssignee Assignee { get { throw null; } set { } }
        protected virtual Azure.AI.Discovery.StartTaskRequest JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.Discovery.StartTaskRequest startTaskRequest) { throw null; }
        protected virtual Azure.AI.Discovery.StartTaskRequest PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.StartTaskRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.StartTaskRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.StartTaskRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.StartTaskRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.StartTaskRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.StartTaskRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.StartTaskRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageAssetReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.StorageAssetReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.StorageAssetReference>
    {
        public StorageAssetReference(Azure.Core.ResourceIdentifier id) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
        protected virtual Azure.AI.Discovery.StorageAssetReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Discovery.StorageAssetReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.StorageAssetReference System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.StorageAssetReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.StorageAssetReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.StorageAssetReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.StorageAssetReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.StorageAssetReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.StorageAssetReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StorageMountProtocol : System.IEquatable<Azure.AI.Discovery.StorageMountProtocol>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StorageMountProtocol(string value) { throw null; }
        public static Azure.AI.Discovery.StorageMountProtocol BlobfuseCaching { get { throw null; } }
        public static Azure.AI.Discovery.StorageMountProtocol Nfs { get { throw null; } }
        public bool Equals(Azure.AI.Discovery.StorageMountProtocol other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Discovery.StorageMountProtocol left, Azure.AI.Discovery.StorageMountProtocol right) { throw null; }
        public static implicit operator Azure.AI.Discovery.StorageMountProtocol (string value) { throw null; }
        public static implicit operator Azure.AI.Discovery.StorageMountProtocol? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Discovery.StorageMountProtocol left, Azure.AI.Discovery.StorageMountProtocol right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SupercomputerUsage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.SupercomputerUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.SupercomputerUsage>
    {
        internal SupercomputerUsage() { }
        public long ActiveJobs { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Discovery.NodePoolUsage> NodePools { get { throw null; } }
        public long PendingJobs { get { throw null; } }
        protected virtual Azure.AI.Discovery.SupercomputerUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Discovery.SupercomputerUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.SupercomputerUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.SupercomputerUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.SupercomputerUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.SupercomputerUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.SupercomputerUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.SupercomputerUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.SupercomputerUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TaskAssignee : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.TaskAssignee>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.TaskAssignee>
    {
        public TaskAssignee(string id, Azure.AI.Discovery.DiscoveryActorType type) { }
        public string Id { get { throw null; } set { } }
        public Azure.AI.Discovery.DiscoveryActorType Type { get { throw null; } set { } }
        protected virtual Azure.AI.Discovery.TaskAssignee JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Discovery.TaskAssignee PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.TaskAssignee System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.TaskAssignee>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.TaskAssignee>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.TaskAssignee System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.TaskAssignee>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.TaskAssignee>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.TaskAssignee>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TaskComment : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.TaskComment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.TaskComment>
    {
        public TaskComment(string createdBy, Azure.AI.Discovery.DiscoveryActorType createdByType, string text) { }
        public string CreatedBy { get { throw null; } set { } }
        public Azure.AI.Discovery.DiscoveryActorType CreatedByType { get { throw null; } set { } }
        public string Text { get { throw null; } set { } }
        public System.DateTimeOffset? Timestamp { get { throw null; } set { } }
        protected virtual Azure.AI.Discovery.TaskComment JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.Discovery.TaskComment taskComment) { throw null; }
        protected virtual Azure.AI.Discovery.TaskComment PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.TaskComment System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.TaskComment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.TaskComment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.TaskComment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.TaskComment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.TaskComment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.TaskComment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TaskPriority : System.IEquatable<Azure.AI.Discovery.TaskPriority>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TaskPriority(string value) { throw null; }
        public static Azure.AI.Discovery.TaskPriority High { get { throw null; } }
        public static Azure.AI.Discovery.TaskPriority Low { get { throw null; } }
        public static Azure.AI.Discovery.TaskPriority Medium { get { throw null; } }
        public bool Equals(Azure.AI.Discovery.TaskPriority other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Discovery.TaskPriority left, Azure.AI.Discovery.TaskPriority right) { throw null; }
        public static implicit operator Azure.AI.Discovery.TaskPriority (string value) { throw null; }
        public static implicit operator Azure.AI.Discovery.TaskPriority? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Discovery.TaskPriority left, Azure.AI.Discovery.TaskPriority right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TaskResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.TaskResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.TaskResult>
    {
        public TaskResult() { }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> StorageAssetIds { get { throw null; } }
        public string Text { get { throw null; } set { } }
        protected virtual Azure.AI.Discovery.TaskResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Discovery.TaskResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.TaskResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.TaskResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.TaskResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.TaskResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.TaskResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.TaskResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.TaskResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TaskStatus : System.IEquatable<Azure.AI.Discovery.TaskStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TaskStatus(string value) { throw null; }
        public static Azure.AI.Discovery.TaskStatus Complete { get { throw null; } }
        public static Azure.AI.Discovery.TaskStatus Executing { get { throw null; } }
        public static Azure.AI.Discovery.TaskStatus ExecutionDone { get { throw null; } }
        public static Azure.AI.Discovery.TaskStatus Failed { get { throw null; } }
        public static Azure.AI.Discovery.TaskStatus FlaggedAi { get { throw null; } }
        public static Azure.AI.Discovery.TaskStatus FlaggedHuman { get { throw null; } }
        public static Azure.AI.Discovery.TaskStatus Incomplete { get { throw null; } }
        public static Azure.AI.Discovery.TaskStatus New { get { throw null; } }
        public static Azure.AI.Discovery.TaskStatus OnHold { get { throw null; } }
        public static Azure.AI.Discovery.TaskStatus Removed { get { throw null; } }
        public static Azure.AI.Discovery.TaskStatus Stale { get { throw null; } }
        public bool Equals(Azure.AI.Discovery.TaskStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Discovery.TaskStatus left, Azure.AI.Discovery.TaskStatus right) { throw null; }
        public static implicit operator Azure.AI.Discovery.TaskStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Discovery.TaskStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Discovery.TaskStatus left, Azure.AI.Discovery.TaskStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkingMemoryEntry : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.WorkingMemoryEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.WorkingMemoryEntry>
    {
        internal WorkingMemoryEntry() { }
        public string Content { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.AI.Discovery.WorkingMemoryEntryType Type { get { throw null; } }
        protected virtual Azure.AI.Discovery.WorkingMemoryEntry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Discovery.WorkingMemoryEntry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.WorkingMemoryEntry System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.WorkingMemoryEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.WorkingMemoryEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.WorkingMemoryEntry System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.WorkingMemoryEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.WorkingMemoryEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.WorkingMemoryEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkingMemoryEntryType : System.IEquatable<Azure.AI.Discovery.WorkingMemoryEntryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkingMemoryEntryType(string value) { throw null; }
        public static Azure.AI.Discovery.WorkingMemoryEntryType Thought { get { throw null; } }
        public bool Equals(Azure.AI.Discovery.WorkingMemoryEntryType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Discovery.WorkingMemoryEntryType left, Azure.AI.Discovery.WorkingMemoryEntryType right) { throw null; }
        public static implicit operator Azure.AI.Discovery.WorkingMemoryEntryType (string value) { throw null; }
        public static implicit operator Azure.AI.Discovery.WorkingMemoryEntryType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Discovery.WorkingMemoryEntryType left, Azure.AI.Discovery.WorkingMemoryEntryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkspaceClient
    {
        protected WorkspaceClient() { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
        public WorkspaceClient(Azure.AI.Discovery.WorkspaceClientSettings settings) { }
        public WorkspaceClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public WorkspaceClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Discovery.WorkspaceClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.AI.Discovery.DiscoveryConversationsClient GetDiscoveryConversationsClient() { throw null; }
        public virtual Azure.AI.Discovery.DiscoveryInvestigationsClient GetDiscoveryInvestigationsClient() { throw null; }
        public virtual Azure.AI.Discovery.DiscoveryTasksClient GetDiscoveryTasksClient() { throw null; }
        public virtual Azure.AI.Discovery.DiscoveryToolsClient GetDiscoveryToolsClient() { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public static partial class WorkspaceClientHostExtensions
    {
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedWorkspaceClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedWorkspaceClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName, System.Action<Azure.AI.Discovery.WorkspaceClientSettings> configureSettings) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddWorkspaceClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddWorkspaceClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName, System.Action<Azure.AI.Discovery.WorkspaceClientSettings> configureSettings) { throw null; }
    }
    public partial class WorkspaceClientOptions : Azure.Core.ClientOptions
    {
        public WorkspaceClientOptions(Azure.AI.Discovery.WorkspaceClientOptions.ServiceVersion version = Azure.AI.Discovery.WorkspaceClientOptions.ServiceVersion.V2026_06_01) { }
        public enum ServiceVersion
        {
            V2026_06_01 = 1,
        }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public partial class WorkspaceClientSettings : System.ClientModel.Primitives.ClientSettings
    {
        public WorkspaceClientSettings() { }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.AI.Discovery.WorkspaceClientOptions Options { get { throw null; } set { } }
        protected override void BindCore(Microsoft.Extensions.Configuration.IConfigurationSection section) { }
    }
    public partial class WorkspaceOperation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.WorkspaceOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.WorkspaceOperation>
    {
        internal WorkspaceOperation() { }
        public System.DateTimeOffset? CompletedOn { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public System.DateTimeOffset CreatedOn { get { throw null; } }
        public string Id { get { throw null; } }
        public string NodepoolId { get { throw null; } }
        public string RuntimeDetails { get { throw null; } }
        public Azure.AI.Discovery.RunStatus Status { get { throw null; } }
        protected virtual Azure.AI.Discovery.WorkspaceOperation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Discovery.WorkspaceOperation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Discovery.WorkspaceOperation System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.WorkspaceOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Discovery.WorkspaceOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Discovery.WorkspaceOperation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.WorkspaceOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.WorkspaceOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Discovery.WorkspaceOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
