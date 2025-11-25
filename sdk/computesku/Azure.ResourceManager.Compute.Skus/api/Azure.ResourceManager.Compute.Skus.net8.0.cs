namespace Azure.ResourceManager.Compute.Models
{
    public partial class ComputeResourceSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeResourceSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourceSku>
    {
        internal ComputeResourceSku() { }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapabilities> Capabilities { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapacity Capacity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ResourceSkuCosts> Costs { get { throw null; } }
        public string Family { get { throw null; } }
        public string Kind { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ComputeResourceSkuLocationInfo> LocationInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictions> Restrictions { get { throw null; } }
        public string Size { get { throw null; } }
        public string Tier { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.Models.ComputeResourceSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.Models.ComputeResourceSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.Models.ComputeResourceSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeResourceSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeResourceSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ComputeResourceSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourceSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourceSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourceSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeResourceSkuCapabilities : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapabilities>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapabilities>
    {
        internal ComputeResourceSkuCapabilities() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapabilities JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapabilities PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapabilities System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapabilities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapabilities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapabilities System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapabilities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapabilities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapabilities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeResourceSkuCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapacity>
    {
        internal ComputeResourceSkuCapacity() { }
        public long? Default { get { throw null; } }
        public long? Maximum { get { throw null; } }
        public long? Minimum { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapacityScaleType? ScaleType { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapacity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapacity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ComputeResourceSkuCapacityScaleType
    {
        None = 0,
        Automatic = 1,
        Manual = 2,
    }
    public partial class ComputeResourceSkuLocationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuLocationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuLocationInfo>
    {
        internal ComputeResourceSkuLocationInfo() { }
        public System.Collections.Generic.IReadOnlyList<string> ExtendedLocations { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocationType? ExtendedLocationType { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ComputeResourceSkuZoneDetails> ZoneDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.Models.ComputeResourceSkuLocationInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.Models.ComputeResourceSkuLocationInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.Models.ComputeResourceSkuLocationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuLocationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuLocationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ComputeResourceSkuLocationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuLocationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuLocationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuLocationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeResourceSkuRestrictionInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictionInfo>
    {
        internal ComputeResourceSkuRestrictionInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictionInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictionInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ComputeResourceSkuRestrictions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictions>
    {
        internal ComputeResourceSkuRestrictions() { }
        public Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictionsReasonCode? ReasonCode { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictionInfo RestrictionInfo { get { throw null; } }
        public Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictionsType? RestrictionsType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictions JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictions PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ComputeResourceSkuRestrictionsReasonCode
    {
        QuotaId = 0,
        NotAvailableForSubscription = 1,
    }
    public enum ComputeResourceSkuRestrictionsType
    {
        Location = 0,
        Zone = 1,
    }
    public partial class ComputeResourceSkuZoneDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuZoneDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuZoneDetails>
    {
        internal ComputeResourceSkuZoneDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapabilities> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Name { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.Models.ComputeResourceSkuZoneDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.Models.ComputeResourceSkuZoneDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.Models.ComputeResourceSkuZoneDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuZoneDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuZoneDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ComputeResourceSkuZoneDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuZoneDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuZoneDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ComputeResourceSkuZoneDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSkuCosts : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ResourceSkuCosts>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ResourceSkuCosts>
    {
        internal ResourceSkuCosts() { }
        public string ExtendedUnit { get { throw null; } }
        public string MeterId { get { throw null; } }
        public long? Quantity { get { throw null; } }
        protected virtual Azure.ResourceManager.Compute.Models.ResourceSkuCosts JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Compute.Models.ResourceSkuCosts PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Compute.Models.ResourceSkuCosts System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ResourceSkuCosts>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Models.ResourceSkuCosts>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Models.ResourceSkuCosts System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ResourceSkuCosts>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ResourceSkuCosts>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Models.ResourceSkuCosts>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.Compute.Skus
{
    public partial class AzureResourceManagerComputeSkusContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerComputeSkusContext() { }
        public static Azure.ResourceManager.Compute.Skus.AzureResourceManagerComputeSkusContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class ComputeSkusExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.Compute.Models.ComputeResourceSku> GetComputeResourceSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, string includeExtendedLocations = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.ComputeResourceSku> GetComputeResourceSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, string includeExtendedLocations = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Compute.Skus.Mocking
{
    public partial class MockableComputeSkusArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeSkusArmClient() { }
    }
    public partial class MockableComputeSkusSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeSkusSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Models.ComputeResourceSku> GetComputeResourceSkus(string filter = null, string includeExtendedLocations = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Models.ComputeResourceSku> GetComputeResourceSkusAsync(string filter = null, string includeExtendedLocations = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Compute.Skus.Models
{
    public static partial class ArmComputeSkusModelFactory
    {
        public static Azure.ResourceManager.Compute.Models.ComputeResourceSku ComputeResourceSku(string resourceType = null, string name = null, string tier = null, string size = null, string family = null, string kind = null, Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapacity capacity = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> locations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.ComputeResourceSkuLocationInfo> locationInfo = null, System.Collections.Generic.IEnumerable<string> apiVersions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.ResourceSkuCosts> costs = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapabilities> capabilities = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictions> restrictions = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapabilities ComputeResourceSkuCapabilities(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapacity ComputeResourceSkuCapacity(long? minimum = default(long?), long? maximum = default(long?), long? @default = default(long?), Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapacityScaleType? scaleType = default(Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapacityScaleType?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ComputeResourceSkuLocationInfo ComputeResourceSkuLocationInfo(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IEnumerable<string> zones = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.ComputeResourceSkuZoneDetails> zoneDetails = null, System.Collections.Generic.IEnumerable<string> extendedLocations = null, Azure.ResourceManager.Resources.Models.ExtendedLocationType? extendedLocationType = default(Azure.ResourceManager.Resources.Models.ExtendedLocationType?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictionInfo ComputeResourceSkuRestrictionInfo(System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> locations = null, System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictions ComputeResourceSkuRestrictions(Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictionsType? restrictionsType = default(Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictionsType?), System.Collections.Generic.IEnumerable<string> values = null, Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictionInfo restrictionInfo = null, Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictionsReasonCode? reasonCode = default(Azure.ResourceManager.Compute.Models.ComputeResourceSkuRestrictionsReasonCode?)) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ComputeResourceSkuZoneDetails ComputeResourceSkuZoneDetails(System.Collections.Generic.IEnumerable<string> name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Models.ComputeResourceSkuCapabilities> capabilities = null) { throw null; }
        public static Azure.ResourceManager.Compute.Models.ResourceSkuCosts ResourceSkuCosts(string meterId = null, long? quantity = default(long?), string extendedUnit = null) { throw null; }
    }
}
