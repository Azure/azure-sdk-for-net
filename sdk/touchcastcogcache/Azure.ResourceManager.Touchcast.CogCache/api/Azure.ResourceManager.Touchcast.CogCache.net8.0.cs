namespace Azure.ResourceManager.Touchcast.CogCache
{
    public partial class AzureResourceManagerTouchcastCogCacheContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerTouchcastCogCacheContext() { }
        public static Azure.ResourceManager.Touchcast.CogCache.AzureResourceManagerTouchcastCogCacheContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class OrganizationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Touchcast.CogCache.OrganizationResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.OrganizationResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OrganizationResource() { }
        public virtual Azure.ResourceManager.Touchcast.CogCache.OrganizationResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationname) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Touchcast.CogCache.OrganizationResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Touchcast.CogCache.OrganizationResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Touchcast.CogCache.OrganizationResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Touchcast.CogCache.OrganizationResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.OrganizationResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.OrganizationResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.OrganizationResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Touchcast.CogCache.Models.OrganizationResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Touchcast.CogCache.Models.OrganizationResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OrganizationResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource>, System.Collections.IEnumerable
    {
        protected OrganizationResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string organizationname, Azure.ResourceManager.Touchcast.CogCache.OrganizationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string organizationname, Azure.ResourceManager.Touchcast.CogCache.OrganizationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource> Get(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource>> GetAsync(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource> GetIfExists(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource>> GetIfExistsAsync(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OrganizationResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Touchcast.CogCache.OrganizationResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.OrganizationResourceData>
    {
        public OrganizationResourceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Touchcast.CogCache.Models.OrganizationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Touchcast.CogCache.OrganizationResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Touchcast.CogCache.OrganizationResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Touchcast.CogCache.OrganizationResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Touchcast.CogCache.OrganizationResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.OrganizationResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.OrganizationResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.OrganizationResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class TouchcastCogCacheExtensions
    {
        public static Azure.ResourceManager.Touchcast.CogCache.OrganizationResource GetOrganizationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource> GetOrganizationResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource>> GetOrganizationResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Touchcast.CogCache.OrganizationResourceCollection GetOrganizationResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource> GetOrganizationResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource> GetOrganizationResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Touchcast.CogCache.Mocking
{
    public partial class MockableTouchcastCogCacheArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableTouchcastCogCacheArmClient() { }
        public virtual Azure.ResourceManager.Touchcast.CogCache.OrganizationResource GetOrganizationResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableTouchcastCogCacheResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableTouchcastCogCacheResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource> GetOrganizationResource(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource>> GetOrganizationResourceAsync(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Touchcast.CogCache.OrganizationResourceCollection GetOrganizationResources() { throw null; }
    }
    public partial class MockableTouchcastCogCacheSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableTouchcastCogCacheSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource> GetOrganizationResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Touchcast.CogCache.OrganizationResource> GetOrganizationResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Touchcast.CogCache.Models
{
    public static partial class ArmTouchcastCogCacheModelFactory
    {
        public static Azure.ResourceManager.Touchcast.CogCache.Models.MarketplaceDetails MarketplaceDetails(string subscriptionId = null, Azure.ResourceManager.Touchcast.CogCache.Models.MarketplaceSubscriptionStatus? subscriptionStatus = default(Azure.ResourceManager.Touchcast.CogCache.Models.MarketplaceSubscriptionStatus?), Azure.ResourceManager.Touchcast.CogCache.Models.OfferDetails offerDetails = null) { throw null; }
        public static Azure.ResourceManager.Touchcast.CogCache.Models.OrganizationProperties OrganizationProperties(Azure.ResourceManager.Touchcast.CogCache.Models.MarketplaceDetails marketplace = null, Azure.ResourceManager.Touchcast.CogCache.Models.UserDetails user = null, Azure.ResourceManager.Touchcast.CogCache.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.Touchcast.CogCache.Models.ResourceProvisioningState?), string partnerApplication = null, Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnPropertiesV2 singleSignOnProperties = null) { throw null; }
        public static Azure.ResourceManager.Touchcast.CogCache.OrganizationResourceData OrganizationResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Touchcast.CogCache.Models.OrganizationProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
    }
    public partial class MarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Touchcast.CogCache.Models.MarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.Models.MarketplaceDetails>
    {
        public MarketplaceDetails(Azure.ResourceManager.Touchcast.CogCache.Models.OfferDetails offerDetails) { }
        public Azure.ResourceManager.Touchcast.CogCache.Models.OfferDetails OfferDetails { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.Touchcast.CogCache.Models.MarketplaceSubscriptionStatus? SubscriptionStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Touchcast.CogCache.Models.MarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Touchcast.CogCache.Models.MarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Touchcast.CogCache.Models.MarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Touchcast.CogCache.Models.MarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.Models.MarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.Models.MarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.Models.MarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.Touchcast.CogCache.Models.MarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Touchcast.CogCache.Models.MarketplaceSubscriptionStatus PendingFulfillmentStart { get { throw null; } }
        public static Azure.ResourceManager.Touchcast.CogCache.Models.MarketplaceSubscriptionStatus Subscribed { get { throw null; } }
        public static Azure.ResourceManager.Touchcast.CogCache.Models.MarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.Touchcast.CogCache.Models.MarketplaceSubscriptionStatus Unsubscribed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Touchcast.CogCache.Models.MarketplaceSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Touchcast.CogCache.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.Touchcast.CogCache.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Touchcast.CogCache.Models.MarketplaceSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Touchcast.CogCache.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.Touchcast.CogCache.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OfferDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Touchcast.CogCache.Models.OfferDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.Models.OfferDetails>
    {
        public OfferDetails(string publisherId, string offerId, string planId) { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Touchcast.CogCache.Models.OfferDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Touchcast.CogCache.Models.OfferDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Touchcast.CogCache.Models.OfferDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Touchcast.CogCache.Models.OfferDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.Models.OfferDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.Models.OfferDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.Models.OfferDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrganizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Touchcast.CogCache.Models.OrganizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.Models.OrganizationProperties>
    {
        public OrganizationProperties(Azure.ResourceManager.Touchcast.CogCache.Models.MarketplaceDetails marketplace, Azure.ResourceManager.Touchcast.CogCache.Models.UserDetails user, Azure.ResourceManager.Touchcast.CogCache.Models.PartnerProperties partnerProperties) { }
        public Azure.ResourceManager.Touchcast.CogCache.Models.MarketplaceDetails Marketplace { get { throw null; } set { } }
        public string PartnerApplication { get { throw null; } set { } }
        public Azure.ResourceManager.Touchcast.CogCache.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnPropertiesV2 SingleSignOnProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Touchcast.CogCache.Models.UserDetails User { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Touchcast.CogCache.Models.OrganizationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Touchcast.CogCache.Models.OrganizationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Touchcast.CogCache.Models.OrganizationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Touchcast.CogCache.Models.OrganizationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.Models.OrganizationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.Models.OrganizationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.Models.OrganizationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrganizationResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Touchcast.CogCache.Models.OrganizationResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.Models.OrganizationResourcePatch>
    {
        public OrganizationResourcePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Touchcast.CogCache.Models.OrganizationResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Touchcast.CogCache.Models.OrganizationResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Touchcast.CogCache.Models.OrganizationResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Touchcast.CogCache.Models.OrganizationResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.Models.OrganizationResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.Models.OrganizationResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.Models.OrganizationResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PartnerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Touchcast.CogCache.Models.PartnerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.Models.PartnerProperties>
    {
        public PartnerProperties(string application) { }
        public string Application { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Touchcast.CogCache.Models.PartnerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Touchcast.CogCache.Models.PartnerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Touchcast.CogCache.Models.PartnerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Touchcast.CogCache.Models.PartnerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.Models.PartnerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.Models.PartnerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.Models.PartnerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProvisioningState : System.IEquatable<Azure.ResourceManager.Touchcast.CogCache.Models.ResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Touchcast.CogCache.Models.ResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Touchcast.CogCache.Models.ResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Touchcast.CogCache.Models.ResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Touchcast.CogCache.Models.ResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Touchcast.CogCache.Models.ResourceProvisioningState left, Azure.ResourceManager.Touchcast.CogCache.Models.ResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Touchcast.CogCache.Models.ResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Touchcast.CogCache.Models.ResourceProvisioningState left, Azure.ResourceManager.Touchcast.CogCache.Models.ResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SingleSignOnPropertiesV2 : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnPropertiesV2>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnPropertiesV2>
    {
        public SingleSignOnPropertiesV2(Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnType type) { }
        public System.Collections.Generic.IList<string> AadDomains { get { throw null; } }
        public string EnterpriseAppId { get { throw null; } set { } }
        public Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnState? State { get { throw null; } set { } }
        public Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnType Type { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnPropertiesV2 System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnPropertiesV2>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnPropertiesV2>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnPropertiesV2 System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnPropertiesV2>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnPropertiesV2>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnPropertiesV2>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SingleSignOnState : System.IEquatable<Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SingleSignOnState(string value) { throw null; }
        public static Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnState Disable { get { throw null; } }
        public static Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnState Enable { get { throw null; } }
        public static Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnState Initial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnState left, Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnState left, Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SingleSignOnType : System.IEquatable<Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SingleSignOnType(string value) { throw null; }
        public static Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnType OpenId { get { throw null; } }
        public static Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnType Saml { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnType left, Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnType left, Azure.ResourceManager.Touchcast.CogCache.Models.SingleSignOnType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Touchcast.CogCache.Models.UserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.Models.UserDetails>
    {
        public UserDetails() { }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Touchcast.CogCache.Models.UserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Touchcast.CogCache.Models.UserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Touchcast.CogCache.Models.UserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Touchcast.CogCache.Models.UserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.Models.UserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.Models.UserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Touchcast.CogCache.Models.UserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
