namespace Azure.ResourceManager.AppNetwork
{
    public partial class AppLinkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppNetwork.AppLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppNetwork.AppLinkResource>, System.Collections.IEnumerable
    {
        protected AppLinkCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppNetwork.AppLinkResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string appLinkName, Azure.ResourceManager.AppNetwork.AppLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppNetwork.AppLinkResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string appLinkName, Azure.ResourceManager.AppNetwork.AppLinkData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string appLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string appLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppNetwork.AppLinkResource> Get(string appLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppNetwork.AppLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppNetwork.AppLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppNetwork.AppLinkResource>> GetAsync(string appLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AppNetwork.AppLinkResource> GetIfExists(string appLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AppNetwork.AppLinkResource>> GetIfExistsAsync(string appLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppNetwork.AppLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppNetwork.AppLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppNetwork.AppLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppNetwork.AppLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppLinkData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.AppLinkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.AppLinkData>
    {
        public AppLinkData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.AppNetwork.Models.AppLinkProvisioningState? AppLinkProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AppNetwork.AppLinkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.AppLinkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.AppLinkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppNetwork.AppLinkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.AppLinkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.AppLinkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.AppLinkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppLinkMemberCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppNetwork.AppLinkMemberResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppNetwork.AppLinkMemberResource>, System.Collections.IEnumerable
    {
        protected AppLinkMemberCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppNetwork.AppLinkMemberResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string appLinkMemberName, Azure.ResourceManager.AppNetwork.AppLinkMemberData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppNetwork.AppLinkMemberResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string appLinkMemberName, Azure.ResourceManager.AppNetwork.AppLinkMemberData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string appLinkMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string appLinkMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppNetwork.AppLinkMemberResource> Get(string appLinkMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppNetwork.AppLinkMemberResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppNetwork.AppLinkMemberResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppNetwork.AppLinkMemberResource>> GetAsync(string appLinkMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.AppNetwork.AppLinkMemberResource> GetIfExists(string appLinkMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.AppNetwork.AppLinkMemberResource>> GetIfExistsAsync(string appLinkMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.AppNetwork.AppLinkMemberResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.AppNetwork.AppLinkMemberResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.AppNetwork.AppLinkMemberResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppNetwork.AppLinkMemberResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AppLinkMemberData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.AppLinkMemberData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.AppLinkMemberData>
    {
        public AppLinkMemberData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.AppNetwork.Models.AppLinkMemberProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AppNetwork.AppLinkMemberData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.AppLinkMemberData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.AppLinkMemberData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppNetwork.AppLinkMemberData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.AppLinkMemberData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.AppLinkMemberData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.AppLinkMemberData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppLinkMemberResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.AppLinkMemberData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.AppLinkMemberData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppLinkMemberResource() { }
        public virtual Azure.ResourceManager.AppNetwork.AppLinkMemberData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppNetwork.AppLinkMemberResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppNetwork.AppLinkMemberResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string appLinkName, string appLinkMemberName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppNetwork.AppLinkMemberResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeHistory> GetAppLinkUpgradeHistories(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeHistory> GetAppLinkUpgradeHistoriesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppNetwork.AppLinkMemberResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppNetwork.AppLinkMemberResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppNetwork.AppLinkMemberResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppNetwork.AppLinkMemberResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppNetwork.AppLinkMemberResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.AppNetwork.AppLinkMemberData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.AppLinkMemberData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.AppLinkMemberData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppNetwork.AppLinkMemberData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.AppLinkMemberData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.AppLinkMemberData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.AppLinkMemberData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppNetwork.AppLinkMemberResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppNetwork.Models.AppLinkMemberPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppNetwork.AppLinkMemberResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppNetwork.Models.AppLinkMemberPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AppLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.AppLinkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.AppLinkData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AppLinkResource() { }
        public virtual Azure.ResourceManager.AppNetwork.AppLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.AppNetwork.AppLinkResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppNetwork.AppLinkResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string appLinkName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppNetwork.AppLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppNetwork.AppLinkMemberResource> GetAppLinkMember(string appLinkMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppNetwork.AppLinkMemberResource>> GetAppLinkMemberAsync(string appLinkMemberName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppNetwork.AppLinkMemberCollection GetAppLinkMembers() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppNetwork.AppLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppNetwork.AppLinkResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppNetwork.AppLinkResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.AppNetwork.AppLinkResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppNetwork.AppLinkResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.AppNetwork.AppLinkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.AppLinkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.AppLinkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppNetwork.AppLinkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.AppLinkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.AppLinkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.AppLinkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppNetwork.AppLinkResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppNetwork.Models.AppLinkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.AppNetwork.AppLinkResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.AppNetwork.Models.AppLinkPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class AppNetworkExtensions
    {
        public static Azure.Response<Azure.ResourceManager.AppNetwork.AppLinkResource> GetAppLink(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string appLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppNetwork.AppLinkResource>> GetAppLinkAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string appLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppNetwork.Models.AppLinkAvailableVersion> GetAppLinkAvailableVersionsByLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string kubernetesVersion = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppNetwork.Models.AppLinkAvailableVersion> GetAppLinkAvailableVersionsByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string kubernetesVersion = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.AppNetwork.AppLinkMemberResource GetAppLinkMemberResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppNetwork.AppLinkResource GetAppLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppNetwork.AppLinkCollection GetAppLinks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppNetwork.AppLinkResource> GetAppLinks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppNetwork.AppLinkResource> GetAppLinksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerAppNetworkContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerAppNetworkContext() { }
        public static Azure.ResourceManager.AppNetwork.AzureResourceManagerAppNetworkContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
}
namespace Azure.ResourceManager.AppNetwork.Mocking
{
    public partial class MockableAppNetworkArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableAppNetworkArmClient() { }
        public virtual Azure.ResourceManager.AppNetwork.AppLinkMemberResource GetAppLinkMemberResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.AppNetwork.AppLinkResource GetAppLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableAppNetworkResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAppNetworkResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.AppNetwork.AppLinkResource> GetAppLink(string appLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppNetwork.AppLinkResource>> GetAppLinkAsync(string appLinkName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.AppNetwork.AppLinkCollection GetAppLinks() { throw null; }
    }
    public partial class MockableAppNetworkSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableAppNetworkSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.AppNetwork.Models.AppLinkAvailableVersion> GetAppLinkAvailableVersionsByLocation(Azure.Core.AzureLocation location, string kubernetesVersion = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppNetwork.Models.AppLinkAvailableVersion> GetAppLinkAvailableVersionsByLocationAsync(Azure.Core.AzureLocation location, string kubernetesVersion = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppNetwork.AppLinkResource> GetAppLinks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppNetwork.AppLinkResource> GetAppLinksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.AppNetwork.Models
{
    public partial class AppLinkAvailableVersion : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkAvailableVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkAvailableVersion>
    {
        internal AppLinkAvailableVersion() { }
        public Azure.ResourceManager.AppNetwork.Models.AppLinkAvailableVersionProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AppNetwork.Models.AppLinkAvailableVersion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkAvailableVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkAvailableVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppNetwork.Models.AppLinkAvailableVersion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkAvailableVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkAvailableVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkAvailableVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppLinkAvailableVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkAvailableVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkAvailableVersionProperties>
    {
        internal AppLinkAvailableVersionProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppNetwork.Models.AppLinkReleaseChannelInfo> FullyManagedVersionsReleaseChannels { get { throw null; } }
        public string KubernetesVersion { get { throw null; } }
        public Azure.ResourceManager.AppNetwork.Models.AppLinkProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppNetwork.Models.AppLinkVersionInfo> SelfManagedVersionDetailVersions { get { throw null; } }
        protected virtual Azure.ResourceManager.AppNetwork.Models.AppLinkAvailableVersionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AppNetwork.Models.AppLinkAvailableVersionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AppNetwork.Models.AppLinkAvailableVersionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkAvailableVersionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkAvailableVersionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppNetwork.Models.AppLinkAvailableVersionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkAvailableVersionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkAvailableVersionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkAvailableVersionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppLinkClusterType : System.IEquatable<Azure.ResourceManager.AppNetwork.Models.AppLinkClusterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppLinkClusterType(string value) { throw null; }
        public static Azure.ResourceManager.AppNetwork.Models.AppLinkClusterType Aks { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppNetwork.Models.AppLinkClusterType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppNetwork.Models.AppLinkClusterType left, Azure.ResourceManager.AppNetwork.Models.AppLinkClusterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppNetwork.Models.AppLinkClusterType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AppNetwork.Models.AppLinkClusterType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppNetwork.Models.AppLinkClusterType left, Azure.ResourceManager.AppNetwork.Models.AppLinkClusterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppLinkConnectivityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkConnectivityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkConnectivityProfile>
    {
        public AppLinkConnectivityProfile() { }
        public Azure.ResourceManager.AppNetwork.Models.AppLinkEastWestGatewayVisibility? EastWestGatewayVisibility { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateConnectSubnetResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AppNetwork.Models.AppLinkConnectivityProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AppNetwork.Models.AppLinkConnectivityProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AppNetwork.Models.AppLinkConnectivityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkConnectivityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkConnectivityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppNetwork.Models.AppLinkConnectivityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkConnectivityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkConnectivityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkConnectivityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppLinkEastWestGatewayVisibility : System.IEquatable<Azure.ResourceManager.AppNetwork.Models.AppLinkEastWestGatewayVisibility>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppLinkEastWestGatewayVisibility(string value) { throw null; }
        public static Azure.ResourceManager.AppNetwork.Models.AppLinkEastWestGatewayVisibility External { get { throw null; } }
        public static Azure.ResourceManager.AppNetwork.Models.AppLinkEastWestGatewayVisibility Internal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppNetwork.Models.AppLinkEastWestGatewayVisibility other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppNetwork.Models.AppLinkEastWestGatewayVisibility left, Azure.ResourceManager.AppNetwork.Models.AppLinkEastWestGatewayVisibility right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppNetwork.Models.AppLinkEastWestGatewayVisibility (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AppNetwork.Models.AppLinkEastWestGatewayVisibility? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppNetwork.Models.AppLinkEastWestGatewayVisibility left, Azure.ResourceManager.AppNetwork.Models.AppLinkEastWestGatewayVisibility right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppLinkMemberPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkMemberPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkMemberPatch>
    {
        public AppLinkMemberPatch() { }
        public Azure.ResourceManager.AppNetwork.Models.AppLinkMemberUpdateProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.AppNetwork.Models.AppLinkMemberPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AppNetwork.Models.AppLinkMemberPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AppNetwork.Models.AppLinkMemberPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkMemberPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkMemberPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppNetwork.Models.AppLinkMemberPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkMemberPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkMemberPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkMemberPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppLinkMemberProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkMemberProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkMemberProperties>
    {
        public AppLinkMemberProperties(Azure.Core.ResourceIdentifier metadataResourceId) { }
        public Azure.ResourceManager.AppNetwork.Models.AppLinkClusterType? ClusterType { get { throw null; } set { } }
        public Azure.ResourceManager.AppNetwork.Models.AppLinkConnectivityProfile ConnectivityProfile { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MetadataResourceId { get { throw null; } set { } }
        public string ObservabilityMetricsEndpoint { get { throw null; } }
        public Azure.ResourceManager.AppNetwork.Models.AppLinkProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeProfile UpgradeProfile { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AppNetwork.Models.AppLinkMemberProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AppNetwork.Models.AppLinkMemberProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AppNetwork.Models.AppLinkMemberProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkMemberProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkMemberProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppNetwork.Models.AppLinkMemberProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkMemberProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkMemberProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkMemberProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppLinkMemberUpdateProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkMemberUpdateProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkMemberUpdateProperties>
    {
        public AppLinkMemberUpdateProperties() { }
        public Azure.ResourceManager.AppNetwork.Models.AppLinkConnectivityProfile ConnectivityProfile { get { throw null; } set { } }
        public string ObservabilityMetricsEndpoint { get { throw null; } }
        public Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeProfile UpgradeProfile { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AppNetwork.Models.AppLinkMemberUpdateProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AppNetwork.Models.AppLinkMemberUpdateProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AppNetwork.Models.AppLinkMemberUpdateProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkMemberUpdateProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkMemberUpdateProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppNetwork.Models.AppLinkMemberUpdateProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkMemberUpdateProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkMemberUpdateProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkMemberUpdateProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppLinkPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkPatch>
    {
        public AppLinkPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.AppNetwork.Models.AppLinkPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AppNetwork.Models.AppLinkPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AppNetwork.Models.AppLinkPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppNetwork.Models.AppLinkPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppLinkProvisioningState : System.IEquatable<Azure.ResourceManager.AppNetwork.Models.AppLinkProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppLinkProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.AppNetwork.Models.AppLinkProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.AppNetwork.Models.AppLinkProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.AppNetwork.Models.AppLinkProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.AppNetwork.Models.AppLinkProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.AppNetwork.Models.AppLinkProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.AppNetwork.Models.AppLinkProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.AppNetwork.Models.AppLinkProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppNetwork.Models.AppLinkProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppNetwork.Models.AppLinkProvisioningState left, Azure.ResourceManager.AppNetwork.Models.AppLinkProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppNetwork.Models.AppLinkProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AppNetwork.Models.AppLinkProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppNetwork.Models.AppLinkProvisioningState left, Azure.ResourceManager.AppNetwork.Models.AppLinkProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppLinkReleaseChannelInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkReleaseChannelInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkReleaseChannelInfo>
    {
        internal AppLinkReleaseChannelInfo() { }
        public string ReleaseChannel { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.AppNetwork.Models.AppLinkReleaseChannelInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AppNetwork.Models.AppLinkReleaseChannelInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AppNetwork.Models.AppLinkReleaseChannelInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkReleaseChannelInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkReleaseChannelInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppNetwork.Models.AppLinkReleaseChannelInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkReleaseChannelInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkReleaseChannelInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkReleaseChannelInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppLinkUpgradeHistory : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeHistory>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeHistory>
    {
        internal AppLinkUpgradeHistory() { }
        public Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeHistoryProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeHistory System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeHistory>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeHistory>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeHistory System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeHistory>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeHistory>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeHistory>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AppLinkUpgradeHistoryProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeHistoryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeHistoryProperties>
    {
        internal AppLinkUpgradeHistoryProperties() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string FromVersion { get { throw null; } }
        public string InitiatedBy { get { throw null; } }
        public Azure.ResourceManager.AppNetwork.Models.AppLinkProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset StartOn { get { throw null; } }
        public string ToVersion { get { throw null; } }
        protected virtual Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeHistoryProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeHistoryProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeHistoryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeHistoryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeHistoryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeHistoryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeHistoryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeHistoryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeHistoryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppLinkUpgradeMode : System.IEquatable<Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppLinkUpgradeMode(string value) { throw null; }
        public static Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeMode FullyManaged { get { throw null; } }
        public static Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeMode SelfManaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeMode left, Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeMode left, Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppLinkUpgradeProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeProfile>
    {
        public AppLinkUpgradeProfile(Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeMode mode) { }
        public Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeReleaseChannel? FullyManagedUpgradeReleaseChannel { get { throw null; } set { } }
        public Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeMode Mode { get { throw null; } set { } }
        public string SelfManagedUpgradeVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AppLinkUpgradeReleaseChannel : System.IEquatable<Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeReleaseChannel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AppLinkUpgradeReleaseChannel(string value) { throw null; }
        public static Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeReleaseChannel Rapid { get { throw null; } }
        public static Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeReleaseChannel Stable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeReleaseChannel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeReleaseChannel left, Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeReleaseChannel right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeReleaseChannel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeReleaseChannel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeReleaseChannel left, Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeReleaseChannel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AppLinkVersionInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkVersionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkVersionInfo>
    {
        internal AppLinkVersionInfo() { }
        public System.Collections.Generic.IList<string> Upgrades { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.AppNetwork.Models.AppLinkVersionInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AppNetwork.Models.AppLinkVersionInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AppNetwork.Models.AppLinkVersionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkVersionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AppLinkVersionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppNetwork.Models.AppLinkVersionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkVersionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkVersionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AppLinkVersionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmAppNetworkModelFactory
    {
        public static Azure.ResourceManager.AppNetwork.Models.AppLinkAvailableVersion AppLinkAvailableVersion(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.AppNetwork.Models.AppLinkAvailableVersionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.AppNetwork.Models.AppLinkAvailableVersionProperties AppLinkAvailableVersionProperties(string kubernetesVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppNetwork.Models.AppLinkReleaseChannelInfo> fullyManagedVersionsReleaseChannels = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppNetwork.Models.AppLinkVersionInfo> selfManagedVersionDetailVersions = null, Azure.ResourceManager.AppNetwork.Models.AppLinkProvisioningState? provisioningState = default(Azure.ResourceManager.AppNetwork.Models.AppLinkProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.AppNetwork.AppLinkData AppLinkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.AppNetwork.Models.AppLinkProvisioningState? appLinkProvisioningState = default(Azure.ResourceManager.AppNetwork.Models.AppLinkProvisioningState?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.AppNetwork.AppLinkMemberData AppLinkMemberData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.AppNetwork.Models.AppLinkMemberProperties properties = null) { throw null; }
        public static Azure.ResourceManager.AppNetwork.Models.AppLinkMemberPatch AppLinkMemberPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.AppNetwork.Models.AppLinkMemberUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.AppNetwork.Models.AppLinkMemberProperties AppLinkMemberProperties(Azure.ResourceManager.AppNetwork.Models.AppLinkClusterType? clusterType = default(Azure.ResourceManager.AppNetwork.Models.AppLinkClusterType?), Azure.Core.ResourceIdentifier metadataResourceId = null, Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeProfile upgradeProfile = null, string observabilityMetricsEndpoint = null, Azure.ResourceManager.AppNetwork.Models.AppLinkConnectivityProfile connectivityProfile = null, Azure.ResourceManager.AppNetwork.Models.AppLinkProvisioningState? provisioningState = default(Azure.ResourceManager.AppNetwork.Models.AppLinkProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.AppNetwork.Models.AppLinkPatch AppLinkPatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.AppNetwork.Models.AppLinkReleaseChannelInfo AppLinkReleaseChannelInfo(string releaseChannel = null, string version = null) { throw null; }
        public static Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeHistory AppLinkUpgradeHistory(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeHistoryProperties properties = null) { throw null; }
        public static Azure.ResourceManager.AppNetwork.Models.AppLinkUpgradeHistoryProperties AppLinkUpgradeHistoryProperties(System.DateTimeOffset startOn = default(System.DateTimeOffset), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string initiatedBy = null, string fromVersion = null, string toVersion = null, Azure.ResourceManager.AppNetwork.Models.AppLinkProvisioningState? provisioningState = default(Azure.ResourceManager.AppNetwork.Models.AppLinkProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.AppNetwork.Models.AppLinkVersionInfo AppLinkVersionInfo(string version = null, System.Collections.Generic.IEnumerable<string> upgrades = null) { throw null; }
    }
}
