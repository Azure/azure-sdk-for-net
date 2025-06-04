namespace Azure.ResourceManager.Astro
{
    public static partial class AstroExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Astro.AstroOrganizationResource> GetAstroOrganization(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Astro.AstroOrganizationResource>> GetAstroOrganizationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Astro.AstroOrganizationResource GetAstroOrganizationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Astro.AstroOrganizationCollection GetAstroOrganizations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Astro.AstroOrganizationResource> GetAstroOrganizations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Astro.AstroOrganizationResource> GetAstroOrganizationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AstroOrganizationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Astro.AstroOrganizationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Astro.AstroOrganizationResource>, System.Collections.IEnumerable
    {
        protected AstroOrganizationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Astro.AstroOrganizationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string organizationName, Azure.ResourceManager.Astro.AstroOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Astro.AstroOrganizationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string organizationName, Azure.ResourceManager.Astro.AstroOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Astro.AstroOrganizationResource> Get(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Astro.AstroOrganizationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Astro.AstroOrganizationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Astro.AstroOrganizationResource>> GetAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Astro.AstroOrganizationResource> GetIfExists(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Astro.AstroOrganizationResource>> GetIfExistsAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Astro.AstroOrganizationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Astro.AstroOrganizationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Astro.AstroOrganizationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Astro.AstroOrganizationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AstroOrganizationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.AstroOrganizationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.AstroOrganizationData>
    {
        public AstroOrganizationData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Astro.Models.AstroOrganizationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.AstroOrganizationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.AstroOrganizationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.AstroOrganizationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.AstroOrganizationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.AstroOrganizationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.AstroOrganizationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.AstroOrganizationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AstroOrganizationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.AstroOrganizationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.AstroOrganizationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AstroOrganizationResource() { }
        public virtual Azure.ResourceManager.Astro.AstroOrganizationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Astro.AstroOrganizationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Astro.AstroOrganizationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Astro.AstroOrganizationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Astro.AstroOrganizationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Astro.AstroOrganizationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Astro.AstroOrganizationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Astro.AstroOrganizationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Astro.AstroOrganizationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Astro.AstroOrganizationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.AstroOrganizationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.AstroOrganizationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.AstroOrganizationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.AstroOrganizationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.AstroOrganizationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.AstroOrganizationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Astro.AstroOrganizationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Astro.Models.AstroOrganizationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Astro.AstroOrganizationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Astro.Models.AstroOrganizationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerAstroContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerAstroContext() { }
        public static Azure.ResourceManager.Astro.AzureResourceManagerAstroContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
}
namespace Azure.ResourceManager.Astro.Mocking
{
    public partial class MockableAstroArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableAstroArmClient() { }
        public virtual Azure.ResourceManager.Astro.AstroOrganizationResource GetAstroOrganizationResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableAstroResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAstroResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Astro.AstroOrganizationResource> GetAstroOrganization(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Astro.AstroOrganizationResource>> GetAstroOrganizationAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Astro.AstroOrganizationCollection GetAstroOrganizations() { throw null; }
    }
    public partial class MockableAstroSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAstroSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Astro.AstroOrganizationResource> GetAstroOrganizations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Astro.AstroOrganizationResource> GetAstroOrganizationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Astro.Models
{
    public static partial class ArmAstroModelFactory
    {
        public static Azure.ResourceManager.Astro.AstroOrganizationData AstroOrganizationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Astro.Models.AstroOrganizationProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Astro.Models.AstroOrganizationProperties AstroOrganizationProperties(Azure.ResourceManager.Astro.Models.AstroMarketplaceDetails marketplace = null, Azure.ResourceManager.Astro.Models.AstroUserDetails user = null, Azure.ResourceManager.Astro.Models.AstroResourceProvisioningState? provisioningState = default(Azure.ResourceManager.Astro.Models.AstroResourceProvisioningState?), Azure.ResourceManager.Astro.Models.AstroPartnerOrganizationProperties partnerOrganizationProperties = null) { throw null; }
        public static Azure.ResourceManager.Astro.Models.AstroSingleSignOnProperties AstroSingleSignOnProperties(Azure.ResourceManager.Astro.Models.AstroSingleSignOnState? singleSignOnState = default(Azure.ResourceManager.Astro.Models.AstroSingleSignOnState?), string enterpriseAppId = null, System.Uri singleSignOnUri = null, System.Collections.Generic.IEnumerable<string> aadDomains = null, Azure.ResourceManager.Astro.Models.AstroResourceProvisioningState? provisioningState = default(Azure.ResourceManager.Astro.Models.AstroResourceProvisioningState?)) { throw null; }
    }
    public partial class AstroMarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.AstroMarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroMarketplaceDetails>
    {
        public AstroMarketplaceDetails(string subscriptionId, Azure.ResourceManager.Astro.Models.AstroOfferDetails offerDetails) { }
        public Azure.ResourceManager.Astro.Models.AstroOfferDetails OfferDetails { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.Astro.Models.MarketplaceSubscriptionStatus? SubscriptionStatus { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.Models.AstroMarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.AstroMarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.AstroMarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.Models.AstroMarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroMarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroMarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroMarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AstroOfferDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.AstroOfferDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroOfferDetails>
    {
        public AstroOfferDetails(string publisherId, string offerId, string planId) { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.Models.AstroOfferDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.AstroOfferDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.AstroOfferDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.Models.AstroOfferDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroOfferDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroOfferDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroOfferDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AstroOrganizationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.AstroOrganizationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroOrganizationPatch>
    {
        public AstroOrganizationPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Astro.Models.AstroOrganizationUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.Models.AstroOrganizationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.AstroOrganizationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.AstroOrganizationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.Models.AstroOrganizationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroOrganizationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroOrganizationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroOrganizationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AstroOrganizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.AstroOrganizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroOrganizationProperties>
    {
        public AstroOrganizationProperties(Azure.ResourceManager.Astro.Models.AstroMarketplaceDetails marketplace, Azure.ResourceManager.Astro.Models.AstroUserDetails user) { }
        public Azure.ResourceManager.Astro.Models.AstroMarketplaceDetails Marketplace { get { throw null; } set { } }
        public Azure.ResourceManager.Astro.Models.AstroPartnerOrganizationProperties PartnerOrganizationProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Astro.Models.AstroResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Astro.Models.AstroUserDetails User { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.Models.AstroOrganizationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.AstroOrganizationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.AstroOrganizationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.Models.AstroOrganizationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroOrganizationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroOrganizationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroOrganizationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AstroOrganizationUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.AstroOrganizationUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroOrganizationUpdateProperties>
    {
        public AstroOrganizationUpdateProperties() { }
        public Azure.ResourceManager.Astro.Models.AstroPartnerOrganizationUpdateProperties PartnerOrganizationProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Astro.Models.AstroUserUpdateDetails User { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.Models.AstroOrganizationUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.AstroOrganizationUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.AstroOrganizationUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.Models.AstroOrganizationUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroOrganizationUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroOrganizationUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroOrganizationUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AstroPartnerOrganizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.AstroPartnerOrganizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroPartnerOrganizationProperties>
    {
        public AstroPartnerOrganizationProperties(string organizationName) { }
        public string OrganizationId { get { throw null; } set { } }
        public string OrganizationName { get { throw null; } set { } }
        public Azure.ResourceManager.Astro.Models.AstroSingleSignOnProperties SingleSignOnProperties { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } set { } }
        public string WorkspaceName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.Models.AstroPartnerOrganizationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.AstroPartnerOrganizationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.AstroPartnerOrganizationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.Models.AstroPartnerOrganizationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroPartnerOrganizationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroPartnerOrganizationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroPartnerOrganizationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AstroPartnerOrganizationUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.AstroPartnerOrganizationUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroPartnerOrganizationUpdateProperties>
    {
        public AstroPartnerOrganizationUpdateProperties() { }
        public string OrganizationId { get { throw null; } set { } }
        public string OrganizationName { get { throw null; } set { } }
        public Azure.ResourceManager.Astro.Models.AstroSingleSignOnProperties SingleSignOnProperties { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } set { } }
        public string WorkspaceName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.Models.AstroPartnerOrganizationUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.AstroPartnerOrganizationUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.AstroPartnerOrganizationUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.Models.AstroPartnerOrganizationUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroPartnerOrganizationUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroPartnerOrganizationUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroPartnerOrganizationUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AstroResourceProvisioningState : System.IEquatable<Azure.ResourceManager.Astro.Models.AstroResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AstroResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Astro.Models.AstroResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Astro.Models.AstroResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Astro.Models.AstroResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Astro.Models.AstroResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Astro.Models.AstroResourceProvisioningState left, Azure.ResourceManager.Astro.Models.AstroResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Astro.Models.AstroResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Astro.Models.AstroResourceProvisioningState left, Azure.ResourceManager.Astro.Models.AstroResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AstroSingleSignOnProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.AstroSingleSignOnProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroSingleSignOnProperties>
    {
        public AstroSingleSignOnProperties() { }
        public System.Collections.Generic.IList<string> AadDomains { get { throw null; } }
        public string EnterpriseAppId { get { throw null; } set { } }
        public Azure.ResourceManager.Astro.Models.AstroResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Astro.Models.AstroSingleSignOnState? SingleSignOnState { get { throw null; } set { } }
        public System.Uri SingleSignOnUri { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.Models.AstroSingleSignOnProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.AstroSingleSignOnProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.AstroSingleSignOnProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.Models.AstroSingleSignOnProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroSingleSignOnProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroSingleSignOnProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroSingleSignOnProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AstroSingleSignOnState : System.IEquatable<Azure.ResourceManager.Astro.Models.AstroSingleSignOnState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AstroSingleSignOnState(string value) { throw null; }
        public static Azure.ResourceManager.Astro.Models.AstroSingleSignOnState Disable { get { throw null; } }
        public static Azure.ResourceManager.Astro.Models.AstroSingleSignOnState Enable { get { throw null; } }
        public static Azure.ResourceManager.Astro.Models.AstroSingleSignOnState Initial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Astro.Models.AstroSingleSignOnState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Astro.Models.AstroSingleSignOnState left, Azure.ResourceManager.Astro.Models.AstroSingleSignOnState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Astro.Models.AstroSingleSignOnState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Astro.Models.AstroSingleSignOnState left, Azure.ResourceManager.Astro.Models.AstroSingleSignOnState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AstroUserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.AstroUserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroUserDetails>
    {
        public AstroUserDetails(string firstName, string lastName, string emailAddress) { }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.Models.AstroUserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.AstroUserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.AstroUserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.Models.AstroUserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroUserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroUserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroUserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AstroUserUpdateDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.AstroUserUpdateDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroUserUpdateDetails>
    {
        public AstroUserUpdateDetails() { }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.Models.AstroUserUpdateDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.AstroUserUpdateDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.AstroUserUpdateDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.Models.AstroUserUpdateDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroUserUpdateDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroUserUpdateDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.AstroUserUpdateDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.Astro.Models.MarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Astro.Models.MarketplaceSubscriptionStatus PendingFulfillmentStart { get { throw null; } }
        public static Azure.ResourceManager.Astro.Models.MarketplaceSubscriptionStatus Subscribed { get { throw null; } }
        public static Azure.ResourceManager.Astro.Models.MarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.Astro.Models.MarketplaceSubscriptionStatus Unsubscribed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Astro.Models.MarketplaceSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Astro.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.Astro.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Astro.Models.MarketplaceSubscriptionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Astro.Models.MarketplaceSubscriptionStatus left, Azure.ResourceManager.Astro.Models.MarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
}
