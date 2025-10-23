namespace Azure.ResourceManager.LambdaTestHyperExecute
{
    public partial class AzureResourceManagerLambdaTestHyperExecuteContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerLambdaTestHyperExecuteContext() { }
        public static Azure.ResourceManager.LambdaTestHyperExecute.AzureResourceManagerLambdaTestHyperExecuteContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class LambdaTestHyperExecuteExtensions
    {
        public static Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource> GetLambdaTestHyperExecuteOrganization(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource>> GetLambdaTestHyperExecuteOrganizationAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource GetLambdaTestHyperExecuteOrganizationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationCollection GetLambdaTestHyperExecuteOrganizations(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource> GetLambdaTestHyperExecuteOrganizations(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource> GetLambdaTestHyperExecuteOrganizationsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class LambdaTestHyperExecuteOrganizationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource>, System.Collections.IEnumerable
    {
        protected LambdaTestHyperExecuteOrganizationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string organizationname, Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string organizationname, Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource> Get(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource>> GetAsync(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource> GetIfExists(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource>> GetIfExistsAsync(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class LambdaTestHyperExecuteOrganizationData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationData>
    {
        public LambdaTestHyperExecuteOrganizationData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOrganizationProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LambdaTestHyperExecuteOrganizationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected LambdaTestHyperExecuteOrganizationResource() { }
        public virtual Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string organizationname) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource> Update(Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOrganizationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource>> UpdateAsync(Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOrganizationPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.LambdaTestHyperExecute.Mocking
{
    public partial class MockableLambdaTestHyperExecuteArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableLambdaTestHyperExecuteArmClient() { }
        public virtual Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource GetLambdaTestHyperExecuteOrganizationResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableLambdaTestHyperExecuteResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableLambdaTestHyperExecuteResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource> GetLambdaTestHyperExecuteOrganization(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource>> GetLambdaTestHyperExecuteOrganizationAsync(string organizationname, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationCollection GetLambdaTestHyperExecuteOrganizations() { throw null; }
    }
    public partial class MockableLambdaTestHyperExecuteSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableLambdaTestHyperExecuteSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource> GetLambdaTestHyperExecuteOrganizations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationResource> GetLambdaTestHyperExecuteOrganizationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.LambdaTestHyperExecute.Models
{
    public static partial class ArmLambdaTestHyperExecuteModelFactory
    {
        public static Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteMarketplaceDetails LambdaTestHyperExecuteMarketplaceDetails(string subscriptionId = null, Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteMarketplaceSubscriptionStatus? subscriptionStatus = default(Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteMarketplaceSubscriptionStatus?), Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferDetails offerDetails = null) { throw null; }
        public static Azure.ResourceManager.LambdaTestHyperExecute.LambdaTestHyperExecuteOrganizationData LambdaTestHyperExecuteOrganizationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOrganizationProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOrganizationPatch LambdaTestHyperExecuteOrganizationPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOrganizationProperties LambdaTestHyperExecuteOrganizationProperties(Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteMarketplaceDetails marketplace = null, Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteUserDetails user = null, Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferProvisioningState? provisioningState = default(Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferProvisioningState?), int? partnerLicensesSubscribed = default(int?), Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnPropertiesV2 singleSignOnProperties = null) { throw null; }
        public static Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnPropertiesV2 LambdaTestHyperExecuteSingleSignOnPropertiesV2(Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnType type = default(Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnType), Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnState? state = default(Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnState?), string enterpriseAppId = null, string uri = null, System.Collections.Generic.IEnumerable<string> aadDomains = null) { throw null; }
    }
    public partial class LambdaTestHyperExecuteMarketplaceDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteMarketplaceDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteMarketplaceDetails>
    {
        public LambdaTestHyperExecuteMarketplaceDetails(Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferDetails offerDetails) { }
        public Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferDetails OfferDetails { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        public Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteMarketplaceSubscriptionStatus? SubscriptionStatus { get { throw null; } }
        protected virtual Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteMarketplaceDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteMarketplaceDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteMarketplaceDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteMarketplaceDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteMarketplaceDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteMarketplaceDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteMarketplaceDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteMarketplaceDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteMarketplaceDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LambdaTestHyperExecuteMarketplaceSubscriptionStatus : System.IEquatable<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteMarketplaceSubscriptionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LambdaTestHyperExecuteMarketplaceSubscriptionStatus(string value) { throw null; }
        public static Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteMarketplaceSubscriptionStatus PendingFulfillmentStart { get { throw null; } }
        public static Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteMarketplaceSubscriptionStatus Subscribed { get { throw null; } }
        public static Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteMarketplaceSubscriptionStatus Suspended { get { throw null; } }
        public static Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteMarketplaceSubscriptionStatus Unsubscribed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteMarketplaceSubscriptionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteMarketplaceSubscriptionStatus left, Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteMarketplaceSubscriptionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteMarketplaceSubscriptionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteMarketplaceSubscriptionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteMarketplaceSubscriptionStatus left, Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteMarketplaceSubscriptionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LambdaTestHyperExecuteOfferDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferDetails>
    {
        public LambdaTestHyperExecuteOfferDetails(string publisherId, string offerId, string planId) { }
        public string OfferId { get { throw null; } set { } }
        public string PlanId { get { throw null; } set { } }
        public string PlanName { get { throw null; } set { } }
        public string PublisherId { get { throw null; } set { } }
        public string TermId { get { throw null; } set { } }
        public string TermUnit { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LambdaTestHyperExecuteOfferPartnerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferPartnerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferPartnerProperties>
    {
        public LambdaTestHyperExecuteOfferPartnerProperties(int licensesSubscribed) { }
        public int LicensesSubscribed { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferPartnerProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferPartnerProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferPartnerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferPartnerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferPartnerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferPartnerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferPartnerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferPartnerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferPartnerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LambdaTestHyperExecuteOfferProvisioningState : System.IEquatable<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LambdaTestHyperExecuteOfferProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferProvisioningState left, Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferProvisioningState left, Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LambdaTestHyperExecuteOrganizationPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOrganizationPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOrganizationPatch>
    {
        public LambdaTestHyperExecuteOrganizationPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOrganizationPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOrganizationPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOrganizationPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOrganizationPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOrganizationPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOrganizationPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOrganizationPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOrganizationPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOrganizationPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LambdaTestHyperExecuteOrganizationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOrganizationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOrganizationProperties>
    {
        public LambdaTestHyperExecuteOrganizationProperties(Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteMarketplaceDetails marketplace, Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteUserDetails user, Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferPartnerProperties partnerProperties) { }
        public Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteMarketplaceDetails Marketplace { get { throw null; } set { } }
        public int? PartnerLicensesSubscribed { get { throw null; } set { } }
        public Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOfferProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnPropertiesV2 SingleSignOnProperties { get { throw null; } set { } }
        public Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteUserDetails User { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOrganizationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOrganizationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOrganizationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOrganizationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOrganizationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOrganizationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOrganizationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOrganizationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteOrganizationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LambdaTestHyperExecuteSingleSignOnPropertiesV2 : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnPropertiesV2>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnPropertiesV2>
    {
        public LambdaTestHyperExecuteSingleSignOnPropertiesV2(Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnType type) { }
        public System.Collections.Generic.IList<string> AadDomains { get { throw null; } }
        public string EnterpriseAppId { get { throw null; } set { } }
        public Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnState? State { get { throw null; } set { } }
        public Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnType Type { get { throw null; } set { } }
        public string Uri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnPropertiesV2 JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnPropertiesV2 PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnPropertiesV2 System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnPropertiesV2>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnPropertiesV2>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnPropertiesV2 System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnPropertiesV2>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnPropertiesV2>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnPropertiesV2>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LambdaTestHyperExecuteSingleSignOnState : System.IEquatable<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LambdaTestHyperExecuteSingleSignOnState(string value) { throw null; }
        public static Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnState Disable { get { throw null; } }
        public static Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnState Enable { get { throw null; } }
        public static Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnState Initial { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnState left, Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnState right) { throw null; }
        public static implicit operator Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnState left, Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LambdaTestHyperExecuteSingleSignOnType : System.IEquatable<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LambdaTestHyperExecuteSingleSignOnType(string value) { throw null; }
        public static Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnType OpenId { get { throw null; } }
        public static Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnType Saml { get { throw null; } }
        public bool Equals(Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnType left, Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnType right) { throw null; }
        public static implicit operator Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnType left, Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteSingleSignOnType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LambdaTestHyperExecuteUserDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteUserDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteUserDetails>
    {
        public LambdaTestHyperExecuteUserDetails() { }
        public string EmailAddress { get { throw null; } set { } }
        public string FirstName { get { throw null; } set { } }
        public string LastName { get { throw null; } set { } }
        public string PhoneNumber { get { throw null; } set { } }
        public string Upn { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteUserDetails JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteUserDetails PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteUserDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteUserDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteUserDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteUserDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteUserDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteUserDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.LambdaTestHyperExecute.Models.LambdaTestHyperExecuteUserDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
