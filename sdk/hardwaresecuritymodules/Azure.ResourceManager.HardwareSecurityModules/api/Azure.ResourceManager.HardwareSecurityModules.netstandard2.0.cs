namespace Azure.ResourceManager.HardwareSecurityModules
{
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
        Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudHsmClusterResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected CloudHsmClusterResource() { }
        public virtual Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.Models.BackupResult> Backup(Azure.WaitUntil waitUntil, Azure.ResourceManager.HardwareSecurityModules.Models.BackupRequestProperties backupRequestProperties = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.Models.BackupResult>> BackupAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HardwareSecurityModules.Models.BackupRequestProperties backupRequestProperties = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudHsmClusterName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HardwareSecurityModules.Models.BackupResult> GetCloudHsmClusterBackupStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HardwareSecurityModules.Models.BackupResult>> GetCloudHsmClusterBackupStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkData> GetCloudHsmClusterPrivateLinkResources(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkData> GetCloudHsmClusterPrivateLinkResourcesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HardwareSecurityModules.Models.RestoreResult> GetCloudHsmClusterRestoreStatus(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HardwareSecurityModules.Models.RestoreResult>> GetCloudHsmClusterRestoreStatusAsync(string jobId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionResource> GetHardwareSecurityModulesPrivateEndpointConnection(string peConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionResource>> GetHardwareSecurityModulesPrivateEndpointConnectionAsync(string peConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionCollection GetHardwareSecurityModulesPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.Models.RestoreResult> Restore(Azure.WaitUntil waitUntil, Azure.ResourceManager.HardwareSecurityModules.Models.RestoreRequestProperties restoreRequestProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.Models.RestoreResult>> RestoreAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HardwareSecurityModules.Models.RestoreRequestProperties restoreRequestProperties, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.Models.BackupResult> ValidateBackup(Azure.WaitUntil waitUntil, Azure.ResourceManager.HardwareSecurityModules.Models.BackupRequestProperties backupRequestProperties = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.Models.BackupResult>> ValidateBackupAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HardwareSecurityModules.Models.BackupRequestProperties backupRequestProperties = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.Models.RestoreResult> ValidateRestore(Azure.WaitUntil waitUntil, Azure.ResourceManager.HardwareSecurityModules.Models.RestoreRequestProperties restoreRequestProperties = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.Models.RestoreResult>> ValidateRestoreAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HardwareSecurityModules.Models.RestoreRequestProperties restoreRequestProperties = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public DedicatedHsmData(Azure.Core.AzureLocation location, Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesSku sku, Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmProperties properties) { }
        public Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesSkuName? SkuName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
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
        public virtual Azure.Pageable<Azure.ResourceManager.HardwareSecurityModules.Models.OutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HardwareSecurityModules.Models.OutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public static Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionResource GetHardwareSecurityModulesPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class HardwareSecurityModulesPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected HardwareSecurityModulesPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string peConnectionName, Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string peConnectionName, Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string peConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string peConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionResource> Get(string peConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionResource>> GetAsync(string peConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionResource> GetIfExists(string peConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionResource>> GetIfExistsAsync(string peConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class HardwareSecurityModulesPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionData>
    {
        public HardwareSecurityModulesPrivateEndpointConnectionData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.HardwareSecurityModules.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HardwareSecurityModulesPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected HardwareSecurityModulesPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string cloudHsmClusterName, string peConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.HardwareSecurityModules.Mocking
{
    public partial class MockableHardwareSecurityModulesArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableHardwareSecurityModulesArmClient() { }
        public virtual Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterResource GetCloudHsmClusterResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmResource GetDedicatedHsmResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionResource GetHardwareSecurityModulesPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
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
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ActivationState : System.IEquatable<Azure.ResourceManager.HardwareSecurityModules.Models.ActivationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ActivationState(string value) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.ActivationState Active { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.ActivationState Failed { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.ActivationState NotActivated { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.ActivationState NotDefined { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.ActivationState Unknown { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HardwareSecurityModules.Models.ActivationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HardwareSecurityModules.Models.ActivationState left, Azure.ResourceManager.HardwareSecurityModules.Models.ActivationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HardwareSecurityModules.Models.ActivationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HardwareSecurityModules.Models.ActivationState left, Azure.ResourceManager.HardwareSecurityModules.Models.ActivationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmHardwareSecurityModulesModelFactory
    {
        public static Azure.ResourceManager.HardwareSecurityModules.Models.BackupRequestProperties BackupRequestProperties(System.Uri azureStorageBlobContainerUri = null, string token = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreBaseResult BackupRestoreBaseResult(Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreOperationStatus? status = default(Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreOperationStatus?), string statusDetails = null, Azure.ResponseError error = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string jobId = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreRequestBaseProperties BackupRestoreRequestBaseProperties(System.Uri azureStorageBlobContainerUri = null, string token = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.BackupResult BackupResult(Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreOperationStatus? status = default(Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreOperationStatus?), string statusDetails = null, Azure.ResponseError error = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string jobId = null, System.Uri azureStorageBlobContainerUri = null, string backupId = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.CloudHsmClusterData CloudHsmClusterData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterSku sku = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProperties CloudHsmClusterProperties(Azure.ResourceManager.HardwareSecurityModules.Models.ActivationState? activationState = default(Azure.ResourceManager.HardwareSecurityModules.Models.ActivationState?), string autoGeneratedDomainNameLabelScope = null, bool? fipsApprovedMode = default(bool?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmProperties> hsms = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.HardwareSecurityModules.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.HardwareSecurityModules.Models.ProvisioningState?), string publicNetworkAccess = null, string statusMessage = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmProperties CloudHsmProperties(string fqdn = null, string state = null, string stateMessage = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.DedicatedHsmData DedicatedHsmData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesSkuName? skuName = default(Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesSkuName?), System.Collections.Generic.IEnumerable<string> zones = null, Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmProperties DedicatedHsmProperties(Azure.ResourceManager.HardwareSecurityModules.Models.NetworkProfile networkProfile = null, Azure.ResourceManager.HardwareSecurityModules.Models.NetworkProfile managementNetworkProfile = null, string stampId = null, string statusMessage = null, Azure.ResourceManager.HardwareSecurityModules.Models.JsonWebKeyType? provisioningState = default(Azure.ResourceManager.HardwareSecurityModules.Models.JsonWebKeyType?)) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.EndpointDependency EndpointDependency(string domainName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HardwareSecurityModules.Models.EndpointDetail> endpointDetails = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.EndpointDetail EndpointDetail(string ipAddress = null, int? port = default(int?), string protocol = null, string description = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionData HardwareSecurityModulesPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HardwareSecurityModules.Models.PrivateEndpointConnectionProperties properties = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkData HardwareSecurityModulesPrivateLinkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkResourceProperties HardwareSecurityModulesPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.NetworkInterface NetworkInterface(string resourceId = null, string privateIPAddress = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.OutboundEnvironmentEndpoint OutboundEnvironmentEndpoint(string category = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.HardwareSecurityModules.Models.EndpointDependency> endpoints = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.PrivateEndpointConnectionProperties PrivateEndpointConnectionProperties(Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkServiceConnectionState connectionState = null, Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateEndpointConnectionProvisioningState?), System.Collections.Generic.IEnumerable<string> groupIds = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.RestoreRequestProperties RestoreRequestProperties(System.Uri azureStorageBlobContainerUri = null, string token = null, string backupId = null) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.RestoreResult RestoreResult(Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreOperationStatus? status = default(Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreOperationStatus?), string statusDetails = null, Azure.ResponseError error = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string jobId = null) { throw null; }
    }
    public partial class BackupRequestProperties : Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreRequestBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRequestProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRequestProperties>
    {
        public BackupRequestProperties(System.Uri azureStorageBlobContainerUri) : base (default(System.Uri)) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.BackupRequestProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRequestProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRequestProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.BackupRequestProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRequestProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRequestProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRequestProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupRestoreBaseResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreBaseResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreBaseResult>
    {
        internal BackupRestoreBaseResult() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public Azure.ResponseError Error { get { throw null; } }
        public string JobId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreOperationStatus? Status { get { throw null; } }
        public string StatusDetails { get { throw null; } }
        Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreBaseResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreBaseResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreBaseResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreBaseResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreBaseResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreBaseResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreBaseResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreRequestBaseProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreRequestBaseProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreRequestBaseProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreRequestBaseProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreRequestBaseProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreRequestBaseProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreRequestBaseProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupResult : Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreBaseResult, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupResult>
    {
        internal BackupResult() { }
        public System.Uri AzureStorageBlobContainerUri { get { throw null; } }
        public string BackupId { get { throw null; } }
        Azure.ResourceManager.HardwareSecurityModules.Models.BackupResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.BackupResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.BackupResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudHsmClusterPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPatch>
    {
        public CloudHsmClusterPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudHsmClusterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProperties>
    {
        public CloudHsmClusterProperties() { }
        public Azure.ResourceManager.HardwareSecurityModules.Models.ActivationState? ActivationState { get { throw null; } }
        public string AutoGeneratedDomainNameLabelScope { get { throw null; } set { } }
        public bool? FipsApprovedMode { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmProperties> Hsms { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HardwareSecurityModules.HardwareSecurityModulesPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.HardwareSecurityModules.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public string PublicNetworkAccess { get { throw null; } set { } }
        public string StatusMessage { get { throw null; } }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class CloudHsmClusterSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterSku>
    {
        public CloudHsmClusterSku(Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterSkuFamily family, Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterSkuName name) { }
        public int? Capacity { get { throw null; } set { } }
        public Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterSkuFamily Family { get { throw null; } set { } }
        public Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmClusterSkuName Name { get { throw null; } set { } }
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
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.CloudHsmProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DedicatedHsmPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmPatch>
    {
        public DedicatedHsmPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DedicatedHsmProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmProperties>
    {
        public DedicatedHsmProperties() { }
        public Azure.ResourceManager.HardwareSecurityModules.Models.NetworkProfile ManagementNetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HardwareSecurityModules.Models.NetworkProfile NetworkProfile { get { throw null; } set { } }
        public Azure.ResourceManager.HardwareSecurityModules.Models.JsonWebKeyType? ProvisioningState { get { throw null; } }
        public string StampId { get { throw null; } set { } }
        public string StatusMessage { get { throw null; } }
        Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.DedicatedHsmProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EndpointDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.EndpointDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.EndpointDependency>
    {
        internal EndpointDependency() { }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HardwareSecurityModules.Models.EndpointDetail> EndpointDetails { get { throw null; } }
        Azure.ResourceManager.HardwareSecurityModules.Models.EndpointDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.EndpointDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.EndpointDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.EndpointDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.EndpointDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.EndpointDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.EndpointDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EndpointDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.EndpointDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.EndpointDetail>
    {
        internal EndpointDetail() { }
        public string Description { get { throw null; } }
        public string IPAddress { get { throw null; } }
        public int? Port { get { throw null; } }
        public string Protocol { get { throw null; } }
        Azure.ResourceManager.HardwareSecurityModules.Models.EndpointDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.EndpointDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.EndpointDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.EndpointDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.EndpointDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.EndpointDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.EndpointDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HardwareSecurityModulesPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HardwareSecurityModulesPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateEndpointConnectionProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateEndpointConnectionProvisioningState InternalError { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateEndpointConnectionProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HardwareSecurityModulesPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HardwareSecurityModulesPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class HardwareSecurityModulesPrivateLinkData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkData>
    {
        public HardwareSecurityModulesPrivateLinkData() { }
        public Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkResourceProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HardwareSecurityModulesPrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkResourceProperties>
    {
        public HardwareSecurityModulesPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HardwareSecurityModulesPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkServiceConnectionState>
    {
        public HardwareSecurityModulesPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HardwareSecurityModulesSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesSku>
    {
        public HardwareSecurityModulesSku() { }
        public Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesSkuName? Name { get { throw null; } set { } }
        Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct HardwareSecurityModulesSkuName : System.IEquatable<Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public HardwareSecurityModulesSkuName(string value) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesSkuName PayShield10KLMK1CPS250 { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesSkuName PayShield10KLMK1CPS2500 { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesSkuName PayShield10KLMK1CPS60 { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesSkuName PayShield10KLMK2CPS250 { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesSkuName PayShield10KLMK2CPS2500 { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesSkuName PayShield10KLMK2CPS60 { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesSkuName SafeNetLunaNetworkHSMA790 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesSkuName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesSkuName left, Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesSkuName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesSkuName left, Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct JsonWebKeyType : System.IEquatable<Azure.ResourceManager.HardwareSecurityModules.Models.JsonWebKeyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public JsonWebKeyType(string value) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.JsonWebKeyType Allocating { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.JsonWebKeyType CheckingQuota { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.JsonWebKeyType Connecting { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.JsonWebKeyType Deleting { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.JsonWebKeyType Failed { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.JsonWebKeyType Provisioning { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.JsonWebKeyType Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HardwareSecurityModules.Models.JsonWebKeyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HardwareSecurityModules.Models.JsonWebKeyType left, Azure.ResourceManager.HardwareSecurityModules.Models.JsonWebKeyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.HardwareSecurityModules.Models.JsonWebKeyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HardwareSecurityModules.Models.JsonWebKeyType left, Azure.ResourceManager.HardwareSecurityModules.Models.JsonWebKeyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class NetworkInterface : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.NetworkInterface>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.NetworkInterface>
    {
        public NetworkInterface() { }
        public string PrivateIPAddress { get { throw null; } set { } }
        public string ResourceId { get { throw null; } }
        Azure.ResourceManager.HardwareSecurityModules.Models.NetworkInterface System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.NetworkInterface>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.NetworkInterface>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.NetworkInterface System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.NetworkInterface>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.NetworkInterface>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.NetworkInterface>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class NetworkProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.NetworkProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.NetworkProfile>
    {
        public NetworkProfile() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.HardwareSecurityModules.Models.NetworkInterface> NetworkInterfaces { get { throw null; } }
        public Azure.Core.ResourceIdentifier SubnetResourceId { get { throw null; } set { } }
        Azure.ResourceManager.HardwareSecurityModules.Models.NetworkProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.NetworkProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.NetworkProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.NetworkProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.NetworkProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.NetworkProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.NetworkProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OutboundEnvironmentEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.OutboundEnvironmentEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.OutboundEnvironmentEndpoint>
    {
        internal OutboundEnvironmentEndpoint() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.HardwareSecurityModules.Models.EndpointDependency> Endpoints { get { throw null; } }
        Azure.ResourceManager.HardwareSecurityModules.Models.OutboundEnvironmentEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.OutboundEnvironmentEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.OutboundEnvironmentEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.OutboundEnvironmentEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.OutboundEnvironmentEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.OutboundEnvironmentEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.OutboundEnvironmentEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.PrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.PrivateEndpointConnectionProperties>
    {
        public PrivateEndpointConnectionProperties(Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkServiceConnectionState connectionState) { }
        public Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.HardwareSecurityModules.Models.HardwareSecurityModulesPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.HardwareSecurityModules.Models.PrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.PrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.PrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.PrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.PrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.PrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.PrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.HardwareSecurityModules.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.ProvisioningState Provisioning { get { throw null; } }
        public static Azure.ResourceManager.HardwareSecurityModules.Models.ProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.HardwareSecurityModules.Models.ProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.HardwareSecurityModules.Models.ProvisioningState left, Azure.ResourceManager.HardwareSecurityModules.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.HardwareSecurityModules.Models.ProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.HardwareSecurityModules.Models.ProvisioningState left, Azure.ResourceManager.HardwareSecurityModules.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RestoreRequestProperties : Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreRequestBaseProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.RestoreRequestProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.RestoreRequestProperties>
    {
        public RestoreRequestProperties(System.Uri azureStorageBlobContainerUri) : base (default(System.Uri)) { }
        public string BackupId { get { throw null; } set { } }
        Azure.ResourceManager.HardwareSecurityModules.Models.RestoreRequestProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.RestoreRequestProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.RestoreRequestProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.RestoreRequestProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.RestoreRequestProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.RestoreRequestProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.RestoreRequestProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RestoreResult : Azure.ResourceManager.HardwareSecurityModules.Models.BackupRestoreBaseResult, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.RestoreResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.RestoreResult>
    {
        internal RestoreResult() { }
        Azure.ResourceManager.HardwareSecurityModules.Models.RestoreResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.RestoreResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.HardwareSecurityModules.Models.RestoreResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.HardwareSecurityModules.Models.RestoreResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.RestoreResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.RestoreResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.HardwareSecurityModules.Models.RestoreResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
