namespace Azure.AI.Agents
{
    public partial class A2ATool : Azure.AI.Agents.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.A2ATool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.A2ATool>
    {
        public A2ATool(System.Uri baseUrl) { }
        public string AgentCardPath { get { throw null; } set { } }
        public System.Uri BaseUrl { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected override Azure.AI.Agents.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Agents.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.A2ATool System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.A2ATool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.A2ATool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.A2ATool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.A2ATool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.A2ATool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.A2ATool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentCommunicationMethod : System.IEquatable<Azure.AI.Agents.AgentCommunicationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentCommunicationMethod(string value) { throw null; }
        public static Azure.AI.Agents.AgentCommunicationMethod ActivityProtocol { get { throw null; } }
        public static Azure.AI.Agents.AgentCommunicationMethod Responses { get { throw null; } }
        public bool Equals(Azure.AI.Agents.AgentCommunicationMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.AgentCommunicationMethod left, Azure.AI.Agents.AgentCommunicationMethod right) { throw null; }
        public static implicit operator Azure.AI.Agents.AgentCommunicationMethod (string value) { throw null; }
        public static implicit operator Azure.AI.Agents.AgentCommunicationMethod? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.AgentCommunicationMethod left, Azure.AI.Agents.AgentCommunicationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentContainer : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentContainer>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentContainer>
    {
        internal AgentContainer() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public int? MaxReplicas { get { throw null; } }
        public int? MinReplicas { get { throw null; } }
        public string Object { get { throw null; } }
        public Azure.AI.Agents.AgentContainerStatus Status { get { throw null; } }
        public System.DateTimeOffset UpdatedAt { get { throw null; } }
        protected virtual Azure.AI.Agents.AgentContainer JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Agents.AgentContainer (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Agents.AgentContainer PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AgentContainer System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentContainer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentContainer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentContainer System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentContainer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentContainer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentContainer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentContainerOperation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentContainerOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentContainerOperation>
    {
        internal AgentContainerOperation() { }
        public string AgentId { get { throw null; } }
        public string AgentVersionId { get { throw null; } }
        public Azure.AI.Agents.AgentContainer Container { get { throw null; } }
        public Azure.AI.Agents.AgentContainerOperationError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.Agents.AgentContainerOperationStatus Status { get { throw null; } }
        protected virtual Azure.AI.Agents.AgentContainerOperation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Agents.AgentContainerOperation (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Agents.AgentContainerOperation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AgentContainerOperation System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentContainerOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentContainerOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentContainerOperation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentContainerOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentContainerOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentContainerOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentContainerOperationError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentContainerOperationError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentContainerOperationError>
    {
        internal AgentContainerOperationError() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.Agents.AgentContainerOperationError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.AgentContainerOperationError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AgentContainerOperationError System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentContainerOperationError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentContainerOperationError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentContainerOperationError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentContainerOperationError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentContainerOperationError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentContainerOperationError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum AgentContainerOperationStatus
    {
        NotStarted = 0,
        InProgress = 1,
        Succeeded = 2,
        Failed = 3,
    }
    public enum AgentContainerStatus
    {
        Starting = 0,
        Running = 1,
        Stopping = 2,
        Stopped = 3,
        Failed = 4,
        Deleting = 5,
        Deleted = 6,
        Updating = 7,
    }
    public partial class AgentConversation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentConversation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentConversation>
    {
        internal AgentConversation() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string Object { get { throw null; } }
        protected virtual Azure.AI.Agents.AgentConversation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Agents.AgentConversation (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Agents.AgentConversation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AgentConversation System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentConversation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentConversation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentConversation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentConversation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentConversation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentConversation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentConversationCreationOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentConversationCreationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentConversationCreationOptions>
    {
        public AgentConversationCreationOptions() { }
        public System.Collections.Generic.IList<OpenAI.Responses.ResponseItem> Items { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        protected virtual Azure.AI.Agents.AgentConversationCreationOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Agents.AgentConversationCreationOptions agentConversationCreationOptions) { throw null; }
        protected virtual Azure.AI.Agents.AgentConversationCreationOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AgentConversationCreationOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentConversationCreationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentConversationCreationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentConversationCreationOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentConversationCreationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentConversationCreationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentConversationCreationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentConversationDeletionResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentConversationDeletionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentConversationDeletionResult>
    {
        internal AgentConversationDeletionResult() { }
        public bool Deleted { get { throw null; } }
        public string Id { get { throw null; } }
        public string Object { get { throw null; } }
        protected virtual Azure.AI.Agents.AgentConversationDeletionResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Agents.AgentConversationDeletionResult (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Agents.AgentConversationDeletionResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AgentConversationDeletionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentConversationDeletionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentConversationDeletionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentConversationDeletionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentConversationDeletionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentConversationDeletionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentConversationDeletionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentConversationUpdateOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentConversationUpdateOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentConversationUpdateOptions>
    {
        public AgentConversationUpdateOptions() { }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        protected virtual Azure.AI.Agents.AgentConversationUpdateOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Agents.AgentConversationUpdateOptions agentConversationUpdateOptions) { throw null; }
        protected virtual Azure.AI.Agents.AgentConversationUpdateOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AgentConversationUpdateOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentConversationUpdateOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentConversationUpdateOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentConversationUpdateOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentConversationUpdateOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentConversationUpdateOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentConversationUpdateOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentCreationOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentCreationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentCreationOptions>
    {
        public AgentCreationOptions() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        protected virtual Azure.AI.Agents.AgentCreationOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Agents.AgentCreationOptions agentCreationOptions) { throw null; }
        protected virtual Azure.AI.Agents.AgentCreationOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AgentCreationOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentCreationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentCreationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentCreationOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentCreationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentCreationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentCreationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AgentDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentDefinition>
    {
        internal AgentDefinition() { }
        public Azure.AI.Agents.RaiConfig RaiConfig { get { throw null; } set { } }
        protected virtual Azure.AI.Agents.AgentDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.AgentDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AgentDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentDeletionResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentDeletionResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentDeletionResult>
    {
        internal AgentDeletionResult() { }
        public bool Deleted { get { throw null; } }
        public string Name { get { throw null; } }
        public string Object { get { throw null; } }
        protected virtual Azure.AI.Agents.AgentDeletionResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Agents.AgentDeletionResult (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Agents.AgentDeletionResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AgentDeletionResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentDeletionResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentDeletionResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentDeletionResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentDeletionResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentDeletionResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentDeletionResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentInfo : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentInfo>
    {
        internal AgentInfo() { }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Agents.AgentInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.AgentInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AgentInfo System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentInfo System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentKind : System.IEquatable<Azure.AI.Agents.AgentKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentKind(string value) { throw null; }
        public static Azure.AI.Agents.AgentKind ContainerApp { get { throw null; } }
        public static Azure.AI.Agents.AgentKind Hosted { get { throw null; } }
        public static Azure.AI.Agents.AgentKind Prompt { get { throw null; } }
        public static Azure.AI.Agents.AgentKind Workflow { get { throw null; } }
        public bool Equals(Azure.AI.Agents.AgentKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.AgentKind left, Azure.AI.Agents.AgentKind right) { throw null; }
        public static implicit operator Azure.AI.Agents.AgentKind (string value) { throw null; }
        public static implicit operator Azure.AI.Agents.AgentKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.AgentKind left, Azure.AI.Agents.AgentKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentManifestOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentManifestOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentManifestOptions>
    {
        internal AgentManifestOptions() { }
        public string Description { get { throw null; } }
        public string ManifestId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ParameterValues { get { throw null; } }
        protected virtual Azure.AI.Agents.AgentManifestOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Agents.AgentManifestOptions agentManifestOptions) { throw null; }
        protected virtual Azure.AI.Agents.AgentManifestOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AgentManifestOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentManifestOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentManifestOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentManifestOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentManifestOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentManifestOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentManifestOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentObjectVersions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentObjectVersions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentObjectVersions>
    {
        internal AgentObjectVersions() { }
        public Azure.AI.Agents.AgentVersion Latest { get { throw null; } }
        protected virtual Azure.AI.Agents.AgentObjectVersions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.AgentObjectVersions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AgentObjectVersions System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentObjectVersions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentObjectVersions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentObjectVersions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentObjectVersions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentObjectVersions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentObjectVersions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentRecord : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentRecord>
    {
        internal AgentRecord() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string Object { get { throw null; } }
        public Azure.AI.Agents.AgentObjectVersions Versions { get { throw null; } }
        protected virtual Azure.AI.Agents.AgentRecord JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Agents.AgentRecord (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Agents.AgentRecord PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AgentRecord System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentRecord System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentReference>
    {
        public AgentReference(string name) { }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.AI.Agents.AgentReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.AgentReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AgentReference System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AgentResponseItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentResponseItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentResponseItem>
    {
        internal AgentResponseItem() { }
        public Azure.AI.Agents.CreatedBy CreatedBy { get { throw null; } }
        public virtual string Id { get { throw null; } }
        public OpenAI.Responses.ResponseItem AsOpenAIResponseItem() { throw null; }
        public static Azure.AI.Agents.AgentResponseItem CreateStructuredOutputsItem(System.BinaryData output = null) { throw null; }
        public static Azure.AI.Agents.AgentResponseItem CreateWorkflowActionItem(string actionKind, string actionId) { throw null; }
        protected virtual Azure.AI.Agents.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Agents.AgentResponseItem (System.ClientModel.ClientResult result) { throw null; }
        public static implicit operator OpenAI.Responses.ResponseItem (Azure.AI.Agents.AgentResponseItem agentResponseItem) { throw null; }
        public static implicit operator Azure.AI.Agents.AgentResponseItem (OpenAI.Responses.ResponseItem responseItem) { throw null; }
        protected virtual Azure.AI.Agents.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AgentResponseItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentResponseItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentResponseItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentResponseItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentResponseItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentResponseItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentResponseItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentResponseItemKind : System.IEquatable<Azure.AI.Agents.AgentResponseItemKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentResponseItemKind(string value) { throw null; }
        public static Azure.AI.Agents.AgentResponseItemKind CodeInterpreterCall { get { throw null; } }
        public static Azure.AI.Agents.AgentResponseItemKind ComputerCall { get { throw null; } }
        public static Azure.AI.Agents.AgentResponseItemKind ComputerCallOutput { get { throw null; } }
        public static Azure.AI.Agents.AgentResponseItemKind FileSearchCall { get { throw null; } }
        public static Azure.AI.Agents.AgentResponseItemKind FunctionCall { get { throw null; } }
        public static Azure.AI.Agents.AgentResponseItemKind FunctionCallOutput { get { throw null; } }
        public static Azure.AI.Agents.AgentResponseItemKind ImageGenerationCall { get { throw null; } }
        public static Azure.AI.Agents.AgentResponseItemKind ItemReference { get { throw null; } }
        public static Azure.AI.Agents.AgentResponseItemKind LocalShellCall { get { throw null; } }
        public static Azure.AI.Agents.AgentResponseItemKind LocalShellCallOutput { get { throw null; } }
        public static Azure.AI.Agents.AgentResponseItemKind McpApprovalRequest { get { throw null; } }
        public static Azure.AI.Agents.AgentResponseItemKind McpApprovalResponse { get { throw null; } }
        public static Azure.AI.Agents.AgentResponseItemKind McpCall { get { throw null; } }
        public static Azure.AI.Agents.AgentResponseItemKind McpListTools { get { throw null; } }
        public static Azure.AI.Agents.AgentResponseItemKind MemorySearchCall { get { throw null; } }
        public static Azure.AI.Agents.AgentResponseItemKind Message { get { throw null; } }
        public static Azure.AI.Agents.AgentResponseItemKind OauthConsentRequest { get { throw null; } }
        public static Azure.AI.Agents.AgentResponseItemKind Reasoning { get { throw null; } }
        public static Azure.AI.Agents.AgentResponseItemKind StructuredOutputs { get { throw null; } }
        public static Azure.AI.Agents.AgentResponseItemKind WebSearchCall { get { throw null; } }
        public static Azure.AI.Agents.AgentResponseItemKind WorkflowAction { get { throw null; } }
        public bool Equals(Azure.AI.Agents.AgentResponseItemKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.AgentResponseItemKind left, Azure.AI.Agents.AgentResponseItemKind right) { throw null; }
        public static implicit operator Azure.AI.Agents.AgentResponseItemKind (string value) { throw null; }
        public static implicit operator Azure.AI.Agents.AgentResponseItemKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.AgentResponseItemKind left, Azure.AI.Agents.AgentResponseItemKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentsApiError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentsApiError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentsApiError>
    {
        internal AgentsApiError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.Agents.AgentsApiError> Details { get { throw null; } }
        public Azure.AI.Agents.ApiInnerError Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual Azure.AI.Agents.AgentsApiError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.AgentsApiError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AgentsApiError System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentsApiError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentsApiError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentsApiError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentsApiError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentsApiError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentsApiError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public string ToExceptionMessage(int httpStatus) { throw null; }
        public System.BinaryData ToOpenAIError() { throw null; }
    }
    public partial class AgentsClient
    {
        protected AgentsClient() { }
        public AgentsClient(System.Uri endpoint, System.ClientModel.AuthenticationTokenProvider tokenProvider) { }
        public AgentsClient(System.Uri endpoint, System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Agents.AgentsClientOptions options) { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult CreateAgent(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.AgentRecord> CreateAgent(string name, Azure.AI.Agents.AgentDefinition definition, Azure.AI.Agents.AgentCreationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateAgentAsync(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.AgentRecord>> CreateAgentAsync(string name, Azure.AI.Agents.AgentDefinition definition, Azure.AI.Agents.AgentCreationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult CreateAgentFromManifest(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.AgentRecord> CreateAgentFromManifest(string agentName, string manifestId, Azure.AI.Agents.AgentManifestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateAgentFromManifestAsync(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.AgentRecord>> CreateAgentFromManifestAsync(string agentName, string manifestId, Azure.AI.Agents.AgentManifestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.AgentVersion> CreateAgentVersion(string agentName, Azure.AI.Agents.AgentDefinition definition, Azure.AI.Agents.AgentVersionCreationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult CreateAgentVersion(string agentName, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.AgentVersion>> CreateAgentVersionAsync(string agentName, Azure.AI.Agents.AgentDefinition definition, Azure.AI.Agents.AgentVersionCreationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateAgentVersionAsync(string agentName, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult CreateAgentVersionFromManifest(string agentName, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.AgentVersion> CreateAgentVersionFromManifest(string agentName, string manifestId, Azure.AI.Agents.AgentManifestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateAgentVersionFromManifestAsync(string agentName, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.AgentVersion>> CreateAgentVersionFromManifestAsync(string agentName, string manifestId, Azure.AI.Agents.AgentManifestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteAgent(string agentName, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.AgentDeletionResult> DeleteAgent(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAgentAsync(string agentName, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.AgentDeletionResult>> DeleteAgentAsync(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteAgentContainer(string agentName, string agentVersion, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.AgentContainerOperation> DeleteAgentContainer(string agentName, string agentVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAgentContainerAsync(string agentName, string agentVersion, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.AgentContainerOperation>> DeleteAgentContainerAsync(string agentName, string agentVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteAgentVersion(string agentName, string agentVersion, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.DeleteAgentVersionResponse> DeleteAgentVersion(string agentName, string agentVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteAgentVersionAsync(string agentName, string agentVersion, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.DeleteAgentVersionResponse>> DeleteAgentVersionAsync(string agentName, string agentVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetAgent(string agentName, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.AgentRecord> GetAgent(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAgentAsync(string agentName, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.AgentRecord>> GetAgentAsync(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetAgentContainer(string agentName, string agentVersion, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.AgentContainer> GetAgentContainer(string agentName, string agentVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAgentContainerAsync(string agentName, string agentVersion, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.AgentContainer>> GetAgentContainerAsync(string agentName, string agentVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetAgentContainerOperation(string agentName, string operationId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.AgentContainerOperation> GetAgentContainerOperation(string agentName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAgentContainerOperationAsync(string agentName, string operationId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.AgentContainerOperation>> GetAgentContainerOperationAsync(string agentName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Agents.AgentContainerOperation> GetAgentContainerOperations(string agentName, int? limit = default(int?), Azure.AI.Agents.AgentsListOrder? order = default(Azure.AI.Agents.AgentsListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Agents.AgentContainerOperation> GetAgentContainerOperationsAsync(string agentName, int? limit = default(int?), Azure.AI.Agents.AgentsListOrder? order = default(Azure.AI.Agents.AgentsListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Agents.AgentRecord> GetAgents(Azure.AI.Agents.AgentKind? kind = default(Azure.AI.Agents.AgentKind?), int? limit = default(int?), Azure.AI.Agents.AgentsListOrder? order = default(Azure.AI.Agents.AgentsListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Agents.AgentRecord> GetAgentsAsync(Azure.AI.Agents.AgentKind? kind = default(Azure.AI.Agents.AgentKind?), int? limit = default(int?), Azure.AI.Agents.AgentsListOrder? order = default(Azure.AI.Agents.AgentsListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetAgentVersion(string agentName, string agentVersion, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.AgentVersion> GetAgentVersion(string agentName, string agentVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetAgentVersionAsync(string agentName, string agentVersion, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.AgentVersion>> GetAgentVersionAsync(string agentName, string agentVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Agents.AgentContainerOperation> GetAgentVersionContainerOperations(string agentName, string agentVersion, int? limit = default(int?), Azure.AI.Agents.AgentsListOrder? order = default(Azure.AI.Agents.AgentsListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Agents.AgentContainerOperation> GetAgentVersionContainerOperationsAsync(string agentName, string agentVersion, int? limit = default(int?), Azure.AI.Agents.AgentsListOrder? order = default(Azure.AI.Agents.AgentsListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Agents.AgentVersion> GetAgentVersions(string agentName, int? limit = default(int?), Azure.AI.Agents.AgentsListOrder? order = default(Azure.AI.Agents.AgentsListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Agents.AgentVersion> GetAgentVersionsAsync(string agentName, int? limit = default(int?), Azure.AI.Agents.AgentsListOrder? order = default(Azure.AI.Agents.AgentsListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AI.Agents.ConversationClient GetConversationClient() { throw null; }
        public virtual Azure.AI.Agents.MemoryStoreClient GetMemoryStoreClient() { throw null; }
        public virtual OpenAI.OpenAIClient GetOpenAIClient(OpenAI.OpenAIClientOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult StartAgentContainer(string agentName, string agentVersion, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.AgentContainerOperation> StartAgentContainer(string agentName, string agentVersion, int? minReplicas = default(int?), int? maxReplicas = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> StartAgentContainerAsync(string agentName, string agentVersion, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.AgentContainerOperation>> StartAgentContainerAsync(string agentName, string agentVersion, int? minReplicas = default(int?), int? maxReplicas = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult StopAgentContainer(string agentName, string agentVersion, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.AgentContainerOperation> StopAgentContainer(string agentName, string agentVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> StopAgentContainerAsync(string agentName, string agentVersion, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.AgentContainerOperation>> StopAgentContainerAsync(string agentName, string agentVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.AgentRecord> UpdateAgent(string agentName, Azure.AI.Agents.AgentUpdateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult UpdateAgent(string agentName, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.AgentRecord>> UpdateAgentAsync(string agentName, Azure.AI.Agents.AgentUpdateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> UpdateAgentAsync(string agentName, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult UpdateAgentContainer(string agentName, string agentVersion, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.AgentContainerOperation> UpdateAgentContainer(string agentName, string agentVersion, int? minReplicas = default(int?), int? maxReplicas = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> UpdateAgentContainerAsync(string agentName, string agentVersion, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.AgentContainerOperation>> UpdateAgentContainerAsync(string agentName, string agentVersion, int? minReplicas = default(int?), int? maxReplicas = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult UpdateAgentFromManifest(string agentName, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.AgentRecord> UpdateAgentFromManifest(string agentName, string manifestId, Azure.AI.Agents.AgentManifestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> UpdateAgentFromManifestAsync(string agentName, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.AgentRecord>> UpdateAgentFromManifestAsync(string agentName, string manifestId, Azure.AI.Agents.AgentManifestOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AgentsClientOptions : System.ClientModel.Primitives.ClientPipelineOptions
    {
        public AgentsClientOptions(Azure.AI.Agents.AgentsClientOptions.ServiceVersion version = Azure.AI.Agents.AgentsClientOptions.ServiceVersion.V2025_11_15_Preview) { }
        public string UserAgentApplicationId { get { throw null; } set { } }
        public enum ServiceVersion
        {
            V2025_11_01 = 1,
            V2025_11_15_Preview = 2,
        }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentsListOrder : System.IEquatable<Azure.AI.Agents.AgentsListOrder>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentsListOrder(string value) { throw null; }
        public static Azure.AI.Agents.AgentsListOrder Asc { get { throw null; } }
        public static Azure.AI.Agents.AgentsListOrder Desc { get { throw null; } }
        public bool Equals(Azure.AI.Agents.AgentsListOrder other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.AgentsListOrder left, Azure.AI.Agents.AgentsListOrder right) { throw null; }
        public static implicit operator Azure.AI.Agents.AgentsListOrder (string value) { throw null; }
        public static implicit operator Azure.AI.Agents.AgentsListOrder? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.AgentsListOrder left, Azure.AI.Agents.AgentsListOrder right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentStructuredOutputsResponseItem : Azure.AI.Agents.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentStructuredOutputsResponseItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentStructuredOutputsResponseItem>
    {
        public AgentStructuredOutputsResponseItem(System.BinaryData output) { }
        public System.BinaryData Output { get { throw null; } }
        protected override Azure.AI.Agents.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Agents.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AgentStructuredOutputsResponseItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentStructuredOutputsResponseItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentStructuredOutputsResponseItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentStructuredOutputsResponseItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentStructuredOutputsResponseItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentStructuredOutputsResponseItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentStructuredOutputsResponseItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AgentTool : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentTool>
    {
        internal AgentTool() { }
        public static OpenAI.Responses.ResponseTool CreateA2ATool(System.Uri baseUrl, string agentCardPath = null) { throw null; }
        public static Azure.AI.Agents.AzureAISearchAgentTool CreateAzureAISearchTool(Azure.AI.Agents.AzureAISearchToolOptions options = null) { throw null; }
        public static Azure.AI.Agents.BingCustomSearchAgentTool CreateBingCustomSearchTool(Azure.AI.Agents.BingCustomSearchToolParameters parameters) { throw null; }
        public static Azure.AI.Agents.BingGroundingAgentTool CreateBingGroundingTool(Azure.AI.Agents.BingGroundingSearchToolParameters parameters) { throw null; }
        public static Azure.AI.Agents.BrowserAutomationAgentTool CreateBrowserAutomationTool(Azure.AI.Agents.BrowserAutomationToolParameters parameters) { throw null; }
        public static Azure.AI.Agents.MicrosoftFabricAgentTool CreateMicrosoftFabricTool(Azure.AI.Agents.FabricDataAgentToolParameters parameters) { throw null; }
        public static Azure.AI.Agents.OpenApiAgentTool CreateOpenApiTool(Azure.AI.Agents.OpenApiFunctionDefinition definition) { throw null; }
        public static Azure.AI.Agents.SharepointAgentTool CreateSharepointTool(Azure.AI.Agents.SharepointGroundingToolParameters parameters) { throw null; }
        public static Azure.AI.Agents.CaptureStructuredOutputsTool CreateStructuredOutputsTool(Azure.AI.Agents.StructuredOutputDefinition outputs) { throw null; }
        protected virtual Azure.AI.Agents.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator OpenAI.Responses.ResponseTool (Azure.AI.Agents.AgentTool agentTool) { throw null; }
        protected virtual Azure.AI.Agents.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AgentTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentUpdateOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentUpdateOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentUpdateOptions>
    {
        public AgentUpdateOptions(Azure.AI.Agents.AgentDefinition definition) { }
        public Azure.AI.Agents.AgentDefinition Definition { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        protected virtual Azure.AI.Agents.AgentUpdateOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Agents.AgentUpdateOptions agentUpdateOptions) { throw null; }
        protected virtual Azure.AI.Agents.AgentUpdateOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AgentUpdateOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentUpdateOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentUpdateOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentUpdateOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentUpdateOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentUpdateOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentUpdateOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentVersion : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentVersion>
    {
        internal AgentVersion() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public Azure.AI.Agents.AgentDefinition Definition { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public string Object { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Agents.AgentVersion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Agents.AgentVersion (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Agents.AgentVersion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AgentVersion System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentVersion System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentVersionCreationOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentVersionCreationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentVersionCreationOptions>
    {
        public AgentVersionCreationOptions() { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        protected virtual Azure.AI.Agents.AgentVersionCreationOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Agents.AgentVersionCreationOptions agentVersionCreationOptions) { throw null; }
        protected virtual Azure.AI.Agents.AgentVersionCreationOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AgentVersionCreationOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentVersionCreationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentVersionCreationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentVersionCreationOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentVersionCreationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentVersionCreationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentVersionCreationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentWorkflowActionResponseItem : Azure.AI.Agents.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentWorkflowActionResponseItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentWorkflowActionResponseItem>
    {
        internal AgentWorkflowActionResponseItem() { }
        public string ActionId { get { throw null; } }
        public string ParentActionId { get { throw null; } }
        public string PreviousActionId { get { throw null; } }
        public Azure.AI.Agents.AgentWorkflowActionStatus? Status { get { throw null; } }
        protected override Azure.AI.Agents.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Agents.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AgentWorkflowActionResponseItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentWorkflowActionResponseItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AgentWorkflowActionResponseItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AgentWorkflowActionResponseItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentWorkflowActionResponseItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentWorkflowActionResponseItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AgentWorkflowActionResponseItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentWorkflowActionStatus : System.IEquatable<Azure.AI.Agents.AgentWorkflowActionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentWorkflowActionStatus(string value) { throw null; }
        public static Azure.AI.Agents.AgentWorkflowActionStatus Cancelled { get { throw null; } }
        public static Azure.AI.Agents.AgentWorkflowActionStatus Completed { get { throw null; } }
        public static Azure.AI.Agents.AgentWorkflowActionStatus Failed { get { throw null; } }
        public static Azure.AI.Agents.AgentWorkflowActionStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Agents.AgentWorkflowActionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.AgentWorkflowActionStatus left, Azure.AI.Agents.AgentWorkflowActionStatus right) { throw null; }
        public static implicit operator Azure.AI.Agents.AgentWorkflowActionStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Agents.AgentWorkflowActionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.AgentWorkflowActionStatus left, Azure.AI.Agents.AgentWorkflowActionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApiInnerError : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ApiInnerError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ApiInnerError>
    {
        internal ApiInnerError() { }
        public string Code { get { throw null; } }
        public Azure.AI.Agents.ApiInnerError Innererror { get { throw null; } }
        protected virtual Azure.AI.Agents.ApiInnerError JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.ApiInnerError PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.ApiInnerError System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ApiInnerError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ApiInnerError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.ApiInnerError System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ApiInnerError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ApiInnerError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ApiInnerError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAIAgentsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAIAgentsContext() { }
        public static Azure.AI.Agents.AzureAIAgentsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class AzureAIAgentsModelFactory
    {
        public static Azure.AI.Agents.A2ATool A2ATool(System.Uri baseUrl = null, string agentCardPath = null, string projectConnectionId = null) { throw null; }
        public static Azure.AI.Agents.AgentContainer AgentContainer(Azure.AI.Agents.AgentContainerStatus status = Azure.AI.Agents.AgentContainerStatus.Starting, int? maxReplicas = default(int?), int? minReplicas = default(int?), string errorMessage = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset updatedAt = default(System.DateTimeOffset)) { throw null; }
        public static Azure.AI.Agents.AgentContainerOperation AgentContainerOperation(string id = null, string agentId = null, string agentVersionId = null, Azure.AI.Agents.AgentContainerOperationStatus status = Azure.AI.Agents.AgentContainerOperationStatus.NotStarted, Azure.AI.Agents.AgentContainerOperationError error = null, Azure.AI.Agents.AgentContainer container = null) { throw null; }
        public static Azure.AI.Agents.AgentContainerOperationError AgentContainerOperationError(string code = null, string type = null, string message = null) { throw null; }
        public static Azure.AI.Agents.AgentConversation AgentConversation(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.Collections.Generic.IDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Agents.AgentConversationDeletionResult AgentConversationDeletionResult(bool deleted = false, string id = null) { throw null; }
        public static Azure.AI.Agents.AgentConversationUpdateOptions AgentConversationUpdateOptions(System.Collections.Generic.IDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Agents.AgentCreationOptions AgentCreationOptions(string name = null, System.Collections.Generic.IDictionary<string, string> metadata = null, string description = null, Azure.AI.Agents.AgentDefinition definition = null) { throw null; }
        public static Azure.AI.Agents.AgentDefinition AgentDefinition(string kind = null, Azure.AI.Agents.RaiConfig raiConfig = null) { throw null; }
        public static Azure.AI.Agents.AgentDeletionResult AgentDeletionResult(string name = null, bool deleted = false) { throw null; }
        public static Azure.AI.Agents.AgentInfo AgentInfo(string name = null, string version = null) { throw null; }
        public static Azure.AI.Agents.AgentManifestOptions AgentManifestOptions(System.Collections.Generic.IDictionary<string, string> metadata = null, string description = null, string manifestId = null, System.Collections.Generic.IDictionary<string, System.BinaryData> parameterValues = null) { throw null; }
        public static Azure.AI.Agents.AgentObjectVersions AgentObjectVersions(Azure.AI.Agents.AgentVersion latest = null) { throw null; }
        public static Azure.AI.Agents.AgentRecord AgentRecord(string id = null, string name = null, Azure.AI.Agents.AgentObjectVersions versions = null) { throw null; }
        public static Azure.AI.Agents.AgentReference AgentReference(string name = null, string version = null) { throw null; }
        public static Azure.AI.Agents.AgentResponseItem AgentResponseItem(string type = null, string id = null, Azure.AI.Agents.CreatedBy createdBy = null) { throw null; }
        public static Azure.AI.Agents.AgentsApiError AgentsApiError(string code = null, string message = null, string target = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.AgentsApiError> details = null, Azure.AI.Agents.ApiInnerError innererror = null) { throw null; }
        public static Azure.AI.Agents.AgentStructuredOutputsResponseItem AgentStructuredOutputsResponseItem(string id = null, Azure.AI.Agents.CreatedBy createdBy = null, System.BinaryData output = null) { throw null; }
        public static Azure.AI.Agents.AgentTool AgentTool(string type = null) { throw null; }
        public static Azure.AI.Agents.AgentUpdateOptions AgentUpdateOptions(System.Collections.Generic.IDictionary<string, string> metadata = null, string description = null, Azure.AI.Agents.AgentDefinition definition = null) { throw null; }
        public static Azure.AI.Agents.AgentVersion AgentVersion(System.Collections.Generic.IDictionary<string, string> metadata = null, string id = null, string name = null, string version = null, string description = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), Azure.AI.Agents.AgentDefinition definition = null) { throw null; }
        public static Azure.AI.Agents.AgentVersionCreationOptions AgentVersionCreationOptions(System.Collections.Generic.IDictionary<string, string> metadata = null, string description = null, Azure.AI.Agents.AgentDefinition definition = null) { throw null; }
        public static Azure.AI.Agents.AgentWorkflowActionResponseItem AgentWorkflowActionResponseItem(string id = null, Azure.AI.Agents.CreatedBy createdBy = null, string actionId = null, string parentActionId = null, string previousActionId = null, Azure.AI.Agents.AgentWorkflowActionStatus? status = default(Azure.AI.Agents.AgentWorkflowActionStatus?)) { throw null; }
        public static Azure.AI.Agents.ApiInnerError ApiInnerError(string code = null, Azure.AI.Agents.ApiInnerError innererror = null) { throw null; }
        public static Azure.AI.Agents.AzureAISearchAgentTool AzureAISearchAgentTool(Azure.AI.Agents.AzureAISearchToolOptions options = null) { throw null; }
        public static Azure.AI.Agents.AzureAISearchIndex AzureAISearchIndex(string projectConnectionId = null, string indexName = null, Azure.AI.Agents.AzureAISearchQueryType? queryType = default(Azure.AI.Agents.AzureAISearchQueryType?), int? topK = default(int?), string filter = null, string indexAssetId = null) { throw null; }
        public static Azure.AI.Agents.AzureAISearchToolOptions AzureAISearchToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Agents.AzureAISearchIndex> indexes = null) { throw null; }
        public static Azure.AI.Agents.AzureFunctionAgentTool AzureFunctionAgentTool(Azure.AI.Agents.AzureFunctionDefinition azureFunction = null) { throw null; }
        public static Azure.AI.Agents.AzureFunctionBinding AzureFunctionBinding(Azure.AI.Agents.AzureFunctionStorageQueue storageQueue = null) { throw null; }
        public static Azure.AI.Agents.AzureFunctionDefinition AzureFunctionDefinition(Azure.AI.Agents.AzureFunctionDefinitionFunction function = null, Azure.AI.Agents.AzureFunctionBinding inputBinding = null, Azure.AI.Agents.AzureFunctionBinding outputBinding = null) { throw null; }
        public static Azure.AI.Agents.AzureFunctionDefinitionFunction AzureFunctionDefinitionFunction(string name = null, string description = null, System.BinaryData parameters = null) { throw null; }
        public static Azure.AI.Agents.AzureFunctionStorageQueue AzureFunctionStorageQueue(string queueServiceEndpoint = null, string queueName = null) { throw null; }
        public static Azure.AI.Agents.BingCustomSearchAgentTool BingCustomSearchAgentTool(Azure.AI.Agents.BingCustomSearchToolParameters bingCustomSearchPreview = null) { throw null; }
        public static Azure.AI.Agents.BingCustomSearchConfiguration BingCustomSearchConfiguration(string projectConnectionId = null, string instanceName = null, string market = null, string setLang = null, long? count = default(long?), string freshness = null) { throw null; }
        public static Azure.AI.Agents.BingCustomSearchToolParameters BingCustomSearchToolParameters(System.Collections.Generic.IEnumerable<Azure.AI.Agents.BingCustomSearchConfiguration> searchConfigurations = null) { throw null; }
        public static Azure.AI.Agents.BingGroundingAgentTool BingGroundingAgentTool(Azure.AI.Agents.BingGroundingSearchToolParameters bingGrounding = null) { throw null; }
        public static Azure.AI.Agents.BingGroundingSearchConfiguration BingGroundingSearchConfiguration(string projectConnectionId = null, string market = null, string setLang = null, long? count = default(long?), string freshness = null) { throw null; }
        public static Azure.AI.Agents.BingGroundingSearchToolParameters BingGroundingSearchToolParameters(System.Collections.Generic.IEnumerable<Azure.AI.Agents.BingGroundingSearchConfiguration> searchConfigurations = null) { throw null; }
        public static Azure.AI.Agents.BrowserAutomationAgentTool BrowserAutomationAgentTool(Azure.AI.Agents.BrowserAutomationToolParameters browserAutomationPreview = null) { throw null; }
        public static Azure.AI.Agents.BrowserAutomationToolConnectionParameters BrowserAutomationToolConnectionParameters(string id = null) { throw null; }
        public static Azure.AI.Agents.BrowserAutomationToolParameters BrowserAutomationToolParameters(Azure.AI.Agents.BrowserAutomationToolConnectionParameters projectConnection = null) { throw null; }
        public static Azure.AI.Agents.CaptureStructuredOutputsTool CaptureStructuredOutputsTool(Azure.AI.Agents.StructuredOutputDefinition outputs = null) { throw null; }
        public static Azure.AI.Agents.ChatSummaryMemoryItem ChatSummaryMemoryItem(string memoryId = null, System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string scope = null, string content = null) { throw null; }
        public static Azure.AI.Agents.ContainerAppAgentDefinition ContainerAppAgentDefinition(Azure.AI.Agents.RaiConfig raiConfig = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.ProtocolVersionRecord> containerProtocolVersions = null, string containerAppResourceId = null, string ingressSubdomainSuffix = null) { throw null; }
        public static Azure.AI.Agents.CreatedBy CreatedBy(Azure.AI.Agents.AgentInfo agent = null, string responseId = null) { throw null; }
        public static Azure.AI.Agents.DeleteAgentVersionResponse DeleteAgentVersionResponse(string name = null, string version = null, bool deleted = false) { throw null; }
        public static Azure.AI.Agents.DeleteMemoryStoreResponse DeleteMemoryStoreResponse(string name = null, bool deleted = false) { throw null; }
        public static Azure.AI.Agents.FabricDataAgentToolParameters FabricDataAgentToolParameters(System.Collections.Generic.IEnumerable<Azure.AI.Agents.ToolProjectConnection> projectConnections = null) { throw null; }
        public static Azure.AI.Agents.HostedAgentDefinition HostedAgentDefinition(Azure.AI.Agents.RaiConfig raiConfig = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.AgentTool> tools = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.ProtocolVersionRecord> containerProtocolVersions = null, string cpu = null, string memory = null, System.Collections.Generic.IDictionary<string, string> environmentVariables = null) { throw null; }
        public static Azure.AI.Agents.ImageBasedHostedAgentDefinition ImageBasedHostedAgentDefinition(Azure.AI.Agents.RaiConfig raiConfig = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.AgentTool> tools = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.ProtocolVersionRecord> containerProtocolVersions = null, string cpu = null, string memory = null, System.Collections.Generic.IDictionary<string, string> environmentVariables = null, string image = null) { throw null; }
        public static Azure.AI.Agents.InvokeAzureAgentWorkflowActionOutputItemResource InvokeAzureAgentWorkflowActionOutputItemResource(string id = null, Azure.AI.Agents.CreatedBy createdBy = null, string actionId = null, string parentActionId = null, string previousActionId = null, Azure.AI.Agents.AgentWorkflowActionStatus? status = default(Azure.AI.Agents.AgentWorkflowActionStatus?), Azure.AI.Agents.AgentInfo agent = null, string conversationId = null, string responseId = null) { throw null; }
        public static Azure.AI.Agents.MemoryItem MemoryItem(string memoryId = null, System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string scope = null, string content = null, string kind = null) { throw null; }
        public static Azure.AI.Agents.MemoryOperation MemoryOperation(Azure.AI.Agents.MemoryOperationKind kind = default(Azure.AI.Agents.MemoryOperationKind), Azure.AI.Agents.MemoryItem memoryItem = null) { throw null; }
        public static Azure.AI.Agents.MemorySearchItem MemorySearchItem(Azure.AI.Agents.MemoryItem memoryItem = null) { throw null; }
        public static Azure.AI.Agents.MemorySearchTool MemorySearchTool(string memoryStoreName = null, string scope = null, Azure.AI.Agents.MemorySearchOptions searchOptions = null, System.TimeSpan? updateDelay = default(System.TimeSpan?)) { throw null; }
        public static Azure.AI.Agents.MemorySearchToolCallItemResource MemorySearchToolCallItemResource(string id = null, Azure.AI.Agents.CreatedBy createdBy = null, Azure.AI.Agents.MemorySearchToolCallItemResourceStatus status = Azure.AI.Agents.MemorySearchToolCallItemResourceStatus.InProgress, System.Collections.Generic.IEnumerable<Azure.AI.Agents.MemorySearchItem> results = null) { throw null; }
        public static Azure.AI.Agents.MemoryStoreDefaultDefinition MemoryStoreDefaultDefinition(string chatModel = null, string embeddingModel = null, Azure.AI.Agents.MemoryStoreDefaultOptions options = null) { throw null; }
        public static Azure.AI.Agents.MemoryStoreDefaultOptions MemoryStoreDefaultOptions(bool userProfileEnabled = false, string userProfileDetails = null, bool chatSummaryEnabled = false) { throw null; }
        public static Azure.AI.Agents.MemoryStoreDefinition MemoryStoreDefinition(string kind = null) { throw null; }
        public static Azure.AI.Agents.MemoryStoreDeleteScopeResponse MemoryStoreDeleteScopeResponse(string name = null, string scope = null, bool deleted = false) { throw null; }
        public static Azure.AI.Agents.MemoryStoreObject MemoryStoreObject(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string name = null, string description = null, System.Collections.Generic.IDictionary<string, string> metadata = null, Azure.AI.Agents.MemoryStoreDefinition definition = null) { throw null; }
        public static Azure.AI.Agents.MemoryStoreOperationUsage MemoryStoreOperationUsage(int embeddingTokens = 0, int inputTokens = 0, OpenAI.MemoryStoreOperationUsageInputTokensDetails inputTokensDetails = null, int outputTokens = 0, OpenAI.MemoryStoreOperationUsageOutputTokensDetails outputTokensDetails = null, int totalTokens = 0) { throw null; }
        public static OpenAI.MemoryStoreOperationUsageInputTokensDetails MemoryStoreOperationUsageInputTokensDetails(int cachedTokens = 0) { throw null; }
        public static OpenAI.MemoryStoreOperationUsageOutputTokensDetails MemoryStoreOperationUsageOutputTokensDetails(int reasoningTokens = 0) { throw null; }
        public static Azure.AI.Agents.MemoryStoreSearchResponse MemoryStoreSearchResponse(string searchId = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.MemorySearchItem> memories = null, Azure.AI.Agents.MemoryStoreOperationUsage usage = null) { throw null; }
        public static Azure.AI.Agents.MemoryUpdateResult MemoryUpdateResult(string updateId = null, Azure.AI.Agents.MemoryStoreUpdateStatus status = Azure.AI.Agents.MemoryStoreUpdateStatus.Queued, string supersededBy = null, Azure.AI.Agents.MemoryUpdateResultDetails details = null, Azure.AI.Agents.AgentsApiError error = null) { throw null; }
        public static Azure.AI.Agents.MemoryUpdateResultDetails MemoryUpdateResultDetails(System.Collections.Generic.IEnumerable<Azure.AI.Agents.MemoryOperation> memoryOperations = null, Azure.AI.Agents.MemoryStoreOperationUsage usage = null) { throw null; }
        public static Azure.AI.Agents.MicrosoftFabricAgentTool MicrosoftFabricAgentTool(Azure.AI.Agents.FabricDataAgentToolParameters fabricDataagentPreview = null) { throw null; }
        public static Azure.AI.Agents.OAuthConsentRequestItemResource OAuthConsentRequestItemResource(Azure.AI.Agents.CreatedBy createdBy = null, string id = null, string consentLink = null, string serverLabel = null) { throw null; }
        public static Azure.AI.Agents.OpenApiAgentTool OpenApiAgentTool(Azure.AI.Agents.OpenApiFunctionDefinition openapi = null) { throw null; }
        public static Azure.AI.Agents.OpenApiAnonymousAuthDetails OpenApiAnonymousAuthDetails() { throw null; }
        public static Azure.AI.Agents.OpenApiAuthDetails OpenApiAuthDetails(string type = null) { throw null; }
        public static Azure.AI.Agents.OpenApiFunctionDefinition OpenApiFunctionDefinition(string name = null, string description = null, System.BinaryData spec = null, Azure.AI.Agents.OpenApiAuthDetails auth = null, System.Collections.Generic.IEnumerable<string> defaultParams = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.OpenApiFunctionDefinitionFunction> functions = null) { throw null; }
        public static Azure.AI.Agents.OpenApiFunctionDefinitionFunction OpenApiFunctionDefinitionFunction(string name = null, string description = null, System.BinaryData parameters = null) { throw null; }
        public static Azure.AI.Agents.OpenApiManagedAuthDetails OpenApiManagedAuthDetails(Azure.AI.Agents.OpenApiManagedSecurityScheme securityScheme = null) { throw null; }
        public static Azure.AI.Agents.OpenApiManagedSecurityScheme OpenApiManagedSecurityScheme(string audience = null) { throw null; }
        public static Azure.AI.Agents.OpenApiProjectConnectionAuthDetails OpenApiProjectConnectionAuthDetails(Azure.AI.Agents.OpenApiProjectConnectionSecurityScheme securityScheme = null) { throw null; }
        public static Azure.AI.Agents.OpenApiProjectConnectionSecurityScheme OpenApiProjectConnectionSecurityScheme(string projectConnectionId = null) { throw null; }
        public static Azure.AI.Agents.ProtocolVersionRecord ProtocolVersionRecord(Azure.AI.Agents.AgentCommunicationMethod protocol = default(Azure.AI.Agents.AgentCommunicationMethod), string version = null) { throw null; }
        public static Azure.AI.Agents.RaiConfig RaiConfig(string raiPolicyName = null) { throw null; }
        public static Azure.AI.Agents.SharepointAgentTool SharepointAgentTool(Azure.AI.Agents.SharepointGroundingToolParameters sharepointGroundingPreview = null) { throw null; }
        public static Azure.AI.Agents.SharepointGroundingToolParameters SharepointGroundingToolParameters(System.Collections.Generic.IEnumerable<Azure.AI.Agents.ToolProjectConnection> projectConnections = null) { throw null; }
        public static Azure.AI.Agents.StructuredInputDefinition StructuredInputDefinition(string description = null, System.BinaryData defaultValue = null, System.Collections.Generic.IEnumerable<Azure.AI.Agents.ToolArgumentBinding> toolArgumentBindings = null, System.BinaryData schema = null, bool? required = default(bool?)) { throw null; }
        public static Azure.AI.Agents.StructuredOutputDefinition StructuredOutputDefinition(string name = null, string description = null, System.Collections.Generic.IDictionary<string, System.BinaryData> schema = null, bool? strict = default(bool?)) { throw null; }
        public static Azure.AI.Agents.ToolArgumentBinding ToolArgumentBinding(string toolName = null, string argumentName = null) { throw null; }
        public static Azure.AI.Agents.ToolProjectConnection ToolProjectConnection(string projectConnectionId = null) { throw null; }
        public static Azure.AI.Agents.UserProfileMemoryItem UserProfileMemoryItem(string memoryId = null, System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string scope = null, string content = null) { throw null; }
        public static Azure.AI.Agents.WorkflowAgentDefinition WorkflowAgentDefinition(Azure.AI.Agents.RaiConfig raiConfig = null, string workflowYaml = null) { throw null; }
    }
    public partial class AzureAISearchAgentTool : Azure.AI.Agents.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureAISearchAgentTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureAISearchAgentTool>
    {
        public AzureAISearchAgentTool() { }
        public AzureAISearchAgentTool(Azure.AI.Agents.AzureAISearchToolOptions options) { }
        public Azure.AI.Agents.AzureAISearchToolOptions Options { get { throw null; } set { } }
        protected override Azure.AI.Agents.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Agents.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AzureAISearchAgentTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureAISearchAgentTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureAISearchAgentTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AzureAISearchAgentTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureAISearchAgentTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureAISearchAgentTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureAISearchAgentTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAISearchIndex : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureAISearchIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureAISearchIndex>
    {
        public AzureAISearchIndex(string projectConnectionId) { }
        public string Filter { get { throw null; } set { } }
        public string IndexAssetId { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public Azure.AI.Agents.AzureAISearchQueryType? QueryType { get { throw null; } set { } }
        public int? TopK { get { throw null; } set { } }
        protected virtual Azure.AI.Agents.AzureAISearchIndex JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.AzureAISearchIndex PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AzureAISearchIndex System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureAISearchIndex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureAISearchIndex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AzureAISearchIndex System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureAISearchIndex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureAISearchIndex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureAISearchIndex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureAISearchQueryType : System.IEquatable<Azure.AI.Agents.AzureAISearchQueryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureAISearchQueryType(string value) { throw null; }
        public static Azure.AI.Agents.AzureAISearchQueryType Semantic { get { throw null; } }
        public static Azure.AI.Agents.AzureAISearchQueryType Simple { get { throw null; } }
        public static Azure.AI.Agents.AzureAISearchQueryType Vector { get { throw null; } }
        public static Azure.AI.Agents.AzureAISearchQueryType VectorSemanticHybrid { get { throw null; } }
        public static Azure.AI.Agents.AzureAISearchQueryType VectorSimpleHybrid { get { throw null; } }
        public bool Equals(Azure.AI.Agents.AzureAISearchQueryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.AzureAISearchQueryType left, Azure.AI.Agents.AzureAISearchQueryType right) { throw null; }
        public static implicit operator Azure.AI.Agents.AzureAISearchQueryType (string value) { throw null; }
        public static implicit operator Azure.AI.Agents.AzureAISearchQueryType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.AzureAISearchQueryType left, Azure.AI.Agents.AzureAISearchQueryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureAISearchToolOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureAISearchToolOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureAISearchToolOptions>
    {
        public AzureAISearchToolOptions() { }
        public System.Collections.Generic.IList<Azure.AI.Agents.AzureAISearchIndex> Indexes { get { throw null; } }
        protected virtual Azure.AI.Agents.AzureAISearchToolOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.AzureAISearchToolOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AzureAISearchToolOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureAISearchToolOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureAISearchToolOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AzureAISearchToolOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureAISearchToolOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureAISearchToolOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureAISearchToolOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionAgentTool : Azure.AI.Agents.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureFunctionAgentTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionAgentTool>
    {
        public AzureFunctionAgentTool(Azure.AI.Agents.AzureFunctionDefinition azureFunction) { }
        public Azure.AI.Agents.AzureFunctionDefinition AzureFunction { get { throw null; } set { } }
        protected override Azure.AI.Agents.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Agents.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AzureFunctionAgentTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureFunctionAgentTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureFunctionAgentTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AzureFunctionAgentTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionAgentTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionAgentTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionAgentTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionBinding : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureFunctionBinding>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionBinding>
    {
        public AzureFunctionBinding(Azure.AI.Agents.AzureFunctionStorageQueue storageQueue) { }
        public Azure.AI.Agents.AzureFunctionStorageQueue StorageQueue { get { throw null; } set { } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.Agents.AzureFunctionBinding JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.AzureFunctionBinding PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AzureFunctionBinding System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureFunctionBinding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureFunctionBinding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AzureFunctionBinding System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionBinding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionBinding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionBinding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureFunctionDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionDefinition>
    {
        public AzureFunctionDefinition(Azure.AI.Agents.AzureFunctionDefinitionFunction function, Azure.AI.Agents.AzureFunctionBinding inputBinding, Azure.AI.Agents.AzureFunctionBinding outputBinding) { }
        public Azure.AI.Agents.AzureFunctionDefinitionFunction Function { get { throw null; } set { } }
        public Azure.AI.Agents.AzureFunctionBinding InputBinding { get { throw null; } set { } }
        public Azure.AI.Agents.AzureFunctionBinding OutputBinding { get { throw null; } set { } }
        protected virtual Azure.AI.Agents.AzureFunctionDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.AzureFunctionDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AzureFunctionDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureFunctionDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureFunctionDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AzureFunctionDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionDefinitionFunction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureFunctionDefinitionFunction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionDefinitionFunction>
    {
        public AzureFunctionDefinitionFunction(string name, System.BinaryData parameters) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Parameters { get { throw null; } set { } }
        protected virtual Azure.AI.Agents.AzureFunctionDefinitionFunction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.AzureFunctionDefinitionFunction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AzureFunctionDefinitionFunction System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureFunctionDefinitionFunction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureFunctionDefinitionFunction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AzureFunctionDefinitionFunction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionDefinitionFunction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionDefinitionFunction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionDefinitionFunction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionStorageQueue : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureFunctionStorageQueue>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionStorageQueue>
    {
        public AzureFunctionStorageQueue(string queueServiceEndpoint, string queueName) { }
        public string QueueName { get { throw null; } set { } }
        public string QueueServiceEndpoint { get { throw null; } set { } }
        protected virtual Azure.AI.Agents.AzureFunctionStorageQueue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.AzureFunctionStorageQueue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.AzureFunctionStorageQueue System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureFunctionStorageQueue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.AzureFunctionStorageQueue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.AzureFunctionStorageQueue System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionStorageQueue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionStorageQueue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.AzureFunctionStorageQueue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingCustomSearchAgentTool : Azure.AI.Agents.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.BingCustomSearchAgentTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BingCustomSearchAgentTool>
    {
        public BingCustomSearchAgentTool(Azure.AI.Agents.BingCustomSearchToolParameters bingCustomSearchPreview) { }
        public Azure.AI.Agents.BingCustomSearchToolParameters BingCustomSearchPreview { get { throw null; } set { } }
        protected override Azure.AI.Agents.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Agents.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.BingCustomSearchAgentTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.BingCustomSearchAgentTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.BingCustomSearchAgentTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.BingCustomSearchAgentTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BingCustomSearchAgentTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BingCustomSearchAgentTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BingCustomSearchAgentTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingCustomSearchConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.BingCustomSearchConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BingCustomSearchConfiguration>
    {
        public BingCustomSearchConfiguration(string projectConnectionId, string instanceName) { }
        public long? Count { get { throw null; } set { } }
        public string Freshness { get { throw null; } set { } }
        public string InstanceName { get { throw null; } set { } }
        public string Market { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public string SetLang { get { throw null; } set { } }
        protected virtual Azure.AI.Agents.BingCustomSearchConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.BingCustomSearchConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.BingCustomSearchConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.BingCustomSearchConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.BingCustomSearchConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.BingCustomSearchConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BingCustomSearchConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BingCustomSearchConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BingCustomSearchConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingCustomSearchToolParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.BingCustomSearchToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BingCustomSearchToolParameters>
    {
        public BingCustomSearchToolParameters(System.Collections.Generic.IEnumerable<Azure.AI.Agents.BingCustomSearchConfiguration> searchConfigurations) { }
        public System.Collections.Generic.IList<Azure.AI.Agents.BingCustomSearchConfiguration> SearchConfigurations { get { throw null; } }
        protected virtual Azure.AI.Agents.BingCustomSearchToolParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.BingCustomSearchToolParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.BingCustomSearchToolParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.BingCustomSearchToolParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.BingCustomSearchToolParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.BingCustomSearchToolParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BingCustomSearchToolParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BingCustomSearchToolParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BingCustomSearchToolParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingGroundingAgentTool : Azure.AI.Agents.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.BingGroundingAgentTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BingGroundingAgentTool>
    {
        public BingGroundingAgentTool(Azure.AI.Agents.BingGroundingSearchToolParameters bingGrounding) { }
        public Azure.AI.Agents.BingGroundingSearchToolParameters BingGrounding { get { throw null; } set { } }
        protected override Azure.AI.Agents.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Agents.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.BingGroundingAgentTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.BingGroundingAgentTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.BingGroundingAgentTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.BingGroundingAgentTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BingGroundingAgentTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BingGroundingAgentTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BingGroundingAgentTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingGroundingSearchConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.BingGroundingSearchConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BingGroundingSearchConfiguration>
    {
        public BingGroundingSearchConfiguration(string projectConnectionId) { }
        public long? Count { get { throw null; } set { } }
        public string Freshness { get { throw null; } set { } }
        public string Market { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public string SetLang { get { throw null; } set { } }
        protected virtual Azure.AI.Agents.BingGroundingSearchConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.BingGroundingSearchConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.BingGroundingSearchConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.BingGroundingSearchConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.BingGroundingSearchConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.BingGroundingSearchConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BingGroundingSearchConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BingGroundingSearchConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BingGroundingSearchConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingGroundingSearchToolParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.BingGroundingSearchToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BingGroundingSearchToolParameters>
    {
        public BingGroundingSearchToolParameters(System.Collections.Generic.IEnumerable<Azure.AI.Agents.BingGroundingSearchConfiguration> searchConfigurations) { }
        public System.Collections.Generic.IList<Azure.AI.Agents.BingGroundingSearchConfiguration> SearchConfigurations { get { throw null; } }
        protected virtual Azure.AI.Agents.BingGroundingSearchToolParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.BingGroundingSearchToolParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.BingGroundingSearchToolParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.BingGroundingSearchToolParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.BingGroundingSearchToolParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.BingGroundingSearchToolParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BingGroundingSearchToolParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BingGroundingSearchToolParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BingGroundingSearchToolParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrowserAutomationAgentTool : Azure.AI.Agents.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.BrowserAutomationAgentTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BrowserAutomationAgentTool>
    {
        public BrowserAutomationAgentTool(Azure.AI.Agents.BrowserAutomationToolParameters browserAutomationPreview) { }
        public Azure.AI.Agents.BrowserAutomationToolParameters BrowserAutomationPreview { get { throw null; } set { } }
        protected override Azure.AI.Agents.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Agents.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.BrowserAutomationAgentTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.BrowserAutomationAgentTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.BrowserAutomationAgentTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.BrowserAutomationAgentTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BrowserAutomationAgentTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BrowserAutomationAgentTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BrowserAutomationAgentTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrowserAutomationToolConnectionParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.BrowserAutomationToolConnectionParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BrowserAutomationToolConnectionParameters>
    {
        public BrowserAutomationToolConnectionParameters(string id) { }
        public string Id { get { throw null; } set { } }
        protected virtual Azure.AI.Agents.BrowserAutomationToolConnectionParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.BrowserAutomationToolConnectionParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.BrowserAutomationToolConnectionParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.BrowserAutomationToolConnectionParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.BrowserAutomationToolConnectionParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.BrowserAutomationToolConnectionParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BrowserAutomationToolConnectionParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BrowserAutomationToolConnectionParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BrowserAutomationToolConnectionParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrowserAutomationToolParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.BrowserAutomationToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BrowserAutomationToolParameters>
    {
        public BrowserAutomationToolParameters(Azure.AI.Agents.BrowserAutomationToolConnectionParameters projectConnection) { }
        public Azure.AI.Agents.BrowserAutomationToolConnectionParameters ProjectConnection { get { throw null; } set { } }
        protected virtual Azure.AI.Agents.BrowserAutomationToolParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.BrowserAutomationToolParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.BrowserAutomationToolParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.BrowserAutomationToolParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.BrowserAutomationToolParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.BrowserAutomationToolParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BrowserAutomationToolParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BrowserAutomationToolParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.BrowserAutomationToolParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CaptureStructuredOutputsTool : Azure.AI.Agents.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.CaptureStructuredOutputsTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.CaptureStructuredOutputsTool>
    {
        public CaptureStructuredOutputsTool(Azure.AI.Agents.StructuredOutputDefinition outputs) { }
        public Azure.AI.Agents.StructuredOutputDefinition Outputs { get { throw null; } set { } }
        protected override Azure.AI.Agents.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Agents.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.CaptureStructuredOutputsTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.CaptureStructuredOutputsTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.CaptureStructuredOutputsTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.CaptureStructuredOutputsTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.CaptureStructuredOutputsTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.CaptureStructuredOutputsTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.CaptureStructuredOutputsTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatSummaryMemoryItem : Azure.AI.Agents.MemoryItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ChatSummaryMemoryItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ChatSummaryMemoryItem>
    {
        public ChatSummaryMemoryItem(string memoryId, System.DateTimeOffset updatedAt, string scope, string content) { }
        protected override Azure.AI.Agents.MemoryItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Agents.MemoryItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.ChatSummaryMemoryItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ChatSummaryMemoryItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ChatSummaryMemoryItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.ChatSummaryMemoryItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ChatSummaryMemoryItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ChatSummaryMemoryItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ChatSummaryMemoryItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ClientConnectionProviderExtensions
    {
        public static Azure.AI.Agents.AgentsClient GetAgentsClient(this System.ClientModel.Primitives.ClientConnectionProvider clientConnectionProvider, Azure.AI.Agents.AgentsClientOptions agentsClientOptions = null) { throw null; }
    }
    public partial class ContainerAppAgentDefinition : Azure.AI.Agents.AgentDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ContainerAppAgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ContainerAppAgentDefinition>
    {
        public ContainerAppAgentDefinition(System.Collections.Generic.IEnumerable<Azure.AI.Agents.ProtocolVersionRecord> containerProtocolVersions, string containerAppResourceId, string ingressSubdomainSuffix) { }
        public string ContainerAppResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Agents.ProtocolVersionRecord> ContainerProtocolVersions { get { throw null; } }
        public string IngressSubdomainSuffix { get { throw null; } set { } }
        protected override Azure.AI.Agents.AgentDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Agents.AgentDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.ContainerAppAgentDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ContainerAppAgentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ContainerAppAgentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.ContainerAppAgentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ContainerAppAgentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ContainerAppAgentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ContainerAppAgentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConversationClient
    {
        protected ConversationClient() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.AgentConversation> CreateConversation(Azure.AI.Agents.AgentConversationCreationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult CreateConversation(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.AgentConversation>> CreateConversationAsync(Azure.AI.Agents.AgentConversationCreationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateConversationAsync(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult CreateConversationItems(string conversationId, System.ClientModel.BinaryContent content, System.Collections.Generic.IEnumerable<string> include = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<System.Collections.ObjectModel.ReadOnlyCollection<OpenAI.Responses.ResponseItem>> CreateConversationItems(string conversationId, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> items, System.Collections.Generic.IEnumerable<string> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateConversationItemsAsync(string conversationId, System.ClientModel.BinaryContent content, System.Collections.Generic.IEnumerable<string> include = null, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<System.Collections.ObjectModel.ReadOnlyCollection<OpenAI.Responses.ResponseItem>>> CreateConversationItemsAsync(string conversationId, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> items, System.Collections.Generic.IEnumerable<string> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteConversation(string conversationId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.AgentConversationDeletionResult> DeleteConversation(string conversationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteConversationAsync(string conversationId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.AgentConversationDeletionResult>> DeleteConversationAsync(string conversationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteConversationItem(string conversationId, string itemId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.AgentConversation> DeleteConversationItem(string conversationId, string itemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteConversationItemAsync(string conversationId, string itemId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.AgentConversation>> DeleteConversationItemAsync(string conversationId, string itemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetConversation(string conversationId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.AgentConversation> GetConversation(string conversationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetConversationAsync(string conversationId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.AgentConversation>> GetConversationAsync(string conversationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetConversationItem(string conversationId, string itemId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.AgentResponseItem> GetConversationItem(string conversationId, string itemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetConversationItemAsync(string conversationId, string itemId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.AgentResponseItem>> GetConversationItemAsync(string conversationId, string itemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Agents.AgentResponseItem> GetConversationItems(string conversationId, int? limit = default(int?), Azure.AI.Agents.AgentsListOrder? order = default(Azure.AI.Agents.AgentsListOrder?), string after = null, string before = null, Azure.AI.Agents.AgentResponseItemKind? itemType = default(Azure.AI.Agents.AgentResponseItemKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Agents.AgentResponseItem> GetConversationItemsAsync(string conversationId, int? limit = default(int?), Azure.AI.Agents.AgentsListOrder? order = default(Azure.AI.Agents.AgentsListOrder?), string after = null, string before = null, Azure.AI.Agents.AgentResponseItemKind? itemType = default(Azure.AI.Agents.AgentResponseItemKind?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Agents.AgentConversation> GetConversations(int? limit = default(int?), Azure.AI.Agents.AgentsListOrder? order = default(Azure.AI.Agents.AgentsListOrder?), string after = null, string before = null, string agentName = null, string agentId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Agents.AgentConversation> GetConversationsAsync(int? limit = default(int?), Azure.AI.Agents.AgentsListOrder? order = default(Azure.AI.Agents.AgentsListOrder?), string after = null, string before = null, string agentName = null, string agentId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.AgentConversation> UpdateConversation(string conversationId, Azure.AI.Agents.AgentConversationUpdateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult UpdateConversation(string conversationId, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.AgentConversation>> UpdateConversationAsync(string conversationId, Azure.AI.Agents.AgentConversationUpdateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> UpdateConversationAsync(string conversationId, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
    }
    public partial class CreatedBy : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.CreatedBy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.CreatedBy>
    {
        internal CreatedBy() { }
        public Azure.AI.Agents.AgentInfo Agent { get { throw null; } }
        public string ResponseId { get { throw null; } }
        protected virtual Azure.AI.Agents.CreatedBy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.CreatedBy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.CreatedBy System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.CreatedBy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.CreatedBy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.CreatedBy System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.CreatedBy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.CreatedBy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.CreatedBy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeleteAgentVersionResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.DeleteAgentVersionResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.DeleteAgentVersionResponse>
    {
        internal DeleteAgentVersionResponse() { }
        public bool Deleted { get { throw null; } }
        public string Name { get { throw null; } }
        public string Object { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Agents.DeleteAgentVersionResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Agents.DeleteAgentVersionResponse (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Agents.DeleteAgentVersionResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.DeleteAgentVersionResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.DeleteAgentVersionResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.DeleteAgentVersionResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.DeleteAgentVersionResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.DeleteAgentVersionResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.DeleteAgentVersionResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.DeleteAgentVersionResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeleteMemoryStoreResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.DeleteMemoryStoreResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.DeleteMemoryStoreResponse>
    {
        internal DeleteMemoryStoreResponse() { }
        public bool Deleted { get { throw null; } }
        public string Name { get { throw null; } }
        public string Object { get { throw null; } }
        protected virtual Azure.AI.Agents.DeleteMemoryStoreResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Agents.DeleteMemoryStoreResponse (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Agents.DeleteMemoryStoreResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.DeleteMemoryStoreResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.DeleteMemoryStoreResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.DeleteMemoryStoreResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.DeleteMemoryStoreResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.DeleteMemoryStoreResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.DeleteMemoryStoreResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.DeleteMemoryStoreResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FabricDataAgentToolParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.FabricDataAgentToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FabricDataAgentToolParameters>
    {
        public FabricDataAgentToolParameters() { }
        public System.Collections.Generic.IList<Azure.AI.Agents.ToolProjectConnection> ProjectConnections { get { throw null; } }
        protected virtual Azure.AI.Agents.FabricDataAgentToolParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.FabricDataAgentToolParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.FabricDataAgentToolParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.FabricDataAgentToolParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.FabricDataAgentToolParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.FabricDataAgentToolParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FabricDataAgentToolParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FabricDataAgentToolParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.FabricDataAgentToolParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HostedAgentDefinition : Azure.AI.Agents.AgentDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.HostedAgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.HostedAgentDefinition>
    {
        public HostedAgentDefinition(System.Collections.Generic.IEnumerable<Azure.AI.Agents.ProtocolVersionRecord> containerProtocolVersions, string cpu, string memory) { }
        public System.Collections.Generic.IList<Azure.AI.Agents.ProtocolVersionRecord> ContainerProtocolVersions { get { throw null; } }
        public string Cpu { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } }
        public string Memory { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Agents.AgentTool> Tools { get { throw null; } }
        protected override Azure.AI.Agents.AgentDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Agents.AgentDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.HostedAgentDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.HostedAgentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.HostedAgentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.HostedAgentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.HostedAgentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.HostedAgentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.HostedAgentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageBasedHostedAgentDefinition : Azure.AI.Agents.HostedAgentDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ImageBasedHostedAgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ImageBasedHostedAgentDefinition>
    {
        public ImageBasedHostedAgentDefinition(System.Collections.Generic.IEnumerable<Azure.AI.Agents.ProtocolVersionRecord> containerProtocolVersions, string cpu, string memory, string image) : base (default(System.Collections.Generic.IEnumerable<Azure.AI.Agents.ProtocolVersionRecord>), default(string), default(string)) { }
        public string Image { get { throw null; } set { } }
        protected override Azure.AI.Agents.AgentDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Agents.AgentDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.ImageBasedHostedAgentDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ImageBasedHostedAgentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ImageBasedHostedAgentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.ImageBasedHostedAgentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ImageBasedHostedAgentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ImageBasedHostedAgentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ImageBasedHostedAgentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InvokeAzureAgentWorkflowActionOutputItemResource : Azure.AI.Agents.AgentWorkflowActionResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.InvokeAzureAgentWorkflowActionOutputItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.InvokeAzureAgentWorkflowActionOutputItemResource>
    {
        internal InvokeAzureAgentWorkflowActionOutputItemResource() { }
        public Azure.AI.Agents.AgentInfo Agent { get { throw null; } }
        public string ConversationId { get { throw null; } }
        public string ResponseId { get { throw null; } }
        protected override Azure.AI.Agents.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Agents.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.InvokeAzureAgentWorkflowActionOutputItemResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.InvokeAzureAgentWorkflowActionOutputItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.InvokeAzureAgentWorkflowActionOutputItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.InvokeAzureAgentWorkflowActionOutputItemResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.InvokeAzureAgentWorkflowActionOutputItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.InvokeAzureAgentWorkflowActionOutputItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.InvokeAzureAgentWorkflowActionOutputItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MemoryItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryItem>
    {
        internal MemoryItem() { }
        public string Content { get { throw null; } set { } }
        public string MemoryId { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public System.DateTimeOffset UpdatedAt { get { throw null; } set { } }
        protected virtual Azure.AI.Agents.MemoryItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.MemoryItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.MemoryItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MemoryItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemoryOperation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryOperation>
    {
        internal MemoryOperation() { }
        public Azure.AI.Agents.MemoryOperationKind Kind { get { throw null; } }
        public Azure.AI.Agents.MemoryItem MemoryItem { get { throw null; } }
        protected virtual Azure.AI.Agents.MemoryOperation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.MemoryOperation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.MemoryOperation System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MemoryOperation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MemoryOperationKind : System.IEquatable<Azure.AI.Agents.MemoryOperationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MemoryOperationKind(string value) { throw null; }
        public static Azure.AI.Agents.MemoryOperationKind Create { get { throw null; } }
        public static Azure.AI.Agents.MemoryOperationKind Delete { get { throw null; } }
        public static Azure.AI.Agents.MemoryOperationKind Update { get { throw null; } }
        public bool Equals(Azure.AI.Agents.MemoryOperationKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Agents.MemoryOperationKind left, Azure.AI.Agents.MemoryOperationKind right) { throw null; }
        public static implicit operator Azure.AI.Agents.MemoryOperationKind (string value) { throw null; }
        public static implicit operator Azure.AI.Agents.MemoryOperationKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Agents.MemoryOperationKind left, Azure.AI.Agents.MemoryOperationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MemorySearchItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemorySearchItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemorySearchItem>
    {
        public MemorySearchItem(Azure.AI.Agents.MemoryItem memoryItem) { }
        public Azure.AI.Agents.MemoryItem MemoryItem { get { throw null; } set { } }
        protected virtual Azure.AI.Agents.MemorySearchItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.MemorySearchItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.MemorySearchItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemorySearchItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemorySearchItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MemorySearchItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemorySearchItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemorySearchItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemorySearchItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemorySearchOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemorySearchOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemorySearchOptions>
    {
        public MemorySearchOptions() { }
        public System.Collections.Generic.IList<OpenAI.Responses.ResponseItem> Items { get { throw null; } }
        public int? MaxMemories { get { throw null; } set { } }
        protected virtual Azure.AI.Agents.MemorySearchOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.MemorySearchOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.MemorySearchOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemorySearchOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemorySearchOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MemorySearchOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemorySearchOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemorySearchOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemorySearchOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemorySearchTool : Azure.AI.Agents.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemorySearchTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemorySearchTool>
    {
        public MemorySearchTool(string memoryStoreName, string scope) { }
        public string MemoryStoreName { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public Azure.AI.Agents.MemorySearchOptions SearchOptions { get { throw null; } set { } }
        public System.TimeSpan? UpdateDelay { get { throw null; } set { } }
        protected override Azure.AI.Agents.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Agents.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.MemorySearchTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemorySearchTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemorySearchTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MemorySearchTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemorySearchTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemorySearchTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemorySearchTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemorySearchToolCallItemResource : Azure.AI.Agents.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemorySearchToolCallItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemorySearchToolCallItemResource>
    {
        internal MemorySearchToolCallItemResource() { }
        public System.Collections.Generic.IList<Azure.AI.Agents.MemorySearchItem> Results { get { throw null; } }
        public Azure.AI.Agents.MemorySearchToolCallItemResourceStatus Status { get { throw null; } }
        protected override Azure.AI.Agents.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Agents.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.MemorySearchToolCallItemResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemorySearchToolCallItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemorySearchToolCallItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MemorySearchToolCallItemResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemorySearchToolCallItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemorySearchToolCallItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemorySearchToolCallItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum MemorySearchToolCallItemResourceStatus
    {
        InProgress = 0,
        Searching = 1,
        Completed = 2,
        Incomplete = 3,
        Failed = 4,
    }
    public partial class MemoryStoreClient
    {
        protected MemoryStoreClient() { }
        public System.ClientModel.Primitives.ClientPipeline Pipeline { get { throw null; } }
        public virtual System.ClientModel.ClientResult CreateMemoryStore(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.MemoryStoreObject> CreateMemoryStore(string name, Azure.AI.Agents.MemoryStoreDefinition definition, string description = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> CreateMemoryStoreAsync(System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.MemoryStoreObject>> CreateMemoryStoreAsync(string name, Azure.AI.Agents.MemoryStoreDefinition definition, string description = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteMemoryStore(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.DeleteMemoryStoreResponse> DeleteMemoryStore(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteMemoryStoreAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.DeleteMemoryStoreResponse>> DeleteMemoryStoreAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult DeleteScope(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.MemoryStoreDeleteScopeResponse> DeleteScope(string name, string scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> DeleteScopeAsync(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.MemoryStoreDeleteScopeResponse>> DeleteScopeAsync(string name, string scope, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetMemoryStore(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.MemoryStoreObject> GetMemoryStore(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetMemoryStoreAsync(string name, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.MemoryStoreObject>> GetMemoryStoreAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Agents.MemoryStoreObject> GetMemoryStores(int? limit = default(int?), Azure.AI.Agents.AgentsListOrder? order = default(Azure.AI.Agents.AgentsListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Agents.MemoryStoreObject> GetMemoryStoresAsync(int? limit = default(int?), Azure.AI.Agents.AgentsListOrder? order = default(Azure.AI.Agents.AgentsListOrder?), string after = null, string before = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult GetUpdateResult(string name, string updateId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.MemoryUpdateResult> GetUpdateResult(string name, string updateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> GetUpdateResultAsync(string name, string updateId, System.ClientModel.Primitives.RequestOptions options) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.MemoryUpdateResult>> GetUpdateResultAsync(string name, string updateId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult SearchMemories(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.MemoryStoreSearchResponse> SearchMemories(string memoryStoreId, string scope, Azure.AI.Agents.MemorySearchOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> SearchMemoriesAsync(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.MemoryStoreSearchResponse>> SearchMemoriesAsync(string memoryStoreId, string scope, Azure.AI.Agents.MemorySearchOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult UpdateMemories(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.MemoryUpdateResult> UpdateMemories(string memoryStoreId, string scope, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> items, Azure.AI.Agents.MemoryUpdateOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.MemoryUpdateResult> UpdateMemories(string memoryStoreId, string scope, string conversationId, Azure.AI.Agents.MemoryUpdateOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> UpdateMemoriesAsync(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.MemoryUpdateResult>> UpdateMemoriesAsync(string memoryStoreId, string scope, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> items, Azure.AI.Agents.MemoryUpdateOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.MemoryUpdateResult>> UpdateMemoriesAsync(string memoryStoreId, string scope, string conversationId, Azure.AI.Agents.MemoryUpdateOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult UpdateMemoryStore(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Agents.MemoryStoreObject> UpdateMemoryStore(string name, string description = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult> UpdateMemoryStoreAsync(string name, System.ClientModel.BinaryContent content, System.ClientModel.Primitives.RequestOptions options = null) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Agents.MemoryStoreObject>> UpdateMemoryStoreAsync(string name, string description = null, System.Collections.Generic.IDictionary<string, string> metadata = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MemoryStoreDefaultDefinition : Azure.AI.Agents.MemoryStoreDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryStoreDefaultDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryStoreDefaultDefinition>
    {
        public MemoryStoreDefaultDefinition(string chatModel, string embeddingModel) { }
        public string ChatModel { get { throw null; } set { } }
        public string EmbeddingModel { get { throw null; } set { } }
        public Azure.AI.Agents.MemoryStoreDefaultOptions Options { get { throw null; } set { } }
        protected override Azure.AI.Agents.MemoryStoreDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Agents.MemoryStoreDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.MemoryStoreDefaultDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryStoreDefaultDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryStoreDefaultDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MemoryStoreDefaultDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryStoreDefaultDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryStoreDefaultDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryStoreDefaultDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemoryStoreDefaultOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryStoreDefaultOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryStoreDefaultOptions>
    {
        public MemoryStoreDefaultOptions(bool userProfileEnabled, bool chatSummaryEnabled) { }
        public bool ChatSummaryEnabled { get { throw null; } set { } }
        public string UserProfileDetails { get { throw null; } set { } }
        public bool UserProfileEnabled { get { throw null; } set { } }
        protected virtual Azure.AI.Agents.MemoryStoreDefaultOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.MemoryStoreDefaultOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.MemoryStoreDefaultOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryStoreDefaultOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryStoreDefaultOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MemoryStoreDefaultOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryStoreDefaultOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryStoreDefaultOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryStoreDefaultOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MemoryStoreDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryStoreDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryStoreDefinition>
    {
        internal MemoryStoreDefinition() { }
        protected virtual Azure.AI.Agents.MemoryStoreDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.MemoryStoreDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.MemoryStoreDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryStoreDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryStoreDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MemoryStoreDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryStoreDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryStoreDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryStoreDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemoryStoreDeleteScopeResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryStoreDeleteScopeResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryStoreDeleteScopeResponse>
    {
        internal MemoryStoreDeleteScopeResponse() { }
        public bool Deleted { get { throw null; } }
        public string Name { get { throw null; } }
        public string Object { get { throw null; } }
        public string Scope { get { throw null; } }
        protected virtual Azure.AI.Agents.MemoryStoreDeleteScopeResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Agents.MemoryStoreDeleteScopeResponse (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Agents.MemoryStoreDeleteScopeResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.MemoryStoreDeleteScopeResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryStoreDeleteScopeResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryStoreDeleteScopeResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MemoryStoreDeleteScopeResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryStoreDeleteScopeResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryStoreDeleteScopeResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryStoreDeleteScopeResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemoryStoreObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryStoreObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryStoreObject>
    {
        internal MemoryStoreObject() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public Azure.AI.Agents.MemoryStoreDefinition Definition { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public string Object { get { throw null; } }
        public System.DateTimeOffset UpdatedAt { get { throw null; } }
        protected virtual Azure.AI.Agents.MemoryStoreObject JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Agents.MemoryStoreObject (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Agents.MemoryStoreObject PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.MemoryStoreObject System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryStoreObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryStoreObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MemoryStoreObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryStoreObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryStoreObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryStoreObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemoryStoreOperationUsage : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryStoreOperationUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryStoreOperationUsage>
    {
        internal MemoryStoreOperationUsage() { }
        public int EmbeddingTokens { get { throw null; } }
        public int InputTokens { get { throw null; } }
        public OpenAI.MemoryStoreOperationUsageInputTokensDetails InputTokensDetails { get { throw null; } }
        public int OutputTokens { get { throw null; } }
        public OpenAI.MemoryStoreOperationUsageOutputTokensDetails OutputTokensDetails { get { throw null; } }
        public int TotalTokens { get { throw null; } }
        protected virtual Azure.AI.Agents.MemoryStoreOperationUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.MemoryStoreOperationUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.MemoryStoreOperationUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryStoreOperationUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryStoreOperationUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MemoryStoreOperationUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryStoreOperationUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryStoreOperationUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryStoreOperationUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemoryStoreSearchResponse : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryStoreSearchResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryStoreSearchResponse>
    {
        internal MemoryStoreSearchResponse() { }
        public System.Collections.Generic.IList<Azure.AI.Agents.MemorySearchItem> Memories { get { throw null; } }
        public string SearchId { get { throw null; } }
        public Azure.AI.Agents.MemoryStoreOperationUsage Usage { get { throw null; } }
        protected virtual Azure.AI.Agents.MemoryStoreSearchResponse JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Agents.MemoryStoreSearchResponse (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Agents.MemoryStoreSearchResponse PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.MemoryStoreSearchResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryStoreSearchResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryStoreSearchResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MemoryStoreSearchResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryStoreSearchResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryStoreSearchResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryStoreSearchResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum MemoryStoreUpdateStatus
    {
        Queued = 0,
        InProgress = 1,
        Completed = 2,
        Failed = 3,
        Superseded = 4,
    }
    public partial class MemoryUpdateOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryUpdateOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryUpdateOptions>
    {
        public MemoryUpdateOptions() { }
        public string PreviousUpdateId { get { throw null; } }
        public int? UpdateDelay { get { throw null; } }
        protected virtual Azure.AI.Agents.MemoryUpdateOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator System.ClientModel.BinaryContent (Azure.AI.Agents.MemoryUpdateOptions memoryUpdateOptions) { throw null; }
        protected virtual Azure.AI.Agents.MemoryUpdateOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.MemoryUpdateOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryUpdateOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryUpdateOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MemoryUpdateOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryUpdateOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryUpdateOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryUpdateOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemoryUpdateResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryUpdateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryUpdateResult>
    {
        internal MemoryUpdateResult() { }
        public Azure.AI.Agents.MemoryUpdateResultDetails Details { get { throw null; } }
        public Azure.AI.Agents.AgentsApiError Error { get { throw null; } }
        public Azure.AI.Agents.MemoryStoreUpdateStatus Status { get { throw null; } }
        public string SupersededBy { get { throw null; } }
        public string UpdateId { get { throw null; } }
        protected virtual Azure.AI.Agents.MemoryUpdateResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Agents.MemoryUpdateResult (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Agents.MemoryUpdateResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.MemoryUpdateResult System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryUpdateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryUpdateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MemoryUpdateResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryUpdateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryUpdateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryUpdateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemoryUpdateResultDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryUpdateResultDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryUpdateResultDetails>
    {
        internal MemoryUpdateResultDetails() { }
        public System.Collections.Generic.IList<Azure.AI.Agents.MemoryOperation> MemoryOperations { get { throw null; } }
        public Azure.AI.Agents.MemoryStoreOperationUsage Usage { get { throw null; } }
        protected virtual Azure.AI.Agents.MemoryUpdateResultDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.Agents.MemoryUpdateResultDetails (System.ClientModel.ClientResult result) { throw null; }
        protected virtual Azure.AI.Agents.MemoryUpdateResultDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.MemoryUpdateResultDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryUpdateResultDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MemoryUpdateResultDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MemoryUpdateResultDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryUpdateResultDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryUpdateResultDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MemoryUpdateResultDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MicrosoftFabricAgentTool : Azure.AI.Agents.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MicrosoftFabricAgentTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MicrosoftFabricAgentTool>
    {
        public MicrosoftFabricAgentTool(Azure.AI.Agents.FabricDataAgentToolParameters fabricDataagentPreview) { }
        public Azure.AI.Agents.FabricDataAgentToolParameters FabricDataagentPreview { get { throw null; } set { } }
        protected override Azure.AI.Agents.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Agents.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.MicrosoftFabricAgentTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MicrosoftFabricAgentTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.MicrosoftFabricAgentTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.MicrosoftFabricAgentTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MicrosoftFabricAgentTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MicrosoftFabricAgentTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.MicrosoftFabricAgentTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OAuthConsentRequestItemResource : Azure.AI.Agents.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OAuthConsentRequestItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OAuthConsentRequestItemResource>
    {
        internal OAuthConsentRequestItemResource() { }
        public string ConsentLink { get { throw null; } }
        public override string Id { get { throw null; } }
        public string ServerLabel { get { throw null; } }
        protected override Azure.AI.Agents.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Agents.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.OAuthConsentRequestItemResource System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OAuthConsentRequestItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OAuthConsentRequestItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.OAuthConsentRequestItemResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OAuthConsentRequestItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OAuthConsentRequestItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OAuthConsentRequestItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class OpenAIFileExtensions
    {
        public static string GetAzureFileStatus(this OpenAI.Files.OpenAIFile file) { throw null; }
    }
    public static partial class OpenAIResponseExtension
    {
        public static System.ClientModel.ClientResult<OpenAI.Responses.OpenAIResponse> CreateResponse(this OpenAI.Responses.OpenAIResponseClient responseClient, Azure.AI.Agents.AgentConversation conversation, Azure.AI.Agents.AgentReference agentRef, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<System.ClientModel.ClientResult<OpenAI.Responses.OpenAIResponse>> CreateResponseAsync(this OpenAI.Responses.OpenAIResponseClient responseClient, Azure.AI.Agents.AgentConversation conversation, Azure.AI.Agents.AgentReference agentRef, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OpenApiAgentTool : Azure.AI.Agents.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiAgentTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiAgentTool>
    {
        public OpenApiAgentTool(Azure.AI.Agents.OpenApiFunctionDefinition openapi) { }
        public Azure.AI.Agents.OpenApiFunctionDefinition Openapi { get { throw null; } set { } }
        protected override Azure.AI.Agents.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Agents.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.OpenApiAgentTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiAgentTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiAgentTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.OpenApiAgentTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiAgentTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiAgentTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiAgentTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiAnonymousAuthDetails : Azure.AI.Agents.OpenApiAuthDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiAnonymousAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiAnonymousAuthDetails>
    {
        public OpenApiAnonymousAuthDetails() { }
        protected override Azure.AI.Agents.OpenApiAuthDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Agents.OpenApiAuthDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.OpenApiAnonymousAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiAnonymousAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiAnonymousAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.OpenApiAnonymousAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiAnonymousAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiAnonymousAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiAnonymousAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class OpenApiAuthDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiAuthDetails>
    {
        internal OpenApiAuthDetails() { }
        protected virtual Azure.AI.Agents.OpenApiAuthDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.OpenApiAuthDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.OpenApiAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.OpenApiAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiFunctionDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiFunctionDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiFunctionDefinition>
    {
        public OpenApiFunctionDefinition(string name, System.BinaryData spec, Azure.AI.Agents.OpenApiAuthDetails auth) { }
        public Azure.AI.Agents.OpenApiAuthDetails Auth { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DefaultParams { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Agents.OpenApiFunctionDefinitionFunction> Functions { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Spec { get { throw null; } set { } }
        protected virtual Azure.AI.Agents.OpenApiFunctionDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.OpenApiFunctionDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.OpenApiFunctionDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiFunctionDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiFunctionDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.OpenApiFunctionDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiFunctionDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiFunctionDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiFunctionDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiFunctionDefinitionFunction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiFunctionDefinitionFunction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiFunctionDefinitionFunction>
    {
        public OpenApiFunctionDefinitionFunction(string name, System.BinaryData parameters) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Parameters { get { throw null; } set { } }
        protected virtual Azure.AI.Agents.OpenApiFunctionDefinitionFunction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.OpenApiFunctionDefinitionFunction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.OpenApiFunctionDefinitionFunction System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiFunctionDefinitionFunction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiFunctionDefinitionFunction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.OpenApiFunctionDefinitionFunction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiFunctionDefinitionFunction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiFunctionDefinitionFunction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiFunctionDefinitionFunction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiManagedAuthDetails : Azure.AI.Agents.OpenApiAuthDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiManagedAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiManagedAuthDetails>
    {
        public OpenApiManagedAuthDetails(Azure.AI.Agents.OpenApiManagedSecurityScheme securityScheme) { }
        public Azure.AI.Agents.OpenApiManagedSecurityScheme SecurityScheme { get { throw null; } set { } }
        protected override Azure.AI.Agents.OpenApiAuthDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Agents.OpenApiAuthDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        protected virtual Azure.AI.Agents.OpenApiManagedSecurityScheme JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.OpenApiManagedSecurityScheme PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.OpenApiManagedSecurityScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiManagedSecurityScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiManagedSecurityScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.OpenApiManagedSecurityScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiManagedSecurityScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiManagedSecurityScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiManagedSecurityScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiProjectConnectionAuthDetails : Azure.AI.Agents.OpenApiAuthDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiProjectConnectionAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiProjectConnectionAuthDetails>
    {
        public OpenApiProjectConnectionAuthDetails(Azure.AI.Agents.OpenApiProjectConnectionSecurityScheme securityScheme) { }
        public Azure.AI.Agents.OpenApiProjectConnectionSecurityScheme SecurityScheme { get { throw null; } set { } }
        protected override Azure.AI.Agents.OpenApiAuthDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Agents.OpenApiAuthDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.OpenApiProjectConnectionAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiProjectConnectionAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiProjectConnectionAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.OpenApiProjectConnectionAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiProjectConnectionAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiProjectConnectionAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiProjectConnectionAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiProjectConnectionSecurityScheme : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiProjectConnectionSecurityScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiProjectConnectionSecurityScheme>
    {
        public OpenApiProjectConnectionSecurityScheme(string projectConnectionId) { }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected virtual Azure.AI.Agents.OpenApiProjectConnectionSecurityScheme JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.OpenApiProjectConnectionSecurityScheme PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.OpenApiProjectConnectionSecurityScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiProjectConnectionSecurityScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.OpenApiProjectConnectionSecurityScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.OpenApiProjectConnectionSecurityScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiProjectConnectionSecurityScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiProjectConnectionSecurityScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.OpenApiProjectConnectionSecurityScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PromptAgentDefinition : Azure.AI.Agents.AgentDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.PromptAgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.PromptAgentDefinition>
    {
        public PromptAgentDefinition(string model) { }
        public string Instructions { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public OpenAI.Responses.ResponseReasoningOptions ReasoningOptions { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Agents.StructuredInputDefinition> StructuredInputs { get { throw null; } }
        public float? Temperature { get { throw null; } set { } }
        public OpenAI.Responses.ResponseTextOptions TextOptions { get { throw null; } set { } }
        public System.Collections.Generic.IList<OpenAI.Responses.ResponseTool> Tools { get { throw null; } }
        public float? TopP { get { throw null; } set { } }
        protected override Azure.AI.Agents.AgentDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Agents.AgentDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.PromptAgentDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.PromptAgentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.PromptAgentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.PromptAgentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.PromptAgentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.PromptAgentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.PromptAgentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProtocolVersionRecord : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ProtocolVersionRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ProtocolVersionRecord>
    {
        public ProtocolVersionRecord(Azure.AI.Agents.AgentCommunicationMethod protocol, string version) { }
        public Azure.AI.Agents.AgentCommunicationMethod Protocol { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.AI.Agents.ProtocolVersionRecord JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.ProtocolVersionRecord PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.ProtocolVersionRecord System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ProtocolVersionRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ProtocolVersionRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.ProtocolVersionRecord System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ProtocolVersionRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ProtocolVersionRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ProtocolVersionRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RaiConfig : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RaiConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RaiConfig>
    {
        public RaiConfig(string raiPolicyName) { }
        public string RaiPolicyName { get { throw null; } set { } }
        protected virtual Azure.AI.Agents.RaiConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.RaiConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.RaiConfig System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RaiConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.RaiConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.RaiConfig System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RaiConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RaiConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.RaiConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ResponseCreationOptionsExtensions
    {
        public static void AddStructuredInput(this OpenAI.Responses.ResponseCreationOptions options, string key, string value) { }
        public static void SetAgentReference(this OpenAI.Responses.ResponseCreationOptions responseCreationOptions, Azure.AI.Agents.AgentRecord agentObject, string version = null) { }
        public static void SetAgentReference(this OpenAI.Responses.ResponseCreationOptions responseCreationOptions, Azure.AI.Agents.AgentReference agentReference) { }
        public static void SetAgentReference(this OpenAI.Responses.ResponseCreationOptions responseCreationOptions, Azure.AI.Agents.AgentVersion agentVersion) { }
        public static void SetAgentReference(this OpenAI.Responses.ResponseCreationOptions responseCreationOptions, string agentName, string version = null) { }
        public static void SetConversationReference(this OpenAI.Responses.ResponseCreationOptions responseCreationOptions, Azure.AI.Agents.AgentConversation conversation) { }
        public static void SetConversationReference(this OpenAI.Responses.ResponseCreationOptions responseCreationOptions, string conversationId) { }
        public static void SetStructuredInputs(this OpenAI.Responses.ResponseCreationOptions options, System.BinaryData structuredInputsBytes) { }
    }
    public static partial class ResponseItemExtensions
    {
        public static Azure.AI.Agents.AgentResponseItem AsAgentResponseItem(this OpenAI.Responses.ResponseItem responseItem) { throw null; }
    }
    public static partial class ResponseToolExtensions
    {
        public static Azure.AI.Agents.AgentTool AsAgentTool(this OpenAI.Responses.ResponseTool responseTool) { throw null; }
    }
    public partial class SharepointAgentTool : Azure.AI.Agents.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.SharepointAgentTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.SharepointAgentTool>
    {
        public SharepointAgentTool(Azure.AI.Agents.SharepointGroundingToolParameters sharepointGroundingPreview) { }
        public Azure.AI.Agents.SharepointGroundingToolParameters SharepointGroundingPreview { get { throw null; } set { } }
        protected override Azure.AI.Agents.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Agents.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.SharepointAgentTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.SharepointAgentTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.SharepointAgentTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.SharepointAgentTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.SharepointAgentTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.SharepointAgentTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.SharepointAgentTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharepointGroundingToolParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.SharepointGroundingToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.SharepointGroundingToolParameters>
    {
        public SharepointGroundingToolParameters() { }
        public System.Collections.Generic.IList<Azure.AI.Agents.ToolProjectConnection> ProjectConnections { get { throw null; } }
        protected virtual Azure.AI.Agents.SharepointGroundingToolParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.SharepointGroundingToolParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.SharepointGroundingToolParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.SharepointGroundingToolParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.SharepointGroundingToolParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.SharepointGroundingToolParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.SharepointGroundingToolParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.SharepointGroundingToolParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.SharepointGroundingToolParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StructuredInputDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.StructuredInputDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.StructuredInputDefinition>
    {
        public StructuredInputDefinition() { }
        public System.BinaryData DefaultValue { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? Required { get { throw null; } set { } }
        public System.BinaryData Schema { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Agents.ToolArgumentBinding> ToolArgumentBindings { get { throw null; } }
        protected virtual Azure.AI.Agents.StructuredInputDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.StructuredInputDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.StructuredInputDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.StructuredInputDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.StructuredInputDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.StructuredInputDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.StructuredInputDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.StructuredInputDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.StructuredInputDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StructuredOutputDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.StructuredOutputDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.StructuredOutputDefinition>
    {
        public StructuredOutputDefinition(string name, string description, System.Collections.Generic.IDictionary<string, System.BinaryData> schema, bool? strict) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Schema { get { throw null; } }
        public bool? Strict { get { throw null; } set { } }
        protected virtual Azure.AI.Agents.StructuredOutputDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.StructuredOutputDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.StructuredOutputDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.StructuredOutputDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.StructuredOutputDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.StructuredOutputDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.StructuredOutputDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.StructuredOutputDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.StructuredOutputDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolArgumentBinding : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ToolArgumentBinding>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ToolArgumentBinding>
    {
        public ToolArgumentBinding(string argumentName) { }
        public string ArgumentName { get { throw null; } set { } }
        public string ToolName { get { throw null; } set { } }
        protected virtual Azure.AI.Agents.ToolArgumentBinding JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.ToolArgumentBinding PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.ToolArgumentBinding System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ToolArgumentBinding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ToolArgumentBinding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.ToolArgumentBinding System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ToolArgumentBinding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ToolArgumentBinding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ToolArgumentBinding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolProjectConnection : System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ToolProjectConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ToolProjectConnection>
    {
        public ToolProjectConnection(string projectConnectionId) { }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected virtual Azure.AI.Agents.ToolProjectConnection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Agents.ToolProjectConnection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.ToolProjectConnection System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ToolProjectConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.ToolProjectConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.ToolProjectConnection System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ToolProjectConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ToolProjectConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.ToolProjectConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserProfileMemoryItem : Azure.AI.Agents.MemoryItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.UserProfileMemoryItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.UserProfileMemoryItem>
    {
        public UserProfileMemoryItem(string memoryId, System.DateTimeOffset updatedAt, string scope, string content) { }
        protected override Azure.AI.Agents.MemoryItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Agents.MemoryItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.UserProfileMemoryItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.UserProfileMemoryItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.UserProfileMemoryItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.UserProfileMemoryItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.UserProfileMemoryItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.UserProfileMemoryItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.UserProfileMemoryItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkflowAgentDefinition : Azure.AI.Agents.AgentDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.WorkflowAgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.WorkflowAgentDefinition>
    {
        public WorkflowAgentDefinition() { }
        public static Azure.AI.Agents.WorkflowAgentDefinition FromYaml(string workflowYamlDocument) { throw null; }
        protected override Azure.AI.Agents.AgentDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Agents.AgentDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Agents.WorkflowAgentDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.WorkflowAgentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Agents.WorkflowAgentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Agents.WorkflowAgentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.WorkflowAgentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.WorkflowAgentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Agents.WorkflowAgentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace OpenAI
{
    public partial class MemoryStoreOperationUsageInputTokensDetails : System.ClientModel.Primitives.IJsonModel<OpenAI.MemoryStoreOperationUsageInputTokensDetails>, System.ClientModel.Primitives.IPersistableModel<OpenAI.MemoryStoreOperationUsageInputTokensDetails>
    {
        internal MemoryStoreOperationUsageInputTokensDetails() { }
        public int CachedTokens { get { throw null; } }
        protected virtual OpenAI.MemoryStoreOperationUsageInputTokensDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual OpenAI.MemoryStoreOperationUsageInputTokensDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        OpenAI.MemoryStoreOperationUsageInputTokensDetails System.ClientModel.Primitives.IJsonModel<OpenAI.MemoryStoreOperationUsageInputTokensDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<OpenAI.MemoryStoreOperationUsageInputTokensDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        OpenAI.MemoryStoreOperationUsageInputTokensDetails System.ClientModel.Primitives.IPersistableModel<OpenAI.MemoryStoreOperationUsageInputTokensDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<OpenAI.MemoryStoreOperationUsageInputTokensDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<OpenAI.MemoryStoreOperationUsageInputTokensDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemoryStoreOperationUsageOutputTokensDetails : System.ClientModel.Primitives.IJsonModel<OpenAI.MemoryStoreOperationUsageOutputTokensDetails>, System.ClientModel.Primitives.IPersistableModel<OpenAI.MemoryStoreOperationUsageOutputTokensDetails>
    {
        internal MemoryStoreOperationUsageOutputTokensDetails() { }
        public int ReasoningTokens { get { throw null; } }
        protected virtual OpenAI.MemoryStoreOperationUsageOutputTokensDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual OpenAI.MemoryStoreOperationUsageOutputTokensDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        OpenAI.MemoryStoreOperationUsageOutputTokensDetails System.ClientModel.Primitives.IJsonModel<OpenAI.MemoryStoreOperationUsageOutputTokensDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<OpenAI.MemoryStoreOperationUsageOutputTokensDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        OpenAI.MemoryStoreOperationUsageOutputTokensDetails System.ClientModel.Primitives.IPersistableModel<OpenAI.MemoryStoreOperationUsageOutputTokensDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<OpenAI.MemoryStoreOperationUsageOutputTokensDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<OpenAI.MemoryStoreOperationUsageOutputTokensDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
