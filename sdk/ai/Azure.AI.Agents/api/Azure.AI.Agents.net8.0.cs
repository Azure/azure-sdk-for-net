namespace Azure.AI.Agents
{
    public partial class Agent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Agent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Agent>
    {
        internal Agent() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public string Instructions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string Model { get { throw null; } }
        public string Name { get { throw null; } }
        public System.BinaryData ResponseFormat { get { throw null; } }
        public float? Temperature { get { throw null; } }
        public Azure.AI.Agents.ToolResources ToolResources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.ToolDefinition> Tools { get { throw null; } }
        public float? TopP { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Agent System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Agent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.Agent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.Agent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Agent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Agent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.Agent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentFile : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentFile>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentFile>
    {
        internal AgentFile() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Filename { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Agents.AgentFilePurpose Purpose { get { throw null; } }
        public int Size { get { throw null; } }
        public Azure.AI.Agents.FileState? Status { get { throw null; } }
        public string StatusDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentFile System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentFile System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentFilePurpose : System.IEquatable<Azure.AI.Agents.AgentFilePurpose>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentFilePurpose(string value) { throw null; }
        public static Azure.AI.Agents.AgentFilePurpose Agents { get { throw null; } }
        public static Azure.AI.Agents.AgentFilePurpose AgentsOutput { get { throw null; } }
        public static Azure.AI.Agents.AgentFilePurpose Batch { get { throw null; } }
        public static Azure.AI.Agents.AgentFilePurpose BatchOutput { get { throw null; } }
        public static Azure.AI.Agents.AgentFilePurpose FineTune { get { throw null; } }
        public static Azure.AI.Agents.AgentFilePurpose FineTuneResults { get { throw null; } }
        public static Azure.AI.Agents.AgentFilePurpose Vision { get { throw null; } }
        public bool Equals(Azure.AI.Agents.AgentFilePurpose other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.AgentFilePurpose left, Azure.AI.Agents.AgentFilePurpose right) { throw null; }
        public static implicit operator Azure.AI.Agents.AgentFilePurpose (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.AgentFilePurpose left, Azure.AI.Agents.AgentFilePurpose right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentPageableListOfVectorStore : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentPageableListOfVectorStore>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentPageableListOfVectorStore>
    {
        internal AgentPageableListOfVectorStore() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.VectorStore> Data { get { throw null; } }
        public string FirstId { get { throw null; } }
        public bool HasMore { get { throw null; } }
        public string LastId { get { throw null; } }
        public Azure.AI.Agents.AgentPageableListOfVectorStoreObject Object { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentPageableListOfVectorStore System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentPageableListOfVectorStore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentPageableListOfVectorStore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentPageableListOfVectorStore System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentPageableListOfVectorStore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentPageableListOfVectorStore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentPageableListOfVectorStore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentPageableListOfVectorStoreFile : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentPageableListOfVectorStoreFile>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentPageableListOfVectorStoreFile>
    {
        internal AgentPageableListOfVectorStoreFile() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.VectorStoreFile> Data { get { throw null; } }
        public string FirstId { get { throw null; } }
        public bool HasMore { get { throw null; } }
        public string LastId { get { throw null; } }
        public Azure.AI.Agents.AgentPageableListOfVectorStoreFileObject Object { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentPageableListOfVectorStoreFile System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentPageableListOfVectorStoreFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentPageableListOfVectorStoreFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentPageableListOfVectorStoreFile System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentPageableListOfVectorStoreFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentPageableListOfVectorStoreFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentPageableListOfVectorStoreFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentPageableListOfVectorStoreFileObject : System.IEquatable<Azure.AI.Agents.AgentPageableListOfVectorStoreFileObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentPageableListOfVectorStoreFileObject(string value) { throw null; }
        public static Azure.AI.Agents.AgentPageableListOfVectorStoreFileObject List { get { throw null; } }
        public bool Equals(Azure.AI.Agents.AgentPageableListOfVectorStoreFileObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.AgentPageableListOfVectorStoreFileObject left, Azure.AI.Agents.AgentPageableListOfVectorStoreFileObject right) { throw null; }
        public static implicit operator Azure.AI.Agents.AgentPageableListOfVectorStoreFileObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.AgentPageableListOfVectorStoreFileObject left, Azure.AI.Agents.AgentPageableListOfVectorStoreFileObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentPageableListOfVectorStoreObject : System.IEquatable<Azure.AI.Agents.AgentPageableListOfVectorStoreObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentPageableListOfVectorStoreObject(string value) { throw null; }
        public static Azure.AI.Agents.AgentPageableListOfVectorStoreObject List { get { throw null; } }
        public bool Equals(Azure.AI.Agents.AgentPageableListOfVectorStoreObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.AgentPageableListOfVectorStoreObject left, Azure.AI.Agents.AgentPageableListOfVectorStoreObject right) { throw null; }
        public static implicit operator Azure.AI.Agents.AgentPageableListOfVectorStoreObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.AgentPageableListOfVectorStoreObject left, Azure.AI.Agents.AgentPageableListOfVectorStoreObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentsApiResponseFormat : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentsApiResponseFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentsApiResponseFormat>
    {
        public AgentsApiResponseFormat() { }
        public Azure.AI.Agents.ResponseFormat? Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentsApiResponseFormat System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentsApiResponseFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentsApiResponseFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentsApiResponseFormat System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentsApiResponseFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentsApiResponseFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentsApiResponseFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentsApiResponseFormatMode : System.IEquatable<Azure.AI.Agents.AgentsApiResponseFormatMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentsApiResponseFormatMode(string value) { throw null; }
        public static Azure.AI.Agents.AgentsApiResponseFormatMode Auto { get { throw null; } }
        public static Azure.AI.Agents.AgentsApiResponseFormatMode None { get { throw null; } }
        public bool Equals(Azure.AI.Agents.AgentsApiResponseFormatMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.AgentsApiResponseFormatMode left, Azure.AI.Agents.AgentsApiResponseFormatMode right) { throw null; }
        public static implicit operator Azure.AI.Agents.AgentsApiResponseFormatMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.AgentsApiResponseFormatMode left, Azure.AI.Agents.AgentsApiResponseFormatMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentsApiToolChoiceOptionMode : System.IEquatable<Azure.AI.Agents.AgentsApiToolChoiceOptionMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentsApiToolChoiceOptionMode(string value) { throw null; }
        public static Azure.AI.Agents.AgentsApiToolChoiceOptionMode Auto { get { throw null; } }
        public static Azure.AI.Agents.AgentsApiToolChoiceOptionMode None { get { throw null; } }
        public bool Equals(Azure.AI.Agents.AgentsApiToolChoiceOptionMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.AgentsApiToolChoiceOptionMode left, Azure.AI.Agents.AgentsApiToolChoiceOptionMode right) { throw null; }
        public static implicit operator Azure.AI.Agents.AgentsApiToolChoiceOptionMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.AgentsApiToolChoiceOptionMode left, Azure.AI.Agents.AgentsApiToolChoiceOptionMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentsClient
    {
        protected AgentsClient() { }
        public AgentsClient(string connectionString, Azure.Core.TokenCredential credential) { }
        public AgentsClient(string connectionString, Azure.Core.TokenCredential credential, Azure.AI.Agents.AgentsClientOptions options) { }
        public AgentsClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential) { }
        public AgentsClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential, Azure.AI.Agents.AgentsClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CancelRun(string threadId, string runId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.ThreadRun> CancelRun(string threadId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelRunAsync(string threadId, string runId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.ThreadRun>> CancelRunAsync(string threadId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CancelVectorStoreFileBatch(string vectorStoreId, string batchId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.VectorStoreFileBatch> CancelVectorStoreFileBatch(string vectorStoreId, string batchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelVectorStoreFileBatchAsync(string vectorStoreId, string batchId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.VectorStoreFileBatch>> CancelVectorStoreFileBatchAsync(string vectorStoreId, string batchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateAgent(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Agent> CreateAgent(string model, string name = null, string description = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.ToolDefinition> tools = null, Azure.AI.Agents.ToolResources toolResources = null, float? temperature = default(float?), float? topP = default(float?), System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAgentAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Agent>> CreateAgentAsync(string model, string name = null, string description = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.ToolDefinition> tools = null, Azure.AI.Agents.ToolResources toolResources = null, float? temperature = default(float?), float? topP = default(float?), System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.ThreadMessage> CreateMessage(string threadId, Azure.AI.Agents.MessageRole role, string content, System.Collections.Generic.IEnumerable<Azure.AI.Agents.MessageAttachment> attachments = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateMessage(string threadId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.ThreadMessage>> CreateMessageAsync(string threadId, Azure.AI.Agents.MessageRole role, string content, System.Collections.Generic.IEnumerable<Azure.AI.Agents.MessageAttachment> attachments = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateMessageAsync(string threadId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.ThreadRun> CreateRun(Azure.AI.Agents.AgentThread thread, Azure.AI.Agents.Agent agent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateRun(string threadId, Azure.Core.RequestContent content, System.Collections.Generic.IEnumerable<Azure.AI.Agents.RunAdditionalFieldList> include = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.ThreadRun> CreateRun(string threadId, string assistantId, string overrideModelName = null, string overrideInstructions = null, string additionalInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.ThreadMessageOptions> additionalMessages = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.ToolDefinition> overrideTools = null, bool? stream = default(bool?), float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Agents.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, bool? parallelToolCalls = default(bool?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.RunAdditionalFieldList> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.ThreadRun>> CreateRunAsync(Azure.AI.Agents.AgentThread thread, Azure.AI.Agents.Agent agent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateRunAsync(string threadId, Azure.Core.RequestContent content, System.Collections.Generic.IEnumerable<Azure.AI.Agents.RunAdditionalFieldList> include = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.ThreadRun>> CreateRunAsync(string threadId, string assistantId, string overrideModelName = null, string overrideInstructions = null, string additionalInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.ThreadMessageOptions> additionalMessages = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.ToolDefinition> overrideTools = null, bool? stream = default(bool?), float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Agents.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, bool? parallelToolCalls = default(bool?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.RunAdditionalFieldList> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Agents.StreamingUpdate> CreateRunStreaming(string threadId, string assistantId, string overrideModelName = null, string overrideInstructions = null, string additionalInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.ThreadMessageOptions> additionalMessages = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.ToolDefinition> overrideTools = null, float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Agents.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, bool? parallelToolCalls = default(bool?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Agents.StreamingUpdate> CreateRunStreamingAsync(string threadId, string assistantId, string overrideModelName = null, string overrideInstructions = null, string additionalInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.ThreadMessageOptions> additionalMessages = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.ToolDefinition> overrideTools = null, float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Agents.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, bool? parallelToolCalls = default(bool?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateThread(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.AgentThread> CreateThread(System.Collections.Generic.IEnumerable<Azure.AI.Agents.ThreadMessageOptions> messages = null, Azure.AI.Agents.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateThreadAndRun(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.ThreadRun> CreateThreadAndRun(string assistantId, Azure.AI.Agents.AgentThreadCreationOptions thread = null, string overrideModelName = null, string overrideInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.ToolDefinition> overrideTools = null, Azure.AI.Agents.UpdateToolResourcesOptions toolResources = null, bool? stream = default(bool?), float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Agents.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, bool? parallelToolCalls = default(bool?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateThreadAndRunAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.ThreadRun>> CreateThreadAndRunAsync(string assistantId, Azure.AI.Agents.AgentThreadCreationOptions thread = null, string overrideModelName = null, string overrideInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.ToolDefinition> overrideTools = null, Azure.AI.Agents.UpdateToolResourcesOptions toolResources = null, bool? stream = default(bool?), float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Agents.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, bool? parallelToolCalls = default(bool?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateThreadAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.AgentThread>> CreateThreadAsync(System.Collections.Generic.IEnumerable<Azure.AI.Agents.ThreadMessageOptions> messages = null, Azure.AI.Agents.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateVectorStore(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.VectorStore> CreateVectorStore(System.Collections.Generic.IEnumerable<string> fileIds = null, string name = null, Azure.AI.Agents.VectorStoreConfiguration storeConfiguration = null, Azure.AI.Agents.VectorStoreExpirationPolicy expiresAfter = null, Azure.AI.Agents.VectorStoreChunkingStrategyRequest chunkingStrategy = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateVectorStoreAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.VectorStore>> CreateVectorStoreAsync(System.Collections.Generic.IEnumerable<string> fileIds = null, string name = null, Azure.AI.Agents.VectorStoreConfiguration storeConfiguration = null, Azure.AI.Agents.VectorStoreExpirationPolicy expiresAfter = null, Azure.AI.Agents.VectorStoreChunkingStrategyRequest chunkingStrategy = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateVectorStoreFile(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.VectorStoreFile> CreateVectorStoreFile(string vectorStoreId, string fileId = null, Azure.AI.Agents.VectorStoreDataSource dataSource = null, Azure.AI.Agents.VectorStoreChunkingStrategyRequest chunkingStrategy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateVectorStoreFileAsync(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.VectorStoreFile>> CreateVectorStoreFileAsync(string vectorStoreId, string fileId = null, Azure.AI.Agents.VectorStoreDataSource dataSource = null, Azure.AI.Agents.VectorStoreChunkingStrategyRequest chunkingStrategy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateVectorStoreFileBatch(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.VectorStoreFileBatch> CreateVectorStoreFileBatch(string vectorStoreId, System.Collections.Generic.IEnumerable<string> fileIds = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.VectorStoreDataSource> dataSources = null, Azure.AI.Agents.VectorStoreChunkingStrategyRequest chunkingStrategy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateVectorStoreFileBatchAsync(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.VectorStoreFileBatch>> CreateVectorStoreFileBatchAsync(string vectorStoreId, System.Collections.Generic.IEnumerable<string> fileIds = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.VectorStoreDataSource> dataSources = null, Azure.AI.Agents.VectorStoreChunkingStrategyRequest chunkingStrategy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> DeleteAgent(string agentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteAgentAsync(string agentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> DeleteFile(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteFileAsync(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> DeleteThread(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteThreadAsync(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteVectorStore(string vectorStoreId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.VectorStoreDeletionStatus> DeleteVectorStore(string vectorStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVectorStoreAsync(string vectorStoreId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.VectorStoreDeletionStatus>> DeleteVectorStoreAsync(string vectorStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteVectorStoreFile(string vectorStoreId, string fileId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.VectorStoreFileDeletionStatus> DeleteVectorStoreFile(string vectorStoreId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVectorStoreFileAsync(string vectorStoreId, string fileId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.VectorStoreFileDeletionStatus>> DeleteVectorStoreFileAsync(string vectorStoreId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetAgent(string assistantId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Agent> GetAgent(string assistantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAgentAsync(string assistantId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Agent>> GetAgentAsync(string assistantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.PageableList<Azure.AI.Agents.Agent>> GetAgents(int? limit = default(int?), Azure.AI.Agents.ListSortOrder? order = default(Azure.AI.Agents.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.PageableList<Azure.AI.Agents.Agent>>> GetAgentsAsync(int? limit = default(int?), Azure.AI.Agents.ListSortOrder? order = default(Azure.AI.Agents.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetFile(string fileId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.AgentFile> GetFile(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetFileAsync(string fileId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.AgentFile>> GetFileAsync(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetFileContent(string fileId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetFileContent(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetFileContentAsync(string fileId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetFileContentAsync(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.AgentFile>> GetFiles(Azure.AI.Agents.AgentFilePurpose? purpose = default(Azure.AI.Agents.AgentFilePurpose?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.AgentFile>>> GetFilesAsync(Azure.AI.Agents.AgentFilePurpose? purpose = default(Azure.AI.Agents.AgentFilePurpose?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetMessage(string threadId, string messageId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.ThreadMessage> GetMessage(string threadId, string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMessageAsync(string threadId, string messageId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.ThreadMessage>> GetMessageAsync(string threadId, string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.PageableList<Azure.AI.Agents.ThreadMessage>> GetMessages(string threadId, string runId = null, int? limit = default(int?), Azure.AI.Agents.ListSortOrder? order = default(Azure.AI.Agents.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.PageableList<Azure.AI.Agents.ThreadMessage>>> GetMessagesAsync(string threadId, string runId = null, int? limit = default(int?), Azure.AI.Agents.ListSortOrder? order = default(Azure.AI.Agents.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetRun(string threadId, string runId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.ThreadRun> GetRun(string threadId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRunAsync(string threadId, string runId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.ThreadRun>> GetRunAsync(string threadId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.PageableList<Azure.AI.Agents.ThreadRun>> GetRuns(string threadId, int? limit = default(int?), Azure.AI.Agents.ListSortOrder? order = default(Azure.AI.Agents.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.PageableList<Azure.AI.Agents.ThreadRun>>> GetRunsAsync(string threadId, int? limit = default(int?), Azure.AI.Agents.ListSortOrder? order = default(Azure.AI.Agents.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetRunStep(string threadId, string runId, string stepId, System.Collections.Generic.IEnumerable<Azure.AI.Agents.RunAdditionalFieldList> include, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.RunStep> GetRunStep(string threadId, string runId, string stepId, System.Collections.Generic.IEnumerable<Azure.AI.Agents.RunAdditionalFieldList> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRunStepAsync(string threadId, string runId, string stepId, System.Collections.Generic.IEnumerable<Azure.AI.Agents.RunAdditionalFieldList> include, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.RunStep>> GetRunStepAsync(string threadId, string runId, string stepId, System.Collections.Generic.IEnumerable<Azure.AI.Agents.RunAdditionalFieldList> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.PageableList<Azure.AI.Agents.RunStep>> GetRunSteps(Azure.AI.Agents.ThreadRun run, int? limit = default(int?), Azure.AI.Agents.ListSortOrder? order = default(Azure.AI.Agents.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.PageableList<Azure.AI.Agents.RunStep>> GetRunSteps(string threadId, string runId, int? limit = default(int?), Azure.AI.Agents.ListSortOrder? order = default(Azure.AI.Agents.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.PageableList<Azure.AI.Agents.RunStep>>> GetRunStepsAsync(Azure.AI.Agents.ThreadRun run, int? limit = default(int?), Azure.AI.Agents.ListSortOrder? order = default(Azure.AI.Agents.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.PageableList<Azure.AI.Agents.RunStep>>> GetRunStepsAsync(string threadId, string runId, int? limit = default(int?), Azure.AI.Agents.ListSortOrder? order = default(Azure.AI.Agents.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetThread(string threadId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.AgentThread> GetThread(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetThreadAsync(string threadId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.AgentThread>> GetThreadAsync(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStore(string vectorStoreId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.VectorStore> GetVectorStore(string vectorStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoreAsync(string vectorStoreId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.VectorStore>> GetVectorStoreAsync(string vectorStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStoreFile(string vectorStoreId, string fileId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.VectorStoreFile> GetVectorStoreFile(string vectorStoreId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoreFileAsync(string vectorStoreId, string fileId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.VectorStoreFile>> GetVectorStoreFileAsync(string vectorStoreId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStoreFileBatch(string vectorStoreId, string batchId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.VectorStoreFileBatch> GetVectorStoreFileBatch(string vectorStoreId, string batchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoreFileBatchAsync(string vectorStoreId, string batchId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.VectorStoreFileBatch>> GetVectorStoreFileBatchAsync(string vectorStoreId, string batchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.AgentPageableListOfVectorStoreFile> GetVectorStoreFileBatchFiles(string vectorStoreId, string batchId, Azure.AI.Agents.VectorStoreFileStatusFilter? filter = default(Azure.AI.Agents.VectorStoreFileStatusFilter?), int? limit = default(int?), Azure.AI.Agents.ListSortOrder? order = default(Azure.AI.Agents.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStoreFileBatchFiles(string vectorStoreId, string batchId, string filter, int? limit, string order, string after, string before, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.AgentPageableListOfVectorStoreFile>> GetVectorStoreFileBatchFilesAsync(string vectorStoreId, string batchId, Azure.AI.Agents.VectorStoreFileStatusFilter? filter = default(Azure.AI.Agents.VectorStoreFileStatusFilter?), int? limit = default(int?), Azure.AI.Agents.ListSortOrder? order = default(Azure.AI.Agents.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoreFileBatchFilesAsync(string vectorStoreId, string batchId, string filter, int? limit, string order, string after, string before, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.AgentPageableListOfVectorStoreFile> GetVectorStoreFiles(string vectorStoreId, Azure.AI.Agents.VectorStoreFileStatusFilter? filter = default(Azure.AI.Agents.VectorStoreFileStatusFilter?), int? limit = default(int?), Azure.AI.Agents.ListSortOrder? order = default(Azure.AI.Agents.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStoreFiles(string vectorStoreId, string filter, int? limit, string order, string after, string before, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.AgentPageableListOfVectorStoreFile>> GetVectorStoreFilesAsync(string vectorStoreId, Azure.AI.Agents.VectorStoreFileStatusFilter? filter = default(Azure.AI.Agents.VectorStoreFileStatusFilter?), int? limit = default(int?), Azure.AI.Agents.ListSortOrder? order = default(Azure.AI.Agents.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoreFilesAsync(string vectorStoreId, string filter, int? limit, string order, string after, string before, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.AgentPageableListOfVectorStore> GetVectorStores(int? limit = default(int?), Azure.AI.Agents.ListSortOrder? order = default(Azure.AI.Agents.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStores(int? limit, string order, string after, string before, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.AgentPageableListOfVectorStore>> GetVectorStoresAsync(int? limit = default(int?), Azure.AI.Agents.ListSortOrder? order = default(Azure.AI.Agents.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoresAsync(int? limit, string order, string after, string before, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response ModifyVectorStore(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.VectorStore> ModifyVectorStore(string vectorStoreId, string name = null, Azure.AI.Agents.VectorStoreExpirationPolicy expiresAfter = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ModifyVectorStoreAsync(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.VectorStore>> ModifyVectorStoreAsync(string vectorStoreId, string name = null, Azure.AI.Agents.VectorStoreExpirationPolicy expiresAfter = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.ThreadRun> SubmitToolOutputsToRun(Azure.AI.Agents.ThreadRun run, System.Collections.Generic.IEnumerable<Azure.AI.Agents.ToolOutput> toolOutputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SubmitToolOutputsToRun(string threadId, string runId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.ThreadRun>> SubmitToolOutputsToRunAsync(Azure.AI.Agents.ThreadRun run, System.Collections.Generic.IEnumerable<Azure.AI.Agents.ToolOutput> toolOutputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SubmitToolOutputsToRunAsync(string threadId, string runId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Agents.StreamingUpdate> SubmitToolOutputsToStream(Azure.AI.Agents.ThreadRun run, System.Collections.Generic.IEnumerable<Azure.AI.Agents.ToolOutput> toolOutputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Agents.StreamingUpdate> SubmitToolOutputsToStreamAsync(Azure.AI.Agents.ThreadRun run, System.Collections.Generic.IEnumerable<Azure.AI.Agents.ToolOutput> toolOutputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateAgent(string assistantId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.Agent> UpdateAgent(string assistantId, string model = null, string name = null, string description = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.ToolDefinition> tools = null, Azure.AI.Agents.ToolResources toolResources = null, float? temperature = default(float?), float? topP = default(float?), System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAgentAsync(string assistantId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.Agent>> UpdateAgentAsync(string assistantId, string model = null, string name = null, string description = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.ToolDefinition> tools = null, Azure.AI.Agents.ToolResources toolResources = null, float? temperature = default(float?), float? topP = default(float?), System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateMessage(string threadId, string messageId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.ThreadMessage> UpdateMessage(string threadId, string messageId, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateMessageAsync(string threadId, string messageId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.ThreadMessage>> UpdateMessageAsync(string threadId, string messageId, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateRun(string threadId, string runId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.ThreadRun> UpdateRun(string threadId, string runId, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateRunAsync(string threadId, string runId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.ThreadRun>> UpdateRunAsync(string threadId, string runId, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.AgentThread> UpdateThread(string threadId, Azure.AI.Agents.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateThread(string threadId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.AgentThread>> UpdateThreadAsync(string threadId, Azure.AI.Agents.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateThreadAsync(string threadId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UploadFile(Azure.Core.RequestContent content, string contentType, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.AgentFile> UploadFile(System.IO.Stream data, Azure.AI.Agents.AgentFilePurpose purpose, string filename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Agents.AgentFile> UploadFile(string filePath, Azure.AI.Agents.AgentFilePurpose purpose, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadFileAsync(Azure.Core.RequestContent content, string contentType, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.AgentFile>> UploadFileAsync(System.IO.Stream data, Azure.AI.Agents.AgentFilePurpose purpose, string filename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Agents.AgentFile>> UploadFileAsync(string filePath, Azure.AI.Agents.AgentFilePurpose purpose, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AgentsClientOptions : Azure.Core.ClientOptions
    {
        public AgentsClientOptions(Azure.AI.Agents.AgentsClientOptions.ServiceVersion version = Azure.AI.Agents.AgentsClientOptions.ServiceVersion.V2024_07_01_Preview) { }
        public enum ServiceVersion
        {
            V2024_07_01_Preview = 1,
        }
    }
    public partial class AgentsNamedToolChoice : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentsNamedToolChoice>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentsNamedToolChoice>
    {
        public AgentsNamedToolChoice(Azure.AI.Agents.AgentsNamedToolChoiceType type) { }
        public Azure.AI.Agents.FunctionName Function { get { throw null; } set { } }
        public Azure.AI.Agents.AgentsNamedToolChoiceType Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentsNamedToolChoice System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentsNamedToolChoice>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentsNamedToolChoice>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentsNamedToolChoice System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentsNamedToolChoice>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentsNamedToolChoice>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentsNamedToolChoice>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentsNamedToolChoiceType : System.IEquatable<Azure.AI.Agents.AgentsNamedToolChoiceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentsNamedToolChoiceType(string value) { throw null; }
        public static Azure.AI.Agents.AgentsNamedToolChoiceType AzureAISearch { get { throw null; } }
        public static Azure.AI.Agents.AgentsNamedToolChoiceType BingGrounding { get { throw null; } }
        public static Azure.AI.Agents.AgentsNamedToolChoiceType CodeInterpreter { get { throw null; } }
        public static Azure.AI.Agents.AgentsNamedToolChoiceType FileSearch { get { throw null; } }
        public static Azure.AI.Agents.AgentsNamedToolChoiceType Function { get { throw null; } }
        public static Azure.AI.Agents.AgentsNamedToolChoiceType MicrosoftFabric { get { throw null; } }
        public static Azure.AI.Agents.AgentsNamedToolChoiceType Sharepoint { get { throw null; } }
        public bool Equals(Azure.AI.Agents.AgentsNamedToolChoiceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.AgentsNamedToolChoiceType left, Azure.AI.Agents.AgentsNamedToolChoiceType right) { throw null; }
        public static implicit operator Azure.AI.Agents.AgentsNamedToolChoiceType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.AgentsNamedToolChoiceType left, Azure.AI.Agents.AgentsNamedToolChoiceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentStreamEvent : System.IEquatable<Azure.AI.Agents.AgentStreamEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentStreamEvent(string value) { throw null; }
        public static Azure.AI.Agents.AgentStreamEvent Done { get { throw null; } }
        public static Azure.AI.Agents.AgentStreamEvent Error { get { throw null; } }
        public static Azure.AI.Agents.AgentStreamEvent ThreadCreated { get { throw null; } }
        public static Azure.AI.Agents.AgentStreamEvent ThreadMessageCompleted { get { throw null; } }
        public static Azure.AI.Agents.AgentStreamEvent ThreadMessageCreated { get { throw null; } }
        public static Azure.AI.Agents.AgentStreamEvent ThreadMessageDelta { get { throw null; } }
        public static Azure.AI.Agents.AgentStreamEvent ThreadMessageIncomplete { get { throw null; } }
        public static Azure.AI.Agents.AgentStreamEvent ThreadMessageInProgress { get { throw null; } }
        public static Azure.AI.Agents.AgentStreamEvent ThreadRunCancelled { get { throw null; } }
        public static Azure.AI.Agents.AgentStreamEvent ThreadRunCancelling { get { throw null; } }
        public static Azure.AI.Agents.AgentStreamEvent ThreadRunCompleted { get { throw null; } }
        public static Azure.AI.Agents.AgentStreamEvent ThreadRunCreated { get { throw null; } }
        public static Azure.AI.Agents.AgentStreamEvent ThreadRunExpired { get { throw null; } }
        public static Azure.AI.Agents.AgentStreamEvent ThreadRunFailed { get { throw null; } }
        public static Azure.AI.Agents.AgentStreamEvent ThreadRunIncomplete { get { throw null; } }
        public static Azure.AI.Agents.AgentStreamEvent ThreadRunInProgress { get { throw null; } }
        public static Azure.AI.Agents.AgentStreamEvent ThreadRunQueued { get { throw null; } }
        public static Azure.AI.Agents.AgentStreamEvent ThreadRunRequiresAction { get { throw null; } }
        public static Azure.AI.Agents.AgentStreamEvent ThreadRunStepCancelled { get { throw null; } }
        public static Azure.AI.Agents.AgentStreamEvent ThreadRunStepCompleted { get { throw null; } }
        public static Azure.AI.Agents.AgentStreamEvent ThreadRunStepCreated { get { throw null; } }
        public static Azure.AI.Agents.AgentStreamEvent ThreadRunStepDelta { get { throw null; } }
        public static Azure.AI.Agents.AgentStreamEvent ThreadRunStepExpired { get { throw null; } }
        public static Azure.AI.Agents.AgentStreamEvent ThreadRunStepFailed { get { throw null; } }
        public static Azure.AI.Agents.AgentStreamEvent ThreadRunStepInProgress { get { throw null; } }
        public bool Equals(Azure.AI.Agents.AgentStreamEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.AgentStreamEvent left, Azure.AI.Agents.AgentStreamEvent right) { throw null; }
        public static implicit operator Azure.AI.Agents.AgentStreamEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.AgentStreamEvent left, Azure.AI.Agents.AgentStreamEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentThread : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentThread>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentThread>
    {
        internal AgentThread() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public Azure.AI.Agents.ToolResources ToolResources { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentThread System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentThread>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentThread>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentThread System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentThread>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentThread>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentThread>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentThreadCreationOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentThreadCreationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentThreadCreationOptions>
    {
        public AgentThreadCreationOptions() { }
        public System.Collections.Generic.IList<Azure.AI.Agents.ThreadMessageOptions> Messages { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public Azure.AI.Agents.ToolResources ToolResources { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentThreadCreationOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentThreadCreationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentThreadCreationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentThreadCreationOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentThreadCreationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentThreadCreationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentThreadCreationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class AIAgentsModelFactory
    {
        public static Azure.AI.Agents.AgentPageableListOfVectorStore AgentPageableListOfVectorStore(Azure.AI.Agents.AgentPageableListOfVectorStoreObject @object = default(Azure.AI.Agents.AgentPageableListOfVectorStoreObject), System.Collections.Generic.IEnumerable<Azure.AI.Agents.VectorStore> data = null, string firstId = null, string lastId = null, bool hasMore = false) { throw null; }
        public static Azure.AI.Agents.AgentPageableListOfVectorStoreFile AgentPageableListOfVectorStoreFile(Azure.AI.Agents.AgentPageableListOfVectorStoreFileObject @object = default(Azure.AI.Agents.AgentPageableListOfVectorStoreFileObject), System.Collections.Generic.IEnumerable<Azure.AI.Agents.VectorStoreFile> data = null, string firstId = null, string lastId = null, bool hasMore = false) { throw null; }
        public static Azure.AI.Agents.AzureFunctionBinding AzureFunctionBinding(Azure.AI.Agents.AzureFunctionBindingType type = default(Azure.AI.Agents.AzureFunctionBindingType), Azure.AI.Agents.AzureFunctionStorageQueue storageQueue = null) { throw null; }
        public static Azure.AI.Agents.FileSearchToolCallContent FileSearchToolCallContent(Azure.AI.Agents.FileSearchToolCallContentType type = default(Azure.AI.Agents.FileSearchToolCallContentType), string text = null) { throw null; }
        public static Azure.AI.Agents.IncompleteRunDetails IncompleteRunDetails(Azure.AI.Agents.IncompleteDetailsReason reason = default(Azure.AI.Agents.IncompleteDetailsReason)) { throw null; }
        public static Azure.AI.Agents.MessageDelta MessageDelta(Azure.AI.Agents.MessageRole role = default(Azure.AI.Agents.MessageRole), System.Collections.Generic.IEnumerable<Azure.AI.Agents.MessageDeltaContent> content = null) { throw null; }
        public static Azure.AI.Agents.MessageDeltaChunk MessageDeltaChunk(string id = null, Azure.AI.Agents.MessageDeltaChunkObject @object = default(Azure.AI.Agents.MessageDeltaChunkObject), Azure.AI.Agents.MessageDelta delta = null) { throw null; }
        public static Azure.AI.Agents.MessageDeltaContent MessageDeltaContent(int index = 0, string type = null) { throw null; }
        public static Azure.AI.Agents.MessageDeltaImageFileContent MessageDeltaImageFileContent(int index = 0, Azure.AI.Agents.MessageDeltaImageFileContentObject imageFile = null) { throw null; }
        public static Azure.AI.Agents.MessageDeltaImageFileContentObject MessageDeltaImageFileContentObject(string fileId = null) { throw null; }
        public static Azure.AI.Agents.MessageDeltaTextAnnotation MessageDeltaTextAnnotation(int index = 0, string type = null) { throw null; }
        public static Azure.AI.Agents.MessageDeltaTextContent MessageDeltaTextContent(int index = 0, Azure.AI.Agents.MessageDeltaTextContentObject text = null) { throw null; }
        public static Azure.AI.Agents.MessageDeltaTextContentObject MessageDeltaTextContentObject(string value = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.MessageDeltaTextAnnotation> annotations = null) { throw null; }
        public static Azure.AI.Agents.MessageDeltaTextFileCitationAnnotation MessageDeltaTextFileCitationAnnotation(int index = 0, Azure.AI.Agents.MessageDeltaTextFileCitationAnnotationObject fileCitation = null, string text = null, int? startIndex = default(int?), int? endIndex = default(int?)) { throw null; }
        public static Azure.AI.Agents.MessageDeltaTextFileCitationAnnotationObject MessageDeltaTextFileCitationAnnotationObject(string fileId = null, string quote = null) { throw null; }
        public static Azure.AI.Agents.MessageDeltaTextFilePathAnnotation MessageDeltaTextFilePathAnnotation(int index = 0, Azure.AI.Agents.MessageDeltaTextFilePathAnnotationObject filePath = null, int? startIndex = default(int?), int? endIndex = default(int?), string text = null) { throw null; }
        public static Azure.AI.Agents.MessageDeltaTextFilePathAnnotationObject MessageDeltaTextFilePathAnnotationObject(string fileId = null) { throw null; }
        public static Azure.AI.Agents.MessageIncompleteDetails MessageIncompleteDetails(Azure.AI.Agents.MessageIncompleteDetailsReason reason = default(Azure.AI.Agents.MessageIncompleteDetailsReason)) { throw null; }
        public static Azure.AI.Agents.MessageTextAnnotation MessageTextAnnotation(string type = null, string text = null) { throw null; }
        public static Azure.AI.Agents.RequiredToolCall RequiredToolCall(string type = null, string id = null) { throw null; }
        public static Azure.AI.Agents.ResponseFormatJsonSchemaType ResponseFormatJsonSchemaType(Azure.AI.Agents.ResponseFormatJsonSchemaTypeType type = default(Azure.AI.Agents.ResponseFormatJsonSchemaTypeType), Azure.AI.Agents.ResponseFormatJsonSchema jsonSchema = null) { throw null; }
        public static Azure.AI.Agents.RunCompletionUsage RunCompletionUsage(long completionTokens = (long)0, long promptTokens = (long)0, long totalTokens = (long)0) { throw null; }
        public static Azure.AI.Agents.RunError RunError(string code = null, string message = null) { throw null; }
        public static Azure.AI.Agents.RunStepAzureAISearchToolCall RunStepAzureAISearchToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> azureAISearch = null) { throw null; }
        public static Azure.AI.Agents.RunStepBingGroundingToolCall RunStepBingGroundingToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> bingGrounding = null) { throw null; }
        public static Azure.AI.Agents.RunStepCodeInterpreterImageOutput RunStepCodeInterpreterImageOutput(Azure.AI.Agents.RunStepCodeInterpreterImageReference image = null) { throw null; }
        public static Azure.AI.Agents.RunStepCodeInterpreterImageReference RunStepCodeInterpreterImageReference(string fileId = null) { throw null; }
        public static Azure.AI.Agents.RunStepCodeInterpreterLogOutput RunStepCodeInterpreterLogOutput(string logs = null) { throw null; }
        public static Azure.AI.Agents.RunStepCompletionUsage RunStepCompletionUsage(long completionTokens = (long)0, long promptTokens = (long)0, long totalTokens = (long)0) { throw null; }
        public static Azure.AI.Agents.RunStepDelta RunStepDelta(Azure.AI.Agents.RunStepDeltaDetail stepDetails = null) { throw null; }
        public static Azure.AI.Agents.RunStepDeltaChunk RunStepDeltaChunk(string id = null, Azure.AI.Agents.RunStepDeltaChunkObject @object = default(Azure.AI.Agents.RunStepDeltaChunkObject), Azure.AI.Agents.RunStepDelta delta = null) { throw null; }
        public static Azure.AI.Agents.RunStepDeltaCodeInterpreterDetailItemObject RunStepDeltaCodeInterpreterDetailItemObject(string input = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.RunStepDeltaCodeInterpreterOutput> outputs = null) { throw null; }
        public static Azure.AI.Agents.RunStepDeltaCodeInterpreterImageOutput RunStepDeltaCodeInterpreterImageOutput(int index = 0, Azure.AI.Agents.RunStepDeltaCodeInterpreterImageOutputObject image = null) { throw null; }
        public static Azure.AI.Agents.RunStepDeltaCodeInterpreterImageOutputObject RunStepDeltaCodeInterpreterImageOutputObject(string fileId = null) { throw null; }
        public static Azure.AI.Agents.RunStepDeltaCodeInterpreterLogOutput RunStepDeltaCodeInterpreterLogOutput(int index = 0, string logs = null) { throw null; }
        public static Azure.AI.Agents.RunStepDeltaCodeInterpreterOutput RunStepDeltaCodeInterpreterOutput(int index = 0, string type = null) { throw null; }
        public static Azure.AI.Agents.RunStepDeltaCodeInterpreterToolCall RunStepDeltaCodeInterpreterToolCall(int index = 0, string id = null, Azure.AI.Agents.RunStepDeltaCodeInterpreterDetailItemObject codeInterpreter = null) { throw null; }
        public static Azure.AI.Agents.RunStepDeltaFileSearchToolCall RunStepDeltaFileSearchToolCall(int index = 0, string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> fileSearch = null) { throw null; }
        public static Azure.AI.Agents.RunStepDeltaFunction RunStepDeltaFunction(string name = null, string arguments = null, string output = null) { throw null; }
        public static Azure.AI.Agents.RunStepDeltaFunctionToolCall RunStepDeltaFunctionToolCall(int index = 0, string id = null, Azure.AI.Agents.RunStepDeltaFunction function = null) { throw null; }
        public static Azure.AI.Agents.RunStepDeltaMessageCreation RunStepDeltaMessageCreation(Azure.AI.Agents.RunStepDeltaMessageCreationObject messageCreation = null) { throw null; }
        public static Azure.AI.Agents.RunStepDeltaMessageCreationObject RunStepDeltaMessageCreationObject(string messageId = null) { throw null; }
        public static Azure.AI.Agents.RunStepDeltaToolCall RunStepDeltaToolCall(int index = 0, string id = null, string type = null) { throw null; }
        public static Azure.AI.Agents.RunStepDeltaToolCallObject RunStepDeltaToolCallObject(System.Collections.Generic.IEnumerable<Azure.AI.Agents.RunStepDeltaToolCall> toolCalls = null) { throw null; }
        public static Azure.AI.Agents.RunStepError RunStepError(Azure.AI.Agents.RunStepErrorCode code = default(Azure.AI.Agents.RunStepErrorCode), string message = null) { throw null; }
        public static Azure.AI.Agents.RunStepFileSearchToolCall RunStepFileSearchToolCall(string id = null, Azure.AI.Agents.RunStepFileSearchToolCallResults fileSearch = null) { throw null; }
        public static Azure.AI.Agents.RunStepFileSearchToolCallResult RunStepFileSearchToolCallResult(string fileId = null, string fileName = null, float score = 0f, System.Collections.Generic.IEnumerable<Azure.AI.Agents.FileSearchToolCallContent> content = null) { throw null; }
        public static Azure.AI.Agents.RunStepFileSearchToolCallResults RunStepFileSearchToolCallResults(Azure.AI.Agents.FileSearchRankingOptions rankingOptions = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.RunStepFileSearchToolCallResult> results = null) { throw null; }
        public static Azure.AI.Agents.RunStepMessageCreationDetails RunStepMessageCreationDetails(Azure.AI.Agents.RunStepMessageCreationReference messageCreation = null) { throw null; }
        public static Azure.AI.Agents.RunStepMessageCreationReference RunStepMessageCreationReference(string messageId = null) { throw null; }
        public static Azure.AI.Agents.RunStepMicrosoftFabricToolCall RunStepMicrosoftFabricToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> microsoftFabric = null) { throw null; }
        public static Azure.AI.Agents.RunStepSharepointToolCall RunStepSharepointToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> sharePoint = null) { throw null; }
        public static Azure.AI.Agents.RunStepToolCall RunStepToolCall(string type = null, string id = null) { throw null; }
        public static Azure.AI.Agents.RunStepToolCallDetails RunStepToolCallDetails(System.Collections.Generic.IEnumerable<Azure.AI.Agents.RunStepToolCall> toolCalls = null) { throw null; }
        public static Azure.AI.Agents.ThreadMessageOptions ThreadMessageOptions(Azure.AI.Agents.MessageRole role = default(Azure.AI.Agents.MessageRole), string content = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.MessageAttachment> attachments = null, System.Collections.Generic.IDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Agents.VectorStore VectorStore(string id = null, Azure.AI.Agents.VectorStoreObject @object = default(Azure.AI.Agents.VectorStoreObject), System.DateTimeOffset createdAt = default(System.DateTimeOffset), string name = null, int usageBytes = 0, Azure.AI.Agents.VectorStoreFileCount fileCounts = null, Azure.AI.Agents.VectorStoreStatus status = default(Azure.AI.Agents.VectorStoreStatus), Azure.AI.Agents.VectorStoreExpirationPolicy expiresAfter = null, System.DateTimeOffset? expiresAt = default(System.DateTimeOffset?), System.DateTimeOffset? lastActiveAt = default(System.DateTimeOffset?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Agents.VectorStoreDeletionStatus VectorStoreDeletionStatus(string id = null, bool deleted = false, Azure.AI.Agents.VectorStoreDeletionStatusObject @object = default(Azure.AI.Agents.VectorStoreDeletionStatusObject)) { throw null; }
        public static Azure.AI.Agents.VectorStoreFile VectorStoreFile(string id = null, Azure.AI.Agents.VectorStoreFileObject @object = default(Azure.AI.Agents.VectorStoreFileObject), int usageBytes = 0, System.DateTimeOffset createdAt = default(System.DateTimeOffset), string vectorStoreId = null, Azure.AI.Agents.VectorStoreFileStatus status = default(Azure.AI.Agents.VectorStoreFileStatus), Azure.AI.Agents.VectorStoreFileError lastError = null, Azure.AI.Agents.VectorStoreChunkingStrategyResponse chunkingStrategy = null) { throw null; }
        public static Azure.AI.Agents.VectorStoreFileBatch VectorStoreFileBatch(string id = null, Azure.AI.Agents.VectorStoreFileBatchObject @object = default(Azure.AI.Agents.VectorStoreFileBatchObject), System.DateTimeOffset createdAt = default(System.DateTimeOffset), string vectorStoreId = null, Azure.AI.Agents.VectorStoreFileBatchStatus status = default(Azure.AI.Agents.VectorStoreFileBatchStatus), Azure.AI.Agents.VectorStoreFileCount fileCounts = null) { throw null; }
        public static Azure.AI.Agents.VectorStoreFileCount VectorStoreFileCount(int inProgress = 0, int completed = 0, int failed = 0, int cancelled = 0, int total = 0) { throw null; }
        public static Azure.AI.Agents.VectorStoreFileDeletionStatus VectorStoreFileDeletionStatus(string id = null, bool deleted = false, Azure.AI.Agents.VectorStoreFileDeletionStatusObject @object = default(Azure.AI.Agents.VectorStoreFileDeletionStatusObject)) { throw null; }
        public static Azure.AI.Agents.VectorStoreFileError VectorStoreFileError(Azure.AI.Agents.VectorStoreFileErrorCode code = default(Azure.AI.Agents.VectorStoreFileErrorCode), string message = null) { throw null; }
        public static Azure.AI.Agents.VectorStoreStaticChunkingStrategyRequest VectorStoreStaticChunkingStrategyRequest(Azure.AI.Agents.VectorStoreStaticChunkingStrategyOptions @static = null) { throw null; }
        public static Azure.AI.Agents.VectorStoreStaticChunkingStrategyResponse VectorStoreStaticChunkingStrategyResponse(Azure.AI.Agents.VectorStoreStaticChunkingStrategyOptions @static = null) { throw null; }
    }
    public static partial class AIClientModelFactory
    {
        public static Azure.AI.Agents.Agent Agent(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), string name = null, string description = null, string model = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.ToolDefinition> tools = null, Azure.AI.Agents.ToolResources toolResources = null, float? temperature = default(float?), float? topP = default(float?), System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Agents.AgentFile AgentFile(string id = null, int size = 0, string filename = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), Azure.AI.Agents.AgentFilePurpose purpose = default(Azure.AI.Agents.AgentFilePurpose)) { throw null; }
        public static Azure.AI.Agents.AgentThread AgentThread(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), Azure.AI.Agents.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Agents.MessageTextFileCitationAnnotation MessageFileCitationTextAnnotation(string text, string fileId, string quote) { throw null; }
        public static Azure.AI.Agents.MessageTextFilePathAnnotation MessageFilePathTextAnnotation(string text, string fileId) { throw null; }
        public static Azure.AI.Agents.MessageImageFileContent MessageImageFileContent(string fileId) { throw null; }
        public static Azure.AI.Agents.MessageTextContent MessageTextContent(string text, System.Collections.Generic.IEnumerable<Azure.AI.Agents.MessageTextAnnotation> annotations) { throw null; }
        public static Azure.AI.Agents.PageableList<T> PageableList<T>(System.Collections.Generic.IReadOnlyList<T> data, string firstId, string lastId, bool hasMore) { throw null; }
        public static Azure.AI.Agents.RequiredFunctionToolCall RequiredFunctionToolCall(string toolCallId, string functionName, string functionArguments) { throw null; }
        public static Azure.AI.Agents.RunStep RunStep(string id = null, Azure.AI.Agents.RunStepType type = default(Azure.AI.Agents.RunStepType), string agentId = null, string threadId = null, string runId = null, Azure.AI.Agents.RunStepStatus status = default(Azure.AI.Agents.RunStepStatus), Azure.AI.Agents.RunStepDetails stepDetails = null, Azure.AI.Agents.RunStepError lastError = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset? expiredAt = default(System.DateTimeOffset?), System.DateTimeOffset? completedAt = default(System.DateTimeOffset?), System.DateTimeOffset? cancelledAt = default(System.DateTimeOffset?), System.DateTimeOffset? failedAt = default(System.DateTimeOffset?), Azure.AI.Agents.RunStepCompletionUsage usage = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Agents.RunStepCodeInterpreterToolCall RunStepCodeInterpreterToolCall(string id, string input, System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.RunStepCodeInterpreterToolCallOutput> outputs) { throw null; }
        public static Azure.AI.Agents.RunStepFunctionToolCall RunStepFunctionToolCall(string id, string name, string arguments, string output) { throw null; }
        public static Azure.AI.Agents.SubmitToolOutputsAction SubmitToolOutputsAction(System.Collections.Generic.IEnumerable<Azure.AI.Agents.RequiredToolCall> toolCalls) { throw null; }
        public static Azure.AI.Agents.ThreadMessage ThreadMessage(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), string threadId = null, Azure.AI.Agents.MessageStatus status = default(Azure.AI.Agents.MessageStatus), Azure.AI.Agents.MessageIncompleteDetails incompleteDetails = null, System.DateTimeOffset? completedAt = default(System.DateTimeOffset?), System.DateTimeOffset? incompleteAt = default(System.DateTimeOffset?), Azure.AI.Agents.MessageRole role = default(Azure.AI.Agents.MessageRole), System.Collections.Generic.IEnumerable<Azure.AI.Agents.MessageContent> contentItems = null, string agentId = null, string runId = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.MessageAttachment> attachments = null, System.Collections.Generic.IDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Agents.ThreadRun ThreadRun(string id = null, string threadId = null, string agentId = null, Azure.AI.Agents.RunStatus status = default(Azure.AI.Agents.RunStatus), Azure.AI.Agents.RequiredAction requiredAction = null, Azure.AI.Agents.RunError lastError = null, string model = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.ToolDefinition> tools = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset? expiresAt = default(System.DateTimeOffset?), System.DateTimeOffset? startedAt = default(System.DateTimeOffset?), System.DateTimeOffset? completedAt = default(System.DateTimeOffset?), System.DateTimeOffset? cancelledAt = default(System.DateTimeOffset?), System.DateTimeOffset? failedAt = default(System.DateTimeOffset?), Azure.AI.Agents.IncompleteRunDetails incompleteDetails = null, Azure.AI.Agents.RunCompletionUsage usage = null, float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Agents.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, Azure.AI.Agents.UpdateToolResourcesOptions toolResources = null, bool? parallelToolCalls = default(bool?)) { throw null; }
    }
    public partial class AzureAISearchResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureAISearchResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureAISearchResource>
    {
        public AzureAISearchResource() { }
        public System.Collections.Generic.IList<Azure.AI.Agents.IndexResource> IndexList { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AzureAISearchResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureAISearchResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureAISearchResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AzureAISearchResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureAISearchResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureAISearchResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureAISearchResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAISearchToolDefinition : Azure.AI.Agents.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureAISearchToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureAISearchToolDefinition>
    {
        public AzureAISearchToolDefinition() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AzureAISearchToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureAISearchToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureAISearchToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AzureAISearchToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureAISearchToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureAISearchToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureAISearchToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionBinding : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureFunctionBinding>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionBinding>
    {
        public AzureFunctionBinding(Azure.AI.Agents.AzureFunctionStorageQueue storageQueue) { }
        public Azure.AI.Agents.AzureFunctionStorageQueue StorageQueue { get { throw null; } set { } }
        public Azure.AI.Agents.AzureFunctionBindingType Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AzureFunctionBinding System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureFunctionBinding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureFunctionBinding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AzureFunctionBinding System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionBinding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionBinding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionBinding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureFunctionBindingType : System.IEquatable<Azure.AI.Agents.AzureFunctionBindingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureFunctionBindingType(string value) { throw null; }
        public static Azure.AI.Agents.AzureFunctionBindingType StorageQueue { get { throw null; } }
        public bool Equals(Azure.AI.Agents.AzureFunctionBindingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.AzureFunctionBindingType left, Azure.AI.Agents.AzureFunctionBindingType right) { throw null; }
        public static implicit operator Azure.AI.Agents.AzureFunctionBindingType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.AzureFunctionBindingType left, Azure.AI.Agents.AzureFunctionBindingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureFunctionStorageQueue : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureFunctionStorageQueue>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionStorageQueue>
    {
        public AzureFunctionStorageQueue(string storageServiceEndpoint, string queueName) { }
        public string QueueName { get { throw null; } set { } }
        public string StorageServiceEndpoint { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AzureFunctionStorageQueue System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureFunctionStorageQueue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureFunctionStorageQueue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AzureFunctionStorageQueue System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionStorageQueue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionStorageQueue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionStorageQueue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionToolDefinition : Azure.AI.Agents.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureFunctionToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionToolDefinition>
    {
        public AzureFunctionToolDefinition(string name, string description, Azure.AI.Agents.AzureFunctionBinding inputBinding, Azure.AI.Agents.AzureFunctionBinding outputBinding, System.BinaryData parameters) { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AzureFunctionToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureFunctionToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureFunctionToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AzureFunctionToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingGroundingToolDefinition : Azure.AI.Agents.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.BingGroundingToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BingGroundingToolDefinition>
    {
        public BingGroundingToolDefinition(Azure.AI.Agents.ToolConnectionList bingGrounding) { }
        public Azure.AI.Agents.ToolConnectionList BingGrounding { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.BingGroundingToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.BingGroundingToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.BingGroundingToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.BingGroundingToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BingGroundingToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BingGroundingToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BingGroundingToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CodeInterpreterToolDefinition : Azure.AI.Agents.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.CodeInterpreterToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.CodeInterpreterToolDefinition>
    {
        public CodeInterpreterToolDefinition() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.CodeInterpreterToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.CodeInterpreterToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.CodeInterpreterToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.CodeInterpreterToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.CodeInterpreterToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.CodeInterpreterToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.CodeInterpreterToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CodeInterpreterToolResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.CodeInterpreterToolResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.CodeInterpreterToolResource>
    {
        public CodeInterpreterToolResource() { }
        public System.Collections.Generic.IList<Azure.AI.Agents.VectorStoreDataSource> DataSources { get { throw null; } }
        public System.Collections.Generic.IList<string> FileIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.CodeInterpreterToolResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.CodeInterpreterToolResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.CodeInterpreterToolResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.CodeInterpreterToolResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.CodeInterpreterToolResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.CodeInterpreterToolResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.CodeInterpreterToolResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DoneEvent : System.IEquatable<Azure.AI.Agents.DoneEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DoneEvent(string value) { throw null; }
        public static Azure.AI.Agents.DoneEvent Done { get { throw null; } }
        public bool Equals(Azure.AI.Agents.DoneEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.DoneEvent left, Azure.AI.Agents.DoneEvent right) { throw null; }
        public static implicit operator Azure.AI.Agents.DoneEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.DoneEvent left, Azure.AI.Agents.DoneEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ErrorEvent : System.IEquatable<Azure.AI.Agents.ErrorEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ErrorEvent(string value) { throw null; }
        public static Azure.AI.Agents.ErrorEvent Error { get { throw null; } }
        public bool Equals(Azure.AI.Agents.ErrorEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.ErrorEvent left, Azure.AI.Agents.ErrorEvent right) { throw null; }
        public static implicit operator Azure.AI.Agents.ErrorEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.ErrorEvent left, Azure.AI.Agents.ErrorEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FileSearchRankingOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.FileSearchRankingOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FileSearchRankingOptions>
    {
        public FileSearchRankingOptions(string ranker, float scoreThreshold) { }
        public string Ranker { get { throw null; } set { } }
        public float ScoreThreshold { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.FileSearchRankingOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.FileSearchRankingOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.FileSearchRankingOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.FileSearchRankingOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FileSearchRankingOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FileSearchRankingOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FileSearchRankingOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSearchToolCallContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.FileSearchToolCallContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FileSearchToolCallContent>
    {
        internal FileSearchToolCallContent() { }
        public string Text { get { throw null; } }
        public Azure.AI.Agents.FileSearchToolCallContentType Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.FileSearchToolCallContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.FileSearchToolCallContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.FileSearchToolCallContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.FileSearchToolCallContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FileSearchToolCallContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FileSearchToolCallContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FileSearchToolCallContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileSearchToolCallContentType : System.IEquatable<Azure.AI.Agents.FileSearchToolCallContentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileSearchToolCallContentType(string value) { throw null; }
        public static Azure.AI.Agents.FileSearchToolCallContentType Text { get { throw null; } }
        public bool Equals(Azure.AI.Agents.FileSearchToolCallContentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.FileSearchToolCallContentType left, Azure.AI.Agents.FileSearchToolCallContentType right) { throw null; }
        public static implicit operator Azure.AI.Agents.FileSearchToolCallContentType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.FileSearchToolCallContentType left, Azure.AI.Agents.FileSearchToolCallContentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FileSearchToolDefinition : Azure.AI.Agents.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.FileSearchToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FileSearchToolDefinition>
    {
        public FileSearchToolDefinition() { }
        public Azure.AI.Agents.FileSearchToolDefinitionDetails FileSearch { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.FileSearchToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.FileSearchToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.FileSearchToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.FileSearchToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FileSearchToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FileSearchToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FileSearchToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSearchToolDefinitionDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.FileSearchToolDefinitionDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FileSearchToolDefinitionDetails>
    {
        public FileSearchToolDefinitionDetails() { }
        public int? MaxNumResults { get { throw null; } set { } }
        public Azure.AI.Agents.FileSearchRankingOptions RankingOptions { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.FileSearchToolDefinitionDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.FileSearchToolDefinitionDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.FileSearchToolDefinitionDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.FileSearchToolDefinitionDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FileSearchToolDefinitionDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FileSearchToolDefinitionDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FileSearchToolDefinitionDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSearchToolResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.FileSearchToolResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FileSearchToolResource>
    {
        public FileSearchToolResource() { }
        public FileSearchToolResource(System.Collections.Generic.IList<string> vectorStoreIds, System.Collections.Generic.IList<Azure.AI.Agents.VectorStoreConfigurations> vectorStores) { }
        public System.Collections.Generic.IList<string> VectorStoreIds { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Agents.VectorStoreConfigurations> VectorStores { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.FileSearchToolResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.FileSearchToolResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.FileSearchToolResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.FileSearchToolResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FileSearchToolResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FileSearchToolResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FileSearchToolResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileState : System.IEquatable<Azure.AI.Agents.FileState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileState(string value) { throw null; }
        public static Azure.AI.Agents.FileState Deleted { get { throw null; } }
        public static Azure.AI.Agents.FileState Deleting { get { throw null; } }
        public static Azure.AI.Agents.FileState Error { get { throw null; } }
        public static Azure.AI.Agents.FileState Pending { get { throw null; } }
        public static Azure.AI.Agents.FileState Processed { get { throw null; } }
        public static Azure.AI.Agents.FileState Running { get { throw null; } }
        public static Azure.AI.Agents.FileState Uploaded { get { throw null; } }
        public bool Equals(Azure.AI.Agents.FileState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.FileState left, Azure.AI.Agents.FileState right) { throw null; }
        public static implicit operator Azure.AI.Agents.FileState (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.FileState left, Azure.AI.Agents.FileState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FunctionName : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.FunctionName>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FunctionName>
    {
        public FunctionName(string name) { }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.FunctionName System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.FunctionName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.FunctionName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.FunctionName System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FunctionName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FunctionName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FunctionName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FunctionToolDefinition : Azure.AI.Agents.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.FunctionToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FunctionToolDefinition>
    {
        public FunctionToolDefinition(string name, string description) { }
        public FunctionToolDefinition(string name, string description, System.BinaryData parameters) { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static bool operator ==(Azure.AI.Agents.FunctionToolDefinition functionToolDefinition, Azure.AI.Agents.RequiredFunctionToolCall functionToolCall) { throw null; }
        public static bool operator ==(Azure.AI.Agents.FunctionToolDefinition functionToolDefinition, Azure.AI.Agents.RunStepFunctionToolCall functionToolCall) { throw null; }
        public static bool operator ==(Azure.AI.Agents.RequiredFunctionToolCall functionToolCall, Azure.AI.Agents.FunctionToolDefinition functionToolDefinition) { throw null; }
        public static bool operator ==(Azure.AI.Agents.RunStepFunctionToolCall functionToolCall, Azure.AI.Agents.FunctionToolDefinition functionToolDefinition) { throw null; }
        public static bool operator !=(Azure.AI.Agents.FunctionToolDefinition functionToolDefinition, Azure.AI.Agents.RequiredFunctionToolCall functionToolCall) { throw null; }
        public static bool operator !=(Azure.AI.Agents.FunctionToolDefinition functionToolDefinition, Azure.AI.Agents.RunStepFunctionToolCall functionToolCall) { throw null; }
        public static bool operator !=(Azure.AI.Agents.RequiredFunctionToolCall functionToolCall, Azure.AI.Agents.FunctionToolDefinition functionToolDefinition) { throw null; }
        public static bool operator !=(Azure.AI.Agents.RunStepFunctionToolCall functionToolCall, Azure.AI.Agents.FunctionToolDefinition functionToolDefinition) { throw null; }
        Azure.AI.Agents.FunctionToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.FunctionToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.FunctionToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.FunctionToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FunctionToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FunctionToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FunctionToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IncompleteDetailsReason : System.IEquatable<Azure.AI.Agents.IncompleteDetailsReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IncompleteDetailsReason(string value) { throw null; }
        public static Azure.AI.Agents.IncompleteDetailsReason MaxCompletionTokens { get { throw null; } }
        public static Azure.AI.Agents.IncompleteDetailsReason MaxPromptTokens { get { throw null; } }
        public bool Equals(Azure.AI.Agents.IncompleteDetailsReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.IncompleteDetailsReason left, Azure.AI.Agents.IncompleteDetailsReason right) { throw null; }
        public static implicit operator Azure.AI.Agents.IncompleteDetailsReason (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.IncompleteDetailsReason left, Azure.AI.Agents.IncompleteDetailsReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IncompleteRunDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.IncompleteRunDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.IncompleteRunDetails>
    {
        internal IncompleteRunDetails() { }
        public Azure.AI.Agents.IncompleteDetailsReason Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.IncompleteRunDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.IncompleteRunDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.IncompleteRunDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.IncompleteRunDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.IncompleteRunDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.IncompleteRunDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.IncompleteRunDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IndexResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.IndexResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.IndexResource>
    {
        public IndexResource(string indexConnectionId, string indexName) { }
        public string IndexConnectionId { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.IndexResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.IndexResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.IndexResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.IndexResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.IndexResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.IndexResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.IndexResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ListSortOrder : System.IEquatable<Azure.AI.Agents.ListSortOrder>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ListSortOrder(string value) { throw null; }
        public static Azure.AI.Agents.ListSortOrder Ascending { get { throw null; } }
        public static Azure.AI.Agents.ListSortOrder Descending { get { throw null; } }
        public bool Equals(Azure.AI.Agents.ListSortOrder other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.ListSortOrder left, Azure.AI.Agents.ListSortOrder right) { throw null; }
        public static implicit operator Azure.AI.Agents.ListSortOrder (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.ListSortOrder left, Azure.AI.Agents.ListSortOrder right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MessageAttachment : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageAttachment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageAttachment>
    {
        public MessageAttachment(Azure.AI.Agents.VectorStoreDataSource ds, System.Collections.Generic.List<Azure.AI.Agents.ToolDefinition> tools) { }
        public MessageAttachment(System.Collections.Generic.IEnumerable<System.BinaryData> tools) { }
        public MessageAttachment(string fileId, System.Collections.Generic.List<Azure.AI.Agents.ToolDefinition> tools) { }
        public Azure.AI.Agents.VectorStoreDataSource DataSource { get { throw null; } set { } }
        public string FileId { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> Tools { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageAttachment System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageAttachment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageAttachment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageAttachment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageAttachment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageAttachment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageAttachment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MessageContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageContent>
    {
        protected MessageContent() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageContentUpdate : Azure.AI.Agents.StreamingUpdate
    {
        internal MessageContentUpdate() { }
        public string ImageFileId { get { throw null; } }
        public string MessageId { get { throw null; } }
        public int MessageIndex { get { throw null; } }
        public Azure.AI.Agents.MessageRole? Role { get { throw null; } }
        public string Text { get { throw null; } }
        public Azure.AI.Agents.TextAnnotationUpdate TextAnnotation { get { throw null; } }
    }
    public partial class MessageDelta : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDelta>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDelta>
    {
        internal MessageDelta() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.MessageDeltaContent> Content { get { throw null; } }
        public Azure.AI.Agents.MessageRole Role { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageDelta System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDelta>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDelta>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageDelta System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDelta>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDelta>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDelta>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaChunk : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaChunk>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaChunk>
    {
        internal MessageDeltaChunk() { }
        public Azure.AI.Agents.MessageDelta Delta { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Agents.MessageDeltaChunkObject Object { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageDeltaChunk System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaChunk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaChunk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageDeltaChunk System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaChunk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaChunk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaChunk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageDeltaChunkObject : System.IEquatable<Azure.AI.Agents.MessageDeltaChunkObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageDeltaChunkObject(string value) { throw null; }
        public static Azure.AI.Agents.MessageDeltaChunkObject ThreadMessageDelta { get { throw null; } }
        public bool Equals(Azure.AI.Agents.MessageDeltaChunkObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.MessageDeltaChunkObject left, Azure.AI.Agents.MessageDeltaChunkObject right) { throw null; }
        public static implicit operator Azure.AI.Agents.MessageDeltaChunkObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.MessageDeltaChunkObject left, Azure.AI.Agents.MessageDeltaChunkObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class MessageDeltaContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaContent>
    {
        protected MessageDeltaContent(int index) { }
        public int Index { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageDeltaContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageDeltaContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaImageFileContent : Azure.AI.Agents.MessageDeltaContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaImageFileContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaImageFileContent>
    {
        internal MessageDeltaImageFileContent() : base (default(int)) { }
        public Azure.AI.Agents.MessageDeltaImageFileContentObject ImageFile { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageDeltaImageFileContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaImageFileContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaImageFileContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageDeltaImageFileContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaImageFileContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaImageFileContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaImageFileContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaImageFileContentObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaImageFileContentObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaImageFileContentObject>
    {
        internal MessageDeltaImageFileContentObject() { }
        public string FileId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageDeltaImageFileContentObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaImageFileContentObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaImageFileContentObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageDeltaImageFileContentObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaImageFileContentObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaImageFileContentObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaImageFileContentObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MessageDeltaTextAnnotation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaTextAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaTextAnnotation>
    {
        protected internal System.Collections.Generic.IDictionary<string, System.BinaryData> SerializedAdditionalRawData;
        protected MessageDeltaTextAnnotation(int index) { }
        public int Index { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageDeltaTextAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaTextAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaTextAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageDeltaTextAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaTextAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaTextAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaTextAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextContent : Azure.AI.Agents.MessageDeltaContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaTextContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaTextContent>
    {
        internal MessageDeltaTextContent() : base (default(int)) { }
        public Azure.AI.Agents.MessageDeltaTextContentObject Text { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageDeltaTextContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaTextContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaTextContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageDeltaTextContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaTextContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaTextContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaTextContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextContentObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaTextContentObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaTextContentObject>
    {
        internal MessageDeltaTextContentObject() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.MessageDeltaTextAnnotation> Annotations { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageDeltaTextContentObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaTextContentObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaTextContentObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageDeltaTextContentObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaTextContentObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaTextContentObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaTextContentObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextFileCitationAnnotation : Azure.AI.Agents.MessageDeltaTextAnnotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaTextFileCitationAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaTextFileCitationAnnotation>
    {
        internal MessageDeltaTextFileCitationAnnotation() : base (default(int)) { }
        public int? EndIndex { get { throw null; } }
        public Azure.AI.Agents.MessageDeltaTextFileCitationAnnotationObject FileCitation { get { throw null; } }
        public int? StartIndex { get { throw null; } }
        public string Text { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageDeltaTextFileCitationAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaTextFileCitationAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaTextFileCitationAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageDeltaTextFileCitationAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaTextFileCitationAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaTextFileCitationAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaTextFileCitationAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextFileCitationAnnotationObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaTextFileCitationAnnotationObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaTextFileCitationAnnotationObject>
    {
        internal MessageDeltaTextFileCitationAnnotationObject() { }
        public string FileId { get { throw null; } }
        public string Quote { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageDeltaTextFileCitationAnnotationObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaTextFileCitationAnnotationObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaTextFileCitationAnnotationObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageDeltaTextFileCitationAnnotationObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaTextFileCitationAnnotationObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaTextFileCitationAnnotationObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaTextFileCitationAnnotationObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextFilePathAnnotation : Azure.AI.Agents.MessageDeltaTextAnnotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaTextFilePathAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaTextFilePathAnnotation>
    {
        internal MessageDeltaTextFilePathAnnotation() : base (default(int)) { }
        public int? EndIndex { get { throw null; } }
        public Azure.AI.Agents.MessageDeltaTextFilePathAnnotationObject FilePath { get { throw null; } }
        public int? StartIndex { get { throw null; } }
        public string Text { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageDeltaTextFilePathAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaTextFilePathAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaTextFilePathAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageDeltaTextFilePathAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaTextFilePathAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaTextFilePathAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaTextFilePathAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextFilePathAnnotationObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaTextFilePathAnnotationObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaTextFilePathAnnotationObject>
    {
        internal MessageDeltaTextFilePathAnnotationObject() { }
        public string FileId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageDeltaTextFilePathAnnotationObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaTextFilePathAnnotationObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageDeltaTextFilePathAnnotationObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageDeltaTextFilePathAnnotationObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaTextFilePathAnnotationObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaTextFilePathAnnotationObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageDeltaTextFilePathAnnotationObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageImageFileContent : Azure.AI.Agents.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageImageFileContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageImageFileContent>
    {
        internal MessageImageFileContent() { }
        public string FileId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageImageFileContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageImageFileContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageImageFileContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageImageFileContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageImageFileContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageImageFileContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageImageFileContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageIncompleteDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageIncompleteDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageIncompleteDetails>
    {
        internal MessageIncompleteDetails() { }
        public Azure.AI.Agents.MessageIncompleteDetailsReason Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageIncompleteDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageIncompleteDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageIncompleteDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageIncompleteDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageIncompleteDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageIncompleteDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageIncompleteDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageIncompleteDetailsReason : System.IEquatable<Azure.AI.Agents.MessageIncompleteDetailsReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageIncompleteDetailsReason(string value) { throw null; }
        public static Azure.AI.Agents.MessageIncompleteDetailsReason ContentFilter { get { throw null; } }
        public static Azure.AI.Agents.MessageIncompleteDetailsReason MaxTokens { get { throw null; } }
        public static Azure.AI.Agents.MessageIncompleteDetailsReason RunCancelled { get { throw null; } }
        public static Azure.AI.Agents.MessageIncompleteDetailsReason RunExpired { get { throw null; } }
        public static Azure.AI.Agents.MessageIncompleteDetailsReason RunFailed { get { throw null; } }
        public bool Equals(Azure.AI.Agents.MessageIncompleteDetailsReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.MessageIncompleteDetailsReason left, Azure.AI.Agents.MessageIncompleteDetailsReason right) { throw null; }
        public static implicit operator Azure.AI.Agents.MessageIncompleteDetailsReason (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.MessageIncompleteDetailsReason left, Azure.AI.Agents.MessageIncompleteDetailsReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageRole : System.IEquatable<Azure.AI.Agents.MessageRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageRole(string value) { throw null; }
        public static Azure.AI.Agents.MessageRole Agent { get { throw null; } }
        public static Azure.AI.Agents.MessageRole User { get { throw null; } }
        public bool Equals(Azure.AI.Agents.MessageRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.MessageRole left, Azure.AI.Agents.MessageRole right) { throw null; }
        public static implicit operator Azure.AI.Agents.MessageRole (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.MessageRole left, Azure.AI.Agents.MessageRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageStatus : System.IEquatable<Azure.AI.Agents.MessageStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageStatus(string value) { throw null; }
        public static Azure.AI.Agents.MessageStatus Completed { get { throw null; } }
        public static Azure.AI.Agents.MessageStatus Incomplete { get { throw null; } }
        public static Azure.AI.Agents.MessageStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Agents.MessageStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.MessageStatus left, Azure.AI.Agents.MessageStatus right) { throw null; }
        public static implicit operator Azure.AI.Agents.MessageStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.MessageStatus left, Azure.AI.Agents.MessageStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MessageStatusUpdate : Azure.AI.Agents.StreamingUpdate<Azure.AI.Agents.ThreadMessage>
    {
        internal MessageStatusUpdate() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageStreamEvent : System.IEquatable<Azure.AI.Agents.MessageStreamEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageStreamEvent(string value) { throw null; }
        public static Azure.AI.Agents.MessageStreamEvent ThreadMessageCompleted { get { throw null; } }
        public static Azure.AI.Agents.MessageStreamEvent ThreadMessageCreated { get { throw null; } }
        public static Azure.AI.Agents.MessageStreamEvent ThreadMessageDelta { get { throw null; } }
        public static Azure.AI.Agents.MessageStreamEvent ThreadMessageIncomplete { get { throw null; } }
        public static Azure.AI.Agents.MessageStreamEvent ThreadMessageInProgress { get { throw null; } }
        public bool Equals(Azure.AI.Agents.MessageStreamEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.MessageStreamEvent left, Azure.AI.Agents.MessageStreamEvent right) { throw null; }
        public static implicit operator Azure.AI.Agents.MessageStreamEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.MessageStreamEvent left, Azure.AI.Agents.MessageStreamEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class MessageTextAnnotation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageTextAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageTextAnnotation>
    {
        protected MessageTextAnnotation(string text) { }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageTextAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageTextAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageTextAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageTextAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageTextAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageTextAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageTextAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTextContent : Azure.AI.Agents.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageTextContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageTextContent>
    {
        internal MessageTextContent() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.MessageTextAnnotation> Annotations { get { throw null; } }
        public string Text { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageTextContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageTextContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageTextContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageTextContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageTextContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageTextContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageTextContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTextFileCitationAnnotation : Azure.AI.Agents.MessageTextAnnotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageTextFileCitationAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageTextFileCitationAnnotation>
    {
        internal MessageTextFileCitationAnnotation() : base (default(string)) { }
        public int? EndIndex { get { throw null; } }
        public string FileId { get { throw null; } }
        public string Quote { get { throw null; } }
        public int? StartIndex { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageTextFileCitationAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageTextFileCitationAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageTextFileCitationAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageTextFileCitationAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageTextFileCitationAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageTextFileCitationAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageTextFileCitationAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTextFilePathAnnotation : Azure.AI.Agents.MessageTextAnnotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageTextFilePathAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageTextFilePathAnnotation>
    {
        internal MessageTextFilePathAnnotation() : base (default(string)) { }
        public int? EndIndex { get { throw null; } }
        public string FileId { get { throw null; } }
        public int? StartIndex { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageTextFilePathAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageTextFilePathAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MessageTextFilePathAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MessageTextFilePathAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageTextFilePathAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageTextFilePathAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MessageTextFilePathAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MicrosoftFabricToolDefinition : Azure.AI.Agents.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MicrosoftFabricToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MicrosoftFabricToolDefinition>
    {
        public MicrosoftFabricToolDefinition(Azure.AI.Agents.ToolConnectionList fabricAiskill) { }
        public Azure.AI.Agents.ToolConnectionList FabricAiskill { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MicrosoftFabricToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MicrosoftFabricToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MicrosoftFabricToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MicrosoftFabricToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MicrosoftFabricToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MicrosoftFabricToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MicrosoftFabricToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiAnonymousAuthDetails : Azure.AI.Agents.OpenApiAuthDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiAnonymousAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiAnonymousAuthDetails>
    {
        public OpenApiAnonymousAuthDetails() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.OpenApiAnonymousAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiAnonymousAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiAnonymousAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.OpenApiAnonymousAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiAnonymousAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiAnonymousAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiAnonymousAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class OpenApiAuthDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiAuthDetails>
    {
        protected OpenApiAuthDetails() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.OpenApiAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.OpenApiAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiConnectionAuthDetails : Azure.AI.Agents.OpenApiAuthDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiConnectionAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiConnectionAuthDetails>
    {
        public OpenApiConnectionAuthDetails(Azure.AI.Agents.OpenApiConnectionSecurityScheme securityScheme) { }
        public Azure.AI.Agents.OpenApiConnectionSecurityScheme SecurityScheme { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.OpenApiConnectionAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiConnectionAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiConnectionAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.OpenApiConnectionAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiConnectionAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiConnectionAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiConnectionAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiConnectionSecurityScheme : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiConnectionSecurityScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiConnectionSecurityScheme>
    {
        public OpenApiConnectionSecurityScheme(string connectionId) { }
        public string ConnectionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.OpenApiConnectionSecurityScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiConnectionSecurityScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiConnectionSecurityScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.OpenApiConnectionSecurityScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiConnectionSecurityScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiConnectionSecurityScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiConnectionSecurityScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiFunctionDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiFunctionDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiFunctionDefinition>
    {
        public OpenApiFunctionDefinition(string name, System.BinaryData spec, Azure.AI.Agents.OpenApiAuthDetails auth) { }
        public Azure.AI.Agents.OpenApiAuthDetails Auth { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Spec { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.OpenApiFunctionDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiFunctionDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiFunctionDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.OpenApiFunctionDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiFunctionDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiFunctionDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiFunctionDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiManagedAuthDetails : Azure.AI.Agents.OpenApiAuthDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiManagedAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiManagedAuthDetails>
    {
        public OpenApiManagedAuthDetails(Azure.AI.Agents.OpenApiManagedSecurityScheme securityScheme) { }
        public Azure.AI.Agents.OpenApiManagedSecurityScheme SecurityScheme { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.OpenApiManagedAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiManagedAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiManagedAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.OpenApiManagedAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiManagedAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiManagedAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiManagedAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiManagedSecurityScheme : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiManagedSecurityScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiManagedSecurityScheme>
    {
        public OpenApiManagedSecurityScheme(string audience) { }
        public string Audience { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.OpenApiManagedSecurityScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiManagedSecurityScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiManagedSecurityScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.OpenApiManagedSecurityScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiManagedSecurityScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiManagedSecurityScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiManagedSecurityScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiToolDefinition : Azure.AI.Agents.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiToolDefinition>
    {
        public OpenApiToolDefinition(Azure.AI.Agents.OpenApiFunctionDefinition openapi) { }
        public OpenApiToolDefinition(string name, string description, System.BinaryData spec, Azure.AI.Agents.OpenApiAuthDetails auth) { }
        public Azure.AI.Agents.OpenApiFunctionDefinition Openapi { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.OpenApiToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.OpenApiToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PageableList<T> : System.Collections.Generic.IEnumerable<T>, System.Collections.IEnumerable
    {
        internal PageableList() { }
        public System.Collections.Generic.IReadOnlyList<T> Data { get { throw null; } }
        public string FirstId { get { throw null; } }
        public bool HasMore { get { throw null; } }
        public T this[int index] { get { throw null; } }
        public string LastId { get { throw null; } }
        public System.Collections.Generic.IEnumerator<T> GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public abstract partial class RequiredAction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RequiredAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RequiredAction>
    {
        protected RequiredAction() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RequiredAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RequiredAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RequiredAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RequiredAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RequiredAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RequiredAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RequiredAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RequiredActionUpdate : Azure.AI.Agents.RunUpdate
    {
        internal RequiredActionUpdate() { }
        public string FunctionArguments { get { throw null; } }
        public string FunctionName { get { throw null; } }
        public string ToolCallId { get { throw null; } }
        public Azure.AI.Agents.ThreadRun GetThreadRun() { throw null; }
    }
    public partial class RequiredFunctionToolCall : Azure.AI.Agents.RequiredToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RequiredFunctionToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RequiredFunctionToolCall>
    {
        internal RequiredFunctionToolCall() : base (default(string)) { }
        public string Arguments { get { throw null; } }
        public string Name { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RequiredFunctionToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RequiredFunctionToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RequiredFunctionToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RequiredFunctionToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RequiredFunctionToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RequiredFunctionToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RequiredFunctionToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RequiredToolCall : Azure.AI.Agents.RequiredAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RequiredToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RequiredToolCall>
    {
        protected RequiredToolCall(string id) { }
        public string Id { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RequiredToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RequiredToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RequiredToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RequiredToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RequiredToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RequiredToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RequiredToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResponseFormat : System.IEquatable<Azure.AI.Agents.ResponseFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResponseFormat(string value) { throw null; }
        public static Azure.AI.Agents.ResponseFormat JsonObject { get { throw null; } }
        public static Azure.AI.Agents.ResponseFormat Text { get { throw null; } }
        public bool Equals(Azure.AI.Agents.ResponseFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.ResponseFormat left, Azure.AI.Agents.ResponseFormat right) { throw null; }
        public static implicit operator Azure.AI.Agents.ResponseFormat (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.ResponseFormat left, Azure.AI.Agents.ResponseFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResponseFormatJsonSchema : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ResponseFormatJsonSchema>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ResponseFormatJsonSchema>
    {
        public ResponseFormatJsonSchema(string name, System.BinaryData schema) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Schema { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.ResponseFormatJsonSchema System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ResponseFormatJsonSchema>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ResponseFormatJsonSchema>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.ResponseFormatJsonSchema System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ResponseFormatJsonSchema>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ResponseFormatJsonSchema>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ResponseFormatJsonSchema>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponseFormatJsonSchemaType : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ResponseFormatJsonSchemaType>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ResponseFormatJsonSchemaType>
    {
        public ResponseFormatJsonSchemaType(Azure.AI.Agents.ResponseFormatJsonSchema jsonSchema) { }
        public Azure.AI.Agents.ResponseFormatJsonSchema JsonSchema { get { throw null; } set { } }
        public Azure.AI.Agents.ResponseFormatJsonSchemaTypeType Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.ResponseFormatJsonSchemaType System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ResponseFormatJsonSchemaType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ResponseFormatJsonSchemaType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.ResponseFormatJsonSchemaType System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ResponseFormatJsonSchemaType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ResponseFormatJsonSchemaType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ResponseFormatJsonSchemaType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResponseFormatJsonSchemaTypeType : System.IEquatable<Azure.AI.Agents.ResponseFormatJsonSchemaTypeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResponseFormatJsonSchemaTypeType(string value) { throw null; }
        public static Azure.AI.Agents.ResponseFormatJsonSchemaTypeType JsonSchema { get { throw null; } }
        public bool Equals(Azure.AI.Agents.ResponseFormatJsonSchemaTypeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.ResponseFormatJsonSchemaTypeType left, Azure.AI.Agents.ResponseFormatJsonSchemaTypeType right) { throw null; }
        public static implicit operator Azure.AI.Agents.ResponseFormatJsonSchemaTypeType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.ResponseFormatJsonSchemaTypeType left, Azure.AI.Agents.ResponseFormatJsonSchemaTypeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunAdditionalFieldList : System.IEquatable<Azure.AI.Agents.RunAdditionalFieldList>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunAdditionalFieldList(string value) { throw null; }
        public static Azure.AI.Agents.RunAdditionalFieldList FileSearchContents { get { throw null; } }
        public bool Equals(Azure.AI.Agents.RunAdditionalFieldList other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.RunAdditionalFieldList left, Azure.AI.Agents.RunAdditionalFieldList right) { throw null; }
        public static implicit operator Azure.AI.Agents.RunAdditionalFieldList (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.RunAdditionalFieldList left, Azure.AI.Agents.RunAdditionalFieldList right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunCompletionUsage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunCompletionUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunCompletionUsage>
    {
        internal RunCompletionUsage() { }
        public long CompletionTokens { get { throw null; } }
        public long PromptTokens { get { throw null; } }
        public long TotalTokens { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunCompletionUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunCompletionUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunCompletionUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunCompletionUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunCompletionUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunCompletionUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunCompletionUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunError>
    {
        internal RunError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunError System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStatus : System.IEquatable<Azure.AI.Agents.RunStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStatus(string value) { throw null; }
        public static Azure.AI.Agents.RunStatus Cancelled { get { throw null; } }
        public static Azure.AI.Agents.RunStatus Cancelling { get { throw null; } }
        public static Azure.AI.Agents.RunStatus Completed { get { throw null; } }
        public static Azure.AI.Agents.RunStatus Expired { get { throw null; } }
        public static Azure.AI.Agents.RunStatus Failed { get { throw null; } }
        public static Azure.AI.Agents.RunStatus InProgress { get { throw null; } }
        public static Azure.AI.Agents.RunStatus Queued { get { throw null; } }
        public static Azure.AI.Agents.RunStatus RequiresAction { get { throw null; } }
        public bool Equals(Azure.AI.Agents.RunStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.RunStatus left, Azure.AI.Agents.RunStatus right) { throw null; }
        public static implicit operator Azure.AI.Agents.RunStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.RunStatus left, Azure.AI.Agents.RunStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunStep : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStep>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStep>
    {
        internal RunStep() { }
        public string AssistantId { get { throw null; } }
        public System.DateTimeOffset? CancelledAt { get { throw null; } }
        public System.DateTimeOffset? CompletedAt { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public System.DateTimeOffset? ExpiredAt { get { throw null; } }
        public System.DateTimeOffset? FailedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Agents.RunStepError LastError { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string RunId { get { throw null; } }
        public Azure.AI.Agents.RunStepStatus Status { get { throw null; } }
        public Azure.AI.Agents.RunStepDetails StepDetails { get { throw null; } }
        public string ThreadId { get { throw null; } }
        public Azure.AI.Agents.RunStepType Type { get { throw null; } }
        public Azure.AI.Agents.RunStepCompletionUsage Usage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStep System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStep System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepAzureAISearchToolCall : Azure.AI.Agents.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepAzureAISearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepAzureAISearchToolCall>
    {
        internal RunStepAzureAISearchToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> AzureAISearch { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepAzureAISearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepAzureAISearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepAzureAISearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepAzureAISearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepAzureAISearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepAzureAISearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepAzureAISearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepBingGroundingToolCall : Azure.AI.Agents.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepBingGroundingToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepBingGroundingToolCall>
    {
        internal RunStepBingGroundingToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> BingGrounding { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepBingGroundingToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepBingGroundingToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepBingGroundingToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepBingGroundingToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepBingGroundingToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepBingGroundingToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepBingGroundingToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCodeInterpreterImageOutput : Azure.AI.Agents.RunStepCodeInterpreterToolCallOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepCodeInterpreterImageOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepCodeInterpreterImageOutput>
    {
        internal RunStepCodeInterpreterImageOutput() { }
        public Azure.AI.Agents.RunStepCodeInterpreterImageReference Image { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepCodeInterpreterImageOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepCodeInterpreterImageOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepCodeInterpreterImageOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepCodeInterpreterImageOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepCodeInterpreterImageOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepCodeInterpreterImageOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepCodeInterpreterImageOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCodeInterpreterImageReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepCodeInterpreterImageReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepCodeInterpreterImageReference>
    {
        internal RunStepCodeInterpreterImageReference() { }
        public string FileId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepCodeInterpreterImageReference System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepCodeInterpreterImageReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepCodeInterpreterImageReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepCodeInterpreterImageReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepCodeInterpreterImageReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepCodeInterpreterImageReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepCodeInterpreterImageReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCodeInterpreterLogOutput : Azure.AI.Agents.RunStepCodeInterpreterToolCallOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepCodeInterpreterLogOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepCodeInterpreterLogOutput>
    {
        internal RunStepCodeInterpreterLogOutput() { }
        public string Logs { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepCodeInterpreterLogOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepCodeInterpreterLogOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepCodeInterpreterLogOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepCodeInterpreterLogOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepCodeInterpreterLogOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepCodeInterpreterLogOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepCodeInterpreterLogOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCodeInterpreterToolCall : Azure.AI.Agents.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepCodeInterpreterToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepCodeInterpreterToolCall>
    {
        internal RunStepCodeInterpreterToolCall() : base (default(string)) { }
        public string Input { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.RunStepCodeInterpreterToolCallOutput> Outputs { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepCodeInterpreterToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepCodeInterpreterToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepCodeInterpreterToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepCodeInterpreterToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepCodeInterpreterToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepCodeInterpreterToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepCodeInterpreterToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepCodeInterpreterToolCallOutput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepCodeInterpreterToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepCodeInterpreterToolCallOutput>
    {
        protected RunStepCodeInterpreterToolCallOutput() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepCodeInterpreterToolCallOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepCodeInterpreterToolCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepCodeInterpreterToolCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepCodeInterpreterToolCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepCodeInterpreterToolCallOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepCodeInterpreterToolCallOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepCodeInterpreterToolCallOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCompletionUsage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepCompletionUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepCompletionUsage>
    {
        internal RunStepCompletionUsage() { }
        public long CompletionTokens { get { throw null; } }
        public long PromptTokens { get { throw null; } }
        public long TotalTokens { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepCompletionUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepCompletionUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepCompletionUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepCompletionUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepCompletionUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepCompletionUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepCompletionUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDelta : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDelta>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDelta>
    {
        internal RunStepDelta() { }
        public Azure.AI.Agents.RunStepDeltaDetail StepDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDelta System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDelta>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDelta>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDelta System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDelta>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDelta>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDelta>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaChunk : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaChunk>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaChunk>
    {
        internal RunStepDeltaChunk() { }
        public Azure.AI.Agents.RunStepDelta Delta { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Agents.RunStepDeltaChunkObject Object { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDeltaChunk System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaChunk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaChunk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDeltaChunk System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaChunk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaChunk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaChunk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepDeltaChunkObject : System.IEquatable<Azure.AI.Agents.RunStepDeltaChunkObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepDeltaChunkObject(string value) { throw null; }
        public static Azure.AI.Agents.RunStepDeltaChunkObject ThreadRunStepDelta { get { throw null; } }
        public bool Equals(Azure.AI.Agents.RunStepDeltaChunkObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.RunStepDeltaChunkObject left, Azure.AI.Agents.RunStepDeltaChunkObject right) { throw null; }
        public static implicit operator Azure.AI.Agents.RunStepDeltaChunkObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.RunStepDeltaChunkObject left, Azure.AI.Agents.RunStepDeltaChunkObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunStepDeltaCodeInterpreterDetailItemObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterDetailItemObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterDetailItemObject>
    {
        internal RunStepDeltaCodeInterpreterDetailItemObject() { }
        public string Input { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.RunStepDeltaCodeInterpreterOutput> Outputs { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDeltaCodeInterpreterDetailItemObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterDetailItemObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterDetailItemObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDeltaCodeInterpreterDetailItemObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterDetailItemObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterDetailItemObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterDetailItemObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaCodeInterpreterImageOutput : Azure.AI.Agents.RunStepDeltaCodeInterpreterOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterImageOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterImageOutput>
    {
        internal RunStepDeltaCodeInterpreterImageOutput() : base (default(int)) { }
        public Azure.AI.Agents.RunStepDeltaCodeInterpreterImageOutputObject Image { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDeltaCodeInterpreterImageOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterImageOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterImageOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDeltaCodeInterpreterImageOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterImageOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterImageOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterImageOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaCodeInterpreterImageOutputObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterImageOutputObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterImageOutputObject>
    {
        internal RunStepDeltaCodeInterpreterImageOutputObject() { }
        public string FileId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDeltaCodeInterpreterImageOutputObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterImageOutputObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterImageOutputObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDeltaCodeInterpreterImageOutputObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterImageOutputObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterImageOutputObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterImageOutputObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaCodeInterpreterLogOutput : Azure.AI.Agents.RunStepDeltaCodeInterpreterOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterLogOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterLogOutput>
    {
        internal RunStepDeltaCodeInterpreterLogOutput() : base (default(int)) { }
        public string Logs { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDeltaCodeInterpreterLogOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterLogOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterLogOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDeltaCodeInterpreterLogOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterLogOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterLogOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterLogOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepDeltaCodeInterpreterOutput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterOutput>
    {
        protected RunStepDeltaCodeInterpreterOutput(int index) { }
        public int Index { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDeltaCodeInterpreterOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDeltaCodeInterpreterOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaCodeInterpreterToolCall : Azure.AI.Agents.RunStepDeltaToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterToolCall>
    {
        internal RunStepDeltaCodeInterpreterToolCall() : base (default(int), default(string)) { }
        public Azure.AI.Agents.RunStepDeltaCodeInterpreterDetailItemObject CodeInterpreter { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDeltaCodeInterpreterToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDeltaCodeInterpreterToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaCodeInterpreterToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepDeltaDetail : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaDetail>
    {
        protected RunStepDeltaDetail() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDeltaDetail System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDeltaDetail System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaFileSearchToolCall : Azure.AI.Agents.RunStepDeltaToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaFileSearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaFileSearchToolCall>
    {
        internal RunStepDeltaFileSearchToolCall() : base (default(int), default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> FileSearch { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDeltaFileSearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaFileSearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaFileSearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDeltaFileSearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaFileSearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaFileSearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaFileSearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaFunction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaFunction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaFunction>
    {
        internal RunStepDeltaFunction() { }
        public string Arguments { get { throw null; } }
        public string Name { get { throw null; } }
        public string Output { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDeltaFunction System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaFunction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaFunction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDeltaFunction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaFunction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaFunction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaFunction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaFunctionToolCall : Azure.AI.Agents.RunStepDeltaToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaFunctionToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaFunctionToolCall>
    {
        internal RunStepDeltaFunctionToolCall() : base (default(int), default(string)) { }
        public Azure.AI.Agents.RunStepDeltaFunction Function { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDeltaFunctionToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaFunctionToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaFunctionToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDeltaFunctionToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaFunctionToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaFunctionToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaFunctionToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaMessageCreation : Azure.AI.Agents.RunStepDeltaDetail, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaMessageCreation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaMessageCreation>
    {
        internal RunStepDeltaMessageCreation() { }
        public Azure.AI.Agents.RunStepDeltaMessageCreationObject MessageCreation { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDeltaMessageCreation System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaMessageCreation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaMessageCreation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDeltaMessageCreation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaMessageCreation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaMessageCreation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaMessageCreation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaMessageCreationObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaMessageCreationObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaMessageCreationObject>
    {
        internal RunStepDeltaMessageCreationObject() { }
        public string MessageId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDeltaMessageCreationObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaMessageCreationObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaMessageCreationObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDeltaMessageCreationObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaMessageCreationObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaMessageCreationObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaMessageCreationObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepDeltaToolCall : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaToolCall>
    {
        protected internal System.Collections.Generic.IDictionary<string, System.BinaryData> SerializedAdditionalRawData;
        protected RunStepDeltaToolCall(int index, string id) { }
        public string Id { get { throw null; } }
        public int Index { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDeltaToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDeltaToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaToolCallObject : Azure.AI.Agents.RunStepDeltaDetail, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaToolCallObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaToolCallObject>
    {
        internal RunStepDeltaToolCallObject() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.RunStepDeltaToolCall> ToolCalls { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDeltaToolCallObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaToolCallObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDeltaToolCallObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDeltaToolCallObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaToolCallObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaToolCallObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDeltaToolCallObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDetails>
    {
        protected RunStepDetails() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDetailsUpdate : Azure.AI.Agents.StreamingUpdate
    {
        internal RunStepDetailsUpdate() { }
        public string CodeInterpreterInput { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.RunStepDeltaCodeInterpreterOutput> CodeInterpreterOutputs { get { throw null; } }
        public string CreatedMessageId { get { throw null; } }
        public string FunctionArguments { get { throw null; } }
        public string FunctionName { get { throw null; } }
        public string FunctionOutput { get { throw null; } }
        public string StepId { get { throw null; } }
        public string ToolCallId { get { throw null; } }
        public int? ToolCallIndex { get { throw null; } }
    }
    public partial class RunStepError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepError>
    {
        internal RunStepError() { }
        public Azure.AI.Agents.RunStepErrorCode Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepError System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepErrorCode : System.IEquatable<Azure.AI.Agents.RunStepErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepErrorCode(string value) { throw null; }
        public static Azure.AI.Agents.RunStepErrorCode RateLimitExceeded { get { throw null; } }
        public static Azure.AI.Agents.RunStepErrorCode ServerError { get { throw null; } }
        public bool Equals(Azure.AI.Agents.RunStepErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.RunStepErrorCode left, Azure.AI.Agents.RunStepErrorCode right) { throw null; }
        public static implicit operator Azure.AI.Agents.RunStepErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.RunStepErrorCode left, Azure.AI.Agents.RunStepErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunStepFileSearchToolCall : Azure.AI.Agents.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepFileSearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepFileSearchToolCall>
    {
        internal RunStepFileSearchToolCall() : base (default(string)) { }
        public Azure.AI.Agents.RunStepFileSearchToolCallResults FileSearch { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepFileSearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepFileSearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepFileSearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepFileSearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepFileSearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepFileSearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepFileSearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepFileSearchToolCallResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepFileSearchToolCallResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepFileSearchToolCallResult>
    {
        internal RunStepFileSearchToolCallResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.FileSearchToolCallContent> Content { get { throw null; } }
        public string FileId { get { throw null; } }
        public string FileName { get { throw null; } }
        public float Score { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepFileSearchToolCallResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepFileSearchToolCallResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepFileSearchToolCallResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepFileSearchToolCallResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepFileSearchToolCallResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepFileSearchToolCallResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepFileSearchToolCallResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepFileSearchToolCallResults : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepFileSearchToolCallResults>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepFileSearchToolCallResults>
    {
        internal RunStepFileSearchToolCallResults() { }
        public Azure.AI.Agents.FileSearchRankingOptions RankingOptions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.RunStepFileSearchToolCallResult> Results { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepFileSearchToolCallResults System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepFileSearchToolCallResults>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepFileSearchToolCallResults>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepFileSearchToolCallResults System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepFileSearchToolCallResults>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepFileSearchToolCallResults>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepFileSearchToolCallResults>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepFunctionToolCall : Azure.AI.Agents.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepFunctionToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepFunctionToolCall>
    {
        internal RunStepFunctionToolCall() : base (default(string)) { }
        public string Arguments { get { throw null; } }
        public string Name { get { throw null; } }
        public string Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepFunctionToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepFunctionToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepFunctionToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepFunctionToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepFunctionToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepFunctionToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepFunctionToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepMessageCreationDetails : Azure.AI.Agents.RunStepDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepMessageCreationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepMessageCreationDetails>
    {
        internal RunStepMessageCreationDetails() { }
        public Azure.AI.Agents.RunStepMessageCreationReference MessageCreation { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepMessageCreationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepMessageCreationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepMessageCreationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepMessageCreationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepMessageCreationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepMessageCreationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepMessageCreationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepMessageCreationReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepMessageCreationReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepMessageCreationReference>
    {
        internal RunStepMessageCreationReference() { }
        public string MessageId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepMessageCreationReference System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepMessageCreationReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepMessageCreationReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepMessageCreationReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepMessageCreationReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepMessageCreationReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepMessageCreationReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepMicrosoftFabricToolCall : Azure.AI.Agents.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepMicrosoftFabricToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepMicrosoftFabricToolCall>
    {
        internal RunStepMicrosoftFabricToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> MicrosoftFabric { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepMicrosoftFabricToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepMicrosoftFabricToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepMicrosoftFabricToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepMicrosoftFabricToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepMicrosoftFabricToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepMicrosoftFabricToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepMicrosoftFabricToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepSharepointToolCall : Azure.AI.Agents.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepSharepointToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepSharepointToolCall>
    {
        internal RunStepSharepointToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> SharePoint { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepSharepointToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepSharepointToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepSharepointToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepSharepointToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepSharepointToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepSharepointToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepSharepointToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepStatus : System.IEquatable<Azure.AI.Agents.RunStepStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepStatus(string value) { throw null; }
        public static Azure.AI.Agents.RunStepStatus Cancelled { get { throw null; } }
        public static Azure.AI.Agents.RunStepStatus Completed { get { throw null; } }
        public static Azure.AI.Agents.RunStepStatus Expired { get { throw null; } }
        public static Azure.AI.Agents.RunStepStatus Failed { get { throw null; } }
        public static Azure.AI.Agents.RunStepStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Agents.RunStepStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.RunStepStatus left, Azure.AI.Agents.RunStepStatus right) { throw null; }
        public static implicit operator Azure.AI.Agents.RunStepStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.RunStepStatus left, Azure.AI.Agents.RunStepStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepStreamEvent : System.IEquatable<Azure.AI.Agents.RunStepStreamEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepStreamEvent(string value) { throw null; }
        public static Azure.AI.Agents.RunStepStreamEvent ThreadRunStepCancelled { get { throw null; } }
        public static Azure.AI.Agents.RunStepStreamEvent ThreadRunStepCompleted { get { throw null; } }
        public static Azure.AI.Agents.RunStepStreamEvent ThreadRunStepCreated { get { throw null; } }
        public static Azure.AI.Agents.RunStepStreamEvent ThreadRunStepDelta { get { throw null; } }
        public static Azure.AI.Agents.RunStepStreamEvent ThreadRunStepExpired { get { throw null; } }
        public static Azure.AI.Agents.RunStepStreamEvent ThreadRunStepFailed { get { throw null; } }
        public static Azure.AI.Agents.RunStepStreamEvent ThreadRunStepInProgress { get { throw null; } }
        public bool Equals(Azure.AI.Agents.RunStepStreamEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.RunStepStreamEvent left, Azure.AI.Agents.RunStepStreamEvent right) { throw null; }
        public static implicit operator Azure.AI.Agents.RunStepStreamEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.RunStepStreamEvent left, Azure.AI.Agents.RunStepStreamEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class RunStepToolCall : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepToolCall>
    {
        protected RunStepToolCall(string id) { }
        public string Id { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepToolCallDetails : Azure.AI.Agents.RunStepDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepToolCallDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepToolCallDetails>
    {
        internal RunStepToolCallDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.RunStepToolCall> ToolCalls { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepToolCallDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepToolCallDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RunStepToolCallDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RunStepToolCallDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepToolCallDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepToolCallDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RunStepToolCallDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepType : System.IEquatable<Azure.AI.Agents.RunStepType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepType(string value) { throw null; }
        public static Azure.AI.Agents.RunStepType MessageCreation { get { throw null; } }
        public static Azure.AI.Agents.RunStepType ToolCalls { get { throw null; } }
        public bool Equals(Azure.AI.Agents.RunStepType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.RunStepType left, Azure.AI.Agents.RunStepType right) { throw null; }
        public static implicit operator Azure.AI.Agents.RunStepType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.RunStepType left, Azure.AI.Agents.RunStepType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunStepUpdate : Azure.AI.Agents.StreamingUpdate<Azure.AI.Agents.RunStep>
    {
        internal RunStepUpdate() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStreamEvent : System.IEquatable<Azure.AI.Agents.RunStreamEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStreamEvent(string value) { throw null; }
        public static Azure.AI.Agents.RunStreamEvent ThreadRunCancelled { get { throw null; } }
        public static Azure.AI.Agents.RunStreamEvent ThreadRunCancelling { get { throw null; } }
        public static Azure.AI.Agents.RunStreamEvent ThreadRunCompleted { get { throw null; } }
        public static Azure.AI.Agents.RunStreamEvent ThreadRunCreated { get { throw null; } }
        public static Azure.AI.Agents.RunStreamEvent ThreadRunExpired { get { throw null; } }
        public static Azure.AI.Agents.RunStreamEvent ThreadRunFailed { get { throw null; } }
        public static Azure.AI.Agents.RunStreamEvent ThreadRunIncomplete { get { throw null; } }
        public static Azure.AI.Agents.RunStreamEvent ThreadRunInProgress { get { throw null; } }
        public static Azure.AI.Agents.RunStreamEvent ThreadRunQueued { get { throw null; } }
        public static Azure.AI.Agents.RunStreamEvent ThreadRunRequiresAction { get { throw null; } }
        public bool Equals(Azure.AI.Agents.RunStreamEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.RunStreamEvent left, Azure.AI.Agents.RunStreamEvent right) { throw null; }
        public static implicit operator Azure.AI.Agents.RunStreamEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.RunStreamEvent left, Azure.AI.Agents.RunStreamEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunUpdate : Azure.AI.Agents.StreamingUpdate<Azure.AI.Agents.ThreadRun>
    {
        internal RunUpdate() { }
    }
    public partial class SharepointToolDefinition : Azure.AI.Agents.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.SharepointToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.SharepointToolDefinition>
    {
        public SharepointToolDefinition(Azure.AI.Agents.ToolConnectionList sharepointGrounding) { }
        public Azure.AI.Agents.ToolConnectionList SharepointGrounding { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.SharepointToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.SharepointToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.SharepointToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.SharepointToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.SharepointToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.SharepointToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.SharepointToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class StreamingUpdate
    {
        internal StreamingUpdate() { }
        public Azure.AI.Agents.StreamingUpdateReason UpdateKind { get { throw null; } }
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
    public partial class StreamingUpdate<T> : Azure.AI.Agents.StreamingUpdate where T : class
    {
        internal StreamingUpdate() { }
        public T Value { get { throw null; } }
        public static implicit operator T (Azure.AI.Agents.StreamingUpdate<T> update) { throw null; }
    }
    public partial class SubmitToolOutputsAction : Azure.AI.Agents.RequiredAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.SubmitToolOutputsAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.SubmitToolOutputsAction>
    {
        internal SubmitToolOutputsAction() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.RequiredToolCall> ToolCalls { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.SubmitToolOutputsAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.SubmitToolOutputsAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.SubmitToolOutputsAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.SubmitToolOutputsAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.SubmitToolOutputsAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.SubmitToolOutputsAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.SubmitToolOutputsAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    }
    public partial class ThreadMessage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ThreadMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ThreadMessage>
    {
        internal ThreadMessage() { }
        public string AssistantId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.MessageAttachment> Attachments { get { throw null; } }
        public System.DateTimeOffset? CompletedAt { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.MessageContent> ContentItems { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? IncompleteAt { get { throw null; } }
        public Azure.AI.Agents.MessageIncompleteDetails IncompleteDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public Azure.AI.Agents.MessageRole Role { get { throw null; } }
        public string RunId { get { throw null; } }
        public Azure.AI.Agents.MessageStatus Status { get { throw null; } }
        public string ThreadId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.ThreadMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ThreadMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ThreadMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.ThreadMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ThreadMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ThreadMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ThreadMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreadMessageOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ThreadMessageOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ThreadMessageOptions>
    {
        public ThreadMessageOptions(Azure.AI.Agents.MessageRole role, string content) { }
        public System.Collections.Generic.IList<Azure.AI.Agents.MessageAttachment> Attachments { get { throw null; } set { } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public Azure.AI.Agents.MessageRole Role { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.ThreadMessageOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ThreadMessageOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ThreadMessageOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.ThreadMessageOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ThreadMessageOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ThreadMessageOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ThreadMessageOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreadRun : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ThreadRun>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ThreadRun>
    {
        internal ThreadRun() { }
        public string AssistantId { get { throw null; } }
        public System.DateTimeOffset? CancelledAt { get { throw null; } }
        public System.DateTimeOffset? CompletedAt { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public System.DateTimeOffset? ExpiresAt { get { throw null; } }
        public System.DateTimeOffset? FailedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Agents.IncompleteRunDetails IncompleteDetails { get { throw null; } }
        public string Instructions { get { throw null; } }
        public Azure.AI.Agents.RunError LastError { get { throw null; } }
        public int? MaxCompletionTokens { get { throw null; } }
        public int? MaxPromptTokens { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string Model { get { throw null; } }
        public bool ParallelToolCalls { get { throw null; } }
        public Azure.AI.Agents.RequiredAction RequiredAction { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.RequiredFunctionToolCall> RequiredActions { get { throw null; } }
        public System.BinaryData ResponseFormat { get { throw null; } }
        public System.DateTimeOffset? StartedAt { get { throw null; } }
        public Azure.AI.Agents.RunStatus Status { get { throw null; } }
        public float? Temperature { get { throw null; } }
        public string ThreadId { get { throw null; } }
        public System.BinaryData ToolChoice { get { throw null; } }
        public Azure.AI.Agents.UpdateToolResourcesOptions ToolResources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Agents.ToolDefinition> Tools { get { throw null; } }
        public float? TopP { get { throw null; } }
        public Azure.AI.Agents.TruncationObject TruncationStrategy { get { throw null; } }
        public Azure.AI.Agents.RunCompletionUsage Usage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.ThreadRun System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ThreadRun>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ThreadRun>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.ThreadRun System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ThreadRun>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ThreadRun>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ThreadRun>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ThreadStreamEvent : System.IEquatable<Azure.AI.Agents.ThreadStreamEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ThreadStreamEvent(string value) { throw null; }
        public static Azure.AI.Agents.ThreadStreamEvent ThreadCreated { get { throw null; } }
        public bool Equals(Azure.AI.Agents.ThreadStreamEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.ThreadStreamEvent left, Azure.AI.Agents.ThreadStreamEvent right) { throw null; }
        public static implicit operator Azure.AI.Agents.ThreadStreamEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.ThreadStreamEvent left, Azure.AI.Agents.ThreadStreamEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ThreadUpdate : Azure.AI.Agents.StreamingUpdate<Azure.AI.Agents.AgentThread>
    {
        internal ThreadUpdate() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public Azure.AI.Agents.ToolResources ToolResources { get { throw null; } }
    }
    public partial class ToolConnection : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ToolConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ToolConnection>
    {
        public ToolConnection(string connectionId) { }
        public string ConnectionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.ToolConnection System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ToolConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ToolConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.ToolConnection System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ToolConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ToolConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ToolConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolConnectionList : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ToolConnectionList>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ToolConnectionList>
    {
        public ToolConnectionList() { }
        public System.Collections.Generic.IList<Azure.AI.Agents.ToolConnection> ConnectionList { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.ToolConnectionList System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ToolConnectionList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ToolConnectionList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.ToolConnectionList System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ToolConnectionList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ToolConnectionList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ToolConnectionList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ToolDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ToolDefinition>
    {
        protected ToolDefinition() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.ToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.ToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolOutput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ToolOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ToolOutput>
    {
        public ToolOutput() { }
        public ToolOutput(Azure.AI.Agents.RequiredToolCall toolCall) { }
        public ToolOutput(Azure.AI.Agents.RequiredToolCall toolCall, string output) { }
        public ToolOutput(string toolCallId) { }
        public ToolOutput(string toolCallId, string output) { }
        public string Output { get { throw null; } set { } }
        public string ToolCallId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.ToolOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ToolOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ToolOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.ToolOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ToolOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ToolOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ToolOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolResources : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ToolResources>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ToolResources>
    {
        public ToolResources() { }
        public Azure.AI.Agents.AzureAISearchResource AzureAISearch { get { throw null; } set { } }
        public Azure.AI.Agents.CodeInterpreterToolResource CodeInterpreter { get { throw null; } set { } }
        public Azure.AI.Agents.FileSearchToolResource FileSearch { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.ToolResources System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ToolResources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ToolResources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.ToolResources System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ToolResources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ToolResources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ToolResources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TruncationObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.TruncationObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.TruncationObject>
    {
        public TruncationObject(Azure.AI.Agents.TruncationStrategy type) { }
        public int? LastMessages { get { throw null; } set { } }
        public Azure.AI.Agents.TruncationStrategy Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.TruncationObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.TruncationObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.TruncationObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.TruncationObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.TruncationObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.TruncationObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.TruncationObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TruncationStrategy : System.IEquatable<Azure.AI.Agents.TruncationStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TruncationStrategy(string value) { throw null; }
        public static Azure.AI.Agents.TruncationStrategy Auto { get { throw null; } }
        public static Azure.AI.Agents.TruncationStrategy LastMessages { get { throw null; } }
        public bool Equals(Azure.AI.Agents.TruncationStrategy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.TruncationStrategy left, Azure.AI.Agents.TruncationStrategy right) { throw null; }
        public static implicit operator Azure.AI.Agents.TruncationStrategy (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.TruncationStrategy left, Azure.AI.Agents.TruncationStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdateCodeInterpreterToolResourceOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.UpdateCodeInterpreterToolResourceOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.UpdateCodeInterpreterToolResourceOptions>
    {
        public UpdateCodeInterpreterToolResourceOptions() { }
        public System.Collections.Generic.IList<string> FileIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.UpdateCodeInterpreterToolResourceOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.UpdateCodeInterpreterToolResourceOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.UpdateCodeInterpreterToolResourceOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.UpdateCodeInterpreterToolResourceOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.UpdateCodeInterpreterToolResourceOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.UpdateCodeInterpreterToolResourceOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.UpdateCodeInterpreterToolResourceOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateFileSearchToolResourceOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.UpdateFileSearchToolResourceOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.UpdateFileSearchToolResourceOptions>
    {
        public UpdateFileSearchToolResourceOptions() { }
        public System.Collections.Generic.IList<string> VectorStoreIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.UpdateFileSearchToolResourceOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.UpdateFileSearchToolResourceOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.UpdateFileSearchToolResourceOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.UpdateFileSearchToolResourceOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.UpdateFileSearchToolResourceOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.UpdateFileSearchToolResourceOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.UpdateFileSearchToolResourceOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateToolResourcesOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.UpdateToolResourcesOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.UpdateToolResourcesOptions>
    {
        public UpdateToolResourcesOptions() { }
        public Azure.AI.Agents.AzureAISearchResource AzureAISearch { get { throw null; } set { } }
        public Azure.AI.Agents.UpdateCodeInterpreterToolResourceOptions CodeInterpreter { get { throw null; } set { } }
        public Azure.AI.Agents.UpdateFileSearchToolResourceOptions FileSearch { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.UpdateToolResourcesOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.UpdateToolResourcesOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.UpdateToolResourcesOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.UpdateToolResourcesOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.UpdateToolResourcesOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.UpdateToolResourcesOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.UpdateToolResourcesOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStore : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStore>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStore>
    {
        internal VectorStore() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public Azure.AI.Agents.VectorStoreExpirationPolicy ExpiresAfter { get { throw null; } }
        public System.DateTimeOffset? ExpiresAt { get { throw null; } }
        public Azure.AI.Agents.VectorStoreFileCount FileCounts { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastActiveAt { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Agents.VectorStoreObject Object { get { throw null; } }
        public Azure.AI.Agents.VectorStoreStatus Status { get { throw null; } }
        public int UsageBytes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStore System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStore System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreAutoChunkingStrategyRequest : Azure.AI.Agents.VectorStoreChunkingStrategyRequest, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreAutoChunkingStrategyRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreAutoChunkingStrategyRequest>
    {
        public VectorStoreAutoChunkingStrategyRequest() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreAutoChunkingStrategyRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreAutoChunkingStrategyRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreAutoChunkingStrategyRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreAutoChunkingStrategyRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreAutoChunkingStrategyRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreAutoChunkingStrategyRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreAutoChunkingStrategyRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreAutoChunkingStrategyResponse : Azure.AI.Agents.VectorStoreChunkingStrategyResponse, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreAutoChunkingStrategyResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreAutoChunkingStrategyResponse>
    {
        internal VectorStoreAutoChunkingStrategyResponse() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreAutoChunkingStrategyResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreAutoChunkingStrategyResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreAutoChunkingStrategyResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreAutoChunkingStrategyResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreAutoChunkingStrategyResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreAutoChunkingStrategyResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreAutoChunkingStrategyResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class VectorStoreChunkingStrategyRequest : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreChunkingStrategyRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreChunkingStrategyRequest>
    {
        protected VectorStoreChunkingStrategyRequest() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreChunkingStrategyRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreChunkingStrategyRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreChunkingStrategyRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreChunkingStrategyRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreChunkingStrategyRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreChunkingStrategyRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreChunkingStrategyRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class VectorStoreChunkingStrategyResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreChunkingStrategyResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreChunkingStrategyResponse>
    {
        protected VectorStoreChunkingStrategyResponse() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreChunkingStrategyResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreChunkingStrategyResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreChunkingStrategyResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreChunkingStrategyResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreChunkingStrategyResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreChunkingStrategyResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreChunkingStrategyResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreConfiguration>
    {
        public VectorStoreConfiguration(System.Collections.Generic.IEnumerable<Azure.AI.Agents.VectorStoreDataSource> dataSources) { }
        public System.Collections.Generic.IList<Azure.AI.Agents.VectorStoreDataSource> DataSources { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreConfigurations : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreConfigurations>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreConfigurations>
    {
        public VectorStoreConfigurations(string storeName, Azure.AI.Agents.VectorStoreConfiguration storeConfiguration) { }
        public Azure.AI.Agents.VectorStoreConfiguration StoreConfiguration { get { throw null; } set { } }
        public string StoreName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreConfigurations System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreConfigurations>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreConfigurations>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreConfigurations System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreConfigurations>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreConfigurations>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreConfigurations>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreDataSource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreDataSource>
    {
        public VectorStoreDataSource(string assetIdentifier, Azure.AI.Agents.VectorStoreDataSourceAssetType assetType) { }
        public string AssetIdentifier { get { throw null; } set { } }
        public Azure.AI.Agents.VectorStoreDataSourceAssetType AssetType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreDataSourceAssetType : System.IEquatable<Azure.AI.Agents.VectorStoreDataSourceAssetType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreDataSourceAssetType(string value) { throw null; }
        public static Azure.AI.Agents.VectorStoreDataSourceAssetType IdAsset { get { throw null; } }
        public static Azure.AI.Agents.VectorStoreDataSourceAssetType UriAsset { get { throw null; } }
        public bool Equals(Azure.AI.Agents.VectorStoreDataSourceAssetType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.VectorStoreDataSourceAssetType left, Azure.AI.Agents.VectorStoreDataSourceAssetType right) { throw null; }
        public static implicit operator Azure.AI.Agents.VectorStoreDataSourceAssetType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.VectorStoreDataSourceAssetType left, Azure.AI.Agents.VectorStoreDataSourceAssetType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreDeletionStatus : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreDeletionStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreDeletionStatus>
    {
        internal VectorStoreDeletionStatus() { }
        public bool Deleted { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Agents.VectorStoreDeletionStatusObject Object { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreDeletionStatus System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreDeletionStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreDeletionStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreDeletionStatus System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreDeletionStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreDeletionStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreDeletionStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreDeletionStatusObject : System.IEquatable<Azure.AI.Agents.VectorStoreDeletionStatusObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreDeletionStatusObject(string value) { throw null; }
        public static Azure.AI.Agents.VectorStoreDeletionStatusObject VectorStoreDeleted { get { throw null; } }
        public bool Equals(Azure.AI.Agents.VectorStoreDeletionStatusObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.VectorStoreDeletionStatusObject left, Azure.AI.Agents.VectorStoreDeletionStatusObject right) { throw null; }
        public static implicit operator Azure.AI.Agents.VectorStoreDeletionStatusObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.VectorStoreDeletionStatusObject left, Azure.AI.Agents.VectorStoreDeletionStatusObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreExpirationPolicy : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreExpirationPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreExpirationPolicy>
    {
        public VectorStoreExpirationPolicy(Azure.AI.Agents.VectorStoreExpirationPolicyAnchor anchor, int days) { }
        public Azure.AI.Agents.VectorStoreExpirationPolicyAnchor Anchor { get { throw null; } set { } }
        public int Days { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreExpirationPolicy System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreExpirationPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreExpirationPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreExpirationPolicy System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreExpirationPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreExpirationPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreExpirationPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreExpirationPolicyAnchor : System.IEquatable<Azure.AI.Agents.VectorStoreExpirationPolicyAnchor>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreExpirationPolicyAnchor(string value) { throw null; }
        public static Azure.AI.Agents.VectorStoreExpirationPolicyAnchor LastActiveAt { get { throw null; } }
        public bool Equals(Azure.AI.Agents.VectorStoreExpirationPolicyAnchor other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.VectorStoreExpirationPolicyAnchor left, Azure.AI.Agents.VectorStoreExpirationPolicyAnchor right) { throw null; }
        public static implicit operator Azure.AI.Agents.VectorStoreExpirationPolicyAnchor (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.VectorStoreExpirationPolicyAnchor left, Azure.AI.Agents.VectorStoreExpirationPolicyAnchor right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreFile : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreFile>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreFile>
    {
        internal VectorStoreFile() { }
        public Azure.AI.Agents.VectorStoreChunkingStrategyResponse ChunkingStrategy { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Agents.VectorStoreFileError LastError { get { throw null; } }
        public Azure.AI.Agents.VectorStoreFileObject Object { get { throw null; } }
        public Azure.AI.Agents.VectorStoreFileStatus Status { get { throw null; } }
        public int UsageBytes { get { throw null; } }
        public string VectorStoreId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreFile System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreFile System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreFileBatch : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreFileBatch>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreFileBatch>
    {
        internal VectorStoreFileBatch() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public Azure.AI.Agents.VectorStoreFileCount FileCounts { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Agents.VectorStoreFileBatchObject Object { get { throw null; } }
        public Azure.AI.Agents.VectorStoreFileBatchStatus Status { get { throw null; } }
        public string VectorStoreId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreFileBatch System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreFileBatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreFileBatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreFileBatch System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreFileBatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreFileBatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreFileBatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileBatchObject : System.IEquatable<Azure.AI.Agents.VectorStoreFileBatchObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileBatchObject(string value) { throw null; }
        public static Azure.AI.Agents.VectorStoreFileBatchObject VectorStoreFilesBatch { get { throw null; } }
        public bool Equals(Azure.AI.Agents.VectorStoreFileBatchObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.VectorStoreFileBatchObject left, Azure.AI.Agents.VectorStoreFileBatchObject right) { throw null; }
        public static implicit operator Azure.AI.Agents.VectorStoreFileBatchObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.VectorStoreFileBatchObject left, Azure.AI.Agents.VectorStoreFileBatchObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileBatchStatus : System.IEquatable<Azure.AI.Agents.VectorStoreFileBatchStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileBatchStatus(string value) { throw null; }
        public static Azure.AI.Agents.VectorStoreFileBatchStatus Cancelled { get { throw null; } }
        public static Azure.AI.Agents.VectorStoreFileBatchStatus Completed { get { throw null; } }
        public static Azure.AI.Agents.VectorStoreFileBatchStatus Failed { get { throw null; } }
        public static Azure.AI.Agents.VectorStoreFileBatchStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Agents.VectorStoreFileBatchStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.VectorStoreFileBatchStatus left, Azure.AI.Agents.VectorStoreFileBatchStatus right) { throw null; }
        public static implicit operator Azure.AI.Agents.VectorStoreFileBatchStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.VectorStoreFileBatchStatus left, Azure.AI.Agents.VectorStoreFileBatchStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreFileCount : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreFileCount>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreFileCount>
    {
        internal VectorStoreFileCount() { }
        public int Cancelled { get { throw null; } }
        public int Completed { get { throw null; } }
        public int Failed { get { throw null; } }
        public int InProgress { get { throw null; } }
        public int Total { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreFileCount System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreFileCount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreFileCount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreFileCount System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreFileCount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreFileCount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreFileCount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreFileDeletionStatus : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreFileDeletionStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreFileDeletionStatus>
    {
        internal VectorStoreFileDeletionStatus() { }
        public bool Deleted { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Agents.VectorStoreFileDeletionStatusObject Object { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreFileDeletionStatus System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreFileDeletionStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreFileDeletionStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreFileDeletionStatus System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreFileDeletionStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreFileDeletionStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreFileDeletionStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileDeletionStatusObject : System.IEquatable<Azure.AI.Agents.VectorStoreFileDeletionStatusObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileDeletionStatusObject(string value) { throw null; }
        public static Azure.AI.Agents.VectorStoreFileDeletionStatusObject VectorStoreFileDeleted { get { throw null; } }
        public bool Equals(Azure.AI.Agents.VectorStoreFileDeletionStatusObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.VectorStoreFileDeletionStatusObject left, Azure.AI.Agents.VectorStoreFileDeletionStatusObject right) { throw null; }
        public static implicit operator Azure.AI.Agents.VectorStoreFileDeletionStatusObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.VectorStoreFileDeletionStatusObject left, Azure.AI.Agents.VectorStoreFileDeletionStatusObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreFileError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreFileError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreFileError>
    {
        internal VectorStoreFileError() { }
        public Azure.AI.Agents.VectorStoreFileErrorCode Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreFileError System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreFileError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreFileError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreFileError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreFileError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreFileError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreFileError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileErrorCode : System.IEquatable<Azure.AI.Agents.VectorStoreFileErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileErrorCode(string value) { throw null; }
        public static Azure.AI.Agents.VectorStoreFileErrorCode InvalidFile { get { throw null; } }
        public static Azure.AI.Agents.VectorStoreFileErrorCode ServerError { get { throw null; } }
        public static Azure.AI.Agents.VectorStoreFileErrorCode UnsupportedFile { get { throw null; } }
        public bool Equals(Azure.AI.Agents.VectorStoreFileErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.VectorStoreFileErrorCode left, Azure.AI.Agents.VectorStoreFileErrorCode right) { throw null; }
        public static implicit operator Azure.AI.Agents.VectorStoreFileErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.VectorStoreFileErrorCode left, Azure.AI.Agents.VectorStoreFileErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileObject : System.IEquatable<Azure.AI.Agents.VectorStoreFileObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileObject(string value) { throw null; }
        public static Azure.AI.Agents.VectorStoreFileObject VectorStoreFile { get { throw null; } }
        public bool Equals(Azure.AI.Agents.VectorStoreFileObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.VectorStoreFileObject left, Azure.AI.Agents.VectorStoreFileObject right) { throw null; }
        public static implicit operator Azure.AI.Agents.VectorStoreFileObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.VectorStoreFileObject left, Azure.AI.Agents.VectorStoreFileObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileStatus : System.IEquatable<Azure.AI.Agents.VectorStoreFileStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileStatus(string value) { throw null; }
        public static Azure.AI.Agents.VectorStoreFileStatus Cancelled { get { throw null; } }
        public static Azure.AI.Agents.VectorStoreFileStatus Completed { get { throw null; } }
        public static Azure.AI.Agents.VectorStoreFileStatus Failed { get { throw null; } }
        public static Azure.AI.Agents.VectorStoreFileStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Agents.VectorStoreFileStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.VectorStoreFileStatus left, Azure.AI.Agents.VectorStoreFileStatus right) { throw null; }
        public static implicit operator Azure.AI.Agents.VectorStoreFileStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.VectorStoreFileStatus left, Azure.AI.Agents.VectorStoreFileStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileStatusFilter : System.IEquatable<Azure.AI.Agents.VectorStoreFileStatusFilter>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileStatusFilter(string value) { throw null; }
        public static Azure.AI.Agents.VectorStoreFileStatusFilter Cancelled { get { throw null; } }
        public static Azure.AI.Agents.VectorStoreFileStatusFilter Completed { get { throw null; } }
        public static Azure.AI.Agents.VectorStoreFileStatusFilter Failed { get { throw null; } }
        public static Azure.AI.Agents.VectorStoreFileStatusFilter InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Agents.VectorStoreFileStatusFilter other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.VectorStoreFileStatusFilter left, Azure.AI.Agents.VectorStoreFileStatusFilter right) { throw null; }
        public static implicit operator Azure.AI.Agents.VectorStoreFileStatusFilter (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.VectorStoreFileStatusFilter left, Azure.AI.Agents.VectorStoreFileStatusFilter right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreObject : System.IEquatable<Azure.AI.Agents.VectorStoreObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreObject(string value) { throw null; }
        public static Azure.AI.Agents.VectorStoreObject VectorStore { get { throw null; } }
        public bool Equals(Azure.AI.Agents.VectorStoreObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.VectorStoreObject left, Azure.AI.Agents.VectorStoreObject right) { throw null; }
        public static implicit operator Azure.AI.Agents.VectorStoreObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.VectorStoreObject left, Azure.AI.Agents.VectorStoreObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreStaticChunkingStrategyOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreStaticChunkingStrategyOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreStaticChunkingStrategyOptions>
    {
        public VectorStoreStaticChunkingStrategyOptions(int maxChunkSizeTokens, int chunkOverlapTokens) { }
        public int ChunkOverlapTokens { get { throw null; } set { } }
        public int MaxChunkSizeTokens { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreStaticChunkingStrategyOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreStaticChunkingStrategyOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreStaticChunkingStrategyOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreStaticChunkingStrategyOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreStaticChunkingStrategyOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreStaticChunkingStrategyOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreStaticChunkingStrategyOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreStaticChunkingStrategyRequest : Azure.AI.Agents.VectorStoreChunkingStrategyRequest, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreStaticChunkingStrategyRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreStaticChunkingStrategyRequest>
    {
        public VectorStoreStaticChunkingStrategyRequest(Azure.AI.Agents.VectorStoreStaticChunkingStrategyOptions @static) { }
        public Azure.AI.Agents.VectorStoreStaticChunkingStrategyOptions Static { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreStaticChunkingStrategyRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreStaticChunkingStrategyRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreStaticChunkingStrategyRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreStaticChunkingStrategyRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreStaticChunkingStrategyRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreStaticChunkingStrategyRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreStaticChunkingStrategyRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreStaticChunkingStrategyResponse : Azure.AI.Agents.VectorStoreChunkingStrategyResponse, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreStaticChunkingStrategyResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreStaticChunkingStrategyResponse>
    {
        internal VectorStoreStaticChunkingStrategyResponse() { }
        public Azure.AI.Agents.VectorStoreStaticChunkingStrategyOptions Static { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreStaticChunkingStrategyResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreStaticChunkingStrategyResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.VectorStoreStaticChunkingStrategyResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.VectorStoreStaticChunkingStrategyResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreStaticChunkingStrategyResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreStaticChunkingStrategyResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.VectorStoreStaticChunkingStrategyResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreStatus : System.IEquatable<Azure.AI.Agents.VectorStoreStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreStatus(string value) { throw null; }
        public static Azure.AI.Agents.VectorStoreStatus Completed { get { throw null; } }
        public static Azure.AI.Agents.VectorStoreStatus Expired { get { throw null; } }
        public static Azure.AI.Agents.VectorStoreStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Agents.VectorStoreStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.VectorStoreStatus left, Azure.AI.Agents.VectorStoreStatus right) { throw null; }
        public static implicit operator Azure.AI.Agents.VectorStoreStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.VectorStoreStatus left, Azure.AI.Agents.VectorStoreStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AIAgentsClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Agents.AgentsClient, Azure.AI.Agents.AgentsClientOptions> AddAgentsClient<TBuilder>(this TBuilder builder, System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Agents.AgentsClient, Azure.AI.Agents.AgentsClientOptions> AddAgentsClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
