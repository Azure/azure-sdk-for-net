namespace Azure.ResourceManager.Monitor.Slis
{
    public partial class AzureResourceManagerMonitorSlisContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerMonitorSlisContext() { }
        public static Azure.ResourceManager.Monitor.Slis.AzureResourceManagerMonitorSlisContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class MonitorSliCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.Slis.MonitorSliResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Slis.MonitorSliResource>, System.Collections.IEnumerable
    {
        protected MonitorSliCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.Slis.MonitorSliResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sliName, Azure.ResourceManager.Monitor.Slis.MonitorSliData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.Slis.MonitorSliResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sliName, Azure.ResourceManager.Monitor.Slis.MonitorSliData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sliName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sliName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Slis.MonitorSliResource> Get(string sliName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.Slis.MonitorSliResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.Slis.MonitorSliResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Slis.MonitorSliResource>> GetAsync(string sliName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Monitor.Slis.MonitorSliResource> GetIfExists(string sliName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Monitor.Slis.MonitorSliResource>> GetIfExistsAsync(string sliName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.Slis.MonitorSliResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.Slis.MonitorSliResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.Slis.MonitorSliResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Slis.MonitorSliResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MonitorSliData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.MonitorSliData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.MonitorSliData>
    {
        public MonitorSliData() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Slis.Models.MonitorSliProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Slis.MonitorSliData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.MonitorSliData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.MonitorSliData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.MonitorSliData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.MonitorSliData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.MonitorSliData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.MonitorSliData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitorSliResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.MonitorSliData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.MonitorSliData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MonitorSliResource() { }
        public virtual Azure.ResourceManager.Monitor.Slis.MonitorSliData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string serviceGroupName, string sliName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Slis.MonitorSliResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Slis.MonitorSliResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Monitor.Slis.MonitorSliData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.MonitorSliData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.MonitorSliData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.MonitorSliData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.MonitorSliData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.MonitorSliData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.MonitorSliData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.Slis.MonitorSliResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.Slis.MonitorSliData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.Slis.MonitorSliResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.Slis.MonitorSliData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class MonitorSlisExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Monitor.Slis.MonitorSliResource> GetMonitorSli(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string sliName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Slis.MonitorSliResource>> GetMonitorSliAsync(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope, string sliName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.MonitorSliResource GetMonitorSliResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.MonitorSliCollection GetMonitorSlis(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier scope) { throw null; }
    }
}
namespace Azure.ResourceManager.Monitor.Slis.Mocking
{
    public partial class MockableMonitorSlisArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableMonitorSlisArmClient() { }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Slis.MonitorSliResource> GetMonitorSli(Azure.Core.ResourceIdentifier scope, string sliName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Slis.MonitorSliResource>> GetMonitorSliAsync(Azure.Core.ResourceIdentifier scope, string sliName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Slis.MonitorSliResource GetMonitorSliResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Slis.MonitorSliCollection GetMonitorSlis(Azure.Core.ResourceIdentifier scope) { throw null; }
    }
}
namespace Azure.ResourceManager.Monitor.Slis.Models
{
    public static partial class ArmMonitorSlisModelFactory
    {
        public static Azure.ResourceManager.Monitor.Slis.MonitorSliData MonitorSliData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Monitor.Slis.Models.MonitorSliProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.Models.MonitorSliProperties MonitorSliProperties(Azure.ResourceManager.Monitor.Slis.Models.SliProvisioningState? provisioningState = default(Azure.ResourceManager.Monitor.Slis.Models.SliProvisioningState?), string description = null, Azure.ResourceManager.Monitor.Slis.Models.SliCategory category = default(Azure.ResourceManager.Monitor.Slis.Models.SliCategory), Azure.ResourceManager.Monitor.Slis.Models.SliEvaluationType evaluationType = default(Azure.ResourceManager.Monitor.Slis.Models.SliEvaluationType), Azure.ResourceManager.Monitor.Slis.Models.SliExecutionState executionState = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Slis.Models.SliAmwAccount> destinationAmwAccounts = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Slis.Models.SliMetric> destinationMetrics = null, Azure.ResourceManager.Monitor.Slis.Models.SliBaseline baseline = null, string streamingRuleId = null, System.DateTimeOffset? streamingRuleLastUpdatedOn = default(System.DateTimeOffset?), bool isAlertEnabled = false, Azure.ResourceManager.Monitor.Slis.Models.SliProperties sliProperties = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliExecutionState SliExecutionState(string state = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliMetric SliMetric(string metricNamespace = null, string metricName = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliSignal SliSignal(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Slis.Models.SliSignalSource> signalSources = null, string signalFormula = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliSignalSource SliSignalSource(string signalSourceId = null, Azure.Core.ResourceIdentifier sourceAmwAccountManagedIdentity = null, Azure.Core.ResourceIdentifier sourceAmwAccountResourceId = null, string metricNamespace = null, string metricName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Slis.Models.SliCondition> filters = null, Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregation spatialAggregation = null, Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregation temporalAggregation = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregation SliSpatialAggregation(Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregationType type = default(Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregationType), System.Collections.Generic.IEnumerable<string> dimensions = null) { throw null; }
    }
    public partial class MonitorSliProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.MonitorSliProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.MonitorSliProperties>
    {
        public MonitorSliProperties(string description, Azure.ResourceManager.Monitor.Slis.Models.SliCategory category, Azure.ResourceManager.Monitor.Slis.Models.SliEvaluationType evaluationType, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Slis.Models.SliAmwAccount> destinationAmwAccounts, Azure.ResourceManager.Monitor.Slis.Models.SliBaseline baseline, bool isAlertEnabled, Azure.ResourceManager.Monitor.Slis.Models.SliProperties sliProperties) { }
        public Azure.ResourceManager.Monitor.Slis.Models.SliBaseline Baseline { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Slis.Models.SliCategory Category { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Slis.Models.SliAmwAccount> DestinationAmwAccounts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Slis.Models.SliMetric> DestinationMetrics { get { throw null; } }
        public Azure.ResourceManager.Monitor.Slis.Models.SliEvaluationType EvaluationType { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Slis.Models.SliExecutionState ExecutionState { get { throw null; } }
        public bool IsAlertEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Slis.Models.SliProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Monitor.Slis.Models.SliProperties SliProperties { get { throw null; } set { } }
        public string StreamingRuleId { get { throw null; } }
        public System.DateTimeOffset? StreamingRuleLastUpdatedOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.Slis.Models.MonitorSliProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Slis.Models.MonitorSliProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Slis.Models.MonitorSliProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.MonitorSliProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.MonitorSliProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.MonitorSliProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.MonitorSliProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.MonitorSliProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.MonitorSliProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SliAmwAccount : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliAmwAccount>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliAmwAccount>
    {
        public SliAmwAccount(Azure.Core.ResourceIdentifier resourceId, Azure.Core.ResourceIdentifier identity) { }
        public Azure.Core.ResourceIdentifier Identity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Slis.Models.SliAmwAccount JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Slis.Models.SliAmwAccount PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Slis.Models.SliAmwAccount System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliAmwAccount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliAmwAccount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.SliAmwAccount System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliAmwAccount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliAmwAccount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliAmwAccount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SliBaseline : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliBaseline>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliBaseline>
    {
        public SliBaseline(float value, int evaluationPeriodDays, Azure.ResourceManager.Monitor.Slis.Models.SliEvaluationCalculationType evaluationCalculationType) { }
        public Azure.ResourceManager.Monitor.Slis.Models.SliEvaluationCalculationType EvaluationCalculationType { get { throw null; } set { } }
        public int EvaluationPeriodDays { get { throw null; } set { } }
        public float Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Slis.Models.SliBaseline JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Slis.Models.SliBaseline PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Slis.Models.SliBaseline System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliBaseline>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliBaseline>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.SliBaseline System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliBaseline>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliBaseline>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliBaseline>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SliCategory : System.IEquatable<Azure.ResourceManager.Monitor.Slis.Models.SliCategory>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SliCategory(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliCategory Availability { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliCategory Latency { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Slis.Models.SliCategory other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Slis.Models.SliCategory left, Azure.ResourceManager.Monitor.Slis.Models.SliCategory right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Slis.Models.SliCategory (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Slis.Models.SliCategory? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Slis.Models.SliCategory left, Azure.ResourceManager.Monitor.Slis.Models.SliCategory right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SliCondition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliCondition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliCondition>
    {
        public SliCondition(Azure.ResourceManager.Monitor.Slis.Models.SliConditionOperator @operator, string value) { }
        public string DimensionName { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Slis.Models.SliConditionOperator Operator { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Slis.Models.SliSamplingType? SamplingType { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Slis.Models.SliScalarFunction? ScalarFunction { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Slis.Models.SliCondition JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Slis.Models.SliCondition PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Slis.Models.SliCondition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliCondition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliCondition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.SliCondition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliCondition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliCondition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliCondition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SliConditionOperator : System.IEquatable<Azure.ResourceManager.Monitor.Slis.Models.SliConditionOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SliConditionOperator(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliConditionOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliConditionOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliConditionOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliConditionOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliConditionOperator In { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliConditionOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliConditionOperator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliConditionOperator NotContains { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliConditionOperator NotEqual { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliConditionOperator NotIn { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliConditionOperator NotStartsWith { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliConditionOperator StartsWith { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Slis.Models.SliConditionOperator other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Slis.Models.SliConditionOperator left, Azure.ResourceManager.Monitor.Slis.Models.SliConditionOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Slis.Models.SliConditionOperator (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Slis.Models.SliConditionOperator? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Slis.Models.SliConditionOperator left, Azure.ResourceManager.Monitor.Slis.Models.SliConditionOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SliEvaluationCalculationType : System.IEquatable<Azure.ResourceManager.Monitor.Slis.Models.SliEvaluationCalculationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SliEvaluationCalculationType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliEvaluationCalculationType CalendarDays { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliEvaluationCalculationType RollingDays { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Slis.Models.SliEvaluationCalculationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Slis.Models.SliEvaluationCalculationType left, Azure.ResourceManager.Monitor.Slis.Models.SliEvaluationCalculationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Slis.Models.SliEvaluationCalculationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Slis.Models.SliEvaluationCalculationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Slis.Models.SliEvaluationCalculationType left, Azure.ResourceManager.Monitor.Slis.Models.SliEvaluationCalculationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SliEvaluationType : System.IEquatable<Azure.ResourceManager.Monitor.Slis.Models.SliEvaluationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SliEvaluationType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliEvaluationType RequestBased { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliEvaluationType WindowBased { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Slis.Models.SliEvaluationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Slis.Models.SliEvaluationType left, Azure.ResourceManager.Monitor.Slis.Models.SliEvaluationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Slis.Models.SliEvaluationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Slis.Models.SliEvaluationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Slis.Models.SliEvaluationType left, Azure.ResourceManager.Monitor.Slis.Models.SliEvaluationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SliExecutionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliExecutionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliExecutionState>
    {
        internal SliExecutionState() { }
        public string Message { get { throw null; } }
        public string State { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.Slis.Models.SliExecutionState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Slis.Models.SliExecutionState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Slis.Models.SliExecutionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliExecutionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliExecutionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.SliExecutionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliExecutionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliExecutionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliExecutionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SliMetric : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliMetric>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliMetric>
    {
        internal SliMetric() { }
        public string MetricName { get { throw null; } }
        public string MetricNamespace { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.Slis.Models.SliMetric JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Slis.Models.SliMetric PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Slis.Models.SliMetric System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliMetric>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliMetric>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.SliMetric System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliMetric>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliMetric>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliMetric>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SliProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliProperties>
    {
        public SliProperties() { }
        public Azure.ResourceManager.Monitor.Slis.Models.SliSignal GoodSignals { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Slis.Models.SliSignal Signals { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Slis.Models.SliSignal TotalSignals { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteria WindowUptimeCriteria { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Slis.Models.SliProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Slis.Models.SliProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Slis.Models.SliProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.SliProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SliProvisioningState : System.IEquatable<Azure.ResourceManager.Monitor.Slis.Models.SliProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SliProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Slis.Models.SliProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Slis.Models.SliProvisioningState left, Azure.ResourceManager.Monitor.Slis.Models.SliProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Slis.Models.SliProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Slis.Models.SliProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Slis.Models.SliProvisioningState left, Azure.ResourceManager.Monitor.Slis.Models.SliProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SliSamplingType : System.IEquatable<Azure.ResourceManager.Monitor.Slis.Models.SliSamplingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SliSamplingType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliSamplingType Avg { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliSamplingType Max { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliSamplingType Min { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliSamplingType Sum { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Slis.Models.SliSamplingType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Slis.Models.SliSamplingType left, Azure.ResourceManager.Monitor.Slis.Models.SliSamplingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Slis.Models.SliSamplingType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Slis.Models.SliSamplingType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Slis.Models.SliSamplingType left, Azure.ResourceManager.Monitor.Slis.Models.SliSamplingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SliScalarFunction : System.IEquatable<Azure.ResourceManager.Monitor.Slis.Models.SliScalarFunction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SliScalarFunction(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliScalarFunction Avg { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliScalarFunction Max { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliScalarFunction Min { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliScalarFunction Sum { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Slis.Models.SliScalarFunction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Slis.Models.SliScalarFunction left, Azure.ResourceManager.Monitor.Slis.Models.SliScalarFunction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Slis.Models.SliScalarFunction (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Slis.Models.SliScalarFunction? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Slis.Models.SliScalarFunction left, Azure.ResourceManager.Monitor.Slis.Models.SliScalarFunction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SliSignal : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliSignal>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliSignal>
    {
        public SliSignal(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Slis.Models.SliSignalSource> signalSources, string signalFormula) { }
        public string SignalFormula { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Slis.Models.SliSignalSource> SignalSources { get { throw null; } }
        protected virtual Azure.ResourceManager.Monitor.Slis.Models.SliSignal JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Slis.Models.SliSignal PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Slis.Models.SliSignal System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliSignal>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliSignal>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.SliSignal System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliSignal>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliSignal>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliSignal>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SliSignalSource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliSignalSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliSignalSource>
    {
        public SliSignalSource(string signalSourceId, Azure.Core.ResourceIdentifier sourceAmwAccountManagedIdentity, Azure.Core.ResourceIdentifier sourceAmwAccountResourceId, string metricNamespace, string metricName, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Slis.Models.SliCondition> filters, Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregation spatialAggregation, Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregation temporalAggregation) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Slis.Models.SliCondition> Filters { get { throw null; } }
        public string MetricName { get { throw null; } set { } }
        public string MetricNamespace { get { throw null; } set { } }
        public string SignalSourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceAmwAccountManagedIdentity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceAmwAccountResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregation SpatialAggregation { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregation TemporalAggregation { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Slis.Models.SliSignalSource JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Slis.Models.SliSignalSource PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Slis.Models.SliSignalSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliSignalSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliSignalSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.SliSignalSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliSignalSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliSignalSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliSignalSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SliSpatialAggregation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregation>
    {
        public SliSpatialAggregation(Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregationType type, System.Collections.Generic.IEnumerable<string> dimensions) { }
        public System.Collections.Generic.IList<string> Dimensions { get { throw null; } }
        public Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregationType Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SliSpatialAggregationType : System.IEquatable<Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SliSpatialAggregationType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregationType Average { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregationType Count { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregationType Max { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregationType Min { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregationType Sum { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregationType left, Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregationType left, Azure.ResourceManager.Monitor.Slis.Models.SliSpatialAggregationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SliTemporalAggregation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregation>
    {
        public SliTemporalAggregation(Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregationType type) { }
        public Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregationType Type { get { throw null; } set { } }
        public int? WindowSizeMinutes { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SliTemporalAggregationType : System.IEquatable<Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SliTemporalAggregationType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregationType Average { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregationType Delta { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregationType IDelta { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregationType Increase { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregationType IRate { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregationType Max { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregationType Min { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregationType Rate { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregationType Sum { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregationType left, Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregationType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregationType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregationType left, Azure.ResourceManager.Monitor.Slis.Models.SliTemporalAggregationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WindowUptimeCriteria : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteria>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteria>
    {
        public WindowUptimeCriteria(float target, Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteriaComparator comparator) { }
        public Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteriaComparator Comparator { get { throw null; } set { } }
        public float Target { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteria JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteria PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteria System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteria>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteria>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteria System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteria>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteria>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteria>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WindowUptimeCriteriaComparator : System.IEquatable<Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteriaComparator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WindowUptimeCriteriaComparator(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteriaComparator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteriaComparator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteriaComparator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteriaComparator LessThanOrEqual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteriaComparator other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteriaComparator left, Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteriaComparator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteriaComparator (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteriaComparator? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteriaComparator left, Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteriaComparator right) { throw null; }
        public override string ToString() { throw null; }
    }
}
