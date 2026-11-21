namespace Azure.ResourceManager.CostManagement._PriceEstimation
{
    public partial class AzureResourceManagerCostManagement_PriceEstimationContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerCostManagement_PriceEstimationContext() { }
        public static Azure.ResourceManager.CostManagement._PriceEstimation.AzureResourceManagerCostManagement_PriceEstimationContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class CostManagementPriceEstimationExtensions
    {
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResult> EstimatePrices(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResult>> EstimatePricesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResult> GetEstimatePricesOperationResult(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResult>> GetEstimatePricesOperationResultAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.CostManagement._PriceEstimation.Mocking
{
    public partial class MockableCostManagementPriceEstimationSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCostManagementPriceEstimationSubscriptionResource() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResult> EstimatePrices(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResult>> EstimatePricesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResult> GetEstimatePricesOperationResult(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResult>> GetEstimatePricesOperationResultAsync(Azure.WaitUntil waitUntil, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.CostManagement._PriceEstimation.Models
{
    public static partial class ArmCostManagementPriceEstimationModelFactory
    {
        public static Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateAppliedValue EstimateAppliedValue(string field = null, Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue value = null) { throw null; }
        public static Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateArrayValue EstimateArrayValue(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue> items = null) { throw null; }
        public static Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateBooleanValue EstimateBooleanValue(bool value = false) { throw null; }
        public static Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateComponentResult EstimateComponentResult(string component = null, System.Collections.Generic.IEnumerable<string> meterIds = null, Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostSummary monthly = null, Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostSummary upfront = null) { throw null; }
        public static Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateContent EstimateContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResourceInput> resources = null) { throw null; }
        public static Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostSummary EstimateCostSummary(Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostStatus status = default(Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostStatus), double? amount = default(double?), double? knownAmount = default(double?)) { throw null; }
        public static Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateDiagnostic EstimateDiagnostic(string code = null, string message = null, string target = null, string component = null) { throw null; }
        public static Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateEffectiveConfiguration EstimateEffectiveConfiguration(string resourceType = null, string resourceApiVersion = null, System.Collections.Generic.IEnumerable<string> defaultedFields = null, System.Collections.Generic.IEnumerable<string> assumedUsageFields = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateAppliedValue> appliedValues = null) { throw null; }
        public static Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateNamedValue EstimateNamedValue(string name = null, Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue value = null) { throw null; }
        public static Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateNumberValue EstimateNumberValue(double value = 0) { throw null; }
        public static Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateObjectValue EstimateObjectValue(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateNamedValue> members = null) { throw null; }
        public static Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResourceInput EstimateResourceInput(string resourceType = null, string resourceApiVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateNamedValue> inputs = null) { throw null; }
        public static Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResourceResult EstimateResourceResult(int inputIndex = 0, Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateEffectiveConfiguration configuration = null, Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostSummary monthly = null, Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostSummary upfront = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateComponentResult> components = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateDiagnostic> issues = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateDiagnostic> assumptions = null) { throw null; }
        public static Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResult EstimateResult(string currency = null, System.DateTimeOffset pricingAsOf = default(System.DateTimeOffset), System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResourceResult> results = null, Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateTotals totals = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateDiagnostic> assumptions = null) { throw null; }
        public static Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateStringValue EstimateStringValue(string value = null) { throw null; }
        public static Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateTotals EstimateTotals(Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostSummary monthly = null, Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostSummary upfront = null) { throw null; }
        public static Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue EstimateValue(string kind = null) { throw null; }
    }
    public partial class EstimateAppliedValue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateAppliedValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateAppliedValue>
    {
        internal EstimateAppliedValue() { }
        public string Field { get { throw null; } }
        public Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue Value { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateAppliedValue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateAppliedValue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateAppliedValue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateAppliedValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateAppliedValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateAppliedValue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateAppliedValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateAppliedValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateAppliedValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EstimateArrayValue : Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateArrayValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateArrayValue>
    {
        public EstimateArrayValue(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue> items) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue> Items { get { throw null; } }
        protected override Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateArrayValue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateArrayValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateArrayValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateArrayValue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateArrayValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateArrayValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateArrayValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EstimateBooleanValue : Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateBooleanValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateBooleanValue>
    {
        public EstimateBooleanValue(bool value) { }
        public bool Value { get { throw null; } set { } }
        protected override Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateBooleanValue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateBooleanValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateBooleanValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateBooleanValue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateBooleanValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateBooleanValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateBooleanValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EstimateComponentResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateComponentResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateComponentResult>
    {
        internal EstimateComponentResult() { }
        public string Component { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> MeterIds { get { throw null; } }
        public Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostSummary Monthly { get { throw null; } }
        public Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostSummary Upfront { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateComponentResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateComponentResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateComponentResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateComponentResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateComponentResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateComponentResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateComponentResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateComponentResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateComponentResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EstimateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateContent>
    {
        public EstimateContent(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResourceInput> resources) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResourceInput> Resources { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EstimateCostStatus : System.IEquatable<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EstimateCostStatus(string value) { throw null; }
        public static Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostStatus Complete { get { throw null; } }
        public static Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostStatus Partial { get { throw null; } }
        public static Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostStatus Unavailable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostStatus left, Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostStatus left, Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EstimateCostSummary : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostSummary>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostSummary>
    {
        internal EstimateCostSummary() { }
        public double? Amount { get { throw null; } }
        public double? KnownAmount { get { throw null; } }
        public Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostStatus Status { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostSummary JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostSummary PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostSummary System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostSummary>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostSummary>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostSummary System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostSummary>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostSummary>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostSummary>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EstimateDiagnostic : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateDiagnostic>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateDiagnostic>
    {
        internal EstimateDiagnostic() { }
        public string Code { get { throw null; } }
        public string Component { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateDiagnostic JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateDiagnostic PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateDiagnostic System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateDiagnostic>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateDiagnostic>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateDiagnostic System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateDiagnostic>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateDiagnostic>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateDiagnostic>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EstimateEffectiveConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateEffectiveConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateEffectiveConfiguration>
    {
        internal EstimateEffectiveConfiguration() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateAppliedValue> AppliedValues { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> AssumedUsageFields { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> DefaultedFields { get { throw null; } }
        public string ResourceApiVersion { get { throw null; } }
        public string ResourceType { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateEffectiveConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateEffectiveConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateEffectiveConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateEffectiveConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateEffectiveConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateEffectiveConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateEffectiveConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateEffectiveConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateEffectiveConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EstimateNamedValue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateNamedValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateNamedValue>
    {
        public EstimateNamedValue(string name, Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue value) { }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateNamedValue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateNamedValue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateNamedValue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateNamedValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateNamedValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateNamedValue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateNamedValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateNamedValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateNamedValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EstimateNumberValue : Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateNumberValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateNumberValue>
    {
        public EstimateNumberValue(double value) { }
        public double Value { get { throw null; } set { } }
        protected override Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateNumberValue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateNumberValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateNumberValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateNumberValue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateNumberValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateNumberValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateNumberValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EstimateObjectValue : Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateObjectValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateObjectValue>
    {
        public EstimateObjectValue(System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateNamedValue> members) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateNamedValue> Members { get { throw null; } }
        protected override Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateObjectValue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateObjectValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateObjectValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateObjectValue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateObjectValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateObjectValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateObjectValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EstimateResourceInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResourceInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResourceInput>
    {
        public EstimateResourceInput(string resourceType, string resourceApiVersion, System.Collections.Generic.IEnumerable<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateNamedValue> inputs) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateNamedValue> Inputs { get { throw null; } }
        public string ResourceApiVersion { get { throw null; } }
        public string ResourceType { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResourceInput JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResourceInput PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResourceInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResourceInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResourceInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResourceInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResourceInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResourceInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResourceInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EstimateResourceResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResourceResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResourceResult>
    {
        internal EstimateResourceResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateDiagnostic> Assumptions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateComponentResult> Components { get { throw null; } }
        public Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateEffectiveConfiguration Configuration { get { throw null; } }
        public int InputIndex { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateDiagnostic> Issues { get { throw null; } }
        public Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostSummary Monthly { get { throw null; } }
        public Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostSummary Upfront { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResourceResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResourceResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResourceResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResourceResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResourceResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResourceResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResourceResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResourceResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResourceResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EstimateResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResult>
    {
        internal EstimateResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateDiagnostic> Assumptions { get { throw null; } }
        public string Coverage { get { throw null; } }
        public string Currency { get { throw null; } }
        public System.DateTimeOffset PricingAsOf { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResourceResult> Results { get { throw null; } }
        public Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateTotals Totals { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EstimateStringValue : Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateStringValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateStringValue>
    {
        public EstimateStringValue(string value) { }
        public string Value { get { throw null; } set { } }
        protected override Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateStringValue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateStringValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateStringValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateStringValue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateStringValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateStringValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateStringValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EstimateTotals : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateTotals>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateTotals>
    {
        internal EstimateTotals() { }
        public Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostSummary Monthly { get { throw null; } }
        public Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateCostSummary Upfront { get { throw null; } }
        protected virtual Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateTotals JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateTotals PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateTotals System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateTotals>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateTotals>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateTotals System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateTotals>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateTotals>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateTotals>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class EstimateValue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue>
    {
        internal EstimateValue() { }
        protected virtual Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.CostManagement._PriceEstimation.Models.EstimateValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
