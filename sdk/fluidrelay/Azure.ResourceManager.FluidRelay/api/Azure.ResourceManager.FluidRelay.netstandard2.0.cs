namespace Azure.ResourceManager.FluidRelay
{
    public partial class FluidRelayContainerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.FluidRelay.FluidRelayContainerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FluidRelay.FluidRelayContainerResource>, System.Collections.IEnumerable
    {
        protected FluidRelayContainerCollection() { }
        public virtual Azure.Response<bool> Exists(string fluidRelayContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fluidRelayContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FluidRelay.FluidRelayContainerResource> Get(string fluidRelayContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.FluidRelay.FluidRelayContainerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.FluidRelay.FluidRelayContainerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FluidRelay.FluidRelayContainerResource>> GetAsync(string fluidRelayContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.FluidRelay.FluidRelayContainerResource> GetIfExists(string fluidRelayContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.FluidRelay.FluidRelayContainerResource>> GetIfExistsAsync(string fluidRelayContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.FluidRelay.FluidRelayContainerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.FluidRelay.FluidRelayContainerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.FluidRelay.FluidRelayContainerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.FluidRelay.FluidRelayContainerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FluidRelayContainerData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FluidRelay.FluidRelayContainerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.FluidRelayContainerData>
    {
        public FluidRelayContainerData() { }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.Guid? FrsContainerId { get { throw null; } }
        public System.Guid? FrsTenantId { get { throw null; } }
        public System.DateTimeOffset? LastAccessOn { get { throw null; } }
        public Azure.ResourceManager.FluidRelay.Models.FluidRelayProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.FluidRelay.FluidRelayContainerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FluidRelay.FluidRelayContainerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FluidRelay.FluidRelayContainerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FluidRelay.FluidRelayContainerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.FluidRelayContainerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.FluidRelayContainerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.FluidRelayContainerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FluidRelayContainerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FluidRelayContainerResource() { }
        public virtual Azure.ResourceManager.FluidRelay.FluidRelayContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroup, string fluidRelayServerName, string fluidRelayContainerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FluidRelay.FluidRelayContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FluidRelay.FluidRelayContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class FluidRelayExtensions
    {
        public static Azure.ResourceManager.FluidRelay.FluidRelayContainerResource GetFluidRelayContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.FluidRelay.FluidRelayServerResource> GetFluidRelayServer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fluidRelayServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FluidRelay.FluidRelayServerResource>> GetFluidRelayServerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fluidRelayServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.FluidRelay.FluidRelayServerResource GetFluidRelayServerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.FluidRelay.FluidRelayServerCollection GetFluidRelayServers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.FluidRelay.FluidRelayServerResource> GetFluidRelayServers(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.FluidRelay.FluidRelayServerResource> GetFluidRelayServersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class FluidRelayServerCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.FluidRelay.FluidRelayServerResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.FluidRelay.FluidRelayServerResource>, System.Collections.IEnumerable
    {
        protected FluidRelayServerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FluidRelay.FluidRelayServerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fluidRelayServerName, Azure.ResourceManager.FluidRelay.FluidRelayServerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.FluidRelay.FluidRelayServerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fluidRelayServerName, Azure.ResourceManager.FluidRelay.FluidRelayServerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fluidRelayServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fluidRelayServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FluidRelay.FluidRelayServerResource> Get(string fluidRelayServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.FluidRelay.FluidRelayServerResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.FluidRelay.FluidRelayServerResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FluidRelay.FluidRelayServerResource>> GetAsync(string fluidRelayServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.FluidRelay.FluidRelayServerResource> GetIfExists(string fluidRelayServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.FluidRelay.FluidRelayServerResource>> GetIfExistsAsync(string fluidRelayServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.FluidRelay.FluidRelayServerResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.FluidRelay.FluidRelayServerResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.FluidRelay.FluidRelayServerResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.FluidRelay.FluidRelayServerResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class FluidRelayServerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FluidRelay.FluidRelayServerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.FluidRelayServerData>
    {
        public FluidRelayServerData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.FluidRelay.Models.CmkEncryptionProperties CustomerManagedKeyEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.FluidRelay.Models.FluidRelayEndpoints FluidRelayEndpoints { get { throw null; } }
        public System.Guid? FrsTenantId { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.FluidRelay.Models.FluidRelayProvisioningState? ProvisioningState { get { throw null; } set { } }
        public Azure.ResourceManager.FluidRelay.Models.FluidRelayStorageSku? StorageSku { get { throw null; } set { } }
        Azure.ResourceManager.FluidRelay.FluidRelayServerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FluidRelay.FluidRelayServerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FluidRelay.FluidRelayServerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FluidRelay.FluidRelayServerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.FluidRelayServerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.FluidRelayServerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.FluidRelayServerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FluidRelayServerResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected FluidRelayServerResource() { }
        public virtual Azure.ResourceManager.FluidRelay.FluidRelayServerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.FluidRelay.FluidRelayServerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FluidRelay.FluidRelayServerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroup, string fluidRelayServerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FluidRelay.FluidRelayServerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FluidRelay.FluidRelayServerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FluidRelay.FluidRelayContainerResource> GetFluidRelayContainer(string fluidRelayContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FluidRelay.FluidRelayContainerResource>> GetFluidRelayContainerAsync(string fluidRelayContainerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.FluidRelay.FluidRelayContainerCollection GetFluidRelayContainers() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FluidRelay.Models.FluidRelayServerKeys> GetKeys(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FluidRelay.Models.FluidRelayServerKeys>> GetKeysAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FluidRelay.Models.FluidRelayServerKeys> RegenerateKeys(Azure.ResourceManager.FluidRelay.Models.RegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FluidRelay.Models.FluidRelayServerKeys>> RegenerateKeysAsync(Azure.ResourceManager.FluidRelay.Models.RegenerateKeyContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FluidRelay.FluidRelayServerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FluidRelay.FluidRelayServerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FluidRelay.FluidRelayServerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FluidRelay.FluidRelayServerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.FluidRelay.FluidRelayServerResource> Update(Azure.ResourceManager.FluidRelay.Models.FluidRelayServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FluidRelay.FluidRelayServerResource>> UpdateAsync(Azure.ResourceManager.FluidRelay.Models.FluidRelayServerPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.FluidRelay.Mocking
{
    public partial class MockableFluidRelayArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableFluidRelayArmClient() { }
        public virtual Azure.ResourceManager.FluidRelay.FluidRelayContainerResource GetFluidRelayContainerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.FluidRelay.FluidRelayServerResource GetFluidRelayServerResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableFluidRelayResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableFluidRelayResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.FluidRelay.FluidRelayServerResource> GetFluidRelayServer(string fluidRelayServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.FluidRelay.FluidRelayServerResource>> GetFluidRelayServerAsync(string fluidRelayServerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.FluidRelay.FluidRelayServerCollection GetFluidRelayServers() { throw null; }
    }
    public partial class MockableFluidRelaySubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableFluidRelaySubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.FluidRelay.FluidRelayServerResource> GetFluidRelayServers(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.FluidRelay.FluidRelayServerResource> GetFluidRelayServersAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.FluidRelay.Models
{
    public static partial class ArmFluidRelayModelFactory
    {
        public static Azure.ResourceManager.FluidRelay.FluidRelayContainerData FluidRelayContainerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Guid? frsTenantId = default(System.Guid?), System.Guid? frsContainerId = default(System.Guid?), Azure.ResourceManager.FluidRelay.Models.FluidRelayProvisioningState? provisioningState = default(Azure.ResourceManager.FluidRelay.Models.FluidRelayProvisioningState?), System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastAccessOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.FluidRelay.Models.FluidRelayEndpoints FluidRelayEndpoints(System.Collections.Generic.IEnumerable<string> ordererEndpoints = null, System.Collections.Generic.IEnumerable<string> storageEndpoints = null, System.Collections.Generic.IEnumerable<string> serviceEndpoints = null) { throw null; }
        public static Azure.ResourceManager.FluidRelay.FluidRelayServerData FluidRelayServerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Guid? frsTenantId = default(System.Guid?), Azure.ResourceManager.FluidRelay.Models.FluidRelayEndpoints fluidRelayEndpoints = null, Azure.ResourceManager.FluidRelay.Models.FluidRelayProvisioningState? provisioningState = default(Azure.ResourceManager.FluidRelay.Models.FluidRelayProvisioningState?), Azure.ResourceManager.FluidRelay.Models.CmkEncryptionProperties customerManagedKeyEncryption = null, Azure.ResourceManager.FluidRelay.Models.FluidRelayStorageSku? storageSku = default(Azure.ResourceManager.FluidRelay.Models.FluidRelayStorageSku?)) { throw null; }
        public static Azure.ResourceManager.FluidRelay.Models.FluidRelayServerKeys FluidRelayServerKeys(string primaryKey = null, string secondaryKey = null) { throw null; }
    }
    public partial class CmkEncryptionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FluidRelay.Models.CmkEncryptionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.Models.CmkEncryptionProperties>
    {
        public CmkEncryptionProperties() { }
        public Azure.ResourceManager.FluidRelay.Models.CmkIdentity KeyEncryptionKeyIdentity { get { throw null; } set { } }
        public System.Uri KeyEncryptionKeyUri { get { throw null; } set { } }
        Azure.ResourceManager.FluidRelay.Models.CmkEncryptionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FluidRelay.Models.CmkEncryptionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FluidRelay.Models.CmkEncryptionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FluidRelay.Models.CmkEncryptionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.Models.CmkEncryptionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.Models.CmkEncryptionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.Models.CmkEncryptionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CmkIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FluidRelay.Models.CmkIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.Models.CmkIdentity>
    {
        public CmkIdentity() { }
        public Azure.ResourceManager.FluidRelay.Models.CmkIdentityType? IdentityType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentityResourceId { get { throw null; } set { } }
        Azure.ResourceManager.FluidRelay.Models.CmkIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FluidRelay.Models.CmkIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FluidRelay.Models.CmkIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FluidRelay.Models.CmkIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.Models.CmkIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.Models.CmkIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.Models.CmkIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum CmkIdentityType
    {
        SystemAssigned = 0,
        UserAssigned = 1,
    }
    public partial class FluidRelayEndpoints : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FluidRelay.Models.FluidRelayEndpoints>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.Models.FluidRelayEndpoints>
    {
        internal FluidRelayEndpoints() { }
        public System.Collections.Generic.IReadOnlyList<string> OrdererEndpoints { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ServiceEndpoints { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> StorageEndpoints { get { throw null; } }
        Azure.ResourceManager.FluidRelay.Models.FluidRelayEndpoints System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FluidRelay.Models.FluidRelayEndpoints>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FluidRelay.Models.FluidRelayEndpoints>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FluidRelay.Models.FluidRelayEndpoints System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.Models.FluidRelayEndpoints>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.Models.FluidRelayEndpoints>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.Models.FluidRelayEndpoints>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum FluidRelayKeyName
    {
        PrimaryKey = 0,
        SecondaryKey = 1,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FluidRelayProvisioningState : System.IEquatable<Azure.ResourceManager.FluidRelay.Models.FluidRelayProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FluidRelayProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.FluidRelay.Models.FluidRelayProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.FluidRelay.Models.FluidRelayProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.FluidRelay.Models.FluidRelayProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FluidRelay.Models.FluidRelayProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FluidRelay.Models.FluidRelayProvisioningState left, Azure.ResourceManager.FluidRelay.Models.FluidRelayProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.FluidRelay.Models.FluidRelayProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FluidRelay.Models.FluidRelayProvisioningState left, Azure.ResourceManager.FluidRelay.Models.FluidRelayProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FluidRelayServerKeys : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FluidRelay.Models.FluidRelayServerKeys>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.Models.FluidRelayServerKeys>
    {
        internal FluidRelayServerKeys() { }
        public string PrimaryKey { get { throw null; } }
        public string SecondaryKey { get { throw null; } }
        Azure.ResourceManager.FluidRelay.Models.FluidRelayServerKeys System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FluidRelay.Models.FluidRelayServerKeys>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FluidRelay.Models.FluidRelayServerKeys>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FluidRelay.Models.FluidRelayServerKeys System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.Models.FluidRelayServerKeys>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.Models.FluidRelayServerKeys>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.Models.FluidRelayServerKeys>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FluidRelayServerPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FluidRelay.Models.FluidRelayServerPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.Models.FluidRelayServerPatch>
    {
        public FluidRelayServerPatch() { }
        public Azure.ResourceManager.FluidRelay.Models.CmkEncryptionProperties CustomerManagedKeyEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.FluidRelay.Models.FluidRelayServerPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FluidRelay.Models.FluidRelayServerPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FluidRelay.Models.FluidRelayServerPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FluidRelay.Models.FluidRelayServerPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.Models.FluidRelayServerPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.Models.FluidRelayServerPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.Models.FluidRelayServerPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FluidRelayStorageSku : System.IEquatable<Azure.ResourceManager.FluidRelay.Models.FluidRelayStorageSku>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FluidRelayStorageSku(string value) { throw null; }
        public static Azure.ResourceManager.FluidRelay.Models.FluidRelayStorageSku Basic { get { throw null; } }
        public static Azure.ResourceManager.FluidRelay.Models.FluidRelayStorageSku Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.FluidRelay.Models.FluidRelayStorageSku other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.FluidRelay.Models.FluidRelayStorageSku left, Azure.ResourceManager.FluidRelay.Models.FluidRelayStorageSku right) { throw null; }
        public static implicit operator Azure.ResourceManager.FluidRelay.Models.FluidRelayStorageSku (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.FluidRelay.Models.FluidRelayStorageSku left, Azure.ResourceManager.FluidRelay.Models.FluidRelayStorageSku right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RegenerateKeyContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FluidRelay.Models.RegenerateKeyContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.Models.RegenerateKeyContent>
    {
        public RegenerateKeyContent(Azure.ResourceManager.FluidRelay.Models.FluidRelayKeyName keyName) { }
        public Azure.ResourceManager.FluidRelay.Models.FluidRelayKeyName KeyName { get { throw null; } }
        Azure.ResourceManager.FluidRelay.Models.RegenerateKeyContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FluidRelay.Models.RegenerateKeyContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.FluidRelay.Models.RegenerateKeyContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.FluidRelay.Models.RegenerateKeyContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.Models.RegenerateKeyContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.Models.RegenerateKeyContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.FluidRelay.Models.RegenerateKeyContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
