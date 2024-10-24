namespace Azure.ResourceManager.Disk
{
    public partial class DiskAccessCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Disk.DiskAccessResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Disk.DiskAccessResource>, System.Collections.IEnumerable
    {
        protected DiskAccessCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Disk.DiskAccessResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string diskAccessName, Azure.ResourceManager.Disk.DiskAccessData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Disk.DiskAccessResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string diskAccessName, Azure.ResourceManager.Disk.DiskAccessData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string diskAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string diskAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Disk.DiskAccessResource> Get(string diskAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Disk.DiskAccessResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Disk.DiskAccessResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.DiskAccessResource>> GetAsync(string diskAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Disk.DiskAccessResource> GetIfExists(string diskAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Disk.DiskAccessResource>> GetIfExistsAsync(string diskAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Disk.DiskAccessResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Disk.DiskAccessResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Disk.DiskAccessResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Disk.DiskAccessResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiskAccessData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.DiskAccessData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskAccessData>
    {
        public DiskAccessData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        Azure.ResourceManager.Disk.DiskAccessData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.DiskAccessData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.DiskAccessData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.DiskAccessData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskAccessData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskAccessData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskAccessData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskAccessResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.DiskAccessData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskAccessData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiskAccessResource() { }
        public virtual Azure.ResourceManager.Disk.DiskAccessData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Disk.DiskAccessResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.DiskAccessResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string diskAccessName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Disk.DiskAccessResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.DiskAccessResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionResource> GetDiskPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionResource>> GetDiskPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionCollection GetDiskPrivateEndpointConnections() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Disk.Models.ComputePrivateLinkResourceData> GetPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Disk.Models.ComputePrivateLinkResourceData> GetPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Disk.DiskAccessResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.DiskAccessResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Disk.DiskAccessResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.DiskAccessResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Disk.DiskAccessData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.DiskAccessData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.DiskAccessData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.DiskAccessData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskAccessData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskAccessData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskAccessData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Disk.DiskAccessResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Disk.Models.DiskAccessPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Disk.DiskAccessResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Disk.Models.DiskAccessPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskEncryptionSetCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Disk.DiskEncryptionSetResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Disk.DiskEncryptionSetResource>, System.Collections.IEnumerable
    {
        protected DiskEncryptionSetCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Disk.DiskEncryptionSetResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string diskEncryptionSetName, Azure.ResourceManager.Disk.DiskEncryptionSetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Disk.DiskEncryptionSetResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string diskEncryptionSetName, Azure.ResourceManager.Disk.DiskEncryptionSetData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string diskEncryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string diskEncryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Disk.DiskEncryptionSetResource> Get(string diskEncryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Disk.DiskEncryptionSetResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Disk.DiskEncryptionSetResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.DiskEncryptionSetResource>> GetAsync(string diskEncryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Disk.DiskEncryptionSetResource> GetIfExists(string diskEncryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Disk.DiskEncryptionSetResource>> GetIfExistsAsync(string diskEncryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Disk.DiskEncryptionSetResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Disk.DiskEncryptionSetResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Disk.DiskEncryptionSetResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Disk.DiskEncryptionSetResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiskEncryptionSetData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.DiskEncryptionSetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskEncryptionSetData>
    {
        public DiskEncryptionSetData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Disk.Models.KeyForDiskEncryptionSet ActiveKey { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.DiskApiError AutoKeyRotationError { get { throw null; } }
        public Azure.ResourceManager.Disk.Models.DiskEncryptionSetType? EncryptionType { get { throw null; } set { } }
        public string FederatedClientId { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.DateTimeOffset? LastKeyRotationTimestamp { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Disk.Models.KeyForDiskEncryptionSet> PreviousKeys { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public bool? RotationToLatestKeyVersionEnabled { get { throw null; } set { } }
        Azure.ResourceManager.Disk.DiskEncryptionSetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.DiskEncryptionSetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.DiskEncryptionSetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.DiskEncryptionSetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskEncryptionSetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskEncryptionSetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskEncryptionSetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskEncryptionSetResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.DiskEncryptionSetData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskEncryptionSetData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiskEncryptionSetResource() { }
        public virtual Azure.ResourceManager.Disk.DiskEncryptionSetData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Disk.DiskEncryptionSetResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.DiskEncryptionSetResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string diskEncryptionSetName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Disk.DiskEncryptionSetResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<string> GetAssociatedResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<string> GetAssociatedResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.DiskEncryptionSetResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Disk.DiskEncryptionSetResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.DiskEncryptionSetResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Disk.DiskEncryptionSetResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.DiskEncryptionSetResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Disk.DiskEncryptionSetData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.DiskEncryptionSetData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.DiskEncryptionSetData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.DiskEncryptionSetData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskEncryptionSetData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskEncryptionSetData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskEncryptionSetData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Disk.DiskEncryptionSetResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Disk.Models.DiskEncryptionSetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Disk.DiskEncryptionSetResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Disk.Models.DiskEncryptionSetPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DiskExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Disk.DiskAccessResource> GetDiskAccess(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string diskAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.DiskAccessResource>> GetDiskAccessAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string diskAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Disk.DiskAccessCollection GetDiskAccesses(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Disk.DiskAccessResource> GetDiskAccesses(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Disk.DiskAccessResource> GetDiskAccessesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Disk.DiskAccessResource GetDiskAccessResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Disk.DiskEncryptionSetResource> GetDiskEncryptionSet(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string diskEncryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.DiskEncryptionSetResource>> GetDiskEncryptionSetAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string diskEncryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Disk.DiskEncryptionSetResource GetDiskEncryptionSetResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Disk.DiskEncryptionSetCollection GetDiskEncryptionSets(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Disk.DiskEncryptionSetResource> GetDiskEncryptionSets(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Disk.DiskEncryptionSetResource> GetDiskEncryptionSetsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionResource GetDiskPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Disk.DiskRestorePointResource> GetDiskRestorePoint(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string restorePointGroupName, string vmRestorePointName, string diskRestorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.DiskRestorePointResource>> GetDiskRestorePointAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string restorePointGroupName, string vmRestorePointName, string diskRestorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Disk.DiskRestorePointResource GetDiskRestorePointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Disk.DiskRestorePointCollection GetDiskRestorePoints(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string restorePointGroupName, string vmRestorePointName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Disk.ManagedDiskResource> GetManagedDisk(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string diskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.ManagedDiskResource>> GetManagedDiskAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string diskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Disk.ManagedDiskResource GetManagedDiskResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Disk.ManagedDiskCollection GetManagedDisks(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Disk.ManagedDiskResource> GetManagedDisks(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Disk.ManagedDiskResource> GetManagedDisksAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Disk.SnapshotResource> GetSnapshot(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.SnapshotResource>> GetSnapshotAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Disk.SnapshotResource GetSnapshotResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Disk.SnapshotCollection GetSnapshots(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Disk.SnapshotResource> GetSnapshots(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Disk.SnapshotResource> GetSnapshotsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected DiskPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiskPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionData>
    {
        public DiskPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Disk.Models.DiskPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Disk.Models.DiskPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiskPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string diskAccessName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DiskRestorePointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Disk.DiskRestorePointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Disk.DiskRestorePointResource>, System.Collections.IEnumerable
    {
        protected DiskRestorePointCollection() { }
        public virtual Azure.Response<bool> Exists(string diskRestorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string diskRestorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Disk.DiskRestorePointResource> Get(string diskRestorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Disk.DiskRestorePointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Disk.DiskRestorePointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.DiskRestorePointResource>> GetAsync(string diskRestorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Disk.DiskRestorePointResource> GetIfExists(string diskRestorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Disk.DiskRestorePointResource>> GetIfExistsAsync(string diskRestorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Disk.DiskRestorePointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Disk.DiskRestorePointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Disk.DiskRestorePointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Disk.DiskRestorePointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DiskRestorePointData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.DiskRestorePointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskRestorePointData>
    {
        internal DiskRestorePointData() { }
        public float? CompletionPercent { get { throw null; } }
        public Azure.Core.ResourceIdentifier DiskAccessId { get { throw null; } }
        public Azure.ResourceManager.Disk.Models.DiskEncryption Encryption { get { throw null; } }
        public string FamilyId { get { throw null; } }
        public Azure.ResourceManager.Disk.Models.HyperVGeneration? HyperVGeneration { get { throw null; } }
        public int? LogicalSectorSize { get { throw null; } }
        public Azure.ResourceManager.Disk.Models.NetworkAccessPolicy? NetworkAccessPolicy { get { throw null; } }
        public Azure.ResourceManager.Disk.Models.SupportedOperatingSystemType? OSType { get { throw null; } }
        public Azure.ResourceManager.Disk.Models.DiskPublicNetworkAccess? PublicNetworkAccess { get { throw null; } }
        public Azure.ResourceManager.Disk.Models.DiskPurchasePlan PurchasePlan { get { throw null; } }
        public string ReplicationState { get { throw null; } }
        public Azure.ResourceManager.Disk.Models.DiskSecurityProfile SecurityProfile { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } }
        public Azure.Core.AzureLocation? SourceResourceLocation { get { throw null; } }
        public string SourceUniqueId { get { throw null; } }
        public Azure.ResourceManager.Disk.Models.SupportedCapabilities SupportedCapabilities { get { throw null; } }
        public bool? SupportsHibernation { get { throw null; } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        Azure.ResourceManager.Disk.DiskRestorePointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.DiskRestorePointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.DiskRestorePointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.DiskRestorePointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskRestorePointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskRestorePointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskRestorePointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskRestorePointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.DiskRestorePointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskRestorePointData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DiskRestorePointResource() { }
        public virtual Azure.ResourceManager.Disk.DiskRestorePointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string restorePointGroupName, string vmRestorePointName, string diskRestorePointName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Disk.DiskRestorePointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.DiskRestorePointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Disk.Models.AccessUri> GrantAccess(Azure.WaitUntil waitUntil, Azure.ResourceManager.Disk.Models.GrantAccessData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Disk.Models.AccessUri>> GrantAccessAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Disk.Models.GrantAccessData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RevokeAccess(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RevokeAccessAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Disk.DiskRestorePointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.DiskRestorePointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.DiskRestorePointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.DiskRestorePointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskRestorePointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskRestorePointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.DiskRestorePointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedDiskCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Disk.ManagedDiskResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Disk.ManagedDiskResource>, System.Collections.IEnumerable
    {
        protected ManagedDiskCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Disk.ManagedDiskResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string diskName, Azure.ResourceManager.Disk.ManagedDiskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Disk.ManagedDiskResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string diskName, Azure.ResourceManager.Disk.ManagedDiskData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string diskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string diskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Disk.ManagedDiskResource> Get(string diskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Disk.ManagedDiskResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Disk.ManagedDiskResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.ManagedDiskResource>> GetAsync(string diskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Disk.ManagedDiskResource> GetIfExists(string diskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Disk.ManagedDiskResource>> GetIfExistsAsync(string diskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Disk.ManagedDiskResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Disk.ManagedDiskResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Disk.ManagedDiskResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Disk.ManagedDiskResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedDiskData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.ManagedDiskData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.ManagedDiskData>
    {
        public ManagedDiskData(Azure.Core.AzureLocation location) { }
        public bool? BurstingEnabled { get { throw null; } set { } }
        public System.DateTimeOffset? BurstingEnabledOn { get { throw null; } }
        public float? CompletionPercent { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.DiskCreationData CreationData { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.DataAccessAuthMode? DataAccessAuthMode { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DiskAccessId { get { throw null; } set { } }
        public long? DiskIopsReadOnly { get { throw null; } set { } }
        public long? DiskIopsReadWrite { get { throw null; } set { } }
        public long? DiskMBpsReadOnly { get { throw null; } set { } }
        public long? DiskMBpsReadWrite { get { throw null; } set { } }
        public long? DiskSizeBytes { get { throw null; } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.DiskState? DiskState { get { throw null; } }
        public Azure.ResourceManager.Disk.Models.DiskEncryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.EncryptionSettingsGroup EncryptionSettingsGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.HyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public bool? IsOptimizedForFrequentAttach { get { throw null; } set { } }
        public System.DateTimeOffset? LastOwnershipUpdateOn { get { throw null; } }
        public Azure.Core.ResourceIdentifier ManagedBy { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> ManagedByExtended { get { throw null; } }
        public int? MaxShares { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.NetworkAccessPolicy? NetworkAccessPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.SupportedOperatingSystemType? OSType { get { throw null; } set { } }
        public string PropertyUpdatesInProgressTargetTier { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Disk.Models.DiskPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.DiskPurchasePlan PurchasePlan { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.DiskSecurityProfile SecurityProfile { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Disk.Models.ShareInfoElement> ShareInfo { get { throw null; } }
        public Azure.ResourceManager.Disk.Models.DiskSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.SupportedCapabilities SupportedCapabilities { get { throw null; } set { } }
        public bool? SupportsHibernation { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public string UniqueId { get { throw null; } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        Azure.ResourceManager.Disk.ManagedDiskData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.ManagedDiskData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.ManagedDiskData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.ManagedDiskData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.ManagedDiskData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.ManagedDiskData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.ManagedDiskData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedDiskResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.ManagedDiskData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.ManagedDiskData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedDiskResource() { }
        public virtual Azure.ResourceManager.Disk.ManagedDiskData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Disk.ManagedDiskResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.ManagedDiskResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string diskName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Disk.ManagedDiskResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.ManagedDiskResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Disk.Models.AccessUri> GrantAccess(Azure.WaitUntil waitUntil, Azure.ResourceManager.Disk.Models.GrantAccessData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Disk.Models.AccessUri>> GrantAccessAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Disk.Models.GrantAccessData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Disk.ManagedDiskResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.ManagedDiskResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RevokeAccess(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RevokeAccessAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Disk.ManagedDiskResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.ManagedDiskResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Disk.ManagedDiskData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.ManagedDiskData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.ManagedDiskData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.ManagedDiskData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.ManagedDiskData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.ManagedDiskData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.ManagedDiskData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Disk.ManagedDiskResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Disk.Models.ManagedDiskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Disk.ManagedDiskResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Disk.Models.ManagedDiskPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SnapshotCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Disk.SnapshotResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Disk.SnapshotResource>, System.Collections.IEnumerable
    {
        protected SnapshotCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Disk.SnapshotResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string snapshotName, Azure.ResourceManager.Disk.SnapshotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Disk.SnapshotResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string snapshotName, Azure.ResourceManager.Disk.SnapshotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Disk.SnapshotResource> Get(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Disk.SnapshotResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Disk.SnapshotResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.SnapshotResource>> GetAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Disk.SnapshotResource> GetIfExists(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Disk.SnapshotResource>> GetIfExistsAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Disk.SnapshotResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Disk.SnapshotResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Disk.SnapshotResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Disk.SnapshotResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SnapshotData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.SnapshotData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.SnapshotData>
    {
        public SnapshotData(Azure.Core.AzureLocation location) { }
        public float? CompletionPercent { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.CopyCompletionError CopyCompletionError { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.DiskCreationData CreationData { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.DataAccessAuthMode? DataAccessAuthMode { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DiskAccessId { get { throw null; } set { } }
        public long? DiskSizeBytes { get { throw null; } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.DiskState? DiskState { get { throw null; } }
        public Azure.ResourceManager.Disk.Models.DiskEncryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.EncryptionSettingsGroup EncryptionSettingsGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.HyperVGeneration? HyperVGeneration { get { throw null; } set { } }
        public bool? Incremental { get { throw null; } set { } }
        public string IncrementalSnapshotFamilyId { get { throw null; } }
        public string ManagedBy { get { throw null; } }
        public Azure.ResourceManager.Disk.Models.NetworkAccessPolicy? NetworkAccessPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.SupportedOperatingSystemType? OSType { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Disk.Models.DiskPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.DiskPurchasePlan PurchasePlan { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.DiskSecurityProfile SecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.SnapshotSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.SupportedCapabilities SupportedCapabilities { get { throw null; } set { } }
        public bool? SupportsHibernation { get { throw null; } set { } }
        public System.DateTimeOffset? TimeCreated { get { throw null; } }
        public string UniqueId { get { throw null; } }
        Azure.ResourceManager.Disk.SnapshotData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.SnapshotData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.SnapshotData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.SnapshotData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.SnapshotData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.SnapshotData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.SnapshotData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SnapshotResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.SnapshotData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.SnapshotData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SnapshotResource() { }
        public virtual Azure.ResourceManager.Disk.SnapshotData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Disk.SnapshotResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.SnapshotResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string snapshotName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Disk.SnapshotResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.SnapshotResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Disk.Models.AccessUri> GrantAccess(Azure.WaitUntil waitUntil, Azure.ResourceManager.Disk.Models.GrantAccessData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Disk.Models.AccessUri>> GrantAccessAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Disk.Models.GrantAccessData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Disk.SnapshotResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.SnapshotResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RevokeAccess(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RevokeAccessAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Disk.SnapshotResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.SnapshotResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Disk.SnapshotData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.SnapshotData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.SnapshotData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.SnapshotData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.SnapshotData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.SnapshotData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.SnapshotData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Disk.SnapshotResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Disk.Models.SnapshotPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Disk.SnapshotResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Disk.Models.SnapshotPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Disk.Mocking
{
    public partial class MockableDiskArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDiskArmClient() { }
        public virtual Azure.ResourceManager.Disk.DiskAccessResource GetDiskAccessResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Disk.DiskEncryptionSetResource GetDiskEncryptionSetResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionResource GetDiskPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Disk.DiskRestorePointResource GetDiskRestorePointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Disk.ManagedDiskResource GetManagedDiskResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Disk.SnapshotResource GetSnapshotResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDiskResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDiskResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Disk.DiskAccessResource> GetDiskAccess(string diskAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.DiskAccessResource>> GetDiskAccessAsync(string diskAccessName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Disk.DiskAccessCollection GetDiskAccesses() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Disk.DiskEncryptionSetResource> GetDiskEncryptionSet(string diskEncryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.DiskEncryptionSetResource>> GetDiskEncryptionSetAsync(string diskEncryptionSetName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Disk.DiskEncryptionSetCollection GetDiskEncryptionSets() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Disk.DiskRestorePointResource> GetDiskRestorePoint(string restorePointGroupName, string vmRestorePointName, string diskRestorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.DiskRestorePointResource>> GetDiskRestorePointAsync(string restorePointGroupName, string vmRestorePointName, string diskRestorePointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Disk.DiskRestorePointCollection GetDiskRestorePoints(string restorePointGroupName, string vmRestorePointName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Disk.ManagedDiskResource> GetManagedDisk(string diskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.ManagedDiskResource>> GetManagedDiskAsync(string diskName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Disk.ManagedDiskCollection GetManagedDisks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Disk.SnapshotResource> GetSnapshot(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Disk.SnapshotResource>> GetSnapshotAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Disk.SnapshotCollection GetSnapshots() { throw null; }
    }
    public partial class MockableDiskSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDiskSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Disk.DiskAccessResource> GetDiskAccesses(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Disk.DiskAccessResource> GetDiskAccessesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Disk.DiskEncryptionSetResource> GetDiskEncryptionSets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Disk.DiskEncryptionSetResource> GetDiskEncryptionSetsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Disk.ManagedDiskResource> GetManagedDisks(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Disk.ManagedDiskResource> GetManagedDisksAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Disk.SnapshotResource> GetSnapshots(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Disk.SnapshotResource> GetSnapshotsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Disk.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AccessLevel : System.IEquatable<Azure.ResourceManager.Disk.Models.AccessLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AccessLevel(string value) { throw null; }
        public static Azure.ResourceManager.Disk.Models.AccessLevel None { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.AccessLevel Read { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.AccessLevel Write { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Disk.Models.AccessLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Disk.Models.AccessLevel left, Azure.ResourceManager.Disk.Models.AccessLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.Disk.Models.AccessLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Disk.Models.AccessLevel left, Azure.ResourceManager.Disk.Models.AccessLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AccessUri : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.AccessUri>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.AccessUri>
    {
        internal AccessUri() { }
        public string AccessSas { get { throw null; } }
        public string SecurityDataAccessSas { get { throw null; } }
        Azure.ResourceManager.Disk.Models.AccessUri System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.AccessUri>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.AccessUri>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.Models.AccessUri System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.AccessUri>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.AccessUri>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.AccessUri>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ArchitectureType : System.IEquatable<Azure.ResourceManager.Disk.Models.ArchitectureType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ArchitectureType(string value) { throw null; }
        public static Azure.ResourceManager.Disk.Models.ArchitectureType Arm64 { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.ArchitectureType X64 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Disk.Models.ArchitectureType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Disk.Models.ArchitectureType left, Azure.ResourceManager.Disk.Models.ArchitectureType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Disk.Models.ArchitectureType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Disk.Models.ArchitectureType left, Azure.ResourceManager.Disk.Models.ArchitectureType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmDiskModelFactory
    {
        public static Azure.ResourceManager.Disk.Models.AccessUri AccessUri(string accessSas = null, string securityDataAccessSas = null) { throw null; }
        public static Azure.ResourceManager.Disk.Models.ComputePrivateLinkResourceData ComputePrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.Disk.DiskAccessData DiskAccessData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionData> privateEndpointConnections = null, string provisioningState = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Disk.Models.DiskApiError DiskApiError(System.Collections.Generic.IEnumerable<Azure.ResourceManager.Disk.Models.DiskApiErrorBase> details = null, Azure.ResourceManager.Disk.Models.InnerError innererror = null, string code = null, string target = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Disk.Models.DiskApiErrorBase DiskApiErrorBase(string code = null, string target = null, string message = null) { throw null; }
        public static Azure.ResourceManager.Disk.Models.DiskCreationData DiskCreationData(Azure.ResourceManager.Disk.Models.DiskCreateOption createOption = default(Azure.ResourceManager.Disk.Models.DiskCreateOption), Azure.Core.ResourceIdentifier storageAccountId = null, Azure.ResourceManager.Disk.Models.ImageDiskReference imageReference = null, Azure.ResourceManager.Disk.Models.ImageDiskReference galleryImageReference = null, System.Uri sourceUri = null, Azure.Core.ResourceIdentifier sourceResourceId = null, string sourceUniqueId = null, long? uploadSizeBytes = default(long?), int? logicalSectorSize = default(int?), System.Uri securityDataUri = null, bool? isPerformancePlusEnabled = default(bool?), Azure.Core.ResourceIdentifier elasticSanResourceId = null, Azure.ResourceManager.Disk.Models.ProvisionedBandwidthCopyOption? provisionedBandwidthCopySpeed = default(Azure.ResourceManager.Disk.Models.ProvisionedBandwidthCopyOption?)) { throw null; }
        public static Azure.ResourceManager.Disk.DiskEncryptionSetData DiskEncryptionSetData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.Disk.Models.DiskEncryptionSetType? encryptionType = default(Azure.ResourceManager.Disk.Models.DiskEncryptionSetType?), Azure.ResourceManager.Disk.Models.KeyForDiskEncryptionSet activeKey = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Disk.Models.KeyForDiskEncryptionSet> previousKeys = null, string provisioningState = null, bool? rotationToLatestKeyVersionEnabled = default(bool?), System.DateTimeOffset? lastKeyRotationTimestamp = default(System.DateTimeOffset?), Azure.ResourceManager.Disk.Models.DiskApiError autoKeyRotationError = null, string federatedClientId = null) { throw null; }
        public static Azure.ResourceManager.Disk.DiskPrivateEndpointConnectionData DiskPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.Disk.Models.DiskPrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.Disk.Models.DiskPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.Disk.Models.DiskPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Disk.DiskRestorePointData DiskRestorePointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?), Azure.Core.ResourceIdentifier sourceResourceId = null, Azure.ResourceManager.Disk.Models.SupportedOperatingSystemType? osType = default(Azure.ResourceManager.Disk.Models.SupportedOperatingSystemType?), Azure.ResourceManager.Disk.Models.HyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.Disk.Models.HyperVGeneration?), Azure.ResourceManager.Disk.Models.DiskPurchasePlan purchasePlan = null, Azure.ResourceManager.Disk.Models.SupportedCapabilities supportedCapabilities = null, string familyId = null, string sourceUniqueId = null, Azure.ResourceManager.Disk.Models.DiskEncryption encryption = null, bool? supportsHibernation = default(bool?), Azure.ResourceManager.Disk.Models.NetworkAccessPolicy? networkAccessPolicy = default(Azure.ResourceManager.Disk.Models.NetworkAccessPolicy?), Azure.ResourceManager.Disk.Models.DiskPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Disk.Models.DiskPublicNetworkAccess?), Azure.Core.ResourceIdentifier diskAccessId = null, float? completionPercent = default(float?), string replicationState = null, Azure.Core.AzureLocation? sourceResourceLocation = default(Azure.Core.AzureLocation?), Azure.ResourceManager.Disk.Models.DiskSecurityProfile securityProfile = null, int? logicalSectorSize = default(int?)) { throw null; }
        public static Azure.ResourceManager.Disk.Models.DiskSku DiskSku(Azure.ResourceManager.Disk.Models.DiskStorageAccountType? name = default(Azure.ResourceManager.Disk.Models.DiskStorageAccountType?), string tier = null) { throw null; }
        public static Azure.ResourceManager.Disk.Models.GrantAccessData GrantAccessData(Azure.ResourceManager.Disk.Models.AccessLevel access = default(Azure.ResourceManager.Disk.Models.AccessLevel), int durationInSeconds = 0, bool? getSecureVmGuestStateSas = default(bool?), Azure.ResourceManager.Disk.Models.DiskImageFileFormat? fileFormat = default(Azure.ResourceManager.Disk.Models.DiskImageFileFormat?)) { throw null; }
        public static Azure.ResourceManager.Disk.Models.InnerError InnerError(string exceptiontype = null, string errordetail = null) { throw null; }
        public static Azure.ResourceManager.Disk.ManagedDiskData ManagedDiskData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.Core.ResourceIdentifier managedBy = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> managedByExtended = null, Azure.ResourceManager.Disk.Models.DiskSku sku = null, System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?), Azure.ResourceManager.Disk.Models.SupportedOperatingSystemType? osType = default(Azure.ResourceManager.Disk.Models.SupportedOperatingSystemType?), Azure.ResourceManager.Disk.Models.HyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.Disk.Models.HyperVGeneration?), Azure.ResourceManager.Disk.Models.DiskPurchasePlan purchasePlan = null, Azure.ResourceManager.Disk.Models.SupportedCapabilities supportedCapabilities = null, Azure.ResourceManager.Disk.Models.DiskCreationData creationData = null, int? diskSizeGB = default(int?), long? diskSizeBytes = default(long?), string uniqueId = null, Azure.ResourceManager.Disk.Models.EncryptionSettingsGroup encryptionSettingsGroup = null, string provisioningState = null, long? diskIopsReadWrite = default(long?), long? diskMBpsReadWrite = default(long?), long? diskIopsReadOnly = default(long?), long? diskMBpsReadOnly = default(long?), Azure.ResourceManager.Disk.Models.DiskState? diskState = default(Azure.ResourceManager.Disk.Models.DiskState?), Azure.ResourceManager.Disk.Models.DiskEncryption encryption = null, int? maxShares = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Disk.Models.ShareInfoElement> shareInfo = null, Azure.ResourceManager.Disk.Models.NetworkAccessPolicy? networkAccessPolicy = default(Azure.ResourceManager.Disk.Models.NetworkAccessPolicy?), Azure.Core.ResourceIdentifier diskAccessId = null, System.DateTimeOffset? burstingEnabledOn = default(System.DateTimeOffset?), string tier = null, bool? burstingEnabled = default(bool?), string propertyUpdatesInProgressTargetTier = null, bool? supportsHibernation = default(bool?), Azure.ResourceManager.Disk.Models.DiskSecurityProfile securityProfile = null, float? completionPercent = default(float?), Azure.ResourceManager.Disk.Models.DiskPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Disk.Models.DiskPublicNetworkAccess?), Azure.ResourceManager.Disk.Models.DataAccessAuthMode? dataAccessAuthMode = default(Azure.ResourceManager.Disk.Models.DataAccessAuthMode?), bool? isOptimizedForFrequentAttach = default(bool?), System.DateTimeOffset? lastOwnershipUpdateOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Disk.Models.ManagedDiskPatch ManagedDiskPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Disk.Models.DiskSku sku = null, Azure.ResourceManager.Disk.Models.SupportedOperatingSystemType? osType = default(Azure.ResourceManager.Disk.Models.SupportedOperatingSystemType?), int? diskSizeGB = default(int?), Azure.ResourceManager.Disk.Models.EncryptionSettingsGroup encryptionSettingsGroup = null, long? diskIopsReadWrite = default(long?), long? diskMBpsReadWrite = default(long?), long? diskIopsReadOnly = default(long?), long? diskMBpsReadOnly = default(long?), int? maxShares = default(int?), Azure.ResourceManager.Disk.Models.DiskEncryption encryption = null, Azure.ResourceManager.Disk.Models.NetworkAccessPolicy? networkAccessPolicy = default(Azure.ResourceManager.Disk.Models.NetworkAccessPolicy?), Azure.Core.ResourceIdentifier diskAccessId = null, string tier = null, bool? burstingEnabled = default(bool?), Azure.ResourceManager.Disk.Models.DiskPurchasePlan purchasePlan = null, Azure.ResourceManager.Disk.Models.SupportedCapabilities supportedCapabilities = null, string propertyUpdatesInProgressTargetTier = null, bool? supportsHibernation = default(bool?), Azure.ResourceManager.Disk.Models.DiskPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Disk.Models.DiskPublicNetworkAccess?), Azure.ResourceManager.Disk.Models.DataAccessAuthMode? dataAccessAuthMode = default(Azure.ResourceManager.Disk.Models.DataAccessAuthMode?), bool? isOptimizedForFrequentAttach = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Disk.Models.ShareInfoElement ShareInfoElement(System.Uri vmUri = null) { throw null; }
        public static Azure.ResourceManager.Disk.SnapshotData SnapshotData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string managedBy = null, Azure.ResourceManager.Disk.Models.SnapshotSku sku = null, Azure.ResourceManager.Resources.Models.ExtendedLocation extendedLocation = null, System.DateTimeOffset? timeCreated = default(System.DateTimeOffset?), Azure.ResourceManager.Disk.Models.SupportedOperatingSystemType? osType = default(Azure.ResourceManager.Disk.Models.SupportedOperatingSystemType?), Azure.ResourceManager.Disk.Models.HyperVGeneration? hyperVGeneration = default(Azure.ResourceManager.Disk.Models.HyperVGeneration?), Azure.ResourceManager.Disk.Models.DiskPurchasePlan purchasePlan = null, Azure.ResourceManager.Disk.Models.SupportedCapabilities supportedCapabilities = null, Azure.ResourceManager.Disk.Models.DiskCreationData creationData = null, int? diskSizeGB = default(int?), long? diskSizeBytes = default(long?), Azure.ResourceManager.Disk.Models.DiskState? diskState = default(Azure.ResourceManager.Disk.Models.DiskState?), string uniqueId = null, Azure.ResourceManager.Disk.Models.EncryptionSettingsGroup encryptionSettingsGroup = null, string provisioningState = null, bool? incremental = default(bool?), string incrementalSnapshotFamilyId = null, Azure.ResourceManager.Disk.Models.DiskEncryption encryption = null, Azure.ResourceManager.Disk.Models.NetworkAccessPolicy? networkAccessPolicy = default(Azure.ResourceManager.Disk.Models.NetworkAccessPolicy?), Azure.Core.ResourceIdentifier diskAccessId = null, Azure.ResourceManager.Disk.Models.DiskSecurityProfile securityProfile = null, bool? supportsHibernation = default(bool?), Azure.ResourceManager.Disk.Models.DiskPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Disk.Models.DiskPublicNetworkAccess?), float? completionPercent = default(float?), Azure.ResourceManager.Disk.Models.CopyCompletionError copyCompletionError = null, Azure.ResourceManager.Disk.Models.DataAccessAuthMode? dataAccessAuthMode = default(Azure.ResourceManager.Disk.Models.DataAccessAuthMode?)) { throw null; }
        public static Azure.ResourceManager.Disk.Models.SnapshotSku SnapshotSku(Azure.ResourceManager.Disk.Models.SnapshotStorageAccountType? name = default(Azure.ResourceManager.Disk.Models.SnapshotStorageAccountType?), string tier = null) { throw null; }
    }
    public partial class ComputePrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.ComputePrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.ComputePrivateLinkResourceData>
    {
        internal ComputePrivateLinkResourceData() { }
        public Azure.Core.ResourceIdentifier GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
        Azure.ResourceManager.Disk.Models.ComputePrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.ComputePrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.ComputePrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.Models.ComputePrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.ComputePrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.ComputePrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.ComputePrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CopyCompletionError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.CopyCompletionError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.CopyCompletionError>
    {
        public CopyCompletionError(Azure.ResourceManager.Disk.Models.CopyCompletionErrorReason errorCode, string errorMessage) { }
        public Azure.ResourceManager.Disk.Models.CopyCompletionErrorReason ErrorCode { get { throw null; } set { } }
        public string ErrorMessage { get { throw null; } set { } }
        Azure.ResourceManager.Disk.Models.CopyCompletionError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.CopyCompletionError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.CopyCompletionError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.Models.CopyCompletionError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.CopyCompletionError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.CopyCompletionError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.CopyCompletionError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CopyCompletionErrorReason : System.IEquatable<Azure.ResourceManager.Disk.Models.CopyCompletionErrorReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CopyCompletionErrorReason(string value) { throw null; }
        public static Azure.ResourceManager.Disk.Models.CopyCompletionErrorReason CopySourceNotFound { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Disk.Models.CopyCompletionErrorReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Disk.Models.CopyCompletionErrorReason left, Azure.ResourceManager.Disk.Models.CopyCompletionErrorReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.Disk.Models.CopyCompletionErrorReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Disk.Models.CopyCompletionErrorReason left, Azure.ResourceManager.Disk.Models.CopyCompletionErrorReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataAccessAuthMode : System.IEquatable<Azure.ResourceManager.Disk.Models.DataAccessAuthMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataAccessAuthMode(string value) { throw null; }
        public static Azure.ResourceManager.Disk.Models.DataAccessAuthMode AzureActiveDirectory { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DataAccessAuthMode None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Disk.Models.DataAccessAuthMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Disk.Models.DataAccessAuthMode left, Azure.ResourceManager.Disk.Models.DataAccessAuthMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Disk.Models.DataAccessAuthMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Disk.Models.DataAccessAuthMode left, Azure.ResourceManager.Disk.Models.DataAccessAuthMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiskAccessPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.DiskAccessPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskAccessPatch>
    {
        public DiskAccessPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Disk.Models.DiskAccessPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.DiskAccessPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.DiskAccessPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.Models.DiskAccessPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskAccessPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskAccessPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskAccessPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskApiError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.DiskApiError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskApiError>
    {
        internal DiskApiError() { }
        public string Code { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Disk.Models.DiskApiErrorBase> Details { get { throw null; } }
        public Azure.ResourceManager.Disk.Models.InnerError Innererror { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        Azure.ResourceManager.Disk.Models.DiskApiError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.DiskApiError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.DiskApiError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.Models.DiskApiError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskApiError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskApiError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskApiError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskApiErrorBase : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.DiskApiErrorBase>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskApiErrorBase>
    {
        internal DiskApiErrorBase() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public string Target { get { throw null; } }
        Azure.ResourceManager.Disk.Models.DiskApiErrorBase System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.DiskApiErrorBase>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.DiskApiErrorBase>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.Models.DiskApiErrorBase System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskApiErrorBase>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskApiErrorBase>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskApiErrorBase>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskCreateOption : System.IEquatable<Azure.ResourceManager.Disk.Models.DiskCreateOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskCreateOption(string value) { throw null; }
        public static Azure.ResourceManager.Disk.Models.DiskCreateOption Attach { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskCreateOption Copy { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskCreateOption CopyFromSanSnapshot { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskCreateOption CopyStart { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskCreateOption Empty { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskCreateOption FromImage { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskCreateOption Import { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskCreateOption ImportSecure { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskCreateOption Restore { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskCreateOption Upload { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskCreateOption UploadPreparedSecure { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Disk.Models.DiskCreateOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Disk.Models.DiskCreateOption left, Azure.ResourceManager.Disk.Models.DiskCreateOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.Disk.Models.DiskCreateOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Disk.Models.DiskCreateOption left, Azure.ResourceManager.Disk.Models.DiskCreateOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiskCreationData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.DiskCreationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskCreationData>
    {
        public DiskCreationData(Azure.ResourceManager.Disk.Models.DiskCreateOption createOption) { }
        public Azure.ResourceManager.Disk.Models.DiskCreateOption CreateOption { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ElasticSanResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.ImageDiskReference GalleryImageReference { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.ImageDiskReference ImageReference { get { throw null; } set { } }
        public bool? IsPerformancePlusEnabled { get { throw null; } set { } }
        public int? LogicalSectorSize { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.ProvisionedBandwidthCopyOption? ProvisionedBandwidthCopySpeed { get { throw null; } set { } }
        public System.Uri SecurityDataUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
        public string SourceUniqueId { get { throw null; } }
        public System.Uri SourceUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageAccountId { get { throw null; } set { } }
        public long? UploadSizeBytes { get { throw null; } set { } }
        Azure.ResourceManager.Disk.Models.DiskCreationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.DiskCreationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.DiskCreationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.Models.DiskCreationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskCreationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskCreationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskCreationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.DiskEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskEncryption>
    {
        public DiskEncryption() { }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.DiskEncryptionType? EncryptionType { get { throw null; } set { } }
        Azure.ResourceManager.Disk.Models.DiskEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.DiskEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.DiskEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.Models.DiskEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskEncryptionSetPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.DiskEncryptionSetPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskEncryptionSetPatch>
    {
        public DiskEncryptionSetPatch() { }
        public Azure.ResourceManager.Disk.Models.KeyForDiskEncryptionSet ActiveKey { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.DiskEncryptionSetType? EncryptionType { get { throw null; } set { } }
        public string FederatedClientId { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public bool? RotationToLatestKeyVersionEnabled { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Disk.Models.DiskEncryptionSetPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.DiskEncryptionSetPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.DiskEncryptionSetPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.Models.DiskEncryptionSetPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskEncryptionSetPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskEncryptionSetPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskEncryptionSetPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskEncryptionSetType : System.IEquatable<Azure.ResourceManager.Disk.Models.DiskEncryptionSetType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskEncryptionSetType(string value) { throw null; }
        public static Azure.ResourceManager.Disk.Models.DiskEncryptionSetType ConfidentialVmEncryptedWithCustomerKey { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskEncryptionSetType EncryptionAtRestWithCustomerKey { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskEncryptionSetType EncryptionAtRestWithPlatformAndCustomerKeys { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Disk.Models.DiskEncryptionSetType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Disk.Models.DiskEncryptionSetType left, Azure.ResourceManager.Disk.Models.DiskEncryptionSetType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Disk.Models.DiskEncryptionSetType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Disk.Models.DiskEncryptionSetType left, Azure.ResourceManager.Disk.Models.DiskEncryptionSetType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskEncryptionType : System.IEquatable<Azure.ResourceManager.Disk.Models.DiskEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.Disk.Models.DiskEncryptionType EncryptionAtRestWithCustomerKey { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskEncryptionType EncryptionAtRestWithPlatformAndCustomerKeys { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskEncryptionType EncryptionAtRestWithPlatformKey { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Disk.Models.DiskEncryptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Disk.Models.DiskEncryptionType left, Azure.ResourceManager.Disk.Models.DiskEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Disk.Models.DiskEncryptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Disk.Models.DiskEncryptionType left, Azure.ResourceManager.Disk.Models.DiskEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskImageFileFormat : System.IEquatable<Azure.ResourceManager.Disk.Models.DiskImageFileFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskImageFileFormat(string value) { throw null; }
        public static Azure.ResourceManager.Disk.Models.DiskImageFileFormat Vhd { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskImageFileFormat Vhdx { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Disk.Models.DiskImageFileFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Disk.Models.DiskImageFileFormat left, Azure.ResourceManager.Disk.Models.DiskImageFileFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.Disk.Models.DiskImageFileFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Disk.Models.DiskImageFileFormat left, Azure.ResourceManager.Disk.Models.DiskImageFileFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.Disk.Models.DiskPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Disk.Models.DiskPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Disk.Models.DiskPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Disk.Models.DiskPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Disk.Models.DiskPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Disk.Models.DiskPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Disk.Models.DiskPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Disk.Models.DiskPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.Disk.Models.DiskPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Disk.Models.DiskPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Disk.Models.DiskPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Disk.Models.DiskPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Disk.Models.DiskPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Disk.Models.DiskPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Disk.Models.DiskPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Disk.Models.DiskPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiskPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.DiskPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskPrivateLinkServiceConnectionState>
    {
        public DiskPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.DiskPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        Azure.ResourceManager.Disk.Models.DiskPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.DiskPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.DiskPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.Models.DiskPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Disk.Models.DiskPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Disk.Models.DiskPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Disk.Models.DiskPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Disk.Models.DiskPublicNetworkAccess left, Azure.ResourceManager.Disk.Models.DiskPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Disk.Models.DiskPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Disk.Models.DiskPublicNetworkAccess left, Azure.ResourceManager.Disk.Models.DiskPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiskPurchasePlan : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.DiskPurchasePlan>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskPurchasePlan>
    {
        public DiskPurchasePlan(string name, string publisher, string product) { }
        public string Name { get { throw null; } set { } }
        public string Product { get { throw null; } set { } }
        public string PromotionCode { get { throw null; } set { } }
        public string Publisher { get { throw null; } set { } }
        Azure.ResourceManager.Disk.Models.DiskPurchasePlan System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.DiskPurchasePlan>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.DiskPurchasePlan>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.Models.DiskPurchasePlan System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskPurchasePlan>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskPurchasePlan>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskPurchasePlan>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskSecurityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.DiskSecurityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskSecurityProfile>
    {
        public DiskSecurityProfile() { }
        public Azure.Core.ResourceIdentifier SecureVmDiskEncryptionSetId { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.DiskSecurityType? SecurityType { get { throw null; } set { } }
        Azure.ResourceManager.Disk.Models.DiskSecurityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.DiskSecurityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.DiskSecurityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.Models.DiskSecurityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskSecurityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskSecurityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskSecurityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskSecurityType : System.IEquatable<Azure.ResourceManager.Disk.Models.DiskSecurityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskSecurityType(string value) { throw null; }
        public static Azure.ResourceManager.Disk.Models.DiskSecurityType ConfidentialVmDiskEncryptedWithCustomerKey { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskSecurityType ConfidentialVmDiskEncryptedWithPlatformKey { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskSecurityType ConfidentialVmGuestStateOnlyEncryptedWithPlatformKey { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskSecurityType ConfidentialVmNonPersistedTPM { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskSecurityType TrustedLaunch { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Disk.Models.DiskSecurityType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Disk.Models.DiskSecurityType left, Azure.ResourceManager.Disk.Models.DiskSecurityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Disk.Models.DiskSecurityType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Disk.Models.DiskSecurityType left, Azure.ResourceManager.Disk.Models.DiskSecurityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiskSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.DiskSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskSku>
    {
        public DiskSku() { }
        public Azure.ResourceManager.Disk.Models.DiskStorageAccountType? Name { get { throw null; } set { } }
        public string Tier { get { throw null; } }
        Azure.ResourceManager.Disk.Models.DiskSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.DiskSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.DiskSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.Models.DiskSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.DiskSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskState : System.IEquatable<Azure.ResourceManager.Disk.Models.DiskState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskState(string value) { throw null; }
        public static Azure.ResourceManager.Disk.Models.DiskState ActiveSas { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskState ActiveSasFrozen { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskState ActiveUpload { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskState Attached { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskState Frozen { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskState ReadyToUpload { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskState Reserved { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskState Unattached { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Disk.Models.DiskState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Disk.Models.DiskState left, Azure.ResourceManager.Disk.Models.DiskState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Disk.Models.DiskState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Disk.Models.DiskState left, Azure.ResourceManager.Disk.Models.DiskState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DiskStorageAccountType : System.IEquatable<Azure.ResourceManager.Disk.Models.DiskStorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DiskStorageAccountType(string value) { throw null; }
        public static Azure.ResourceManager.Disk.Models.DiskStorageAccountType PremiumLrs { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskStorageAccountType PremiumV2Lrs { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskStorageAccountType PremiumZrs { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskStorageAccountType StandardLrs { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskStorageAccountType StandardSsdLrs { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskStorageAccountType StandardSsdZrs { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.DiskStorageAccountType UltraSsdLrs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Disk.Models.DiskStorageAccountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Disk.Models.DiskStorageAccountType left, Azure.ResourceManager.Disk.Models.DiskStorageAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Disk.Models.DiskStorageAccountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Disk.Models.DiskStorageAccountType left, Azure.ResourceManager.Disk.Models.DiskStorageAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EncryptionSettingsElement : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.EncryptionSettingsElement>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.EncryptionSettingsElement>
    {
        public EncryptionSettingsElement() { }
        public Azure.ResourceManager.Disk.Models.KeyVaultAndSecretReference DiskEncryptionKey { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.KeyVaultAndKeyReference KeyEncryptionKey { get { throw null; } set { } }
        Azure.ResourceManager.Disk.Models.EncryptionSettingsElement System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.EncryptionSettingsElement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.EncryptionSettingsElement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.Models.EncryptionSettingsElement System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.EncryptionSettingsElement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.EncryptionSettingsElement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.EncryptionSettingsElement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EncryptionSettingsGroup : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.EncryptionSettingsGroup>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.EncryptionSettingsGroup>
    {
        public EncryptionSettingsGroup(bool enabled) { }
        public bool Enabled { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Disk.Models.EncryptionSettingsElement> EncryptionSettings { get { throw null; } }
        public string EncryptionSettingsVersion { get { throw null; } set { } }
        Azure.ResourceManager.Disk.Models.EncryptionSettingsGroup System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.EncryptionSettingsGroup>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.EncryptionSettingsGroup>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.Models.EncryptionSettingsGroup System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.EncryptionSettingsGroup>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.EncryptionSettingsGroup>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.EncryptionSettingsGroup>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GrantAccessData : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.GrantAccessData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.GrantAccessData>
    {
        public GrantAccessData(Azure.ResourceManager.Disk.Models.AccessLevel access, int durationInSeconds) { }
        public Azure.ResourceManager.Disk.Models.AccessLevel Access { get { throw null; } }
        public int DurationInSeconds { get { throw null; } }
        public Azure.ResourceManager.Disk.Models.DiskImageFileFormat? FileFormat { get { throw null; } set { } }
        public bool? GetSecureVmGuestStateSas { get { throw null; } set { } }
        Azure.ResourceManager.Disk.Models.GrantAccessData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.GrantAccessData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.GrantAccessData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.Models.GrantAccessData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.GrantAccessData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.GrantAccessData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.GrantAccessData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HyperVGeneration : System.IEquatable<Azure.ResourceManager.Disk.Models.HyperVGeneration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HyperVGeneration(string value) { throw null; }
        public static Azure.ResourceManager.Disk.Models.HyperVGeneration V1 { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.HyperVGeneration V2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Disk.Models.HyperVGeneration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Disk.Models.HyperVGeneration left, Azure.ResourceManager.Disk.Models.HyperVGeneration right) { throw null; }
        public static implicit operator Azure.ResourceManager.Disk.Models.HyperVGeneration (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Disk.Models.HyperVGeneration left, Azure.ResourceManager.Disk.Models.HyperVGeneration right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ImageDiskReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.ImageDiskReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.ImageDiskReference>
    {
        public ImageDiskReference() { }
        public string CommunityGalleryImageId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public int? Lun { get { throw null; } set { } }
        public string SharedGalleryImageId { get { throw null; } set { } }
        Azure.ResourceManager.Disk.Models.ImageDiskReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.ImageDiskReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.ImageDiskReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.Models.ImageDiskReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.ImageDiskReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.ImageDiskReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.ImageDiskReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InnerError : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.InnerError>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.InnerError>
    {
        internal InnerError() { }
        public string Errordetail { get { throw null; } }
        public string Exceptiontype { get { throw null; } }
        Azure.ResourceManager.Disk.Models.InnerError System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.InnerError>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.InnerError>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.Models.InnerError System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.InnerError>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.InnerError>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.InnerError>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyForDiskEncryptionSet : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.KeyForDiskEncryptionSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.KeyForDiskEncryptionSet>
    {
        public KeyForDiskEncryptionSet(System.Uri keyUri) { }
        public System.Uri KeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
        Azure.ResourceManager.Disk.Models.KeyForDiskEncryptionSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.KeyForDiskEncryptionSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.KeyForDiskEncryptionSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.Models.KeyForDiskEncryptionSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.KeyForDiskEncryptionSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.KeyForDiskEncryptionSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.KeyForDiskEncryptionSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultAndKeyReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.KeyVaultAndKeyReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.KeyVaultAndKeyReference>
    {
        public KeyVaultAndKeyReference(Azure.ResourceManager.Resources.Models.WritableSubResource sourceVault, System.Uri keyUri) { }
        public System.Uri KeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
        Azure.ResourceManager.Disk.Models.KeyVaultAndKeyReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.KeyVaultAndKeyReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.KeyVaultAndKeyReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.Models.KeyVaultAndKeyReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.KeyVaultAndKeyReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.KeyVaultAndKeyReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.KeyVaultAndKeyReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyVaultAndSecretReference : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.KeyVaultAndSecretReference>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.KeyVaultAndSecretReference>
    {
        public KeyVaultAndSecretReference(Azure.ResourceManager.Resources.Models.WritableSubResource sourceVault, System.Uri secretUri) { }
        public System.Uri SecretUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceVaultId { get { throw null; } set { } }
        Azure.ResourceManager.Disk.Models.KeyVaultAndSecretReference System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.KeyVaultAndSecretReference>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.KeyVaultAndSecretReference>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.Models.KeyVaultAndSecretReference System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.KeyVaultAndSecretReference>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.KeyVaultAndSecretReference>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.KeyVaultAndSecretReference>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedDiskPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.ManagedDiskPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.ManagedDiskPatch>
    {
        public ManagedDiskPatch() { }
        public bool? BurstingEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.DataAccessAuthMode? DataAccessAuthMode { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DiskAccessId { get { throw null; } set { } }
        public long? DiskIopsReadOnly { get { throw null; } set { } }
        public long? DiskIopsReadWrite { get { throw null; } set { } }
        public long? DiskMBpsReadOnly { get { throw null; } set { } }
        public long? DiskMBpsReadWrite { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.DiskEncryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.EncryptionSettingsGroup EncryptionSettingsGroup { get { throw null; } set { } }
        public bool? IsOptimizedForFrequentAttach { get { throw null; } set { } }
        public int? MaxShares { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.NetworkAccessPolicy? NetworkAccessPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.SupportedOperatingSystemType? OSType { get { throw null; } set { } }
        public string PropertyUpdatesInProgressTargetTier { get { throw null; } }
        public Azure.ResourceManager.Disk.Models.DiskPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.DiskPurchasePlan PurchasePlan { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.DiskSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.SupportedCapabilities SupportedCapabilities { get { throw null; } set { } }
        public bool? SupportsHibernation { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public string Tier { get { throw null; } set { } }
        Azure.ResourceManager.Disk.Models.ManagedDiskPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.ManagedDiskPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.ManagedDiskPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.Models.ManagedDiskPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.ManagedDiskPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.ManagedDiskPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.ManagedDiskPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkAccessPolicy : System.IEquatable<Azure.ResourceManager.Disk.Models.NetworkAccessPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkAccessPolicy(string value) { throw null; }
        public static Azure.ResourceManager.Disk.Models.NetworkAccessPolicy AllowAll { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.NetworkAccessPolicy AllowPrivate { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.NetworkAccessPolicy DenyAll { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Disk.Models.NetworkAccessPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Disk.Models.NetworkAccessPolicy left, Azure.ResourceManager.Disk.Models.NetworkAccessPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Disk.Models.NetworkAccessPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Disk.Models.NetworkAccessPolicy left, Azure.ResourceManager.Disk.Models.NetworkAccessPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisionedBandwidthCopyOption : System.IEquatable<Azure.ResourceManager.Disk.Models.ProvisionedBandwidthCopyOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisionedBandwidthCopyOption(string value) { throw null; }
        public static Azure.ResourceManager.Disk.Models.ProvisionedBandwidthCopyOption Enhanced { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.ProvisionedBandwidthCopyOption None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Disk.Models.ProvisionedBandwidthCopyOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Disk.Models.ProvisionedBandwidthCopyOption left, Azure.ResourceManager.Disk.Models.ProvisionedBandwidthCopyOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.Disk.Models.ProvisionedBandwidthCopyOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Disk.Models.ProvisionedBandwidthCopyOption left, Azure.ResourceManager.Disk.Models.ProvisionedBandwidthCopyOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ShareInfoElement : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.ShareInfoElement>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.ShareInfoElement>
    {
        internal ShareInfoElement() { }
        public System.Uri VmUri { get { throw null; } }
        Azure.ResourceManager.Disk.Models.ShareInfoElement System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.ShareInfoElement>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.ShareInfoElement>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.Models.ShareInfoElement System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.ShareInfoElement>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.ShareInfoElement>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.ShareInfoElement>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SnapshotPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.SnapshotPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.SnapshotPatch>
    {
        public SnapshotPatch() { }
        public Azure.ResourceManager.Disk.Models.DataAccessAuthMode? DataAccessAuthMode { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DiskAccessId { get { throw null; } set { } }
        public int? DiskSizeGB { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.DiskEncryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.EncryptionSettingsGroup EncryptionSettingsGroup { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.NetworkAccessPolicy? NetworkAccessPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.SupportedOperatingSystemType? OSType { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.DiskPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.SnapshotSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.SupportedCapabilities SupportedCapabilities { get { throw null; } set { } }
        public bool? SupportsHibernation { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.Disk.Models.SnapshotPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.SnapshotPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.SnapshotPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.Models.SnapshotPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.SnapshotPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.SnapshotPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.SnapshotPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SnapshotSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.SnapshotSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.SnapshotSku>
    {
        public SnapshotSku() { }
        public Azure.ResourceManager.Disk.Models.SnapshotStorageAccountType? Name { get { throw null; } set { } }
        public string Tier { get { throw null; } }
        Azure.ResourceManager.Disk.Models.SnapshotSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.SnapshotSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.SnapshotSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.Models.SnapshotSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.SnapshotSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.SnapshotSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.SnapshotSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SnapshotStorageAccountType : System.IEquatable<Azure.ResourceManager.Disk.Models.SnapshotStorageAccountType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SnapshotStorageAccountType(string value) { throw null; }
        public static Azure.ResourceManager.Disk.Models.SnapshotStorageAccountType PremiumLrs { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.SnapshotStorageAccountType StandardLrs { get { throw null; } }
        public static Azure.ResourceManager.Disk.Models.SnapshotStorageAccountType StandardZrs { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Disk.Models.SnapshotStorageAccountType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Disk.Models.SnapshotStorageAccountType left, Azure.ResourceManager.Disk.Models.SnapshotStorageAccountType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Disk.Models.SnapshotStorageAccountType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Disk.Models.SnapshotStorageAccountType left, Azure.ResourceManager.Disk.Models.SnapshotStorageAccountType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SupportedCapabilities : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.SupportedCapabilities>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.SupportedCapabilities>
    {
        public SupportedCapabilities() { }
        public bool? AcceleratedNetwork { get { throw null; } set { } }
        public Azure.ResourceManager.Disk.Models.ArchitectureType? Architecture { get { throw null; } set { } }
        public string DiskControllerTypes { get { throw null; } set { } }
        Azure.ResourceManager.Disk.Models.SupportedCapabilities System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.SupportedCapabilities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Disk.Models.SupportedCapabilities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Disk.Models.SupportedCapabilities System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.SupportedCapabilities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.SupportedCapabilities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Disk.Models.SupportedCapabilities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum SupportedOperatingSystemType
    {
        Windows = 0,
        Linux = 1,
    }
}
