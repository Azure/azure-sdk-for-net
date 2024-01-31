namespace Azure.ResourceManager.ConfidentialLedger
{
    public partial class ConfidentialLedgerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>, System.Collections.IEnumerable
    {
        protected ConfidentialLedgerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string ledgerName, Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string ledgerName, Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string ledgerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string ledgerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> Get(string ledgerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>> GetAsync(string ledgerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> GetIfExists(string ledgerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>> GetIfExistsAsync(string ledgerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ConfidentialLedgerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData>
    {
        public ConfidentialLedgerData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ConfidentialLedgerExtensions
    {
        public static Azure.Response<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult> CheckConfidentialLedgerNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult>> CheckConfidentialLedgerNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> GetConfidentialLedger(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ledgerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>> GetConfidentialLedgerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string ledgerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource GetConfidentialLedgerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerCollection GetConfidentialLedgers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> GetConfidentialLedgers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> GetConfidentialLedgersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource> GetManagedCcf(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string appName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource>> GetManagedCcfAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string appName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource GetManagedCcfResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.ManagedCcfCollection GetManagedCcfs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource> GetManagedCcfs(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource> GetManagedCcfsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ConfidentialLedgerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ConfidentialLedgerResource() { }
        public virtual Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string ledgerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedCcfCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource>, System.Collections.IEnumerable
    {
        protected ManagedCcfCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string appName, Azure.ResourceManager.ConfidentialLedger.ManagedCcfData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string appName, Azure.ResourceManager.ConfidentialLedger.ManagedCcfData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string appName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string appName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource> Get(string appName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource>> GetAsync(string appName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource> GetIfExists(string appName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource>> GetIfExistsAsync(string appName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedCcfData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.ManagedCcfData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.ManagedCcfData>
    {
        public ManagedCcfData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.ConfidentialLedger.Models.ManagedCcfProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.ConfidentialLedger.ManagedCcfData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.ManagedCcfData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.ManagedCcfData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConfidentialLedger.ManagedCcfData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.ManagedCcfData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.ManagedCcfData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.ManagedCcfData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedCcfResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedCcfResource() { }
        public virtual Azure.ResourceManager.ConfidentialLedger.ManagedCcfData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string appName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.ConfidentialLedger.ManagedCcfData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.ConfidentialLedger.ManagedCcfData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ConfidentialLedger.Mocking
{
    public partial class MockableConfidentialLedgerArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableConfidentialLedgerArmClient() { }
        public virtual Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource GetConfidentialLedgerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource GetManagedCcfResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableConfidentialLedgerResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableConfidentialLedgerResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> GetConfidentialLedger(string ledgerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource>> GetConfidentialLedgerAsync(string ledgerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerCollection GetConfidentialLedgers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource> GetManagedCcf(string appName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource>> GetManagedCcfAsync(string appName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ConfidentialLedger.ManagedCcfCollection GetManagedCcfs() { throw null; }
    }
    public partial class MockableConfidentialLedgerSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableConfidentialLedgerSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult> CheckConfidentialLedgerNameAvailability(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult>> CheckConfidentialLedgerNameAvailabilityAsync(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> GetConfidentialLedgers(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerResource> GetConfidentialLedgersAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource> GetManagedCcfs(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.ConfidentialLedger.ManagedCcfResource> GetManagedCcfsAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.ConfidentialLedger.Models
{
    public partial class AadBasedSecurityPrincipal : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.AadBasedSecurityPrincipal>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.AadBasedSecurityPrincipal>
    {
        public AadBasedSecurityPrincipal() { }
        public Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName? LedgerRoleName { get { throw null; } set { } }
        public System.Guid? PrincipalId { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
        Azure.ResourceManager.ConfidentialLedger.Models.AadBasedSecurityPrincipal System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.AadBasedSecurityPrincipal>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.AadBasedSecurityPrincipal>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConfidentialLedger.Models.AadBasedSecurityPrincipal System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.AadBasedSecurityPrincipal>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.AadBasedSecurityPrincipal>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.AadBasedSecurityPrincipal>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmConfidentialLedgerModelFactory
    {
        public static Azure.ResourceManager.ConfidentialLedger.ConfidentialLedgerData ConfidentialLedgerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult ConfidentialLedgerNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason? reason = default(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProperties ConfidentialLedgerProperties(string ledgerName = null, System.Uri ledgerUri = null, System.Uri identityServiceUri = null, string ledgerInternalNamespace = null, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState? runningState = default(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState?), Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType? ledgerType = default(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType?), Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState? provisioningState = default(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConfidentialLedger.Models.AadBasedSecurityPrincipal> aadBasedSecurityPrincipals = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConfidentialLedger.Models.CertBasedSecurityPrincipal> certBasedSecurityPrincipals = null) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.ManagedCcfData ManagedCcfData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.ConfidentialLedger.Models.ManagedCcfProperties properties = null) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ManagedCcfProperties ManagedCcfProperties(string appName = null, System.Uri appUri = null, System.Uri identityServiceUri = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerMemberIdentityCertificate> memberIdentityCertificates = null, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerDeploymentType deploymentType = null, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState? provisioningState = default(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState?), int? nodeCount = default(int?)) { throw null; }
    }
    public partial class CertBasedSecurityPrincipal : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.CertBasedSecurityPrincipal>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.CertBasedSecurityPrincipal>
    {
        public CertBasedSecurityPrincipal() { }
        public string Cert { get { throw null; } set { } }
        public Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName? LedgerRoleName { get { throw null; } set { } }
        Azure.ResourceManager.ConfidentialLedger.Models.CertBasedSecurityPrincipal System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.CertBasedSecurityPrincipal>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.CertBasedSecurityPrincipal>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConfidentialLedger.Models.CertBasedSecurityPrincipal System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.CertBasedSecurityPrincipal>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.CertBasedSecurityPrincipal>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.CertBasedSecurityPrincipal>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfidentialLedgerDeploymentType : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerDeploymentType>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerDeploymentType>
    {
        public ConfidentialLedgerDeploymentType() { }
        public System.Uri AppSourceUri { get { throw null; } set { } }
        public Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerLanguageRuntime? LanguageRuntime { get { throw null; } set { } }
        Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerDeploymentType System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerDeploymentType>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerDeploymentType>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerDeploymentType System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerDeploymentType>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerDeploymentType>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerDeploymentType>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfidentialLedgerLanguageRuntime : System.IEquatable<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerLanguageRuntime>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfidentialLedgerLanguageRuntime(string value) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerLanguageRuntime CPP { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerLanguageRuntime JS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerLanguageRuntime other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerLanguageRuntime left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerLanguageRuntime right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerLanguageRuntime (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerLanguageRuntime left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerLanguageRuntime right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConfidentialLedgerMemberIdentityCertificate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerMemberIdentityCertificate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerMemberIdentityCertificate>
    {
        public ConfidentialLedgerMemberIdentityCertificate() { }
        public string Certificate { get { throw null; } set { } }
        public string Encryptionkey { get { throw null; } set { } }
        public System.BinaryData Tags { get { throw null; } set { } }
        Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerMemberIdentityCertificate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerMemberIdentityCertificate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerMemberIdentityCertificate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerMemberIdentityCertificate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerMemberIdentityCertificate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerMemberIdentityCertificate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerMemberIdentityCertificate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfidentialLedgerNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityContent>
    {
        public ConfidentialLedgerNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
        Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ConfidentialLedgerNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult>
    {
        internal ConfidentialLedgerNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason? Reason { get { throw null; } }
        Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfidentialLedgerNameUnavailableReason : System.IEquatable<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfidentialLedgerNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConfidentialLedgerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProperties>
    {
        public ConfidentialLedgerProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.ConfidentialLedger.Models.AadBasedSecurityPrincipal> AadBasedSecurityPrincipals { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ConfidentialLedger.Models.CertBasedSecurityPrincipal> CertBasedSecurityPrincipals { get { throw null; } }
        public System.Uri IdentityServiceUri { get { throw null; } }
        public string LedgerInternalNamespace { get { throw null; } }
        public string LedgerName { get { throw null; } }
        public Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType? LedgerType { get { throw null; } set { } }
        public System.Uri LedgerUri { get { throw null; } }
        public Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState? RunningState { get { throw null; } set { } }
        Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfidentialLedgerProvisioningState : System.IEquatable<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfidentialLedgerProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState Unknown { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfidentialLedgerRoleName : System.IEquatable<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfidentialLedgerRoleName(string value) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName Administrator { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName Contributor { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName Reader { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRoleName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfidentialLedgerRunningState : System.IEquatable<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfidentialLedgerRunningState(string value) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState Active { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState Paused { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState Pausing { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState Resuming { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerRunningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ConfidentialLedgerType : System.IEquatable<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ConfidentialLedgerType(string value) { throw null; }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType Private { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType Public { get { throw null; } }
        public static Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType left, Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedCcfProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ManagedCcfProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ManagedCcfProperties>
    {
        public ManagedCcfProperties() { }
        public string AppName { get { throw null; } }
        public System.Uri AppUri { get { throw null; } }
        public Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerDeploymentType DeploymentType { get { throw null; } set { } }
        public System.Uri IdentityServiceUri { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerMemberIdentityCertificate> MemberIdentityCertificates { get { throw null; } }
        public int? NodeCount { get { throw null; } set { } }
        public Azure.ResourceManager.ConfidentialLedger.Models.ConfidentialLedgerProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.ConfidentialLedger.Models.ManagedCcfProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ManagedCcfProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.ConfidentialLedger.Models.ManagedCcfProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.ConfidentialLedger.Models.ManagedCcfProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ManagedCcfProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ManagedCcfProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.ConfidentialLedger.Models.ManagedCcfProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
