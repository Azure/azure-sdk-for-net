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
        public static Azure.Response<Azure.ResourceManager.Commerce.Models.CommerceRateCardInfo> GetRateCard(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Commerce.Models.CommerceRateCardInfo>> GetRateCardAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Commerce.Models.CommerceUsageAggregation> GetUsageAggregates(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.DateTimeOffset reportedStartsOn, System.DateTimeOffset reportedEndsOn, bool? showDetails = default(bool?), Azure.ResourceManager.Commerce.Models.CommerceUsageAggregationGranularity? aggregationGranularity = default(Azure.ResourceManager.Commerce.Models.CommerceUsageAggregationGranularity?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Commerce.Models.CommerceUsageAggregation> GetUsageAggregatesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.DateTimeOffset reportedStartsOn, System.DateTimeOffset reportedEndsOn, bool? showDetails = default(bool?), Azure.ResourceManager.Commerce.Models.CommerceUsageAggregationGranularity? aggregationGranularity = default(Azure.ResourceManager.Commerce.Models.CommerceUsageAggregationGranularity?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Commerce.Mocking
{
    public partial class MockableCommerceSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableCommerceSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Commerce.Models.CommerceRateCardInfo> GetRateCard(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Commerce.Models.CommerceRateCardInfo>> GetRateCardAsync(string filter, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Commerce.Models.CommerceUsageAggregation> GetUsageAggregates(System.DateTimeOffset reportedStartsOn, System.DateTimeOffset reportedEndsOn, bool? showDetails = default(bool?), Azure.ResourceManager.Commerce.Models.CommerceUsageAggregationGranularity? aggregationGranularity = default(Azure.ResourceManager.Commerce.Models.CommerceUsageAggregationGranularity?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Commerce.Models.CommerceUsageAggregation> GetUsageAggregatesAsync(System.DateTimeOffset reportedStartsOn, System.DateTimeOffset reportedEndsOn, bool? showDetails = default(bool?), Azure.ResourceManager.Commerce.Models.CommerceUsageAggregationGranularity? aggregationGranularity = default(Azure.ResourceManager.Commerce.Models.CommerceUsageAggregationGranularity?), string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Commerce.Models
{
    public static partial class ArmCommerceModelFactory
    {
        public static Azure.ResourceManager.Commerce.Models.CommerceMeterInfo CommerceMeterInfo(System.Guid? meterId = default(System.Guid?), string meterName = null, string meterCategory = null, string meterSubCategory = null, string unit = null, System.Collections.Generic.IEnumerable<string> meterTags = null, string meterRegion = null, System.Collections.Generic.IDictionary<string, float> meterRates = null, System.DateTimeOffset? effectiveOn = default(System.DateTimeOffset?), float? includedQuantity = default(float?)) { throw null; }
        public static Azure.ResourceManager.Commerce.Models.CommerceMonetaryCommitment CommerceMonetaryCommitment(System.DateTimeOffset? effectiveOn = default(System.DateTimeOffset?), System.Collections.Generic.IDictionary<string, decimal> tieredDiscount = null, System.Collections.Generic.IEnumerable<System.Guid> excludedMeterIds = null) { throw null; }
        public static Azure.ResourceManager.Commerce.Models.CommerceMonetaryCredit CommerceMonetaryCredit(System.DateTimeOffset? effectiveOn = default(System.DateTimeOffset?), decimal? credit = default(decimal?), System.Collections.Generic.IEnumerable<System.Guid> excludedMeterIds = null) { throw null; }
        public static Azure.ResourceManager.Commerce.Models.CommerceOfferTermInfo CommerceOfferTermInfo(string name = null, System.DateTimeOffset? effectiveOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Commerce.Models.CommerceRateCardInfo CommerceRateCardInfo(string currency = null, string locale = null, bool? isTaxIncluded = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Commerce.Models.CommerceOfferTermInfo> offerTerms = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Commerce.Models.CommerceMeterInfo> meters = null) { throw null; }
        public static Azure.ResourceManager.Commerce.Models.CommerceRecurringCharge CommerceRecurringCharge(System.DateTimeOffset? effectiveOn = default(System.DateTimeOffset?), int? amount = default(int?)) { throw null; }
        public static Azure.ResourceManager.Commerce.Models.CommerceUsageAggregation CommerceUsageAggregation(string id = null, string name = null, string type = null, System.Guid? subscriptionId = default(System.Guid?), string meterId = null, System.DateTimeOffset? usageStartsOn = default(System.DateTimeOffset?), System.DateTimeOffset? usageEndsOn = default(System.DateTimeOffset?), float? quantity = default(float?), string unit = null, string meterName = null, string meterCategory = null, string meterSubCategory = null, string meterRegion = null, System.BinaryData infoFields = null, string instanceData = null) { throw null; }
    }
    public partial class CommerceMeterInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.CommerceMeterInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.CommerceMeterInfo>
    {
        internal CommerceMeterInfo() { }
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
        protected virtual Azure.ResourceManager.Commerce.Models.CommerceMeterInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Commerce.Models.CommerceMeterInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Commerce.Models.CommerceMeterInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.CommerceMeterInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.CommerceMeterInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Commerce.Models.CommerceMeterInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.CommerceMeterInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.CommerceMeterInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.CommerceMeterInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommerceMonetaryCommitment : Azure.ResourceManager.Commerce.Models.CommerceOfferTermInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.CommerceMonetaryCommitment>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.CommerceMonetaryCommitment>
    {
        internal CommerceMonetaryCommitment() { }
        public System.Collections.Generic.IList<System.Guid> ExcludedMeterIds { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, decimal> TieredDiscount { get { throw null; } }
        protected override Azure.ResourceManager.Commerce.Models.CommerceOfferTermInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Commerce.Models.CommerceOfferTermInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Commerce.Models.CommerceMonetaryCommitment System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.CommerceMonetaryCommitment>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.CommerceMonetaryCommitment>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Commerce.Models.CommerceMonetaryCommitment System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.CommerceMonetaryCommitment>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.CommerceMonetaryCommitment>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.CommerceMonetaryCommitment>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommerceMonetaryCredit : Azure.ResourceManager.Commerce.Models.CommerceOfferTermInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.CommerceMonetaryCredit>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.CommerceMonetaryCredit>
    {
        internal CommerceMonetaryCredit() { }
        public decimal? Credit { get { throw null; } }
        public System.Collections.Generic.IList<System.Guid> ExcludedMeterIds { get { throw null; } }
        protected override Azure.ResourceManager.Commerce.Models.CommerceOfferTermInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Commerce.Models.CommerceOfferTermInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Commerce.Models.CommerceMonetaryCredit System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.CommerceMonetaryCredit>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.CommerceMonetaryCredit>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Commerce.Models.CommerceMonetaryCredit System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.CommerceMonetaryCredit>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.CommerceMonetaryCredit>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.CommerceMonetaryCredit>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class CommerceOfferTermInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.CommerceOfferTermInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.CommerceOfferTermInfo>
    {
        internal CommerceOfferTermInfo() { }
        public System.DateTimeOffset? EffectiveOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Commerce.Models.CommerceOfferTermInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Commerce.Models.CommerceOfferTermInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Commerce.Models.CommerceOfferTermInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.CommerceOfferTermInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.CommerceOfferTermInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Commerce.Models.CommerceOfferTermInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.CommerceOfferTermInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.CommerceOfferTermInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.CommerceOfferTermInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommerceRateCardInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.CommerceRateCardInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.CommerceRateCardInfo>
    {
        internal CommerceRateCardInfo() { }
        public string Currency { get { throw null; } }
        public bool? IsTaxIncluded { get { throw null; } }
        public string Locale { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Commerce.Models.CommerceMeterInfo> Meters { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Commerce.Models.CommerceOfferTermInfo> OfferTerms { get { throw null; } }
        protected virtual Azure.ResourceManager.Commerce.Models.CommerceRateCardInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Commerce.Models.CommerceRateCardInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Commerce.Models.CommerceRateCardInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.CommerceRateCardInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.CommerceRateCardInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Commerce.Models.CommerceRateCardInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.CommerceRateCardInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.CommerceRateCardInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.CommerceRateCardInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommerceRecurringCharge : Azure.ResourceManager.Commerce.Models.CommerceOfferTermInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.CommerceRecurringCharge>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.CommerceRecurringCharge>
    {
        internal CommerceRecurringCharge() { }
        public int? Amount { get { throw null; } }
        protected override Azure.ResourceManager.Commerce.Models.CommerceOfferTermInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected override Azure.ResourceManager.Commerce.Models.CommerceOfferTermInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Commerce.Models.CommerceRecurringCharge System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.CommerceRecurringCharge>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.CommerceRecurringCharge>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Commerce.Models.CommerceRecurringCharge System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.CommerceRecurringCharge>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.CommerceRecurringCharge>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.CommerceRecurringCharge>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CommerceUsageAggregation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.CommerceUsageAggregation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.CommerceUsageAggregation>
    {
        internal CommerceUsageAggregation() { }
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
        public System.DateTimeOffset? UsageEndsOn { get { throw null; } }
        public System.DateTimeOffset? UsageStartsOn { get { throw null; } }
        protected virtual Azure.ResourceManager.Commerce.Models.CommerceUsageAggregation JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Commerce.Models.CommerceUsageAggregation PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Commerce.Models.CommerceUsageAggregation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.CommerceUsageAggregation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Commerce.Models.CommerceUsageAggregation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Commerce.Models.CommerceUsageAggregation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.CommerceUsageAggregation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.CommerceUsageAggregation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Commerce.Models.CommerceUsageAggregation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum CommerceUsageAggregationGranularity
    {
        Daily = 0,
        Hourly = 1,
    }
}
