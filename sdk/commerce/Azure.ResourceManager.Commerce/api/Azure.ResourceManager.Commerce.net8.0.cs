namespace Azure.ResourceManager.Commerce
{
    public partial class AzureResourceManagerCommerceContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerCommerceContext() { }
        public static Azure.ResourceManager.Commerce.AzureResourceManagerCommerceContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class CommerceExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Commerce.Models.ResourceRateCardInfo> GetRateCard(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Commerce.Models.ResourceRateCardInfo>> GetRateCardAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Commerce.Models.UsageAggregation> GetUsageAggregates(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.DateTimeOffset reportedStartTime, System.DateTimeOffset reportedEndTime, bool? showDetails = default(bool?), Azure.ResourceManager.Commerce.Models.AggregationGranularity? aggregationGranularity = default(Azure.ResourceManager.Commerce.Models.AggregationGranularity?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Commerce.Models.UsageAggregation> GetUsageAggregatesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.DateTimeOffset reportedStartTime, System.DateTimeOffset reportedEndTime, bool? showDetails = default(bool?), Azure.ResourceManager.Commerce.Models.AggregationGranularity? aggregationGranularity = default(Azure.ResourceManager.Commerce.Models.AggregationGranularity?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Commerce.Mocking
{
    public partial class MockableCommerceSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCommerceSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Commerce.Models.ResourceRateCardInfo> GetRateCard(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Commerce.Models.ResourceRateCardInfo>> GetRateCardAsync(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Commerce.Models.UsageAggregation> GetUsageAggregates(System.DateTimeOffset reportedStartTime, System.DateTimeOffset reportedEndTime, bool? showDetails = default(bool?), Azure.ResourceManager.Commerce.Models.AggregationGranularity? aggregationGranularity = default(Azure.ResourceManager.Commerce.Models.AggregationGranularity?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Commerce.Models.UsageAggregation> GetUsageAggregatesAsync(System.DateTimeOffset reportedStartTime, System.DateTimeOffset reportedEndTime, bool? showDetails = default(bool?), Azure.ResourceManager.Commerce.Models.AggregationGranularity? aggregationGranularity = default(Azure.ResourceManager.Commerce.Models.AggregationGranularity?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Commerce.Models
{
    public enum AggregationGranularity
    {
        Daily = 0,
        Hourly = 1,
    }
    public static partial class ArmCommerceModelFactory
    {
        public static Azure.ResourceManager.Commerce.Models.MeterInfo MeterInfo(System.Guid? meterId = default(System.Guid?), string meterName = null, string meterCategory = null, string meterSubCategory = null, string unit = null, System.Collections.Generic.IEnumerable<string> meterTags = null, string meterRegion = null, System.Collections.Generic.IDictionary<string, float> meterRates = null, System.DateTimeOffset? effectiveOn = default(System.DateTimeOffset?), float? includedQuantity = default(float?)) { throw null; }
        public static Azure.ResourceManager.Commerce.Models.MonetaryCommitment MonetaryCommitment(System.DateTimeOffset? effectiveOn = default(System.DateTimeOffset?), System.Collections.Generic.IDictionary<string, decimal> tieredDiscount = null, System.Collections.Generic.IEnumerable<System.Guid> excludedMeterIds = null) { throw null; }
        public static Azure.ResourceManager.Commerce.Models.MonetaryCredit MonetaryCredit(System.DateTimeOffset? effectiveOn = default(System.DateTimeOffset?), decimal? credit = default(decimal?), System.Collections.Generic.IEnumerable<System.Guid> excludedMeterIds = null) { throw null; }
        public static Azure.ResourceManager.Commerce.Models.OfferTermInfo OfferTermInfo(string name = null, System.DateTimeOffset? effectiveOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Commerce.Models.RecurringCharge RecurringCharge(System.DateTimeOffset? effectiveOn = default(System.DateTimeOffset?), int? amount = default(int?)) { throw null; }
        public static Azure.ResourceManager.Commerce.Models.ResourceRateCardInfo ResourceRateCardInfo(string currency = null, string locale = null, bool? isTaxIncluded = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Commerce.Models.OfferTermInfo> offerTerms = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Commerce.Models.MeterInfo> meters = null) { throw null; }
        public static Azure.ResourceManager.Commerce.Models.UsageAggregation UsageAggregation(string id = null, string name = null, string type = null, System.Guid? subscriptionId = default(System.Guid?), string meterId = null, System.DateTimeOffset? usageStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? usageEndOn = default(System.DateTimeOffset?), float? quantity = default(float?), string unit = null, string meterName = null, string meterCategory = null, string meterSubCategory = null, string meterRegion = null, System.BinaryData infoFields = null, string instanceData = null) { throw null; }
    }
    public partial class MeterInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.MeterInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.MeterInfo>
    {
        internal MeterInfo() { }
        public System.DateTimeOffset? EffectiveOn { get { throw null; } }
        public float? IncludedQuantity { get { throw null; } }
        public string MeterCategory { get { throw null; } }
        public System.Guid? MeterId { get { throw null; } }
        public string MeterName { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, float> MeterRates { get { throw null; } }
        public string MeterRegion { get { throw null; } }
        public string MeterSubCategory { get { throw null; } }
        public System.Collections.Generic.IList<string> MeterTags { get { throw null; } }
        public string Unit { get { throw null; } }
        protected virtual Azure.ResourceManager.Commerce.Models.MeterInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Commerce.Models.MeterInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Commerce.Models.MeterInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.MeterInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.MeterInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Commerce.Models.MeterInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.MeterInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.MeterInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.MeterInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonetaryCommitment : Azure.ResourceManager.Commerce.Models.OfferTermInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.MonetaryCommitment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.MonetaryCommitment>
    {
        internal MonetaryCommitment() { }
        public System.Collections.Generic.IList<System.Guid> ExcludedMeterIds { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, decimal> TieredDiscount { get { throw null; } }
        protected override Azure.ResourceManager.Commerce.Models.OfferTermInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Commerce.Models.OfferTermInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Commerce.Models.MonetaryCommitment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.MonetaryCommitment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.MonetaryCommitment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Commerce.Models.MonetaryCommitment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.MonetaryCommitment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.MonetaryCommitment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.MonetaryCommitment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonetaryCredit : Azure.ResourceManager.Commerce.Models.OfferTermInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.MonetaryCredit>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.MonetaryCredit>
    {
        internal MonetaryCredit() { }
        public decimal? Credit { get { throw null; } }
        public System.Collections.Generic.IList<System.Guid> ExcludedMeterIds { get { throw null; } }
        protected override Azure.ResourceManager.Commerce.Models.OfferTermInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Commerce.Models.OfferTermInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Commerce.Models.MonetaryCredit System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.MonetaryCredit>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.MonetaryCredit>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Commerce.Models.MonetaryCredit System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.MonetaryCredit>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.MonetaryCredit>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.MonetaryCredit>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class OfferTermInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.OfferTermInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.OfferTermInfo>
    {
        internal OfferTermInfo() { }
        public System.DateTimeOffset? EffectiveOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Commerce.Models.OfferTermInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Commerce.Models.OfferTermInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Commerce.Models.OfferTermInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.OfferTermInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.OfferTermInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Commerce.Models.OfferTermInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.OfferTermInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.OfferTermInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.OfferTermInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecurringCharge : Azure.ResourceManager.Commerce.Models.OfferTermInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.RecurringCharge>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.RecurringCharge>
    {
        internal RecurringCharge() { }
        public int? Amount { get { throw null; } }
        protected override Azure.ResourceManager.Commerce.Models.OfferTermInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Commerce.Models.OfferTermInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Commerce.Models.RecurringCharge System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.RecurringCharge>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.RecurringCharge>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Commerce.Models.RecurringCharge System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.RecurringCharge>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.RecurringCharge>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.RecurringCharge>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceRateCardInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.ResourceRateCardInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.ResourceRateCardInfo>
    {
        internal ResourceRateCardInfo() { }
        public string Currency { get { throw null; } }
        public bool? IsTaxIncluded { get { throw null; } }
        public string Locale { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Commerce.Models.MeterInfo> Meters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Commerce.Models.OfferTermInfo> OfferTerms { get { throw null; } }
        protected virtual Azure.ResourceManager.Commerce.Models.ResourceRateCardInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Commerce.Models.ResourceRateCardInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Commerce.Models.ResourceRateCardInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.ResourceRateCardInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.ResourceRateCardInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Commerce.Models.ResourceRateCardInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.ResourceRateCardInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.ResourceRateCardInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.ResourceRateCardInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UsageAggregation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.UsageAggregation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.UsageAggregation>
    {
        internal UsageAggregation() { }
        public string Id { get { throw null; } }
        public System.BinaryData InfoFields { get { throw null; } }
        public string InstanceData { get { throw null; } }
        public string MeterCategory { get { throw null; } }
        public string MeterId { get { throw null; } }
        public string MeterName { get { throw null; } }
        public string MeterRegion { get { throw null; } }
        public string MeterSubCategory { get { throw null; } }
        public string Name { get { throw null; } }
        public float? Quantity { get { throw null; } }
        public System.Guid? SubscriptionId { get { throw null; } }
        public string Type { get { throw null; } }
        public string Unit { get { throw null; } }
        public System.DateTimeOffset? UsageEndOn { get { throw null; } }
        public System.DateTimeOffset? UsageStartOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Commerce.Models.UsageAggregation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Commerce.Models.UsageAggregation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Commerce.Models.UsageAggregation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.UsageAggregation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.UsageAggregation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Commerce.Models.UsageAggregation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.UsageAggregation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.UsageAggregation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.UsageAggregation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
