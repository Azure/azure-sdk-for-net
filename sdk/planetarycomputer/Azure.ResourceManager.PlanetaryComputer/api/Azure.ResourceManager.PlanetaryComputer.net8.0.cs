namespace Azure.ResourceManager.PlanetaryComputer
{
    public partial class AzureResourceManagerPlanetaryComputerContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerPlanetaryComputerContext() { }
        public static Azure.ResourceManager.PlanetaryComputer.AzureResourceManagerPlanetaryComputerContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class PlanetaryComputerExtensions
    {
        public static Azure.Response<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource> GetPlanetaryComputerGeoCatalog(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource>> GetPlanetaryComputerGeoCatalogAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource GetPlanetaryComputerGeoCatalogResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogCollection GetPlanetaryComputerGeoCatalogs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource> GetPlanetaryComputerGeoCatalogs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource> GetPlanetaryComputerGeoCatalogsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PlanetaryComputerGeoCatalogCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource>, System.Collections.IEnumerable
    {
        protected PlanetaryComputerGeoCatalogCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string catalogName, Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string catalogName, Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource> Get(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource>> GetAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource> GetIfExists(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource>> GetIfExistsAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PlanetaryComputerGeoCatalogData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogData>
    {
        public PlanetaryComputerGeoCatalogData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlanetaryComputerGeoCatalogResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PlanetaryComputerGeoCatalogResource() { }
        public virtual Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string catalogName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PlanetaryComputer.Mocking
{
    public partial class MockablePlanetaryComputerArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockablePlanetaryComputerArmClient() { }
        public virtual Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource GetPlanetaryComputerGeoCatalogResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockablePlanetaryComputerResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePlanetaryComputerResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource> GetPlanetaryComputerGeoCatalog(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource>> GetPlanetaryComputerGeoCatalogAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogCollection GetPlanetaryComputerGeoCatalogs() { throw null; }
    }
    public partial class MockablePlanetaryComputerSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockablePlanetaryComputerSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource> GetPlanetaryComputerGeoCatalogs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogResource> GetPlanetaryComputerGeoCatalogsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.PlanetaryComputer.Models
{
    public static partial class ArmPlanetaryComputerModelFactory
    {
        public static Azure.ResourceManager.PlanetaryComputer.PlanetaryComputerGeoCatalogData PlanetaryComputerGeoCatalogData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogPatch PlanetaryComputerGeoCatalogPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogProperties PlanetaryComputerGeoCatalogProperties(Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogTier? tier = default(Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogTier?), System.Uri catalogUri = null, Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerProvisioningState? provisioningState = default(Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerProvisioningState?), Azure.ResourceManager.PlanetaryComputer.Models.AutoGeneratedDomainNameLabelScope? autoGeneratedDomainNameLabelScope = default(Azure.ResourceManager.PlanetaryComputer.Models.AutoGeneratedDomainNameLabelScope?)) { throw null; }
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
        public static implicit operator Azure.ResourceManager.PlanetaryComputer.Models.AutoGeneratedDomainNameLabelScope? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlanetaryComputer.Models.AutoGeneratedDomainNameLabelScope left, Azure.ResourceManager.PlanetaryComputer.Models.AutoGeneratedDomainNameLabelScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PlanetaryComputerGeoCatalogPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogPatch>
    {
        public PlanetaryComputerGeoCatalogPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlanetaryComputerGeoCatalogProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogProperties>
    {
        public PlanetaryComputerGeoCatalogProperties() { }
        public Azure.ResourceManager.PlanetaryComputer.Models.AutoGeneratedDomainNameLabelScope? AutoGeneratedDomainNameLabelScope { get { throw null; } set { } }
        public System.Uri CatalogUri { get { throw null; } }
        public Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogTier? Tier { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlanetaryComputerGeoCatalogTier : System.IEquatable<Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlanetaryComputerGeoCatalogTier(string value) { throw null; }
        public static Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogTier Basic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogTier left, Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogTier (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogTier? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogTier left, Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerGeoCatalogTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PlanetaryComputerProvisioningState : System.IEquatable<Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PlanetaryComputerProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerProvisioningState left, Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerProvisioningState left, Azure.ResourceManager.PlanetaryComputer.Models.PlanetaryComputerProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
