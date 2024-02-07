namespace Azure.ResourceManager.Astro
{
    public static partial class AstroExtensions
    {
        public static Azure.ResourceManager.Astro.OrganizationResource GetOrganizationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Astro.OrganizationResource> GetOrganizationResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Astro.OrganizationResource>> GetOrganizationResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Astro.OrganizationResourceCollection GetOrganizationResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Astro.OrganizationResource> GetOrganizationResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Astro.OrganizationResource> GetOrganizationResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OrganizationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OrganizationResource() { }
        public virtual Azure.ResourceManager.Astro.OrganizationResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Astro.OrganizationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Astro.OrganizationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Astro.OrganizationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Astro.OrganizationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Astro.OrganizationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Astro.OrganizationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Astro.OrganizationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Astro.OrganizationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Astro.OrganizationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Astro.Models.OrganizationResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Astro.OrganizationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Astro.Models.OrganizationResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OrganizationResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Astro.OrganizationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Astro.OrganizationResource>, System.Collections.IEnumerable
    {
        protected OrganizationResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Astro.OrganizationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string organizationName, Azure.ResourceManager.Astro.OrganizationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Astro.OrganizationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string organizationName, Azure.ResourceManager.Astro.OrganizationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Astro.OrganizationResource> Get(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Astro.OrganizationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Astro.OrganizationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Astro.OrganizationResource>> GetAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Astro.OrganizationResource> GetIfExists(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Astro.OrganizationResource>> GetIfExistsAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Astro.OrganizationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Astro.OrganizationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Astro.OrganizationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Astro.OrganizationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OrganizationResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.OrganizationResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.OrganizationResourceData>
    {
        public OrganizationResourceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Astro.Models.LiftrBaseDataOrganizationProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.Astro.OrganizationResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.OrganizationResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.OrganizationResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.OrganizationResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.OrganizationResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.OrganizationResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.OrganizationResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.Astro.Mocking
{
    public partial class MockableAstroArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableAstroArmClient() { }
        public virtual Azure.ResourceManager.Astro.OrganizationResource GetOrganizationResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableAstroResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAstroResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Astro.OrganizationResource> GetOrganizationResource(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Astro.OrganizationResource>> GetOrganizationResourceAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Astro.OrganizationResourceCollection GetOrganizationResources() { throw null; }
    }
    public partial class MockableAstroSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAstroSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Astro.OrganizationResource> GetOrganizationResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Astro.OrganizationResource> GetOrganizationResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Astro.Models
{
    public static partial class ArmAstroModelFactory
    {
        public static Azure.ResourceManager.Astro.Models.LiftrBaseDataOrganizationProperties LiftrBaseDataOrganizationProperties(Azure.ResourceManager.Astro.Models.LiftrBaseMarketplaceDetails marketplace = null, Azure.ResourceManager.Astro.Models.LiftrBaseUserDetails user = null, Azure.ResourceManager.Astro.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.Astro.Models.ResourceProvisioningState?), Azure.ResourceManager.Astro.Models.LiftrBaseDataPartnerOrganizationProperties partnerOrganizationProperties = null) { throw null; }
        public static Azure.ResourceManager.Astro.Models.LiftrBaseSingleSignOnProperties LiftrBaseSingleSignOnProperties(Azure.ResourceManager.Astro.Models.SingleSignOnState? singleSignOnState = default(Azure.ResourceManager.Astro.Models.SingleSignOnState?), string enterpriseAppId = null, System.Uri singleSignOnUri = null, System.Collections.Generic.IEnumerable<string> aadDomains = null, Azure.ResourceManager.Astro.Models.ResourceProvisioningState? provisioningState = default(Azure.ResourceManager.Astro.Models.ResourceProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Astro.OrganizationResourceData OrganizationResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Astro.Models.LiftrBaseDataOrganizationProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
    }
    public partial class LiftrBaseDataOrganizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.LiftrBaseDataOrganizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseDataOrganizationProperties>
    {
        public LiftrBaseDataOrganizationProperties(Azure.ResourceManager.Astro.Models.LiftrBaseMarketplaceDetails marketplace, Azure.ResourceManager.Astro.Models.LiftrBaseUserDetails user) { }
        public Azure.ResourceManager.Astro.Models.LiftrBaseMarketplaceDetails Marketplace { get { throw null; } set { } }
        public Azure.ResourceManager.Astro.Models.LiftrBaseDataPartnerOrganizationProperties PartnerOrganizationProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Astro.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Astro.Models.LiftrBaseUserDetails User { get { throw null; } set { } }
        Azure.ResourceManager.Astro.Models.LiftrBaseDataOrganizationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.LiftrBaseDataOrganizationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.LiftrBaseDataOrganizationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.Models.LiftrBaseDataOrganizationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseDataOrganizationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseDataOrganizationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseDataOrganizationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LiftrBaseDataPartnerOrganizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.LiftrBaseDataPartnerOrganizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseDataPartnerOrganizationProperties>
    {
        public LiftrBaseDataPartnerOrganizationProperties(string organizationName) { }
        public string OrganizationId { get { throw null; } set { } }
        public string OrganizationName { get { throw null; } set { } }
        public Azure.ResourceManager.Astro.Models.LiftrBaseSingleSignOnProperties SingleSignOnProperties { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } set { } }
        public string WorkspaceName { get { throw null; } set { } }
        Azure.ResourceManager.Astro.Models.LiftrBaseDataPartnerOrganizationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.LiftrBaseDataPartnerOrganizationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.LiftrBaseDataPartnerOrganizationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.Models.LiftrBaseDataPartnerOrganizationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseDataPartnerOrganizationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseDataPartnerOrganizationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseDataPartnerOrganizationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LiftrBaseDataPartnerOrganizationPropertiesUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.LiftrBaseDataPartnerOrganizationPropertiesUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseDataPartnerOrganizationPropertiesUpdate>
    {
        public LiftrBaseDataPartnerOrganizationPropertiesUpdate() { }
        public string OrganizationId { get { throw null; } set { } }
        public string OrganizationName { get { throw null; } set { } }
        public Azure.ResourceManager.Astro.Models.LiftrBaseSingleSignOnProperties SingleSignOnProperties { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } set { } }
        public string WorkspaceName { get { throw null; } set { } }
        Azure.ResourceManager.Astro.Models.LiftrBaseDataPartnerOrganizationPropertiesUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.LiftrBaseDataPartnerOrganizationPropertiesUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.LiftrBaseDataPartnerOrganizationPropertiesUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.Models.LiftrBaseDataPartnerOrganizationPropertiesUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseDataPartnerOrganizationPropertiesUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseDataPartnerOrganizationPropertiesUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseDataPartnerOrganizationPropertiesUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LiftrBaseMarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.LiftrBaseMarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseMarketplaceDetails>
    {
        public LiftrBaseMarketplaceDetails(string subscriptionId, Azure.ResourceManager.Astro.Models.LiftrBaseOfferDetails offerDetails) { }
        public Azure.ResourceManager.Astro.Models.LiftrBaseOfferDetails OfferDetails { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.Astro.Models.MarketplaceSubscriptionStatus? SubscriptionStatus { get { throw null; } set { } }
        Azure.ResourceManager.Astro.Models.LiftrBaseMarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.LiftrBaseMarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.LiftrBaseMarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.Models.LiftrBaseMarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseMarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseMarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseMarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LiftrBaseOfferDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.LiftrBaseOfferDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseOfferDetails>
    {
        public LiftrBaseOfferDetails(string publisherId, string offerId, string planId) { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        Azure.ResourceManager.Astro.Models.LiftrBaseOfferDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.LiftrBaseOfferDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.LiftrBaseOfferDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.Models.LiftrBaseOfferDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseOfferDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseOfferDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseOfferDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LiftrBaseSingleSignOnProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.LiftrBaseSingleSignOnProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseSingleSignOnProperties>
    {
        public LiftrBaseSingleSignOnProperties() { }
        public System.Collections.Generic.IList<string> AadDomains { get { throw null; } }
        public string EnterpriseAppId { get { throw null; } set { } }
        public Azure.ResourceManager.Astro.Models.ResourceProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Astro.Models.SingleSignOnState? SingleSignOnState { get { throw null; } set { } }
        public System.Uri SingleSignOnUri { get { throw null; } set { } }
        Azure.ResourceManager.Astro.Models.LiftrBaseSingleSignOnProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.LiftrBaseSingleSignOnProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.LiftrBaseSingleSignOnProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.Models.LiftrBaseSingleSignOnProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseSingleSignOnProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseSingleSignOnProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseSingleSignOnProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LiftrBaseUserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.LiftrBaseUserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseUserDetails>
    {
        public LiftrBaseUserDetails(string firstName, string lastName, string emailAddress) { }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        Azure.ResourceManager.Astro.Models.LiftrBaseUserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.LiftrBaseUserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.LiftrBaseUserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.Models.LiftrBaseUserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseUserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseUserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseUserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LiftrBaseUserDetailsUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.LiftrBaseUserDetailsUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseUserDetailsUpdate>
    {
        public LiftrBaseUserDetailsUpdate() { }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        Azure.ResourceManager.Astro.Models.LiftrBaseUserDetailsUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.LiftrBaseUserDetailsUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.LiftrBaseUserDetailsUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.Models.LiftrBaseUserDetailsUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseUserDetailsUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseUserDetailsUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.LiftrBaseUserDetailsUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class OrganizationResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.OrganizationResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.OrganizationResourcePatch>
    {
        public OrganizationResourcePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Astro.Models.OrganizationResourceUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Astro.Models.OrganizationResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.OrganizationResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.OrganizationResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.Models.OrganizationResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.OrganizationResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.OrganizationResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.OrganizationResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OrganizationResourceUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.OrganizationResourceUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.OrganizationResourceUpdateProperties>
    {
        public OrganizationResourceUpdateProperties() { }
        public Azure.ResourceManager.Astro.Models.LiftrBaseDataPartnerOrganizationPropertiesUpdate PartnerOrganizationProperties { get { throw null; } set { } }
        public Azure.ResourceManager.Astro.Models.LiftrBaseUserDetailsUpdate User { get { throw null; } set { } }
        Azure.ResourceManager.Astro.Models.OrganizationResourceUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.OrganizationResourceUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Astro.Models.OrganizationResourceUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Astro.Models.OrganizationResourceUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.OrganizationResourceUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.OrganizationResourceUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Astro.Models.OrganizationResourceUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceProvisioningState : System.IEquatable<Azure.ResourceManager.Astro.Models.ResourceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Astro.Models.ResourceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Astro.Models.ResourceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Astro.Models.ResourceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Astro.Models.ResourceProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Astro.Models.ResourceProvisioningState left, Azure.ResourceManager.Astro.Models.ResourceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Astro.Models.ResourceProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Astro.Models.ResourceProvisioningState left, Azure.ResourceManager.Astro.Models.ResourceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SingleSignOnState : System.IEquatable<Azure.ResourceManager.Astro.Models.SingleSignOnState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SingleSignOnState(string value) { throw null; }
        public static Azure.ResourceManager.Astro.Models.SingleSignOnState Disable { get { throw null; } }
        public static Azure.ResourceManager.Astro.Models.SingleSignOnState Enable { get { throw null; } }
        public static Azure.ResourceManager.Astro.Models.SingleSignOnState Initial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Astro.Models.SingleSignOnState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Astro.Models.SingleSignOnState left, Azure.ResourceManager.Astro.Models.SingleSignOnState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Astro.Models.SingleSignOnState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Astro.Models.SingleSignOnState left, Azure.ResourceManager.Astro.Models.SingleSignOnState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
