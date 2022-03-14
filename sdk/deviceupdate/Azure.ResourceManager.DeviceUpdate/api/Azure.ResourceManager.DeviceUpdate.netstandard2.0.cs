namespace Azure.ResourceManager.DeviceUpdate
{
    public static partial class ArmClientExtensions
    {
        public static Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount GetDeviceUpdateAccount(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance GetDeviceUpdateInstance(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnection GetPrivateEndpointConnection(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxy GetPrivateEndpointConnectionProxy(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.PrivateLink GetPrivateLink(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DeviceUpdateAccount : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeviceUpdateAccount() { }
        public virtual Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance> GetDeviceUpdateInstance(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance>> GetDeviceUpdateInstanceAsync(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceCollection GetDeviceUpdateInstances() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnection> GetPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnection>> GetPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxyCollection GetPrivateEndpointConnectionProxies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxy> GetPrivateEndpointConnectionProxy(string privateEndpointConnectionProxyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxy>> GetPrivateEndpointConnectionProxyAsync(string privateEndpointConnectionProxyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionCollection GetPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateLink> GetPrivateLink(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateLink>> GetPrivateLinkAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceUpdate.PrivateLinkCollection GetPrivateLinks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceUpdate.Models.PatchableDeviceUpdateAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.DeviceUpdate.Models.PatchableDeviceUpdateAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeviceUpdateAccountCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount>, System.Collections.IEnumerable
    {
        protected DeviceUpdateAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountData account, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountData account, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount> GetIfExists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount>> GetIfExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeviceUpdateAccountData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DeviceUpdateAccountData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string HostName { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceUpdate.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DeviceUpdate.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
    }
    public partial class DeviceUpdateInstance : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeviceUpdateInstance() { }
        public virtual Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string instanceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeviceUpdateInstanceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance>, System.Collections.IEnumerable
    {
        protected DeviceUpdateInstanceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance> CreateOrUpdate(Azure.WaitUntil waitUntil, string instanceName, Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceData instance, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string instanceName, Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceData instance, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance> Get(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance>> GetAsync(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance> GetIfExists(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance>> GetIfExistsAsync(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeviceUpdateInstanceData : Azure.ResourceManager.Models.TrackedResourceData
    {
        public DeviceUpdateInstanceData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string AccountName { get { throw null; } }
        public Azure.ResourceManager.DeviceUpdate.Models.DiagnosticStorageProperties DiagnosticStorageProperties { get { throw null; } set { } }
        public bool? EnableDiagnostics { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceUpdate.Models.IotHubSettings> IotHubs { get { throw null; } }
        public Azure.ResourceManager.DeviceUpdate.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class PrivateEndpointConnection : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateEndpointConnection() { }
        public virtual Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnection> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnection>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnection>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnection>, System.Collections.IEnumerable
    {
        protected PrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnection> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionData privateEndpointConnection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnection>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionData privateEndpointConnection, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnection> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnection> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnection> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnection>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnection> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnection>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnection> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnection>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnection> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnection>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData
    {
        public PrivateEndpointConnectionData() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.DeviceUpdate.Models.PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class PrivateEndpointConnectionProxy : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateEndpointConnectionProxy() { }
        public virtual Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string privateEndpointConnectionProxyId) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxy> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxy>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Validate(Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxyData privateEndpointConnectionProxy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ValidateAsync(Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxyData privateEndpointConnectionProxy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionProxyCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxy>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxy>, System.Collections.IEnumerable
    {
        protected PrivateEndpointConnectionProxyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxy> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionProxyId, Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxyData privateEndpointConnectionProxy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxy>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionProxyId, Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxyData privateEndpointConnectionProxy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionProxyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionProxyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxy> Get(string privateEndpointConnectionProxyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxy> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxy> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxy>> GetAsync(string privateEndpointConnectionProxyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxy> GetIfExists(string privateEndpointConnectionProxyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxy>> GetIfExistsAsync(string privateEndpointConnectionProxyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxy> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxy>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxy> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxy>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateEndpointConnectionProxyData : Azure.ResourceManager.Models.ResourceData
    {
        public PrivateEndpointConnectionProxyData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProxyProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DeviceUpdate.Models.RemotePrivateEndpoint RemotePrivateEndpoint { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    public partial class PrivateLink : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateLink() { }
        public virtual Azure.ResourceManager.DeviceUpdate.PrivateLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string groupId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateLink> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateLink>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateLinkCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceUpdate.PrivateLink>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceUpdate.PrivateLink>, System.Collections.IEnumerable
    {
        protected PrivateLinkCollection() { }
        public virtual Azure.Response<bool> Exists(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateLink> Get(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceUpdate.PrivateLink> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceUpdate.PrivateLink> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateLink>> GetAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateLink> GetIfExists(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateLink>> GetIfExistsAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceUpdate.PrivateLink> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceUpdate.PrivateLink>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceUpdate.PrivateLink> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceUpdate.PrivateLink>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateLinkData : Azure.ResourceManager.Models.ResourceData
    {
        public PrivateLinkData() { }
        public string GroupId { get { throw null; } }
        public Azure.ResourceManager.DeviceUpdate.Models.GroupIdProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
    public static partial class ResourceGroupExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount> GetDeviceUpdateAccount(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount>> GetDeviceUpdateAccountAsync(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountCollection GetDeviceUpdateAccounts(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DeviceUpdate.Models.CheckNameAvailabilityResponse> CheckDeviceUpdateNameAvailability(this Azure.ResourceManager.Resources.Subscription subscription, Azure.ResourceManager.DeviceUpdate.Models.CheckNameAvailabilityRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.Models.CheckNameAvailabilityResponse>> CheckDeviceUpdateNameAvailabilityAsync(this Azure.ResourceManager.Resources.Subscription subscription, Azure.ResourceManager.DeviceUpdate.Models.CheckNameAvailabilityRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount> GetDeviceUpdateAccounts(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount> GetDeviceUpdateAccountsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.DeviceUpdate.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AuthenticationType : System.IEquatable<Azure.ResourceManager.DeviceUpdate.Models.AuthenticationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthenticationType(string value) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.Models.AuthenticationType KeyBased { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceUpdate.Models.AuthenticationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceUpdate.Models.AuthenticationType left, Azure.ResourceManager.DeviceUpdate.Models.AuthenticationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceUpdate.Models.AuthenticationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceUpdate.Models.AuthenticationType left, Azure.ResourceManager.DeviceUpdate.Models.AuthenticationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CheckNameAvailabilityReason : System.IEquatable<Azure.ResourceManager.DeviceUpdate.Models.CheckNameAvailabilityReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CheckNameAvailabilityReason(string value) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.Models.CheckNameAvailabilityReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.CheckNameAvailabilityReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceUpdate.Models.CheckNameAvailabilityReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceUpdate.Models.CheckNameAvailabilityReason left, Azure.ResourceManager.DeviceUpdate.Models.CheckNameAvailabilityReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceUpdate.Models.CheckNameAvailabilityReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceUpdate.Models.CheckNameAvailabilityReason left, Azure.ResourceManager.DeviceUpdate.Models.CheckNameAvailabilityReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CheckNameAvailabilityRequest
    {
        public CheckNameAvailabilityRequest() { }
        public string Name { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
    }
    public partial class CheckNameAvailabilityResponse
    {
        internal CheckNameAvailabilityResponse() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.DeviceUpdate.Models.CheckNameAvailabilityReason? Reason { get { throw null; } }
    }
    public partial class ConnectionDetails
    {
        public ConnectionDetails() { }
        public string GroupId { get { throw null; } }
        public string Id { get { throw null; } }
        public string LinkIdentifier { get { throw null; } }
        public string MemberName { get { throw null; } }
        public string PrivateIPAddress { get { throw null; } }
    }
    public partial class DiagnosticStorageProperties
    {
        public DiagnosticStorageProperties(Azure.ResourceManager.DeviceUpdate.Models.AuthenticationType authenticationType, string resourceId) { }
        public Azure.ResourceManager.DeviceUpdate.Models.AuthenticationType AuthenticationType { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class GroupConnectivityInformation
    {
        public GroupConnectivityInformation() { }
        public System.Collections.Generic.IList<string> CustomerVisibleFqdns { get { throw null; } }
        public string GroupId { get { throw null; } }
        public string InternalFqdn { get { throw null; } }
        public string MemberName { get { throw null; } }
        public string PrivateLinkServiceArmRegion { get { throw null; } set { } }
        public string RedirectMapId { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GroupIdProvisioningState : System.IEquatable<Azure.ResourceManager.DeviceUpdate.Models.GroupIdProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GroupIdProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.Models.GroupIdProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.GroupIdProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.GroupIdProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceUpdate.Models.GroupIdProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceUpdate.Models.GroupIdProvisioningState left, Azure.ResourceManager.DeviceUpdate.Models.GroupIdProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceUpdate.Models.GroupIdProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceUpdate.Models.GroupIdProvisioningState left, Azure.ResourceManager.DeviceUpdate.Models.GroupIdProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IotHubSettings
    {
        public IotHubSettings(string resourceId) { }
        public string EventHubConnectionString { get { throw null; } set { } }
        public string IoTHubConnectionString { get { throw null; } set { } }
        public string ResourceId { get { throw null; } set { } }
    }
    public partial class PatchableDeviceUpdateAccountData
    {
        public PatchableDeviceUpdateAccountData() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointConnectionProxyProvisioningState : System.IEquatable<Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProxyProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointConnectionProxyProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProxyProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProxyProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProxyProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProxyProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProxyProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProxyProvisioningState left, Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProxyProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProxyProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProxyProvisioningState left, Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProxyProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateLinkServiceConnection
    {
        public PrivateLinkServiceConnection() { }
        public System.Collections.Generic.IList<string> GroupIds { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string RequestMessage { get { throw null; } set { } }
    }
    public partial class PrivateLinkServiceConnectionState
    {
        public PrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    public partial class PrivateLinkServiceProxy
    {
        public PrivateLinkServiceProxy() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceUpdate.Models.GroupConnectivityInformation> GroupConnectivityInformation { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RemotePrivateEndpointConnectionId { get { throw null; } }
        public Azure.ResourceManager.DeviceUpdate.Models.PrivateLinkServiceConnectionState RemotePrivateLinkServiceConnectionState { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.DeviceUpdate.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.ProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceUpdate.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceUpdate.Models.ProvisioningState left, Azure.ResourceManager.DeviceUpdate.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceUpdate.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceUpdate.Models.ProvisioningState left, Azure.ResourceManager.DeviceUpdate.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.DeviceUpdate.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceUpdate.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceUpdate.Models.PublicNetworkAccess left, Azure.ResourceManager.DeviceUpdate.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceUpdate.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceUpdate.Models.PublicNetworkAccess left, Azure.ResourceManager.DeviceUpdate.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RemotePrivateEndpoint
    {
        public RemotePrivateEndpoint() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceUpdate.Models.ConnectionDetails> ConnectionDetails { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceUpdate.Models.PrivateLinkServiceConnection> ManualPrivateLinkServiceConnections { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceUpdate.Models.PrivateLinkServiceConnection> PrivateLinkServiceConnections { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceUpdate.Models.PrivateLinkServiceProxy> PrivateLinkServiceProxies { get { throw null; } }
        public string VnetTrafficTag { get { throw null; } }
    }
}
