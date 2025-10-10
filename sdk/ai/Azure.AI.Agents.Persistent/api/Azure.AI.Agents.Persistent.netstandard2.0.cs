namespace Azure.AI.Agents.Persistent
{
    public partial class ActivityFunctionDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ActivityFunctionDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ActivityFunctionDefinition>
    {
        internal ActivityFunctionDefinition() { }
        public string Description { get { throw null; } }
        public Azure.AI.Agents.Persistent.ActivityFunctionParameters Parameters { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ActivityFunctionDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ActivityFunctionDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ActivityFunctionDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ActivityFunctionDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ActivityFunctionDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ActivityFunctionDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ActivityFunctionDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ActivityFunctionParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ActivityFunctionParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ActivityFunctionParameters>
    {
        internal ActivityFunctionParameters() { }
        public bool? AdditionalProperties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Agents.Persistent.FunctionArgument> Properties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Required { get { throw null; } }
        public Azure.AI.Agents.Persistent.ActivityFunctionParametersType Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ActivityFunctionParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ActivityFunctionParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ActivityFunctionParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ActivityFunctionParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ActivityFunctionParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ActivityFunctionParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ActivityFunctionParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActivityFunctionParametersType : System.IEquatable<Azure.AI.Agents.Persistent.ActivityFunctionParametersType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActivityFunctionParametersType(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.ActivityFunctionParametersType Object { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.ActivityFunctionParametersType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.ActivityFunctionParametersType left, Azure.AI.Agents.Persistent.ActivityFunctionParametersType right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.ActivityFunctionParametersType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.ActivityFunctionParametersType left, Azure.AI.Agents.Persistent.ActivityFunctionParametersType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AISearchIndexResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.AISearchIndexResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.AISearchIndexResource>
    {
        public AISearchIndexResource() { }
        public string Filter { get { throw null; } }
        public string IndexAssetId { get { throw null; } }
        public string IndexConnectionId { get { throw null; } }
        public string IndexName { get { throw null; } }
        public Azure.AI.Agents.Persistent.AzureAISearchQueryType? QueryType { get { throw null; } set { } }
        public int? TopK { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.AISearchIndexResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.AISearchIndexResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.AISearchIndexResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.AISearchIndexResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.AISearchIndexResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.AISearchIndexResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.AISearchIndexResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AutoFunctionCallOptions
    {
        public AutoFunctionCallOptions(System.Collections.Generic.Dictionary<string, System.Delegate> toolDelegates, int maxRetry) { }
    }
    public partial class AzureAIAgentsPersistentContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAIAgentsPersistentContext() { }
        public static Azure.AI.Agents.Persistent.AzureAIAgentsPersistentContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureAISearchQueryType : System.IEquatable<Azure.AI.Agents.Persistent.AzureAISearchQueryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureAISearchQueryType(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.AzureAISearchQueryType Semantic { get { throw null; } }
        public static Azure.AI.Agents.Persistent.AzureAISearchQueryType Simple { get { throw null; } }
        public static Azure.AI.Agents.Persistent.AzureAISearchQueryType Vector { get { throw null; } }
        public static Azure.AI.Agents.Persistent.AzureAISearchQueryType VectorSemanticHybrid { get { throw null; } }
        public static Azure.AI.Agents.Persistent.AzureAISearchQueryType VectorSimpleHybrid { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.AzureAISearchQueryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.AzureAISearchQueryType left, Azure.AI.Agents.Persistent.AzureAISearchQueryType right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.AzureAISearchQueryType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.AzureAISearchQueryType left, Azure.AI.Agents.Persistent.AzureAISearchQueryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureAISearchToolDefinition : Azure.AI.Agents.Persistent.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.AzureAISearchToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.AzureAISearchToolDefinition>
    {
        public AzureAISearchToolDefinition() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.AzureAISearchToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.AzureAISearchToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.AzureAISearchToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.AzureAISearchToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.AzureAISearchToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.AzureAISearchToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.AzureAISearchToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAISearchToolResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.AzureAISearchToolResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.AzureAISearchToolResource>
    {
        public AzureAISearchToolResource() { }
        public AzureAISearchToolResource(string indexConnectionId, string indexName, int topK, string filter, Azure.AI.Agents.Persistent.AzureAISearchQueryType? queryType = default(Azure.AI.Agents.Persistent.AzureAISearchQueryType?)) { }
        public System.Collections.Generic.IList<Azure.AI.Agents.Persistent.AISearchIndexResource> IndexList { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.AzureAISearchToolResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.AzureAISearchToolResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.AzureAISearchToolResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.AzureAISearchToolResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.AzureAISearchToolResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.AzureAISearchToolResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.AzureAISearchToolResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionBinding : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.AzureFunctionBinding>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.AzureFunctionBinding>
    {
        public AzureFunctionBinding(Azure.AI.Agents.Persistent.AzureFunctionStorageQueue storageQueue) { }
        public Azure.AI.Agents.Persistent.AzureFunctionStorageQueue StorageQueue { get { throw null; } }
        public Azure.AI.Agents.Persistent.AzureFunctionBindingType Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.AzureFunctionBinding System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.AzureFunctionBinding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.AzureFunctionBinding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.AzureFunctionBinding System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.AzureFunctionBinding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.AzureFunctionBinding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.AzureFunctionBinding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureFunctionBindingType : System.IEquatable<Azure.AI.Agents.Persistent.AzureFunctionBindingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureFunctionBindingType(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.AzureFunctionBindingType StorageQueue { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.AzureFunctionBindingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.AzureFunctionBindingType left, Azure.AI.Agents.Persistent.AzureFunctionBindingType right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.AzureFunctionBindingType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.AzureFunctionBindingType left, Azure.AI.Agents.Persistent.AzureFunctionBindingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureFunctionStorageQueue : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.AzureFunctionStorageQueue>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.AzureFunctionStorageQueue>
    {
        public AzureFunctionStorageQueue(string storageServiceEndpoint, string queueName) { }
        public string QueueName { get { throw null; } }
        public string StorageServiceEndpoint { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.AzureFunctionStorageQueue System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.AzureFunctionStorageQueue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.AzureFunctionStorageQueue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.AzureFunctionStorageQueue System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.AzureFunctionStorageQueue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.AzureFunctionStorageQueue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.AzureFunctionStorageQueue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionToolCallDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.AzureFunctionToolCallDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.AzureFunctionToolCallDetails>
    {
        internal AzureFunctionToolCallDetails() { }
        public string Arguments { get { throw null; } }
        public string Name { get { throw null; } }
        public string Output { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.AzureFunctionToolCallDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.AzureFunctionToolCallDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.AzureFunctionToolCallDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.AzureFunctionToolCallDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.AzureFunctionToolCallDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.AzureFunctionToolCallDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.AzureFunctionToolCallDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionToolDefinition : Azure.AI.Agents.Persistent.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.AzureFunctionToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.AzureFunctionToolDefinition>
    {
        public AzureFunctionToolDefinition(string name, string description, Azure.AI.Agents.Persistent.AzureFunctionBinding inputBinding, Azure.AI.Agents.Persistent.AzureFunctionBinding outputBinding, System.BinaryData parameters) { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.AzureFunctionToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.AzureFunctionToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.AzureFunctionToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.AzureFunctionToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.AzureFunctionToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.AzureFunctionToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.AzureFunctionToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingCustomSearchConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BingCustomSearchConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BingCustomSearchConfiguration>
    {
        public BingCustomSearchConfiguration(string connectionId, string instanceName) { }
        public string ConnectionId { get { throw null; } set { } }
        public long? Count { get { throw null; } set { } }
        public string Freshness { get { throw null; } set { } }
        public string InstanceName { get { throw null; } set { } }
        public string Market { get { throw null; } set { } }
        public string SetLang { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.BingCustomSearchConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BingCustomSearchConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BingCustomSearchConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.BingCustomSearchConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BingCustomSearchConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BingCustomSearchConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BingCustomSearchConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingCustomSearchToolDefinition : Azure.AI.Agents.Persistent.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BingCustomSearchToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BingCustomSearchToolDefinition>
    {
        public BingCustomSearchToolDefinition(Azure.AI.Agents.Persistent.BingCustomSearchToolParameters bingCustomSearch) { }
        public Azure.AI.Agents.Persistent.BingCustomSearchToolParameters BingCustomSearch { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.BingCustomSearchToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BingCustomSearchToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BingCustomSearchToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.BingCustomSearchToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BingCustomSearchToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BingCustomSearchToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BingCustomSearchToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingCustomSearchToolParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BingCustomSearchToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BingCustomSearchToolParameters>
    {
        public BingCustomSearchToolParameters(System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.BingCustomSearchConfiguration> searchConfigurations) { }
        public BingCustomSearchToolParameters(string connectionId, string instanceName) { }
        public System.Collections.Generic.IList<Azure.AI.Agents.Persistent.BingCustomSearchConfiguration> SearchConfigurations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.BingCustomSearchToolParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BingCustomSearchToolParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BingCustomSearchToolParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.BingCustomSearchToolParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BingCustomSearchToolParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BingCustomSearchToolParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BingCustomSearchToolParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingGroundingSearchConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BingGroundingSearchConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BingGroundingSearchConfiguration>
    {
        public BingGroundingSearchConfiguration(string connectionId) { }
        public string ConnectionId { get { throw null; } set { } }
        public long? Count { get { throw null; } set { } }
        public string Freshness { get { throw null; } set { } }
        public string Market { get { throw null; } set { } }
        public string SetLang { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.BingGroundingSearchConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BingGroundingSearchConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BingGroundingSearchConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.BingGroundingSearchConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BingGroundingSearchConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BingGroundingSearchConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BingGroundingSearchConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingGroundingSearchToolParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BingGroundingSearchToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BingGroundingSearchToolParameters>
    {
        public BingGroundingSearchToolParameters(System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.BingGroundingSearchConfiguration> searchConfigurations) { }
        public System.Collections.Generic.IList<Azure.AI.Agents.Persistent.BingGroundingSearchConfiguration> SearchConfigurations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.BingGroundingSearchToolParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BingGroundingSearchToolParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BingGroundingSearchToolParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.BingGroundingSearchToolParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BingGroundingSearchToolParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BingGroundingSearchToolParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BingGroundingSearchToolParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingGroundingToolDefinition : Azure.AI.Agents.Persistent.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BingGroundingToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BingGroundingToolDefinition>
    {
        public BingGroundingToolDefinition(Azure.AI.Agents.Persistent.BingGroundingSearchToolParameters bingGrounding) { }
        public Azure.AI.Agents.Persistent.BingGroundingSearchToolParameters BingGrounding { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.BingGroundingToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BingGroundingToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BingGroundingToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.BingGroundingToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BingGroundingToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BingGroundingToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BingGroundingToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrowserAutomationToolCallDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BrowserAutomationToolCallDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BrowserAutomationToolCallDetails>
    {
        internal BrowserAutomationToolCallDetails() { }
        public string Input { get { throw null; } }
        public string Output { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.Persistent.BrowserAutomationToolCallStep> Steps { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.BrowserAutomationToolCallDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BrowserAutomationToolCallDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BrowserAutomationToolCallDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.BrowserAutomationToolCallDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BrowserAutomationToolCallDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BrowserAutomationToolCallDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BrowserAutomationToolCallDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrowserAutomationToolCallStep : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BrowserAutomationToolCallStep>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BrowserAutomationToolCallStep>
    {
        internal BrowserAutomationToolCallStep() { }
        public string CurrentState { get { throw null; } }
        public string LastStepResult { get { throw null; } }
        public string NextStep { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.BrowserAutomationToolCallStep System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BrowserAutomationToolCallStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BrowserAutomationToolCallStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.BrowserAutomationToolCallStep System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BrowserAutomationToolCallStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BrowserAutomationToolCallStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BrowserAutomationToolCallStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrowserAutomationToolConnectionParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BrowserAutomationToolConnectionParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BrowserAutomationToolConnectionParameters>
    {
        public BrowserAutomationToolConnectionParameters(string id) { }
        public string Id { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.BrowserAutomationToolConnectionParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BrowserAutomationToolConnectionParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BrowserAutomationToolConnectionParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.BrowserAutomationToolConnectionParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BrowserAutomationToolConnectionParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BrowserAutomationToolConnectionParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BrowserAutomationToolConnectionParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrowserAutomationToolDefinition : Azure.AI.Agents.Persistent.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BrowserAutomationToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BrowserAutomationToolDefinition>
    {
        public BrowserAutomationToolDefinition(Azure.AI.Agents.Persistent.BrowserAutomationToolParameters browserAutomation) { }
        public Azure.AI.Agents.Persistent.BrowserAutomationToolParameters BrowserAutomation { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.BrowserAutomationToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BrowserAutomationToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BrowserAutomationToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.BrowserAutomationToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BrowserAutomationToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BrowserAutomationToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BrowserAutomationToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrowserAutomationToolParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BrowserAutomationToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BrowserAutomationToolParameters>
    {
        public BrowserAutomationToolParameters(Azure.AI.Agents.Persistent.BrowserAutomationToolConnectionParameters connection) { }
        public Azure.AI.Agents.Persistent.BrowserAutomationToolConnectionParameters Connection { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.BrowserAutomationToolParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BrowserAutomationToolParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.BrowserAutomationToolParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.BrowserAutomationToolParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BrowserAutomationToolParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BrowserAutomationToolParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.BrowserAutomationToolParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ClickAction : Azure.AI.Agents.Persistent.ComputerUseAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ClickAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ClickAction>
    {
        internal ClickAction() { }
        public Azure.AI.Agents.Persistent.MouseButton Button { get { throw null; } }
        public int X { get { throw null; } }
        public int Y { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ClickAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ClickAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ClickAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ClickAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ClickAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ClickAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ClickAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CodeInterpreterToolDefinition : Azure.AI.Agents.Persistent.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.CodeInterpreterToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.CodeInterpreterToolDefinition>
    {
        public CodeInterpreterToolDefinition() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.CodeInterpreterToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.CodeInterpreterToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.CodeInterpreterToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.CodeInterpreterToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.CodeInterpreterToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.CodeInterpreterToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.CodeInterpreterToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CodeInterpreterToolResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.CodeInterpreterToolResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.CodeInterpreterToolResource>
    {
        public CodeInterpreterToolResource() { }
        public System.Collections.Generic.IList<Azure.AI.Agents.Persistent.VectorStoreDataSource> DataSources { get { throw null; } }
        public System.Collections.Generic.IList<string> FileIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.CodeInterpreterToolResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.CodeInterpreterToolResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.CodeInterpreterToolResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.CodeInterpreterToolResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.CodeInterpreterToolResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.CodeInterpreterToolResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.CodeInterpreterToolResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputerScreenshot : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ComputerScreenshot>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ComputerScreenshot>
    {
        public ComputerScreenshot() { }
        public string FileId { get { throw null; } set { } }
        public string ImageUrl { get { throw null; } set { } }
        public Azure.AI.Agents.Persistent.ComputerScreenshotType Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ComputerScreenshot System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ComputerScreenshot>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ComputerScreenshot>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ComputerScreenshot System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ComputerScreenshot>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ComputerScreenshot>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ComputerScreenshot>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputerScreenshotType : System.IEquatable<Azure.AI.Agents.Persistent.ComputerScreenshotType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputerScreenshotType(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.ComputerScreenshotType ComputerScreenshot { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.ComputerScreenshotType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.ComputerScreenshotType left, Azure.AI.Agents.Persistent.ComputerScreenshotType right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.ComputerScreenshotType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.ComputerScreenshotType left, Azure.AI.Agents.Persistent.ComputerScreenshotType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputerToolOutput : Azure.AI.Agents.Persistent.StructuredToolOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ComputerToolOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ComputerToolOutput>
    {
        public ComputerToolOutput(Azure.AI.Agents.Persistent.ComputerScreenshot output) { }
        public System.Collections.Generic.IList<Azure.AI.Agents.Persistent.SafetyCheck> AcknowledgedSafetyChecks { get { throw null; } }
        public Azure.AI.Agents.Persistent.ComputerScreenshot Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ComputerToolOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ComputerToolOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ComputerToolOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ComputerToolOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ComputerToolOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ComputerToolOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ComputerToolOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ComputerUseAction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ComputerUseAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ComputerUseAction>
    {
        protected ComputerUseAction() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ComputerUseAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ComputerUseAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ComputerUseAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ComputerUseAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ComputerUseAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ComputerUseAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ComputerUseAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputerUseEnvironment : System.IEquatable<Azure.AI.Agents.Persistent.ComputerUseEnvironment>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputerUseEnvironment(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.ComputerUseEnvironment Browser { get { throw null; } }
        public static Azure.AI.Agents.Persistent.ComputerUseEnvironment Linux { get { throw null; } }
        public static Azure.AI.Agents.Persistent.ComputerUseEnvironment Mac { get { throw null; } }
        public static Azure.AI.Agents.Persistent.ComputerUseEnvironment Windows { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.ComputerUseEnvironment other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.ComputerUseEnvironment left, Azure.AI.Agents.Persistent.ComputerUseEnvironment right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.ComputerUseEnvironment (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.ComputerUseEnvironment left, Azure.AI.Agents.Persistent.ComputerUseEnvironment right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputerUseToolDefinition : Azure.AI.Agents.Persistent.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ComputerUseToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ComputerUseToolDefinition>
    {
        public ComputerUseToolDefinition(Azure.AI.Agents.Persistent.ComputerUseToolParameters computerUsePreview) { }
        public Azure.AI.Agents.Persistent.ComputerUseToolParameters ComputerUsePreview { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ComputerUseToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ComputerUseToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ComputerUseToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ComputerUseToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ComputerUseToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ComputerUseToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ComputerUseToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputerUseToolParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ComputerUseToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ComputerUseToolParameters>
    {
        public ComputerUseToolParameters(int displayWidth, int displayHeight, Azure.AI.Agents.Persistent.ComputerUseEnvironment environment) { }
        public int DisplayHeight { get { throw null; } set { } }
        public int DisplayWidth { get { throw null; } set { } }
        public Azure.AI.Agents.Persistent.ComputerUseEnvironment Environment { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ComputerUseToolParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ComputerUseToolParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ComputerUseToolParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ComputerUseToolParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ComputerUseToolParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ComputerUseToolParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ComputerUseToolParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedAgentDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ConnectedAgentDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ConnectedAgentDetails>
    {
        public ConnectedAgentDetails(string id, string name, string description) { }
        public string Description { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ConnectedAgentDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ConnectedAgentDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ConnectedAgentDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ConnectedAgentDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ConnectedAgentDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ConnectedAgentDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ConnectedAgentDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectedAgentToolDefinition : Azure.AI.Agents.Persistent.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ConnectedAgentToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ConnectedAgentToolDefinition>
    {
        public ConnectedAgentToolDefinition(Azure.AI.Agents.Persistent.ConnectedAgentDetails connectedAgent) { }
        public Azure.AI.Agents.Persistent.ConnectedAgentDetails ConnectedAgent { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ConnectedAgentToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ConnectedAgentToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ConnectedAgentToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ConnectedAgentToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ConnectedAgentToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ConnectedAgentToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ConnectedAgentToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CoordinatePoint : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.CoordinatePoint>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.CoordinatePoint>
    {
        internal CoordinatePoint() { }
        public int X { get { throw null; } }
        public int Y { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.CoordinatePoint System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.CoordinatePoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.CoordinatePoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.CoordinatePoint System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.CoordinatePoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.CoordinatePoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.CoordinatePoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CreateRunStreamingOptions
    {
        public CreateRunStreamingOptions() { }
        public string AdditionalInstructions { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ThreadMessageOptions> AdditionalMessages { get { throw null; } set { } }
        public Azure.AI.Agents.Persistent.AutoFunctionCallOptions AutoFunctionCallOptions { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.RunAdditionalFieldList> Include { get { throw null; } set { } }
        public int? MaxCompletionTokens { get { throw null; } set { } }
        public int? MaxPromptTokens { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } set { } }
        public string OverrideInstructions { get { throw null; } set { } }
        public string OverrideModelName { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ToolDefinition> OverrideTools { get { throw null; } set { } }
        public bool? ParallelToolCalls { get { throw null; } set { } }
        public System.BinaryData ResponseFormat { get { throw null; } set { } }
        public float? Temperature { get { throw null; } set { } }
        public System.BinaryData ToolChoice { get { throw null; } set { } }
        public Azure.AI.Agents.Persistent.ToolResources ToolResources { get { throw null; } set { } }
        public float? TopP { get { throw null; } set { } }
        public Azure.AI.Agents.Persistent.Truncation TruncationStrategy { get { throw null; } set { } }
    }
    public partial class DeepResearchBingGroundingConnection : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.DeepResearchBingGroundingConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.DeepResearchBingGroundingConnection>
    {
        public DeepResearchBingGroundingConnection(string connectionId) { }
        public string ConnectionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.DeepResearchBingGroundingConnection System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.DeepResearchBingGroundingConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.DeepResearchBingGroundingConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.DeepResearchBingGroundingConnection System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.DeepResearchBingGroundingConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.DeepResearchBingGroundingConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.DeepResearchBingGroundingConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeepResearchDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.DeepResearchDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.DeepResearchDetails>
    {
        public DeepResearchDetails(string model, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.DeepResearchBingGroundingConnection> bingGroundingConnections) { }
        public System.Collections.Generic.IList<Azure.AI.Agents.Persistent.DeepResearchBingGroundingConnection> BingGroundingConnections { get { throw null; } }
        public string Model { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.DeepResearchDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.DeepResearchDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.DeepResearchDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.DeepResearchDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.DeepResearchDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.DeepResearchDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.DeepResearchDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeepResearchToolDefinition : Azure.AI.Agents.Persistent.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.DeepResearchToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.DeepResearchToolDefinition>
    {
        public DeepResearchToolDefinition(Azure.AI.Agents.Persistent.DeepResearchDetails deepResearch) { }
        public Azure.AI.Agents.Persistent.DeepResearchDetails DeepResearch { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.DeepResearchToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.DeepResearchToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.DeepResearchToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.DeepResearchToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.DeepResearchToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.DeepResearchToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.DeepResearchToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DoneEvent : System.IEquatable<Azure.AI.Agents.Persistent.DoneEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DoneEvent(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.DoneEvent Done { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.DoneEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.DoneEvent left, Azure.AI.Agents.Persistent.DoneEvent right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.DoneEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.DoneEvent left, Azure.AI.Agents.Persistent.DoneEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DoubleClickAction : Azure.AI.Agents.Persistent.ComputerUseAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.DoubleClickAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.DoubleClickAction>
    {
        internal DoubleClickAction() { }
        public int X { get { throw null; } }
        public int Y { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.DoubleClickAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.DoubleClickAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.DoubleClickAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.DoubleClickAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.DoubleClickAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.DoubleClickAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.DoubleClickAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DragAction : Azure.AI.Agents.Persistent.ComputerUseAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.DragAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.DragAction>
    {
        internal DragAction() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.Persistent.CoordinatePoint> Path { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.DragAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.DragAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.DragAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.DragAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.DragAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.DragAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.DragAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ErrorEvent : System.IEquatable<Azure.AI.Agents.Persistent.ErrorEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ErrorEvent(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.ErrorEvent Error { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.ErrorEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.ErrorEvent left, Azure.AI.Agents.Persistent.ErrorEvent right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.ErrorEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.ErrorEvent left, Azure.AI.Agents.Persistent.ErrorEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FabricDataAgentToolParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.FabricDataAgentToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FabricDataAgentToolParameters>
    {
        public FabricDataAgentToolParameters() { }
        public FabricDataAgentToolParameters(string connectionId) { }
        public System.Collections.Generic.IList<Azure.AI.Agents.Persistent.ToolConnection> ConnectionList { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.FabricDataAgentToolParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.FabricDataAgentToolParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.FabricDataAgentToolParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.FabricDataAgentToolParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FabricDataAgentToolParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FabricDataAgentToolParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FabricDataAgentToolParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSearchRankingOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.FileSearchRankingOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FileSearchRankingOptions>
    {
        public FileSearchRankingOptions(string ranker, float scoreThreshold) { }
        public string Ranker { get { throw null; } set { } }
        public float ScoreThreshold { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.FileSearchRankingOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.FileSearchRankingOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.FileSearchRankingOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.FileSearchRankingOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FileSearchRankingOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FileSearchRankingOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FileSearchRankingOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSearchToolCallContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.FileSearchToolCallContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FileSearchToolCallContent>
    {
        internal FileSearchToolCallContent() { }
        public string Text { get { throw null; } }
        public Azure.AI.Agents.Persistent.FileSearchToolCallContentType Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.FileSearchToolCallContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.FileSearchToolCallContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.FileSearchToolCallContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.FileSearchToolCallContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FileSearchToolCallContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FileSearchToolCallContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FileSearchToolCallContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileSearchToolCallContentType : System.IEquatable<Azure.AI.Agents.Persistent.FileSearchToolCallContentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileSearchToolCallContentType(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.FileSearchToolCallContentType Text { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.FileSearchToolCallContentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.FileSearchToolCallContentType left, Azure.AI.Agents.Persistent.FileSearchToolCallContentType right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.FileSearchToolCallContentType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.FileSearchToolCallContentType left, Azure.AI.Agents.Persistent.FileSearchToolCallContentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FileSearchToolDefinition : Azure.AI.Agents.Persistent.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.FileSearchToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FileSearchToolDefinition>
    {
        public FileSearchToolDefinition() { }
        public Azure.AI.Agents.Persistent.FileSearchToolDefinitionDetails FileSearch { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.FileSearchToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.FileSearchToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.FileSearchToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.FileSearchToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FileSearchToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FileSearchToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FileSearchToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSearchToolDefinitionDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.FileSearchToolDefinitionDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FileSearchToolDefinitionDetails>
    {
        public FileSearchToolDefinitionDetails() { }
        public int? MaxNumResults { get { throw null; } set { } }
        public Azure.AI.Agents.Persistent.FileSearchRankingOptions RankingOptions { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.FileSearchToolDefinitionDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.FileSearchToolDefinitionDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.FileSearchToolDefinitionDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.FileSearchToolDefinitionDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FileSearchToolDefinitionDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FileSearchToolDefinitionDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FileSearchToolDefinitionDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSearchToolResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.FileSearchToolResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FileSearchToolResource>
    {
        public FileSearchToolResource() { }
        public FileSearchToolResource(System.Collections.Generic.IList<string> vectorStoreIds, System.Collections.Generic.IList<Azure.AI.Agents.Persistent.VectorStoreConfigurations> vectorStores) { }
        public System.Collections.Generic.IList<string> VectorStoreIds { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Agents.Persistent.VectorStoreConfigurations> VectorStores { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.FileSearchToolResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.FileSearchToolResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.FileSearchToolResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.FileSearchToolResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FileSearchToolResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FileSearchToolResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FileSearchToolResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileState : System.IEquatable<Azure.AI.Agents.Persistent.FileState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileState(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.FileState Deleted { get { throw null; } }
        public static Azure.AI.Agents.Persistent.FileState Deleting { get { throw null; } }
        public static Azure.AI.Agents.Persistent.FileState Error { get { throw null; } }
        public static Azure.AI.Agents.Persistent.FileState Pending { get { throw null; } }
        public static Azure.AI.Agents.Persistent.FileState Processed { get { throw null; } }
        public static Azure.AI.Agents.Persistent.FileState Running { get { throw null; } }
        public static Azure.AI.Agents.Persistent.FileState Uploaded { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.FileState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.FileState left, Azure.AI.Agents.Persistent.FileState right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.FileState (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.FileState left, Azure.AI.Agents.Persistent.FileState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FunctionArgument : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.FunctionArgument>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FunctionArgument>
    {
        internal FunctionArgument() { }
        public string Description { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.FunctionArgument System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.FunctionArgument>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.FunctionArgument>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.FunctionArgument System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FunctionArgument>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FunctionArgument>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FunctionArgument>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FunctionToolDefinition : Azure.AI.Agents.Persistent.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.FunctionToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FunctionToolDefinition>
    {
        public FunctionToolDefinition(string name, string description) { }
        public FunctionToolDefinition(string name, string description, System.BinaryData parameters) { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static bool operator ==(Azure.AI.Agents.Persistent.FunctionToolDefinition functionToolDefinition, Azure.AI.Agents.Persistent.RequiredFunctionToolCall functionToolCall) { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.FunctionToolDefinition functionToolDefinition, Azure.AI.Agents.Persistent.RunStepFunctionToolCall functionToolCall) { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.RequiredFunctionToolCall functionToolCall, Azure.AI.Agents.Persistent.FunctionToolDefinition functionToolDefinition) { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.RunStepFunctionToolCall functionToolCall, Azure.AI.Agents.Persistent.FunctionToolDefinition functionToolDefinition) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.FunctionToolDefinition functionToolDefinition, Azure.AI.Agents.Persistent.RequiredFunctionToolCall functionToolCall) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.FunctionToolDefinition functionToolDefinition, Azure.AI.Agents.Persistent.RunStepFunctionToolCall functionToolCall) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.RequiredFunctionToolCall functionToolCall, Azure.AI.Agents.Persistent.FunctionToolDefinition functionToolDefinition) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.RunStepFunctionToolCall functionToolCall, Azure.AI.Agents.Persistent.FunctionToolDefinition functionToolDefinition) { throw null; }
        Azure.AI.Agents.Persistent.FunctionToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.FunctionToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.FunctionToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.FunctionToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FunctionToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FunctionToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.FunctionToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageDetailLevel : System.IEquatable<Azure.AI.Agents.Persistent.ImageDetailLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageDetailLevel(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.ImageDetailLevel Auto { get { throw null; } }
        public static Azure.AI.Agents.Persistent.ImageDetailLevel High { get { throw null; } }
        public static Azure.AI.Agents.Persistent.ImageDetailLevel Low { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.ImageDetailLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.ImageDetailLevel left, Azure.AI.Agents.Persistent.ImageDetailLevel right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.ImageDetailLevel (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.ImageDetailLevel left, Azure.AI.Agents.Persistent.ImageDetailLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IncompleteDetailsReason : System.IEquatable<Azure.AI.Agents.Persistent.IncompleteDetailsReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IncompleteDetailsReason(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.IncompleteDetailsReason MaxCompletionTokens { get { throw null; } }
        public static Azure.AI.Agents.Persistent.IncompleteDetailsReason MaxPromptTokens { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.IncompleteDetailsReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.IncompleteDetailsReason left, Azure.AI.Agents.Persistent.IncompleteDetailsReason right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.IncompleteDetailsReason (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.IncompleteDetailsReason left, Azure.AI.Agents.Persistent.IncompleteDetailsReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IncompleteRunDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.IncompleteRunDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.IncompleteRunDetails>
    {
        internal IncompleteRunDetails() { }
        public Azure.AI.Agents.Persistent.IncompleteDetailsReason Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.IncompleteRunDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.IncompleteRunDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.IncompleteRunDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.IncompleteRunDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.IncompleteRunDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.IncompleteRunDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.IncompleteRunDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyPressAction : Azure.AI.Agents.Persistent.ComputerUseAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.KeyPressAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.KeyPressAction>
    {
        internal KeyPressAction() { }
        public System.Collections.Generic.IReadOnlyList<string> Keys { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.KeyPressAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.KeyPressAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.KeyPressAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.KeyPressAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.KeyPressAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.KeyPressAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.KeyPressAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ListSortOrder : System.IEquatable<Azure.AI.Agents.Persistent.ListSortOrder>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ListSortOrder(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.ListSortOrder Ascending { get { throw null; } }
        public static Azure.AI.Agents.Persistent.ListSortOrder Descending { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.ListSortOrder other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.ListSortOrder left, Azure.AI.Agents.Persistent.ListSortOrder right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.ListSortOrder (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.ListSortOrder left, Azure.AI.Agents.Persistent.ListSortOrder right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MCPApproval
    {
        public MCPApproval(Azure.AI.Agents.Persistent.MCPApprovalPerTool perToolApproval) { }
        public MCPApproval(string trust) { }
        public bool AlwaysRequireApproval { get { throw null; } }
        public bool NeverRequireApproval { get { throw null; } }
        public Azure.AI.Agents.Persistent.MCPApprovalPerTool PerToolApproval { get { throw null; } }
    }
    public partial class MCPApprovalPerTool : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MCPApprovalPerTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MCPApprovalPerTool>
    {
        public MCPApprovalPerTool() { }
        public Azure.AI.Agents.Persistent.MCPToolList Always { get { throw null; } set { } }
        public Azure.AI.Agents.Persistent.MCPToolList Never { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MCPApprovalPerTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MCPApprovalPerTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MCPApprovalPerTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MCPApprovalPerTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MCPApprovalPerTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MCPApprovalPerTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MCPApprovalPerTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MCPToolDefinition : Azure.AI.Agents.Persistent.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MCPToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MCPToolDefinition>
    {
        public MCPToolDefinition(string serverLabel, string serverUrl) { }
        public System.Collections.Generic.IList<string> AllowedTools { get { throw null; } }
        public string ServerLabel { get { throw null; } set { } }
        public string ServerUrl { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MCPToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MCPToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MCPToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MCPToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MCPToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MCPToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MCPToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MCPToolList : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MCPToolList>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MCPToolList>
    {
        public MCPToolList(System.Collections.Generic.IEnumerable<string> toolNames) { }
        public System.Collections.Generic.IList<string> ToolNames { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MCPToolList System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MCPToolList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MCPToolList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MCPToolList System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MCPToolList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MCPToolList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MCPToolList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MCPToolResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MCPToolResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MCPToolResource>
    {
        public MCPToolResource(string serverLabel) { }
        public MCPToolResource(string serverLabel, System.Collections.Generic.IDictionary<string, string> headers) { }
        public System.Collections.Generic.IDictionary<string, string> Headers { get { throw null; } }
        public Azure.AI.Agents.Persistent.MCPApproval RequireApproval { get { throw null; } set { } }
        public string ServerLabel { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MCPToolResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MCPToolResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MCPToolResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MCPToolResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MCPToolResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MCPToolResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MCPToolResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public Azure.AI.Agents.Persistent.ToolResources ToToolResources() { throw null; }
        public void UpdateHeader(string key, string value) { }
    }
    public partial class MessageAttachment : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageAttachment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageAttachment>
    {
        public MessageAttachment(Azure.AI.Agents.Persistent.VectorStoreDataSource ds, System.Collections.Generic.List<Azure.AI.Agents.Persistent.ToolDefinition> tools) { }
        public MessageAttachment(System.Collections.Generic.IEnumerable<System.BinaryData> tools) { }
        public MessageAttachment(string fileId, System.Collections.Generic.List<Azure.AI.Agents.Persistent.ToolDefinition> tools) { }
        public Azure.AI.Agents.Persistent.VectorStoreDataSource DataSource { get { throw null; } set { } }
        public string FileId { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> Tools { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageAttachment System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageAttachment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageAttachment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageAttachment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageAttachment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageAttachment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageAttachment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MessageContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageContent>
    {
        protected MessageContent() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageContentUpdate : Azure.AI.Agents.Persistent.StreamingUpdate
    {
        internal MessageContentUpdate() { }
        public string ImageFileId { get { throw null; } }
        public string MessageId { get { throw null; } }
        public int MessageIndex { get { throw null; } }
        public Azure.AI.Agents.Persistent.MessageRole? Role { get { throw null; } }
        public string Text { get { throw null; } }
        public Azure.AI.Agents.Persistent.TextAnnotationUpdate TextAnnotation { get { throw null; } }
    }
    public partial class MessageDelta : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDelta>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDelta>
    {
        internal MessageDelta() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.Persistent.MessageDeltaContent> Content { get { throw null; } }
        public Azure.AI.Agents.Persistent.MessageRole Role { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageDelta System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDelta>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDelta>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageDelta System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDelta>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDelta>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDelta>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaChunk : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaChunk>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaChunk>
    {
        internal MessageDeltaChunk() { }
        public Azure.AI.Agents.Persistent.MessageDelta Delta { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Agents.Persistent.MessageDeltaChunkObject Object { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageDeltaChunk System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaChunk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaChunk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageDeltaChunk System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaChunk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaChunk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaChunk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageDeltaChunkObject : System.IEquatable<Azure.AI.Agents.Persistent.MessageDeltaChunkObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageDeltaChunkObject(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageDeltaChunkObject ThreadMessageDelta { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.MessageDeltaChunkObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.MessageDeltaChunkObject left, Azure.AI.Agents.Persistent.MessageDeltaChunkObject right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.MessageDeltaChunkObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.MessageDeltaChunkObject left, Azure.AI.Agents.Persistent.MessageDeltaChunkObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class MessageDeltaContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaContent>
    {
        protected MessageDeltaContent(int index) { }
        public int Index { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageDeltaContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageDeltaContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaImageFileContent : Azure.AI.Agents.Persistent.MessageDeltaContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaImageFileContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaImageFileContent>
    {
        internal MessageDeltaImageFileContent() : base (default(int)) { }
        public Azure.AI.Agents.Persistent.MessageDeltaImageFileContentObject ImageFile { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageDeltaImageFileContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaImageFileContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaImageFileContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageDeltaImageFileContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaImageFileContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaImageFileContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaImageFileContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaImageFileContentObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaImageFileContentObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaImageFileContentObject>
    {
        internal MessageDeltaImageFileContentObject() { }
        public string FileId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageDeltaImageFileContentObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaImageFileContentObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaImageFileContentObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageDeltaImageFileContentObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaImageFileContentObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaImageFileContentObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaImageFileContentObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MessageDeltaTextAnnotation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaTextAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextAnnotation>
    {
        protected internal System.Collections.Generic.IDictionary<string, System.BinaryData> SerializedAdditionalRawData;
        protected MessageDeltaTextAnnotation(int index) { }
        public int Index { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageDeltaTextAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaTextAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaTextAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageDeltaTextAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextContent : Azure.AI.Agents.Persistent.MessageDeltaContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaTextContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextContent>
    {
        internal MessageDeltaTextContent() : base (default(int)) { }
        public Azure.AI.Agents.Persistent.MessageDeltaTextContentObject Text { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageDeltaTextContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaTextContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaTextContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageDeltaTextContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextContentObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaTextContentObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextContentObject>
    {
        internal MessageDeltaTextContentObject() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.Persistent.MessageDeltaTextAnnotation> Annotations { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageDeltaTextContentObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaTextContentObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaTextContentObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageDeltaTextContentObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextContentObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextContentObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextContentObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextFileCitationAnnotation : Azure.AI.Agents.Persistent.MessageDeltaTextAnnotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaTextFileCitationAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextFileCitationAnnotation>
    {
        internal MessageDeltaTextFileCitationAnnotation() : base (default(int)) { }
        public int? EndIndex { get { throw null; } }
        public Azure.AI.Agents.Persistent.MessageDeltaTextFileCitationAnnotationObject FileCitation { get { throw null; } }
        public int? StartIndex { get { throw null; } }
        public string Text { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageDeltaTextFileCitationAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaTextFileCitationAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaTextFileCitationAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageDeltaTextFileCitationAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextFileCitationAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextFileCitationAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextFileCitationAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextFileCitationAnnotationObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaTextFileCitationAnnotationObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextFileCitationAnnotationObject>
    {
        internal MessageDeltaTextFileCitationAnnotationObject() { }
        public string FileId { get { throw null; } }
        public string Quote { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageDeltaTextFileCitationAnnotationObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaTextFileCitationAnnotationObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaTextFileCitationAnnotationObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageDeltaTextFileCitationAnnotationObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextFileCitationAnnotationObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextFileCitationAnnotationObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextFileCitationAnnotationObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextFilePathAnnotation : Azure.AI.Agents.Persistent.MessageDeltaTextAnnotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaTextFilePathAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextFilePathAnnotation>
    {
        internal MessageDeltaTextFilePathAnnotation() : base (default(int)) { }
        public int? EndIndex { get { throw null; } }
        public Azure.AI.Agents.Persistent.MessageDeltaTextFilePathAnnotationObject FilePath { get { throw null; } }
        public int? StartIndex { get { throw null; } }
        public string Text { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageDeltaTextFilePathAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaTextFilePathAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaTextFilePathAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageDeltaTextFilePathAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextFilePathAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextFilePathAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextFilePathAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextFilePathAnnotationObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaTextFilePathAnnotationObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextFilePathAnnotationObject>
    {
        internal MessageDeltaTextFilePathAnnotationObject() { }
        public string FileId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageDeltaTextFilePathAnnotationObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaTextFilePathAnnotationObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaTextFilePathAnnotationObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageDeltaTextFilePathAnnotationObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextFilePathAnnotationObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextFilePathAnnotationObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextFilePathAnnotationObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextUriCitationAnnotation : Azure.AI.Agents.Persistent.MessageDeltaTextAnnotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaTextUriCitationAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextUriCitationAnnotation>
    {
        internal MessageDeltaTextUriCitationAnnotation() : base (default(int)) { }
        public int? EndIndex { get { throw null; } }
        public int? StartIndex { get { throw null; } }
        public Azure.AI.Agents.Persistent.MessageDeltaTextUriCitationDetails UriCitation { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageDeltaTextUriCitationAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaTextUriCitationAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaTextUriCitationAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageDeltaTextUriCitationAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextUriCitationAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextUriCitationAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextUriCitationAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextUriCitationDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaTextUriCitationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextUriCitationDetails>
    {
        internal MessageDeltaTextUriCitationDetails() { }
        public string Title { get { throw null; } }
        public string Uri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageDeltaTextUriCitationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaTextUriCitationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageDeltaTextUriCitationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageDeltaTextUriCitationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextUriCitationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextUriCitationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageDeltaTextUriCitationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageImageFileContent : Azure.AI.Agents.Persistent.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageImageFileContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageImageFileContent>
    {
        internal MessageImageFileContent() { }
        public string FileId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageImageFileContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageImageFileContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageImageFileContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageImageFileContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageImageFileContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageImageFileContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageImageFileContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageImageFileParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageImageFileParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageImageFileParam>
    {
        public MessageImageFileParam(string fileId) { }
        public Azure.AI.Agents.Persistent.ImageDetailLevel? Detail { get { throw null; } set { } }
        public string FileId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageImageFileParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageImageFileParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageImageFileParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageImageFileParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageImageFileParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageImageFileParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageImageFileParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageImageUriParam : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageImageUriParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageImageUriParam>
    {
        public MessageImageUriParam(string uri) { }
        public Azure.AI.Agents.Persistent.ImageDetailLevel? Detail { get { throw null; } set { } }
        public string Uri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageImageUriParam System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageImageUriParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageImageUriParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageImageUriParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageImageUriParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageImageUriParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageImageUriParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageIncompleteDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageIncompleteDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageIncompleteDetails>
    {
        internal MessageIncompleteDetails() { }
        public Azure.AI.Agents.Persistent.MessageIncompleteDetailsReason Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageIncompleteDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageIncompleteDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageIncompleteDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageIncompleteDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageIncompleteDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageIncompleteDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageIncompleteDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageIncompleteDetailsReason : System.IEquatable<Azure.AI.Agents.Persistent.MessageIncompleteDetailsReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageIncompleteDetailsReason(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageIncompleteDetailsReason ContentFilter { get { throw null; } }
        public static Azure.AI.Agents.Persistent.MessageIncompleteDetailsReason MaxTokens { get { throw null; } }
        public static Azure.AI.Agents.Persistent.MessageIncompleteDetailsReason RunCancelled { get { throw null; } }
        public static Azure.AI.Agents.Persistent.MessageIncompleteDetailsReason RunExpired { get { throw null; } }
        public static Azure.AI.Agents.Persistent.MessageIncompleteDetailsReason RunFailed { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.MessageIncompleteDetailsReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.MessageIncompleteDetailsReason left, Azure.AI.Agents.Persistent.MessageIncompleteDetailsReason right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.MessageIncompleteDetailsReason (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.MessageIncompleteDetailsReason left, Azure.AI.Agents.Persistent.MessageIncompleteDetailsReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class MessageInputContentBlock : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageInputContentBlock>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageInputContentBlock>
    {
        protected MessageInputContentBlock() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageInputContentBlock System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageInputContentBlock>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageInputContentBlock>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageInputContentBlock System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageInputContentBlock>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageInputContentBlock>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageInputContentBlock>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageInputImageFileBlock : Azure.AI.Agents.Persistent.MessageInputContentBlock, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageInputImageFileBlock>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageInputImageFileBlock>
    {
        public MessageInputImageFileBlock(Azure.AI.Agents.Persistent.MessageImageFileParam imageFile) { }
        public Azure.AI.Agents.Persistent.MessageImageFileParam ImageFile { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageInputImageFileBlock System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageInputImageFileBlock>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageInputImageFileBlock>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageInputImageFileBlock System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageInputImageFileBlock>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageInputImageFileBlock>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageInputImageFileBlock>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageInputImageUriBlock : Azure.AI.Agents.Persistent.MessageInputContentBlock, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageInputImageUriBlock>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageInputImageUriBlock>
    {
        public MessageInputImageUriBlock(Azure.AI.Agents.Persistent.MessageImageUriParam imageUrl) { }
        public Azure.AI.Agents.Persistent.MessageImageUriParam ImageUrl { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageInputImageUriBlock System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageInputImageUriBlock>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageInputImageUriBlock>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageInputImageUriBlock System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageInputImageUriBlock>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageInputImageUriBlock>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageInputImageUriBlock>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageInputTextBlock : Azure.AI.Agents.Persistent.MessageInputContentBlock, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageInputTextBlock>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageInputTextBlock>
    {
        public MessageInputTextBlock(string text) { }
        public string Text { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageInputTextBlock System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageInputTextBlock>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageInputTextBlock>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageInputTextBlock System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageInputTextBlock>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageInputTextBlock>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageInputTextBlock>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageRole : System.IEquatable<Azure.AI.Agents.Persistent.MessageRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageRole(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageRole Agent { get { throw null; } }
        public static Azure.AI.Agents.Persistent.MessageRole User { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.MessageRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.MessageRole left, Azure.AI.Agents.Persistent.MessageRole right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.MessageRole (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.MessageRole left, Azure.AI.Agents.Persistent.MessageRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageStatus : System.IEquatable<Azure.AI.Agents.Persistent.MessageStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageStatus(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageStatus Completed { get { throw null; } }
        public static Azure.AI.Agents.Persistent.MessageStatus Incomplete { get { throw null; } }
        public static Azure.AI.Agents.Persistent.MessageStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.MessageStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.MessageStatus left, Azure.AI.Agents.Persistent.MessageStatus right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.MessageStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.MessageStatus left, Azure.AI.Agents.Persistent.MessageStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MessageStatusUpdate : Azure.AI.Agents.Persistent.StreamingUpdate<Azure.AI.Agents.Persistent.PersistentThreadMessage>
    {
        internal MessageStatusUpdate() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageStreamEvent : System.IEquatable<Azure.AI.Agents.Persistent.MessageStreamEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageStreamEvent(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageStreamEvent MessageCompleted { get { throw null; } }
        public static Azure.AI.Agents.Persistent.MessageStreamEvent MessageCreated { get { throw null; } }
        public static Azure.AI.Agents.Persistent.MessageStreamEvent MessageDelta { get { throw null; } }
        public static Azure.AI.Agents.Persistent.MessageStreamEvent MessageIncomplete { get { throw null; } }
        public static Azure.AI.Agents.Persistent.MessageStreamEvent MessageInProgress { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.MessageStreamEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.MessageStreamEvent left, Azure.AI.Agents.Persistent.MessageStreamEvent right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.MessageStreamEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.MessageStreamEvent left, Azure.AI.Agents.Persistent.MessageStreamEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class MessageTextAnnotation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageTextAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageTextAnnotation>
    {
        protected MessageTextAnnotation(string text) { }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageTextAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageTextAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageTextAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageTextAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageTextAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageTextAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageTextAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTextContent : Azure.AI.Agents.Persistent.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageTextContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageTextContent>
    {
        internal MessageTextContent() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.Persistent.MessageTextAnnotation> Annotations { get { throw null; } }
        public string Text { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageTextContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageTextContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageTextContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageTextContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageTextContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageTextContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageTextContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTextFileCitationAnnotation : Azure.AI.Agents.Persistent.MessageTextAnnotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageTextFileCitationAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageTextFileCitationAnnotation>
    {
        internal MessageTextFileCitationAnnotation() : base (default(string)) { }
        public int? EndIndex { get { throw null; } }
        public string FileId { get { throw null; } }
        public string Quote { get { throw null; } }
        public int? StartIndex { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageTextFileCitationAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageTextFileCitationAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageTextFileCitationAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageTextFileCitationAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageTextFileCitationAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageTextFileCitationAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageTextFileCitationAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTextFilePathAnnotation : Azure.AI.Agents.Persistent.MessageTextAnnotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageTextFilePathAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageTextFilePathAnnotation>
    {
        internal MessageTextFilePathAnnotation() : base (default(string)) { }
        public int? EndIndex { get { throw null; } }
        public string FileId { get { throw null; } }
        public int? StartIndex { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageTextFilePathAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageTextFilePathAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageTextFilePathAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageTextFilePathAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageTextFilePathAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageTextFilePathAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageTextFilePathAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTextUriCitationAnnotation : Azure.AI.Agents.Persistent.MessageTextAnnotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageTextUriCitationAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageTextUriCitationAnnotation>
    {
        internal MessageTextUriCitationAnnotation() : base (default(string)) { }
        public int? EndIndex { get { throw null; } }
        public int? StartIndex { get { throw null; } }
        public Azure.AI.Agents.Persistent.MessageTextUriCitationDetails UriCitation { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageTextUriCitationAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageTextUriCitationAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageTextUriCitationAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageTextUriCitationAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageTextUriCitationAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageTextUriCitationAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageTextUriCitationAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTextUriCitationDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageTextUriCitationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageTextUriCitationDetails>
    {
        internal MessageTextUriCitationDetails() { }
        public string Title { get { throw null; } }
        public string Uri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageTextUriCitationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageTextUriCitationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MessageTextUriCitationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MessageTextUriCitationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageTextUriCitationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageTextUriCitationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MessageTextUriCitationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MicrosoftFabricToolDefinition : Azure.AI.Agents.Persistent.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MicrosoftFabricToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MicrosoftFabricToolDefinition>
    {
        public MicrosoftFabricToolDefinition(Azure.AI.Agents.Persistent.FabricDataAgentToolParameters fabricDataagent) { }
        public Azure.AI.Agents.Persistent.FabricDataAgentToolParameters FabricDataagent { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MicrosoftFabricToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MicrosoftFabricToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MicrosoftFabricToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MicrosoftFabricToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MicrosoftFabricToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MicrosoftFabricToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MicrosoftFabricToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MouseButton : System.IEquatable<Azure.AI.Agents.Persistent.MouseButton>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MouseButton(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.MouseButton Back { get { throw null; } }
        public static Azure.AI.Agents.Persistent.MouseButton Forward { get { throw null; } }
        public static Azure.AI.Agents.Persistent.MouseButton Left { get { throw null; } }
        public static Azure.AI.Agents.Persistent.MouseButton Right { get { throw null; } }
        public static Azure.AI.Agents.Persistent.MouseButton Wheel { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.MouseButton other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.MouseButton left, Azure.AI.Agents.Persistent.MouseButton right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.MouseButton (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.MouseButton left, Azure.AI.Agents.Persistent.MouseButton right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MoveAction : Azure.AI.Agents.Persistent.ComputerUseAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MoveAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MoveAction>
    {
        internal MoveAction() { }
        public int X { get { throw null; } }
        public int Y { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MoveAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MoveAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.MoveAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.MoveAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MoveAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MoveAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.MoveAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiAnonymousAuthDetails : Azure.AI.Agents.Persistent.OpenApiAuthDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.OpenApiAnonymousAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiAnonymousAuthDetails>
    {
        public OpenApiAnonymousAuthDetails() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.OpenApiAnonymousAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.OpenApiAnonymousAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.OpenApiAnonymousAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.OpenApiAnonymousAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiAnonymousAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiAnonymousAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiAnonymousAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class OpenApiAuthDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.OpenApiAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiAuthDetails>
    {
        protected OpenApiAuthDetails() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.OpenApiAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.OpenApiAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.OpenApiAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.OpenApiAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiConnectionAuthDetails : Azure.AI.Agents.Persistent.OpenApiAuthDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.OpenApiConnectionAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiConnectionAuthDetails>
    {
        public OpenApiConnectionAuthDetails(Azure.AI.Agents.Persistent.OpenApiConnectionSecurityScheme securityScheme) { }
        public Azure.AI.Agents.Persistent.OpenApiConnectionSecurityScheme SecurityScheme { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.OpenApiConnectionAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.OpenApiConnectionAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.OpenApiConnectionAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.OpenApiConnectionAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiConnectionAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiConnectionAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiConnectionAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiConnectionSecurityScheme : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.OpenApiConnectionSecurityScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiConnectionSecurityScheme>
    {
        public OpenApiConnectionSecurityScheme(string connectionId) { }
        public string ConnectionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.OpenApiConnectionSecurityScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.OpenApiConnectionSecurityScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.OpenApiConnectionSecurityScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.OpenApiConnectionSecurityScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiConnectionSecurityScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiConnectionSecurityScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiConnectionSecurityScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiFunctionDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.OpenApiFunctionDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiFunctionDefinition>
    {
        public OpenApiFunctionDefinition(string name, System.BinaryData spec, Azure.AI.Agents.Persistent.OpenApiAuthDetails openApiAuthentication) { }
        public System.Collections.Generic.IList<string> DefaultParams { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.AI.Agents.Persistent.OpenApiAuthDetails OpenApiAuthentication { get { throw null; } set { } }
        public System.BinaryData Spec { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.OpenApiFunctionDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.OpenApiFunctionDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.OpenApiFunctionDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.OpenApiFunctionDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiFunctionDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiFunctionDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiFunctionDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiManagedAuthDetails : Azure.AI.Agents.Persistent.OpenApiAuthDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.OpenApiManagedAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiManagedAuthDetails>
    {
        public OpenApiManagedAuthDetails(Azure.AI.Agents.Persistent.OpenApiManagedSecurityScheme securityScheme) { }
        public Azure.AI.Agents.Persistent.OpenApiManagedSecurityScheme SecurityScheme { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.OpenApiManagedAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.OpenApiManagedAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.OpenApiManagedAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.OpenApiManagedAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiManagedAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiManagedAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiManagedAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiManagedSecurityScheme : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.OpenApiManagedSecurityScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiManagedSecurityScheme>
    {
        public OpenApiManagedSecurityScheme(string audience) { }
        public string Audience { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.OpenApiManagedSecurityScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.OpenApiManagedSecurityScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.OpenApiManagedSecurityScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.OpenApiManagedSecurityScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiManagedSecurityScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiManagedSecurityScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiManagedSecurityScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiToolDefinition : Azure.AI.Agents.Persistent.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.OpenApiToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiToolDefinition>
    {
        public OpenApiToolDefinition(Azure.AI.Agents.Persistent.OpenApiFunctionDefinition openapi) { }
        public OpenApiToolDefinition(string name, string description, System.BinaryData spec, Azure.AI.Agents.Persistent.OpenApiAuthDetails openApiAuthentication, System.Collections.Generic.IList<string> defaultParams = null) { }
        public Azure.AI.Agents.Persistent.OpenApiFunctionDefinition Openapi { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.OpenApiToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.OpenApiToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.OpenApiToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.OpenApiToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.OpenApiToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PersistentAgent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.PersistentAgent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentAgent>
    {
        internal PersistentAgent() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Instructions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string Model { get { throw null; } }
        public string Name { get { throw null; } }
        public System.BinaryData ResponseFormat { get { throw null; } }
        public float? Temperature { get { throw null; } }
        public Azure.AI.Agents.Persistent.ToolResources ToolResources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.Persistent.ToolDefinition> Tools { get { throw null; } }
        public float? TopP { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.PersistentAgent System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.PersistentAgent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.PersistentAgent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.PersistentAgent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentAgent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentAgent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentAgent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PersistentAgentFileInfo : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.PersistentAgentFileInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentAgentFileInfo>
    {
        internal PersistentAgentFileInfo() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Filename { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Agents.Persistent.PersistentAgentFilePurpose Purpose { get { throw null; } }
        public int Size { get { throw null; } }
        public Azure.AI.Agents.Persistent.FileState? Status { get { throw null; } }
        public string StatusDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.PersistentAgentFileInfo System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.PersistentAgentFileInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.PersistentAgentFileInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.PersistentAgentFileInfo System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentAgentFileInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentAgentFileInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentAgentFileInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PersistentAgentFilePurpose : System.IEquatable<Azure.AI.Agents.Persistent.PersistentAgentFilePurpose>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PersistentAgentFilePurpose(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.PersistentAgentFilePurpose Agents { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentFilePurpose AgentsOutput { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentFilePurpose Vision { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.PersistentAgentFilePurpose other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.PersistentAgentFilePurpose left, Azure.AI.Agents.Persistent.PersistentAgentFilePurpose right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.PersistentAgentFilePurpose (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.PersistentAgentFilePurpose left, Azure.AI.Agents.Persistent.PersistentAgentFilePurpose right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PersistentAgentsAdministrationClient
    {
        protected PersistentAgentsAdministrationClient() { }
        public PersistentAgentsAdministrationClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public PersistentAgentsAdministrationClient(string endpoint, Azure.Core.TokenCredential credential, Azure.AI.Agents.Persistent.PersistentAgentsAdministrationClientOptions options) { }
        public PersistentAgentsAdministrationClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public PersistentAgentsAdministrationClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.Agents.Persistent.PersistentAgentsAdministrationClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response CreateAgent(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.PersistentAgent> CreateAgent(string model, string name = null, string description = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ToolDefinition> tools = null, Azure.AI.Agents.Persistent.ToolResources toolResources = null, float? temperature = default(float?), float? topP = default(float?), System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAgentAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.PersistentAgent>> CreateAgentAsync(string model, string name = null, string description = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ToolDefinition> tools = null, Azure.AI.Agents.Persistent.ToolResources toolResources = null, float? temperature = default(float?), float? topP = default(float?), System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> DeleteAgent(string agentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteAgentAsync(string agentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetAgent(string agentId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.PersistentAgent> GetAgent(string assistantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAgentAsync(string agentId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.PersistentAgent>> GetAgentAsync(string assistantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Agents.Persistent.PersistentAgent> GetAgents(int? limit = default(int?), Azure.AI.Agents.Persistent.ListSortOrder? order = default(Azure.AI.Agents.Persistent.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Agents.Persistent.PersistentAgent> GetAgentsAsync(int? limit = default(int?), Azure.AI.Agents.Persistent.ListSortOrder? order = default(Azure.AI.Agents.Persistent.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response UpdateAgent(string assistantId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.PersistentAgent> UpdateAgent(string assistantId, string model = null, string name = null, string description = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ToolDefinition> tools = null, Azure.AI.Agents.Persistent.ToolResources toolResources = null, float? temperature = default(float?), float? topP = default(float?), System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAgentAsync(string assistantId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.PersistentAgent>> UpdateAgentAsync(string assistantId, string model = null, string name = null, string description = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ToolDefinition> tools = null, Azure.AI.Agents.Persistent.ToolResources toolResources = null, float? temperature = default(float?), float? topP = default(float?), System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PersistentAgentsAdministrationClientOptions : Azure.Core.ClientOptions
    {
        public PersistentAgentsAdministrationClientOptions(Azure.AI.Agents.Persistent.PersistentAgentsAdministrationClientOptions.ServiceVersion version = Azure.AI.Agents.Persistent.PersistentAgentsAdministrationClientOptions.ServiceVersion.V2025_05_15_Preview) { }
        public enum ServiceVersion
        {
            V2025_05_01 = 1,
            V1 = 2,
            V2025_05_15_Preview = 3,
        }
    }
    public partial class PersistentAgentsClient
    {
        protected PersistentAgentsClient() { }
        public PersistentAgentsClient(string endpoint, Azure.Core.TokenCredential credential) { }
        public PersistentAgentsClient(string endpoint, Azure.Core.TokenCredential credential, Azure.AI.Agents.Persistent.PersistentAgentsAdministrationClientOptions options) { }
        public Azure.AI.Agents.Persistent.PersistentAgentsAdministrationClient Administration { get { throw null; } }
        public Azure.AI.Agents.Persistent.PersistentAgentsFiles Files { get { throw null; } }
        public Azure.AI.Agents.Persistent.ThreadMessages Messages { get { throw null; } }
        public Azure.AI.Agents.Persistent.ThreadRuns Runs { get { throw null; } }
        public Azure.AI.Agents.Persistent.Threads Threads { get { throw null; } }
        public Azure.AI.Agents.Persistent.VectorStores VectorStores { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.ThreadRun> CreateThreadAndRun(string assistantId, Azure.AI.Agents.Persistent.ThreadAndRunOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.ThreadRun>> CreateThreadAndRunAsync(string assistantId, Azure.AI.Agents.Persistent.ThreadAndRunOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class PersistentAgentsClientExtensions
    {
        public static Microsoft.Extensions.AI.IChatClient AsIChatClient(this Azure.AI.Agents.Persistent.PersistentAgentsClient client, string agentId, string? defaultThreadId = null) { throw null; }
    }
    public static partial class PersistentAgentsExtensions
    {
        public static Azure.AI.Agents.Persistent.PersistentAgentsClient GetPersistentAgentsClient(this System.ClientModel.Primitives.ClientConnectionProvider provider) { throw null; }
    }
    public partial class PersistentAgentsFiles
    {
        protected PersistentAgentsFiles() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<bool> DeleteFile(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteFileAsync(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetFile(string fileId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.PersistentAgentFileInfo> GetFile(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetFileAsync(string fileId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.PersistentAgentFileInfo>> GetFileAsync(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetFileContent(string fileId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetFileContent(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetFileContentAsync(string fileId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetFileContentAsync(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.Persistent.PersistentAgentFileInfo>> GetFiles(Azure.AI.Agents.Persistent.PersistentAgentFilePurpose? purpose = default(Azure.AI.Agents.Persistent.PersistentAgentFilePurpose?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.Persistent.PersistentAgentFileInfo>>> GetFilesAsync(Azure.AI.Agents.Persistent.PersistentAgentFilePurpose? purpose = default(Azure.AI.Agents.Persistent.PersistentAgentFilePurpose?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UploadFile(Azure.Core.RequestContent content, string contentType, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.PersistentAgentFileInfo> UploadFile(System.IO.Stream data, Azure.AI.Agents.Persistent.PersistentAgentFilePurpose purpose, string filename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.PersistentAgentFileInfo> UploadFile(string filePath, Azure.AI.Agents.Persistent.PersistentAgentFilePurpose purpose, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadFileAsync(Azure.Core.RequestContent content, string contentType, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.PersistentAgentFileInfo>> UploadFileAsync(System.IO.Stream data, Azure.AI.Agents.Persistent.PersistentAgentFilePurpose purpose, string filename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.PersistentAgentFileInfo>> UploadFileAsync(string filePath, Azure.AI.Agents.Persistent.PersistentAgentFilePurpose purpose, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PersistentAgentsFunctionName : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.PersistentAgentsFunctionName>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentAgentsFunctionName>
    {
        public PersistentAgentsFunctionName(string name) { }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.PersistentAgentsFunctionName System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.PersistentAgentsFunctionName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.PersistentAgentsFunctionName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.PersistentAgentsFunctionName System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentAgentsFunctionName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentAgentsFunctionName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentAgentsFunctionName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class PersistentAgentsModelFactory
    {
        public static Azure.AI.Agents.Persistent.ActivityFunctionDefinition ActivityFunctionDefinition(string description = null, Azure.AI.Agents.Persistent.ActivityFunctionParameters parameters = null) { throw null; }
        public static Azure.AI.Agents.Persistent.ActivityFunctionParameters ActivityFunctionParameters(Azure.AI.Agents.Persistent.ActivityFunctionParametersType type = default(Azure.AI.Agents.Persistent.ActivityFunctionParametersType), System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Agents.Persistent.FunctionArgument> properties = null, System.Collections.Generic.IEnumerable<string> required = null, bool? additionalProperties = default(bool?)) { throw null; }
        public static Azure.AI.Agents.Persistent.AISearchIndexResource AISearchIndexResource(string indexConnectionId = null, string indexName = null, Azure.AI.Agents.Persistent.AzureAISearchQueryType? queryType = default(Azure.AI.Agents.Persistent.AzureAISearchQueryType?), int? topK = default(int?), string filter = null, string indexAssetId = null) { throw null; }
        public static Azure.AI.Agents.Persistent.AzureFunctionBinding AzureFunctionBinding(Azure.AI.Agents.Persistent.AzureFunctionBindingType type = default(Azure.AI.Agents.Persistent.AzureFunctionBindingType), Azure.AI.Agents.Persistent.AzureFunctionStorageQueue storageQueue = null) { throw null; }
        public static Azure.AI.Agents.Persistent.AzureFunctionToolCallDetails AzureFunctionToolCallDetails(string name = null, string arguments = null, string output = null) { throw null; }
        public static Azure.AI.Agents.Persistent.BrowserAutomationToolCallDetails BrowserAutomationToolCallDetails(string input = null, string output = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.BrowserAutomationToolCallStep> steps = null) { throw null; }
        public static Azure.AI.Agents.Persistent.BrowserAutomationToolCallStep BrowserAutomationToolCallStep(string lastStepResult = null, string currentState = null, string nextStep = null) { throw null; }
        public static Azure.AI.Agents.Persistent.ClickAction ClickAction(int x = 0, int y = 0, Azure.AI.Agents.Persistent.MouseButton button = default(Azure.AI.Agents.Persistent.MouseButton)) { throw null; }
        public static Azure.AI.Agents.Persistent.ComputerScreenshot ComputerScreenshot(Azure.AI.Agents.Persistent.ComputerScreenshotType type = default(Azure.AI.Agents.Persistent.ComputerScreenshotType), string fileId = null, string imageUrl = null) { throw null; }
        public static Azure.AI.Agents.Persistent.ComputerToolOutput ComputerToolOutput(string toolCallId = null, Azure.AI.Agents.Persistent.ComputerScreenshot output = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.SafetyCheck> acknowledgedSafetyChecks = null) { throw null; }
        public static Azure.AI.Agents.Persistent.CoordinatePoint CoordinatePoint(int x = 0, int y = 0) { throw null; }
        public static Azure.AI.Agents.Persistent.DoubleClickAction DoubleClickAction(int x = 0, int y = 0) { throw null; }
        public static Azure.AI.Agents.Persistent.DragAction DragAction(System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.CoordinatePoint> path = null) { throw null; }
        public static Azure.AI.Agents.Persistent.FileSearchToolCallContent FileSearchToolCallContent(Azure.AI.Agents.Persistent.FileSearchToolCallContentType type = default(Azure.AI.Agents.Persistent.FileSearchToolCallContentType), string text = null) { throw null; }
        public static Azure.AI.Agents.Persistent.FunctionArgument FunctionArgument(string type = null, string description = null) { throw null; }
        public static Azure.AI.Agents.Persistent.IncompleteRunDetails IncompleteRunDetails(Azure.AI.Agents.Persistent.IncompleteDetailsReason reason = default(Azure.AI.Agents.Persistent.IncompleteDetailsReason)) { throw null; }
        public static Azure.AI.Agents.Persistent.KeyPressAction KeyPressAction(System.Collections.Generic.IEnumerable<string> keys = null) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageDelta MessageDelta(Azure.AI.Agents.Persistent.MessageRole role = default(Azure.AI.Agents.Persistent.MessageRole), System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.MessageDeltaContent> content = null) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageDeltaChunk MessageDeltaChunk(string id = null, Azure.AI.Agents.Persistent.MessageDeltaChunkObject @object = default(Azure.AI.Agents.Persistent.MessageDeltaChunkObject), Azure.AI.Agents.Persistent.MessageDelta delta = null) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageDeltaContent MessageDeltaContent(int index = 0, string type = null) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageDeltaImageFileContent MessageDeltaImageFileContent(int index = 0, Azure.AI.Agents.Persistent.MessageDeltaImageFileContentObject imageFile = null) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageDeltaImageFileContentObject MessageDeltaImageFileContentObject(string fileId = null) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageDeltaTextAnnotation MessageDeltaTextAnnotation(int index = 0, string type = null) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageDeltaTextContent MessageDeltaTextContent(int index = 0, Azure.AI.Agents.Persistent.MessageDeltaTextContentObject text = null) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageDeltaTextContentObject MessageDeltaTextContentObject(string value = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.MessageDeltaTextAnnotation> annotations = null) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageDeltaTextFileCitationAnnotation MessageDeltaTextFileCitationAnnotation(int index = 0, Azure.AI.Agents.Persistent.MessageDeltaTextFileCitationAnnotationObject fileCitation = null, string text = null, int? startIndex = default(int?), int? endIndex = default(int?)) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageDeltaTextFileCitationAnnotationObject MessageDeltaTextFileCitationAnnotationObject(string fileId = null, string quote = null) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageDeltaTextFilePathAnnotation MessageDeltaTextFilePathAnnotation(int index = 0, Azure.AI.Agents.Persistent.MessageDeltaTextFilePathAnnotationObject filePath = null, int? startIndex = default(int?), int? endIndex = default(int?), string text = null) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageDeltaTextFilePathAnnotationObject MessageDeltaTextFilePathAnnotationObject(string fileId = null) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageDeltaTextUriCitationAnnotation MessageDeltaTextUriCitationAnnotation(int index = 0, Azure.AI.Agents.Persistent.MessageDeltaTextUriCitationDetails uriCitation = null, int? startIndex = default(int?), int? endIndex = default(int?)) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageDeltaTextUriCitationDetails MessageDeltaTextUriCitationDetails(string uri = null, string title = null) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageTextFileCitationAnnotation MessageFileCitationTextAnnotation(string text, string fileId, string quote) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageTextFilePathAnnotation MessageFilePathTextAnnotation(string text, string fileId) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageImageFileContent MessageImageFileContent(string fileId) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageImageFileParam MessageImageFileParam(string fileId = null, Azure.AI.Agents.Persistent.ImageDetailLevel? detail = default(Azure.AI.Agents.Persistent.ImageDetailLevel?)) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageImageUriParam MessageImageUriParam(string uri = null, Azure.AI.Agents.Persistent.ImageDetailLevel? detail = default(Azure.AI.Agents.Persistent.ImageDetailLevel?)) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageIncompleteDetails MessageIncompleteDetails(Azure.AI.Agents.Persistent.MessageIncompleteDetailsReason reason = default(Azure.AI.Agents.Persistent.MessageIncompleteDetailsReason)) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageInputImageFileBlock MessageInputImageFileBlock(Azure.AI.Agents.Persistent.MessageImageFileParam imageFile = null) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageInputImageUriBlock MessageInputImageUriBlock(Azure.AI.Agents.Persistent.MessageImageUriParam imageUrl = null) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageInputTextBlock MessageInputTextBlock(string text = null) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageTextAnnotation MessageTextAnnotation(string type = null, string text = null) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageTextContent MessageTextContent(string text, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.MessageTextAnnotation> annotations) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageTextUriCitationAnnotation MessageTextUriCitationAnnotation(string text = null, Azure.AI.Agents.Persistent.MessageTextUriCitationDetails uriCitation = null, int? startIndex = default(int?), int? endIndex = default(int?)) { throw null; }
        public static Azure.AI.Agents.Persistent.MessageTextUriCitationDetails MessageTextUriCitationDetails(string uri = null, string title = null) { throw null; }
        public static Azure.AI.Agents.Persistent.MoveAction MoveAction(int x = 0, int y = 0) { throw null; }
        public static Azure.AI.Agents.Persistent.PersistentAgent PersistentAgent(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), string name = null, string description = null, string model = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ToolDefinition> tools = null, Azure.AI.Agents.Persistent.ToolResources toolResources = null, float? temperature = default(float?), float? topP = default(float?), System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Agents.Persistent.PersistentAgentFileInfo PersistentAgentFile(string id = null, int size = 0, string filename = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), Azure.AI.Agents.Persistent.PersistentAgentFilePurpose purpose = default(Azure.AI.Agents.Persistent.PersistentAgentFilePurpose)) { throw null; }
        public static Azure.AI.Agents.Persistent.PersistentAgentsVectorStore PersistentAgentsVectorStore(string id = null, Azure.AI.Agents.Persistent.PersistentAgentsVectorStoreObject @object = default(Azure.AI.Agents.Persistent.PersistentAgentsVectorStoreObject), System.DateTimeOffset createdAt = default(System.DateTimeOffset), string name = null, int usageBytes = 0, Azure.AI.Agents.Persistent.VectorStoreFileCount fileCounts = null, Azure.AI.Agents.Persistent.VectorStoreStatus status = default(Azure.AI.Agents.Persistent.VectorStoreStatus), Azure.AI.Agents.Persistent.VectorStoreExpirationPolicy expiresAfter = null, System.DateTimeOffset? expiresAt = default(System.DateTimeOffset?), System.DateTimeOffset? lastActiveAt = default(System.DateTimeOffset?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Agents.Persistent.PersistentAgentThread PersistentAgentThread(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), Azure.AI.Agents.Persistent.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RequiredComputerUseToolCall RequiredComputerUseToolCall(string id = null, Azure.AI.Agents.Persistent.RequiredComputerUseToolCallDetails computerUsePreview = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RequiredComputerUseToolCallDetails RequiredComputerUseToolCallDetails(Azure.AI.Agents.Persistent.ComputerUseAction action = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.SafetyCheck> pendingSafetyChecks = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RequiredFunctionToolCall RequiredFunctionToolCall(string toolCallId, string functionName, string functionArguments) { throw null; }
        public static Azure.AI.Agents.Persistent.RequiredMcpToolCall RequiredMcpToolCall(string id = null, string arguments = null, string name = null, string serverLabel = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RequiredToolCall RequiredToolCall(string type = null, string id = null) { throw null; }
        public static Azure.AI.Agents.Persistent.ResponseFormatJsonSchemaType ResponseFormatJsonSchemaType(Azure.AI.Agents.Persistent.ResponseFormatJsonSchemaTypeType type = default(Azure.AI.Agents.Persistent.ResponseFormatJsonSchemaTypeType), Azure.AI.Agents.Persistent.ResponseFormatJsonSchema jsonSchema = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunCompletionUsage RunCompletionUsage(long completionTokens = (long)0, long promptTokens = (long)0, long totalTokens = (long)0) { throw null; }
        public static Azure.AI.Agents.Persistent.RunError RunError(string code = null, string message = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStep RunStep(string id = null, Azure.AI.Agents.Persistent.RunStepType type = default(Azure.AI.Agents.Persistent.RunStepType), string agentId = null, string threadId = null, string runId = null, Azure.AI.Agents.Persistent.RunStepStatus status = default(Azure.AI.Agents.Persistent.RunStepStatus), Azure.AI.Agents.Persistent.RunStepDetails stepDetails = null, Azure.AI.Agents.Persistent.RunStepError lastError = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset? expiredAt = default(System.DateTimeOffset?), System.DateTimeOffset? completedAt = default(System.DateTimeOffset?), System.DateTimeOffset? cancelledAt = default(System.DateTimeOffset?), System.DateTimeOffset? failedAt = default(System.DateTimeOffset?), Azure.AI.Agents.Persistent.RunStepCompletionUsage usage = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepActivityDetails RunStepActivityDetails(System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.RunStepDetailsActivity> activities = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepAzureAISearchToolCall RunStepAzureAISearchToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> azureAISearch = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepAzureFunctionToolCall RunStepAzureFunctionToolCall(string id = null, Azure.AI.Agents.Persistent.AzureFunctionToolCallDetails azureFunction = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepBingCustomSearchToolCall RunStepBingCustomSearchToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> bingCustomSearch = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepBingGroundingToolCall RunStepBingGroundingToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> bingGrounding = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepBrowserAutomationToolCall RunStepBrowserAutomationToolCall(string id = null, Azure.AI.Agents.Persistent.BrowserAutomationToolCallDetails browserAutomation = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepCodeInterpreterImageOutput RunStepCodeInterpreterImageOutput(Azure.AI.Agents.Persistent.RunStepCodeInterpreterImageReference image = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepCodeInterpreterImageReference RunStepCodeInterpreterImageReference(string fileId = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepCodeInterpreterLogOutput RunStepCodeInterpreterLogOutput(string logs = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepCodeInterpreterToolCall RunStepCodeInterpreterToolCall(string id, string input, System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.Persistent.RunStepCodeInterpreterToolCallOutput> outputs) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepCompletionUsage RunStepCompletionUsage(long completionTokens = (long)0, long promptTokens = (long)0, long totalTokens = (long)0) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepComputerUseToolCall RunStepComputerUseToolCall(string id = null, Azure.AI.Agents.Persistent.RunStepComputerUseToolCallDetails computerUsePreview = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepComputerUseToolCallDetails RunStepComputerUseToolCallDetails(Azure.AI.Agents.Persistent.ComputerUseAction action = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.SafetyCheck> pendingSafetyChecks = null, Azure.AI.Agents.Persistent.ComputerScreenshot output = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.SafetyCheck> acknowledgedSafetyChecks = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepConnectedAgent RunStepConnectedAgent(string name = null, string arguments = null, string output = null, string runId = null, string threadId = null, string agentId = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepConnectedAgentToolCall RunStepConnectedAgentToolCall(string id = null, Azure.AI.Agents.Persistent.RunStepConnectedAgent connectedAgent = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeepResearchToolCall RunStepDeepResearchToolCall(string id = null, Azure.AI.Agents.Persistent.RunStepDeepResearchToolCallDetails deepResearch = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeepResearchToolCallDetails RunStepDeepResearchToolCallDetails(string input = null, string output = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDelta RunStepDelta(Azure.AI.Agents.Persistent.RunStepDeltaDetail stepDetails = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeltaAzureAISearchToolCall RunStepDeltaAzureAISearchToolCall(int index = 0, string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> azureAISearch = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeltaAzureFunctionToolCall RunStepDeltaAzureFunctionToolCall(int index = 0, string id = null, Azure.AI.Agents.Persistent.AzureFunctionToolCallDetails azureFunction = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeltaBingGroundingToolCall RunStepDeltaBingGroundingToolCall(int index = 0, string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> bingGrounding = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeltaChunk RunStepDeltaChunk(string id = null, Azure.AI.Agents.Persistent.RunStepDeltaChunkObject @object = default(Azure.AI.Agents.Persistent.RunStepDeltaChunkObject), Azure.AI.Agents.Persistent.RunStepDelta delta = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterDetailItemObject RunStepDeltaCodeInterpreterDetailItemObject(string input = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterOutput> outputs = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterImageOutput RunStepDeltaCodeInterpreterImageOutput(int index = 0, Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterImageOutputObject image = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterImageOutputObject RunStepDeltaCodeInterpreterImageOutputObject(string fileId = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterLogOutput RunStepDeltaCodeInterpreterLogOutput(int index = 0, string logs = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterOutput RunStepDeltaCodeInterpreterOutput(int index = 0, string type = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterToolCall RunStepDeltaCodeInterpreterToolCall(int index = 0, string id = null, Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterDetailItemObject codeInterpreter = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeltaComputerUseDetails RunStepDeltaComputerUseDetails(Azure.AI.Agents.Persistent.ComputerUseAction action = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.SafetyCheck> pendingSafetyChecks = null, Azure.AI.Agents.Persistent.ComputerScreenshot output = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.SafetyCheck> acknowledgedSafetyChecks = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeltaComputerUseToolCall RunStepDeltaComputerUseToolCall(int index = 0, string id = null, Azure.AI.Agents.Persistent.RunStepDeltaComputerUseDetails computerUsePreview = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeltaConnectedAgentToolCall RunStepDeltaConnectedAgentToolCall(int index = 0, string id = null, Azure.AI.Agents.Persistent.RunStepConnectedAgent connectedAgent = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeltaCustomBingGroundingToolCall RunStepDeltaCustomBingGroundingToolCall(int index = 0, string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> bingCustomSearch = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeltaDeepResearchToolCall RunStepDeltaDeepResearchToolCall(int index = 0, string id = null, Azure.AI.Agents.Persistent.RunStepDeepResearchToolCallDetails deepResearch = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeltaFileSearchToolCall RunStepDeltaFileSearchToolCall(int index = 0, string id = null, Azure.AI.Agents.Persistent.RunStepFileSearchToolCallResults fileSearch = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeltaFunction RunStepDeltaFunction(string name = null, string arguments = null, string output = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeltaFunctionToolCall RunStepDeltaFunctionToolCall(int index = 0, string id = null, Azure.AI.Agents.Persistent.RunStepDeltaFunction function = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeltaMCPObject RunStepDeltaMCPObject(System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.RunStepDeltaMcpToolCall> toolCalls = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeltaMcpToolCall RunStepDeltaMcpToolCall(int index = 0, string id = null, string arguments = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeltaMessageCreation RunStepDeltaMessageCreation(Azure.AI.Agents.Persistent.RunStepDeltaMessageCreationObject messageCreation = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeltaMessageCreationObject RunStepDeltaMessageCreationObject(string messageId = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeltaMicrosoftFabricToolCall RunStepDeltaMicrosoftFabricToolCall(int index = 0, string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> microsoftFabric = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeltaOpenAPIObject RunStepDeltaOpenAPIObject(System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.RunStepDeltaOpenAPIToolCall> toolCalls = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeltaOpenAPIToolCall RunStepDeltaOpenAPIToolCall(int index = 0, string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> openAPI = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeltaSharepointToolCall RunStepDeltaSharepointToolCall(int index = 0, string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> sharepointGrounding = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeltaToolCall RunStepDeltaToolCall(int index = 0, string id = null, string type = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeltaToolCallObject RunStepDeltaToolCallObject(System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.RunStepDeltaToolCall> toolCalls = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDetailsActivity RunStepDetailsActivity(Azure.AI.Agents.Persistent.RunStepDetailsActivityType type = default(Azure.AI.Agents.Persistent.RunStepDetailsActivityType), string id = null, string serverLabel = null, System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Agents.Persistent.ActivityFunctionDefinition> tools = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepError RunStepError(Azure.AI.Agents.Persistent.RunStepErrorCode code = default(Azure.AI.Agents.Persistent.RunStepErrorCode), string message = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepFileSearchToolCall RunStepFileSearchToolCall(string id = null, Azure.AI.Agents.Persistent.RunStepFileSearchToolCallResults fileSearch = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepFileSearchToolCallResult RunStepFileSearchToolCallResult(string fileId = null, string fileName = null, float score = 0f, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.FileSearchToolCallContent> content = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepFileSearchToolCallResults RunStepFileSearchToolCallResults(Azure.AI.Agents.Persistent.FileSearchRankingOptions rankingOptions = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.RunStepFileSearchToolCallResult> results = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepFunctionToolCall RunStepFunctionToolCall(string id, string name, string arguments) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepMcpToolCall RunStepMcpToolCall(string id = null, string arguments = null, string name = null, string output = null, string serverLabel = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepMessageCreationDetails RunStepMessageCreationDetails(Azure.AI.Agents.Persistent.RunStepMessageCreationReference messageCreation = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepMessageCreationReference RunStepMessageCreationReference(string messageId = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepMicrosoftFabricToolCall RunStepMicrosoftFabricToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> microsoftFabric = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepOpenAPIToolCall RunStepOpenAPIToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> openAPI = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepSharepointToolCall RunStepSharepointToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> sharePoint = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepToolCall RunStepToolCall(string type = null, string id = null) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepToolCallDetails RunStepToolCallDetails(System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.RunStepToolCall> toolCalls = null) { throw null; }
        public static Azure.AI.Agents.Persistent.ScrollAction ScrollAction(int x = 0, int y = 0, int scrollX = 0, int scrollY = 0) { throw null; }
        public static Azure.AI.Agents.Persistent.SubmitToolApprovalAction SubmitToolApprovalAction(Azure.AI.Agents.Persistent.SubmitToolApprovalDetails submitToolApproval = null) { throw null; }
        public static Azure.AI.Agents.Persistent.SubmitToolApprovalDetails SubmitToolApprovalDetails(System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.RequiredToolCall> toolCalls = null) { throw null; }
        public static Azure.AI.Agents.Persistent.SubmitToolOutputsAction SubmitToolOutputsAction(System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.RequiredToolCall> toolCalls) { throw null; }
        public static Azure.AI.Agents.Persistent.PersistentThreadMessage ThreadMessage(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), string threadId = null, Azure.AI.Agents.Persistent.MessageStatus status = default(Azure.AI.Agents.Persistent.MessageStatus), Azure.AI.Agents.Persistent.MessageIncompleteDetails incompleteDetails = null, System.DateTimeOffset? completedAt = default(System.DateTimeOffset?), System.DateTimeOffset? incompleteAt = default(System.DateTimeOffset?), Azure.AI.Agents.Persistent.MessageRole role = default(Azure.AI.Agents.Persistent.MessageRole), System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.MessageContent> contentItems = null, string agentId = null, string runId = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.MessageAttachment> attachments = null, System.Collections.Generic.IDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Agents.Persistent.ThreadMessageOptions ThreadMessageOptions(Azure.AI.Agents.Persistent.MessageRole role = default(Azure.AI.Agents.Persistent.MessageRole), System.BinaryData content = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.MessageAttachment> attachments = null, System.Collections.Generic.IDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Agents.Persistent.ThreadRun ThreadRun(string id = null, string threadId = null, string agentId = null, Azure.AI.Agents.Persistent.RunStatus status = default(Azure.AI.Agents.Persistent.RunStatus), Azure.AI.Agents.Persistent.RequiredAction requiredAction = null, Azure.AI.Agents.Persistent.RunError lastError = null, string model = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ToolDefinition> tools = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset? expiresAt = default(System.DateTimeOffset?), System.DateTimeOffset? startedAt = default(System.DateTimeOffset?), System.DateTimeOffset? completedAt = default(System.DateTimeOffset?), System.DateTimeOffset? cancelledAt = default(System.DateTimeOffset?), System.DateTimeOffset? failedAt = default(System.DateTimeOffset?), Azure.AI.Agents.Persistent.IncompleteRunDetails incompleteDetails = null, Azure.AI.Agents.Persistent.RunCompletionUsage usage = null, float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Agents.Persistent.Truncation truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, Azure.AI.Agents.Persistent.ToolResources toolResources = null, bool? parallelToolCalls = default(bool?)) { throw null; }
        public static Azure.AI.Agents.Persistent.ToolApproval ToolApproval(string toolCallId = null, bool approve = false, System.Collections.Generic.IDictionary<string, string> headers = null) { throw null; }
        public static Azure.AI.Agents.Persistent.TypeAction TypeAction(string text = null) { throw null; }
        public static Azure.AI.Agents.Persistent.VectorStoreFile VectorStoreFile(string id = null, Azure.AI.Agents.Persistent.VectorStoreFileObject @object = default(Azure.AI.Agents.Persistent.VectorStoreFileObject), int usageBytes = 0, System.DateTimeOffset createdAt = default(System.DateTimeOffset), string vectorStoreId = null, Azure.AI.Agents.Persistent.VectorStoreFileStatus status = default(Azure.AI.Agents.Persistent.VectorStoreFileStatus), Azure.AI.Agents.Persistent.VectorStoreFileError lastError = null, Azure.AI.Agents.Persistent.VectorStoreChunkingStrategyResponse chunkingStrategy = null) { throw null; }
        public static Azure.AI.Agents.Persistent.VectorStoreFileBatch VectorStoreFileBatch(string id = null, Azure.AI.Agents.Persistent.VectorStoreFileBatchObject @object = default(Azure.AI.Agents.Persistent.VectorStoreFileBatchObject), System.DateTimeOffset createdAt = default(System.DateTimeOffset), string vectorStoreId = null, Azure.AI.Agents.Persistent.VectorStoreFileBatchStatus status = default(Azure.AI.Agents.Persistent.VectorStoreFileBatchStatus), Azure.AI.Agents.Persistent.VectorStoreFileCount fileCounts = null) { throw null; }
        public static Azure.AI.Agents.Persistent.VectorStoreFileCount VectorStoreFileCount(int inProgress = 0, int completed = 0, int failed = 0, int cancelled = 0, int total = 0) { throw null; }
        public static Azure.AI.Agents.Persistent.VectorStoreFileError VectorStoreFileError(Azure.AI.Agents.Persistent.VectorStoreFileErrorCode code = default(Azure.AI.Agents.Persistent.VectorStoreFileErrorCode), string message = null) { throw null; }
        public static Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyRequest VectorStoreStaticChunkingStrategyRequest(Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyOptions @static = null) { throw null; }
        public static Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyResponse VectorStoreStaticChunkingStrategyResponse(Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyOptions @static = null) { throw null; }
    }
    public partial class PersistentAgentsNamedToolChoice : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.PersistentAgentsNamedToolChoice>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentAgentsNamedToolChoice>
    {
        public PersistentAgentsNamedToolChoice(Azure.AI.Agents.Persistent.PersistentAgentsNamedToolChoiceType type) { }
        public Azure.AI.Agents.Persistent.PersistentAgentsFunctionName Function { get { throw null; } set { } }
        public Azure.AI.Agents.Persistent.PersistentAgentsNamedToolChoiceType Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.PersistentAgentsNamedToolChoice System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.PersistentAgentsNamedToolChoice>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.PersistentAgentsNamedToolChoice>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.PersistentAgentsNamedToolChoice System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentAgentsNamedToolChoice>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentAgentsNamedToolChoice>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentAgentsNamedToolChoice>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PersistentAgentsNamedToolChoiceType : System.IEquatable<Azure.AI.Agents.Persistent.PersistentAgentsNamedToolChoiceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PersistentAgentsNamedToolChoiceType(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.PersistentAgentsNamedToolChoiceType AzureAISearch { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentsNamedToolChoiceType BingCustomSearch { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentsNamedToolChoiceType BingGrounding { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentsNamedToolChoiceType CodeInterpreter { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentsNamedToolChoiceType ComputerUsePreview { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentsNamedToolChoiceType ConnectedAgent { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentsNamedToolChoiceType DeepResearch { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentsNamedToolChoiceType FileSearch { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentsNamedToolChoiceType Function { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentsNamedToolChoiceType Mcp { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentsNamedToolChoiceType MicrosoftFabric { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentsNamedToolChoiceType Sharepoint { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.PersistentAgentsNamedToolChoiceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.PersistentAgentsNamedToolChoiceType left, Azure.AI.Agents.Persistent.PersistentAgentsNamedToolChoiceType right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.PersistentAgentsNamedToolChoiceType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.PersistentAgentsNamedToolChoiceType left, Azure.AI.Agents.Persistent.PersistentAgentsNamedToolChoiceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PersistentAgentsResponseFormatMode : System.IEquatable<Azure.AI.Agents.Persistent.PersistentAgentsResponseFormatMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PersistentAgentsResponseFormatMode(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.PersistentAgentsResponseFormatMode Auto { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentsResponseFormatMode None { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.PersistentAgentsResponseFormatMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.PersistentAgentsResponseFormatMode left, Azure.AI.Agents.Persistent.PersistentAgentsResponseFormatMode right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.PersistentAgentsResponseFormatMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.PersistentAgentsResponseFormatMode left, Azure.AI.Agents.Persistent.PersistentAgentsResponseFormatMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PersistentAgentsToolChoiceOptionMode : System.IEquatable<Azure.AI.Agents.Persistent.PersistentAgentsToolChoiceOptionMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PersistentAgentsToolChoiceOptionMode(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.PersistentAgentsToolChoiceOptionMode Auto { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentsToolChoiceOptionMode None { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.PersistentAgentsToolChoiceOptionMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.PersistentAgentsToolChoiceOptionMode left, Azure.AI.Agents.Persistent.PersistentAgentsToolChoiceOptionMode right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.PersistentAgentsToolChoiceOptionMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.PersistentAgentsToolChoiceOptionMode left, Azure.AI.Agents.Persistent.PersistentAgentsToolChoiceOptionMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PersistentAgentStreamEvent : System.IEquatable<Azure.AI.Agents.Persistent.PersistentAgentStreamEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PersistentAgentStreamEvent(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.PersistentAgentStreamEvent Done { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentStreamEvent Error { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentStreamEvent MessageCompleted { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentStreamEvent MessageCreated { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentStreamEvent MessageDelta { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentStreamEvent MessageIncomplete { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentStreamEvent MessageInProgress { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentStreamEvent RunStepCancelled { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentStreamEvent RunStepCompleted { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentStreamEvent RunStepCreated { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentStreamEvent RunStepDelta { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentStreamEvent RunStepExpired { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentStreamEvent RunStepFailed { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentStreamEvent RunStepInProgress { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentStreamEvent ThreadCreated { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentStreamEvent ThreadRunCancelled { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentStreamEvent ThreadRunCancelling { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentStreamEvent ThreadRunCompleted { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentStreamEvent ThreadRunCreated { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentStreamEvent ThreadRunExpired { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentStreamEvent ThreadRunFailed { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentStreamEvent ThreadRunIncomplete { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentStreamEvent ThreadRunInProgress { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentStreamEvent ThreadRunQueued { get { throw null; } }
        public static Azure.AI.Agents.Persistent.PersistentAgentStreamEvent ThreadRunRequiresAction { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.PersistentAgentStreamEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.PersistentAgentStreamEvent left, Azure.AI.Agents.Persistent.PersistentAgentStreamEvent right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.PersistentAgentStreamEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.PersistentAgentStreamEvent left, Azure.AI.Agents.Persistent.PersistentAgentStreamEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PersistentAgentsVectorStore : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.PersistentAgentsVectorStore>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentAgentsVectorStore>
    {
        internal PersistentAgentsVectorStore() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public Azure.AI.Agents.Persistent.VectorStoreExpirationPolicy ExpiresAfter { get { throw null; } }
        public System.DateTimeOffset? ExpiresAt { get { throw null; } }
        public Azure.AI.Agents.Persistent.VectorStoreFileCount FileCounts { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastActiveAt { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Agents.Persistent.PersistentAgentsVectorStoreObject Object { get { throw null; } }
        public Azure.AI.Agents.Persistent.VectorStoreStatus Status { get { throw null; } }
        public int UsageBytes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.PersistentAgentsVectorStore System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.PersistentAgentsVectorStore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.PersistentAgentsVectorStore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.PersistentAgentsVectorStore System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentAgentsVectorStore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentAgentsVectorStore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentAgentsVectorStore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PersistentAgentsVectorStoreObject : System.IEquatable<Azure.AI.Agents.Persistent.PersistentAgentsVectorStoreObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PersistentAgentsVectorStoreObject(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.PersistentAgentsVectorStoreObject VectorStore { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.PersistentAgentsVectorStoreObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.PersistentAgentsVectorStoreObject left, Azure.AI.Agents.Persistent.PersistentAgentsVectorStoreObject right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.PersistentAgentsVectorStoreObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.PersistentAgentsVectorStoreObject left, Azure.AI.Agents.Persistent.PersistentAgentsVectorStoreObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PersistentAgentThread : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.PersistentAgentThread>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentAgentThread>
    {
        internal PersistentAgentThread() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public Azure.AI.Agents.Persistent.ToolResources ToolResources { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.PersistentAgentThread System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.PersistentAgentThread>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.PersistentAgentThread>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.PersistentAgentThread System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentAgentThread>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentAgentThread>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentAgentThread>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PersistentAgentThreadCreationOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.PersistentAgentThreadCreationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentAgentThreadCreationOptions>
    {
        public PersistentAgentThreadCreationOptions() { }
        public System.Collections.Generic.IList<Azure.AI.Agents.Persistent.ThreadMessageOptions> Messages { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public Azure.AI.Agents.Persistent.ToolResources ToolResources { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.PersistentAgentThreadCreationOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.PersistentAgentThreadCreationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.PersistentAgentThreadCreationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.PersistentAgentThreadCreationOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentAgentThreadCreationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentAgentThreadCreationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentAgentThreadCreationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PersistentThreadMessage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.PersistentThreadMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentThreadMessage>
    {
        internal PersistentThreadMessage() { }
        public string AssistantId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.Persistent.MessageAttachment> Attachments { get { throw null; } }
        public System.DateTimeOffset? CompletedAt { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.Persistent.MessageContent> ContentItems { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? IncompleteAt { get { throw null; } }
        public Azure.AI.Agents.Persistent.MessageIncompleteDetails IncompleteDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public Azure.AI.Agents.Persistent.MessageRole Role { get { throw null; } }
        public string RunId { get { throw null; } }
        public Azure.AI.Agents.Persistent.MessageStatus Status { get { throw null; } }
        public string ThreadId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.PersistentThreadMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.PersistentThreadMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.PersistentThreadMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.PersistentThreadMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentThreadMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentThreadMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.PersistentThreadMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RequiredAction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RequiredAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RequiredAction>
    {
        protected RequiredAction() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RequiredAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RequiredAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RequiredAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RequiredAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RequiredAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RequiredAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RequiredAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RequiredActionUpdate : Azure.AI.Agents.Persistent.RunUpdate
    {
        internal RequiredActionUpdate() { }
        public string FunctionArguments { get { throw null; } }
        public string FunctionName { get { throw null; } }
        public string ToolCallId { get { throw null; } }
        public Azure.AI.Agents.Persistent.ThreadRun GetThreadRun() { throw null; }
    }
    public partial class RequiredComputerUseToolCall : Azure.AI.Agents.Persistent.RequiredToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RequiredComputerUseToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RequiredComputerUseToolCall>
    {
        internal RequiredComputerUseToolCall() : base (default(string)) { }
        public Azure.AI.Agents.Persistent.RequiredComputerUseToolCallDetails ComputerUsePreview { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RequiredComputerUseToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RequiredComputerUseToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RequiredComputerUseToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RequiredComputerUseToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RequiredComputerUseToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RequiredComputerUseToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RequiredComputerUseToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RequiredComputerUseToolCallDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RequiredComputerUseToolCallDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RequiredComputerUseToolCallDetails>
    {
        internal RequiredComputerUseToolCallDetails() { }
        public Azure.AI.Agents.Persistent.ComputerUseAction Action { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.Persistent.SafetyCheck> PendingSafetyChecks { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RequiredComputerUseToolCallDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RequiredComputerUseToolCallDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RequiredComputerUseToolCallDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RequiredComputerUseToolCallDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RequiredComputerUseToolCallDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RequiredComputerUseToolCallDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RequiredComputerUseToolCallDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RequiredFunctionToolCall : Azure.AI.Agents.Persistent.RequiredToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RequiredFunctionToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RequiredFunctionToolCall>
    {
        internal RequiredFunctionToolCall() : base (default(string)) { }
        public string Arguments { get { throw null; } }
        public string Name { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RequiredFunctionToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RequiredFunctionToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RequiredFunctionToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RequiredFunctionToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RequiredFunctionToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RequiredFunctionToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RequiredFunctionToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RequiredMcpToolCall : Azure.AI.Agents.Persistent.RequiredToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RequiredMcpToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RequiredMcpToolCall>
    {
        internal RequiredMcpToolCall() : base (default(string)) { }
        public string Arguments { get { throw null; } }
        public string Name { get { throw null; } }
        public string ServerLabel { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RequiredMcpToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RequiredMcpToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RequiredMcpToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RequiredMcpToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RequiredMcpToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RequiredMcpToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RequiredMcpToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RequiredToolCall : Azure.AI.Agents.Persistent.RequiredAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RequiredToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RequiredToolCall>
    {
        protected RequiredToolCall(string id) { }
        public string Id { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RequiredToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RequiredToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RequiredToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RequiredToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RequiredToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RequiredToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RequiredToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponseFormatJsonSchema : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ResponseFormatJsonSchema>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ResponseFormatJsonSchema>
    {
        public ResponseFormatJsonSchema(string name, System.BinaryData schema) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Schema { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ResponseFormatJsonSchema System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ResponseFormatJsonSchema>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ResponseFormatJsonSchema>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ResponseFormatJsonSchema System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ResponseFormatJsonSchema>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ResponseFormatJsonSchema>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ResponseFormatJsonSchema>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponseFormatJsonSchemaType : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ResponseFormatJsonSchemaType>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ResponseFormatJsonSchemaType>
    {
        public ResponseFormatJsonSchemaType(Azure.AI.Agents.Persistent.ResponseFormatJsonSchema jsonSchema) { }
        public Azure.AI.Agents.Persistent.ResponseFormatJsonSchema JsonSchema { get { throw null; } set { } }
        public Azure.AI.Agents.Persistent.ResponseFormatJsonSchemaTypeType Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ResponseFormatJsonSchemaType System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ResponseFormatJsonSchemaType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ResponseFormatJsonSchemaType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ResponseFormatJsonSchemaType System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ResponseFormatJsonSchemaType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ResponseFormatJsonSchemaType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ResponseFormatJsonSchemaType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResponseFormatJsonSchemaTypeType : System.IEquatable<Azure.AI.Agents.Persistent.ResponseFormatJsonSchemaTypeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResponseFormatJsonSchemaTypeType(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.ResponseFormatJsonSchemaTypeType JsonSchema { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.ResponseFormatJsonSchemaTypeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.ResponseFormatJsonSchemaTypeType left, Azure.AI.Agents.Persistent.ResponseFormatJsonSchemaTypeType right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.ResponseFormatJsonSchemaTypeType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.ResponseFormatJsonSchemaTypeType left, Azure.AI.Agents.Persistent.ResponseFormatJsonSchemaTypeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunAdditionalFieldList : System.IEquatable<Azure.AI.Agents.Persistent.RunAdditionalFieldList>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunAdditionalFieldList(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.RunAdditionalFieldList FileSearchContents { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.RunAdditionalFieldList other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.RunAdditionalFieldList left, Azure.AI.Agents.Persistent.RunAdditionalFieldList right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.RunAdditionalFieldList (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.RunAdditionalFieldList left, Azure.AI.Agents.Persistent.RunAdditionalFieldList right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunCompletionUsage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunCompletionUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunCompletionUsage>
    {
        internal RunCompletionUsage() { }
        public long CompletionTokens { get { throw null; } }
        public long PromptTokens { get { throw null; } }
        public long TotalTokens { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunCompletionUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunCompletionUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunCompletionUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunCompletionUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunCompletionUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunCompletionUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunCompletionUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunError>
    {
        internal RunError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunError System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStatus : System.IEquatable<Azure.AI.Agents.Persistent.RunStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStatus(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStatus Cancelled { get { throw null; } }
        public static Azure.AI.Agents.Persistent.RunStatus Cancelling { get { throw null; } }
        public static Azure.AI.Agents.Persistent.RunStatus Completed { get { throw null; } }
        public static Azure.AI.Agents.Persistent.RunStatus Expired { get { throw null; } }
        public static Azure.AI.Agents.Persistent.RunStatus Failed { get { throw null; } }
        public static Azure.AI.Agents.Persistent.RunStatus InProgress { get { throw null; } }
        public static Azure.AI.Agents.Persistent.RunStatus Queued { get { throw null; } }
        public static Azure.AI.Agents.Persistent.RunStatus RequiresAction { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.RunStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.RunStatus left, Azure.AI.Agents.Persistent.RunStatus right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.RunStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.RunStatus left, Azure.AI.Agents.Persistent.RunStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunStep : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStep>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStep>
    {
        internal RunStep() { }
        public string AssistantId { get { throw null; } }
        public System.DateTimeOffset? CancelledAt { get { throw null; } }
        public System.DateTimeOffset? CompletedAt { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public System.DateTimeOffset? ExpiredAt { get { throw null; } }
        public System.DateTimeOffset? FailedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Agents.Persistent.RunStepError LastError { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string RunId { get { throw null; } }
        public Azure.AI.Agents.Persistent.RunStepStatus Status { get { throw null; } }
        public Azure.AI.Agents.Persistent.RunStepDetails StepDetails { get { throw null; } }
        public string ThreadId { get { throw null; } }
        public Azure.AI.Agents.Persistent.RunStepType Type { get { throw null; } }
        public Azure.AI.Agents.Persistent.RunStepCompletionUsage Usage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStep System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStep System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepActivityDetails : Azure.AI.Agents.Persistent.RunStepDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepActivityDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepActivityDetails>
    {
        internal RunStepActivityDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.Persistent.RunStepDetailsActivity> Activities { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepActivityDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepActivityDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepActivityDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepActivityDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepActivityDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepActivityDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepActivityDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepAzureAISearchToolCall : Azure.AI.Agents.Persistent.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepAzureAISearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepAzureAISearchToolCall>
    {
        internal RunStepAzureAISearchToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> AzureAISearch { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepAzureAISearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepAzureAISearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepAzureAISearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepAzureAISearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepAzureAISearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepAzureAISearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepAzureAISearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepAzureFunctionToolCall : Azure.AI.Agents.Persistent.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepAzureFunctionToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepAzureFunctionToolCall>
    {
        internal RunStepAzureFunctionToolCall() : base (default(string)) { }
        public Azure.AI.Agents.Persistent.AzureFunctionToolCallDetails AzureFunction { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepAzureFunctionToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepAzureFunctionToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepAzureFunctionToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepAzureFunctionToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepAzureFunctionToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepAzureFunctionToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepAzureFunctionToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepBingCustomSearchToolCall : Azure.AI.Agents.Persistent.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepBingCustomSearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepBingCustomSearchToolCall>
    {
        internal RunStepBingCustomSearchToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> BingCustomSearch { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepBingCustomSearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepBingCustomSearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepBingCustomSearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepBingCustomSearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepBingCustomSearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepBingCustomSearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepBingCustomSearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepBingGroundingToolCall : Azure.AI.Agents.Persistent.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepBingGroundingToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepBingGroundingToolCall>
    {
        internal RunStepBingGroundingToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> BingGrounding { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepBingGroundingToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepBingGroundingToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepBingGroundingToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepBingGroundingToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepBingGroundingToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepBingGroundingToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepBingGroundingToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepBrowserAutomationToolCall : Azure.AI.Agents.Persistent.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepBrowserAutomationToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepBrowserAutomationToolCall>
    {
        internal RunStepBrowserAutomationToolCall() : base (default(string)) { }
        public Azure.AI.Agents.Persistent.BrowserAutomationToolCallDetails BrowserAutomation { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepBrowserAutomationToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepBrowserAutomationToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepBrowserAutomationToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepBrowserAutomationToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepBrowserAutomationToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepBrowserAutomationToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepBrowserAutomationToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCodeInterpreterImageOutput : Azure.AI.Agents.Persistent.RunStepCodeInterpreterToolCallOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterImageOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterImageOutput>
    {
        internal RunStepCodeInterpreterImageOutput() { }
        public Azure.AI.Agents.Persistent.RunStepCodeInterpreterImageReference Image { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepCodeInterpreterImageOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterImageOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterImageOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepCodeInterpreterImageOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterImageOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterImageOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterImageOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCodeInterpreterImageReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterImageReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterImageReference>
    {
        internal RunStepCodeInterpreterImageReference() { }
        public string FileId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepCodeInterpreterImageReference System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterImageReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterImageReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepCodeInterpreterImageReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterImageReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterImageReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterImageReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCodeInterpreterLogOutput : Azure.AI.Agents.Persistent.RunStepCodeInterpreterToolCallOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterLogOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterLogOutput>
    {
        internal RunStepCodeInterpreterLogOutput() { }
        public string Logs { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepCodeInterpreterLogOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterLogOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterLogOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepCodeInterpreterLogOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterLogOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterLogOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterLogOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCodeInterpreterToolCall : Azure.AI.Agents.Persistent.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterToolCall>
    {
        internal RunStepCodeInterpreterToolCall() : base (default(string)) { }
        public string Input { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.Persistent.RunStepCodeInterpreterToolCallOutput> Outputs { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepCodeInterpreterToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepCodeInterpreterToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepCodeInterpreterToolCallOutput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterToolCallOutput>
    {
        protected RunStepCodeInterpreterToolCallOutput() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepCodeInterpreterToolCallOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterToolCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterToolCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepCodeInterpreterToolCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterToolCallOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterToolCallOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepCodeInterpreterToolCallOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCompletionUsage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepCompletionUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepCompletionUsage>
    {
        internal RunStepCompletionUsage() { }
        public long CompletionTokens { get { throw null; } }
        public long PromptTokens { get { throw null; } }
        public long TotalTokens { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepCompletionUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepCompletionUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepCompletionUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepCompletionUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepCompletionUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepCompletionUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepCompletionUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepComputerUseToolCall : Azure.AI.Agents.Persistent.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepComputerUseToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepComputerUseToolCall>
    {
        internal RunStepComputerUseToolCall() : base (default(string)) { }
        public Azure.AI.Agents.Persistent.RunStepComputerUseToolCallDetails ComputerUsePreview { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepComputerUseToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepComputerUseToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepComputerUseToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepComputerUseToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepComputerUseToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepComputerUseToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepComputerUseToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepComputerUseToolCallDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepComputerUseToolCallDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepComputerUseToolCallDetails>
    {
        internal RunStepComputerUseToolCallDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.Persistent.SafetyCheck> AcknowledgedSafetyChecks { get { throw null; } }
        public Azure.AI.Agents.Persistent.ComputerUseAction Action { get { throw null; } }
        public Azure.AI.Agents.Persistent.ComputerScreenshot Output { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.Persistent.SafetyCheck> PendingSafetyChecks { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepComputerUseToolCallDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepComputerUseToolCallDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepComputerUseToolCallDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepComputerUseToolCallDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepComputerUseToolCallDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepComputerUseToolCallDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepComputerUseToolCallDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepConnectedAgent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepConnectedAgent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepConnectedAgent>
    {
        internal RunStepConnectedAgent() { }
        public string AgentId { get { throw null; } }
        public string Arguments { get { throw null; } }
        public string Name { get { throw null; } }
        public string Output { get { throw null; } }
        public string RunId { get { throw null; } }
        public string ThreadId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepConnectedAgent System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepConnectedAgent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepConnectedAgent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepConnectedAgent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepConnectedAgent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepConnectedAgent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepConnectedAgent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepConnectedAgentToolCall : Azure.AI.Agents.Persistent.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepConnectedAgentToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepConnectedAgentToolCall>
    {
        internal RunStepConnectedAgentToolCall() : base (default(string)) { }
        public Azure.AI.Agents.Persistent.RunStepConnectedAgent ConnectedAgent { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepConnectedAgentToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepConnectedAgentToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepConnectedAgentToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepConnectedAgentToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepConnectedAgentToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepConnectedAgentToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepConnectedAgentToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeepResearchToolCall : Azure.AI.Agents.Persistent.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeepResearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeepResearchToolCall>
    {
        internal RunStepDeepResearchToolCall() : base (default(string)) { }
        public Azure.AI.Agents.Persistent.RunStepDeepResearchToolCallDetails DeepResearch { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeepResearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeepResearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeepResearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeepResearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeepResearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeepResearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeepResearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeepResearchToolCallDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeepResearchToolCallDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeepResearchToolCallDetails>
    {
        internal RunStepDeepResearchToolCallDetails() { }
        public string Input { get { throw null; } }
        public string Output { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeepResearchToolCallDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeepResearchToolCallDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeepResearchToolCallDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeepResearchToolCallDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeepResearchToolCallDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeepResearchToolCallDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeepResearchToolCallDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDelta : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDelta>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDelta>
    {
        internal RunStepDelta() { }
        public Azure.AI.Agents.Persistent.RunStepDeltaDetail StepDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDelta System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDelta>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDelta>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDelta System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDelta>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDelta>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDelta>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaAzureAISearchToolCall : Azure.AI.Agents.Persistent.RunStepDeltaToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaAzureAISearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaAzureAISearchToolCall>
    {
        internal RunStepDeltaAzureAISearchToolCall() : base (default(int), default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> AzureAISearch { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaAzureAISearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaAzureAISearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaAzureAISearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaAzureAISearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaAzureAISearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaAzureAISearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaAzureAISearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaAzureFunctionToolCall : Azure.AI.Agents.Persistent.RunStepDeltaToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaAzureFunctionToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaAzureFunctionToolCall>
    {
        internal RunStepDeltaAzureFunctionToolCall() : base (default(int), default(string)) { }
        public Azure.AI.Agents.Persistent.AzureFunctionToolCallDetails AzureFunction { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaAzureFunctionToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaAzureFunctionToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaAzureFunctionToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaAzureFunctionToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaAzureFunctionToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaAzureFunctionToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaAzureFunctionToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaBingGroundingToolCall : Azure.AI.Agents.Persistent.RunStepDeltaToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaBingGroundingToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaBingGroundingToolCall>
    {
        internal RunStepDeltaBingGroundingToolCall() : base (default(int), default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> BingGrounding { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaBingGroundingToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaBingGroundingToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaBingGroundingToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaBingGroundingToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaBingGroundingToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaBingGroundingToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaBingGroundingToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaChunk : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaChunk>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaChunk>
    {
        internal RunStepDeltaChunk() { }
        public Azure.AI.Agents.Persistent.RunStepDelta Delta { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Agents.Persistent.RunStepDeltaChunkObject Object { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaChunk System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaChunk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaChunk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaChunk System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaChunk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaChunk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaChunk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepDeltaChunkObject : System.IEquatable<Azure.AI.Agents.Persistent.RunStepDeltaChunkObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepDeltaChunkObject(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDeltaChunkObject ThreadRunStepDelta { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.RunStepDeltaChunkObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.RunStepDeltaChunkObject left, Azure.AI.Agents.Persistent.RunStepDeltaChunkObject right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.RunStepDeltaChunkObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.RunStepDeltaChunkObject left, Azure.AI.Agents.Persistent.RunStepDeltaChunkObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunStepDeltaCodeInterpreterDetailItemObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterDetailItemObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterDetailItemObject>
    {
        internal RunStepDeltaCodeInterpreterDetailItemObject() { }
        public string Input { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterOutput> Outputs { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterDetailItemObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterDetailItemObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterDetailItemObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterDetailItemObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterDetailItemObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterDetailItemObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterDetailItemObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaCodeInterpreterImageOutput : Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterImageOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterImageOutput>
    {
        internal RunStepDeltaCodeInterpreterImageOutput() : base (default(int)) { }
        public Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterImageOutputObject Image { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterImageOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterImageOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterImageOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterImageOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterImageOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterImageOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterImageOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaCodeInterpreterImageOutputObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterImageOutputObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterImageOutputObject>
    {
        internal RunStepDeltaCodeInterpreterImageOutputObject() { }
        public string FileId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterImageOutputObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterImageOutputObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterImageOutputObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterImageOutputObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterImageOutputObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterImageOutputObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterImageOutputObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaCodeInterpreterLogOutput : Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterLogOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterLogOutput>
    {
        internal RunStepDeltaCodeInterpreterLogOutput() : base (default(int)) { }
        public string Logs { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterLogOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterLogOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterLogOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterLogOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterLogOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterLogOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterLogOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepDeltaCodeInterpreterOutput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterOutput>
    {
        protected RunStepDeltaCodeInterpreterOutput(int index) { }
        public int Index { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaCodeInterpreterToolCall : Azure.AI.Agents.Persistent.RunStepDeltaToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterToolCall>
    {
        internal RunStepDeltaCodeInterpreterToolCall() : base (default(int), default(string)) { }
        public Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterDetailItemObject CodeInterpreter { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaComputerUseDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaComputerUseDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaComputerUseDetails>
    {
        internal RunStepDeltaComputerUseDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.Persistent.SafetyCheck> AcknowledgedSafetyChecks { get { throw null; } }
        public Azure.AI.Agents.Persistent.ComputerUseAction Action { get { throw null; } }
        public Azure.AI.Agents.Persistent.ComputerScreenshot Output { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.Persistent.SafetyCheck> PendingSafetyChecks { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaComputerUseDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaComputerUseDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaComputerUseDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaComputerUseDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaComputerUseDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaComputerUseDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaComputerUseDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaComputerUseToolCall : Azure.AI.Agents.Persistent.RunStepDeltaToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaComputerUseToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaComputerUseToolCall>
    {
        internal RunStepDeltaComputerUseToolCall() : base (default(int), default(string)) { }
        public Azure.AI.Agents.Persistent.RunStepDeltaComputerUseDetails ComputerUsePreview { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaComputerUseToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaComputerUseToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaComputerUseToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaComputerUseToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaComputerUseToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaComputerUseToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaComputerUseToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaConnectedAgentToolCall : Azure.AI.Agents.Persistent.RunStepDeltaToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaConnectedAgentToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaConnectedAgentToolCall>
    {
        internal RunStepDeltaConnectedAgentToolCall() : base (default(int), default(string)) { }
        public Azure.AI.Agents.Persistent.RunStepConnectedAgent ConnectedAgent { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaConnectedAgentToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaConnectedAgentToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaConnectedAgentToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaConnectedAgentToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaConnectedAgentToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaConnectedAgentToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaConnectedAgentToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaCustomBingGroundingToolCall : Azure.AI.Agents.Persistent.RunStepDeltaToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaCustomBingGroundingToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaCustomBingGroundingToolCall>
    {
        internal RunStepDeltaCustomBingGroundingToolCall() : base (default(int), default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> BingCustomSearch { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaCustomBingGroundingToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaCustomBingGroundingToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaCustomBingGroundingToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaCustomBingGroundingToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaCustomBingGroundingToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaCustomBingGroundingToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaCustomBingGroundingToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaDeepResearchToolCall : Azure.AI.Agents.Persistent.RunStepDeltaToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaDeepResearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaDeepResearchToolCall>
    {
        internal RunStepDeltaDeepResearchToolCall() : base (default(int), default(string)) { }
        public Azure.AI.Agents.Persistent.RunStepDeepResearchToolCallDetails DeepResearch { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaDeepResearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaDeepResearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaDeepResearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaDeepResearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaDeepResearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaDeepResearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaDeepResearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepDeltaDetail : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaDetail>
    {
        protected RunStepDeltaDetail() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaDetail System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaDetail System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaFileSearchToolCall : Azure.AI.Agents.Persistent.RunStepDeltaToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaFileSearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaFileSearchToolCall>
    {
        internal RunStepDeltaFileSearchToolCall() : base (default(int), default(string)) { }
        public Azure.AI.Agents.Persistent.RunStepFileSearchToolCallResults FileSearch { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaFileSearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaFileSearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaFileSearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaFileSearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaFileSearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaFileSearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaFileSearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaFunction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaFunction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaFunction>
    {
        internal RunStepDeltaFunction() { }
        public string Arguments { get { throw null; } }
        public string Name { get { throw null; } }
        public string Output { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaFunction System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaFunction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaFunction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaFunction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaFunction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaFunction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaFunction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaFunctionToolCall : Azure.AI.Agents.Persistent.RunStepDeltaToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaFunctionToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaFunctionToolCall>
    {
        internal RunStepDeltaFunctionToolCall() : base (default(int), default(string)) { }
        public Azure.AI.Agents.Persistent.RunStepDeltaFunction Function { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaFunctionToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaFunctionToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaFunctionToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaFunctionToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaFunctionToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaFunctionToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaFunctionToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaMCPObject : Azure.AI.Agents.Persistent.RunStepDeltaDetail, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaMCPObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaMCPObject>
    {
        internal RunStepDeltaMCPObject() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.Persistent.RunStepDeltaMcpToolCall> ToolCalls { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaMCPObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaMCPObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaMCPObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaMCPObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaMCPObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaMCPObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaMCPObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaMcpToolCall : Azure.AI.Agents.Persistent.RunStepDeltaToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaMcpToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaMcpToolCall>
    {
        internal RunStepDeltaMcpToolCall() : base (default(int), default(string)) { }
        public string Arguments { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaMcpToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaMcpToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaMcpToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaMcpToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaMcpToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaMcpToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaMcpToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaMessageCreation : Azure.AI.Agents.Persistent.RunStepDeltaDetail, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaMessageCreation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaMessageCreation>
    {
        internal RunStepDeltaMessageCreation() { }
        public Azure.AI.Agents.Persistent.RunStepDeltaMessageCreationObject MessageCreation { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaMessageCreation System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaMessageCreation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaMessageCreation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaMessageCreation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaMessageCreation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaMessageCreation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaMessageCreation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaMessageCreationObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaMessageCreationObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaMessageCreationObject>
    {
        internal RunStepDeltaMessageCreationObject() { }
        public string MessageId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaMessageCreationObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaMessageCreationObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaMessageCreationObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaMessageCreationObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaMessageCreationObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaMessageCreationObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaMessageCreationObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaMicrosoftFabricToolCall : Azure.AI.Agents.Persistent.RunStepDeltaToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaMicrosoftFabricToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaMicrosoftFabricToolCall>
    {
        internal RunStepDeltaMicrosoftFabricToolCall() : base (default(int), default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> MicrosoftFabric { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaMicrosoftFabricToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaMicrosoftFabricToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaMicrosoftFabricToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaMicrosoftFabricToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaMicrosoftFabricToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaMicrosoftFabricToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaMicrosoftFabricToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaOpenAPIObject : Azure.AI.Agents.Persistent.RunStepDeltaDetail, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaOpenAPIObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaOpenAPIObject>
    {
        internal RunStepDeltaOpenAPIObject() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.Persistent.RunStepDeltaOpenAPIToolCall> ToolCalls { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaOpenAPIObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaOpenAPIObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaOpenAPIObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaOpenAPIObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaOpenAPIObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaOpenAPIObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaOpenAPIObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaOpenAPIToolCall : Azure.AI.Agents.Persistent.RunStepDeltaToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaOpenAPIToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaOpenAPIToolCall>
    {
        internal RunStepDeltaOpenAPIToolCall() : base (default(int), default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> OpenAPI { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaOpenAPIToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaOpenAPIToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaOpenAPIToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaOpenAPIToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaOpenAPIToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaOpenAPIToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaOpenAPIToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaSharepointToolCall : Azure.AI.Agents.Persistent.RunStepDeltaToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaSharepointToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaSharepointToolCall>
    {
        internal RunStepDeltaSharepointToolCall() : base (default(int), default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> SharepointGrounding { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaSharepointToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaSharepointToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaSharepointToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaSharepointToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaSharepointToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaSharepointToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaSharepointToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepDeltaToolCall : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaToolCall>
    {
        protected internal System.Collections.Generic.IDictionary<string, System.BinaryData> SerializedAdditionalRawData;
        protected RunStepDeltaToolCall(int index, string id) { }
        public string Id { get { throw null; } }
        public int Index { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaToolCallObject : Azure.AI.Agents.Persistent.RunStepDeltaDetail, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaToolCallObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaToolCallObject>
    {
        internal RunStepDeltaToolCallObject() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.Persistent.RunStepDeltaToolCall> ToolCalls { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaToolCallObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaToolCallObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDeltaToolCallObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDeltaToolCallObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaToolCallObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaToolCallObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDeltaToolCallObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDetails>
    {
        protected RunStepDetails() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDetailsActivity : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDetailsActivity>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDetailsActivity>
    {
        internal RunStepDetailsActivity() { }
        public string Id { get { throw null; } }
        public string ServerLabel { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, Azure.AI.Agents.Persistent.ActivityFunctionDefinition> Tools { get { throw null; } }
        public Azure.AI.Agents.Persistent.RunStepDetailsActivityType Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDetailsActivity System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDetailsActivity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepDetailsActivity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepDetailsActivity System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDetailsActivity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDetailsActivity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepDetailsActivity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepDetailsActivityType : System.IEquatable<Azure.AI.Agents.Persistent.RunStepDetailsActivityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepDetailsActivityType(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepDetailsActivityType McpListTools { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.RunStepDetailsActivityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.RunStepDetailsActivityType left, Azure.AI.Agents.Persistent.RunStepDetailsActivityType right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.RunStepDetailsActivityType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.RunStepDetailsActivityType left, Azure.AI.Agents.Persistent.RunStepDetailsActivityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunStepDetailsUpdate : Azure.AI.Agents.Persistent.StreamingUpdate
    {
        internal RunStepDetailsUpdate() { }
        public string CodeInterpreterInput { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.Persistent.RunStepDeltaCodeInterpreterOutput> CodeInterpreterOutputs { get { throw null; } }
        public string CreatedMessageId { get { throw null; } }
        public string FunctionArguments { get { throw null; } }
        public string FunctionName { get { throw null; } }
        public string FunctionOutput { get { throw null; } }
        public Azure.AI.Agents.Persistent.RunStepDeltaToolCall GetDeltaToolCall { get { throw null; } }
        public string StepId { get { throw null; } }
        public string ToolCallId { get { throw null; } }
        public int? ToolCallIndex { get { throw null; } }
    }
    public partial class RunStepError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepError>
    {
        internal RunStepError() { }
        public Azure.AI.Agents.Persistent.RunStepErrorCode Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepError System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepErrorCode : System.IEquatable<Azure.AI.Agents.Persistent.RunStepErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepErrorCode(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepErrorCode RateLimitExceeded { get { throw null; } }
        public static Azure.AI.Agents.Persistent.RunStepErrorCode ServerError { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.RunStepErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.RunStepErrorCode left, Azure.AI.Agents.Persistent.RunStepErrorCode right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.RunStepErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.RunStepErrorCode left, Azure.AI.Agents.Persistent.RunStepErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunStepFileSearchToolCall : Azure.AI.Agents.Persistent.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepFileSearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepFileSearchToolCall>
    {
        internal RunStepFileSearchToolCall() : base (default(string)) { }
        public Azure.AI.Agents.Persistent.RunStepFileSearchToolCallResults FileSearch { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepFileSearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepFileSearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepFileSearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepFileSearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepFileSearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepFileSearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepFileSearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepFileSearchToolCallResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepFileSearchToolCallResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepFileSearchToolCallResult>
    {
        internal RunStepFileSearchToolCallResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.Persistent.FileSearchToolCallContent> Content { get { throw null; } }
        public string FileId { get { throw null; } }
        public string FileName { get { throw null; } }
        public float Score { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepFileSearchToolCallResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepFileSearchToolCallResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepFileSearchToolCallResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepFileSearchToolCallResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepFileSearchToolCallResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepFileSearchToolCallResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepFileSearchToolCallResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepFileSearchToolCallResults : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepFileSearchToolCallResults>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepFileSearchToolCallResults>
    {
        internal RunStepFileSearchToolCallResults() { }
        public Azure.AI.Agents.Persistent.FileSearchRankingOptions RankingOptions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.Persistent.RunStepFileSearchToolCallResult> Results { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepFileSearchToolCallResults System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepFileSearchToolCallResults>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepFileSearchToolCallResults>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepFileSearchToolCallResults System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepFileSearchToolCallResults>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepFileSearchToolCallResults>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepFileSearchToolCallResults>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepFunctionToolCall : Azure.AI.Agents.Persistent.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepFunctionToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepFunctionToolCall>
    {
        internal RunStepFunctionToolCall() : base (default(string)) { }
        public string Arguments { get { throw null; } }
        public string Name { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepFunctionToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepFunctionToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepFunctionToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepFunctionToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepFunctionToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepFunctionToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepFunctionToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepMcpToolCall : Azure.AI.Agents.Persistent.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepMcpToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepMcpToolCall>
    {
        internal RunStepMcpToolCall() : base (default(string)) { }
        public string Arguments { get { throw null; } }
        public string Name { get { throw null; } }
        public string Output { get { throw null; } }
        public string ServerLabel { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepMcpToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepMcpToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepMcpToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepMcpToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepMcpToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepMcpToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepMcpToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepMessageCreationDetails : Azure.AI.Agents.Persistent.RunStepDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepMessageCreationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepMessageCreationDetails>
    {
        internal RunStepMessageCreationDetails() { }
        public Azure.AI.Agents.Persistent.RunStepMessageCreationReference MessageCreation { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepMessageCreationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepMessageCreationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepMessageCreationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepMessageCreationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepMessageCreationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepMessageCreationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepMessageCreationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepMessageCreationReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepMessageCreationReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepMessageCreationReference>
    {
        internal RunStepMessageCreationReference() { }
        public string MessageId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepMessageCreationReference System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepMessageCreationReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepMessageCreationReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepMessageCreationReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepMessageCreationReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepMessageCreationReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepMessageCreationReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepMicrosoftFabricToolCall : Azure.AI.Agents.Persistent.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepMicrosoftFabricToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepMicrosoftFabricToolCall>
    {
        internal RunStepMicrosoftFabricToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> MicrosoftFabric { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepMicrosoftFabricToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepMicrosoftFabricToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepMicrosoftFabricToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepMicrosoftFabricToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepMicrosoftFabricToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepMicrosoftFabricToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepMicrosoftFabricToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepOpenAPIToolCall : Azure.AI.Agents.Persistent.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepOpenAPIToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepOpenAPIToolCall>
    {
        internal RunStepOpenAPIToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> OpenAPI { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepOpenAPIToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepOpenAPIToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepOpenAPIToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepOpenAPIToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepOpenAPIToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepOpenAPIToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepOpenAPIToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepSharepointToolCall : Azure.AI.Agents.Persistent.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepSharepointToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepSharepointToolCall>
    {
        internal RunStepSharepointToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> SharePoint { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepSharepointToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepSharepointToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepSharepointToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepSharepointToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepSharepointToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepSharepointToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepSharepointToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepStatus : System.IEquatable<Azure.AI.Agents.Persistent.RunStepStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepStatus(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepStatus Cancelled { get { throw null; } }
        public static Azure.AI.Agents.Persistent.RunStepStatus Completed { get { throw null; } }
        public static Azure.AI.Agents.Persistent.RunStepStatus Expired { get { throw null; } }
        public static Azure.AI.Agents.Persistent.RunStepStatus Failed { get { throw null; } }
        public static Azure.AI.Agents.Persistent.RunStepStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.RunStepStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.RunStepStatus left, Azure.AI.Agents.Persistent.RunStepStatus right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.RunStepStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.RunStepStatus left, Azure.AI.Agents.Persistent.RunStepStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepStreamEvent : System.IEquatable<Azure.AI.Agents.Persistent.RunStepStreamEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepStreamEvent(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepStreamEvent RunStepCancelled { get { throw null; } }
        public static Azure.AI.Agents.Persistent.RunStepStreamEvent RunStepCompleted { get { throw null; } }
        public static Azure.AI.Agents.Persistent.RunStepStreamEvent RunStepCreated { get { throw null; } }
        public static Azure.AI.Agents.Persistent.RunStepStreamEvent RunStepDelta { get { throw null; } }
        public static Azure.AI.Agents.Persistent.RunStepStreamEvent RunStepExpired { get { throw null; } }
        public static Azure.AI.Agents.Persistent.RunStepStreamEvent RunStepFailed { get { throw null; } }
        public static Azure.AI.Agents.Persistent.RunStepStreamEvent RunStepInProgress { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.RunStepStreamEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.RunStepStreamEvent left, Azure.AI.Agents.Persistent.RunStepStreamEvent right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.RunStepStreamEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.RunStepStreamEvent left, Azure.AI.Agents.Persistent.RunStepStreamEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class RunStepToolCall : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepToolCall>
    {
        protected RunStepToolCall(string id) { }
        public string Id { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepToolCallDetails : Azure.AI.Agents.Persistent.RunStepDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepToolCallDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepToolCallDetails>
    {
        internal RunStepToolCallDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.Persistent.RunStepToolCall> ToolCalls { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepToolCallDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepToolCallDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.RunStepToolCallDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.RunStepToolCallDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepToolCallDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepToolCallDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.RunStepToolCallDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepType : System.IEquatable<Azure.AI.Agents.Persistent.RunStepType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepType(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStepType Activities { get { throw null; } }
        public static Azure.AI.Agents.Persistent.RunStepType MessageCreation { get { throw null; } }
        public static Azure.AI.Agents.Persistent.RunStepType ToolCalls { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.RunStepType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.RunStepType left, Azure.AI.Agents.Persistent.RunStepType right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.RunStepType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.RunStepType left, Azure.AI.Agents.Persistent.RunStepType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunStepUpdate : Azure.AI.Agents.Persistent.StreamingUpdate<Azure.AI.Agents.Persistent.RunStep>
    {
        internal RunStepUpdate() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStreamEvent : System.IEquatable<Azure.AI.Agents.Persistent.RunStreamEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStreamEvent(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.RunStreamEvent ThreadRunCancelled { get { throw null; } }
        public static Azure.AI.Agents.Persistent.RunStreamEvent ThreadRunCancelling { get { throw null; } }
        public static Azure.AI.Agents.Persistent.RunStreamEvent ThreadRunCompleted { get { throw null; } }
        public static Azure.AI.Agents.Persistent.RunStreamEvent ThreadRunCreated { get { throw null; } }
        public static Azure.AI.Agents.Persistent.RunStreamEvent ThreadRunExpired { get { throw null; } }
        public static Azure.AI.Agents.Persistent.RunStreamEvent ThreadRunFailed { get { throw null; } }
        public static Azure.AI.Agents.Persistent.RunStreamEvent ThreadRunIncomplete { get { throw null; } }
        public static Azure.AI.Agents.Persistent.RunStreamEvent ThreadRunInProgress { get { throw null; } }
        public static Azure.AI.Agents.Persistent.RunStreamEvent ThreadRunQueued { get { throw null; } }
        public static Azure.AI.Agents.Persistent.RunStreamEvent ThreadRunRequiresAction { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.RunStreamEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.RunStreamEvent left, Azure.AI.Agents.Persistent.RunStreamEvent right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.RunStreamEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.RunStreamEvent left, Azure.AI.Agents.Persistent.RunStreamEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunUpdate : Azure.AI.Agents.Persistent.StreamingUpdate<Azure.AI.Agents.Persistent.ThreadRun>
    {
        internal RunUpdate() { }
    }
    public partial class SafetyCheck : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.SafetyCheck>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.SafetyCheck>
    {
        public SafetyCheck(string id) { }
        public string Code { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.SafetyCheck System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.SafetyCheck>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.SafetyCheck>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.SafetyCheck System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.SafetyCheck>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.SafetyCheck>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.SafetyCheck>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScreenshotAction : Azure.AI.Agents.Persistent.ComputerUseAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ScreenshotAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ScreenshotAction>
    {
        internal ScreenshotAction() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ScreenshotAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ScreenshotAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ScreenshotAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ScreenshotAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ScreenshotAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ScreenshotAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ScreenshotAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ScrollAction : Azure.AI.Agents.Persistent.ComputerUseAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ScrollAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ScrollAction>
    {
        internal ScrollAction() { }
        public int ScrollX { get { throw null; } }
        public int ScrollY { get { throw null; } }
        public int X { get { throw null; } }
        public int Y { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ScrollAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ScrollAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ScrollAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ScrollAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ScrollAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ScrollAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ScrollAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharepointGroundingToolParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.SharepointGroundingToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.SharepointGroundingToolParameters>
    {
        public SharepointGroundingToolParameters() { }
        public SharepointGroundingToolParameters(string connectionId) { }
        public System.Collections.Generic.IList<Azure.AI.Agents.Persistent.ToolConnection> ConnectionList { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.SharepointGroundingToolParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.SharepointGroundingToolParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.SharepointGroundingToolParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.SharepointGroundingToolParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.SharepointGroundingToolParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.SharepointGroundingToolParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.SharepointGroundingToolParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharepointToolDefinition : Azure.AI.Agents.Persistent.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.SharepointToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.SharepointToolDefinition>
    {
        public SharepointToolDefinition(Azure.AI.Agents.Persistent.SharepointGroundingToolParameters sharepointGrounding) { }
        public Azure.AI.Agents.Persistent.SharepointGroundingToolParameters SharepointGrounding { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.SharepointToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.SharepointToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.SharepointToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.SharepointToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.SharepointToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.SharepointToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.SharepointToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class StreamingUpdate
    {
        internal StreamingUpdate() { }
        public Azure.AI.Agents.Persistent.StreamingUpdateReason UpdateKind { get { throw null; } }
    }
    public enum StreamingUpdateReason
    {
        Unknown = 0,
        ThreadCreated = 1,
        RunCreated = 2,
        RunQueued = 3,
        RunInProgress = 4,
        RunRequiresAction = 5,
        RunCompleted = 6,
        RunIncomplete = 7,
        RunFailed = 8,
        RunCancelling = 9,
        RunCancelled = 10,
        RunExpired = 11,
        RunStepCreated = 12,
        RunStepInProgress = 13,
        RunStepUpdated = 14,
        RunStepCompleted = 15,
        RunStepFailed = 16,
        RunStepCancelled = 17,
        RunStepExpired = 18,
        MessageCreated = 19,
        MessageInProgress = 20,
        MessageUpdated = 21,
        MessageCompleted = 22,
        MessageFailed = 23,
        Error = 24,
        Done = 25,
    }
    public partial class StreamingUpdate<T> : Azure.AI.Agents.Persistent.StreamingUpdate where T : class
    {
        internal StreamingUpdate() { }
        public T Value { get { throw null; } }
        public static implicit operator T (Azure.AI.Agents.Persistent.StreamingUpdate<T> update) { throw null; }
    }
    public abstract partial class StructuredToolOutput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.StructuredToolOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.StructuredToolOutput>
    {
        protected StructuredToolOutput() { }
        public string ToolCallId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.StructuredToolOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.StructuredToolOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.StructuredToolOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.StructuredToolOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.StructuredToolOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.StructuredToolOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.StructuredToolOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubmitToolApprovalAction : Azure.AI.Agents.Persistent.RequiredAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.SubmitToolApprovalAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.SubmitToolApprovalAction>
    {
        internal SubmitToolApprovalAction() { }
        public Azure.AI.Agents.Persistent.SubmitToolApprovalDetails SubmitToolApproval { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.SubmitToolApprovalAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.SubmitToolApprovalAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.SubmitToolApprovalAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.SubmitToolApprovalAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.SubmitToolApprovalAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.SubmitToolApprovalAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.SubmitToolApprovalAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubmitToolApprovalDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.SubmitToolApprovalDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.SubmitToolApprovalDetails>
    {
        internal SubmitToolApprovalDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.Persistent.RequiredToolCall> ToolCalls { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.SubmitToolApprovalDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.SubmitToolApprovalDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.SubmitToolApprovalDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.SubmitToolApprovalDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.SubmitToolApprovalDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.SubmitToolApprovalDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.SubmitToolApprovalDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubmitToolApprovalUpdate : Azure.AI.Agents.Persistent.RunUpdate
    {
        public SubmitToolApprovalUpdate(Azure.AI.Agents.Persistent.ThreadRun run, Azure.AI.Agents.Persistent.RequiredMcpToolCall mcpToolCall) { }
        public string Arguments { get { throw null; } }
        public string Name { get { throw null; } }
        public string ServerLabel { get { throw null; } }
        public string ToolCallId { get { throw null; } }
    }
    public partial class SubmitToolOutputsAction : Azure.AI.Agents.Persistent.RequiredAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.SubmitToolOutputsAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.SubmitToolOutputsAction>
    {
        internal SubmitToolOutputsAction() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.Persistent.RequiredToolCall> ToolCalls { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.SubmitToolOutputsAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.SubmitToolOutputsAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.SubmitToolOutputsAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.SubmitToolOutputsAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.SubmitToolOutputsAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.SubmitToolOutputsAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.SubmitToolOutputsAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextAnnotationUpdate
    {
        internal TextAnnotationUpdate() { }
        public int ContentIndex { get { throw null; } }
        public int? EndIndex { get { throw null; } }
        public string InputFileId { get { throw null; } }
        public string OutputFileId { get { throw null; } }
        public int? StartIndex { get { throw null; } }
        public string TextToReplace { get { throw null; } }
        public string Title { get { throw null; } }
        public string Url { get { throw null; } }
    }
    public partial class ThreadAndRunOptions
    {
        public ThreadAndRunOptions() { }
        public int? MaxCompletionTokens { get { throw null; } set { } }
        public int? MaxPromptTokens { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } set { } }
        public string OverrideInstructions { get { throw null; } set { } }
        public string OverrideModelName { get { throw null; } set { } }
        public System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ToolDefinition> OverrideTools { get { throw null; } set { } }
        public bool? ParallelToolCalls { get { throw null; } set { } }
        public System.BinaryData ResponseFormat { get { throw null; } set { } }
        public bool? Stream { get { throw null; } set { } }
        public float? Temperature { get { throw null; } set { } }
        public Azure.AI.Agents.Persistent.PersistentAgentThreadCreationOptions ThreadOptions { get { throw null; } set { } }
        public System.BinaryData ToolChoice { get { throw null; } set { } }
        public Azure.AI.Agents.Persistent.ToolResources ToolResources { get { throw null; } set { } }
        public float? TopP { get { throw null; } set { } }
        public Azure.AI.Agents.Persistent.Truncation TruncationStrategy { get { throw null; } set { } }
    }
    public partial class ThreadMessageOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ThreadMessageOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ThreadMessageOptions>
    {
        public ThreadMessageOptions(Azure.AI.Agents.Persistent.MessageRole role, System.BinaryData content) { }
        public ThreadMessageOptions(Azure.AI.Agents.Persistent.MessageRole role, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.MessageInputContentBlock> contentBlocks) { }
        public ThreadMessageOptions(Azure.AI.Agents.Persistent.MessageRole role, string content) { }
        public System.Collections.Generic.IList<Azure.AI.Agents.Persistent.MessageAttachment> Attachments { get { throw null; } set { } }
        public System.BinaryData Content { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public Azure.AI.Agents.Persistent.MessageRole Role { get { throw null; } }
        public System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.MessageInputContentBlock> GetContentBlocks() { throw null; }
        public string GetTextContent() { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ThreadMessageOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ThreadMessageOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ThreadMessageOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ThreadMessageOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ThreadMessageOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ThreadMessageOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ThreadMessageOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreadMessages
    {
        protected ThreadMessages() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.PersistentThreadMessage> CreateMessage(string threadId, Azure.AI.Agents.Persistent.MessageRole role, System.BinaryData content, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.MessageAttachment> attachments = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.PersistentThreadMessage> CreateMessage(string threadId, Azure.AI.Agents.Persistent.MessageRole role, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.MessageInputContentBlock> contentBlocks, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.MessageAttachment> attachments = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.PersistentThreadMessage> CreateMessage(string threadId, Azure.AI.Agents.Persistent.MessageRole role, string content, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.MessageAttachment> attachments = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateMessage(string threadId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.PersistentThreadMessage>> CreateMessageAsync(string threadId, Azure.AI.Agents.Persistent.MessageRole role, System.BinaryData content, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.MessageAttachment> attachments = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.PersistentThreadMessage>> CreateMessageAsync(string threadId, Azure.AI.Agents.Persistent.MessageRole role, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.MessageInputContentBlock> contentBlocks, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.MessageAttachment> attachments = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.PersistentThreadMessage>> CreateMessageAsync(string threadId, Azure.AI.Agents.Persistent.MessageRole role, string content, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.MessageAttachment> attachments = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateMessageAsync(string threadId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<bool> DeleteMessage(string threadId, string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteMessageAsync(string threadId, string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetMessage(string threadId, string messageId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.PersistentThreadMessage> GetMessage(string threadId, string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMessageAsync(string threadId, string messageId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.PersistentThreadMessage>> GetMessageAsync(string threadId, string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Agents.Persistent.PersistentThreadMessage> GetMessages(string threadId, string runId = null, int? limit = default(int?), Azure.AI.Agents.Persistent.ListSortOrder? order = default(Azure.AI.Agents.Persistent.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Agents.Persistent.PersistentThreadMessage> GetMessagesAsync(string threadId, string runId = null, int? limit = default(int?), Azure.AI.Agents.Persistent.ListSortOrder? order = default(Azure.AI.Agents.Persistent.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateMessage(string threadId, string messageId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.PersistentThreadMessage> UpdateMessage(string threadId, string messageId, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateMessageAsync(string threadId, string messageId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.PersistentThreadMessage>> UpdateMessageAsync(string threadId, string messageId, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ThreadRun : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ThreadRun>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ThreadRun>
    {
        internal ThreadRun() { }
        public string AssistantId { get { throw null; } }
        public System.DateTimeOffset? CancelledAt { get { throw null; } }
        public System.DateTimeOffset? CompletedAt { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public System.DateTimeOffset? ExpiresAt { get { throw null; } }
        public System.DateTimeOffset? FailedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Agents.Persistent.IncompleteRunDetails IncompleteDetails { get { throw null; } }
        public string Instructions { get { throw null; } }
        public Azure.AI.Agents.Persistent.RunError LastError { get { throw null; } }
        public int? MaxCompletionTokens { get { throw null; } }
        public int? MaxPromptTokens { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string Model { get { throw null; } }
        public bool ParallelToolCalls { get { throw null; } }
        public Azure.AI.Agents.Persistent.RequiredAction RequiredAction { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.Persistent.RequiredFunctionToolCall> RequiredActions { get { throw null; } }
        public System.BinaryData ResponseFormat { get { throw null; } }
        public System.DateTimeOffset? StartedAt { get { throw null; } }
        public Azure.AI.Agents.Persistent.RunStatus Status { get { throw null; } }
        public float? Temperature { get { throw null; } }
        public string ThreadId { get { throw null; } }
        public System.BinaryData ToolChoice { get { throw null; } }
        public Azure.AI.Agents.Persistent.ToolResources ToolResources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.Persistent.ToolDefinition> Tools { get { throw null; } }
        public float? TopP { get { throw null; } }
        public Azure.AI.Agents.Persistent.Truncation TruncationStrategy { get { throw null; } }
        public Azure.AI.Agents.Persistent.RunCompletionUsage Usage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ThreadRun System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ThreadRun>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ThreadRun>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ThreadRun System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ThreadRun>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ThreadRun>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ThreadRun>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreadRuns
    {
        protected ThreadRuns() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CancelRun(string threadId, string runId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.ThreadRun> CancelRun(string threadId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelRunAsync(string threadId, string runId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.ThreadRun>> CancelRunAsync(string threadId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.ThreadRun> CreateRun(Azure.AI.Agents.Persistent.PersistentAgentThread thread, Azure.AI.Agents.Persistent.PersistentAgent agent, Azure.AI.Agents.Persistent.ToolResources toolResources, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.ThreadRun> CreateRun(Azure.AI.Agents.Persistent.PersistentAgentThread thread, Azure.AI.Agents.Persistent.PersistentAgent agent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateRun(string threadId, Azure.Core.RequestContent content, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.RunAdditionalFieldList> include = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.ThreadRun> CreateRun(string threadId, string assistantId, string overrideModelName = null, string overrideInstructions = null, string additionalInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ThreadMessageOptions> additionalMessages = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ToolDefinition> overrideTools = null, bool? stream = default(bool?), float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Agents.Persistent.Truncation truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, bool? parallelToolCalls = default(bool?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.RunAdditionalFieldList> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.ThreadRun>> CreateRunAsync(Azure.AI.Agents.Persistent.PersistentAgentThread thread, Azure.AI.Agents.Persistent.PersistentAgent agent, Azure.AI.Agents.Persistent.ToolResources toolResources, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.ThreadRun>> CreateRunAsync(Azure.AI.Agents.Persistent.PersistentAgentThread thread, Azure.AI.Agents.Persistent.PersistentAgent agent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateRunAsync(string threadId, Azure.Core.RequestContent content, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.RunAdditionalFieldList> include = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.ThreadRun>> CreateRunAsync(string threadId, string assistantId, string overrideModelName = null, string overrideInstructions = null, string additionalInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ThreadMessageOptions> additionalMessages = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ToolDefinition> overrideTools = null, bool? stream = default(bool?), float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Agents.Persistent.Truncation truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, bool? parallelToolCalls = default(bool?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.RunAdditionalFieldList> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Agents.Persistent.StreamingUpdate> CreateRunStreaming(string threadId, string agentId, Azure.AI.Agents.Persistent.CreateRunStreamingOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Agents.Persistent.StreamingUpdate> CreateRunStreaming(string threadId, string agentId, string overrideModelName = null, string overrideInstructions = null, string additionalInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ThreadMessageOptions> additionalMessages = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ToolDefinition> overrideTools = null, float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Agents.Persistent.Truncation truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, bool? parallelToolCalls = default(bool?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Agents.Persistent.StreamingUpdate> CreateRunStreamingAsync(string threadId, string agentId, Azure.AI.Agents.Persistent.CreateRunStreamingOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Agents.Persistent.StreamingUpdate> CreateRunStreamingAsync(string threadId, string agentId, string overrideModelName = null, string overrideInstructions = null, string additionalInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ThreadMessageOptions> additionalMessages = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ToolDefinition> overrideTools = null, float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Agents.Persistent.Truncation truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, bool? parallelToolCalls = default(bool?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetRun(string threadId, string runId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.ThreadRun> GetRun(string threadId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRunAsync(string threadId, string runId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.ThreadRun>> GetRunAsync(string threadId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Agents.Persistent.ThreadRun> GetRuns(string threadId, int? limit = default(int?), Azure.AI.Agents.Persistent.ListSortOrder? order = default(Azure.AI.Agents.Persistent.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Agents.Persistent.ThreadRun> GetRunsAsync(string threadId, int? limit = default(int?), Azure.AI.Agents.Persistent.ListSortOrder? order = default(Azure.AI.Agents.Persistent.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.RunStep> GetRunStep(string threadId, string runId, string stepId, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.RunAdditionalFieldList> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.RunStep>> GetRunStepAsync(string threadId, string runId, string stepId, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.RunAdditionalFieldList> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Agents.Persistent.RunStep> GetRunSteps(Azure.AI.Agents.Persistent.ThreadRun run, int? limit = default(int?), Azure.AI.Agents.Persistent.ListSortOrder? order = default(Azure.AI.Agents.Persistent.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Agents.Persistent.RunStep> GetRunSteps(string threadId, string runId, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.RunAdditionalFieldList> include = null, int? limit = default(int?), Azure.AI.Agents.Persistent.ListSortOrder? order = default(Azure.AI.Agents.Persistent.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Agents.Persistent.RunStep> GetRunStepsAsync(Azure.AI.Agents.Persistent.ThreadRun run, int? limit = default(int?), Azure.AI.Agents.Persistent.ListSortOrder? order = default(Azure.AI.Agents.Persistent.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Agents.Persistent.RunStep> GetRunStepsAsync(string threadId, string runId, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.RunAdditionalFieldList> include = null, int? limit = default(int?), Azure.AI.Agents.Persistent.ListSortOrder? order = default(Azure.AI.Agents.Persistent.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.ThreadRun> SubmitToolOutputsToRun(Azure.AI.Agents.Persistent.ThreadRun run, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ToolOutput> toolOutputs = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ToolApproval> toolApprovals = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.ThreadRun> SubmitToolOutputsToRun(Azure.AI.Agents.Persistent.ThreadRun run, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ToolOutput> toolOutputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SubmitToolOutputsToRun(string threadId, string runId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.ThreadRun> SubmitToolOutputsToRun(string threadId, string runId, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.StructuredToolOutput> toolOutputs = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ToolApproval> toolApprovals = null, bool? stream = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.ThreadRun>> SubmitToolOutputsToRunAsync(Azure.AI.Agents.Persistent.ThreadRun run, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ToolOutput> toolOutputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SubmitToolOutputsToRunAsync(string threadId, string runId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.ThreadRun>> SubmitToolOutputsToRunAsync(string threadId, string runId, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.StructuredToolOutput> toolOutputs = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ToolApproval> toolApprovals = null, bool? stream = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Agents.Persistent.StreamingUpdate> SubmitToolOutputsToStream(Azure.AI.Agents.Persistent.ThreadRun run, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ToolOutput> toolOutputs, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ToolApproval> toolApprovals, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Agents.Persistent.StreamingUpdate> SubmitToolOutputsToStream(Azure.AI.Agents.Persistent.ThreadRun run, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ToolOutput> toolOutputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Agents.Persistent.StreamingUpdate> SubmitToolOutputsToStreamAsync(Azure.AI.Agents.Persistent.ThreadRun run, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ToolOutput> toolOutputs, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ToolApproval> toolApprovals, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Agents.Persistent.StreamingUpdate> SubmitToolOutputsToStreamAsync(Azure.AI.Agents.Persistent.ThreadRun run, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ToolOutput> toolOutputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateRun(string threadId, string runId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.ThreadRun> UpdateRun(string threadId, string runId, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateRunAsync(string threadId, string runId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.ThreadRun>> UpdateRunAsync(string threadId, string runId, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class Threads
    {
        protected Threads() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CreateThread(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.PersistentAgentThread> CreateThread(System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ThreadMessageOptions> messages = null, Azure.AI.Agents.Persistent.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateThreadAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.PersistentAgentThread>> CreateThreadAsync(System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.ThreadMessageOptions> messages = null, Azure.AI.Agents.Persistent.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> DeleteThread(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteThreadAsync(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetThread(string threadId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.PersistentAgentThread> GetThread(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetThreadAsync(string threadId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.PersistentAgentThread>> GetThreadAsync(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Agents.Persistent.PersistentAgentThread> GetThreads(int? limit = default(int?), Azure.AI.Agents.Persistent.ListSortOrder? order = default(Azure.AI.Agents.Persistent.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Agents.Persistent.PersistentAgentThread> GetThreadsAsync(int? limit = default(int?), Azure.AI.Agents.Persistent.ListSortOrder? order = default(Azure.AI.Agents.Persistent.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.PersistentAgentThread> UpdateThread(string threadId, Azure.AI.Agents.Persistent.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateThread(string threadId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.PersistentAgentThread>> UpdateThreadAsync(string threadId, Azure.AI.Agents.Persistent.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateThreadAsync(string threadId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ThreadStreamEvent : System.IEquatable<Azure.AI.Agents.Persistent.ThreadStreamEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ThreadStreamEvent(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.ThreadStreamEvent ThreadCreated { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.ThreadStreamEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.ThreadStreamEvent left, Azure.AI.Agents.Persistent.ThreadStreamEvent right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.ThreadStreamEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.ThreadStreamEvent left, Azure.AI.Agents.Persistent.ThreadStreamEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ThreadUpdate : Azure.AI.Agents.Persistent.StreamingUpdate<Azure.AI.Agents.Persistent.PersistentAgentThread>
    {
        internal ThreadUpdate() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public Azure.AI.Agents.Persistent.ToolResources ToolResources { get { throw null; } }
    }
    public partial class ToolApproval : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ToolApproval>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ToolApproval>
    {
        public ToolApproval(string toolCallId, bool approve) { }
        public bool Approve { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Headers { get { throw null; } }
        public string ToolCallId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ToolApproval System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ToolApproval>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ToolApproval>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ToolApproval System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ToolApproval>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ToolApproval>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ToolApproval>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolConnection : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ToolConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ToolConnection>
    {
        public ToolConnection(string connectionId) { }
        public string ConnectionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ToolConnection System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ToolConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ToolConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ToolConnection System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ToolConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ToolConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ToolConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ToolDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ToolDefinition>
    {
        protected ToolDefinition() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolOutput : Azure.AI.Agents.Persistent.StructuredToolOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ToolOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ToolOutput>
    {
        public ToolOutput() { }
        public ToolOutput(Azure.AI.Agents.Persistent.RequiredToolCall toolCall) { }
        public ToolOutput(Azure.AI.Agents.Persistent.RequiredToolCall toolCall, string output) { }
        public ToolOutput(string toolCallId) { }
        public ToolOutput(string toolCallId, string output = null) { }
        public string Output { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ToolOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ToolOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ToolOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ToolOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ToolOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ToolOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ToolOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolResources : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ToolResources>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ToolResources>
    {
        public ToolResources() { }
        public Azure.AI.Agents.Persistent.AzureAISearchToolResource AzureAISearch { get { throw null; } set { } }
        public Azure.AI.Agents.Persistent.CodeInterpreterToolResource CodeInterpreter { get { throw null; } set { } }
        public Azure.AI.Agents.Persistent.FileSearchToolResource FileSearch { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Agents.Persistent.MCPToolResource> Mcp { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ToolResources System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ToolResources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.ToolResources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.ToolResources System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ToolResources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ToolResources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.ToolResources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Truncation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.Truncation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.Truncation>
    {
        public Truncation(Azure.AI.Agents.Persistent.TruncationStrategy type) { }
        public int? LastMessages { get { throw null; } set { } }
        public Azure.AI.Agents.Persistent.TruncationStrategy Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.Truncation System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.Truncation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.Truncation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.Truncation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.Truncation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.Truncation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.Truncation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TruncationStrategy : System.IEquatable<Azure.AI.Agents.Persistent.TruncationStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TruncationStrategy(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.TruncationStrategy Auto { get { throw null; } }
        public static Azure.AI.Agents.Persistent.TruncationStrategy LastMessages { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.TruncationStrategy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.TruncationStrategy left, Azure.AI.Agents.Persistent.TruncationStrategy right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.TruncationStrategy (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.TruncationStrategy left, Azure.AI.Agents.Persistent.TruncationStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TypeAction : Azure.AI.Agents.Persistent.ComputerUseAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.TypeAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.TypeAction>
    {
        internal TypeAction() { }
        public string Text { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.TypeAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.TypeAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.TypeAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.TypeAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.TypeAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.TypeAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.TypeAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreAutoChunkingStrategy : Azure.AI.Agents.Persistent.VectorStoreChunkingStrategy, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreAutoChunkingStrategy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreAutoChunkingStrategy>
    {
        public VectorStoreAutoChunkingStrategy() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.VectorStoreAutoChunkingStrategy System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreAutoChunkingStrategy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreAutoChunkingStrategy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.VectorStoreAutoChunkingStrategy System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreAutoChunkingStrategy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreAutoChunkingStrategy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreAutoChunkingStrategy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreAutoChunkingStrategyResponse : Azure.AI.Agents.Persistent.VectorStoreChunkingStrategyResponse, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreAutoChunkingStrategyResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreAutoChunkingStrategyResponse>
    {
        internal VectorStoreAutoChunkingStrategyResponse() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.VectorStoreAutoChunkingStrategyResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreAutoChunkingStrategyResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreAutoChunkingStrategyResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.VectorStoreAutoChunkingStrategyResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreAutoChunkingStrategyResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreAutoChunkingStrategyResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreAutoChunkingStrategyResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class VectorStoreChunkingStrategy : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreChunkingStrategy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreChunkingStrategy>
    {
        protected VectorStoreChunkingStrategy() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.VectorStoreChunkingStrategy System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreChunkingStrategy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreChunkingStrategy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.VectorStoreChunkingStrategy System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreChunkingStrategy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreChunkingStrategy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreChunkingStrategy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class VectorStoreChunkingStrategyResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreChunkingStrategyResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreChunkingStrategyResponse>
    {
        protected VectorStoreChunkingStrategyResponse() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.VectorStoreChunkingStrategyResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreChunkingStrategyResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreChunkingStrategyResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.VectorStoreChunkingStrategyResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreChunkingStrategyResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreChunkingStrategyResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreChunkingStrategyResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreConfiguration>
    {
        public VectorStoreConfiguration(System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.VectorStoreDataSource> dataSources) { }
        public System.Collections.Generic.IList<Azure.AI.Agents.Persistent.VectorStoreDataSource> DataSources { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.VectorStoreConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.VectorStoreConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreConfigurations : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreConfigurations>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreConfigurations>
    {
        public VectorStoreConfigurations(string storeName, Azure.AI.Agents.Persistent.VectorStoreConfiguration storeConfiguration) { }
        public Azure.AI.Agents.Persistent.VectorStoreConfiguration StoreConfiguration { get { throw null; } set { } }
        public string StoreName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.VectorStoreConfigurations System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreConfigurations>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreConfigurations>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.VectorStoreConfigurations System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreConfigurations>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreConfigurations>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreConfigurations>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreDataSource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreDataSource>
    {
        public VectorStoreDataSource(string assetIdentifier, Azure.AI.Agents.Persistent.VectorStoreDataSourceAssetType assetType) { }
        public string AssetIdentifier { get { throw null; } set { } }
        public Azure.AI.Agents.Persistent.VectorStoreDataSourceAssetType AssetType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.VectorStoreDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.VectorStoreDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreDataSourceAssetType : System.IEquatable<Azure.AI.Agents.Persistent.VectorStoreDataSourceAssetType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreDataSourceAssetType(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.VectorStoreDataSourceAssetType IdAsset { get { throw null; } }
        public static Azure.AI.Agents.Persistent.VectorStoreDataSourceAssetType UriAsset { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.VectorStoreDataSourceAssetType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.VectorStoreDataSourceAssetType left, Azure.AI.Agents.Persistent.VectorStoreDataSourceAssetType right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.VectorStoreDataSourceAssetType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.VectorStoreDataSourceAssetType left, Azure.AI.Agents.Persistent.VectorStoreDataSourceAssetType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreExpirationPolicy : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreExpirationPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreExpirationPolicy>
    {
        public VectorStoreExpirationPolicy(Azure.AI.Agents.Persistent.VectorStoreExpirationPolicyAnchor anchor, int days) { }
        public Azure.AI.Agents.Persistent.VectorStoreExpirationPolicyAnchor Anchor { get { throw null; } set { } }
        public int Days { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.VectorStoreExpirationPolicy System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreExpirationPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreExpirationPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.VectorStoreExpirationPolicy System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreExpirationPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreExpirationPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreExpirationPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreExpirationPolicyAnchor : System.IEquatable<Azure.AI.Agents.Persistent.VectorStoreExpirationPolicyAnchor>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreExpirationPolicyAnchor(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.VectorStoreExpirationPolicyAnchor LastActiveAt { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.VectorStoreExpirationPolicyAnchor other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.VectorStoreExpirationPolicyAnchor left, Azure.AI.Agents.Persistent.VectorStoreExpirationPolicyAnchor right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.VectorStoreExpirationPolicyAnchor (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.VectorStoreExpirationPolicyAnchor left, Azure.AI.Agents.Persistent.VectorStoreExpirationPolicyAnchor right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreFile : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreFile>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreFile>
    {
        internal VectorStoreFile() { }
        public Azure.AI.Agents.Persistent.VectorStoreChunkingStrategyResponse ChunkingStrategy { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Agents.Persistent.VectorStoreFileError LastError { get { throw null; } }
        public Azure.AI.Agents.Persistent.VectorStoreFileObject Object { get { throw null; } }
        public Azure.AI.Agents.Persistent.VectorStoreFileStatus Status { get { throw null; } }
        public int UsageBytes { get { throw null; } }
        public string VectorStoreId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.VectorStoreFile System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.VectorStoreFile System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreFileBatch : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreFileBatch>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreFileBatch>
    {
        internal VectorStoreFileBatch() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public Azure.AI.Agents.Persistent.VectorStoreFileCount FileCounts { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Agents.Persistent.VectorStoreFileBatchObject Object { get { throw null; } }
        public Azure.AI.Agents.Persistent.VectorStoreFileBatchStatus Status { get { throw null; } }
        public string VectorStoreId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.VectorStoreFileBatch System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreFileBatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreFileBatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.VectorStoreFileBatch System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreFileBatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreFileBatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreFileBatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileBatchObject : System.IEquatable<Azure.AI.Agents.Persistent.VectorStoreFileBatchObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileBatchObject(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.VectorStoreFileBatchObject VectorStoreFilesBatch { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.VectorStoreFileBatchObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.VectorStoreFileBatchObject left, Azure.AI.Agents.Persistent.VectorStoreFileBatchObject right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.VectorStoreFileBatchObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.VectorStoreFileBatchObject left, Azure.AI.Agents.Persistent.VectorStoreFileBatchObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileBatchStatus : System.IEquatable<Azure.AI.Agents.Persistent.VectorStoreFileBatchStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileBatchStatus(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.VectorStoreFileBatchStatus Cancelled { get { throw null; } }
        public static Azure.AI.Agents.Persistent.VectorStoreFileBatchStatus Completed { get { throw null; } }
        public static Azure.AI.Agents.Persistent.VectorStoreFileBatchStatus Failed { get { throw null; } }
        public static Azure.AI.Agents.Persistent.VectorStoreFileBatchStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.VectorStoreFileBatchStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.VectorStoreFileBatchStatus left, Azure.AI.Agents.Persistent.VectorStoreFileBatchStatus right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.VectorStoreFileBatchStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.VectorStoreFileBatchStatus left, Azure.AI.Agents.Persistent.VectorStoreFileBatchStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreFileCount : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreFileCount>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreFileCount>
    {
        internal VectorStoreFileCount() { }
        public int Cancelled { get { throw null; } }
        public int Completed { get { throw null; } }
        public int Failed { get { throw null; } }
        public int InProgress { get { throw null; } }
        public int Total { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.VectorStoreFileCount System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreFileCount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreFileCount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.VectorStoreFileCount System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreFileCount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreFileCount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreFileCount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreFileError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreFileError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreFileError>
    {
        internal VectorStoreFileError() { }
        public Azure.AI.Agents.Persistent.VectorStoreFileErrorCode Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.VectorStoreFileError System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreFileError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreFileError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.VectorStoreFileError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreFileError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreFileError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreFileError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileErrorCode : System.IEquatable<Azure.AI.Agents.Persistent.VectorStoreFileErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileErrorCode(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.VectorStoreFileErrorCode InvalidFile { get { throw null; } }
        public static Azure.AI.Agents.Persistent.VectorStoreFileErrorCode ServerError { get { throw null; } }
        public static Azure.AI.Agents.Persistent.VectorStoreFileErrorCode UnsupportedFile { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.VectorStoreFileErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.VectorStoreFileErrorCode left, Azure.AI.Agents.Persistent.VectorStoreFileErrorCode right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.VectorStoreFileErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.VectorStoreFileErrorCode left, Azure.AI.Agents.Persistent.VectorStoreFileErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileObject : System.IEquatable<Azure.AI.Agents.Persistent.VectorStoreFileObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileObject(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.VectorStoreFileObject VectorStoreFile { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.VectorStoreFileObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.VectorStoreFileObject left, Azure.AI.Agents.Persistent.VectorStoreFileObject right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.VectorStoreFileObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.VectorStoreFileObject left, Azure.AI.Agents.Persistent.VectorStoreFileObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileStatus : System.IEquatable<Azure.AI.Agents.Persistent.VectorStoreFileStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileStatus(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.VectorStoreFileStatus Cancelled { get { throw null; } }
        public static Azure.AI.Agents.Persistent.VectorStoreFileStatus Completed { get { throw null; } }
        public static Azure.AI.Agents.Persistent.VectorStoreFileStatus Failed { get { throw null; } }
        public static Azure.AI.Agents.Persistent.VectorStoreFileStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.VectorStoreFileStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.VectorStoreFileStatus left, Azure.AI.Agents.Persistent.VectorStoreFileStatus right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.VectorStoreFileStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.VectorStoreFileStatus left, Azure.AI.Agents.Persistent.VectorStoreFileStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileStatusFilter : System.IEquatable<Azure.AI.Agents.Persistent.VectorStoreFileStatusFilter>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileStatusFilter(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.VectorStoreFileStatusFilter Cancelled { get { throw null; } }
        public static Azure.AI.Agents.Persistent.VectorStoreFileStatusFilter Completed { get { throw null; } }
        public static Azure.AI.Agents.Persistent.VectorStoreFileStatusFilter Failed { get { throw null; } }
        public static Azure.AI.Agents.Persistent.VectorStoreFileStatusFilter InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.VectorStoreFileStatusFilter other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.VectorStoreFileStatusFilter left, Azure.AI.Agents.Persistent.VectorStoreFileStatusFilter right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.VectorStoreFileStatusFilter (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.VectorStoreFileStatusFilter left, Azure.AI.Agents.Persistent.VectorStoreFileStatusFilter right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStores
    {
        protected VectorStores() { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.VectorStoreFileBatch> CancelVectorStoreFileBatch(string vectorStoreId, string batchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.VectorStoreFileBatch>> CancelVectorStoreFileBatchAsync(string vectorStoreId, string batchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateVectorStore(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.PersistentAgentsVectorStore> CreateVectorStore(System.Collections.Generic.IEnumerable<string> fileIds = null, string name = null, Azure.AI.Agents.Persistent.VectorStoreConfiguration storeConfiguration = null, Azure.AI.Agents.Persistent.VectorStoreExpirationPolicy expiresAfter = null, Azure.AI.Agents.Persistent.VectorStoreChunkingStrategy chunkingStrategy = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateVectorStoreAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.PersistentAgentsVectorStore>> CreateVectorStoreAsync(System.Collections.Generic.IEnumerable<string> fileIds = null, string name = null, Azure.AI.Agents.Persistent.VectorStoreConfiguration storeConfiguration = null, Azure.AI.Agents.Persistent.VectorStoreExpirationPolicy expiresAfter = null, Azure.AI.Agents.Persistent.VectorStoreChunkingStrategy chunkingStrategy = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.VectorStoreFile> CreateVectorStoreFile(string vectorStoreId, string fileId = null, Azure.AI.Agents.Persistent.VectorStoreDataSource dataSource = null, Azure.AI.Agents.Persistent.VectorStoreChunkingStrategy chunkingStrategy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.VectorStoreFile>> CreateVectorStoreFileAsync(string vectorStoreId, string fileId = null, Azure.AI.Agents.Persistent.VectorStoreDataSource dataSource = null, Azure.AI.Agents.Persistent.VectorStoreChunkingStrategy chunkingStrategy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.VectorStoreFileBatch> CreateVectorStoreFileBatch(string vectorStoreId, System.Collections.Generic.IEnumerable<string> fileIds = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.VectorStoreDataSource> dataSources = null, Azure.AI.Agents.Persistent.VectorStoreChunkingStrategy chunkingStrategy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.VectorStoreFileBatch>> CreateVectorStoreFileBatchAsync(string vectorStoreId, System.Collections.Generic.IEnumerable<string> fileIds = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.Persistent.VectorStoreDataSource> dataSources = null, Azure.AI.Agents.Persistent.VectorStoreChunkingStrategy chunkingStrategy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> DeleteVectorStore(string vectorStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteVectorStoreAsync(string vectorStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> DeleteVectorStoreFile(string vectorStoreId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteVectorStoreFileAsync(string vectorStoreId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStore(string vectorStoreId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.PersistentAgentsVectorStore> GetVectorStore(string vectorStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoreAsync(string vectorStoreId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.PersistentAgentsVectorStore>> GetVectorStoreAsync(string vectorStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.VectorStoreFile> GetVectorStoreFile(string vectorStoreId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.VectorStoreFile>> GetVectorStoreFileAsync(string vectorStoreId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.VectorStoreFileBatch> GetVectorStoreFileBatch(string vectorStoreId, string batchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.VectorStoreFileBatch>> GetVectorStoreFileBatchAsync(string vectorStoreId, string batchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Agents.Persistent.VectorStoreFile> GetVectorStoreFileBatchFiles(string vectorStoreId, string batchId, Azure.AI.Agents.Persistent.VectorStoreFileStatusFilter? filter = default(Azure.AI.Agents.Persistent.VectorStoreFileStatusFilter?), int? limit = default(int?), Azure.AI.Agents.Persistent.ListSortOrder? order = default(Azure.AI.Agents.Persistent.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Agents.Persistent.VectorStoreFile> GetVectorStoreFileBatchFilesAsync(string vectorStoreId, string batchId, Azure.AI.Agents.Persistent.VectorStoreFileStatusFilter? filter = default(Azure.AI.Agents.Persistent.VectorStoreFileStatusFilter?), int? limit = default(int?), Azure.AI.Agents.Persistent.ListSortOrder? order = default(Azure.AI.Agents.Persistent.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Agents.Persistent.VectorStoreFile> GetVectorStoreFiles(string vectorStoreId, Azure.AI.Agents.Persistent.VectorStoreFileStatusFilter? filter = default(Azure.AI.Agents.Persistent.VectorStoreFileStatusFilter?), int? limit = default(int?), Azure.AI.Agents.Persistent.ListSortOrder? order = default(Azure.AI.Agents.Persistent.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Agents.Persistent.VectorStoreFile> GetVectorStoreFilesAsync(string vectorStoreId, Azure.AI.Agents.Persistent.VectorStoreFileStatusFilter? filter = default(Azure.AI.Agents.Persistent.VectorStoreFileStatusFilter?), int? limit = default(int?), Azure.AI.Agents.Persistent.ListSortOrder? order = default(Azure.AI.Agents.Persistent.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Agents.Persistent.PersistentAgentsVectorStore> GetVectorStores(int? limit = default(int?), Azure.AI.Agents.Persistent.ListSortOrder? order = default(Azure.AI.Agents.Persistent.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Agents.Persistent.PersistentAgentsVectorStore> GetVectorStoresAsync(int? limit = default(int?), Azure.AI.Agents.Persistent.ListSortOrder? order = default(Azure.AI.Agents.Persistent.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ModifyVectorStore(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Persistent.PersistentAgentsVectorStore> ModifyVectorStore(string vectorStoreId, string name = null, Azure.AI.Agents.Persistent.VectorStoreExpirationPolicy expiresAfter = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ModifyVectorStoreAsync(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Persistent.PersistentAgentsVectorStore>> ModifyVectorStoreAsync(string vectorStoreId, string name = null, Azure.AI.Agents.Persistent.VectorStoreExpirationPolicy expiresAfter = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VectorStoreStaticChunkingStrategyOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyOptions>
    {
        public VectorStoreStaticChunkingStrategyOptions(int maxChunkSizeTokens, int chunkOverlapTokens) { }
        public int ChunkOverlapTokens { get { throw null; } set { } }
        public int MaxChunkSizeTokens { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreStaticChunkingStrategyRequest : Azure.AI.Agents.Persistent.VectorStoreChunkingStrategy, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyRequest>
    {
        public VectorStoreStaticChunkingStrategyRequest(Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyOptions @static) { }
        public Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyOptions Static { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreStaticChunkingStrategyResponse : Azure.AI.Agents.Persistent.VectorStoreChunkingStrategyResponse, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyResponse>
    {
        internal VectorStoreStaticChunkingStrategyResponse() { }
        public Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyOptions Static { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.VectorStoreStaticChunkingStrategyResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreStatus : System.IEquatable<Azure.AI.Agents.Persistent.VectorStoreStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreStatus(string value) { throw null; }
        public static Azure.AI.Agents.Persistent.VectorStoreStatus Completed { get { throw null; } }
        public static Azure.AI.Agents.Persistent.VectorStoreStatus Expired { get { throw null; } }
        public static Azure.AI.Agents.Persistent.VectorStoreStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Agents.Persistent.VectorStoreStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.Persistent.VectorStoreStatus left, Azure.AI.Agents.Persistent.VectorStoreStatus right) { throw null; }
        public static implicit operator Azure.AI.Agents.Persistent.VectorStoreStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.Persistent.VectorStoreStatus left, Azure.AI.Agents.Persistent.VectorStoreStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WaitAction : Azure.AI.Agents.Persistent.ComputerUseAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.WaitAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.WaitAction>
    {
        internal WaitAction() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.WaitAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.WaitAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Persistent.WaitAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Persistent.WaitAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.WaitAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.WaitAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Persistent.WaitAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AIAgentsPersistentClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Agents.Persistent.PersistentAgentsAdministrationClient, Azure.AI.Agents.Persistent.PersistentAgentsAdministrationClientOptions> AddPersistentAgentsAdministrationClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Agents.Persistent.PersistentAgentsAdministrationClient, Azure.AI.Agents.Persistent.PersistentAgentsAdministrationClientOptions> AddPersistentAgentsAdministrationClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
