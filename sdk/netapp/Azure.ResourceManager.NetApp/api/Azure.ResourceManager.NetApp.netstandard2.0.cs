namespace Azure.ResourceManager.NetApp
{
    public partial class AzureResourceManagerNetAppContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerNetAppContext() { }
        public static Azure.ResourceManager.NetApp.AzureResourceManagerNetAppContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class BucketCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.BucketResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.BucketResource>, System.Collections.IEnumerable
    {
        protected BucketCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.BucketResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string bucketName, Azure.ResourceManager.NetApp.BucketData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.BucketResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string bucketName, Azure.ResourceManager.NetApp.BucketData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string bucketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string bucketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.BucketResource> Get(string bucketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.BucketResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.BucketResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.BucketResource>> GetAsync(string bucketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetApp.BucketResource> GetIfExists(string bucketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetApp.BucketResource>> GetIfExistsAsync(string bucketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.BucketResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.BucketResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.BucketResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.BucketResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BucketData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.BucketData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.BucketData>
    {
        public BucketData() { }
        public Azure.ResourceManager.NetApp.Models.FileSystemUser FileSystemUser { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.BucketPermission? Permissions { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.BucketServerProperties Server { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.CredentialsStatus? Status { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.BucketData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.BucketData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.BucketData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.BucketData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.BucketData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.BucketData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.BucketData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BucketResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.BucketData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.BucketData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BucketResource() { }
        public virtual Azure.ResourceManager.NetApp.BucketData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName, string bucketName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.Models.BucketGenerateCredentials> GenerateCredentials(Azure.ResourceManager.NetApp.Models.BucketCredentialsExpiry body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.BucketGenerateCredentials>> GenerateCredentialsAsync(Azure.ResourceManager.NetApp.Models.BucketCredentialsExpiry body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.BucketResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.BucketResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetApp.BucketData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.BucketData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.BucketData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.BucketData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.BucketData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.BucketData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.BucketData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.BucketResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.BucketPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.BucketResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.BucketPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CapacityPoolCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.CapacityPoolResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.CapacityPoolResource>, System.Collections.IEnumerable
    {
        protected CapacityPoolCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.CapacityPoolResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string poolName, Azure.ResourceManager.NetApp.CapacityPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.CapacityPoolResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string poolName, Azure.ResourceManager.NetApp.CapacityPoolData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.CapacityPoolResource> Get(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.CapacityPoolResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.CapacityPoolResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.CapacityPoolResource>> GetAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetApp.CapacityPoolResource> GetIfExists(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetApp.CapacityPoolResource>> GetIfExistsAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.CapacityPoolResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.CapacityPoolResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.CapacityPoolResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.CapacityPoolResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CapacityPoolData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.CapacityPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.CapacityPoolData>
    {
        public CapacityPoolData(Azure.Core.AzureLocation location, long size, Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel serviceLevel) { }
        public float? CustomThroughputMibps { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.CapacityPoolEncryptionType? EncryptionType { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public bool? IsCoolAccessEnabled { get { throw null; } set { } }
        public System.Guid? PoolId { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.CapacityPoolQosType? QosType { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel ServiceLevel { get { throw null; } set { } }
        public long Size { get { throw null; } set { } }
        public float? TotalThroughputMibps { get { throw null; } }
        public float? UtilizedThroughputMibps { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.CapacityPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.CapacityPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.CapacityPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.CapacityPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.CapacityPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.CapacityPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.CapacityPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CapacityPoolResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.CapacityPoolData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.CapacityPoolData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CapacityPoolResource() { }
        public virtual Azure.ResourceManager.NetApp.CapacityPoolData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.CapacityPoolResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.CapacityPoolResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string poolName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.CapacityPoolResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.CapacityPoolResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeResource> GetNetAppVolume(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeResource>> GetNetAppVolumeAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetApp.NetAppVolumeCollection GetNetAppVolumes() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.CapacityPoolResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.CapacityPoolResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.CapacityPoolResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.CapacityPoolResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetApp.CapacityPoolData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.CapacityPoolData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.CapacityPoolData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.CapacityPoolData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.CapacityPoolData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.CapacityPoolData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.CapacityPoolData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.CapacityPoolResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.CapacityPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.CapacityPoolResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.CapacityPoolPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class NetAppAccountBackupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppAccountBackupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppAccountBackupResource>, System.Collections.IEnumerable
    {
        protected NetAppAccountBackupCollection() { }
        public virtual Azure.Response<bool> Exists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountBackupResource> Get(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.NetAppAccountBackupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.NetAppAccountBackupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountBackupResource>> GetAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetApp.NetAppAccountBackupResource> GetIfExists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetApp.NetAppAccountBackupResource>> GetIfExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.NetAppAccountBackupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppAccountBackupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.NetAppAccountBackupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppAccountBackupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class NetAppAccountBackupResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetAppAccountBackupResource() { }
        public virtual Azure.ResourceManager.NetApp.NetAppBackupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string backupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountBackupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountBackupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetAppAccountCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppAccountResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppAccountResource>, System.Collections.IEnumerable
    {
        protected NetAppAccountCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppAccountResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.NetApp.NetAppAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppAccountResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string accountName, Azure.ResourceManager.NetApp.NetAppAccountData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource> Get(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.NetAppAccountResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.NetAppAccountResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource>> GetAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetApp.NetAppAccountResource> GetIfExists(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetApp.NetAppAccountResource>> GetIfExistsAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.NetAppAccountResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppAccountResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.NetAppAccountResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppAccountResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetAppAccountData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppAccountData>
    {
        public NetAppAccountData(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectory> ActiveDirectories { get { throw null; } }
        public bool? DisableShowmount { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppAccountEncryption Encryption { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.LdapConfiguration LdapConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.MultiAdStatus? MultiAdStatus { get { throw null; } }
        public string NfsV4IdDomain { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.NetAppAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.NetAppAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class NetAppAccountResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppAccountData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppAccountData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetAppAccountResource() { }
        public virtual Azure.ResourceManager.NetApp.NetAppAccountData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ChangeKeyVault(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppChangeKeyVault body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ChangeKeyVaultAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppChangeKeyVault body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.CapacityPoolResource> GetCapacityPool(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.CapacityPoolResource>> GetCapacityPoolAsync(string poolName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetApp.CapacityPoolCollection GetCapacityPools() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatusResult> GetChangeKeyVaultInformation(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatusResult>> GetChangeKeyVaultInformationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountBackupResource> GetNetAppAccountBackup(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountBackupResource>> GetNetAppAccountBackupAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.NetApp.NetAppAccountBackupCollection GetNetAppAccountBackups() { throw null; }
        public virtual Azure.ResourceManager.NetApp.NetAppBackupPolicyCollection GetNetAppBackupPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource> GetNetAppBackupPolicy(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource>> GetNetAppBackupPolicyAsync(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupVaultResource> GetNetAppBackupVault(string backupVaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupVaultResource>> GetNetAppBackupVaultAsync(string backupVaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetApp.NetAppBackupVaultCollection GetNetAppBackupVaults() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppSubscriptionQuotaItem> GetNetAppResourceQuotaLimitsAccount(string quotaLimitName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppSubscriptionQuotaItem>> GetNetAppResourceQuotaLimitsAccountAsync(string quotaLimitName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.Models.NetAppSubscriptionQuotaItem> GetNetAppResourceQuotaLimitsAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.Models.NetAppSubscriptionQuotaItem> GetNetAppResourceQuotaLimitsAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeGroupResource> GetNetAppVolumeGroup(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeGroupResource>> GetNetAppVolumeGroupAsync(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetApp.NetAppVolumeGroupCollection GetNetAppVolumeGroups() { throw null; }
        public virtual Azure.ResourceManager.NetApp.SnapshotPolicyCollection GetSnapshotPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.SnapshotPolicyResource> GetSnapshotPolicy(string snapshotPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.SnapshotPolicyResource>> GetSnapshotPolicyAsync(string snapshotPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.Models.NetAppVault> GetVaults(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.Models.NetAppVault> GetVaultsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupResult> GetVolumeGroups(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupResult> GetVolumeGroupsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation MigrateBackupsBackupsUnderAccount(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.BackupsMigrationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> MigrateBackupsBackupsUnderAccountAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.BackupsMigrationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RenewCredentials(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RenewCredentialsAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetApp.NetAppAccountData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppAccountData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppAccountData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.NetAppAccountData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppAccountData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppAccountData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppAccountData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation TransitionToCmk(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppEncryptionTransitionContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TransitionToCmkAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppEncryptionTransitionContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppAccountResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppAccountResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppAccountPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class NetAppBackupData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppBackupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppBackupData>
    {
        public NetAppBackupData(Azure.Core.AzureLocation location) { }
        public NetAppBackupData(Azure.Core.ResourceIdentifier volumeResourceId) { }
        public string BackupId { get { throw null; } }
        public Azure.Core.ResourceIdentifier BackupPolicyArmResourceId { get { throw null; } }
        public string BackupPolicyResourceId { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppBackupType? BackupType { get { throw null; } }
        public System.DateTimeOffset? CompletionOn { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string FailureReason { get { throw null; } }
        public bool? IsLargeVolume { get { throw null; } }
        public string Label { get { throw null; } set { } }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public long? Size { get { throw null; } }
        public System.DateTimeOffset? SnapshotCreationOn { get { throw null; } }
        public string SnapshotName { get { throw null; } set { } }
        public bool? UseExistingSnapshot { get { throw null; } set { } }
        public string VolumeName { get { throw null; } }
        public Azure.Core.ResourceIdentifier VolumeResourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.NetAppBackupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppBackupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppBackupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.NetAppBackupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppBackupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppBackupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppBackupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppBackupPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource>, System.Collections.IEnumerable
    {
        protected NetAppBackupPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string backupPolicyName, Azure.ResourceManager.NetApp.NetAppBackupPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string backupPolicyName, Azure.ResourceManager.NetApp.NetAppBackupPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource> Get(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource>> GetAsync(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource> GetIfExists(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource>> GetIfExistsAsync(string backupPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetAppBackupPolicyData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppBackupPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppBackupPolicyData>
    {
        public NetAppBackupPolicyData(Azure.Core.AzureLocation location) { }
        public Azure.Core.ResourceIdentifier BackupPolicyId { get { throw null; } }
        public int? DailyBackupsToKeep { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public bool? IsEnabled { get { throw null; } set { } }
        public int? MonthlyBackupsToKeep { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupDetail> VolumeBackups { get { throw null; } }
        public int? VolumesAssigned { get { throw null; } }
        public int? WeeklyBackupsToKeep { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.NetAppBackupPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppBackupPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppBackupPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.NetAppBackupPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppBackupPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppBackupPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppBackupPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppBackupPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppBackupPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppBackupPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetAppBackupPolicyResource() { }
        public virtual Azure.ResourceManager.NetApp.NetAppBackupPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string backupPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetApp.NetAppBackupPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppBackupPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppBackupPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.NetAppBackupPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppBackupPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppBackupPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppBackupPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppBackupPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppBackupPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppBackupPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetAppBackupVaultBackupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppBackupVaultBackupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppBackupVaultBackupResource>, System.Collections.IEnumerable
    {
        protected NetAppBackupVaultBackupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppBackupVaultBackupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string backupName, Azure.ResourceManager.NetApp.NetAppBackupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppBackupVaultBackupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string backupName, Azure.ResourceManager.NetApp.NetAppBackupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupVaultBackupResource> Get(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.NetAppBackupVaultBackupResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.NetAppBackupVaultBackupResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupVaultBackupResource>> GetAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetApp.NetAppBackupVaultBackupResource> GetIfExists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetApp.NetAppBackupVaultBackupResource>> GetIfExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.NetAppBackupVaultBackupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppBackupVaultBackupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.NetAppBackupVaultBackupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppBackupVaultBackupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetAppBackupVaultBackupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppBackupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppBackupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetAppBackupVaultBackupResource() { }
        public virtual Azure.ResourceManager.NetApp.NetAppBackupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string backupVaultName, string backupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupVaultBackupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupVaultBackupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RestoreFilesBackupsUnderBackupVault(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupBackupRestoreFilesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestoreFilesBackupsUnderBackupVaultAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupBackupRestoreFilesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetApp.NetAppBackupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppBackupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppBackupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.NetAppBackupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppBackupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppBackupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppBackupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppBackupVaultBackupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppBackupVaultBackupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppBackupVaultBackupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppBackupVaultBackupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetAppBackupVaultCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppBackupVaultResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppBackupVaultResource>, System.Collections.IEnumerable
    {
        protected NetAppBackupVaultCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppBackupVaultResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string backupVaultName, Azure.ResourceManager.NetApp.NetAppBackupVaultData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppBackupVaultResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string backupVaultName, Azure.ResourceManager.NetApp.NetAppBackupVaultData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string backupVaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupVaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupVaultResource> Get(string backupVaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.NetAppBackupVaultResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.NetAppBackupVaultResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupVaultResource>> GetAsync(string backupVaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetApp.NetAppBackupVaultResource> GetIfExists(string backupVaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetApp.NetAppBackupVaultResource>> GetIfExistsAsync(string backupVaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.NetAppBackupVaultResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppBackupVaultResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.NetAppBackupVaultResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppBackupVaultResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetAppBackupVaultData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppBackupVaultData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppBackupVaultData>
    {
        public NetAppBackupVaultData(Azure.Core.AzureLocation location) { }
        public string ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.NetAppBackupVaultData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppBackupVaultData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppBackupVaultData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.NetAppBackupVaultData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppBackupVaultData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppBackupVaultData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppBackupVaultData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppBackupVaultResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppBackupVaultData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppBackupVaultData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetAppBackupVaultResource() { }
        public virtual Azure.ResourceManager.NetApp.NetAppBackupVaultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupVaultResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupVaultResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string backupVaultName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupVaultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupVaultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupVaultBackupResource> GetNetAppBackupVaultBackup(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupVaultBackupResource>> GetNetAppBackupVaultBackupAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetApp.NetAppBackupVaultBackupCollection GetNetAppBackupVaultBackups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupVaultResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupVaultResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupVaultResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppBackupVaultResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetApp.NetAppBackupVaultData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppBackupVaultData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppBackupVaultData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.NetAppBackupVaultData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppBackupVaultData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppBackupVaultData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppBackupVaultData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppBackupVaultResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppBackupVaultPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppBackupVaultResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppBackupVaultPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class NetAppExtensions
    {
        public static Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppCheckAvailabilityResult> CheckNetAppFilePathAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.NetAppFilePathAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppCheckAvailabilityResult>> CheckNetAppFilePathAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.NetAppFilePathAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppCheckAvailabilityResult> CheckNetAppNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppCheckAvailabilityResult>> CheckNetAppNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppCheckAvailabilityResult> CheckNetAppQuotaAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppCheckAvailabilityResult>> CheckNetAppQuotaAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetApp.BucketResource GetBucketResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetApp.CapacityPoolResource GetCapacityPoolResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource> GetNetAppAccount(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource>> GetNetAppAccountAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.NetAppAccountBackupResource GetNetAppAccountBackupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppAccountResource GetNetAppAccountResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppAccountCollection GetNetAppAccounts(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetApp.NetAppAccountResource> GetNetAppAccounts(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetApp.NetAppAccountResource> GetNetAppAccountsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppBackupPolicyResource GetNetAppBackupPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppBackupVaultBackupResource GetNetAppBackupVaultBackupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppBackupVaultResource GetNetAppBackupVaultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppSubscriptionQuotaItem> GetNetAppQuotaLimit(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string quotaLimitName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppSubscriptionQuotaItem>> GetNetAppQuotaLimitAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string quotaLimitName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetApp.Models.NetAppSubscriptionQuotaItem> GetNetAppQuotaLimits(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetApp.Models.NetAppSubscriptionQuotaItem> GetNetAppQuotaLimitsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppUsageResult> GetNetAppResourceUsage(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string usageType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppUsageResult>> GetNetAppResourceUsageAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, string usageType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.NetApp.Models.NetAppUsageResult> GetNetAppResourceUsages(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.NetApp.Models.NetAppUsageResult> GetNetAppResourceUsagesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource GetNetAppSubvolumeInfoResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.NetAppVolumeBackupResource GetNetAppVolumeBackupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppVolumeGroupResource GetNetAppVolumeGroupResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource GetNetAppVolumeQuotaRuleResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppVolumeResource GetNetAppVolumeResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource GetNetAppVolumeSnapshotResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.NetApp.RegionInfoResource GetRegionInfoResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetApp.RegionInfoResource> GetRegionInfoResource(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.RegionInfoResource>> GetRegionInfoResourceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.NetApp.RegionInfoResourceCollection GetRegionInfoResources(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location) { throw null; }
        public static Azure.ResourceManager.NetApp.SnapshotPolicyResource GetSnapshotPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetApp.Models.NetworkSiblingSet> QueryNetworkSiblingSetNetAppResource(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.QueryNetworkSiblingSetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.NetworkSiblingSet>> QueryNetworkSiblingSetNetAppResourceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.QueryNetworkSiblingSetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppRegionInfo> QueryRegionInfoNetAppResource(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppRegionInfo>> QueryRegionInfoNetAppResourceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.Models.NetworkSiblingSet> UpdateNetworkSiblingSetNetAppResource(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.UpdateNetworkSiblingSetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.Models.NetworkSiblingSet>> UpdateNetworkSiblingSetNetAppResourceAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.UpdateNetworkSiblingSetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetAppSubvolumeInfoCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource>, System.Collections.IEnumerable
    {
        protected NetAppSubvolumeInfoCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string subvolumeName, Azure.ResourceManager.NetApp.NetAppSubvolumeInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string subvolumeName, Azure.ResourceManager.NetApp.NetAppSubvolumeInfoData info, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string subvolumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string subvolumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource> Get(string subvolumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource>> GetAsync(string subvolumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource> GetIfExists(string subvolumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource>> GetIfExistsAsync(string subvolumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetAppSubvolumeInfoData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoData>
    {
        public NetAppSubvolumeInfoData() { }
        public string ParentPath { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public long? Size { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.NetAppSubvolumeInfoData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.NetAppSubvolumeInfoData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppSubvolumeInfoResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetAppSubvolumeInfoResource() { }
        public virtual Azure.ResourceManager.NetApp.NetAppSubvolumeInfoData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName, string subvolumeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.Models.NetAppSubvolumeMetadata> GetMetadata(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.Models.NetAppSubvolumeMetadata>> GetMetadataAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetApp.NetAppSubvolumeInfoData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.NetAppSubvolumeInfoData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppSubvolumeInfoPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppSubvolumeInfoPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class NetAppVolumeBackupCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource>, System.Collections.IEnumerable
    {
        protected NetAppVolumeBackupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string backupName, Azure.ResourceManager.NetApp.NetAppBackupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string backupName, Azure.ResourceManager.NetApp.NetAppBackupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource> Get(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource>> GetAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource> GetIfExists(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource>> GetIfExistsAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class NetAppVolumeBackupResource : Azure.ResourceManager.ArmResource
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetAppVolumeBackupResource() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.NetApp.NetAppBackupData Data { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName, string backupName) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation RestoreFiles(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupBackupRestoreFilesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestoreFilesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupBackupRestoreFilesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetAppVolumeCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeResource>, System.Collections.IEnumerable
    {
        protected NetAppVolumeCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string volumeName, Azure.ResourceManager.NetApp.NetAppVolumeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string volumeName, Azure.ResourceManager.NetApp.NetAppVolumeData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeResource> Get(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.NetAppVolumeResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.NetAppVolumeResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeResource>> GetAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetApp.NetAppVolumeResource> GetIfExists(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetApp.NetAppVolumeResource>> GetIfExistsAsync(string volumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.NetAppVolumeResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.NetAppVolumeResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetAppVolumeData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppVolumeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeData>
    {
        public NetAppVolumeData(Azure.Core.AzureLocation location, string creationToken, long usageThreshold, Azure.Core.ResourceIdentifier subnetId) { }
        public Azure.ResourceManager.NetApp.Models.AcceptGrowCapacityPoolForShortTermCloneSplit? AcceptGrowCapacityPoolForShortTermCloneSplit { get { throw null; } set { } }
        public float? ActualThroughputMibps { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore? AvsDataStore { get { throw null; } set { } }
        public string BackupId { get { throw null; } set { } }
        public string BaremetalTenantId { get { throw null; } }
        public Azure.Core.ResourceIdentifier CapacityPoolResourceId { get { throw null; } set { } }
        public int? CloneProgress { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.CoolAccessRetrievalPolicy? CoolAccessRetrievalPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.CoolAccessTieringPolicy? CoolAccessTieringPolicy { get { throw null; } set { } }
        public int? CoolnessPeriod { get { throw null; } set { } }
        public string CreationToken { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppVolumeDataProtection DataProtection { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> DataStoreResourceId { get { throw null; } }
        public long? DefaultGroupQuotaInKiBs { get { throw null; } set { } }
        public long? DefaultUserQuotaInKiBs { get { throw null; } set { } }
        public bool? DeleteBaseSnapshot { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature? EffectiveNetworkFeatures { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume? EnableSubvolumes { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource? EncryptionKeySource { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule> ExportRules { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppFileAccessLog? FileAccessLogs { get { throw null; } }
        public System.Guid? FileSystemId { get { throw null; } }
        public long? InheritedSizeInBytes { get { throw null; } }
        public bool? IsCoolAccessEnabled { get { throw null; } set { } }
        public bool? IsDefaultQuotaEnabled { get { throw null; } set { } }
        public bool? IsEncrypted { get { throw null; } }
        public bool? IsKerberosEnabled { get { throw null; } set { } }
        public bool? IsLargeVolume { get { throw null; } set { } }
        public bool? IsLdapEnabled { get { throw null; } set { } }
        public bool? IsRestoring { get { throw null; } [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)] set { } }
        public bool? IsSmbContinuouslyAvailable { get { throw null; } set { } }
        public bool? IsSmbEncryptionEnabled { get { throw null; } set { } }
        public bool? IsSnapshotDirectoryVisible { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier KeyVaultPrivateEndpointResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage? Language { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.LdapServerType? LdapServerType { get { throw null; } set { } }
        public long? MaximumNumberOfFiles { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetApp.Models.NetAppVolumeMountTarget> MountTargets { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature? NetworkFeatures { get { throw null; } set { } }
        public System.Guid? NetworkSiblingSetId { get { throw null; } }
        public Azure.Core.ResourceIdentifier OriginatingResourceId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule> PlacementRules { get { throw null; } }
        public System.Collections.Generic.IList<string> ProtocolTypes { get { throw null; } }
        public string ProvisionedAvailabilityZone { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle? SecurityStyle { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel? ServiceLevel { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration? SmbAccessBasedEnumeration { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.SmbNonBrowsable? SmbNonBrowsable { get { throw null; } set { } }
        public string SnapshotId { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity? StorageToNetworkProximity { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public string T2Network { get { throw null; } }
        public float? ThroughputMibps { get { throw null; } set { } }
        public string UnixPermissions { get { throw null; } set { } }
        public long UsageThreshold { get { throw null; } set { } }
        public string VolumeGroupName { get { throw null; } }
        public string VolumeSpecName { get { throw null; } set { } }
        public string VolumeType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.NetAppVolumeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppVolumeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppVolumeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.NetAppVolumeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppVolumeGroupCollection : Azure.ResourceManager.ArmCollection
    {
        protected NetAppVolumeGroupCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeGroupResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string volumeGroupName, Azure.ResourceManager.NetApp.NetAppVolumeGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeGroupResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string volumeGroupName, Azure.ResourceManager.NetApp.NetAppVolumeGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeGroupResource> Get(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeGroupResource>> GetAsync(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetApp.NetAppVolumeGroupResource> GetIfExists(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetApp.NetAppVolumeGroupResource>> GetIfExistsAsync(string volumeGroupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetAppVolumeGroupData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppVolumeGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeGroupData>
    {
        public NetAppVolumeGroupData() { }
        public Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupMetadata GroupMetaData { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupVolume> Volumes { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.NetAppVolumeGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppVolumeGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppVolumeGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.NetAppVolumeGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppVolumeGroupResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppVolumeGroupData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeGroupData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetAppVolumeGroupResource() { }
        public virtual Azure.ResourceManager.NetApp.NetAppVolumeGroupData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string volumeGroupName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeGroupResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeGroupResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetApp.NetAppVolumeGroupData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppVolumeGroupData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppVolumeGroupData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.NetAppVolumeGroupData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeGroupData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeGroupData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeGroupData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeGroupResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.NetAppVolumeGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeGroupResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.NetAppVolumeGroupData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetAppVolumeQuotaRuleCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource>, System.Collections.IEnumerable
    {
        protected NetAppVolumeQuotaRuleCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string volumeQuotaRuleName, Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string volumeQuotaRuleName, Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string volumeQuotaRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string volumeQuotaRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource> Get(string volumeQuotaRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource>> GetAsync(string volumeQuotaRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource> GetIfExists(string volumeQuotaRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource>> GetIfExistsAsync(string volumeQuotaRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetAppVolumeQuotaRuleData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleData>
    {
        public NetAppVolumeQuotaRuleData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.NetApp.Models.NetAppProvisioningState? ProvisioningState { get { throw null; } }
        public long? QuotaSizeInKiBs { get { throw null; } set { } }
        public string QuotaTarget { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType? QuotaType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppVolumeQuotaRuleResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetAppVolumeQuotaRuleResource() { }
        public virtual Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName, string volumeQuotaRuleName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaRulePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetAppVolumeResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppVolumeData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetAppVolumeResource() { }
        public virtual Azure.ResourceManager.NetApp.NetAppVolumeData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.Models.SvmPeerCommandResult> AuthorizeExternalReplication(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.Models.SvmPeerCommandResult>> AuthorizeExternalReplicationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation AuthorizeReplication(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeAuthorizeReplicationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> AuthorizeReplicationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeAuthorizeReplicationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation BreakFileLocks(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeBreakFileLocksContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> BreakFileLocksAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeBreakFileLocksContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation BreakReplication(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeBreakReplicationContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> BreakReplicationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeBreakReplicationContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? forceDelete = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? forceDelete = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation DeleteReplication(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteReplicationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation FinalizeExternalReplication(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FinalizeExternalReplicationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation FinalizeRelocation(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> FinalizeRelocationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupStatus> GetBackupStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupStatus>> GetBackupStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.BucketResource> GetBucket(string bucketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.BucketResource>> GetBucketAsync(string bucketName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetApp.BucketCollection GetBuckets() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.Models.GetGroupIdListForLdapUserResult> GetGetGroupIdListForLdapUser(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.GetGroupIdListForLdapUserContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.Models.GetGroupIdListForLdapUserResult>> GetGetGroupIdListForLdapUserAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.GetGroupIdListForLdapUserContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupStatus> GetLatestStatusBackup(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupStatus>> GetLatestStatusBackupAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource> GetNetAppSubvolumeInfo(string subvolumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource>> GetNetAppSubvolumeInfoAsync(string subvolumeName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetApp.NetAppSubvolumeInfoCollection GetNetAppSubvolumeInfos() { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource> GetNetAppVolumeBackup(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeBackupResource>> GetNetAppVolumeBackupAsync(string backupName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.NetApp.NetAppVolumeBackupCollection GetNetAppVolumeBackups() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource> GetNetAppVolumeQuotaRule(string volumeQuotaRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource>> GetNetAppVolumeQuotaRuleAsync(string volumeQuotaRuleName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleCollection GetNetAppVolumeQuotaRules() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource> GetNetAppVolumeSnapshot(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource>> GetNetAppVolumeSnapshotAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetApp.NetAppVolumeSnapshotCollection GetNetAppVolumeSnapshots() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaReportListResult> GetQuotaReport(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaReportListResult>> GetQuotaReportAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.Models.NetAppVolumeReplication> GetReplications(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.Models.NetAppVolumeReplication> GetReplicationsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppVolumeReplicationStatus> GetReplicationStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppVolumeReplicationStatus>> GetReplicationStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppRestoreStatus> GetRestoreStatus(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppRestoreStatus>> GetRestoreStatusAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppRestoreStatus> GetVolumeLatestRestoreStatusBackup(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppRestoreStatus>> GetVolumeLatestRestoreStatusBackupAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation MigrateBackupsBackupsUnderVolume(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.BackupsMigrationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> MigrateBackupsBackupsUnderVolumeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.BackupsMigrationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.Models.ClusterPeerCommandResult> PeerExternalCluster(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.PeerClusterForVolumeMigrationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.Models.ClusterPeerCommandResult>> PeerExternalClusterAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.PeerClusterForVolumeMigrationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PerformReplicationTransfer(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PerformReplicationTransferAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PoolChange(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumePoolChangeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PoolChangeAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumePoolChangeContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeResource> PopulateAvailabilityZone(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeResource>> PopulateAvailabilityZoneAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ReestablishReplication(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeReestablishReplicationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReestablishReplicationAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeReestablishReplicationContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ReInitializeReplication(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ReInitializeReplicationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Relocate(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.RelocateVolumeContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RelocateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.RelocateVolumeContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ResetCifsPassword(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResetCifsPasswordAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation ResyncReplication(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> ResyncReplicationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Revert(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeRevertContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RevertAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeRevertContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RevertRelocation(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RevertRelocationAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeResource> SplitCloneFromParent(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeResource>> SplitCloneFromParentAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetApp.NetAppVolumeData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppVolumeData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppVolumeData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.NetAppVolumeData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class NetAppVolumeSnapshotCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource>, System.Collections.IEnumerable
    {
        protected NetAppVolumeSnapshotCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string snapshotName, Azure.ResourceManager.NetApp.NetAppVolumeSnapshotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string snapshotName, Azure.ResourceManager.NetApp.NetAppVolumeSnapshotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource> Get(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource>> GetAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource> GetIfExists(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource>> GetIfExistsAsync(string snapshotName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class NetAppVolumeSnapshotData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotData>
    {
        public NetAppVolumeSnapshotData(Azure.Core.AzureLocation location) { }
        public System.DateTimeOffset? Created { get { throw null; } }
        public Azure.Core.AzureLocation Location { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public string SnapshotId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.NetAppVolumeSnapshotData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.NetAppVolumeSnapshotData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppVolumeSnapshotResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected NetAppVolumeSnapshotResource() { }
        public virtual Azure.ResourceManager.NetApp.NetAppVolumeSnapshotData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string poolName, string volumeName, string snapshotName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RestoreFiles(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeSnapshotRestoreFilesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RestoreFilesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.NetAppVolumeSnapshotRestoreFilesContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetApp.NetAppVolumeSnapshotData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.NetAppVolumeSnapshotData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.NetAppVolumeSnapshotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.NetAppVolumeSnapshotData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class RegionInfoResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.RegionInfoResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.RegionInfoResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected RegionInfoResource() { }
        public virtual Azure.ResourceManager.NetApp.RegionInfoResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.RegionInfoResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.RegionInfoResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetApp.RegionInfoResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.RegionInfoResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.RegionInfoResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.RegionInfoResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.RegionInfoResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.RegionInfoResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.RegionInfoResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RegionInfoResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.RegionInfoResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.RegionInfoResource>, System.Collections.IEnumerable
    {
        protected RegionInfoResourceCollection() { }
        public virtual Azure.Response<bool> Exists(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.RegionInfoResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.RegionInfoResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.RegionInfoResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.RegionInfoResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetApp.RegionInfoResource> GetIfExists(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetApp.RegionInfoResource>> GetIfExistsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.RegionInfoResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.RegionInfoResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.RegionInfoResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.RegionInfoResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class RegionInfoResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.RegionInfoResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.RegionInfoResourceData>
    {
        public RegionInfoResourceData() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetApp.Models.AvailabilityZoneMapping> AvailabilityZoneMappings { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity? StorageToNetworkProximity { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.RegionInfoResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.RegionInfoResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.RegionInfoResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.RegionInfoResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.RegionInfoResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.RegionInfoResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.RegionInfoResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SnapshotPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.SnapshotPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.SnapshotPolicyResource>, System.Collections.IEnumerable
    {
        protected SnapshotPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.SnapshotPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string snapshotPolicyName, Azure.ResourceManager.NetApp.SnapshotPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.SnapshotPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string snapshotPolicyName, Azure.ResourceManager.NetApp.SnapshotPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string snapshotPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string snapshotPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.SnapshotPolicyResource> Get(string snapshotPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.SnapshotPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.SnapshotPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.SnapshotPolicyResource>> GetAsync(string snapshotPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.NetApp.SnapshotPolicyResource> GetIfExists(string snapshotPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.NetApp.SnapshotPolicyResource>> GetIfExistsAsync(string snapshotPolicyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.NetApp.SnapshotPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.NetApp.SnapshotPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.NetApp.SnapshotPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.SnapshotPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SnapshotPolicyData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.SnapshotPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.SnapshotPolicyData>
    {
        public SnapshotPolicyData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.NetApp.Models.SnapshotPolicyDailySchedule DailySchedule { get { throw null; } set { } }
        public Azure.ETag? ETag { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.SnapshotPolicyHourlySchedule HourlySchedule { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.SnapshotPolicyMonthlySchedule MonthlySchedule { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.SnapshotPolicyWeeklySchedule WeeklySchedule { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.SnapshotPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.SnapshotPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.SnapshotPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.SnapshotPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.SnapshotPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.SnapshotPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.SnapshotPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SnapshotPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.SnapshotPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.SnapshotPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SnapshotPolicyResource() { }
        public virtual Azure.ResourceManager.NetApp.SnapshotPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.SnapshotPolicyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.SnapshotPolicyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string accountName, string snapshotPolicyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.SnapshotPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.SnapshotPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.NetAppVolumeResource> GetVolumes(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.NetAppVolumeResource> GetVolumesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.SnapshotPolicyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.SnapshotPolicyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.SnapshotPolicyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.SnapshotPolicyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.NetApp.SnapshotPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.SnapshotPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.SnapshotPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.SnapshotPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.SnapshotPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.SnapshotPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.SnapshotPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.SnapshotPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.SnapshotPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.SnapshotPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.NetApp.Models.SnapshotPolicyPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.NetApp.Mocking
{
    public partial class MockableNetAppArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableNetAppArmClient() { }
        public virtual Azure.ResourceManager.NetApp.BucketResource GetBucketResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetApp.CapacityPoolResource GetCapacityPoolResource(Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.NetApp.NetAppAccountBackupResource GetNetAppAccountBackupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetApp.NetAppAccountResource GetNetAppAccountResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetApp.NetAppBackupPolicyResource GetNetAppBackupPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetApp.NetAppBackupVaultBackupResource GetNetAppBackupVaultBackupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetApp.NetAppBackupVaultResource GetNetAppBackupVaultResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetApp.NetAppSubvolumeInfoResource GetNetAppSubvolumeInfoResource(Azure.Core.ResourceIdentifier id) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.NetApp.NetAppVolumeBackupResource GetNetAppVolumeBackupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetApp.NetAppVolumeGroupResource GetNetAppVolumeGroupResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleResource GetNetAppVolumeQuotaRuleResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetApp.NetAppVolumeResource GetNetAppVolumeResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetApp.NetAppVolumeSnapshotResource GetNetAppVolumeSnapshotResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetApp.RegionInfoResource GetRegionInfoResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.NetApp.SnapshotPolicyResource GetSnapshotPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableNetAppResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNetAppResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource> GetNetAppAccount(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.NetAppAccountResource>> GetNetAppAccountAsync(string accountName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetApp.NetAppAccountCollection GetNetAppAccounts() { throw null; }
    }
    public partial class MockableNetAppSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableNetAppSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppCheckAvailabilityResult> CheckNetAppFilePathAvailability(Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.NetAppFilePathAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppCheckAvailabilityResult>> CheckNetAppFilePathAvailabilityAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.NetAppFilePathAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppCheckAvailabilityResult> CheckNetAppNameAvailability(Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppCheckAvailabilityResult>> CheckNetAppNameAvailabilityAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppCheckAvailabilityResult> CheckNetAppQuotaAvailability(Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppCheckAvailabilityResult>> CheckNetAppQuotaAvailabilityAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.NetAppAccountResource> GetNetAppAccounts(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.NetAppAccountResource> GetNetAppAccountsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppSubscriptionQuotaItem> GetNetAppQuotaLimit(Azure.Core.AzureLocation location, string quotaLimitName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppSubscriptionQuotaItem>> GetNetAppQuotaLimitAsync(Azure.Core.AzureLocation location, string quotaLimitName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.Models.NetAppSubscriptionQuotaItem> GetNetAppQuotaLimits(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.Models.NetAppSubscriptionQuotaItem> GetNetAppQuotaLimitsAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppUsageResult> GetNetAppResourceUsage(Azure.Core.AzureLocation location, string usageType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppUsageResult>> GetNetAppResourceUsageAsync(Azure.Core.AzureLocation location, string usageType, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.NetApp.Models.NetAppUsageResult> GetNetAppResourceUsages(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.NetApp.Models.NetAppUsageResult> GetNetAppResourceUsagesAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.RegionInfoResource> GetRegionInfoResource(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.RegionInfoResource>> GetRegionInfoResourceAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.NetApp.RegionInfoResourceCollection GetRegionInfoResources(Azure.Core.AzureLocation location) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.Models.NetworkSiblingSet> QueryNetworkSiblingSetNetAppResource(Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.QueryNetworkSiblingSetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.NetworkSiblingSet>> QueryNetworkSiblingSetNetAppResourceAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.QueryNetworkSiblingSetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppRegionInfo> QueryRegionInfoNetAppResource(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.NetApp.Models.NetAppRegionInfo>> QueryRegionInfoNetAppResourceAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.Models.NetworkSiblingSet> UpdateNetworkSiblingSetNetAppResource(Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.UpdateNetworkSiblingSetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.NetApp.Models.NetworkSiblingSet>> UpdateNetworkSiblingSetNetAppResourceAsync(Azure.WaitUntil waitUntil, Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.UpdateNetworkSiblingSetContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.NetApp.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AcceptGrowCapacityPoolForShortTermCloneSplit : System.IEquatable<Azure.ResourceManager.NetApp.Models.AcceptGrowCapacityPoolForShortTermCloneSplit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AcceptGrowCapacityPoolForShortTermCloneSplit(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.AcceptGrowCapacityPoolForShortTermCloneSplit Accepted { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.AcceptGrowCapacityPoolForShortTermCloneSplit Declined { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.AcceptGrowCapacityPoolForShortTermCloneSplit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.AcceptGrowCapacityPoolForShortTermCloneSplit left, Azure.ResourceManager.NetApp.Models.AcceptGrowCapacityPoolForShortTermCloneSplit right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.AcceptGrowCapacityPoolForShortTermCloneSplit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.AcceptGrowCapacityPoolForShortTermCloneSplit left, Azure.ResourceManager.NetApp.Models.AcceptGrowCapacityPoolForShortTermCloneSplit right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmNetAppModelFactory
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.Models.AvailabilityZoneMapping AvailabilityZoneMapping(string availabilityZone = null, bool? isAvailable = default(bool?)) { throw null; }
        public static Azure.ResourceManager.NetApp.BucketData BucketData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string path = null, Azure.ResourceManager.NetApp.Models.FileSystemUser fileSystemUser = null, Azure.ResourceManager.NetApp.Models.NetAppProvisioningState? provisioningState = default(Azure.ResourceManager.NetApp.Models.NetAppProvisioningState?), Azure.ResourceManager.NetApp.Models.CredentialsStatus? status = default(Azure.ResourceManager.NetApp.Models.CredentialsStatus?), Azure.ResourceManager.NetApp.Models.BucketServerProperties server = null, Azure.ResourceManager.NetApp.Models.BucketPermission? permissions = default(Azure.ResourceManager.NetApp.Models.BucketPermission?)) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.BucketGenerateCredentials BucketGenerateCredentials(string accessKey = null, string secretKey = null, System.DateTimeOffset? keyPairExpiry = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.BucketPatch BucketPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string path = null, Azure.ResourceManager.NetApp.Models.FileSystemUser fileSystemUser = null, Azure.ResourceManager.NetApp.Models.NetAppProvisioningState? provisioningState = default(Azure.ResourceManager.NetApp.Models.NetAppProvisioningState?), Azure.ResourceManager.NetApp.Models.BucketServerPatchProperties server = null, Azure.ResourceManager.NetApp.Models.BucketPatchPermission? permissions = default(Azure.ResourceManager.NetApp.Models.BucketPatchPermission?)) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.BucketServerProperties BucketServerProperties(string fqdn = null, string certificateCommonName = null, System.DateTimeOffset? certificateExpiryOn = default(System.DateTimeOffset?), string ipAddress = null, string certificateObject = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.CapacityPoolData CapacityPoolData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ETag? etag, System.Guid? poolId, long size, Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel serviceLevel, string provisioningState, float? totalThroughputMibps, float? utilizedThroughputMibps, Azure.ResourceManager.NetApp.Models.CapacityPoolQosType? qosType, bool? isCoolAccessEnabled, Azure.ResourceManager.NetApp.Models.CapacityPoolEncryptionType? encryptionType) { throw null; }
        public static Azure.ResourceManager.NetApp.CapacityPoolData CapacityPoolData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), System.Guid? poolId = default(System.Guid?), long size = (long)0, Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel serviceLevel = default(Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel), string provisioningState = null, float? totalThroughputMibps = default(float?), float? utilizedThroughputMibps = default(float?), float? customThroughputMibps = default(float?), Azure.ResourceManager.NetApp.Models.CapacityPoolQosType? qosType = default(Azure.ResourceManager.NetApp.Models.CapacityPoolQosType?), bool? isCoolAccessEnabled = default(bool?), Azure.ResourceManager.NetApp.Models.CapacityPoolEncryptionType? encryptionType = default(Azure.ResourceManager.NetApp.Models.CapacityPoolEncryptionType?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.Models.CapacityPoolPatch CapacityPoolPatch(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, long? size, Azure.ResourceManager.NetApp.Models.CapacityPoolQosType? qosType, bool? isCoolAccessEnabled) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.CapacityPoolPatch CapacityPoolPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), long? size = default(long?), Azure.ResourceManager.NetApp.Models.CapacityPoolQosType? qosType = default(Azure.ResourceManager.NetApp.Models.CapacityPoolQosType?), bool? isCoolAccessEnabled = default(bool?), float? customThroughputMibps = default(float?)) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.ClusterPeerCommandResult ClusterPeerCommandResult(string peerAcceptCommand = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.GetGroupIdListForLdapUserResult GetGroupIdListForLdapUserResult(System.Collections.Generic.IEnumerable<string> groupIdsForLdapUser = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectory NetAppAccountActiveDirectory(string activeDirectoryId = null, string username = null, string password = null, string domain = null, string dns = null, Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectoryStatus? status = default(Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectoryStatus?), string statusDetails = null, string smbServerName = null, string organizationalUnit = null, string site = null, System.Collections.Generic.IEnumerable<string> backupOperators = null, System.Collections.Generic.IEnumerable<string> administrators = null, System.Net.IPAddress kdcIP = null, string adName = null, string serverRootCACertificate = null, bool? isAesEncryptionEnabled = default(bool?), bool? isLdapSigningEnabled = default(bool?), System.Collections.Generic.IEnumerable<string> securityOperators = null, bool? isLdapOverTlsEnabled = default(bool?), bool? allowLocalNfsUsersWithLdap = default(bool?), bool? encryptDCConnections = default(bool?), Azure.ResourceManager.NetApp.Models.NetAppLdapSearchScopeConfiguration ldapSearchScope = null, string preferredServersForLdapClient = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.NetAppAccountData NetAppAccountData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ETag? etag, Azure.ResourceManager.Models.ManagedServiceIdentity identity, string provisioningState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectory> activeDirectories, Azure.ResourceManager.NetApp.Models.NetAppAccountEncryption encryption, bool? disableShowmount) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.NetAppAccountData NetAppAccountData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ETag? etag, Azure.ResourceManager.Models.ManagedServiceIdentity identity, string provisioningState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectory> activeDirectories, Azure.ResourceManager.NetApp.Models.NetAppAccountEncryption encryption, bool? disableShowmount, string nfsV4IdDomain, Azure.ResourceManager.NetApp.Models.MultiAdStatus? multiAdStatus) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppAccountData NetAppAccountData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string provisioningState = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectory> activeDirectories = null, Azure.ResourceManager.NetApp.Models.NetAppAccountEncryption encryption = null, bool? disableShowmount = default(bool?), string nfsV4IdDomain = null, Azure.ResourceManager.NetApp.Models.MultiAdStatus? multiAdStatus = default(Azure.ResourceManager.NetApp.Models.MultiAdStatus?), Azure.ResourceManager.NetApp.Models.LdapConfiguration ldapConfiguration = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.Models.NetAppAccountPatch NetAppAccountPatch(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Models.ManagedServiceIdentity identity, string provisioningState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectory> activeDirectories, Azure.ResourceManager.NetApp.Models.NetAppAccountEncryption encryption, bool? disableShowmount) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.Models.NetAppAccountPatch NetAppAccountPatch(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.Models.ManagedServiceIdentity identity, string provisioningState, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectory> activeDirectories, Azure.ResourceManager.NetApp.Models.NetAppAccountEncryption encryption, bool? disableShowmount, string nfsV4IdDomain, Azure.ResourceManager.NetApp.Models.MultiAdStatus? multiAdStatus) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppAccountPatch NetAppAccountPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, string provisioningState = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectory> activeDirectories = null, Azure.ResourceManager.NetApp.Models.NetAppAccountEncryption encryption = null, bool? disableShowmount = default(bool?), string nfsV4IdDomain = null, Azure.ResourceManager.NetApp.Models.MultiAdStatus? multiAdStatus = default(Azure.ResourceManager.NetApp.Models.MultiAdStatus?), Azure.ResourceManager.NetApp.Models.LdapConfiguration ldapConfiguration = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.NetAppBackupData NetAppBackupData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Azure.Core.AzureLocation location, string backupId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string provisioningState = null, long? size = default(long?), string label = null, Azure.ResourceManager.NetApp.Models.NetAppBackupType? backupType = default(Azure.ResourceManager.NetApp.Models.NetAppBackupType?), string failureReason = null, string volumeName = null, bool? useExistingSnapshot = default(bool?)) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppBackupData NetAppBackupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string backupId = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? snapshotCreationOn = default(System.DateTimeOffset?), System.DateTimeOffset? completionOn = default(System.DateTimeOffset?), string provisioningState = null, long? size = default(long?), string label = null, Azure.ResourceManager.NetApp.Models.NetAppBackupType? backupType = default(Azure.ResourceManager.NetApp.Models.NetAppBackupType?), string failureReason = null, Azure.Core.ResourceIdentifier volumeResourceId = null, bool? useExistingSnapshot = default(bool?), string snapshotName = null, Azure.Core.ResourceIdentifier backupPolicyArmResourceId = null, bool? isLargeVolume = default(bool?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.NetAppBackupData NetAppBackupData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string backupId, System.DateTimeOffset? createdOn, string provisioningState, long? size, string label, Azure.ResourceManager.NetApp.Models.NetAppBackupType? backupType, string failureReason, Azure.Core.ResourceIdentifier volumeResourceId, bool? useExistingSnapshot, string snapshotName, Azure.Core.ResourceIdentifier backupPolicyArmResourceId) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.NetAppBackupData NetAppBackupData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, string backupId, System.DateTimeOffset? createdOn, string provisioningState = null, long? size = default(long?), string label = null, Azure.ResourceManager.NetApp.Models.NetAppBackupType? backupType = default(Azure.ResourceManager.NetApp.Models.NetAppBackupType?), string failureReason = null, Azure.Core.ResourceIdentifier volumeResourceId = null, bool? useExistingSnapshot = default(bool?), string snapshotName = null, string backupPolicyResourceId = null) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppBackupPolicyData NetAppBackupPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.Core.ResourceIdentifier backupPolicyId = null, string provisioningState = null, int? dailyBackupsToKeep = default(int?), int? weeklyBackupsToKeep = default(int?), int? monthlyBackupsToKeep = default(int?), int? volumesAssigned = default(int?), bool? isEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupDetail> volumeBackups = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppBackupPolicyPatch NetAppBackupPolicyPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.Core.ResourceIdentifier backupPolicyId = null, string provisioningState = null, int? dailyBackupsToKeep = default(int?), int? weeklyBackupsToKeep = default(int?), int? monthlyBackupsToKeep = default(int?), int? volumesAssigned = default(int?), bool? isEnabled = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupDetail> volumeBackups = null) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppBackupVaultData NetAppBackupVaultData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppChangeKeyVault NetAppChangeKeyVault(System.Uri keyVaultUri = null, string keyName = null, Azure.Core.ResourceIdentifier keyVaultResourceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppKeyVaultPrivateEndpoint> keyVaultPrivateEndpoints = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppCheckAvailabilityResult NetAppCheckAvailabilityResult(bool? isAvailable = default(bool?), Azure.ResourceManager.NetApp.Models.NetAppNameUnavailableReason? reason = default(Azure.ResourceManager.NetApp.Models.NetAppNameUnavailableReason?), string message = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppDestinationReplication NetAppDestinationReplication(Azure.Core.ResourceIdentifier resourceId = null, Azure.ResourceManager.NetApp.Models.NetAppReplicationType? replicationType = default(Azure.ResourceManager.NetApp.Models.NetAppReplicationType?), string region = null, string zone = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.Models.NetAppEncryptionIdentity NetAppEncryptionIdentity(string principalId, string userAssignedIdentity) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppEncryptionIdentity NetAppEncryptionIdentity(string principalId = null, string userAssignedIdentity = null, string federatedClientId = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppFilePathAvailabilityContent NetAppFilePathAvailabilityContent(string name = null, Azure.Core.ResourceIdentifier subnetId = null, string availabilityZone = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppKeyVaultProperties NetAppKeyVaultProperties(string keyVaultId = null, System.Uri keyVaultUri = null, string keyName = null, Azure.Core.ResourceIdentifier keyVaultArmResourceId = null, Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus? status = default(Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus?)) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppKeyVaultProperties NetAppKeyVaultProperties(string keyVaultId = null, System.Uri keyVaultUri = null, string keyName = null, string keyVaultResourceId = null, Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus? status = default(Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus?)) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatusResult NetAppKeyVaultStatusResult(System.Uri keyVaultUri = null, string keyName = null, Azure.Core.ResourceIdentifier keyVaultResourceId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppKeyVaultPrivateEndpoint> keyVaultPrivateEndpoints = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppRegionInfo NetAppRegionInfo(Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity? storageToNetworkProximity = default(Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.AvailabilityZoneMapping> availabilityZoneMappings = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.Models.NetAppReplicationObject NetAppReplicationObject(string replicationId, Azure.ResourceManager.NetApp.Models.NetAppEndpointType? endpointType, Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule? replicationSchedule, Azure.Core.ResourceIdentifier remoteVolumeResourceId, Azure.ResourceManager.NetApp.Models.RemotePath remotePath, string remoteVolumeRegion) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.Models.NetAppReplicationObject NetAppReplicationObject(string replicationId, Azure.ResourceManager.NetApp.Models.NetAppEndpointType? endpointType, Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule? replicationSchedule, Azure.Core.ResourceIdentifier remoteVolumeResourceId, Azure.ResourceManager.NetApp.Models.RemotePath remotePath, string remoteVolumeRegion, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppDestinationReplication> destinationReplications) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppReplicationObject NetAppReplicationObject(string replicationId = null, Azure.ResourceManager.NetApp.Models.NetAppEndpointType? endpointType = default(Azure.ResourceManager.NetApp.Models.NetAppEndpointType?), Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule? replicationSchedule = default(Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule?), Azure.Core.ResourceIdentifier remoteVolumeResourceId = null, Azure.ResourceManager.NetApp.Models.RemotePath remotePath = null, string remoteVolumeRegion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppDestinationReplication> destinationReplications = null, Azure.ResourceManager.NetApp.Models.ExternalReplicationSetupStatus? externalReplicationSetupStatus = default(Azure.ResourceManager.NetApp.Models.ExternalReplicationSetupStatus?), string externalReplicationSetupInfo = null, Azure.ResourceManager.NetApp.Models.NetAppMirrorState? mirrorState = default(Azure.ResourceManager.NetApp.Models.NetAppMirrorState?), Azure.ResourceManager.NetApp.Models.VolumeReplicationRelationshipStatus? relationshipStatus = default(Azure.ResourceManager.NetApp.Models.VolumeReplicationRelationshipStatus?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.Models.NetAppReplicationObject NetAppReplicationObject(string replicationId, Azure.ResourceManager.NetApp.Models.NetAppEndpointType? endpointType, Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule? replicationSchedule, Azure.Core.ResourceIdentifier remoteVolumeResourceId, string remoteVolumeRegion) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppRestoreStatus NetAppRestoreStatus(bool? isHealthy = default(bool?), Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus? relationshipStatus = default(Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus?), Azure.ResourceManager.NetApp.Models.NetAppMirrorState? mirrorState = default(Azure.ResourceManager.NetApp.Models.NetAppMirrorState?), string unhealthyReason = null, string errorMessage = null, long? totalTransferBytes = default(long?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.Models.NetAppSubscriptionQuotaItem NetAppSubscriptionQuotaItem(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, int? current, int? @default) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppSubscriptionQuotaItem NetAppSubscriptionQuotaItem(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, int? current = default(int?), int? @default = default(int?), int? usage = default(int?)) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppSubvolumeInfoData NetAppSubvolumeInfoData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string path = null, long? size = default(long?), string parentPath = null, string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppSubvolumeMetadata NetAppSubvolumeMetadata(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, string path = null, string parentPath = null, long? size = default(long?), long? bytesUsed = default(long?), string permissions = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), System.DateTimeOffset? accessedOn = default(System.DateTimeOffset?), System.DateTimeOffset? modifiedOn = default(System.DateTimeOffset?), System.DateTimeOffset? changedOn = default(System.DateTimeOffset?), string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppUsageName NetAppUsageName(string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppUsageResult NetAppUsageResult(string id = null, Azure.ResourceManager.NetApp.Models.NetAppUsageName name = null, int? currentValue = default(int?), int? limit = default(int?), string unit = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupBackupRestoreFilesContent NetAppVolumeBackupBackupRestoreFilesContent(System.Collections.Generic.IEnumerable<string> fileList = null, string restoreFilePath = null, Azure.Core.ResourceIdentifier destinationVolumeId = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupDetail NetAppVolumeBackupDetail(string volumeName = null, Azure.Core.ResourceIdentifier volumeResourceId = null, int? backupsCount = default(int?), bool? isPolicyEnabled = default(bool?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupDetail NetAppVolumeBackupDetail(string volumeName, int? backupsCount, bool? isPolicyEnabled) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupStatus NetAppVolumeBackupStatus(bool? isHealthy, Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus? relationshipStatus, Azure.ResourceManager.NetApp.Models.NetAppMirrorState? mirrorState, string unhealthyReason, string errorMessage, long? lastTransferSize, string lastTransferType, long? totalTransferBytes) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupStatus NetAppVolumeBackupStatus(bool? isHealthy = default(bool?), Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus? relationshipStatus = default(Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus?), Azure.ResourceManager.NetApp.Models.NetAppMirrorState? mirrorState = default(Azure.ResourceManager.NetApp.Models.NetAppMirrorState?), string unhealthyReason = null, string errorMessage = null, long? lastTransferSize = default(long?), string lastTransferType = null, long? totalTransferBytes = default(long?), long? transferProgressBytes = default(long?)) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppVolumeData NetAppVolumeData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), System.Collections.Generic.IEnumerable<string> zones = null, System.Guid? fileSystemId = default(System.Guid?), string creationToken = null, Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel? serviceLevel = default(Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel?), long usageThreshold = (long)0, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule> exportRules = null, System.Collections.Generic.IEnumerable<string> protocolTypes = null, string provisioningState = null, string snapshotId = null, bool? deleteBaseSnapshot = default(bool?), string backupId = null, string baremetalTenantId = null, Azure.Core.ResourceIdentifier subnetId = null, Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature? networkFeatures = default(Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature?), Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature? effectiveNetworkFeatures = default(Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature?), System.Guid? networkSiblingSetId = default(System.Guid?), Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity? storageToNetworkProximity = default(Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeMountTarget> mountTargets = null, string volumeType = null, Azure.ResourceManager.NetApp.Models.NetAppVolumeDataProtection dataProtection = null, Azure.ResourceManager.NetApp.Models.AcceptGrowCapacityPoolForShortTermCloneSplit? acceptGrowCapacityPoolForShortTermCloneSplit = default(Azure.ResourceManager.NetApp.Models.AcceptGrowCapacityPoolForShortTermCloneSplit?), bool? isRestoring = default(bool?), bool? isSnapshotDirectoryVisible = default(bool?), bool? isKerberosEnabled = default(bool?), Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle? securityStyle = default(Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle?), bool? isSmbEncryptionEnabled = default(bool?), Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration? smbAccessBasedEnumeration = default(Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration?), Azure.ResourceManager.NetApp.Models.SmbNonBrowsable? smbNonBrowsable = default(Azure.ResourceManager.NetApp.Models.SmbNonBrowsable?), bool? isSmbContinuouslyAvailable = default(bool?), float? throughputMibps = default(float?), float? actualThroughputMibps = default(float?), Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource? encryptionKeySource = default(Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource?), Azure.Core.ResourceIdentifier keyVaultPrivateEndpointResourceId = null, bool? isLdapEnabled = default(bool?), Azure.ResourceManager.NetApp.Models.LdapServerType? ldapServerType = default(Azure.ResourceManager.NetApp.Models.LdapServerType?), bool? isCoolAccessEnabled = default(bool?), int? coolnessPeriod = default(int?), Azure.ResourceManager.NetApp.Models.CoolAccessRetrievalPolicy? coolAccessRetrievalPolicy = default(Azure.ResourceManager.NetApp.Models.CoolAccessRetrievalPolicy?), Azure.ResourceManager.NetApp.Models.CoolAccessTieringPolicy? coolAccessTieringPolicy = default(Azure.ResourceManager.NetApp.Models.CoolAccessTieringPolicy?), string unixPermissions = null, int? cloneProgress = default(int?), Azure.ResourceManager.NetApp.Models.NetAppFileAccessLog? fileAccessLogs = default(Azure.ResourceManager.NetApp.Models.NetAppFileAccessLog?), Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore? avsDataStore = default(Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> dataStoreResourceId = null, bool? isDefaultQuotaEnabled = default(bool?), long? defaultUserQuotaInKiBs = default(long?), long? defaultGroupQuotaInKiBs = default(long?), long? maximumNumberOfFiles = default(long?), string volumeGroupName = null, Azure.Core.ResourceIdentifier capacityPoolResourceId = null, Azure.Core.ResourceIdentifier proximityPlacementGroupId = null, string t2Network = null, string volumeSpecName = null, bool? isEncrypted = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule> placementRules = null, Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume? enableSubvolumes = default(Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume?), string provisionedAvailabilityZone = null, bool? isLargeVolume = default(bool?), Azure.Core.ResourceIdentifier originatingResourceId = null, long? inheritedSizeInBytes = default(long?), Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage? language = default(Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.NetAppVolumeData NetAppVolumeData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ETag? etag, System.Collections.Generic.IEnumerable<string> zones, System.Guid? fileSystemId, string creationToken, Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel? serviceLevel, long usageThreshold, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule> exportRules, System.Collections.Generic.IEnumerable<string> protocolTypes, string provisioningState, string snapshotId, bool? deleteBaseSnapshot, string backupId, string baremetalTenantId, Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature? networkFeatures, Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature? effectiveNetworkFeatures, System.Guid? networkSiblingSetId, Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity? storageToNetworkProximity, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeMountTarget> mountTargets, string volumeType, Azure.ResourceManager.NetApp.Models.NetAppVolumeDataProtection dataProtection, Azure.ResourceManager.NetApp.Models.AcceptGrowCapacityPoolForShortTermCloneSplit? acceptGrowCapacityPoolForShortTermCloneSplit, bool? isRestoring, bool? isSnapshotDirectoryVisible, bool? isKerberosEnabled, Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle? securityStyle, bool? isSmbEncryptionEnabled, Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration? smbAccessBasedEnumeration, Azure.ResourceManager.NetApp.Models.SmbNonBrowsable? smbNonBrowsable, bool? isSmbContinuouslyAvailable, float? throughputMibps, float? actualThroughputMibps, Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource? encryptionKeySource, Azure.Core.ResourceIdentifier keyVaultPrivateEndpointResourceId, bool? isLdapEnabled, bool? isCoolAccessEnabled, int? coolnessPeriod, Azure.ResourceManager.NetApp.Models.CoolAccessRetrievalPolicy? coolAccessRetrievalPolicy, Azure.ResourceManager.NetApp.Models.CoolAccessTieringPolicy? coolAccessTieringPolicy, string unixPermissions, int? cloneProgress, Azure.ResourceManager.NetApp.Models.NetAppFileAccessLog? fileAccessLogs, Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore? avsDataStore, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> dataStoreResourceId, bool? isDefaultQuotaEnabled, long? defaultUserQuotaInKiBs, long? defaultGroupQuotaInKiBs, long? maximumNumberOfFiles, string volumeGroupName, Azure.Core.ResourceIdentifier capacityPoolResourceId, Azure.Core.ResourceIdentifier proximityPlacementGroupId, string t2Network, string volumeSpecName, bool? isEncrypted, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule> placementRules, Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume? enableSubvolumes, string provisionedAvailabilityZone, bool? isLargeVolume, Azure.Core.ResourceIdentifier originatingResourceId, long? inheritedSizeInBytes) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.NetAppVolumeData NetAppVolumeData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ETag? etag, System.Collections.Generic.IEnumerable<string> zones, System.Guid? fileSystemId, string creationToken, Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel? serviceLevel, long usageThreshold, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule> exportRules, System.Collections.Generic.IEnumerable<string> protocolTypes, string provisioningState, string snapshotId, bool? deleteBaseSnapshot, string backupId, string baremetalTenantId, Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature? networkFeatures, Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature? effectiveNetworkFeatures, System.Guid? networkSiblingSetId, Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity? storageToNetworkProximity, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeMountTarget> mountTargets, string volumeType, Azure.ResourceManager.NetApp.Models.NetAppVolumeDataProtection dataProtection, bool? isRestoring, bool? isSnapshotDirectoryVisible, bool? isKerberosEnabled, Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle? securityStyle, bool? isSmbEncryptionEnabled, Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration? smbAccessBasedEnumeration, Azure.ResourceManager.NetApp.Models.SmbNonBrowsable? smbNonBrowsable, bool? isSmbContinuouslyAvailable, float? throughputMibps, float? actualThroughputMibps, Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource? encryptionKeySource, Azure.Core.ResourceIdentifier keyVaultPrivateEndpointResourceId, bool? isLdapEnabled, bool? isCoolAccessEnabled, int? coolnessPeriod, Azure.ResourceManager.NetApp.Models.CoolAccessRetrievalPolicy? coolAccessRetrievalPolicy, Azure.ResourceManager.NetApp.Models.CoolAccessTieringPolicy? coolAccessTieringPolicy, string unixPermissions, int? cloneProgress, Azure.ResourceManager.NetApp.Models.NetAppFileAccessLog? fileAccessLogs, Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore? avsDataStore, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> dataStoreResourceId, bool? isDefaultQuotaEnabled, long? defaultUserQuotaInKiBs, long? defaultGroupQuotaInKiBs, long? maximumNumberOfFiles, string volumeGroupName, Azure.Core.ResourceIdentifier capacityPoolResourceId, Azure.Core.ResourceIdentifier proximityPlacementGroupId, string t2Network, string volumeSpecName, bool? isEncrypted, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule> placementRules, Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume? enableSubvolumes, string provisionedAvailabilityZone, bool? isLargeVolume, Azure.Core.ResourceIdentifier originatingResourceId) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.NetAppVolumeData NetAppVolumeData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ETag? etag, System.Collections.Generic.IEnumerable<string> zones, System.Guid? fileSystemId, string creationToken, Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel? serviceLevel, long usageThreshold, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule> exportRules, System.Collections.Generic.IEnumerable<string> protocolTypes, string provisioningState, string snapshotId, bool? deleteBaseSnapshot, string backupId, string baremetalTenantId, Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature? networkFeatures, Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature? effectiveNetworkFeatures, System.Guid? networkSiblingSetId, Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity? storageToNetworkProximity, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeMountTarget> mountTargets, string volumeType, Azure.ResourceManager.NetApp.Models.NetAppVolumeDataProtection dataProtection, bool? isRestoring, bool? isSnapshotDirectoryVisible, bool? isKerberosEnabled, Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle? securityStyle, bool? isSmbEncryptionEnabled, Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration? smbAccessBasedEnumeration, Azure.ResourceManager.NetApp.Models.SmbNonBrowsable? smbNonBrowsable, bool? isSmbContinuouslyAvailable, float? throughputMibps, float? actualThroughputMibps, Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource? encryptionKeySource, Azure.Core.ResourceIdentifier keyVaultPrivateEndpointResourceId, bool? isLdapEnabled, bool? isCoolAccessEnabled, int? coolnessPeriod, Azure.ResourceManager.NetApp.Models.CoolAccessRetrievalPolicy? coolAccessRetrievalPolicy, string unixPermissions, int? cloneProgress, Azure.ResourceManager.NetApp.Models.NetAppFileAccessLog? fileAccessLogs, Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore? avsDataStore, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> dataStoreResourceId, bool? isDefaultQuotaEnabled, long? defaultUserQuotaInKiBs, long? defaultGroupQuotaInKiBs, long? maximumNumberOfFiles, string volumeGroupName, Azure.Core.ResourceIdentifier capacityPoolResourceId, Azure.Core.ResourceIdentifier proximityPlacementGroupId, string t2Network, string volumeSpecName, bool? isEncrypted, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule> placementRules, Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume? enableSubvolumes, string provisionedAvailabilityZone, bool? isLargeVolume, Azure.Core.ResourceIdentifier originatingResourceId) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.NetAppVolumeData NetAppVolumeData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ETag? etag, System.Collections.Generic.IEnumerable<string> zones, System.Guid? fileSystemId, string creationToken, Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel? serviceLevel, long usageThreshold, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule> exportRules, System.Collections.Generic.IEnumerable<string> protocolTypes, string provisioningState, string snapshotId, bool? deleteBaseSnapshot, string backupId, string baremetalTenantId, Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature? networkFeatures, System.Guid? networkSiblingSetId, Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity? storageToNetworkProximity, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeMountTarget> mountTargets, string volumeType, Azure.ResourceManager.NetApp.Models.NetAppVolumeDataProtection dataProtection, bool? isRestoring, bool? isSnapshotDirectoryVisible, bool? isKerberosEnabled, Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle? securityStyle, bool? isSmbEncryptionEnabled, Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration? smbAccessBasedEnumeration, Azure.ResourceManager.NetApp.Models.SmbNonBrowsable? smbNonBrowsable, bool? isSmbContinuouslyAvailable, float? throughputMibps, float? actualThroughputMibps, Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource? encryptionKeySource, Azure.Core.ResourceIdentifier keyVaultPrivateEndpointResourceId, bool? isLdapEnabled, bool? isCoolAccessEnabled, int? coolnessPeriod, Azure.ResourceManager.NetApp.Models.CoolAccessRetrievalPolicy? coolAccessRetrievalPolicy, string unixPermissions, int? cloneProgress, Azure.ResourceManager.NetApp.Models.NetAppFileAccessLog? fileAccessLogs, Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore? avsDataStore, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> dataStoreResourceId, bool? isDefaultQuotaEnabled, long? defaultUserQuotaInKiBs, long? defaultGroupQuotaInKiBs, long? maximumNumberOfFiles, string volumeGroupName, Azure.Core.ResourceIdentifier capacityPoolResourceId, Azure.Core.ResourceIdentifier proximityPlacementGroupId, string t2Network, string volumeSpecName, bool? isEncrypted, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule> placementRules, Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume? enableSubvolumes, string provisionedAvailabilityZone, bool? isLargeVolume, Azure.Core.ResourceIdentifier originatingResourceId) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.NetAppVolumeData NetAppVolumeData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ETag? etag, System.Collections.Generic.IEnumerable<string> zones, System.Guid? fileSystemId, string creationToken, Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel? serviceLevel, long usageThreshold, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule> exportRules, System.Collections.Generic.IEnumerable<string> protocolTypes, string provisioningState, string snapshotId, bool? deleteBaseSnapshot, string backupId, string baremetalTenantId, Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature? networkFeatures, System.Guid? networkSiblingSetId, Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity? storageToNetworkProximity, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeMountTarget> mountTargets, string volumeType, Azure.ResourceManager.NetApp.Models.NetAppVolumeDataProtection dataProtection, bool? isRestoring, bool? isSnapshotDirectoryVisible, bool? isKerberosEnabled, Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle? securityStyle, bool? isSmbEncryptionEnabled, Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration? smbAccessBasedEnumeration, Azure.ResourceManager.NetApp.Models.SmbNonBrowsable? smbNonBrowsable, bool? isSmbContinuouslyAvailable, float? throughputMibps, float? actualThroughputMibps, Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource? encryptionKeySource, Azure.Core.ResourceIdentifier keyVaultPrivateEndpointResourceId, bool? isLdapEnabled, bool? isCoolAccessEnabled, int? coolnessPeriod, string unixPermissions, int? cloneProgress, Azure.ResourceManager.NetApp.Models.NetAppFileAccessLog? fileAccessLogs, Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore? avsDataStore, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> dataStoreResourceId, bool? isDefaultQuotaEnabled, long? defaultUserQuotaInKiBs, long? defaultGroupQuotaInKiBs, long? maximumNumberOfFiles, string volumeGroupName, Azure.Core.ResourceIdentifier capacityPoolResourceId, Azure.Core.ResourceIdentifier proximityPlacementGroupId, string t2Network, string volumeSpecName, bool? isEncrypted, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule> placementRules, Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume? enableSubvolumes, string provisionedAvailabilityZone, bool? isLargeVolume, Azure.Core.ResourceIdentifier originatingResourceId) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppVolumeGroupData NetAppVolumeGroupData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string provisioningState = null, Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupMetadata groupMetaData = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupVolume> volumes = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupMetadata NetAppVolumeGroupMetadata(string groupDescription = null, Azure.ResourceManager.NetApp.Models.NetAppApplicationType? applicationType = default(Azure.ResourceManager.NetApp.Models.NetAppApplicationType?), string applicationIdentifier = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule> globalPlacementRules = null, long? volumesCount = default(long?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupMetadata NetAppVolumeGroupMetadata(string groupDescription, Azure.ResourceManager.NetApp.Models.NetAppApplicationType? applicationType, string applicationIdentifier, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule> globalPlacementRules, string deploymentSpecId, long? volumesCount) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupResult NetAppVolumeGroupResult(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation? location = default(Azure.Core.AzureLocation?), string provisioningState = null, Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupMetadata groupMetaData = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupVolume NetAppVolumeGroupVolume(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), System.Collections.Generic.IDictionary<string, string> tags = null, System.Collections.Generic.IEnumerable<string> zones = null, System.Guid? fileSystemId = default(System.Guid?), string creationToken = null, Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel? serviceLevel = default(Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel?), long usageThreshold = (long)0, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule> exportRules = null, System.Collections.Generic.IEnumerable<string> protocolTypes = null, string provisioningState = null, string snapshotId = null, bool? deleteBaseSnapshot = default(bool?), string backupId = null, string baremetalTenantId = null, Azure.Core.ResourceIdentifier subnetId = null, Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature? networkFeatures = default(Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature?), Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature? effectiveNetworkFeatures = default(Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature?), System.Guid? networkSiblingSetId = default(System.Guid?), Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity? storageToNetworkProximity = default(Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeMountTarget> mountTargets = null, string volumeType = null, Azure.ResourceManager.NetApp.Models.NetAppVolumeDataProtection dataProtection = null, Azure.ResourceManager.NetApp.Models.AcceptGrowCapacityPoolForShortTermCloneSplit? acceptGrowCapacityPoolForShortTermCloneSplit = default(Azure.ResourceManager.NetApp.Models.AcceptGrowCapacityPoolForShortTermCloneSplit?), bool? isRestoring = default(bool?), bool? isSnapshotDirectoryVisible = default(bool?), bool? isKerberosEnabled = default(bool?), Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle? securityStyle = default(Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle?), bool? isSmbEncryptionEnabled = default(bool?), Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration? smbAccessBasedEnumeration = default(Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration?), Azure.ResourceManager.NetApp.Models.SmbNonBrowsable? smbNonBrowsable = default(Azure.ResourceManager.NetApp.Models.SmbNonBrowsable?), bool? isSmbContinuouslyAvailable = default(bool?), float? throughputMibps = default(float?), float? actualThroughputMibps = default(float?), Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource? encryptionKeySource = default(Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource?), Azure.Core.ResourceIdentifier keyVaultPrivateEndpointResourceId = null, bool? isLdapEnabled = default(bool?), Azure.ResourceManager.NetApp.Models.LdapServerType? ldapServerType = default(Azure.ResourceManager.NetApp.Models.LdapServerType?), bool? isCoolAccessEnabled = default(bool?), int? coolnessPeriod = default(int?), Azure.ResourceManager.NetApp.Models.CoolAccessRetrievalPolicy? coolAccessRetrievalPolicy = default(Azure.ResourceManager.NetApp.Models.CoolAccessRetrievalPolicy?), Azure.ResourceManager.NetApp.Models.CoolAccessTieringPolicy? coolAccessTieringPolicy = default(Azure.ResourceManager.NetApp.Models.CoolAccessTieringPolicy?), string unixPermissions = null, int? cloneProgress = default(int?), Azure.ResourceManager.NetApp.Models.NetAppFileAccessLog? fileAccessLogs = default(Azure.ResourceManager.NetApp.Models.NetAppFileAccessLog?), Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore? avsDataStore = default(Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore?), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> dataStoreResourceId = null, bool? isDefaultQuotaEnabled = default(bool?), long? defaultUserQuotaInKiBs = default(long?), long? defaultGroupQuotaInKiBs = default(long?), long? maximumNumberOfFiles = default(long?), string volumeGroupName = null, Azure.Core.ResourceIdentifier capacityPoolResourceId = null, Azure.Core.ResourceIdentifier proximityPlacementGroupId = null, string t2Network = null, string volumeSpecName = null, bool? isEncrypted = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule> placementRules = null, Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume? enableSubvolumes = default(Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume?), string provisionedAvailabilityZone = null, bool? isLargeVolume = default(bool?), Azure.Core.ResourceIdentifier originatingResourceId = null, long? inheritedSizeInBytes = default(long?), Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage? language = default(Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupVolume NetAppVolumeGroupVolume(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType? resourceType, System.Collections.Generic.IDictionary<string, string> tags, System.Collections.Generic.IEnumerable<string> zones, System.Guid? fileSystemId, string creationToken, Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel? serviceLevel, long usageThreshold, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule> exportRules, System.Collections.Generic.IEnumerable<string> protocolTypes, string provisioningState, string snapshotId, bool? deleteBaseSnapshot, string backupId, string baremetalTenantId, Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature? networkFeatures, Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature? effectiveNetworkFeatures, System.Guid? networkSiblingSetId, Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity? storageToNetworkProximity, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeMountTarget> mountTargets, string volumeType, Azure.ResourceManager.NetApp.Models.NetAppVolumeDataProtection dataProtection, Azure.ResourceManager.NetApp.Models.AcceptGrowCapacityPoolForShortTermCloneSplit? acceptGrowCapacityPoolForShortTermCloneSplit, bool? isRestoring, bool? isSnapshotDirectoryVisible, bool? isKerberosEnabled, Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle? securityStyle, bool? isSmbEncryptionEnabled, Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration? smbAccessBasedEnumeration, Azure.ResourceManager.NetApp.Models.SmbNonBrowsable? smbNonBrowsable, bool? isSmbContinuouslyAvailable, float? throughputMibps, float? actualThroughputMibps, Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource? encryptionKeySource, Azure.Core.ResourceIdentifier keyVaultPrivateEndpointResourceId, bool? isLdapEnabled, bool? isCoolAccessEnabled, int? coolnessPeriod, Azure.ResourceManager.NetApp.Models.CoolAccessRetrievalPolicy? coolAccessRetrievalPolicy, Azure.ResourceManager.NetApp.Models.CoolAccessTieringPolicy? coolAccessTieringPolicy, string unixPermissions, int? cloneProgress, Azure.ResourceManager.NetApp.Models.NetAppFileAccessLog? fileAccessLogs, Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore? avsDataStore, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> dataStoreResourceId, bool? isDefaultQuotaEnabled, long? defaultUserQuotaInKiBs, long? defaultGroupQuotaInKiBs, long? maximumNumberOfFiles, string volumeGroupName, Azure.Core.ResourceIdentifier capacityPoolResourceId, Azure.Core.ResourceIdentifier proximityPlacementGroupId, string t2Network, string volumeSpecName, bool? isEncrypted, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule> placementRules, Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume? enableSubvolumes, string provisionedAvailabilityZone, bool? isLargeVolume, Azure.Core.ResourceIdentifier originatingResourceId, long? inheritedSizeInBytes) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupVolume NetAppVolumeGroupVolume(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType? resourceType, System.Collections.Generic.IDictionary<string, string> tags, System.Collections.Generic.IEnumerable<string> zones, System.Guid? fileSystemId, string creationToken, Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel? serviceLevel, long usageThreshold, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule> exportRules, System.Collections.Generic.IEnumerable<string> protocolTypes, string provisioningState, string snapshotId, bool? deleteBaseSnapshot, string backupId, string baremetalTenantId, Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature? networkFeatures, Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature? effectiveNetworkFeatures, System.Guid? networkSiblingSetId, Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity? storageToNetworkProximity, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeMountTarget> mountTargets, string volumeType, Azure.ResourceManager.NetApp.Models.NetAppVolumeDataProtection dataProtection, bool? isRestoring, bool? isSnapshotDirectoryVisible, bool? isKerberosEnabled, Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle? securityStyle, bool? isSmbEncryptionEnabled, Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration? smbAccessBasedEnumeration, Azure.ResourceManager.NetApp.Models.SmbNonBrowsable? smbNonBrowsable, bool? isSmbContinuouslyAvailable, float? throughputMibps, float? actualThroughputMibps, Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource? encryptionKeySource, Azure.Core.ResourceIdentifier keyVaultPrivateEndpointResourceId, bool? isLdapEnabled, bool? isCoolAccessEnabled, int? coolnessPeriod, Azure.ResourceManager.NetApp.Models.CoolAccessRetrievalPolicy? coolAccessRetrievalPolicy, Azure.ResourceManager.NetApp.Models.CoolAccessTieringPolicy? coolAccessTieringPolicy, string unixPermissions, int? cloneProgress, Azure.ResourceManager.NetApp.Models.NetAppFileAccessLog? fileAccessLogs, Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore? avsDataStore, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> dataStoreResourceId, bool? isDefaultQuotaEnabled, long? defaultUserQuotaInKiBs, long? defaultGroupQuotaInKiBs, long? maximumNumberOfFiles, string volumeGroupName, Azure.Core.ResourceIdentifier capacityPoolResourceId, Azure.Core.ResourceIdentifier proximityPlacementGroupId, string t2Network, string volumeSpecName, bool? isEncrypted, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule> placementRules, Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume? enableSubvolumes, string provisionedAvailabilityZone, bool? isLargeVolume, Azure.Core.ResourceIdentifier originatingResourceId) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupVolume NetAppVolumeGroupVolume(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType? resourceType, System.Collections.Generic.IDictionary<string, string> tags, System.Collections.Generic.IEnumerable<string> zones, System.Guid? fileSystemId, string creationToken, Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel? serviceLevel, long usageThreshold, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule> exportRules, System.Collections.Generic.IEnumerable<string> protocolTypes, string provisioningState, string snapshotId, bool? deleteBaseSnapshot, string backupId, string baremetalTenantId, Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature? networkFeatures, Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature? effectiveNetworkFeatures, System.Guid? networkSiblingSetId, Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity? storageToNetworkProximity, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeMountTarget> mountTargets, string volumeType, Azure.ResourceManager.NetApp.Models.NetAppVolumeDataProtection dataProtection, bool? isRestoring, bool? isSnapshotDirectoryVisible, bool? isKerberosEnabled, Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle? securityStyle, bool? isSmbEncryptionEnabled, Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration? smbAccessBasedEnumeration, Azure.ResourceManager.NetApp.Models.SmbNonBrowsable? smbNonBrowsable, bool? isSmbContinuouslyAvailable, float? throughputMibps, float? actualThroughputMibps, Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource? encryptionKeySource, Azure.Core.ResourceIdentifier keyVaultPrivateEndpointResourceId, bool? isLdapEnabled, bool? isCoolAccessEnabled, int? coolnessPeriod, Azure.ResourceManager.NetApp.Models.CoolAccessRetrievalPolicy? coolAccessRetrievalPolicy, string unixPermissions, int? cloneProgress, Azure.ResourceManager.NetApp.Models.NetAppFileAccessLog? fileAccessLogs, Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore? avsDataStore, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> dataStoreResourceId, bool? isDefaultQuotaEnabled, long? defaultUserQuotaInKiBs, long? defaultGroupQuotaInKiBs, long? maximumNumberOfFiles, string volumeGroupName, Azure.Core.ResourceIdentifier capacityPoolResourceId, Azure.Core.ResourceIdentifier proximityPlacementGroupId, string t2Network, string volumeSpecName, bool? isEncrypted, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule> placementRules, Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume? enableSubvolumes, string provisionedAvailabilityZone, bool? isLargeVolume, Azure.Core.ResourceIdentifier originatingResourceId) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupVolume NetAppVolumeGroupVolume(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType? resourceType, System.Collections.Generic.IDictionary<string, string> tags, System.Collections.Generic.IEnumerable<string> zones, System.Guid? fileSystemId, string creationToken, Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel? serviceLevel, long usageThreshold, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule> exportRules, System.Collections.Generic.IEnumerable<string> protocolTypes, string provisioningState, string snapshotId, bool? deleteBaseSnapshot, string backupId, string baremetalTenantId, Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature? networkFeatures, System.Guid? networkSiblingSetId, Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity? storageToNetworkProximity, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeMountTarget> mountTargets, string volumeType, Azure.ResourceManager.NetApp.Models.NetAppVolumeDataProtection dataProtection, bool? isRestoring, bool? isSnapshotDirectoryVisible, bool? isKerberosEnabled, Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle? securityStyle, bool? isSmbEncryptionEnabled, Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration? smbAccessBasedEnumeration, Azure.ResourceManager.NetApp.Models.SmbNonBrowsable? smbNonBrowsable, bool? isSmbContinuouslyAvailable, float? throughputMibps, float? actualThroughputMibps, Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource? encryptionKeySource, Azure.Core.ResourceIdentifier keyVaultPrivateEndpointResourceId, bool? isLdapEnabled, bool? isCoolAccessEnabled, int? coolnessPeriod, Azure.ResourceManager.NetApp.Models.CoolAccessRetrievalPolicy? coolAccessRetrievalPolicy, string unixPermissions, int? cloneProgress, Azure.ResourceManager.NetApp.Models.NetAppFileAccessLog? fileAccessLogs, Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore? avsDataStore, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> dataStoreResourceId, bool? isDefaultQuotaEnabled, long? defaultUserQuotaInKiBs, long? defaultGroupQuotaInKiBs, long? maximumNumberOfFiles, string volumeGroupName, Azure.Core.ResourceIdentifier capacityPoolResourceId, Azure.Core.ResourceIdentifier proximityPlacementGroupId, string t2Network, string volumeSpecName, bool? isEncrypted, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule> placementRules, Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume? enableSubvolumes, string provisionedAvailabilityZone, bool? isLargeVolume, Azure.Core.ResourceIdentifier originatingResourceId) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupVolume NetAppVolumeGroupVolume(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType? resourceType, System.Collections.Generic.IDictionary<string, string> tags, System.Guid? fileSystemId, string creationToken, Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel? serviceLevel, long usageThreshold, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule> exportRules, System.Collections.Generic.IEnumerable<string> protocolTypes, string provisioningState, string snapshotId, bool? deleteBaseSnapshot, string backupId, string baremetalTenantId, Azure.Core.ResourceIdentifier subnetId, Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature? networkFeatures, System.Guid? networkSiblingSetId, Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity? storageToNetworkProximity, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeMountTarget> mountTargets, string volumeType, Azure.ResourceManager.NetApp.Models.NetAppVolumeDataProtection dataProtection, bool? isRestoring, bool? isSnapshotDirectoryVisible, bool? isKerberosEnabled, Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle? securityStyle, bool? isSmbEncryptionEnabled, Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration? smbAccessBasedEnumeration, Azure.ResourceManager.NetApp.Models.SmbNonBrowsable? smbNonBrowsable, bool? isSmbContinuouslyAvailable, float? throughputMibps, float? actualThroughputMibps, Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource? encryptionKeySource, Azure.Core.ResourceIdentifier keyVaultPrivateEndpointResourceId, bool? isLdapEnabled, bool? isCoolAccessEnabled, int? coolnessPeriod, string unixPermissions, int? cloneProgress, Azure.ResourceManager.NetApp.Models.NetAppFileAccessLog? fileAccessLogs, Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore? avsDataStore, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> dataStoreResourceId, bool? isDefaultQuotaEnabled, long? defaultUserQuotaInKiBs, long? defaultGroupQuotaInKiBs, long? maximumNumberOfFiles, string volumeGroupName, Azure.Core.ResourceIdentifier capacityPoolResourceId, Azure.Core.ResourceIdentifier proximityPlacementGroupId, string t2Network, string volumeSpecName, bool? isEncrypted, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule> placementRules, Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume? enableSubvolumes, string provisionedAvailabilityZone, bool? isLargeVolume, Azure.Core.ResourceIdentifier originatingResourceId) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeMountTarget NetAppVolumeMountTarget(System.Guid? mountTargetId = default(System.Guid?), System.Guid fileSystemId = default(System.Guid), System.Net.IPAddress ipAddress = null, string smbServerFqdn = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumePatch NetAppVolumePatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel? serviceLevel = default(Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel?), long? usageThreshold = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule> exportRules = null, System.Collections.Generic.IEnumerable<string> protocolTypes = null, float? throughputMibps = default(float?), Azure.ResourceManager.NetApp.Models.NetAppVolumePatchDataProtection dataProtection = null, bool? isDefaultQuotaEnabled = default(bool?), long? defaultUserQuotaInKiBs = default(long?), long? defaultGroupQuotaInKiBs = default(long?), string unixPermissions = null, bool? isCoolAccessEnabled = default(bool?), int? coolnessPeriod = default(int?), Azure.ResourceManager.NetApp.Models.CoolAccessRetrievalPolicy? coolAccessRetrievalPolicy = default(Azure.ResourceManager.NetApp.Models.CoolAccessRetrievalPolicy?), Azure.ResourceManager.NetApp.Models.CoolAccessTieringPolicy? coolAccessTieringPolicy = default(Azure.ResourceManager.NetApp.Models.CoolAccessTieringPolicy?), bool? isSnapshotDirectoryVisible = default(bool?), Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration? smbAccessBasedEnumeration = default(Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration?), Azure.ResourceManager.NetApp.Models.SmbNonBrowsable? smbNonBrowsable = default(Azure.ResourceManager.NetApp.Models.SmbNonBrowsable?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumePatch NetAppVolumePatch(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, System.Collections.Generic.IDictionary<string, string> tags, Azure.Core.AzureLocation location, Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel? serviceLevel, long? usageThreshold, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule> exportRules, System.Collections.Generic.IEnumerable<string> protocolTypes, float? throughputMibps, Azure.ResourceManager.NetApp.Models.NetAppVolumePatchDataProtection dataProtection, bool? isDefaultQuotaEnabled, long? defaultUserQuotaInKiBs, long? defaultGroupQuotaInKiBs, string unixPermissions, bool? isCoolAccessEnabled, int? coolnessPeriod, Azure.ResourceManager.NetApp.Models.CoolAccessRetrievalPolicy? coolAccessRetrievalPolicy, bool? isSnapshotDirectoryVisible, Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration? smbAccessBasedEnumeration, Azure.ResourceManager.NetApp.Models.SmbNonBrowsable? smbNonBrowsable) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumePatch NetAppVolumePatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel? serviceLevel = default(Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel?), long? usageThreshold = default(long?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule> exportRules = null, float? throughputMibps = default(float?), Azure.Core.ResourceIdentifier snapshotPolicyId = null, bool? isDefaultQuotaEnabled = default(bool?), long? defaultUserQuotaInKiBs = default(long?), long? defaultGroupQuotaInKiBs = default(long?), string unixPermissions = null, bool? isCoolAccessEnabled = default(bool?), int? coolnessPeriod = default(int?), Azure.ResourceManager.NetApp.Models.CoolAccessRetrievalPolicy? coolAccessRetrievalPolicy = default(Azure.ResourceManager.NetApp.Models.CoolAccessRetrievalPolicy?), bool? isSnapshotDirectoryVisible = default(bool?), Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration? smbAccessBasedEnumeration = default(Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration?), Azure.ResourceManager.NetApp.Models.SmbNonBrowsable? smbNonBrowsable = default(Azure.ResourceManager.NetApp.Models.SmbNonBrowsable?)) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaReport NetAppVolumeQuotaReport(Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType? quotaType = default(Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType?), string quotaTarget = null, long? quotaLimitUsedInKiBs = default(long?), long? quotaLimitTotalInKiBs = default(long?), float? percentageUsed = default(float?), bool? isDerivedQuota = default(bool?)) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaReportListResult NetAppVolumeQuotaReportListResult(System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaReport> value = null) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppVolumeQuotaRuleData NetAppVolumeQuotaRuleData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetApp.Models.NetAppProvisioningState? provisioningState = default(Azure.ResourceManager.NetApp.Models.NetAppProvisioningState?), long? quotaSizeInKiBs = default(long?), Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType? quotaType = default(Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType?), string quotaTarget = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaRulePatch NetAppVolumeQuotaRulePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.NetApp.Models.NetAppProvisioningState? provisioningState = default(Azure.ResourceManager.NetApp.Models.NetAppProvisioningState?), long? quotaSizeInKiBs = default(long?), Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType? quotaType = default(Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType?), string quotaTarget = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeRelocationProperties NetAppVolumeRelocationProperties(bool? isRelocationRequested = default(bool?), bool? isReadyToBeFinalized = default(bool?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeReplication NetAppVolumeReplication(Azure.ResourceManager.NetApp.Models.NetAppEndpointType? endpointType, Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule? replicationSchedule, Azure.Core.ResourceIdentifier remoteVolumeResourceId, string remoteVolumeRegion) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeReplication NetAppVolumeReplication(string replicationId = null, Azure.ResourceManager.NetApp.Models.NetAppEndpointType? endpointType = default(Azure.ResourceManager.NetApp.Models.NetAppEndpointType?), Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule? replicationSchedule = default(Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule?), Azure.Core.ResourceIdentifier remoteVolumeResourceId = null, string remoteVolumeRegion = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeReplicationStatus NetAppVolumeReplicationStatus(bool? isHealthy = default(bool?), Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus? relationshipStatus = default(Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus?), Azure.ResourceManager.NetApp.Models.NetAppMirrorState? mirrorState = default(Azure.ResourceManager.NetApp.Models.NetAppMirrorState?), string totalProgress = null, string errorMessage = null) { throw null; }
        public static Azure.ResourceManager.NetApp.NetAppVolumeSnapshotData NetAppVolumeSnapshotData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string snapshotId = null, System.DateTimeOffset? created = default(System.DateTimeOffset?), string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetworkSiblingSet NetworkSiblingSet(string networkSiblingSetId = null, Azure.Core.ResourceIdentifier subnetId = null, string networkSiblingSetStateId = null, Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature? networkFeatures = default(Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature?), Azure.ResourceManager.NetApp.Models.NetworkSiblingSetProvisioningState? provisioningState = default(Azure.ResourceManager.NetApp.Models.NetworkSiblingSetProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NicInfo> nicInfoList = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NicInfo NicInfo(string ipAddress = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> volumeResourceIds = null) { throw null; }
        public static Azure.ResourceManager.NetApp.RegionInfoResourceData RegionInfoResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity? storageToNetworkProximity = default(Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.AvailabilityZoneMapping> availabilityZoneMappings = null) { throw null; }
        public static Azure.ResourceManager.NetApp.SnapshotPolicyData SnapshotPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ETag? etag = default(Azure.ETag?), Azure.ResourceManager.NetApp.Models.SnapshotPolicyHourlySchedule hourlySchedule = null, Azure.ResourceManager.NetApp.Models.SnapshotPolicyDailySchedule dailySchedule = null, Azure.ResourceManager.NetApp.Models.SnapshotPolicyWeeklySchedule weeklySchedule = null, Azure.ResourceManager.NetApp.Models.SnapshotPolicyMonthlySchedule monthlySchedule = null, bool? isEnabled = default(bool?), string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.SnapshotPolicyPatch SnapshotPolicyPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.NetApp.Models.SnapshotPolicyHourlySchedule hourlySchedule = null, Azure.ResourceManager.NetApp.Models.SnapshotPolicyDailySchedule dailySchedule = null, Azure.ResourceManager.NetApp.Models.SnapshotPolicyWeeklySchedule weeklySchedule = null, Azure.ResourceManager.NetApp.Models.SnapshotPolicyMonthlySchedule monthlySchedule = null, bool? isEnabled = default(bool?), string provisioningState = null) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.SvmPeerCommandResult SvmPeerCommandResult(string svmPeeringCommand = null) { throw null; }
    }
    public partial class AvailabilityZoneMapping : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.AvailabilityZoneMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.AvailabilityZoneMapping>
    {
        public AvailabilityZoneMapping() { }
        public string AvailabilityZone { get { throw null; } set { } }
        public bool? IsAvailable { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.AvailabilityZoneMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.AvailabilityZoneMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.AvailabilityZoneMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.AvailabilityZoneMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.AvailabilityZoneMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.AvailabilityZoneMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.AvailabilityZoneMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupsMigrationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.BackupsMigrationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.BackupsMigrationContent>
    {
        public BackupsMigrationContent(string backupVaultId) { }
        public string BackupVaultId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.BackupsMigrationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.BackupsMigrationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.BackupsMigrationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.BackupsMigrationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.BackupsMigrationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.BackupsMigrationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.BackupsMigrationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BucketCredentialsExpiry : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.BucketCredentialsExpiry>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.BucketCredentialsExpiry>
    {
        public BucketCredentialsExpiry() { }
        public int? KeyPairExpiryDays { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.BucketCredentialsExpiry System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.BucketCredentialsExpiry>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.BucketCredentialsExpiry>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.BucketCredentialsExpiry System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.BucketCredentialsExpiry>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.BucketCredentialsExpiry>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.BucketCredentialsExpiry>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BucketGenerateCredentials : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.BucketGenerateCredentials>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.BucketGenerateCredentials>
    {
        internal BucketGenerateCredentials() { }
        public string AccessKey { get { throw null; } }
        public System.DateTimeOffset? KeyPairExpiry { get { throw null; } }
        public string SecretKey { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.BucketGenerateCredentials System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.BucketGenerateCredentials>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.BucketGenerateCredentials>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.BucketGenerateCredentials System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.BucketGenerateCredentials>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.BucketGenerateCredentials>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.BucketGenerateCredentials>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BucketPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.BucketPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.BucketPatch>
    {
        public BucketPatch() { }
        public Azure.ResourceManager.NetApp.Models.FileSystemUser FileSystemUser { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.BucketPatchPermission? Permissions { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.BucketServerPatchProperties Server { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.BucketPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.BucketPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.BucketPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.BucketPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.BucketPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.BucketPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.BucketPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BucketPatchPermission : System.IEquatable<Azure.ResourceManager.NetApp.Models.BucketPatchPermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BucketPatchPermission(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.BucketPatchPermission ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.BucketPatchPermission ReadWrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.BucketPatchPermission other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.BucketPatchPermission left, Azure.ResourceManager.NetApp.Models.BucketPatchPermission right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.BucketPatchPermission (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.BucketPatchPermission left, Azure.ResourceManager.NetApp.Models.BucketPatchPermission right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BucketPermission : System.IEquatable<Azure.ResourceManager.NetApp.Models.BucketPermission>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BucketPermission(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.BucketPermission ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.BucketPermission ReadWrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.BucketPermission other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.BucketPermission left, Azure.ResourceManager.NetApp.Models.BucketPermission right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.BucketPermission (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.BucketPermission left, Azure.ResourceManager.NetApp.Models.BucketPermission right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BucketServerPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.BucketServerPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.BucketServerPatchProperties>
    {
        public BucketServerPatchProperties() { }
        public string CertificateObject { get { throw null; } set { } }
        public string Fqdn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.BucketServerPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.BucketServerPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.BucketServerPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.BucketServerPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.BucketServerPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.BucketServerPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.BucketServerPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BucketServerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.BucketServerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.BucketServerProperties>
    {
        public BucketServerProperties() { }
        public string CertificateCommonName { get { throw null; } }
        public System.DateTimeOffset? CertificateExpiryOn { get { throw null; } }
        public string CertificateObject { get { throw null; } set { } }
        public string Fqdn { get { throw null; } set { } }
        public string IPAddress { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.BucketServerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.BucketServerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.BucketServerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.BucketServerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.BucketServerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.BucketServerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.BucketServerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CapacityPoolEncryptionType : System.IEquatable<Azure.ResourceManager.NetApp.Models.CapacityPoolEncryptionType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CapacityPoolEncryptionType(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.CapacityPoolEncryptionType Double { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.CapacityPoolEncryptionType Single { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.CapacityPoolEncryptionType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.CapacityPoolEncryptionType left, Azure.ResourceManager.NetApp.Models.CapacityPoolEncryptionType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.CapacityPoolEncryptionType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.CapacityPoolEncryptionType left, Azure.ResourceManager.NetApp.Models.CapacityPoolEncryptionType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CapacityPoolPatch : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.CapacityPoolPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.CapacityPoolPatch>
    {
        public CapacityPoolPatch(Azure.Core.AzureLocation location) { }
        public float? CustomThroughputMibps { get { throw null; } set { } }
        public bool? IsCoolAccessEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.CapacityPoolQosType? QosType { get { throw null; } set { } }
        public long? Size { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.CapacityPoolPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.CapacityPoolPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.CapacityPoolPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.CapacityPoolPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.CapacityPoolPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.CapacityPoolPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.CapacityPoolPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CapacityPoolQosType : System.IEquatable<Azure.ResourceManager.NetApp.Models.CapacityPoolQosType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CapacityPoolQosType(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.CapacityPoolQosType Auto { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.CapacityPoolQosType Manual { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.CapacityPoolQosType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.CapacityPoolQosType left, Azure.ResourceManager.NetApp.Models.CapacityPoolQosType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.CapacityPoolQosType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.CapacityPoolQosType left, Azure.ResourceManager.NetApp.Models.CapacityPoolQosType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ClusterPeerCommandResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.ClusterPeerCommandResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.ClusterPeerCommandResult>
    {
        internal ClusterPeerCommandResult() { }
        public string PeerAcceptCommand { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.ClusterPeerCommandResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.ClusterPeerCommandResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.ClusterPeerCommandResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.ClusterPeerCommandResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.ClusterPeerCommandResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.ClusterPeerCommandResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.ClusterPeerCommandResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CoolAccessRetrievalPolicy : System.IEquatable<Azure.ResourceManager.NetApp.Models.CoolAccessRetrievalPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CoolAccessRetrievalPolicy(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.CoolAccessRetrievalPolicy Default { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.CoolAccessRetrievalPolicy Never { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.CoolAccessRetrievalPolicy OnRead { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.CoolAccessRetrievalPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.CoolAccessRetrievalPolicy left, Azure.ResourceManager.NetApp.Models.CoolAccessRetrievalPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.CoolAccessRetrievalPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.CoolAccessRetrievalPolicy left, Azure.ResourceManager.NetApp.Models.CoolAccessRetrievalPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CoolAccessTieringPolicy : System.IEquatable<Azure.ResourceManager.NetApp.Models.CoolAccessTieringPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CoolAccessTieringPolicy(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.CoolAccessTieringPolicy Auto { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.CoolAccessTieringPolicy SnapshotOnly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.CoolAccessTieringPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.CoolAccessTieringPolicy left, Azure.ResourceManager.NetApp.Models.CoolAccessTieringPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.CoolAccessTieringPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.CoolAccessTieringPolicy left, Azure.ResourceManager.NetApp.Models.CoolAccessTieringPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CredentialsStatus : System.IEquatable<Azure.ResourceManager.NetApp.Models.CredentialsStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CredentialsStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.CredentialsStatus Active { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.CredentialsStatus CredentialsExpired { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.CredentialsStatus NoCredentialsSet { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.CredentialsStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.CredentialsStatus left, Azure.ResourceManager.NetApp.Models.CredentialsStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.CredentialsStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.CredentialsStatus left, Azure.ResourceManager.NetApp.Models.CredentialsStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnableNetAppSubvolume : System.IEquatable<Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnableNetAppSubvolume(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume Disabled { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume left, Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume left, Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ExternalReplicationSetupStatus : System.IEquatable<Azure.ResourceManager.NetApp.Models.ExternalReplicationSetupStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ExternalReplicationSetupStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.ExternalReplicationSetupStatus ClusterPeerPending { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.ExternalReplicationSetupStatus ClusterPeerRequired { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.ExternalReplicationSetupStatus NoActionRequired { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.ExternalReplicationSetupStatus ReplicationCreateRequired { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.ExternalReplicationSetupStatus VServerPeerRequired { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.ExternalReplicationSetupStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.ExternalReplicationSetupStatus left, Azure.ResourceManager.NetApp.Models.ExternalReplicationSetupStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.ExternalReplicationSetupStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.ExternalReplicationSetupStatus left, Azure.ResourceManager.NetApp.Models.ExternalReplicationSetupStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FileSystemUser : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.FileSystemUser>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.FileSystemUser>
    {
        public FileSystemUser() { }
        public string CifsUserUsername { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NfsUser NfsUser { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.FileSystemUser System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.FileSystemUser>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.FileSystemUser>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.FileSystemUser System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.FileSystemUser>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.FileSystemUser>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.FileSystemUser>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetGroupIdListForLdapUserContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.GetGroupIdListForLdapUserContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.GetGroupIdListForLdapUserContent>
    {
        public GetGroupIdListForLdapUserContent(string username) { }
        public string Username { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.GetGroupIdListForLdapUserContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.GetGroupIdListForLdapUserContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.GetGroupIdListForLdapUserContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.GetGroupIdListForLdapUserContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.GetGroupIdListForLdapUserContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.GetGroupIdListForLdapUserContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.GetGroupIdListForLdapUserContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GetGroupIdListForLdapUserResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.GetGroupIdListForLdapUserResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.GetGroupIdListForLdapUserResult>
    {
        internal GetGroupIdListForLdapUserResult() { }
        public System.Collections.Generic.IReadOnlyList<string> GroupIdsForLdapUser { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.GetGroupIdListForLdapUserResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.GetGroupIdListForLdapUserResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.GetGroupIdListForLdapUserResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.GetGroupIdListForLdapUserResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.GetGroupIdListForLdapUserResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.GetGroupIdListForLdapUserResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.GetGroupIdListForLdapUserResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LdapConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.LdapConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.LdapConfiguration>
    {
        public LdapConfiguration() { }
        public string CertificateCNHost { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public bool? LdapOverTls { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> LdapServers { get { throw null; } }
        public string ServerCACertificate { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.LdapConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.LdapConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.LdapConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.LdapConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.LdapConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.LdapConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.LdapConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LdapServerType : System.IEquatable<Azure.ResourceManager.NetApp.Models.LdapServerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LdapServerType(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.LdapServerType ActiveDirectory { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.LdapServerType OpenLdap { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.LdapServerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.LdapServerType left, Azure.ResourceManager.NetApp.Models.LdapServerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.LdapServerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.LdapServerType left, Azure.ResourceManager.NetApp.Models.LdapServerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MultiAdStatus : System.IEquatable<Azure.ResourceManager.NetApp.Models.MultiAdStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MultiAdStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.MultiAdStatus Disabled { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.MultiAdStatus Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.MultiAdStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.MultiAdStatus left, Azure.ResourceManager.NetApp.Models.MultiAdStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.MultiAdStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.MultiAdStatus left, Azure.ResourceManager.NetApp.Models.MultiAdStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetAppAccountActiveDirectory : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectory>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectory>
    {
        public NetAppAccountActiveDirectory() { }
        public string ActiveDirectoryId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Administrators { get { throw null; } }
        public string AdName { get { throw null; } set { } }
        public bool? AllowLocalNfsUsersWithLdap { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> BackupOperators { get { throw null; } }
        public string Dns { get { throw null; } set { } }
        public string Domain { get { throw null; } set { } }
        public bool? EncryptDCConnections { get { throw null; } set { } }
        public bool? IsAesEncryptionEnabled { get { throw null; } set { } }
        public bool? IsLdapOverTlsEnabled { get { throw null; } set { } }
        public bool? IsLdapSigningEnabled { get { throw null; } set { } }
        public System.Net.IPAddress KdcIP { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppLdapSearchScopeConfiguration LdapSearchScope { get { throw null; } set { } }
        public string OrganizationalUnit { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public string PreferredServersForLdapClient { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> SecurityOperators { get { throw null; } }
        public string ServerRootCACertificate { get { throw null; } set { } }
        public string Site { get { throw null; } set { } }
        public string SmbServerName { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectoryStatus? Status { get { throw null; } }
        public string StatusDetails { get { throw null; } }
        public string Username { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectory System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectory>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectory>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectory System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectory>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectory>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectory>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppAccountActiveDirectoryStatus : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectoryStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppAccountActiveDirectoryStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectoryStatus Created { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectoryStatus Deleted { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectoryStatus Error { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectoryStatus InUse { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectoryStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectoryStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectoryStatus left, Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectoryStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectoryStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectoryStatus left, Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectoryStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetAppAccountEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppAccountEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppAccountEncryption>
    {
        public NetAppAccountEncryption() { }
        public Azure.ResourceManager.NetApp.Models.NetAppEncryptionIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppKeySource? KeySource { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppAccountEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppAccountEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppAccountEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppAccountEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppAccountEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppAccountEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppAccountEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppAccountPatch : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppAccountPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppAccountPatch>
    {
        public NetAppAccountPatch(Azure.Core.AzureLocation location) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetApp.Models.NetAppAccountActiveDirectory> ActiveDirectories { get { throw null; } }
        public bool? DisableShowmount { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppAccountEncryption Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.LdapConfiguration LdapConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.MultiAdStatus? MultiAdStatus { get { throw null; } }
        public string NfsV4IdDomain { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppAccountPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppAccountPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppAccountPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppAccountPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppAccountPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppAccountPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppAccountPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppApplicationType : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppApplicationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppApplicationType(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppApplicationType Oracle { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppApplicationType SapHana { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppApplicationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppApplicationType left, Azure.ResourceManager.NetApp.Models.NetAppApplicationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppApplicationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppApplicationType left, Azure.ResourceManager.NetApp.Models.NetAppApplicationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppAvsDataStore : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppAvsDataStore(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore Disabled { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore left, Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore left, Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetAppBackupPolicyPatch : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppBackupPolicyPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppBackupPolicyPatch>
    {
        public NetAppBackupPolicyPatch(Azure.Core.AzureLocation location) { }
        public Azure.Core.ResourceIdentifier BackupPolicyId { get { throw null; } }
        public int? DailyBackupsToKeep { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public int? MonthlyBackupsToKeep { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupDetail> VolumeBackups { get { throw null; } }
        public int? VolumesAssigned { get { throw null; } }
        public int? WeeklyBackupsToKeep { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppBackupPolicyPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppBackupPolicyPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppBackupPolicyPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppBackupPolicyPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppBackupPolicyPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppBackupPolicyPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppBackupPolicyPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppBackupType : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppBackupType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppBackupType(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppBackupType Manual { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppBackupType Scheduled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppBackupType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppBackupType left, Azure.ResourceManager.NetApp.Models.NetAppBackupType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppBackupType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppBackupType left, Azure.ResourceManager.NetApp.Models.NetAppBackupType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetAppBackupVaultBackupPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppBackupVaultBackupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppBackupVaultBackupPatch>
    {
        public NetAppBackupVaultBackupPatch() { }
        public string Label { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppBackupVaultBackupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppBackupVaultBackupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppBackupVaultBackupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppBackupVaultBackupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppBackupVaultBackupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppBackupVaultBackupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppBackupVaultBackupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppBackupVaultPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppBackupVaultPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppBackupVaultPatch>
    {
        public NetAppBackupVaultPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppBackupVaultPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppBackupVaultPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppBackupVaultPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppBackupVaultPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppBackupVaultPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppBackupVaultPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppBackupVaultPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppChangeKeyVault : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppChangeKeyVault>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppChangeKeyVault>
    {
        public NetAppChangeKeyVault(System.Uri keyVaultUri, string keyName, System.Collections.Generic.IEnumerable<Azure.ResourceManager.NetApp.Models.NetAppKeyVaultPrivateEndpoint> keyVaultPrivateEndpoints) { }
        public string KeyName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetApp.Models.NetAppKeyVaultPrivateEndpoint> KeyVaultPrivateEndpoints { get { throw null; } }
        public Azure.Core.ResourceIdentifier KeyVaultResourceId { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppChangeKeyVault System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppChangeKeyVault>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppChangeKeyVault>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppChangeKeyVault System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppChangeKeyVault>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppChangeKeyVault>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppChangeKeyVault>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppCheckAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppCheckAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppCheckAvailabilityResult>
    {
        internal NetAppCheckAvailabilityResult() { }
        public bool? IsAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppNameUnavailableReason? Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppCheckAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppCheckAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppCheckAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppCheckAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppCheckAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppCheckAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppCheckAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppChownMode : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppChownMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppChownMode(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppChownMode Restricted { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppChownMode Unrestricted { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppChownMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppChownMode left, Azure.ResourceManager.NetApp.Models.NetAppChownMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppChownMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppChownMode left, Azure.ResourceManager.NetApp.Models.NetAppChownMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetAppDestinationReplication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppDestinationReplication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppDestinationReplication>
    {
        internal NetAppDestinationReplication() { }
        public string Region { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppReplicationType? ReplicationType { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        public string Zone { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppDestinationReplication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppDestinationReplication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppDestinationReplication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppDestinationReplication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppDestinationReplication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppDestinationReplication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppDestinationReplication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppEncryptionIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppEncryptionIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppEncryptionIdentity>
    {
        public NetAppEncryptionIdentity() { }
        public string FederatedClientId { get { throw null; } set { } }
        public string PrincipalId { get { throw null; } }
        public string UserAssignedIdentity { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppEncryptionIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppEncryptionIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppEncryptionIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppEncryptionIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppEncryptionIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppEncryptionIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppEncryptionIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppEncryptionKeySource : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppEncryptionKeySource(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource MicrosoftKeyVault { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource MicrosoftNetApp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource left, Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource left, Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetAppEncryptionTransitionContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppEncryptionTransitionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppEncryptionTransitionContent>
    {
        public NetAppEncryptionTransitionContent(Azure.Core.ResourceIdentifier virtualNetworkId, Azure.Core.ResourceIdentifier privateEndpointId) { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.Core.ResourceIdentifier VirtualNetworkId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppEncryptionTransitionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppEncryptionTransitionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppEncryptionTransitionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppEncryptionTransitionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppEncryptionTransitionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppEncryptionTransitionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppEncryptionTransitionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppEndpointType : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppEndpointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppEndpointType(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppEndpointType Destination { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppEndpointType Source { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppEndpointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppEndpointType left, Azure.ResourceManager.NetApp.Models.NetAppEndpointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppEndpointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppEndpointType left, Azure.ResourceManager.NetApp.Models.NetAppEndpointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppFileAccessLog : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppFileAccessLog>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppFileAccessLog(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppFileAccessLog Disabled { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppFileAccessLog Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppFileAccessLog other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppFileAccessLog left, Azure.ResourceManager.NetApp.Models.NetAppFileAccessLog right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppFileAccessLog (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppFileAccessLog left, Azure.ResourceManager.NetApp.Models.NetAppFileAccessLog right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetAppFilePathAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppFilePathAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppFilePathAvailabilityContent>
    {
        public NetAppFilePathAvailabilityContent(string name, Azure.Core.ResourceIdentifier subnetId) { }
        public string AvailabilityZone { get { throw null; } set { } }
        public string Name { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppFilePathAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppFilePathAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppFilePathAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppFilePathAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppFilePathAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppFilePathAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppFilePathAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppFileServiceLevel : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppFileServiceLevel(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel Flexible { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel Premium { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel Standard { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel StandardZrs { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel Ultra { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel left, Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel left, Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppKeySource : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppKeySource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppKeySource(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppKeySource MicrosoftKeyVault { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppKeySource MicrosoftNetApp { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppKeySource other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppKeySource left, Azure.ResourceManager.NetApp.Models.NetAppKeySource right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppKeySource (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppKeySource left, Azure.ResourceManager.NetApp.Models.NetAppKeySource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetAppKeyVaultPrivateEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppKeyVaultPrivateEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppKeyVaultPrivateEndpoint>
    {
        public NetAppKeyVaultPrivateEndpoint() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualNetworkId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppKeyVaultPrivateEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppKeyVaultPrivateEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppKeyVaultPrivateEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppKeyVaultPrivateEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppKeyVaultPrivateEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppKeyVaultPrivateEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppKeyVaultPrivateEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppKeyVaultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppKeyVaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppKeyVaultProperties>
    {
        public NetAppKeyVaultProperties(System.Uri keyVaultUri, string keyName) { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public NetAppKeyVaultProperties(System.Uri keyVaultUri, string keyName, string keyVaultResourceId) { }
        public string KeyName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier KeyVaultArmResourceId { get { throw null; } set { } }
        public string KeyVaultId { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string KeyVaultResourceId { get { throw null; } set { } }
        public System.Uri KeyVaultUri { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppKeyVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppKeyVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppKeyVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppKeyVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppKeyVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppKeyVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppKeyVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppKeyVaultStatus : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppKeyVaultStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus Created { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus Deleted { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus Error { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus InUse { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus left, Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus left, Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetAppKeyVaultStatusResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatusResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatusResult>
    {
        internal NetAppKeyVaultStatusResult() { }
        public string KeyName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetApp.Models.NetAppKeyVaultPrivateEndpoint> KeyVaultPrivateEndpoints { get { throw null; } }
        public Azure.Core.ResourceIdentifier KeyVaultResourceId { get { throw null; } }
        public System.Uri KeyVaultUri { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatusResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatusResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatusResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatusResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatusResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatusResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppKeyVaultStatusResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppLdapSearchScopeConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppLdapSearchScopeConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppLdapSearchScopeConfiguration>
    {
        public NetAppLdapSearchScopeConfiguration() { }
        public string GroupDN { get { throw null; } set { } }
        public string GroupMembershipFilter { get { throw null; } set { } }
        public string UserDN { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppLdapSearchScopeConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppLdapSearchScopeConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppLdapSearchScopeConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppLdapSearchScopeConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppLdapSearchScopeConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppLdapSearchScopeConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppLdapSearchScopeConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppMirrorState : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppMirrorState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppMirrorState(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppMirrorState Broken { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppMirrorState Mirrored { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppMirrorState Uninitialized { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppMirrorState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppMirrorState left, Azure.ResourceManager.NetApp.Models.NetAppMirrorState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppMirrorState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppMirrorState left, Azure.ResourceManager.NetApp.Models.NetAppMirrorState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetAppNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityContent>
    {
        public NetAppNameAvailabilityContent(string name, Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityResourceType resourceType, string resourceGroup) { }
        public string Name { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityResourceType ResourceType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppNameAvailabilityResourceType : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppNameAvailabilityResourceType(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityResourceType MicrosoftNetAppNetAppAccounts { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityResourceType MicrosoftNetAppNetAppAccountsCapacityPools { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityResourceType MicrosoftNetAppNetAppAccountsCapacityPoolsVolumes { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityResourceType MicrosoftNetAppNetAppAccountsCapacityPoolsVolumesSnapshots { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityResourceType left, Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityResourceType left, Azure.ResourceManager.NetApp.Models.NetAppNameAvailabilityResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppNameUnavailableReason : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppNameUnavailableReason>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppNameUnavailableReason(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppNameUnavailableReason AlreadyExists { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppNameUnavailableReason Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppNameUnavailableReason other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppNameUnavailableReason left, Azure.ResourceManager.NetApp.Models.NetAppNameUnavailableReason right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppNameUnavailableReason (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppNameUnavailableReason left, Azure.ResourceManager.NetApp.Models.NetAppNameUnavailableReason right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppNetworkFeature : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppNetworkFeature(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature Basic { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature BasicStandard { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature Standard { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature StandardBasic { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature left, Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature left, Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum NetAppProvisioningState
    {
        Accepted = 0,
        Creating = 1,
        Patching = 2,
        Deleting = 3,
        Moving = 4,
        Failed = 5,
        Succeeded = 6,
    }
    public partial class NetAppQuotaAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityContent>
    {
        public NetAppQuotaAvailabilityContent(string name, Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityResourceType availabilityResourceType, string resourceGroup) { }
        public Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityResourceType AvailabilityResourceType { get { throw null; } }
        public string Name { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppQuotaAvailabilityResourceType : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppQuotaAvailabilityResourceType(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityResourceType MicrosoftNetAppNetAppAccounts { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityResourceType MicrosoftNetAppNetAppAccountsCapacityPools { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityResourceType MicrosoftNetAppNetAppAccountsCapacityPoolsVolumes { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityResourceType MicrosoftNetAppNetAppAccountsCapacityPoolsVolumesSnapshots { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityResourceType left, Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityResourceType left, Azure.ResourceManager.NetApp.Models.NetAppQuotaAvailabilityResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetAppRegionInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppRegionInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppRegionInfo>
    {
        internal NetAppRegionInfo() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetApp.Models.AvailabilityZoneMapping> AvailabilityZoneMappings { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity? StorageToNetworkProximity { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppRegionInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppRegionInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppRegionInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppRegionInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppRegionInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppRegionInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppRegionInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppRelationshipStatus : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppRelationshipStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus Idle { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus Transferring { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus left, Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus left, Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetAppReplicationObject : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppReplicationObject>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppReplicationObject>
    {
        public NetAppReplicationObject() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public NetAppReplicationObject(Azure.Core.ResourceIdentifier remoteVolumeResourceId) { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetApp.Models.NetAppDestinationReplication> DestinationReplications { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppEndpointType? EndpointType { get { throw null; } [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)] set { } }
        public string ExternalReplicationSetupInfo { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.ExternalReplicationSetupStatus? ExternalReplicationSetupStatus { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppMirrorState? MirrorState { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.VolumeReplicationRelationshipStatus? RelationshipStatus { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.RemotePath RemotePath { get { throw null; } set { } }
        public string RemoteVolumeRegion { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RemoteVolumeResourceId { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string ReplicationId { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule? ReplicationSchedule { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppReplicationObject System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppReplicationObject>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppReplicationObject>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppReplicationObject System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppReplicationObject>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppReplicationObject>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppReplicationObject>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppReplicationSchedule : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppReplicationSchedule(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule Daily { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule Hourly { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule TenMinutely { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule left, Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule left, Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppReplicationType : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppReplicationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppReplicationType(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppReplicationType CrossRegionReplication { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppReplicationType CrossZoneReplication { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppReplicationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppReplicationType left, Azure.ResourceManager.NetApp.Models.NetAppReplicationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppReplicationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppReplicationType left, Azure.ResourceManager.NetApp.Models.NetAppReplicationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetAppRestoreStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppRestoreStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppRestoreStatus>
    {
        internal NetAppRestoreStatus() { }
        public string ErrorMessage { get { throw null; } }
        public bool? IsHealthy { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppMirrorState? MirrorState { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus? RelationshipStatus { get { throw null; } }
        public long? TotalTransferBytes { get { throw null; } }
        public string UnhealthyReason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppRestoreStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppRestoreStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppRestoreStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppRestoreStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppRestoreStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppRestoreStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppRestoreStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppSubscriptionQuotaItem : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppSubscriptionQuotaItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppSubscriptionQuotaItem>
    {
        public NetAppSubscriptionQuotaItem() { }
        public int? Current { get { throw null; } }
        public int? Default { get { throw null; } }
        public int? Usage { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppSubscriptionQuotaItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppSubscriptionQuotaItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppSubscriptionQuotaItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppSubscriptionQuotaItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppSubscriptionQuotaItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppSubscriptionQuotaItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppSubscriptionQuotaItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppSubvolumeInfoPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppSubvolumeInfoPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppSubvolumeInfoPatch>
    {
        public NetAppSubvolumeInfoPatch() { }
        public string Path { get { throw null; } set { } }
        public long? Size { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppSubvolumeInfoPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppSubvolumeInfoPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppSubvolumeInfoPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppSubvolumeInfoPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppSubvolumeInfoPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppSubvolumeInfoPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppSubvolumeInfoPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppSubvolumeMetadata : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppSubvolumeMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppSubvolumeMetadata>
    {
        internal NetAppSubvolumeMetadata() { }
        public System.DateTimeOffset? AccessedOn { get { throw null; } }
        public long? BytesUsed { get { throw null; } }
        public System.DateTimeOffset? ChangedOn { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public System.DateTimeOffset? ModifiedOn { get { throw null; } }
        public string ParentPath { get { throw null; } }
        public string Path { get { throw null; } }
        public string Permissions { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public long? Size { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppSubvolumeMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppSubvolumeMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppSubvolumeMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppSubvolumeMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppSubvolumeMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppSubvolumeMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppSubvolumeMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppUsageName : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppUsageName>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppUsageName>
    {
        internal NetAppUsageName() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppUsageName System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppUsageName>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppUsageName>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppUsageName System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppUsageName>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppUsageName>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppUsageName>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppUsageResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppUsageResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppUsageResult>
    {
        internal NetAppUsageResult() { }
        public int? CurrentValue { get { throw null; } }
        public string Id { get { throw null; } }
        public int? Limit { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppUsageName Name { get { throw null; } }
        public string Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppUsageResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppUsageResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppUsageResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppUsageResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppUsageResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppUsageResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppUsageResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class NetAppVault : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVault>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVault>
    {
        internal NetAppVault() { }
        public string VaultName { get { throw null; } }
        Azure.ResourceManager.NetApp.Models.NetAppVault System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVault>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVault>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVault System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVault>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVault>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVault>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppVolumeAuthorizeReplicationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeAuthorizeReplicationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeAuthorizeReplicationContent>
    {
        public NetAppVolumeAuthorizeReplicationContent() { }
        public Azure.Core.ResourceIdentifier RemoteVolumeResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeAuthorizeReplicationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeAuthorizeReplicationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeAuthorizeReplicationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeAuthorizeReplicationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeAuthorizeReplicationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeAuthorizeReplicationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeAuthorizeReplicationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class NetAppVolumeBackupBackupRestoreFilesContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupBackupRestoreFilesContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupBackupRestoreFilesContent>
    {
        public NetAppVolumeBackupBackupRestoreFilesContent(System.Collections.Generic.IEnumerable<string> fileList, Azure.Core.ResourceIdentifier destinationVolumeId) { }
        public Azure.Core.ResourceIdentifier DestinationVolumeId { get { throw null; } }
        public System.Collections.Generic.IList<string> FileList { get { throw null; } }
        public string RestoreFilePath { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupBackupRestoreFilesContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupBackupRestoreFilesContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupBackupRestoreFilesContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupBackupRestoreFilesContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupBackupRestoreFilesContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupBackupRestoreFilesContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupBackupRestoreFilesContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppVolumeBackupConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupConfiguration>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public NetAppVolumeBackupConfiguration() { }
        public Azure.Core.ResourceIdentifier BackupPolicyId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier BackupVaultId { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public bool? IsBackupEnabled { get { throw null; } set { } }
        public bool? IsPolicyEnforced { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Core.ResourceIdentifier VaultId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppVolumeBackupDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupDetail>
    {
        internal NetAppVolumeBackupDetail() { }
        public int? BackupsCount { get { throw null; } }
        public bool? IsPolicyEnabled { get { throw null; } }
        public string VolumeName { get { throw null; } }
        public Azure.Core.ResourceIdentifier VolumeResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class NetAppVolumeBackupPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupPatch>
    {
        public NetAppVolumeBackupPatch() { }
        public NetAppVolumeBackupPatch(System.Collections.Generic.IDictionary<string, System.BinaryData> serializedAdditionalRawData) { }
        public string BackupId { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppBackupType? BackupType { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string FailureReason { get { throw null; } }
        public string Label { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public long? Size { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public bool? UseExistingSnapshot { get { throw null; } set { } }
        public string VolumeName { get { throw null; } }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppVolumeBackupStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupStatus>
    {
        internal NetAppVolumeBackupStatus() { }
        public string ErrorMessage { get { throw null; } }
        public bool? IsHealthy { get { throw null; } }
        public long? LastTransferSize { get { throw null; } }
        public string LastTransferType { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppMirrorState? MirrorState { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus? RelationshipStatus { get { throw null; } }
        public long? TotalTransferBytes { get { throw null; } }
        public long? TransferProgressBytes { get { throw null; } }
        public string UnhealthyReason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppVolumeBreakFileLocksContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBreakFileLocksContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBreakFileLocksContent>
    {
        public NetAppVolumeBreakFileLocksContent() { }
        public System.Net.IPAddress ClientIP { get { throw null; } set { } }
        public bool? ConfirmRunningDisruptiveOperation { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeBreakFileLocksContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBreakFileLocksContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBreakFileLocksContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeBreakFileLocksContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBreakFileLocksContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBreakFileLocksContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBreakFileLocksContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppVolumeBreakReplicationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBreakReplicationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBreakReplicationContent>
    {
        public NetAppVolumeBreakReplicationContent() { }
        public bool? ForceBreakReplication { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeBreakReplicationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBreakReplicationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBreakReplicationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeBreakReplicationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBreakReplicationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBreakReplicationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeBreakReplicationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppVolumeDataProtection : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeDataProtection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeDataProtection>
    {
        public NetAppVolumeDataProtection() { }
        public Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupConfiguration Backup { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppReplicationObject Replication { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SnapshotPolicyId { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppVolumeRelocationProperties VolumeRelocation { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeDataProtection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeDataProtection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeDataProtection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeDataProtection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeDataProtection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeDataProtection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeDataProtection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppVolumeExportPolicyRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule>
    {
        public NetAppVolumeExportPolicyRule() { }
        public bool? AllowCifsProtocol { get { throw null; } set { } }
        public string AllowedClients { get { throw null; } set { } }
        public bool? AllowNfsV3Protocol { get { throw null; } set { } }
        public bool? AllowNfsV41Protocol { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppChownMode? ChownMode { get { throw null; } set { } }
        public bool? HasRootAccess { get { throw null; } set { } }
        public bool? IsKerberos5iReadOnly { get { throw null; } set { } }
        public bool? IsKerberos5iReadWrite { get { throw null; } set { } }
        public bool? IsKerberos5pReadOnly { get { throw null; } set { } }
        public bool? IsKerberos5pReadWrite { get { throw null; } set { } }
        public bool? IsKerberos5ReadOnly { get { throw null; } set { } }
        public bool? IsKerberos5ReadWrite { get { throw null; } set { } }
        public bool? IsUnixReadOnly { get { throw null; } set { } }
        public bool? IsUnixReadWrite { get { throw null; } set { } }
        public int? RuleIndex { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppVolumeGroupMetadata : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupMetadata>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupMetadata>
    {
        public NetAppVolumeGroupMetadata() { }
        public string ApplicationIdentifier { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppApplicationType? ApplicationType { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string DeploymentSpecId { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule> GlobalPlacementRules { get { throw null; } }
        public string GroupDescription { get { throw null; } set { } }
        public long? VolumesCount { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupMetadata System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupMetadata>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupMetadata>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupMetadata System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupMetadata>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupMetadata>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupMetadata>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppVolumeGroupResult : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupResult>
    {
        internal NetAppVolumeGroupResult() { }
        public Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupMetadata GroupMetaData { get { throw null; } }
        public Azure.Core.AzureLocation? Location { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppVolumeGroupVolume : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupVolume>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupVolume>
    {
        public NetAppVolumeGroupVolume(string creationToken, long usageThreshold, Azure.Core.ResourceIdentifier subnetId) { }
        public Azure.ResourceManager.NetApp.Models.AcceptGrowCapacityPoolForShortTermCloneSplit? AcceptGrowCapacityPoolForShortTermCloneSplit { get { throw null; } set { } }
        public float? ActualThroughputMibps { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppAvsDataStore? AvsDataStore { get { throw null; } set { } }
        public string BackupId { get { throw null; } set { } }
        public string BaremetalTenantId { get { throw null; } }
        public Azure.Core.ResourceIdentifier CapacityPoolResourceId { get { throw null; } set { } }
        public int? CloneProgress { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.CoolAccessRetrievalPolicy? CoolAccessRetrievalPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.CoolAccessTieringPolicy? CoolAccessTieringPolicy { get { throw null; } set { } }
        public int? CoolnessPeriod { get { throw null; } set { } }
        public string CreationToken { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppVolumeDataProtection DataProtection { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> DataStoreResourceId { get { throw null; } }
        public long? DefaultGroupQuotaInKiBs { get { throw null; } set { } }
        public long? DefaultUserQuotaInKiBs { get { throw null; } set { } }
        public bool? DeleteBaseSnapshot { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature? EffectiveNetworkFeatures { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.EnableNetAppSubvolume? EnableSubvolumes { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppEncryptionKeySource? EncryptionKeySource { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule> ExportRules { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppFileAccessLog? FileAccessLogs { get { throw null; } }
        public System.Guid? FileSystemId { get { throw null; } }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } }
        public long? InheritedSizeInBytes { get { throw null; } }
        public bool? IsCoolAccessEnabled { get { throw null; } set { } }
        public bool? IsDefaultQuotaEnabled { get { throw null; } set { } }
        public bool? IsEncrypted { get { throw null; } }
        public bool? IsKerberosEnabled { get { throw null; } set { } }
        public bool? IsLargeVolume { get { throw null; } set { } }
        public bool? IsLdapEnabled { get { throw null; } set { } }
        public bool? IsRestoring { get { throw null; } [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)] set { } }
        public bool? IsSmbContinuouslyAvailable { get { throw null; } set { } }
        public bool? IsSmbEncryptionEnabled { get { throw null; } set { } }
        public bool? IsSnapshotDirectoryVisible { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier KeyVaultPrivateEndpointResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage? Language { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.LdapServerType? LdapServerType { get { throw null; } set { } }
        public long? MaximumNumberOfFiles { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetApp.Models.NetAppVolumeMountTarget> MountTargets { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature? NetworkFeatures { get { throw null; } set { } }
        public System.Guid? NetworkSiblingSetId { get { throw null; } }
        public Azure.Core.ResourceIdentifier OriginatingResourceId { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule> PlacementRules { get { throw null; } }
        public System.Collections.Generic.IList<string> ProtocolTypes { get { throw null; } }
        public string ProvisionedAvailabilityZone { get { throw null; } }
        public string ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ProximityPlacementGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle? SecurityStyle { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel? ServiceLevel { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration? SmbAccessBasedEnumeration { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.SmbNonBrowsable? SmbNonBrowsable { get { throw null; } set { } }
        public string SnapshotId { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity? StorageToNetworkProximity { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public string T2Network { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        public float? ThroughputMibps { get { throw null; } set { } }
        public string UnixPermissions { get { throw null; } set { } }
        public long UsageThreshold { get { throw null; } set { } }
        public string VolumeGroupName { get { throw null; } }
        public string VolumeSpecName { get { throw null; } set { } }
        public string VolumeType { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupVolume System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupVolume>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupVolume>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupVolume System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupVolume>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupVolume>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeGroupVolume>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppVolumeLanguage : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppVolumeLanguage(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage Ar { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage ArUtf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage C { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage Cs { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage CsUtf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage CUtf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage Da { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage DaUtf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage De { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage DeUtf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage En { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage EnUs { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage EnUsUtf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage EnUtf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage Es { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage EsUtf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage Fi { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage FiUtf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage Fr { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage FrUtf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage He { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage HeUtf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage Hr { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage HrUtf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage Hu { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage HuUtf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage It { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage ItUtf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage Ja { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage JaJp932 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage JaJp932Utf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage JaJpPck { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage JaJpPckUtf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage JaJpPckV2 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage JaJpPckV2Utf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage JaUtf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage JaV1 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage JaV1Utf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage Ko { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage KoUtf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage Nl { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage NlUtf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage No { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage NoUtf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage Pl { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage PlUtf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage Pt { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage PtUtf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage Ro { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage RoUtf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage Ru { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage RuUtf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage Sk { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage SkUtf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage Sl { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage SlUtf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage Sv { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage SvUtf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage Tr { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage TrUtf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage Utf8Mb4 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage Zh { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage ZhGbk { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage ZhGbkUtf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage ZhTw { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage ZhTwBig5 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage ZhTwBig5Utf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage ZhTwUtf8 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage ZhUtf8 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage left, Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage left, Azure.ResourceManager.NetApp.Models.NetAppVolumeLanguage right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetAppVolumeMountTarget : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeMountTarget>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeMountTarget>
    {
        internal NetAppVolumeMountTarget() { }
        public System.Guid FileSystemId { get { throw null; } }
        public System.Net.IPAddress IPAddress { get { throw null; } }
        public System.Guid? MountTargetId { get { throw null; } }
        public string SmbServerFqdn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeMountTarget System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeMountTarget>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeMountTarget>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeMountTarget System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeMountTarget>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeMountTarget>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeMountTarget>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppVolumePatch : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumePatch>
    {
        public NetAppVolumePatch(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.NetApp.Models.CoolAccessRetrievalPolicy? CoolAccessRetrievalPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.CoolAccessTieringPolicy? CoolAccessTieringPolicy { get { throw null; } set { } }
        public int? CoolnessPeriod { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppVolumePatchDataProtection DataProtection { get { throw null; } set { } }
        public long? DefaultGroupQuotaInKiBs { get { throw null; } set { } }
        public long? DefaultUserQuotaInKiBs { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.NetApp.Models.NetAppVolumeExportPolicyRule> ExportRules { get { throw null; } }
        public bool? IsCoolAccessEnabled { get { throw null; } set { } }
        public bool? IsDefaultQuotaEnabled { get { throw null; } set { } }
        public bool? IsSnapshotDirectoryVisible { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ProtocolTypes { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppFileServiceLevel? ServiceLevel { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration? SmbAccessBasedEnumeration { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.SmbNonBrowsable? SmbNonBrowsable { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public Azure.Core.ResourceIdentifier SnapshotPolicyId { get { throw null; } set { } }
        public float? ThroughputMibps { get { throw null; } set { } }
        public string UnixPermissions { get { throw null; } set { } }
        public long? UsageThreshold { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppVolumePatchDataProtection : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumePatchDataProtection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumePatchDataProtection>
    {
        public NetAppVolumePatchDataProtection() { }
        public Azure.ResourceManager.NetApp.Models.NetAppVolumeBackupConfiguration Backup { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SnapshotPolicyId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumePatchDataProtection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumePatchDataProtection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumePatchDataProtection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumePatchDataProtection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumePatchDataProtection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumePatchDataProtection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumePatchDataProtection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppVolumePlacementRule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule>
    {
        public NetAppVolumePlacementRule(string key, string value) { }
        public string Key { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumePlacementRule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppVolumePoolChangeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumePoolChangeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumePoolChangeContent>
    {
        public NetAppVolumePoolChangeContent(Azure.Core.ResourceIdentifier newPoolResourceId) { }
        public Azure.Core.ResourceIdentifier NewPoolResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumePoolChangeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumePoolChangeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumePoolChangeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumePoolChangeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumePoolChangeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumePoolChangeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumePoolChangeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppVolumeQuotaReport : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaReport>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaReport>
    {
        internal NetAppVolumeQuotaReport() { }
        public bool? IsDerivedQuota { get { throw null; } }
        public float? PercentageUsed { get { throw null; } }
        public long? QuotaLimitTotalInKiBs { get { throw null; } }
        public long? QuotaLimitUsedInKiBs { get { throw null; } }
        public string QuotaTarget { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType? QuotaType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaReport System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaReport>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaReport>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaReport System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaReport>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaReport>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaReport>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppVolumeQuotaReportListResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaReportListResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaReportListResult>
    {
        internal NetAppVolumeQuotaReportListResult() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaReport> Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaReportListResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaReportListResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaReportListResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaReportListResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaReportListResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaReportListResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaReportListResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppVolumeQuotaRulePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaRulePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaRulePatch>
    {
        public NetAppVolumeQuotaRulePatch() { }
        public Azure.ResourceManager.NetApp.Models.NetAppProvisioningState? ProvisioningState { get { throw null; } }
        public long? QuotaSizeInKiBs { get { throw null; } set { } }
        public string QuotaTarget { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType? QuotaType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaRulePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaRulePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaRulePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaRulePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaRulePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaRulePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaRulePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppVolumeQuotaType : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppVolumeQuotaType(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType DefaultGroupQuota { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType DefaultUserQuota { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType IndividualGroupQuota { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType IndividualUserQuota { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType left, Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType left, Azure.ResourceManager.NetApp.Models.NetAppVolumeQuotaType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetAppVolumeReestablishReplicationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeReestablishReplicationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeReestablishReplicationContent>
    {
        public NetAppVolumeReestablishReplicationContent() { }
        public Azure.Core.ResourceIdentifier SourceVolumeId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeReestablishReplicationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeReestablishReplicationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeReestablishReplicationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeReestablishReplicationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeReestablishReplicationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeReestablishReplicationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeReestablishReplicationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppVolumeRelocationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeRelocationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeRelocationProperties>
    {
        public NetAppVolumeRelocationProperties() { }
        public bool? IsReadyToBeFinalized { get { throw null; } }
        public bool? IsRelocationRequested { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeRelocationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeRelocationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeRelocationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeRelocationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeRelocationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeRelocationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeRelocationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppVolumeReplication : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeReplication>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeReplication>
    {
        internal NetAppVolumeReplication() { }
        public Azure.ResourceManager.NetApp.Models.NetAppEndpointType? EndpointType { get { throw null; } }
        public string RemoteVolumeRegion { get { throw null; } }
        public Azure.Core.ResourceIdentifier RemoteVolumeResourceId { get { throw null; } }
        public string ReplicationId { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppReplicationSchedule? ReplicationSchedule { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeReplication System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeReplication>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeReplication>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeReplication System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeReplication>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeReplication>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeReplication>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppVolumeReplicationStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeReplicationStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeReplicationStatus>
    {
        internal NetAppVolumeReplicationStatus() { }
        public string ErrorMessage { get { throw null; } }
        public bool? IsHealthy { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppMirrorState? MirrorState { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetAppRelationshipStatus? RelationshipStatus { get { throw null; } }
        public string TotalProgress { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeReplicationStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeReplicationStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeReplicationStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeReplicationStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeReplicationStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeReplicationStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeReplicationStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetAppVolumeRevertContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeRevertContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeRevertContent>
    {
        public NetAppVolumeRevertContent() { }
        public string SnapshotId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeRevertContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeRevertContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeRevertContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeRevertContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeRevertContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeRevertContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeRevertContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppVolumeSecurityStyle : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppVolumeSecurityStyle(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle Ntfs { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle Unix { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle left, Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle left, Azure.ResourceManager.NetApp.Models.NetAppVolumeSecurityStyle right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetAppVolumeSnapshotRestoreFilesContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeSnapshotRestoreFilesContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeSnapshotRestoreFilesContent>
    {
        public NetAppVolumeSnapshotRestoreFilesContent(System.Collections.Generic.IEnumerable<string> filePaths) { }
        public string DestinationPath { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> FilePaths { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeSnapshotRestoreFilesContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeSnapshotRestoreFilesContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeSnapshotRestoreFilesContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetAppVolumeSnapshotRestoreFilesContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeSnapshotRestoreFilesContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeSnapshotRestoreFilesContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetAppVolumeSnapshotRestoreFilesContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetAppVolumeStorageToNetworkProximity : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetAppVolumeStorageToNetworkProximity(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity AcrossT2 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity Default { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity T1 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity T2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity left, Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity left, Azure.ResourceManager.NetApp.Models.NetAppVolumeStorageToNetworkProximity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkSiblingSet : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetworkSiblingSet>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetworkSiblingSet>
    {
        internal NetworkSiblingSet() { }
        public Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature? NetworkFeatures { get { throw null; } }
        public string NetworkSiblingSetId { get { throw null; } }
        public string NetworkSiblingSetStateId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.NetApp.Models.NicInfo> NicInfoList { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.NetworkSiblingSetProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetworkSiblingSet System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetworkSiblingSet>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NetworkSiblingSet>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NetworkSiblingSet System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetworkSiblingSet>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetworkSiblingSet>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NetworkSiblingSet>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct NetworkSiblingSetProvisioningState : System.IEquatable<Azure.ResourceManager.NetApp.Models.NetworkSiblingSetProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public NetworkSiblingSetProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.NetworkSiblingSetProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetworkSiblingSetProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetworkSiblingSetProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.NetworkSiblingSetProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.NetworkSiblingSetProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.NetworkSiblingSetProvisioningState left, Azure.ResourceManager.NetApp.Models.NetworkSiblingSetProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.NetworkSiblingSetProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.NetworkSiblingSetProvisioningState left, Azure.ResourceManager.NetApp.Models.NetworkSiblingSetProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NfsUser : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NfsUser>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NfsUser>
    {
        public NfsUser() { }
        public long? GroupId { get { throw null; } set { } }
        public long? UserId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NfsUser System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NfsUser>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NfsUser>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NfsUser System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NfsUser>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NfsUser>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NfsUser>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NicInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NicInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NicInfo>
    {
        internal NicInfo() { }
        public string IPAddress { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.Core.ResourceIdentifier> VolumeResourceIds { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NicInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NicInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.NicInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.NicInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NicInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NicInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.NicInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PeerClusterForVolumeMigrationContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.PeerClusterForVolumeMigrationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.PeerClusterForVolumeMigrationContent>
    {
        public PeerClusterForVolumeMigrationContent(System.Collections.Generic.IEnumerable<string> peerIPAddresses) { }
        public System.Collections.Generic.IList<string> PeerIPAddresses { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.PeerClusterForVolumeMigrationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.PeerClusterForVolumeMigrationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.PeerClusterForVolumeMigrationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.PeerClusterForVolumeMigrationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.PeerClusterForVolumeMigrationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.PeerClusterForVolumeMigrationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.PeerClusterForVolumeMigrationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class QueryNetworkSiblingSetContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.QueryNetworkSiblingSetContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.QueryNetworkSiblingSetContent>
    {
        public QueryNetworkSiblingSetContent(string networkSiblingSetId, Azure.Core.ResourceIdentifier subnetId) { }
        public string NetworkSiblingSetId { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.QueryNetworkSiblingSetContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.QueryNetworkSiblingSetContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.QueryNetworkSiblingSetContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.QueryNetworkSiblingSetContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.QueryNetworkSiblingSetContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.QueryNetworkSiblingSetContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.QueryNetworkSiblingSetContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RegionStorageToNetworkProximity : System.IEquatable<Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RegionStorageToNetworkProximity(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity AcrossT2 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity Default { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity T1 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity T1AndAcrossT2 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity T1AndT2 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity T1AndT2AndAcrossT2 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity T2 { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity T2AndAcrossT2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity left, Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity left, Azure.ResourceManager.NetApp.Models.RegionStorageToNetworkProximity right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RelocateVolumeContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.RelocateVolumeContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.RelocateVolumeContent>
    {
        public RelocateVolumeContent() { }
        public string CreationToken { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.RelocateVolumeContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.RelocateVolumeContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.RelocateVolumeContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.RelocateVolumeContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.RelocateVolumeContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.RelocateVolumeContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.RelocateVolumeContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemotePath : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.RemotePath>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.RemotePath>
    {
        public RemotePath(string externalHostName, string serverName, string volumeName) { }
        public string ExternalHostName { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
        public string VolumeName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.RemotePath System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.RemotePath>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.RemotePath>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.RemotePath System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.RemotePath>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.RemotePath>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.RemotePath>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SmbAccessBasedEnumeration : System.IEquatable<Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SmbAccessBasedEnumeration(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration Disabled { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration left, Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration left, Azure.ResourceManager.NetApp.Models.SmbAccessBasedEnumeration right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SmbNonBrowsable : System.IEquatable<Azure.ResourceManager.NetApp.Models.SmbNonBrowsable>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SmbNonBrowsable(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.SmbNonBrowsable Disabled { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.SmbNonBrowsable Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.SmbNonBrowsable other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.SmbNonBrowsable left, Azure.ResourceManager.NetApp.Models.SmbNonBrowsable right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.SmbNonBrowsable (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.SmbNonBrowsable left, Azure.ResourceManager.NetApp.Models.SmbNonBrowsable right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SnapshotPolicyDailySchedule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyDailySchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyDailySchedule>
    {
        public SnapshotPolicyDailySchedule() { }
        public int? Hour { get { throw null; } set { } }
        public int? Minute { get { throw null; } set { } }
        public int? SnapshotsToKeep { get { throw null; } set { } }
        public long? UsedBytes { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.SnapshotPolicyDailySchedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyDailySchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyDailySchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.SnapshotPolicyDailySchedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyDailySchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyDailySchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyDailySchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SnapshotPolicyHourlySchedule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyHourlySchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyHourlySchedule>
    {
        public SnapshotPolicyHourlySchedule() { }
        public int? Minute { get { throw null; } set { } }
        public int? SnapshotsToKeep { get { throw null; } set { } }
        public long? UsedBytes { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.SnapshotPolicyHourlySchedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyHourlySchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyHourlySchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.SnapshotPolicyHourlySchedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyHourlySchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyHourlySchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyHourlySchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SnapshotPolicyMonthlySchedule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyMonthlySchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyMonthlySchedule>
    {
        public SnapshotPolicyMonthlySchedule() { }
        public string DaysOfMonth { get { throw null; } set { } }
        public int? Hour { get { throw null; } set { } }
        public int? Minute { get { throw null; } set { } }
        public int? SnapshotsToKeep { get { throw null; } set { } }
        public long? UsedBytes { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.SnapshotPolicyMonthlySchedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyMonthlySchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyMonthlySchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.SnapshotPolicyMonthlySchedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyMonthlySchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyMonthlySchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyMonthlySchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SnapshotPolicyPatch : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyPatch>
    {
        public SnapshotPolicyPatch(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.NetApp.Models.SnapshotPolicyDailySchedule DailySchedule { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.SnapshotPolicyHourlySchedule HourlySchedule { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.NetApp.Models.SnapshotPolicyMonthlySchedule MonthlySchedule { get { throw null; } set { } }
        public string ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.NetApp.Models.SnapshotPolicyWeeklySchedule WeeklySchedule { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.SnapshotPolicyPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.SnapshotPolicyPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SnapshotPolicyWeeklySchedule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyWeeklySchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyWeeklySchedule>
    {
        public SnapshotPolicyWeeklySchedule() { }
        public string Day { get { throw null; } set { } }
        public int? Hour { get { throw null; } set { } }
        public int? Minute { get { throw null; } set { } }
        public int? SnapshotsToKeep { get { throw null; } set { } }
        public long? UsedBytes { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.SnapshotPolicyWeeklySchedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyWeeklySchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyWeeklySchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.SnapshotPolicyWeeklySchedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyWeeklySchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyWeeklySchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.SnapshotPolicyWeeklySchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SvmPeerCommandResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.SvmPeerCommandResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.SvmPeerCommandResult>
    {
        internal SvmPeerCommandResult() { }
        public string SvmPeeringCommand { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.SvmPeerCommandResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.SvmPeerCommandResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.SvmPeerCommandResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.SvmPeerCommandResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.SvmPeerCommandResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.SvmPeerCommandResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.SvmPeerCommandResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UpdateNetworkSiblingSetContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.UpdateNetworkSiblingSetContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.UpdateNetworkSiblingSetContent>
    {
        public UpdateNetworkSiblingSetContent(string networkSiblingSetId, Azure.Core.ResourceIdentifier subnetId, string networkSiblingSetStateId, Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature networkFeatures) { }
        public Azure.ResourceManager.NetApp.Models.NetAppNetworkFeature NetworkFeatures { get { throw null; } }
        public string NetworkSiblingSetId { get { throw null; } }
        public string NetworkSiblingSetStateId { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.UpdateNetworkSiblingSetContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.UpdateNetworkSiblingSetContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.NetApp.Models.UpdateNetworkSiblingSetContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.NetApp.Models.UpdateNetworkSiblingSetContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.UpdateNetworkSiblingSetContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.UpdateNetworkSiblingSetContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.NetApp.Models.UpdateNetworkSiblingSetContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VolumeReplicationRelationshipStatus : System.IEquatable<Azure.ResourceManager.NetApp.Models.VolumeReplicationRelationshipStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VolumeReplicationRelationshipStatus(string value) { throw null; }
        public static Azure.ResourceManager.NetApp.Models.VolumeReplicationRelationshipStatus Idle { get { throw null; } }
        public static Azure.ResourceManager.NetApp.Models.VolumeReplicationRelationshipStatus Transferring { get { throw null; } }
        public bool Equals(Azure.ResourceManager.NetApp.Models.VolumeReplicationRelationshipStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.NetApp.Models.VolumeReplicationRelationshipStatus left, Azure.ResourceManager.NetApp.Models.VolumeReplicationRelationshipStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.NetApp.Models.VolumeReplicationRelationshipStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.NetApp.Models.VolumeReplicationRelationshipStatus left, Azure.ResourceManager.NetApp.Models.VolumeReplicationRelationshipStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
}
