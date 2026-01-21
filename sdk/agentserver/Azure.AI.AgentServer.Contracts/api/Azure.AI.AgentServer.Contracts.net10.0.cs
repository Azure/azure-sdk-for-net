namespace Azure.AI.AgentServer.Contracts.Generated
{
    public partial class AzureAIAgentServerContractsContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureAIAgentServerContractsContext() { }
        public static Azure.AI.AgentServer.Contracts.Generated.AzureAIAgentServerContractsContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
}
namespace Azure.AI.AgentServer.Contracts.Generated.Agents
{
    public partial class AgentId : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.Agents.AgentId>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Agents.AgentId>
    {
        public AgentId() { }
        public AgentId(Azure.AI.AgentServer.Contracts.Generated.Agents.AgentIdType type, string name, string version, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public AgentId(string name, string version) { }
        public string Name { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.Agents.AgentIdType Type { get { throw null; } }
        public string Version { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.Agents.AgentId DeserializeAgentId(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.Agents.AgentId FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.Agents.AgentId System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.Agents.AgentId>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.Agents.AgentId>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.Agents.AgentId System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Agents.AgentId>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Agents.AgentId>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Agents.AgentId>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentIdType : System.IEquatable<Azure.AI.AgentServer.Contracts.Generated.Agents.AgentIdType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentIdType(string value) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.Agents.AgentIdType AgentId { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Contracts.Generated.Agents.AgentIdType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Contracts.Generated.Agents.AgentIdType left, Azure.AI.AgentServer.Contracts.Generated.Agents.AgentIdType right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Contracts.Generated.Agents.AgentIdType (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Contracts.Generated.Agents.AgentIdType left, Azure.AI.AgentServer.Contracts.Generated.Agents.AgentIdType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentReference : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.Agents.AgentReference>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Agents.AgentReference>
    {
        public AgentReference() { }
        public AgentReference(Azure.AI.AgentServer.Contracts.Generated.Agents.AgentReferenceType type, string name, string version, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public AgentReference(string name) { }
        public string Name { get { throw null; } set { } }
        public Azure.AI.AgentServer.Contracts.Generated.Agents.AgentReferenceType Type { get { throw null; } }
        public string Version { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.Agents.AgentReference DeserializeAgentReference(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.Agents.AgentReference FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.Agents.AgentReference System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.Agents.AgentReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.Agents.AgentReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.Agents.AgentReference System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Agents.AgentReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Agents.AgentReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Agents.AgentReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentReferenceType : System.IEquatable<Azure.AI.AgentServer.Contracts.Generated.Agents.AgentReferenceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentReferenceType(string value) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.Agents.AgentReferenceType AgentReference { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Contracts.Generated.Agents.AgentReferenceType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Contracts.Generated.Agents.AgentReferenceType left, Azure.AI.AgentServer.Contracts.Generated.Agents.AgentReferenceType right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Contracts.Generated.Agents.AgentReferenceType (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Contracts.Generated.Agents.AgentReferenceType left, Azure.AI.AgentServer.Contracts.Generated.Agents.AgentReferenceType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
namespace Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents
{
    public partial class InvokeAzureAgentWorkflowActionOutputItemResource : Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents.WorkflowActionOutputItemResource, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents.InvokeAzureAgentWorkflowActionOutputItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents.InvokeAzureAgentWorkflowActionOutputItemResource>
    {
        public InvokeAzureAgentWorkflowActionOutputItemResource() { }
        public InvokeAzureAgentWorkflowActionOutputItemResource(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string kind, string actionId, string parentActionId, string previousActionId, Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents.WorkflowActionOutputItemResourceStatus status, Azure.AI.AgentServer.Contracts.Generated.Agents.AgentId agent, string conversationId, string responseId) { }
        public InvokeAzureAgentWorkflowActionOutputItemResource(string id, string actionId, Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents.WorkflowActionOutputItemResourceStatus status, Azure.AI.AgentServer.Contracts.Generated.Agents.AgentId agent, string responseId) { }
        public Azure.AI.AgentServer.Contracts.Generated.Agents.AgentId Agent { get { throw null; } }
        public string ConversationId { get { throw null; } }
        public string ResponseId { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents.InvokeAzureAgentWorkflowActionOutputItemResource DeserializeInvokeAzureAgentWorkflowActionOutputItemResource(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents.InvokeAzureAgentWorkflowActionOutputItemResource FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents.InvokeAzureAgentWorkflowActionOutputItemResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents.InvokeAzureAgentWorkflowActionOutputItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents.InvokeAzureAgentWorkflowActionOutputItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents.InvokeAzureAgentWorkflowActionOutputItemResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents.InvokeAzureAgentWorkflowActionOutputItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents.InvokeAzureAgentWorkflowActionOutputItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents.InvokeAzureAgentWorkflowActionOutputItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class WorkflowActionOutputItemResource : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents.WorkflowActionOutputItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents.WorkflowActionOutputItemResource>
    {
        public WorkflowActionOutputItemResource() { }
        public WorkflowActionOutputItemResource(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string kind, string actionId, string parentActionId, string previousActionId, Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents.WorkflowActionOutputItemResourceStatus status) { }
        public WorkflowActionOutputItemResource(string id, string actionId, Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents.WorkflowActionOutputItemResourceStatus status) { }
        public string ActionId { get { throw null; } }
        public string Kind { get { throw null; } set { } }
        public string ParentActionId { get { throw null; } }
        public string PreviousActionId { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents.WorkflowActionOutputItemResourceStatus Status { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents.WorkflowActionOutputItemResource DeserializeWorkflowActionOutputItemResource(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents.WorkflowActionOutputItemResource FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents.WorkflowActionOutputItemResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents.WorkflowActionOutputItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents.WorkflowActionOutputItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents.WorkflowActionOutputItemResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents.WorkflowActionOutputItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents.WorkflowActionOutputItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents.WorkflowActionOutputItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum WorkflowActionOutputItemResourceStatus
    {
        Completed = 0,
        Failed = 1,
        InProgress = 2,
        Cancelled = 3,
    }
    public static partial class WorkflowActionOutputItemResourceStatusExtensions
    {
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents.WorkflowActionOutputItemResourceStatus value) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.Agents.WorkflowAgents.WorkflowActionOutputItemResourceStatus ToWorkflowActionOutputItemResourceStatus(this string value) { throw null; }
    }
}
namespace Azure.AI.AgentServer.Contracts.Generated.Common
{
    public partial class ApiError : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.Common.ApiError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Common.ApiError>
    {
        public ApiError() { }
        public ApiError(string code, string message, System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.Common.ApiError> details) { }
        public ApiError(string code, string message, string target, System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.Common.ApiError> details, Azure.AI.AgentServer.Contracts.Generated.Common.ApiInnerError innererror, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.Common.ApiError> Details { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.Common.ApiInnerError Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.Common.ApiError DeserializeApiError(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.Common.ApiError FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.Common.ApiError System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.Common.ApiError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.Common.ApiError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.Common.ApiError System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Common.ApiError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Common.ApiError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Common.ApiError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ApiInnerError : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.Common.ApiInnerError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Common.ApiInnerError>
    {
        public ApiInnerError() { }
        public ApiInnerError(string code) { }
        public ApiInnerError(string code, Azure.AI.AgentServer.Contracts.Generated.Common.ApiInnerError innererror, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public string Code { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.Common.ApiInnerError Innererror { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.Common.ApiInnerError DeserializeApiInnerError(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.Common.ApiInnerError FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.Common.ApiInnerError System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.Common.ApiInnerError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.Common.ApiInnerError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.Common.ApiInnerError System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Common.ApiInnerError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Common.ApiInnerError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Common.ApiInnerError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public static partial class Argument
    {
        public static void AssertEnumDefined(System.Type enumType, object value, string name) { }
        public static void AssertInRange<T>(T value, T minimum, T maximum, string name) where T : notnull, System.IComparable<T> { }
        public static void AssertNotDefault<T>(ref T value, string name) where T : struct { }
        public static void AssertNotNullOrEmpty(string value, string name) { }
        public static void AssertNotNullOrEmpty<T>(System.Collections.Generic.IEnumerable<T> value, string name) { }
        public static void AssertNotNullOrWhiteSpace(string value, string name) { }
        public static void AssertNotNull<T>(T? value, string name) where T : struct { }
        public static void AssertNotNull<T>(T value, string name) { }
        public static void AssertNull<T>(T value, string name, string message = null) { }
        public static string CheckNotNullOrEmpty(string value, string name) { throw null; }
        public static T CheckNotNull<T>(T value, string name) where T : class { throw null; }
    }
    public partial class ChangeTrackingDictionary<TKey, TValue> : System.Collections.Generic.ICollection<System.Collections.Generic.KeyValuePair<TKey, TValue>>, System.Collections.Generic.IDictionary<TKey, TValue>, System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TKey, TValue>>, System.Collections.Generic.IReadOnlyCollection<System.Collections.Generic.KeyValuePair<TKey, TValue>>, System.Collections.Generic.IReadOnlyDictionary<TKey, TValue>, System.Collections.IEnumerable where TKey : notnull
    {
        public ChangeTrackingDictionary() { }
        public ChangeTrackingDictionary(System.Collections.Generic.IDictionary<TKey, TValue> dictionary) { }
        public ChangeTrackingDictionary(System.Collections.Generic.IReadOnlyDictionary<TKey, TValue> dictionary) { }
        public int Count { get { throw null; } }
        public bool IsReadOnly { get { throw null; } }
        public bool IsUndefined { get { throw null; } }
        public TValue this[TKey key] { get { throw null; } set { } }
        public System.Collections.Generic.ICollection<TKey> Keys { get { throw null; } }
        System.Collections.Generic.IEnumerable<TKey> System.Collections.Generic.IReadOnlyDictionary<TKey,TValue>.Keys { get { throw null; } }
        System.Collections.Generic.IEnumerable<TValue> System.Collections.Generic.IReadOnlyDictionary<TKey,TValue>.Values { get { throw null; } }
        public System.Collections.Generic.ICollection<TValue> Values { get { throw null; } }
        public void Add(System.Collections.Generic.KeyValuePair<TKey, TValue> item) { }
        public void Add(TKey key, TValue value) { }
        public void Clear() { }
        public bool Contains(System.Collections.Generic.KeyValuePair<TKey, TValue> item) { throw null; }
        public bool ContainsKey(TKey key) { throw null; }
        public void CopyTo(System.Collections.Generic.KeyValuePair<TKey, TValue>[] array, int index) { }
        public System.Collections.Generic.IDictionary<TKey, TValue> EnsureDictionary() { throw null; }
        public System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TKey, TValue>> GetEnumerator() { throw null; }
        public bool Remove(System.Collections.Generic.KeyValuePair<TKey, TValue> item) { throw null; }
        public bool Remove(TKey key) { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
        public bool TryGetValue(TKey key, out TValue value) { throw null; }
    }
    public partial class ChangeTrackingList<T> : System.Collections.Generic.ICollection<T>, System.Collections.Generic.IEnumerable<T>, System.Collections.Generic.IList<T>, System.Collections.Generic.IReadOnlyCollection<T>, System.Collections.Generic.IReadOnlyList<T>, System.Collections.IEnumerable
    {
        public ChangeTrackingList() { }
        public ChangeTrackingList(System.Collections.Generic.IList<T> innerList) { }
        public ChangeTrackingList(System.Collections.Generic.IReadOnlyList<T> innerList) { }
        public int Count { get { throw null; } }
        public bool IsReadOnly { get { throw null; } }
        public bool IsUndefined { get { throw null; } }
        public T this[int index] { get { throw null; } set { } }
        public void Add(T item) { }
        public void Clear() { }
        public bool Contains(T item) { throw null; }
        public void CopyTo(T[] array, int arrayIndex) { }
        public System.Collections.Generic.IList<T> EnsureList() { throw null; }
        public System.Collections.Generic.IEnumerator<T> GetEnumerator() { throw null; }
        public int IndexOf(T item) { throw null; }
        public void Insert(int index, T item) { }
        public bool Remove(T item) { throw null; }
        public void RemoveAt(int index) { }
        public void Reset() { }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial interface IUtf8JsonSerializable
    {
        void Write(System.Text.Json.Utf8JsonWriter writer);
    }
    public static partial class ModelSerializationExtensions
    {
        public static readonly System.Text.Json.JsonDocumentOptions JsonDocumentOptions;
        public static readonly System.ClientModel.Primitives.ModelReaderWriterOptions JsonV3Options;
        public static readonly System.BinaryData SentinelValue;
        public static readonly System.ClientModel.Primitives.ModelReaderWriterOptions WireOptions;
        public static readonly System.ClientModel.Primitives.ModelReaderWriterOptions WireV3Options;
        public static byte[] GetBytesFromBase64(this System.Text.Json.JsonElement element, string format) { throw null; }
        public static char GetChar(this System.Text.Json.JsonElement element) { throw null; }
        public static System.DateTimeOffset GetDateTimeOffset(this System.Text.Json.JsonElement element, string format) { throw null; }
        public static object GetObject(this System.Text.Json.JsonElement element) { throw null; }
        public static string GetRequiredString(this System.Text.Json.JsonElement element) { throw null; }
        public static System.TimeSpan GetTimeSpan(this System.Text.Json.JsonElement element, string format) { throw null; }
        public static bool IsSentinelValue(System.BinaryData value) { throw null; }
        [System.Diagnostics.ConditionalAttribute("DEBUG")]
        public static void ThrowNonNullablePropertyIsNull(this System.Text.Json.JsonProperty property) { }
        public static void WriteBase64StringValue(this System.Text.Json.Utf8JsonWriter writer, byte[] value, string format) { }
        public static void WriteNumberValue(this System.Text.Json.Utf8JsonWriter writer, System.DateTimeOffset value, string format) { }
        public static void WriteObjectValue(this System.Text.Json.Utf8JsonWriter writer, object value, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { }
        public static void WriteObjectValue<T>(this System.Text.Json.Utf8JsonWriter writer, T value, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { }
        public static void WriteStringValue(this System.Text.Json.Utf8JsonWriter writer, char value) { }
        public static void WriteStringValue(this System.Text.Json.Utf8JsonWriter writer, System.DateTime value, string format) { }
        public static void WriteStringValue(this System.Text.Json.Utf8JsonWriter writer, System.DateTimeOffset value, string format) { }
        public static void WriteStringValue(this System.Text.Json.Utf8JsonWriter writer, System.TimeSpan value, string format) { }
        public static partial class TypeFormatters
        {
            public const string DefaultNumberFormat = "G";
            public static string ConvertToString(object value, string format = null) { throw null; }
            public static byte[] FromBase64UrlString(string value) { throw null; }
            public static System.DateTimeOffset ParseDateTimeOffset(string value, string format) { throw null; }
            public static System.TimeSpan ParseTimeSpan(string value, string format) { throw null; }
            public static string ToBase64UrlString(byte[] value) { throw null; }
            public static string ToString(bool value) { throw null; }
            public static string ToString(byte[] value, string format) { throw null; }
            public static string ToString(System.DateTime value, string format) { throw null; }
            public static string ToString(System.DateTimeOffset value, string format) { throw null; }
            public static string ToString(System.TimeSpan value, string format) { throw null; }
        }
    }
    public static partial class Optional
    {
        public static bool IsCollectionDefined<T>(System.Collections.Generic.IEnumerable<T> collection) { throw null; }
        public static bool IsCollectionDefined<TKey, TValue>(System.Collections.Generic.IDictionary<TKey, TValue> collection) { throw null; }
        public static bool IsCollectionDefined<TKey, TValue>(System.Collections.Generic.IReadOnlyDictionary<TKey, TValue> collection) { throw null; }
        public static bool IsDefined(object value) { throw null; }
        public static bool IsDefined(string value) { throw null; }
        public static bool IsDefined(System.Text.Json.JsonElement value) { throw null; }
        public static bool IsDefined<T>(T? value) where T : struct { throw null; }
    }
    public partial class Utf8JsonRequestContent : Azure.Core.RequestContent
    {
        public Utf8JsonRequestContent() { }
        public System.Text.Json.Utf8JsonWriter JsonWriter { get { throw null; } }
        public override void Dispose() { }
        public override bool TryComputeLength(out long length) { throw null; }
        public override void WriteTo(System.IO.Stream stream, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { }
        public override System.Threading.Tasks.Task WriteToAsync(System.IO.Stream stream, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.AI.AgentServer.Contracts.Generated.Conversations
{
    public partial class ResponseConversation1 : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.Conversations.ResponseConversation1>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Conversations.ResponseConversation1>
    {
        public ResponseConversation1() { }
        public ResponseConversation1(string id) { }
        public ResponseConversation1(string id, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public string Id { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.Conversations.ResponseConversation1 DeserializeResponseConversation1(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.Conversations.ResponseConversation1 FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.Conversations.ResponseConversation1 System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.Conversations.ResponseConversation1>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.Conversations.ResponseConversation1>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.Conversations.ResponseConversation1 System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Conversations.ResponseConversation1>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Conversations.ResponseConversation1>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Conversations.ResponseConversation1>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
}
namespace Azure.AI.AgentServer.Contracts.Generated.MemoryStore
{
    public partial class ChatSummaryMemoryItem : Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItem, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.ChatSummaryMemoryItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.ChatSummaryMemoryItem>
    {
        public ChatSummaryMemoryItem() { }
        public ChatSummaryMemoryItem(string memoryId, System.DateTimeOffset updatedAt, string scope, string content) { }
        public ChatSummaryMemoryItem(string memoryId, System.DateTimeOffset updatedAt, string scope, string content, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItemKind kind, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.ChatSummaryMemoryItem DeserializeChatSummaryMemoryItem(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.MemoryStore.ChatSummaryMemoryItem FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.ChatSummaryMemoryItem System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.ChatSummaryMemoryItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.ChatSummaryMemoryItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.ChatSummaryMemoryItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.ChatSummaryMemoryItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.ChatSummaryMemoryItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.ChatSummaryMemoryItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class CreateMemoryStoreRequest : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.CreateMemoryStoreRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.CreateMemoryStoreRequest>
    {
        public CreateMemoryStoreRequest() { }
        public CreateMemoryStoreRequest(string name, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefinition definition) { }
        public CreateMemoryStoreRequest(string name, string description, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefinition definition, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefinition Definition { get { throw null; } }
        public string Description { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.CreateMemoryStoreRequest DeserializeCreateMemoryStoreRequest(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.CreateMemoryStoreRequest FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.CreateMemoryStoreRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.CreateMemoryStoreRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.CreateMemoryStoreRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.CreateMemoryStoreRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.CreateMemoryStoreRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.CreateMemoryStoreRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.CreateMemoryStoreRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class DeleteMemoryStoreResponse : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.DeleteMemoryStoreResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.DeleteMemoryStoreResponse>
    {
        public DeleteMemoryStoreResponse() { }
        public DeleteMemoryStoreResponse(Azure.AI.AgentServer.Contracts.Generated.MemoryStore.DeleteMemoryStoreResponseObject @object, string name, bool deleted, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public DeleteMemoryStoreResponse(string name, bool deleted) { }
        public bool Deleted { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.MemoryStore.DeleteMemoryStoreResponseObject Object { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.DeleteMemoryStoreResponse DeserializeDeleteMemoryStoreResponse(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.DeleteMemoryStoreResponse FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.DeleteMemoryStoreResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.DeleteMemoryStoreResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.DeleteMemoryStoreResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.DeleteMemoryStoreResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.DeleteMemoryStoreResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.DeleteMemoryStoreResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.DeleteMemoryStoreResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeleteMemoryStoreResponseObject : System.IEquatable<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.DeleteMemoryStoreResponseObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeleteMemoryStoreResponseObject(string value) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.DeleteMemoryStoreResponseObject MemoryStoreDeleted { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Contracts.Generated.MemoryStore.DeleteMemoryStoreResponseObject other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Contracts.Generated.MemoryStore.DeleteMemoryStoreResponseObject left, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.DeleteMemoryStoreResponseObject right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Contracts.Generated.MemoryStore.DeleteMemoryStoreResponseObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Contracts.Generated.MemoryStore.DeleteMemoryStoreResponseObject left, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.DeleteMemoryStoreResponseObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.ClientModel.Primitives.PersistableModelProxyAttribute(typeof(Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UnknownMemoryItem))]
    public abstract partial class MemoryItem : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItem>
    {
        public MemoryItem() { }
        protected MemoryItem(string memoryId, System.DateTimeOffset updatedAt, string scope, string content) { }
        public MemoryItem(string memoryId, System.DateTimeOffset updatedAt, string scope, string content, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItemKind kind, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public string Content { get { throw null; } set { } }
        public Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItemKind Kind { get { throw null; } set { } }
        public string MemoryId { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public System.DateTimeOffset UpdatedAt { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItem DeserializeMemoryItem(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItem FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItem System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MemoryItemKind : System.IEquatable<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItemKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MemoryItemKind(string value) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItemKind ChatSummary { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItemKind UserProfile { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItemKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItemKind left, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItemKind right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItemKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItemKind left, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItemKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MemoryOperation : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryOperation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryOperation>
    {
        public MemoryOperation() { }
        public MemoryOperation(Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryOperationKind kind, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItem memoryItem) { }
        public MemoryOperation(Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryOperationKind kind, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItem memoryItem, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryOperationKind Kind { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItem MemoryItem { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryOperation DeserializeMemoryOperation(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryOperation FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryOperation System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryOperation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryOperation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryOperation System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryOperation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryOperation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryOperation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MemoryOperationKind : System.IEquatable<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryOperationKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MemoryOperationKind(string value) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryOperationKind Create { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryOperationKind Delete { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryOperationKind Update { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryOperationKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryOperationKind left, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryOperationKind right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryOperationKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryOperationKind left, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryOperationKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MemorySearchItem : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchItem>
    {
        public MemorySearchItem() { }
        public MemorySearchItem(Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItem memoryItem) { }
        public MemorySearchItem(Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItem memoryItem, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItem MemoryItem { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchItem DeserializeMemorySearchItem(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchItem FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchItem System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class MemorySearchOptions : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchOptions>
    {
        public MemorySearchOptions() { }
        public MemorySearchOptions(int? maxMemories, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public int? MaxMemories { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchOptions DeserializeMemorySearchOptions(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchOptions FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class MemorySearchTool : Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchTool>
    {
        public MemorySearchTool() { }
        public MemorySearchTool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string memoryStoreId, string scope, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchOptions searchOptions, System.TimeSpan? updateDelay) { }
        public MemorySearchTool(string memoryStoreId, string scope) { }
        public string MemoryStoreId { get { throw null; } set { } }
        public string Scope { get { throw null; } set { } }
        public Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchOptions SearchOptions { get { throw null; } set { } }
        public System.TimeSpan? UpdateDelay { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchTool DeserializeMemorySearchTool(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchTool FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchTool System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class MemorySearchToolCallItemParam : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchToolCallItemParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchToolCallItemParam>
    {
        public MemorySearchToolCallItemParam() { }
        public MemorySearchToolCallItemParam(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchItem> results) { }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchItem> Results { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchToolCallItemParam DeserializeMemorySearchToolCallItemParam(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchToolCallItemParam FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchToolCallItemParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchToolCallItemParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchToolCallItemParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchToolCallItemParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchToolCallItemParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchToolCallItemParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchToolCallItemParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class MemorySearchToolCallItemResource : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchToolCallItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchToolCallItemResource>
    {
        public MemorySearchToolCallItemResource() { }
        public MemorySearchToolCallItemResource(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchToolCallItemResourceStatus status, System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchItem> results) { }
        public MemorySearchToolCallItemResource(string id, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchToolCallItemResourceStatus status) { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchItem> Results { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchToolCallItemResourceStatus Status { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchToolCallItemResource DeserializeMemorySearchToolCallItemResource(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchToolCallItemResource FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchToolCallItemResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchToolCallItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchToolCallItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchToolCallItemResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchToolCallItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchToolCallItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchToolCallItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum MemorySearchToolCallItemResourceStatus
    {
        InProgress = 0,
        Searching = 1,
        Completed = 2,
        Incomplete = 3,
        Failed = 4,
    }
    public static partial class MemorySearchToolCallItemResourceStatusExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchToolCallItemResourceStatus ToMemorySearchToolCallItemResourceStatus(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchToolCallItemResourceStatus value) { throw null; }
    }
    public partial class MemoryStoreDefaultDefinition : Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefinition, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefaultDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefaultDefinition>
    {
        public MemoryStoreDefaultDefinition() { }
        public MemoryStoreDefaultDefinition(Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreKind kind, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string chatModel, string embeddingModel, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefaultOptions options) { }
        public MemoryStoreDefaultDefinition(string chatModel, string embeddingModel) { }
        public string ChatModel { get { throw null; } set { } }
        public string EmbeddingModel { get { throw null; } set { } }
        public Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefaultOptions Options { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefaultDefinition DeserializeMemoryStoreDefaultDefinition(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefaultDefinition FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefaultDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefaultDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefaultDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefaultDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefaultDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefaultDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefaultDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class MemoryStoreDefaultOptions : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefaultOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefaultOptions>
    {
        public MemoryStoreDefaultOptions() { }
        public MemoryStoreDefaultOptions(bool userProfileEnabled, bool chatSummaryEnabled) { }
        public MemoryStoreDefaultOptions(bool userProfileEnabled, string userProfileDetails, bool chatSummaryEnabled, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public bool ChatSummaryEnabled { get { throw null; } set { } }
        public string UserProfileDetails { get { throw null; } set { } }
        public bool UserProfileEnabled { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefaultOptions DeserializeMemoryStoreDefaultOptions(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefaultOptions FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefaultOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefaultOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefaultOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefaultOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefaultOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefaultOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefaultOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.ClientModel.Primitives.PersistableModelProxyAttribute(typeof(Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UnknownMemoryStoreDefinition))]
    public abstract partial class MemoryStoreDefinition : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefinition>
    {
        protected MemoryStoreDefinition() { }
        public MemoryStoreDefinition(Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreKind kind, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreKind Kind { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefinition DeserializeMemoryStoreDefinition(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefinition FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class MemoryStoreDeleteScopeResponse : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDeleteScopeResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDeleteScopeResponse>
    {
        public MemoryStoreDeleteScopeResponse() { }
        public MemoryStoreDeleteScopeResponse(Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDeleteScopeResponseObject @object, string name, string scope, bool deleted, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public MemoryStoreDeleteScopeResponse(string name, string scope, bool deleted) { }
        public bool Deleted { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDeleteScopeResponseObject Object { get { throw null; } }
        public string Scope { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDeleteScopeResponse DeserializeMemoryStoreDeleteScopeResponse(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDeleteScopeResponse FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDeleteScopeResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDeleteScopeResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDeleteScopeResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDeleteScopeResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDeleteScopeResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDeleteScopeResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDeleteScopeResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MemoryStoreDeleteScopeResponseObject : System.IEquatable<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDeleteScopeResponseObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MemoryStoreDeleteScopeResponseObject(string value) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDeleteScopeResponseObject MemoryStoreScopeDeleted { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDeleteScopeResponseObject other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDeleteScopeResponseObject left, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDeleteScopeResponseObject right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDeleteScopeResponseObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDeleteScopeResponseObject left, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDeleteScopeResponseObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MemoryStoreKind : System.IEquatable<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreKind>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MemoryStoreKind(string value) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreKind Default { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreKind other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreKind left, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreKind right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreKind (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreKind left, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreKind right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MemoryStoreObject : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreObject>
    {
        public MemoryStoreObject() { }
        public MemoryStoreObject(Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreObjectObject @object, string id, System.DateTimeOffset createdAt, System.DateTimeOffset updatedAt, string name, string description, System.Collections.Generic.IReadOnlyDictionary<string, string> metadata, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefinition definition, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public MemoryStoreObject(string id, System.DateTimeOffset createdAt, System.DateTimeOffset updatedAt, string name, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefinition definition) { }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefinition Definition { get { throw null; } }
        public string Description { get { throw null; } }
        public string Id { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreObjectObject Object { get { throw null; } }
        public System.DateTimeOffset UpdatedAt { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreObject DeserializeMemoryStoreObject(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreObject FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreObject System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MemoryStoreObjectObject : System.IEquatable<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreObjectObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MemoryStoreObjectObject(string value) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreObjectObject MemoryStore { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreObjectObject other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreObjectObject left, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreObjectObject right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreObjectObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreObjectObject left, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreObjectObject right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MemoryStoreOperationUsage : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreOperationUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreOperationUsage>
    {
        public MemoryStoreOperationUsage() { }
        public MemoryStoreOperationUsage(int embeddingTokens, int inputTokens, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageInputTokensDetails inputTokensDetails, int outputTokens, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageOutputTokensDetails outputTokensDetails, int totalTokens) { }
        public MemoryStoreOperationUsage(int embeddingTokens, int inputTokens, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageInputTokensDetails inputTokensDetails, int outputTokens, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageOutputTokensDetails outputTokensDetails, int totalTokens, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public int EmbeddingTokens { get { throw null; } }
        public int InputTokens { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageInputTokensDetails InputTokensDetails { get { throw null; } }
        public int OutputTokens { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageOutputTokensDetails OutputTokensDetails { get { throw null; } }
        public int TotalTokens { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreOperationUsage DeserializeMemoryStoreOperationUsage(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreOperationUsage FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreOperationUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreOperationUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreOperationUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreOperationUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreOperationUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreOperationUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreOperationUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class MemoryStorePagedResult : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStorePagedResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStorePagedResult>
    {
        public MemoryStorePagedResult() { }
        public MemoryStorePagedResult(System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreObject> data, bool hasMore) { }
        public MemoryStorePagedResult(System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreObject> data, string firstId, string lastId, bool hasMore, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreObject> Data { get { throw null; } }
        public string FirstId { get { throw null; } }
        public bool HasMore { get { throw null; } }
        public string LastId { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStorePagedResult DeserializeAgentsPagedResultConversationResource(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStorePagedResult FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStorePagedResult System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStorePagedResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStorePagedResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStorePagedResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStorePagedResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStorePagedResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStorePagedResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class MemoryStoreSearchResponse : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreSearchResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreSearchResponse>
    {
        public MemoryStoreSearchResponse() { }
        public MemoryStoreSearchResponse(string searchId, System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchItem> memories, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreOperationUsage usage) { }
        public MemoryStoreSearchResponse(string searchId, System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchItem> memories, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreOperationUsage usage, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchItem> Memories { get { throw null; } }
        public string SearchId { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreOperationUsage Usage { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreSearchResponse DeserializeMemoryStoreSearchResponse(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreSearchResponse FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreSearchResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreSearchResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreSearchResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreSearchResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreSearchResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreSearchResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreSearchResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class MemoryStoreUpdateResponse : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreUpdateResponse>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreUpdateResponse>
    {
        public MemoryStoreUpdateResponse() { }
        public MemoryStoreUpdateResponse(string updateId, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreUpdateStatus status) { }
        public MemoryStoreUpdateResponse(string updateId, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreUpdateStatus status, string supersededBy, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreUpdateResult result, Azure.AI.AgentServer.Contracts.Generated.Common.ApiError error, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Azure.AI.AgentServer.Contracts.Generated.Common.ApiError Error { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreUpdateResult Result { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreUpdateStatus Status { get { throw null; } }
        public string SupersededBy { get { throw null; } }
        public string UpdateId { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreUpdateResponse DeserializeMemoryStoreUpdateResponse(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreUpdateResponse FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreUpdateResponse System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreUpdateResponse>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreUpdateResponse>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreUpdateResponse System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreUpdateResponse>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreUpdateResponse>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreUpdateResponse>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class MemoryStoreUpdateResult : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreUpdateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreUpdateResult>
    {
        public MemoryStoreUpdateResult() { }
        public MemoryStoreUpdateResult(System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryOperation> memoryOperations, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreOperationUsage usage) { }
        public MemoryStoreUpdateResult(System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryOperation> memoryOperations, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreOperationUsage usage, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryOperation> MemoryOperations { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreOperationUsage Usage { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreUpdateResult DeserializeMemoryStoreUpdateResult(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreUpdateResult FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreUpdateResult System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreUpdateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreUpdateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreUpdateResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreUpdateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreUpdateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreUpdateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum MemoryStoreUpdateStatus
    {
        Queued = 0,
        InProgress = 1,
        Completed = 2,
        Failed = 3,
        Superseded = 4,
    }
    public static partial class MemoryStoreUpdateStatusExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreUpdateStatus ToMemoryStoreUpdateStatus(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreUpdateStatus value) { throw null; }
    }
    public partial class SearchMemoriesRequest : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.SearchMemoriesRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.SearchMemoriesRequest>
    {
        public SearchMemoriesRequest() { }
        public SearchMemoriesRequest(string scope) { }
        public SearchMemoriesRequest(string scope, string conversationId, System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam> items, string previousSearchId, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchOptions options, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public string ConversationId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam> Items { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemorySearchOptions Options { get { throw null; } }
        public string PreviousSearchId { get { throw null; } }
        public string Scope { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.SearchMemoriesRequest DeserializeSearchMemoriesRequest(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.SearchMemoriesRequest FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.SearchMemoriesRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.SearchMemoriesRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.SearchMemoriesRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.SearchMemoriesRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.SearchMemoriesRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.SearchMemoriesRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.SearchMemoriesRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class UnknownMemoryItem : Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItem, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItem>
    {
        public UnknownMemoryItem() { }
        public UnknownMemoryItem(string memoryId, System.DateTimeOffset updatedAt, string scope, string content, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItemKind kind, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UnknownMemoryItem DeserializeUnknownMemoryItem(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UnknownMemoryItem FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItem System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class UnknownMemoryStoreDefinition : Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefinition, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefinition>
    {
        public UnknownMemoryStoreDefinition() { }
        public UnknownMemoryStoreDefinition(Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreKind kind, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UnknownMemoryStoreDefinition DeserializeUnknownMemoryStoreDefinition(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UnknownMemoryStoreDefinition FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryStoreDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class UpdateMemoriesRequest : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UpdateMemoriesRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UpdateMemoriesRequest>
    {
        public UpdateMemoriesRequest() { }
        public UpdateMemoriesRequest(string scope) { }
        public UpdateMemoriesRequest(string scope, string conversationId, System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam> items, string previousUpdateId, int? updateDelay, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public string ConversationId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam> Items { get { throw null; } }
        public string PreviousUpdateId { get { throw null; } }
        public string Scope { get { throw null; } }
        public int? UpdateDelay { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UpdateMemoriesRequest DeserializeUpdateMemoriesRequest(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UpdateMemoriesRequest FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UpdateMemoriesRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UpdateMemoriesRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UpdateMemoriesRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UpdateMemoriesRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UpdateMemoriesRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UpdateMemoriesRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UpdateMemoriesRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class UpdateMemoryStoreRequest : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UpdateMemoryStoreRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UpdateMemoryStoreRequest>
    {
        public UpdateMemoryStoreRequest() { }
        public UpdateMemoryStoreRequest(string description, System.Collections.Generic.IDictionary<string, string> metadata, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Metadata { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UpdateMemoryStoreRequest DeserializeUpdateMemoryStoreRequest(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UpdateMemoryStoreRequest FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UpdateMemoryStoreRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UpdateMemoryStoreRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UpdateMemoryStoreRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UpdateMemoryStoreRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UpdateMemoryStoreRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UpdateMemoryStoreRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UpdateMemoryStoreRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class UserProfileMemoryItem : Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItem, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UserProfileMemoryItem>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UserProfileMemoryItem>
    {
        public UserProfileMemoryItem() { }
        public UserProfileMemoryItem(string memoryId, System.DateTimeOffset updatedAt, string scope, string content) { }
        public UserProfileMemoryItem(string memoryId, System.DateTimeOffset updatedAt, string scope, string content, Azure.AI.AgentServer.Contracts.Generated.MemoryStore.MemoryItemKind kind, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UserProfileMemoryItem DeserializeUserProfileMemoryItem(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UserProfileMemoryItem FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UserProfileMemoryItem System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UserProfileMemoryItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UserProfileMemoryItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UserProfileMemoryItem System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UserProfileMemoryItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UserProfileMemoryItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.MemoryStore.UserProfileMemoryItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
}
namespace Azure.AI.AgentServer.Contracts.Generated.OpenAI
{
    public partial class A2ATool : Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.A2ATool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.A2ATool>
    {
        public A2ATool() { }
        public A2ATool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, System.Uri baseUrl, string agentCardPath, string projectConnectionId) { }
        public string AgentCardPath { get { throw null; } set { } }
        public System.Uri BaseUrl { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.A2ATool DeserializeA2ATool(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.A2ATool FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.A2ATool System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.A2ATool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.A2ATool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.A2ATool System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.A2ATool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.A2ATool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.A2ATool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class AISearchIndexResource : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AISearchIndexResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AISearchIndexResource>
    {
        public AISearchIndexResource() { }
        public AISearchIndexResource(string projectConnectionId) { }
        public AISearchIndexResource(string projectConnectionId, string indexName, Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchQueryType? queryType, int? topK, string filter, string indexAssetId, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public string Filter { get { throw null; } set { } }
        public string IndexAssetId { get { throw null; } set { } }
        public string IndexName { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchQueryType? QueryType { get { throw null; } set { } }
        public int? TopK { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.AISearchIndexResource DeserializeAISearchIndexResource(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.AISearchIndexResource FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.AISearchIndexResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AISearchIndexResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AISearchIndexResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.AISearchIndexResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AISearchIndexResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AISearchIndexResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AISearchIndexResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.ClientModel.Primitives.PersistableModelProxyAttribute(typeof(Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownAnnotation))]
    public abstract partial class Annotation : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Annotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Annotation>
    {
        protected Annotation() { }
        public Annotation(Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationType Type { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.Annotation DeserializeAnnotation(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.Annotation FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.Annotation System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Annotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Annotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.Annotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Annotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Annotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Annotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class AnnotationFileCitation : Azure.AI.AgentServer.Contracts.Generated.OpenAI.Annotation, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationFileCitation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationFileCitation>
    {
        public AnnotationFileCitation() { }
        public AnnotationFileCitation(Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string fileId, int index, string filename) { }
        public AnnotationFileCitation(string fileId, int index, string filename) { }
        public string FileId { get { throw null; } set { } }
        public string Filename { get { throw null; } set { } }
        public int Index { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationFileCitation DeserializeAnnotationFileCitation(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationFileCitation FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationFileCitation System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationFileCitation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationFileCitation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationFileCitation System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationFileCitation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationFileCitation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationFileCitation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class AnnotationFilePath : Azure.AI.AgentServer.Contracts.Generated.OpenAI.Annotation, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationFilePath>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationFilePath>
    {
        public AnnotationFilePath() { }
        public AnnotationFilePath(Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string fileId, int index) { }
        public AnnotationFilePath(string fileId, int index) { }
        public string FileId { get { throw null; } set { } }
        public int Index { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationFilePath DeserializeAnnotationFilePath(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationFilePath FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationFilePath System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationFilePath>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationFilePath>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationFilePath System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationFilePath>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationFilePath>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationFilePath>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AnnotationType : System.IEquatable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AnnotationType(string value) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationType ContainerFileCitation { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationType FileCitation { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationType FilePath { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationType UrlCitation { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationType left, Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationType right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationType (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationType left, Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AnnotationUrlCitation : Azure.AI.AgentServer.Contracts.Generated.OpenAI.Annotation, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationUrlCitation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationUrlCitation>
    {
        public AnnotationUrlCitation() { }
        public AnnotationUrlCitation(Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, System.Uri url, int startIndex, int endIndex, string title) { }
        public AnnotationUrlCitation(System.Uri url, int startIndex, int endIndex, string title) { }
        public int EndIndex { get { throw null; } set { } }
        public int StartIndex { get { throw null; } set { } }
        public string Title { get { throw null; } set { } }
        public System.Uri Url { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationUrlCitation DeserializeAnnotationUrlCitation(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationUrlCitation FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationUrlCitation System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationUrlCitation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationUrlCitation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationUrlCitation System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationUrlCitation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationUrlCitation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationUrlCitation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ApproximateLocation : Azure.AI.AgentServer.Contracts.Generated.OpenAI.Location, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ApproximateLocation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ApproximateLocation>
    {
        public ApproximateLocation() { }
        public ApproximateLocation(Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocationType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string country, string region, string city, string timezone) { }
        public string City { get { throw null; } set { } }
        public string Country { get { throw null; } set { } }
        public string Region { get { throw null; } set { } }
        public string Timezone { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ApproximateLocation DeserializeApproximateLocation(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ApproximateLocation FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ApproximateLocation System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ApproximateLocation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ApproximateLocation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ApproximateLocation System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ApproximateLocation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ApproximateLocation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ApproximateLocation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class AzureAISearchAgentTool : Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchAgentTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchAgentTool>
    {
        public AzureAISearchAgentTool() { }
        public AzureAISearchAgentTool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchToolResource azureAiSearch) { }
        public AzureAISearchAgentTool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchToolResource azureAiSearch) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchToolResource AzureAiSearch { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchAgentTool DeserializeAzureAISearchAgentTool(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchAgentTool FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchAgentTool System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchAgentTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchAgentTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchAgentTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchAgentTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchAgentTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchAgentTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureAISearchQueryType : System.IEquatable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchQueryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureAISearchQueryType(string value) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchQueryType Semantic { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchQueryType Simple { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchQueryType Vector { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchQueryType VectorSemanticHybrid { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchQueryType VectorSimpleHybrid { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchQueryType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchQueryType left, Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchQueryType right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchQueryType (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchQueryType left, Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchQueryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureAISearchToolResource : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchToolResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchToolResource>
    {
        public AzureAISearchToolResource() { }
        public AzureAISearchToolResource(System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AISearchIndexResource> indexList, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AISearchIndexResource> IndexList { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchToolResource DeserializeAzureAISearchToolResource(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchToolResource FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchToolResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchToolResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchToolResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchToolResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchToolResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchToolResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureAISearchToolResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class AzureFunctionAgentTool : Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionAgentTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionAgentTool>
    {
        public AzureFunctionAgentTool() { }
        public AzureFunctionAgentTool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionDefinition azureFunction) { }
        public AzureFunctionAgentTool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionDefinition azureFunction) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionDefinition AzureFunction { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionAgentTool DeserializeAzureFunctionAgentTool(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionAgentTool FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionAgentTool System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionAgentTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionAgentTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionAgentTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionAgentTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionAgentTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionAgentTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class AzureFunctionBinding : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionBinding>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionBinding>
    {
        public AzureFunctionBinding() { }
        public AzureFunctionBinding(Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionBindingType type, Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionStorageQueue storageQueue, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public AzureFunctionBinding(Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionStorageQueue storageQueue) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionStorageQueue StorageQueue { get { throw null; } set { } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionBindingType Type { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionBinding DeserializeAzureFunctionBinding(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionBinding FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionBinding System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionBinding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionBinding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionBinding System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionBinding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionBinding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionBinding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AzureFunctionBindingType : System.IEquatable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionBindingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AzureFunctionBindingType(string value) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionBindingType StorageQueue { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionBindingType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionBindingType left, Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionBindingType right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionBindingType (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionBindingType left, Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionBindingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AzureFunctionDefinition : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionDefinition>
    {
        public AzureFunctionDefinition() { }
        public AzureFunctionDefinition(Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionDefinitionFunction function, Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionBinding inputBinding, Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionBinding outputBinding) { }
        public AzureFunctionDefinition(Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionDefinitionFunction function, Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionBinding inputBinding, Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionBinding outputBinding, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionDefinitionFunction Function { get { throw null; } set { } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionBinding InputBinding { get { throw null; } set { } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionBinding OutputBinding { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionDefinition DeserializeAzureFunctionDefinition(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionDefinition FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class AzureFunctionDefinitionFunction : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionDefinitionFunction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionDefinitionFunction>
    {
        public AzureFunctionDefinitionFunction() { }
        public AzureFunctionDefinitionFunction(string name, System.BinaryData parameters) { }
        public AzureFunctionDefinitionFunction(string name, string description, System.BinaryData parameters, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Parameters { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionDefinitionFunction DeserializeAzureFunctionDefinitionFunction(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionDefinitionFunction FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionDefinitionFunction System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionDefinitionFunction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionDefinitionFunction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionDefinitionFunction System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionDefinitionFunction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionDefinitionFunction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionDefinitionFunction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class AzureFunctionStorageQueue : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionStorageQueue>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionStorageQueue>
    {
        public AzureFunctionStorageQueue() { }
        public AzureFunctionStorageQueue(string queueServiceEndpoint, string queueName) { }
        public AzureFunctionStorageQueue(string queueServiceEndpoint, string queueName, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public string QueueName { get { throw null; } set { } }
        public string QueueServiceEndpoint { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionStorageQueue DeserializeAzureFunctionStorageQueue(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionStorageQueue FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionStorageQueue System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionStorageQueue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionStorageQueue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionStorageQueue System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionStorageQueue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionStorageQueue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.AzureFunctionStorageQueue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class BingCustomSearchAgentTool : Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchAgentTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchAgentTool>
    {
        public BingCustomSearchAgentTool() { }
        public BingCustomSearchAgentTool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchToolParameters bingCustomSearchPreview) { }
        public BingCustomSearchAgentTool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchToolParameters bingCustomSearchPreview) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchToolParameters BingCustomSearchPreview { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchAgentTool DeserializeBingCustomSearchAgentTool(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchAgentTool FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchAgentTool System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchAgentTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchAgentTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchAgentTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchAgentTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchAgentTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchAgentTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class BingCustomSearchConfiguration : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchConfiguration>
    {
        public BingCustomSearchConfiguration() { }
        public BingCustomSearchConfiguration(string projectConnectionId, string instanceName) { }
        public BingCustomSearchConfiguration(string projectConnectionId, string instanceName, string market, string setLang, long? count, string freshness, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public long? Count { get { throw null; } set { } }
        public string Freshness { get { throw null; } set { } }
        public string InstanceName { get { throw null; } set { } }
        public string Market { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public string SetLang { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchConfiguration DeserializeBingCustomSearchConfiguration(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchConfiguration FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class BingCustomSearchToolParameters : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchToolParameters>
    {
        public BingCustomSearchToolParameters() { }
        public BingCustomSearchToolParameters(System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchConfiguration> searchConfigurations) { }
        public BingCustomSearchToolParameters(System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchConfiguration> searchConfigurations, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchConfiguration> SearchConfigurations { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchToolParameters DeserializeBingCustomSearchToolParameters(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchToolParameters FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchToolParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchToolParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchToolParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchToolParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchToolParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchToolParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingCustomSearchToolParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class BingGroundingAgentTool : Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingAgentTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingAgentTool>
    {
        public BingGroundingAgentTool() { }
        public BingGroundingAgentTool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingSearchToolParameters bingGrounding) { }
        public BingGroundingAgentTool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingSearchToolParameters bingGrounding) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingSearchToolParameters BingGrounding { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingAgentTool DeserializeBingGroundingAgentTool(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingAgentTool FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingAgentTool System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingAgentTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingAgentTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingAgentTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingAgentTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingAgentTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingAgentTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class BingGroundingSearchConfiguration : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingSearchConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingSearchConfiguration>
    {
        public BingGroundingSearchConfiguration() { }
        public BingGroundingSearchConfiguration(string projectConnectionId) { }
        public BingGroundingSearchConfiguration(string projectConnectionId, string market, string setLang, long? count, string freshness, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public long? Count { get { throw null; } set { } }
        public string Freshness { get { throw null; } set { } }
        public string Market { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public string SetLang { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingSearchConfiguration DeserializeBingGroundingSearchConfiguration(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingSearchConfiguration FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingSearchConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingSearchConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingSearchConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingSearchConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingSearchConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingSearchConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingSearchConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class BingGroundingSearchToolParameters : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingSearchToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingSearchToolParameters>
    {
        public BingGroundingSearchToolParameters() { }
        public BingGroundingSearchToolParameters(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnectionList projectConnections, System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingSearchConfiguration> searchConfigurations) { }
        public BingGroundingSearchToolParameters(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnectionList projectConnections, System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingSearchConfiguration> searchConfigurations, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnectionList ProjectConnections { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingSearchConfiguration> SearchConfigurations { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingSearchToolParameters DeserializeBingGroundingSearchToolParameters(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingSearchToolParameters FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingSearchToolParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingSearchToolParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingSearchToolParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingSearchToolParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingSearchToolParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingSearchToolParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BingGroundingSearchToolParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class BrowserAutomationAgentTool : Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationAgentTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationAgentTool>
    {
        public BrowserAutomationAgentTool() { }
        public BrowserAutomationAgentTool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationToolParameters browserAutomationPreview) { }
        public BrowserAutomationAgentTool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationToolParameters browserAutomationPreview) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationToolParameters BrowserAutomationPreview { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationAgentTool DeserializeBrowserAutomationAgentTool(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationAgentTool FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationAgentTool System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationAgentTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationAgentTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationAgentTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationAgentTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationAgentTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationAgentTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class BrowserAutomationToolConnectionParameters : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationToolConnectionParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationToolConnectionParameters>
    {
        public BrowserAutomationToolConnectionParameters() { }
        public BrowserAutomationToolConnectionParameters(string id) { }
        public BrowserAutomationToolConnectionParameters(string id, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public string Id { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationToolConnectionParameters DeserializeBrowserAutomationToolConnectionParameters(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationToolConnectionParameters FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationToolConnectionParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationToolConnectionParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationToolConnectionParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationToolConnectionParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationToolConnectionParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationToolConnectionParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationToolConnectionParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class BrowserAutomationToolParameters : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationToolParameters>
    {
        public BrowserAutomationToolParameters() { }
        public BrowserAutomationToolParameters(Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationToolConnectionParameters projectConnection) { }
        public BrowserAutomationToolParameters(Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationToolConnectionParameters projectConnection, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationToolConnectionParameters ProjectConnection { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationToolParameters DeserializeBrowserAutomationToolParameters(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationToolParameters FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationToolParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationToolParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationToolParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationToolParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationToolParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationToolParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.BrowserAutomationToolParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class CaptureStructuredOutputsTool : Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CaptureStructuredOutputsTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CaptureStructuredOutputsTool>
    {
        public CaptureStructuredOutputsTool() { }
        public CaptureStructuredOutputsTool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredOutputDefinition outputs) { }
        public CaptureStructuredOutputsTool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredOutputDefinition outputs) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredOutputDefinition Outputs { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.CaptureStructuredOutputsTool DeserializeCaptureStructuredOutputsTool(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.CaptureStructuredOutputsTool FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.CaptureStructuredOutputsTool System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CaptureStructuredOutputsTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CaptureStructuredOutputsTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.CaptureStructuredOutputsTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CaptureStructuredOutputsTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CaptureStructuredOutputsTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CaptureStructuredOutputsTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.ClientModel.Primitives.PersistableModelProxyAttribute(typeof(Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownCodeInterpreterOutput))]
    public abstract partial class CodeInterpreterOutput : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutput>
    {
        protected CodeInterpreterOutput() { }
        public CodeInterpreterOutput(Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutputType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutputType Type { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutput DeserializeCodeInterpreterOutput(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutput FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class CodeInterpreterOutputImage : Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutput, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutputImage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutputImage>
    {
        public CodeInterpreterOutputImage() { }
        public CodeInterpreterOutputImage(Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutputType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, System.Uri url) { }
        public CodeInterpreterOutputImage(System.Uri url) { }
        public System.Uri Url { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutputImage DeserializeCodeInterpreterOutputImage(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutputImage FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutputImage System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutputImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutputImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutputImage System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutputImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutputImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutputImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class CodeInterpreterOutputLogs : Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutput, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutputLogs>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutputLogs>
    {
        public CodeInterpreterOutputLogs() { }
        public CodeInterpreterOutputLogs(Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutputType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string logs) { }
        public CodeInterpreterOutputLogs(string logs) { }
        public string Logs { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutputLogs DeserializeCodeInterpreterOutputLogs(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutputLogs FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutputLogs System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutputLogs>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutputLogs>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutputLogs System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutputLogs>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutputLogs>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutputLogs>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum CodeInterpreterOutputType
    {
        Logs = 0,
        Image = 1,
    }
    public static partial class CodeInterpreterOutputTypeExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutputType ToCodeInterpreterOutputType(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutputType value) { throw null; }
    }
    public partial class CodeInterpreterTool : Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterTool>
    {
        public CodeInterpreterTool() { }
        public CodeInterpreterTool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, System.BinaryData container) { }
        public CodeInterpreterTool(System.BinaryData container) { }
        public System.BinaryData Container { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterTool DeserializeCodeInterpreterTool(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterTool FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterTool System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class CodeInterpreterToolAuto : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolAuto>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolAuto>
    {
        public CodeInterpreterToolAuto() { }
        public CodeInterpreterToolAuto(Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolAutoType type, System.Collections.Generic.IList<string> fileIds, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public System.Collections.Generic.IList<string> FileIds { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolAutoType Type { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolAuto DeserializeCodeInterpreterToolAuto(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolAuto FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolAuto System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolAuto>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolAuto>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolAuto System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolAuto>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolAuto>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolAuto>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CodeInterpreterToolAutoType : System.IEquatable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolAutoType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CodeInterpreterToolAutoType(string value) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolAutoType Auto { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolAutoType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolAutoType left, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolAutoType right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolAutoType (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolAutoType left, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolAutoType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CodeInterpreterToolCallItemParam : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolCallItemParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolCallItemParam>
    {
        public CodeInterpreterToolCallItemParam() { }
        public CodeInterpreterToolCallItemParam(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string containerId, string code, System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutput> outputs) { }
        public CodeInterpreterToolCallItemParam(string containerId, string code, System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutput> outputs) { }
        public string Code { get { throw null; } set { } }
        public string ContainerId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutput> Outputs { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolCallItemParam DeserializeCodeInterpreterToolCallItemParam(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolCallItemParam FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolCallItemParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolCallItemParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolCallItemParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolCallItemParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolCallItemParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolCallItemParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolCallItemParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class CodeInterpreterToolCallItemResource : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolCallItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolCallItemResource>
    {
        public CodeInterpreterToolCallItemResource() { }
        public CodeInterpreterToolCallItemResource(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolCallItemResourceStatus status, string containerId, string code, System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutput> outputs) { }
        public CodeInterpreterToolCallItemResource(string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolCallItemResourceStatus status, string containerId, string code, System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutput> outputs) { }
        public string Code { get { throw null; } }
        public string ContainerId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutput> Outputs { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolCallItemResourceStatus Status { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolCallItemResource DeserializeCodeInterpreterToolCallItemResource(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolCallItemResource FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolCallItemResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolCallItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolCallItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolCallItemResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolCallItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolCallItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolCallItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum CodeInterpreterToolCallItemResourceStatus
    {
        InProgress = 0,
        Completed = 1,
        Incomplete = 2,
        Interpreting = 3,
        Failed = 4,
    }
    public static partial class CodeInterpreterToolCallItemResourceStatusExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolCallItemResourceStatus ToCodeInterpreterToolCallItemResourceStatus(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterToolCallItemResourceStatus value) { throw null; }
    }
    public partial class ComparisonFilter : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComparisonFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComparisonFilter>
    {
        public ComparisonFilter() { }
        public ComparisonFilter(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComparisonFilterType type, string key, System.BinaryData value) { }
        public ComparisonFilter(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComparisonFilterType type, string key, System.BinaryData value, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public string Key { get { throw null; } set { } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComparisonFilterType Type { get { throw null; } set { } }
        public System.BinaryData Value { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComparisonFilter DeserializeComparisonFilter(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComparisonFilter FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComparisonFilter System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComparisonFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComparisonFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComparisonFilter System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComparisonFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComparisonFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComparisonFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum ComparisonFilterType
    {
        Eq = 0,
        Ne = 1,
        Gt = 2,
        Gte = 3,
        Lt = 4,
        Lte = 5,
    }
    public static partial class ComparisonFilterTypeExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComparisonFilterType ToComparisonFilterType(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComparisonFilterType value) { throw null; }
    }
    public partial class CompoundFilter : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CompoundFilter>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CompoundFilter>
    {
        public CompoundFilter() { }
        public CompoundFilter(Azure.AI.AgentServer.Contracts.Generated.OpenAI.CompoundFilterType type, System.Collections.Generic.IEnumerable<System.BinaryData> filters) { }
        public CompoundFilter(Azure.AI.AgentServer.Contracts.Generated.OpenAI.CompoundFilterType type, System.Collections.Generic.IList<System.BinaryData> filters, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public System.Collections.Generic.IList<System.BinaryData> Filters { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.CompoundFilterType Type { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.CompoundFilter DeserializeCompoundFilter(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.CompoundFilter FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.CompoundFilter System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CompoundFilter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CompoundFilter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.CompoundFilter System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CompoundFilter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CompoundFilter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CompoundFilter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum CompoundFilterType
    {
        And = 0,
        Or = 1,
    }
    public static partial class CompoundFilterTypeExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.CompoundFilterType ToCompoundFilterType(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.CompoundFilterType value) { throw null; }
    }
    [System.ClientModel.Primitives.PersistableModelProxyAttribute(typeof(Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownComputerAction))]
    public abstract partial class ComputerAction : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction>
    {
        protected ComputerAction() { }
        public ComputerAction(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionType Type { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction DeserializeComputerAction(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ComputerActionClick : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionClick>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionClick>
    {
        public ComputerActionClick() { }
        public ComputerActionClick(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionClickButton button, int x, int y) { }
        public ComputerActionClick(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionClickButton button, int x, int y) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionClickButton Button { get { throw null; } set { } }
        public int X { get { throw null; } set { } }
        public int Y { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionClick DeserializeComputerActionClick(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionClick FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionClick System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionClick>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionClick>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionClick System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionClick>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionClick>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionClick>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum ComputerActionClickButton
    {
        Left = 0,
        Right = 1,
        Wheel = 2,
        Back = 3,
        Forward = 4,
    }
    public static partial class ComputerActionClickButtonExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionClickButton ToComputerActionClickButton(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionClickButton value) { throw null; }
    }
    public partial class ComputerActionDoubleClick : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionDoubleClick>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionDoubleClick>
    {
        public ComputerActionDoubleClick() { }
        public ComputerActionDoubleClick(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, int x, int y) { }
        public ComputerActionDoubleClick(int x, int y) { }
        public int X { get { throw null; } set { } }
        public int Y { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionDoubleClick DeserializeComputerActionDoubleClick(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionDoubleClick FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionDoubleClick System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionDoubleClick>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionDoubleClick>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionDoubleClick System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionDoubleClick>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionDoubleClick>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionDoubleClick>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ComputerActionDrag : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionDrag>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionDrag>
    {
        public ComputerActionDrag() { }
        public ComputerActionDrag(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Coordinate> path) { }
        public ComputerActionDrag(System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Coordinate> path) { }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Coordinate> Path { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionDrag DeserializeComputerActionDrag(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionDrag FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionDrag System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionDrag>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionDrag>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionDrag System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionDrag>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionDrag>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionDrag>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ComputerActionKeyPress : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionKeyPress>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionKeyPress>
    {
        public ComputerActionKeyPress() { }
        public ComputerActionKeyPress(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, System.Collections.Generic.IList<string> keys) { }
        public ComputerActionKeyPress(System.Collections.Generic.IEnumerable<string> keys) { }
        public System.Collections.Generic.IList<string> Keys { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionKeyPress DeserializeComputerActionKeyPress(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionKeyPress FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionKeyPress System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionKeyPress>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionKeyPress>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionKeyPress System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionKeyPress>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionKeyPress>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionKeyPress>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ComputerActionMove : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionMove>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionMove>
    {
        public ComputerActionMove() { }
        public ComputerActionMove(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, int x, int y) { }
        public ComputerActionMove(int x, int y) { }
        public int X { get { throw null; } set { } }
        public int Y { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionMove DeserializeComputerActionMove(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionMove FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionMove System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionMove>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionMove>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionMove System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionMove>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionMove>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionMove>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ComputerActionScreenshot : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionScreenshot>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionScreenshot>
    {
        public ComputerActionScreenshot() { }
        public ComputerActionScreenshot(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionScreenshot DeserializeComputerActionScreenshot(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionScreenshot FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionScreenshot System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionScreenshot>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionScreenshot>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionScreenshot System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionScreenshot>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionScreenshot>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionScreenshot>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ComputerActionScroll : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionScroll>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionScroll>
    {
        public ComputerActionScroll() { }
        public ComputerActionScroll(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, int x, int y, int scrollX, int scrollY) { }
        public ComputerActionScroll(int x, int y, int scrollX, int scrollY) { }
        public int ScrollX { get { throw null; } set { } }
        public int ScrollY { get { throw null; } set { } }
        public int X { get { throw null; } set { } }
        public int Y { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionScroll DeserializeComputerActionScroll(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionScroll FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionScroll System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionScroll>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionScroll>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionScroll System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionScroll>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionScroll>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionScroll>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum ComputerActionType
    {
        Screenshot = 0,
        Click = 1,
        DoubleClick = 2,
        Scroll = 3,
        Type = 4,
        Wait = 5,
        Keypress = 6,
        Drag = 7,
        Move = 8,
    }
    public static partial class ComputerActionTypeExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionType ToComputerActionType(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionType value) { throw null; }
    }
    public partial class ComputerActionTypeKeys : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionTypeKeys>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionTypeKeys>
    {
        public ComputerActionTypeKeys() { }
        public ComputerActionTypeKeys(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string text) { }
        public ComputerActionTypeKeys(string text) { }
        public string Text { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionTypeKeys DeserializeComputerActionTypeKeys(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionTypeKeys FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionTypeKeys System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionTypeKeys>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionTypeKeys>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionTypeKeys System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionTypeKeys>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionTypeKeys>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionTypeKeys>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ComputerActionWait : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionWait>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionWait>
    {
        public ComputerActionWait() { }
        public ComputerActionWait(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionWait DeserializeComputerActionWait(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionWait FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionWait System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionWait>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionWait>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionWait System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionWait>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionWait>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionWait>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ComputerToolCallItemParam : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallItemParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallItemParam>
    {
        public ComputerToolCallItemParam() { }
        public ComputerToolCallItemParam(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string callId, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction action, System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallSafetyCheck> pendingSafetyChecks) { }
        public ComputerToolCallItemParam(string callId, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction action, System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallSafetyCheck> pendingSafetyChecks) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction Action { get { throw null; } set { } }
        public string CallId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallSafetyCheck> PendingSafetyChecks { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallItemParam DeserializeComputerToolCallItemParam(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallItemParam FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallItemParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallItemParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallItemParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallItemParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallItemParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallItemParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallItemParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ComputerToolCallItemResource : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallItemResource>
    {
        public ComputerToolCallItemResource() { }
        public ComputerToolCallItemResource(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallItemResourceStatus status, string callId, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction action, System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallSafetyCheck> pendingSafetyChecks) { }
        public ComputerToolCallItemResource(string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallItemResourceStatus status, string callId, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction action, System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallSafetyCheck> pendingSafetyChecks) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction Action { get { throw null; } }
        public string CallId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallSafetyCheck> PendingSafetyChecks { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallItemResourceStatus Status { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallItemResource DeserializeComputerToolCallItemResource(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallItemResource FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallItemResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallItemResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum ComputerToolCallItemResourceStatus
    {
        InProgress = 0,
        Completed = 1,
        Incomplete = 2,
    }
    public static partial class ComputerToolCallItemResourceStatusExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallItemResourceStatus ToComputerToolCallItemResourceStatus(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallItemResourceStatus value) { throw null; }
    }
    [System.ClientModel.Primitives.PersistableModelProxyAttribute(typeof(Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownComputerToolCallOutputItemOutput))]
    public abstract partial class ComputerToolCallOutputItemOutput : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutput>
    {
        protected ComputerToolCallOutputItemOutput() { }
        public ComputerToolCallOutputItemOutput(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutputType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutputType Type { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutput DeserializeComputerToolCallOutputItemOutput(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutput FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ComputerToolCallOutputItemOutputComputerScreenshot : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutput, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutputComputerScreenshot>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutputComputerScreenshot>
    {
        public ComputerToolCallOutputItemOutputComputerScreenshot() { }
        public ComputerToolCallOutputItemOutputComputerScreenshot(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutputType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string imageUrl, string fileId) { }
        public string FileId { get { throw null; } set { } }
        public string ImageUrl { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutputComputerScreenshot DeserializeComputerToolCallOutputItemOutputComputerScreenshot(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutputComputerScreenshot FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutputComputerScreenshot System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutputComputerScreenshot>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutputComputerScreenshot>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutputComputerScreenshot System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutputComputerScreenshot>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutputComputerScreenshot>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutputComputerScreenshot>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputerToolCallOutputItemOutputType : System.IEquatable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutputType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputerToolCallOutputItemOutputType(string value) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutputType Screenshot { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutputType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutputType left, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutputType right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutputType (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutputType left, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutputType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComputerToolCallOutputItemParam : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemParam>
    {
        public ComputerToolCallOutputItemParam() { }
        public ComputerToolCallOutputItemParam(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string callId, System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallSafetyCheck> acknowledgedSafetyChecks, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutput output) { }
        public ComputerToolCallOutputItemParam(string callId, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutput output) { }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallSafetyCheck> AcknowledgedSafetyChecks { get { throw null; } }
        public string CallId { get { throw null; } set { } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutput Output { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemParam DeserializeComputerToolCallOutputItemParam(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemParam FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ComputerToolCallOutputItemResource : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemResource>
    {
        public ComputerToolCallOutputItemResource() { }
        public ComputerToolCallOutputItemResource(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemResourceStatus status, string callId, System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallSafetyCheck> acknowledgedSafetyChecks, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutput output) { }
        public ComputerToolCallOutputItemResource(string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemResourceStatus status, string callId, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutput output) { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallSafetyCheck> AcknowledgedSafetyChecks { get { throw null; } }
        public string CallId { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutput Output { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemResourceStatus Status { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemResource DeserializeComputerToolCallOutputItemResource(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemResource FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum ComputerToolCallOutputItemResourceStatus
    {
        InProgress = 0,
        Completed = 1,
        Incomplete = 2,
    }
    public static partial class ComputerToolCallOutputItemResourceStatusExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemResourceStatus ToComputerToolCallOutputItemResourceStatus(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemResourceStatus value) { throw null; }
    }
    public partial class ComputerToolCallSafetyCheck : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallSafetyCheck>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallSafetyCheck>
    {
        public ComputerToolCallSafetyCheck() { }
        public ComputerToolCallSafetyCheck(string id, string code, string message) { }
        public ComputerToolCallSafetyCheck(string id, string code, string message, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public string Code { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallSafetyCheck DeserializeComputerToolCallSafetyCheck(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallSafetyCheck FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallSafetyCheck System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallSafetyCheck>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallSafetyCheck>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallSafetyCheck System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallSafetyCheck>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallSafetyCheck>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallSafetyCheck>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ComputerUsePreviewTool : Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerUsePreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerUsePreviewTool>
    {
        public ComputerUsePreviewTool() { }
        public ComputerUsePreviewTool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerUsePreviewToolEnvironment environment, int displayWidth, int displayHeight) { }
        public ComputerUsePreviewTool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerUsePreviewToolEnvironment environment, int displayWidth, int displayHeight) { }
        public int DisplayHeight { get { throw null; } set { } }
        public int DisplayWidth { get { throw null; } set { } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerUsePreviewToolEnvironment Environment { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerUsePreviewTool DeserializeComputerUsePreviewTool(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerUsePreviewTool FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerUsePreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerUsePreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerUsePreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerUsePreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerUsePreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerUsePreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerUsePreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum ComputerUsePreviewToolEnvironment
    {
        Windows = 0,
        Mac = 1,
        Linux = 2,
        Ubuntu = 3,
        Browser = 4,
    }
    public static partial class ComputerUsePreviewToolEnvironmentExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerUsePreviewToolEnvironment ToComputerUsePreviewToolEnvironment(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerUsePreviewToolEnvironment value) { throw null; }
    }
    public partial class Coordinate : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Coordinate>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Coordinate>
    {
        public Coordinate() { }
        public Coordinate(int x, int y) { }
        public Coordinate(int x, int y, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public int X { get { throw null; } set { } }
        public int Y { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.Coordinate DeserializeCoordinate(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.Coordinate FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.Coordinate System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Coordinate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Coordinate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.Coordinate System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Coordinate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Coordinate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Coordinate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class CreatedBy : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy>
    {
        public CreatedBy() { }
        public CreatedBy(Azure.AI.AgentServer.Contracts.Generated.Agents.AgentId agent, string responseId, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Azure.AI.AgentServer.Contracts.Generated.Agents.AgentId Agent { get { throw null; } }
        public string ResponseId { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy DeserializeCreatedBy(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class DeleteScopeRequest : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.DeleteScopeRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.DeleteScopeRequest>
    {
        public DeleteScopeRequest() { }
        public DeleteScopeRequest(string scope) { }
        public DeleteScopeRequest(string scope, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public string Scope { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.DeleteScopeRequest DeserializeDeleteScopeRequest(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.DeleteScopeRequest FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.DeleteScopeRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.DeleteScopeRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.DeleteScopeRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.DeleteScopeRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.DeleteScopeRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.DeleteScopeRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.DeleteScopeRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class EasyInputMessage : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.EasyInputMessage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.EasyInputMessage>
    {
        public EasyInputMessage() { }
        public EasyInputMessage(string role, System.BinaryData content) { }
        public EasyInputMessage(string role, System.BinaryData content, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public System.BinaryData Content { get { throw null; } }
        public string Role { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.EasyInputMessage DeserializeEasyInputMessage(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.EasyInputMessage FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.EasyInputMessage System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.EasyInputMessage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.EasyInputMessage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.EasyInputMessage System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.EasyInputMessage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.EasyInputMessage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.EasyInputMessage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class FabricDataAgentToolParameters : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FabricDataAgentToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FabricDataAgentToolParameters>
    {
        public FabricDataAgentToolParameters() { }
        public FabricDataAgentToolParameters(System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnection> projectConnections, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnection> ProjectConnections { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.FabricDataAgentToolParameters DeserializeFabricDataAgentToolParameters(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.FabricDataAgentToolParameters FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.FabricDataAgentToolParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FabricDataAgentToolParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FabricDataAgentToolParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.FabricDataAgentToolParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FabricDataAgentToolParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FabricDataAgentToolParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FabricDataAgentToolParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class FileSearchTool : Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchTool>
    {
        public FileSearchTool() { }
        public FileSearchTool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, System.Collections.Generic.IList<string> vectorStoreIds, int? maxNumResults, Azure.AI.AgentServer.Contracts.Generated.OpenAI.RankingOptions rankingOptions, System.BinaryData filters) { }
        public FileSearchTool(System.Collections.Generic.IEnumerable<string> vectorStoreIds) { }
        public System.BinaryData Filters { get { throw null; } set { } }
        public int? MaxNumResults { get { throw null; } set { } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.RankingOptions RankingOptions { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> VectorStoreIds { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchTool DeserializeFileSearchTool(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchTool FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchTool System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class FileSearchToolCallItemParam : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemParam>
    {
        public FileSearchToolCallItemParam() { }
        public FileSearchToolCallItemParam(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, System.Collections.Generic.IList<string> queries, System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemParamResult> results) { }
        public FileSearchToolCallItemParam(System.Collections.Generic.IEnumerable<string> queries) { }
        public System.Collections.Generic.IList<string> Queries { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemParamResult> Results { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemParam DeserializeFileSearchToolCallItemParam(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemParam FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class FileSearchToolCallItemParamResult : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemParamResult>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemParamResult>
    {
        public FileSearchToolCallItemParamResult() { }
        public FileSearchToolCallItemParamResult(string fileId, string text, string filename, Azure.AI.AgentServer.Contracts.Generated.OpenAI.VectorStoreFileAttributes attributes, float? score, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.VectorStoreFileAttributes Attributes { get { throw null; } set { } }
        public string FileId { get { throw null; } set { } }
        public string Filename { get { throw null; } set { } }
        public float? Score { get { throw null; } set { } }
        public string Text { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemParamResult DeserializeFileSearchToolCallItemParamResult(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemParamResult FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemParamResult System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemParamResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemParamResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemParamResult System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemParamResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemParamResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemParamResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class FileSearchToolCallItemResource : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemResource>
    {
        public FileSearchToolCallItemResource() { }
        public FileSearchToolCallItemResource(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemResourceStatus status, System.Collections.Generic.IReadOnlyList<string> queries, System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemParamResult> results) { }
        public FileSearchToolCallItemResource(string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemResourceStatus status, System.Collections.Generic.IEnumerable<string> queries) { }
        public System.Collections.Generic.IReadOnlyList<string> Queries { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemParamResult> Results { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemResourceStatus Status { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemResource DeserializeFileSearchToolCallItemResource(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemResource FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum FileSearchToolCallItemResourceStatus
    {
        InProgress = 0,
        Searching = 1,
        Completed = 2,
        Incomplete = 3,
        Failed = 4,
    }
    public static partial class FileSearchToolCallItemResourceStatusExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemResourceStatus ToFileSearchToolCallItemResourceStatus(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.FileSearchToolCallItemResourceStatus value) { throw null; }
    }
    public partial class FunctionTool : Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionTool>
    {
        public FunctionTool() { }
        public FunctionTool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string name, string description, System.BinaryData parameters, bool? strict) { }
        public FunctionTool(string name, System.BinaryData parameters, bool? strict) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Parameters { get { throw null; } set { } }
        public bool? Strict { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionTool DeserializeFunctionTool(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionTool FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionTool System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class FunctionToolCallItemParam : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemParam>
    {
        public FunctionToolCallItemParam() { }
        public FunctionToolCallItemParam(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string callId, string name, string arguments) { }
        public FunctionToolCallItemParam(string callId, string name, string arguments) { }
        public string Arguments { get { throw null; } set { } }
        public string CallId { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemParam DeserializeFunctionToolCallItemParam(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemParam FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class FunctionToolCallItemResource : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemResource>
    {
        public FunctionToolCallItemResource() { }
        public FunctionToolCallItemResource(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemResourceStatus status, string callId, string name, string arguments) { }
        public FunctionToolCallItemResource(string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemResourceStatus status, string callId, string name, string arguments) { }
        public string Arguments { get { throw null; } }
        public string CallId { get { throw null; } }
        public string Name { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemResourceStatus Status { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemResource DeserializeFunctionToolCallItemResource(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemResource FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum FunctionToolCallItemResourceStatus
    {
        InProgress = 0,
        Completed = 1,
        Incomplete = 2,
    }
    public static partial class FunctionToolCallItemResourceStatusExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemResourceStatus ToFunctionToolCallItemResourceStatus(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallItemResourceStatus value) { throw null; }
    }
    public partial class FunctionToolCallOutputItemParam : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallOutputItemParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallOutputItemParam>
    {
        public FunctionToolCallOutputItemParam() { }
        public FunctionToolCallOutputItemParam(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string callId, string output) { }
        public FunctionToolCallOutputItemParam(string callId, string output) { }
        public string CallId { get { throw null; } set { } }
        public string Output { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallOutputItemParam DeserializeFunctionToolCallOutputItemParam(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallOutputItemParam FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallOutputItemParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallOutputItemParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallOutputItemParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallOutputItemParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallOutputItemParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallOutputItemParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallOutputItemParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class FunctionToolCallOutputItemResource : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallOutputItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallOutputItemResource>
    {
        public FunctionToolCallOutputItemResource() { }
        public FunctionToolCallOutputItemResource(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallOutputItemResourceStatus status, string callId, string output) { }
        public FunctionToolCallOutputItemResource(string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallOutputItemResourceStatus status, string callId, string output) { }
        public string CallId { get { throw null; } }
        public string Output { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallOutputItemResourceStatus Status { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallOutputItemResource DeserializeFunctionToolCallOutputItemResource(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallOutputItemResource FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallOutputItemResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallOutputItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallOutputItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallOutputItemResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallOutputItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallOutputItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallOutputItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum FunctionToolCallOutputItemResourceStatus
    {
        InProgress = 0,
        Completed = 1,
        Incomplete = 2,
    }
    public static partial class FunctionToolCallOutputItemResourceStatusExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallOutputItemResourceStatus ToFunctionToolCallOutputItemResourceStatus(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.FunctionToolCallOutputItemResourceStatus value) { throw null; }
    }
    public partial class ImageGenTool : Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenTool>
    {
        public ImageGenTool() { }
        public ImageGenTool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolModel? model, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolQuality? quality, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolSize? size, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolOutputFormat? outputFormat, int? outputCompression, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolModeration? moderation, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolBackground? background, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolInputImageMask inputImageMask, int? partialImages) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolBackground? Background { get { throw null; } set { } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolInputImageMask InputImageMask { get { throw null; } set { } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolModel? Model { get { throw null; } set { } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolModeration? Moderation { get { throw null; } set { } }
        public int? OutputCompression { get { throw null; } set { } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolOutputFormat? OutputFormat { get { throw null; } set { } }
        public int? PartialImages { get { throw null; } set { } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolQuality? Quality { get { throw null; } set { } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolSize? Size { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenTool DeserializeImageGenTool(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenTool FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenTool System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum ImageGenToolBackground
    {
        Transparent = 0,
        Opaque = 1,
        Auto = 2,
    }
    public static partial class ImageGenToolBackgroundExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolBackground ToImageGenToolBackground(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolBackground value) { throw null; }
    }
    public partial class ImageGenToolCallItemParam : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolCallItemParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolCallItemParam>
    {
        public ImageGenToolCallItemParam() { }
        public ImageGenToolCallItemParam(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string result) { }
        public ImageGenToolCallItemParam(string result) { }
        public string Result { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolCallItemParam DeserializeImageGenToolCallItemParam(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolCallItemParam FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolCallItemParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolCallItemParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolCallItemParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolCallItemParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolCallItemParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolCallItemParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolCallItemParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ImageGenToolCallItemResource : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolCallItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolCallItemResource>
    {
        public ImageGenToolCallItemResource() { }
        public ImageGenToolCallItemResource(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolCallItemResourceStatus status, string result) { }
        public ImageGenToolCallItemResource(string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolCallItemResourceStatus status, string result) { }
        public string Result { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolCallItemResourceStatus Status { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolCallItemResource DeserializeImageGenToolCallItemResource(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolCallItemResource FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolCallItemResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolCallItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolCallItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolCallItemResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolCallItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolCallItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolCallItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum ImageGenToolCallItemResourceStatus
    {
        InProgress = 0,
        Completed = 1,
        Generating = 2,
        Failed = 3,
    }
    public static partial class ImageGenToolCallItemResourceStatusExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolCallItemResourceStatus ToImageGenToolCallItemResourceStatus(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolCallItemResourceStatus value) { throw null; }
    }
    public partial class ImageGenToolInputImageMask : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolInputImageMask>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolInputImageMask>
    {
        public ImageGenToolInputImageMask() { }
        public ImageGenToolInputImageMask(string imageUrl, string fileId, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public string FileId { get { throw null; } set { } }
        public string ImageUrl { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolInputImageMask DeserializeImageGenToolInputImageMask(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolInputImageMask FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolInputImageMask System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolInputImageMask>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolInputImageMask>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolInputImageMask System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolInputImageMask>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolInputImageMask>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolInputImageMask>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ImageGenToolModel : System.IEquatable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolModel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ImageGenToolModel(string value) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolModel GptImage1 { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolModel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolModel left, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolModel right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolModel (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolModel left, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolModel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ImageGenToolModeration
    {
        Auto = 0,
        Low = 1,
    }
    public static partial class ImageGenToolModerationExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolModeration ToImageGenToolModeration(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolModeration value) { throw null; }
    }
    public enum ImageGenToolOutputFormat
    {
        Png = 0,
        Webp = 1,
        Jpeg = 2,
    }
    public static partial class ImageGenToolOutputFormatExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolOutputFormat ToImageGenToolOutputFormat(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolOutputFormat value) { throw null; }
    }
    public enum ImageGenToolQuality
    {
        Low = 0,
        Medium = 1,
        High = 2,
        Auto = 3,
    }
    public static partial class ImageGenToolQualityExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolQuality ToImageGenToolQuality(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolQuality value) { throw null; }
    }
    public enum ImageGenToolSize
    {
        _1024x1024 = 0,
        _1024x1536 = 1,
        _1536x1024 = 2,
        Auto = 3,
    }
    public static partial class ImageGenToolSizeExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolSize ToImageGenToolSize(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.ImageGenToolSize value) { throw null; }
    }
    public enum Includable
    {
        CodeInterpreterCallOutputs = 0,
        ComputerCallOutputOutputImageUrl = 1,
        FileSearchCallResults = 2,
        MessageInputImageImageUrl = 3,
        MessageOutputTextLogprobs = 4,
        ReasoningEncryptedContent = 5,
        WebSearchCallResults = 6,
        WebSearchCallActionSources = 7,
        MemorySearchCallResults = 8,
    }
    public static partial class IncludableExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.Includable ToIncludable(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.Includable value) { throw null; }
    }
    [System.ClientModel.Primitives.PersistableModelProxyAttribute(typeof(Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownItemContent))]
    public abstract partial class ItemContent : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent>
    {
        protected ItemContent() { }
        public ItemContent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentType Type { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent DeserializeItemContent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ItemContentInputAudio : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputAudio>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputAudio>
    {
        public ItemContentInputAudio() { }
        public ItemContentInputAudio(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string data, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputAudioFormat format) { }
        public ItemContentInputAudio(string data, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputAudioFormat format) { }
        public string Data { get { throw null; } set { } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputAudioFormat Format { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputAudio DeserializeItemContentInputAudio(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputAudio FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputAudio System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputAudio>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputAudio>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputAudio System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputAudio>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputAudio>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputAudio>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum ItemContentInputAudioFormat
    {
        Mp3 = 0,
        Wav = 1,
    }
    public static partial class ItemContentInputAudioFormatExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputAudioFormat ToItemContentInputAudioFormat(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputAudioFormat value) { throw null; }
    }
    public partial class ItemContentInputFile : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputFile>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputFile>
    {
        public ItemContentInputFile() { }
        public ItemContentInputFile(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string fileId, string filename, string fileData) { }
        public string FileData { get { throw null; } set { } }
        public string FileId { get { throw null; } set { } }
        public string Filename { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputFile DeserializeItemContentInputFile(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputFile FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputFile System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputFile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputFile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputFile System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputFile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputFile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputFile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ItemContentInputImage : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputImage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputImage>
    {
        public ItemContentInputImage() { }
        public ItemContentInputImage(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string imageUrl, string fileId, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputImageDetail? detail) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputImageDetail? Detail { get { throw null; } set { } }
        public string FileId { get { throw null; } set { } }
        public string ImageUrl { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputImage DeserializeItemContentInputImage(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputImage FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputImage System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputImage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputImage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputImage System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputImage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputImage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputImage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum ItemContentInputImageDetail
    {
        Low = 0,
        High = 1,
        Auto = 2,
    }
    public static partial class ItemContentInputImageDetailExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputImageDetail ToItemContentInputImageDetail(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputImageDetail value) { throw null; }
    }
    public partial class ItemContentInputText : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputText>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputText>
    {
        public ItemContentInputText() { }
        public ItemContentInputText(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string text) { }
        public ItemContentInputText(string text) { }
        public string Text { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputText DeserializeItemContentInputText(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputText FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputText System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputText>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputText>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputText System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputText>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputText>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentInputText>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ItemContentOutputAudio : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentOutputAudio>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentOutputAudio>
    {
        public ItemContentOutputAudio() { }
        public ItemContentOutputAudio(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string data, string transcript) { }
        public ItemContentOutputAudio(string data, string transcript) { }
        public string Data { get { throw null; } set { } }
        public string Transcript { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentOutputAudio DeserializeItemContentOutputAudio(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentOutputAudio FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentOutputAudio System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentOutputAudio>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentOutputAudio>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentOutputAudio System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentOutputAudio>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentOutputAudio>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentOutputAudio>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ItemContentOutputText : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentOutputText>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentOutputText>
    {
        public ItemContentOutputText() { }
        public ItemContentOutputText(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string text, System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Annotation> annotations, System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LogProb> logprobs) { }
        public ItemContentOutputText(string text, System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Annotation> annotations) { }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Annotation> Annotations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LogProb> Logprobs { get { throw null; } }
        public string Text { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentOutputText DeserializeItemContentOutputText(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentOutputText FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentOutputText System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentOutputText>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentOutputText>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentOutputText System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentOutputText>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentOutputText>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentOutputText>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ItemContentRefusal : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentRefusal>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentRefusal>
    {
        public ItemContentRefusal() { }
        public ItemContentRefusal(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string refusal) { }
        public ItemContentRefusal(string refusal) { }
        public string Refusal { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentRefusal DeserializeItemContentRefusal(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentRefusal FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentRefusal System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentRefusal>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentRefusal>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentRefusal System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentRefusal>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentRefusal>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentRefusal>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum ItemContentType
    {
        InputText = 0,
        InputAudio = 1,
        InputImage = 2,
        InputFile = 3,
        OutputText = 4,
        OutputAudio = 5,
        Refusal = 6,
    }
    public static partial class ItemContentTypeExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentType ToItemContentType(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentType value) { throw null; }
    }
    [System.ClientModel.Primitives.PersistableModelProxyAttribute(typeof(Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownItemParam))]
    public abstract partial class ItemParam : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam>
    {
        protected ItemParam() { }
        public ItemParam(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> SerializedAdditionalRawData { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType Type { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam DeserializeItemParam(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ItemReferenceItemParam : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemReferenceItemParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemReferenceItemParam>
    {
        public ItemReferenceItemParam() { }
        public ItemReferenceItemParam(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string id) { }
        public ItemReferenceItemParam(string id) { }
        public string Id { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemReferenceItemParam DeserializeItemReferenceItemParam(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemReferenceItemParam FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemReferenceItemParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemReferenceItemParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemReferenceItemParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemReferenceItemParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemReferenceItemParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemReferenceItemParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemReferenceItemParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.ClientModel.Primitives.PersistableModelProxyAttribute(typeof(Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownItemResource))]
    public abstract partial class ItemResource : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource>
    {
        public ItemResource() { }
        public ItemResource(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        protected ItemResource(string id) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy CreatedBy { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType Type { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource DeserializeItemResource(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ItemType : System.IEquatable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ItemType(string value) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType CodeInterpreterCall { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType ComputerCall { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType ComputerCallOutput { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType FileSearchCall { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType FunctionCall { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType FunctionCallOutput { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType ImageGenerationCall { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType ItemReference { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType LocalShellCall { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType LocalShellCallOutput { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType McpApprovalRequest { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType McpApprovalResponse { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType McpCall { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType McpListTools { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType MemorySearchCall { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType Message { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType OauthConsentRequest { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType Reasoning { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType StructuredOutputs { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType WebSearchCall { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType WorkflowAction { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType left, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType left, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ListAgentsRequestOrder
    {
        Asc = 0,
        Desc = 1,
    }
    public static partial class ListAgentsRequestOrderExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ListAgentsRequestOrder ToListAgentsRequestOrder(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.ListAgentsRequestOrder value) { throw null; }
    }
    public partial class LocalShellExecAction : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellExecAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellExecAction>
    {
        public LocalShellExecAction() { }
        public LocalShellExecAction(Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellExecActionType type, System.Collections.Generic.IList<string> command, int? timeoutMs, string workingDirectory, System.Collections.Generic.IDictionary<string, string> env, string user, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public LocalShellExecAction(System.Collections.Generic.IEnumerable<string> command, System.Collections.Generic.IDictionary<string, string> env) { }
        public System.Collections.Generic.IList<string> Command { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Env { get { throw null; } }
        public int? TimeoutMs { get { throw null; } set { } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellExecActionType Type { get { throw null; } }
        public string User { get { throw null; } set { } }
        public string WorkingDirectory { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellExecAction DeserializeLocalShellExecAction(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellExecAction FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellExecAction System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellExecAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellExecAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellExecAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellExecAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellExecAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellExecAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LocalShellExecActionType : System.IEquatable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellExecActionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LocalShellExecActionType(string value) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellExecActionType Exec { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellExecActionType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellExecActionType left, Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellExecActionType right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellExecActionType (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellExecActionType left, Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellExecActionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LocalShellTool : Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellTool>
    {
        public LocalShellTool() { }
        public LocalShellTool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellTool DeserializeLocalShellTool(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellTool FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellTool System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class LocalShellToolCallItemParam : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallItemParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallItemParam>
    {
        public LocalShellToolCallItemParam() { }
        public LocalShellToolCallItemParam(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string callId, Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellExecAction action) { }
        public LocalShellToolCallItemParam(string callId, Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellExecAction action) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellExecAction Action { get { throw null; } set { } }
        public string CallId { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallItemParam DeserializeLocalShellToolCallItemParam(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallItemParam FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallItemParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallItemParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallItemParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallItemParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallItemParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallItemParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallItemParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class LocalShellToolCallItemResource : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallItemResource>
    {
        public LocalShellToolCallItemResource() { }
        public LocalShellToolCallItemResource(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallItemResourceStatus status, string callId, Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellExecAction action) { }
        public LocalShellToolCallItemResource(string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallItemResourceStatus status, string callId, Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellExecAction action) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellExecAction Action { get { throw null; } }
        public string CallId { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallItemResourceStatus Status { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallItemResource DeserializeLocalShellToolCallItemResource(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallItemResource FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallItemResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallItemResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum LocalShellToolCallItemResourceStatus
    {
        InProgress = 0,
        Completed = 1,
        Incomplete = 2,
    }
    public static partial class LocalShellToolCallItemResourceStatusExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallItemResourceStatus ToLocalShellToolCallItemResourceStatus(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallItemResourceStatus value) { throw null; }
    }
    public partial class LocalShellToolCallOutputItemParam : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallOutputItemParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallOutputItemParam>
    {
        public LocalShellToolCallOutputItemParam() { }
        public LocalShellToolCallOutputItemParam(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string output) { }
        public LocalShellToolCallOutputItemParam(string output) { }
        public string Output { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallOutputItemParam DeserializeLocalShellToolCallOutputItemParam(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallOutputItemParam FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallOutputItemParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallOutputItemParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallOutputItemParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallOutputItemParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallOutputItemParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallOutputItemParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallOutputItemParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class LocalShellToolCallOutputItemResource : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallOutputItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallOutputItemResource>
    {
        public LocalShellToolCallOutputItemResource() { }
        public LocalShellToolCallOutputItemResource(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallOutputItemResourceStatus status, string output) { }
        public LocalShellToolCallOutputItemResource(string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallOutputItemResourceStatus status, string output) { }
        public string Output { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallOutputItemResourceStatus Status { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallOutputItemResource DeserializeLocalShellToolCallOutputItemResource(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallOutputItemResource FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallOutputItemResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallOutputItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallOutputItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallOutputItemResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallOutputItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallOutputItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallOutputItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum LocalShellToolCallOutputItemResourceStatus
    {
        InProgress = 0,
        Completed = 1,
        Incomplete = 2,
    }
    public static partial class LocalShellToolCallOutputItemResourceStatusExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallOutputItemResourceStatus ToLocalShellToolCallOutputItemResourceStatus(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocalShellToolCallOutputItemResourceStatus value) { throw null; }
    }
    [System.ClientModel.Primitives.PersistableModelProxyAttribute(typeof(Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownLocation))]
    public abstract partial class Location : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Location>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Location>
    {
        protected Location() { }
        public Location(Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocationType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocationType Type { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.Location DeserializeLocation(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.Location FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.Location System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Location>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Location>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.Location System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Location>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Location>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Location>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LocationType : System.IEquatable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LocationType(string value) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocationType Approximate { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocationType left, Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocationType right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocationType (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocationType left, Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogProb : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LogProb>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LogProb>
    {
        public LogProb() { }
        public LogProb(string token, float logprob, System.Collections.Generic.IEnumerable<int> bytes, System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.TopLogProb> topLogprobs) { }
        public LogProb(string token, float logprob, System.Collections.Generic.IList<int> bytes, System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.TopLogProb> topLogprobs, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public System.Collections.Generic.IList<int> Bytes { get { throw null; } }
        public float Logprob { get { throw null; } set { } }
        public string Token { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.TopLogProb> TopLogprobs { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.LogProb DeserializeLogProb(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.LogProb FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.LogProb System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LogProb>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LogProb>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.LogProb System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LogProb>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LogProb>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.LogProb>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class MCPApprovalRequestItemParam : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalRequestItemParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalRequestItemParam>
    {
        public MCPApprovalRequestItemParam() { }
        public MCPApprovalRequestItemParam(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string serverLabel, string name, string arguments) { }
        public MCPApprovalRequestItemParam(string serverLabel, string name, string arguments) { }
        public string Arguments { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string ServerLabel { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalRequestItemParam DeserializeMCPApprovalRequestItemParam(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalRequestItemParam FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalRequestItemParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalRequestItemParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalRequestItemParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalRequestItemParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalRequestItemParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalRequestItemParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalRequestItemParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class MCPApprovalRequestItemResource : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalRequestItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalRequestItemResource>
    {
        public MCPApprovalRequestItemResource() { }
        public MCPApprovalRequestItemResource(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string serverLabel, string name, string arguments) { }
        public MCPApprovalRequestItemResource(string id, string serverLabel, string name, string arguments) { }
        public string Arguments { get { throw null; } }
        public string Name { get { throw null; } }
        public string ServerLabel { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalRequestItemResource DeserializeMCPApprovalRequestItemResource(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalRequestItemResource FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalRequestItemResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalRequestItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalRequestItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalRequestItemResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalRequestItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalRequestItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalRequestItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class MCPApprovalResponseItemParam : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalResponseItemParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalResponseItemParam>
    {
        public MCPApprovalResponseItemParam() { }
        public MCPApprovalResponseItemParam(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string approvalRequestId, bool approve, string reason) { }
        public MCPApprovalResponseItemParam(string approvalRequestId, bool approve) { }
        public string ApprovalRequestId { get { throw null; } set { } }
        public bool Approve { get { throw null; } set { } }
        public string Reason { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalResponseItemParam DeserializeMCPApprovalResponseItemParam(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalResponseItemParam FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalResponseItemParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalResponseItemParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalResponseItemParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalResponseItemParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalResponseItemParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalResponseItemParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalResponseItemParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class MCPApprovalResponseItemResource : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalResponseItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalResponseItemResource>
    {
        public MCPApprovalResponseItemResource() { }
        public MCPApprovalResponseItemResource(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string approvalRequestId, bool approve, string reason) { }
        public MCPApprovalResponseItemResource(string id, string approvalRequestId, bool approve) { }
        public string ApprovalRequestId { get { throw null; } }
        public bool Approve { get { throw null; } }
        public string Reason { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalResponseItemResource DeserializeMCPApprovalResponseItemResource(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalResponseItemResource FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalResponseItemResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalResponseItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalResponseItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalResponseItemResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalResponseItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalResponseItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPApprovalResponseItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class MCPCallItemParam : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPCallItemParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPCallItemParam>
    {
        public MCPCallItemParam() { }
        public MCPCallItemParam(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string serverLabel, string name, string arguments, string output, string error) { }
        public MCPCallItemParam(string serverLabel, string name, string arguments) { }
        public string Arguments { get { throw null; } set { } }
        public string Error { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Output { get { throw null; } set { } }
        public string ServerLabel { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPCallItemParam DeserializeMCPCallItemParam(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPCallItemParam FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPCallItemParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPCallItemParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPCallItemParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPCallItemParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPCallItemParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPCallItemParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPCallItemParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class MCPCallItemResource : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPCallItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPCallItemResource>
    {
        public MCPCallItemResource() { }
        public MCPCallItemResource(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string serverLabel, string name, string arguments, string output, string error) { }
        public MCPCallItemResource(string id, string serverLabel, string name, string arguments) { }
        public string Arguments { get { throw null; } }
        public string Error { get { throw null; } }
        public string Name { get { throw null; } }
        public string Output { get { throw null; } }
        public string ServerLabel { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPCallItemResource DeserializeMCPCallItemResource(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPCallItemResource FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPCallItemResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPCallItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPCallItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPCallItemResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPCallItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPCallItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPCallItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class MCPListToolsItemParam : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsItemParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsItemParam>
    {
        public MCPListToolsItemParam() { }
        public MCPListToolsItemParam(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string serverLabel, System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsTool> tools, string error) { }
        public MCPListToolsItemParam(string serverLabel, System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsTool> tools) { }
        public string Error { get { throw null; } set { } }
        public string ServerLabel { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsTool> Tools { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsItemParam DeserializeMCPListToolsItemParam(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsItemParam FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsItemParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsItemParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsItemParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsItemParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsItemParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsItemParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsItemParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class MCPListToolsItemResource : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsItemResource>
    {
        public MCPListToolsItemResource() { }
        public MCPListToolsItemResource(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string serverLabel, System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsTool> tools, string error) { }
        public MCPListToolsItemResource(string id, string serverLabel, System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsTool> tools) { }
        public string Error { get { throw null; } }
        public string ServerLabel { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsTool> Tools { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsItemResource DeserializeMCPListToolsItemResource(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsItemResource FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsItemResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsItemResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class MCPListToolsTool : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsTool>
    {
        public MCPListToolsTool() { }
        public MCPListToolsTool(string name, System.BinaryData inputSchema) { }
        public MCPListToolsTool(string name, string description, System.BinaryData inputSchema, System.BinaryData annotations, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public System.BinaryData Annotations { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.BinaryData InputSchema { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsTool DeserializeMCPListToolsTool(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsTool FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsTool System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPListToolsTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class MCPTool : Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPTool>
    {
        public MCPTool() { }
        public MCPTool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string serverLabel, string serverUrl, System.Collections.Generic.IDictionary<string, string> headers, System.BinaryData allowedTools, System.BinaryData requireApproval, string projectConnectionId) { }
        public MCPTool(string serverLabel, string serverUrl) { }
        public System.BinaryData AllowedTools { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Headers { get { throw null; } set { } }
        public string ProjectConnectionId { get { throw null; } set { } }
        public System.BinaryData RequireApproval { get { throw null; } set { } }
        public string ServerLabel { get { throw null; } set { } }
        public string ServerUrl { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPTool DeserializeMCPTool(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPTool FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPTool System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class MCPToolAllowedTools1 : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolAllowedTools1>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolAllowedTools1>
    {
        public MCPToolAllowedTools1() { }
        public MCPToolAllowedTools1(System.Collections.Generic.IList<string> toolNames, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public System.Collections.Generic.IList<string> ToolNames { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolAllowedTools1 DeserializeMCPToolAllowedTools1(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolAllowedTools1 FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolAllowedTools1 System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolAllowedTools1>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolAllowedTools1>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolAllowedTools1 System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolAllowedTools1>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolAllowedTools1>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolAllowedTools1>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class MCPToolRequireApproval1 : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApproval1>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApproval1>
    {
        public MCPToolRequireApproval1() { }
        public MCPToolRequireApproval1(Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApprovalAlways always, Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApprovalNever never, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApprovalAlways Always { get { throw null; } set { } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApprovalNever Never { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApproval1 DeserializeMCPToolRequireApproval1(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApproval1 FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApproval1 System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApproval1>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApproval1>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApproval1 System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApproval1>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApproval1>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApproval1>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class MCPToolRequireApprovalAlways : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApprovalAlways>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApprovalAlways>
    {
        public MCPToolRequireApprovalAlways() { }
        public MCPToolRequireApprovalAlways(System.Collections.Generic.IList<string> toolNames, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public System.Collections.Generic.IList<string> ToolNames { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApprovalAlways DeserializeMCPToolRequireApprovalAlways(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApprovalAlways FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApprovalAlways System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApprovalAlways>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApprovalAlways>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApprovalAlways System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApprovalAlways>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApprovalAlways>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApprovalAlways>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class MCPToolRequireApprovalNever : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApprovalNever>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApprovalNever>
    {
        public MCPToolRequireApprovalNever() { }
        public MCPToolRequireApprovalNever(System.Collections.Generic.IList<string> toolNames, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public System.Collections.Generic.IList<string> ToolNames { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApprovalNever DeserializeMCPToolRequireApprovalNever(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApprovalNever FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApprovalNever System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApprovalNever>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApprovalNever>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApprovalNever System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApprovalNever>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApprovalNever>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MCPToolRequireApprovalNever>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class MicrosoftFabricAgentTool : Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MicrosoftFabricAgentTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MicrosoftFabricAgentTool>
    {
        public MicrosoftFabricAgentTool() { }
        public MicrosoftFabricAgentTool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.FabricDataAgentToolParameters fabricDataagentPreview) { }
        public MicrosoftFabricAgentTool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.FabricDataAgentToolParameters fabricDataagentPreview) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.FabricDataAgentToolParameters FabricDataagentPreview { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.MicrosoftFabricAgentTool DeserializeMicrosoftFabricAgentTool(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.MicrosoftFabricAgentTool FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.MicrosoftFabricAgentTool System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MicrosoftFabricAgentTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MicrosoftFabricAgentTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.MicrosoftFabricAgentTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MicrosoftFabricAgentTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MicrosoftFabricAgentTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.MicrosoftFabricAgentTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class OAuthConsentRequestItemResource : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OAuthConsentRequestItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OAuthConsentRequestItemResource>
    {
        public OAuthConsentRequestItemResource() { }
        public OAuthConsentRequestItemResource(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string consentLink, string serverLabel) { }
        public OAuthConsentRequestItemResource(string id, string consentLink, string serverLabel) { }
        public string ConsentLink { get { throw null; } }
        public string ServerLabel { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.OAuthConsentRequestItemResource DeserializeOAuthConsentRequestItemResource(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.OAuthConsentRequestItemResource FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.OAuthConsentRequestItemResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OAuthConsentRequestItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OAuthConsentRequestItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.OAuthConsentRequestItemResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OAuthConsentRequestItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OAuthConsentRequestItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OAuthConsentRequestItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class OpenApiAgentTool : Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAgentTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAgentTool>
    {
        public OpenApiAgentTool() { }
        public OpenApiAgentTool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiFunctionDefinition openapi) { }
        public OpenApiAgentTool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiFunctionDefinition openapi) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiFunctionDefinition Openapi { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAgentTool DeserializeOpenApiAgentTool(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAgentTool FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAgentTool System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAgentTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAgentTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAgentTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAgentTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAgentTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAgentTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class OpenApiAnonymousAuthDetails : Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthDetails, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAnonymousAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAnonymousAuthDetails>
    {
        public OpenApiAnonymousAuthDetails() { }
        public OpenApiAnonymousAuthDetails(Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAnonymousAuthDetails DeserializeOpenApiAnonymousAuthDetails(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAnonymousAuthDetails FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAnonymousAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAnonymousAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAnonymousAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAnonymousAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAnonymousAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAnonymousAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAnonymousAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.ClientModel.Primitives.PersistableModelProxyAttribute(typeof(Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownOpenApiAuthDetails))]
    public abstract partial class OpenApiAuthDetails : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthDetails>
    {
        protected OpenApiAuthDetails() { }
        public OpenApiAuthDetails(Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthType Type { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthDetails DeserializeOpenApiAuthDetails(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthDetails FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OpenApiAuthType : System.IEquatable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OpenApiAuthType(string value) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthType Anonymous { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthType ManagedIdentity { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthType ProjectConnection { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthType left, Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthType right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthType (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthType left, Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OpenApiFunctionDefinition : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiFunctionDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiFunctionDefinition>
    {
        public OpenApiFunctionDefinition() { }
        public OpenApiFunctionDefinition(string name, System.BinaryData spec, Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthDetails auth) { }
        public OpenApiFunctionDefinition(string name, string description, System.BinaryData spec, Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthDetails auth, System.Collections.Generic.IList<string> defaultParams, System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiFunctionDefinitionFunction> functions, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthDetails Auth { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DefaultParams { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiFunctionDefinitionFunction> Functions { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Spec { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiFunctionDefinition DeserializeOpenApiFunctionDefinition(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiFunctionDefinition FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiFunctionDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiFunctionDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiFunctionDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiFunctionDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiFunctionDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiFunctionDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiFunctionDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class OpenApiFunctionDefinitionFunction : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiFunctionDefinitionFunction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiFunctionDefinitionFunction>
    {
        public OpenApiFunctionDefinitionFunction() { }
        public OpenApiFunctionDefinitionFunction(string name, System.BinaryData parameters) { }
        public OpenApiFunctionDefinitionFunction(string name, string description, System.BinaryData parameters, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Parameters { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiFunctionDefinitionFunction DeserializeOpenApiFunctionDefinitionFunction(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiFunctionDefinitionFunction FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiFunctionDefinitionFunction System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiFunctionDefinitionFunction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiFunctionDefinitionFunction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiFunctionDefinitionFunction System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiFunctionDefinitionFunction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiFunctionDefinitionFunction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiFunctionDefinitionFunction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class OpenApiManagedAuthDetails : Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthDetails, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiManagedAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiManagedAuthDetails>
    {
        public OpenApiManagedAuthDetails() { }
        public OpenApiManagedAuthDetails(Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiManagedSecurityScheme securityScheme) { }
        public OpenApiManagedAuthDetails(Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiManagedSecurityScheme securityScheme) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiManagedSecurityScheme SecurityScheme { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiManagedAuthDetails DeserializeOpenApiManagedAuthDetails(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiManagedAuthDetails FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiManagedAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiManagedAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiManagedAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiManagedAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiManagedAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiManagedAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiManagedAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class OpenApiManagedSecurityScheme : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiManagedSecurityScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiManagedSecurityScheme>
    {
        public OpenApiManagedSecurityScheme() { }
        public OpenApiManagedSecurityScheme(string audience) { }
        public OpenApiManagedSecurityScheme(string audience, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public string Audience { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiManagedSecurityScheme DeserializeOpenApiManagedSecurityScheme(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiManagedSecurityScheme FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiManagedSecurityScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiManagedSecurityScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiManagedSecurityScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiManagedSecurityScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiManagedSecurityScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiManagedSecurityScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiManagedSecurityScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class OpenApiProjectConnectionAuthDetails : Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthDetails, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiProjectConnectionAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiProjectConnectionAuthDetails>
    {
        public OpenApiProjectConnectionAuthDetails() { }
        public OpenApiProjectConnectionAuthDetails(Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiProjectConnectionSecurityScheme securityScheme) { }
        public OpenApiProjectConnectionAuthDetails(Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiProjectConnectionSecurityScheme securityScheme) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiProjectConnectionSecurityScheme SecurityScheme { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiProjectConnectionAuthDetails DeserializeOpenApiProjectConnectionAuthDetails(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiProjectConnectionAuthDetails FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiProjectConnectionAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiProjectConnectionAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiProjectConnectionAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiProjectConnectionAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiProjectConnectionAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiProjectConnectionAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiProjectConnectionAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class OpenApiProjectConnectionSecurityScheme : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiProjectConnectionSecurityScheme>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiProjectConnectionSecurityScheme>
    {
        public OpenApiProjectConnectionSecurityScheme() { }
        public OpenApiProjectConnectionSecurityScheme(string projectConnectionId) { }
        public OpenApiProjectConnectionSecurityScheme(string projectConnectionId, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public string ProjectConnectionId { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiProjectConnectionSecurityScheme DeserializeOpenApiProjectConnectionSecurityScheme(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiProjectConnectionSecurityScheme FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiProjectConnectionSecurityScheme System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiProjectConnectionSecurityScheme>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiProjectConnectionSecurityScheme>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiProjectConnectionSecurityScheme System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiProjectConnectionSecurityScheme>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiProjectConnectionSecurityScheme>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiProjectConnectionSecurityScheme>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class Prompt : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Prompt>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Prompt>
    {
        public Prompt() { }
        public Prompt(string id) { }
        public Prompt(string id, string version, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsePromptVariables variables, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public string Id { get { throw null; } set { } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsePromptVariables Variables { get { throw null; } set { } }
        public string Version { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.Prompt DeserializePrompt(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.Prompt FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.Prompt System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Prompt>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Prompt>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.Prompt System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Prompt>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Prompt>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Prompt>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class RankingOptions : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.RankingOptions>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.RankingOptions>
    {
        public RankingOptions() { }
        public RankingOptions(Azure.AI.AgentServer.Contracts.Generated.OpenAI.RankingOptionsRanker? ranker, float? scoreThreshold, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.RankingOptionsRanker? Ranker { get { throw null; } set { } }
        public float? ScoreThreshold { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.RankingOptions DeserializeRankingOptions(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.RankingOptions FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.RankingOptions System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.RankingOptions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.RankingOptions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.RankingOptions System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.RankingOptions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.RankingOptions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.RankingOptions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum RankingOptionsRanker
    {
        Auto = 0,
        Default20241115 = 1,
    }
    public static partial class RankingOptionsRankerExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.RankingOptionsRanker ToRankingOptionsRanker(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.RankingOptionsRanker value) { throw null; }
    }
    public partial class Reasoning : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Reasoning>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Reasoning>
    {
        public Reasoning() { }
        public Reasoning(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningEffort? effort, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningSummary? summary, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningGenerateSummary? generateSummary, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningEffort? Effort { get { throw null; } set { } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningGenerateSummary? GenerateSummary { get { throw null; } set { } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningSummary? Summary { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.Reasoning DeserializeReasoning(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.Reasoning FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.Reasoning System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Reasoning>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Reasoning>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.Reasoning System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Reasoning>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Reasoning>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Reasoning>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum ReasoningEffort
    {
        Low = 0,
        Medium = 1,
        High = 2,
    }
    public static partial class ReasoningEffortExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningEffort ToReasoningEffort(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningEffort value) { throw null; }
    }
    public enum ReasoningGenerateSummary
    {
        Auto = 0,
        Concise = 1,
        Detailed = 2,
    }
    public static partial class ReasoningGenerateSummaryExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningGenerateSummary ToReasoningGenerateSummary(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningGenerateSummary value) { throw null; }
    }
    public partial class ReasoningItemParam : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemParam>
    {
        public ReasoningItemParam() { }
        public ReasoningItemParam(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string encryptedContent, System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart> summary) { }
        public ReasoningItemParam(System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart> summary) { }
        public string EncryptedContent { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart> Summary { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemParam DeserializeReasoningItemParam(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemParam FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ReasoningItemResource : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemResource>
    {
        public ReasoningItemResource() { }
        public ReasoningItemResource(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string encryptedContent, System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart> summary) { }
        public ReasoningItemResource(string id, System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart> summary) { }
        public string EncryptedContent { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart> Summary { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemResource DeserializeReasoningItemResource(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemResource FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.ClientModel.Primitives.PersistableModelProxyAttribute(typeof(Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownReasoningItemSummaryPart))]
    public abstract partial class ReasoningItemSummaryPart : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart>
    {
        protected ReasoningItemSummaryPart() { }
        public ReasoningItemSummaryPart(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPartType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPartType Type { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart DeserializeReasoningItemSummaryPart(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ReasoningItemSummaryPartType : System.IEquatable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPartType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ReasoningItemSummaryPartType(string value) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPartType SummaryText { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPartType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPartType left, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPartType right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPartType (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPartType left, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPartType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReasoningItemSummaryTextPart : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryTextPart>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryTextPart>
    {
        public ReasoningItemSummaryTextPart() { }
        public ReasoningItemSummaryTextPart(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPartType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string text) { }
        public ReasoningItemSummaryTextPart(string text) { }
        public string Text { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryTextPart DeserializeReasoningItemSummaryTextPart(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryTextPart FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryTextPart System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryTextPart>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryTextPart>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryTextPart System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryTextPart>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryTextPart>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryTextPart>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum ReasoningSummary
    {
        Auto = 0,
        Concise = 1,
        Detailed = 2,
    }
    public static partial class ReasoningSummaryExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningSummary ToReasoningSummary(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningSummary value) { throw null; }
    }
    public partial class ResponseCodeInterpreterCallCodeDeltaEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCodeDeltaEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCodeDeltaEvent>
    {
        public ResponseCodeInterpreterCallCodeDeltaEvent() { }
        public ResponseCodeInterpreterCallCodeDeltaEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, int outputIndex, string itemId, string delta) { }
        public ResponseCodeInterpreterCallCodeDeltaEvent(int sequenceNumber, int outputIndex, string itemId, string delta) { }
        public string Delta { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCodeDeltaEvent DeserializeResponseCodeInterpreterCallCodeDeltaEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCodeDeltaEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCodeDeltaEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCodeDeltaEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCodeDeltaEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCodeDeltaEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCodeDeltaEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCodeDeltaEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCodeDeltaEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseCodeInterpreterCallCodeDoneEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCodeDoneEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCodeDoneEvent>
    {
        public ResponseCodeInterpreterCallCodeDoneEvent() { }
        public ResponseCodeInterpreterCallCodeDoneEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, int outputIndex, string itemId, string code) { }
        public ResponseCodeInterpreterCallCodeDoneEvent(int sequenceNumber, int outputIndex, string itemId, string code) { }
        public string Code { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCodeDoneEvent DeserializeResponseCodeInterpreterCallCodeDoneEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCodeDoneEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCodeDoneEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCodeDoneEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCodeDoneEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCodeDoneEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCodeDoneEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCodeDoneEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCodeDoneEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseCodeInterpreterCallCompletedEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCompletedEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCompletedEvent>
    {
        public ResponseCodeInterpreterCallCompletedEvent() { }
        public ResponseCodeInterpreterCallCompletedEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, int outputIndex, string itemId) { }
        public ResponseCodeInterpreterCallCompletedEvent(int sequenceNumber, int outputIndex, string itemId) { }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCompletedEvent DeserializeResponseCodeInterpreterCallCompletedEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCompletedEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCompletedEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCompletedEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCompletedEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCompletedEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCompletedEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCompletedEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallCompletedEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseCodeInterpreterCallInProgressEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallInProgressEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallInProgressEvent>
    {
        public ResponseCodeInterpreterCallInProgressEvent() { }
        public ResponseCodeInterpreterCallInProgressEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, int outputIndex, string itemId) { }
        public ResponseCodeInterpreterCallInProgressEvent(int sequenceNumber, int outputIndex, string itemId) { }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallInProgressEvent DeserializeResponseCodeInterpreterCallInProgressEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallInProgressEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallInProgressEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallInProgressEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallInProgressEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallInProgressEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallInProgressEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallInProgressEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallInProgressEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseCodeInterpreterCallInterpretingEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallInterpretingEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallInterpretingEvent>
    {
        public ResponseCodeInterpreterCallInterpretingEvent() { }
        public ResponseCodeInterpreterCallInterpretingEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, int outputIndex, string itemId) { }
        public ResponseCodeInterpreterCallInterpretingEvent(int sequenceNumber, int outputIndex, string itemId) { }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallInterpretingEvent DeserializeResponseCodeInterpreterCallInterpretingEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallInterpretingEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallInterpretingEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallInterpretingEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallInterpretingEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallInterpretingEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallInterpretingEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallInterpretingEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCodeInterpreterCallInterpretingEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseCompletedEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCompletedEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCompletedEvent>
    {
        public ResponseCompletedEvent() { }
        public ResponseCompletedEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.Responses.Response response) { }
        public ResponseCompletedEvent(int sequenceNumber, Azure.AI.AgentServer.Contracts.Generated.Responses.Response response) { }
        public Azure.AI.AgentServer.Contracts.Generated.Responses.Response Response { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCompletedEvent DeserializeResponseCompletedEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCompletedEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCompletedEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCompletedEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCompletedEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCompletedEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCompletedEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCompletedEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCompletedEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseContentPartAddedEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseContentPartAddedEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseContentPartAddedEvent>
    {
        public ResponseContentPartAddedEvent() { }
        public ResponseContentPartAddedEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string itemId, int outputIndex, int contentIndex, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent part) { }
        public ResponseContentPartAddedEvent(int sequenceNumber, string itemId, int outputIndex, int contentIndex, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent part) { }
        public int ContentIndex { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent Part { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseContentPartAddedEvent DeserializeResponseContentPartAddedEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseContentPartAddedEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseContentPartAddedEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseContentPartAddedEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseContentPartAddedEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseContentPartAddedEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseContentPartAddedEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseContentPartAddedEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseContentPartAddedEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseContentPartDoneEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseContentPartDoneEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseContentPartDoneEvent>
    {
        public ResponseContentPartDoneEvent() { }
        public ResponseContentPartDoneEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string itemId, int outputIndex, int contentIndex, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent part) { }
        public ResponseContentPartDoneEvent(int sequenceNumber, string itemId, int outputIndex, int contentIndex, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent part) { }
        public int ContentIndex { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent Part { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseContentPartDoneEvent DeserializeResponseContentPartDoneEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseContentPartDoneEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseContentPartDoneEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseContentPartDoneEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseContentPartDoneEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseContentPartDoneEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseContentPartDoneEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseContentPartDoneEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseContentPartDoneEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseCreatedEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCreatedEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCreatedEvent>
    {
        public ResponseCreatedEvent() { }
        public ResponseCreatedEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.Responses.Response response) { }
        public ResponseCreatedEvent(int sequenceNumber, Azure.AI.AgentServer.Contracts.Generated.Responses.Response response) { }
        public Azure.AI.AgentServer.Contracts.Generated.Responses.Response Response { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCreatedEvent DeserializeResponseCreatedEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCreatedEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCreatedEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCreatedEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCreatedEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCreatedEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCreatedEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCreatedEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseCreatedEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseError : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseError>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseError>
    {
        public ResponseError() { }
        public ResponseError(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseErrorCode code, string message) { }
        public ResponseError(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseErrorCode code, string message, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseErrorCode Code { get { throw null; } }
        public string Message { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseError DeserializeResponseError(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseError FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseError System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseError System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum ResponseErrorCode
    {
        ServerError = 0,
        RateLimitExceeded = 1,
        InvalidPrompt = 2,
        VectorStoreTimeout = 3,
        InvalidImage = 4,
        InvalidImageFormat = 5,
        InvalidBase64Image = 6,
        InvalidImageUrl = 7,
        ImageTooLarge = 8,
        ImageTooSmall = 9,
        ImageParseError = 10,
        ImageContentPolicyViolation = 11,
        InvalidImageMode = 12,
        ImageFileTooLarge = 13,
        UnsupportedImageMediaType = 14,
        EmptyImageFile = 15,
        FailedToDownloadImage = 16,
        ImageFileNotFound = 17,
    }
    public static partial class ResponseErrorCodeExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseErrorCode ToResponseErrorCode(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseErrorCode value) { throw null; }
    }
    public partial class ResponseErrorEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseErrorEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseErrorEvent>
    {
        public ResponseErrorEvent() { }
        public ResponseErrorEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string code, string message, string param) { }
        public ResponseErrorEvent(int sequenceNumber, string code, string message, string param) { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string Param { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseErrorEvent DeserializeResponseErrorEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseErrorEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseErrorEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseErrorEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseErrorEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseErrorEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseErrorEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseErrorEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseErrorEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseFailedEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFailedEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFailedEvent>
    {
        public ResponseFailedEvent() { }
        public ResponseFailedEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.Responses.Response response) { }
        public ResponseFailedEvent(int sequenceNumber, Azure.AI.AgentServer.Contracts.Generated.Responses.Response response) { }
        public Azure.AI.AgentServer.Contracts.Generated.Responses.Response Response { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFailedEvent DeserializeResponseFailedEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFailedEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFailedEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFailedEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFailedEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFailedEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFailedEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFailedEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFailedEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseFileSearchCallCompletedEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallCompletedEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallCompletedEvent>
    {
        public ResponseFileSearchCallCompletedEvent() { }
        public ResponseFileSearchCallCompletedEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, int outputIndex, string itemId) { }
        public ResponseFileSearchCallCompletedEvent(int sequenceNumber, int outputIndex, string itemId) { }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallCompletedEvent DeserializeResponseFileSearchCallCompletedEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallCompletedEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallCompletedEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallCompletedEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallCompletedEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallCompletedEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallCompletedEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallCompletedEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallCompletedEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseFileSearchCallInProgressEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallInProgressEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallInProgressEvent>
    {
        public ResponseFileSearchCallInProgressEvent() { }
        public ResponseFileSearchCallInProgressEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, int outputIndex, string itemId) { }
        public ResponseFileSearchCallInProgressEvent(int sequenceNumber, int outputIndex, string itemId) { }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallInProgressEvent DeserializeResponseFileSearchCallInProgressEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallInProgressEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallInProgressEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallInProgressEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallInProgressEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallInProgressEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallInProgressEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallInProgressEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallInProgressEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseFileSearchCallSearchingEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallSearchingEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallSearchingEvent>
    {
        public ResponseFileSearchCallSearchingEvent() { }
        public ResponseFileSearchCallSearchingEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, int outputIndex, string itemId) { }
        public ResponseFileSearchCallSearchingEvent(int sequenceNumber, int outputIndex, string itemId) { }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallSearchingEvent DeserializeResponseFileSearchCallSearchingEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallSearchingEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallSearchingEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallSearchingEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallSearchingEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallSearchingEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallSearchingEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallSearchingEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFileSearchCallSearchingEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseFormatJsonSchemaSchema : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFormatJsonSchemaSchema>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFormatJsonSchemaSchema>
    {
        public ResponseFormatJsonSchemaSchema() { }
        public ResponseFormatJsonSchemaSchema(System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFormatJsonSchemaSchema DeserializeResponseFormatJsonSchemaSchema(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFormatJsonSchemaSchema FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFormatJsonSchemaSchema System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFormatJsonSchemaSchema>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFormatJsonSchemaSchema>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFormatJsonSchemaSchema System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFormatJsonSchemaSchema>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFormatJsonSchemaSchema>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFormatJsonSchemaSchema>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseFunctionCallArgumentsDeltaEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFunctionCallArgumentsDeltaEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFunctionCallArgumentsDeltaEvent>
    {
        public ResponseFunctionCallArgumentsDeltaEvent() { }
        public ResponseFunctionCallArgumentsDeltaEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string itemId, int outputIndex, string delta) { }
        public ResponseFunctionCallArgumentsDeltaEvent(int sequenceNumber, string itemId, int outputIndex, string delta) { }
        public string Delta { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFunctionCallArgumentsDeltaEvent DeserializeResponseFunctionCallArgumentsDeltaEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFunctionCallArgumentsDeltaEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFunctionCallArgumentsDeltaEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFunctionCallArgumentsDeltaEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFunctionCallArgumentsDeltaEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFunctionCallArgumentsDeltaEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFunctionCallArgumentsDeltaEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFunctionCallArgumentsDeltaEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFunctionCallArgumentsDeltaEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseFunctionCallArgumentsDoneEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFunctionCallArgumentsDoneEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFunctionCallArgumentsDoneEvent>
    {
        public ResponseFunctionCallArgumentsDoneEvent() { }
        public ResponseFunctionCallArgumentsDoneEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string itemId, int outputIndex, string arguments) { }
        public ResponseFunctionCallArgumentsDoneEvent(int sequenceNumber, string itemId, int outputIndex, string arguments) { }
        public string Arguments { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFunctionCallArgumentsDoneEvent DeserializeResponseFunctionCallArgumentsDoneEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFunctionCallArgumentsDoneEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFunctionCallArgumentsDoneEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFunctionCallArgumentsDoneEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFunctionCallArgumentsDoneEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFunctionCallArgumentsDoneEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFunctionCallArgumentsDoneEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFunctionCallArgumentsDoneEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFunctionCallArgumentsDoneEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseImageGenCallCompletedEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallCompletedEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallCompletedEvent>
    {
        public ResponseImageGenCallCompletedEvent() { }
        public ResponseImageGenCallCompletedEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, int outputIndex, string itemId) { }
        public ResponseImageGenCallCompletedEvent(int sequenceNumber, int outputIndex, string itemId) { }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallCompletedEvent DeserializeResponseImageGenCallCompletedEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallCompletedEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallCompletedEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallCompletedEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallCompletedEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallCompletedEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallCompletedEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallCompletedEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallCompletedEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseImageGenCallGeneratingEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallGeneratingEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallGeneratingEvent>
    {
        public ResponseImageGenCallGeneratingEvent() { }
        public ResponseImageGenCallGeneratingEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, int outputIndex, string itemId) { }
        public ResponseImageGenCallGeneratingEvent(int sequenceNumber, int outputIndex, string itemId) { }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallGeneratingEvent DeserializeResponseImageGenCallGeneratingEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallGeneratingEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallGeneratingEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallGeneratingEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallGeneratingEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallGeneratingEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallGeneratingEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallGeneratingEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallGeneratingEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseImageGenCallInProgressEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallInProgressEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallInProgressEvent>
    {
        public ResponseImageGenCallInProgressEvent() { }
        public ResponseImageGenCallInProgressEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, int outputIndex, string itemId) { }
        public ResponseImageGenCallInProgressEvent(int sequenceNumber, int outputIndex, string itemId) { }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallInProgressEvent DeserializeResponseImageGenCallInProgressEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallInProgressEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallInProgressEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallInProgressEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallInProgressEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallInProgressEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallInProgressEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallInProgressEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallInProgressEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseImageGenCallPartialImageEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallPartialImageEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallPartialImageEvent>
    {
        public ResponseImageGenCallPartialImageEvent() { }
        public ResponseImageGenCallPartialImageEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, int outputIndex, string itemId, int partialImageIndex, string partialImageB64) { }
        public ResponseImageGenCallPartialImageEvent(int sequenceNumber, int outputIndex, string itemId, int partialImageIndex, string partialImageB64) { }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        public string PartialImageB64 { get { throw null; } }
        public int PartialImageIndex { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallPartialImageEvent DeserializeResponseImageGenCallPartialImageEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallPartialImageEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallPartialImageEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallPartialImageEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallPartialImageEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallPartialImageEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallPartialImageEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallPartialImageEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseImageGenCallPartialImageEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseIncompleteDetails1 : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseIncompleteDetails1>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseIncompleteDetails1>
    {
        public ResponseIncompleteDetails1() { }
        public ResponseIncompleteDetails1(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseIncompleteDetailsReason? reason, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseIncompleteDetailsReason? Reason { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseIncompleteDetails1 DeserializeResponseIncompleteDetails1(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseIncompleteDetails1 FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseIncompleteDetails1 System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseIncompleteDetails1>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseIncompleteDetails1>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseIncompleteDetails1 System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseIncompleteDetails1>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseIncompleteDetails1>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseIncompleteDetails1>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum ResponseIncompleteDetailsReason
    {
        MaxOutputTokens = 0,
        ContentFilter = 1,
    }
    public static partial class ResponseIncompleteDetailsReasonExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseIncompleteDetailsReason ToResponseIncompleteDetailsReason(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseIncompleteDetailsReason value) { throw null; }
    }
    public partial class ResponseIncompleteEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseIncompleteEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseIncompleteEvent>
    {
        public ResponseIncompleteEvent() { }
        public ResponseIncompleteEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.Responses.Response response) { }
        public ResponseIncompleteEvent(int sequenceNumber, Azure.AI.AgentServer.Contracts.Generated.Responses.Response response) { }
        public Azure.AI.AgentServer.Contracts.Generated.Responses.Response Response { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseIncompleteEvent DeserializeResponseIncompleteEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseIncompleteEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseIncompleteEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseIncompleteEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseIncompleteEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseIncompleteEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseIncompleteEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseIncompleteEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseIncompleteEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseInProgressEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseInProgressEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseInProgressEvent>
    {
        public ResponseInProgressEvent() { }
        public ResponseInProgressEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.Responses.Response response) { }
        public ResponseInProgressEvent(int sequenceNumber, Azure.AI.AgentServer.Contracts.Generated.Responses.Response response) { }
        public Azure.AI.AgentServer.Contracts.Generated.Responses.Response Response { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseInProgressEvent DeserializeResponseInProgressEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseInProgressEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseInProgressEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseInProgressEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseInProgressEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseInProgressEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseInProgressEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseInProgressEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseInProgressEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseMCPCallArgumentsDeltaEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallArgumentsDeltaEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallArgumentsDeltaEvent>
    {
        public ResponseMCPCallArgumentsDeltaEvent() { }
        public ResponseMCPCallArgumentsDeltaEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, int outputIndex, string itemId, System.BinaryData delta) { }
        public ResponseMCPCallArgumentsDeltaEvent(int sequenceNumber, int outputIndex, string itemId, System.BinaryData delta) { }
        public System.BinaryData Delta { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallArgumentsDeltaEvent DeserializeResponseMCPCallArgumentsDeltaEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallArgumentsDeltaEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallArgumentsDeltaEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallArgumentsDeltaEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallArgumentsDeltaEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallArgumentsDeltaEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallArgumentsDeltaEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallArgumentsDeltaEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallArgumentsDeltaEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseMCPCallArgumentsDoneEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallArgumentsDoneEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallArgumentsDoneEvent>
    {
        public ResponseMCPCallArgumentsDoneEvent() { }
        public ResponseMCPCallArgumentsDoneEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, int outputIndex, string itemId, System.BinaryData arguments) { }
        public ResponseMCPCallArgumentsDoneEvent(int sequenceNumber, int outputIndex, string itemId, System.BinaryData arguments) { }
        public System.BinaryData Arguments { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallArgumentsDoneEvent DeserializeResponseMCPCallArgumentsDoneEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallArgumentsDoneEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallArgumentsDoneEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallArgumentsDoneEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallArgumentsDoneEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallArgumentsDoneEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallArgumentsDoneEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallArgumentsDoneEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallArgumentsDoneEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseMCPCallCompletedEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallCompletedEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallCompletedEvent>
    {
        public ResponseMCPCallCompletedEvent() { }
        public ResponseMCPCallCompletedEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public ResponseMCPCallCompletedEvent(int sequenceNumber) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallCompletedEvent DeserializeResponseMCPCallCompletedEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallCompletedEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallCompletedEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallCompletedEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallCompletedEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallCompletedEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallCompletedEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallCompletedEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallCompletedEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseMCPCallFailedEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallFailedEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallFailedEvent>
    {
        public ResponseMCPCallFailedEvent() { }
        public ResponseMCPCallFailedEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public ResponseMCPCallFailedEvent(int sequenceNumber) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallFailedEvent DeserializeResponseMCPCallFailedEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallFailedEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallFailedEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallFailedEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallFailedEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallFailedEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallFailedEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallFailedEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallFailedEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseMCPCallInProgressEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallInProgressEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallInProgressEvent>
    {
        public ResponseMCPCallInProgressEvent() { }
        public ResponseMCPCallInProgressEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, int outputIndex, string itemId) { }
        public ResponseMCPCallInProgressEvent(int sequenceNumber, int outputIndex, string itemId) { }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallInProgressEvent DeserializeResponseMCPCallInProgressEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallInProgressEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallInProgressEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallInProgressEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallInProgressEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallInProgressEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallInProgressEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallInProgressEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPCallInProgressEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseMCPListToolsCompletedEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsCompletedEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsCompletedEvent>
    {
        public ResponseMCPListToolsCompletedEvent() { }
        public ResponseMCPListToolsCompletedEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public ResponseMCPListToolsCompletedEvent(int sequenceNumber) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsCompletedEvent DeserializeResponseMCPListToolsCompletedEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsCompletedEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsCompletedEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsCompletedEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsCompletedEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsCompletedEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsCompletedEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsCompletedEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsCompletedEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseMCPListToolsFailedEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsFailedEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsFailedEvent>
    {
        public ResponseMCPListToolsFailedEvent() { }
        public ResponseMCPListToolsFailedEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public ResponseMCPListToolsFailedEvent(int sequenceNumber) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsFailedEvent DeserializeResponseMCPListToolsFailedEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsFailedEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsFailedEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsFailedEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsFailedEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsFailedEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsFailedEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsFailedEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsFailedEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseMCPListToolsInProgressEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsInProgressEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsInProgressEvent>
    {
        public ResponseMCPListToolsInProgressEvent() { }
        public ResponseMCPListToolsInProgressEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public ResponseMCPListToolsInProgressEvent(int sequenceNumber) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsInProgressEvent DeserializeResponseMCPListToolsInProgressEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsInProgressEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsInProgressEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsInProgressEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsInProgressEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsInProgressEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsInProgressEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsInProgressEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseMCPListToolsInProgressEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseOutputItemAddedEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseOutputItemAddedEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseOutputItemAddedEvent>
    {
        public ResponseOutputItemAddedEvent() { }
        public ResponseOutputItemAddedEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, int outputIndex, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource item) { }
        public ResponseOutputItemAddedEvent(int sequenceNumber, int outputIndex, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource item) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource Item { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseOutputItemAddedEvent DeserializeResponseOutputItemAddedEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseOutputItemAddedEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseOutputItemAddedEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseOutputItemAddedEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseOutputItemAddedEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseOutputItemAddedEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseOutputItemAddedEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseOutputItemAddedEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseOutputItemAddedEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseOutputItemDoneEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseOutputItemDoneEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseOutputItemDoneEvent>
    {
        public ResponseOutputItemDoneEvent() { }
        public ResponseOutputItemDoneEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, int outputIndex, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource item) { }
        public ResponseOutputItemDoneEvent(int sequenceNumber, int outputIndex, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource item) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource Item { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseOutputItemDoneEvent DeserializeResponseOutputItemDoneEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseOutputItemDoneEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseOutputItemDoneEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseOutputItemDoneEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseOutputItemDoneEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseOutputItemDoneEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseOutputItemDoneEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseOutputItemDoneEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseOutputItemDoneEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponsePromptVariables : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsePromptVariables>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsePromptVariables>
    {
        public ResponsePromptVariables() { }
        public ResponsePromptVariables(System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsePromptVariables DeserializeResponsePromptVariables(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsePromptVariables FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsePromptVariables System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsePromptVariables>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsePromptVariables>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsePromptVariables System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsePromptVariables>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsePromptVariables>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsePromptVariables>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseQueuedEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseQueuedEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseQueuedEvent>
    {
        public ResponseQueuedEvent() { }
        public ResponseQueuedEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.Responses.Response response) { }
        public ResponseQueuedEvent(int sequenceNumber, Azure.AI.AgentServer.Contracts.Generated.Responses.Response response) { }
        public Azure.AI.AgentServer.Contracts.Generated.Responses.Response Response { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseQueuedEvent DeserializeResponseQueuedEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseQueuedEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseQueuedEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseQueuedEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseQueuedEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseQueuedEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseQueuedEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseQueuedEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseQueuedEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseReasoningDeltaEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningDeltaEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningDeltaEvent>
    {
        public ResponseReasoningDeltaEvent() { }
        public ResponseReasoningDeltaEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string itemId, int outputIndex, int contentIndex, System.BinaryData delta) { }
        public ResponseReasoningDeltaEvent(int sequenceNumber, string itemId, int outputIndex, int contentIndex, System.BinaryData delta) { }
        public int ContentIndex { get { throw null; } }
        public System.BinaryData Delta { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningDeltaEvent DeserializeResponseReasoningDeltaEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningDeltaEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningDeltaEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningDeltaEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningDeltaEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningDeltaEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningDeltaEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningDeltaEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningDeltaEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseReasoningDoneEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningDoneEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningDoneEvent>
    {
        public ResponseReasoningDoneEvent() { }
        public ResponseReasoningDoneEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string itemId, int outputIndex, int contentIndex, string text) { }
        public ResponseReasoningDoneEvent(int sequenceNumber, string itemId, int outputIndex, int contentIndex, string text) { }
        public int ContentIndex { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        public string Text { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningDoneEvent DeserializeResponseReasoningDoneEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningDoneEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningDoneEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningDoneEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningDoneEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningDoneEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningDoneEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningDoneEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningDoneEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseReasoningSummaryDeltaEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryDeltaEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryDeltaEvent>
    {
        public ResponseReasoningSummaryDeltaEvent() { }
        public ResponseReasoningSummaryDeltaEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string itemId, int outputIndex, int summaryIndex, System.BinaryData delta) { }
        public ResponseReasoningSummaryDeltaEvent(int sequenceNumber, string itemId, int outputIndex, int summaryIndex, System.BinaryData delta) { }
        public System.BinaryData Delta { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        public int SummaryIndex { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryDeltaEvent DeserializeResponseReasoningSummaryDeltaEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryDeltaEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryDeltaEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryDeltaEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryDeltaEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryDeltaEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryDeltaEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryDeltaEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryDeltaEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseReasoningSummaryDoneEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryDoneEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryDoneEvent>
    {
        public ResponseReasoningSummaryDoneEvent() { }
        public ResponseReasoningSummaryDoneEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string itemId, int outputIndex, int summaryIndex, string text) { }
        public ResponseReasoningSummaryDoneEvent(int sequenceNumber, string itemId, int outputIndex, int summaryIndex, string text) { }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        public int SummaryIndex { get { throw null; } }
        public string Text { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryDoneEvent DeserializeResponseReasoningSummaryDoneEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryDoneEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryDoneEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryDoneEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryDoneEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryDoneEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryDoneEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryDoneEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryDoneEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseReasoningSummaryPartAddedEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryPartAddedEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryPartAddedEvent>
    {
        public ResponseReasoningSummaryPartAddedEvent() { }
        public ResponseReasoningSummaryPartAddedEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string itemId, int outputIndex, int summaryIndex, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart part) { }
        public ResponseReasoningSummaryPartAddedEvent(int sequenceNumber, string itemId, int outputIndex, int summaryIndex, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart part) { }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart Part { get { throw null; } }
        public int SummaryIndex { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryPartAddedEvent DeserializeResponseReasoningSummaryPartAddedEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryPartAddedEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryPartAddedEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryPartAddedEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryPartAddedEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryPartAddedEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryPartAddedEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryPartAddedEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryPartAddedEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseReasoningSummaryPartDoneEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryPartDoneEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryPartDoneEvent>
    {
        public ResponseReasoningSummaryPartDoneEvent() { }
        public ResponseReasoningSummaryPartDoneEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string itemId, int outputIndex, int summaryIndex, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart part) { }
        public ResponseReasoningSummaryPartDoneEvent(int sequenceNumber, string itemId, int outputIndex, int summaryIndex, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart part) { }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart Part { get { throw null; } }
        public int SummaryIndex { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryPartDoneEvent DeserializeResponseReasoningSummaryPartDoneEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryPartDoneEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryPartDoneEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryPartDoneEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryPartDoneEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryPartDoneEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryPartDoneEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryPartDoneEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryPartDoneEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseReasoningSummaryTextDeltaEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryTextDeltaEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryTextDeltaEvent>
    {
        public ResponseReasoningSummaryTextDeltaEvent() { }
        public ResponseReasoningSummaryTextDeltaEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string itemId, int outputIndex, int summaryIndex, string delta) { }
        public ResponseReasoningSummaryTextDeltaEvent(int sequenceNumber, string itemId, int outputIndex, int summaryIndex, string delta) { }
        public string Delta { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        public int SummaryIndex { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryTextDeltaEvent DeserializeResponseReasoningSummaryTextDeltaEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryTextDeltaEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryTextDeltaEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryTextDeltaEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryTextDeltaEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryTextDeltaEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryTextDeltaEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryTextDeltaEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryTextDeltaEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseReasoningSummaryTextDoneEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryTextDoneEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryTextDoneEvent>
    {
        public ResponseReasoningSummaryTextDoneEvent() { }
        public ResponseReasoningSummaryTextDoneEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string itemId, int outputIndex, int summaryIndex, string text) { }
        public ResponseReasoningSummaryTextDoneEvent(int sequenceNumber, string itemId, int outputIndex, int summaryIndex, string text) { }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        public int SummaryIndex { get { throw null; } }
        public string Text { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryTextDoneEvent DeserializeResponseReasoningSummaryTextDoneEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryTextDoneEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryTextDoneEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryTextDoneEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryTextDoneEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryTextDoneEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryTextDoneEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryTextDoneEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseReasoningSummaryTextDoneEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseRefusalDeltaEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseRefusalDeltaEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseRefusalDeltaEvent>
    {
        public ResponseRefusalDeltaEvent() { }
        public ResponseRefusalDeltaEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string itemId, int outputIndex, int contentIndex, string delta) { }
        public ResponseRefusalDeltaEvent(int sequenceNumber, string itemId, int outputIndex, int contentIndex, string delta) { }
        public int ContentIndex { get { throw null; } }
        public string Delta { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseRefusalDeltaEvent DeserializeResponseRefusalDeltaEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseRefusalDeltaEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseRefusalDeltaEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseRefusalDeltaEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseRefusalDeltaEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseRefusalDeltaEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseRefusalDeltaEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseRefusalDeltaEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseRefusalDeltaEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseRefusalDoneEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseRefusalDoneEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseRefusalDoneEvent>
    {
        public ResponseRefusalDoneEvent() { }
        public ResponseRefusalDoneEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string itemId, int outputIndex, int contentIndex, string refusal) { }
        public ResponseRefusalDoneEvent(int sequenceNumber, string itemId, int outputIndex, int contentIndex, string refusal) { }
        public int ContentIndex { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        public string Refusal { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseRefusalDoneEvent DeserializeResponseRefusalDoneEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseRefusalDoneEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseRefusalDoneEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseRefusalDoneEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseRefusalDoneEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseRefusalDoneEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseRefusalDoneEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseRefusalDoneEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseRefusalDoneEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponsesAssistantMessageItemParam : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemParam, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesAssistantMessageItemParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesAssistantMessageItemParam>
    {
        public ResponsesAssistantMessageItemParam() { }
        public ResponsesAssistantMessageItemParam(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageRole role, System.BinaryData content) { }
        public ResponsesAssistantMessageItemParam(System.BinaryData content) { }
        public System.BinaryData Content { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesAssistantMessageItemParam DeserializeResponsesAssistantMessageItemParam(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesAssistantMessageItemParam FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesAssistantMessageItemParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesAssistantMessageItemParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesAssistantMessageItemParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesAssistantMessageItemParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesAssistantMessageItemParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesAssistantMessageItemParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesAssistantMessageItemParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponsesAssistantMessageItemResource : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemResource, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesAssistantMessageItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesAssistantMessageItemResource>
    {
        public ResponsesAssistantMessageItemResource() { }
        public ResponsesAssistantMessageItemResource(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemResourceStatus status, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageRole role, System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent> content) { }
        public ResponsesAssistantMessageItemResource(string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemResourceStatus status, System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent> content, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy = null) { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent> Content { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesAssistantMessageItemResource DeserializeResponsesAssistantMessageItemResource(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesAssistantMessageItemResource FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesAssistantMessageItemResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesAssistantMessageItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesAssistantMessageItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesAssistantMessageItemResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesAssistantMessageItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesAssistantMessageItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesAssistantMessageItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponsesDeveloperMessageItemParam : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemParam, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesDeveloperMessageItemParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesDeveloperMessageItemParam>
    {
        public ResponsesDeveloperMessageItemParam() { }
        public ResponsesDeveloperMessageItemParam(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageRole role, System.BinaryData content) { }
        public ResponsesDeveloperMessageItemParam(System.BinaryData content) { }
        public System.BinaryData Content { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesDeveloperMessageItemParam DeserializeResponsesDeveloperMessageItemParam(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesDeveloperMessageItemParam FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesDeveloperMessageItemParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesDeveloperMessageItemParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesDeveloperMessageItemParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesDeveloperMessageItemParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesDeveloperMessageItemParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesDeveloperMessageItemParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesDeveloperMessageItemParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponsesDeveloperMessageItemResource : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemResource, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesDeveloperMessageItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesDeveloperMessageItemResource>
    {
        public ResponsesDeveloperMessageItemResource() { }
        public ResponsesDeveloperMessageItemResource(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemResourceStatus status, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageRole role, System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent> content) { }
        public ResponsesDeveloperMessageItemResource(string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemResourceStatus status, System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent> content, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy = null) { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent> Content { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesDeveloperMessageItemResource DeserializeResponsesDeveloperMessageItemResource(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesDeveloperMessageItemResource FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesDeveloperMessageItemResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesDeveloperMessageItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesDeveloperMessageItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesDeveloperMessageItemResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesDeveloperMessageItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesDeveloperMessageItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesDeveloperMessageItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponsesMessageItemParam : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemParam>
    {
        public ResponsesMessageItemParam() { }
        public ResponsesMessageItemParam(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageRole role) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageRole Role { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemParam DeserializeResponsesMessageItemParam(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemParam FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponsesMessageItemResource : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemResource>
    {
        public ResponsesMessageItemResource() { }
        public ResponsesMessageItemResource(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemResourceStatus status, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageRole role) { }
        public ResponsesMessageItemResource(string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemResourceStatus status) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageRole Role { get { throw null; } set { } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemResourceStatus Status { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemResource DeserializeResponsesMessageItemResource(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemResource FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum ResponsesMessageItemResourceStatus
    {
        InProgress = 0,
        Completed = 1,
        Incomplete = 2,
    }
    public static partial class ResponsesMessageItemResourceStatusExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemResourceStatus ToResponsesMessageItemResourceStatus(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemResourceStatus value) { throw null; }
    }
    public enum ResponsesMessageRole
    {
        System = 0,
        Developer = 1,
        User = 2,
        Assistant = 3,
    }
    public static partial class ResponsesMessageRoleExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageRole ToResponsesMessageRole(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageRole value) { throw null; }
    }
    public partial class ResponsesSystemMessageItemParam : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemParam, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesSystemMessageItemParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesSystemMessageItemParam>
    {
        public ResponsesSystemMessageItemParam() { }
        public ResponsesSystemMessageItemParam(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageRole role, System.BinaryData content) { }
        public ResponsesSystemMessageItemParam(System.BinaryData content) { }
        public System.BinaryData Content { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesSystemMessageItemParam DeserializeResponsesSystemMessageItemParam(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesSystemMessageItemParam FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesSystemMessageItemParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesSystemMessageItemParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesSystemMessageItemParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesSystemMessageItemParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesSystemMessageItemParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesSystemMessageItemParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesSystemMessageItemParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponsesSystemMessageItemResource : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemResource, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesSystemMessageItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesSystemMessageItemResource>
    {
        public ResponsesSystemMessageItemResource() { }
        public ResponsesSystemMessageItemResource(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemResourceStatus status, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageRole role, System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent> content) { }
        public ResponsesSystemMessageItemResource(string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemResourceStatus status, System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent> content, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy = null) { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent> Content { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesSystemMessageItemResource DeserializeResponsesSystemMessageItemResource(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesSystemMessageItemResource FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesSystemMessageItemResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesSystemMessageItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesSystemMessageItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesSystemMessageItemResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesSystemMessageItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesSystemMessageItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesSystemMessageItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum ResponseStatus
    {
        Completed = 0,
        Failed = 1,
        InProgress = 2,
        Cancelled = 3,
        Queued = 4,
        Incomplete = 5,
    }
    public static partial class ResponseStatusExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStatus ToResponseStatus(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStatus value) { throw null; }
    }
    [System.ClientModel.Primitives.PersistableModelProxyAttribute(typeof(Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownResponseStreamEvent))]
    public abstract partial class ResponseStreamEvent : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent>
    {
        public ResponseStreamEvent() { }
        public ResponseStreamEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        protected ResponseStreamEvent(int sequenceNumber) { }
        public int SequenceNumber { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType Type { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent DeserializeResponseStreamEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResponseStreamEventType : System.IEquatable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResponseStreamEventType(string value) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType Error { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseAudioDelta { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseAudioDone { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseAudioTranscriptDelta { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseAudioTranscriptDone { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseCodeInterpreterCallCodeDelta { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseCodeInterpreterCallCodeDone { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseCodeInterpreterCallCompleted { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseCodeInterpreterCallInProgress { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseCodeInterpreterCallInterpreting { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseCompleted { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseContentPartAdded { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseContentPartDone { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseCreated { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseFailed { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseFileSearchCallCompleted { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseFileSearchCallInProgress { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseFileSearchCallSearching { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseFunctionCallArgumentsDelta { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseFunctionCallArgumentsDone { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseImageGenerationCallCompleted { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseImageGenerationCallGenerating { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseImageGenerationCallInProgress { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseImageGenerationCallPartialImage { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseIncomplete { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseInProgress { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseMcpCallArgumentsDelta { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseMcpCallArgumentsDone { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseMcpCallCompleted { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseMcpCallFailed { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseMcpCallInProgress { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseMcpListToolsCompleted { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseMcpListToolsFailed { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseMcpListToolsInProgress { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseOutputItemAdded { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseOutputItemDone { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseOutputTextAnnotationAdded { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseOutputTextDelta { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseOutputTextDone { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseQueued { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseReasoningDelta { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseReasoningDone { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseReasoningSummaryDelta { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseReasoningSummaryDone { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseReasoningSummaryPartAdded { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseReasoningSummaryPartDone { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseReasoningSummaryTextDelta { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseReasoningSummaryTextDone { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseRefusalDelta { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseRefusalDone { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseWebSearchCallCompleted { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseWebSearchCallInProgress { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType ResponseWebSearchCallSearching { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType left, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType left, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResponsesUserMessageItemParam : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemParam, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesUserMessageItemParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesUserMessageItemParam>
    {
        public ResponsesUserMessageItemParam() { }
        public ResponsesUserMessageItemParam(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageRole role, System.BinaryData content) { }
        public ResponsesUserMessageItemParam(System.BinaryData content) { }
        public System.BinaryData Content { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesUserMessageItemParam DeserializeResponsesUserMessageItemParam(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesUserMessageItemParam FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesUserMessageItemParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesUserMessageItemParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesUserMessageItemParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesUserMessageItemParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesUserMessageItemParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesUserMessageItemParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesUserMessageItemParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponsesUserMessageItemResource : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemResource, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesUserMessageItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesUserMessageItemResource>
    {
        public ResponsesUserMessageItemResource() { }
        public ResponsesUserMessageItemResource(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemResourceStatus status, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageRole role, System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent> content) { }
        public ResponsesUserMessageItemResource(string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesMessageItemResourceStatus status, System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent> content, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy = null) { }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent> Content { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesUserMessageItemResource DeserializeResponsesUserMessageItemResource(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesUserMessageItemResource FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesUserMessageItemResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesUserMessageItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesUserMessageItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesUserMessageItemResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesUserMessageItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesUserMessageItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponsesUserMessageItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseTextDeltaEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextDeltaEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextDeltaEvent>
    {
        public ResponseTextDeltaEvent() { }
        public ResponseTextDeltaEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string itemId, int outputIndex, int contentIndex, string delta) { }
        public ResponseTextDeltaEvent(int sequenceNumber, string itemId, int outputIndex, int contentIndex, string delta) { }
        public int ContentIndex { get { throw null; } }
        public string Delta { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextDeltaEvent DeserializeResponseTextDeltaEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextDeltaEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextDeltaEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextDeltaEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextDeltaEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextDeltaEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextDeltaEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextDeltaEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextDeltaEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseTextDoneEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextDoneEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextDoneEvent>
    {
        public ResponseTextDoneEvent() { }
        public ResponseTextDoneEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string itemId, int outputIndex, int contentIndex, string text) { }
        public ResponseTextDoneEvent(int sequenceNumber, string itemId, int outputIndex, int contentIndex, string text) { }
        public int ContentIndex { get { throw null; } }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        public string Text { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextDoneEvent DeserializeResponseTextDoneEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextDoneEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextDoneEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextDoneEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextDoneEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextDoneEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextDoneEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextDoneEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextDoneEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.ClientModel.Primitives.PersistableModelProxyAttribute(typeof(Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownResponseTextFormatConfiguration))]
    public abstract partial class ResponseTextFormatConfiguration : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfiguration>
    {
        protected ResponseTextFormatConfiguration() { }
        public ResponseTextFormatConfiguration(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationType Type { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfiguration DeserializeResponseTextFormatConfiguration(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfiguration FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseTextFormatConfigurationJsonObject : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfiguration, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationJsonObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationJsonObject>
    {
        public ResponseTextFormatConfigurationJsonObject() { }
        public ResponseTextFormatConfigurationJsonObject(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationJsonObject DeserializeResponseTextFormatConfigurationJsonObject(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationJsonObject FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationJsonObject System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationJsonObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationJsonObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationJsonObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationJsonObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationJsonObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationJsonObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseTextFormatConfigurationJsonSchema : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfiguration, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationJsonSchema>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationJsonSchema>
    {
        public ResponseTextFormatConfigurationJsonSchema() { }
        public ResponseTextFormatConfigurationJsonSchema(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string description, string name, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFormatJsonSchemaSchema schema, bool? strict) { }
        public ResponseTextFormatConfigurationJsonSchema(string name, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFormatJsonSchemaSchema schema) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseFormatJsonSchemaSchema Schema { get { throw null; } set { } }
        public bool? Strict { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationJsonSchema DeserializeResponseTextFormatConfigurationJsonSchema(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationJsonSchema FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationJsonSchema System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationJsonSchema>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationJsonSchema>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationJsonSchema System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationJsonSchema>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationJsonSchema>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationJsonSchema>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseTextFormatConfigurationText : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfiguration, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationText>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationText>
    {
        public ResponseTextFormatConfigurationText() { }
        public ResponseTextFormatConfigurationText(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationText DeserializeResponseTextFormatConfigurationText(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationText FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationText System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationText>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationText>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationText System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationText>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationText>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationText>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResponseTextFormatConfigurationType : System.IEquatable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResponseTextFormatConfigurationType(string value) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationType JsonObject { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationType JsonSchema { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationType Text { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationType left, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationType right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationType (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationType left, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResponseUsage : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsage>
    {
        public ResponseUsage() { }
        public ResponseUsage(int inputTokens, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageInputTokensDetails inputTokensDetails, int outputTokens, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageOutputTokensDetails outputTokensDetails, int totalTokens) { }
        public ResponseUsage(int inputTokens, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageInputTokensDetails inputTokensDetails, int outputTokens, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageOutputTokensDetails outputTokensDetails, int totalTokens, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public int InputTokens { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageInputTokensDetails InputTokensDetails { get { throw null; } }
        public int OutputTokens { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageOutputTokensDetails OutputTokensDetails { get { throw null; } }
        public int TotalTokens { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsage DeserializeResponseUsage(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsage FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsage System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsage System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseUsageInputTokensDetails : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageInputTokensDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageInputTokensDetails>
    {
        public ResponseUsageInputTokensDetails() { }
        public ResponseUsageInputTokensDetails(int cachedTokens) { }
        public ResponseUsageInputTokensDetails(int cachedTokens, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public int CachedTokens { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageInputTokensDetails DeserializeResponseUsageInputTokensDetails(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageInputTokensDetails FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageInputTokensDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageInputTokensDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageInputTokensDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageInputTokensDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageInputTokensDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageInputTokensDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageInputTokensDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseUsageOutputTokensDetails : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageOutputTokensDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageOutputTokensDetails>
    {
        public ResponseUsageOutputTokensDetails() { }
        public ResponseUsageOutputTokensDetails(int reasoningTokens) { }
        public ResponseUsageOutputTokensDetails(int reasoningTokens, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public int ReasoningTokens { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageOutputTokensDetails DeserializeResponseUsageOutputTokensDetails(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageOutputTokensDetails FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageOutputTokensDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageOutputTokensDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageOutputTokensDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageOutputTokensDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageOutputTokensDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageOutputTokensDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsageOutputTokensDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseWebSearchCallCompletedEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallCompletedEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallCompletedEvent>
    {
        public ResponseWebSearchCallCompletedEvent() { }
        public ResponseWebSearchCallCompletedEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, int outputIndex, string itemId) { }
        public ResponseWebSearchCallCompletedEvent(int sequenceNumber, int outputIndex, string itemId) { }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallCompletedEvent DeserializeResponseWebSearchCallCompletedEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallCompletedEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallCompletedEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallCompletedEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallCompletedEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallCompletedEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallCompletedEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallCompletedEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallCompletedEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseWebSearchCallInProgressEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallInProgressEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallInProgressEvent>
    {
        public ResponseWebSearchCallInProgressEvent() { }
        public ResponseWebSearchCallInProgressEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, int outputIndex, string itemId) { }
        public ResponseWebSearchCallInProgressEvent(int sequenceNumber, int outputIndex, string itemId) { }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallInProgressEvent DeserializeResponseWebSearchCallInProgressEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallInProgressEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallInProgressEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallInProgressEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallInProgressEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallInProgressEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallInProgressEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallInProgressEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallInProgressEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ResponseWebSearchCallSearchingEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallSearchingEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallSearchingEvent>
    {
        public ResponseWebSearchCallSearchingEvent() { }
        public ResponseWebSearchCallSearchingEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, int outputIndex, string itemId) { }
        public ResponseWebSearchCallSearchingEvent(int sequenceNumber, int outputIndex, string itemId) { }
        public string ItemId { get { throw null; } }
        public int OutputIndex { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallSearchingEvent DeserializeResponseWebSearchCallSearchingEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallSearchingEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallSearchingEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallSearchingEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallSearchingEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallSearchingEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallSearchingEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallSearchingEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseWebSearchCallSearchingEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum ServiceTier
    {
        Auto = 0,
        Default = 1,
        Flex = 2,
        Scale = 3,
        Priority = 4,
    }
    public static partial class ServiceTierExtensions
    {
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.ServiceTier value) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ServiceTier ToServiceTier(this string value) { throw null; }
    }
    public partial class SharepointAgentTool : Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.SharepointAgentTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.SharepointAgentTool>
    {
        public SharepointAgentTool() { }
        public SharepointAgentTool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.SharepointGroundingToolParameters sharepointGroundingPreview) { }
        public SharepointAgentTool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.SharepointGroundingToolParameters sharepointGroundingPreview) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.SharepointGroundingToolParameters SharepointGroundingPreview { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.SharepointAgentTool DeserializeSharepointAgentTool(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.SharepointAgentTool FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.SharepointAgentTool System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.SharepointAgentTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.SharepointAgentTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.SharepointAgentTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.SharepointAgentTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.SharepointAgentTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.SharepointAgentTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class SharepointGroundingToolParameters : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.SharepointGroundingToolParameters>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.SharepointGroundingToolParameters>
    {
        public SharepointGroundingToolParameters() { }
        public SharepointGroundingToolParameters(System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnection> projectConnections, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnection> ProjectConnections { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.SharepointGroundingToolParameters DeserializeSharepointGroundingToolParameters(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.SharepointGroundingToolParameters FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.SharepointGroundingToolParameters System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.SharepointGroundingToolParameters>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.SharepointGroundingToolParameters>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.SharepointGroundingToolParameters System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.SharepointGroundingToolParameters>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.SharepointGroundingToolParameters>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.SharepointGroundingToolParameters>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class StructuredInputDefinition : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredInputDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredInputDefinition>
    {
        public StructuredInputDefinition() { }
        public StructuredInputDefinition(string description, System.BinaryData defaultValue, System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolArgumentBinding> toolArgumentBindings, System.BinaryData schema, bool? required, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public System.BinaryData DefaultValue { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public bool? Required { get { throw null; } set { } }
        public System.BinaryData Schema { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolArgumentBinding> ToolArgumentBindings { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredInputDefinition DeserializeStructuredInputDefinition(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredInputDefinition FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredInputDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredInputDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredInputDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredInputDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredInputDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredInputDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredInputDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class StructuredOutputDefinition : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredOutputDefinition>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredOutputDefinition>
    {
        public StructuredOutputDefinition() { }
        public StructuredOutputDefinition(string name, string description, System.Collections.Generic.IDictionary<string, System.BinaryData> schema, bool? strict) { }
        public StructuredOutputDefinition(string name, string description, System.Collections.Generic.IDictionary<string, System.BinaryData> schema, bool? strict, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public string Description { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> Schema { get { throw null; } }
        public bool? Strict { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredOutputDefinition DeserializeStructuredOutputDefinition(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredOutputDefinition FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredOutputDefinition System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredOutputDefinition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredOutputDefinition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredOutputDefinition System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredOutputDefinition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredOutputDefinition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredOutputDefinition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class StructuredOutputsItemResource : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredOutputsItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredOutputsItemResource>
    {
        public StructuredOutputsItemResource() { }
        public StructuredOutputsItemResource(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, System.BinaryData output) { }
        public StructuredOutputsItemResource(string id, System.BinaryData output) { }
        public System.BinaryData Output { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredOutputsItemResource DeserializeStructuredOutputsItemResource(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredOutputsItemResource FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredOutputsItemResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredOutputsItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredOutputsItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredOutputsItemResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredOutputsItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredOutputsItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.StructuredOutputsItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.ClientModel.Primitives.PersistableModelProxyAttribute(typeof(Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownTool))]
    public abstract partial class Tool : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool>
    {
        protected Tool() { }
        public Tool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType Type { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool DeserializeTool(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ToolArgumentBinding : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolArgumentBinding>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolArgumentBinding>
    {
        public ToolArgumentBinding() { }
        public ToolArgumentBinding(string argumentName) { }
        public ToolArgumentBinding(string toolName, string argumentName, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public string ArgumentName { get { throw null; } set { } }
        public string ToolName { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolArgumentBinding DeserializeToolArgumentBinding(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolArgumentBinding FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolArgumentBinding System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolArgumentBinding>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolArgumentBinding>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolArgumentBinding System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolArgumentBinding>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolArgumentBinding>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolArgumentBinding>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.ClientModel.Primitives.PersistableModelProxyAttribute(typeof(Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownToolChoiceObject))]
    public abstract partial class ToolChoiceObject : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObject>
    {
        protected ToolChoiceObject() { }
        public ToolChoiceObject(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectType Type { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObject DeserializeToolChoiceObject(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObject FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObject System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ToolChoiceObjectCodeInterpreter : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObject, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectCodeInterpreter>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectCodeInterpreter>
    {
        public ToolChoiceObjectCodeInterpreter() { }
        public ToolChoiceObjectCodeInterpreter(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectCodeInterpreter DeserializeToolChoiceObjectCodeInterpreter(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectCodeInterpreter FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectCodeInterpreter System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectCodeInterpreter>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectCodeInterpreter>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectCodeInterpreter System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectCodeInterpreter>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectCodeInterpreter>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectCodeInterpreter>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ToolChoiceObjectComputer : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObject, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectComputer>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectComputer>
    {
        public ToolChoiceObjectComputer() { }
        public ToolChoiceObjectComputer(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectComputer DeserializeToolChoiceObjectComputer(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectComputer FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectComputer System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectComputer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectComputer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectComputer System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectComputer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectComputer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectComputer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ToolChoiceObjectFileSearch : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObject, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectFileSearch>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectFileSearch>
    {
        public ToolChoiceObjectFileSearch() { }
        public ToolChoiceObjectFileSearch(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectFileSearch DeserializeToolChoiceObjectFileSearch(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectFileSearch FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectFileSearch System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectFileSearch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectFileSearch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectFileSearch System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectFileSearch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectFileSearch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectFileSearch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ToolChoiceObjectFunction : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObject, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectFunction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectFunction>
    {
        public ToolChoiceObjectFunction() { }
        public ToolChoiceObjectFunction(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string name) { }
        public ToolChoiceObjectFunction(string name) { }
        public string Name { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectFunction DeserializeToolChoiceObjectFunction(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectFunction FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectFunction System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectFunction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectFunction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectFunction System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectFunction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectFunction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectFunction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ToolChoiceObjectImageGen : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObject, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectImageGen>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectImageGen>
    {
        public ToolChoiceObjectImageGen() { }
        public ToolChoiceObjectImageGen(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectImageGen DeserializeToolChoiceObjectImageGen(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectImageGen FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectImageGen System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectImageGen>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectImageGen>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectImageGen System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectImageGen>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectImageGen>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectImageGen>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ToolChoiceObjectMCP : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObject, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectMCP>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectMCP>
    {
        public ToolChoiceObjectMCP() { }
        public ToolChoiceObjectMCP(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string serverLabel, string name) { }
        public ToolChoiceObjectMCP(string serverLabel) { }
        public string Name { get { throw null; } set { } }
        public string ServerLabel { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectMCP DeserializeToolChoiceObjectMCP(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectMCP FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectMCP System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectMCP>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectMCP>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectMCP System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectMCP>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectMCP>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectMCP>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ToolChoiceObjectType : System.IEquatable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ToolChoiceObjectType(string value) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectType CodeInterpreter { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectType Computer { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectType FileSearch { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectType Function { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectType ImageGeneration { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectType Mcp { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectType WebSearch { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectType left, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectType right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectType (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectType left, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ToolChoiceObjectWebSearch : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObject, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectWebSearch>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectWebSearch>
    {
        public ToolChoiceObjectWebSearch() { }
        public ToolChoiceObjectWebSearch(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectWebSearch DeserializeToolChoiceObjectWebSearch(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectWebSearch FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectWebSearch System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectWebSearch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectWebSearch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectWebSearch System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectWebSearch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectWebSearch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectWebSearch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum ToolChoiceOptions
    {
        None = 0,
        Auto = 1,
        Required = 2,
    }
    public static partial class ToolChoiceOptionsExtensions
    {
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceOptions value) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceOptions ToToolChoiceOptions(this string value) { throw null; }
    }
    public partial class ToolProjectConnection : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnection>
    {
        public ToolProjectConnection() { }
        public ToolProjectConnection(string projectConnectionId) { }
        public ToolProjectConnection(string projectConnectionId, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public string ProjectConnectionId { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnection DeserializeToolProjectConnection(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnection FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnection System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnection System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class ToolProjectConnectionList : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnectionList>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnectionList>
    {
        public ToolProjectConnectionList() { }
        public ToolProjectConnectionList(System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnection> projectConnections, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public System.Collections.Generic.IList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnection> ProjectConnections { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnectionList DeserializeToolProjectConnectionList(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnectionList FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnectionList System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnectionList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnectionList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnectionList System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnectionList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnectionList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolProjectConnectionList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ToolType : System.IEquatable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ToolType(string value) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType A2aPreview { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType AzureAiSearch { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType AzureFunction { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType BingCustomSearchPreview { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType BingGrounding { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType BrowserAutomationPreview { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType CaptureStructuredOutputs { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType CodeInterpreter { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType ComputerUsePreview { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType FabricDataagentPreview { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType FileSearch { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType Function { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType ImageGeneration { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType LocalShell { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType Mcp { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType MemorySearch { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType Openapi { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType SharepointGroundingPreview { get { throw null; } }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType WebSearchPreview { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType left, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType left, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TopLogProb : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.TopLogProb>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.TopLogProb>
    {
        public TopLogProb() { }
        public TopLogProb(string token, float logprob, System.Collections.Generic.IEnumerable<int> bytes) { }
        public TopLogProb(string token, float logprob, System.Collections.Generic.IList<int> bytes, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public System.Collections.Generic.IList<int> Bytes { get { throw null; } }
        public float Logprob { get { throw null; } set { } }
        public string Token { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.TopLogProb DeserializeTopLogProb(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.TopLogProb FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.TopLogProb System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.TopLogProb>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.TopLogProb>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.TopLogProb System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.TopLogProb>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.TopLogProb>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.TopLogProb>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class UnknownAnnotation : Azure.AI.AgentServer.Contracts.Generated.OpenAI.Annotation, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Annotation>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Annotation>
    {
        public UnknownAnnotation() { }
        public UnknownAnnotation(Azure.AI.AgentServer.Contracts.Generated.OpenAI.AnnotationType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownAnnotation DeserializeUnknownAnnotation(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownAnnotation FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.Annotation System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Annotation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Annotation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.Annotation System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Annotation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Annotation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Annotation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class UnknownCodeInterpreterOutput : Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutput, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutput>
    {
        public UnknownCodeInterpreterOutput() { }
        public UnknownCodeInterpreterOutput(Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutputType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownCodeInterpreterOutput DeserializeUnknownCodeInterpreterOutput(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownCodeInterpreterOutput FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.CodeInterpreterOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class UnknownComputerAction : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction>
    {
        public UnknownComputerAction() { }
        public UnknownComputerAction(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerActionType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownComputerAction DeserializeUnknownComputerAction(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownComputerAction FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class UnknownComputerToolCallOutputItemOutput : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutput, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutput>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutput>
    {
        public UnknownComputerToolCallOutputItemOutput() { }
        public UnknownComputerToolCallOutputItemOutput(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutputType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownComputerToolCallOutputItemOutput DeserializeUnknownComputerToolCallOutputItemOutput(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownComputerToolCallOutputItemOutput FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutput System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutput System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ComputerToolCallOutputItemOutput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class UnknownItemContent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent>
    {
        public UnknownItemContent() { }
        public UnknownItemContent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContentType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownItemContent DeserializeUnknownItemContent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownItemContent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class UnknownItemParam : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam>
    {
        public UnknownItemParam() { }
        public UnknownItemParam(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownItemParam DeserializeUnknownItemParam(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownItemParam FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class UnknownItemResource : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource>
    {
        public UnknownItemResource() { }
        public UnknownItemResource(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownItemResource DeserializeUnknownItemResource(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownItemResource FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class UnknownLocation : Azure.AI.AgentServer.Contracts.Generated.OpenAI.Location, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Location>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Location>
    {
        public UnknownLocation() { }
        public UnknownLocation(Azure.AI.AgentServer.Contracts.Generated.OpenAI.LocationType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownLocation DeserializeUnknownLocation(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownLocation FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.Location System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Location>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Location>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.Location System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Location>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Location>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Location>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class UnknownOpenApiAuthDetails : Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthDetails, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthDetails>
    {
        public UnknownOpenApiAuthDetails() { }
        public UnknownOpenApiAuthDetails(Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownOpenApiAuthDetails DeserializeUnknownOpenApiAuthDetails(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownOpenApiAuthDetails FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthDetails System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthDetails System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.OpenApiAuthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class UnknownReasoningItemSummaryPart : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart>
    {
        public UnknownReasoningItemSummaryPart() { }
        public UnknownReasoningItemSummaryPart(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPartType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownReasoningItemSummaryPart DeserializeUnknownReasoningItemSummaryPart(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownReasoningItemSummaryPart FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ReasoningItemSummaryPart>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class UnknownResponseStreamEvent : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent>
    {
        public UnknownResponseStreamEvent() { }
        public UnknownResponseStreamEvent(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEventType type, int sequenceNumber, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownResponseStreamEvent DeserializeUnknownResponseStreamEvent(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownResponseStreamEvent FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStreamEvent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class UnknownResponseTextFormatConfiguration : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfiguration, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfiguration>
    {
        public UnknownResponseTextFormatConfiguration() { }
        public UnknownResponseTextFormatConfiguration(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfigurationType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownResponseTextFormatConfiguration DeserializeUnknownResponseTextFormatConfiguration(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownResponseTextFormatConfiguration FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfiguration System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class UnknownTool : Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool>
    {
        public UnknownTool() { }
        public UnknownTool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownTool DeserializeUnknownTool(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownTool FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class UnknownToolChoiceObject : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObject, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObject>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObject>
    {
        public UnknownToolChoiceObject() { }
        public UnknownToolChoiceObject(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObjectType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownToolChoiceObject DeserializeUnknownToolChoiceObject(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownToolChoiceObject FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObject System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObject System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolChoiceObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class UnknownWebSearchAction : Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchAction, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchAction>
    {
        public UnknownWebSearchAction() { }
        public UnknownWebSearchAction(Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownWebSearchAction DeserializeUnknownWebSearchAction(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownWebSearchAction FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchAction System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class VectorStoreFileAttributes : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.VectorStoreFileAttributes>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.VectorStoreFileAttributes>
    {
        public VectorStoreFileAttributes() { }
        public VectorStoreFileAttributes(System.Collections.Generic.IDictionary<string, System.BinaryData> additionalProperties) { }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> AdditionalProperties { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.VectorStoreFileAttributes DeserializeVectorStoreFileAttributes(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.VectorStoreFileAttributes FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.VectorStoreFileAttributes System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.VectorStoreFileAttributes>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.VectorStoreFileAttributes>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.VectorStoreFileAttributes System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.VectorStoreFileAttributes>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.VectorStoreFileAttributes>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.VectorStoreFileAttributes>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.ClientModel.Primitives.PersistableModelProxyAttribute(typeof(Azure.AI.AgentServer.Contracts.Generated.OpenAI.UnknownWebSearchAction))]
    public abstract partial class WebSearchAction : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchAction>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchAction>
    {
        protected WebSearchAction() { }
        public WebSearchAction(Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionType Type { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchAction DeserializeWebSearchAction(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchAction FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchAction System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchAction>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchAction>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchAction System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchAction>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchAction>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchAction>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class WebSearchActionFind : Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchAction, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionFind>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionFind>
    {
        public WebSearchActionFind() { }
        public WebSearchActionFind(Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, System.Uri url, string pattern) { }
        public WebSearchActionFind(System.Uri url, string pattern) { }
        public string Pattern { get { throw null; } set { } }
        public System.Uri Url { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionFind DeserializeWebSearchActionFind(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionFind FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionFind System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionFind>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionFind>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionFind System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionFind>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionFind>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionFind>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class WebSearchActionOpenPage : Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchAction, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionOpenPage>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionOpenPage>
    {
        public WebSearchActionOpenPage() { }
        public WebSearchActionOpenPage(Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, System.Uri url) { }
        public WebSearchActionOpenPage(System.Uri url) { }
        public System.Uri Url { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionOpenPage DeserializeWebSearchActionOpenPage(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionOpenPage FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionOpenPage System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionOpenPage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionOpenPage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionOpenPage System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionOpenPage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionOpenPage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionOpenPage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class WebSearchActionSearch : Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchAction, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionSearch>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionSearch>
    {
        public WebSearchActionSearch() { }
        public WebSearchActionSearch(Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, string query) { }
        public WebSearchActionSearch(string query) { }
        public string Query { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionSearch DeserializeWebSearchActionSearch(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionSearch FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionSearch System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionSearch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionSearch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionSearch System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionSearch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionSearch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionSearch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum WebSearchActionType
    {
        Search = 0,
        OpenPage = 1,
        Find = 2,
    }
    public static partial class WebSearchActionTypeExtensions
    {
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionType value) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchActionType ToWebSearchActionType(this string value) { throw null; }
    }
    public partial class WebSearchPreviewTool : Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchPreviewTool>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchPreviewTool>
    {
        public WebSearchPreviewTool() { }
        public WebSearchPreviewTool(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ToolType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.Location userLocation, Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchPreviewToolSearchContextSize? searchContextSize) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchPreviewToolSearchContextSize? SearchContextSize { get { throw null; } set { } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.Location UserLocation { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchPreviewTool DeserializeWebSearchPreviewTool(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchPreviewTool FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchPreviewTool System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchPreviewTool>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchPreviewTool>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchPreviewTool System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchPreviewTool>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchPreviewTool>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchPreviewTool>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum WebSearchPreviewToolSearchContextSize
    {
        Low = 0,
        Medium = 1,
        High = 2,
    }
    public static partial class WebSearchPreviewToolSearchContextSizeExtensions
    {
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchPreviewToolSearchContextSize value) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchPreviewToolSearchContextSize ToWebSearchPreviewToolSearchContextSize(this string value) { throw null; }
    }
    public partial class WebSearchToolCallItemParam : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemParam, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchToolCallItemParam>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchToolCallItemParam>
    {
        public WebSearchToolCallItemParam() { }
        public WebSearchToolCallItemParam(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchAction action) { }
        public WebSearchToolCallItemParam(Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchAction action) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchAction Action { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchToolCallItemParam DeserializeWebSearchToolCallItemParam(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchToolCallItemParam FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchToolCallItemParam System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchToolCallItemParam>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchToolCallItemParam>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchToolCallItemParam System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchToolCallItemParam>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchToolCallItemParam>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchToolCallItemParam>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class WebSearchToolCallItemResource : Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource, Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchToolCallItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchToolCallItemResource>
    {
        public WebSearchToolCallItemResource() { }
        public WebSearchToolCallItemResource(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemType type, string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.CreatedBy createdBy, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData, Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchToolCallItemResourceStatus status, Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchAction action) { }
        public WebSearchToolCallItemResource(string id, Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchToolCallItemResourceStatus status, Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchAction action) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchAction Action { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchToolCallItemResourceStatus Status { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchToolCallItemResource DeserializeWebSearchToolCallItemResource(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static new Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchToolCallItemResource FromResponse(Azure.Response response) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchToolCallItemResource System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchToolCallItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchToolCallItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchToolCallItemResource System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchToolCallItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchToolCallItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchToolCallItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public override Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum WebSearchToolCallItemResourceStatus
    {
        InProgress = 0,
        Searching = 1,
        Completed = 2,
        Failed = 3,
    }
    public static partial class WebSearchToolCallItemResourceStatusExtensions
    {
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchToolCallItemResourceStatus value) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.OpenAI.WebSearchToolCallItemResourceStatus ToWebSearchToolCallItemResourceStatus(this string value) { throw null; }
    }
}
namespace Azure.AI.AgentServer.Contracts.Generated.Responses
{
    public partial class CreateResponseRequest : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest>
    {
        public CreateResponseRequest() { }
        public CreateResponseRequest(System.Collections.Generic.IReadOnlyDictionary<string, string> metadata, float? temperature, float? topP, string user, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ServiceTier? serviceTier, int? topLogprobs, string previousResponseId, string model, Azure.AI.AgentServer.Contracts.Generated.OpenAI.Reasoning reasoning, bool? background, int? maxOutputTokens, int? maxToolCalls, Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequestText text, System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool> tools, System.BinaryData toolChoice, Azure.AI.AgentServer.Contracts.Generated.OpenAI.Prompt prompt, Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequestTruncation? truncation, System.BinaryData input, System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Includable> include, bool? parallelToolCalls, bool? store, string instructions, bool? stream, System.BinaryData conversation, Azure.AI.AgentServer.Contracts.Generated.Agents.AgentReference agent, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> structuredInputs, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Azure.AI.AgentServer.Contracts.Generated.Agents.AgentReference Agent { get { throw null; } set { } }
        public bool? Background { get { throw null; } }
        public System.BinaryData Conversation { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Includable> Include { get { throw null; } }
        public System.BinaryData Input { get { throw null; } set { } }
        public string Instructions { get { throw null; } set { } }
        public int? MaxOutputTokens { get { throw null; } }
        public int? MaxToolCalls { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } set { } }
        public string Model { get { throw null; } set { } }
        public bool? ParallelToolCalls { get { throw null; } }
        public string PreviousResponseId { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.Prompt Prompt { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.Reasoning Reasoning { get { throw null; } set { } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ServiceTier? ServiceTier { get { throw null; } }
        public bool? Store { get { throw null; } }
        public bool? Stream { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> StructuredInputs { get { throw null; } set { } }
        public float? Temperature { get { throw null; } set { } }
        public Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequestText Text { get { throw null; } set { } }
        public System.BinaryData ToolChoice { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool> Tools { get { throw null; } set { } }
        public int? TopLogprobs { get { throw null; } }
        public float? TopP { get { throw null; } set { } }
        public Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequestTruncation? Truncation { get { throw null; } }
        public string User { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest DeserializeCreateResponseRequest(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequest>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public partial class CreateResponseRequestText : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequestText>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequestText>
    {
        public CreateResponseRequestText() { }
        public CreateResponseRequestText(Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfiguration format, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseTextFormatConfiguration Format { get { throw null; } set { } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequestText DeserializeCreateResponseRequestText(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequestText FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequestText System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequestText>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequestText>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequestText System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequestText>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequestText>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequestText>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    public enum CreateResponseRequestTruncation
    {
        Auto = 0,
        Disabled = 1,
    }
    public static partial class CreateResponseRequestTruncationExtensions
    {
        public static Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequestTruncation ToCreateResponseRequestTruncation(this string value) { throw null; }
        public static string ToSerialString(this Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequestTruncation value) { throw null; }
    }
    public partial class Response : Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable, System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.Responses.Response>, System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Responses.Response>
    {
        public Response() { }
        public Response(System.Collections.Generic.IReadOnlyDictionary<string, string> metadata, float? temperature, float? topP, string user, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ServiceTier? serviceTier, int? topLogprobs, string previousResponseId, string model, Azure.AI.AgentServer.Contracts.Generated.OpenAI.Reasoning reasoning, bool? background, int? maxOutputTokens, int? maxToolCalls, Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequestText text, System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool> tools, System.BinaryData toolChoice, Azure.AI.AgentServer.Contracts.Generated.OpenAI.Prompt prompt, Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequestTruncation? truncation, string id, Azure.AI.AgentServer.Contracts.Generated.Responses.ResponseObject @object, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStatus? status, System.DateTimeOffset createdAt, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseError error, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseIncompleteDetails1 incompleteDetails, System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource> output, System.BinaryData instructions, string outputText, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsage usage, bool parallelToolCalls, Azure.AI.AgentServer.Contracts.Generated.Conversations.ResponseConversation1 conversation, Azure.AI.AgentServer.Contracts.Generated.Agents.AgentId agent, System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> structuredInputs, System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public Response(System.Collections.Generic.IReadOnlyDictionary<string, string> metadata, float? temperature, float? topP, string user, string id, System.DateTimeOffset createdAt, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseError error, Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseIncompleteDetails1 incompleteDetails, System.Collections.Generic.IEnumerable<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource> output, System.BinaryData instructions, bool parallelToolCalls, Azure.AI.AgentServer.Contracts.Generated.Conversations.ResponseConversation1 conversation) { }
        public Azure.AI.AgentServer.Contracts.Generated.Agents.AgentId Agent { get { throw null; } }
        public bool? Background { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.Conversations.ResponseConversation1 Conversation { get { throw null; } }
        public System.DateTimeOffset CreatedAt { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseError Error { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseIncompleteDetails1 IncompleteDetails { get { throw null; } }
        public System.BinaryData Instructions { get { throw null; } }
        public int? MaxOutputTokens { get { throw null; } }
        public int? MaxToolCalls { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Metadata { get { throw null; } }
        public string Model { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.Responses.ResponseObject Object { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.ItemResource> Output { get { throw null; } }
        public string OutputText { get { throw null; } }
        public bool ParallelToolCalls { get { throw null; } }
        public string PreviousResponseId { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.Prompt Prompt { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.Reasoning Reasoning { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ServiceTier? ServiceTier { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseStatus? Status { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, System.BinaryData> StructuredInputs { get { throw null; } }
        public float? Temperature { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequestText Text { get { throw null; } }
        public System.BinaryData ToolChoice { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.AI.AgentServer.Contracts.Generated.OpenAI.Tool> Tools { get { throw null; } }
        public int? TopLogprobs { get { throw null; } }
        public float? TopP { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.Responses.CreateResponseRequestTruncation? Truncation { get { throw null; } }
        public Azure.AI.AgentServer.Contracts.Generated.OpenAI.ResponseUsage Usage { get { throw null; } }
        public string User { get { throw null; } }
        void Azure.AI.AgentServer.Contracts.Generated.Common.IUtf8JsonSerializable.Write(System.Text.Json.Utf8JsonWriter writer) { }
        public static Azure.AI.AgentServer.Contracts.Generated.Responses.Response DeserializeResponse(System.Text.Json.JsonElement element, System.ClientModel.Primitives.ModelReaderWriterOptions options = null) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.Responses.Response FromResponse(Azure.Response response) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.Responses.Response System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.Responses.Response>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.AI.AgentServer.Contracts.Generated.Responses.Response>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.AI.AgentServer.Contracts.Generated.Responses.Response System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Responses.Response>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Responses.Response>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.AI.AgentServer.Contracts.Generated.Responses.Response>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Core.RequestContent ToRequestContent() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResponseObject : System.IEquatable<Azure.AI.AgentServer.Contracts.Generated.Responses.ResponseObject>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResponseObject(string value) { throw null; }
        public static Azure.AI.AgentServer.Contracts.Generated.Responses.ResponseObject Response { get { throw null; } }
        public bool Equals(Azure.AI.AgentServer.Contracts.Generated.Responses.ResponseObject other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.AI.AgentServer.Contracts.Generated.Responses.ResponseObject left, Azure.AI.AgentServer.Contracts.Generated.Responses.ResponseObject right) { throw null; }
        public static implicit operator Azure.AI.AgentServer.Contracts.Generated.Responses.ResponseObject (string value) { throw null; }
        public static bool operator !=(Azure.AI.AgentServer.Contracts.Generated.Responses.ResponseObject left, Azure.AI.AgentServer.Contracts.Generated.Responses.ResponseObject right) { throw null; }
        public override string ToString() { throw null; }
    }
}
