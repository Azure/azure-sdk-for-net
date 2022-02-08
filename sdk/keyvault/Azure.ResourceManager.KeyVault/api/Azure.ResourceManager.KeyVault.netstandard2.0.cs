namespace Azure.ResourceManager.KeyVault
{
    public static partial class ArmClientExtensions
    {
        public static Azure.ResourceManager.KeyVault.DeletedManagedHsm GetDeletedManagedHsm(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KeyVault.DeletedVault GetDeletedVault(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KeyVault.ManagedHsm GetManagedHsm(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnection GetMhsmPrivateEndpointConnection(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KeyVault.PrivateEndpointConnection GetPrivateEndpointConnection(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KeyVault.Secret GetSecret(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KeyVault.Vault GetVault(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KeyVault.VaultKey GetVaultKey(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.KeyVault.VaultKeyVersion GetVaultKeyVersion(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DeletedManagedHsm : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeletedManagedHsm() { }
        public virtual Azure.ResourceManager.KeyVault.DeletedManagedHsmData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string location, string name) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.DeletedManagedHsm> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.DeletedManagedHsm>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.Models.DeletedManagedHsmPurgeDeletedOperation PurgeDeleted(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.KeyVault.Models.DeletedManagedHsmPurgeDeletedOperation> PurgeDeletedAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeletedManagedHsmCollection : Azure.ResourceManager.Core.ArmCollection
    {
        protected DeletedManagedHsmCollection() { }
        public virtual Azure.Response<bool> Exists(string location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.DeletedManagedHsm> Get(string location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.DeletedManagedHsm>> GetAsync(string location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.DeletedManagedHsm> GetIfExists(string location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.DeletedManagedHsm>> GetIfExistsAsync(string location, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeletedManagedHsmData : Azure.ResourceManager.Models.Resource
    {
        internal DeletedManagedHsmData() { }
        public Azure.ResourceManager.KeyVault.Models.DeletedManagedHsmProperties Properties { get { throw null; } }
    }
    public partial class DeletedVault : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DeletedVault() { }
        public virtual Azure.ResourceManager.KeyVault.DeletedVaultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string location, string vaultName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.DeletedVault> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.DeletedVault>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.Models.DeletedVaultPurgeDeletedOperation PurgeDeleted(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.KeyVault.Models.DeletedVaultPurgeDeletedOperation> PurgeDeletedAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeletedVaultCollection : Azure.ResourceManager.Core.ArmCollection
    {
        protected DeletedVaultCollection() { }
        public virtual Azure.Response<bool> Exists(string location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.DeletedVault> Get(string location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.DeletedVault>> GetAsync(string location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.DeletedVault> GetIfExists(string location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.DeletedVault>> GetIfExistsAsync(string location, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeletedVaultData : Azure.ResourceManager.Models.Resource
    {
        internal DeletedVaultData() { }
        public Azure.ResourceManager.KeyVault.Models.DeletedVaultProperties Properties { get { throw null; } }
    }
    public partial class KeyData : Azure.ResourceManager.KeyVault.Models.KeyVaultResource
    {
        public KeyData() { }
        public Azure.ResourceManager.KeyVault.Models.KeyAttributes Attributes { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.JsonWebKeyCurveName? CurveName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.JsonWebKeyOperation> KeyOps { get { throw null; } }
        public int? KeySize { get { throw null; } set { } }
        public System.Uri KeyUri { get { throw null; } }
        public string KeyUriWithVersion { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.JsonWebKeyType? Kty { get { throw null; } set { } }
    }
    public partial class ManagedHsm : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedHsm() { }
        public virtual Azure.ResourceManager.KeyVault.ManagedHsmData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsm> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsm>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.Models.ManagedHsmDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.KeyVault.Models.ManagedHsmDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsm> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsm>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionCollection GetMhsmPrivateEndpointConnections() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.Models.MhsmPrivateLinkResource> GetMhsmPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.Models.MhsmPrivateLinkResource> GetMhsmPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsm> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsm>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsm> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsm>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.Models.ManagedHsmUpdateOperation Update(bool waitForCompletion, Azure.ResourceManager.KeyVault.ManagedHsmData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.KeyVault.Models.ManagedHsmUpdateOperation> UpdateAsync(bool waitForCompletion, Azure.ResourceManager.KeyVault.ManagedHsmData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedHsmCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.ManagedHsm>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.ManagedHsm>, System.Collections.IEnumerable
    {
        protected ManagedHsmCollection() { }
        public virtual Azure.ResourceManager.KeyVault.Models.ManagedHsmCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string name, Azure.ResourceManager.KeyVault.ManagedHsmData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.KeyVault.Models.ManagedHsmCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string name, Azure.ResourceManager.KeyVault.ManagedHsmData parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsm> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.ManagedHsm> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.ManagedHsm> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsm>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsm> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsm>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KeyVault.ManagedHsm> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.ManagedHsm>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KeyVault.ManagedHsm> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.ManagedHsm>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedHsmData : Azure.ResourceManager.KeyVault.Models.ManagedHsmResource
    {
        public ManagedHsmData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmProperties Properties { get { throw null; } set { } }
    }
    public partial class MhsmPrivateEndpointConnection : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected MhsmPrivateEndpointConnection() { }
        public virtual Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnection> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnection>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.Models.MhsmPrivateEndpointConnectionDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.KeyVault.Models.MhsmPrivateEndpointConnectionDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnection> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnection>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnection> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnection>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnection> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnection>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MhsmPrivateEndpointConnectionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnection>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnection>, System.Collections.IEnumerable
    {
        protected MhsmPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.KeyVault.Models.MhsmPrivateEndpointConnectionCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string privateEndpointConnectionName, Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionData properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.KeyVault.Models.MhsmPrivateEndpointConnectionCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string privateEndpointConnectionName, Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionData properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnection> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnection> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnection> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnection>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnection> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnection>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnection> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnection>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnection> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnection>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class MhsmPrivateEndpointConnectionData : Azure.ResourceManager.KeyVault.Models.ManagedHsmResource
    {
        public MhsmPrivateEndpointConnectionData(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string Etag { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.SubResource PrivateEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.MhsmPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } set { } }
    }
    public partial class PrivateEndpointConnection : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateEndpointConnection() { }
        public virtual Azure.ResourceManager.KeyVault.PrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.PrivateEndpointConnection> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.PrivateEndpointConnection>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.PrivateEndpointConnection>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.PrivateEndpointConnection>, System.Collections.IEnumerable
    {
        protected PrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string privateEndpointConnectionName, Azure.ResourceManager.KeyVault.PrivateEndpointConnectionData properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string privateEndpointConnectionName, Azure.ResourceManager.KeyVault.PrivateEndpointConnectionData properties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.PrivateEndpointConnection> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.PrivateEndpointConnection> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.PrivateEndpointConnection> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.PrivateEndpointConnection>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.PrivateEndpointConnection> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.PrivateEndpointConnection>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KeyVault.PrivateEndpointConnection> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.PrivateEndpointConnection>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KeyVault.PrivateEndpointConnection> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.PrivateEndpointConnection>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateEndpointConnectionData : Azure.ResourceManager.KeyVault.Models.KeyVaultResource
    {
        public PrivateEndpointConnectionData() { }
        public string Etag { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.SubResource PrivateEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } set { } }
    }
    public static partial class ResourceGroupExtensions
    {
        public static Azure.ResourceManager.KeyVault.ManagedHsmCollection GetManagedHsms(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
        public static Azure.ResourceManager.KeyVault.VaultCollection GetVaults(this Azure.ResourceManager.Resources.ResourceGroup resourceGroup) { throw null; }
    }
    public partial class Secret : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected Secret() { }
        public virtual Azure.ResourceManager.KeyVault.SecretData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string secretName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.Secret> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.Secret>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.Secret> Update(Azure.ResourceManager.KeyVault.Models.SecretPatchParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.Secret>> UpdateAsync(Azure.ResourceManager.KeyVault.Models.SecretPatchParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecretCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.Secret>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.Secret>, System.Collections.IEnumerable
    {
        protected SecretCollection() { }
        public virtual Azure.ResourceManager.KeyVault.Models.SecretCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string secretName, Azure.ResourceManager.KeyVault.Models.SecretCreateOrUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.KeyVault.Models.SecretCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string secretName, Azure.ResourceManager.KeyVault.Models.SecretCreateOrUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.Secret> Get(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.Secret> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.Secret> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.Secret>> GetAsync(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.Secret> GetIfExists(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.Secret>> GetIfExistsAsync(string secretName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KeyVault.Secret> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.Secret>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KeyVault.Secret> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.Secret>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SecretData : Azure.ResourceManager.KeyVault.Models.KeyVaultResource
    {
        public SecretData(Azure.ResourceManager.KeyVault.Models.SecretProperties properties) { }
        public Azure.ResourceManager.KeyVault.Models.SecretProperties Properties { get { throw null; } set { } }
    }
    public static partial class SubscriptionExtensions
    {
        public static Azure.Response<Azure.ResourceManager.KeyVault.Models.CheckNameAvailabilityResult> CheckKeyVaultNameAvailability(this Azure.ResourceManager.Resources.Subscription subscription, Azure.ResourceManager.KeyVault.Models.VaultCheckNameAvailabilityParameters vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.Models.CheckNameAvailabilityResult>> CheckKeyVaultNameAvailabilityAsync(this Azure.ResourceManager.Resources.Subscription subscription, Azure.ResourceManager.KeyVault.Models.VaultCheckNameAvailabilityParameters vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.KeyVault.DeletedManagedHsmCollection GetDeletedManagedHsms(this Azure.ResourceManager.Resources.Subscription subscription) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.KeyVault.DeletedManagedHsm> GetDeletedManagedHsms(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.KeyVault.DeletedManagedHsm> GetDeletedManagedHsmsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.KeyVault.DeletedVaultCollection GetDeletedVaults(this Azure.ResourceManager.Resources.Subscription subscription) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.KeyVault.DeletedVault> GetDeletedVaults(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.KeyVault.DeletedVault> GetDeletedVaultsAsync(this Azure.ResourceManager.Resources.Subscription subscription, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.KeyVault.ManagedHsm> GetManagedHsms(this Azure.ResourceManager.Resources.Subscription subscription, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.KeyVault.ManagedHsm> GetManagedHsmsAsync(this Azure.ResourceManager.Resources.Subscription subscription, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.KeyVault.Vault> GetVaults(this Azure.ResourceManager.Resources.Subscription subscription, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.KeyVault.Vault> GetVaultsAsync(this Azure.ResourceManager.Resources.Subscription subscription, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class Vault : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected Vault() { }
        public virtual Azure.ResourceManager.KeyVault.VaultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.Models.VaultDeleteOperation Delete(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.KeyVault.Models.VaultDeleteOperation> DeleteAsync(bool waitForCompletion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.Vault> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.Vault>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.PrivateEndpointConnectionCollection GetPrivateEndpointConnections() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.Models.PrivateLinkResource> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.Models.PrivateLinkResource> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.SecretCollection GetSecrets() { throw null; }
        public virtual Azure.ResourceManager.KeyVault.VaultKeyCollection GetVaultKeys() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.Vault> Update(Azure.ResourceManager.KeyVault.Models.VaultPatchParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.Models.VaultAccessPolicyParameters> UpdateAccessPolicy(Azure.ResourceManager.KeyVault.Models.AccessPolicyUpdateKind operationKind, Azure.ResourceManager.KeyVault.Models.VaultAccessPolicyParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.Models.VaultAccessPolicyParameters>> UpdateAccessPolicyAsync(Azure.ResourceManager.KeyVault.Models.AccessPolicyUpdateKind operationKind, Azure.ResourceManager.KeyVault.Models.VaultAccessPolicyParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.Vault>> UpdateAsync(Azure.ResourceManager.KeyVault.Models.VaultPatchParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VaultCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.Vault>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.Vault>, System.Collections.IEnumerable
    {
        protected VaultCollection() { }
        public virtual Azure.ResourceManager.KeyVault.Models.VaultCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string vaultName, Azure.ResourceManager.KeyVault.Models.VaultCreateOrUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.KeyVault.Models.VaultCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string vaultName, Azure.ResourceManager.KeyVault.Models.VaultCreateOrUpdateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.Vault> Get(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.Vault> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.Vault> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.Vault>> GetAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.Vault> GetIfExists(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.Vault>> GetIfExistsAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KeyVault.Vault> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.Vault>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KeyVault.Vault> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.Vault>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VaultData : Azure.ResourceManager.Models.Resource
    {
        internal VaultData() { }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.VaultProperties Properties { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class VaultKey : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VaultKey() { }
        public virtual Azure.ResourceManager.KeyVault.KeyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string keyName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.VaultKey> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.VaultKey>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.KeyVault.VaultKeyVersionCollection GetVaultKeyVersions() { throw null; }
    }
    public partial class VaultKeyCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.VaultKey>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.VaultKey>, System.Collections.IEnumerable
    {
        protected VaultKeyCollection() { }
        public virtual Azure.ResourceManager.KeyVault.Models.VaultKeyCreateOrUpdateOperation CreateOrUpdate(bool waitForCompletion, string keyName, Azure.ResourceManager.KeyVault.Models.KeyCreateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.KeyVault.Models.VaultKeyCreateOrUpdateOperation> CreateOrUpdateAsync(bool waitForCompletion, string keyName, Azure.ResourceManager.KeyVault.Models.KeyCreateParameters parameters, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.VaultKey> Get(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.VaultKey> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.VaultKey> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.VaultKey>> GetAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.VaultKey> GetIfExists(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.VaultKey>> GetIfExistsAsync(string keyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KeyVault.VaultKey> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.VaultKey>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KeyVault.VaultKey> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.VaultKey>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VaultKeyVersion : Azure.ResourceManager.Core.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VaultKeyVersion() { }
        public virtual Azure.ResourceManager.KeyVault.KeyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string keyName, string keyVersion) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.VaultKeyVersion> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.VaultKeyVersion>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VaultKeyVersionCollection : Azure.ResourceManager.Core.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.VaultKeyVersion>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.VaultKeyVersion>, System.Collections.IEnumerable
    {
        protected VaultKeyVersionCollection() { }
        public virtual Azure.Response<bool> Exists(string keyVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string keyVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.VaultKeyVersion> Get(string keyVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.KeyVault.VaultKeyVersion> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.KeyVault.VaultKeyVersion> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.VaultKeyVersion>> GetAsync(string keyVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.KeyVault.VaultKeyVersion> GetIfExists(string keyVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.KeyVault.VaultKeyVersion>> GetIfExistsAsync(string keyVersion, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.KeyVault.VaultKeyVersion> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.KeyVault.VaultKeyVersion>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.KeyVault.VaultKeyVersion> System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.VaultKeyVersion>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
}
namespace Azure.ResourceManager.KeyVault.Models
{
    public partial class AccessPermissions
    {
        public AccessPermissions() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.CertificatePermissions> Certificates { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.KeyPermissions> Keys { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.SecretPermissions> Secrets { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.StoragePermissions> Storage { get { throw null; } }
    }
    public partial class AccessPolicyEntry
    {
        public AccessPolicyEntry(System.Guid tenantId, string objectId, Azure.ResourceManager.KeyVault.Models.AccessPermissions permissions) { }
        public System.Guid? ApplicationId { get { throw null; } set { } }
        public string ObjectId { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.AccessPermissions Permissions { get { throw null; } set { } }
        public System.Guid TenantId { get { throw null; } set { } }
    }
    public enum AccessPolicyUpdateKind
    {
        Add = 0,
        Replace = 1,
        Remove = 2,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActionsRequired : System.IEquatable<Azure.ResourceManager.KeyVault.Models.ActionsRequired>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActionsRequired(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.ActionsRequired None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.ActionsRequired other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.ActionsRequired left, Azure.ResourceManager.KeyVault.Models.ActionsRequired right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.ActionsRequired (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.ActionsRequired left, Azure.ResourceManager.KeyVault.Models.ActionsRequired right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BaseAttributes
    {
        public BaseAttributes() { }
        public System.DateTimeOffset? Created { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public System.DateTimeOffset? Expires { get { throw null; } set { } }
        public System.DateTimeOffset? NotBefore { get { throw null; } set { } }
        public System.DateTimeOffset? Updated { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CertificatePermissions : System.IEquatable<Azure.ResourceManager.KeyVault.Models.CertificatePermissions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CertificatePermissions(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions All { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions Backup { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions Create { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions Delete { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions Deleteissuers { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions Get { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions Getissuers { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions Import { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions List { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions Listissuers { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions Managecontacts { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions Manageissuers { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions Purge { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions Recover { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions Restore { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions Setissuers { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.CertificatePermissions Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.CertificatePermissions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.CertificatePermissions left, Azure.ResourceManager.KeyVault.Models.CertificatePermissions right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.CertificatePermissions (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.CertificatePermissions left, Azure.ResourceManager.KeyVault.Models.CertificatePermissions right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CheckNameAvailabilityResult
    {
        internal CheckNameAvailabilityResult() { }
        public string Message { get { throw null; } }
        public bool? NameAvailable { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.NameAvailabilityReason? Reason { get { throw null; } }
    }
    public enum CreateMode
    {
        Recover = 0,
        Default = 1,
    }
    public partial class DeletedManagedHsmProperties
    {
        internal DeletedManagedHsmProperties() { }
        public System.DateTimeOffset? DeletionDate { get { throw null; } }
        public string Location { get { throw null; } }
        public string MhsmId { get { throw null; } }
        public bool? PurgeProtectionEnabled { get { throw null; } }
        public System.DateTimeOffset? ScheduledPurgeDate { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class DeletedManagedHsmPurgeDeletedOperation : Azure.Operation
    {
        protected DeletedManagedHsmPurgeDeletedOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DeletedVaultProperties
    {
        internal DeletedVaultProperties() { }
        public System.DateTimeOffset? DeletionDate { get { throw null; } }
        public string Location { get { throw null; } }
        public bool? PurgeProtectionEnabled { get { throw null; } }
        public System.DateTimeOffset? ScheduledPurgeDate { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
        public string VaultId { get { throw null; } }
    }
    public partial class DeletedVaultPurgeDeletedOperation : Azure.Operation
    {
        protected DeletedVaultPurgeDeletedOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeletionRecoveryLevel : System.IEquatable<Azure.ResourceManager.KeyVault.Models.DeletionRecoveryLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeletionRecoveryLevel(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.DeletionRecoveryLevel Purgeable { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.DeletionRecoveryLevel Recoverable { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.DeletionRecoveryLevel RecoverableProtectedSubscription { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.DeletionRecoveryLevel RecoverablePurgeable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.DeletionRecoveryLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.DeletionRecoveryLevel left, Azure.ResourceManager.KeyVault.Models.DeletionRecoveryLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.DeletionRecoveryLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.DeletionRecoveryLevel left, Azure.ResourceManager.KeyVault.Models.DeletionRecoveryLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentityType : System.IEquatable<Azure.ResourceManager.KeyVault.Models.IdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentityType(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.IdentityType Application { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityType Key { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityType ManagedIdentity { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.IdentityType User { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.IdentityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.IdentityType left, Azure.ResourceManager.KeyVault.Models.IdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.IdentityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.IdentityType left, Azure.ResourceManager.KeyVault.Models.IdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IPRule
    {
        public IPRule(string value) { }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JsonWebKeyCurveName : System.IEquatable<Azure.ResourceManager.KeyVault.Models.JsonWebKeyCurveName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JsonWebKeyCurveName(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.JsonWebKeyCurveName P256 { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.JsonWebKeyCurveName P256K { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.JsonWebKeyCurveName P384 { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.JsonWebKeyCurveName P521 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.JsonWebKeyCurveName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.JsonWebKeyCurveName left, Azure.ResourceManager.KeyVault.Models.JsonWebKeyCurveName right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.JsonWebKeyCurveName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.JsonWebKeyCurveName left, Azure.ResourceManager.KeyVault.Models.JsonWebKeyCurveName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JsonWebKeyOperation : System.IEquatable<Azure.ResourceManager.KeyVault.Models.JsonWebKeyOperation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JsonWebKeyOperation(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.JsonWebKeyOperation Decrypt { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.JsonWebKeyOperation Encrypt { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.JsonWebKeyOperation Import { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.JsonWebKeyOperation Sign { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.JsonWebKeyOperation UnwrapKey { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.JsonWebKeyOperation Verify { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.JsonWebKeyOperation WrapKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.JsonWebKeyOperation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.JsonWebKeyOperation left, Azure.ResourceManager.KeyVault.Models.JsonWebKeyOperation right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.JsonWebKeyOperation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.JsonWebKeyOperation left, Azure.ResourceManager.KeyVault.Models.JsonWebKeyOperation right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JsonWebKeyType : System.IEquatable<Azure.ResourceManager.KeyVault.Models.JsonWebKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JsonWebKeyType(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.JsonWebKeyType EC { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.JsonWebKeyType ECHSM { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.JsonWebKeyType RSA { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.JsonWebKeyType RSAHSM { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.JsonWebKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.JsonWebKeyType left, Azure.ResourceManager.KeyVault.Models.JsonWebKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.JsonWebKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.JsonWebKeyType left, Azure.ResourceManager.KeyVault.Models.JsonWebKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyAttributes
    {
        public KeyAttributes() { }
        public long? Created { get { throw null; } }
        public bool? Enabled { get { throw null; } set { } }
        public long? Expires { get { throw null; } set { } }
        public bool? Exportable { get { throw null; } set { } }
        public long? NotBefore { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.DeletionRecoveryLevel? RecoveryLevel { get { throw null; } }
        public long? Updated { get { throw null; } }
    }
    public partial class KeyCreateParameters
    {
        public KeyCreateParameters(Azure.ResourceManager.KeyVault.Models.KeyProperties properties) { }
        public Azure.ResourceManager.KeyVault.Models.KeyProperties Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyPermissions : System.IEquatable<Azure.ResourceManager.KeyVault.Models.KeyPermissions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyPermissions(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions All { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions Backup { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions Create { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions Decrypt { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions Delete { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions Encrypt { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions Get { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions Import { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions List { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions Purge { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions Recover { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions Restore { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions Sign { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions UnwrapKey { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions Update { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions Verify { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.KeyPermissions WrapKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.KeyPermissions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.KeyPermissions left, Azure.ResourceManager.KeyVault.Models.KeyPermissions right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.KeyPermissions (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.KeyPermissions left, Azure.ResourceManager.KeyVault.Models.KeyPermissions right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class KeyProperties
    {
        public KeyProperties() { }
        public Azure.ResourceManager.KeyVault.Models.KeyAttributes Attributes { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.JsonWebKeyCurveName? CurveName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.JsonWebKeyOperation> KeyOps { get { throw null; } }
        public int? KeySize { get { throw null; } set { } }
        public System.Uri KeyUri { get { throw null; } }
        public string KeyUriWithVersion { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.JsonWebKeyType? Kty { get { throw null; } set { } }
    }
    public partial class KeyVaultResource : Azure.ResourceManager.Models.Resource
    {
        public KeyVaultResource() { }
        public string Location { get { throw null; } }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class ManagedHsmCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.KeyVault.ManagedHsm>
    {
        protected ManagedHsmCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.KeyVault.ManagedHsm Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsm>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsm>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedHsmDeleteOperation : Azure.Operation
    {
        protected ManagedHsmDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedHsmProperties
    {
        public ManagedHsmProperties() { }
        public Azure.ResourceManager.KeyVault.Models.CreateMode? CreateMode { get { throw null; } set { } }
        public bool? EnablePurgeProtection { get { throw null; } set { } }
        public bool? EnableSoftDelete { get { throw null; } set { } }
        public System.Uri HsmUri { get { throw null; } }
        public System.Collections.Generic.IList<string> InitialAdminObjectIds { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.MhsmNetworkRuleSet NetworkAcls { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.KeyVault.Models.MhsmPrivateEndpointConnectionItem> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public System.DateTimeOffset? ScheduledPurgeDate { get { throw null; } }
        public int? SoftDeleteRetentionInDays { get { throw null; } set { } }
        public string StatusMessage { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class ManagedHsmResource : Azure.ResourceManager.Models.TrackedResource
    {
        public ManagedHsmResource(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmSku Sku { get { throw null; } set { } }
    }
    public partial class ManagedHsmSku
    {
        public ManagedHsmSku(Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily family, Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuName name) { }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily Family { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuName Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedHsmSkuFamily : System.IEquatable<Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedHsmSkuFamily(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily B { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily left, Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily left, Azure.ResourceManager.KeyVault.Models.ManagedHsmSkuFamily right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum ManagedHsmSkuName
    {
        StandardB1 = 0,
        CustomB32 = 1,
    }
    public partial class ManagedHsmUpdateOperation : Azure.Operation<Azure.ResourceManager.KeyVault.ManagedHsm>
    {
        protected ManagedHsmUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.KeyVault.ManagedHsm Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsm>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.KeyVault.ManagedHsm>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MhsmipRule
    {
        public MhsmipRule(string value) { }
        public string Value { get { throw null; } set { } }
    }
    public partial class MhsmNetworkRuleSet
    {
        public MhsmNetworkRuleSet() { }
        public Azure.ResourceManager.KeyVault.Models.NetworkRuleBypassOptions? Bypass { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.NetworkRuleAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.MhsmipRule> IpRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Resources.Models.WritableSubResource> VirtualNetworkRules { get { throw null; } }
    }
    public partial class MhsmPrivateEndpointConnectionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnection>
    {
        protected MhsmPrivateEndpointConnectionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnection Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnection>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnection>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MhsmPrivateEndpointConnectionDeleteOperation : Azure.Operation<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionData>
    {
        protected MhsmPrivateEndpointConnectionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionData>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.KeyVault.MhsmPrivateEndpointConnectionData>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MhsmPrivateEndpointConnectionItem
    {
        internal MhsmPrivateEndpointConnectionItem() { }
        public Azure.ResourceManager.Resources.Models.SubResource PrivateEndpoint { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.MhsmPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    public partial class MhsmPrivateLinkResource : Azure.ResourceManager.KeyVault.Models.ManagedHsmResource
    {
        public MhsmPrivateLinkResource(Azure.Core.AzureLocation location) : base (default(Azure.Core.AzureLocation)) { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class MhsmPrivateLinkResourceListResult
    {
        internal MhsmPrivateLinkResourceListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.KeyVault.Models.MhsmPrivateLinkResource> Value { get { throw null; } }
    }
    public partial class MhsmPrivateLinkServiceConnectionState
    {
        public MhsmPrivateLinkServiceConnectionState() { }
        public Azure.ResourceManager.KeyVault.Models.ActionsRequired? ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.PrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    public enum NameAvailabilityReason
    {
        AccountNameInvalid = 0,
        AlreadyExists = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkRuleAction : System.IEquatable<Azure.ResourceManager.KeyVault.Models.NetworkRuleAction>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkRuleAction(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.NetworkRuleAction Allow { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.NetworkRuleAction Deny { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.NetworkRuleAction other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.NetworkRuleAction left, Azure.ResourceManager.KeyVault.Models.NetworkRuleAction right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.NetworkRuleAction (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.NetworkRuleAction left, Azure.ResourceManager.KeyVault.Models.NetworkRuleAction right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkRuleBypassOptions : System.IEquatable<Azure.ResourceManager.KeyVault.Models.NetworkRuleBypassOptions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkRuleBypassOptions(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.NetworkRuleBypassOptions AzureServices { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.NetworkRuleBypassOptions None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.NetworkRuleBypassOptions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.NetworkRuleBypassOptions left, Azure.ResourceManager.KeyVault.Models.NetworkRuleBypassOptions right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.NetworkRuleBypassOptions (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.NetworkRuleBypassOptions left, Azure.ResourceManager.KeyVault.Models.NetworkRuleBypassOptions right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkRuleSet
    {
        public NetworkRuleSet() { }
        public Azure.ResourceManager.KeyVault.Models.NetworkRuleBypassOptions? Bypass { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.NetworkRuleAction? DefaultAction { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.IPRule> IpRules { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.VirtualNetworkRule> VirtualNetworkRules { get { throw null; } }
    }
    public partial class PrivateEndpointConnectionCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.KeyVault.PrivateEndpointConnection>
    {
        protected PrivateEndpointConnectionCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.KeyVault.PrivateEndpointConnection Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.KeyVault.PrivateEndpointConnection>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.KeyVault.PrivateEndpointConnection>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionDeleteOperation : Azure.Operation<Azure.ResourceManager.KeyVault.PrivateEndpointConnectionData>
    {
        protected PrivateEndpointConnectionDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.KeyVault.PrivateEndpointConnectionData Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.KeyVault.PrivateEndpointConnectionData>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.KeyVault.PrivateEndpointConnectionData>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class PrivateEndpointConnectionItem
    {
        internal PrivateEndpointConnectionItem() { }
        public string Etag { get { throw null; } }
        public string Id { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.SubResource PrivateEndpoint { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.KeyVault.Models.PrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.PrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.PrivateEndpointServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.PrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.PrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.PrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.PrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.KeyVault.Models.PrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.PrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.PrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.KeyVault.Models.PrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateLinkResource : Azure.ResourceManager.KeyVault.Models.KeyVaultResource
    {
        public PrivateLinkResource() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
    }
    public partial class PrivateLinkResourceListResult
    {
        internal PrivateLinkResourceListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.KeyVault.Models.PrivateLinkResource> Value { get { throw null; } }
    }
    public partial class PrivateLinkServiceConnectionState
    {
        public PrivateLinkServiceConnectionState() { }
        public Azure.ResourceManager.KeyVault.Models.ActionsRequired? ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.PrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.KeyVault.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.ProvisioningState Activated { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ProvisioningState Restoring { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ProvisioningState SecurityDomainRestore { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.ProvisioningState left, Azure.ResourceManager.KeyVault.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.ProvisioningState left, Azure.ResourceManager.KeyVault.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.KeyVault.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.PublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.PublicNetworkAccess left, Azure.ResourceManager.KeyVault.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.PublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.PublicNetworkAccess left, Azure.ResourceManager.KeyVault.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecretAttributes : Azure.ResourceManager.KeyVault.Models.BaseAttributes
    {
        public SecretAttributes() { }
    }
    public partial class SecretCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.KeyVault.Secret>
    {
        protected SecretCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.KeyVault.Secret Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.KeyVault.Secret>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.KeyVault.Secret>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SecretCreateOrUpdateParameters
    {
        public SecretCreateOrUpdateParameters(Azure.ResourceManager.KeyVault.Models.SecretProperties properties) { }
        public Azure.ResourceManager.KeyVault.Models.SecretProperties Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class SecretPatchParameters
    {
        public SecretPatchParameters() { }
        public Azure.ResourceManager.KeyVault.Models.SecretPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class SecretPatchProperties
    {
        public SecretPatchProperties() { }
        public Azure.ResourceManager.KeyVault.Models.SecretAttributes Attributes { get { throw null; } set { } }
        public string ContentType { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecretPermissions : System.IEquatable<Azure.ResourceManager.KeyVault.Models.SecretPermissions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecretPermissions(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.SecretPermissions All { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.SecretPermissions Backup { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.SecretPermissions Delete { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.SecretPermissions Get { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.SecretPermissions List { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.SecretPermissions Purge { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.SecretPermissions Recover { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.SecretPermissions Restore { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.SecretPermissions Set { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.SecretPermissions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.SecretPermissions left, Azure.ResourceManager.KeyVault.Models.SecretPermissions right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.SecretPermissions (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.SecretPermissions left, Azure.ResourceManager.KeyVault.Models.SecretPermissions right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecretProperties
    {
        public SecretProperties() { }
        public Azure.ResourceManager.KeyVault.Models.SecretAttributes Attributes { get { throw null; } set { } }
        public string ContentType { get { throw null; } set { } }
        public System.Uri SecretUri { get { throw null; } }
        public string SecretUriWithVersion { get { throw null; } }
        public string Value { get { throw null; } set { } }
    }
    public partial class Sku
    {
        public Sku(Azure.ResourceManager.KeyVault.Models.SkuFamily family, Azure.ResourceManager.KeyVault.Models.SkuName name) { }
        public Azure.ResourceManager.KeyVault.Models.SkuFamily Family { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.SkuName Name { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SkuFamily : System.IEquatable<Azure.ResourceManager.KeyVault.Models.SkuFamily>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SkuFamily(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.SkuFamily A { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.SkuFamily other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.SkuFamily left, Azure.ResourceManager.KeyVault.Models.SkuFamily right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.SkuFamily (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.SkuFamily left, Azure.ResourceManager.KeyVault.Models.SkuFamily right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum SkuName
    {
        Standard = 0,
        Premium = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StoragePermissions : System.IEquatable<Azure.ResourceManager.KeyVault.Models.StoragePermissions>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StoragePermissions(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermissions All { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermissions Backup { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermissions Delete { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermissions Deletesas { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermissions Get { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermissions Getsas { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermissions List { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermissions Listsas { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermissions Purge { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermissions Recover { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermissions Regeneratekey { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermissions Restore { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermissions Set { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermissions Setsas { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.StoragePermissions Update { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.StoragePermissions other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.StoragePermissions left, Azure.ResourceManager.KeyVault.Models.StoragePermissions right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.StoragePermissions (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.StoragePermissions left, Azure.ResourceManager.KeyVault.Models.StoragePermissions right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VaultAccessPolicyParameters : Azure.ResourceManager.Models.Resource
    {
        public VaultAccessPolicyParameters(Azure.ResourceManager.KeyVault.Models.VaultAccessPolicyProperties properties) { }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.VaultAccessPolicyProperties Properties { get { throw null; } set { } }
    }
    public partial class VaultAccessPolicyProperties
    {
        public VaultAccessPolicyProperties(System.Collections.Generic.IEnumerable<Azure.ResourceManager.KeyVault.Models.AccessPolicyEntry> accessPolicies) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.AccessPolicyEntry> AccessPolicies { get { throw null; } }
    }
    public partial class VaultCheckNameAvailabilityParameters
    {
        public VaultCheckNameAvailabilityParameters(string name) { }
        public string Name { get { throw null; } }
        public string Type { get { throw null; } }
    }
    public partial class VaultCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.KeyVault.Vault>
    {
        protected VaultCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.KeyVault.Vault Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.KeyVault.Vault>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.KeyVault.Vault>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VaultCreateOrUpdateParameters
    {
        public VaultCreateOrUpdateParameters(string location, Azure.ResourceManager.KeyVault.Models.VaultProperties properties) { }
        public string Location { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.VaultProperties Properties { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class VaultDeleteOperation : Azure.Operation
    {
        protected VaultDeleteOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> WaitForCompletionResponseAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VaultKeyCreateOrUpdateOperation : Azure.Operation<Azure.ResourceManager.KeyVault.VaultKey>
    {
        protected VaultKeyCreateOrUpdateOperation() { }
        public override bool HasCompleted { get { throw null; } }
        public override bool HasValue { get { throw null; } }
        public override string Id { get { throw null; } }
        public override Azure.ResourceManager.KeyVault.VaultKey Value { get { throw null; } }
        public override Azure.Response GetRawResponse() { throw null; }
        public override Azure.Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.KeyVault.VaultKey>> WaitForCompletionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public override System.Threading.Tasks.ValueTask<Azure.Response<Azure.ResourceManager.KeyVault.VaultKey>> WaitForCompletionAsync(System.TimeSpan pollingInterval, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VaultPatchParameters
    {
        public VaultPatchParameters() { }
        public Azure.ResourceManager.KeyVault.Models.VaultPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
    }
    public partial class VaultPatchProperties
    {
        public VaultPatchProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.AccessPolicyEntry> AccessPolicies { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.CreateMode? CreateMode { get { throw null; } set { } }
        public bool? EnabledForDeployment { get { throw null; } set { } }
        public bool? EnabledForDiskEncryption { get { throw null; } set { } }
        public bool? EnabledForTemplateDeployment { get { throw null; } set { } }
        public bool? EnablePurgeProtection { get { throw null; } set { } }
        public bool? EnableRbacAuthorization { get { throw null; } set { } }
        public bool? EnableSoftDelete { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.NetworkRuleSet NetworkAcls { get { throw null; } set { } }
        public string PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.Sku Sku { get { throw null; } set { } }
        public int? SoftDeleteRetentionInDays { get { throw null; } set { } }
        public System.Guid? TenantId { get { throw null; } set { } }
    }
    public partial class VaultProperties
    {
        public VaultProperties(System.Guid tenantId, Azure.ResourceManager.KeyVault.Models.Sku sku) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.KeyVault.Models.AccessPolicyEntry> AccessPolicies { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.CreateMode? CreateMode { get { throw null; } set { } }
        public bool? EnabledForDeployment { get { throw null; } set { } }
        public bool? EnabledForDiskEncryption { get { throw null; } set { } }
        public bool? EnabledForTemplateDeployment { get { throw null; } set { } }
        public bool? EnablePurgeProtection { get { throw null; } set { } }
        public bool? EnableRbacAuthorization { get { throw null; } set { } }
        public bool? EnableSoftDelete { get { throw null; } set { } }
        public string HsmPoolResourceId { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.NetworkRuleSet NetworkAcls { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.KeyVault.Models.PrivateEndpointConnectionItem> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.KeyVault.Models.VaultProvisioningState? ProvisioningState { get { throw null; } set { } }
        public string PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.KeyVault.Models.Sku Sku { get { throw null; } set { } }
        public int? SoftDeleteRetentionInDays { get { throw null; } set { } }
        public System.Guid TenantId { get { throw null; } set { } }
        public System.Uri VaultUri { get { throw null; } set { } }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VaultProvisioningState : System.IEquatable<Azure.ResourceManager.KeyVault.Models.VaultProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VaultProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.KeyVault.Models.VaultProvisioningState RegisteringDns { get { throw null; } }
        public static Azure.ResourceManager.KeyVault.Models.VaultProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.KeyVault.Models.VaultProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.KeyVault.Models.VaultProvisioningState left, Azure.ResourceManager.KeyVault.Models.VaultProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.KeyVault.Models.VaultProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.KeyVault.Models.VaultProvisioningState left, Azure.ResourceManager.KeyVault.Models.VaultProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VirtualNetworkRule
    {
        public VirtualNetworkRule(string id) { }
        public string Id { get { throw null; } set { } }
        public bool? IgnoreMissingVnetServiceEndpoint { get { throw null; } set { } }
    }
}
