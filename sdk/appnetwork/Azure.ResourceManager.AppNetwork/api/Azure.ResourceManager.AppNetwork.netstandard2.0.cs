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
        public Azure.ResourceManager.AppNetwork.Models.ProvisioningState? AppLinkProvisioningState { get { throw null; } }
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
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.AppNetwork.AppLinkMemberResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppNetwork.Models.UpgradeHistory> GetByAppLinkMember(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppNetwork.Models.UpgradeHistory> GetByAppLinkMemberAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.ResourceManager.AppNetwork.AppLinkMemberResource GetAppLinkMemberResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppNetwork.AppLinkResource GetAppLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.AppNetwork.AppLinkCollection GetAppLinks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppNetwork.AppLinkResource> GetAppLinks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppNetwork.AppLinkResource> GetAppLinksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.AppNetwork.Models.AvailableVersion> GetByLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string kubernetesVersion = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.AppNetwork.Models.AvailableVersion> GetByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string kubernetesVersion = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public virtual Azure.Pageable<Azure.ResourceManager.AppNetwork.AppLinkResource> GetAppLinks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppNetwork.AppLinkResource> GetAppLinksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.AppNetwork.Models.AvailableVersion> GetByLocation(Azure.Core.AzureLocation location, string kubernetesVersion = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.AppNetwork.Models.AvailableVersion> GetByLocationAsync(Azure.Core.AzureLocation location, string kubernetesVersion = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.AppNetwork.Models
{
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
        public Azure.ResourceManager.AppNetwork.Models.ClusterType? ClusterType { get { throw null; } set { } }
        public Azure.ResourceManager.AppNetwork.Models.ConnectivityProfile ConnectivityProfile { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier MetadataResourceId { get { throw null; } set { } }
        public string ObservabilityMetricsEndpoint { get { throw null; } }
        public Azure.ResourceManager.AppNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.AppNetwork.Models.UpgradeProfile UpgradeProfile { get { throw null; } set { } }
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
        public Azure.ResourceManager.AppNetwork.Models.ConnectivityProfile ConnectivityProfile { get { throw null; } set { } }
        public string ObservabilityMetricsEndpoint { get { throw null; } }
        public Azure.ResourceManager.AppNetwork.Models.UpgradeProfile UpgradeProfile { get { throw null; } set { } }
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
    public static partial class ArmAppNetworkModelFactory
    {
        public static Azure.ResourceManager.AppNetwork.AppLinkData AppLinkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.AppNetwork.Models.ProvisioningState? appLinkProvisioningState = default(Azure.ResourceManager.AppNetwork.Models.ProvisioningState?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.AppNetwork.AppLinkMemberData AppLinkMemberData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.AppNetwork.Models.AppLinkMemberProperties properties = null) { throw null; }
        public static Azure.ResourceManager.AppNetwork.Models.AppLinkMemberPatch AppLinkMemberPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.AppNetwork.Models.AppLinkMemberUpdateProperties properties = null) { throw null; }
        public static Azure.ResourceManager.AppNetwork.Models.AppLinkMemberProperties AppLinkMemberProperties(Azure.ResourceManager.AppNetwork.Models.ClusterType? clusterType = default(Azure.ResourceManager.AppNetwork.Models.ClusterType?), Azure.Core.ResourceIdentifier metadataResourceId = null, Azure.ResourceManager.AppNetwork.Models.UpgradeProfile upgradeProfile = null, string observabilityMetricsEndpoint = null, Azure.ResourceManager.AppNetwork.Models.ConnectivityProfile connectivityProfile = null, Azure.ResourceManager.AppNetwork.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.AppNetwork.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.AppNetwork.Models.AppLinkPatch AppLinkPatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.AppNetwork.Models.AvailableVersion AvailableVersion(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.AppNetwork.Models.AvailableVersionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.AppNetwork.Models.AvailableVersionProperties AvailableVersionProperties(string kubernetesVersion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppNetwork.Models.ReleaseChannelInfo> fullyManagedVersionsReleaseChannels = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.AppNetwork.Models.VersionInfo> selfManagedVersionDetailVersions = null, Azure.ResourceManager.AppNetwork.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.AppNetwork.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.AppNetwork.Models.ReleaseChannelInfo ReleaseChannelInfo(string releaseChannel = null, string version = null) { throw null; }
        public static Azure.ResourceManager.AppNetwork.Models.UpgradeHistory UpgradeHistory(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.AppNetwork.Models.UpgradeHistoryProperties properties = null) { throw null; }
        public static Azure.ResourceManager.AppNetwork.Models.UpgradeHistoryProperties UpgradeHistoryProperties(System.DateTimeOffset startTimestamp = default(System.DateTimeOffset), System.DateTimeOffset? endTimestamp = default(System.DateTimeOffset?), string initiatedBy = null, string fromVersion = null, string toVersion = null, Azure.ResourceManager.AppNetwork.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.AppNetwork.Models.ProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.AppNetwork.Models.VersionInfo VersionInfo(string version = null, System.Collections.Generic.IEnumerable<string> upgrades = null) { throw null; }
    }
    public partial class AvailableVersion : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AvailableVersion>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AvailableVersion>
    {
        internal AvailableVersion() { }
        public Azure.ResourceManager.AppNetwork.Models.AvailableVersionProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AppNetwork.Models.AvailableVersion System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AvailableVersion>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AvailableVersion>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppNetwork.Models.AvailableVersion System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AvailableVersion>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AvailableVersion>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AvailableVersion>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AvailableVersionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AvailableVersionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AvailableVersionProperties>
    {
        internal AvailableVersionProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppNetwork.Models.ReleaseChannelInfo> FullyManagedVersionsReleaseChannels { get { throw null; } }
        public string KubernetesVersion { get { throw null; } }
        public Azure.ResourceManager.AppNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.AppNetwork.Models.VersionInfo> SelfManagedVersionDetailVersions { get { throw null; } }
        protected virtual Azure.ResourceManager.AppNetwork.Models.AvailableVersionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AppNetwork.Models.AvailableVersionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AppNetwork.Models.AvailableVersionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AvailableVersionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.AvailableVersionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppNetwork.Models.AvailableVersionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AvailableVersionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AvailableVersionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.AvailableVersionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ClusterType : System.IEquatable<Azure.ResourceManager.AppNetwork.Models.ClusterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ClusterType(string value) { throw null; }
        public static Azure.ResourceManager.AppNetwork.Models.ClusterType AKS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppNetwork.Models.ClusterType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppNetwork.Models.ClusterType left, Azure.ResourceManager.AppNetwork.Models.ClusterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppNetwork.Models.ClusterType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AppNetwork.Models.ClusterType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppNetwork.Models.ClusterType left, Azure.ResourceManager.AppNetwork.Models.ClusterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ConnectivityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.ConnectivityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.ConnectivityProfile>
    {
        public ConnectivityProfile() { }
        public Azure.ResourceManager.AppNetwork.Models.EastWestGatewayVisibility? EastWestGatewayVisibility { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateConnectSubnetResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AppNetwork.Models.ConnectivityProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AppNetwork.Models.ConnectivityProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AppNetwork.Models.ConnectivityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.ConnectivityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.ConnectivityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppNetwork.Models.ConnectivityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.ConnectivityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.ConnectivityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.ConnectivityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EastWestGatewayVisibility : System.IEquatable<Azure.ResourceManager.AppNetwork.Models.EastWestGatewayVisibility>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EastWestGatewayVisibility(string value) { throw null; }
        public static Azure.ResourceManager.AppNetwork.Models.EastWestGatewayVisibility External { get { throw null; } }
        public static Azure.ResourceManager.AppNetwork.Models.EastWestGatewayVisibility Internal { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppNetwork.Models.EastWestGatewayVisibility other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppNetwork.Models.EastWestGatewayVisibility left, Azure.ResourceManager.AppNetwork.Models.EastWestGatewayVisibility right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppNetwork.Models.EastWestGatewayVisibility (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AppNetwork.Models.EastWestGatewayVisibility? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppNetwork.Models.EastWestGatewayVisibility left, Azure.ResourceManager.AppNetwork.Models.EastWestGatewayVisibility right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.AppNetwork.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.AppNetwork.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.AppNetwork.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.AppNetwork.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.AppNetwork.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.AppNetwork.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.AppNetwork.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.AppNetwork.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppNetwork.Models.ProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppNetwork.Models.ProvisioningState left, Azure.ResourceManager.AppNetwork.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppNetwork.Models.ProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AppNetwork.Models.ProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppNetwork.Models.ProvisioningState left, Azure.ResourceManager.AppNetwork.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ReleaseChannelInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.ReleaseChannelInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.ReleaseChannelInfo>
    {
        internal ReleaseChannelInfo() { }
        public string ReleaseChannel { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.AppNetwork.Models.ReleaseChannelInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AppNetwork.Models.ReleaseChannelInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AppNetwork.Models.ReleaseChannelInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.ReleaseChannelInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.ReleaseChannelInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppNetwork.Models.ReleaseChannelInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.ReleaseChannelInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.ReleaseChannelInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.ReleaseChannelInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpgradeHistory : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.UpgradeHistory>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.UpgradeHistory>
    {
        internal UpgradeHistory() { }
        public Azure.ResourceManager.AppNetwork.Models.UpgradeHistoryProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AppNetwork.Models.UpgradeHistory System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.UpgradeHistory>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.UpgradeHistory>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppNetwork.Models.UpgradeHistory System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.UpgradeHistory>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.UpgradeHistory>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.UpgradeHistory>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpgradeHistoryProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.UpgradeHistoryProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.UpgradeHistoryProperties>
    {
        internal UpgradeHistoryProperties() { }
        public System.DateTimeOffset? EndTimestamp { get { throw null; } }
        public string FromVersion { get { throw null; } }
        public string InitiatedBy { get { throw null; } }
        public Azure.ResourceManager.AppNetwork.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset StartTimestamp { get { throw null; } }
        public string ToVersion { get { throw null; } }
        protected virtual Azure.ResourceManager.AppNetwork.Models.UpgradeHistoryProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AppNetwork.Models.UpgradeHistoryProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AppNetwork.Models.UpgradeHistoryProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.UpgradeHistoryProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.UpgradeHistoryProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppNetwork.Models.UpgradeHistoryProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.UpgradeHistoryProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.UpgradeHistoryProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.UpgradeHistoryProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpgradeMode : System.IEquatable<Azure.ResourceManager.AppNetwork.Models.UpgradeMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpgradeMode(string value) { throw null; }
        public static Azure.ResourceManager.AppNetwork.Models.UpgradeMode FullyManaged { get { throw null; } }
        public static Azure.ResourceManager.AppNetwork.Models.UpgradeMode SelfManaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppNetwork.Models.UpgradeMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppNetwork.Models.UpgradeMode left, Azure.ResourceManager.AppNetwork.Models.UpgradeMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppNetwork.Models.UpgradeMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AppNetwork.Models.UpgradeMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppNetwork.Models.UpgradeMode left, Azure.ResourceManager.AppNetwork.Models.UpgradeMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class UpgradeProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.UpgradeProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.UpgradeProfile>
    {
        public UpgradeProfile(Azure.ResourceManager.AppNetwork.Models.UpgradeMode mode) { }
        public Azure.ResourceManager.AppNetwork.Models.UpgradeReleaseChannel? FullyManagedUpgradeReleaseChannel { get { throw null; } set { } }
        public Azure.ResourceManager.AppNetwork.Models.UpgradeMode Mode { get { throw null; } set { } }
        public string SelfManagedUpgradeVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.AppNetwork.Models.UpgradeProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AppNetwork.Models.UpgradeProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AppNetwork.Models.UpgradeProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.UpgradeProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.UpgradeProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppNetwork.Models.UpgradeProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.UpgradeProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.UpgradeProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.UpgradeProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct UpgradeReleaseChannel : System.IEquatable<Azure.ResourceManager.AppNetwork.Models.UpgradeReleaseChannel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public UpgradeReleaseChannel(string value) { throw null; }
        public static Azure.ResourceManager.AppNetwork.Models.UpgradeReleaseChannel Rapid { get { throw null; } }
        public static Azure.ResourceManager.AppNetwork.Models.UpgradeReleaseChannel Stable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.AppNetwork.Models.UpgradeReleaseChannel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.AppNetwork.Models.UpgradeReleaseChannel left, Azure.ResourceManager.AppNetwork.Models.UpgradeReleaseChannel right) { throw null; }
        public static implicit operator Azure.ResourceManager.AppNetwork.Models.UpgradeReleaseChannel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.AppNetwork.Models.UpgradeReleaseChannel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.AppNetwork.Models.UpgradeReleaseChannel left, Azure.ResourceManager.AppNetwork.Models.UpgradeReleaseChannel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VersionInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.VersionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.VersionInfo>
    {
        internal VersionInfo() { }
        public System.Collections.Generic.IList<string> Upgrades { get { throw null; } }
        public string Version { get { throw null; } }
        protected virtual Azure.ResourceManager.AppNetwork.Models.VersionInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.AppNetwork.Models.VersionInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.AppNetwork.Models.VersionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.VersionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.AppNetwork.Models.VersionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.AppNetwork.Models.VersionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.VersionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.VersionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.AppNetwork.Models.VersionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
