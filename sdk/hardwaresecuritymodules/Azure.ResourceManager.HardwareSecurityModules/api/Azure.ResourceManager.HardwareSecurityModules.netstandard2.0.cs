namespace Azure.ResourceManager.HardwareSecurityModules
{
    public partial class AzureResourceManagerHardwareSecurityModulesContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerHardwareSecurityModulesContext() { }
        public static Azure.ResourceManager.HardwareSecurityModules.AzureResourceManagerHardwareSecurityModulesContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class CloudHsmClusterCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource>, System.Collections.IEnumerable
    {
        protected CloudHsmClusterCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string cloudHsmClusterName, Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string cloudHsmClusterName, Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string cloudHsmClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string cloudHsmClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource> Get(string cloudHsmClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource> GetAll(string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource> GetAllAsync(string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource>> GetAsync(string cloudHsmClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource> GetIfExists(string cloudHsmClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource>> GetIfExistsAsync(string cloudHsmClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CloudHsmClusterData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData>
    {
        public CloudHsmClusterData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterSku Sku { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudHsmClusterPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected CloudHsmClusterPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string peConnectionName, Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string peConnectionName, Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string peConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string peConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionResource> Get(string peConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionResource>> GetAsync(string peConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionResource> GetIfExists(string peConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionResource>> GetIfExistsAsync(string peConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class CloudHsmClusterPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionData>
    {
        public CloudHsmClusterPrivateEndpointConnectionData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudHsmClusterPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CloudHsmClusterPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudHsmClusterName, string peConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class CloudHsmClusterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CloudHsmClusterResource() { }
        public virtual Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupResult> Backup(Azure.WaitUntil waitUntil, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupResult>> BackupAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudHsmClusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupResult> GetCloudHsmClusterBackupStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupResult>> GetCloudHsmClusterBackupStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionResource> GetCloudHsmClusterPrivateEndpointConnection(string peConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionResource>> GetCloudHsmClusterPrivateEndpointConnectionAsync(string peConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionCollection GetCloudHsmClusterPrivateEndpointConnections() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkData> GetCloudHsmClusterPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkData> GetCloudHsmClusterPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterRestoreResult> GetCloudHsmClusterRestoreStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterRestoreResult>> GetCloudHsmClusterRestoreStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterRestoreResult> Restore(Azure.WaitUntil waitUntil, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterRestoreResult>> RestoreAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterRestoreContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupResult> ValidateBackupProperties(Azure.WaitUntil waitUntil, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupResult>> ValidateBackupPropertiesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterRestoreResult> ValidateRestoreProperties(Azure.WaitUntil waitUntil, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterRestoreContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterRestoreResult>> ValidateRestorePropertiesAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterRestoreContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DedicatedHsmCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource>, System.Collections.IEnumerable
    {
        protected DedicatedHsmCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string name, Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource> Get(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource> GetAll(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource> GetAllAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource>> GetAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource> GetIfExists(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource>> GetIfExistsAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DedicatedHsmData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmData>
    {
        public DedicatedHsmData(Azure.Core.AzureLocation location, Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmProperties properties, Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmSku sku) { }
        public Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmSkuName? SkuName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DedicatedHsmResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DedicatedHsmResource() { }
        public virtual Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string name) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEgressEndpoint> GetOutboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEgressEndpoint> GetOutboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class HardwareSecurityModulesExtensions
    {
        public static Azure.Response<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource> GetCloudHsmCluster(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudHsmClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource>> GetCloudHsmClusterAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string cloudHsmClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionResource GetCloudHsmClusterPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource GetCloudHsmClusterResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterCollection GetCloudHsmClusters(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource> GetCloudHsmClusters(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource> GetCloudHsmClustersAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource> GetDedicatedHsm(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource>> GetDedicatedHsmAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource GetDedicatedHsmResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmCollection GetDedicatedHsms(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource> GetDedicatedHsms(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource> GetDedicatedHsmsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HardwareSecurityModules.Mocking
{
    public partial class MockableHardwareSecurityModulesArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableHardwareSecurityModulesArmClient() { }
        public virtual Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionResource GetCloudHsmClusterPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource GetCloudHsmClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource GetDedicatedHsmResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableHardwareSecurityModulesResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHardwareSecurityModulesResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource> GetCloudHsmCluster(string cloudHsmClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource>> GetCloudHsmClusterAsync(string cloudHsmClusterName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterCollection GetCloudHsmClusters() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource> GetDedicatedHsm(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource>> GetDedicatedHsmAsync(string name, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmCollection GetDedicatedHsms() { throw null; }
    }
    public partial class MockableHardwareSecurityModulesSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableHardwareSecurityModulesSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource> GetCloudHsmClusters(string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource> GetCloudHsmClustersAsync(string skiptoken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource> GetDedicatedHsms(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource> GetDedicatedHsmsAsync(int? top = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HardwareSecurityModules.Models
{
    public static partial class ArmHardwareSecurityModulesModelFactory
    {
        public static Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreBaseResultProperties BackupRestoreBaseResultProperties(Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreOperationStatus? status = default(Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreOperationStatus?), string statusDetails = null, Azure.ResponseError error = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string jobId = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreRequestBaseProperties BackupRestoreRequestBaseProperties(System.Uri azureStorageBlobContainerUri = null, string token = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupContent CloudHsmClusterBackupContent(System.Uri azureStorageBlobContainerUri = null, string token = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupResult CloudHsmClusterBackupResult(Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupResultProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupResultProperties CloudHsmClusterBackupResultProperties(Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreOperationStatus? status = default(Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreOperationStatus?), string statusDetails = null, Azure.ResponseError error = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string jobId = null, System.Uri azureStorageBlobContainerUri = null, string backupId = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData CloudHsmClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterSku sku = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionData CloudHsmClusterPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointConnectionProperties properties = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointConnectionProperties CloudHsmClusterPrivateEndpointConnectionProperties(Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointConnectionProvisioningState?), System.Collections.Generic.IEnumerable<string> groupIds = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkData CloudHsmClusterPrivateLinkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkResourceProperties CloudHsmClusterPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProperties CloudHsmClusterProperties(Azure.ResourceManager.HardwareSecurityModules.Models.SecurityDomainActivationState? activationState = default(Azure.ResourceManager.HardwareSecurityModules.Models.SecurityDomainActivationState?), Azure.ResourceManager.HardwareSecurityModules.Models.AutoGeneratedDomainNameLabelScope? autoGeneratedDomainNameLabelScope = default(Azure.ResourceManager.HardwareSecurityModules.Models.AutoGeneratedDomainNameLabelScope?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmProperties> hsms = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProvisioningState? provisioningState = default(Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProvisioningState?), Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPublicNetworkAccess?), string statusMessage = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterRestoreContent CloudHsmClusterRestoreContent(System.Uri azureStorageBlobContainerUri = null, string token = null, string backupId = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterRestoreResult CloudHsmClusterRestoreResult(Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreBaseResultProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmProperties CloudHsmProperties(string fqdn = null, string state = null, string stateMessage = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmData DedicatedHsmData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmProperties properties = null, Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmSkuName? skuName = default(Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmSkuName?), System.Collections.Generic.IEnumerable<string> zones = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEgressEndpoint DedicatedHsmEgressEndpoint(string category = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEndpointDependency> endpoints = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEndpointDependency DedicatedHsmEndpointDependency(string domainName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEndpointDetail> endpointDetails = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEndpointDetail DedicatedHsmEndpointDetail(string ipAddress = null, int? port = default(int?), string protocol = null, string description = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmNetworkInterface DedicatedHsmNetworkInterface(Azure.Core.ResourceIdentifier resourceId = null, string privateIPAddress = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmProperties DedicatedHsmProperties(Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmNetworkProfile networkProfile = null, Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmNetworkProfile managementNetworkProfile = null, string stampId = null, string statusMessage = null, Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmJsonWebKeyType? provisioningState = default(Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmJsonWebKeyType?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoGeneratedDomainNameLabelScope : System.IEquatable<Azure.ResourceManager.HardwareSecurityModules.Models.AutoGeneratedDomainNameLabelScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoGeneratedDomainNameLabelScope(string value) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.AutoGeneratedDomainNameLabelScope NoReuse { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.AutoGeneratedDomainNameLabelScope ResourceGroupReuse { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.AutoGeneratedDomainNameLabelScope SubscriptionReuse { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.AutoGeneratedDomainNameLabelScope TenantReuse { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HardwareSecurityModules.Models.AutoGeneratedDomainNameLabelScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HardwareSecurityModules.Models.AutoGeneratedDomainNameLabelScope left, Azure.ResourceManager.HardwareSecurityModules.Models.AutoGeneratedDomainNameLabelScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.HardwareSecurityModules.Models.AutoGeneratedDomainNameLabelScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HardwareSecurityModules.Models.AutoGeneratedDomainNameLabelScope left, Azure.ResourceManager.HardwareSecurityModules.Models.AutoGeneratedDomainNameLabelScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BackupRestoreBaseResultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreBaseResultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreBaseResultProperties>
    {
        internal BackupRestoreBaseResultProperties() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreOperationStatus? Status { get { throw null; } }
        public string StatusDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreBaseResultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreBaseResultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreBaseResultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreBaseResultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreBaseResultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreBaseResultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreBaseResultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupRestoreOperationStatus : System.IEquatable<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreOperationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupRestoreOperationStatus(string value) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreOperationStatus Cancelled { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreOperationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreOperationStatus InProgress { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreOperationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreOperationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreOperationStatus left, Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreOperationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreOperationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreOperationStatus left, Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreOperationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BackupRestoreRequestBaseProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreRequestBaseProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreRequestBaseProperties>
    {
        public BackupRestoreRequestBaseProperties(System.Uri azureStorageBlobContainerUri) { }
        public System.Uri AzureStorageBlobContainerUri { get { throw null; } }
        public string Token { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreRequestBaseProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreRequestBaseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreRequestBaseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreRequestBaseProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreRequestBaseProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreRequestBaseProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreRequestBaseProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudHsmClusterBackupContent : Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreRequestBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupContent>
    {
        public CloudHsmClusterBackupContent(System.Uri azureStorageBlobContainerUri) : base (default(System.Uri)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudHsmClusterBackupResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupResult>
    {
        internal CloudHsmClusterBackupResult() { }
        public Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupResultProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudHsmClusterBackupResultProperties : Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreBaseResultProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupResultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupResultProperties>
    {
        internal CloudHsmClusterBackupResultProperties() { }
        public System.Uri AzureStorageBlobContainerUri { get { throw null; } }
        public string BackupId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupResultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupResultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupResultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupResultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupResultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupResultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterBackupResultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudHsmClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPatch>
    {
        public CloudHsmClusterPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudHsmClusterPrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointConnectionProperties>
    {
        public CloudHsmClusterPrivateEndpointConnectionProperties(Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkServiceConnectionState connectionState) { }
        public Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudHsmClusterPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudHsmClusterPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointConnectionProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointConnectionProvisioningState InternalError { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointConnectionProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudHsmClusterPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudHsmClusterPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CloudHsmClusterPrivateLinkData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkData>
    {
        public CloudHsmClusterPrivateLinkData() { }
        public Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkResourceProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudHsmClusterPrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkResourceProperties>
    {
        public CloudHsmClusterPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudHsmClusterPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkServiceConnectionState>
    {
        public CloudHsmClusterPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudHsmClusterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProperties>
    {
        public CloudHsmClusterProperties() { }
        public Azure.ResourceManager.HardwareSecurityModules.Models.SecurityDomainActivationState? ActivationState { get { throw null; } }
        public Azure.ResourceManager.HardwareSecurityModules.Models.AutoGeneratedDomainNameLabelScope? AutoGeneratedDomainNameLabelScope { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmProperties> Hsms { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public string StatusMessage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudHsmClusterProvisioningState : System.IEquatable<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudHsmClusterProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProvisioningState left, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProvisioningState left, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudHsmClusterPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudHsmClusterPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPublicNetworkAccess Disabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPublicNetworkAccess left, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPublicNetworkAccess left, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CloudHsmClusterRestoreContent : Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreRequestBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterRestoreContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterRestoreContent>
    {
        public CloudHsmClusterRestoreContent(System.Uri azureStorageBlobContainerUri, string backupId) : base (default(System.Uri)) { }
        public string BackupId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterRestoreContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterRestoreContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterRestoreContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterRestoreContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterRestoreContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterRestoreContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterRestoreContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudHsmClusterRestoreResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterRestoreResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterRestoreResult>
    {
        internal CloudHsmClusterRestoreResult() { }
        public Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreBaseResultProperties Properties { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterRestoreResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterRestoreResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterRestoreResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterRestoreResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterRestoreResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterRestoreResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterRestoreResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudHsmClusterSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterSku>
    {
        public CloudHsmClusterSku(Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterSkuFamily family, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterSkuName name) { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterSkuFamily Family { get { throw null; } set { } }
        public Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterSkuName Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CloudHsmClusterSkuFamily : System.IEquatable<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterSkuFamily>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CloudHsmClusterSkuFamily(string value) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterSkuFamily B { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterSkuFamily other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterSkuFamily left, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterSkuFamily right) { throw null; }
        public static implicit operator Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterSkuFamily (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterSkuFamily left, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterSkuFamily right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum CloudHsmClusterSkuName
    {
        StandardB1 = 0,
        StandardB10 = 1,
    }
    public partial class CloudHsmProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmProperties>
    {
        internal CloudHsmProperties() { }
        public string Fqdn { get { throw null; } }
        public string State { get { throw null; } }
        public string StateMessage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DedicatedHsmEgressEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEgressEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEgressEndpoint>
    {
        internal DedicatedHsmEgressEndpoint() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEndpointDependency> Endpoints { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEgressEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEgressEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEgressEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEgressEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEgressEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEgressEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEgressEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DedicatedHsmEndpointDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEndpointDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEndpointDependency>
    {
        internal DedicatedHsmEndpointDependency() { }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEndpointDetail> EndpointDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEndpointDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEndpointDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEndpointDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEndpointDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEndpointDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEndpointDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEndpointDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DedicatedHsmEndpointDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEndpointDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEndpointDetail>
    {
        internal DedicatedHsmEndpointDetail() { }
        public string Description { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public int? Port { get { throw null; } }
        public string Protocol { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEndpointDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEndpointDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEndpointDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEndpointDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEndpointDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEndpointDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmEndpointDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DedicatedHsmJsonWebKeyType : System.IEquatable<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmJsonWebKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DedicatedHsmJsonWebKeyType(string value) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmJsonWebKeyType Allocating { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmJsonWebKeyType CheckingQuota { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmJsonWebKeyType Connecting { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmJsonWebKeyType Deleting { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmJsonWebKeyType Failed { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmJsonWebKeyType Provisioning { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmJsonWebKeyType Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmJsonWebKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmJsonWebKeyType left, Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmJsonWebKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmJsonWebKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmJsonWebKeyType left, Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmJsonWebKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DedicatedHsmNetworkInterface : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmNetworkInterface>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmNetworkInterface>
    {
        public DedicatedHsmNetworkInterface() { }
        public string PrivateIPAddress { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmNetworkInterface System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmNetworkInterface>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmNetworkInterface>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmNetworkInterface System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmNetworkInterface>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmNetworkInterface>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmNetworkInterface>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DedicatedHsmNetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmNetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmNetworkProfile>
    {
        public DedicatedHsmNetworkProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmNetworkInterface> NetworkInterfaces { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmNetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmNetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmNetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmNetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmNetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmNetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmNetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DedicatedHsmPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmPatch>
    {
        public DedicatedHsmPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DedicatedHsmProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmProperties>
    {
        public DedicatedHsmProperties() { }
        public Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmNetworkProfile ManagementNetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmNetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmJsonWebKeyType? ProvisioningState { get { throw null; } }
        public string StampId { get { throw null; } set { } }
        public string StatusMessage { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DedicatedHsmSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmSku>
    {
        public DedicatedHsmSku() { }
        public Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmSkuName? Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DedicatedHsmSkuName : System.IEquatable<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DedicatedHsmSkuName(string value) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmSkuName PayShield10KLmk1Cps250 { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmSkuName PayShield10KLmk1Cps2500 { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmSkuName PayShield10KLmk1Cps60 { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmSkuName PayShield10KLmk2Cps250 { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmSkuName PayShield10KLmk2Cps2500 { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmSkuName PayShield10KLmk2Cps60 { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmSkuName SafeNetLunaNetworkHsmA790 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmSkuName left, Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmSkuName left, Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SecurityDomainActivationState : System.IEquatable<Azure.ResourceManager.HardwareSecurityModules.Models.SecurityDomainActivationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SecurityDomainActivationState(string value) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.SecurityDomainActivationState Active { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.SecurityDomainActivationState Failed { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.SecurityDomainActivationState NotActivated { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.SecurityDomainActivationState NotDefined { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.SecurityDomainActivationState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HardwareSecurityModules.Models.SecurityDomainActivationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HardwareSecurityModules.Models.SecurityDomainActivationState left, Azure.ResourceManager.HardwareSecurityModules.Models.SecurityDomainActivationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HardwareSecurityModules.Models.SecurityDomainActivationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HardwareSecurityModules.Models.SecurityDomainActivationState left, Azure.ResourceManager.HardwareSecurityModules.Models.SecurityDomainActivationState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
