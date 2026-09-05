namespace Azure.ResourceManager.EdgeOperator
{
    public partial class AzureResourceManagerEdgeOperatorContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerEdgeOperatorContext() { }
        public static Azure.ResourceManager.EdgeOperator.AzureResourceManagerEdgeOperatorContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class EdgeOperatorExtensions
    {
        public static Azure.ResourceManager.EdgeOperator.SystemReadinessResource GetSystemReadiness(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource) { throw null; }
        public static Azure.ResourceManager.EdgeOperator.SystemReadinessResource GetSystemReadinessResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class SystemReadinessData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.SystemReadinessData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.SystemReadinessData>
    {
        internal SystemReadinessData() { }
        public Azure.ResourceManager.EdgeOperator.Models.SystemReadinessProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOperator.SystemReadinessData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.SystemReadinessData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.SystemReadinessData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOperator.SystemReadinessData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.SystemReadinessData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.SystemReadinessData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.SystemReadinessData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SystemReadinessResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.SystemReadinessData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.SystemReadinessData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SystemReadinessResource() { }
        public virtual Azure.ResourceManager.EdgeOperator.SystemReadinessData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.EdgeOperator.SystemReadinessResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.EdgeOperator.SystemReadinessResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.EdgeOperator.SystemReadinessData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.SystemReadinessData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.SystemReadinessData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOperator.SystemReadinessData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.SystemReadinessData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.SystemReadinessData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.SystemReadinessData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.EdgeOperator.Mocking
{
    public partial class MockableEdgeOperatorArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableEdgeOperatorArmClient() { }
        public virtual Azure.ResourceManager.EdgeOperator.SystemReadinessResource GetSystemReadinessResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableEdgeOperatorSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableEdgeOperatorSubscriptionResource() { }
        public virtual Azure.ResourceManager.EdgeOperator.SystemReadinessResource GetSystemReadiness() { throw null; }
    }
}
namespace Azure.ResourceManager.EdgeOperator.Models
{
    public static partial class ArmEdgeOperatorModelFactory
    {
        public static Azure.ResourceManager.EdgeOperator.Models.SystemReadinessCategory SystemReadinessCategory(string categoryName = null, int readinessPercentage = 0, System.Collections.Generic.IEnumerable<string> errorMessageDetails = null) { throw null; }
        public static Azure.ResourceManager.EdgeOperator.SystemReadinessData SystemReadinessData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.EdgeOperator.Models.SystemReadinessProperties properties = null) { throw null; }
        public static Azure.ResourceManager.EdgeOperator.Models.SystemReadinessProperties SystemReadinessProperties(bool systemReady = false, System.Collections.Generic.IEnumerable<Azure.ResourceManager.EdgeOperator.Models.SystemReadinessCategory> categories = null) { throw null; }
    }
    public partial class SystemReadinessCategory : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.Models.SystemReadinessCategory>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.Models.SystemReadinessCategory>
    {
        internal SystemReadinessCategory() { }
        public string CategoryName { get { throw null; } }
        public System.Collections.Generic.IList<string> ErrorMessageDetails { get { throw null; } }
        public int ReadinessPercentage { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOperator.Models.SystemReadinessCategory JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOperator.Models.SystemReadinessCategory PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOperator.Models.SystemReadinessCategory System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.Models.SystemReadinessCategory>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.Models.SystemReadinessCategory>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOperator.Models.SystemReadinessCategory System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.Models.SystemReadinessCategory>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.Models.SystemReadinessCategory>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.Models.SystemReadinessCategory>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SystemReadinessProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.Models.SystemReadinessProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.Models.SystemReadinessProperties>
    {
        internal SystemReadinessProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.EdgeOperator.Models.SystemReadinessCategory> Categories { get { throw null; } }
        public bool SystemReady { get { throw null; } }
        protected virtual Azure.ResourceManager.EdgeOperator.Models.SystemReadinessProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.EdgeOperator.Models.SystemReadinessProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.EdgeOperator.Models.SystemReadinessProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.Models.SystemReadinessProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.EdgeOperator.Models.SystemReadinessProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.EdgeOperator.Models.SystemReadinessProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.Models.SystemReadinessProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.Models.SystemReadinessProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.EdgeOperator.Models.SystemReadinessProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
