namespace Azure.ResourceManager.MixedReality
{
    public static partial class MixedRealityExtensions
    {
        public static Azure.Response<Azure.ResourceManager.MixedReality.Models.MixedRealityNameAvailabilityResult> CheckMixedRealityNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.MixedReality.Models.MixedRealityNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MixedReality.Models.MixedRealityNameAvailabilityResult>> CheckMixedRealityNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.MixedReality.Models.MixedRealityNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource> GetRemoteRenderingAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource>> GetRemoteRenderingAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource GetRemoteRenderingAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MixedReality.RemoteRenderingAccountCollection GetRemoteRenderingAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource> GetRemoteRenderingAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource> GetRemoteRenderingAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource> GetSpatialAnchorsAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource>> GetSpatialAnchorsAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource GetSpatialAnchorsAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.MixedReality.SpatialAnchorsAccountCollection GetSpatialAnchorsAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource> GetSpatialAnchorsAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource> GetSpatialAnchorsAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RemoteRenderingAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource>, System.Collections.IEnumerable
    {
        protected RemoteRenderingAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.MixedReality.RemoteRenderingAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.MixedReality.RemoteRenderingAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource> GetIfExists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource>> GetIfExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RemoteRenderingAccountData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MixedReality.RemoteRenderingAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MixedReality.RemoteRenderingAccountData>
    {
        public RemoteRenderingAccountData(Azure.Core.AzureLocation location) { }
        public string AccountDomain { get { throw null; } }
        public System.Guid? AccountId { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.MixedReality.Models.MixedRealitySku Kind { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Plan { get { throw null; } set { } }
        public Azure.ResourceManager.MixedReality.Models.MixedRealitySku Sku { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        Azure.ResourceManager.MixedReality.RemoteRenderingAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MixedReality.RemoteRenderingAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MixedReality.RemoteRenderingAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MixedReality.RemoteRenderingAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MixedReality.RemoteRenderingAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MixedReality.RemoteRenderingAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MixedReality.RemoteRenderingAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemoteRenderingAccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RemoteRenderingAccountResource() { }
        public virtual Azure.ResourceManager.MixedReality.RemoteRenderingAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeys> RegenerateKeys(Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeyRegenerateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeys>> RegenerateKeysAsync(Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeyRegenerateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource> Update(Azure.ResourceManager.MixedReality.RemoteRenderingAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource>> UpdateAsync(Azure.ResourceManager.MixedReality.RemoteRenderingAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SpatialAnchorsAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource>, System.Collections.IEnumerable
    {
        protected SpatialAnchorsAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.MixedReality.SpatialAnchorsAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.MixedReality.SpatialAnchorsAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource> GetIfExists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource>> GetIfExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SpatialAnchorsAccountData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountData>
    {
        public SpatialAnchorsAccountData(Azure.Core.AzureLocation location) { }
        public string AccountDomain { get { throw null; } }
        public System.Guid? AccountId { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.MixedReality.Models.MixedRealitySku Kind { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Plan { get { throw null; } set { } }
        public Azure.ResourceManager.MixedReality.Models.MixedRealitySku Sku { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        Azure.ResourceManager.MixedReality.SpatialAnchorsAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MixedReality.SpatialAnchorsAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SpatialAnchorsAccountResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SpatialAnchorsAccountResource() { }
        public virtual Azure.ResourceManager.MixedReality.SpatialAnchorsAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeys> RegenerateKeys(Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeyRegenerateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeys>> RegenerateKeysAsync(Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeyRegenerateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource> Update(Azure.ResourceManager.MixedReality.SpatialAnchorsAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource>> UpdateAsync(Azure.ResourceManager.MixedReality.SpatialAnchorsAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.MixedReality.Mocking
{
    public partial class MockableMixedRealityArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableMixedRealityArmClient() { }
        public virtual Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource GetRemoteRenderingAccountResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource GetSpatialAnchorsAccountResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableMixedRealityResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMixedRealityResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource> GetRemoteRenderingAccount(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource>> GetRemoteRenderingAccountAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MixedReality.RemoteRenderingAccountCollection GetRemoteRenderingAccounts() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource> GetSpatialAnchorsAccount(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource>> GetSpatialAnchorsAccountAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.MixedReality.SpatialAnchorsAccountCollection GetSpatialAnchorsAccounts() { throw null; }
    }
    public partial class MockableMixedRealitySubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableMixedRealitySubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.MixedReality.Models.MixedRealityNameAvailabilityResult> CheckMixedRealityNameAvailability(Azure.Core.AzureLocation location, Azure.ResourceManager.MixedReality.Models.MixedRealityNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.MixedReality.Models.MixedRealityNameAvailabilityResult>> CheckMixedRealityNameAvailabilityAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.MixedReality.Models.MixedRealityNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource> GetRemoteRenderingAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MixedReality.RemoteRenderingAccountResource> GetRemoteRenderingAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource> GetSpatialAnchorsAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.MixedReality.SpatialAnchorsAccountResource> GetSpatialAnchorsAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.MixedReality.Models
{
    public static partial class ArmMixedRealityModelFactory
    {
        public static Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeys MixedRealityAccountKeys(string primaryKey = null, string secondaryKey = null) { throw null; }
        public static Azure.ResourceManager.MixedReality.Models.MixedRealityNameAvailabilityResult MixedRealityNameAvailabilityResult(bool isNameAvailable = false, Azure.ResourceManager.MixedReality.Models.MixedRealityNameUnavailableReason? reason = default(Azure.ResourceManager.MixedReality.Models.MixedRealityNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.MixedReality.RemoteRenderingAccountData RemoteRenderingAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Models.ManagedServiceIdentity plan = null, Azure.ResourceManager.MixedReality.Models.MixedRealitySku sku = null, Azure.ResourceManager.MixedReality.Models.MixedRealitySku kind = null, string storageAccountName = null, System.Guid? accountId = default(System.Guid?), string accountDomain = null) { throw null; }
        public static Azure.ResourceManager.MixedReality.SpatialAnchorsAccountData SpatialAnchorsAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Models.ManagedServiceIdentity plan = null, Azure.ResourceManager.MixedReality.Models.MixedRealitySku sku = null, Azure.ResourceManager.MixedReality.Models.MixedRealitySku kind = null, string storageAccountName = null, System.Guid? accountId = default(System.Guid?), string accountDomain = null) { throw null; }
    }
    public partial class MixedRealityAccountKeyRegenerateContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeyRegenerateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeyRegenerateContent>
    {
        public MixedRealityAccountKeyRegenerateContent() { }
        public Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeySerial? Serial { get { throw null; } set { } }
        Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeyRegenerateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeyRegenerateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeyRegenerateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeyRegenerateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeyRegenerateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeyRegenerateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeyRegenerateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MixedRealityAccountKeys : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeys>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeys>
    {
        internal MixedRealityAccountKeys() { }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
        Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeys System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeys>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeys>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeys System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeys>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeys>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MixedReality.Models.MixedRealityAccountKeys>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum MixedRealityAccountKeySerial
    {
        Primary = 1,
        Secondary = 2,
    }
    public partial class MixedRealityNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MixedReality.Models.MixedRealityNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MixedReality.Models.MixedRealityNameAvailabilityContent>
    {
        public MixedRealityNameAvailabilityContent(string name, string resourceType) { }
        public string Name { get { throw null; } }
        public string ResourceType { get { throw null; } }
        Azure.ResourceManager.MixedReality.Models.MixedRealityNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MixedReality.Models.MixedRealityNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MixedReality.Models.MixedRealityNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MixedReality.Models.MixedRealityNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MixedReality.Models.MixedRealityNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MixedReality.Models.MixedRealityNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MixedReality.Models.MixedRealityNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MixedRealityNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MixedReality.Models.MixedRealityNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MixedReality.Models.MixedRealityNameAvailabilityResult>
    {
        internal MixedRealityNameAvailabilityResult() { }
        public bool IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.MixedReality.Models.MixedRealityNameUnavailableReason? Reason { get { throw null; } }
        Azure.ResourceManager.MixedReality.Models.MixedRealityNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MixedReality.Models.MixedRealityNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MixedReality.Models.MixedRealityNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MixedReality.Models.MixedRealityNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MixedReality.Models.MixedRealityNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MixedReality.Models.MixedRealityNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MixedReality.Models.MixedRealityNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MixedRealityNameUnavailableReason : System.IEquatable<Azure.ResourceManager.MixedReality.Models.MixedRealityNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MixedRealityNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.MixedReality.Models.MixedRealityNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.MixedReality.Models.MixedRealityNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.MixedReality.Models.MixedRealityNameUnavailableReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.MixedReality.Models.MixedRealityNameUnavailableReason left, Azure.ResourceManager.MixedReality.Models.MixedRealityNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.MixedReality.Models.MixedRealityNameUnavailableReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.MixedReality.Models.MixedRealityNameUnavailableReason left, Azure.ResourceManager.MixedReality.Models.MixedRealityNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MixedRealitySku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MixedReality.Models.MixedRealitySku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MixedReality.Models.MixedRealitySku>
    {
        public MixedRealitySku(string name) { }
        public int? Capacity { get { throw null; } set { } }
        public string Family { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public string Size { get { throw null; } set { } }
        public Azure.ResourceManager.MixedReality.Models.MixedRealitySkuTier? Tier { get { throw null; } set { } }
        Azure.ResourceManager.MixedReality.Models.MixedRealitySku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MixedReality.Models.MixedRealitySku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.MixedReality.Models.MixedRealitySku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.MixedReality.Models.MixedRealitySku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MixedReality.Models.MixedRealitySku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MixedReality.Models.MixedRealitySku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.MixedReality.Models.MixedRealitySku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum MixedRealitySkuTier
    {
        Free = 0,
        Basic = 1,
        Standard = 2,
        Premium = 3,
    }
}
