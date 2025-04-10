namespace Azure.ResourceManager.LambdaTestHyperExecute
{
    public static partial class LambdaTestHyperExecuteExtensions
    {
        public static Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource GetOrganizationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource> GetOrganizationResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource>> GetOrganizationResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResourceCollection GetOrganizationResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource> GetOrganizationResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource> GetOrganizationResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OrganizationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OrganizationResource() { }
        public virtual Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationname) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource> Update(Azure.ResourceManager.LambdaTestHyperExecute.Models.OrganizationResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource>> UpdateAsync(Azure.ResourceManager.LambdaTestHyperExecute.Models.OrganizationResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OrganizationResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource>, System.Collections.IEnumerable
    {
        protected OrganizationResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string organizationname, Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string organizationname, Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource> Get(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource>> GetAsync(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource> GetIfExists(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource>> GetIfExistsAsync(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OrganizationResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResourceData>
    {
        public OrganizationResourceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.LambdaTestHyperExecute.Models.OrganizationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.LambdaTestHyperExecute.Mocking
{
    public partial class MockableLambdaTestHyperExecuteArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableLambdaTestHyperExecuteArmClient() { }
        public virtual Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource GetOrganizationResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableLambdaTestHyperExecuteResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableLambdaTestHyperExecuteResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource> GetOrganizationResource(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource>> GetOrganizationResourceAsync(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResourceCollection GetOrganizationResources() { throw null; }
    }
    public partial class MockableLambdaTestHyperExecuteSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableLambdaTestHyperExecuteSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource> GetOrganizationResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResource> GetOrganizationResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.LambdaTestHyperExecute.Models
{
    public static partial class ArmLambdaTestHyperExecuteModelFactory
    {
        public static Azure.ResourceManager.LambdaTestHyperExecute.Models.MarketplaceDetails MarketplaceDetails(string subscriptionId = null, Azure.ResourceManager.LambdaTestHyperExecute.Models.MarketplaceSubscriptionStatus? subscriptionStatus = default(Azure.ResourceManager.LambdaTestHyperExecute.Models.MarketplaceSubscriptionStatus?), Azure.ResourceManager.LambdaTestHyperExecute.Models.OfferDetails offerDetails = null) { throw null; }
        public static Azure.ResourceManager.LambdaTestHyperExecute.Models.OrganizationProperties OrganizationProperties(Azure.ResourceManager.LambdaTestHyperExecute.Models.MarketplaceDetails marketplace = null, Azure.ResourceManager.LambdaTestHyperExecute.Models.UserDetails user = null, Azure.ResourceManager.LambdaTestHyperExecute.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.LambdaTestHyperExecute.Models.ResourceProvisioningState?), int? partnerLicensesSubscribed = default(int?), Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnPropertiesV2 singleSignOnProperties = null) { throw null; }
        public static Azure.ResourceManager.LambdaTestHyperExecute.OrganizationResourceData OrganizationResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.LambdaTestHyperExecute.Models.OrganizationProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
    }
    public partial class MarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.MarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.MarketplaceDetails>
    {
        public MarketplaceDetails(Azure.ResourceManager.LambdaTestHyperExecute.Models.OfferDetails offerDetails) { }
        public Azure.ResourceManager.LambdaTestHyperExecute.Models.OfferDetails OfferDetails { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.LambdaTestHyperExecute.Models.MarketplaceSubscriptionStatus? SubscriptionStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LambdaTestHyperExecute.Models.MarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.MarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.MarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LambdaTestHyperExecute.Models.MarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.MarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.MarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.MarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.LambdaTestHyperExecute.Models.MarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.LambdaTestHyperExecute.Models.MarketplaceSubscriptionStatus PendingFulfillmentStart { get { throw null; } }
        public static Azure.ResourceManager.LambdaTestHyperExecute.Models.MarketplaceSubscriptionStatus Subscribed { get { throw null; } }
        public static Azure.ResourceManager.LambdaTestHyperExecute.Models.MarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.LambdaTestHyperExecute.Models.MarketplaceSubscriptionStatus Unsubscribed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LambdaTestHyperExecute.Models.MarketplaceSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LambdaTestHyperExecute.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.LambdaTestHyperExecute.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.LambdaTestHyperExecute.Models.MarketplaceSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LambdaTestHyperExecute.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.LambdaTestHyperExecute.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OfferDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.OfferDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.OfferDetails>
    {
        public OfferDetails(string publisherId, string offerId, string planId) { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LambdaTestHyperExecute.Models.OfferDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.OfferDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.OfferDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LambdaTestHyperExecute.Models.OfferDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.OfferDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.OfferDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.OfferDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrganizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.OrganizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.OrganizationProperties>
    {
        public OrganizationProperties(Azure.ResourceManager.LambdaTestHyperExecute.Models.MarketplaceDetails marketplace, Azure.ResourceManager.LambdaTestHyperExecute.Models.UserDetails user, Azure.ResourceManager.LambdaTestHyperExecute.Models.PartnerProperties partnerProperties) { }
        public Azure.ResourceManager.LambdaTestHyperExecute.Models.MarketplaceDetails Marketplace { get { throw null; } set { } }
        public int? PartnerLicensesSubscribed { get { throw null; } set { } }
        public Azure.ResourceManager.LambdaTestHyperExecute.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnPropertiesV2 SingleSignOnProperties { get { throw null; } set { } }
        public Azure.ResourceManager.LambdaTestHyperExecute.Models.UserDetails User { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LambdaTestHyperExecute.Models.OrganizationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.OrganizationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.OrganizationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LambdaTestHyperExecute.Models.OrganizationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.OrganizationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.OrganizationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.OrganizationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrganizationResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.OrganizationResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.OrganizationResourcePatch>
    {
        public OrganizationResourcePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LambdaTestHyperExecute.Models.OrganizationResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.OrganizationResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.OrganizationResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LambdaTestHyperExecute.Models.OrganizationResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.OrganizationResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.OrganizationResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.OrganizationResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PartnerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.PartnerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.PartnerProperties>
    {
        public PartnerProperties(int licensesSubscribed) { }
        public int LicensesSubscribed { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LambdaTestHyperExecute.Models.PartnerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.PartnerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.PartnerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LambdaTestHyperExecute.Models.PartnerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.PartnerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.PartnerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.PartnerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProvisioningState : System.IEquatable<Azure.ResourceManager.LambdaTestHyperExecute.Models.ResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.LambdaTestHyperExecute.Models.ResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.LambdaTestHyperExecute.Models.ResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.LambdaTestHyperExecute.Models.ResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LambdaTestHyperExecute.Models.ResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LambdaTestHyperExecute.Models.ResourceProvisioningState left, Azure.ResourceManager.LambdaTestHyperExecute.Models.ResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.LambdaTestHyperExecute.Models.ResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LambdaTestHyperExecute.Models.ResourceProvisioningState left, Azure.ResourceManager.LambdaTestHyperExecute.Models.ResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SingleSignOnPropertiesV2 : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnPropertiesV2>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnPropertiesV2>
    {
        public SingleSignOnPropertiesV2(Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnType type) { }
        public System.Collections.Generic.IList<string> AadDomains { get { throw null; } }
        public string EnterpriseAppId { get { throw null; } set { } }
        public Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnState? State { get { throw null; } set { } }
        public Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnType Type { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnPropertiesV2 System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnPropertiesV2>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnPropertiesV2>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnPropertiesV2 System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnPropertiesV2>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnPropertiesV2>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnPropertiesV2>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SingleSignOnState : System.IEquatable<Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SingleSignOnState(string value) { throw null; }
        public static Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnState Disable { get { throw null; } }
        public static Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnState Enable { get { throw null; } }
        public static Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnState Initial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnState left, Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnState right) { throw null; }
        public static implicit operator Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnState left, Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SingleSignOnType : System.IEquatable<Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SingleSignOnType(string value) { throw null; }
        public static Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnType OpenId { get { throw null; } }
        public static Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnType Saml { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnType left, Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnType right) { throw null; }
        public static implicit operator Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnType left, Azure.ResourceManager.LambdaTestHyperExecute.Models.SingleSignOnType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.UserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.UserDetails>
    {
        public UserDetails() { }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LambdaTestHyperExecute.Models.UserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.UserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.UserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LambdaTestHyperExecute.Models.UserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.UserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.UserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.UserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
