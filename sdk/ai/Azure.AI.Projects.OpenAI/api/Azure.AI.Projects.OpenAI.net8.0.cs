namespace Azure.AI.Projects.OpenAI
{
    public partial class A2ATool : Azure.AI.Projects.OpenAI.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.A2ATool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.A2ATool>
    {
        public A2ATool(System.Uri baseUri) { }
        public string AgentCardPath { get { throw null; } set { } }
        public System.Uri BaseUri { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected override Azure.AI.Projects.OpenAI.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.OpenAI.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.A2ATool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.A2ATool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.A2ATool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.A2ATool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.A2ATool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.A2ATool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.A2ATool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentCommunicationMethod : System.IEquatable<Azure.AI.Projects.OpenAI.AgentCommunicationMethod>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentCommunicationMethod(string value) { throw null; }
        public static Azure.AI.Projects.OpenAI.AgentCommunicationMethod ActivityProtocol { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.AgentCommunicationMethod Responses { get { throw null; } }
        public bool Equals(Azure.AI.Projects.OpenAI.AgentCommunicationMethod other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.OpenAI.AgentCommunicationMethod left, Azure.AI.Projects.OpenAI.AgentCommunicationMethod right) { throw null; }
        public static implicit operator Azure.AI.Projects.OpenAI.AgentCommunicationMethod (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.OpenAI.AgentCommunicationMethod? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.OpenAI.AgentCommunicationMethod left, Azure.AI.Projects.OpenAI.AgentCommunicationMethod right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentConversation : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentConversation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentConversation>
    {
        internal AgentConversation() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        protected virtual Azure.AI.Projects.OpenAI.AgentConversation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator string (Azure.AI.Projects.OpenAI.AgentConversation conversation) { throw null; }
        protected virtual Azure.AI.Projects.OpenAI.AgentConversation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.AgentConversation System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentConversation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentConversation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.AgentConversation System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentConversation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentConversation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentConversation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AgentDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentDefinition>
    {
        internal AgentDefinition() { }
        public Azure.AI.Projects.OpenAI.ContentFilterConfiguration ContentFilterConfiguration { get { throw null; } set { } }
        public static Azure.AI.Projects.OpenAI.ContainerApplicationAgentDefinition CreateContainerApplicationAgentDefinition(System.Collections.Generic.IEnumerable<Azure.AI.Projects.OpenAI.ProtocolVersionRecord> containerProtocolVersions, string containerAppResourceId, string ingressSubdomainSuffix) { throw null; }
        public static Azure.AI.Projects.OpenAI.HostedAgentDefinition CreateHostedAgentDefinition(System.Collections.Generic.IEnumerable<Azure.AI.Projects.OpenAI.ProtocolVersionRecord> containerProtocolVersions, string cpuConfiguration, string memoryConfiguration) { throw null; }
        public static Azure.AI.Projects.OpenAI.PromptAgentDefinition CreatePromptAgentDefinition(string model) { throw null; }
        public static Azure.AI.Projects.OpenAI.WorkflowAgentDefinition CreateWorkflowAgentDefinitionFromYaml(string workflowYamlDocument) { throw null; }
        protected virtual Azure.AI.Projects.OpenAI.AgentDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.AgentDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.AgentDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.AgentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentInfo : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentInfo>
    {
        internal AgentInfo() { }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Projects.OpenAI.AgentInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.AgentInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.AgentInfo System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.AgentInfo System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentObjectVersions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentObjectVersions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentObjectVersions>
    {
        internal AgentObjectVersions() { }
        public Azure.AI.Projects.OpenAI.AgentVersion Latest { get { throw null; } }
        protected virtual Azure.AI.Projects.OpenAI.AgentObjectVersions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.AgentObjectVersions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.AgentObjectVersions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentObjectVersions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentObjectVersions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.AgentObjectVersions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentObjectVersions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentObjectVersions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentObjectVersions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentRecord : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentRecord>
    {
        internal AgentRecord() { }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.Projects.OpenAI.AgentObjectVersions Versions { get { throw null; } }
        protected virtual Azure.AI.Projects.OpenAI.AgentRecord JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.AgentRecord PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.AgentRecord System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.AgentRecord System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentReference : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentReference>
    {
        public AgentReference(string name, string version = null) { }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Projects.OpenAI.AgentReference JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.AI.Projects.OpenAI.AgentReference (Azure.AI.Projects.OpenAI.AgentRecord agentRecord) { throw null; }
        public static implicit operator Azure.AI.Projects.OpenAI.AgentReference (Azure.AI.Projects.OpenAI.AgentVersion agentVersion) { throw null; }
        public static implicit operator Azure.AI.Projects.OpenAI.AgentReference (string agentName) { throw null; }
        protected virtual Azure.AI.Projects.OpenAI.AgentReference PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.AgentReference System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.AgentReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AgentResponseItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentResponseItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentResponseItem>
    {
        internal AgentResponseItem() { }
        public Azure.AI.Projects.OpenAI.AgentResponseItemSource CreatedBy { get { throw null; } }
        public virtual string Id { get { throw null; } }
        public OpenAI.Responses.ResponseItem AsOpenAIResponseItem() { throw null; }
        public static Azure.AI.Projects.OpenAI.AgentResponseItem CreateStructuredOutputsItem(System.BinaryData output = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.AgentResponseItem CreateWorkflowActionItem(string actionKind, string actionId) { throw null; }
        protected virtual Azure.AI.Projects.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator OpenAI.Responses.ResponseItem (Azure.AI.Projects.OpenAI.AgentResponseItem agentResponseItem) { throw null; }
        public static implicit operator Azure.AI.Projects.OpenAI.AgentResponseItem (OpenAI.Responses.ResponseItem responseItem) { throw null; }
        protected virtual Azure.AI.Projects.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.AgentResponseItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentResponseItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentResponseItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.AgentResponseItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentResponseItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentResponseItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentResponseItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentResponseItemKind : System.IEquatable<Azure.AI.Projects.OpenAI.AgentResponseItemKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentResponseItemKind(string value) { throw null; }
        public static Azure.AI.Projects.OpenAI.AgentResponseItemKind CodeInterpreterCall { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.AgentResponseItemKind ComputerCall { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.AgentResponseItemKind ComputerCallOutput { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.AgentResponseItemKind FileSearchCall { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.AgentResponseItemKind FunctionCall { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.AgentResponseItemKind FunctionCallOutput { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.AgentResponseItemKind ImageGenerationCall { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.AgentResponseItemKind ItemReference { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.AgentResponseItemKind LocalShellCall { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.AgentResponseItemKind LocalShellCallOutput { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.AgentResponseItemKind McpApprovalRequest { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.AgentResponseItemKind McpApprovalResponse { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.AgentResponseItemKind McpCall { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.AgentResponseItemKind McpListTools { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.AgentResponseItemKind MemorySearchCall { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.AgentResponseItemKind Message { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.AgentResponseItemKind OauthConsentRequest { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.AgentResponseItemKind Reasoning { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.AgentResponseItemKind StructuredOutputs { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.AgentResponseItemKind WebSearchCall { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.AgentResponseItemKind WorkflowAction { get { throw null; } }
        public bool Equals(Azure.AI.Projects.OpenAI.AgentResponseItemKind other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.OpenAI.AgentResponseItemKind left, Azure.AI.Projects.OpenAI.AgentResponseItemKind right) { throw null; }
        public static implicit operator Azure.AI.Projects.OpenAI.AgentResponseItemKind (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.OpenAI.AgentResponseItemKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.OpenAI.AgentResponseItemKind left, Azure.AI.Projects.OpenAI.AgentResponseItemKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentResponseItemSource : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentResponseItemSource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentResponseItemSource>
    {
        internal AgentResponseItemSource() { }
        public Azure.AI.Projects.OpenAI.AgentInfo Agent { get { throw null; } }
        public string ResponseId { get { throw null; } }
        protected virtual Azure.AI.Projects.OpenAI.AgentResponseItemSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.AgentResponseItemSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.AgentResponseItemSource System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentResponseItemSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentResponseItemSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.AgentResponseItemSource System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentResponseItemSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentResponseItemSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentResponseItemSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentStructuredOutputsResponseItem : Azure.AI.Projects.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentStructuredOutputsResponseItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentStructuredOutputsResponseItem>
    {
        public AgentStructuredOutputsResponseItem(System.BinaryData output) { }
        public System.BinaryData Output { get { throw null; } }
        protected override Azure.AI.Projects.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.AgentStructuredOutputsResponseItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentStructuredOutputsResponseItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentStructuredOutputsResponseItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.AgentStructuredOutputsResponseItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentStructuredOutputsResponseItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentStructuredOutputsResponseItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentStructuredOutputsResponseItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AgentTool : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentTool>
    {
        internal AgentTool() { }
        public static OpenAI.Responses.ResponseTool CreateA2ATool(System.Uri baseUri, string agentCardPath = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.AzureAISearchAgentTool CreateAzureAISearchTool(Azure.AI.Projects.OpenAI.AzureAISearchToolOptions options = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.BingCustomSearchAgentTool CreateBingCustomSearchTool(Azure.AI.Projects.OpenAI.BingCustomSearchToolParameters parameters) { throw null; }
        public static Azure.AI.Projects.OpenAI.BingGroundingAgentTool CreateBingGroundingTool(Azure.AI.Projects.OpenAI.BingGroundingSearchToolOptions options) { throw null; }
        public static Azure.AI.Projects.OpenAI.BrowserAutomationAgentTool CreateBrowserAutomationTool(Azure.AI.Projects.OpenAI.BrowserAutomationToolParameters parameters) { throw null; }
        public static Azure.AI.Projects.OpenAI.MicrosoftFabricAgentTool CreateMicrosoftFabricTool(Azure.AI.Projects.OpenAI.FabricDataAgentToolOptions options) { throw null; }
        public static Azure.AI.Projects.OpenAI.OpenAPIAgentTool CreateOpenApiTool(Azure.AI.Projects.OpenAI.OpenAPIFunctionDefinition definition) { throw null; }
        public static Azure.AI.Projects.OpenAI.SharepointAgentTool CreateSharepointTool(Azure.AI.Projects.OpenAI.SharePointGroundingToolOptions options) { throw null; }
        public static Azure.AI.Projects.OpenAI.CaptureStructuredOutputsTool CreateStructuredOutputsTool(Azure.AI.Projects.OpenAI.StructuredOutputDefinition outputs) { throw null; }
        protected virtual Azure.AI.Projects.OpenAI.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator OpenAI.Responses.ResponseTool (Azure.AI.Projects.OpenAI.AgentTool agentTool) { throw null; }
        protected virtual Azure.AI.Projects.OpenAI.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.AgentTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.AgentTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentVersion : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentVersion>
    {
        internal AgentVersion() { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public Azure.AI.Projects.OpenAI.AgentDefinition Definition { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.AI.Projects.OpenAI.AgentVersion JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.AgentVersion PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.AgentVersion System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.AgentVersion System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentWorkflowActionResponseItem : Azure.AI.Projects.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentWorkflowActionResponseItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentWorkflowActionResponseItem>
    {
        internal AgentWorkflowActionResponseItem() { }
        public string ActionId { get { throw null; } }
        public string Kind { get { throw null; } }
        public string ParentActionId { get { throw null; } }
        public string PreviousActionId { get { throw null; } }
        public Azure.AI.Projects.OpenAI.AgentWorkflowActionStatus? Status { get { throw null; } }
        protected override Azure.AI.Projects.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.AgentWorkflowActionResponseItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentWorkflowActionResponseItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AgentWorkflowActionResponseItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.AgentWorkflowActionResponseItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentWorkflowActionResponseItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentWorkflowActionResponseItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AgentWorkflowActionResponseItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentWorkflowActionStatus : System.IEquatable<Azure.AI.Projects.OpenAI.AgentWorkflowActionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentWorkflowActionStatus(string value) { throw null; }
        public static Azure.AI.Projects.OpenAI.AgentWorkflowActionStatus Cancelled { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.AgentWorkflowActionStatus Completed { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.AgentWorkflowActionStatus Failed { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.AgentWorkflowActionStatus InProgress { get { throw null; } }
        public bool Equals(Azure.AI.Projects.OpenAI.AgentWorkflowActionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.OpenAI.AgentWorkflowActionStatus left, Azure.AI.Projects.OpenAI.AgentWorkflowActionStatus right) { throw null; }
        public static implicit operator Azure.AI.Projects.OpenAI.AgentWorkflowActionStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.OpenAI.AgentWorkflowActionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.OpenAI.AgentWorkflowActionStatus left, Azure.AI.Projects.OpenAI.AgentWorkflowActionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class AzureAIAgentsModelFactory
    {
    }
    public partial class AzureAIProjectsOpenAIContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAIProjectsOpenAIContext() { }
        public static Azure.AI.Projects.OpenAI.AzureAIProjectsOpenAIContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class AzureAISearchAgentTool : Azure.AI.Projects.OpenAI.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AzureAISearchAgentTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureAISearchAgentTool>
    {
        public AzureAISearchAgentTool(Azure.AI.Projects.OpenAI.AzureAISearchToolOptions options) { }
        public Azure.AI.Projects.OpenAI.AzureAISearchToolOptions Options { get { throw null; } set { } }
        protected override Azure.AI.Projects.OpenAI.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.OpenAI.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.AzureAISearchAgentTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AzureAISearchAgentTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AzureAISearchAgentTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.AzureAISearchAgentTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureAISearchAgentTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureAISearchAgentTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureAISearchAgentTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAISearchIndex : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AzureAISearchIndex>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureAISearchIndex>
    {
        public AzureAISearchIndex() { }
        public string Filter { get { throw null; } set { } }
        public string IndexAssetId { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public Azure.AI.Projects.OpenAI.AzureAISearchQueryType? QueryType { get { throw null; } set { } }
        public int? TopK { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.OpenAI.AzureAISearchIndex JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.AzureAISearchIndex PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.AzureAISearchIndex System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AzureAISearchIndex>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AzureAISearchIndex>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.AzureAISearchIndex System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureAISearchIndex>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureAISearchIndex>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureAISearchIndex>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureAISearchQueryType : System.IEquatable<Azure.AI.Projects.OpenAI.AzureAISearchQueryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureAISearchQueryType(string value) { throw null; }
        public static Azure.AI.Projects.OpenAI.AzureAISearchQueryType Semantic { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.AzureAISearchQueryType Simple { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.AzureAISearchQueryType Vector { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.AzureAISearchQueryType VectorSemanticHybrid { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.AzureAISearchQueryType VectorSimpleHybrid { get { throw null; } }
        public bool Equals(Azure.AI.Projects.OpenAI.AzureAISearchQueryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.OpenAI.AzureAISearchQueryType left, Azure.AI.Projects.OpenAI.AzureAISearchQueryType right) { throw null; }
        public static implicit operator Azure.AI.Projects.OpenAI.AzureAISearchQueryType (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.OpenAI.AzureAISearchQueryType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.OpenAI.AzureAISearchQueryType left, Azure.AI.Projects.OpenAI.AzureAISearchQueryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureAISearchToolOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AzureAISearchToolOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureAISearchToolOptions>
    {
        public AzureAISearchToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Projects.OpenAI.AzureAISearchIndex> indexes) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.OpenAI.AzureAISearchIndex> Indexes { get { throw null; } }
        protected virtual Azure.AI.Projects.OpenAI.AzureAISearchToolOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.AzureAISearchToolOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.AzureAISearchToolOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AzureAISearchToolOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AzureAISearchToolOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.AzureAISearchToolOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureAISearchToolOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureAISearchToolOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureAISearchToolOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionAgentTool : Azure.AI.Projects.OpenAI.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AzureFunctionAgentTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureFunctionAgentTool>
    {
        public AzureFunctionAgentTool(Azure.AI.Projects.OpenAI.AzureFunctionDefinition azureFunction) { }
        public Azure.AI.Projects.OpenAI.AzureFunctionDefinition AzureFunction { get { throw null; } set { } }
        protected override Azure.AI.Projects.OpenAI.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.OpenAI.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.AzureFunctionAgentTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AzureFunctionAgentTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AzureFunctionAgentTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.AzureFunctionAgentTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureFunctionAgentTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureFunctionAgentTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureFunctionAgentTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionBinding : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AzureFunctionBinding>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureFunctionBinding>
    {
        public AzureFunctionBinding(Azure.AI.Projects.OpenAI.AzureFunctionStorageQueue storageQueue) { }
        public Azure.AI.Projects.OpenAI.AzureFunctionStorageQueue StorageQueue { get { throw null; } set { } }
        public string Type { get { throw null; } }
        protected virtual Azure.AI.Projects.OpenAI.AzureFunctionBinding JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.AzureFunctionBinding PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.AzureFunctionBinding System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AzureFunctionBinding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AzureFunctionBinding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.AzureFunctionBinding System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureFunctionBinding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureFunctionBinding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureFunctionBinding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AzureFunctionDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureFunctionDefinition>
    {
        public AzureFunctionDefinition(Azure.AI.Projects.OpenAI.AzureFunctionDefinitionFunction function, Azure.AI.Projects.OpenAI.AzureFunctionBinding inputBinding, Azure.AI.Projects.OpenAI.AzureFunctionBinding outputBinding) { }
        public Azure.AI.Projects.OpenAI.AzureFunctionDefinitionFunction Function { get { throw null; } set { } }
        public Azure.AI.Projects.OpenAI.AzureFunctionBinding InputBinding { get { throw null; } set { } }
        public Azure.AI.Projects.OpenAI.AzureFunctionBinding OutputBinding { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.OpenAI.AzureFunctionDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.AzureFunctionDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.AzureFunctionDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AzureFunctionDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AzureFunctionDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.AzureFunctionDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureFunctionDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureFunctionDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureFunctionDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionDefinitionFunction : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AzureFunctionDefinitionFunction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureFunctionDefinitionFunction>
    {
        public AzureFunctionDefinitionFunction(string name, System.BinaryData parameters) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Parameters { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.OpenAI.AzureFunctionDefinitionFunction JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.AzureFunctionDefinitionFunction PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.AzureFunctionDefinitionFunction System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AzureFunctionDefinitionFunction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AzureFunctionDefinitionFunction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.AzureFunctionDefinitionFunction System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureFunctionDefinitionFunction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureFunctionDefinitionFunction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureFunctionDefinitionFunction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureFunctionStorageQueue : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AzureFunctionStorageQueue>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureFunctionStorageQueue>
    {
        public AzureFunctionStorageQueue(string queueServiceEndpoint, string queueName) { }
        public string QueueName { get { throw null; } set { } }
        public string QueueServiceEndpoint { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.OpenAI.AzureFunctionStorageQueue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.AzureFunctionStorageQueue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.AzureFunctionStorageQueue System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AzureFunctionStorageQueue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.AzureFunctionStorageQueue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.AzureFunctionStorageQueue System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureFunctionStorageQueue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureFunctionStorageQueue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.AzureFunctionStorageQueue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingCustomSearchAgentTool : Azure.AI.Projects.OpenAI.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.BingCustomSearchAgentTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BingCustomSearchAgentTool>
    {
        public BingCustomSearchAgentTool(Azure.AI.Projects.OpenAI.BingCustomSearchToolParameters bingCustomSearchPreview) { }
        public Azure.AI.Projects.OpenAI.BingCustomSearchToolParameters BingCustomSearchPreview { get { throw null; } set { } }
        protected override Azure.AI.Projects.OpenAI.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.OpenAI.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.BingCustomSearchAgentTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.BingCustomSearchAgentTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.BingCustomSearchAgentTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.BingCustomSearchAgentTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BingCustomSearchAgentTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BingCustomSearchAgentTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BingCustomSearchAgentTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingCustomSearchConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.BingCustomSearchConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BingCustomSearchConfiguration>
    {
        public BingCustomSearchConfiguration(string projectConnectionId, string instanceName) { }
        public long? Count { get { throw null; } set { } }
        public string Freshness { get { throw null; } set { } }
        public string InstanceName { get { throw null; } set { } }
        public string Market { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public string SetLang { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.OpenAI.BingCustomSearchConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.BingCustomSearchConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.BingCustomSearchConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.BingCustomSearchConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.BingCustomSearchConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.BingCustomSearchConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BingCustomSearchConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BingCustomSearchConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BingCustomSearchConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingCustomSearchToolParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.BingCustomSearchToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BingCustomSearchToolParameters>
    {
        public BingCustomSearchToolParameters(System.Collections.Generic.IEnumerable<Azure.AI.Projects.OpenAI.BingCustomSearchConfiguration> searchConfigurations) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.OpenAI.BingCustomSearchConfiguration> SearchConfigurations { get { throw null; } }
        protected virtual Azure.AI.Projects.OpenAI.BingCustomSearchToolParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.BingCustomSearchToolParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.BingCustomSearchToolParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.BingCustomSearchToolParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.BingCustomSearchToolParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.BingCustomSearchToolParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BingCustomSearchToolParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BingCustomSearchToolParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BingCustomSearchToolParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingGroundingAgentTool : Azure.AI.Projects.OpenAI.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.BingGroundingAgentTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BingGroundingAgentTool>
    {
        public BingGroundingAgentTool(Azure.AI.Projects.OpenAI.BingGroundingSearchToolOptions bingGrounding) { }
        public Azure.AI.Projects.OpenAI.BingGroundingSearchToolOptions BingGrounding { get { throw null; } set { } }
        protected override Azure.AI.Projects.OpenAI.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.OpenAI.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.BingGroundingAgentTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.BingGroundingAgentTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.BingGroundingAgentTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.BingGroundingAgentTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BingGroundingAgentTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BingGroundingAgentTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BingGroundingAgentTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingGroundingSearchConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.BingGroundingSearchConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BingGroundingSearchConfiguration>
    {
        public BingGroundingSearchConfiguration(string projectConnectionId) { }
        public long? Count { get { throw null; } set { } }
        public string Freshness { get { throw null; } set { } }
        public string Market { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public string SetLang { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.OpenAI.BingGroundingSearchConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.BingGroundingSearchConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.BingGroundingSearchConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.BingGroundingSearchConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.BingGroundingSearchConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.BingGroundingSearchConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BingGroundingSearchConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BingGroundingSearchConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BingGroundingSearchConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BingGroundingSearchToolOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.BingGroundingSearchToolOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BingGroundingSearchToolOptions>
    {
        public BingGroundingSearchToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Projects.OpenAI.BingGroundingSearchConfiguration> searchConfigurations) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.OpenAI.BingGroundingSearchConfiguration> SearchConfigurations { get { throw null; } }
        protected virtual Azure.AI.Projects.OpenAI.BingGroundingSearchToolOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.BingGroundingSearchToolOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.BingGroundingSearchToolOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.BingGroundingSearchToolOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.BingGroundingSearchToolOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.BingGroundingSearchToolOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BingGroundingSearchToolOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BingGroundingSearchToolOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BingGroundingSearchToolOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrowserAutomationAgentTool : Azure.AI.Projects.OpenAI.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.BrowserAutomationAgentTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BrowserAutomationAgentTool>
    {
        public BrowserAutomationAgentTool(Azure.AI.Projects.OpenAI.BrowserAutomationToolParameters browserAutomationPreview) { }
        public Azure.AI.Projects.OpenAI.BrowserAutomationToolParameters BrowserAutomationPreview { get { throw null; } set { } }
        protected override Azure.AI.Projects.OpenAI.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.OpenAI.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.BrowserAutomationAgentTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.BrowserAutomationAgentTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.BrowserAutomationAgentTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.BrowserAutomationAgentTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BrowserAutomationAgentTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BrowserAutomationAgentTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BrowserAutomationAgentTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrowserAutomationToolConnectionParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.BrowserAutomationToolConnectionParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BrowserAutomationToolConnectionParameters>
    {
        public BrowserAutomationToolConnectionParameters(string projectConnectionId) { }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.OpenAI.BrowserAutomationToolConnectionParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.BrowserAutomationToolConnectionParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.BrowserAutomationToolConnectionParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.BrowserAutomationToolConnectionParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.BrowserAutomationToolConnectionParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.BrowserAutomationToolConnectionParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BrowserAutomationToolConnectionParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BrowserAutomationToolConnectionParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BrowserAutomationToolConnectionParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BrowserAutomationToolParameters : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.BrowserAutomationToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BrowserAutomationToolParameters>
    {
        public BrowserAutomationToolParameters(Azure.AI.Projects.OpenAI.BrowserAutomationToolConnectionParameters connection) { }
        public Azure.AI.Projects.OpenAI.BrowserAutomationToolConnectionParameters Connection { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.OpenAI.BrowserAutomationToolParameters JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.BrowserAutomationToolParameters PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.BrowserAutomationToolParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.BrowserAutomationToolParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.BrowserAutomationToolParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.BrowserAutomationToolParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BrowserAutomationToolParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BrowserAutomationToolParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.BrowserAutomationToolParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CaptureStructuredOutputsTool : Azure.AI.Projects.OpenAI.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.CaptureStructuredOutputsTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.CaptureStructuredOutputsTool>
    {
        public CaptureStructuredOutputsTool(Azure.AI.Projects.OpenAI.StructuredOutputDefinition outputs) { }
        public Azure.AI.Projects.OpenAI.StructuredOutputDefinition Outputs { get { throw null; } set { } }
        protected override Azure.AI.Projects.OpenAI.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.OpenAI.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.CaptureStructuredOutputsTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.CaptureStructuredOutputsTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.CaptureStructuredOutputsTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.CaptureStructuredOutputsTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.CaptureStructuredOutputsTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.CaptureStructuredOutputsTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.CaptureStructuredOutputsTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ChatSummaryMemoryItem : Azure.AI.Projects.OpenAI.MemoryItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.ChatSummaryMemoryItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ChatSummaryMemoryItem>
    {
        public ChatSummaryMemoryItem(string memoryId, System.DateTimeOffset updatedAt, string scope, string content) { }
        protected override Azure.AI.Projects.OpenAI.MemoryItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.OpenAI.MemoryItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.ChatSummaryMemoryItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.ChatSummaryMemoryItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.ChatSummaryMemoryItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.ChatSummaryMemoryItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ChatSummaryMemoryItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ChatSummaryMemoryItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ChatSummaryMemoryItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ClientConnectionProviderExtensions
    {
        public static Azure.AI.Projects.OpenAI.ProjectOpenAIClient GetProjectOpenAIClient(this System.ClientModel.Primitives.ClientConnectionProvider connectionProvider, Azure.AI.Projects.OpenAI.ProjectOpenAIClientOptions options = null) { throw null; }
        public sealed partial class <>E__0
        {
            internal <>E__0() { }
            public Azure.AI.Projects.OpenAI.ProjectOpenAIClient GetProjectOpenAIClient(Azure.AI.Projects.OpenAI.ProjectOpenAIClientOptions options = null) { throw null; }
        }
    }
    public partial class ContainerApplicationAgentDefinition : Azure.AI.Projects.OpenAI.AgentDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.ContainerApplicationAgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ContainerApplicationAgentDefinition>
    {
        public ContainerApplicationAgentDefinition(System.Collections.Generic.IEnumerable<Azure.AI.Projects.OpenAI.ProtocolVersionRecord> containerProtocolVersions, string containerAppResourceId, string ingressSubdomainSuffix) { }
        public string ContainerAppResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Projects.OpenAI.ProtocolVersionRecord> ContainerProtocolVersions { get { throw null; } }
        public string IngressSubdomainSuffix { get { throw null; } set { } }
        protected override Azure.AI.Projects.OpenAI.AgentDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.OpenAI.AgentDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.ContainerApplicationAgentDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.ContainerApplicationAgentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.ContainerApplicationAgentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.ContainerApplicationAgentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ContainerApplicationAgentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ContainerApplicationAgentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ContainerApplicationAgentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContentFilterConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.ContentFilterConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ContentFilterConfiguration>
    {
        public ContentFilterConfiguration(string policyName) { }
        public string PolicyName { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.OpenAI.ContentFilterConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.ContentFilterConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.ContentFilterConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.ContentFilterConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.ContentFilterConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.ContentFilterConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ContentFilterConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ContentFilterConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ContentFilterConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ConversationClientExtensions
    {
        public sealed partial class <>E__0
        {
            internal <>E__0() { }
        }
    }
    public partial class FabricDataAgentToolOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.FabricDataAgentToolOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.FabricDataAgentToolOptions>
    {
        public FabricDataAgentToolOptions() { }
        public System.Collections.Generic.IList<Azure.AI.Projects.OpenAI.ToolProjectConnection> ProjectConnections { get { throw null; } }
        protected virtual Azure.AI.Projects.OpenAI.FabricDataAgentToolOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.FabricDataAgentToolOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.FabricDataAgentToolOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.FabricDataAgentToolOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.FabricDataAgentToolOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.FabricDataAgentToolOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.FabricDataAgentToolOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.FabricDataAgentToolOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.FabricDataAgentToolOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HostedAgentDefinition : Azure.AI.Projects.OpenAI.AgentDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.HostedAgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.HostedAgentDefinition>
    {
        public HostedAgentDefinition(System.Collections.Generic.IEnumerable<Azure.AI.Projects.OpenAI.ProtocolVersionRecord> containerProtocolVersions, string cpu, string memory) { }
        public System.Collections.Generic.IList<Azure.AI.Projects.OpenAI.ProtocolVersionRecord> ContainerProtocolVersions { get { throw null; } }
        public string Cpu { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> EnvironmentVariables { get { throw null; } }
        public string Memory { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.Projects.OpenAI.AgentTool> Tools { get { throw null; } }
        protected override Azure.AI.Projects.OpenAI.AgentDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.OpenAI.AgentDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.HostedAgentDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.HostedAgentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.HostedAgentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.HostedAgentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.HostedAgentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.HostedAgentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.HostedAgentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageBasedHostedAgentDefinition : Azure.AI.Projects.OpenAI.HostedAgentDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.ImageBasedHostedAgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ImageBasedHostedAgentDefinition>
    {
        public ImageBasedHostedAgentDefinition(System.Collections.Generic.IEnumerable<Azure.AI.Projects.OpenAI.ProtocolVersionRecord> containerProtocolVersions, string cpu, string memory, string image) : base (default(System.Collections.Generic.IEnumerable<Azure.AI.Projects.OpenAI.ProtocolVersionRecord>), default(string), default(string)) { }
        public string Image { get { throw null; } set { } }
        protected override Azure.AI.Projects.OpenAI.AgentDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.OpenAI.AgentDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.ImageBasedHostedAgentDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.ImageBasedHostedAgentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.ImageBasedHostedAgentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.ImageBasedHostedAgentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ImageBasedHostedAgentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ImageBasedHostedAgentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ImageBasedHostedAgentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class MemoryItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.MemoryItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.MemoryItem>
    {
        internal MemoryItem() { }
        public string Content { get { throw null; } }
        public string MemoryId { get { throw null; } }
        public string Scope { get { throw null; } }
        public System.DateTimeOffset UpdatedAt { get { throw null; } }
        protected virtual Azure.AI.Projects.OpenAI.MemoryItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.MemoryItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.MemoryItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.MemoryItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.MemoryItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.MemoryItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.MemoryItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.MemoryItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.MemoryItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemorySearchItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.MemorySearchItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.MemorySearchItem>
    {
        public MemorySearchItem(Azure.AI.Projects.OpenAI.MemoryItem memoryItem) { }
        public Azure.AI.Projects.OpenAI.MemoryItem MemoryItem { get { throw null; } }
        protected virtual Azure.AI.Projects.OpenAI.MemorySearchItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.MemorySearchItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.MemorySearchItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.MemorySearchItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.MemorySearchItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.MemorySearchItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.MemorySearchItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.MemorySearchItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.MemorySearchItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemorySearchTool : Azure.AI.Projects.OpenAI.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.MemorySearchTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.MemorySearchTool>
    {
        public MemorySearchTool(string memoryStoreName, string scope) { }
        public string MemoryStoreName { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public Azure.AI.Projects.OpenAI.MemorySearchToolOptions SearchOptions { get { throw null; } set { } }
        public int? UpdateDelay { get { throw null; } set { } }
        protected override Azure.AI.Projects.OpenAI.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.OpenAI.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.MemorySearchTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.MemorySearchTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.MemorySearchTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.MemorySearchTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.MemorySearchTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.MemorySearchTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.MemorySearchTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MemorySearchToolCallResponseItem : Azure.AI.Projects.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.MemorySearchToolCallResponseItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.MemorySearchToolCallResponseItem>
    {
        internal MemorySearchToolCallResponseItem() { }
        public System.Collections.Generic.IList<Azure.AI.Projects.OpenAI.MemorySearchItem> Results { get { throw null; } }
        public Azure.AI.Projects.OpenAI.MemorySearchToolCallStatus Status { get { throw null; } }
        protected override Azure.AI.Projects.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.MemorySearchToolCallResponseItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.MemorySearchToolCallResponseItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.MemorySearchToolCallResponseItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.MemorySearchToolCallResponseItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.MemorySearchToolCallResponseItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.MemorySearchToolCallResponseItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.MemorySearchToolCallResponseItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MemorySearchToolCallStatus : System.IEquatable<Azure.AI.Projects.OpenAI.MemorySearchToolCallStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MemorySearchToolCallStatus(string value) { throw null; }
        public static Azure.AI.Projects.OpenAI.MemorySearchToolCallStatus Completed { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.MemorySearchToolCallStatus Failed { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.MemorySearchToolCallStatus Incomplete { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.MemorySearchToolCallStatus InProgress { get { throw null; } }
        public static Azure.AI.Projects.OpenAI.MemorySearchToolCallStatus Searching { get { throw null; } }
        public bool Equals(Azure.AI.Projects.OpenAI.MemorySearchToolCallStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.Projects.OpenAI.MemorySearchToolCallStatus left, Azure.AI.Projects.OpenAI.MemorySearchToolCallStatus right) { throw null; }
        public static implicit operator Azure.AI.Projects.OpenAI.MemorySearchToolCallStatus (string value) { throw null; }
        public static implicit operator Azure.AI.Projects.OpenAI.MemorySearchToolCallStatus? (string value) { throw null; }
        public static bool operator !=(Azure.AI.Projects.OpenAI.MemorySearchToolCallStatus left, Azure.AI.Projects.OpenAI.MemorySearchToolCallStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MemorySearchToolOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.MemorySearchToolOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.MemorySearchToolOptions>
    {
        public MemorySearchToolOptions() { }
        public int? MaxMemories { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.OpenAI.MemorySearchToolOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.MemorySearchToolOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.MemorySearchToolOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.MemorySearchToolOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.MemorySearchToolOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.MemorySearchToolOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.MemorySearchToolOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.MemorySearchToolOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.MemorySearchToolOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MicrosoftFabricAgentTool : Azure.AI.Projects.OpenAI.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.MicrosoftFabricAgentTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.MicrosoftFabricAgentTool>
    {
        public MicrosoftFabricAgentTool(Azure.AI.Projects.OpenAI.FabricDataAgentToolOptions fabricDataagentPreview) { }
        public Azure.AI.Projects.OpenAI.FabricDataAgentToolOptions FabricDataagentPreview { get { throw null; } set { } }
        protected override Azure.AI.Projects.OpenAI.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.OpenAI.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.MicrosoftFabricAgentTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.MicrosoftFabricAgentTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.MicrosoftFabricAgentTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.MicrosoftFabricAgentTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.MicrosoftFabricAgentTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.MicrosoftFabricAgentTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.MicrosoftFabricAgentTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OAuthConsentRequestResponseItem : Azure.AI.Projects.OpenAI.AgentResponseItem, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.OAuthConsentRequestResponseItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OAuthConsentRequestResponseItem>
    {
        internal OAuthConsentRequestResponseItem() { }
        public string ConsentLink { get { throw null; } }
        public override string Id { get { throw null; } }
        public string ServerLabel { get { throw null; } }
        protected override Azure.AI.Projects.OpenAI.AgentResponseItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.OpenAI.AgentResponseItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.OAuthConsentRequestResponseItem System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.OAuthConsentRequestResponseItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.OAuthConsentRequestResponseItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.OAuthConsentRequestResponseItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OAuthConsentRequestResponseItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OAuthConsentRequestResponseItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OAuthConsentRequestResponseItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class OpenAIFileExtensions
    {
        public static string GetAzureFileStatus(this OpenAI.Files.OpenAIFile file) { throw null; }
    }
    public static partial class OpenAIResponseExtension
    {
        public static System.ClientModel.ClientResult<OpenAI.Responses.OpenAIResponse> CreateResponse(this OpenAI.Responses.OpenAIResponseClient responseClient, Azure.AI.Projects.OpenAI.AgentConversation conversation, Azure.AI.Projects.OpenAI.AgentReference agentRef, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<System.ClientModel.ClientResult<OpenAI.Responses.OpenAIResponse>> CreateResponseAsync(this OpenAI.Responses.OpenAIResponseClient responseClient, Azure.AI.Projects.OpenAI.AgentConversation conversation, Azure.AI.Projects.OpenAI.AgentReference agentRef, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OpenAPIAgentTool : Azure.AI.Projects.OpenAI.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.OpenAPIAgentTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIAgentTool>
    {
        public OpenAPIAgentTool(Azure.AI.Projects.OpenAI.OpenAPIFunctionDefinition openapi) { }
        public Azure.AI.Projects.OpenAI.OpenAPIFunctionDefinition Openapi { get { throw null; } set { } }
        protected override Azure.AI.Projects.OpenAI.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.OpenAI.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.OpenAPIAgentTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.OpenAPIAgentTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.OpenAPIAgentTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.OpenAPIAgentTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIAgentTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIAgentTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIAgentTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenAPIAnonymousAuthenticationDetails : Azure.AI.Projects.OpenAI.OpenAPIAuthenticationDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.OpenAPIAnonymousAuthenticationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIAnonymousAuthenticationDetails>
    {
        public OpenAPIAnonymousAuthenticationDetails() { }
        protected override Azure.AI.Projects.OpenAI.OpenAPIAuthenticationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.OpenAI.OpenAPIAuthenticationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.OpenAPIAnonymousAuthenticationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.OpenAPIAnonymousAuthenticationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.OpenAPIAnonymousAuthenticationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.OpenAPIAnonymousAuthenticationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIAnonymousAuthenticationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIAnonymousAuthenticationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIAnonymousAuthenticationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class OpenAPIAuthenticationDetails : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.OpenAPIAuthenticationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIAuthenticationDetails>
    {
        internal OpenAPIAuthenticationDetails() { }
        protected virtual Azure.AI.Projects.OpenAI.OpenAPIAuthenticationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.OpenAPIAuthenticationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.OpenAPIAuthenticationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.OpenAPIAuthenticationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.OpenAPIAuthenticationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.OpenAPIAuthenticationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIAuthenticationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIAuthenticationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIAuthenticationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenAPIFunctionDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.OpenAPIFunctionDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIFunctionDefinition>
    {
        public OpenAPIFunctionDefinition(string name, System.BinaryData spec, Azure.AI.Projects.OpenAI.OpenAPIAuthenticationDetails auth) { }
        public Azure.AI.Projects.OpenAI.OpenAPIAuthenticationDetails Auth { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DefaultParams { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.Projects.OpenAI.OpenAPIFunctionEntry> Functions { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Spec { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.OpenAI.OpenAPIFunctionDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.OpenAPIFunctionDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.OpenAPIFunctionDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.OpenAPIFunctionDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.OpenAPIFunctionDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.OpenAPIFunctionDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIFunctionDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIFunctionDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIFunctionDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenAPIFunctionEntry : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.OpenAPIFunctionEntry>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIFunctionEntry>
    {
        public OpenAPIFunctionEntry(string name, System.BinaryData parameters) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Parameters { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.OpenAI.OpenAPIFunctionEntry JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.OpenAPIFunctionEntry PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.OpenAPIFunctionEntry System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.OpenAPIFunctionEntry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.OpenAPIFunctionEntry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.OpenAPIFunctionEntry System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIFunctionEntry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIFunctionEntry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIFunctionEntry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenAPIManagedAuthenticationDetails : Azure.AI.Projects.OpenAI.OpenAPIAuthenticationDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.OpenAPIManagedAuthenticationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIManagedAuthenticationDetails>
    {
        public OpenAPIManagedAuthenticationDetails(Azure.AI.Projects.OpenAI.OpenApiManagedSecurityScheme securityScheme) { }
        public Azure.AI.Projects.OpenAI.OpenApiManagedSecurityScheme SecurityScheme { get { throw null; } set { } }
        protected override Azure.AI.Projects.OpenAI.OpenAPIAuthenticationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.OpenAI.OpenAPIAuthenticationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.OpenAPIManagedAuthenticationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.OpenAPIManagedAuthenticationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.OpenAPIManagedAuthenticationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.OpenAPIManagedAuthenticationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIManagedAuthenticationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIManagedAuthenticationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIManagedAuthenticationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenApiManagedSecurityScheme : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.OpenApiManagedSecurityScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenApiManagedSecurityScheme>
    {
        public OpenApiManagedSecurityScheme(string audience) { }
        public string Audience { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.OpenAI.OpenApiManagedSecurityScheme JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.OpenApiManagedSecurityScheme PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.OpenApiManagedSecurityScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.OpenApiManagedSecurityScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.OpenApiManagedSecurityScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.OpenApiManagedSecurityScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenApiManagedSecurityScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenApiManagedSecurityScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenApiManagedSecurityScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenAPIProjectConnectionAuthenticationDetails : Azure.AI.Projects.OpenAI.OpenAPIAuthenticationDetails, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.OpenAPIProjectConnectionAuthenticationDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIProjectConnectionAuthenticationDetails>
    {
        public OpenAPIProjectConnectionAuthenticationDetails(Azure.AI.Projects.OpenAI.OpenAPIProjectConnectionSecurityScheme securityScheme) { }
        public Azure.AI.Projects.OpenAI.OpenAPIProjectConnectionSecurityScheme SecurityScheme { get { throw null; } set { } }
        protected override Azure.AI.Projects.OpenAI.OpenAPIAuthenticationDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.OpenAI.OpenAPIAuthenticationDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.OpenAPIProjectConnectionAuthenticationDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.OpenAPIProjectConnectionAuthenticationDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.OpenAPIProjectConnectionAuthenticationDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.OpenAPIProjectConnectionAuthenticationDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIProjectConnectionAuthenticationDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIProjectConnectionAuthenticationDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIProjectConnectionAuthenticationDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OpenAPIProjectConnectionSecurityScheme : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.OpenAPIProjectConnectionSecurityScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIProjectConnectionSecurityScheme>
    {
        public OpenAPIProjectConnectionSecurityScheme(string projectConnectionId) { }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.OpenAI.OpenAPIProjectConnectionSecurityScheme JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.OpenAPIProjectConnectionSecurityScheme PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.OpenAPIProjectConnectionSecurityScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.OpenAPIProjectConnectionSecurityScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.OpenAPIProjectConnectionSecurityScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.OpenAPIProjectConnectionSecurityScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIProjectConnectionSecurityScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIProjectConnectionSecurityScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.OpenAPIProjectConnectionSecurityScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectConversationCreationOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.ProjectConversationCreationOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ProjectConversationCreationOptions>
    {
        public ProjectConversationCreationOptions() { }
        public System.Collections.Generic.IList<OpenAI.Responses.ResponseItem> Items { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        protected virtual Azure.AI.Projects.OpenAI.ProjectConversationCreationOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.ProjectConversationCreationOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.ProjectConversationCreationOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.ProjectConversationCreationOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.ProjectConversationCreationOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.ProjectConversationCreationOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ProjectConversationCreationOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ProjectConversationCreationOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ProjectConversationCreationOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectConversationUpdateOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.ProjectConversationUpdateOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ProjectConversationUpdateOptions>
    {
        public ProjectConversationUpdateOptions() { }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        protected virtual Azure.AI.Projects.OpenAI.ProjectConversationUpdateOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.ProjectConversationUpdateOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.ProjectConversationUpdateOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.ProjectConversationUpdateOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.ProjectConversationUpdateOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.ProjectConversationUpdateOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ProjectConversationUpdateOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ProjectConversationUpdateOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ProjectConversationUpdateOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProjectOpenAIClient : OpenAI.OpenAIClient
    {
        protected ProjectOpenAIClient() { }
        public ProjectOpenAIClient(System.ClientModel.Primitives.AuthenticationPolicy authenticationPolicy, Azure.AI.Projects.OpenAI.ProjectOpenAIClientOptions options) { }
        protected internal ProjectOpenAIClient(System.ClientModel.Primitives.ClientPipeline pipeline, Azure.AI.Projects.OpenAI.ProjectOpenAIClientOptions options) { }
        public ProjectOpenAIClient(System.Uri projectEndpoint, System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Projects.OpenAI.ProjectOpenAIClientOptions options = null) { }
        public virtual Azure.AI.Projects.OpenAI.ProjectOpenAIConversationClient Conversations { get { throw null; } }
        public virtual Azure.AI.Projects.OpenAI.ProjectOpenAIFileClient Files { get { throw null; } }
        public virtual Azure.AI.Projects.OpenAI.ProjectOpenAIResponseClient Responses { get { throw null; } }
        public virtual Azure.AI.Projects.OpenAI.ProjectOpenAIVectorStoreClient VectorStores { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override OpenAI.Conversations.ConversationClient GetConversationClient() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override OpenAI.Files.OpenAIFileClient GetOpenAIFileClient() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override OpenAI.Responses.OpenAIResponseClient GetOpenAIResponseClient(string model) { throw null; }
        public virtual Azure.AI.Projects.OpenAI.ProjectOpenAIConversationClient GetProjectOpenAIConversationClient() { throw null; }
        public virtual Azure.AI.Projects.OpenAI.ProjectOpenAIFileClient GetProjectOpenAIFileClient() { throw null; }
        public virtual Azure.AI.Projects.OpenAI.ProjectOpenAIResponseClient GetProjectOpenAIResponseClient() { throw null; }
        public virtual Azure.AI.Projects.OpenAI.ProjectOpenAIResponseClient GetProjectOpenAIResponseClientForAgent(Azure.AI.Projects.OpenAI.AgentReference agent, string agentConversationId = null) { throw null; }
        public virtual Azure.AI.Projects.OpenAI.ProjectOpenAIResponseClient GetProjectOpenAIResponseClientForModel(string model) { throw null; }
        public virtual Azure.AI.Projects.OpenAI.ProjectOpenAIVectorStoreClient GetProjectOpenAIVectorStoreClient() { throw null; }
    }
    public partial class ProjectOpenAIClientOptions : OpenAI.OpenAIClientOptions
    {
        public ProjectOpenAIClientOptions() { }
        public string ApiVersion { get { throw null; } set { } }
    }
    public partial class ProjectOpenAIConversationClient : OpenAI.Conversations.ConversationClient
    {
        protected ProjectOpenAIConversationClient() { }
        public ProjectOpenAIConversationClient(System.ClientModel.Primitives.ClientPipeline pipeline, OpenAI.OpenAIClientOptions options) { }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.OpenAI.AgentConversation> CreateAgentConversation(Azure.AI.Projects.OpenAI.ProjectConversationCreationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.OpenAI.AgentConversation>> CreateAgentConversationAsync(Azure.AI.Projects.OpenAI.ProjectConversationCreationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<System.Collections.ObjectModel.ReadOnlyCollection<OpenAI.Responses.ResponseItem>> CreateAgentConversationItems(string conversationId, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> items, System.Collections.Generic.IEnumerable<OpenAI.Conversations.IncludedConversationItemProperty> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<System.Collections.ObjectModel.ReadOnlyCollection<OpenAI.Responses.ResponseItem>>> CreateAgentConversationItemsAsync(string conversationId, System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> items, System.Collections.Generic.IEnumerable<OpenAI.Conversations.IncludedConversationItemProperty> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.OpenAI.AgentConversation> GetAgentConversation(string conversationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.OpenAI.AgentConversation>> GetAgentConversationAsync(string conversationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.OpenAI.AgentResponseItem> GetAgentConversationItems(string conversationId, int? limit = default(int?), string order = null, string after = null, System.Collections.Generic.IEnumerable<OpenAI.Conversations.IncludedConversationItemProperty> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.OpenAI.AgentResponseItem> GetAgentConversationItemsAsync(string conversationId, int? limit = default(int?), string order = null, string after = null, System.Collections.Generic.IEnumerable<OpenAI.Conversations.IncludedConversationItemProperty> include = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.CollectionResult<Azure.AI.Projects.OpenAI.AgentConversation> GetAgentConversations(int? limit = default(int?), string order = null, string after = null, string before = null, string agentName = null, string agentId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.AsyncCollectionResult<Azure.AI.Projects.OpenAI.AgentConversation> GetAgentConversationsAsync(int? limit = default(int?), string order = null, string after = null, string before = null, string agentName = null, string agentId = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.ClientModel.ClientResult<Azure.AI.Projects.OpenAI.AgentConversation> UpdateAgentConversation(string conversationId, Azure.AI.Projects.OpenAI.ProjectConversationUpdateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.ClientModel.ClientResult<Azure.AI.Projects.OpenAI.AgentConversation>> UpdateAgentConversationAsync(string conversationId, Azure.AI.Projects.OpenAI.ProjectConversationUpdateOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProjectOpenAIFileClient : OpenAI.Files.OpenAIFileClient
    {
        protected ProjectOpenAIFileClient() { }
    }
    public partial class ProjectOpenAIResponseClient : OpenAI.Responses.OpenAIResponseClient
    {
        protected ProjectOpenAIResponseClient() { }
        public ProjectOpenAIResponseClient(System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Projects.OpenAI.ProjectOpenAIClientOptions options) { }
        public ProjectOpenAIResponseClient(System.Uri projectEndpoint, System.ClientModel.AuthenticationTokenProvider tokenProvider, Azure.AI.Projects.OpenAI.ProjectOpenAIClientOptions options = null) { }
        public override System.ClientModel.ClientResult<OpenAI.Responses.OpenAIResponse> CreateResponse(System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> inputItems, OpenAI.Responses.ResponseCreationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.ClientModel.ClientResult<OpenAI.Responses.OpenAIResponse> CreateResponse(string userInputText, OpenAI.Responses.ResponseCreationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<System.ClientModel.ClientResult<OpenAI.Responses.OpenAIResponse>> CreateResponseAsync(System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> inputItems, OpenAI.Responses.ResponseCreationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.Task<System.ClientModel.ClientResult<OpenAI.Responses.OpenAIResponse>> CreateResponseAsync(string userInputText, OpenAI.Responses.ResponseCreationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.ClientModel.CollectionResult<OpenAI.Responses.StreamingResponseUpdate> CreateResponseStreaming(System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> inputItems, OpenAI.Responses.ResponseCreationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.ClientModel.CollectionResult<OpenAI.Responses.StreamingResponseUpdate> CreateResponseStreaming(string userInputText, OpenAI.Responses.ResponseCreationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.ClientModel.AsyncCollectionResult<OpenAI.Responses.StreamingResponseUpdate> CreateResponseStreamingAsync(System.Collections.Generic.IEnumerable<OpenAI.Responses.ResponseItem> inputItems, OpenAI.Responses.ResponseCreationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.ClientModel.AsyncCollectionResult<OpenAI.Responses.StreamingResponseUpdate> CreateResponseStreamingAsync(string userInputText, OpenAI.Responses.ResponseCreationOptions options = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ProjectOpenAIVectorStoreClient : OpenAI.VectorStores.VectorStoreClient
    {
        protected ProjectOpenAIVectorStoreClient() { }
    }
    public static partial class ProjectsOpenAIModelFactory
    {
        public static Azure.AI.Projects.OpenAI.A2ATool A2ATool(System.Uri baseUri = null, string agentCardPath = null, string projectConnectionId = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.AgentConversation AgentConversation(string id = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), System.Collections.Generic.IDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.AgentDefinition AgentDefinition(string kind = null, Azure.AI.Projects.OpenAI.ContentFilterConfiguration contentFilterConfiguration = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.AgentInfo AgentInfo(string name = null, string version = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.AgentObjectVersions AgentObjectVersions(Azure.AI.Projects.OpenAI.AgentVersion latest = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.AgentRecord AgentRecord(string id = null, string name = null, Azure.AI.Projects.OpenAI.AgentObjectVersions versions = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.AgentReference AgentReference(string name = null, string version = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.AgentResponseItem AgentResponseItem(string type = null, string id = null, Azure.AI.Projects.OpenAI.AgentResponseItemSource createdBy = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.AgentResponseItemSource AgentResponseItemSource(Azure.AI.Projects.OpenAI.AgentInfo agent = null, string responseId = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.AgentStructuredOutputsResponseItem AgentStructuredOutputsResponseItem(string id = null, Azure.AI.Projects.OpenAI.AgentResponseItemSource createdBy = null, System.BinaryData output = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.AgentTool AgentTool(string type = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.AgentVersion AgentVersion(System.Collections.Generic.IDictionary<string, string> metadata = null, string id = null, string name = null, string version = null, string description = null, System.DateTimeOffset createdAt = default(System.DateTimeOffset), Azure.AI.Projects.OpenAI.AgentDefinition definition = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.AgentWorkflowActionResponseItem AgentWorkflowActionResponseItem(string id = null, Azure.AI.Projects.OpenAI.AgentResponseItemSource createdBy = null, string kind = null, string actionId = null, string parentActionId = null, string previousActionId = null, Azure.AI.Projects.OpenAI.AgentWorkflowActionStatus? status = default(Azure.AI.Projects.OpenAI.AgentWorkflowActionStatus?)) { throw null; }
        public static Azure.AI.Projects.OpenAI.AzureAISearchAgentTool AzureAISearchAgentTool(Azure.AI.Projects.OpenAI.AzureAISearchToolOptions options = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.AzureAISearchIndex AzureAISearchIndex(string projectConnectionId = null, string indexName = null, Azure.AI.Projects.OpenAI.AzureAISearchQueryType? queryType = default(Azure.AI.Projects.OpenAI.AzureAISearchQueryType?), int? topK = default(int?), string filter = null, string indexAssetId = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.AzureAISearchToolOptions AzureAISearchToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Projects.OpenAI.AzureAISearchIndex> indexes = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.AzureFunctionAgentTool AzureFunctionAgentTool(Azure.AI.Projects.OpenAI.AzureFunctionDefinition azureFunction = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.AzureFunctionBinding AzureFunctionBinding(Azure.AI.Projects.OpenAI.AzureFunctionStorageQueue storageQueue = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.AzureFunctionDefinition AzureFunctionDefinition(Azure.AI.Projects.OpenAI.AzureFunctionDefinitionFunction function = null, Azure.AI.Projects.OpenAI.AzureFunctionBinding inputBinding = null, Azure.AI.Projects.OpenAI.AzureFunctionBinding outputBinding = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.AzureFunctionDefinitionFunction AzureFunctionDefinitionFunction(string name = null, string description = null, System.BinaryData parameters = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.AzureFunctionStorageQueue AzureFunctionStorageQueue(string queueServiceEndpoint = null, string queueName = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.BingCustomSearchAgentTool BingCustomSearchAgentTool(Azure.AI.Projects.OpenAI.BingCustomSearchToolParameters bingCustomSearchPreview = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.BingCustomSearchConfiguration BingCustomSearchConfiguration(string projectConnectionId = null, string instanceName = null, string market = null, string setLang = null, long? count = default(long?), string freshness = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.BingCustomSearchToolParameters BingCustomSearchToolParameters(System.Collections.Generic.IEnumerable<Azure.AI.Projects.OpenAI.BingCustomSearchConfiguration> searchConfigurations = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.BingGroundingAgentTool BingGroundingAgentTool(Azure.AI.Projects.OpenAI.BingGroundingSearchToolOptions bingGrounding = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.BingGroundingSearchConfiguration BingGroundingSearchConfiguration(string projectConnectionId = null, string market = null, string setLang = null, long? count = default(long?), string freshness = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.BingGroundingSearchToolOptions BingGroundingSearchToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Projects.OpenAI.BingGroundingSearchConfiguration> searchConfigurations = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.BrowserAutomationAgentTool BrowserAutomationAgentTool(Azure.AI.Projects.OpenAI.BrowserAutomationToolParameters browserAutomationPreview = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.BrowserAutomationToolConnectionParameters BrowserAutomationToolConnectionParameters(string projectConnectionId = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.BrowserAutomationToolParameters BrowserAutomationToolParameters(Azure.AI.Projects.OpenAI.BrowserAutomationToolConnectionParameters connection = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.CaptureStructuredOutputsTool CaptureStructuredOutputsTool(Azure.AI.Projects.OpenAI.StructuredOutputDefinition outputs = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.ChatSummaryMemoryItem ChatSummaryMemoryItem(string memoryId = null, System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string scope = null, string content = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.ContainerApplicationAgentDefinition ContainerApplicationAgentDefinition(Azure.AI.Projects.OpenAI.ContentFilterConfiguration contentFilterConfiguration = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.OpenAI.ProtocolVersionRecord> containerProtocolVersions = null, string containerAppResourceId = null, string ingressSubdomainSuffix = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.ContentFilterConfiguration ContentFilterConfiguration(string policyName = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.FabricDataAgentToolOptions FabricDataAgentToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Projects.OpenAI.ToolProjectConnection> projectConnections = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.HostedAgentDefinition HostedAgentDefinition(Azure.AI.Projects.OpenAI.ContentFilterConfiguration contentFilterConfiguration = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.OpenAI.AgentTool> tools = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.OpenAI.ProtocolVersionRecord> containerProtocolVersions = null, string cpu = null, string memory = null, System.Collections.Generic.IDictionary<string, string> environmentVariables = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.ImageBasedHostedAgentDefinition ImageBasedHostedAgentDefinition(Azure.AI.Projects.OpenAI.ContentFilterConfiguration contentFilterConfiguration = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.OpenAI.AgentTool> tools = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.OpenAI.ProtocolVersionRecord> containerProtocolVersions = null, string cpu = null, string memory = null, System.Collections.Generic.IDictionary<string, string> environmentVariables = null, string image = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.MemoryItem MemoryItem(string memoryId = null, System.DateTimeOffset updatedAt = default(System.DateTimeOffset), string scope = null, string content = null, string kind = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.MemorySearchItem MemorySearchItem(Azure.AI.Projects.OpenAI.MemoryItem memoryItem = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.MemorySearchTool MemorySearchTool(string memoryStoreName = null, string scope = null, Azure.AI.Projects.OpenAI.MemorySearchToolOptions searchOptions = null, int? updateDelay = default(int?)) { throw null; }
        public static Azure.AI.Projects.OpenAI.MemorySearchToolCallResponseItem MemorySearchToolCallResponseItem(string id = null, Azure.AI.Projects.OpenAI.AgentResponseItemSource createdBy = null, Azure.AI.Projects.OpenAI.MemorySearchToolCallStatus status = default(Azure.AI.Projects.OpenAI.MemorySearchToolCallStatus), System.Collections.Generic.IEnumerable<Azure.AI.Projects.OpenAI.MemorySearchItem> results = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.MemorySearchToolOptions MemorySearchToolOptions(int? maxMemories = default(int?)) { throw null; }
        public static Azure.AI.Projects.OpenAI.MicrosoftFabricAgentTool MicrosoftFabricAgentTool(Azure.AI.Projects.OpenAI.FabricDataAgentToolOptions fabricDataagentPreview = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.OAuthConsentRequestResponseItem OAuthConsentRequestResponseItem(Azure.AI.Projects.OpenAI.AgentResponseItemSource createdBy = null, string id = null, string consentLink = null, string serverLabel = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.OpenAPIAgentTool OpenAPIAgentTool(Azure.AI.Projects.OpenAI.OpenAPIFunctionDefinition openapi = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.OpenAPIAnonymousAuthenticationDetails OpenAPIAnonymousAuthenticationDetails() { throw null; }
        public static Azure.AI.Projects.OpenAI.OpenAPIAuthenticationDetails OpenAPIAuthenticationDetails(string type = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.OpenAPIFunctionDefinition OpenAPIFunctionDefinition(string name = null, string description = null, System.BinaryData spec = null, Azure.AI.Projects.OpenAI.OpenAPIAuthenticationDetails auth = null, System.Collections.Generic.IEnumerable<string> defaultParams = null, System.Collections.Generic.IEnumerable<Azure.AI.Projects.OpenAI.OpenAPIFunctionEntry> functions = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.OpenAPIFunctionEntry OpenAPIFunctionEntry(string name = null, string description = null, System.BinaryData parameters = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.OpenAPIManagedAuthenticationDetails OpenAPIManagedAuthenticationDetails(Azure.AI.Projects.OpenAI.OpenApiManagedSecurityScheme securityScheme = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.OpenApiManagedSecurityScheme OpenApiManagedSecurityScheme(string audience = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.OpenAPIProjectConnectionAuthenticationDetails OpenAPIProjectConnectionAuthenticationDetails(Azure.AI.Projects.OpenAI.OpenAPIProjectConnectionSecurityScheme securityScheme = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.OpenAPIProjectConnectionSecurityScheme OpenAPIProjectConnectionSecurityScheme(string projectConnectionId = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.ProjectConversationUpdateOptions ProjectConversationUpdateOptions(System.Collections.Generic.IDictionary<string, string> metadata = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.ProtocolVersionRecord ProtocolVersionRecord(Azure.AI.Projects.OpenAI.AgentCommunicationMethod protocol = default(Azure.AI.Projects.OpenAI.AgentCommunicationMethod), string version = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.SharepointAgentTool SharepointAgentTool(Azure.AI.Projects.OpenAI.SharePointGroundingToolOptions sharepointGroundingPreview = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.SharePointGroundingToolOptions SharePointGroundingToolOptions(System.Collections.Generic.IEnumerable<Azure.AI.Projects.OpenAI.ToolProjectConnection> projectConnections = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.StructuredInputDefinition StructuredInputDefinition(string description = null, System.BinaryData defaultValue = null, System.BinaryData schema = null, bool? isRequired = default(bool?)) { throw null; }
        public static Azure.AI.Projects.OpenAI.StructuredOutputDefinition StructuredOutputDefinition(string name = null, string description = null, System.BinaryData schema = null, bool? strict = default(bool?)) { throw null; }
        public static Azure.AI.Projects.OpenAI.ToolProjectConnection ToolProjectConnection(string projectConnectionId = null) { throw null; }
        public static Azure.AI.Projects.OpenAI.WorkflowAgentDefinition WorkflowAgentDefinition(Azure.AI.Projects.OpenAI.ContentFilterConfiguration contentFilterConfiguration = null, string workflowYaml = null) { throw null; }
    }
    public partial class PromptAgentDefinition : Azure.AI.Projects.OpenAI.AgentDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.PromptAgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.PromptAgentDefinition>
    {
        public PromptAgentDefinition(string model) { }
        public string Instructions { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public OpenAI.Responses.ResponseReasoningOptions ReasoningOptions { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.Projects.OpenAI.StructuredInputDefinition> StructuredInputs { get { throw null; } }
        public float? Temperature { get { throw null; } set { } }
        public OpenAI.Responses.ResponseTextOptions TextOptions { get { throw null; } set { } }
        public System.Collections.Generic.IList<OpenAI.Responses.ResponseTool> Tools { get { throw null; } }
        public float? TopP { get { throw null; } set { } }
        protected override Azure.AI.Projects.OpenAI.AgentDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.OpenAI.AgentDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.PromptAgentDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.PromptAgentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.PromptAgentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.PromptAgentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.PromptAgentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.PromptAgentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.PromptAgentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProtocolVersionRecord : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.ProtocolVersionRecord>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ProtocolVersionRecord>
    {
        public ProtocolVersionRecord(Azure.AI.Projects.OpenAI.AgentCommunicationMethod protocol, string version) { }
        public Azure.AI.Projects.OpenAI.AgentCommunicationMethod Protocol { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.OpenAI.ProtocolVersionRecord JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.ProtocolVersionRecord PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.ProtocolVersionRecord System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.ProtocolVersionRecord>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.ProtocolVersionRecord>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.ProtocolVersionRecord System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ProtocolVersionRecord>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ProtocolVersionRecord>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ProtocolVersionRecord>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ResponseCreationOptionsExtensions
    {
        public static void AddStructuredInput(this OpenAI.Responses.ResponseCreationOptions options, string key, string value) { }
        public static Azure.AI.Projects.OpenAI.AgentReference get_Agent(OpenAI.Responses.ResponseCreationOptions options) { throw null; }
        public static string get_AgentConversationId(OpenAI.Responses.ResponseCreationOptions options) { throw null; }
        public static string get_Model(OpenAI.Responses.ResponseCreationOptions options) { throw null; }
        public static void SetStructuredInputs(this OpenAI.Responses.ResponseCreationOptions options, System.BinaryData structuredInputsBytes) { }
        public static void set_Agent(OpenAI.Responses.ResponseCreationOptions options, Azure.AI.Projects.OpenAI.AgentReference value) { }
        public static void set_AgentConversationId(OpenAI.Responses.ResponseCreationOptions options, string value) { }
        public static void set_Model(OpenAI.Responses.ResponseCreationOptions options, string value) { }
        public sealed partial class <>E__0
        {
            internal <>E__0() { }
            public Azure.AI.Projects.OpenAI.AgentReference Agent { get { throw null; } set { } }
            public string AgentConversationId { get { throw null; } set { } }
            public string Model { get { throw null; } set { } }
        }
    }
    public static partial class ResponseItemExtensions
    {
        public static Azure.AI.Projects.OpenAI.AgentResponseItem AsAgentResponseItem(this OpenAI.Responses.ResponseItem responseItem) { throw null; }
    }
    public static partial class ResponseToolExtensions
    {
        public static Azure.AI.Projects.OpenAI.AgentTool AsAgentTool(this OpenAI.Responses.ResponseTool responseTool) { throw null; }
    }
    public partial class SharepointAgentTool : Azure.AI.Projects.OpenAI.AgentTool, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.SharepointAgentTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.SharepointAgentTool>
    {
        public SharepointAgentTool(Azure.AI.Projects.OpenAI.SharePointGroundingToolOptions sharepointGroundingPreview) { }
        public Azure.AI.Projects.OpenAI.SharePointGroundingToolOptions SharepointGroundingPreview { get { throw null; } set { } }
        protected override Azure.AI.Projects.OpenAI.AgentTool JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.OpenAI.AgentTool PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.SharepointAgentTool System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.SharepointAgentTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.SharepointAgentTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.SharepointAgentTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.SharepointAgentTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.SharepointAgentTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.SharepointAgentTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SharePointGroundingToolOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.SharePointGroundingToolOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.SharePointGroundingToolOptions>
    {
        public SharePointGroundingToolOptions() { }
        public System.Collections.Generic.IList<Azure.AI.Projects.OpenAI.ToolProjectConnection> ProjectConnections { get { throw null; } }
        protected virtual Azure.AI.Projects.OpenAI.SharePointGroundingToolOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.SharePointGroundingToolOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.SharePointGroundingToolOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.SharePointGroundingToolOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.SharePointGroundingToolOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.SharePointGroundingToolOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.SharePointGroundingToolOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.SharePointGroundingToolOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.SharePointGroundingToolOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StructuredInputDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.StructuredInputDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.StructuredInputDefinition>
    {
        public StructuredInputDefinition() { }
        public System.BinaryData DefaultValue { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? IsRequired { get { throw null; } set { } }
        public System.BinaryData Schema { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.OpenAI.StructuredInputDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.StructuredInputDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.StructuredInputDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.StructuredInputDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.StructuredInputDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.StructuredInputDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.StructuredInputDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.StructuredInputDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.StructuredInputDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StructuredOutputDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.StructuredOutputDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.StructuredOutputDefinition>
    {
        public StructuredOutputDefinition(string name, string description, System.BinaryData schema, bool? strict) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Schema { get { throw null; } set { } }
        public bool? Strict { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.OpenAI.StructuredOutputDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.StructuredOutputDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.StructuredOutputDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.StructuredOutputDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.StructuredOutputDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.StructuredOutputDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.StructuredOutputDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.StructuredOutputDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.StructuredOutputDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ToolProjectConnection : System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.ToolProjectConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ToolProjectConnection>
    {
        public ToolProjectConnection(string projectConnectionId) { }
        public string ProjectConnectionId { get { throw null; } set { } }
        protected virtual Azure.AI.Projects.OpenAI.ToolProjectConnection JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.Projects.OpenAI.ToolProjectConnection PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.ToolProjectConnection System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.ToolProjectConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.ToolProjectConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.ToolProjectConnection System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ToolProjectConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ToolProjectConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.ToolProjectConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkflowAgentDefinition : Azure.AI.Projects.OpenAI.AgentDefinition, System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.WorkflowAgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.WorkflowAgentDefinition>
    {
        internal WorkflowAgentDefinition() { }
        public static Azure.AI.Projects.OpenAI.WorkflowAgentDefinition FromYaml(string workflowYamlDocument) { throw null; }
        protected override Azure.AI.Projects.OpenAI.AgentDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.Projects.OpenAI.AgentDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.Projects.OpenAI.WorkflowAgentDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.WorkflowAgentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.Projects.OpenAI.WorkflowAgentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.Projects.OpenAI.WorkflowAgentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.WorkflowAgentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.WorkflowAgentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.Projects.OpenAI.WorkflowAgentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
