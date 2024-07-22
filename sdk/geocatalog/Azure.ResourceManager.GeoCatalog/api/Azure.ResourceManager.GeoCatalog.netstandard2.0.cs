namespace Azure.ResourceManager.GeoCatalog
{
    public partial class GeoCatalogCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.GeoCatalog.GeoCatalogResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.GeoCatalog.GeoCatalogResource>, System.Collections.IEnumerable
    {
        protected GeoCatalogCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GeoCatalog.GeoCatalogResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string catalogName, Azure.ResourceManager.GeoCatalog.GeoCatalogData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.GeoCatalog.GeoCatalogResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string catalogName, Azure.ResourceManager.GeoCatalog.GeoCatalogData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GeoCatalog.GeoCatalogResource> Get(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.GeoCatalog.GeoCatalogResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.GeoCatalog.GeoCatalogResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GeoCatalog.GeoCatalogResource>> GetAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.GeoCatalog.GeoCatalogResource> GetIfExists(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.GeoCatalog.GeoCatalogResource>> GetIfExistsAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.GeoCatalog.GeoCatalogResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.GeoCatalog.GeoCatalogResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.GeoCatalog.GeoCatalogResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.GeoCatalog.GeoCatalogResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GeoCatalogData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GeoCatalog.GeoCatalogData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GeoCatalog.GeoCatalogData>
    {
        public GeoCatalogData(Azure.Core.AzureLocation location) { }
        public System.Uri CatalogUri { get { throw null; } }
        public Azure.ResourceManager.GeoCatalog.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.GeoCatalog.Models.CatalogTier? Tier { get { throw null; } set { } }
        Azure.ResourceManager.GeoCatalog.GeoCatalogData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GeoCatalog.GeoCatalogData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GeoCatalog.GeoCatalogData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GeoCatalog.GeoCatalogData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GeoCatalog.GeoCatalogData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GeoCatalog.GeoCatalogData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GeoCatalog.GeoCatalogData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class GeoCatalogExtensions
    {
        public static Azure.Response<Azure.ResourceManager.GeoCatalog.GeoCatalogResource> GetGeoCatalog(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GeoCatalog.GeoCatalogResource>> GetGeoCatalogAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.GeoCatalog.GeoCatalogResource GetGeoCatalogResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.GeoCatalog.GeoCatalogCollection GetGeoCatalogs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.GeoCatalog.GeoCatalogResource> GetGeoCatalogs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.GeoCatalog.GeoCatalogResource> GetGeoCatalogsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GeoCatalogResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GeoCatalog.GeoCatalogData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GeoCatalog.GeoCatalogData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GeoCatalogResource() { }
        public virtual Azure.ResourceManager.GeoCatalog.GeoCatalogData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.GeoCatalog.GeoCatalogResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GeoCatalog.GeoCatalogResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string catalogName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GeoCatalog.GeoCatalogResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GeoCatalog.GeoCatalogResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GeoCatalog.GeoCatalogResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GeoCatalog.GeoCatalogResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GeoCatalog.GeoCatalogResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GeoCatalog.GeoCatalogResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.GeoCatalog.GeoCatalogData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GeoCatalog.GeoCatalogData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GeoCatalog.GeoCatalogData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GeoCatalog.GeoCatalogData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GeoCatalog.GeoCatalogData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GeoCatalog.GeoCatalogData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GeoCatalog.GeoCatalogData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.GeoCatalog.GeoCatalogResource> Update(Azure.ResourceManager.GeoCatalog.Models.GeoCatalogPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GeoCatalog.GeoCatalogResource>> UpdateAsync(Azure.ResourceManager.GeoCatalog.Models.GeoCatalogPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.GeoCatalog.Mocking
{
    public partial class MockableGeoCatalogArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableGeoCatalogArmClient() { }
        public virtual Azure.ResourceManager.GeoCatalog.GeoCatalogResource GetGeoCatalogResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableGeoCatalogResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableGeoCatalogResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.GeoCatalog.GeoCatalogResource> GetGeoCatalog(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.GeoCatalog.GeoCatalogResource>> GetGeoCatalogAsync(string catalogName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.GeoCatalog.GeoCatalogCollection GetGeoCatalogs() { throw null; }
    }
    public partial class MockableGeoCatalogSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableGeoCatalogSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.GeoCatalog.GeoCatalogResource> GetGeoCatalogs(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.GeoCatalog.GeoCatalogResource> GetGeoCatalogsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.GeoCatalog.Models
{
    public static partial class ArmGeoCatalogModelFactory
    {
        public static Azure.ResourceManager.GeoCatalog.GeoCatalogData GeoCatalogData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.GeoCatalog.Models.CatalogTier? tier = default(Azure.ResourceManager.GeoCatalog.Models.CatalogTier?), System.Uri catalogUri = null, Azure.ResourceManager.GeoCatalog.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.GeoCatalog.Models.ProvisioningState?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CatalogTier : System.IEquatable<Azure.ResourceManager.GeoCatalog.Models.CatalogTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CatalogTier(string value) { throw null; }
        public static Azure.ResourceManager.GeoCatalog.Models.CatalogTier Basic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.GeoCatalog.Models.CatalogTier other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.GeoCatalog.Models.CatalogTier left, Azure.ResourceManager.GeoCatalog.Models.CatalogTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.GeoCatalog.Models.CatalogTier (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.GeoCatalog.Models.CatalogTier left, Azure.ResourceManager.GeoCatalog.Models.CatalogTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GeoCatalogPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GeoCatalog.Models.GeoCatalogPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GeoCatalog.Models.GeoCatalogPatch>
    {
        public GeoCatalogPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.GeoCatalog.Models.GeoCatalogPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GeoCatalog.Models.GeoCatalogPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.GeoCatalog.Models.GeoCatalogPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.GeoCatalog.Models.GeoCatalogPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GeoCatalog.Models.GeoCatalogPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GeoCatalog.Models.GeoCatalogPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.GeoCatalog.Models.GeoCatalogPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.GeoCatalog.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.GeoCatalog.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.GeoCatalog.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.GeoCatalog.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.GeoCatalog.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.GeoCatalog.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.GeoCatalog.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.GeoCatalog.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.GeoCatalog.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.GeoCatalog.Models.ProvisioningState left, Azure.ResourceManager.GeoCatalog.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.GeoCatalog.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.GeoCatalog.Models.ProvisioningState left, Azure.ResourceManager.GeoCatalog.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
