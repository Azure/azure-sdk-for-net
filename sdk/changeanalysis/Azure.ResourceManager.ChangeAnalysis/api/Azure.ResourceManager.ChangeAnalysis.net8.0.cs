namespace Azure.ResourceManager.ChangeAnalysis
{
    public partial class AzureResourceManagerChangeAnalysisContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerChangeAnalysisContext() { }
        public static Azure.ResourceManager.ChangeAnalysis.AzureResourceManagerChangeAnalysisContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class ChangeAnalysisExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.ChangeAnalysis.Models.DetectedChangeData> GetChangesByResourceGroup(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.DateTimeOffset startTime, System.DateTimeOffset endTime, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ChangeAnalysis.Models.DetectedChangeData> GetChangesByResourceGroupAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, System.DateTimeOffset startTime, System.DateTimeOffset endTime, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ChangeAnalysis.Models.DetectedChangeData> GetChangesBySubscription(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.DateTimeOffset startTime, System.DateTimeOffset endTime, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ChangeAnalysis.Models.DetectedChangeData> GetChangesBySubscriptionAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.DateTimeOffset startTime, System.DateTimeOffset endTime, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ChangeAnalysis.Models.DetectedChangeData> GetResourceChanges(this Azure.ResourceManager.Resources.TenantResource tenantResource, string resourceId, System.DateTimeOffset startTime, System.DateTimeOffset endTime, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ChangeAnalysis.Models.DetectedChangeData> GetResourceChangesAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string resourceId, System.DateTimeOffset startTime, System.DateTimeOffset endTime, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ChangeAnalysis.Mocking
{
    public partial class MockableChangeAnalysisResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableChangeAnalysisResourceGroupResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ChangeAnalysis.Models.DetectedChangeData> GetChangesByResourceGroup(System.DateTimeOffset startTime, System.DateTimeOffset endTime, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ChangeAnalysis.Models.DetectedChangeData> GetChangesByResourceGroupAsync(System.DateTimeOffset startTime, System.DateTimeOffset endTime, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableChangeAnalysisSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableChangeAnalysisSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ChangeAnalysis.Models.DetectedChangeData> GetChangesBySubscription(System.DateTimeOffset startTime, System.DateTimeOffset endTime, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ChangeAnalysis.Models.DetectedChangeData> GetChangesBySubscriptionAsync(System.DateTimeOffset startTime, System.DateTimeOffset endTime, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableChangeAnalysisTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableChangeAnalysisTenantResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.ChangeAnalysis.Models.DetectedChangeData> GetResourceChanges(string resourceId, System.DateTimeOffset startTime, System.DateTimeOffset endTime, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ChangeAnalysis.Models.DetectedChangeData> GetResourceChangesAsync(string resourceId, System.DateTimeOffset startTime, System.DateTimeOffset endTime, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ChangeAnalysis.Models
{
    public static partial class ArmChangeAnalysisModelFactory
    {
        public static Azure.ResourceManager.ChangeAnalysis.Models.ChangeProperties ChangeProperties(Azure.Core.ResourceIdentifier resourceId = null, System.DateTimeOffset? changeDetectedOn = default(System.DateTimeOffset?), System.Collections.Generic.IEnumerable<string> initiatedByList = null, Azure.ResourceManager.ChangeAnalysis.Models.ChangeType? changeType = default(Azure.ResourceManager.ChangeAnalysis.Models.ChangeType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ChangeAnalysis.Models.PropertyChange> propertyChanges = null) { throw null; }
        public static Azure.ResourceManager.ChangeAnalysis.Models.DetectedChangeData DetectedChangeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.ChangeAnalysis.Models.ChangeProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ChangeAnalysis.Models.PropertyChange PropertyChange(Azure.ResourceManager.ChangeAnalysis.Models.ChangeType? changeType = default(Azure.ResourceManager.ChangeAnalysis.Models.ChangeType?), Azure.ResourceManager.ChangeAnalysis.Models.ChangeCategory? changeCategory = default(Azure.ResourceManager.ChangeAnalysis.Models.ChangeCategory?), string jsonPath = null, string displayName = null, Azure.ResourceManager.ChangeAnalysis.Models.PropertyChangeLevel? level = default(Azure.ResourceManager.ChangeAnalysis.Models.PropertyChangeLevel?), string description = null, string oldValue = null, string newValue = null, bool? isDataMasked = default(bool?)) { throw null; }
    }
    public enum ChangeCategory
    {
        User = 0,
        System = 1,
    }
    public partial class ChangeProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ChangeAnalysis.Models.ChangeProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ChangeAnalysis.Models.ChangeProperties>
    {
        internal ChangeProperties() { }
        public System.DateTimeOffset? ChangeDetectedOn { get { throw null; } }
        public Azure.ResourceManager.ChangeAnalysis.Models.ChangeType? ChangeType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> InitiatedByList { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.ChangeAnalysis.Models.PropertyChange> PropertyChanges { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ChangeAnalysis.Models.ChangeProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ChangeAnalysis.Models.ChangeProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ChangeAnalysis.Models.ChangeProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ChangeAnalysis.Models.ChangeProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ChangeAnalysis.Models.ChangeProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ChangeAnalysis.Models.ChangeProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ChangeAnalysis.Models.ChangeProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ChangeType : System.IEquatable<Azure.ResourceManager.ChangeAnalysis.Models.ChangeType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ChangeType(string value) { throw null; }
        public static Azure.ResourceManager.ChangeAnalysis.Models.ChangeType Add { get { throw null; } }
        public static Azure.ResourceManager.ChangeAnalysis.Models.ChangeType Remove { get { throw null; } }
        public static Azure.ResourceManager.ChangeAnalysis.Models.ChangeType Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ChangeAnalysis.Models.ChangeType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ChangeAnalysis.Models.ChangeType left, Azure.ResourceManager.ChangeAnalysis.Models.ChangeType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ChangeAnalysis.Models.ChangeType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ChangeAnalysis.Models.ChangeType left, Azure.ResourceManager.ChangeAnalysis.Models.ChangeType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DetectedChangeData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ChangeAnalysis.Models.DetectedChangeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ChangeAnalysis.Models.DetectedChangeData>
    {
        internal DetectedChangeData() { }
        public Azure.ResourceManager.ChangeAnalysis.Models.ChangeProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ChangeAnalysis.Models.DetectedChangeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ChangeAnalysis.Models.DetectedChangeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ChangeAnalysis.Models.DetectedChangeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ChangeAnalysis.Models.DetectedChangeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ChangeAnalysis.Models.DetectedChangeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ChangeAnalysis.Models.DetectedChangeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ChangeAnalysis.Models.DetectedChangeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PropertyChange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ChangeAnalysis.Models.PropertyChange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ChangeAnalysis.Models.PropertyChange>
    {
        internal PropertyChange() { }
        public Azure.ResourceManager.ChangeAnalysis.Models.ChangeCategory? ChangeCategory { get { throw null; } }
        public Azure.ResourceManager.ChangeAnalysis.Models.ChangeType? ChangeType { get { throw null; } }
        public string Description { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public bool? IsDataMasked { get { throw null; } }
        public string JsonPath { get { throw null; } }
        public Azure.ResourceManager.ChangeAnalysis.Models.PropertyChangeLevel? Level { get { throw null; } }
        public string NewValue { get { throw null; } }
        public string OldValue { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ChangeAnalysis.Models.PropertyChange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ChangeAnalysis.Models.PropertyChange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ChangeAnalysis.Models.PropertyChange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ChangeAnalysis.Models.PropertyChange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ChangeAnalysis.Models.PropertyChange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ChangeAnalysis.Models.PropertyChange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ChangeAnalysis.Models.PropertyChange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PropertyChangeLevel : System.IEquatable<Azure.ResourceManager.ChangeAnalysis.Models.PropertyChangeLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PropertyChangeLevel(string value) { throw null; }
        public static Azure.ResourceManager.ChangeAnalysis.Models.PropertyChangeLevel Important { get { throw null; } }
        public static Azure.ResourceManager.ChangeAnalysis.Models.PropertyChangeLevel Noisy { get { throw null; } }
        public static Azure.ResourceManager.ChangeAnalysis.Models.PropertyChangeLevel Normal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ChangeAnalysis.Models.PropertyChangeLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ChangeAnalysis.Models.PropertyChangeLevel left, Azure.ResourceManager.ChangeAnalysis.Models.PropertyChangeLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.ChangeAnalysis.Models.PropertyChangeLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ChangeAnalysis.Models.PropertyChangeLevel left, Azure.ResourceManager.ChangeAnalysis.Models.PropertyChangeLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
}
