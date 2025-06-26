namespace Azure.ResourceManager.PlanetaryComputer
{
    public partial class AzureResourceManagerPlanetaryComputerContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerPlanetaryComputerContext() { }
        public static Azure.ResourceManager.PlanetaryComputer.AzureResourceManagerPlanetaryComputerContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class GeoCatalogCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource>, System.Collections.IEnumerable
    {
        protected GeoCatalogCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string catalogName, Azure.ResourceManager.PlanetaryComputer.GeoCatalogData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string catalogName, Azure.ResourceManager.PlanetaryComputer.GeoCatalogData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource> Get(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource>> GetAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource> GetIfExists(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource>> GetIfExistsAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GeoCatalogData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlanetaryComputer.GeoCatalogData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.GeoCatalogData>
    {
        public GeoCatalogData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.PlanetaryComputer.Models.GeoCatalogProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlanetaryComputer.GeoCatalogData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlanetaryComputer.GeoCatalogData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlanetaryComputer.GeoCatalogData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlanetaryComputer.GeoCatalogData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.GeoCatalogData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.GeoCatalogData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.GeoCatalogData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GeoCatalogResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlanetaryComputer.GeoCatalogData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.GeoCatalogData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GeoCatalogResource() { }
        public virtual Azure.ResourceManager.PlanetaryComputer.GeoCatalogData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string catalogName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PlanetaryComputer.GeoCatalogData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlanetaryComputer.GeoCatalogData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlanetaryComputer.GeoCatalogData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlanetaryComputer.GeoCatalogData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.GeoCatalogData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.GeoCatalogData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.GeoCatalogData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PlanetaryComputer.Models.GeoCatalogPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PlanetaryComputer.Models.GeoCatalogPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class PlanetaryComputerExtensions
    {
        public static Azure.Response<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource> GetGeoCatalog(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource>> GetGeoCatalogAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource GetGeoCatalogResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PlanetaryComputer.GeoCatalogCollection GetGeoCatalogs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource> GetGeoCatalogs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource> GetGeoCatalogsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PlanetaryComputer.Mocking
{
    public partial class MockablePlanetaryComputerArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockablePlanetaryComputerArmClient() { }
        public virtual Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource GetGeoCatalogResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockablePlanetaryComputerResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePlanetaryComputerResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource> GetGeoCatalog(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource>> GetGeoCatalogAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PlanetaryComputer.GeoCatalogCollection GetGeoCatalogs() { throw null; }
    }
    public partial class MockablePlanetaryComputerSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePlanetaryComputerSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource> GetGeoCatalogs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PlanetaryComputer.GeoCatalogResource> GetGeoCatalogsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PlanetaryComputer.Models
{
    public static partial class ArmPlanetaryComputerModelFactory
    {
        public static Azure.ResourceManager.PlanetaryComputer.GeoCatalogData GeoCatalogData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.PlanetaryComputer.Models.GeoCatalogProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.PlanetaryComputer.Models.GeoCatalogProperties GeoCatalogProperties(Azure.ResourceManager.PlanetaryComputer.Models.CatalogTier? tier = default(Azure.ResourceManager.PlanetaryComputer.Models.CatalogTier?), string catalogUri = null, Azure.ResourceManager.PlanetaryComputer.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.PlanetaryComputer.Models.ProvisioningState?), Azure.ResourceManager.PlanetaryComputer.Models.AutoGeneratedDomainNameLabelScope? autoGeneratedDomainNameLabelScope = default(Azure.ResourceManager.PlanetaryComputer.Models.AutoGeneratedDomainNameLabelScope?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoGeneratedDomainNameLabelScope : System.IEquatable<Azure.ResourceManager.PlanetaryComputer.Models.AutoGeneratedDomainNameLabelScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoGeneratedDomainNameLabelScope(string value) { throw null; }
        public static Azure.ResourceManager.PlanetaryComputer.Models.AutoGeneratedDomainNameLabelScope NoReuse { get { throw null; } }
        public static Azure.ResourceManager.PlanetaryComputer.Models.AutoGeneratedDomainNameLabelScope ResourceGroupReuse { get { throw null; } }
        public static Azure.ResourceManager.PlanetaryComputer.Models.AutoGeneratedDomainNameLabelScope SubscriptionReuse { get { throw null; } }
        public static Azure.ResourceManager.PlanetaryComputer.Models.AutoGeneratedDomainNameLabelScope TenantReuse { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlanetaryComputer.Models.AutoGeneratedDomainNameLabelScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlanetaryComputer.Models.AutoGeneratedDomainNameLabelScope left, Azure.ResourceManager.PlanetaryComputer.Models.AutoGeneratedDomainNameLabelScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlanetaryComputer.Models.AutoGeneratedDomainNameLabelScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlanetaryComputer.Models.AutoGeneratedDomainNameLabelScope left, Azure.ResourceManager.PlanetaryComputer.Models.AutoGeneratedDomainNameLabelScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CatalogTier : System.IEquatable<Azure.ResourceManager.PlanetaryComputer.Models.CatalogTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CatalogTier(string value) { throw null; }
        public static Azure.ResourceManager.PlanetaryComputer.Models.CatalogTier Basic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlanetaryComputer.Models.CatalogTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlanetaryComputer.Models.CatalogTier left, Azure.ResourceManager.PlanetaryComputer.Models.CatalogTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlanetaryComputer.Models.CatalogTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlanetaryComputer.Models.CatalogTier left, Azure.ResourceManager.PlanetaryComputer.Models.CatalogTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GeoCatalogPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlanetaryComputer.Models.GeoCatalogPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.Models.GeoCatalogPatch>
    {
        public GeoCatalogPatch() { }
        public Azure.ResourceManager.PlanetaryComputer.Models.ManagedServiceIdentityUpdate Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlanetaryComputer.Models.GeoCatalogPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlanetaryComputer.Models.GeoCatalogPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlanetaryComputer.Models.GeoCatalogPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlanetaryComputer.Models.GeoCatalogPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.Models.GeoCatalogPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.Models.GeoCatalogPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.Models.GeoCatalogPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GeoCatalogProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlanetaryComputer.Models.GeoCatalogProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.Models.GeoCatalogProperties>
    {
        public GeoCatalogProperties() { }
        public Azure.ResourceManager.PlanetaryComputer.Models.AutoGeneratedDomainNameLabelScope? AutoGeneratedDomainNameLabelScope { get { throw null; } set { } }
        public string CatalogUri { get { throw null; } }
        public Azure.ResourceManager.PlanetaryComputer.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.PlanetaryComputer.Models.CatalogTier? Tier { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlanetaryComputer.Models.GeoCatalogProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlanetaryComputer.Models.GeoCatalogProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlanetaryComputer.Models.GeoCatalogProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlanetaryComputer.Models.GeoCatalogProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.Models.GeoCatalogProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.Models.GeoCatalogProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.Models.GeoCatalogProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedServiceIdentityType : System.IEquatable<Azure.ResourceManager.PlanetaryComputer.Models.ManagedServiceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedServiceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.PlanetaryComputer.Models.ManagedServiceIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.PlanetaryComputer.Models.ManagedServiceIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.PlanetaryComputer.Models.ManagedServiceIdentityType SystemAssignedUserAssigned { get { throw null; } }
        public static Azure.ResourceManager.PlanetaryComputer.Models.ManagedServiceIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlanetaryComputer.Models.ManagedServiceIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlanetaryComputer.Models.ManagedServiceIdentityType left, Azure.ResourceManager.PlanetaryComputer.Models.ManagedServiceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlanetaryComputer.Models.ManagedServiceIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlanetaryComputer.Models.ManagedServiceIdentityType left, Azure.ResourceManager.PlanetaryComputer.Models.ManagedServiceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedServiceIdentityUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlanetaryComputer.Models.ManagedServiceIdentityUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.Models.ManagedServiceIdentityUpdate>
    {
        public ManagedServiceIdentityUpdate() { }
        public Azure.ResourceManager.PlanetaryComputer.Models.ManagedServiceIdentityType? Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlanetaryComputer.Models.ManagedServiceIdentityUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlanetaryComputer.Models.ManagedServiceIdentityUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlanetaryComputer.Models.ManagedServiceIdentityUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlanetaryComputer.Models.ManagedServiceIdentityUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.Models.ManagedServiceIdentityUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.Models.ManagedServiceIdentityUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.Models.ManagedServiceIdentityUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.PlanetaryComputer.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.PlanetaryComputer.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.PlanetaryComputer.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.PlanetaryComputer.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.PlanetaryComputer.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.PlanetaryComputer.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.PlanetaryComputer.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.PlanetaryComputer.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlanetaryComputer.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlanetaryComputer.Models.ProvisioningState left, Azure.ResourceManager.PlanetaryComputer.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlanetaryComputer.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlanetaryComputer.Models.ProvisioningState left, Azure.ResourceManager.PlanetaryComputer.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
