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
        public static Azure.Pageable<Azure.ResourceManager.Compute.Skus.Models.ResourceSku> GetComputeResourceSkus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, string includeExtendedLocations = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Compute.Skus.Models.ResourceSku> GetComputeResourceSkusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, string includeExtendedLocations = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Compute.Skus.Mocking
{
    public partial class MockableComputeSkusSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableComputeSkusSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Compute.Skus.Models.ResourceSku> GetComputeResourceSkus(string filter = null, string includeExtendedLocations = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Compute.Skus.Models.ResourceSku> GetComputeResourceSkusAsync(string filter = null, string includeExtendedLocations = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Compute.Skus.Models
{
    public static partial class ArmComputeSkusModelFactory
    {
        public static Azure.ResourceManager.Compute.Skus.Models.ComputeResourceSkuCapabilities ComputeResourceSkuCapabilities(string name = null, string value = null) { throw null; }
        public static Azure.ResourceManager.Compute.Skus.Models.ResourceSku ResourceSku(string resourceType = null, string name = null, string tier = null, string size = null, string family = null, string kind = null, Azure.ResourceManager.Compute.Skus.Models.ResourceSkuCapacity capacity = null, System.Collections.Generic.IEnumerable<string> locations = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuLocationInfo> locationInfo = null, System.Collections.Generic.IEnumerable<string> apiVersions = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuCosts> costs = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Skus.Models.ComputeResourceSkuCapabilities> capabilities = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuRestrictions> restrictions = null) { throw null; }
        public static Azure.ResourceManager.Compute.Skus.Models.ResourceSkuCapacity ResourceSkuCapacity(long? minimum = default(long?), long? maximum = default(long?), long? @default = default(long?), Azure.ResourceManager.Compute.Skus.Models.ResourceSkuCapacityScaleType? scaleType = default(Azure.ResourceManager.Compute.Skus.Models.ResourceSkuCapacityScaleType?)) { throw null; }
        public static Azure.ResourceManager.Compute.Skus.Models.ResourceSkuCosts ResourceSkuCosts(string meterId = null, long? quantity = default(long?), string extendedUnit = null) { throw null; }
        public static Azure.ResourceManager.Compute.Skus.Models.ResourceSkuLocationInfo ResourceSkuLocationInfo(string location = null, System.Collections.Generic.IEnumerable<string> zones = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuZoneDetails> zoneDetails = null, System.Collections.Generic.IEnumerable<string> extendedLocations = null, Azure.ResourceManager.Compute.Skus.Models.ExtendedLocationType? extendedLocationType = default(Azure.ResourceManager.Compute.Skus.Models.ExtendedLocationType?)) { throw null; }
        public static Azure.ResourceManager.Compute.Skus.Models.ResourceSkuRestrictionInfo ResourceSkuRestrictionInfo(System.Collections.Generic.IEnumerable<string> locations = null, System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.Compute.Skus.Models.ResourceSkuRestrictions ResourceSkuRestrictions(Azure.ResourceManager.Compute.Skus.Models.ResourceSkuRestrictionsType? restrictionsType = default(Azure.ResourceManager.Compute.Skus.Models.ResourceSkuRestrictionsType?), System.Collections.Generic.IEnumerable<string> values = null, Azure.ResourceManager.Compute.Skus.Models.ResourceSkuRestrictionInfo restrictionInfo = null, Azure.ResourceManager.Compute.Skus.Models.ResourceSkuRestrictionsReasonCode? reasonCode = default(Azure.ResourceManager.Compute.Skus.Models.ResourceSkuRestrictionsReasonCode?)) { throw null; }
        public static Azure.ResourceManager.Compute.Skus.Models.ResourceSkuZoneDetails ResourceSkuZoneDetails(System.Collections.Generic.IEnumerable<string> name = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Compute.Skus.Models.ComputeResourceSkuCapabilities> capabilities = null) { throw null; }
    }
    public partial class ComputeResourceSkuCapabilities : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Skus.Models.ComputeResourceSkuCapabilities>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ComputeResourceSkuCapabilities>
    {
        internal ComputeResourceSkuCapabilities() { }
        public string Name { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Skus.Models.ComputeResourceSkuCapabilities System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Skus.Models.ComputeResourceSkuCapabilities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Skus.Models.ComputeResourceSkuCapabilities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Skus.Models.ComputeResourceSkuCapabilities System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ComputeResourceSkuCapabilities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ComputeResourceSkuCapabilities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ComputeResourceSkuCapabilities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExtendedLocationType : System.IEquatable<Azure.ResourceManager.Compute.Skus.Models.ExtendedLocationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExtendedLocationType(string value) { throw null; }
        public static Azure.ResourceManager.Compute.Skus.Models.ExtendedLocationType EdgeZone { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Compute.Skus.Models.ExtendedLocationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Compute.Skus.Models.ExtendedLocationType left, Azure.ResourceManager.Compute.Skus.Models.ExtendedLocationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Compute.Skus.Models.ExtendedLocationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Compute.Skus.Models.ExtendedLocationType left, Azure.ResourceManager.Compute.Skus.Models.ExtendedLocationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSku>
    {
        internal ResourceSku() { }
        public System.Collections.Generic.IReadOnlyList<string> ApiVersions { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Skus.Models.ComputeResourceSkuCapabilities> Capabilities { get { throw null; } }
        public Azure.ResourceManager.Compute.Skus.Models.ResourceSkuCapacity Capacity { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuCosts> Costs { get { throw null; } }
        public string Family { get { throw null; } }
        public string Kind { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuLocationInfo> LocationInfo { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuRestrictions> Restrictions { get { throw null; } }
        public string Size { get { throw null; } }
        public string Tier { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Skus.Models.ResourceSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Skus.Models.ResourceSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSkuCapacity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuCapacity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuCapacity>
    {
        internal ResourceSkuCapacity() { }
        public long? Default { get { throw null; } }
        public long? Maximum { get { throw null; } }
        public long? Minimum { get { throw null; } }
        public Azure.ResourceManager.Compute.Skus.Models.ResourceSkuCapacityScaleType? ScaleType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Skus.Models.ResourceSkuCapacity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuCapacity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuCapacity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Skus.Models.ResourceSkuCapacity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuCapacity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuCapacity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuCapacity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ResourceSkuCapacityScaleType
    {
        None = 0,
        Automatic = 1,
        Manual = 2,
    }
    public partial class ResourceSkuCosts : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuCosts>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuCosts>
    {
        internal ResourceSkuCosts() { }
        public string ExtendedUnit { get { throw null; } }
        public string MeterID { get { throw null; } }
        public long? Quantity { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Skus.Models.ResourceSkuCosts System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuCosts>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuCosts>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Skus.Models.ResourceSkuCosts System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuCosts>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuCosts>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuCosts>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSkuLocationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuLocationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuLocationInfo>
    {
        internal ResourceSkuLocationInfo() { }
        public System.Collections.Generic.IReadOnlyList<string> ExtendedLocations { get { throw null; } }
        public Azure.ResourceManager.Compute.Skus.Models.ExtendedLocationType? ExtendedLocationType { get { throw null; } }
        public string Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuZoneDetails> ZoneDetails { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Skus.Models.ResourceSkuLocationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuLocationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuLocationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Skus.Models.ResourceSkuLocationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuLocationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuLocationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuLocationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSkuRestrictionInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuRestrictionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuRestrictionInfo>
    {
        internal ResourceSkuRestrictionInfo() { }
        public System.Collections.Generic.IReadOnlyList<string> Locations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Skus.Models.ResourceSkuRestrictionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuRestrictionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuRestrictionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Skus.Models.ResourceSkuRestrictionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuRestrictionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuRestrictionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuRestrictionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceSkuRestrictions : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuRestrictions>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuRestrictions>
    {
        internal ResourceSkuRestrictions() { }
        public Azure.ResourceManager.Compute.Skus.Models.ResourceSkuRestrictionsReasonCode? ReasonCode { get { throw null; } }
        public Azure.ResourceManager.Compute.Skus.Models.ResourceSkuRestrictionInfo RestrictionInfo { get { throw null; } }
        public Azure.ResourceManager.Compute.Skus.Models.ResourceSkuRestrictionsType? RestrictionsType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Values { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Skus.Models.ResourceSkuRestrictions System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuRestrictions>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuRestrictions>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Skus.Models.ResourceSkuRestrictions System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuRestrictions>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuRestrictions>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuRestrictions>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum ResourceSkuRestrictionsReasonCode
    {
        QuotaId = 0,
        NotAvailableForSubscription = 1,
    }
    public enum ResourceSkuRestrictionsType
    {
        Location = 0,
        Zone = 1,
    }
    public partial class ResourceSkuZoneDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuZoneDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuZoneDetails>
    {
        internal ResourceSkuZoneDetails() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Compute.Skus.Models.ComputeResourceSkuCapabilities> Capabilities { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Name { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Skus.Models.ResourceSkuZoneDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuZoneDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuZoneDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Compute.Skus.Models.ResourceSkuZoneDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuZoneDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuZoneDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Compute.Skus.Models.ResourceSkuZoneDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
