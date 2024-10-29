namespace Azure.ResourceManager.Sku
{
    public static partial class SkuExtensions
    {
        public static Azure.Pageable<Azure.ResourceManager.Sku.Models.SkuResourceSku> GetComputeResourceSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, string includeExtendedLocations = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Sku.Models.SkuResourceSku> GetComputeResourceSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, string includeExtendedLocations = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Sku.Mocking
{
    public partial class MockableSkuSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSkuSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Sku.Models.SkuResourceSku> GetComputeResourceSkus(string filter = null, string includeExtendedLocations = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Sku.Models.SkuResourceSku> GetComputeResourceSkusAsync(string filter = null, string includeExtendedLocations = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Sku.Models
{
    public static partial class ArmSkuModelFactory
    {
        public static Azure.ResourceManager.Sku.Models.ComputeResourceSkuCapabilities ComputeResourceSkuCapabilities(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.Sku.Models.ResourceSkuCosts ResourceSkuCosts(string meterId = null, long? quantity = default(long?), string extendedUnit = null) { throw null; }
        public static Azure.ResourceManager.Sku.Models.SkuResourceSku SkuResourceSku(string resourceType = null, string name = null, string tier = null, string size = null, string family = null, string kind = null, Azure.ResourceManager.Sku.Models.SkuResourceSkuCapacity capacity = null, System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> locations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sku.Models.SkuResourceSkuLocationInfo> locationInfo = null, System.Collections.Generic.IEnumerable<string> apiVersions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sku.Models.ResourceSkuCosts> costs = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sku.Models.ComputeResourceSkuCapabilities> capabilities = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sku.Models.SkuResourceSkuRestrictions> restrictions = null) { throw null; }
        public static Azure.ResourceManager.Sku.Models.SkuResourceSkuCapacity SkuResourceSkuCapacity(long? minimum = default(long?), long? maximum = default(long?), long? @default = default(long?), Azure.ResourceManager.Sku.Models.SkuResourceSkuCapacityScaleType? scaleType = default(Azure.ResourceManager.Sku.Models.SkuResourceSkuCapacityScaleType?)) { throw null; }
        public static Azure.ResourceManager.Sku.Models.SkuResourceSkuLocationInfo SkuResourceSkuLocationInfo(Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), System.Collections.Generic.IEnumerable<string> zones = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sku.Models.SkuResourceSkuZoneDetails> zoneDetails = null, System.Collections.Generic.IEnumerable<string> extendedLocations = null, Azure.ResourceManager.Sku.Models.ExtendedLocationType? extendedLocationType = default(Azure.ResourceManager.Sku.Models.ExtendedLocationType?)) { throw null; }
        public static Azure.ResourceManager.Sku.Models.SkuResourceSkuRestrictionInfo SkuResourceSkuRestrictionInfo(System.Collections.Generic.IEnumerable<Azure.Core.AzureLocation> locations = null, System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.Sku.Models.SkuResourceSkuRestrictions SkuResourceSkuRestrictions(Azure.ResourceManager.Sku.Models.SkuResourceSkuRestrictionsType? restrictionsType = default(Azure.ResourceManager.Sku.Models.SkuResourceSkuRestrictionsType?), System.Collections.Generic.IEnumerable<string> values = null, Azure.ResourceManager.Sku.Models.SkuResourceSkuRestrictionInfo restrictionInfo = null, Azure.ResourceManager.Sku.Models.SkuResourceSkuRestrictionsReasonCode? reasonCode = default(Azure.ResourceManager.Sku.Models.SkuResourceSkuRestrictionsReasonCode?)) { throw null; }
        public static Azure.ResourceManager.Sku.Models.SkuResourceSkuZoneDetails SkuResourceSkuZoneDetails(System.Collections.Generic.IEnumerable<string> name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Sku.Models.ComputeResourceSkuCapabilities> capabilities = null) { throw null; }
    }
    public partial class ComputeResourceSkuCapabilities : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sku.Models.ComputeResourceSkuCapabilities>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.ComputeResourceSkuCapabilities>
    {
        internal ComputeResourceSkuCapabilities() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sku.Models.ComputeResourceSkuCapabilities System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sku.Models.ComputeResourceSkuCapabilities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sku.Models.ComputeResourceSkuCapabilities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sku.Models.ComputeResourceSkuCapabilities System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.ComputeResourceSkuCapabilities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.ComputeResourceSkuCapabilities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.ComputeResourceSkuCapabilities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtendedLocationType : System.IEquatable<Azure.ResourceManager.Sku.Models.ExtendedLocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtendedLocationType(string value) { throw null; }
        public static Azure.ResourceManager.Sku.Models.ExtendedLocationType EdgeZone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Sku.Models.ExtendedLocationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Sku.Models.ExtendedLocationType left, Azure.ResourceManager.Sku.Models.ExtendedLocationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Sku.Models.ExtendedLocationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Sku.Models.ExtendedLocationType left, Azure.ResourceManager.Sku.Models.ExtendedLocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceSkuCosts : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sku.Models.ResourceSkuCosts>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.ResourceSkuCosts>
    {
        internal ResourceSkuCosts() { }
        public string ExtendedUnit { get { throw null; } }
        public string MeterId { get { throw null; } }
        public long? Quantity { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sku.Models.ResourceSkuCosts System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sku.Models.ResourceSkuCosts>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sku.Models.ResourceSkuCosts>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sku.Models.ResourceSkuCosts System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.ResourceSkuCosts>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.ResourceSkuCosts>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.ResourceSkuCosts>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkuResourceSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sku.Models.SkuResourceSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.SkuResourceSku>
    {
        internal SkuResourceSku() { }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sku.Models.ComputeResourceSkuCapabilities> Capabilities { get { throw null; } }
        public Azure.ResourceManager.Sku.Models.SkuResourceSkuCapacity Capacity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sku.Models.ResourceSkuCosts> Costs { get { throw null; } }
        public string Family { get { throw null; } }
        public string Kind { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sku.Models.SkuResourceSkuLocationInfo> LocationInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sku.Models.SkuResourceSkuRestrictions> Restrictions { get { throw null; } }
        public string Size { get { throw null; } }
        public string Tier { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sku.Models.SkuResourceSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sku.Models.SkuResourceSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sku.Models.SkuResourceSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sku.Models.SkuResourceSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.SkuResourceSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.SkuResourceSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.SkuResourceSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkuResourceSkuCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuCapacity>
    {
        internal SkuResourceSkuCapacity() { }
        public long? Default { get { throw null; } }
        public long? Maximum { get { throw null; } }
        public long? Minimum { get { throw null; } }
        public Azure.ResourceManager.Sku.Models.SkuResourceSkuCapacityScaleType? ScaleType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sku.Models.SkuResourceSkuCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sku.Models.SkuResourceSkuCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SkuResourceSkuCapacityScaleType
    {
        None = 0,
        Automatic = 1,
        Manual = 2,
    }
    public partial class SkuResourceSkuLocationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuLocationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuLocationInfo>
    {
        internal SkuResourceSkuLocationInfo() { }
        public System.Collections.Generic.IReadOnlyList<string> ExtendedLocations { get { throw null; } }
        public Azure.ResourceManager.Sku.Models.ExtendedLocationType? ExtendedLocationType { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sku.Models.SkuResourceSkuZoneDetails> ZoneDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sku.Models.SkuResourceSkuLocationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuLocationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuLocationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sku.Models.SkuResourceSkuLocationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuLocationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuLocationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuLocationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkuResourceSkuRestrictionInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuRestrictionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuRestrictionInfo>
    {
        internal SkuResourceSkuRestrictionInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.AzureLocation> Locations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sku.Models.SkuResourceSkuRestrictionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuRestrictionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuRestrictionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sku.Models.SkuResourceSkuRestrictionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuRestrictionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuRestrictionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuRestrictionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SkuResourceSkuRestrictions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuRestrictions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuRestrictions>
    {
        internal SkuResourceSkuRestrictions() { }
        public Azure.ResourceManager.Sku.Models.SkuResourceSkuRestrictionsReasonCode? ReasonCode { get { throw null; } }
        public Azure.ResourceManager.Sku.Models.SkuResourceSkuRestrictionInfo RestrictionInfo { get { throw null; } }
        public Azure.ResourceManager.Sku.Models.SkuResourceSkuRestrictionsType? RestrictionsType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sku.Models.SkuResourceSkuRestrictions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuRestrictions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuRestrictions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sku.Models.SkuResourceSkuRestrictions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuRestrictions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuRestrictions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuRestrictions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SkuResourceSkuRestrictionsReasonCode
    {
        QuotaId = 0,
        NotAvailableForSubscription = 1,
    }
    public enum SkuResourceSkuRestrictionsType
    {
        Location = 0,
        Zone = 1,
    }
    public partial class SkuResourceSkuZoneDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuZoneDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuZoneDetails>
    {
        internal SkuResourceSkuZoneDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Sku.Models.ComputeResourceSkuCapabilities> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sku.Models.SkuResourceSkuZoneDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuZoneDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuZoneDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Sku.Models.SkuResourceSkuZoneDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuZoneDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuZoneDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Sku.Models.SkuResourceSkuZoneDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
