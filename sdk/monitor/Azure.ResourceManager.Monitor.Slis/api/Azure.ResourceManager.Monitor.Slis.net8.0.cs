namespace Azure.ResourceManager.Monitor.Slis
{
    public partial class AzureResourceManagerMonitorSlisContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerMonitorSlisContext() { }
        public static Azure.ResourceManager.Monitor.Slis.AzureResourceManagerMonitorSlisContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class MonitorSlisExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Monitor.Slis.SliResource> GetSli(this Azure.ResourceManager.Resources.TenantResource tenantResource, string serviceGroupName, string sliName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Slis.SliResource>> GetSliAsync(this Azure.ResourceManager.Resources.TenantResource tenantResource, string serviceGroupName, string sliName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.SliResource GetSliResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.SliCollection GetSlis(this Azure.ResourceManager.Resources.TenantResource tenantResource, string serviceGroupName) { throw null; }
    }
    public partial class SliCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.Slis.SliResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Slis.SliResource>, System.Collections.IEnumerable
    {
        protected SliCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.Slis.SliResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string sliName, Azure.ResourceManager.Monitor.Slis.SliData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.Slis.SliResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string sliName, Azure.ResourceManager.Monitor.Slis.SliData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string sliName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string sliName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Slis.SliResource> Get(string sliName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Monitor.Slis.SliResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Monitor.Slis.SliResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Slis.SliResource>> GetAsync(string sliName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Monitor.Slis.SliResource> GetIfExists(string sliName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Monitor.Slis.SliResource>> GetIfExistsAsync(string sliName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Monitor.Slis.SliResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Monitor.Slis.SliResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Monitor.Slis.SliResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Slis.SliResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SliData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.SliData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.SliData>
    {
        public SliData() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Slis.Models.SliResourceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.SliData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.SliData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.SliData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.SliData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.SliData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.SliData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.SliData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SliResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.SliData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.SliData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SliResource() { }
        public virtual Azure.ResourceManager.Monitor.Slis.SliData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string serviceGroupName, string sliName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Slis.SliResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Slis.SliResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Monitor.Slis.SliData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.SliData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.SliData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.SliData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.SliData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.SliData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.SliData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.Slis.SliResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.Slis.SliData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Monitor.Slis.SliResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Monitor.Slis.SliData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Monitor.Slis.Mocking
{
    public partial class MockableMonitorSlisArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableMonitorSlisArmClient() { }
        public virtual Azure.ResourceManager.Monitor.Slis.SliResource GetSliResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableMonitorSlisTenantResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMonitorSlisTenantResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Monitor.Slis.SliResource> GetSli(string serviceGroupName, string sliName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Monitor.Slis.SliResource>> GetSliAsync(string serviceGroupName, string sliName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Monitor.Slis.SliCollection GetSlis(string serviceGroupName) { throw null; }
    }
}
namespace Azure.ResourceManager.Monitor.Slis.Models
{
    public partial class AmwAccount : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.AmwAccount>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.AmwAccount>
    {
        public AmwAccount(Azure.Core.ResourceIdentifier resourceId, Azure.Core.ResourceIdentifier identity) { }
        public Azure.Core.ResourceIdentifier Identity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.AmwAccount System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.AmwAccount>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.AmwAccount>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.AmwAccount System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.AmwAccount>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.AmwAccount>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.AmwAccount>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmMonitorSlisModelFactory
    {
        public static Azure.ResourceManager.Monitor.Slis.Models.ExecutionState ExecutionState(string state = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.Models.Metric Metric(string metricNamespace = null, string metricName = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.SliData SliData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Monitor.Slis.Models.SliResourceProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.Models.SliResourceProperties SliResourceProperties(Azure.ResourceManager.Monitor.Slis.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Monitor.Slis.Models.ProvisioningState?), string description = null, Azure.ResourceManager.Monitor.Slis.Models.Category category = default(Azure.ResourceManager.Monitor.Slis.Models.Category), Azure.ResourceManager.Monitor.Slis.Models.EvaluationType evaluationType = default(Azure.ResourceManager.Monitor.Slis.Models.EvaluationType), Azure.ResourceManager.Monitor.Slis.Models.ExecutionState executionState = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Slis.Models.AmwAccount> destinationAmwAccounts = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Slis.Models.Metric> destinationMetrics = null, Azure.ResourceManager.Monitor.Slis.Models.Baseline baseline = null, string streamingRuleId = null, System.DateTimeOffset? streamingRuleLastUpdatedTimestamp = default(System.DateTimeOffset?), bool enableAlert = false, Azure.ResourceManager.Monitor.Slis.Models.SliProperties sliProperties = null) { throw null; }
    }
    public partial class Baseline : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.Baseline>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.Baseline>
    {
        public Baseline(float value, int evaluationPeriodDays, Azure.ResourceManager.Monitor.Slis.Models.EvaluationCalculationType evaluationCalculationType) { }
        public Azure.ResourceManager.Monitor.Slis.Models.EvaluationCalculationType EvaluationCalculationType { get { throw null; } set { } }
        public int EvaluationPeriodDays { get { throw null; } set { } }
        public float Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.Baseline System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.Baseline>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.Baseline>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.Baseline System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.Baseline>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.Baseline>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.Baseline>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BaselineProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.BaselineProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.BaselineProperties>
    {
        public BaselineProperties(Azure.ResourceManager.Monitor.Slis.Models.Baseline baseline) { }
        public Azure.ResourceManager.Monitor.Slis.Models.Baseline Baseline { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.BaselineProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.BaselineProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.BaselineProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.BaselineProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.BaselineProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.BaselineProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.BaselineProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct Category : System.IEquatable<Azure.ResourceManager.Monitor.Slis.Models.Category>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public Category(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.Models.Category Availability { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.Category Latency { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Slis.Models.Category other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Slis.Models.Category left, Azure.ResourceManager.Monitor.Slis.Models.Category right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Slis.Models.Category (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Slis.Models.Category left, Azure.ResourceManager.Monitor.Slis.Models.Category right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Condition : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.Condition>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.Condition>
    {
        public Condition(Azure.ResourceManager.Monitor.Slis.Models.ConditionOperator @operator, string value) { }
        public string DimensionName { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Slis.Models.ConditionOperator Operator { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Slis.Models.SamplingType? SamplingType { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Slis.Models.ScalarFunction? ScalarFunction { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.Condition System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.Condition>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.Condition>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.Condition System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.Condition>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.Condition>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.Condition>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConditionOperator : System.IEquatable<Azure.ResourceManager.Monitor.Slis.Models.ConditionOperator>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConditionOperator(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.Models.ConditionOperator Contains { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.ConditionOperator Equal { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.ConditionOperator GreaterThan { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.ConditionOperator GreaterThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.ConditionOperator In { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.ConditionOperator LessThan { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.ConditionOperator LessThanOrEqual { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.ConditionOperator NotContains { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.ConditionOperator NotEqual { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.ConditionOperator NotIn { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.ConditionOperator NotStartsWith { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.ConditionOperator StartsWith { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Slis.Models.ConditionOperator other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Slis.Models.ConditionOperator left, Azure.ResourceManager.Monitor.Slis.Models.ConditionOperator right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Slis.Models.ConditionOperator (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Slis.Models.ConditionOperator left, Azure.ResourceManager.Monitor.Slis.Models.ConditionOperator right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvaluationCalculationType : System.IEquatable<Azure.ResourceManager.Monitor.Slis.Models.EvaluationCalculationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvaluationCalculationType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.Models.EvaluationCalculationType CalendarDays { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.EvaluationCalculationType RollingDays { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Slis.Models.EvaluationCalculationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Slis.Models.EvaluationCalculationType left, Azure.ResourceManager.Monitor.Slis.Models.EvaluationCalculationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Slis.Models.EvaluationCalculationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Slis.Models.EvaluationCalculationType left, Azure.ResourceManager.Monitor.Slis.Models.EvaluationCalculationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EvaluationType : System.IEquatable<Azure.ResourceManager.Monitor.Slis.Models.EvaluationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EvaluationType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.Models.EvaluationType RequestBased { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.EvaluationType WindowBased { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Slis.Models.EvaluationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Slis.Models.EvaluationType left, Azure.ResourceManager.Monitor.Slis.Models.EvaluationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Slis.Models.EvaluationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Slis.Models.EvaluationType left, Azure.ResourceManager.Monitor.Slis.Models.EvaluationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ExecutionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.ExecutionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.ExecutionState>
    {
        internal ExecutionState() { }
        public string Message { get { throw null; } }
        public string State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.ExecutionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.ExecutionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.ExecutionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.ExecutionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.ExecutionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.ExecutionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.ExecutionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Metric : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.Metric>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.Metric>
    {
        internal Metric() { }
        public string MetricName { get { throw null; } }
        public string MetricNamespace { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.Metric System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.Metric>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.Metric>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.Metric System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.Metric>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.Metric>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.Metric>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Monitor.Slis.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Slis.Models.ProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Slis.Models.ProvisioningState left, Azure.ResourceManager.Monitor.Slis.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Slis.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Slis.Models.ProvisioningState left, Azure.ResourceManager.Monitor.Slis.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SamplingType : System.IEquatable<Azure.ResourceManager.Monitor.Slis.Models.SamplingType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SamplingType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.Models.SamplingType Avg { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SamplingType Max { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SamplingType Min { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SamplingType Sum { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Slis.Models.SamplingType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Slis.Models.SamplingType left, Azure.ResourceManager.Monitor.Slis.Models.SamplingType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Slis.Models.SamplingType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Slis.Models.SamplingType left, Azure.ResourceManager.Monitor.Slis.Models.SamplingType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScalarFunction : System.IEquatable<Azure.ResourceManager.Monitor.Slis.Models.ScalarFunction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScalarFunction(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.Models.ScalarFunction Avg { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.ScalarFunction Max { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.ScalarFunction Min { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.ScalarFunction Sum { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Slis.Models.ScalarFunction other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Slis.Models.ScalarFunction left, Azure.ResourceManager.Monitor.Slis.Models.ScalarFunction right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Slis.Models.ScalarFunction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Slis.Models.ScalarFunction left, Azure.ResourceManager.Monitor.Slis.Models.ScalarFunction right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Signal : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.Signal>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.Signal>
    {
        public Signal(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Slis.Models.SignalSource> signalSources, string signalFormula) { }
        public string SignalFormula { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Slis.Models.SignalSource> SignalSources { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.Signal System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.Signal>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.Signal>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.Signal System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.Signal>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.Signal>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.Signal>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SignalSource : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SignalSource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SignalSource>
    {
        public SignalSource(string signalSourceId, Azure.Core.ResourceIdentifier sourceAmwAccountManagedIdentity, Azure.Core.ResourceIdentifier sourceAmwAccountResourceId, string metricNamespace, string metricName, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Slis.Models.Condition> filters, Azure.ResourceManager.Monitor.Slis.Models.SpatialAggregation spatialAggregation, Azure.ResourceManager.Monitor.Slis.Models.TemporalAggregation temporalAggregation) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Slis.Models.Condition> Filters { get { throw null; } }
        public string MetricName { get { throw null; } set { } }
        public string MetricNamespace { get { throw null; } set { } }
        public string SignalSourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceAmwAccountManagedIdentity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceAmwAccountResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Slis.Models.SpatialAggregation SpatialAggregation { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Slis.Models.TemporalAggregation TemporalAggregation { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.SignalSource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SignalSource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SignalSource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.SignalSource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SignalSource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SignalSource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SignalSource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SliProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliProperties>
    {
        public SliProperties() { }
        public Azure.ResourceManager.Monitor.Slis.Models.Signal GoodSignals { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Slis.Models.Signal Signals { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Slis.Models.Signal TotalSignals { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteria WindowUptimeCriteria { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.SliProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.SliProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SliResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliResourceProperties>
    {
        public SliResourceProperties(string description, Azure.ResourceManager.Monitor.Slis.Models.Category category, Azure.ResourceManager.Monitor.Slis.Models.EvaluationType evaluationType, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Monitor.Slis.Models.AmwAccount> destinationAmwAccounts, Azure.ResourceManager.Monitor.Slis.Models.BaselineProperties baselineProperties, bool enableAlert, Azure.ResourceManager.Monitor.Slis.Models.SliProperties sliProperties) { }
        public Azure.ResourceManager.Monitor.Slis.Models.Baseline Baseline { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Slis.Models.Category Category { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Monitor.Slis.Models.AmwAccount> DestinationAmwAccounts { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Monitor.Slis.Models.Metric> DestinationMetrics { get { throw null; } }
        public bool EnableAlert { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Slis.Models.EvaluationType EvaluationType { get { throw null; } set { } }
        public Azure.ResourceManager.Monitor.Slis.Models.ExecutionState ExecutionState { get { throw null; } }
        public Azure.ResourceManager.Monitor.Slis.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Monitor.Slis.Models.SliProperties SliProperties { get { throw null; } set { } }
        public string StreamingRuleId { get { throw null; } }
        public System.DateTimeOffset? StreamingRuleLastUpdatedTimestamp { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.SliResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SliResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.SliResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SliResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpatialAggregation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SpatialAggregation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SpatialAggregation>
    {
        public SpatialAggregation(Azure.ResourceManager.Monitor.Slis.Models.SpatialAggregationType type, System.Collections.Generic.IEnumerable<string> dimensions) { }
        public System.Collections.Generic.IList<string> Dimensions { get { throw null; } }
        public Azure.ResourceManager.Monitor.Slis.Models.SpatialAggregationType Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.SpatialAggregation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SpatialAggregation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.SpatialAggregation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.SpatialAggregation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SpatialAggregation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SpatialAggregation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.SpatialAggregation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SpatialAggregationType : System.IEquatable<Azure.ResourceManager.Monitor.Slis.Models.SpatialAggregationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SpatialAggregationType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.Models.SpatialAggregationType Average { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SpatialAggregationType Count { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SpatialAggregationType Max { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SpatialAggregationType Min { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.SpatialAggregationType Sum { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Slis.Models.SpatialAggregationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Slis.Models.SpatialAggregationType left, Azure.ResourceManager.Monitor.Slis.Models.SpatialAggregationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Slis.Models.SpatialAggregationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Slis.Models.SpatialAggregationType left, Azure.ResourceManager.Monitor.Slis.Models.SpatialAggregationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TemporalAggregation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.TemporalAggregation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.TemporalAggregation>
    {
        public TemporalAggregation(Azure.ResourceManager.Monitor.Slis.Models.TemporalAggregationType type) { }
        public Azure.ResourceManager.Monitor.Slis.Models.TemporalAggregationType Type { get { throw null; } set { } }
        public int? WindowSizeMinutes { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.TemporalAggregation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.TemporalAggregation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.TemporalAggregation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Monitor.Slis.Models.TemporalAggregation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.TemporalAggregation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.TemporalAggregation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.TemporalAggregation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TemporalAggregationType : System.IEquatable<Azure.ResourceManager.Monitor.Slis.Models.TemporalAggregationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TemporalAggregationType(string value) { throw null; }
        public static Azure.ResourceManager.Monitor.Slis.Models.TemporalAggregationType Average { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.TemporalAggregationType Delta { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.TemporalAggregationType IDelta { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.TemporalAggregationType Increase { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.TemporalAggregationType IRate { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.TemporalAggregationType Max { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.TemporalAggregationType Min { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.TemporalAggregationType Rate { get { throw null; } }
        public static Azure.ResourceManager.Monitor.Slis.Models.TemporalAggregationType Sum { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Monitor.Slis.Models.TemporalAggregationType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Monitor.Slis.Models.TemporalAggregationType left, Azure.ResourceManager.Monitor.Slis.Models.TemporalAggregationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Monitor.Slis.Models.TemporalAggregationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Monitor.Slis.Models.TemporalAggregationType left, Azure.ResourceManager.Monitor.Slis.Models.TemporalAggregationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WindowUptimeCriteria : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteria>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteria>
    {
        public WindowUptimeCriteria(float target, Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteriaComparator comparator) { }
        public Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteriaComparator Comparator { get { throw null; } set { } }
        public float Target { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
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
        public static bool operator !=(Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteriaComparator left, Azure.ResourceManager.Monitor.Slis.Models.WindowUptimeCriteriaComparator right) { throw null; }
        public override string ToString() { throw null; }
    }
}
