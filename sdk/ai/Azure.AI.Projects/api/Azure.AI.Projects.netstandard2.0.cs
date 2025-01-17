namespace Azure.AI.Projects
{
    public partial class Agent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agent>
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
        public Azure.AI.Projects.ToolResources ToolResources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.ToolDefinition> Tools { get { throw null; } }
        public float? TopP { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agent System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Agent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Agent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Agent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentFile : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentFile>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentFile>
    {
        internal AgentFile() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Filename { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Projects.AgentFilePurpose Purpose { get { throw null; } }
        public int Size { get { throw null; } }
        public Azure.AI.Projects.FileState? Status { get { throw null; } }
        public string StatusDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentFile System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentFile System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentFilePurpose : System.IEquatable<Azure.AI.Projects.AgentFilePurpose>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentFilePurpose(string value) { throw null; }
        public static Azure.AI.Projects.AgentFilePurpose Agents { get { throw null; } }
        public static Azure.AI.Projects.AgentFilePurpose AgentsOutput { get { throw null; } }
        public static Azure.AI.Projects.AgentFilePurpose Batch { get { throw null; } }
        public static Azure.AI.Projects.AgentFilePurpose BatchOutput { get { throw null; } }
        public static Azure.AI.Projects.AgentFilePurpose FineTune { get { throw null; } }
        public static Azure.AI.Projects.AgentFilePurpose FineTuneResults { get { throw null; } }
        public static Azure.AI.Projects.AgentFilePurpose Vision { get { throw null; } }
        public bool Equals(Azure.AI.Projects.AgentFilePurpose other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.AgentFilePurpose left, Azure.AI.Projects.AgentFilePurpose right) { throw null; }
        public static implicit operator Azure.AI.Projects.AgentFilePurpose (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.AgentFilePurpose left, Azure.AI.Projects.AgentFilePurpose right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentPageableListOfVectorStore : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentPageableListOfVectorStore>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentPageableListOfVectorStore>
    {
        internal AgentPageableListOfVectorStore() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.VectorStore> Data { get { throw null; } }
        public string FirstId { get { throw null; } }
        public bool HasMore { get { throw null; } }
        public string LastId { get { throw null; } }
        public Azure.AI.Projects.AgentPageableListOfVectorStoreObject Object { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentPageableListOfVectorStore System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentPageableListOfVectorStore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentPageableListOfVectorStore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentPageableListOfVectorStore System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentPageableListOfVectorStore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentPageableListOfVectorStore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentPageableListOfVectorStore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentPageableListOfVectorStoreFile : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentPageableListOfVectorStoreFile>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentPageableListOfVectorStoreFile>
    {
        internal AgentPageableListOfVectorStoreFile() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.VectorStoreFile> Data { get { throw null; } }
        public string FirstId { get { throw null; } }
        public bool HasMore { get { throw null; } }
        public string LastId { get { throw null; } }
        public Azure.AI.Projects.AgentPageableListOfVectorStoreFileObject Object { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentPageableListOfVectorStoreFile System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentPageableListOfVectorStoreFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentPageableListOfVectorStoreFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentPageableListOfVectorStoreFile System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentPageableListOfVectorStoreFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentPageableListOfVectorStoreFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentPageableListOfVectorStoreFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentPageableListOfVectorStoreFileObject : System.IEquatable<Azure.AI.Projects.AgentPageableListOfVectorStoreFileObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentPageableListOfVectorStoreFileObject(string value) { throw null; }
        public static Azure.AI.Projects.AgentPageableListOfVectorStoreFileObject List { get { throw null; } }
        public bool Equals(Azure.AI.Projects.AgentPageableListOfVectorStoreFileObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.AgentPageableListOfVectorStoreFileObject left, Azure.AI.Projects.AgentPageableListOfVectorStoreFileObject right) { throw null; }
        public static implicit operator Azure.AI.Projects.AgentPageableListOfVectorStoreFileObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.AgentPageableListOfVectorStoreFileObject left, Azure.AI.Projects.AgentPageableListOfVectorStoreFileObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentPageableListOfVectorStoreObject : System.IEquatable<Azure.AI.Projects.AgentPageableListOfVectorStoreObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentPageableListOfVectorStoreObject(string value) { throw null; }
        public static Azure.AI.Projects.AgentPageableListOfVectorStoreObject List { get { throw null; } }
        public bool Equals(Azure.AI.Projects.AgentPageableListOfVectorStoreObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.AgentPageableListOfVectorStoreObject left, Azure.AI.Projects.AgentPageableListOfVectorStoreObject right) { throw null; }
        public static implicit operator Azure.AI.Projects.AgentPageableListOfVectorStoreObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.AgentPageableListOfVectorStoreObject left, Azure.AI.Projects.AgentPageableListOfVectorStoreObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentsApiResponseFormat : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentsApiResponseFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentsApiResponseFormat>
    {
        public AgentsApiResponseFormat() { }
        public Azure.AI.Projects.ResponseFormat? Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentsApiResponseFormat System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentsApiResponseFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentsApiResponseFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentsApiResponseFormat System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentsApiResponseFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentsApiResponseFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentsApiResponseFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentsApiResponseFormatMode : System.IEquatable<Azure.AI.Projects.AgentsApiResponseFormatMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentsApiResponseFormatMode(string value) { throw null; }
        public static Azure.AI.Projects.AgentsApiResponseFormatMode Auto { get { throw null; } }
        public static Azure.AI.Projects.AgentsApiResponseFormatMode None { get { throw null; } }
        public bool Equals(Azure.AI.Projects.AgentsApiResponseFormatMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.AgentsApiResponseFormatMode left, Azure.AI.Projects.AgentsApiResponseFormatMode right) { throw null; }
        public static implicit operator Azure.AI.Projects.AgentsApiResponseFormatMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.AgentsApiResponseFormatMode left, Azure.AI.Projects.AgentsApiResponseFormatMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentsApiToolChoiceOptionMode : System.IEquatable<Azure.AI.Projects.AgentsApiToolChoiceOptionMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentsApiToolChoiceOptionMode(string value) { throw null; }
        public static Azure.AI.Projects.AgentsApiToolChoiceOptionMode Auto { get { throw null; } }
        public static Azure.AI.Projects.AgentsApiToolChoiceOptionMode None { get { throw null; } }
        public bool Equals(Azure.AI.Projects.AgentsApiToolChoiceOptionMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.AgentsApiToolChoiceOptionMode left, Azure.AI.Projects.AgentsApiToolChoiceOptionMode right) { throw null; }
        public static implicit operator Azure.AI.Projects.AgentsApiToolChoiceOptionMode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.AgentsApiToolChoiceOptionMode left, Azure.AI.Projects.AgentsApiToolChoiceOptionMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentsClient
    {
        protected AgentsClient() { }
        public AgentsClient(string connectionString, Azure.Core.TokenCredential credential) { }
        public AgentsClient(string connectionString, Azure.Core.TokenCredential credential, Azure.AI.Projects.AIProjectClientOptions options) { }
        public AgentsClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential) { }
        public AgentsClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential, Azure.AI.Projects.AIProjectClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response CancelRun(string threadId, string runId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.ThreadRun> CancelRun(string threadId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelRunAsync(string threadId, string runId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.ThreadRun>> CancelRunAsync(string threadId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CancelVectorStoreFileBatch(string vectorStoreId, string batchId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.VectorStoreFileBatch> CancelVectorStoreFileBatch(string vectorStoreId, string batchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CancelVectorStoreFileBatchAsync(string vectorStoreId, string batchId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.VectorStoreFileBatch>> CancelVectorStoreFileBatchAsync(string vectorStoreId, string batchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateAgent(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.Agent> CreateAgent(string model, string name = null, string description = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.ToolDefinition> tools = null, Azure.AI.Projects.ToolResources toolResources = null, float? temperature = default(float?), float? topP = default(float?), System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAgentAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.Agent>> CreateAgentAsync(string model, string name = null, string description = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.ToolDefinition> tools = null, Azure.AI.Projects.ToolResources toolResources = null, float? temperature = default(float?), float? topP = default(float?), System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.ThreadMessage> CreateMessage(string threadId, Azure.AI.Projects.MessageRole role, string content, System.Collections.Generic.IEnumerable<Azure.AI.Projects.MessageAttachment> attachments = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateMessage(string threadId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.ThreadMessage>> CreateMessageAsync(string threadId, Azure.AI.Projects.MessageRole role, string content, System.Collections.Generic.IEnumerable<Azure.AI.Projects.MessageAttachment> attachments = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateMessageAsync(string threadId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.ThreadRun> CreateRun(Azure.AI.Projects.AgentThread thread, Azure.AI.Projects.Agent agent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateRun(string threadId, Azure.Core.RequestContent content, System.Collections.Generic.IEnumerable<Azure.AI.Projects.RunAdditionalFieldList> include = null, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.ThreadRun> CreateRun(string threadId, string assistantId, string overrideModelName = null, string overrideInstructions = null, string additionalInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.ThreadMessageOptions> additionalMessages = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.ToolDefinition> overrideTools = null, bool? stream = default(bool?), float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Projects.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, bool? parallelToolCalls = default(bool?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.RunAdditionalFieldList> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.ThreadRun>> CreateRunAsync(Azure.AI.Projects.AgentThread thread, Azure.AI.Projects.Agent agent, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateRunAsync(string threadId, Azure.Core.RequestContent content, System.Collections.Generic.IEnumerable<Azure.AI.Projects.RunAdditionalFieldList> include = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.ThreadRun>> CreateRunAsync(string threadId, string assistantId, string overrideModelName = null, string overrideInstructions = null, string additionalInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.ThreadMessageOptions> additionalMessages = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.ToolDefinition> overrideTools = null, bool? stream = default(bool?), float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Projects.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, bool? parallelToolCalls = default(bool?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.RunAdditionalFieldList> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.StreamingUpdate> CreateRunStreaming(string threadId, string assistantId, string overrideModelName = null, string overrideInstructions = null, string additionalInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.ThreadMessageOptions> additionalMessages = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.ToolDefinition> overrideTools = null, float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Projects.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, bool? parallelToolCalls = default(bool?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.StreamingUpdate> CreateRunStreamingAsync(string threadId, string assistantId, string overrideModelName = null, string overrideInstructions = null, string additionalInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.ThreadMessageOptions> additionalMessages = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.ToolDefinition> overrideTools = null, float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Projects.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, bool? parallelToolCalls = default(bool?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateThread(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.AgentThread> CreateThread(System.Collections.Generic.IEnumerable<Azure.AI.Projects.ThreadMessageOptions> messages = null, Azure.AI.Projects.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateThreadAndRun(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.ThreadRun> CreateThreadAndRun(string assistantId, Azure.AI.Projects.AgentThreadCreationOptions thread = null, string overrideModelName = null, string overrideInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.ToolDefinition> overrideTools = null, Azure.AI.Projects.UpdateToolResourcesOptions toolResources = null, bool? stream = default(bool?), float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Projects.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, bool? parallelToolCalls = default(bool?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateThreadAndRunAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.ThreadRun>> CreateThreadAndRunAsync(string assistantId, Azure.AI.Projects.AgentThreadCreationOptions thread = null, string overrideModelName = null, string overrideInstructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.ToolDefinition> overrideTools = null, Azure.AI.Projects.UpdateToolResourcesOptions toolResources = null, bool? stream = default(bool?), float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Projects.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, bool? parallelToolCalls = default(bool?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateThreadAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.AgentThread>> CreateThreadAsync(System.Collections.Generic.IEnumerable<Azure.AI.Projects.ThreadMessageOptions> messages = null, Azure.AI.Projects.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateVectorStore(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.VectorStore> CreateVectorStore(System.Collections.Generic.IEnumerable<string> fileIds = null, string name = null, Azure.AI.Projects.VectorStoreConfiguration storeConfiguration = null, Azure.AI.Projects.VectorStoreExpirationPolicy expiresAfter = null, Azure.AI.Projects.VectorStoreChunkingStrategyRequest chunkingStrategy = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateVectorStoreAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.VectorStore>> CreateVectorStoreAsync(System.Collections.Generic.IEnumerable<string> fileIds = null, string name = null, Azure.AI.Projects.VectorStoreConfiguration storeConfiguration = null, Azure.AI.Projects.VectorStoreExpirationPolicy expiresAfter = null, Azure.AI.Projects.VectorStoreChunkingStrategyRequest chunkingStrategy = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateVectorStoreFile(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.VectorStoreFile> CreateVectorStoreFile(string vectorStoreId, string fileId = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.VectorStoreDataSource> dataSources = null, Azure.AI.Projects.VectorStoreChunkingStrategyRequest chunkingStrategy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateVectorStoreFileAsync(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.VectorStoreFile>> CreateVectorStoreFileAsync(string vectorStoreId, string fileId = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.VectorStoreDataSource> dataSources = null, Azure.AI.Projects.VectorStoreChunkingStrategyRequest chunkingStrategy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateVectorStoreFileBatch(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.VectorStoreFileBatch> CreateVectorStoreFileBatch(string vectorStoreId, System.Collections.Generic.IEnumerable<string> fileIds = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.VectorStoreDataSource> dataSources = null, Azure.AI.Projects.VectorStoreChunkingStrategyRequest chunkingStrategy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateVectorStoreFileBatchAsync(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.VectorStoreFileBatch>> CreateVectorStoreFileBatchAsync(string vectorStoreId, System.Collections.Generic.IEnumerable<string> fileIds = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.VectorStoreDataSource> dataSources = null, Azure.AI.Projects.VectorStoreChunkingStrategyRequest chunkingStrategy = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> DeleteAgent(string agentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteAgentAsync(string agentId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> DeleteFile(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteFileAsync(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> DeleteThread(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> DeleteThreadAsync(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteVectorStore(string vectorStoreId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.VectorStoreDeletionStatus> DeleteVectorStore(string vectorStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVectorStoreAsync(string vectorStoreId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.VectorStoreDeletionStatus>> DeleteVectorStoreAsync(string vectorStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DeleteVectorStoreFile(string vectorStoreId, string fileId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.VectorStoreFileDeletionStatus> DeleteVectorStoreFile(string vectorStoreId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteVectorStoreFileAsync(string vectorStoreId, string fileId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.VectorStoreFileDeletionStatus>> DeleteVectorStoreFileAsync(string vectorStoreId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetAgent(string assistantId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.Agent> GetAgent(string assistantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetAgentAsync(string assistantId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.Agent>> GetAgentAsync(string assistantId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.PageableList<Azure.AI.Projects.Agent>> GetAgents(int? limit = default(int?), Azure.AI.Projects.ListSortOrder? order = default(Azure.AI.Projects.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.PageableList<Azure.AI.Projects.Agent>>> GetAgentsAsync(int? limit = default(int?), Azure.AI.Projects.ListSortOrder? order = default(Azure.AI.Projects.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetFile(string fileId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.AgentFile> GetFile(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetFileAsync(string fileId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.AgentFile>> GetFileAsync(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetFileContent(string fileId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<System.BinaryData> GetFileContent(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetFileContentAsync(string fileId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.BinaryData>> GetFileContentAsync(string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.AgentFile>> GetFiles(Azure.AI.Projects.AgentFilePurpose? purpose = default(Azure.AI.Projects.AgentFilePurpose?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.AgentFile>>> GetFilesAsync(Azure.AI.Projects.AgentFilePurpose? purpose = default(Azure.AI.Projects.AgentFilePurpose?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetMessage(string threadId, string messageId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.ThreadMessage> GetMessage(string threadId, string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetMessageAsync(string threadId, string messageId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.ThreadMessage>> GetMessageAsync(string threadId, string messageId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.PageableList<Azure.AI.Projects.ThreadMessage>> GetMessages(string threadId, string runId = null, int? limit = default(int?), Azure.AI.Projects.ListSortOrder? order = default(Azure.AI.Projects.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.PageableList<Azure.AI.Projects.ThreadMessage>>> GetMessagesAsync(string threadId, string runId = null, int? limit = default(int?), Azure.AI.Projects.ListSortOrder? order = default(Azure.AI.Projects.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetRun(string threadId, string runId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.ThreadRun> GetRun(string threadId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRunAsync(string threadId, string runId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.ThreadRun>> GetRunAsync(string threadId, string runId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.PageableList<Azure.AI.Projects.ThreadRun>> GetRuns(string threadId, int? limit = default(int?), Azure.AI.Projects.ListSortOrder? order = default(Azure.AI.Projects.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.PageableList<Azure.AI.Projects.ThreadRun>>> GetRunsAsync(string threadId, int? limit = default(int?), Azure.AI.Projects.ListSortOrder? order = default(Azure.AI.Projects.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetRunStep(string threadId, string runId, string stepId, System.Collections.Generic.IEnumerable<Azure.AI.Projects.RunAdditionalFieldList> include, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.RunStep> GetRunStep(string threadId, string runId, string stepId, System.Collections.Generic.IEnumerable<Azure.AI.Projects.RunAdditionalFieldList> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetRunStepAsync(string threadId, string runId, string stepId, System.Collections.Generic.IEnumerable<Azure.AI.Projects.RunAdditionalFieldList> include, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.RunStep>> GetRunStepAsync(string threadId, string runId, string stepId, System.Collections.Generic.IEnumerable<Azure.AI.Projects.RunAdditionalFieldList> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.PageableList<Azure.AI.Projects.RunStep>> GetRunSteps(Azure.AI.Projects.ThreadRun run, int? limit = default(int?), Azure.AI.Projects.ListSortOrder? order = default(Azure.AI.Projects.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.PageableList<Azure.AI.Projects.RunStep>> GetRunSteps(string threadId, string runId, int? limit = default(int?), Azure.AI.Projects.ListSortOrder? order = default(Azure.AI.Projects.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.PageableList<Azure.AI.Projects.RunStep>>> GetRunStepsAsync(Azure.AI.Projects.ThreadRun run, int? limit = default(int?), Azure.AI.Projects.ListSortOrder? order = default(Azure.AI.Projects.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.PageableList<Azure.AI.Projects.RunStep>>> GetRunStepsAsync(string threadId, string runId, int? limit = default(int?), Azure.AI.Projects.ListSortOrder? order = default(Azure.AI.Projects.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetThread(string threadId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.AgentThread> GetThread(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetThreadAsync(string threadId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.AgentThread>> GetThreadAsync(string threadId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStore(string vectorStoreId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.VectorStore> GetVectorStore(string vectorStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoreAsync(string vectorStoreId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.VectorStore>> GetVectorStoreAsync(string vectorStoreId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStoreFile(string vectorStoreId, string fileId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.VectorStoreFile> GetVectorStoreFile(string vectorStoreId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoreFileAsync(string vectorStoreId, string fileId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.VectorStoreFile>> GetVectorStoreFileAsync(string vectorStoreId, string fileId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStoreFileBatch(string vectorStoreId, string batchId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.VectorStoreFileBatch> GetVectorStoreFileBatch(string vectorStoreId, string batchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoreFileBatchAsync(string vectorStoreId, string batchId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.VectorStoreFileBatch>> GetVectorStoreFileBatchAsync(string vectorStoreId, string batchId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.AgentPageableListOfVectorStoreFile> GetVectorStoreFileBatchFiles(string vectorStoreId, string batchId, Azure.AI.Projects.VectorStoreFileStatusFilter? filter = default(Azure.AI.Projects.VectorStoreFileStatusFilter?), int? limit = default(int?), Azure.AI.Projects.ListSortOrder? order = default(Azure.AI.Projects.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStoreFileBatchFiles(string vectorStoreId, string batchId, string filter, int? limit, string order, string after, string before, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.AgentPageableListOfVectorStoreFile>> GetVectorStoreFileBatchFilesAsync(string vectorStoreId, string batchId, Azure.AI.Projects.VectorStoreFileStatusFilter? filter = default(Azure.AI.Projects.VectorStoreFileStatusFilter?), int? limit = default(int?), Azure.AI.Projects.ListSortOrder? order = default(Azure.AI.Projects.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoreFileBatchFilesAsync(string vectorStoreId, string batchId, string filter, int? limit, string order, string after, string before, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.AgentPageableListOfVectorStoreFile> GetVectorStoreFiles(string vectorStoreId, Azure.AI.Projects.VectorStoreFileStatusFilter? filter = default(Azure.AI.Projects.VectorStoreFileStatusFilter?), int? limit = default(int?), Azure.AI.Projects.ListSortOrder? order = default(Azure.AI.Projects.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStoreFiles(string vectorStoreId, string filter, int? limit, string order, string after, string before, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.AgentPageableListOfVectorStoreFile>> GetVectorStoreFilesAsync(string vectorStoreId, Azure.AI.Projects.VectorStoreFileStatusFilter? filter = default(Azure.AI.Projects.VectorStoreFileStatusFilter?), int? limit = default(int?), Azure.AI.Projects.ListSortOrder? order = default(Azure.AI.Projects.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoreFilesAsync(string vectorStoreId, string filter, int? limit, string order, string after, string before, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.AgentPageableListOfVectorStore> GetVectorStores(int? limit = default(int?), Azure.AI.Projects.ListSortOrder? order = default(Azure.AI.Projects.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetVectorStores(int? limit, string order, string after, string before, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.AgentPageableListOfVectorStore>> GetVectorStoresAsync(int? limit = default(int?), Azure.AI.Projects.ListSortOrder? order = default(Azure.AI.Projects.ListSortOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetVectorStoresAsync(int? limit, string order, string after, string before, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response ModifyVectorStore(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.VectorStore> ModifyVectorStore(string vectorStoreId, string name = null, Azure.AI.Projects.VectorStoreExpirationPolicy expiresAfter = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ModifyVectorStoreAsync(string vectorStoreId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.VectorStore>> ModifyVectorStoreAsync(string vectorStoreId, string name = null, Azure.AI.Projects.VectorStoreExpirationPolicy expiresAfter = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.ThreadRun> SubmitToolOutputsToRun(Azure.AI.Projects.ThreadRun run, System.Collections.Generic.IEnumerable<Azure.AI.Projects.ToolOutput> toolOutputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response SubmitToolOutputsToRun(string threadId, string runId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.ThreadRun>> SubmitToolOutputsToRunAsync(Azure.AI.Projects.ThreadRun run, System.Collections.Generic.IEnumerable<Azure.AI.Projects.ToolOutput> toolOutputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> SubmitToolOutputsToRunAsync(string threadId, string runId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.StreamingUpdate> SubmitToolOutputsToStream(Azure.AI.Projects.ThreadRun run, System.Collections.Generic.IEnumerable<Azure.AI.Projects.ToolOutput> toolOutputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.StreamingUpdate> SubmitToolOutputsToStreamAsync(Azure.AI.Projects.ThreadRun run, System.Collections.Generic.IEnumerable<Azure.AI.Projects.ToolOutput> toolOutputs, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateAgent(string assistantId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.Agent> UpdateAgent(string assistantId, string model = null, string name = null, string description = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.ToolDefinition> tools = null, Azure.AI.Projects.ToolResources toolResources = null, float? temperature = default(float?), float? topP = default(float?), System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAgentAsync(string assistantId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.Agent>> UpdateAgentAsync(string assistantId, string model = null, string name = null, string description = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.ToolDefinition> tools = null, Azure.AI.Projects.ToolResources toolResources = null, float? temperature = default(float?), float? topP = default(float?), System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateMessage(string threadId, string messageId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.ThreadMessage> UpdateMessage(string threadId, string messageId, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateMessageAsync(string threadId, string messageId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.ThreadMessage>> UpdateMessageAsync(string threadId, string messageId, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateRun(string threadId, string runId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.ThreadRun> UpdateRun(string threadId, string runId, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateRunAsync(string threadId, string runId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.ThreadRun>> UpdateRunAsync(string threadId, string runId, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.AgentThread> UpdateThread(string threadId, Azure.AI.Projects.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdateThread(string threadId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.AgentThread>> UpdateThreadAsync(string threadId, Azure.AI.Projects.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateThreadAsync(string threadId, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response UploadFile(Azure.Core.RequestContent content, string contentType, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.AgentFile> UploadFile(System.IO.Stream data, Azure.AI.Projects.AgentFilePurpose purpose, string filename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.AgentFile> UploadFile(string filePath, Azure.AI.Projects.AgentFilePurpose purpose, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UploadFileAsync(Azure.Core.RequestContent content, string contentType, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.AgentFile>> UploadFileAsync(System.IO.Stream data, Azure.AI.Projects.AgentFilePurpose purpose, string filename, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.AgentFile>> UploadFileAsync(string filePath, Azure.AI.Projects.AgentFilePurpose purpose, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AgentsNamedToolChoice : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentsNamedToolChoice>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentsNamedToolChoice>
    {
        public AgentsNamedToolChoice(Azure.AI.Projects.AgentsNamedToolChoiceType type) { }
        public Azure.AI.Projects.FunctionName Function { get { throw null; } set { } }
        public Azure.AI.Projects.AgentsNamedToolChoiceType Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentsNamedToolChoice System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentsNamedToolChoice>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentsNamedToolChoice>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentsNamedToolChoice System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentsNamedToolChoice>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentsNamedToolChoice>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentsNamedToolChoice>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentsNamedToolChoiceType : System.IEquatable<Azure.AI.Projects.AgentsNamedToolChoiceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentsNamedToolChoiceType(string value) { throw null; }
        public static Azure.AI.Projects.AgentsNamedToolChoiceType AzureAISearch { get { throw null; } }
        public static Azure.AI.Projects.AgentsNamedToolChoiceType BingGrounding { get { throw null; } }
        public static Azure.AI.Projects.AgentsNamedToolChoiceType CodeInterpreter { get { throw null; } }
        public static Azure.AI.Projects.AgentsNamedToolChoiceType FileSearch { get { throw null; } }
        public static Azure.AI.Projects.AgentsNamedToolChoiceType Function { get { throw null; } }
        public static Azure.AI.Projects.AgentsNamedToolChoiceType MicrosoftFabric { get { throw null; } }
        public static Azure.AI.Projects.AgentsNamedToolChoiceType Sharepoint { get { throw null; } }
        public bool Equals(Azure.AI.Projects.AgentsNamedToolChoiceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.AgentsNamedToolChoiceType left, Azure.AI.Projects.AgentsNamedToolChoiceType right) { throw null; }
        public static implicit operator Azure.AI.Projects.AgentsNamedToolChoiceType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.AgentsNamedToolChoiceType left, Azure.AI.Projects.AgentsNamedToolChoiceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentStreamEvent : System.IEquatable<Azure.AI.Projects.AgentStreamEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentStreamEvent(string value) { throw null; }
        public static Azure.AI.Projects.AgentStreamEvent Done { get { throw null; } }
        public static Azure.AI.Projects.AgentStreamEvent Error { get { throw null; } }
        public static Azure.AI.Projects.AgentStreamEvent ThreadCreated { get { throw null; } }
        public static Azure.AI.Projects.AgentStreamEvent ThreadMessageCompleted { get { throw null; } }
        public static Azure.AI.Projects.AgentStreamEvent ThreadMessageCreated { get { throw null; } }
        public static Azure.AI.Projects.AgentStreamEvent ThreadMessageDelta { get { throw null; } }
        public static Azure.AI.Projects.AgentStreamEvent ThreadMessageIncomplete { get { throw null; } }
        public static Azure.AI.Projects.AgentStreamEvent ThreadMessageInProgress { get { throw null; } }
        public static Azure.AI.Projects.AgentStreamEvent ThreadRunCancelled { get { throw null; } }
        public static Azure.AI.Projects.AgentStreamEvent ThreadRunCancelling { get { throw null; } }
        public static Azure.AI.Projects.AgentStreamEvent ThreadRunCompleted { get { throw null; } }
        public static Azure.AI.Projects.AgentStreamEvent ThreadRunCreated { get { throw null; } }
        public static Azure.AI.Projects.AgentStreamEvent ThreadRunExpired { get { throw null; } }
        public static Azure.AI.Projects.AgentStreamEvent ThreadRunFailed { get { throw null; } }
        public static Azure.AI.Projects.AgentStreamEvent ThreadRunIncomplete { get { throw null; } }
        public static Azure.AI.Projects.AgentStreamEvent ThreadRunInProgress { get { throw null; } }
        public static Azure.AI.Projects.AgentStreamEvent ThreadRunQueued { get { throw null; } }
        public static Azure.AI.Projects.AgentStreamEvent ThreadRunRequiresAction { get { throw null; } }
        public static Azure.AI.Projects.AgentStreamEvent ThreadRunStepCancelled { get { throw null; } }
        public static Azure.AI.Projects.AgentStreamEvent ThreadRunStepCompleted { get { throw null; } }
        public static Azure.AI.Projects.AgentStreamEvent ThreadRunStepCreated { get { throw null; } }
        public static Azure.AI.Projects.AgentStreamEvent ThreadRunStepDelta { get { throw null; } }
        public static Azure.AI.Projects.AgentStreamEvent ThreadRunStepExpired { get { throw null; } }
        public static Azure.AI.Projects.AgentStreamEvent ThreadRunStepFailed { get { throw null; } }
        public static Azure.AI.Projects.AgentStreamEvent ThreadRunStepInProgress { get { throw null; } }
        public bool Equals(Azure.AI.Projects.AgentStreamEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.AgentStreamEvent left, Azure.AI.Projects.AgentStreamEvent right) { throw null; }
        public static implicit operator Azure.AI.Projects.AgentStreamEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.AgentStreamEvent left, Azure.AI.Projects.AgentStreamEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentThread : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentThread>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentThread>
    {
        internal AgentThread() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public Azure.AI.Projects.ToolResources ToolResources { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentThread System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentThread>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentThread>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentThread System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentThread>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentThread>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentThread>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentThreadCreationOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentThreadCreationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentThreadCreationOptions>
    {
        public AgentThreadCreationOptions() { }
        public System.Collections.Generic.IList<Azure.AI.Projects.ThreadMessageOptions> Messages { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public Azure.AI.Projects.ToolResources ToolResources { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentThreadCreationOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentThreadCreationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AgentThreadCreationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AgentThreadCreationOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentThreadCreationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentThreadCreationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AgentThreadCreationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class AIClientModelFactory
    {
        public static Azure.AI.Projects.Agent Agent(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), string name = null, string description = null, string model = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.ToolDefinition> tools = null, Azure.AI.Projects.ToolResources toolResources = null, float? temperature = default(float?), float? topP = default(float?), System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Projects.AgentFile AgentFile(string id = null, int size = 0, string filename = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), Azure.AI.Projects.AgentFilePurpose purpose = default(Azure.AI.Projects.AgentFilePurpose)) { throw null; }
        public static Azure.AI.Projects.AgentThread AgentThread(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), Azure.AI.Projects.ToolResources toolResources = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Projects.MessageTextFileCitationAnnotation MessageFileCitationTextAnnotation(string text, string fileId, string quote) { throw null; }
        public static Azure.AI.Projects.MessageTextFilePathAnnotation MessageFilePathTextAnnotation(string text, string fileId) { throw null; }
        public static Azure.AI.Projects.MessageImageFileContent MessageImageFileContent(string fileId) { throw null; }
        public static Azure.AI.Projects.MessageTextContent MessageTextContent(string text, System.Collections.Generic.IEnumerable<Azure.AI.Projects.MessageTextAnnotation> annotations) { throw null; }
        public static Azure.AI.Projects.PageableList<T> PageableList<T>(System.Collections.Generic.IReadOnlyList<T> data, string firstId, string lastId, bool hasMore) { throw null; }
        public static Azure.AI.Projects.RequiredFunctionToolCall RequiredFunctionToolCall(string toolCallId, string functionName, string functionArguments) { throw null; }
        public static Azure.AI.Projects.RunStep RunStep(string id = null, Azure.AI.Projects.RunStepType type = default(Azure.AI.Projects.RunStepType), string agentId = null, string threadId = null, string runId = null, Azure.AI.Projects.RunStepStatus status = default(Azure.AI.Projects.RunStepStatus), Azure.AI.Projects.RunStepDetails stepDetails = null, Azure.AI.Projects.RunStepError lastError = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset? expiredAt = default(System.DateTimeOffset?), System.DateTimeOffset? completedAt = default(System.DateTimeOffset?), System.DateTimeOffset? cancelledAt = default(System.DateTimeOffset?), System.DateTimeOffset? failedAt = default(System.DateTimeOffset?), Azure.AI.Projects.RunStepCompletionUsage usage = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Projects.RunStepCodeInterpreterToolCall RunStepCodeInterpreterToolCall(string id, string input, System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.RunStepCodeInterpreterToolCallOutput> outputs) { throw null; }
        public static Azure.AI.Projects.RunStepFunctionToolCall RunStepFunctionToolCall(string id, string name, string arguments, string output) { throw null; }
        public static Azure.AI.Projects.SubmitToolOutputsAction SubmitToolOutputsAction(System.Collections.Generic.IEnumerable<Azure.AI.Projects.RequiredToolCall> toolCalls) { throw null; }
        public static Azure.AI.Projects.ThreadMessage ThreadMessage(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), string threadId = null, Azure.AI.Projects.MessageStatus status = default(Azure.AI.Projects.MessageStatus), Azure.AI.Projects.MessageIncompleteDetails incompleteDetails = null, System.DateTimeOffset? completedAt = default(System.DateTimeOffset?), System.DateTimeOffset? incompleteAt = default(System.DateTimeOffset?), Azure.AI.Projects.MessageRole role = default(Azure.AI.Projects.MessageRole), System.Collections.Generic.IEnumerable<Azure.AI.Projects.MessageContent> contentItems = null, string agentId = null, string runId = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.MessageAttachment> attachments = null, System.Collections.Generic.IDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Projects.ThreadRun ThreadRun(string id = null, string threadId = null, string agentId = null, Azure.AI.Projects.RunStatus status = default(Azure.AI.Projects.RunStatus), Azure.AI.Projects.RequiredAction requiredAction = null, Azure.AI.Projects.RunError lastError = null, string model = null, string instructions = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.ToolDefinition> tools = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset? expiresAt = default(System.DateTimeOffset?), System.DateTimeOffset? startedAt = default(System.DateTimeOffset?), System.DateTimeOffset? completedAt = default(System.DateTimeOffset?), System.DateTimeOffset? cancelledAt = default(System.DateTimeOffset?), System.DateTimeOffset? failedAt = default(System.DateTimeOffset?), Azure.AI.Projects.IncompleteRunDetails incompleteDetails = null, Azure.AI.Projects.RunCompletionUsage usage = null, float? temperature = default(float?), float? topP = default(float?), int? maxPromptTokens = default(int?), int? maxCompletionTokens = default(int?), Azure.AI.Projects.TruncationObject truncationStrategy = null, System.BinaryData toolChoice = null, System.BinaryData responseFormat = null, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null, Azure.AI.Projects.UpdateToolResourcesOptions toolResources = null, bool? parallelToolCalls = default(bool?)) { throw null; }
    }
    public partial class AIProjectClient
    {
        protected AIProjectClient() { }
        public AIProjectClient(string connectionString, Azure.Core.TokenCredential credential) { }
        public AIProjectClient(string connectionString, Azure.Core.TokenCredential credential, Azure.AI.Projects.AIProjectClientOptions options) { }
        public AIProjectClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential) { }
        public AIProjectClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential, Azure.AI.Projects.AIProjectClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.AI.Projects.AgentsClient GetAgentsClient(string apiVersion = "2024-07-01-preview") { throw null; }
        public virtual Azure.AI.Inference.ChatCompletionsClient GetChatCompletionsClient() { throw null; }
        public virtual Azure.AI.Projects.ConnectionsClient GetConnectionsClient(string apiVersion = "2024-07-01-preview") { throw null; }
        public virtual Azure.AI.Inference.EmbeddingsClient GetEmbeddingsClient() { throw null; }
        public virtual Azure.AI.Projects.EvaluationsClient GetEvaluationsClient(string apiVersion = "2024-07-01-preview") { throw null; }
        public virtual Azure.AI.Projects.TelemetryClient GetTelemetryClient(string apiVersion = "2024-07-01-preview") { throw null; }
    }
    public partial class AIProjectClientOptions : Azure.Core.ClientOptions
    {
        public AIProjectClientOptions(Azure.AI.Projects.AIProjectClientOptions.ServiceVersion version = Azure.AI.Projects.AIProjectClientOptions.ServiceVersion.V2024_07_01_Preview) { }
        public enum ServiceVersion
        {
            V2024_07_01_Preview = 1,
        }
    }
    public static partial class AIProjectsModelFactory
    {
        public static Azure.AI.Projects.AgentPageableListOfVectorStore AgentPageableListOfVectorStore(Azure.AI.Projects.AgentPageableListOfVectorStoreObject @object = default(Azure.AI.Projects.AgentPageableListOfVectorStoreObject), System.Collections.Generic.IEnumerable<Azure.AI.Projects.VectorStore> data = null, string firstId = null, string lastId = null, bool hasMore = false) { throw null; }
        public static Azure.AI.Projects.AgentPageableListOfVectorStoreFile AgentPageableListOfVectorStoreFile(Azure.AI.Projects.AgentPageableListOfVectorStoreFileObject @object = default(Azure.AI.Projects.AgentPageableListOfVectorStoreFileObject), System.Collections.Generic.IEnumerable<Azure.AI.Projects.VectorStoreFile> data = null, string firstId = null, string lastId = null, bool hasMore = false) { throw null; }
        public static Azure.AI.Projects.AzureFunctionBinding AzureFunctionBinding(Azure.AI.Projects.AzureFunctionBindingType type = default(Azure.AI.Projects.AzureFunctionBindingType), Azure.AI.Projects.AzureFunctionStorageQueue storageQueue = null) { throw null; }
        public static Azure.AI.Projects.ConnectionProperties ConnectionProperties(Azure.AI.Projects.ConnectionType category = Azure.AI.Projects.ConnectionType.AzureOpenAI, string target = null) { throw null; }
        public static Azure.AI.Projects.ConnectionPropertiesApiKeyAuth ConnectionPropertiesApiKeyAuth(Azure.AI.Projects.ConnectionType category = Azure.AI.Projects.ConnectionType.AzureOpenAI, string target = null, Azure.AI.Projects.CredentialsApiKeyAuth credentials = null) { throw null; }
        public static Azure.AI.Projects.ConnectionResponse ConnectionResponse(string id = null, string name = null, Azure.AI.Projects.ConnectionProperties properties = null) { throw null; }
        public static Azure.AI.Projects.CredentialsApiKeyAuth CredentialsApiKeyAuth(string key = null) { throw null; }
        public static Azure.AI.Projects.Evaluation Evaluation(string id = null, Azure.AI.Projects.InputData data = null, string displayName = null, string description = null, Azure.AI.Projects.SystemData systemData = null, string status = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IDictionary<string, string> properties = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.EvaluatorConfiguration> evaluators = null) { throw null; }
        public static Azure.AI.Projects.EvaluationSchedule EvaluationSchedule(string name = null, Azure.AI.Projects.ApplicationInsightsConfiguration data = null, string description = null, Azure.AI.Projects.SystemData systemData = null, string provisioningState = null, System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IDictionary<string, string> properties = null, string isEnabled = null, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.EvaluatorConfiguration> evaluators = null, Azure.AI.Projects.Trigger trigger = null) { throw null; }
        public static Azure.AI.Projects.FileSearchToolCallContent FileSearchToolCallContent(Azure.AI.Projects.FileSearchToolCallContentType type = default(Azure.AI.Projects.FileSearchToolCallContentType), string text = null) { throw null; }
        public static Azure.AI.Projects.GetWorkspaceResponse GetWorkspaceResponse(string id = null, string name = null, Azure.AI.Projects.WorkspaceProperties properties = null) { throw null; }
        public static Azure.AI.Projects.IncompleteRunDetails IncompleteRunDetails(Azure.AI.Projects.IncompleteDetailsReason reason = default(Azure.AI.Projects.IncompleteDetailsReason)) { throw null; }
        public static Azure.AI.Projects.ListConnectionsResponse ListConnectionsResponse(System.Collections.Generic.IEnumerable<Azure.AI.Projects.ConnectionResponse> value = null) { throw null; }
        public static Azure.AI.Projects.MessageDelta MessageDelta(Azure.AI.Projects.MessageRole role = default(Azure.AI.Projects.MessageRole), System.Collections.Generic.IEnumerable<Azure.AI.Projects.MessageDeltaContent> content = null) { throw null; }
        public static Azure.AI.Projects.MessageDeltaChunk MessageDeltaChunk(string id = null, Azure.AI.Projects.MessageDeltaChunkObject @object = default(Azure.AI.Projects.MessageDeltaChunkObject), Azure.AI.Projects.MessageDelta delta = null) { throw null; }
        public static Azure.AI.Projects.MessageDeltaContent MessageDeltaContent(int index = 0, string type = null) { throw null; }
        public static Azure.AI.Projects.MessageDeltaImageFileContent MessageDeltaImageFileContent(int index = 0, Azure.AI.Projects.MessageDeltaImageFileContentObject imageFile = null) { throw null; }
        public static Azure.AI.Projects.MessageDeltaImageFileContentObject MessageDeltaImageFileContentObject(string fileId = null) { throw null; }
        public static Azure.AI.Projects.MessageDeltaTextAnnotation MessageDeltaTextAnnotation(int index = 0, string type = null) { throw null; }
        public static Azure.AI.Projects.MessageDeltaTextContent MessageDeltaTextContent(int index = 0, Azure.AI.Projects.MessageDeltaTextContentObject text = null) { throw null; }
        public static Azure.AI.Projects.MessageDeltaTextContentObject MessageDeltaTextContentObject(string value = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.MessageDeltaTextAnnotation> annotations = null) { throw null; }
        public static Azure.AI.Projects.MessageDeltaTextFileCitationAnnotation MessageDeltaTextFileCitationAnnotation(int index = 0, Azure.AI.Projects.MessageDeltaTextFileCitationAnnotationObject fileCitation = null, string text = null, int? startIndex = default(int?), int? endIndex = default(int?)) { throw null; }
        public static Azure.AI.Projects.MessageDeltaTextFileCitationAnnotationObject MessageDeltaTextFileCitationAnnotationObject(string fileId = null, string quote = null) { throw null; }
        public static Azure.AI.Projects.MessageDeltaTextFilePathAnnotation MessageDeltaTextFilePathAnnotation(int index = 0, Azure.AI.Projects.MessageDeltaTextFilePathAnnotationObject filePath = null, int? startIndex = default(int?), int? endIndex = default(int?), string text = null) { throw null; }
        public static Azure.AI.Projects.MessageDeltaTextFilePathAnnotationObject MessageDeltaTextFilePathAnnotationObject(string fileId = null) { throw null; }
        public static Azure.AI.Projects.MessageIncompleteDetails MessageIncompleteDetails(Azure.AI.Projects.MessageIncompleteDetailsReason reason = default(Azure.AI.Projects.MessageIncompleteDetailsReason)) { throw null; }
        public static Azure.AI.Projects.MessageTextAnnotation MessageTextAnnotation(string type = null, string text = null) { throw null; }
        public static Azure.AI.Projects.RequiredToolCall RequiredToolCall(string type = null, string id = null) { throw null; }
        public static Azure.AI.Projects.ResponseFormatJsonSchemaType ResponseFormatJsonSchemaType(Azure.AI.Projects.ResponseFormatJsonSchemaTypeType type = default(Azure.AI.Projects.ResponseFormatJsonSchemaTypeType), Azure.AI.Projects.ResponseFormatJsonSchema jsonSchema = null) { throw null; }
        public static Azure.AI.Projects.RunCompletionUsage RunCompletionUsage(long completionTokens = (long)0, long promptTokens = (long)0, long totalTokens = (long)0) { throw null; }
        public static Azure.AI.Projects.RunError RunError(string code = null, string message = null) { throw null; }
        public static Azure.AI.Projects.RunStepAzureAISearchToolCall RunStepAzureAISearchToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> azureAISearch = null) { throw null; }
        public static Azure.AI.Projects.RunStepBingGroundingToolCall RunStepBingGroundingToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> bingGrounding = null) { throw null; }
        public static Azure.AI.Projects.RunStepCodeInterpreterImageOutput RunStepCodeInterpreterImageOutput(Azure.AI.Projects.RunStepCodeInterpreterImageReference image = null) { throw null; }
        public static Azure.AI.Projects.RunStepCodeInterpreterImageReference RunStepCodeInterpreterImageReference(string fileId = null) { throw null; }
        public static Azure.AI.Projects.RunStepCodeInterpreterLogOutput RunStepCodeInterpreterLogOutput(string logs = null) { throw null; }
        public static Azure.AI.Projects.RunStepCompletionUsage RunStepCompletionUsage(long completionTokens = (long)0, long promptTokens = (long)0, long totalTokens = (long)0) { throw null; }
        public static Azure.AI.Projects.RunStepDelta RunStepDelta(Azure.AI.Projects.RunStepDeltaDetail stepDetails = null) { throw null; }
        public static Azure.AI.Projects.RunStepDeltaChunk RunStepDeltaChunk(string id = null, Azure.AI.Projects.RunStepDeltaChunkObject @object = default(Azure.AI.Projects.RunStepDeltaChunkObject), Azure.AI.Projects.RunStepDelta delta = null) { throw null; }
        public static Azure.AI.Projects.RunStepDeltaCodeInterpreterDetailItemObject RunStepDeltaCodeInterpreterDetailItemObject(string input = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.RunStepDeltaCodeInterpreterOutput> outputs = null) { throw null; }
        public static Azure.AI.Projects.RunStepDeltaCodeInterpreterImageOutput RunStepDeltaCodeInterpreterImageOutput(int index = 0, Azure.AI.Projects.RunStepDeltaCodeInterpreterImageOutputObject image = null) { throw null; }
        public static Azure.AI.Projects.RunStepDeltaCodeInterpreterImageOutputObject RunStepDeltaCodeInterpreterImageOutputObject(string fileId = null) { throw null; }
        public static Azure.AI.Projects.RunStepDeltaCodeInterpreterLogOutput RunStepDeltaCodeInterpreterLogOutput(int index = 0, string logs = null) { throw null; }
        public static Azure.AI.Projects.RunStepDeltaCodeInterpreterOutput RunStepDeltaCodeInterpreterOutput(int index = 0, string type = null) { throw null; }
        public static Azure.AI.Projects.RunStepDeltaCodeInterpreterToolCall RunStepDeltaCodeInterpreterToolCall(int index = 0, string id = null, Azure.AI.Projects.RunStepDeltaCodeInterpreterDetailItemObject codeInterpreter = null) { throw null; }
        public static Azure.AI.Projects.RunStepDeltaFileSearchToolCall RunStepDeltaFileSearchToolCall(int index = 0, string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> fileSearch = null) { throw null; }
        public static Azure.AI.Projects.RunStepDeltaFunction RunStepDeltaFunction(string name = null, string arguments = null, string output = null) { throw null; }
        public static Azure.AI.Projects.RunStepDeltaFunctionToolCall RunStepDeltaFunctionToolCall(int index = 0, string id = null, Azure.AI.Projects.RunStepDeltaFunction function = null) { throw null; }
        public static Azure.AI.Projects.RunStepDeltaMessageCreation RunStepDeltaMessageCreation(Azure.AI.Projects.RunStepDeltaMessageCreationObject messageCreation = null) { throw null; }
        public static Azure.AI.Projects.RunStepDeltaMessageCreationObject RunStepDeltaMessageCreationObject(string messageId = null) { throw null; }
        public static Azure.AI.Projects.RunStepDeltaToolCall RunStepDeltaToolCall(int index = 0, string id = null, string type = null) { throw null; }
        public static Azure.AI.Projects.RunStepDeltaToolCallObject RunStepDeltaToolCallObject(System.Collections.Generic.IEnumerable<Azure.AI.Projects.RunStepDeltaToolCall> toolCalls = null) { throw null; }
        public static Azure.AI.Projects.RunStepError RunStepError(Azure.AI.Projects.RunStepErrorCode code = default(Azure.AI.Projects.RunStepErrorCode), string message = null) { throw null; }
        public static Azure.AI.Projects.RunStepFileSearchToolCall RunStepFileSearchToolCall(string id = null, Azure.AI.Projects.RunStepFileSearchToolCallResults fileSearch = null) { throw null; }
        public static Azure.AI.Projects.RunStepFileSearchToolCallResult RunStepFileSearchToolCallResult(string fileId = null, string fileName = null, float score = 0f, System.Collections.Generic.IEnumerable<Azure.AI.Projects.FileSearchToolCallContent> content = null) { throw null; }
        public static Azure.AI.Projects.RunStepFileSearchToolCallResults RunStepFileSearchToolCallResults(Azure.AI.Projects.FileSearchRankingOptions rankingOptions = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.RunStepFileSearchToolCallResult> results = null) { throw null; }
        public static Azure.AI.Projects.RunStepMessageCreationDetails RunStepMessageCreationDetails(Azure.AI.Projects.RunStepMessageCreationReference messageCreation = null) { throw null; }
        public static Azure.AI.Projects.RunStepMessageCreationReference RunStepMessageCreationReference(string messageId = null) { throw null; }
        public static Azure.AI.Projects.RunStepMicrosoftFabricToolCall RunStepMicrosoftFabricToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> microsoftFabric = null) { throw null; }
        public static Azure.AI.Projects.RunStepSharepointToolCall RunStepSharepointToolCall(string id = null, System.Collections.Generic.IReadOnlyDictionary<string, string> sharePoint = null) { throw null; }
        public static Azure.AI.Projects.RunStepToolCall RunStepToolCall(string type = null, string id = null) { throw null; }
        public static Azure.AI.Projects.RunStepToolCallDetails RunStepToolCallDetails(System.Collections.Generic.IEnumerable<Azure.AI.Projects.RunStepToolCall> toolCalls = null) { throw null; }
        public static Azure.AI.Projects.SystemData SystemData(System.DateTimeOffset? createdAt = default(System.DateTimeOffset?), string createdBy = null, string createdByType = null, System.DateTimeOffset? lastModifiedAt = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.Projects.ThreadMessageOptions ThreadMessageOptions(Azure.AI.Projects.MessageRole role = default(Azure.AI.Projects.MessageRole), string content = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.MessageAttachment> attachments = null, System.Collections.Generic.IDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Projects.VectorStore VectorStore(string id = null, Azure.AI.Projects.VectorStoreObject @object = default(Azure.AI.Projects.VectorStoreObject), System.DateTimeOffset createdAt = default(System.DateTimeOffset), string name = null, int usageBytes = 0, Azure.AI.Projects.VectorStoreFileCount fileCounts = null, Azure.AI.Projects.VectorStoreStatus status = default(Azure.AI.Projects.VectorStoreStatus), Azure.AI.Projects.VectorStoreExpirationPolicy expiresAfter = null, System.DateTimeOffset? expiresAt = default(System.DateTimeOffset?), System.DateTimeOffset? lastActiveAt = default(System.DateTimeOffset?), System.Collections.Generic.IReadOnlyDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Projects.VectorStoreDeletionStatus VectorStoreDeletionStatus(string id = null, bool deleted = false, Azure.AI.Projects.VectorStoreDeletionStatusObject @object = default(Azure.AI.Projects.VectorStoreDeletionStatusObject)) { throw null; }
        public static Azure.AI.Projects.VectorStoreFile VectorStoreFile(string id = null, Azure.AI.Projects.VectorStoreFileObject @object = default(Azure.AI.Projects.VectorStoreFileObject), int usageBytes = 0, System.DateTimeOffset createdAt = default(System.DateTimeOffset), string vectorStoreId = null, Azure.AI.Projects.VectorStoreFileStatus status = default(Azure.AI.Projects.VectorStoreFileStatus), Azure.AI.Projects.VectorStoreFileError lastError = null, Azure.AI.Projects.VectorStoreChunkingStrategyResponse chunkingStrategy = null) { throw null; }
        public static Azure.AI.Projects.VectorStoreFileBatch VectorStoreFileBatch(string id = null, Azure.AI.Projects.VectorStoreFileBatchObject @object = default(Azure.AI.Projects.VectorStoreFileBatchObject), System.DateTimeOffset createdAt = default(System.DateTimeOffset), string vectorStoreId = null, Azure.AI.Projects.VectorStoreFileBatchStatus status = default(Azure.AI.Projects.VectorStoreFileBatchStatus), Azure.AI.Projects.VectorStoreFileCount fileCounts = null) { throw null; }
        public static Azure.AI.Projects.VectorStoreFileCount VectorStoreFileCount(int inProgress = 0, int completed = 0, int failed = 0, int cancelled = 0, int total = 0) { throw null; }
        public static Azure.AI.Projects.VectorStoreFileDeletionStatus VectorStoreFileDeletionStatus(string id = null, bool deleted = false, Azure.AI.Projects.VectorStoreFileDeletionStatusObject @object = default(Azure.AI.Projects.VectorStoreFileDeletionStatusObject)) { throw null; }
        public static Azure.AI.Projects.VectorStoreFileError VectorStoreFileError(Azure.AI.Projects.VectorStoreFileErrorCode code = default(Azure.AI.Projects.VectorStoreFileErrorCode), string message = null) { throw null; }
        public static Azure.AI.Projects.VectorStoreStaticChunkingStrategyRequest VectorStoreStaticChunkingStrategyRequest(Azure.AI.Projects.VectorStoreStaticChunkingStrategyOptions @static = null) { throw null; }
        public static Azure.AI.Projects.VectorStoreStaticChunkingStrategyResponse VectorStoreStaticChunkingStrategyResponse(Azure.AI.Projects.VectorStoreStaticChunkingStrategyOptions @static = null) { throw null; }
        public static Azure.AI.Projects.WorkspaceProperties WorkspaceProperties(string applicationInsights = null) { throw null; }
    }
    public partial class ApplicationInsightsConfiguration : Azure.AI.Projects.InputData, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ApplicationInsightsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ApplicationInsightsConfiguration>
    {
        public ApplicationInsightsConfiguration(string resourceId, string query, string serviceName) { }
        public string ConnectionString { get { throw null; } set { } }
        public string Query { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
        public string ServiceName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ApplicationInsightsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ApplicationInsightsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ApplicationInsightsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ApplicationInsightsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ApplicationInsightsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ApplicationInsightsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ApplicationInsightsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum AuthenticationType
    {
        ApiKey = 0,
        EntraId = 1,
        SAS = 2,
    }
    public partial class AzureAISearchResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureAISearchResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureAISearchResource>
    {
        public AzureAISearchResource() { }
        public System.Collections.Generic.IList<Azure.AI.Projects.IndexResource> IndexList { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AzureAISearchResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureAISearchResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureAISearchResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AzureAISearchResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureAISearchResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureAISearchResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureAISearchResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAISearchToolDefinition : Azure.AI.Projects.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureAISearchToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureAISearchToolDefinition>
    {
        public AzureAISearchToolDefinition() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AzureAISearchToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureAISearchToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureAISearchToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AzureAISearchToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureAISearchToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureAISearchToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureAISearchToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionBinding : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureFunctionBinding>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureFunctionBinding>
    {
        public AzureFunctionBinding(Azure.AI.Projects.AzureFunctionStorageQueue storageQueue) { }
        public Azure.AI.Projects.AzureFunctionStorageQueue StorageQueue { get { throw null; } set { } }
        public Azure.AI.Projects.AzureFunctionBindingType Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AzureFunctionBinding System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureFunctionBinding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureFunctionBinding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AzureFunctionBinding System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureFunctionBinding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureFunctionBinding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureFunctionBinding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureFunctionBindingType : System.IEquatable<Azure.AI.Projects.AzureFunctionBindingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureFunctionBindingType(string value) { throw null; }
        public static Azure.AI.Projects.AzureFunctionBindingType StorageQueue { get { throw null; } }
        public bool Equals(Azure.AI.Projects.AzureFunctionBindingType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.AzureFunctionBindingType left, Azure.AI.Projects.AzureFunctionBindingType right) { throw null; }
        public static implicit operator Azure.AI.Projects.AzureFunctionBindingType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.AzureFunctionBindingType left, Azure.AI.Projects.AzureFunctionBindingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureFunctionStorageQueue : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureFunctionStorageQueue>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureFunctionStorageQueue>
    {
        public AzureFunctionStorageQueue(string storageServiceEndpoint, string queueName) { }
        public string QueueName { get { throw null; } set { } }
        public string StorageServiceEndpoint { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AzureFunctionStorageQueue System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureFunctionStorageQueue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureFunctionStorageQueue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AzureFunctionStorageQueue System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureFunctionStorageQueue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureFunctionStorageQueue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureFunctionStorageQueue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionToolDefinition : Azure.AI.Projects.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureFunctionToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureFunctionToolDefinition>
    {
        public AzureFunctionToolDefinition(string name, string description, Azure.AI.Projects.AzureFunctionBinding inputBinding, Azure.AI.Projects.AzureFunctionBinding outputBinding, System.BinaryData parameters) { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AzureFunctionToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureFunctionToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.AzureFunctionToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.AzureFunctionToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureFunctionToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureFunctionToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.AzureFunctionToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingGroundingToolDefinition : Azure.AI.Projects.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.BingGroundingToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.BingGroundingToolDefinition>
    {
        public BingGroundingToolDefinition(Azure.AI.Projects.ToolConnectionList bingGrounding) { }
        public Azure.AI.Projects.ToolConnectionList BingGrounding { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.BingGroundingToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.BingGroundingToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.BingGroundingToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.BingGroundingToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.BingGroundingToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.BingGroundingToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.BingGroundingToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CodeInterpreterToolDefinition : Azure.AI.Projects.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CodeInterpreterToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CodeInterpreterToolDefinition>
    {
        public CodeInterpreterToolDefinition() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.CodeInterpreterToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CodeInterpreterToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CodeInterpreterToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.CodeInterpreterToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CodeInterpreterToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CodeInterpreterToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CodeInterpreterToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CodeInterpreterToolResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CodeInterpreterToolResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CodeInterpreterToolResource>
    {
        public CodeInterpreterToolResource() { }
        public System.Collections.Generic.IList<Azure.AI.Projects.VectorStoreDataSource> DataSources { get { throw null; } }
        public System.Collections.Generic.IList<string> FileIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.CodeInterpreterToolResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CodeInterpreterToolResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CodeInterpreterToolResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.CodeInterpreterToolResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CodeInterpreterToolResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CodeInterpreterToolResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CodeInterpreterToolResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConnectionProperties>
    {
        protected ConnectionProperties(Azure.AI.Projects.ConnectionType category, string target) { }
        public Azure.AI.Projects.AuthenticationType AuthType { get { throw null; } set { } }
        public Azure.AI.Projects.ConnectionType Category { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectionPropertiesApiKeyAuth : Azure.AI.Projects.ConnectionProperties, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ConnectionPropertiesApiKeyAuth>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConnectionPropertiesApiKeyAuth>
    {
        internal ConnectionPropertiesApiKeyAuth() : base (default(Azure.AI.Projects.ConnectionType), default(string)) { }
        public Azure.AI.Projects.CredentialsApiKeyAuth Credentials { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ConnectionPropertiesApiKeyAuth System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ConnectionPropertiesApiKeyAuth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ConnectionPropertiesApiKeyAuth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ConnectionPropertiesApiKeyAuth System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConnectionPropertiesApiKeyAuth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConnectionPropertiesApiKeyAuth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConnectionPropertiesApiKeyAuth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectionResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ConnectionResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConnectionResponse>
    {
        internal ConnectionResponse() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Projects.ConnectionProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ConnectionResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ConnectionResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ConnectionResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ConnectionResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConnectionResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConnectionResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ConnectionResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConnectionsClient
    {
        protected ConnectionsClient() { }
        public ConnectionsClient(string connectionString, Azure.Core.TokenCredential credential) { }
        public ConnectionsClient(string connectionString, Azure.Core.TokenCredential credential, Azure.AI.Projects.AIProjectClientOptions options) { }
        public ConnectionsClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential) { }
        public ConnectionsClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential, Azure.AI.Projects.AIProjectClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response GetConnection(string connectionName, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.ConnectionResponse> GetConnection(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetConnectionAsync(string connectionName, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.ConnectionResponse>> GetConnectionAsync(string connectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.ListConnectionsResponse> GetConnections(Azure.AI.Projects.ConnectionType? category = default(Azure.AI.Projects.ConnectionType?), bool? includeAll = default(bool?), string target = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetConnections(string category, bool? includeAll, string target, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.ListConnectionsResponse>> GetConnectionsAsync(Azure.AI.Projects.ConnectionType? category = default(Azure.AI.Projects.ConnectionType?), bool? includeAll = default(bool?), string target = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetConnectionsAsync(string category, bool? includeAll, string target, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response GetConnectionWithSecrets(string connectionName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.ConnectionResponse> GetConnectionWithSecrets(string connectionName, string ignored, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetConnectionWithSecretsAsync(string connectionName, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.ConnectionResponse>> GetConnectionWithSecretsAsync(string connectionName, string ignored, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.ConnectionResponse> GetDefaultConnection(Azure.AI.Projects.ConnectionType category, bool? withCredential = default(bool?), bool? includeAll = default(bool?), string target = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.ConnectionResponse>> GetDefaultConnectionAsync(Azure.AI.Projects.ConnectionType category, bool? withCredential = default(bool?), bool? includeAll = default(bool?), string target = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetWorkspace(Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.GetWorkspaceResponse> GetWorkspace(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetWorkspaceAsync(Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.GetWorkspaceResponse>> GetWorkspaceAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public enum ConnectionType
    {
        AzureOpenAI = 0,
        Serverless = 1,
        AzureBlobStorage = 2,
        AzureAIServices = 3,
        AzureAISearch = 4,
        ApiKey = 5,
    }
    public partial class CredentialsApiKeyAuth : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CredentialsApiKeyAuth>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CredentialsApiKeyAuth>
    {
        internal CredentialsApiKeyAuth() { }
        public string Key { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.CredentialsApiKeyAuth System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CredentialsApiKeyAuth>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CredentialsApiKeyAuth>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.CredentialsApiKeyAuth System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CredentialsApiKeyAuth>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CredentialsApiKeyAuth>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CredentialsApiKeyAuth>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CronTrigger : Azure.AI.Projects.Trigger, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CronTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CronTrigger>
    {
        public CronTrigger(string expression) { }
        public string Expression { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.CronTrigger System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CronTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.CronTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.CronTrigger System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CronTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CronTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.CronTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Dataset : Azure.AI.Projects.InputData, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Dataset>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Dataset>
    {
        public Dataset(string id) { }
        public string Id { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Dataset System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Dataset>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Dataset>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Dataset System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Dataset>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Dataset>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Dataset>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DoneEvent : System.IEquatable<Azure.AI.Projects.DoneEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DoneEvent(string value) { throw null; }
        public static Azure.AI.Projects.DoneEvent Done { get { throw null; } }
        public bool Equals(Azure.AI.Projects.DoneEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.DoneEvent left, Azure.AI.Projects.DoneEvent right) { throw null; }
        public static implicit operator Azure.AI.Projects.DoneEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.DoneEvent left, Azure.AI.Projects.DoneEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ErrorEvent : System.IEquatable<Azure.AI.Projects.ErrorEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ErrorEvent(string value) { throw null; }
        public static Azure.AI.Projects.ErrorEvent Error { get { throw null; } }
        public bool Equals(Azure.AI.Projects.ErrorEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.ErrorEvent left, Azure.AI.Projects.ErrorEvent right) { throw null; }
        public static implicit operator Azure.AI.Projects.ErrorEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.ErrorEvent left, Azure.AI.Projects.ErrorEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Evaluation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation>
    {
        public Evaluation(Azure.AI.Projects.InputData data, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.EvaluatorConfiguration> evaluators) { }
        public Azure.AI.Projects.InputData Data { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string DisplayName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Projects.EvaluatorConfiguration> Evaluators { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public string Status { get { throw null; } }
        public Azure.AI.Projects.SystemData SystemData { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Evaluation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Evaluation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Evaluation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationSchedule : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluationSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationSchedule>
    {
        public EvaluationSchedule(Azure.AI.Projects.ApplicationInsightsConfiguration data, System.Collections.Generic.IDictionary<string, Azure.AI.Projects.EvaluatorConfiguration> evaluators, Azure.AI.Projects.Trigger trigger) { }
        public Azure.AI.Projects.ApplicationInsightsConfiguration Data { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Projects.EvaluatorConfiguration> Evaluators { get { throw null; } }
        public string IsEnabled { get { throw null; } }
        public string Name { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Properties { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.AI.Projects.SystemData SystemData { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public Azure.AI.Projects.Trigger Trigger { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EvaluationSchedule System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluationSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluationSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EvaluationSchedule System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluationSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EvaluationsClient
    {
        protected EvaluationsClient() { }
        public EvaluationsClient(string connectionString, Azure.Core.TokenCredential credential) { }
        public EvaluationsClient(string connectionString, Azure.Core.TokenCredential credential, Azure.AI.Projects.AIProjectClientOptions options) { }
        public EvaluationsClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential) { }
        public EvaluationsClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential, Azure.AI.Projects.AIProjectClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.Projects.Evaluation> Create(Azure.AI.Projects.Evaluation evaluation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Create(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.Evaluation>> CreateAsync(Azure.AI.Projects.Evaluation evaluation, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.EvaluationSchedule> CreateOrReplaceSchedule(string name, Azure.AI.Projects.EvaluationSchedule resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response CreateOrReplaceSchedule(string name, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.EvaluationSchedule>> CreateOrReplaceScheduleAsync(string name, Azure.AI.Projects.EvaluationSchedule resource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrReplaceScheduleAsync(string name, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DisableSchedule(string name, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DisableScheduleAsync(string name, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetEvaluation(string id, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.Evaluation> GetEvaluation(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetEvaluationAsync(string id, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.Evaluation>> GetEvaluationAsync(string id, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetEvaluations(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Projects.Evaluation> GetEvaluations(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetEvaluationsAsync(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Projects.Evaluation> GetEvaluationsAsync(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetSchedule(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.Projects.EvaluationSchedule> GetSchedule(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetScheduleAsync(string name, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.Projects.EvaluationSchedule>> GetScheduleAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetSchedules(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.Projects.EvaluationSchedule> GetSchedules(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetSchedulesAsync(int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.Projects.EvaluationSchedule> GetSchedulesAsync(int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Update(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdateAsync(string id, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    public partial class EvaluatorConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluatorConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluatorConfiguration>
    {
        public EvaluatorConfiguration(string id) { }
        public System.Collections.Generic.IDictionary<string, string> DataMapping { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> InitParams { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EvaluatorConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluatorConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.EvaluatorConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.EvaluatorConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluatorConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluatorConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.EvaluatorConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSearchRankingOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileSearchRankingOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileSearchRankingOptions>
    {
        public FileSearchRankingOptions(string ranker, float scoreThreshold) { }
        public string Ranker { get { throw null; } set { } }
        public float ScoreThreshold { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FileSearchRankingOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileSearchRankingOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileSearchRankingOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FileSearchRankingOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileSearchRankingOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileSearchRankingOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileSearchRankingOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSearchToolCallContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileSearchToolCallContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileSearchToolCallContent>
    {
        internal FileSearchToolCallContent() { }
        public string Text { get { throw null; } }
        public Azure.AI.Projects.FileSearchToolCallContentType Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FileSearchToolCallContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileSearchToolCallContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileSearchToolCallContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FileSearchToolCallContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileSearchToolCallContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileSearchToolCallContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileSearchToolCallContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileSearchToolCallContentType : System.IEquatable<Azure.AI.Projects.FileSearchToolCallContentType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileSearchToolCallContentType(string value) { throw null; }
        public static Azure.AI.Projects.FileSearchToolCallContentType Text { get { throw null; } }
        public bool Equals(Azure.AI.Projects.FileSearchToolCallContentType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.FileSearchToolCallContentType left, Azure.AI.Projects.FileSearchToolCallContentType right) { throw null; }
        public static implicit operator Azure.AI.Projects.FileSearchToolCallContentType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.FileSearchToolCallContentType left, Azure.AI.Projects.FileSearchToolCallContentType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FileSearchToolDefinition : Azure.AI.Projects.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileSearchToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileSearchToolDefinition>
    {
        public FileSearchToolDefinition() { }
        public Azure.AI.Projects.FileSearchToolDefinitionDetails FileSearch { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FileSearchToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileSearchToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileSearchToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FileSearchToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileSearchToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileSearchToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileSearchToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSearchToolDefinitionDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileSearchToolDefinitionDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileSearchToolDefinitionDetails>
    {
        public FileSearchToolDefinitionDetails() { }
        public int? MaxNumResults { get { throw null; } set { } }
        public Azure.AI.Projects.FileSearchRankingOptions RankingOptions { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FileSearchToolDefinitionDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileSearchToolDefinitionDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileSearchToolDefinitionDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FileSearchToolDefinitionDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileSearchToolDefinitionDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileSearchToolDefinitionDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileSearchToolDefinitionDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileSearchToolResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileSearchToolResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileSearchToolResource>
    {
        public FileSearchToolResource() { }
        public FileSearchToolResource(System.Collections.Generic.IList<string> vectorStoreIds, System.Collections.Generic.IList<Azure.AI.Projects.VectorStoreConfigurations> vectorStores) { }
        public System.Collections.Generic.IList<string> VectorStoreIds { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.VectorStoreConfigurations> VectorStores { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FileSearchToolResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileSearchToolResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FileSearchToolResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FileSearchToolResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileSearchToolResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileSearchToolResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FileSearchToolResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileState : System.IEquatable<Azure.AI.Projects.FileState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileState(string value) { throw null; }
        public static Azure.AI.Projects.FileState Deleted { get { throw null; } }
        public static Azure.AI.Projects.FileState Deleting { get { throw null; } }
        public static Azure.AI.Projects.FileState Error { get { throw null; } }
        public static Azure.AI.Projects.FileState Pending { get { throw null; } }
        public static Azure.AI.Projects.FileState Processed { get { throw null; } }
        public static Azure.AI.Projects.FileState Running { get { throw null; } }
        public static Azure.AI.Projects.FileState Uploaded { get { throw null; } }
        public bool Equals(Azure.AI.Projects.FileState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.FileState left, Azure.AI.Projects.FileState right) { throw null; }
        public static implicit operator Azure.AI.Projects.FileState (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.FileState left, Azure.AI.Projects.FileState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Frequency : System.IEquatable<Azure.AI.Projects.Frequency>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Frequency(string value) { throw null; }
        public static Azure.AI.Projects.Frequency Day { get { throw null; } }
        public static Azure.AI.Projects.Frequency Hour { get { throw null; } }
        public static Azure.AI.Projects.Frequency Minute { get { throw null; } }
        public static Azure.AI.Projects.Frequency Month { get { throw null; } }
        public static Azure.AI.Projects.Frequency Week { get { throw null; } }
        public bool Equals(Azure.AI.Projects.Frequency other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.Frequency left, Azure.AI.Projects.Frequency right) { throw null; }
        public static implicit operator Azure.AI.Projects.Frequency (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.Frequency left, Azure.AI.Projects.Frequency right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FunctionName : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FunctionName>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FunctionName>
    {
        public FunctionName(string name) { }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FunctionName System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FunctionName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FunctionName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FunctionName System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FunctionName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FunctionName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FunctionName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FunctionToolDefinition : Azure.AI.Projects.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FunctionToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FunctionToolDefinition>
    {
        public FunctionToolDefinition(string name, string description) { }
        public FunctionToolDefinition(string name, string description, System.BinaryData parameters) { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        public System.BinaryData Parameters { get { throw null; } }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static bool operator ==(Azure.AI.Projects.FunctionToolDefinition functionToolDefinition, Azure.AI.Projects.RequiredFunctionToolCall functionToolCall) { throw null; }
        public static bool operator ==(Azure.AI.Projects.FunctionToolDefinition functionToolDefinition, Azure.AI.Projects.RunStepFunctionToolCall functionToolCall) { throw null; }
        public static bool operator ==(Azure.AI.Projects.RequiredFunctionToolCall functionToolCall, Azure.AI.Projects.FunctionToolDefinition functionToolDefinition) { throw null; }
        public static bool operator ==(Azure.AI.Projects.RunStepFunctionToolCall functionToolCall, Azure.AI.Projects.FunctionToolDefinition functionToolDefinition) { throw null; }
        public static bool operator !=(Azure.AI.Projects.FunctionToolDefinition functionToolDefinition, Azure.AI.Projects.RequiredFunctionToolCall functionToolCall) { throw null; }
        public static bool operator !=(Azure.AI.Projects.FunctionToolDefinition functionToolDefinition, Azure.AI.Projects.RunStepFunctionToolCall functionToolCall) { throw null; }
        public static bool operator !=(Azure.AI.Projects.RequiredFunctionToolCall functionToolCall, Azure.AI.Projects.FunctionToolDefinition functionToolDefinition) { throw null; }
        public static bool operator !=(Azure.AI.Projects.RunStepFunctionToolCall functionToolCall, Azure.AI.Projects.FunctionToolDefinition functionToolDefinition) { throw null; }
        Azure.AI.Projects.FunctionToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FunctionToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.FunctionToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.FunctionToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FunctionToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FunctionToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.FunctionToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetWorkspaceResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.GetWorkspaceResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.GetWorkspaceResponse>
    {
        internal GetWorkspaceResponse() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Projects.WorkspaceProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.GetWorkspaceResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.GetWorkspaceResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.GetWorkspaceResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.GetWorkspaceResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.GetWorkspaceResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.GetWorkspaceResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.GetWorkspaceResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IncompleteDetailsReason : System.IEquatable<Azure.AI.Projects.IncompleteDetailsReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IncompleteDetailsReason(string value) { throw null; }
        public static Azure.AI.Projects.IncompleteDetailsReason MaxCompletionTokens { get { throw null; } }
        public static Azure.AI.Projects.IncompleteDetailsReason MaxPromptTokens { get { throw null; } }
        public bool Equals(Azure.AI.Projects.IncompleteDetailsReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.IncompleteDetailsReason left, Azure.AI.Projects.IncompleteDetailsReason right) { throw null; }
        public static implicit operator Azure.AI.Projects.IncompleteDetailsReason (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.IncompleteDetailsReason left, Azure.AI.Projects.IncompleteDetailsReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IncompleteRunDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.IncompleteRunDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.IncompleteRunDetails>
    {
        internal IncompleteRunDetails() { }
        public Azure.AI.Projects.IncompleteDetailsReason Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.IncompleteRunDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.IncompleteRunDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.IncompleteRunDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.IncompleteRunDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.IncompleteRunDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.IncompleteRunDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.IncompleteRunDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IndexResource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.IndexResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.IndexResource>
    {
        public IndexResource(string indexConnectionId, string indexName) { }
        public string IndexConnectionId { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.IndexResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.IndexResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.IndexResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.IndexResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.IndexResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.IndexResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.IndexResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class InputData : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.InputData>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InputData>
    {
        protected InputData() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.InputData System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.InputData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.InputData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.InputData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InputData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InputData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.InputData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ListConnectionsResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ListConnectionsResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ListConnectionsResponse>
    {
        internal ListConnectionsResponse() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.ConnectionResponse> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ListConnectionsResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ListConnectionsResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ListConnectionsResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ListConnectionsResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ListConnectionsResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ListConnectionsResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ListConnectionsResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ListSortOrder : System.IEquatable<Azure.AI.Projects.ListSortOrder>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ListSortOrder(string value) { throw null; }
        public static Azure.AI.Projects.ListSortOrder Ascending { get { throw null; } }
        public static Azure.AI.Projects.ListSortOrder Descending { get { throw null; } }
        public bool Equals(Azure.AI.Projects.ListSortOrder other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.ListSortOrder left, Azure.AI.Projects.ListSortOrder right) { throw null; }
        public static implicit operator Azure.AI.Projects.ListSortOrder (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.ListSortOrder left, Azure.AI.Projects.ListSortOrder right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MessageAttachment : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageAttachment>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageAttachment>
    {
        public MessageAttachment(Azure.AI.Projects.VectorStoreDataSource ds, System.Collections.Generic.List<Azure.AI.Projects.ToolDefinition> tools) { }
        public MessageAttachment(System.Collections.Generic.IEnumerable<System.BinaryData> tools) { }
        public MessageAttachment(string fileId, System.Collections.Generic.List<Azure.AI.Projects.ToolDefinition> tools) { }
        public Azure.AI.Projects.VectorStoreDataSource DataSource { get { throw null; } set { } }
        public string FileId { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.BinaryData> Tools { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageAttachment System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageAttachment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageAttachment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageAttachment System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageAttachment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageAttachment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageAttachment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MessageContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageContent>
    {
        protected MessageContent() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageContentUpdate : Azure.AI.Projects.StreamingUpdate
    {
        internal MessageContentUpdate() { }
        public string ImageFileId { get { throw null; } }
        public string MessageId { get { throw null; } }
        public int MessageIndex { get { throw null; } }
        public Azure.AI.Projects.MessageRole? Role { get { throw null; } }
        public string Text { get { throw null; } }
        public Azure.AI.Projects.TextAnnotationUpdate TextAnnotation { get { throw null; } }
    }
    public partial class MessageDelta : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDelta>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDelta>
    {
        internal MessageDelta() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.MessageDeltaContent> Content { get { throw null; } }
        public Azure.AI.Projects.MessageRole Role { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageDelta System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDelta>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDelta>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageDelta System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDelta>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDelta>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDelta>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaChunk : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaChunk>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaChunk>
    {
        internal MessageDeltaChunk() { }
        public Azure.AI.Projects.MessageDelta Delta { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Projects.MessageDeltaChunkObject Object { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageDeltaChunk System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaChunk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaChunk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageDeltaChunk System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaChunk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaChunk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaChunk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageDeltaChunkObject : System.IEquatable<Azure.AI.Projects.MessageDeltaChunkObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageDeltaChunkObject(string value) { throw null; }
        public static Azure.AI.Projects.MessageDeltaChunkObject ThreadMessageDelta { get { throw null; } }
        public bool Equals(Azure.AI.Projects.MessageDeltaChunkObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.MessageDeltaChunkObject left, Azure.AI.Projects.MessageDeltaChunkObject right) { throw null; }
        public static implicit operator Azure.AI.Projects.MessageDeltaChunkObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.MessageDeltaChunkObject left, Azure.AI.Projects.MessageDeltaChunkObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class MessageDeltaContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaContent>
    {
        protected MessageDeltaContent(int index) { }
        public int Index { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageDeltaContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageDeltaContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaImageFileContent : Azure.AI.Projects.MessageDeltaContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaImageFileContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaImageFileContent>
    {
        internal MessageDeltaImageFileContent() : base (default(int)) { }
        public Azure.AI.Projects.MessageDeltaImageFileContentObject ImageFile { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageDeltaImageFileContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaImageFileContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaImageFileContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageDeltaImageFileContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaImageFileContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaImageFileContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaImageFileContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaImageFileContentObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaImageFileContentObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaImageFileContentObject>
    {
        internal MessageDeltaImageFileContentObject() { }
        public string FileId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageDeltaImageFileContentObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaImageFileContentObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaImageFileContentObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageDeltaImageFileContentObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaImageFileContentObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaImageFileContentObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaImageFileContentObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MessageDeltaTextAnnotation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaTextAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaTextAnnotation>
    {
        protected internal System.Collections.Generic.IDictionary<string, System.BinaryData> SerializedAdditionalRawData;
        protected MessageDeltaTextAnnotation(int index) { }
        public int Index { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageDeltaTextAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaTextAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaTextAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageDeltaTextAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaTextAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaTextAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaTextAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextContent : Azure.AI.Projects.MessageDeltaContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaTextContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaTextContent>
    {
        internal MessageDeltaTextContent() : base (default(int)) { }
        public Azure.AI.Projects.MessageDeltaTextContentObject Text { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageDeltaTextContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaTextContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaTextContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageDeltaTextContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaTextContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaTextContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaTextContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextContentObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaTextContentObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaTextContentObject>
    {
        internal MessageDeltaTextContentObject() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.MessageDeltaTextAnnotation> Annotations { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageDeltaTextContentObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaTextContentObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaTextContentObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageDeltaTextContentObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaTextContentObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaTextContentObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaTextContentObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextFileCitationAnnotation : Azure.AI.Projects.MessageDeltaTextAnnotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaTextFileCitationAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaTextFileCitationAnnotation>
    {
        internal MessageDeltaTextFileCitationAnnotation() : base (default(int)) { }
        public int? EndIndex { get { throw null; } }
        public Azure.AI.Projects.MessageDeltaTextFileCitationAnnotationObject FileCitation { get { throw null; } }
        public int? StartIndex { get { throw null; } }
        public string Text { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageDeltaTextFileCitationAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaTextFileCitationAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaTextFileCitationAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageDeltaTextFileCitationAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaTextFileCitationAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaTextFileCitationAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaTextFileCitationAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextFileCitationAnnotationObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaTextFileCitationAnnotationObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaTextFileCitationAnnotationObject>
    {
        internal MessageDeltaTextFileCitationAnnotationObject() { }
        public string FileId { get { throw null; } }
        public string Quote { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageDeltaTextFileCitationAnnotationObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaTextFileCitationAnnotationObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaTextFileCitationAnnotationObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageDeltaTextFileCitationAnnotationObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaTextFileCitationAnnotationObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaTextFileCitationAnnotationObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaTextFileCitationAnnotationObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextFilePathAnnotation : Azure.AI.Projects.MessageDeltaTextAnnotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaTextFilePathAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaTextFilePathAnnotation>
    {
        internal MessageDeltaTextFilePathAnnotation() : base (default(int)) { }
        public int? EndIndex { get { throw null; } }
        public Azure.AI.Projects.MessageDeltaTextFilePathAnnotationObject FilePath { get { throw null; } }
        public int? StartIndex { get { throw null; } }
        public string Text { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageDeltaTextFilePathAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaTextFilePathAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaTextFilePathAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageDeltaTextFilePathAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaTextFilePathAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaTextFilePathAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaTextFilePathAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageDeltaTextFilePathAnnotationObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaTextFilePathAnnotationObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaTextFilePathAnnotationObject>
    {
        internal MessageDeltaTextFilePathAnnotationObject() { }
        public string FileId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageDeltaTextFilePathAnnotationObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaTextFilePathAnnotationObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageDeltaTextFilePathAnnotationObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageDeltaTextFilePathAnnotationObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaTextFilePathAnnotationObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaTextFilePathAnnotationObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageDeltaTextFilePathAnnotationObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageImageFileContent : Azure.AI.Projects.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageImageFileContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageImageFileContent>
    {
        internal MessageImageFileContent() { }
        public string FileId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageImageFileContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageImageFileContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageImageFileContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageImageFileContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageImageFileContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageImageFileContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageImageFileContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageIncompleteDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageIncompleteDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageIncompleteDetails>
    {
        internal MessageIncompleteDetails() { }
        public Azure.AI.Projects.MessageIncompleteDetailsReason Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageIncompleteDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageIncompleteDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageIncompleteDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageIncompleteDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageIncompleteDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageIncompleteDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageIncompleteDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageIncompleteDetailsReason : System.IEquatable<Azure.AI.Projects.MessageIncompleteDetailsReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageIncompleteDetailsReason(string value) { throw null; }
        public static Azure.AI.Projects.MessageIncompleteDetailsReason ContentFilter { get { throw null; } }
        public static Azure.AI.Projects.MessageIncompleteDetailsReason MaxTokens { get { throw null; } }
        public static Azure.AI.Projects.MessageIncompleteDetailsReason RunCancelled { get { throw null; } }
        public static Azure.AI.Projects.MessageIncompleteDetailsReason RunExpired { get { throw null; } }
        public static Azure.AI.Projects.MessageIncompleteDetailsReason RunFailed { get { throw null; } }
        public bool Equals(Azure.AI.Projects.MessageIncompleteDetailsReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.MessageIncompleteDetailsReason left, Azure.AI.Projects.MessageIncompleteDetailsReason right) { throw null; }
        public static implicit operator Azure.AI.Projects.MessageIncompleteDetailsReason (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.MessageIncompleteDetailsReason left, Azure.AI.Projects.MessageIncompleteDetailsReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageRole : System.IEquatable<Azure.AI.Projects.MessageRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageRole(string value) { throw null; }
        public static Azure.AI.Projects.MessageRole Agent { get { throw null; } }
        public static Azure.AI.Projects.MessageRole User { get { throw null; } }
        public bool Equals(Azure.AI.Projects.MessageRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.MessageRole left, Azure.AI.Projects.MessageRole right) { throw null; }
        public static implicit operator Azure.AI.Projects.MessageRole (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.MessageRole left, Azure.AI.Projects.MessageRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageStatus : System.IEquatable<Azure.AI.Projects.MessageStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageStatus(string value) { throw null; }
        public static Azure.AI.Projects.MessageStatus Completed { get { throw null; } }
        public static Azure.AI.Projects.MessageStatus Incomplete { get { throw null; } }
        public static Azure.AI.Projects.MessageStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Projects.MessageStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.MessageStatus left, Azure.AI.Projects.MessageStatus right) { throw null; }
        public static implicit operator Azure.AI.Projects.MessageStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.MessageStatus left, Azure.AI.Projects.MessageStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MessageStatusUpdate : Azure.AI.Projects.StreamingUpdate<Azure.AI.Projects.ThreadMessage>
    {
        internal MessageStatusUpdate() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MessageStreamEvent : System.IEquatable<Azure.AI.Projects.MessageStreamEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MessageStreamEvent(string value) { throw null; }
        public static Azure.AI.Projects.MessageStreamEvent ThreadMessageCompleted { get { throw null; } }
        public static Azure.AI.Projects.MessageStreamEvent ThreadMessageCreated { get { throw null; } }
        public static Azure.AI.Projects.MessageStreamEvent ThreadMessageDelta { get { throw null; } }
        public static Azure.AI.Projects.MessageStreamEvent ThreadMessageIncomplete { get { throw null; } }
        public static Azure.AI.Projects.MessageStreamEvent ThreadMessageInProgress { get { throw null; } }
        public bool Equals(Azure.AI.Projects.MessageStreamEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.MessageStreamEvent left, Azure.AI.Projects.MessageStreamEvent right) { throw null; }
        public static implicit operator Azure.AI.Projects.MessageStreamEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.MessageStreamEvent left, Azure.AI.Projects.MessageStreamEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class MessageTextAnnotation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageTextAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageTextAnnotation>
    {
        protected MessageTextAnnotation(string text) { }
        public string Text { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageTextAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageTextAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageTextAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageTextAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageTextAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageTextAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageTextAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTextContent : Azure.AI.Projects.MessageContent, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageTextContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageTextContent>
    {
        internal MessageTextContent() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.MessageTextAnnotation> Annotations { get { throw null; } }
        public string Text { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageTextContent System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageTextContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageTextContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageTextContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageTextContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageTextContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageTextContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTextFileCitationAnnotation : Azure.AI.Projects.MessageTextAnnotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageTextFileCitationAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageTextFileCitationAnnotation>
    {
        internal MessageTextFileCitationAnnotation() : base (default(string)) { }
        public int? EndIndex { get { throw null; } }
        public string FileId { get { throw null; } }
        public string Quote { get { throw null; } }
        public int? StartIndex { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageTextFileCitationAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageTextFileCitationAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageTextFileCitationAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageTextFileCitationAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageTextFileCitationAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageTextFileCitationAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageTextFileCitationAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MessageTextFilePathAnnotation : Azure.AI.Projects.MessageTextAnnotation, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageTextFilePathAnnotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageTextFilePathAnnotation>
    {
        internal MessageTextFilePathAnnotation() : base (default(string)) { }
        public int? EndIndex { get { throw null; } }
        public string FileId { get { throw null; } }
        public int? StartIndex { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageTextFilePathAnnotation System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageTextFilePathAnnotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MessageTextFilePathAnnotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MessageTextFilePathAnnotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageTextFilePathAnnotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageTextFilePathAnnotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MessageTextFilePathAnnotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MicrosoftFabricToolDefinition : Azure.AI.Projects.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MicrosoftFabricToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MicrosoftFabricToolDefinition>
    {
        public MicrosoftFabricToolDefinition(Azure.AI.Projects.ToolConnectionList fabricAiskill) { }
        public Azure.AI.Projects.ToolConnectionList FabricAiskill { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MicrosoftFabricToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MicrosoftFabricToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.MicrosoftFabricToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.MicrosoftFabricToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MicrosoftFabricToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MicrosoftFabricToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.MicrosoftFabricToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiAnonymousAuthDetails : Azure.AI.Projects.OpenApiAuthDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenApiAnonymousAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiAnonymousAuthDetails>
    {
        public OpenApiAnonymousAuthDetails() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenApiAnonymousAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenApiAnonymousAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenApiAnonymousAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenApiAnonymousAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiAnonymousAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiAnonymousAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiAnonymousAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class OpenApiAuthDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenApiAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiAuthDetails>
    {
        protected OpenApiAuthDetails() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenApiAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenApiAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenApiAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenApiAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiConnectionAuthDetails : Azure.AI.Projects.OpenApiAuthDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenApiConnectionAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiConnectionAuthDetails>
    {
        public OpenApiConnectionAuthDetails(Azure.AI.Projects.OpenApiConnectionSecurityScheme securityScheme) { }
        public Azure.AI.Projects.OpenApiConnectionSecurityScheme SecurityScheme { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenApiConnectionAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenApiConnectionAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenApiConnectionAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenApiConnectionAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiConnectionAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiConnectionAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiConnectionAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiConnectionSecurityScheme : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenApiConnectionSecurityScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiConnectionSecurityScheme>
    {
        public OpenApiConnectionSecurityScheme(string connectionId) { }
        public string ConnectionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenApiConnectionSecurityScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenApiConnectionSecurityScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenApiConnectionSecurityScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenApiConnectionSecurityScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiConnectionSecurityScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiConnectionSecurityScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiConnectionSecurityScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiFunctionDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenApiFunctionDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiFunctionDefinition>
    {
        public OpenApiFunctionDefinition(string name, System.BinaryData spec, Azure.AI.Projects.OpenApiAuthDetails auth) { }
        public Azure.AI.Projects.OpenApiAuthDetails Auth { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Spec { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenApiFunctionDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenApiFunctionDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenApiFunctionDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenApiFunctionDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiFunctionDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiFunctionDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiFunctionDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiManagedAuthDetails : Azure.AI.Projects.OpenApiAuthDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenApiManagedAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiManagedAuthDetails>
    {
        public OpenApiManagedAuthDetails(Azure.AI.Projects.OpenApiManagedSecurityScheme securityScheme) { }
        public Azure.AI.Projects.OpenApiManagedSecurityScheme SecurityScheme { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenApiManagedAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenApiManagedAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenApiManagedAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenApiManagedAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiManagedAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiManagedAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiManagedAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiManagedSecurityScheme : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenApiManagedSecurityScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiManagedSecurityScheme>
    {
        public OpenApiManagedSecurityScheme(string audience) { }
        public string Audience { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenApiManagedSecurityScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenApiManagedSecurityScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenApiManagedSecurityScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenApiManagedSecurityScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiManagedSecurityScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiManagedSecurityScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiManagedSecurityScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiToolDefinition : Azure.AI.Projects.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenApiToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiToolDefinition>
    {
        public OpenApiToolDefinition(Azure.AI.Projects.OpenApiFunctionDefinition openapi) { }
        public OpenApiToolDefinition(string name, string description, System.BinaryData spec, Azure.AI.Projects.OpenApiAuthDetails auth) { }
        public Azure.AI.Projects.OpenApiFunctionDefinition Openapi { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenApiToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenApiToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenApiToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenApiToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenApiToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class RecurrenceSchedule : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RecurrenceSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RecurrenceSchedule>
    {
        public RecurrenceSchedule(System.Collections.Generic.IEnumerable<int> hours, System.Collections.Generic.IEnumerable<int> minutes) { }
        public System.Collections.Generic.IList<int> Hours { get { throw null; } }
        public System.Collections.Generic.IList<int> Minutes { get { throw null; } }
        public System.Collections.Generic.IList<int> MonthDays { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Projects.WeekDays> WeekDays { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RecurrenceSchedule System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RecurrenceSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RecurrenceSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RecurrenceSchedule System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RecurrenceSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RecurrenceSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RecurrenceSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecurrenceTrigger : Azure.AI.Projects.Trigger, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RecurrenceTrigger>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RecurrenceTrigger>
    {
        public RecurrenceTrigger(Azure.AI.Projects.Frequency frequency, int interval) { }
        public Azure.AI.Projects.Frequency Frequency { get { throw null; } set { } }
        public int Interval { get { throw null; } set { } }
        public Azure.AI.Projects.RecurrenceSchedule Schedule { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RecurrenceTrigger System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RecurrenceTrigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RecurrenceTrigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RecurrenceTrigger System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RecurrenceTrigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RecurrenceTrigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RecurrenceTrigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RequiredAction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RequiredAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RequiredAction>
    {
        protected RequiredAction() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RequiredAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RequiredAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RequiredAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RequiredAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RequiredAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RequiredAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RequiredAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RequiredActionUpdate : Azure.AI.Projects.RunUpdate
    {
        internal RequiredActionUpdate() { }
        public string FunctionArguments { get { throw null; } }
        public string FunctionName { get { throw null; } }
        public string ToolCallId { get { throw null; } }
        public Azure.AI.Projects.ThreadRun GetThreadRun() { throw null; }
    }
    public partial class RequiredFunctionToolCall : Azure.AI.Projects.RequiredToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RequiredFunctionToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RequiredFunctionToolCall>
    {
        internal RequiredFunctionToolCall() : base (default(string)) { }
        public string Arguments { get { throw null; } }
        public string Name { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RequiredFunctionToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RequiredFunctionToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RequiredFunctionToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RequiredFunctionToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RequiredFunctionToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RequiredFunctionToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RequiredFunctionToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RequiredToolCall : Azure.AI.Projects.RequiredAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RequiredToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RequiredToolCall>
    {
        protected RequiredToolCall(string id) { }
        public string Id { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RequiredToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RequiredToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RequiredToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RequiredToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RequiredToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RequiredToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RequiredToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResponseFormat : System.IEquatable<Azure.AI.Projects.ResponseFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResponseFormat(string value) { throw null; }
        public static Azure.AI.Projects.ResponseFormat JsonObject { get { throw null; } }
        public static Azure.AI.Projects.ResponseFormat Text { get { throw null; } }
        public bool Equals(Azure.AI.Projects.ResponseFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.ResponseFormat left, Azure.AI.Projects.ResponseFormat right) { throw null; }
        public static implicit operator Azure.AI.Projects.ResponseFormat (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.ResponseFormat left, Azure.AI.Projects.ResponseFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResponseFormatJsonSchema : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ResponseFormatJsonSchema>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseFormatJsonSchema>
    {
        public ResponseFormatJsonSchema(string name, System.BinaryData schema) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Schema { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ResponseFormatJsonSchema System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ResponseFormatJsonSchema>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ResponseFormatJsonSchema>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ResponseFormatJsonSchema System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseFormatJsonSchema>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseFormatJsonSchema>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseFormatJsonSchema>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResponseFormatJsonSchemaType : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ResponseFormatJsonSchemaType>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseFormatJsonSchemaType>
    {
        public ResponseFormatJsonSchemaType(Azure.AI.Projects.ResponseFormatJsonSchema jsonSchema) { }
        public Azure.AI.Projects.ResponseFormatJsonSchema JsonSchema { get { throw null; } set { } }
        public Azure.AI.Projects.ResponseFormatJsonSchemaTypeType Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ResponseFormatJsonSchemaType System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ResponseFormatJsonSchemaType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ResponseFormatJsonSchemaType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ResponseFormatJsonSchemaType System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseFormatJsonSchemaType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseFormatJsonSchemaType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ResponseFormatJsonSchemaType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResponseFormatJsonSchemaTypeType : System.IEquatable<Azure.AI.Projects.ResponseFormatJsonSchemaTypeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResponseFormatJsonSchemaTypeType(string value) { throw null; }
        public static Azure.AI.Projects.ResponseFormatJsonSchemaTypeType JsonSchema { get { throw null; } }
        public bool Equals(Azure.AI.Projects.ResponseFormatJsonSchemaTypeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.ResponseFormatJsonSchemaTypeType left, Azure.AI.Projects.ResponseFormatJsonSchemaTypeType right) { throw null; }
        public static implicit operator Azure.AI.Projects.ResponseFormatJsonSchemaTypeType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.ResponseFormatJsonSchemaTypeType left, Azure.AI.Projects.ResponseFormatJsonSchemaTypeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunAdditionalFieldList : System.IEquatable<Azure.AI.Projects.RunAdditionalFieldList>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunAdditionalFieldList(string value) { throw null; }
        public static Azure.AI.Projects.RunAdditionalFieldList FileSearchContents { get { throw null; } }
        public bool Equals(Azure.AI.Projects.RunAdditionalFieldList other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.RunAdditionalFieldList left, Azure.AI.Projects.RunAdditionalFieldList right) { throw null; }
        public static implicit operator Azure.AI.Projects.RunAdditionalFieldList (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.RunAdditionalFieldList left, Azure.AI.Projects.RunAdditionalFieldList right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunCompletionUsage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunCompletionUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunCompletionUsage>
    {
        internal RunCompletionUsage() { }
        public long CompletionTokens { get { throw null; } }
        public long PromptTokens { get { throw null; } }
        public long TotalTokens { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunCompletionUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunCompletionUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunCompletionUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunCompletionUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunCompletionUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunCompletionUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunCompletionUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunError>
    {
        internal RunError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunError System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStatus : System.IEquatable<Azure.AI.Projects.RunStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStatus(string value) { throw null; }
        public static Azure.AI.Projects.RunStatus Cancelled { get { throw null; } }
        public static Azure.AI.Projects.RunStatus Cancelling { get { throw null; } }
        public static Azure.AI.Projects.RunStatus Completed { get { throw null; } }
        public static Azure.AI.Projects.RunStatus Expired { get { throw null; } }
        public static Azure.AI.Projects.RunStatus Failed { get { throw null; } }
        public static Azure.AI.Projects.RunStatus InProgress { get { throw null; } }
        public static Azure.AI.Projects.RunStatus Queued { get { throw null; } }
        public static Azure.AI.Projects.RunStatus RequiresAction { get { throw null; } }
        public bool Equals(Azure.AI.Projects.RunStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.RunStatus left, Azure.AI.Projects.RunStatus right) { throw null; }
        public static implicit operator Azure.AI.Projects.RunStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.RunStatus left, Azure.AI.Projects.RunStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunStep : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStep>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStep>
    {
        internal RunStep() { }
        public string AssistantId { get { throw null; } }
        public System.DateTimeOffset? CancelledAt { get { throw null; } }
        public System.DateTimeOffset? CompletedAt { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public System.DateTimeOffset? ExpiredAt { get { throw null; } }
        public System.DateTimeOffset? FailedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Projects.RunStepError LastError { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string RunId { get { throw null; } }
        public Azure.AI.Projects.RunStepStatus Status { get { throw null; } }
        public Azure.AI.Projects.RunStepDetails StepDetails { get { throw null; } }
        public string ThreadId { get { throw null; } }
        public Azure.AI.Projects.RunStepType Type { get { throw null; } }
        public Azure.AI.Projects.RunStepCompletionUsage Usage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStep System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStep>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStep>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStep System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStep>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStep>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStep>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepAzureAISearchToolCall : Azure.AI.Projects.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepAzureAISearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepAzureAISearchToolCall>
    {
        internal RunStepAzureAISearchToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> AzureAISearch { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepAzureAISearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepAzureAISearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepAzureAISearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepAzureAISearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepAzureAISearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepAzureAISearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepAzureAISearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepBingGroundingToolCall : Azure.AI.Projects.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepBingGroundingToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepBingGroundingToolCall>
    {
        internal RunStepBingGroundingToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> BingGrounding { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepBingGroundingToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepBingGroundingToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepBingGroundingToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepBingGroundingToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepBingGroundingToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepBingGroundingToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepBingGroundingToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCodeInterpreterImageOutput : Azure.AI.Projects.RunStepCodeInterpreterToolCallOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepCodeInterpreterImageOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepCodeInterpreterImageOutput>
    {
        internal RunStepCodeInterpreterImageOutput() { }
        public Azure.AI.Projects.RunStepCodeInterpreterImageReference Image { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepCodeInterpreterImageOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepCodeInterpreterImageOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepCodeInterpreterImageOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepCodeInterpreterImageOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepCodeInterpreterImageOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepCodeInterpreterImageOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepCodeInterpreterImageOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCodeInterpreterImageReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepCodeInterpreterImageReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepCodeInterpreterImageReference>
    {
        internal RunStepCodeInterpreterImageReference() { }
        public string FileId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepCodeInterpreterImageReference System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepCodeInterpreterImageReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepCodeInterpreterImageReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepCodeInterpreterImageReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepCodeInterpreterImageReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepCodeInterpreterImageReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepCodeInterpreterImageReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCodeInterpreterLogOutput : Azure.AI.Projects.RunStepCodeInterpreterToolCallOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepCodeInterpreterLogOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepCodeInterpreterLogOutput>
    {
        internal RunStepCodeInterpreterLogOutput() { }
        public string Logs { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepCodeInterpreterLogOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepCodeInterpreterLogOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepCodeInterpreterLogOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepCodeInterpreterLogOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepCodeInterpreterLogOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepCodeInterpreterLogOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepCodeInterpreterLogOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCodeInterpreterToolCall : Azure.AI.Projects.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepCodeInterpreterToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepCodeInterpreterToolCall>
    {
        internal RunStepCodeInterpreterToolCall() : base (default(string)) { }
        public string Input { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.RunStepCodeInterpreterToolCallOutput> Outputs { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepCodeInterpreterToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepCodeInterpreterToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepCodeInterpreterToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepCodeInterpreterToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepCodeInterpreterToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepCodeInterpreterToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepCodeInterpreterToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepCodeInterpreterToolCallOutput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepCodeInterpreterToolCallOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepCodeInterpreterToolCallOutput>
    {
        protected RunStepCodeInterpreterToolCallOutput() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepCodeInterpreterToolCallOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepCodeInterpreterToolCallOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepCodeInterpreterToolCallOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepCodeInterpreterToolCallOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepCodeInterpreterToolCallOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepCodeInterpreterToolCallOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepCodeInterpreterToolCallOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepCompletionUsage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepCompletionUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepCompletionUsage>
    {
        internal RunStepCompletionUsage() { }
        public long CompletionTokens { get { throw null; } }
        public long PromptTokens { get { throw null; } }
        public long TotalTokens { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepCompletionUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepCompletionUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepCompletionUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepCompletionUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepCompletionUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepCompletionUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepCompletionUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDelta : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDelta>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDelta>
    {
        internal RunStepDelta() { }
        public Azure.AI.Projects.RunStepDeltaDetail StepDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDelta System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDelta>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDelta>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDelta System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDelta>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDelta>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDelta>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaChunk : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaChunk>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaChunk>
    {
        internal RunStepDeltaChunk() { }
        public Azure.AI.Projects.RunStepDelta Delta { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Projects.RunStepDeltaChunkObject Object { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDeltaChunk System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaChunk>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaChunk>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDeltaChunk System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaChunk>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaChunk>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaChunk>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepDeltaChunkObject : System.IEquatable<Azure.AI.Projects.RunStepDeltaChunkObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepDeltaChunkObject(string value) { throw null; }
        public static Azure.AI.Projects.RunStepDeltaChunkObject ThreadRunStepDelta { get { throw null; } }
        public bool Equals(Azure.AI.Projects.RunStepDeltaChunkObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.RunStepDeltaChunkObject left, Azure.AI.Projects.RunStepDeltaChunkObject right) { throw null; }
        public static implicit operator Azure.AI.Projects.RunStepDeltaChunkObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.RunStepDeltaChunkObject left, Azure.AI.Projects.RunStepDeltaChunkObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunStepDeltaCodeInterpreterDetailItemObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterDetailItemObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterDetailItemObject>
    {
        internal RunStepDeltaCodeInterpreterDetailItemObject() { }
        public string Input { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.RunStepDeltaCodeInterpreterOutput> Outputs { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDeltaCodeInterpreterDetailItemObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterDetailItemObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterDetailItemObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDeltaCodeInterpreterDetailItemObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterDetailItemObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterDetailItemObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterDetailItemObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaCodeInterpreterImageOutput : Azure.AI.Projects.RunStepDeltaCodeInterpreterOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterImageOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterImageOutput>
    {
        internal RunStepDeltaCodeInterpreterImageOutput() : base (default(int)) { }
        public Azure.AI.Projects.RunStepDeltaCodeInterpreterImageOutputObject Image { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDeltaCodeInterpreterImageOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterImageOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterImageOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDeltaCodeInterpreterImageOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterImageOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterImageOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterImageOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaCodeInterpreterImageOutputObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterImageOutputObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterImageOutputObject>
    {
        internal RunStepDeltaCodeInterpreterImageOutputObject() { }
        public string FileId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDeltaCodeInterpreterImageOutputObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterImageOutputObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterImageOutputObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDeltaCodeInterpreterImageOutputObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterImageOutputObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterImageOutputObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterImageOutputObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaCodeInterpreterLogOutput : Azure.AI.Projects.RunStepDeltaCodeInterpreterOutput, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterLogOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterLogOutput>
    {
        internal RunStepDeltaCodeInterpreterLogOutput() : base (default(int)) { }
        public string Logs { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDeltaCodeInterpreterLogOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterLogOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterLogOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDeltaCodeInterpreterLogOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterLogOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterLogOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterLogOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepDeltaCodeInterpreterOutput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterOutput>
    {
        protected RunStepDeltaCodeInterpreterOutput(int index) { }
        public int Index { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDeltaCodeInterpreterOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDeltaCodeInterpreterOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaCodeInterpreterToolCall : Azure.AI.Projects.RunStepDeltaToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterToolCall>
    {
        internal RunStepDeltaCodeInterpreterToolCall() : base (default(int), default(string)) { }
        public Azure.AI.Projects.RunStepDeltaCodeInterpreterDetailItemObject CodeInterpreter { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDeltaCodeInterpreterToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDeltaCodeInterpreterToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaCodeInterpreterToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepDeltaDetail : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaDetail>
    {
        protected RunStepDeltaDetail() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDeltaDetail System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDeltaDetail System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaFileSearchToolCall : Azure.AI.Projects.RunStepDeltaToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaFileSearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaFileSearchToolCall>
    {
        internal RunStepDeltaFileSearchToolCall() : base (default(int), default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> FileSearch { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDeltaFileSearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaFileSearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaFileSearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDeltaFileSearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaFileSearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaFileSearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaFileSearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaFunction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaFunction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaFunction>
    {
        internal RunStepDeltaFunction() { }
        public string Arguments { get { throw null; } }
        public string Name { get { throw null; } }
        public string Output { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDeltaFunction System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaFunction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaFunction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDeltaFunction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaFunction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaFunction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaFunction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaFunctionToolCall : Azure.AI.Projects.RunStepDeltaToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaFunctionToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaFunctionToolCall>
    {
        internal RunStepDeltaFunctionToolCall() : base (default(int), default(string)) { }
        public Azure.AI.Projects.RunStepDeltaFunction Function { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDeltaFunctionToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaFunctionToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaFunctionToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDeltaFunctionToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaFunctionToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaFunctionToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaFunctionToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaMessageCreation : Azure.AI.Projects.RunStepDeltaDetail, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaMessageCreation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaMessageCreation>
    {
        internal RunStepDeltaMessageCreation() { }
        public Azure.AI.Projects.RunStepDeltaMessageCreationObject MessageCreation { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDeltaMessageCreation System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaMessageCreation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaMessageCreation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDeltaMessageCreation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaMessageCreation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaMessageCreation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaMessageCreation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaMessageCreationObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaMessageCreationObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaMessageCreationObject>
    {
        internal RunStepDeltaMessageCreationObject() { }
        public string MessageId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDeltaMessageCreationObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaMessageCreationObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaMessageCreationObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDeltaMessageCreationObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaMessageCreationObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaMessageCreationObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaMessageCreationObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepDeltaToolCall : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaToolCall>
    {
        protected internal System.Collections.Generic.IDictionary<string, System.BinaryData> SerializedAdditionalRawData;
        protected RunStepDeltaToolCall(int index, string id) { }
        public string Id { get { throw null; } }
        public int Index { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDeltaToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDeltaToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDeltaToolCallObject : Azure.AI.Projects.RunStepDeltaDetail, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaToolCallObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaToolCallObject>
    {
        internal RunStepDeltaToolCallObject() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.RunStepDeltaToolCall> ToolCalls { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDeltaToolCallObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaToolCallObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDeltaToolCallObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDeltaToolCallObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaToolCallObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaToolCallObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDeltaToolCallObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RunStepDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDetails>
    {
        protected RunStepDetails() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepDetailsUpdate : Azure.AI.Projects.StreamingUpdate
    {
        internal RunStepDetailsUpdate() { }
        public string CodeInterpreterInput { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.RunStepDeltaCodeInterpreterOutput> CodeInterpreterOutputs { get { throw null; } }
        public string CreatedMessageId { get { throw null; } }
        public string FunctionArguments { get { throw null; } }
        public string FunctionName { get { throw null; } }
        public string FunctionOutput { get { throw null; } }
        public string StepId { get { throw null; } }
        public string ToolCallId { get { throw null; } }
        public int? ToolCallIndex { get { throw null; } }
    }
    public partial class RunStepError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepError>
    {
        internal RunStepError() { }
        public Azure.AI.Projects.RunStepErrorCode Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepError System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepErrorCode : System.IEquatable<Azure.AI.Projects.RunStepErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepErrorCode(string value) { throw null; }
        public static Azure.AI.Projects.RunStepErrorCode RateLimitExceeded { get { throw null; } }
        public static Azure.AI.Projects.RunStepErrorCode ServerError { get { throw null; } }
        public bool Equals(Azure.AI.Projects.RunStepErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.RunStepErrorCode left, Azure.AI.Projects.RunStepErrorCode right) { throw null; }
        public static implicit operator Azure.AI.Projects.RunStepErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.RunStepErrorCode left, Azure.AI.Projects.RunStepErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunStepFileSearchToolCall : Azure.AI.Projects.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepFileSearchToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepFileSearchToolCall>
    {
        internal RunStepFileSearchToolCall() : base (default(string)) { }
        public Azure.AI.Projects.RunStepFileSearchToolCallResults FileSearch { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepFileSearchToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepFileSearchToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepFileSearchToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepFileSearchToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepFileSearchToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepFileSearchToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepFileSearchToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepFileSearchToolCallResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepFileSearchToolCallResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepFileSearchToolCallResult>
    {
        internal RunStepFileSearchToolCallResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.FileSearchToolCallContent> Content { get { throw null; } }
        public string FileId { get { throw null; } }
        public string FileName { get { throw null; } }
        public float Score { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepFileSearchToolCallResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepFileSearchToolCallResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepFileSearchToolCallResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepFileSearchToolCallResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepFileSearchToolCallResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepFileSearchToolCallResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepFileSearchToolCallResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepFileSearchToolCallResults : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepFileSearchToolCallResults>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepFileSearchToolCallResults>
    {
        internal RunStepFileSearchToolCallResults() { }
        public Azure.AI.Projects.FileSearchRankingOptions RankingOptions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.RunStepFileSearchToolCallResult> Results { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepFileSearchToolCallResults System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepFileSearchToolCallResults>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepFileSearchToolCallResults>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepFileSearchToolCallResults System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepFileSearchToolCallResults>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepFileSearchToolCallResults>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepFileSearchToolCallResults>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepFunctionToolCall : Azure.AI.Projects.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepFunctionToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepFunctionToolCall>
    {
        internal RunStepFunctionToolCall() : base (default(string)) { }
        public string Arguments { get { throw null; } }
        public string Name { get { throw null; } }
        public string Output { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepFunctionToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepFunctionToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepFunctionToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepFunctionToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepFunctionToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepFunctionToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepFunctionToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepMessageCreationDetails : Azure.AI.Projects.RunStepDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepMessageCreationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepMessageCreationDetails>
    {
        internal RunStepMessageCreationDetails() { }
        public Azure.AI.Projects.RunStepMessageCreationReference MessageCreation { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepMessageCreationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepMessageCreationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepMessageCreationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepMessageCreationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepMessageCreationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepMessageCreationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepMessageCreationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepMessageCreationReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepMessageCreationReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepMessageCreationReference>
    {
        internal RunStepMessageCreationReference() { }
        public string MessageId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepMessageCreationReference System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepMessageCreationReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepMessageCreationReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepMessageCreationReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepMessageCreationReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepMessageCreationReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepMessageCreationReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepMicrosoftFabricToolCall : Azure.AI.Projects.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepMicrosoftFabricToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepMicrosoftFabricToolCall>
    {
        internal RunStepMicrosoftFabricToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> MicrosoftFabric { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepMicrosoftFabricToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepMicrosoftFabricToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepMicrosoftFabricToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepMicrosoftFabricToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepMicrosoftFabricToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepMicrosoftFabricToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepMicrosoftFabricToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepSharepointToolCall : Azure.AI.Projects.RunStepToolCall, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepSharepointToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepSharepointToolCall>
    {
        internal RunStepSharepointToolCall() : base (default(string)) { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> SharePoint { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepSharepointToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepSharepointToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepSharepointToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepSharepointToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepSharepointToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepSharepointToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepSharepointToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepStatus : System.IEquatable<Azure.AI.Projects.RunStepStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepStatus(string value) { throw null; }
        public static Azure.AI.Projects.RunStepStatus Cancelled { get { throw null; } }
        public static Azure.AI.Projects.RunStepStatus Completed { get { throw null; } }
        public static Azure.AI.Projects.RunStepStatus Expired { get { throw null; } }
        public static Azure.AI.Projects.RunStepStatus Failed { get { throw null; } }
        public static Azure.AI.Projects.RunStepStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Projects.RunStepStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.RunStepStatus left, Azure.AI.Projects.RunStepStatus right) { throw null; }
        public static implicit operator Azure.AI.Projects.RunStepStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.RunStepStatus left, Azure.AI.Projects.RunStepStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepStreamEvent : System.IEquatable<Azure.AI.Projects.RunStepStreamEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepStreamEvent(string value) { throw null; }
        public static Azure.AI.Projects.RunStepStreamEvent ThreadRunStepCancelled { get { throw null; } }
        public static Azure.AI.Projects.RunStepStreamEvent ThreadRunStepCompleted { get { throw null; } }
        public static Azure.AI.Projects.RunStepStreamEvent ThreadRunStepCreated { get { throw null; } }
        public static Azure.AI.Projects.RunStepStreamEvent ThreadRunStepDelta { get { throw null; } }
        public static Azure.AI.Projects.RunStepStreamEvent ThreadRunStepExpired { get { throw null; } }
        public static Azure.AI.Projects.RunStepStreamEvent ThreadRunStepFailed { get { throw null; } }
        public static Azure.AI.Projects.RunStepStreamEvent ThreadRunStepInProgress { get { throw null; } }
        public bool Equals(Azure.AI.Projects.RunStepStreamEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.RunStepStreamEvent left, Azure.AI.Projects.RunStepStreamEvent right) { throw null; }
        public static implicit operator Azure.AI.Projects.RunStepStreamEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.RunStepStreamEvent left, Azure.AI.Projects.RunStepStreamEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class RunStepToolCall : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepToolCall>
    {
        protected RunStepToolCall(string id) { }
        public string Id { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RunStepToolCallDetails : Azure.AI.Projects.RunStepDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepToolCallDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepToolCallDetails>
    {
        internal RunStepToolCallDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.RunStepToolCall> ToolCalls { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepToolCallDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepToolCallDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.RunStepToolCallDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.RunStepToolCallDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepToolCallDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepToolCallDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.RunStepToolCallDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStepType : System.IEquatable<Azure.AI.Projects.RunStepType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStepType(string value) { throw null; }
        public static Azure.AI.Projects.RunStepType MessageCreation { get { throw null; } }
        public static Azure.AI.Projects.RunStepType ToolCalls { get { throw null; } }
        public bool Equals(Azure.AI.Projects.RunStepType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.RunStepType left, Azure.AI.Projects.RunStepType right) { throw null; }
        public static implicit operator Azure.AI.Projects.RunStepType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.RunStepType left, Azure.AI.Projects.RunStepType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunStepUpdate : Azure.AI.Projects.StreamingUpdate<Azure.AI.Projects.RunStep>
    {
        internal RunStepUpdate() { }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RunStreamEvent : System.IEquatable<Azure.AI.Projects.RunStreamEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RunStreamEvent(string value) { throw null; }
        public static Azure.AI.Projects.RunStreamEvent ThreadRunCancelled { get { throw null; } }
        public static Azure.AI.Projects.RunStreamEvent ThreadRunCancelling { get { throw null; } }
        public static Azure.AI.Projects.RunStreamEvent ThreadRunCompleted { get { throw null; } }
        public static Azure.AI.Projects.RunStreamEvent ThreadRunCreated { get { throw null; } }
        public static Azure.AI.Projects.RunStreamEvent ThreadRunExpired { get { throw null; } }
        public static Azure.AI.Projects.RunStreamEvent ThreadRunFailed { get { throw null; } }
        public static Azure.AI.Projects.RunStreamEvent ThreadRunIncomplete { get { throw null; } }
        public static Azure.AI.Projects.RunStreamEvent ThreadRunInProgress { get { throw null; } }
        public static Azure.AI.Projects.RunStreamEvent ThreadRunQueued { get { throw null; } }
        public static Azure.AI.Projects.RunStreamEvent ThreadRunRequiresAction { get { throw null; } }
        public bool Equals(Azure.AI.Projects.RunStreamEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.RunStreamEvent left, Azure.AI.Projects.RunStreamEvent right) { throw null; }
        public static implicit operator Azure.AI.Projects.RunStreamEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.RunStreamEvent left, Azure.AI.Projects.RunStreamEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RunUpdate : Azure.AI.Projects.StreamingUpdate<Azure.AI.Projects.ThreadRun>
    {
        internal RunUpdate() { }
    }
    public partial class SharepointToolDefinition : Azure.AI.Projects.ToolDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SharepointToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SharepointToolDefinition>
    {
        public SharepointToolDefinition(Azure.AI.Projects.ToolConnectionList sharepointGrounding) { }
        public Azure.AI.Projects.ToolConnectionList SharepointGrounding { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.SharepointToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SharepointToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SharepointToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.SharepointToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SharepointToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SharepointToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SharepointToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class StreamingUpdate
    {
        internal StreamingUpdate() { }
        public Azure.AI.Projects.StreamingUpdateReason UpdateKind { get { throw null; } }
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
    public partial class StreamingUpdate<T> : Azure.AI.Projects.StreamingUpdate where T : class
    {
        internal StreamingUpdate() { }
        public T Value { get { throw null; } }
        public static implicit operator T (Azure.AI.Projects.StreamingUpdate<T> update) { throw null; }
    }
    public partial class SubmitToolOutputsAction : Azure.AI.Projects.RequiredAction, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SubmitToolOutputsAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SubmitToolOutputsAction>
    {
        internal SubmitToolOutputsAction() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.RequiredToolCall> ToolCalls { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.SubmitToolOutputsAction System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SubmitToolOutputsAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SubmitToolOutputsAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.SubmitToolOutputsAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SubmitToolOutputsAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SubmitToolOutputsAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SubmitToolOutputsAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SystemData : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SystemData>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SystemData>
    {
        internal SystemData() { }
        public System.DateTimeOffset? CreatedAt { get { throw null; } }
        public string CreatedBy { get { throw null; } }
        public string CreatedByType { get { throw null; } }
        public System.DateTimeOffset? LastModifiedAt { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.SystemData System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SystemData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.SystemData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.SystemData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SystemData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SystemData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.SystemData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TelemetryClient
    {
        protected TelemetryClient() { }
        public TelemetryClient(string connectionString, Azure.Core.TokenCredential credential) { }
        public TelemetryClient(string connectionString, Azure.Core.TokenCredential credential, Azure.AI.Projects.AIProjectClientOptions options) { }
        public TelemetryClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential) { }
        public TelemetryClient(System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName, Azure.Core.TokenCredential credential, Azure.AI.Projects.AIProjectClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
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
    public partial class ThreadMessage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ThreadMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ThreadMessage>
    {
        internal ThreadMessage() { }
        public string AssistantId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.MessageAttachment> Attachments { get { throw null; } }
        public System.DateTimeOffset? CompletedAt { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.MessageContent> ContentItems { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? IncompleteAt { get { throw null; } }
        public Azure.AI.Projects.MessageIncompleteDetails IncompleteDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public Azure.AI.Projects.MessageRole Role { get { throw null; } }
        public string RunId { get { throw null; } }
        public Azure.AI.Projects.MessageStatus Status { get { throw null; } }
        public string ThreadId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ThreadMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ThreadMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ThreadMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ThreadMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ThreadMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ThreadMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ThreadMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreadMessageOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ThreadMessageOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ThreadMessageOptions>
    {
        public ThreadMessageOptions(Azure.AI.Projects.MessageRole role, string content) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.MessageAttachment> Attachments { get { throw null; } set { } }
        public string Content { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } set { } }
        public Azure.AI.Projects.MessageRole Role { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ThreadMessageOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ThreadMessageOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ThreadMessageOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ThreadMessageOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ThreadMessageOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ThreadMessageOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ThreadMessageOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ThreadRun : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ThreadRun>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ThreadRun>
    {
        internal ThreadRun() { }
        public string AssistantId { get { throw null; } }
        public System.DateTimeOffset? CancelledAt { get { throw null; } }
        public System.DateTimeOffset? CompletedAt { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public System.DateTimeOffset? ExpiresAt { get { throw null; } }
        public System.DateTimeOffset? FailedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Projects.IncompleteRunDetails IncompleteDetails { get { throw null; } }
        public string Instructions { get { throw null; } }
        public Azure.AI.Projects.RunError LastError { get { throw null; } }
        public int? MaxCompletionTokens { get { throw null; } }
        public int? MaxPromptTokens { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string Model { get { throw null; } }
        public bool ParallelToolCalls { get { throw null; } }
        public Azure.AI.Projects.RequiredAction RequiredAction { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.RequiredFunctionToolCall> RequiredActions { get { throw null; } }
        public System.BinaryData ResponseFormat { get { throw null; } }
        public System.DateTimeOffset? StartedAt { get { throw null; } }
        public Azure.AI.Projects.RunStatus Status { get { throw null; } }
        public float? Temperature { get { throw null; } }
        public string ThreadId { get { throw null; } }
        public System.BinaryData ToolChoice { get { throw null; } }
        public Azure.AI.Projects.UpdateToolResourcesOptions ToolResources { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.ToolDefinition> Tools { get { throw null; } }
        public float? TopP { get { throw null; } }
        public Azure.AI.Projects.TruncationObject TruncationStrategy { get { throw null; } }
        public Azure.AI.Projects.RunCompletionUsage Usage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ThreadRun System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ThreadRun>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ThreadRun>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ThreadRun System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ThreadRun>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ThreadRun>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ThreadRun>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ThreadStreamEvent : System.IEquatable<Azure.AI.Projects.ThreadStreamEvent>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ThreadStreamEvent(string value) { throw null; }
        public static Azure.AI.Projects.ThreadStreamEvent ThreadCreated { get { throw null; } }
        public bool Equals(Azure.AI.Projects.ThreadStreamEvent other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.ThreadStreamEvent left, Azure.AI.Projects.ThreadStreamEvent right) { throw null; }
        public static implicit operator Azure.AI.Projects.ThreadStreamEvent (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.ThreadStreamEvent left, Azure.AI.Projects.ThreadStreamEvent right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ThreadUpdate : Azure.AI.Projects.StreamingUpdate<Azure.AI.Projects.AgentThread>
    {
        internal ThreadUpdate() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public Azure.AI.Projects.ToolResources ToolResources { get { throw null; } }
    }
    public partial class ToolConnection : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ToolConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolConnection>
    {
        public ToolConnection(string connectionId) { }
        public string ConnectionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ToolConnection System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ToolConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ToolConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ToolConnection System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolConnectionList : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ToolConnectionList>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolConnectionList>
    {
        public ToolConnectionList() { }
        public System.Collections.Generic.IList<Azure.AI.Projects.ToolConnection> ConnectionList { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ToolConnectionList System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ToolConnectionList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ToolConnectionList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ToolConnectionList System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolConnectionList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolConnectionList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolConnectionList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ToolDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ToolDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolDefinition>
    {
        protected ToolDefinition() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ToolDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ToolDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ToolDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ToolDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolOutput : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ToolOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolOutput>
    {
        public ToolOutput() { }
        public ToolOutput(Azure.AI.Projects.RequiredToolCall toolCall) { }
        public ToolOutput(Azure.AI.Projects.RequiredToolCall toolCall, string output) { }
        public ToolOutput(string toolCallId) { }
        public ToolOutput(string toolCallId, string output) { }
        public string Output { get { throw null; } set { } }
        public string ToolCallId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ToolOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ToolOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ToolOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ToolOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolResources : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ToolResources>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolResources>
    {
        public ToolResources() { }
        public Azure.AI.Projects.AzureAISearchResource AzureAISearch { get { throw null; } set { } }
        public Azure.AI.Projects.CodeInterpreterToolResource CodeInterpreter { get { throw null; } set { } }
        public Azure.AI.Projects.FileSearchToolResource FileSearch { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ToolResources System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ToolResources>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.ToolResources>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.ToolResources System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolResources>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolResources>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.ToolResources>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class Trigger : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Trigger>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Trigger>
    {
        protected Trigger() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Trigger System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Trigger>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.Trigger>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.Trigger System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Trigger>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Trigger>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.Trigger>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TruncationObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TruncationObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TruncationObject>
    {
        public TruncationObject(Azure.AI.Projects.TruncationStrategy type) { }
        public int? LastMessages { get { throw null; } set { } }
        public Azure.AI.Projects.TruncationStrategy Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.TruncationObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TruncationObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.TruncationObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.TruncationObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TruncationObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TruncationObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.TruncationObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TruncationStrategy : System.IEquatable<Azure.AI.Projects.TruncationStrategy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TruncationStrategy(string value) { throw null; }
        public static Azure.AI.Projects.TruncationStrategy Auto { get { throw null; } }
        public static Azure.AI.Projects.TruncationStrategy LastMessages { get { throw null; } }
        public bool Equals(Azure.AI.Projects.TruncationStrategy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.TruncationStrategy left, Azure.AI.Projects.TruncationStrategy right) { throw null; }
        public static implicit operator Azure.AI.Projects.TruncationStrategy (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.TruncationStrategy left, Azure.AI.Projects.TruncationStrategy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpdateCodeInterpreterToolResourceOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UpdateCodeInterpreterToolResourceOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UpdateCodeInterpreterToolResourceOptions>
    {
        public UpdateCodeInterpreterToolResourceOptions() { }
        public System.Collections.Generic.IList<string> FileIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.UpdateCodeInterpreterToolResourceOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UpdateCodeInterpreterToolResourceOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UpdateCodeInterpreterToolResourceOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.UpdateCodeInterpreterToolResourceOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UpdateCodeInterpreterToolResourceOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UpdateCodeInterpreterToolResourceOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UpdateCodeInterpreterToolResourceOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateFileSearchToolResourceOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UpdateFileSearchToolResourceOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UpdateFileSearchToolResourceOptions>
    {
        public UpdateFileSearchToolResourceOptions() { }
        public System.Collections.Generic.IList<string> VectorStoreIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.UpdateFileSearchToolResourceOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UpdateFileSearchToolResourceOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UpdateFileSearchToolResourceOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.UpdateFileSearchToolResourceOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UpdateFileSearchToolResourceOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UpdateFileSearchToolResourceOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UpdateFileSearchToolResourceOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateToolResourcesOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UpdateToolResourcesOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UpdateToolResourcesOptions>
    {
        public UpdateToolResourcesOptions() { }
        public Azure.AI.Projects.AzureAISearchResource AzureAISearch { get { throw null; } set { } }
        public Azure.AI.Projects.UpdateCodeInterpreterToolResourceOptions CodeInterpreter { get { throw null; } set { } }
        public Azure.AI.Projects.UpdateFileSearchToolResourceOptions FileSearch { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.UpdateToolResourcesOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UpdateToolResourcesOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.UpdateToolResourcesOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.UpdateToolResourcesOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UpdateToolResourcesOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UpdateToolResourcesOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.UpdateToolResourcesOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStore : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStore>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStore>
    {
        internal VectorStore() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public Azure.AI.Projects.VectorStoreExpirationPolicy ExpiresAfter { get { throw null; } }
        public System.DateTimeOffset? ExpiresAt { get { throw null; } }
        public Azure.AI.Projects.VectorStoreFileCount FileCounts { get { throw null; } }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? LastActiveAt { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Projects.VectorStoreObject Object { get { throw null; } }
        public Azure.AI.Projects.VectorStoreStatus Status { get { throw null; } }
        public int UsageBytes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStore System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStore>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStore>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStore System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStore>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStore>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStore>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreAutoChunkingStrategyRequest : Azure.AI.Projects.VectorStoreChunkingStrategyRequest, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreAutoChunkingStrategyRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreAutoChunkingStrategyRequest>
    {
        public VectorStoreAutoChunkingStrategyRequest() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreAutoChunkingStrategyRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreAutoChunkingStrategyRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreAutoChunkingStrategyRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreAutoChunkingStrategyRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreAutoChunkingStrategyRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreAutoChunkingStrategyRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreAutoChunkingStrategyRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreAutoChunkingStrategyResponse : Azure.AI.Projects.VectorStoreChunkingStrategyResponse, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreAutoChunkingStrategyResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreAutoChunkingStrategyResponse>
    {
        internal VectorStoreAutoChunkingStrategyResponse() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreAutoChunkingStrategyResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreAutoChunkingStrategyResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreAutoChunkingStrategyResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreAutoChunkingStrategyResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreAutoChunkingStrategyResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreAutoChunkingStrategyResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreAutoChunkingStrategyResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class VectorStoreChunkingStrategyRequest : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreChunkingStrategyRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreChunkingStrategyRequest>
    {
        protected VectorStoreChunkingStrategyRequest() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreChunkingStrategyRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreChunkingStrategyRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreChunkingStrategyRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreChunkingStrategyRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreChunkingStrategyRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreChunkingStrategyRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreChunkingStrategyRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class VectorStoreChunkingStrategyResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreChunkingStrategyResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreChunkingStrategyResponse>
    {
        protected VectorStoreChunkingStrategyResponse() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreChunkingStrategyResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreChunkingStrategyResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreChunkingStrategyResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreChunkingStrategyResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreChunkingStrategyResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreChunkingStrategyResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreChunkingStrategyResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreConfiguration>
    {
        public VectorStoreConfiguration(System.Collections.Generic.IEnumerable<Azure.AI.Projects.VectorStoreDataSource> dataSources) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.VectorStoreDataSource> DataSources { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreConfigurations : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreConfigurations>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreConfigurations>
    {
        public VectorStoreConfigurations(string storeName, Azure.AI.Projects.VectorStoreConfiguration storeConfiguration) { }
        public Azure.AI.Projects.VectorStoreConfiguration StoreConfiguration { get { throw null; } set { } }
        public string StoreName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreConfigurations System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreConfigurations>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreConfigurations>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreConfigurations System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreConfigurations>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreConfigurations>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreConfigurations>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreDataSource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreDataSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreDataSource>
    {
        public VectorStoreDataSource(string assetIdentifier, Azure.AI.Projects.VectorStoreDataSourceAssetType assetType) { }
        public string AssetIdentifier { get { throw null; } set { } }
        public Azure.AI.Projects.VectorStoreDataSourceAssetType AssetType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreDataSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreDataSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreDataSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreDataSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreDataSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreDataSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreDataSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreDataSourceAssetType : System.IEquatable<Azure.AI.Projects.VectorStoreDataSourceAssetType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreDataSourceAssetType(string value) { throw null; }
        public static Azure.AI.Projects.VectorStoreDataSourceAssetType IdAsset { get { throw null; } }
        public static Azure.AI.Projects.VectorStoreDataSourceAssetType UriAsset { get { throw null; } }
        public bool Equals(Azure.AI.Projects.VectorStoreDataSourceAssetType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.VectorStoreDataSourceAssetType left, Azure.AI.Projects.VectorStoreDataSourceAssetType right) { throw null; }
        public static implicit operator Azure.AI.Projects.VectorStoreDataSourceAssetType (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.VectorStoreDataSourceAssetType left, Azure.AI.Projects.VectorStoreDataSourceAssetType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreDeletionStatus : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreDeletionStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreDeletionStatus>
    {
        internal VectorStoreDeletionStatus() { }
        public bool Deleted { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Projects.VectorStoreDeletionStatusObject Object { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreDeletionStatus System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreDeletionStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreDeletionStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreDeletionStatus System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreDeletionStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreDeletionStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreDeletionStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreDeletionStatusObject : System.IEquatable<Azure.AI.Projects.VectorStoreDeletionStatusObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreDeletionStatusObject(string value) { throw null; }
        public static Azure.AI.Projects.VectorStoreDeletionStatusObject VectorStoreDeleted { get { throw null; } }
        public bool Equals(Azure.AI.Projects.VectorStoreDeletionStatusObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.VectorStoreDeletionStatusObject left, Azure.AI.Projects.VectorStoreDeletionStatusObject right) { throw null; }
        public static implicit operator Azure.AI.Projects.VectorStoreDeletionStatusObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.VectorStoreDeletionStatusObject left, Azure.AI.Projects.VectorStoreDeletionStatusObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreExpirationPolicy : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreExpirationPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreExpirationPolicy>
    {
        public VectorStoreExpirationPolicy(Azure.AI.Projects.VectorStoreExpirationPolicyAnchor anchor, int days) { }
        public Azure.AI.Projects.VectorStoreExpirationPolicyAnchor Anchor { get { throw null; } set { } }
        public int Days { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreExpirationPolicy System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreExpirationPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreExpirationPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreExpirationPolicy System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreExpirationPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreExpirationPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreExpirationPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreExpirationPolicyAnchor : System.IEquatable<Azure.AI.Projects.VectorStoreExpirationPolicyAnchor>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreExpirationPolicyAnchor(string value) { throw null; }
        public static Azure.AI.Projects.VectorStoreExpirationPolicyAnchor LastActiveAt { get { throw null; } }
        public bool Equals(Azure.AI.Projects.VectorStoreExpirationPolicyAnchor other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.VectorStoreExpirationPolicyAnchor left, Azure.AI.Projects.VectorStoreExpirationPolicyAnchor right) { throw null; }
        public static implicit operator Azure.AI.Projects.VectorStoreExpirationPolicyAnchor (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.VectorStoreExpirationPolicyAnchor left, Azure.AI.Projects.VectorStoreExpirationPolicyAnchor right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreFile : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreFile>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreFile>
    {
        internal VectorStoreFile() { }
        public Azure.AI.Projects.VectorStoreChunkingStrategyResponse ChunkingStrategy { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Projects.VectorStoreFileError LastError { get { throw null; } }
        public Azure.AI.Projects.VectorStoreFileObject Object { get { throw null; } }
        public Azure.AI.Projects.VectorStoreFileStatus Status { get { throw null; } }
        public int UsageBytes { get { throw null; } }
        public string VectorStoreId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreFile System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreFile System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreFileBatch : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreFileBatch>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreFileBatch>
    {
        internal VectorStoreFileBatch() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public Azure.AI.Projects.VectorStoreFileCount FileCounts { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Projects.VectorStoreFileBatchObject Object { get { throw null; } }
        public Azure.AI.Projects.VectorStoreFileBatchStatus Status { get { throw null; } }
        public string VectorStoreId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreFileBatch System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreFileBatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreFileBatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreFileBatch System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreFileBatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreFileBatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreFileBatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileBatchObject : System.IEquatable<Azure.AI.Projects.VectorStoreFileBatchObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileBatchObject(string value) { throw null; }
        public static Azure.AI.Projects.VectorStoreFileBatchObject VectorStoreFilesBatch { get { throw null; } }
        public bool Equals(Azure.AI.Projects.VectorStoreFileBatchObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.VectorStoreFileBatchObject left, Azure.AI.Projects.VectorStoreFileBatchObject right) { throw null; }
        public static implicit operator Azure.AI.Projects.VectorStoreFileBatchObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.VectorStoreFileBatchObject left, Azure.AI.Projects.VectorStoreFileBatchObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileBatchStatus : System.IEquatable<Azure.AI.Projects.VectorStoreFileBatchStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileBatchStatus(string value) { throw null; }
        public static Azure.AI.Projects.VectorStoreFileBatchStatus Cancelled { get { throw null; } }
        public static Azure.AI.Projects.VectorStoreFileBatchStatus Completed { get { throw null; } }
        public static Azure.AI.Projects.VectorStoreFileBatchStatus Failed { get { throw null; } }
        public static Azure.AI.Projects.VectorStoreFileBatchStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Projects.VectorStoreFileBatchStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.VectorStoreFileBatchStatus left, Azure.AI.Projects.VectorStoreFileBatchStatus right) { throw null; }
        public static implicit operator Azure.AI.Projects.VectorStoreFileBatchStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.VectorStoreFileBatchStatus left, Azure.AI.Projects.VectorStoreFileBatchStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreFileCount : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreFileCount>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreFileCount>
    {
        internal VectorStoreFileCount() { }
        public int Cancelled { get { throw null; } }
        public int Completed { get { throw null; } }
        public int Failed { get { throw null; } }
        public int InProgress { get { throw null; } }
        public int Total { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreFileCount System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreFileCount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreFileCount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreFileCount System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreFileCount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreFileCount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreFileCount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreFileDeletionStatus : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreFileDeletionStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreFileDeletionStatus>
    {
        internal VectorStoreFileDeletionStatus() { }
        public bool Deleted { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Projects.VectorStoreFileDeletionStatusObject Object { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreFileDeletionStatus System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreFileDeletionStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreFileDeletionStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreFileDeletionStatus System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreFileDeletionStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreFileDeletionStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreFileDeletionStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileDeletionStatusObject : System.IEquatable<Azure.AI.Projects.VectorStoreFileDeletionStatusObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileDeletionStatusObject(string value) { throw null; }
        public static Azure.AI.Projects.VectorStoreFileDeletionStatusObject VectorStoreFileDeleted { get { throw null; } }
        public bool Equals(Azure.AI.Projects.VectorStoreFileDeletionStatusObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.VectorStoreFileDeletionStatusObject left, Azure.AI.Projects.VectorStoreFileDeletionStatusObject right) { throw null; }
        public static implicit operator Azure.AI.Projects.VectorStoreFileDeletionStatusObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.VectorStoreFileDeletionStatusObject left, Azure.AI.Projects.VectorStoreFileDeletionStatusObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreFileError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreFileError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreFileError>
    {
        internal VectorStoreFileError() { }
        public Azure.AI.Projects.VectorStoreFileErrorCode Code { get { throw null; } }
        public string Message { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreFileError System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreFileError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreFileError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreFileError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreFileError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreFileError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreFileError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileErrorCode : System.IEquatable<Azure.AI.Projects.VectorStoreFileErrorCode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileErrorCode(string value) { throw null; }
        public static Azure.AI.Projects.VectorStoreFileErrorCode InvalidFile { get { throw null; } }
        public static Azure.AI.Projects.VectorStoreFileErrorCode ServerError { get { throw null; } }
        public static Azure.AI.Projects.VectorStoreFileErrorCode UnsupportedFile { get { throw null; } }
        public bool Equals(Azure.AI.Projects.VectorStoreFileErrorCode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.VectorStoreFileErrorCode left, Azure.AI.Projects.VectorStoreFileErrorCode right) { throw null; }
        public static implicit operator Azure.AI.Projects.VectorStoreFileErrorCode (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.VectorStoreFileErrorCode left, Azure.AI.Projects.VectorStoreFileErrorCode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileObject : System.IEquatable<Azure.AI.Projects.VectorStoreFileObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileObject(string value) { throw null; }
        public static Azure.AI.Projects.VectorStoreFileObject VectorStoreFile { get { throw null; } }
        public bool Equals(Azure.AI.Projects.VectorStoreFileObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.VectorStoreFileObject left, Azure.AI.Projects.VectorStoreFileObject right) { throw null; }
        public static implicit operator Azure.AI.Projects.VectorStoreFileObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.VectorStoreFileObject left, Azure.AI.Projects.VectorStoreFileObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileStatus : System.IEquatable<Azure.AI.Projects.VectorStoreFileStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileStatus(string value) { throw null; }
        public static Azure.AI.Projects.VectorStoreFileStatus Cancelled { get { throw null; } }
        public static Azure.AI.Projects.VectorStoreFileStatus Completed { get { throw null; } }
        public static Azure.AI.Projects.VectorStoreFileStatus Failed { get { throw null; } }
        public static Azure.AI.Projects.VectorStoreFileStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Projects.VectorStoreFileStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.VectorStoreFileStatus left, Azure.AI.Projects.VectorStoreFileStatus right) { throw null; }
        public static implicit operator Azure.AI.Projects.VectorStoreFileStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.VectorStoreFileStatus left, Azure.AI.Projects.VectorStoreFileStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreFileStatusFilter : System.IEquatable<Azure.AI.Projects.VectorStoreFileStatusFilter>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreFileStatusFilter(string value) { throw null; }
        public static Azure.AI.Projects.VectorStoreFileStatusFilter Cancelled { get { throw null; } }
        public static Azure.AI.Projects.VectorStoreFileStatusFilter Completed { get { throw null; } }
        public static Azure.AI.Projects.VectorStoreFileStatusFilter Failed { get { throw null; } }
        public static Azure.AI.Projects.VectorStoreFileStatusFilter InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Projects.VectorStoreFileStatusFilter other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.VectorStoreFileStatusFilter left, Azure.AI.Projects.VectorStoreFileStatusFilter right) { throw null; }
        public static implicit operator Azure.AI.Projects.VectorStoreFileStatusFilter (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.VectorStoreFileStatusFilter left, Azure.AI.Projects.VectorStoreFileStatusFilter right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreObject : System.IEquatable<Azure.AI.Projects.VectorStoreObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreObject(string value) { throw null; }
        public static Azure.AI.Projects.VectorStoreObject VectorStore { get { throw null; } }
        public bool Equals(Azure.AI.Projects.VectorStoreObject other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.VectorStoreObject left, Azure.AI.Projects.VectorStoreObject right) { throw null; }
        public static implicit operator Azure.AI.Projects.VectorStoreObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.VectorStoreObject left, Azure.AI.Projects.VectorStoreObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VectorStoreStaticChunkingStrategyOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreStaticChunkingStrategyOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreStaticChunkingStrategyOptions>
    {
        public VectorStoreStaticChunkingStrategyOptions(int maxChunkSizeTokens, int chunkOverlapTokens) { }
        public int ChunkOverlapTokens { get { throw null; } set { } }
        public int MaxChunkSizeTokens { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreStaticChunkingStrategyOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreStaticChunkingStrategyOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreStaticChunkingStrategyOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreStaticChunkingStrategyOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreStaticChunkingStrategyOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreStaticChunkingStrategyOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreStaticChunkingStrategyOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreStaticChunkingStrategyRequest : Azure.AI.Projects.VectorStoreChunkingStrategyRequest, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreStaticChunkingStrategyRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreStaticChunkingStrategyRequest>
    {
        public VectorStoreStaticChunkingStrategyRequest(Azure.AI.Projects.VectorStoreStaticChunkingStrategyOptions @static) { }
        public Azure.AI.Projects.VectorStoreStaticChunkingStrategyOptions Static { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreStaticChunkingStrategyRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreStaticChunkingStrategyRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreStaticChunkingStrategyRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreStaticChunkingStrategyRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreStaticChunkingStrategyRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreStaticChunkingStrategyRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreStaticChunkingStrategyRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VectorStoreStaticChunkingStrategyResponse : Azure.AI.Projects.VectorStoreChunkingStrategyResponse, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreStaticChunkingStrategyResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreStaticChunkingStrategyResponse>
    {
        internal VectorStoreStaticChunkingStrategyResponse() { }
        public Azure.AI.Projects.VectorStoreStaticChunkingStrategyOptions Static { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreStaticChunkingStrategyResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreStaticChunkingStrategyResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.VectorStoreStaticChunkingStrategyResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.VectorStoreStaticChunkingStrategyResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreStaticChunkingStrategyResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreStaticChunkingStrategyResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.VectorStoreStaticChunkingStrategyResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VectorStoreStatus : System.IEquatable<Azure.AI.Projects.VectorStoreStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VectorStoreStatus(string value) { throw null; }
        public static Azure.AI.Projects.VectorStoreStatus Completed { get { throw null; } }
        public static Azure.AI.Projects.VectorStoreStatus Expired { get { throw null; } }
        public static Azure.AI.Projects.VectorStoreStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Projects.VectorStoreStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.VectorStoreStatus left, Azure.AI.Projects.VectorStoreStatus right) { throw null; }
        public static implicit operator Azure.AI.Projects.VectorStoreStatus (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.VectorStoreStatus left, Azure.AI.Projects.VectorStoreStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WeekDays : System.IEquatable<Azure.AI.Projects.WeekDays>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WeekDays(string value) { throw null; }
        public static Azure.AI.Projects.WeekDays Friday { get { throw null; } }
        public static Azure.AI.Projects.WeekDays Monday { get { throw null; } }
        public static Azure.AI.Projects.WeekDays Saturday { get { throw null; } }
        public static Azure.AI.Projects.WeekDays Sunday { get { throw null; } }
        public static Azure.AI.Projects.WeekDays Thursday { get { throw null; } }
        public static Azure.AI.Projects.WeekDays Tuesday { get { throw null; } }
        public static Azure.AI.Projects.WeekDays Wednesday { get { throw null; } }
        public bool Equals(Azure.AI.Projects.WeekDays other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.WeekDays left, Azure.AI.Projects.WeekDays right) { throw null; }
        public static implicit operator Azure.AI.Projects.WeekDays (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.WeekDays left, Azure.AI.Projects.WeekDays right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkspaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.WorkspaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.WorkspaceProperties>
    {
        internal WorkspaceProperties() { }
        public string ApplicationInsights { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.WorkspaceProperties System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.WorkspaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.WorkspaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.WorkspaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.WorkspaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.WorkspaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.WorkspaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class AIProjectsClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Projects.AIProjectClient, Azure.AI.Projects.AIProjectClientOptions> AddAIProjectClient<TBuilder>(this TBuilder builder, System.Uri endpoint, string subscriptionId, string resourceGroupName, string projectName) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.Projects.AIProjectClient, Azure.AI.Projects.AIProjectClientOptions> AddAIProjectClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
