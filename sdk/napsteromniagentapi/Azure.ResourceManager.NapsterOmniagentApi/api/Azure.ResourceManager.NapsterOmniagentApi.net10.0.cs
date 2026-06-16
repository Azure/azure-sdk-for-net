namespace Azure.ResourceManager.NapsterOmniagentApi
{
    public partial class AzureResourceManagerNapsterOmniagentApiContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerNapsterOmniagentApiContext() { }
        public static Azure.ResourceManager.NapsterOmniagentApi.AzureResourceManagerNapsterOmniagentApiContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class NapsterOmniagentApiExtensions
    {
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NapsterOmniagentApi.Models.SaaSResourceDetailsData> ActivateResource(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.NapsterOmniagentApi.Models.ActivateSaaSParameterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NapsterOmniagentApi.Models.SaaSResourceDetailsData>> ActivateResourceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.ResourceManager.NapsterOmniagentApi.Models.ActivateSaaSParameterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource GetNapsterOrganizationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource> GetNapsterOrganizationResource(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource>> GetNapsterOrganizationResourceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResourceCollection GetNapsterOrganizationResources(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource> GetNapsterOrganizationResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource> GetNapsterOrganizationResourcesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NapsterOrganizationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NapsterOrganizationResource() { }
        public virtual Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationname) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NapsterOmniagentApi.Models.LatestLinkedSaaSResult> LatestLinkedSaaS(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NapsterOmniagentApi.Models.LatestLinkedSaaSResult>> LatestLinkedSaaSAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource> LinkSaaS(Azure.WaitUntil waitUntil, Azure.ResourceManager.NapsterOmniagentApi.Models.SaaSInfo content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource>> LinkSaaSAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NapsterOmniagentApi.Models.SaaSInfo content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOrganizationResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOrganizationResourcePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NapsterOrganizationResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource>, System.Collections.IEnumerable
    {
        protected NapsterOrganizationResourceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string organizationName, Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string organizationName, Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResourceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource> Get(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource>> GetAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource> GetIfExists(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource>> GetIfExistsAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NapsterOrganizationResourceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResourceData>
    {
        public NapsterOrganizationResourceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string OrganizationName { get { throw null; } }
        public Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOrganizationProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.NapsterOmniagentApi.Mocking
{
    public partial class MockableNapsterOmniagentApiArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableNapsterOmniagentApiArmClient() { }
        public virtual Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource GetNapsterOrganizationResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableNapsterOmniagentApiResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNapsterOmniagentApiResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource> GetNapsterOrganizationResource(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource>> GetNapsterOrganizationResourceAsync(string organizationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResourceCollection GetNapsterOrganizationResources() { throw null; }
    }
    public partial class MockableNapsterOmniagentApiSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNapsterOmniagentApiSubscriptionResource() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NapsterOmniagentApi.Models.SaaSResourceDetailsData> ActivateResource(Azure.WaitUntil waitUntil, Azure.ResourceManager.NapsterOmniagentApi.Models.ActivateSaaSParameterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NapsterOmniagentApi.Models.SaaSResourceDetailsData>> ActivateResourceAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NapsterOmniagentApi.Models.ActivateSaaSParameterContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource> GetNapsterOrganizationResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResource> GetNapsterOrganizationResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.NapsterOmniagentApi.Models
{
    public partial class ActivateSaaSParameterContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.Models.ActivateSaaSParameterContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.ActivateSaaSParameterContent>
    {
        public ActivateSaaSParameterContent(System.Guid saasGuid) { }
        public string PublisherId { get { throw null; } set { } }
        public System.Guid SaasGuid { get { throw null; } }
        protected virtual Azure.ResourceManager.NapsterOmniagentApi.Models.ActivateSaaSParameterContent JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NapsterOmniagentApi.Models.ActivateSaaSParameterContent PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NapsterOmniagentApi.Models.ActivateSaaSParameterContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.Models.ActivateSaaSParameterContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.Models.ActivateSaaSParameterContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NapsterOmniagentApi.Models.ActivateSaaSParameterContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.ActivateSaaSParameterContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.ActivateSaaSParameterContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.ActivateSaaSParameterContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmNapsterOmniagentApiModelFactory
    {
        public static Azure.ResourceManager.NapsterOmniagentApi.Models.ActivateSaaSParameterContent ActivateSaaSParameterContent(System.Guid saasGuid = default(System.Guid), string publisherId = null) { throw null; }
        public static Azure.ResourceManager.NapsterOmniagentApi.Models.LatestLinkedSaaSResult LatestLinkedSaaSResult(string saaSId = null, bool? isHiddenSaaS = default(bool?)) { throw null; }
        public static Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterMarketplaceDetails NapsterMarketplaceDetails(string subscriptionId = null, Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterMarketplaceSubscriptionStatus? subscriptionStatus = default(Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterMarketplaceSubscriptionStatus?), string saaSId = null, Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOfferDetails offerDetails = null) { throw null; }
        public static Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOfferDetails NapsterOfferDetails(string publisherId = null, string offerId = null, string planId = null, string planName = null, string termUnit = null, string termId = null) { throw null; }
        public static Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOrganizationProperties NapsterOrganizationProperties(Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterMarketplaceDetails marketplace = null, Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterUserDetails user = null, Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterProvisioningState? provisioningState = default(Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterProvisioningState?), string partnerApplication = null, Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnPropertiesV2 singleSignOnProperties = null) { throw null; }
        public static Azure.ResourceManager.NapsterOmniagentApi.NapsterOrganizationResourceData NapsterOrganizationResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOrganizationProperties properties = null, string organizationName = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOrganizationResourcePatch NapsterOrganizationResourcePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnPropertiesV2 NapsterSingleSignOnPropertiesV2(Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnType type = default(Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnType), Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnState? state = default(Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnState?), string enterpriseAppId = null, string uri = null, System.Collections.Generic.IEnumerable<string> aadDomains = null) { throw null; }
        public static Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterUserDetails NapsterUserDetails(string firstName = null, string lastName = null, string emailAddress = null, string upn = null, string phoneNumber = null) { throw null; }
        public static Azure.ResourceManager.NapsterOmniagentApi.Models.SaaSInfo SaaSInfo(string saaSId = null) { throw null; }
        public static Azure.ResourceManager.NapsterOmniagentApi.Models.SaaSResourceDetailsData SaaSResourceDetailsData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string saasId = null) { throw null; }
    }
    public partial class LatestLinkedSaaSResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.Models.LatestLinkedSaaSResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.LatestLinkedSaaSResult>
    {
        internal LatestLinkedSaaSResult() { }
        public bool? IsHiddenSaaS { get { throw null; } }
        public string SaaSId { get { throw null; } }
        protected virtual Azure.ResourceManager.NapsterOmniagentApi.Models.LatestLinkedSaaSResult JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NapsterOmniagentApi.Models.LatestLinkedSaaSResult PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NapsterOmniagentApi.Models.LatestLinkedSaaSResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.Models.LatestLinkedSaaSResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.Models.LatestLinkedSaaSResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NapsterOmniagentApi.Models.LatestLinkedSaaSResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.LatestLinkedSaaSResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.LatestLinkedSaaSResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.LatestLinkedSaaSResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NapsterMarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterMarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterMarketplaceDetails>
    {
        public NapsterMarketplaceDetails(Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOfferDetails offerDetails) { }
        public Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOfferDetails OfferDetails { get { throw null; } set { } }
        public string SaaSId { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterMarketplaceSubscriptionStatus? SubscriptionStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterMarketplaceDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterMarketplaceDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterMarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterMarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterMarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterMarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterMarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterMarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterMarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NapsterMarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterMarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NapsterMarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterMarketplaceSubscriptionStatus PendingFulfillmentStart { get { throw null; } }
        public static Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterMarketplaceSubscriptionStatus Subscribed { get { throw null; } }
        public static Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterMarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterMarketplaceSubscriptionStatus Unsubscribed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterMarketplaceSubscriptionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterMarketplaceSubscriptionStatus left, Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterMarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterMarketplaceSubscriptionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterMarketplaceSubscriptionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterMarketplaceSubscriptionStatus left, Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterMarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NapsterOfferDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOfferDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOfferDetails>
    {
        public NapsterOfferDetails(string publisherId, string offerId) { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOfferDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOfferDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOfferDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOfferDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOfferDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOfferDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOfferDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOfferDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOfferDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NapsterOrganizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOrganizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOrganizationProperties>
    {
        public NapsterOrganizationProperties(Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterMarketplaceDetails marketplace, Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterUserDetails user, string partnerApplication) { }
        public Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterMarketplaceDetails Marketplace { get { throw null; } set { } }
        public string PartnerApplication { get { throw null; } set { } }
        public Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnPropertiesV2 SingleSignOnProperties { get { throw null; } set { } }
        public Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterUserDetails User { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOrganizationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOrganizationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOrganizationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOrganizationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOrganizationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOrganizationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOrganizationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOrganizationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOrganizationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NapsterOrganizationResourcePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOrganizationResourcePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOrganizationResourcePatch>
    {
        public NapsterOrganizationResourcePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOrganizationResourcePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOrganizationResourcePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOrganizationResourcePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOrganizationResourcePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOrganizationResourcePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOrganizationResourcePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOrganizationResourcePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOrganizationResourcePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterOrganizationResourcePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NapsterProvisioningState : System.IEquatable<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NapsterProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterProvisioningState left, Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterProvisioningState left, Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NapsterSingleSignOnPropertiesV2 : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnPropertiesV2>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnPropertiesV2>
    {
        public NapsterSingleSignOnPropertiesV2(Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnType type) { }
        public System.Collections.Generic.IList<string> AadDomains { get { throw null; } }
        public string EnterpriseAppId { get { throw null; } set { } }
        public Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnState? State { get { throw null; } set { } }
        public Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnType Type { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnPropertiesV2 JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnPropertiesV2 PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnPropertiesV2 System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnPropertiesV2>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnPropertiesV2>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnPropertiesV2 System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnPropertiesV2>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnPropertiesV2>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnPropertiesV2>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NapsterSingleSignOnState : System.IEquatable<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NapsterSingleSignOnState(string value) { throw null; }
        public static Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnState Disable { get { throw null; } }
        public static Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnState Enable { get { throw null; } }
        public static Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnState Initial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnState left, Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnState left, Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NapsterSingleSignOnType : System.IEquatable<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NapsterSingleSignOnType(string value) { throw null; }
        public static Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnType OpenId { get { throw null; } }
        public static Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnType Saml { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnType left, Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnType left, Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterSingleSignOnType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NapsterUserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterUserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterUserDetails>
    {
        public NapsterUserDetails() { }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterUserDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterUserDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterUserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterUserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterUserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterUserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterUserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterUserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.NapsterUserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SaaSInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.Models.SaaSInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.SaaSInfo>
    {
        public SaaSInfo() { }
        public string SaaSId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.NapsterOmniagentApi.Models.SaaSInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.NapsterOmniagentApi.Models.SaaSInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NapsterOmniagentApi.Models.SaaSInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.Models.SaaSInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.Models.SaaSInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NapsterOmniagentApi.Models.SaaSInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.SaaSInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.SaaSInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.SaaSInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SaaSResourceDetailsData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.Models.SaaSResourceDetailsData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.SaaSResourceDetailsData>
    {
        internal SaaSResourceDetailsData() { }
        public string SaasId { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.NapsterOmniagentApi.Models.SaaSResourceDetailsData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.Models.SaaSResourceDetailsData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NapsterOmniagentApi.Models.SaaSResourceDetailsData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NapsterOmniagentApi.Models.SaaSResourceDetailsData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.SaaSResourceDetailsData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.SaaSResourceDetailsData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NapsterOmniagentApi.Models.SaaSResourceDetailsData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
