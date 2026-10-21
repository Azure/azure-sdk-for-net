namespace Azure.AI.ContentSafety
{
    public partial class AacsContextExtension : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AacsContextExtension>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AacsContextExtension>
    {
        public AacsContextExtension() { }
        public Azure.AI.ContentSafety.AacsSubjectRole? Role { get { throw null; } set { } }
        protected virtual Azure.AI.ContentSafety.AacsContextExtension JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.AacsContextExtension PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AacsContextExtension System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AacsContextExtension>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AacsContextExtension>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AacsContextExtension System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AacsContextExtension>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AacsContextExtension>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AacsContextExtension>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AacsSubjectRole : System.IEquatable<Azure.AI.ContentSafety.AacsSubjectRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AacsSubjectRole(string value) { throw null; }
        public static Azure.AI.ContentSafety.AacsSubjectRole Assistant { get { throw null; } }
        public static Azure.AI.ContentSafety.AacsSubjectRole Function { get { throw null; } }
        public static Azure.AI.ContentSafety.AacsSubjectRole System { get { throw null; } }
        public static Azure.AI.ContentSafety.AacsSubjectRole Tool { get { throw null; } }
        public static Azure.AI.ContentSafety.AacsSubjectRole User { get { throw null; } }
        public bool Equals(Azure.AI.ContentSafety.AacsSubjectRole other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.ContentSafety.AacsSubjectRole left, Azure.AI.ContentSafety.AacsSubjectRole right) { throw null; }
        public static implicit operator Azure.AI.ContentSafety.AacsSubjectRole (string value) { throw null; }
        public static implicit operator Azure.AI.ContentSafety.AacsSubjectRole? (string value) { throw null; }
        public static bool operator !=(Azure.AI.ContentSafety.AacsSubjectRole left, Azure.AI.ContentSafety.AacsSubjectRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AddOrUpdateTextBlocklistItemsOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsOptions>
    {
        public AddOrUpdateTextBlocklistItemsOptions(System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.TextBlocklistItem> blocklistItems) { }
        public System.Collections.Generic.IList<Azure.AI.ContentSafety.TextBlocklistItem> BlocklistItems { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsOptions addOrUpdateTextBlocklistItemsOptions) { throw null; }
        protected virtual Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AddOrUpdateTextBlocklistItemsResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsResult>
    {
        internal AddOrUpdateTextBlocklistItemsResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.ContentSafety.TextBlocklistItem> BlocklistItems { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsResult (Azure.Response response) { throw null; }
        protected virtual Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsResult System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentActor : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentActor>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentActor>
    {
        public AgentActor() { }
        public string Id { get { throw null; } set { } }
        public Azure.AI.ContentSafety.AgentActorKind? Kind { get { throw null; } set { } }
        protected virtual Azure.AI.ContentSafety.AgentActor JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.AgentActor PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentActor System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentActor>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentActor>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentActor System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentActor>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentActor>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentActor>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum AgentActorKind
    {
        Human = 0,
        Service = 1,
        Agent = 2,
    }
    public partial class AgentAllowVerdict : Azure.AI.ContentSafety.AgentVerdict, System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentAllowVerdict>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentAllowVerdict>
    {
        internal AgentAllowVerdict() { }
        protected override Azure.AI.ContentSafety.AgentVerdict JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.ContentSafety.AgentVerdict PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentAllowVerdict System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentAllowVerdict>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentAllowVerdict>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentAllowVerdict System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentAllowVerdict>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentAllowVerdict>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentAllowVerdict>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentBudgets : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentBudgets>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentBudgets>
    {
        public AgentBudgets() { }
        public double? CostUsd { get { throw null; } set { } }
        public double? ElapsedSeconds { get { throw null; } set { } }
        public double? TokenCount { get { throw null; } set { } }
        public double? ToolCallCount { get { throw null; } set { } }
        protected virtual Azure.AI.ContentSafety.AgentBudgets JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.AgentBudgets PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentBudgets System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentBudgets>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentBudgets>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentBudgets System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentBudgets>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentBudgets>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentBudgets>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AgentContext : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentContext>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentContext>
    {
        internal AgentContext() { }
        public Azure.AI.ContentSafety.AgentActor Actor { get { throw null; } set { } }
        public Azure.AI.ContentSafety.AgentDefinition Agent { get { throw null; } }
        public Azure.AI.ContentSafety.AgentInitialization AgentInit { get { throw null; } set { } }
        public Azure.AI.ContentSafety.AgentBudgets Budgets { get { throw null; } set { } }
        public Azure.AI.ContentSafety.AgentContextExtensions Extensions { get { throw null; } set { } }
        public Azure.AI.ContentSafety.AgentInput Input { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.ContentSafety.AgentMessage> Messages { get { throw null; } }
        public Azure.AI.ContentSafety.AgentModel Model { get { throw null; } set { } }
        public Azure.AI.ContentSafety.AgentOutput Output { get { throw null; } set { } }
        public string RequestId { get { throw null; } set { } }
        public Azure.AI.ContentSafety.AgentModelResult Response { get { throw null; } set { } }
        public long Sequence { get { throw null; } }
        public Azure.AI.ContentSafety.AgentSession Session { get { throw null; } }
        public Azure.AI.ContentSafety.AgentSummary Summary { get { throw null; } set { } }
        public System.BinaryData Target { get { throw null; } }
        public Azure.AI.ContentSafety.AgentTenant Tenant { get { throw null; } set { } }
        public System.DateTimeOffset Timestamp { get { throw null; } }
        public Azure.AI.ContentSafety.AgentToolCall ToolCall { get { throw null; } set { } }
        public Azure.AI.ContentSafety.AgentToolResult ToolResult { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.ContentSafety.AgentToolDeclaration> Tools { get { throw null; } }
        public Azure.AI.ContentSafety.AgentTrace Trace { get { throw null; } set { } }
        public Azure.AI.ContentSafety.AgentModelUsage Usage { get { throw null; } set { } }
        protected virtual Azure.AI.ContentSafety.AgentContext JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.ContentSafety.AgentContext agentContext) { throw null; }
        protected virtual Azure.AI.ContentSafety.AgentContext PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentContext System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentContext System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentContextExtensions : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentContextExtensions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentContextExtensions>
    {
        public AgentContextExtensions() { }
        public Azure.AI.ContentSafety.AacsContextExtension Aacs { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.AgentContextExtensions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.AgentContextExtensions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentContextExtensions System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentContextExtensions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentContextExtensions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentContextExtensions System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentContextExtensions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentContextExtensions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentContextExtensions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum AgentDecision
    {
        Allow = 0,
        Deny = 1,
        Transform = 2,
    }
    public partial class AgentDefinition : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentDefinition>
    {
        public AgentDefinition(string id, string framework) { }
        public string Framework { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        protected virtual Azure.AI.ContentSafety.AgentDefinition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.AgentDefinition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentDenyVerdict : Azure.AI.ContentSafety.AgentVerdict, System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentDenyVerdict>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentDenyVerdict>
    {
        internal AgentDenyVerdict() { }
        public Azure.AI.ContentSafety.AgentJsonObject Approval { get { throw null; } }
        protected override Azure.AI.ContentSafety.AgentVerdict JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.ContentSafety.AgentVerdict PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentDenyVerdict System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentDenyVerdict>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentDenyVerdict>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentDenyVerdict System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentDenyVerdict>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentDenyVerdict>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentDenyVerdict>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentEvaluatedPolicyLayer : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentEvaluatedPolicyLayer>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentEvaluatedPolicyLayer>
    {
        internal AgentEvaluatedPolicyLayer() { }
        public string ActivatedArtifactDigest { get { throw null; } }
        public Azure.AI.ContentSafety.AgentDecision Decision { get { throw null; } }
        public Azure.AI.ContentSafety.AgentPolicyLayerKind Kind { get { throw null; } }
        public string PolicyResourceId { get { throw null; } }
        public string PolicyRevision { get { throw null; } }
        public string PolicySemanticDigest { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.AgentEvaluatedPolicyLayer JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.AgentEvaluatedPolicyLayer PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentEvaluatedPolicyLayer System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentEvaluatedPolicyLayer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentEvaluatedPolicyLayer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentEvaluatedPolicyLayer System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentEvaluatedPolicyLayer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentEvaluatedPolicyLayer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentEvaluatedPolicyLayer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentEvaluationRequestBinding : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentEvaluationRequestBinding>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentEvaluationRequestBinding>
    {
        internal AgentEvaluationRequestBinding() { }
        public string Algorithm { get { throw null; } }
        public string Canonicalization { get { throw null; } }
        public string Digest { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.AgentEvaluationRequestBinding JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.AgentEvaluationRequestBinding PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentEvaluationRequestBinding System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentEvaluationRequestBinding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentEvaluationRequestBinding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentEvaluationRequestBinding System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentEvaluationRequestBinding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentEvaluationRequestBinding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentEvaluationRequestBinding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentEvaluationResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentEvaluationResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentEvaluationResult>
    {
        internal AgentEvaluationResult() { }
        public Azure.AI.ContentSafety.AgentPolicyEvaluationReceipt Receipt { get { throw null; } }
        public Azure.AI.ContentSafety.AgentVerdict Verdict { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.AgentEvaluationResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.ContentSafety.AgentEvaluationResult (Azure.Response response) { throw null; }
        protected virtual Azure.AI.ContentSafety.AgentEvaluationResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentEvaluationResult System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentEvaluationResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentEvaluationResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentEvaluationResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentEvaluationResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentEvaluationResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentEvaluationResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentEvidence : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentEvidence>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentEvidence>
    {
        internal AgentEvidence() { }
        public string Artefact { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> VerificationPointers { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.AgentEvidence JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.AgentEvidence PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentEvidence System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentEvidence>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentEvidence>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentEvidence System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentEvidence>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentEvidence>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentEvidence>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentFoundryProjectReceipt : Azure.AI.ContentSafety.AgentPolicyEvaluationReceipt, System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentFoundryProjectReceipt>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentFoundryProjectReceipt>
    {
        internal AgentFoundryProjectReceipt() { }
        public string TargetIncarnation { get { throw null; } }
        public string TargetResourceId { get { throw null; } }
        protected override Azure.AI.ContentSafety.AgentPolicyEvaluationReceipt JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.ContentSafety.AgentPolicyEvaluationReceipt PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentFoundryProjectReceipt System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentFoundryProjectReceipt>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentFoundryProjectReceipt>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentFoundryProjectReceipt System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentFoundryProjectReceipt>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentFoundryProjectReceipt>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentFoundryProjectReceipt>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentHarmDetail : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentHarmDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentHarmDetail>
    {
        internal AgentHarmDetail() { }
        public bool Detected { get { throw null; } }
        public string Id { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.AgentHarmDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.AgentHarmDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentHarmDetail System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentHarmDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentHarmDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentHarmDetail System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentHarmDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentHarmDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentHarmDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentHarmResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentHarmResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentHarmResult>
    {
        internal AgentHarmResult() { }
        public bool Blocked { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentSafety.AgentHarmDetail> Details { get { throw null; } }
        public bool Detected { get { throw null; } }
        public string License { get { throw null; } }
        public int? NumericSeverity { get { throw null; } }
        public string Severity { get { throw null; } }
        public System.Uri Url { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.AgentHarmResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.AgentHarmResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentHarmResult System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentHarmResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentHarmResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentHarmResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentHarmResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentHarmResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentHarmResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentInitialization : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentInitialization>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentInitialization>
    {
        public AgentInitialization(System.Collections.Generic.IEnumerable<string> toolsRegistered) { }
        public System.Collections.Generic.IList<string> ToolsRegistered { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.AgentInitialization JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.AgentInitialization PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentInitialization System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentInitialization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentInitialization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentInitialization System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentInitialization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentInitialization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentInitialization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentInput : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentInput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentInput>
    {
        public AgentInput(System.BinaryData content, Azure.AI.ContentSafety.AgentInputRole role) { }
        public System.BinaryData Content { get { throw null; } }
        public Azure.AI.ContentSafety.AgentInputRole Role { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.AgentInput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.AgentInput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentInput System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentInput System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentInputContext : Azure.AI.ContentSafety.AgentContext, System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentInputContext>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentInputContext>
    {
        public AgentInputContext(System.DateTimeOffset timestamp, long sequence, Azure.AI.ContentSafety.AgentDefinition agent, Azure.AI.ContentSafety.AgentSession session, System.BinaryData target, Azure.AI.ContentSafety.AgentInput input) { }
        protected override Azure.AI.ContentSafety.AgentContext JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.ContentSafety.AgentContext PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentInputContext System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentInputContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentInputContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentInputContext System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentInputContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentInputContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentInputContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum AgentInputRole
    {
        User = 0,
        System = 1,
        External = 2,
    }
    public enum AgentInterceptionPoint
    {
        AgentStartup = 0,
        Input = 1,
        PreModelCall = 2,
        PostModelCall = 3,
        PreToolCall = 4,
        PostToolCall = 5,
        Output = 6,
        AgentShutdown = 7,
    }
    public partial class AgentJsonObject : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentJsonObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentJsonObject>
    {
        public AgentJsonObject() { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.AgentJsonObject JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.AgentJsonObject PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentJsonObject System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentJsonObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentJsonObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentJsonObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentJsonObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentJsonObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentJsonObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentMessage : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentMessage>
    {
        public AgentMessage(string role, System.BinaryData content) { }
        public System.BinaryData Content { get { throw null; } }
        public string Role { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.AgentMessage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.AgentMessage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentModel : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentModel>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentModel>
    {
        public AgentModel(string id) { }
        public string Id { get { throw null; } }
        public Azure.AI.ContentSafety.AgentJsonObject Params { get { throw null; } set { } }
        public string Vendor { get { throw null; } set { } }
        protected virtual Azure.AI.ContentSafety.AgentModel JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.AgentModel PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentModel System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentModel System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentModelResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentModelResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentModelResult>
    {
        public AgentModelResult(System.BinaryData content, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentModelToolCall> toolCalls, string finishReason) { }
        public System.BinaryData Content { get { throw null; } }
        public string FinishReason { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentSafety.AgentModelToolCall> ToolCalls { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.AgentModelResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.AgentModelResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentModelResult System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentModelResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentModelResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentModelResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentModelResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentModelResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentModelResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentModelToolCall : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentModelToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentModelToolCall>
    {
        public AgentModelToolCall(string name, Azure.AI.ContentSafety.AgentJsonObject args) { }
        public Azure.AI.ContentSafety.AgentJsonObject Args { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.AgentModelToolCall JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.AgentModelToolCall PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentModelToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentModelToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentModelToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentModelToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentModelToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentModelToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentModelToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentModelUsage : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentModelUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentModelUsage>
    {
        public AgentModelUsage() { }
        public long? CompletionTokens { get { throw null; } set { } }
        public long? PromptTokens { get { throw null; } set { } }
        protected virtual Azure.AI.ContentSafety.AgentModelUsage JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.AgentModelUsage PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentModelUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentModelUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentModelUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentModelUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentModelUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentModelUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentModelUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentNamedPolicyReceipt : Azure.AI.ContentSafety.AgentPolicyEvaluationReceipt, System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentNamedPolicyReceipt>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentNamedPolicyReceipt>
    {
        internal AgentNamedPolicyReceipt() { }
        protected override Azure.AI.ContentSafety.AgentPolicyEvaluationReceipt JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.ContentSafety.AgentPolicyEvaluationReceipt PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentNamedPolicyReceipt System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentNamedPolicyReceipt>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentNamedPolicyReceipt>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentNamedPolicyReceipt System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentNamedPolicyReceipt>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentNamedPolicyReceipt>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentNamedPolicyReceipt>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentOutput : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentOutput>
    {
        public AgentOutput(System.BinaryData content) { }
        public System.BinaryData Content { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.AgentOutput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.AgentOutput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentOutputContext : Azure.AI.ContentSafety.AgentContext, System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentOutputContext>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentOutputContext>
    {
        public AgentOutputContext(System.DateTimeOffset timestamp, long sequence, Azure.AI.ContentSafety.AgentDefinition agent, Azure.AI.ContentSafety.AgentSession session, System.BinaryData target, Azure.AI.ContentSafety.AgentOutput output) { }
        protected override Azure.AI.ContentSafety.AgentContext JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.ContentSafety.AgentContext PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentOutputContext System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentOutputContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentOutputContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentOutputContext System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentOutputContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentOutputContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentOutputContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AgentPolicyEvaluationReceipt : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentPolicyEvaluationReceipt>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentPolicyEvaluationReceipt>
    {
        internal AgentPolicyEvaluationReceipt() { }
        public long Attempt { get { throw null; } }
        public string AuthenticatedProducerResourceId { get { throw null; } }
        public Azure.AI.ContentSafety.AgentInterceptionPoint EvaluatedInterventionPoint { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentSafety.AgentEvaluatedPolicyLayer> EvaluatedPolicyLayers { get { throw null; } }
        public string EvaluationId { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.AI.ContentSafety.AgentHarmResult> HarmResults { get { throw null; } }
        public string HostProfileVersion { get { throw null; } }
        public string ReceiptVersion { get { throw null; } }
        public Azure.AI.ContentSafety.AgentEvaluationRequestBinding RequestBinding { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentSafety.AgentInterceptionPoint> RequiredInterventionPoints { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.AgentPolicyEvaluationReceipt JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.AgentPolicyEvaluationReceipt PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentPolicyEvaluationReceipt System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentPolicyEvaluationReceipt>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentPolicyEvaluationReceipt>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentPolicyEvaluationReceipt System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentPolicyEvaluationReceipt>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentPolicyEvaluationReceipt>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentPolicyEvaluationReceipt>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentPolicyLayerKind : System.IEquatable<Azure.AI.ContentSafety.AgentPolicyLayerKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentPolicyLayerKind(string value) { throw null; }
        public static Azure.AI.ContentSafety.AgentPolicyLayerKind BuiltIn { get { throw null; } }
        public static Azure.AI.ContentSafety.AgentPolicyLayerKind Hierarchy { get { throw null; } }
        public static Azure.AI.ContentSafety.AgentPolicyLayerKind NamedPolicy { get { throw null; } }
        public static Azure.AI.ContentSafety.AgentPolicyLayerKind Project { get { throw null; } }
        public static Azure.AI.ContentSafety.AgentPolicyLayerKind Selected { get { throw null; } }
        public static Azure.AI.ContentSafety.AgentPolicyLayerKind Subscription { get { throw null; } }
        public bool Equals(Azure.AI.ContentSafety.AgentPolicyLayerKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.ContentSafety.AgentPolicyLayerKind left, Azure.AI.ContentSafety.AgentPolicyLayerKind right) { throw null; }
        public static implicit operator Azure.AI.ContentSafety.AgentPolicyLayerKind (string value) { throw null; }
        public static implicit operator Azure.AI.ContentSafety.AgentPolicyLayerKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.ContentSafety.AgentPolicyLayerKind left, Azure.AI.ContentSafety.AgentPolicyLayerKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentPostModelCallContext : Azure.AI.ContentSafety.AgentContext, System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentPostModelCallContext>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentPostModelCallContext>
    {
        public AgentPostModelCallContext(System.DateTimeOffset timestamp, long sequence, Azure.AI.ContentSafety.AgentDefinition agent, Azure.AI.ContentSafety.AgentSession session, System.BinaryData target, Azure.AI.ContentSafety.AgentModel model, Azure.AI.ContentSafety.AgentModelResult response) { }
        protected override Azure.AI.ContentSafety.AgentContext JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.ContentSafety.AgentContext PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentPostModelCallContext System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentPostModelCallContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentPostModelCallContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentPostModelCallContext System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentPostModelCallContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentPostModelCallContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentPostModelCallContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentPostToolCallContext : Azure.AI.ContentSafety.AgentContext, System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentPostToolCallContext>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentPostToolCallContext>
    {
        public AgentPostToolCallContext(System.DateTimeOffset timestamp, long sequence, Azure.AI.ContentSafety.AgentDefinition agent, Azure.AI.ContentSafety.AgentSession session, System.BinaryData target, Azure.AI.ContentSafety.AgentToolCall toolCall, Azure.AI.ContentSafety.AgentToolResult toolResult) { }
        protected override Azure.AI.ContentSafety.AgentContext JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.ContentSafety.AgentContext PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentPostToolCallContext System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentPostToolCallContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentPostToolCallContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentPostToolCallContext System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentPostToolCallContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentPostToolCallContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentPostToolCallContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentPreModelCallContext : Azure.AI.ContentSafety.AgentContext, System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentPreModelCallContext>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentPreModelCallContext>
    {
        public AgentPreModelCallContext(System.DateTimeOffset timestamp, long sequence, Azure.AI.ContentSafety.AgentDefinition agent, Azure.AI.ContentSafety.AgentSession session, System.BinaryData target, Azure.AI.ContentSafety.AgentModel model, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentMessage> messages) { }
        protected override Azure.AI.ContentSafety.AgentContext JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.ContentSafety.AgentContext PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentPreModelCallContext System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentPreModelCallContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentPreModelCallContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentPreModelCallContext System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentPreModelCallContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentPreModelCallContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentPreModelCallContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentPreToolCallContext : Azure.AI.ContentSafety.AgentContext, System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentPreToolCallContext>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentPreToolCallContext>
    {
        public AgentPreToolCallContext(System.DateTimeOffset timestamp, long sequence, Azure.AI.ContentSafety.AgentDefinition agent, Azure.AI.ContentSafety.AgentSession session, System.BinaryData target, Azure.AI.ContentSafety.AgentToolCall toolCall) { }
        protected override Azure.AI.ContentSafety.AgentContext JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.ContentSafety.AgentContext PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentPreToolCallContext System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentPreToolCallContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentPreToolCallContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentPreToolCallContext System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentPreToolCallContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentPreToolCallContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentPreToolCallContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentSession : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentSession>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentSession>
    {
        public AgentSession(string id) { }
        public string Id { get { throw null; } }
        public System.DateTimeOffset? StartedOn { get { throw null; } set { } }
        public long? Turn { get { throw null; } set { } }
        protected virtual Azure.AI.ContentSafety.AgentSession JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.AgentSession PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentSession System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentSession>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentSession>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentSession System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentSession>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentSession>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentSession>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentShutdownContext : Azure.AI.ContentSafety.AgentContext, System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentShutdownContext>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentShutdownContext>
    {
        public AgentShutdownContext(System.DateTimeOffset timestamp, long sequence, Azure.AI.ContentSafety.AgentDefinition agent, Azure.AI.ContentSafety.AgentSession session, System.BinaryData target, Azure.AI.ContentSafety.AgentSummary summary) { }
        protected override Azure.AI.ContentSafety.AgentContext JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.ContentSafety.AgentContext PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentShutdownContext System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentShutdownContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentShutdownContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentShutdownContext System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentShutdownContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentShutdownContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentShutdownContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum AgentShutdownReason
    {
        Completed = 0,
        Error = 1,
        Cancelled = 2,
    }
    public partial class AgentStartupContext : Azure.AI.ContentSafety.AgentContext, System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentStartupContext>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentStartupContext>
    {
        public AgentStartupContext(System.DateTimeOffset timestamp, long sequence, Azure.AI.ContentSafety.AgentDefinition agent, Azure.AI.ContentSafety.AgentSession session, System.BinaryData target, Azure.AI.ContentSafety.AgentInitialization agentInit) { }
        protected override Azure.AI.ContentSafety.AgentContext JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.ContentSafety.AgentContext PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentStartupContext System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentStartupContext>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentStartupContext>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentStartupContext System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentStartupContext>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentStartupContext>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentStartupContext>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentSummary : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentSummary>
    {
        public AgentSummary(Azure.AI.ContentSafety.AgentShutdownReason reason) { }
        public double? DurationSeconds { get { throw null; } set { } }
        public long? Errors { get { throw null; } set { } }
        public Azure.AI.ContentSafety.AgentShutdownReason Reason { get { throw null; } }
        public long? ToolCalls { get { throw null; } set { } }
        protected virtual Azure.AI.ContentSafety.AgentSummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.AgentSummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentSummary System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentSummary System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentTenant : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentTenant>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentTenant>
    {
        public AgentTenant() { }
        public string Id { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual Azure.AI.ContentSafety.AgentTenant JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.AgentTenant PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentTenant System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentTenant>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentTenant>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentTenant System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentTenant>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentTenant>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentTenant>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentToolCall : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentToolCall>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentToolCall>
    {
        public AgentToolCall(string id, string name, Azure.AI.ContentSafety.AgentJsonObject args) { }
        public Azure.AI.ContentSafety.AgentJsonObject Args { get { throw null; } }
        public string ContentHash { get { throw null; } set { } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.AgentToolCall JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.AgentToolCall PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentToolCall System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentToolCall>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentToolCall>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentToolCall System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentToolCall>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentToolCall>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentToolCall>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentToolDeclaration : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentToolDeclaration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentToolDeclaration>
    {
        public AgentToolDeclaration(string name) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.AI.ContentSafety.AgentJsonObject Schema { get { throw null; } set { } }
        protected virtual Azure.AI.ContentSafety.AgentToolDeclaration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.AgentToolDeclaration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentToolDeclaration System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentToolDeclaration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentToolDeclaration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentToolDeclaration System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentToolDeclaration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentToolDeclaration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentToolDeclaration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentToolResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentToolResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentToolResult>
    {
        public AgentToolResult(System.BinaryData value, bool isError) { }
        public double? DurationMs { get { throw null; } set { } }
        public bool IsError { get { throw null; } }
        public System.BinaryData Value { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.AgentToolResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.AgentToolResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentToolResult System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentToolResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentToolResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentToolResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentToolResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentToolResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentToolResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentTrace : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentTrace>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentTrace>
    {
        public AgentTrace() { }
        public string SpanId { get { throw null; } set { } }
        public string TraceId { get { throw null; } set { } }
        protected virtual Azure.AI.ContentSafety.AgentTrace JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.AgentTrace PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentTrace System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentTrace>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentTrace>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentTrace System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentTrace>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentTrace>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentTrace>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentTransform : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentTransform>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentTransform>
    {
        internal AgentTransform() { }
        public string Path { get { throw null; } }
        public System.BinaryData Value { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.AgentTransform JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.AgentTransform PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentTransform System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentTransform>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentTransform>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentTransform System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentTransform>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentTransform>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentTransform>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentTransformVerdict : Azure.AI.ContentSafety.AgentVerdict, System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentTransformVerdict>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentTransformVerdict>
    {
        internal AgentTransformVerdict() { }
        public Azure.AI.ContentSafety.AgentTransform Transform { get { throw null; } }
        protected override Azure.AI.ContentSafety.AgentVerdict JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.AI.ContentSafety.AgentVerdict PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentTransformVerdict System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentTransformVerdict>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentTransformVerdict>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentTransformVerdict System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentTransformVerdict>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentTransformVerdict>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentTransformVerdict>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class AgentVerdict : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentVerdict>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentVerdict>
    {
        internal AgentVerdict() { }
        public Azure.AI.ContentSafety.AgentEvidence Evidence { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
        public System.Collections.Generic.IList<string> ResultLabels { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentSafety.AgentWarning> Warnings { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.AgentVerdict JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.AgentVerdict PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentVerdict System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentVerdict>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentVerdict>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentVerdict System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentVerdict>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentVerdict>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentVerdict>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentWarning : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentWarning>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentWarning>
    {
        internal AgentWarning() { }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.AgentWarning JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.AgentWarning PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AgentWarning System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentWarning>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AgentWarning>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AgentWarning System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentWarning>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentWarning>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AgentWarning>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeImageOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AnalyzeImageOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeImageOptions>
    {
        public AnalyzeImageOptions(Azure.AI.ContentSafety.ContentSafetyImageData image) { }
        public System.Collections.Generic.IList<Azure.AI.ContentSafety.ImageCategory> Categories { get { throw null; } }
        public Azure.AI.ContentSafety.ContentSafetyImageData Image { get { throw null; } }
        public Azure.AI.ContentSafety.AnalyzeImageOutputType? OutputType { get { throw null; } set { } }
        protected virtual Azure.AI.ContentSafety.AnalyzeImageOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.ContentSafety.AnalyzeImageOptions analyzeImageOptions) { throw null; }
        protected virtual Azure.AI.ContentSafety.AnalyzeImageOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AnalyzeImageOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AnalyzeImageOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AnalyzeImageOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AnalyzeImageOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeImageOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeImageOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeImageOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalyzeImageOutputType : System.IEquatable<Azure.AI.ContentSafety.AnalyzeImageOutputType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnalyzeImageOutputType(string value) { throw null; }
        public static Azure.AI.ContentSafety.AnalyzeImageOutputType FourSeverityLevels { get { throw null; } }
        public bool Equals(Azure.AI.ContentSafety.AnalyzeImageOutputType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.ContentSafety.AnalyzeImageOutputType left, Azure.AI.ContentSafety.AnalyzeImageOutputType right) { throw null; }
        public static implicit operator Azure.AI.ContentSafety.AnalyzeImageOutputType (string value) { throw null; }
        public static implicit operator Azure.AI.ContentSafety.AnalyzeImageOutputType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.ContentSafety.AnalyzeImageOutputType left, Azure.AI.ContentSafety.AnalyzeImageOutputType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AnalyzeImageResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AnalyzeImageResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeImageResult>
    {
        internal AnalyzeImageResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.ContentSafety.ImageCategoriesAnalysis> CategoriesAnalysis { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.AnalyzeImageResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.ContentSafety.AnalyzeImageResult (Azure.Response response) { throw null; }
        protected virtual Azure.AI.ContentSafety.AnalyzeImageResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AnalyzeImageResult System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AnalyzeImageResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AnalyzeImageResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AnalyzeImageResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeImageResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeImageResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeImageResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AnalyzeTextOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AnalyzeTextOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeTextOptions>
    {
        public AnalyzeTextOptions(string text) { }
        public System.Collections.Generic.IList<string> BlocklistNames { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentSafety.TextCategory> Categories { get { throw null; } }
        public bool? HaltOnBlocklistHit { get { throw null; } set { } }
        public Azure.AI.ContentSafety.AnalyzeTextOutputType? OutputType { get { throw null; } set { } }
        public string Text { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.AnalyzeTextOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.ContentSafety.AnalyzeTextOptions analyzeTextOptions) { throw null; }
        protected virtual Azure.AI.ContentSafety.AnalyzeTextOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AnalyzeTextOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AnalyzeTextOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AnalyzeTextOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AnalyzeTextOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeTextOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeTextOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeTextOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnalyzeTextOutputType : System.IEquatable<Azure.AI.ContentSafety.AnalyzeTextOutputType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnalyzeTextOutputType(string value) { throw null; }
        public static Azure.AI.ContentSafety.AnalyzeTextOutputType EightSeverityLevels { get { throw null; } }
        public static Azure.AI.ContentSafety.AnalyzeTextOutputType FourSeverityLevels { get { throw null; } }
        public bool Equals(Azure.AI.ContentSafety.AnalyzeTextOutputType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.ContentSafety.AnalyzeTextOutputType left, Azure.AI.ContentSafety.AnalyzeTextOutputType right) { throw null; }
        public static implicit operator Azure.AI.ContentSafety.AnalyzeTextOutputType (string value) { throw null; }
        public static implicit operator Azure.AI.ContentSafety.AnalyzeTextOutputType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.ContentSafety.AnalyzeTextOutputType left, Azure.AI.ContentSafety.AnalyzeTextOutputType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AnalyzeTextResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AnalyzeTextResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeTextResult>
    {
        internal AnalyzeTextResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.ContentSafety.TextBlocklistMatch> BlocklistsMatch { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.ContentSafety.TextCategoriesAnalysis> CategoriesAnalysis { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.AnalyzeTextResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.ContentSafety.AnalyzeTextResult (Azure.Response response) { throw null; }
        protected virtual Azure.AI.ContentSafety.AnalyzeTextResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.AnalyzeTextResult System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AnalyzeTextResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.AnalyzeTextResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.AnalyzeTextResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeTextResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeTextResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.AnalyzeTextResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzureAIContentSafetyContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAIContentSafetyContext() { }
        public static Azure.AI.ContentSafety.AzureAIContentSafetyContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class BlocklistClient
    {
        protected BlocklistClient() { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
        public BlocklistClient(Azure.AI.ContentSafety.BlocklistClientSettings settings) { }
        public BlocklistClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public BlocklistClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.ContentSafety.ContentSafetyClientOptions options) { }
        public BlocklistClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public BlocklistClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.ContentSafety.ContentSafetyClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsResult> AddOrUpdateBlocklistItems(string name, Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AddOrUpdateBlocklistItems(string name, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsResult>> AddOrUpdateBlocklistItemsAsync(string name, Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AddOrUpdateBlocklistItemsAsync(string name, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response CreateOrUpdateTextBlocklist(string name, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> CreateOrUpdateTextBlocklistAsync(string name, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response DeleteTextBlocklist(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response DeleteTextBlocklist(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTextBlocklistAsync(string name, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DeleteTextBlocklistAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTextBlocklist(string name, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.ContentSafety.TextBlocklist> GetTextBlocklist(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTextBlocklistAsync(string name, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentSafety.TextBlocklist>> GetTextBlocklistAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response GetTextBlocklistItem(string name, string blocklistItemId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.ContentSafety.TextBlocklistItem> GetTextBlocklistItem(string name, string blocklistItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetTextBlocklistItemAsync(string name, string blocklistItemId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentSafety.TextBlocklistItem>> GetTextBlocklistItemAsync(string name, string blocklistItemId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTextBlocklistItems(string name, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.ContentSafety.TextBlocklistItem> GetTextBlocklistItems(string name, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTextBlocklistItemsAsync(string name, int? maxCount, int? skip, int? maxpagesize, Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.ContentSafety.TextBlocklistItem> GetTextBlocklistItemsAsync(string name, int? maxCount = default(int?), int? skip = default(int?), int? maxpagesize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<System.BinaryData> GetTextBlocklists(Azure.RequestContext context) { throw null; }
        public virtual Azure.Pageable<Azure.AI.ContentSafety.TextBlocklist> GetTextBlocklists(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<System.BinaryData> GetTextBlocklistsAsync(Azure.RequestContext context) { throw null; }
        public virtual Azure.AsyncPageable<Azure.AI.ContentSafety.TextBlocklist> GetTextBlocklistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveBlocklistItems(string name, Azure.AI.ContentSafety.RemoveTextBlocklistItemsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RemoveBlocklistItems(string name, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveBlocklistItemsAsync(string name, Azure.AI.ContentSafety.RemoveTextBlocklistItemsOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RemoveBlocklistItemsAsync(string name, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public static partial class BlocklistClientHostExtensions
    {
        public static System.ClientModel.Primitives.IClientBuilder AddBlocklistClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddBlocklistClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName, System.Action<Azure.AI.ContentSafety.BlocklistClientSettings> configureSettings) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedBlocklistClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedBlocklistClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName, System.Action<Azure.AI.ContentSafety.BlocklistClientSettings> configureSettings) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public partial class BlocklistClientSettings : System.ClientModel.Primitives.ClientSettings
    {
        public BlocklistClientSettings() { }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.AI.ContentSafety.ContentSafetyClientOptions Options { get { throw null; } set { } }
        protected override void BindCore(Microsoft.Extensions.Configuration.IConfigurationSection section) { }
    }
    public partial class ContentProvenanceClient
    {
        protected ContentProvenanceClient() { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
        public ContentProvenanceClient(Azure.AI.ContentSafety.ContentProvenanceClientSettings settings) { }
        public ContentProvenanceClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public ContentProvenanceClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.ContentSafety.ContentSafetyClientOptions options) { }
        public ContentProvenanceClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ContentProvenanceClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.ContentSafety.ContentSafetyClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Operation<Azure.AI.ContentSafety.DetectProvenanceResult> Detect(Azure.WaitUntil waitUntil, Azure.AI.ContentSafety.DetectProvenanceOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Operation<System.BinaryData> Detect(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<Azure.AI.ContentSafety.DetectProvenanceResult>> DetectAsync(Azure.WaitUntil waitUntil, Azure.AI.ContentSafety.DetectProvenanceOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Operation<System.BinaryData>> DetectAsync(Azure.WaitUntil waitUntil, Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response GetOperationStatus(string operationId, Azure.RequestContext context) { throw null; }
        public virtual Azure.Response<Azure.AI.ContentSafety.ProvenanceDetectOperation> GetOperationStatus(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> GetOperationStatusAsync(string operationId, Azure.RequestContext context) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentSafety.ProvenanceDetectOperation>> GetOperationStatusAsync(string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public static partial class ContentProvenanceClientHostExtensions
    {
        public static System.ClientModel.Primitives.IClientBuilder AddContentProvenanceClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddContentProvenanceClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName, System.Action<Azure.AI.ContentSafety.ContentProvenanceClientSettings> configureSettings) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedContentProvenanceClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedContentProvenanceClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName, System.Action<Azure.AI.ContentSafety.ContentProvenanceClientSettings> configureSettings) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public partial class ContentProvenanceClientSettings : System.ClientModel.Primitives.ClientSettings
    {
        public ContentProvenanceClientSettings() { }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.AI.ContentSafety.ContentSafetyClientOptions Options { get { throw null; } set { } }
        protected override void BindCore(Microsoft.Extensions.Configuration.IConfigurationSection section) { }
    }
    public partial class ContentSafetyClient
    {
        protected ContentSafetyClient() { }
        [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
        public ContentSafetyClient(Azure.AI.ContentSafety.ContentSafetyClientSettings settings) { }
        public ContentSafetyClient(System.Uri endpoint, Azure.AzureKeyCredential credential) { }
        public ContentSafetyClient(System.Uri endpoint, Azure.AzureKeyCredential credential, Azure.AI.ContentSafety.ContentSafetyClientOptions options) { }
        public ContentSafetyClient(System.Uri endpoint, Azure.Core.TokenCredential credential) { }
        public ContentSafetyClient(System.Uri endpoint, Azure.Core.TokenCredential credential, Azure.AI.ContentSafety.ContentSafetyClientOptions options) { }
        public virtual Azure.Core.Pipeline.HttpPipeline Pipeline { get { throw null; } }
        public virtual Azure.Response<Azure.AI.ContentSafety.AnalyzeImageResult> AnalyzeImage(Azure.AI.ContentSafety.AnalyzeImageOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AnalyzeImage(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.ContentSafety.AnalyzeImageResult> AnalyzeImage(System.BinaryData content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.ContentSafety.AnalyzeImageResult> AnalyzeImage(System.Uri blobUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentSafety.AnalyzeImageResult>> AnalyzeImageAsync(Azure.AI.ContentSafety.AnalyzeImageOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AnalyzeImageAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentSafety.AnalyzeImageResult>> AnalyzeImageAsync(System.BinaryData content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentSafety.AnalyzeImageResult>> AnalyzeImageAsync(System.Uri blobUri, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.ContentSafety.AnalyzeTextResult> AnalyzeText(Azure.AI.ContentSafety.AnalyzeTextOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response AnalyzeText(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.ContentSafety.AnalyzeTextResult> AnalyzeText(string text, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentSafety.AnalyzeTextResult>> AnalyzeTextAsync(Azure.AI.ContentSafety.AnalyzeTextOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> AnalyzeTextAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentSafety.AnalyzeTextResult>> AnalyzeTextAsync(string text, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.AI.ContentSafety.DetectTextProtectedMaterialResult> DetectTextProtectedMaterial(Azure.AI.ContentSafety.DetectTextProtectedMaterialOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response DetectTextProtectedMaterial(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentSafety.DetectTextProtectedMaterialResult>> DetectTextProtectedMaterialAsync(Azure.AI.ContentSafety.DetectTextProtectedMaterialOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> DetectTextProtectedMaterialAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.ContentSafety.ShieldPromptResult> ShieldPrompt(Azure.AI.ContentSafety.ShieldPromptOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ShieldPrompt(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentSafety.ShieldPromptResult>> ShieldPromptAsync(Azure.AI.ContentSafety.ShieldPromptOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ShieldPromptAsync(Azure.Core.RequestContent content, Azure.RequestContext context = null) { throw null; }
        public virtual Azure.Response<Azure.AI.ContentSafety.AgentEvaluationResult> UnifiedModerate(Azure.AI.ContentSafety.AgentContext options, string targetResourceId = null, string policyId = null, string selectedPolicyId = null, string selectedPolicyRevision = null, string selectedPolicySemanticDigest = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UnifiedModerate(Azure.Core.RequestContent content, string targetResourceId = null, string policyId = null, string selectedPolicyId = null, string selectedPolicyRevision = null, string selectedPolicySemanticDigest = null, Azure.RequestContext context = null) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.AI.ContentSafety.AgentEvaluationResult>> UnifiedModerateAsync(Azure.AI.ContentSafety.AgentContext options, string targetResourceId = null, string policyId = null, string selectedPolicyId = null, string selectedPolicyRevision = null, string selectedPolicySemanticDigest = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UnifiedModerateAsync(Azure.Core.RequestContent content, string targetResourceId = null, string policyId = null, string selectedPolicyId = null, string selectedPolicyRevision = null, string selectedPolicySemanticDigest = null, Azure.RequestContext context = null) { throw null; }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public static partial class ContentSafetyClientHostExtensions
    {
        public static System.ClientModel.Primitives.IClientBuilder AddContentSafetyClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddContentSafetyClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string sectionName, System.Action<Azure.AI.ContentSafety.ContentSafetyClientSettings> configureSettings) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedContentSafetyClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName) { throw null; }
        public static System.ClientModel.Primitives.IClientBuilder AddKeyedContentSafetyClient(this Microsoft.Extensions.Hosting.IHostApplicationBuilder host, string key, string sectionName, System.Action<Azure.AI.ContentSafety.ContentSafetyClientSettings> configureSettings) { throw null; }
    }
    public partial class ContentSafetyClientOptions : Azure.Core.ClientOptions
    {
        public ContentSafetyClientOptions(Azure.AI.ContentSafety.ContentSafetyClientOptions.ServiceVersion version = Azure.AI.ContentSafety.ContentSafetyClientOptions.ServiceVersion.V2026_10_15_Preview) { }
        public enum ServiceVersion
        {
            V2023_10_01 = 1,
            V2024_09_01 = 2,
            V2026_09_01_Preview = 3,
            V2026_10_15_Preview = 4,
        }
    }
    [System.Diagnostics.CodeAnalysis.ExperimentalAttribute("SCME0002")]
    public partial class ContentSafetyClientSettings : System.ClientModel.Primitives.ClientSettings
    {
        public ContentSafetyClientSettings() { }
        public System.Uri Endpoint { get { throw null; } set { } }
        public Azure.AI.ContentSafety.ContentSafetyClientOptions Options { get { throw null; } set { } }
        protected override void BindCore(Microsoft.Extensions.Configuration.IConfigurationSection section) { }
    }
    public partial class ContentSafetyImageData : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.ContentSafetyImageData>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ContentSafetyImageData>
    {
        public ContentSafetyImageData() { }
        public ContentSafetyImageData(System.BinaryData content) { }
        public ContentSafetyImageData(System.Uri blobUri) { }
        protected virtual Azure.AI.ContentSafety.ContentSafetyImageData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.ContentSafetyImageData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.ContentSafetyImageData System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.ContentSafetyImageData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.ContentSafetyImageData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.ContentSafetyImageData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ContentSafetyImageData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ContentSafetyImageData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ContentSafetyImageData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ContentSafetyModelFactory
    {
        public static Azure.AI.ContentSafety.AacsContextExtension AacsContextExtension(Azure.AI.ContentSafety.AacsSubjectRole? role = default(Azure.AI.ContentSafety.AacsSubjectRole?)) { throw null; }
        public static Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsOptions AddOrUpdateTextBlocklistItemsOptions(System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.TextBlocklistItem> blocklistItems = null) { throw null; }
        public static Azure.AI.ContentSafety.AddOrUpdateTextBlocklistItemsResult AddOrUpdateTextBlocklistItemsResult(System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.TextBlocklistItem> blocklistItems = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentActor AgentActor(string id = null, Azure.AI.ContentSafety.AgentActorKind? kind = default(Azure.AI.ContentSafety.AgentActorKind?)) { throw null; }
        public static Azure.AI.ContentSafety.AgentAllowVerdict AgentAllowVerdict(string reason = null, string message = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentWarning> warnings = null, Azure.AI.ContentSafety.AgentEvidence evidence = null, System.Collections.Generic.IEnumerable<string> resultLabels = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentBudgets AgentBudgets(double? toolCallCount = default(double?), double? tokenCount = default(double?), double? elapsedSeconds = default(double?), double? costUsd = default(double?)) { throw null; }
        public static Azure.AI.ContentSafety.AgentContext AgentContext(string interceptionPoint = null, System.DateTimeOffset timestamp = default(System.DateTimeOffset), long sequence = (long)0, Azure.AI.ContentSafety.AgentDefinition agent = null, Azure.AI.ContentSafety.AgentSession session = null, System.BinaryData target = null, Azure.AI.ContentSafety.AgentInitialization agentInit = null, Azure.AI.ContentSafety.AgentInput input = null, Azure.AI.ContentSafety.AgentModel model = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentMessage> messages = null, string requestId = null, Azure.AI.ContentSafety.AgentModelResult response = null, Azure.AI.ContentSafety.AgentModelUsage usage = null, Azure.AI.ContentSafety.AgentToolCall toolCall = null, Azure.AI.ContentSafety.AgentToolResult toolResult = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentToolDeclaration> tools = null, Azure.AI.ContentSafety.AgentOutput output = null, Azure.AI.ContentSafety.AgentSummary summary = null, Azure.AI.ContentSafety.AgentTrace trace = null, Azure.AI.ContentSafety.AgentTenant tenant = null, Azure.AI.ContentSafety.AgentActor actor = null, Azure.AI.ContentSafety.AgentBudgets budgets = null, Azure.AI.ContentSafety.AgentContextExtensions extensions = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentContextExtensions AgentContextExtensions(Azure.AI.ContentSafety.AacsContextExtension aacs = null, System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentDefinition AgentDefinition(string id = null, string framework = null, string name = null, string version = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentDenyVerdict AgentDenyVerdict(string reason = null, string message = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentWarning> warnings = null, Azure.AI.ContentSafety.AgentEvidence evidence = null, System.Collections.Generic.IEnumerable<string> resultLabels = null, Azure.AI.ContentSafety.AgentJsonObject approval = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentEvaluatedPolicyLayer AgentEvaluatedPolicyLayer(Azure.AI.ContentSafety.AgentPolicyLayerKind kind = default(Azure.AI.ContentSafety.AgentPolicyLayerKind), string policyResourceId = null, string policyRevision = null, string policySemanticDigest = null, string activatedArtifactDigest = null, Azure.AI.ContentSafety.AgentDecision decision = Azure.AI.ContentSafety.AgentDecision.Allow) { throw null; }
        public static Azure.AI.ContentSafety.AgentEvaluationRequestBinding AgentEvaluationRequestBinding(string digest = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentEvaluationResult AgentEvaluationResult(Azure.AI.ContentSafety.AgentVerdict verdict = null, Azure.AI.ContentSafety.AgentPolicyEvaluationReceipt receipt = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentEvidence AgentEvidence(string artefact = null, System.Collections.Generic.IDictionary<string, string> verificationPointers = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentFoundryProjectReceipt AgentFoundryProjectReceipt(string evaluationId = null, long attempt = (long)0, Azure.AI.ContentSafety.AgentEvaluationRequestBinding requestBinding = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentEvaluatedPolicyLayer> evaluatedPolicyLayers = null, Azure.AI.ContentSafety.AgentInterceptionPoint evaluatedInterventionPoint = Azure.AI.ContentSafety.AgentInterceptionPoint.AgentStartup, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentInterceptionPoint> requiredInterventionPoints = null, string hostProfileVersion = null, string authenticatedProducerResourceId = null, System.Collections.Generic.IDictionary<string, Azure.AI.ContentSafety.AgentHarmResult> harmResults = null, string targetResourceId = null, string targetIncarnation = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentHarmDetail AgentHarmDetail(bool detected = false, string id = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentHarmResult AgentHarmResult(bool blocked = false, bool detected = false, string severity = null, int? numericSeverity = default(int?), System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentHarmDetail> details = null, System.Uri url = null, string license = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentInitialization AgentInitialization(System.Collections.Generic.IEnumerable<string> toolsRegistered = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentInput AgentInput(System.BinaryData content = null, Azure.AI.ContentSafety.AgentInputRole role = Azure.AI.ContentSafety.AgentInputRole.User) { throw null; }
        public static Azure.AI.ContentSafety.AgentInputContext AgentInputContext(System.DateTimeOffset timestamp = default(System.DateTimeOffset), long sequence = (long)0, Azure.AI.ContentSafety.AgentDefinition agent = null, Azure.AI.ContentSafety.AgentSession session = null, System.BinaryData target = null, Azure.AI.ContentSafety.AgentInitialization agentInit = null, Azure.AI.ContentSafety.AgentInput input = null, Azure.AI.ContentSafety.AgentModel model = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentMessage> messages = null, string requestId = null, Azure.AI.ContentSafety.AgentModelResult response = null, Azure.AI.ContentSafety.AgentModelUsage usage = null, Azure.AI.ContentSafety.AgentToolCall toolCall = null, Azure.AI.ContentSafety.AgentToolResult toolResult = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentToolDeclaration> tools = null, Azure.AI.ContentSafety.AgentOutput output = null, Azure.AI.ContentSafety.AgentSummary summary = null, Azure.AI.ContentSafety.AgentTrace trace = null, Azure.AI.ContentSafety.AgentTenant tenant = null, Azure.AI.ContentSafety.AgentActor actor = null, Azure.AI.ContentSafety.AgentBudgets budgets = null, Azure.AI.ContentSafety.AgentContextExtensions extensions = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentJsonObject AgentJsonObject(System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentMessage AgentMessage(string role = null, System.BinaryData content = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentModel AgentModel(string id = null, string vendor = null, Azure.AI.ContentSafety.AgentJsonObject @params = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentModelResult AgentModelResult(System.BinaryData content = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentModelToolCall> toolCalls = null, string finishReason = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentModelToolCall AgentModelToolCall(string id = null, string name = null, Azure.AI.ContentSafety.AgentJsonObject args = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentModelUsage AgentModelUsage(long? promptTokens = default(long?), long? completionTokens = default(long?)) { throw null; }
        public static Azure.AI.ContentSafety.AgentNamedPolicyReceipt AgentNamedPolicyReceipt(string evaluationId = null, long attempt = (long)0, Azure.AI.ContentSafety.AgentEvaluationRequestBinding requestBinding = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentEvaluatedPolicyLayer> evaluatedPolicyLayers = null, Azure.AI.ContentSafety.AgentInterceptionPoint evaluatedInterventionPoint = Azure.AI.ContentSafety.AgentInterceptionPoint.AgentStartup, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentInterceptionPoint> requiredInterventionPoints = null, string hostProfileVersion = null, string authenticatedProducerResourceId = null, System.Collections.Generic.IDictionary<string, Azure.AI.ContentSafety.AgentHarmResult> harmResults = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentOutput AgentOutput(System.BinaryData content = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentOutputContext AgentOutputContext(System.DateTimeOffset timestamp = default(System.DateTimeOffset), long sequence = (long)0, Azure.AI.ContentSafety.AgentDefinition agent = null, Azure.AI.ContentSafety.AgentSession session = null, System.BinaryData target = null, Azure.AI.ContentSafety.AgentInitialization agentInit = null, Azure.AI.ContentSafety.AgentInput input = null, Azure.AI.ContentSafety.AgentModel model = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentMessage> messages = null, string requestId = null, Azure.AI.ContentSafety.AgentModelResult response = null, Azure.AI.ContentSafety.AgentModelUsage usage = null, Azure.AI.ContentSafety.AgentToolCall toolCall = null, Azure.AI.ContentSafety.AgentToolResult toolResult = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentToolDeclaration> tools = null, Azure.AI.ContentSafety.AgentOutput output = null, Azure.AI.ContentSafety.AgentSummary summary = null, Azure.AI.ContentSafety.AgentTrace trace = null, Azure.AI.ContentSafety.AgentTenant tenant = null, Azure.AI.ContentSafety.AgentActor actor = null, Azure.AI.ContentSafety.AgentBudgets budgets = null, Azure.AI.ContentSafety.AgentContextExtensions extensions = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentPolicyEvaluationReceipt AgentPolicyEvaluationReceipt(string profile = null, string evaluationId = null, long attempt = (long)0, Azure.AI.ContentSafety.AgentEvaluationRequestBinding requestBinding = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentEvaluatedPolicyLayer> evaluatedPolicyLayers = null, Azure.AI.ContentSafety.AgentInterceptionPoint evaluatedInterventionPoint = Azure.AI.ContentSafety.AgentInterceptionPoint.AgentStartup, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentInterceptionPoint> requiredInterventionPoints = null, string hostProfileVersion = null, string authenticatedProducerResourceId = null, System.Collections.Generic.IDictionary<string, Azure.AI.ContentSafety.AgentHarmResult> harmResults = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentPostModelCallContext AgentPostModelCallContext(System.DateTimeOffset timestamp = default(System.DateTimeOffset), long sequence = (long)0, Azure.AI.ContentSafety.AgentDefinition agent = null, Azure.AI.ContentSafety.AgentSession session = null, System.BinaryData target = null, Azure.AI.ContentSafety.AgentInitialization agentInit = null, Azure.AI.ContentSafety.AgentInput input = null, Azure.AI.ContentSafety.AgentModel model = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentMessage> messages = null, string requestId = null, Azure.AI.ContentSafety.AgentModelResult response = null, Azure.AI.ContentSafety.AgentModelUsage usage = null, Azure.AI.ContentSafety.AgentToolCall toolCall = null, Azure.AI.ContentSafety.AgentToolResult toolResult = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentToolDeclaration> tools = null, Azure.AI.ContentSafety.AgentOutput output = null, Azure.AI.ContentSafety.AgentSummary summary = null, Azure.AI.ContentSafety.AgentTrace trace = null, Azure.AI.ContentSafety.AgentTenant tenant = null, Azure.AI.ContentSafety.AgentActor actor = null, Azure.AI.ContentSafety.AgentBudgets budgets = null, Azure.AI.ContentSafety.AgentContextExtensions extensions = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentPostToolCallContext AgentPostToolCallContext(System.DateTimeOffset timestamp = default(System.DateTimeOffset), long sequence = (long)0, Azure.AI.ContentSafety.AgentDefinition agent = null, Azure.AI.ContentSafety.AgentSession session = null, System.BinaryData target = null, Azure.AI.ContentSafety.AgentInitialization agentInit = null, Azure.AI.ContentSafety.AgentInput input = null, Azure.AI.ContentSafety.AgentModel model = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentMessage> messages = null, string requestId = null, Azure.AI.ContentSafety.AgentModelResult response = null, Azure.AI.ContentSafety.AgentModelUsage usage = null, Azure.AI.ContentSafety.AgentToolCall toolCall = null, Azure.AI.ContentSafety.AgentToolResult toolResult = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentToolDeclaration> tools = null, Azure.AI.ContentSafety.AgentOutput output = null, Azure.AI.ContentSafety.AgentSummary summary = null, Azure.AI.ContentSafety.AgentTrace trace = null, Azure.AI.ContentSafety.AgentTenant tenant = null, Azure.AI.ContentSafety.AgentActor actor = null, Azure.AI.ContentSafety.AgentBudgets budgets = null, Azure.AI.ContentSafety.AgentContextExtensions extensions = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentPreModelCallContext AgentPreModelCallContext(System.DateTimeOffset timestamp = default(System.DateTimeOffset), long sequence = (long)0, Azure.AI.ContentSafety.AgentDefinition agent = null, Azure.AI.ContentSafety.AgentSession session = null, System.BinaryData target = null, Azure.AI.ContentSafety.AgentInitialization agentInit = null, Azure.AI.ContentSafety.AgentInput input = null, Azure.AI.ContentSafety.AgentModel model = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentMessage> messages = null, string requestId = null, Azure.AI.ContentSafety.AgentModelResult response = null, Azure.AI.ContentSafety.AgentModelUsage usage = null, Azure.AI.ContentSafety.AgentToolCall toolCall = null, Azure.AI.ContentSafety.AgentToolResult toolResult = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentToolDeclaration> tools = null, Azure.AI.ContentSafety.AgentOutput output = null, Azure.AI.ContentSafety.AgentSummary summary = null, Azure.AI.ContentSafety.AgentTrace trace = null, Azure.AI.ContentSafety.AgentTenant tenant = null, Azure.AI.ContentSafety.AgentActor actor = null, Azure.AI.ContentSafety.AgentBudgets budgets = null, Azure.AI.ContentSafety.AgentContextExtensions extensions = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentPreToolCallContext AgentPreToolCallContext(System.DateTimeOffset timestamp = default(System.DateTimeOffset), long sequence = (long)0, Azure.AI.ContentSafety.AgentDefinition agent = null, Azure.AI.ContentSafety.AgentSession session = null, System.BinaryData target = null, Azure.AI.ContentSafety.AgentInitialization agentInit = null, Azure.AI.ContentSafety.AgentInput input = null, Azure.AI.ContentSafety.AgentModel model = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentMessage> messages = null, string requestId = null, Azure.AI.ContentSafety.AgentModelResult response = null, Azure.AI.ContentSafety.AgentModelUsage usage = null, Azure.AI.ContentSafety.AgentToolCall toolCall = null, Azure.AI.ContentSafety.AgentToolResult toolResult = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentToolDeclaration> tools = null, Azure.AI.ContentSafety.AgentOutput output = null, Azure.AI.ContentSafety.AgentSummary summary = null, Azure.AI.ContentSafety.AgentTrace trace = null, Azure.AI.ContentSafety.AgentTenant tenant = null, Azure.AI.ContentSafety.AgentActor actor = null, Azure.AI.ContentSafety.AgentBudgets budgets = null, Azure.AI.ContentSafety.AgentContextExtensions extensions = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentSession AgentSession(string id = null, System.DateTimeOffset? startedOn = default(System.DateTimeOffset?), long? turn = default(long?)) { throw null; }
        public static Azure.AI.ContentSafety.AgentShutdownContext AgentShutdownContext(System.DateTimeOffset timestamp = default(System.DateTimeOffset), long sequence = (long)0, Azure.AI.ContentSafety.AgentDefinition agent = null, Azure.AI.ContentSafety.AgentSession session = null, System.BinaryData target = null, Azure.AI.ContentSafety.AgentInitialization agentInit = null, Azure.AI.ContentSafety.AgentInput input = null, Azure.AI.ContentSafety.AgentModel model = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentMessage> messages = null, string requestId = null, Azure.AI.ContentSafety.AgentModelResult response = null, Azure.AI.ContentSafety.AgentModelUsage usage = null, Azure.AI.ContentSafety.AgentToolCall toolCall = null, Azure.AI.ContentSafety.AgentToolResult toolResult = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentToolDeclaration> tools = null, Azure.AI.ContentSafety.AgentOutput output = null, Azure.AI.ContentSafety.AgentSummary summary = null, Azure.AI.ContentSafety.AgentTrace trace = null, Azure.AI.ContentSafety.AgentTenant tenant = null, Azure.AI.ContentSafety.AgentActor actor = null, Azure.AI.ContentSafety.AgentBudgets budgets = null, Azure.AI.ContentSafety.AgentContextExtensions extensions = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentStartupContext AgentStartupContext(System.DateTimeOffset timestamp = default(System.DateTimeOffset), long sequence = (long)0, Azure.AI.ContentSafety.AgentDefinition agent = null, Azure.AI.ContentSafety.AgentSession session = null, System.BinaryData target = null, Azure.AI.ContentSafety.AgentInitialization agentInit = null, Azure.AI.ContentSafety.AgentInput input = null, Azure.AI.ContentSafety.AgentModel model = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentMessage> messages = null, string requestId = null, Azure.AI.ContentSafety.AgentModelResult response = null, Azure.AI.ContentSafety.AgentModelUsage usage = null, Azure.AI.ContentSafety.AgentToolCall toolCall = null, Azure.AI.ContentSafety.AgentToolResult toolResult = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentToolDeclaration> tools = null, Azure.AI.ContentSafety.AgentOutput output = null, Azure.AI.ContentSafety.AgentSummary summary = null, Azure.AI.ContentSafety.AgentTrace trace = null, Azure.AI.ContentSafety.AgentTenant tenant = null, Azure.AI.ContentSafety.AgentActor actor = null, Azure.AI.ContentSafety.AgentBudgets budgets = null, Azure.AI.ContentSafety.AgentContextExtensions extensions = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentSummary AgentSummary(Azure.AI.ContentSafety.AgentShutdownReason reason = Azure.AI.ContentSafety.AgentShutdownReason.Completed, long? toolCalls = default(long?), long? errors = default(long?), double? durationSeconds = default(double?)) { throw null; }
        public static Azure.AI.ContentSafety.AgentTenant AgentTenant(string id = null, string name = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentToolCall AgentToolCall(string id = null, string name = null, Azure.AI.ContentSafety.AgentJsonObject args = null, string contentHash = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentToolDeclaration AgentToolDeclaration(string name = null, string description = null, Azure.AI.ContentSafety.AgentJsonObject schema = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentToolResult AgentToolResult(System.BinaryData value = null, bool isError = false, double? durationMs = default(double?)) { throw null; }
        public static Azure.AI.ContentSafety.AgentTrace AgentTrace(string traceId = null, string spanId = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentTransform AgentTransform(string path = null, System.BinaryData value = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentTransformVerdict AgentTransformVerdict(string reason = null, string message = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentWarning> warnings = null, Azure.AI.ContentSafety.AgentEvidence evidence = null, System.Collections.Generic.IEnumerable<string> resultLabels = null, Azure.AI.ContentSafety.AgentTransform transform = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentVerdict AgentVerdict(string decision = null, string reason = null, string message = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.AgentWarning> warnings = null, Azure.AI.ContentSafety.AgentEvidence evidence = null, System.Collections.Generic.IEnumerable<string> resultLabels = null) { throw null; }
        public static Azure.AI.ContentSafety.AgentWarning AgentWarning(string reason = null, string message = null) { throw null; }
        public static Azure.AI.ContentSafety.AnalyzeImageOptions AnalyzeImageOptions(Azure.AI.ContentSafety.ContentSafetyImageData image = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.ImageCategory> categories = null, Azure.AI.ContentSafety.AnalyzeImageOutputType? outputType = default(Azure.AI.ContentSafety.AnalyzeImageOutputType?)) { throw null; }
        public static Azure.AI.ContentSafety.AnalyzeImageResult AnalyzeImageResult(System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.ImageCategoriesAnalysis> categoriesAnalysis = null) { throw null; }
        public static Azure.AI.ContentSafety.AnalyzeTextOptions AnalyzeTextOptions(string text = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.TextCategory> categories = null, System.Collections.Generic.IEnumerable<string> blocklistNames = null, bool? haltOnBlocklistHit = default(bool?), Azure.AI.ContentSafety.AnalyzeTextOutputType? outputType = default(Azure.AI.ContentSafety.AnalyzeTextOutputType?)) { throw null; }
        public static Azure.AI.ContentSafety.AnalyzeTextResult AnalyzeTextResult(System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.TextBlocklistMatch> blocklistsMatch = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.TextCategoriesAnalysis> categoriesAnalysis = null) { throw null; }
        public static Azure.AI.ContentSafety.ContentSafetyImageData ContentSafetyImageData(System.BinaryData content = null, System.Uri blobUri = null) { throw null; }
        public static Azure.AI.ContentSafety.DetectedProvenance DetectedProvenance(Azure.AI.ContentSafety.DetectedProvenanceType? type = default(Azure.AI.ContentSafety.DetectedProvenanceType?), string provider = null, string modelName = null, System.DateTimeOffset? timestamp = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.ContentSafety.DetectProvenanceOptions DetectProvenanceOptions(Azure.AI.ContentSafety.ProvenanceContent content = null) { throw null; }
        public static Azure.AI.ContentSafety.DetectProvenanceResult DetectProvenanceResult(Azure.AI.ContentSafety.DetectOutcome outcome = default(Azure.AI.ContentSafety.DetectOutcome), System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.DetectedProvenance> results = null) { throw null; }
        public static Azure.AI.ContentSafety.DetectTextProtectedMaterialOptions DetectTextProtectedMaterialOptions(string text = null) { throw null; }
        public static Azure.AI.ContentSafety.DetectTextProtectedMaterialResult DetectTextProtectedMaterialResult(Azure.AI.ContentSafety.TextProtectedMaterialAnalysisResult protectedMaterialAnalysis = null) { throw null; }
        public static Azure.AI.ContentSafety.DocumentInjectionAnalysisResult DocumentInjectionAnalysisResult(bool attackDetected = false) { throw null; }
        public static Azure.AI.ContentSafety.ImageCategoriesAnalysis ImageCategoriesAnalysis(Azure.AI.ContentSafety.ImageCategory category = default(Azure.AI.ContentSafety.ImageCategory), int? severity = default(int?)) { throw null; }
        public static Azure.AI.ContentSafety.ProvenanceContent ProvenanceContent(System.Uri uri = null) { throw null; }
        public static Azure.AI.ContentSafety.ProvenanceDetectOperation ProvenanceDetectOperation(string id = null, Azure.AI.ContentSafety.OperationState status = default(Azure.AI.ContentSafety.OperationState), Azure.ResponseError error = null, Azure.AI.ContentSafety.DetectProvenanceResult result = null, Azure.AI.ContentSafety.ProvenanceOperationKind kind = default(Azure.AI.ContentSafety.ProvenanceOperationKind), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastUpdatedOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.AI.ContentSafety.RemoveTextBlocklistItemsOptions RemoveTextBlocklistItemsOptions(System.Collections.Generic.IEnumerable<string> blocklistItemIds = null) { throw null; }
        public static Azure.AI.ContentSafety.ShieldPromptOptions ShieldPromptOptions(string userPrompt = null, System.Collections.Generic.IEnumerable<string> documents = null) { throw null; }
        public static Azure.AI.ContentSafety.ShieldPromptResult ShieldPromptResult(Azure.AI.ContentSafety.UserPromptInjectionAnalysisResult userPromptAnalysis = null, System.Collections.Generic.IEnumerable<Azure.AI.ContentSafety.DocumentInjectionAnalysisResult> documentsAnalysis = null) { throw null; }
        public static Azure.AI.ContentSafety.TextBlocklist TextBlocklist(string name = null, string description = null) { throw null; }
        public static Azure.AI.ContentSafety.TextBlocklistItem TextBlocklistItem(string blocklistItemId, string description, string text) { throw null; }
        public static Azure.AI.ContentSafety.TextBlocklistItem TextBlocklistItem(string blocklistItemId = null, string description = null, string text = null, bool? isRegex = default(bool?)) { throw null; }
        public static Azure.AI.ContentSafety.TextBlocklistMatch TextBlocklistMatch(string blocklistName = null, string blocklistItemId = null, string blocklistItemText = null) { throw null; }
        public static Azure.AI.ContentSafety.TextCategoriesAnalysis TextCategoriesAnalysis(Azure.AI.ContentSafety.TextCategory category = default(Azure.AI.ContentSafety.TextCategory), int? severity = default(int?)) { throw null; }
        public static Azure.AI.ContentSafety.TextProtectedMaterialAnalysisResult TextProtectedMaterialAnalysisResult(bool detected = false) { throw null; }
        public static Azure.AI.ContentSafety.UserPromptInjectionAnalysisResult UserPromptInjectionAnalysisResult(bool attackDetected = false) { throw null; }
    }
    public partial class DetectedProvenance : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.DetectedProvenance>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DetectedProvenance>
    {
        internal DetectedProvenance() { }
        public string ModelName { get { throw null; } }
        public string Provider { get { throw null; } }
        public System.DateTimeOffset? Timestamp { get { throw null; } }
        public Azure.AI.ContentSafety.DetectedProvenanceType? Type { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.DetectedProvenance JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.DetectedProvenance PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.DetectedProvenance System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.DetectedProvenance>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.DetectedProvenance>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.DetectedProvenance System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DetectedProvenance>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DetectedProvenance>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DetectedProvenance>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DetectedProvenanceType : System.IEquatable<Azure.AI.ContentSafety.DetectedProvenanceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DetectedProvenanceType(string value) { throw null; }
        public static Azure.AI.ContentSafety.DetectedProvenanceType C2PA { get { throw null; } }
        public static Azure.AI.ContentSafety.DetectedProvenanceType Watermark { get { throw null; } }
        public bool Equals(Azure.AI.ContentSafety.DetectedProvenanceType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.ContentSafety.DetectedProvenanceType left, Azure.AI.ContentSafety.DetectedProvenanceType right) { throw null; }
        public static implicit operator Azure.AI.ContentSafety.DetectedProvenanceType (string value) { throw null; }
        public static implicit operator Azure.AI.ContentSafety.DetectedProvenanceType? (string value) { throw null; }
        public static bool operator !=(Azure.AI.ContentSafety.DetectedProvenanceType left, Azure.AI.ContentSafety.DetectedProvenanceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DetectOutcome : System.IEquatable<Azure.AI.ContentSafety.DetectOutcome>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DetectOutcome(string value) { throw null; }
        public static Azure.AI.ContentSafety.DetectOutcome NoProvenanceDetected { get { throw null; } }
        public static Azure.AI.ContentSafety.DetectOutcome ProvenanceDetected { get { throw null; } }
        public bool Equals(Azure.AI.ContentSafety.DetectOutcome other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.ContentSafety.DetectOutcome left, Azure.AI.ContentSafety.DetectOutcome right) { throw null; }
        public static implicit operator Azure.AI.ContentSafety.DetectOutcome (string value) { throw null; }
        public static implicit operator Azure.AI.ContentSafety.DetectOutcome? (string value) { throw null; }
        public static bool operator !=(Azure.AI.ContentSafety.DetectOutcome left, Azure.AI.ContentSafety.DetectOutcome right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DetectProvenanceOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.DetectProvenanceOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DetectProvenanceOptions>
    {
        public DetectProvenanceOptions(Azure.AI.ContentSafety.ProvenanceContent content) { }
        public Azure.AI.ContentSafety.ProvenanceContent Content { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.DetectProvenanceOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.ContentSafety.DetectProvenanceOptions detectProvenanceOptions) { throw null; }
        protected virtual Azure.AI.ContentSafety.DetectProvenanceOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.DetectProvenanceOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.DetectProvenanceOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.DetectProvenanceOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.DetectProvenanceOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DetectProvenanceOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DetectProvenanceOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DetectProvenanceOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DetectProvenanceResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.DetectProvenanceResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DetectProvenanceResult>
    {
        internal DetectProvenanceResult() { }
        public Azure.AI.ContentSafety.DetectOutcome Outcome { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.ContentSafety.DetectedProvenance> Results { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.DetectProvenanceResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.DetectProvenanceResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.DetectProvenanceResult System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.DetectProvenanceResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.DetectProvenanceResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.DetectProvenanceResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DetectProvenanceResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DetectProvenanceResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DetectProvenanceResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DetectTextProtectedMaterialOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.DetectTextProtectedMaterialOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DetectTextProtectedMaterialOptions>
    {
        public DetectTextProtectedMaterialOptions(string text) { }
        public string Text { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.DetectTextProtectedMaterialOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.ContentSafety.DetectTextProtectedMaterialOptions detectTextProtectedMaterialOptions) { throw null; }
        protected virtual Azure.AI.ContentSafety.DetectTextProtectedMaterialOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.DetectTextProtectedMaterialOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.DetectTextProtectedMaterialOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.DetectTextProtectedMaterialOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.DetectTextProtectedMaterialOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DetectTextProtectedMaterialOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DetectTextProtectedMaterialOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DetectTextProtectedMaterialOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DetectTextProtectedMaterialResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.DetectTextProtectedMaterialResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DetectTextProtectedMaterialResult>
    {
        internal DetectTextProtectedMaterialResult() { }
        public Azure.AI.ContentSafety.TextProtectedMaterialAnalysisResult ProtectedMaterialAnalysis { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.DetectTextProtectedMaterialResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.ContentSafety.DetectTextProtectedMaterialResult (Azure.Response response) { throw null; }
        protected virtual Azure.AI.ContentSafety.DetectTextProtectedMaterialResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.DetectTextProtectedMaterialResult System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.DetectTextProtectedMaterialResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.DetectTextProtectedMaterialResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.DetectTextProtectedMaterialResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DetectTextProtectedMaterialResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DetectTextProtectedMaterialResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DetectTextProtectedMaterialResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DocumentInjectionAnalysisResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.DocumentInjectionAnalysisResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DocumentInjectionAnalysisResult>
    {
        internal DocumentInjectionAnalysisResult() { }
        public bool AttackDetected { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.DocumentInjectionAnalysisResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.DocumentInjectionAnalysisResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.DocumentInjectionAnalysisResult System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.DocumentInjectionAnalysisResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.DocumentInjectionAnalysisResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.DocumentInjectionAnalysisResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DocumentInjectionAnalysisResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DocumentInjectionAnalysisResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.DocumentInjectionAnalysisResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ImageCategoriesAnalysis : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.ImageCategoriesAnalysis>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ImageCategoriesAnalysis>
    {
        internal ImageCategoriesAnalysis() { }
        public Azure.AI.ContentSafety.ImageCategory Category { get { throw null; } }
        public int? Severity { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.ImageCategoriesAnalysis JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.ImageCategoriesAnalysis PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.ImageCategoriesAnalysis System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.ImageCategoriesAnalysis>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.ImageCategoriesAnalysis>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.ImageCategoriesAnalysis System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ImageCategoriesAnalysis>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ImageCategoriesAnalysis>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ImageCategoriesAnalysis>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageCategory : System.IEquatable<Azure.AI.ContentSafety.ImageCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageCategory(string value) { throw null; }
        public static Azure.AI.ContentSafety.ImageCategory Hate { get { throw null; } }
        public static Azure.AI.ContentSafety.ImageCategory SelfHarm { get { throw null; } }
        public static Azure.AI.ContentSafety.ImageCategory Sexual { get { throw null; } }
        public static Azure.AI.ContentSafety.ImageCategory Violence { get { throw null; } }
        public bool Equals(Azure.AI.ContentSafety.ImageCategory other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.ContentSafety.ImageCategory left, Azure.AI.ContentSafety.ImageCategory right) { throw null; }
        public static implicit operator Azure.AI.ContentSafety.ImageCategory (string value) { throw null; }
        public static implicit operator Azure.AI.ContentSafety.ImageCategory? (string value) { throw null; }
        public static bool operator !=(Azure.AI.ContentSafety.ImageCategory left, Azure.AI.ContentSafety.ImageCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OperationState : System.IEquatable<Azure.AI.ContentSafety.OperationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OperationState(string value) { throw null; }
        public static Azure.AI.ContentSafety.OperationState Canceled { get { throw null; } }
        public static Azure.AI.ContentSafety.OperationState Failed { get { throw null; } }
        public static Azure.AI.ContentSafety.OperationState NotStarted { get { throw null; } }
        public static Azure.AI.ContentSafety.OperationState Running { get { throw null; } }
        public static Azure.AI.ContentSafety.OperationState Succeeded { get { throw null; } }
        public bool Equals(Azure.AI.ContentSafety.OperationState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.ContentSafety.OperationState left, Azure.AI.ContentSafety.OperationState right) { throw null; }
        public static implicit operator Azure.AI.ContentSafety.OperationState (string value) { throw null; }
        public static implicit operator Azure.AI.ContentSafety.OperationState? (string value) { throw null; }
        public static bool operator !=(Azure.AI.ContentSafety.OperationState left, Azure.AI.ContentSafety.OperationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProvenanceContent : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.ProvenanceContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ProvenanceContent>
    {
        public ProvenanceContent(System.Uri uri) { }
        public System.Uri Uri { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.ProvenanceContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.ProvenanceContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.ProvenanceContent System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.ProvenanceContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.ProvenanceContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.ProvenanceContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ProvenanceContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ProvenanceContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ProvenanceContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProvenanceDetectOperation : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.ProvenanceDetectOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ProvenanceDetectOperation>
    {
        internal ProvenanceDetectOperation() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.ContentSafety.ProvenanceOperationKind Kind { get { throw null; } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } }
        public Azure.AI.ContentSafety.DetectProvenanceResult Result { get { throw null; } }
        public Azure.AI.ContentSafety.OperationState Status { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.ProvenanceDetectOperation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.ContentSafety.ProvenanceDetectOperation (Azure.Response response) { throw null; }
        protected virtual Azure.AI.ContentSafety.ProvenanceDetectOperation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.ProvenanceDetectOperation System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.ProvenanceDetectOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.ProvenanceDetectOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.ProvenanceDetectOperation System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ProvenanceDetectOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ProvenanceDetectOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ProvenanceDetectOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvenanceOperationKind : System.IEquatable<Azure.AI.ContentSafety.ProvenanceOperationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvenanceOperationKind(string value) { throw null; }
        public static Azure.AI.ContentSafety.ProvenanceOperationKind Detect { get { throw null; } }
        public bool Equals(Azure.AI.ContentSafety.ProvenanceOperationKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.ContentSafety.ProvenanceOperationKind left, Azure.AI.ContentSafety.ProvenanceOperationKind right) { throw null; }
        public static implicit operator Azure.AI.ContentSafety.ProvenanceOperationKind (string value) { throw null; }
        public static implicit operator Azure.AI.ContentSafety.ProvenanceOperationKind? (string value) { throw null; }
        public static bool operator !=(Azure.AI.ContentSafety.ProvenanceOperationKind left, Azure.AI.ContentSafety.ProvenanceOperationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RemoveTextBlocklistItemsOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.RemoveTextBlocklistItemsOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.RemoveTextBlocklistItemsOptions>
    {
        public RemoveTextBlocklistItemsOptions(System.Collections.Generic.IEnumerable<string> blocklistItemIds) { }
        public System.Collections.Generic.IList<string> BlocklistItemIds { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.RemoveTextBlocklistItemsOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.ContentSafety.RemoveTextBlocklistItemsOptions removeTextBlocklistItemsOptions) { throw null; }
        protected virtual Azure.AI.ContentSafety.RemoveTextBlocklistItemsOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.RemoveTextBlocklistItemsOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.RemoveTextBlocklistItemsOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.RemoveTextBlocklistItemsOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.RemoveTextBlocklistItemsOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.RemoveTextBlocklistItemsOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.RemoveTextBlocklistItemsOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.RemoveTextBlocklistItemsOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ShieldPromptOptions : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.ShieldPromptOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ShieldPromptOptions>
    {
        public ShieldPromptOptions() { }
        public System.Collections.Generic.IList<string> Documents { get { throw null; } }
        public string UserPrompt { get { throw null; } set { } }
        protected virtual Azure.AI.ContentSafety.ShieldPromptOptions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static implicit operator Azure.Core.RequestContent (Azure.AI.ContentSafety.ShieldPromptOptions shieldPromptOptions) { throw null; }
        protected virtual Azure.AI.ContentSafety.ShieldPromptOptions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.ShieldPromptOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.ShieldPromptOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.ShieldPromptOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.ShieldPromptOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ShieldPromptOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ShieldPromptOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ShieldPromptOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ShieldPromptResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.ShieldPromptResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ShieldPromptResult>
    {
        internal ShieldPromptResult() { }
        public System.Collections.Generic.IList<Azure.AI.ContentSafety.DocumentInjectionAnalysisResult> DocumentsAnalysis { get { throw null; } }
        public Azure.AI.ContentSafety.UserPromptInjectionAnalysisResult UserPromptAnalysis { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.ShieldPromptResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.ContentSafety.ShieldPromptResult (Azure.Response response) { throw null; }
        protected virtual Azure.AI.ContentSafety.ShieldPromptResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.ShieldPromptResult System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.ShieldPromptResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.ShieldPromptResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.ShieldPromptResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ShieldPromptResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ShieldPromptResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.ShieldPromptResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextBlocklist : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.TextBlocklist>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextBlocklist>
    {
        internal TextBlocklist() { }
        public string Description { get { throw null; } }
        public string Name { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.TextBlocklist JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.ContentSafety.TextBlocklist (Azure.Response response) { throw null; }
        protected virtual Azure.AI.ContentSafety.TextBlocklist PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.TextBlocklist System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.TextBlocklist>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.TextBlocklist>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.TextBlocklist System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextBlocklist>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextBlocklist>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextBlocklist>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextBlocklistItem : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.TextBlocklistItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextBlocklistItem>
    {
        public TextBlocklistItem(string text) { }
        public string BlocklistItemId { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public bool? IsRegex { get { throw null; } set { } }
        public string Text { get { throw null; } set { } }
        protected virtual Azure.AI.ContentSafety.TextBlocklistItem JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        public static explicit operator Azure.AI.ContentSafety.TextBlocklistItem (Azure.Response response) { throw null; }
        protected virtual Azure.AI.ContentSafety.TextBlocklistItem PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.TextBlocklistItem System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.TextBlocklistItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.TextBlocklistItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.TextBlocklistItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextBlocklistItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextBlocklistItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextBlocklistItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextBlocklistMatch : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.TextBlocklistMatch>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextBlocklistMatch>
    {
        internal TextBlocklistMatch() { }
        public string BlocklistItemId { get { throw null; } }
        public string BlocklistItemText { get { throw null; } }
        public string BlocklistName { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.TextBlocklistMatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.TextBlocklistMatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.TextBlocklistMatch System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.TextBlocklistMatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.TextBlocklistMatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.TextBlocklistMatch System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextBlocklistMatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextBlocklistMatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextBlocklistMatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TextCategoriesAnalysis : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.TextCategoriesAnalysis>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextCategoriesAnalysis>
    {
        internal TextCategoriesAnalysis() { }
        public Azure.AI.ContentSafety.TextCategory Category { get { throw null; } }
        public int? Severity { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.TextCategoriesAnalysis JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.TextCategoriesAnalysis PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.TextCategoriesAnalysis System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.TextCategoriesAnalysis>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.TextCategoriesAnalysis>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.TextCategoriesAnalysis System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextCategoriesAnalysis>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextCategoriesAnalysis>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextCategoriesAnalysis>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TextCategory : System.IEquatable<Azure.AI.ContentSafety.TextCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TextCategory(string value) { throw null; }
        public static Azure.AI.ContentSafety.TextCategory Hate { get { throw null; } }
        public static Azure.AI.ContentSafety.TextCategory SelfHarm { get { throw null; } }
        public static Azure.AI.ContentSafety.TextCategory Sexual { get { throw null; } }
        public static Azure.AI.ContentSafety.TextCategory Violence { get { throw null; } }
        public bool Equals(Azure.AI.ContentSafety.TextCategory other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.ContentSafety.TextCategory left, Azure.AI.ContentSafety.TextCategory right) { throw null; }
        public static implicit operator Azure.AI.ContentSafety.TextCategory (string value) { throw null; }
        public static implicit operator Azure.AI.ContentSafety.TextCategory? (string value) { throw null; }
        public static bool operator !=(Azure.AI.ContentSafety.TextCategory left, Azure.AI.ContentSafety.TextCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TextProtectedMaterialAnalysisResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.TextProtectedMaterialAnalysisResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextProtectedMaterialAnalysisResult>
    {
        internal TextProtectedMaterialAnalysisResult() { }
        public bool Detected { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.TextProtectedMaterialAnalysisResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.TextProtectedMaterialAnalysisResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.TextProtectedMaterialAnalysisResult System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.TextProtectedMaterialAnalysisResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.TextProtectedMaterialAnalysisResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.TextProtectedMaterialAnalysisResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextProtectedMaterialAnalysisResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextProtectedMaterialAnalysisResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.TextProtectedMaterialAnalysisResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserPromptInjectionAnalysisResult : System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.UserPromptInjectionAnalysisResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.UserPromptInjectionAnalysisResult>
    {
        internal UserPromptInjectionAnalysisResult() { }
        public bool AttackDetected { get { throw null; } }
        protected virtual Azure.AI.ContentSafety.UserPromptInjectionAnalysisResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.AI.ContentSafety.UserPromptInjectionAnalysisResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.AI.ContentSafety.UserPromptInjectionAnalysisResult System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.UserPromptInjectionAnalysisResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.ContentSafety.UserPromptInjectionAnalysisResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.ContentSafety.UserPromptInjectionAnalysisResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.UserPromptInjectionAnalysisResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.UserPromptInjectionAnalysisResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.ContentSafety.UserPromptInjectionAnalysisResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Microsoft.Extensions.Azure
{
    public static partial class ContentSafetyClientBuilderExtensions
    {
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.ContentSafety.BlocklistClient, Azure.AI.ContentSafety.ContentSafetyClientOptions> AddBlocklistClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.ContentSafety.BlocklistClient, Azure.AI.ContentSafety.ContentSafetyClientOptions> AddBlocklistClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.ContentSafety.BlocklistClient, Azure.AI.ContentSafety.ContentSafetyClientOptions> AddBlocklistClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.ContentSafety.ContentProvenanceClient, Azure.AI.ContentSafety.ContentSafetyClientOptions> AddContentProvenanceClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.ContentSafety.ContentProvenanceClient, Azure.AI.ContentSafety.ContentSafetyClientOptions> AddContentProvenanceClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.ContentSafety.ContentProvenanceClient, Azure.AI.ContentSafety.ContentSafetyClientOptions> AddContentProvenanceClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.ContentSafety.ContentSafetyClient, Azure.AI.ContentSafety.ContentSafetyClientOptions> AddContentSafetyClient<TBuilder>(this TBuilder builder, System.Uri endpoint) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithCredential { throw null; }
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.ContentSafety.ContentSafetyClient, Azure.AI.ContentSafety.ContentSafetyClientOptions> AddContentSafetyClient<TBuilder>(this TBuilder builder, System.Uri endpoint, Azure.AzureKeyCredential credential) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilder { throw null; }
        [System.Diagnostics.CodeAnalysis.RequiresDynamicCodeAttribute("Requires unreferenced code until we opt into EnableConfigurationBindingGenerator.")]
        public static Azure.Core.Extensions.IAzureClientBuilder<Azure.AI.ContentSafety.ContentSafetyClient, Azure.AI.ContentSafety.ContentSafetyClientOptions> AddContentSafetyClient<TBuilder, TConfiguration>(this TBuilder builder, TConfiguration configuration) where TBuilder : Azure.Core.Extensions.IAzureClientFactoryBuilderWithConfiguration<TConfiguration> { throw null; }
    }
}
