namespace Azure.ResourceManager.DeviceUpdate
{
    public partial class AzureResourceManagerDeviceUpdateContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerDeviceUpdateContext() { }
        public static Azure.ResourceManager.DeviceUpdate.AzureResourceManagerDeviceUpdateContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DeviceUpdateAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource>, System.Collections.IEnumerable
    {
        protected DeviceUpdateAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource> GetIfExists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource>> GetIfExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeviceUpdateAccountData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountData>
    {
        public DeviceUpdateAccountData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateEncryption Encryption { get { throw null; } set { } }
        public string HostName { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountLocationDetail> Locations { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateSku? Sku { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceUpdateAccountResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeviceUpdateAccountResource() { }
        public virtual Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceResource> GetDeviceUpdateInstance(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceResource>> GetDeviceUpdateInstanceAsync(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceCollection GetDeviceUpdateInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionResource> GetDeviceUpdatePrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionResource>> GetDeviceUpdatePrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyCollection GetDeviceUpdatePrivateEndpointConnectionProxies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyResource> GetDeviceUpdatePrivateEndpointConnectionProxy(string privateEndpointConnectionProxyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyResource>> GetDeviceUpdatePrivateEndpointConnectionProxyAsync(string privateEndpointConnectionProxyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionCollection GetDeviceUpdatePrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkResource> GetDeviceUpdatePrivateLink(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkResource>> GetDeviceUpdatePrivateLinkAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkCollection GetDeviceUpdatePrivateLinks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DeviceUpdateExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateNameAvailabilityResult> CheckDeviceUpdateNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateNameAvailabilityResult>> CheckDeviceUpdateNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource> GetDeviceUpdateAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource>> GetDeviceUpdateAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource GetDeviceUpdateAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountCollection GetDeviceUpdateAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource> GetDeviceUpdateAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource> GetDeviceUpdateAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceResource GetDeviceUpdateInstanceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyResource GetDeviceUpdatePrivateEndpointConnectionProxyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionResource GetDeviceUpdatePrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkResource GetDeviceUpdatePrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DeviceUpdateInstanceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceResource>, System.Collections.IEnumerable
    {
        protected DeviceUpdateInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string instanceName, Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string instanceName, Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceResource> Get(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceResource>> GetAsync(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceResource> GetIfExists(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceResource>> GetIfExistsAsync(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeviceUpdateInstanceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceData>
    {
        public DeviceUpdateInstanceData(Azure.Core.AzureLocation location) { }
        public string AccountName { get { throw null; } }
        public Azure.ResourceManager.DeviceUpdate.Models.DiagnosticStorageProperties DiagnosticStorageProperties { get { throw null; } set { } }
        public bool? EnableDiagnostics { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateIotHubSettings> IotHubs { get { throw null; } }
        public Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceUpdateInstanceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeviceUpdateInstanceResource() { }
        public virtual Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string instanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceResource> Update(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceResource>> UpdateAsync(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateInstancePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeviceUpdatePrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected DeviceUpdatePrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeviceUpdatePrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionData>
    {
        public DeviceUpdatePrivateEndpointConnectionData(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceConnectionState connectionState) { }
        public Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceUpdatePrivateEndpointConnectionProxyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyResource>, System.Collections.IEnumerable
    {
        protected DeviceUpdatePrivateEndpointConnectionProxyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionProxyId, Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionProxyId, Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionProxyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionProxyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyResource> Get(string privateEndpointConnectionProxyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyResource>> GetAsync(string privateEndpointConnectionProxyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyResource> GetIfExists(string privateEndpointConnectionProxyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyResource>> GetIfExistsAsync(string privateEndpointConnectionProxyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeviceUpdatePrivateEndpointConnectionProxyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyData>
    {
        public DeviceUpdatePrivateEndpointConnectionProxyData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionProxyProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateRemotePrivateEndpoint RemotePrivateEndpoint { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceUpdatePrivateEndpointConnectionProxyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeviceUpdatePrivateEndpointConnectionProxyResource() { }
        public virtual Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string privateEndpointConnectionProxyId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response UpdatePrivateEndpointProperties(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointUpdate privateEndpointUpdate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> UpdatePrivateEndpointPropertiesAsync(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointUpdate privateEndpointUpdate, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Validate(Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ValidateAsync(Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeviceUpdatePrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeviceUpdatePrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeviceUpdatePrivateLinkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkResource>, System.Collections.IEnumerable
    {
        protected DeviceUpdatePrivateLinkCollection() { }
        public virtual Azure.Response<bool> Exists(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkResource> Get(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkResource>> GetAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkResource> GetIfExists(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkResource>> GetIfExistsAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeviceUpdatePrivateLinkData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkData>
    {
        public DeviceUpdatePrivateLinkData() { }
        public string GroupId { get { throw null; } }
        public Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceUpdatePrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeviceUpdatePrivateLinkResource() { }
        public virtual Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string groupId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
namespace Azure.ResourceManager.DeviceUpdate.Mocking
{
    public partial class MockableDeviceUpdateArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDeviceUpdateArmClient() { }
        public virtual Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource GetDeviceUpdateAccountResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceResource GetDeviceUpdateInstanceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyResource GetDeviceUpdatePrivateEndpointConnectionProxyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionResource GetDeviceUpdatePrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkResource GetDeviceUpdatePrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDeviceUpdateResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDeviceUpdateResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource> GetDeviceUpdateAccount(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource>> GetDeviceUpdateAccountAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountCollection GetDeviceUpdateAccounts() { throw null; }
    }
    public partial class MockableDeviceUpdateSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDeviceUpdateSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateNameAvailabilityResult> CheckDeviceUpdateNameAvailability(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateNameAvailabilityResult>> CheckDeviceUpdateNameAvailabilityAsync(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource> GetDeviceUpdateAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountResource> GetDeviceUpdateAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DeviceUpdate.Models
{
    public static partial class ArmDeviceUpdateModelFactory
    {
        public static Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountData DeviceUpdateAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateProvisioningState?), string hostName = null, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePublicNetworkAccess?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateSku? sku = default(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateSku?), Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateEncryption encryption = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountLocationDetail> locations = null) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountLocationDetail DeviceUpdateAccountLocationDetail(string name = null, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountLocationRole? role = default(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountLocationRole?)) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceData DeviceUpdateInstanceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateProvisioningState?), string accountName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateIotHubSettings> iotHubs = null, bool? enableDiagnostics = default(bool?), Azure.ResourceManager.DeviceUpdate.Models.DiagnosticStorageProperties diagnosticStorageProperties = null) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateNameAvailabilityResult DeviceUpdateNameAvailabilityResult(bool? isNameAvailable = default(bool?), Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateNameUnavailableReason? reason = default(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionData DeviceUpdatePrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceConnectionState connectionState = null, System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionDetails DeviceUpdatePrivateEndpointConnectionDetails(string id = null, string privateIPAddress = null, string linkIdentifier = null, string groupId = null, string memberName = null) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateEndpointConnectionProxyData DeviceUpdatePrivateEndpointConnectionProxyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionProxyProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionProxyProvisioningState?), string eTag = null, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateRemotePrivateEndpoint remotePrivateEndpoint = null, string status = null) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.DeviceUpdatePrivateLinkData DeviceUpdatePrivateLinkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkProvisioningState? provisioningState = default(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.Models.GroupConnectivityInformation GroupConnectivityInformation(string groupId = null, string memberName = null, System.Collections.Generic.IEnumerable<string> customerVisibleFqdns = null, string internalFqdn = null, string redirectMapId = null, Azure.Core.AzureLocation? privateLinkServiceArmRegion = default(Azure.Core.AzureLocation?)) { throw null; }
    }
    public partial class DeviceUpdateAccountLocationDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountLocationDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountLocationDetail>
    {
        internal DeviceUpdateAccountLocationDetail() { }
        public string Name { get { throw null; } }
        public Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountLocationRole? Role { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountLocationDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountLocationDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountLocationDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountLocationDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountLocationDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountLocationDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountLocationDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceUpdateAccountLocationRole : System.IEquatable<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountLocationRole>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceUpdateAccountLocationRole(string value) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountLocationRole Failover { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountLocationRole Primary { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountLocationRole other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountLocationRole left, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountLocationRole right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountLocationRole (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountLocationRole left, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountLocationRole right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeviceUpdateAccountPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountPatch>
    {
        public DeviceUpdateAccountPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceUpdateAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAvailabilityContent>
    {
        public DeviceUpdateAvailabilityContent() { }
        public Azure.Core.ResourceType? CheckNameAvailabilityRequestType { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceUpdateEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateEncryption>
    {
        public DeviceUpdateEncryption() { }
        public System.Uri KeyVaultKeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceUpdateInstancePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateInstancePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateInstancePatch>
    {
        public DeviceUpdateInstancePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateInstancePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateInstancePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateInstancePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateInstancePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateInstancePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateInstancePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateInstancePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceUpdateIotHubSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateIotHubSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateIotHubSettings>
    {
        public DeviceUpdateIotHubSettings(Azure.Core.ResourceIdentifier resourceId) { }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateIotHubSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateIotHubSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateIotHubSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateIotHubSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateIotHubSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateIotHubSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateIotHubSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceUpdateNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateNameAvailabilityResult>
    {
        internal DeviceUpdateNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateNameUnavailableReason? Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceUpdateNameUnavailableReason : System.IEquatable<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceUpdateNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateNameUnavailableReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateNameUnavailableReason left, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateNameUnavailableReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateNameUnavailableReason left, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeviceUpdatePrivateEndpointConnectionDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionDetails>
    {
        public DeviceUpdatePrivateEndpointConnectionDetails() { }
        public string GroupId { get { throw null; } }
        public string Id { get { throw null; } }
        public string LinkIdentifier { get { throw null; } }
        public string MemberName { get { throw null; } }
        public string PrivateIPAddress { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceUpdatePrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceUpdatePrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceUpdatePrivateEndpointConnectionProxyProvisioningState : System.IEquatable<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionProxyProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceUpdatePrivateEndpointConnectionProxyProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionProxyProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionProxyProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionProxyProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionProxyProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionProxyProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionProxyProvisioningState left, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionProxyProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionProxyProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionProxyProvisioningState left, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionProxyProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceUpdatePrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceUpdatePrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeviceUpdatePrivateEndpointUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointUpdate>
    {
        public DeviceUpdatePrivateEndpointUpdate() { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ImmutableResourceId { get { throw null; } set { } }
        public string ImmutableSubscriptionId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string VnetTrafficTag { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceUpdatePrivateLinkProvisioningState : System.IEquatable<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceUpdatePrivateLinkProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkProvisioningState left, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkProvisioningState left, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeviceUpdatePrivateLinkServiceConnection : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceConnection>
    {
        public DeviceUpdatePrivateLinkServiceConnection() { }
        public System.Collections.Generic.IList<string> GroupIds { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string RequestMessage { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceConnection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceConnection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceUpdatePrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceConnectionState>
    {
        public DeviceUpdatePrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeviceUpdatePrivateLinkServiceProxy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceProxy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceProxy>
    {
        public DeviceUpdatePrivateLinkServiceProxy() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceUpdate.Models.GroupConnectivityInformation> GroupConnectivityInformation { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RemotePrivateEndpointConnectionId { get { throw null; } }
        public Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceConnectionState RemotePrivateLinkServiceConnectionState { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceProxy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceProxy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceProxy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceProxy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceProxy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceProxy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceProxy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceUpdateProvisioningState : System.IEquatable<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceUpdateProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateProvisioningState left, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateProvisioningState left, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceUpdatePublicNetworkAccess : System.IEquatable<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceUpdatePublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePublicNetworkAccess left, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePublicNetworkAccess left, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeviceUpdateRemotePrivateEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateRemotePrivateEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateRemotePrivateEndpoint>
    {
        public DeviceUpdateRemotePrivateEndpoint() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateEndpointConnectionDetails> ConnectionDetails { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ImmutableResourceId { get { throw null; } set { } }
        public string ImmutableSubscriptionId { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceConnection> ManualPrivateLinkServiceConnections { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceConnection> PrivateLinkServiceConnections { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdatePrivateLinkServiceProxy> PrivateLinkServiceProxies { get { throw null; } }
        public string VnetTrafficTag { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateRemotePrivateEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateRemotePrivateEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateRemotePrivateEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateRemotePrivateEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateRemotePrivateEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateRemotePrivateEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateRemotePrivateEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeviceUpdateSku : System.IEquatable<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeviceUpdateSku(string value) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateSku Free { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateSku Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateSku left, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateSku left, Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiagnosticStorageAuthenticationType : System.IEquatable<Azure.ResourceManager.DeviceUpdate.Models.DiagnosticStorageAuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiagnosticStorageAuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.Models.DiagnosticStorageAuthenticationType KeyBased { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceUpdate.Models.DiagnosticStorageAuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceUpdate.Models.DiagnosticStorageAuthenticationType left, Azure.ResourceManager.DeviceUpdate.Models.DiagnosticStorageAuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceUpdate.Models.DiagnosticStorageAuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceUpdate.Models.DiagnosticStorageAuthenticationType left, Azure.ResourceManager.DeviceUpdate.Models.DiagnosticStorageAuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiagnosticStorageProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DiagnosticStorageProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DiagnosticStorageProperties>
    {
        public DiagnosticStorageProperties(Azure.ResourceManager.DeviceUpdate.Models.DiagnosticStorageAuthenticationType authenticationType, Azure.Core.ResourceIdentifier resourceId) { }
        public Azure.ResourceManager.DeviceUpdate.Models.DiagnosticStorageAuthenticationType AuthenticationType { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.Models.DiagnosticStorageProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DiagnosticStorageProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.DiagnosticStorageProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.Models.DiagnosticStorageProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DiagnosticStorageProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DiagnosticStorageProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.DiagnosticStorageProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupConnectivityInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.GroupConnectivityInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.GroupConnectivityInformation>
    {
        public GroupConnectivityInformation() { }
        public System.Collections.Generic.IList<string> CustomerVisibleFqdns { get { throw null; } }
        public string GroupId { get { throw null; } }
        public string InternalFqdn { get { throw null; } }
        public string MemberName { get { throw null; } }
        public Azure.Core.AzureLocation? PrivateLinkServiceArmRegion { get { throw null; } set { } }
        public string RedirectMapId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.Models.GroupConnectivityInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.GroupConnectivityInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.DeviceUpdate.Models.GroupConnectivityInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.DeviceUpdate.Models.GroupConnectivityInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.GroupConnectivityInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.GroupConnectivityInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.DeviceUpdate.Models.GroupConnectivityInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
