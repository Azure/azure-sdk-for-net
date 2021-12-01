namespace Azure.ResourceManager.DeviceUpdate
{
    public static partial class ArmClientExtensions
    {
        public static Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount GetDeviceUpdateAccount(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance GetDeviceUpdateInstance(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnection GetPrivateEndpointConnection(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxy GetPrivateEndpointConnectionProxy(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.PrivateLink GetPrivateLink(this Azure.ResourceManager.ArmClient armClient, Azure.ResourceManager.ResourceIdentifier id) { throw null; }
    }
    public partial class DeviceUpdateAccount : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected DeviceUpdateAccount() { }
        public virtual Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceCollection GetDeviceUpdateInstances() { throw null; }
        public Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxyCollection GetPrivateEndpointConnectionProxies() { throw null; }
        public Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionCollection GetPrivateEndpointConnections() { throw null; }
        public Azure.ResourceManager.DeviceUpdate.PrivateLinkCollection GetPrivateLinks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeviceUpdateAccountCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount>, System.Collections.IEnumerable
    {
        protected DeviceUpdateAccountCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountCreateOperation CreateOrUpdate(string accountName, Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountData account, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateAccountCreateOperation> CreateOrUpdateAsync(string accountName, Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountData account, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResources(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetAllAsGenericResourcesAsync(string nameFilter, string expand = null, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount> GetIfExists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount>> GetIfExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount> System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DeviceUpdateAccountData : Azure.ResourceManager.DeviceUpdate.Models.TrackedResource
    {
        public DeviceUpdateAccountData(string location) : base (default(string)) { }
        public string HostName { get { throw null; } }
        public Azure.ResourceManager.DeviceUpdate.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceUpdate.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DeviceUpdate.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
    }
    public partial class DeviceUpdateInstance : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected DeviceUpdateInstance() { }
        public virtual Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateInstanceDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateInstanceDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance> Update(Azure.ResourceManager.DeviceUpdate.Models.TagUpdateOptions tagUpdatePayload, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance>> UpdateAsync(Azure.ResourceManager.DeviceUpdate.Models.TagUpdateOptions tagUpdatePayload, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeviceUpdateInstanceCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance>, System.Collections.IEnumerable
    {
        protected DeviceUpdateInstanceCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string instanceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateInstanceCreateOperation CreateOrUpdate(string instanceName, Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceData instance, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.DeviceUpdate.Models.DeviceUpdateInstanceCreateOperation> CreateOrUpdateAsync(string instanceName, Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstanceData instance, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class DeviceUpdateInstanceData : Azure.ResourceManager.DeviceUpdate.Models.TrackedResource
    {
        public DeviceUpdateInstanceData(string location) : base (default(string)) { }
        public string AccountName { get { throw null; } }
        public Azure.ResourceManager.DeviceUpdate.Models.DiagnosticStorageProperties DiagnosticStorageProperties { get { throw null; } set { } }
        public bool? EnableDiagnostics { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.DeviceUpdate.Models.IotHubSettings> IotHubs { get { throw null; } }
        public Azure.ResourceManager.DeviceUpdate.Models.ProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class PrivateEndpointConnection : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected PrivateEndpointConnection() { }
        public virtual Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnection> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnection>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnection>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnection>, System.Collections.IEnumerable
    {
        protected PrivateEndpointConnectionCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionCreateOrUpdateOperation CreateOrUpdate(string privateEndpointConnectionName, Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionData privateEndpointConnection, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionCreateOrUpdateOperation> CreateOrUpdateAsync(string privateEndpointConnectionName, Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionData privateEndpointConnection, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class PrivateEndpointConnectionData : Azure.ResourceManager.DeviceUpdate.Models.Resource
    {
        public PrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Resources.Models.SubResource PrivateEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceUpdate.Models.PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class PrivateEndpointConnectionProxy : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected PrivateEndpointConnectionProxy() { }
        public virtual Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProxyDeleteOperation Delete(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProxyDeleteOperation> DeleteAsync(bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxy> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxy>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Validate(Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxyData privateEndpointConnectionProxy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ValidateAsync(Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxyData privateEndpointConnectionProxy, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionProxyCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxy>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxy>, System.Collections.IEnumerable
    {
        protected PrivateEndpointConnectionProxyCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string privateEndpointConnectionProxyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string privateEndpointConnectionProxyId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProxyCreateOrUpdateOperation CreateOrUpdate(string privateEndpointConnectionProxyId, Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxyData privateEndpointConnectionProxy, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProxyCreateOrUpdateOperation> CreateOrUpdateAsync(string privateEndpointConnectionProxyId, Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxyData privateEndpointConnectionProxy, bool waitForCompletion = true, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class PrivateEndpointConnectionProxyData : Azure.ResourceManager.DeviceUpdate.Models.ProxyResource
    {
        public PrivateEndpointConnectionProxyData() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProxyProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DeviceUpdate.Models.RemotePrivateEndpoint RemotePrivateEndpoint { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
    }
    public partial class PrivateLink : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.ResourceManager.ResourceType ResourceType;
        protected PrivateLink() { }
        public virtual Azure.ResourceManager.DeviceUpdate.PrivateLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateLink> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateLink>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location> GetAvailableLocations(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Azure.ResourceManager.Resources.Models.Location>> GetAvailableLocationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateLinkCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.DeviceUpdate.PrivateLink>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.DeviceUpdate.PrivateLink>, System.Collections.IEnumerable
    {
        protected PrivateLinkCollection() { }
        protected override Azure.ResourceManager.ResourceType ValidResourceType { get { throw null; } }
        public virtual Azure.Response<bool> CheckIfExists(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> CheckIfExistsAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class PrivateLinkData : Azure.ResourceManager.DeviceUpdate.Models.ProxyResource
    {
        public PrivateLinkData() { }
        public string GroupId { get { throw null; } }
        public Azure.ResourceManager.DeviceUpdate.Models.GroupIdProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
    public static partial class ResourceGroupExtensions
    {
        public static Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccountCollection GetDeviceUpdateAccounts(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.Response<Azure.ResourceManager.DeviceUpdate.Models.CheckNameAvailabilityResponse> CheckNameAvailability(this Azure.ResourceManager.Resources.Subscription subscription, Azure.ResourceManager.DeviceUpdate.Models.CheckNameAvailabilityRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.DeviceUpdate.Models.CheckNameAvailabilityResponse>> CheckNameAvailabilityAsync(this Azure.ResourceManager.Resources.Subscription subscription, Azure.ResourceManager.DeviceUpdate.Models.CheckNameAvailabilityRequest request, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Resources.GenericResource> GetDeviceUpdateAccountByName(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Resources.GenericResource> GetDeviceUpdateAccountByNameAsync(this Azure.ResourceManager.Resources.Subscription subscription, string filter, string expand, int? top, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public string PrivateIpAddress { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CreatedByType : System.IEquatable<Azure.ResourceManager.DeviceUpdate.Models.CreatedByType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CreatedByType(string value) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.Models.CreatedByType Application { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.CreatedByType Key { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.CreatedByType ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.CreatedByType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceUpdate.Models.CreatedByType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceUpdate.Models.CreatedByType left, Azure.ResourceManager.DeviceUpdate.Models.CreatedByType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceUpdate.Models.CreatedByType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceUpdate.Models.CreatedByType left, Azure.ResourceManager.DeviceUpdate.Models.CreatedByType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeviceUpdateAccountCreateOperation : Azure.Operation<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount>
    {
        protected DeviceUpdateAccountCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateAccount>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeviceUpdateAccountDeleteOperation : Azure.Operation
    {
        protected DeviceUpdateAccountDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeviceUpdateAccountUpdateOptions : Azure.ResourceManager.DeviceUpdate.Models.TagUpdateOptions
    {
        public DeviceUpdateAccountUpdateOptions() { }
        public Azure.ResourceManager.DeviceUpdate.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public string Location { get { throw null; } set { } }
    }
    public partial class DeviceUpdateInstanceCreateOperation : Azure.Operation<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance>
    {
        protected DeviceUpdateInstanceCreateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeviceUpdateInstanceDeleteOperation : Azure.Operation
    {
        protected DeviceUpdateInstanceDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeviceUpdateInstanceUpdateOperation : Azure.Operation<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance>
    {
        protected DeviceUpdateInstanceUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DeviceUpdate.DeviceUpdateInstance>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class ManagedServiceIdentity
    {
        public ManagedServiceIdentity(Azure.ResourceManager.DeviceUpdate.Models.ManagedServiceIdentityType type) { }
        public System.Guid? PrincipalId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public Azure.ResourceManager.DeviceUpdate.Models.ManagedServiceIdentityType Type { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Resources.Models.UserAssignedIdentity> UserAssignedIdentities { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedServiceIdentityType : System.IEquatable<Azure.ResourceManager.DeviceUpdate.Models.ManagedServiceIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedServiceIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.DeviceUpdate.Models.ManagedServiceIdentityType None { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.ManagedServiceIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.ManagedServiceIdentityType SystemAssignedUserAssigned { get { throw null; } }
        public static Azure.ResourceManager.DeviceUpdate.Models.ManagedServiceIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.DeviceUpdate.Models.ManagedServiceIdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.DeviceUpdate.Models.ManagedServiceIdentityType left, Azure.ResourceManager.DeviceUpdate.Models.ManagedServiceIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.DeviceUpdate.Models.ManagedServiceIdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.DeviceUpdate.Models.ManagedServiceIdentityType left, Azure.ResourceManager.DeviceUpdate.Models.ManagedServiceIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateEndpointConnectionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnection>
    {
        protected PrivateEndpointConnectionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnection Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnection>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnection>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionDeleteOperation : Azure.Operation
    {
        protected PrivateEndpointConnectionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
    public partial class PrivateEndpointConnectionProxyCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxy>
    {
        protected PrivateEndpointConnectionProxyCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxy Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxy>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.DeviceUpdate.PrivateEndpointConnectionProxy>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionProxyDeleteOperation : Azure.Operation
    {
        protected PrivateEndpointConnectionProxyDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionProxyProperties
    {
        public PrivateEndpointConnectionProxyProperties() { }
        public string ETag { get { throw null; } }
        public Azure.ResourceManager.DeviceUpdate.Models.PrivateEndpointConnectionProxyProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.DeviceUpdate.Models.RemotePrivateEndpoint RemotePrivateEndpoint { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
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
        public Azure.ResourceManager.Resources.Models.SubResource RemotePrivateEndpointConnection { get { throw null; } set { } }
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
    public partial class ProxyResource : Azure.ResourceManager.DeviceUpdate.Models.Resource
    {
        public ProxyResource() { }
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
    public partial class Resource : Azure.ResourceManager.Models.Resource
    {
        public Resource() { }
        public Azure.ResourceManager.Models.SystemData SystemData { get { throw null; } }
    }
    public partial class TagUpdateOptions
    {
        public TagUpdateOptions() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class TrackedResource : Azure.ResourceManager.DeviceUpdate.Models.Resource
    {
        public TrackedResource(string location) { }
        public string Location { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
}
