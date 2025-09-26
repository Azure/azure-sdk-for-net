namespace Azure.ResourceManager.RecoveryServicesBackup
{
    public partial class AzureResourceManagerRecoveryServicesBackupContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerRecoveryServicesBackupContext() { }
        public static Azure.ResourceManager.RecoveryServicesBackup.AzureResourceManagerRecoveryServicesBackupContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class BackupEngineCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource>, System.Collections.IEnumerable
    {
        protected BackupEngineCollection() { }
        public virtual Azure.Response<bool> Exists(string backupEngineName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string backupEngineName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource> Get(string backupEngineName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource> GetAll(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource> GetAllAsync(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource>> GetAsync(string backupEngineName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource> GetIfExists(string backupEngineName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource>> GetIfExistsAsync(string backupEngineName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BackupEngineData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineData>
    {
        public BackupEngineData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericEngine Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupEngineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupEngineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupEngineResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupEngineResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupEngineData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string backupEngineName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource> Get(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource>> GetAsync(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RecoveryServicesBackup.BackupEngineData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupEngineData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource>, System.Collections.IEnumerable
    {
        protected BackupJobCollection() { }
        public virtual Azure.Response<bool> Exists(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource> Get(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource> GetAll(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource> GetAllAsync(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource>> GetAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource> GetIfExists(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource>> GetIfExistsAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BackupJobData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupJobData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupJobData>
    {
        public BackupJobData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericJob Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupJobData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupJobData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupJobData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupJobData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupJobData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupJobData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupJobData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupJobResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupJobData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupJobData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupJobResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string jobName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RecoveryServicesBackup.BackupJobData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupJobData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupJobData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupJobData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupJobData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupJobData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupJobData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response TriggerJobCancellation(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> TriggerJobCancellationAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection
    {
        protected BackupPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vaultName, string privateEndpointConnectionName, Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vaultName, string privateEndpointConnectionName, Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vaultName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vaultName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource> Get(string vaultName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource>> GetAsync(string vaultName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource> GetIfExists(string vaultName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource>> GetIfExistsAsync(string vaultName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupPrivateEndpointConnectionData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData>
    {
        public BackupPrivateEndpointConnectionData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupProtectedItemCollection : Azure.ResourceManager.ArmCollection
    {
        protected BackupProtectedItemCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string protectedItemName, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData data, string xMsAuthorizationAuxiliary = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string protectedItemName, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string protectedItemName, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData data, string xMsAuthorizationAuxiliary = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string protectedItemName, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<bool> Exists(string protectedItemName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string protectedItemName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource> Get(string protectedItemName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource>> GetAsync(string protectedItemName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource> GetIfExists(string protectedItemName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource>> GetIfExistsAsync(string protectedItemName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupProtectedItemData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData>
    {
        public BackupProtectedItemData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectedItem Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupProtectedItemResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupProtectedItemResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string fabricName, string containerName, string protectedItemName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource> Get(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource>> GetAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource> GetBackupRecoveryPoint(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource>> GetBackupRecoveryPointAsync(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointCollection GetBackupRecoveryPoints() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource> GetRecoveryPointsRecommendedForMove(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointsRecommendedForMoveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource> GetRecoveryPointsRecommendedForMoveAsync(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointsRecommendedForMoveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response TriggerBackup(Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> TriggerBackupAsync(Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData data, string xMsAuthorizationAuxiliary = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData data, string xMsAuthorizationAuxiliary = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData data, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class BackupProtectionContainerCollection : Azure.ResourceManager.ArmCollection
    {
        protected BackupProtectionContainerCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vaultName, string fabricName, string containerName, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vaultName, string fabricName, string containerName, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vaultName, string fabricName, string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vaultName, string fabricName, string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource> Get(string vaultName, string fabricName, string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource>> GetAsync(string vaultName, string fabricName, string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource> GetIfExists(string vaultName, string fabricName, string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource>> GetIfExistsAsync(string vaultName, string fabricName, string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupProtectionContainerData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerData>
    {
        public BackupProtectionContainerData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionContainer Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupProtectionContainerResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupProtectionContainerResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string fabricName, string containerName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource> GetBackupProtectedItem(string protectedItemName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource>> GetBackupProtectedItemAsync(string protectedItemName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemCollection GetBackupProtectedItems() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemResource> GetBackupWorkloadItems(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemResource> GetBackupWorkloadItemsAsync(string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response Inquire(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> InquireAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupProtectionIntentCollection : Azure.ResourceManager.ArmCollection
    {
        protected BackupProtectionIntentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vaultName, string fabricName, string intentObjectName, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vaultName, string fabricName, string intentObjectName, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vaultName, string fabricName, string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vaultName, string fabricName, string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource> Get(string vaultName, string fabricName, string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource>> GetAsync(string vaultName, string fabricName, string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource> GetIfExists(string vaultName, string fabricName, string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource>> GetIfExistsAsync(string vaultName, string fabricName, string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupProtectionIntentData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentData>
    {
        public BackupProtectionIntentData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionIntent Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupProtectionIntentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupProtectionIntentResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string fabricName, string intentObjectName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupProtectionPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource>, System.Collections.IEnumerable
    {
        protected BackupProtectionPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string policyName, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData data, string xMsAuthorizationAuxiliary = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string policyName, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string policyName, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData data, string xMsAuthorizationAuxiliary = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string policyName, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<bool> Exists(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource> Get(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource>> GetAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource> GetIfExists(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource>> GetIfExistsAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BackupProtectionPolicyData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData>
    {
        public BackupProtectionPolicyData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionPolicy Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupProtectionPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupProtectionPolicyResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string policyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData data, string xMsAuthorizationAuxiliary = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData data, string xMsAuthorizationAuxiliary = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData data, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class BackupRecoveryPointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource>, System.Collections.IEnumerable
    {
        protected BackupRecoveryPointCollection() { }
        public virtual Azure.Response<bool> Exists(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource> Get(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource> GetAll(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource> GetAllAsync(string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource>> GetAsync(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource> GetIfExists(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource>> GetIfExistsAsync(string recoveryPointId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class BackupRecoveryPointData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointData>
    {
        public BackupRecoveryPointData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericRecoveryPoint Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupRecoveryPointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupRecoveryPointResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string fabricName, string containerName, string protectedItemName, string recoveryPointId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation MoveRecoveryPoint(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.Models.MoveRPAcrossTiersContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> MoveRecoveryPointAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.Models.MoveRPAcrossTiersContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response ProvisionItemLevelRecoveryConnection(Azure.ResourceManager.RecoveryServicesBackup.Models.ProvisionIlrConnectionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ProvisionItemLevelRecoveryConnectionAsync(Azure.ResourceManager.RecoveryServicesBackup.Models.ProvisionIlrConnectionContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RevokeItemLevelRecoveryConnection(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RevokeItemLevelRecoveryConnectionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation TriggerRestore(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerRestoreContent content, string xMsAuthorizationAuxiliary = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation TriggerRestore(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerRestoreContent content, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TriggerRestoreAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerRestoreContent content, string xMsAuthorizationAuxiliary = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TriggerRestoreAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerRestoreContent content, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public partial class BackupResourceConfigCollection : Azure.ResourceManager.ArmCollection
    {
        protected BackupResourceConfigCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource> Get(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource>> GetAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource> GetIfExists(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource>> GetIfExistsAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupResourceConfigData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigData>
    {
        public BackupResourceConfigData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceConfigProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupResourceConfigResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupResourceConfigResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation PrepareDataMove(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.Models.PrepareDataMoveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> PrepareDataMoveAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.Models.PrepareDataMoveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation TriggerDataMove(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerDataMoveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> TriggerDataMoveAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerDataMoveContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource> Update(Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource>> UpdateAsync(Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupResourceEncryptionConfigExtendedCollection : Azure.ResourceManager.ArmCollection
    {
        protected BackupResourceEncryptionConfigExtendedCollection() { }
        public virtual Azure.ResourceManager.ArmOperation CreateOrUpdate(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfigExtendedCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfigExtendedCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource> Get(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource>> GetAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource> GetIfExists(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource>> GetIfExistsAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupResourceEncryptionConfigExtendedData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedData>
    {
        public BackupResourceEncryptionConfigExtendedData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfigExtendedProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupResourceEncryptionConfigExtendedResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupResourceEncryptionConfigExtendedResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfigExtendedCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfigExtendedCreateOrUpdateContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupResourceVaultConfigCollection : Azure.ResourceManager.ArmCollection
    {
        protected BackupResourceVaultConfigCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData data, string xMsAuthorizationAuxiliary = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData data, string xMsAuthorizationAuxiliary = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Response<bool> Exists(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource> Get(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource>> GetAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource> GetIfExists(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource>> GetIfExistsAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class BackupResourceVaultConfigData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData>
    {
        public BackupResourceVaultConfigData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceVaultConfigProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupResourceVaultConfigResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected BackupResourceVaultConfigResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource> Update(Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData data, string xMsAuthorizationAuxiliary = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource> Update(Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData data, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource>> UpdateAsync(Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData data, string xMsAuthorizationAuxiliary = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource>> UpdateAsync(Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData data, System.Threading.CancellationToken cancellationToken) { throw null; }
    }
    public static partial class RecoveryServicesBackupExtensions
    {
        public static Azure.Response ExportJob(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> ExportJobAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource> GetBackupEngine(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string backupEngineName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource>> GetBackupEngineAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string backupEngineName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource GetBackupEngineResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupEngineCollection GetBackupEngines(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource> GetBackupJob(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource>> GetBackupJobAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource GetBackupJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupJobCollection GetBackupJobs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource> GetBackupPrivateEndpointConnection(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource>> GetBackupPrivateEndpointConnectionAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource GetBackupPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionCollection GetBackupPrivateEndpointConnections(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItemResource> GetBackupProtectableItems(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItemResource> GetBackupProtectableItemsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource GetBackupProtectedItemResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource> GetBackupProtectedItems(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource> GetBackupProtectedItemsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource> GetBackupProtectionContainer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string fabricName, string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource>> GetBackupProtectionContainerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string fabricName, string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource GetBackupProtectionContainerResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerCollection GetBackupProtectionContainers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource> GetBackupProtectionContainers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource> GetBackupProtectionContainersAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource> GetBackupProtectionIntent(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string fabricName, string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource>> GetBackupProtectionIntentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string fabricName, string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource GetBackupProtectionIntentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentCollection GetBackupProtectionIntents(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource> GetBackupProtectionIntents(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource> GetBackupProtectionIntentsAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyCollection GetBackupProtectionPolicies(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource> GetBackupProtectionPolicy(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource>> GetBackupProtectionPolicyAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource GetBackupProtectionPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource GetBackupRecoveryPointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource> GetBackupResourceConfig(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource>> GetBackupResourceConfigAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource GetBackupResourceConfigResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigCollection GetBackupResourceConfigs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource> GetBackupResourceEncryptionConfigExtended(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource>> GetBackupResourceEncryptionConfigExtendedAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource GetBackupResourceEncryptionConfigExtendedResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedCollection GetBackupResourceEncryptionConfigExtendeds(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource> GetBackupResourceVaultConfig(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource>> GetBackupResourceVaultConfigAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource GetBackupResourceVaultConfigResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigCollection GetBackupResourceVaultConfigs(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusResult> GetBackupStatus(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusResult>> GetBackupStatusAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementUsage> GetBackupUsageSummaries(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementUsage> GetBackupUsageSummariesAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostInfo> GetGetTieringCostOperationResult(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostInfo>> GetGetTieringCostOperationResultAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainerResource> GetProtectableContainers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainerResource> GetProtectableContainersAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyCollection GetResourceGuardProxies(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource> GetResourceGuardProxy(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource>> GetResourceGuardProxyAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource GetResourceGuardProxyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.TokenInformation> GetSecurityPin(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, Azure.ResourceManager.RecoveryServicesBackup.Models.SecurityPinContent content = null, string xMsAuthorizationAuxiliary = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.TokenInformation> GetSecurityPin(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, Azure.ResourceManager.RecoveryServicesBackup.Models.SecurityPinContent content, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.TokenInformation>> GetSecurityPinAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, Azure.ResourceManager.RecoveryServicesBackup.Models.SecurityPinContent content = null, string xMsAuthorizationAuxiliary = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.TokenInformation>> GetSecurityPinAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, Azure.ResourceManager.RecoveryServicesBackup.Models.SecurityPinContent content, System.Threading.CancellationToken cancellationToken) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource> GetSoftDeletedProtectionContainers(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource> GetSoftDeletedProtectionContainersAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostInfo> PostFetchTieringCost(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostInfoContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostInfo>> PostFetchTieringCostAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostInfoContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response RefreshProtectionContainer(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response> RefreshProtectionContainerAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportResult> ValidateFeatureSupport(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServicesBackup.Models.FeatureSupportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportResult>> ValidateFeatureSupportAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServicesBackup.Models.FeatureSupportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupResult> ValidateProtectionIntent(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupResult>> ValidateProtectionIntentAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ResourceGuardProxyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource>, System.Collections.IEnumerable
    {
        protected ResourceGuardProxyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string resourceGuardProxyName, Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string resourceGuardProxyName, Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource> Get(string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource>> GetAsync(string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource> GetIfExists(string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource>> GetIfExistsAsync(string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ResourceGuardProxyData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyData>
    {
        public ResourceGuardProxyData(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceGuardProxyProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceGuardProxyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ResourceGuardProxyResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string resourceGuardProxyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteResult> UnlockDelete(Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteResult>> UnlockDeleteAsync(Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.RecoveryServicesBackup.Mocking
{
    public partial class MockableRecoveryServicesBackupArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableRecoveryServicesBackupArmClient() { }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource GetBackupEngineResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource GetBackupJobResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource GetBackupPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource GetBackupProtectedItemResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource GetBackupProtectionContainerResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource GetBackupProtectionIntentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource GetBackupProtectionPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointResource GetBackupRecoveryPointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource GetBackupResourceConfigResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource GetBackupResourceEncryptionConfigExtendedResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource GetBackupResourceVaultConfigResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource GetResourceGuardProxyResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableRecoveryServicesBackupResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableRecoveryServicesBackupResourceGroupResource() { }
        public virtual Azure.Response ExportJob(string vaultName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> ExportJobAsync(string vaultName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource> GetBackupEngine(string vaultName, string backupEngineName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupEngineResource>> GetBackupEngineAsync(string vaultName, string backupEngineName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupEngineCollection GetBackupEngines(string vaultName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource> GetBackupJob(string vaultName, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupJobResource>> GetBackupJobAsync(string vaultName, string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupJobCollection GetBackupJobs(string vaultName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource> GetBackupPrivateEndpointConnection(string vaultName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionResource>> GetBackupPrivateEndpointConnectionAsync(string vaultName, string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionCollection GetBackupPrivateEndpointConnections() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItemResource> GetBackupProtectableItems(string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItemResource> GetBackupProtectableItemsAsync(string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource> GetBackupProtectedItems(string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemResource> GetBackupProtectedItemsAsync(string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource> GetBackupProtectionContainer(string vaultName, string fabricName, string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource>> GetBackupProtectionContainerAsync(string vaultName, string fabricName, string containerName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerCollection GetBackupProtectionContainers() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource> GetBackupProtectionContainers(string vaultName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource> GetBackupProtectionContainersAsync(string vaultName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource> GetBackupProtectionIntent(string vaultName, string fabricName, string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource>> GetBackupProtectionIntentAsync(string vaultName, string fabricName, string intentObjectName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentCollection GetBackupProtectionIntents() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource> GetBackupProtectionIntents(string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentResource> GetBackupProtectionIntentsAsync(string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyCollection GetBackupProtectionPolicies(string vaultName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource> GetBackupProtectionPolicy(string vaultName, string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyResource>> GetBackupProtectionPolicyAsync(string vaultName, string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource> GetBackupResourceConfig(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigResource>> GetBackupResourceConfigAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigCollection GetBackupResourceConfigs() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource> GetBackupResourceEncryptionConfigExtended(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedResource>> GetBackupResourceEncryptionConfigExtendedAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedCollection GetBackupResourceEncryptionConfigExtendeds() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource> GetBackupResourceVaultConfig(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigResource>> GetBackupResourceVaultConfigAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigCollection GetBackupResourceVaultConfigs() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementUsage> GetBackupUsageSummaries(string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementUsage> GetBackupUsageSummariesAsync(string vaultName, string filter = null, string skipToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostInfo> GetGetTieringCostOperationResult(string vaultName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostInfo>> GetGetTieringCostOperationResultAsync(string vaultName, string operationId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainerResource> GetProtectableContainers(string vaultName, string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainerResource> GetProtectableContainersAsync(string vaultName, string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyCollection GetResourceGuardProxies(string vaultName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource> GetResourceGuardProxy(string vaultName, string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyResource>> GetResourceGuardProxyAsync(string vaultName, string resourceGuardProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.TokenInformation> GetSecurityPin(string vaultName, Azure.ResourceManager.RecoveryServicesBackup.Models.SecurityPinContent content = null, string xMsAuthorizationAuxiliary = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.TokenInformation> GetSecurityPin(string vaultName, Azure.ResourceManager.RecoveryServicesBackup.Models.SecurityPinContent content, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.TokenInformation>> GetSecurityPinAsync(string vaultName, Azure.ResourceManager.RecoveryServicesBackup.Models.SecurityPinContent content = null, string xMsAuthorizationAuxiliary = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.TokenInformation>> GetSecurityPinAsync(string vaultName, Azure.ResourceManager.RecoveryServicesBackup.Models.SecurityPinContent content, System.Threading.CancellationToken cancellationToken) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource> GetSoftDeletedProtectionContainers(string vaultName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerResource> GetSoftDeletedProtectionContainersAsync(string vaultName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostInfo> PostFetchTieringCost(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostInfoContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostInfo>> PostFetchTieringCostAsync(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostInfoContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response RefreshProtectionContainer(string vaultName, string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response> RefreshProtectionContainerAsync(string vaultName, string fabricName, string filter = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableRecoveryServicesBackupSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableRecoveryServicesBackupSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusResult> GetBackupStatus(Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusResult>> GetBackupStatusAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportResult> ValidateFeatureSupport(Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServicesBackup.Models.FeatureSupportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportResult>> ValidateFeatureSupportAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServicesBackup.Models.FeatureSupportContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupResult> ValidateProtectionIntent(Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupResult>> ValidateProtectionIntentAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupContent content, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.RecoveryServicesBackup.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AcquireStorageAccountLock : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.AcquireStorageAccountLock>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AcquireStorageAccountLock(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.AcquireStorageAccountLock Acquire { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.AcquireStorageAccountLock NotAcquire { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.AcquireStorageAccountLock other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.AcquireStorageAccountLock left, Azure.ResourceManager.RecoveryServicesBackup.Models.AcquireStorageAccountLock right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.AcquireStorageAccountLock (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.AcquireStorageAccountLock left, Azure.ResourceManager.RecoveryServicesBackup.Models.AcquireStorageAccountLock right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmRecoveryServicesBackupModelFactory
    {
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupEngineData BackupEngineData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericEngine properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupErrorDetail BackupErrorDetail(string code = null, string message = null, System.Collections.Generic.IEnumerable<string> recommendations = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectedItem BackupGenericProtectedItem(string protectedItemType, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType, string containerName, Azure.Core.ResourceIdentifier sourceResourceId, Azure.Core.ResourceIdentifier policyId, System.DateTimeOffset? lastRecoverOn, string backupSetName, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode, System.DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectedItem BackupGenericProtectedItem(string protectedItemType = null, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType?), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType?), string containerName = null, Azure.Core.ResourceIdentifier sourceResourceId = null, Azure.Core.ResourceIdentifier policyId = null, System.DateTimeOffset? lastRecoverOn = default(System.DateTimeOffset?), string backupSetName = null, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode?), System.DateTimeOffset? deferredDeletedOn = default(System.DateTimeOffset?), bool? isScheduledForDeferredDelete = default(bool?), string deferredDeleteTimeRemaining = null, bool? isDeferredDeleteScheduleUpcoming = default(bool?), bool? isRehydrate = default(bool?), System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests = null, bool? isArchiveEnabled = default(bool?), string policyName = null, int? softDeleteRetentionPeriodInDays = default(int?), string vaultId = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupJobData BackupJobData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericJob properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementUsage BackupManagementUsage(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupUsagesUnit? unit = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupUsagesUnit?), string quotaPeriod = null, System.DateTimeOffset? nextResetOn = default(System.DateTimeOffset?), long? currentValue = default(long?), long? limit = default(long?), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupNameInfo name = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupNameInfo BackupNameInfo(string value = null, string localizedValue = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupPrivateEndpointConnectionData BackupPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProperties properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupProtectedItemData BackupProtectedItemData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectedItem properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionContainerData BackupProtectionContainerData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionContainer properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionIntentData BackupProtectionIntentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionIntent properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupProtectionPolicyData BackupProtectionPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionPolicy properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupRecoveryPointData BackupRecoveryPointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericRecoveryPoint properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupResourceConfigData BackupResourceConfigData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceConfigProperties properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfigExtendedCreateOrUpdateContent BackupResourceEncryptionConfigExtendedCreateOrUpdateContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfig properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupResourceEncryptionConfigExtendedData BackupResourceEncryptionConfigExtendedData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfigExtendedProperties properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.BackupResourceVaultConfigData BackupResourceVaultConfigData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceVaultConfigProperties properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusResult BackupStatusResult(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus? protectionStatus, Azure.Core.ResourceIdentifier vaultId, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFabricName? fabricName, string containerName, string protectedItemName, string errorCode, string errorMessage, string policyName, string registrationStatus) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusResult BackupStatusResult(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus? protectionStatus = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus?), Azure.Core.ResourceIdentifier vaultId = null, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFabricName? fabricName = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFabricName?), string containerName = null, string protectedItemName = null, string errorCode = null, string errorMessage = null, string policyName = null, string registrationStatus = null, int? protectedItemsCount = default(int?), Azure.ResourceManager.RecoveryServicesBackup.Models.AcquireStorageAccountLock? acquireStorageAccountLock = default(Azure.ResourceManager.RecoveryServicesBackup.Models.AcquireStorageAccountLock?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.DpmProtectedItem DpmProtectedItem(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType, string containerName, Azure.Core.ResourceIdentifier sourceResourceId, Azure.Core.ResourceIdentifier policyId, System.DateTimeOffset? lastRecoverOn, string backupSetName, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode, System.DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays, string friendlyName, string backupEngineName, Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState? protectionState, Azure.ResourceManager.RecoveryServicesBackup.Models.DpmProtectedItemExtendedInfo extendedInfo) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.DpmProtectedItem DpmProtectedItem(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType?), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType?), string containerName = null, Azure.Core.ResourceIdentifier sourceResourceId = null, Azure.Core.ResourceIdentifier policyId = null, System.DateTimeOffset? lastRecoverOn = default(System.DateTimeOffset?), string backupSetName = null, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode?), System.DateTimeOffset? deferredDeletedOn = default(System.DateTimeOffset?), bool? isScheduledForDeferredDelete = default(bool?), string deferredDeleteTimeRemaining = null, bool? isDeferredDeleteScheduleUpcoming = default(bool?), bool? isRehydrate = default(bool?), System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests = null, bool? isArchiveEnabled = default(bool?), string policyName = null, int? softDeleteRetentionPeriodInDays = default(int?), string vaultId = null, string friendlyName = null, string backupEngineName = null, Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState? protectionState = default(Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState?), Azure.ResourceManager.RecoveryServicesBackup.Models.DpmProtectedItemExtendedInfo extendedInfo = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostInfoContent FetchTieringCostInfoContent(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType sourceTierType = Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType.Invalid, Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType targetTierType = Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType.Invalid, string objectType = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostInfoForRehydrationContent FetchTieringCostInfoForRehydrationContent(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType sourceTierType = Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType.Invalid, Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType targetTierType = Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType.Invalid, string containerName = null, string protectedItemName = null, string recoveryPointId = null, Azure.ResourceManager.RecoveryServicesBackup.Models.RehydrationPriority rehydrationPriority = default(Azure.ResourceManager.RecoveryServicesBackup.Models.RehydrationPriority)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostSavingsInfoForPolicyContent FetchTieringCostSavingsInfoForPolicyContent(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType sourceTierType = Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType.Invalid, Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType targetTierType = Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType.Invalid, string policyName = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostSavingsInfoForProtectedItemContent FetchTieringCostSavingsInfoForProtectedItemContent(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType sourceTierType = Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType.Invalid, Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType targetTierType = Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType.Invalid, string containerName = null, string protectedItemName = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostSavingsInfoForVaultContent FetchTieringCostSavingsInfoForVaultContent(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType sourceTierType = Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType.Invalid, Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType targetTierType = Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType.Invalid) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FileshareProtectedItem FileshareProtectedItem(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType, string containerName, Azure.Core.ResourceIdentifier sourceResourceId, Azure.Core.ResourceIdentifier policyId, System.DateTimeOffset? lastRecoverOn, string backupSetName, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode, System.DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays, string friendlyName, string protectionStatus, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? protectionState, string lastBackupStatus, System.DateTimeOffset? lastBackupOn, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails> kpisHealths, Azure.ResourceManager.RecoveryServicesBackup.Models.FileshareProtectedItemExtendedInfo extendedInfo) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FileshareProtectedItem FileshareProtectedItem(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType?), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType?), string containerName = null, Azure.Core.ResourceIdentifier sourceResourceId = null, Azure.Core.ResourceIdentifier policyId = null, System.DateTimeOffset? lastRecoverOn = default(System.DateTimeOffset?), string backupSetName = null, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode?), System.DateTimeOffset? deferredDeletedOn = default(System.DateTimeOffset?), bool? isScheduledForDeferredDelete = default(bool?), string deferredDeleteTimeRemaining = null, bool? isDeferredDeleteScheduleUpcoming = default(bool?), bool? isRehydrate = default(bool?), System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests = null, bool? isArchiveEnabled = default(bool?), string policyName = null, int? softDeleteRetentionPeriodInDays = default(int?), string vaultId = null, string friendlyName = null, string protectionStatus = null, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? protectionState = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState?), string lastBackupStatus = null, System.DateTimeOffset? lastBackupOn = default(System.DateTimeOffset?), System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails> kpisHealths = null, Azure.ResourceManager.RecoveryServicesBackup.Models.FileshareProtectedItemExtendedInfo extendedInfo = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FileshareProtectedItemExtendedInfo FileshareProtectedItemExtendedInfo(System.DateTimeOffset? oldestRecoverOn = default(System.DateTimeOffset?), int? recoveryPointCount = default(int?), string policyState = null, string resourceState = null, System.DateTimeOffset? resourceStateSyncOn = default(System.DateTimeOffset?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.GenericProtectedItem GenericProtectedItem(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType, string containerName, Azure.Core.ResourceIdentifier sourceResourceId, Azure.Core.ResourceIdentifier policyId, System.DateTimeOffset? lastRecoverOn, string backupSetName, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode, System.DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays, string friendlyName, string policyState, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? protectionState, long? protectedItemId, System.Collections.Generic.IDictionary<string, string> sourceAssociations, string fabricName) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.GenericProtectedItem GenericProtectedItem(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType?), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType?), string containerName = null, Azure.Core.ResourceIdentifier sourceResourceId = null, Azure.Core.ResourceIdentifier policyId = null, System.DateTimeOffset? lastRecoverOn = default(System.DateTimeOffset?), string backupSetName = null, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode?), System.DateTimeOffset? deferredDeletedOn = default(System.DateTimeOffset?), bool? isScheduledForDeferredDelete = default(bool?), string deferredDeleteTimeRemaining = null, bool? isDeferredDeleteScheduleUpcoming = default(bool?), bool? isRehydrate = default(bool?), System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests = null, bool? isArchiveEnabled = default(bool?), string policyName = null, int? softDeleteRetentionPeriodInDays = default(int?), string vaultId = null, string friendlyName = null, string policyState = null, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? protectionState = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState?), long? protectedItemId = default(long?), System.Collections.Generic.IDictionary<string, string> sourceAssociations = null, string fabricName = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.IaasClassicComputeVmProtectedItem IaasClassicComputeVmProtectedItem(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType, string containerName, Azure.Core.ResourceIdentifier sourceResourceId, Azure.Core.ResourceIdentifier policyId, System.DateTimeOffset? lastRecoverOn, string backupSetName, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode, System.DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays, string friendlyName, Azure.Core.ResourceIdentifier virtualMachineId, string protectionStatus, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? protectionState, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus? healthStatus, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmHealthDetails> healthDetails, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails> kpisHealths, string lastBackupStatus, System.DateTimeOffset? lastBackupOn, string protectedItemDataId, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemExtendedInfo extendedInfo, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupExtendedProperties extendedProperties) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.IaasClassicComputeVmProtectedItem IaasClassicComputeVmProtectedItem(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType, string containerName, Azure.Core.ResourceIdentifier sourceResourceId, Azure.Core.ResourceIdentifier policyId, System.DateTimeOffset? lastRecoverOn, string backupSetName, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode, System.DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays, string vaultId, string friendlyName, Azure.Core.ResourceIdentifier virtualMachineId, string protectionStatus, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? protectionState, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus? healthStatus, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmHealthDetails> healthDetails, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails> kpisHealths, string lastBackupStatus, System.DateTimeOffset? lastBackupOn, string protectedItemDataId, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemExtendedInfo extendedInfo, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupExtendedProperties extendedProperties) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.IaasClassicComputeVmProtectedItem IaasClassicComputeVmProtectedItem(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType?), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType?), string containerName = null, Azure.Core.ResourceIdentifier sourceResourceId = null, Azure.Core.ResourceIdentifier policyId = null, System.DateTimeOffset? lastRecoverOn = default(System.DateTimeOffset?), string backupSetName = null, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode?), System.DateTimeOffset? deferredDeletedOn = default(System.DateTimeOffset?), bool? isScheduledForDeferredDelete = default(bool?), string deferredDeleteTimeRemaining = null, bool? isDeferredDeleteScheduleUpcoming = default(bool?), bool? isRehydrate = default(bool?), System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests = null, bool? isArchiveEnabled = default(bool?), string policyName = null, int? softDeleteRetentionPeriodInDays = default(int?), string vaultId = null, string friendlyName = null, Azure.Core.ResourceIdentifier virtualMachineId = null, string protectionStatus = null, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? protectionState = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState?), Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus? healthStatus = default(Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmHealthDetails> healthDetails = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails> kpisHealths = null, string lastBackupStatus = null, System.DateTimeOffset? lastBackupOn = default(System.DateTimeOffset?), string protectedItemDataId = null, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemExtendedInfo extendedInfo = null, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupExtendedProperties extendedProperties = null, string policyType = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.IaasComputeVmProtectedItem IaasComputeVmProtectedItem(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType, string containerName, Azure.Core.ResourceIdentifier sourceResourceId, Azure.Core.ResourceIdentifier policyId, System.DateTimeOffset? lastRecoverOn, string backupSetName, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode, System.DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays, string friendlyName, Azure.Core.ResourceIdentifier virtualMachineId, string protectionStatus, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? protectionState, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus? healthStatus, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmHealthDetails> healthDetails, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails> kpisHealths, string lastBackupStatus, System.DateTimeOffset? lastBackupOn, string protectedItemDataId, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemExtendedInfo extendedInfo, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupExtendedProperties extendedProperties) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.IaasComputeVmProtectedItem IaasComputeVmProtectedItem(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType, string containerName, Azure.Core.ResourceIdentifier sourceResourceId, Azure.Core.ResourceIdentifier policyId, System.DateTimeOffset? lastRecoverOn, string backupSetName, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode, System.DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays, string vaultId, string friendlyName, Azure.Core.ResourceIdentifier virtualMachineId, string protectionStatus, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? protectionState, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus? healthStatus, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmHealthDetails> healthDetails, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails> kpisHealths, string lastBackupStatus, System.DateTimeOffset? lastBackupOn, string protectedItemDataId, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemExtendedInfo extendedInfo, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupExtendedProperties extendedProperties) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.IaasComputeVmProtectedItem IaasComputeVmProtectedItem(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType?), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType?), string containerName = null, Azure.Core.ResourceIdentifier sourceResourceId = null, Azure.Core.ResourceIdentifier policyId = null, System.DateTimeOffset? lastRecoverOn = default(System.DateTimeOffset?), string backupSetName = null, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode?), System.DateTimeOffset? deferredDeletedOn = default(System.DateTimeOffset?), bool? isScheduledForDeferredDelete = default(bool?), string deferredDeleteTimeRemaining = null, bool? isDeferredDeleteScheduleUpcoming = default(bool?), bool? isRehydrate = default(bool?), System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests = null, bool? isArchiveEnabled = default(bool?), string policyName = null, int? softDeleteRetentionPeriodInDays = default(int?), string vaultId = null, string friendlyName = null, Azure.Core.ResourceIdentifier virtualMachineId = null, string protectionStatus = null, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? protectionState = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState?), Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus? healthStatus = default(Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmHealthDetails> healthDetails = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails> kpisHealths = null, string lastBackupStatus = null, System.DateTimeOffset? lastBackupOn = default(System.DateTimeOffset?), string protectedItemDataId = null, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemExtendedInfo extendedInfo = null, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupExtendedProperties extendedProperties = null, string policyType = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmErrorInfo IaasVmErrorInfo(int? errorCode = default(int?), string errorTitle = null, string errorString = null, System.Collections.Generic.IEnumerable<string> recommendations = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmHealthDetails IaasVmHealthDetails(int? code = default(int?), string title = null, string message = null, System.Collections.Generic.IEnumerable<string> recommendations = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItem IaasVmProtectedItem(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType, string containerName, Azure.Core.ResourceIdentifier sourceResourceId, Azure.Core.ResourceIdentifier policyId, System.DateTimeOffset? lastRecoverOn, string backupSetName, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode, System.DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays, string friendlyName, Azure.Core.ResourceIdentifier virtualMachineId, string protectionStatus, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? protectionState, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus? healthStatus, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmHealthDetails> healthDetails, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails> kpisHealths, string lastBackupStatus, System.DateTimeOffset? lastBackupOn, string protectedItemDataId, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemExtendedInfo extendedInfo, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupExtendedProperties extendedProperties) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItem IaasVmProtectedItem(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType, string containerName, Azure.Core.ResourceIdentifier sourceResourceId, Azure.Core.ResourceIdentifier policyId, System.DateTimeOffset? lastRecoverOn, string backupSetName, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode, System.DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays, string vaultId, string friendlyName, Azure.Core.ResourceIdentifier virtualMachineId, string protectionStatus, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? protectionState, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus? healthStatus, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmHealthDetails> healthDetails, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails> kpisHealths, string lastBackupStatus, System.DateTimeOffset? lastBackupOn, string protectedItemDataId, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemExtendedInfo extendedInfo, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupExtendedProperties extendedProperties) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItem IaasVmProtectedItem(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType?), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType?), string containerName = null, Azure.Core.ResourceIdentifier sourceResourceId = null, Azure.Core.ResourceIdentifier policyId = null, System.DateTimeOffset? lastRecoverOn = default(System.DateTimeOffset?), string backupSetName = null, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode?), System.DateTimeOffset? deferredDeletedOn = default(System.DateTimeOffset?), bool? isScheduledForDeferredDelete = default(bool?), string deferredDeleteTimeRemaining = null, bool? isDeferredDeleteScheduleUpcoming = default(bool?), bool? isRehydrate = default(bool?), System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests = null, bool? isArchiveEnabled = default(bool?), string policyName = null, int? softDeleteRetentionPeriodInDays = default(int?), string vaultId = null, string friendlyName = null, Azure.Core.ResourceIdentifier virtualMachineId = null, string protectionStatus = null, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? protectionState = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState?), Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus? healthStatus = default(Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmHealthDetails> healthDetails = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails> kpisHealths = null, string lastBackupStatus = null, System.DateTimeOffset? lastBackupOn = default(System.DateTimeOffset?), string protectedItemDataId = null, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemExtendedInfo extendedInfo = null, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupExtendedProperties extendedProperties = null, string policyType = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryValidation InquiryValidation(string status = null, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupErrorDetail errorDetail = null, string additionalDetail = null, System.BinaryData protectableItemCount = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabErrorInfo MabErrorInfo(string errorString = null, System.Collections.Generic.IEnumerable<string> recommendations = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabFileFolderProtectedItem MabFileFolderProtectedItem(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType, string containerName, Azure.Core.ResourceIdentifier sourceResourceId, Azure.Core.ResourceIdentifier policyId, System.DateTimeOffset? lastRecoverOn, string backupSetName, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode, System.DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays, string friendlyName, string computerName, string lastBackupStatus, System.DateTimeOffset? lastBackupOn, string protectionState, long? deferredDeleteSyncTimeInUTC, Azure.ResourceManager.RecoveryServicesBackup.Models.MabFileFolderProtectedItemExtendedInfo extendedInfo) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabFileFolderProtectedItem MabFileFolderProtectedItem(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType?), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType?), string containerName = null, Azure.Core.ResourceIdentifier sourceResourceId = null, Azure.Core.ResourceIdentifier policyId = null, System.DateTimeOffset? lastRecoverOn = default(System.DateTimeOffset?), string backupSetName = null, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode?), System.DateTimeOffset? deferredDeletedOn = default(System.DateTimeOffset?), bool? isScheduledForDeferredDelete = default(bool?), string deferredDeleteTimeRemaining = null, bool? isDeferredDeleteScheduleUpcoming = default(bool?), bool? isRehydrate = default(bool?), System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests = null, bool? isArchiveEnabled = default(bool?), string policyName = null, int? softDeleteRetentionPeriodInDays = default(int?), string vaultId = null, string friendlyName = null, string computerName = null, string lastBackupStatus = null, System.DateTimeOffset? lastBackupOn = default(System.DateTimeOffset?), string protectionState = null, long? deferredDeleteSyncTimeInUTC = default(long?), Azure.ResourceManager.RecoveryServicesBackup.Models.MabFileFolderProtectedItemExtendedInfo extendedInfo = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.PrepareDataMoveContent PrepareDataMoveContent(Azure.Core.ResourceIdentifier targetResourceId = null, Azure.Core.AzureLocation targetRegion = default(Azure.Core.AzureLocation), Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel dataMoveLevel = default(Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel), System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> sourceContainerArmIds = null, bool? ignoreMoved = default(bool?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupResult PreValidateEnableBackupResult(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupValidationStatus? status = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupValidationStatus?), string errorCode = null, string errorMessage = null, string recommendation = null, string containerName = null, string protectedItemName = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainerResource ProtectableContainerResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainer properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProvisionIlrConnectionContent ProvisionIlrConnectionContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RecoveryServicesBackup.Models.IlrContent properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.ResourceGuardProxyData ResourceGuardProxyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceGuardProxyProperties properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthDetails ResourceHealthDetails(int? code = default(int?), string title = null, string message = null, System.Collections.Generic.IEnumerable<string> recommendations = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectedItem SqlProtectedItem(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType, string containerName, Azure.Core.ResourceIdentifier sourceResourceId, Azure.Core.ResourceIdentifier policyId, System.DateTimeOffset? lastRecoverOn, string backupSetName, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode, System.DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays, string protectedItemDataId, Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState? protectionState, Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectedItemExtendedInfo extendedInfo) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectedItem SqlProtectedItem(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType?), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType?), string containerName = null, Azure.Core.ResourceIdentifier sourceResourceId = null, Azure.Core.ResourceIdentifier policyId = null, System.DateTimeOffset? lastRecoverOn = default(System.DateTimeOffset?), string backupSetName = null, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode?), System.DateTimeOffset? deferredDeletedOn = default(System.DateTimeOffset?), bool? isScheduledForDeferredDelete = default(bool?), string deferredDeleteTimeRemaining = null, bool? isDeferredDeleteScheduleUpcoming = default(bool?), bool? isRehydrate = default(bool?), System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests = null, bool? isArchiveEnabled = default(bool?), string policyName = null, int? softDeleteRetentionPeriodInDays = default(int?), string vaultId = null, string protectedItemDataId = null, Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState? protectionState = default(Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState?), Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectedItemExtendedInfo extendedInfo = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostRehydrationInfo TieringCostRehydrationInfo(long rehydrationSizeInBytes = (long)0, double retailRehydrationCostPerGBPerMonth = 0) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostSavingInfo TieringCostSavingInfo(long sourceTierSizeReductionInBytes = (long)0, long targetTierSizeIncreaseInBytes = (long)0, double retailSourceTierCostPerGBPerMonth = 0, double retailTargetTierCostPerGBPerMonth = 0) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.TokenInformation TokenInformation(string token = null, long? expiryTimeInUtcTicks = default(long?), string securityPin = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerBackupContent TriggerBackupContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupContent properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerDataMoveContent TriggerDataMoveContent(Azure.Core.ResourceIdentifier sourceResourceId = null, Azure.Core.AzureLocation sourceRegion = default(Azure.Core.AzureLocation), Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel dataMoveLevel = default(Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel), string correlationId = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> sourceContainerArmIds = null, bool? doesPauseGC = default(bool?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerRestoreContent TriggerRestoreContent(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreContent properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteResult UnlockDeleteResult(System.DateTimeOffset? unlockDeleteExpireOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportResult VmResourceFeatureSupportResult(Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportStatus? supportStatus = default(Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportStatus?)) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItem VmWorkloadProtectedItem(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType, string containerName, Azure.Core.ResourceIdentifier sourceResourceId, Azure.Core.ResourceIdentifier policyId, System.DateTimeOffset? lastRecoverOn, string backupSetName, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode, System.DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays, string friendlyName, string serverName, string parentName, string parentType, string protectionStatus, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? protectionState, Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus? lastBackupStatus, System.DateTimeOffset? lastBackupOn, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupErrorDetail lastBackupErrorDetail, string protectedItemDataSourceId, Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus? protectedItemHealthStatus, Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemExtendedInfo extendedInfo, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails> kpisHealths, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.Models.DistributedNodesInfo> nodesList) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItem VmWorkloadProtectedItem(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType?), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType?), string containerName = null, Azure.Core.ResourceIdentifier sourceResourceId = null, Azure.Core.ResourceIdentifier policyId = null, System.DateTimeOffset? lastRecoverOn = default(System.DateTimeOffset?), string backupSetName = null, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode?), System.DateTimeOffset? deferredDeletedOn = default(System.DateTimeOffset?), bool? isScheduledForDeferredDelete = default(bool?), string deferredDeleteTimeRemaining = null, bool? isDeferredDeleteScheduleUpcoming = default(bool?), bool? isRehydrate = default(bool?), System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests = null, bool? isArchiveEnabled = default(bool?), string policyName = null, int? softDeleteRetentionPeriodInDays = default(int?), string vaultId = null, string friendlyName = null, string serverName = null, string parentName = null, string parentType = null, string protectionStatus = null, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? protectionState = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState?), Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus? lastBackupStatus = default(Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus?), System.DateTimeOffset? lastBackupOn = default(System.DateTimeOffset?), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupErrorDetail lastBackupErrorDetail = null, string protectedItemDataSourceId = null, Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus? protectedItemHealthStatus = default(Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus?), Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemExtendedInfo extendedInfo = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails> kpisHealths = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.Models.DistributedNodesInfo> nodesList = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseDatabaseProtectedItem VmWorkloadSapAseDatabaseProtectedItem(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType, string containerName, Azure.Core.ResourceIdentifier sourceResourceId, Azure.Core.ResourceIdentifier policyId, System.DateTimeOffset? lastRecoverOn, string backupSetName, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode, System.DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays, string friendlyName, string serverName, string parentName, string parentType, string protectionStatus, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? protectionState, Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus? lastBackupStatus, System.DateTimeOffset? lastBackupOn, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupErrorDetail lastBackupErrorDetail, string protectedItemDataSourceId, Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus? protectedItemHealthStatus, Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemExtendedInfo extendedInfo, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails> kpisHealths, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.Models.DistributedNodesInfo> nodesList) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseDatabaseProtectedItem VmWorkloadSapAseDatabaseProtectedItem(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType?), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType?), string containerName = null, Azure.Core.ResourceIdentifier sourceResourceId = null, Azure.Core.ResourceIdentifier policyId = null, System.DateTimeOffset? lastRecoverOn = default(System.DateTimeOffset?), string backupSetName = null, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode?), System.DateTimeOffset? deferredDeletedOn = default(System.DateTimeOffset?), bool? isScheduledForDeferredDelete = default(bool?), string deferredDeleteTimeRemaining = null, bool? isDeferredDeleteScheduleUpcoming = default(bool?), bool? isRehydrate = default(bool?), System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests = null, bool? isArchiveEnabled = default(bool?), string policyName = null, int? softDeleteRetentionPeriodInDays = default(int?), string vaultId = null, string friendlyName = null, string serverName = null, string parentName = null, string parentType = null, string protectionStatus = null, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? protectionState = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState?), Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus? lastBackupStatus = default(Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus?), System.DateTimeOffset? lastBackupOn = default(System.DateTimeOffset?), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupErrorDetail lastBackupErrorDetail = null, string protectedItemDataSourceId = null, Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus? protectedItemHealthStatus = default(Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus?), Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemExtendedInfo extendedInfo = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails> kpisHealths = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.Models.DistributedNodesInfo> nodesList = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDatabaseProtectedItem VmWorkloadSapHanaDatabaseProtectedItem(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType, string containerName, Azure.Core.ResourceIdentifier sourceResourceId, Azure.Core.ResourceIdentifier policyId, System.DateTimeOffset? lastRecoverOn, string backupSetName, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode, System.DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays, string friendlyName, string serverName, string parentName, string parentType, string protectionStatus, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? protectionState, Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus? lastBackupStatus, System.DateTimeOffset? lastBackupOn, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupErrorDetail lastBackupErrorDetail, string protectedItemDataSourceId, Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus? protectedItemHealthStatus, Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemExtendedInfo extendedInfo, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails> kpisHealths, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.Models.DistributedNodesInfo> nodesList) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDatabaseProtectedItem VmWorkloadSapHanaDatabaseProtectedItem(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType?), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType?), string containerName = null, Azure.Core.ResourceIdentifier sourceResourceId = null, Azure.Core.ResourceIdentifier policyId = null, System.DateTimeOffset? lastRecoverOn = default(System.DateTimeOffset?), string backupSetName = null, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode?), System.DateTimeOffset? deferredDeletedOn = default(System.DateTimeOffset?), bool? isScheduledForDeferredDelete = default(bool?), string deferredDeleteTimeRemaining = null, bool? isDeferredDeleteScheduleUpcoming = default(bool?), bool? isRehydrate = default(bool?), System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests = null, bool? isArchiveEnabled = default(bool?), string policyName = null, int? softDeleteRetentionPeriodInDays = default(int?), string vaultId = null, string friendlyName = null, string serverName = null, string parentName = null, string parentType = null, string protectionStatus = null, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? protectionState = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState?), Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus? lastBackupStatus = default(Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus?), System.DateTimeOffset? lastBackupOn = default(System.DateTimeOffset?), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupErrorDetail lastBackupErrorDetail = null, string protectedItemDataSourceId = null, Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus? protectedItemHealthStatus = default(Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus?), Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemExtendedInfo extendedInfo = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails> kpisHealths = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.Models.DistributedNodesInfo> nodesList = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDBInstanceProtectedItem VmWorkloadSapHanaDBInstanceProtectedItem(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType, string containerName, Azure.Core.ResourceIdentifier sourceResourceId, Azure.Core.ResourceIdentifier policyId, System.DateTimeOffset? lastRecoverOn, string backupSetName, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode, System.DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays, string friendlyName, string serverName, string parentName, string parentType, string protectionStatus, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? protectionState, Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus? lastBackupStatus, System.DateTimeOffset? lastBackupOn, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupErrorDetail lastBackupErrorDetail, string protectedItemDataSourceId, Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus? protectedItemHealthStatus, Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemExtendedInfo extendedInfo, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails> kpisHealths, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.Models.DistributedNodesInfo> nodesList) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDBInstanceProtectedItem VmWorkloadSapHanaDBInstanceProtectedItem(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType?), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType?), string containerName = null, Azure.Core.ResourceIdentifier sourceResourceId = null, Azure.Core.ResourceIdentifier policyId = null, System.DateTimeOffset? lastRecoverOn = default(System.DateTimeOffset?), string backupSetName = null, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode?), System.DateTimeOffset? deferredDeletedOn = default(System.DateTimeOffset?), bool? isScheduledForDeferredDelete = default(bool?), string deferredDeleteTimeRemaining = null, bool? isDeferredDeleteScheduleUpcoming = default(bool?), bool? isRehydrate = default(bool?), System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests = null, bool? isArchiveEnabled = default(bool?), string policyName = null, int? softDeleteRetentionPeriodInDays = default(int?), string vaultId = null, string friendlyName = null, string serverName = null, string parentName = null, string parentType = null, string protectionStatus = null, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? protectionState = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState?), Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus? lastBackupStatus = default(Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus?), System.DateTimeOffset? lastBackupOn = default(System.DateTimeOffset?), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupErrorDetail lastBackupErrorDetail = null, string protectedItemDataSourceId = null, Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus? protectedItemHealthStatus = default(Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus?), Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemExtendedInfo extendedInfo = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails> kpisHealths = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.Models.DistributedNodesInfo> nodesList = null) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlDatabaseProtectedItem VmWorkloadSqlDatabaseProtectedItem(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType, string containerName, Azure.Core.ResourceIdentifier sourceResourceId, Azure.Core.ResourceIdentifier policyId, System.DateTimeOffset? lastRecoverOn, string backupSetName, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode, System.DateTimeOffset? deferredDeletedOn, bool? isScheduledForDeferredDelete, string deferredDeleteTimeRemaining, bool? isDeferredDeleteScheduleUpcoming, bool? isRehydrate, System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests, bool? isArchiveEnabled, string policyName, int? softDeleteRetentionPeriodInDays, string friendlyName, string serverName, string parentName, string parentType, string protectionStatus, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? protectionState, Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus? lastBackupStatus, System.DateTimeOffset? lastBackupOn, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupErrorDetail lastBackupErrorDetail, string protectedItemDataSourceId, Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus? protectedItemHealthStatus, Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemExtendedInfo extendedInfo, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails> kpisHealths, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.Models.DistributedNodesInfo> nodesList) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlDatabaseProtectedItem VmWorkloadSqlDatabaseProtectedItem(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? backupManagementType = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType?), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? workloadType = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType?), string containerName = null, Azure.Core.ResourceIdentifier sourceResourceId = null, Azure.Core.ResourceIdentifier policyId = null, System.DateTimeOffset? lastRecoverOn = default(System.DateTimeOffset?), string backupSetName = null, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? createMode = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode?), System.DateTimeOffset? deferredDeletedOn = default(System.DateTimeOffset?), bool? isScheduledForDeferredDelete = default(bool?), string deferredDeleteTimeRemaining = null, bool? isDeferredDeleteScheduleUpcoming = default(bool?), bool? isRehydrate = default(bool?), System.Collections.Generic.IEnumerable<string> resourceGuardOperationRequests = null, bool? isArchiveEnabled = default(bool?), string policyName = null, int? softDeleteRetentionPeriodInDays = default(int?), string vaultId = null, string friendlyName = null, string serverName = null, string parentName = null, string parentType = null, string protectionStatus = null, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? protectionState = default(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState?), Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus? lastBackupStatus = default(Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus?), System.DateTimeOffset? lastBackupOn = default(System.DateTimeOffset?), Azure.ResourceManager.RecoveryServicesBackup.Models.BackupErrorDetail lastBackupErrorDetail = null, string protectedItemDataSourceId = null, Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus? protectedItemHealthStatus = default(Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus?), Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemExtendedInfo extendedInfo = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails> kpisHealths = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesBackup.Models.DistributedNodesInfo> nodesList = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemResource WorkloadItemResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItem properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItemResource WorkloadProtectableItemResource(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItem properties = null, Azure.ETag? eTag = default(Azure.ETag?)) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class AzureVmWorkloadSapHanaHSRProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectableItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.AzureVmWorkloadSapHanaHSRProtectableItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.AzureVmWorkloadSapHanaHSRProtectableItem>
    {
        public AzureVmWorkloadSapHanaHSRProtectableItem() { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.AzureVmWorkloadSapHanaHSRProtectableItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.AzureVmWorkloadSapHanaHSRProtectableItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.AzureVmWorkloadSapHanaHSRProtectableItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.AzureVmWorkloadSapHanaHSRProtectableItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.AzureVmWorkloadSapHanaHSRProtectableItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.AzureVmWorkloadSapHanaHSRProtectableItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.AzureVmWorkloadSapHanaHSRProtectableItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupCommonSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCommonSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCommonSettings>
    {
        public BackupCommonSettings() { }
        public bool? IsCompression { get { throw null; } set { } }
        public bool? IsSqlCompression { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCommonSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCommonSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCommonSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCommonSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCommonSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCommonSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCommonSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class BackupContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupContent>
    {
        protected BackupContent() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupCreateMode : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupCreateMode(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode Default { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode Recover { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupDataSourceType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupDataSourceType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType AzureFileShare { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType AzureSqlDB { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType Client { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType Exchange { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType FileFolder { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType GenericDataSource { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType SapAseDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType SapHanaDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType SapHanaDBInstance { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType Sharepoint { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType SqlDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType SqlDB { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType SystemState { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType Vm { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType VMwareVm { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BackupDay : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDay>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDay>
    {
        public BackupDay() { }
        public int? Date { get { throw null; } set { } }
        public bool? IsLast { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDay System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDay>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDay>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDay System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDay>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDay>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDay>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum BackupDayOfWeek
    {
        Sunday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupEncryptionAtRestType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEncryptionAtRestType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupEncryptionAtRestType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEncryptionAtRestType CustomerManaged { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEncryptionAtRestType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEncryptionAtRestType MicrosoftManaged { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEncryptionAtRestType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEncryptionAtRestType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEncryptionAtRestType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEncryptionAtRestType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEncryptionAtRestType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEncryptionAtRestType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BackupEngineExtendedInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEngineExtendedInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEngineExtendedInfo>
    {
        public BackupEngineExtendedInfo() { }
        public double? AvailableDiskSpace { get { throw null; } set { } }
        public int? AzureProtectedInstances { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public int? DiskCount { get { throw null; } set { } }
        public int? ProtectedItemsCount { get { throw null; } set { } }
        public int? ProtectedServersCount { get { throw null; } set { } }
        public System.DateTimeOffset? RefreshedOn { get { throw null; } set { } }
        public double? UsedDiskSpace { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEngineExtendedInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEngineExtendedInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEngineExtendedInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEngineExtendedInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEngineExtendedInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEngineExtendedInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEngineExtendedInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupErrorDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupErrorDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupErrorDetail>
    {
        public BackupErrorDetail() { }
        public string Code { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Recommendations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupErrorDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupErrorDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupErrorDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupErrorDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupErrorDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupErrorDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupErrorDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupFabricName : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFabricName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupFabricName(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFabricName Azure { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFabricName Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFabricName other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFabricName left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFabricName right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFabricName (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFabricName left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFabricName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupFileShareType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFileShareType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupFileShareType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFileShareType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFileShareType Xsmb { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFileShareType XSync { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFileShareType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFileShareType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFileShareType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFileShareType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFileShareType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFileShareType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class BackupGenericEngine : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericEngine>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericEngine>
    {
        protected BackupGenericEngine() { }
        public string AzureBackupAgentVersion { get { throw null; } set { } }
        public string BackupEngineId { get { throw null; } set { } }
        public string BackupEngineState { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? BackupManagementType { get { throw null; } set { } }
        public bool? CanReRegister { get { throw null; } set { } }
        public string DpmVersion { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEngineExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public string HealthStatus { get { throw null; } set { } }
        public bool? IsAzureBackupAgentUpgradeAvailable { get { throw null; } set { } }
        public bool? IsDpmUpgradeAvailable { get { throw null; } set { } }
        public string RegistrationStatus { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericEngine System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericEngine>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericEngine>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericEngine System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericEngine>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericEngine>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericEngine>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class BackupGenericJob : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericJob>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericJob>
    {
        protected BackupGenericJob() { }
        public string ActivityId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? BackupManagementType { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string EntityFriendlyName { get { throw null; } set { } }
        public string Operation { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericJob System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericJob System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class BackupGenericProtectedItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectedItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectedItem>
    {
        protected BackupGenericProtectedItem() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? BackupManagementType { get { throw null; } }
        public string BackupSetName { get { throw null; } set { } }
        public string ContainerName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCreateMode? CreateMode { get { throw null; } set { } }
        public System.DateTimeOffset? DeferredDeletedOn { get { throw null; } set { } }
        public string DeferredDeleteTimeRemaining { get { throw null; } set { } }
        public bool? IsArchiveEnabled { get { throw null; } set { } }
        public bool? IsDeferredDeleteScheduleUpcoming { get { throw null; } set { } }
        public bool? IsRehydrate { get { throw null; } set { } }
        public bool? IsScheduledForDeferredDelete { get { throw null; } set { } }
        public System.DateTimeOffset? LastRecoverOn { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PolicyId { get { throw null; } set { } }
        public string PolicyName { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ResourceGuardOperationRequests { get { throw null; } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public int? SoftDeleteRetentionPeriod { get { throw null; } set { } }
        public int? SoftDeleteRetentionPeriodInDays { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
        public string VaultId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? WorkloadType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectedItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectedItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectedItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectedItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectedItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectedItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectedItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class BackupGenericProtectionContainer : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionContainer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionContainer>
    {
        protected BackupGenericProtectionContainer() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? BackupManagementType { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public string HealthStatus { get { throw null; } set { } }
        public string ProtectableObjectType { get { throw null; } set { } }
        public string RegistrationStatus { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionContainer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionContainer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionContainer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionContainer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionContainer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionContainer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionContainer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class BackupGenericProtectionIntent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionIntent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionIntent>
    {
        protected BackupGenericProtectionIntent() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? BackupManagementType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ItemId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier PolicyId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus? ProtectionState { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionIntent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionIntent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionIntent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionIntent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionIntent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionIntent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionIntent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class BackupGenericProtectionPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionPolicy>
    {
        protected BackupGenericProtectionPolicy() { }
        public int? ProtectedItemsCount { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ResourceGuardOperationRequests { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class BackupGenericRecoveryPoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericRecoveryPoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericRecoveryPoint>
    {
        protected BackupGenericRecoveryPoint() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericRecoveryPoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericRecoveryPoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericRecoveryPoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericRecoveryPoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericRecoveryPoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericRecoveryPoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericRecoveryPoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupGoalFeatureSupportContent : Azure.ResourceManager.RecoveryServicesBackup.Models.FeatureSupportContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGoalFeatureSupportContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGoalFeatureSupportContent>
    {
        public BackupGoalFeatureSupportContent() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGoalFeatureSupportContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGoalFeatureSupportContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGoalFeatureSupportContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGoalFeatureSupportContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGoalFeatureSupportContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGoalFeatureSupportContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGoalFeatureSupportContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupHourlySchedule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupHourlySchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupHourlySchedule>
    {
        public BackupHourlySchedule() { }
        public int? Interval { get { throw null; } set { } }
        public int? ScheduleWindowDuration { get { throw null; } set { } }
        public System.DateTimeOffset? ScheduleWindowStartOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupHourlySchedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupHourlySchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupHourlySchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupHourlySchedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupHourlySchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupHourlySchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupHourlySchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupIdentityInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupIdentityInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupIdentityInfo>
    {
        public BackupIdentityInfo() { }
        public bool? IsSystemAssignedIdentity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ManagedIdentityResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupIdentityInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupIdentityInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupIdentityInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupIdentityInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupIdentityInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupIdentityInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupIdentityInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupItemType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupItemType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType AzureFileShare { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType AzureSqlDB { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType Client { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType Exchange { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType FileFolder { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType GenericDataSource { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType SapAseDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType SapHanaDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType SapHanaDBInstance { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType Sharepoint { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType SqlDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType SqlDB { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType SystemState { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType Vm { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType VMwareVm { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupManagementType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupManagementType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType AzureBackupServer { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType AzureIaasVm { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType AzureSql { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType AzureStorage { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType AzureWorkload { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType BackupProtectedItemCountSummary { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType BackupProtectionContainerCountSummary { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType DefaultBackup { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType Dpm { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType Mab { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BackupManagementUsage : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementUsage>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementUsage>
    {
        internal BackupManagementUsage() { }
        public long? CurrentValue { get { throw null; } }
        public long? Limit { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupNameInfo Name { get { throw null; } }
        public System.DateTimeOffset? NextResetOn { get { throw null; } }
        public string QuotaPeriod { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupUsagesUnit? Unit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementUsage System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementUsage>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementUsage>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementUsage System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementUsage>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementUsage>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementUsage>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum BackupMonthOfYear
    {
        Invalid = 0,
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12,
    }
    public partial class BackupNameInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupNameInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupNameInfo>
    {
        internal BackupNameInfo() { }
        public string LocalizedValue { get { throw null; } }
        public string Value { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupNameInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupNameInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupNameInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupNameInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupNameInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupNameInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupNameInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupPrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProperties>
    {
        public BackupPrivateEndpointConnectionProperties() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultSubResourceType> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryServicesBackupPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProvisioningState Pending { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupProtectionState : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupProtectionState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState BackupsSuspended { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState IRPending { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState Protected { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState ProtectionError { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState ProtectionPaused { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState ProtectionStopped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupProtectionStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupProtectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus NotProtected { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus Protected { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus Protecting { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus ProtectionFailed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BackupResourceConfigProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceConfigProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceConfigProperties>
    {
        public BackupResourceConfigProperties() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.VaultDedupState? DedupState { get { throw null; } set { } }
        public bool? EnableCrossRegionRestore { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType? StorageModelType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType? StorageType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageTypeState? StorageTypeState { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.VaultXcoolState? XcoolState { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceConfigProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceConfigProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceConfigProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceConfigProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceConfigProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceConfigProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceConfigProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupResourceEncryptionConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfig>
    {
        public BackupResourceEncryptionConfig() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupEncryptionAtRestType? EncryptionAtRestType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.InfrastructureEncryptionState? InfrastructureEncryptionState { get { throw null; } set { } }
        public System.Uri KeyUri { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus? LastUpdateStatus { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupResourceEncryptionConfigExtendedCreateOrUpdateContent : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfigExtendedCreateOrUpdateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfigExtendedCreateOrUpdateContent>
    {
        public BackupResourceEncryptionConfigExtendedCreateOrUpdateContent(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfig Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfigExtendedCreateOrUpdateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfigExtendedCreateOrUpdateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfigExtendedCreateOrUpdateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfigExtendedCreateOrUpdateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfigExtendedCreateOrUpdateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfigExtendedCreateOrUpdateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfigExtendedCreateOrUpdateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupResourceEncryptionConfigExtendedProperties : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfig, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfigExtendedProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfigExtendedProperties>
    {
        public BackupResourceEncryptionConfigExtendedProperties() { }
        public Azure.Core.ResourceIdentifier UserAssignedIdentity { get { throw null; } set { } }
        public bool? UseSystemAssignedIdentity { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfigExtendedProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfigExtendedProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfigExtendedProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfigExtendedProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfigExtendedProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfigExtendedProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceEncryptionConfigExtendedProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupResourceVaultConfigProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceVaultConfigProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceVaultConfigProperties>
    {
        public BackupResourceVaultConfigProperties() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.EnhancedSecurityState? EnhancedSecurityState { get { throw null; } set { } }
        public bool? IsSoftDeleteFeatureStateEditable { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> ResourceGuardOperationRequests { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.SoftDeleteFeatureState? SoftDeleteFeatureState { get { throw null; } set { } }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public int? SoftDeleteRetentionPeriod { get { throw null; } set { } }
        public int? SoftDeleteRetentionPeriodInDays { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType? StorageModelType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType? StorageType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageTypeState? StorageTypeState { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceVaultConfigProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceVaultConfigProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceVaultConfigProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceVaultConfigProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceVaultConfigProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceVaultConfigProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupResourceVaultConfigProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class BackupRetentionPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRetentionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRetentionPolicy>
    {
        protected BackupRetentionPolicy() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRetentionPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRetentionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRetentionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRetentionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRetentionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRetentionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRetentionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class BackupSchedulePolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupSchedulePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupSchedulePolicy>
    {
        protected BackupSchedulePolicy() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupSchedulePolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupSchedulePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupSchedulePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupSchedulePolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupSchedulePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupSchedulePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupSchedulePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupServerContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.DpmContainer, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupServerContainer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupServerContainer>
    {
        public BackupServerContainer() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupServerContainer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupServerContainer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupServerContainer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupServerContainer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupServerContainer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupServerContainer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupServerContainer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupServerEngine : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericEngine, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupServerEngine>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupServerEngine>
    {
        public BackupServerEngine() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupServerEngine System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupServerEngine>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupServerEngine>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupServerEngine System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupServerEngine>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupServerEngine>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupServerEngine>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupStatusContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusContent>
    {
        public BackupStatusContent() { }
        public string PoLogicalName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? ResourceType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupStatusResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusResult>
    {
        internal BackupStatusResult() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.AcquireStorageAccountLock? AcquireStorageAccountLock { get { throw null; } }
        public string ContainerName { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFabricName? FabricName { get { throw null; } }
        public string PolicyName { get { throw null; } }
        public string ProtectedItemName { get { throw null; } }
        public int? ProtectedItemsCount { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus? ProtectionStatus { get { throw null; } }
        public string RegistrationStatus { get { throw null; } }
        public Azure.Core.ResourceIdentifier VaultId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStatusResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupStorageType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupStorageType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType GeoRedundant { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType LocallyRedundant { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType ReadAccessGeoZoneRedundant { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType ZoneRedundant { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupStorageTypeState : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageTypeState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupStorageTypeState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageTypeState Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageTypeState Locked { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageTypeState Unlocked { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageTypeState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageTypeState left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageTypeState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageTypeState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageTypeState left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupStorageTypeState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public enum BackupTargetDiskNetworkAccessOption
    {
        SameAsOnSourceDisks = 0,
        EnablePrivateAccessForAllDisks = 1,
        EnablePublicAccessForAllDisks = 2,
    }
    public partial class BackupTargetDiskNetworkAccessSettings : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupTargetDiskNetworkAccessSettings>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupTargetDiskNetworkAccessSettings>
    {
        public BackupTargetDiskNetworkAccessSettings() { }
        public Azure.Core.ResourceIdentifier TargetDiskAccessId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupTargetDiskNetworkAccessOption? TargetDiskNetworkAccessOption { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupTargetDiskNetworkAccessSettings System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupTargetDiskNetworkAccessSettings>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupTargetDiskNetworkAccessSettings>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupTargetDiskNetworkAccessSettings System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupTargetDiskNetworkAccessSettings>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupTargetDiskNetworkAccessSettings>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupTargetDiskNetworkAccessSettings>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class BackupTieringPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupTieringPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupTieringPolicy>
    {
        public BackupTieringPolicy() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDurationType? DurationType { get { throw null; } set { } }
        public int? DurationValue { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.TieringMode? TieringMode { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupTieringPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupTieringPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupTieringPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupTieringPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupTieringPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupTieringPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupTieringPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType CopyOnlyFull { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType Differential { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType Full { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType Incremental { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType Log { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType SnapshotCopyOnlyFull { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType SnapshotFull { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupUsagesUnit : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupUsagesUnit>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupUsagesUnit(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupUsagesUnit Bytes { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupUsagesUnit BytesPerSecond { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupUsagesUnit Count { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupUsagesUnit CountPerSecond { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupUsagesUnit Percent { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupUsagesUnit Seconds { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupUsagesUnit other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupUsagesUnit left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupUsagesUnit right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupUsagesUnit (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupUsagesUnit left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupUsagesUnit right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupValidationStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupValidationStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupValidationStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupValidationStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupValidationStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupValidationStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupValidationStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupValidationStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupValidationStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupValidationStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupValidationStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupValidationStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BackupWeeklySchedule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWeeklySchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWeeklySchedule>
    {
        public BackupWeeklySchedule() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDayOfWeek> ScheduleRunDays { get { throw null; } }
        public System.Collections.Generic.IList<System.DateTimeOffset> ScheduleRunTimes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWeeklySchedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWeeklySchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWeeklySchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWeeklySchedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWeeklySchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWeeklySchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWeeklySchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum BackupWeekOfMonth
    {
        First = 0,
        Second = 1,
        Third = 2,
        Fourth = 3,
        Last = 4,
        Invalid = 5,
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct BackupWorkloadType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public BackupWorkloadType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType AzureFileShare { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType AzureSqlDB { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType Client { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType Exchange { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType FileFolder { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType GenericDataSource { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType SapAseDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType SapHanaDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType SapHanaDBInstance { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType Sharepoint { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType SqlDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType SqlDB { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType SystemState { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType Vm { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType VMwareVm { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType left, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class BekDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BekDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BekDetails>
    {
        public BekDetails() { }
        public string SecretData { get { throw null; } set { } }
        public System.Uri SecretUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SecretVaultId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BekDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BekDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BekDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.BekDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BekDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BekDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.BekDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ContainerIdentityInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ContainerIdentityInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ContainerIdentityInfo>
    {
        public ContainerIdentityInfo() { }
        public System.Guid? AadTenantId { get { throw null; } set { } }
        public string Audience { get { throw null; } set { } }
        public string ServicePrincipalClientId { get { throw null; } set { } }
        public string UniqueName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.ContainerIdentityInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ContainerIdentityInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ContainerIdentityInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.ContainerIdentityInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ContainerIdentityInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ContainerIdentityInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ContainerIdentityInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DailyRetentionSchedule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DailyRetentionSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DailyRetentionSchedule>
    {
        public DailyRetentionSchedule() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDuration RetentionDuration { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.DateTimeOffset> RetentionTimes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.DailyRetentionSchedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DailyRetentionSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DailyRetentionSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.DailyRetentionSchedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DailyRetentionSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DailyRetentionSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DailyRetentionSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataMoveLevel : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataMoveLevel(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel Container { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel Vault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel left, Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel left, Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DiskExclusionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DiskExclusionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DiskExclusionProperties>
    {
        public DiskExclusionProperties() { }
        public System.Collections.Generic.IList<int> DiskLunList { get { throw null; } }
        public bool? IsInclusionList { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.DiskExclusionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DiskExclusionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DiskExclusionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.DiskExclusionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DiskExclusionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DiskExclusionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DiskExclusionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DiskInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DiskInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DiskInformation>
    {
        public DiskInformation() { }
        public int? Lun { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.DiskInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DiskInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DiskInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.DiskInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DiskInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DiskInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DiskInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DistributedNodesInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DistributedNodesInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DistributedNodesInfo>
    {
        public DistributedNodesInfo() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupErrorDetail ErrorDetail { get { throw null; } set { } }
        public string NodeName { get { throw null; } set { } }
        public string SourceResourceId { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.DistributedNodesInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DistributedNodesInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DistributedNodesInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.DistributedNodesInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DistributedNodesInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DistributedNodesInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DistributedNodesInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DpmBackupEngine : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericEngine, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupEngine>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupEngine>
    {
        public DpmBackupEngine() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupEngine System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupEngine>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupEngine>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupEngine System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupEngine>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupEngine>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupEngine>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DpmBackupJob : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericJob, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJob>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJob>
    {
        public DpmBackupJob() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.JobSupportedAction> ActionsInfo { get { throw null; } }
        public string ContainerName { get { throw null; } set { } }
        public string ContainerType { get { throw null; } set { } }
        public string DpmServerName { get { throw null; } set { } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmErrorInfo> ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJobExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public string WorkloadType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJob System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJob System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DpmBackupJobExtendedInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJobExtendedInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJobExtendedInfo>
    {
        public DpmBackupJobExtendedInfo() { }
        public string DynamicErrorMessage { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> PropertyBag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJobTaskDetails> TasksList { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJobExtendedInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJobExtendedInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJobExtendedInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJobExtendedInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJobExtendedInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJobExtendedInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJobExtendedInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DpmBackupJobTaskDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJobTaskDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJobTaskDetails>
    {
        public DpmBackupJobTaskDetails() { }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        public string TaskId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJobTaskDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJobTaskDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJobTaskDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJobTaskDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJobTaskDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJobTaskDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmBackupJobTaskDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DpmContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionContainer, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmContainer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmContainer>
    {
        public DpmContainer() { }
        public bool? CanReRegister { get { throw null; } set { } }
        public string ContainerId { get { throw null; } set { } }
        public string DpmAgentVersion { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DpmServers { get { throw null; } }
        public System.DateTimeOffset? ExtendedInfoLastRefreshedOn { get { throw null; } set { } }
        public bool? IsUpgradeAvailable { get { throw null; } set { } }
        public long? ProtectedItemCount { get { throw null; } set { } }
        public string ProtectionStatus { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.DpmContainer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmContainer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmContainer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.DpmContainer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmContainer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmContainer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmContainer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DpmErrorInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmErrorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmErrorInfo>
    {
        public DpmErrorInfo() { }
        public string ErrorString { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Recommendations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.DpmErrorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmErrorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmErrorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.DpmErrorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmErrorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmErrorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmErrorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DpmProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectedItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmProtectedItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmProtectedItem>
    {
        public DpmProtectedItem() { }
        public string BackupEngineName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.DpmProtectedItemExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState? ProtectionState { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.DpmProtectedItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmProtectedItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmProtectedItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.DpmProtectedItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmProtectedItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmProtectedItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmProtectedItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DpmProtectedItemExtendedInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmProtectedItemExtendedInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmProtectedItemExtendedInfo>
    {
        public DpmProtectedItemExtendedInfo() { }
        public string DiskStorageUsedInBytes { get { throw null; } set { } }
        public bool? IsCollocated { get { throw null; } set { } }
        public bool? IsPresentOnCloud { get { throw null; } set { } }
        public bool? IsProtected { get { throw null; } set { } }
        public string LastBackupStatus { get { throw null; } set { } }
        public System.DateTimeOffset? LastRefreshedOn { get { throw null; } set { } }
        public System.DateTimeOffset? OldestRecoverOn { get { throw null; } set { } }
        public System.DateTimeOffset? OnPremiseLatestRecoverOn { get { throw null; } set { } }
        public System.DateTimeOffset? OnPremiseOldestRecoverOn { get { throw null; } set { } }
        public int? OnPremiseRecoveryPointCount { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ProtectableObjectLoadPath { get { throw null; } }
        public string ProtectionGroupName { get { throw null; } set { } }
        public int? RecoveryPointCount { get { throw null; } set { } }
        public string TotalDiskStorageSizeInBytes { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.DpmProtectedItemExtendedInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmProtectedItemExtendedInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmProtectedItemExtendedInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.DpmProtectedItemExtendedInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmProtectedItemExtendedInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmProtectedItemExtendedInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.DpmProtectedItemExtendedInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnhancedSecurityState : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.EnhancedSecurityState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnhancedSecurityState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.EnhancedSecurityState Disabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.EnhancedSecurityState Enabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.EnhancedSecurityState Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.EnhancedSecurityState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.EnhancedSecurityState left, Azure.ResourceManager.RecoveryServicesBackup.Models.EnhancedSecurityState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.EnhancedSecurityState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.EnhancedSecurityState left, Azure.ResourceManager.RecoveryServicesBackup.Models.EnhancedSecurityState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class FeatureSupportContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FeatureSupportContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FeatureSupportContent>
    {
        protected FeatureSupportContent() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.FeatureSupportContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FeatureSupportContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FeatureSupportContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.FeatureSupportContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FeatureSupportContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FeatureSupportContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FeatureSupportContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class FetchTieringCostInfoContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostInfoContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostInfoContent>
    {
        protected FetchTieringCostInfoContent(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType sourceTierType, Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType targetTierType) { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType SourceTierType { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType TargetTierType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostInfoContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostInfoContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostInfoContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostInfoContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostInfoContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostInfoContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostInfoContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FetchTieringCostInfoForRehydrationContent : Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostInfoContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostInfoForRehydrationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostInfoForRehydrationContent>
    {
        public FetchTieringCostInfoForRehydrationContent(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType sourceTierType, Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType targetTierType, string containerName, string protectedItemName, string recoveryPointId, Azure.ResourceManager.RecoveryServicesBackup.Models.RehydrationPriority rehydrationPriority) : base (default(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType), default(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType)) { }
        public string ContainerName { get { throw null; } }
        public string ProtectedItemName { get { throw null; } }
        public string RecoveryPointId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RehydrationPriority RehydrationPriority { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostInfoForRehydrationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostInfoForRehydrationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostInfoForRehydrationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostInfoForRehydrationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostInfoForRehydrationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostInfoForRehydrationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostInfoForRehydrationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FetchTieringCostSavingsInfoForPolicyContent : Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostInfoContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostSavingsInfoForPolicyContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostSavingsInfoForPolicyContent>
    {
        public FetchTieringCostSavingsInfoForPolicyContent(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType sourceTierType, Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType targetTierType, string policyName) : base (default(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType), default(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType)) { }
        public string PolicyName { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostSavingsInfoForPolicyContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostSavingsInfoForPolicyContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostSavingsInfoForPolicyContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostSavingsInfoForPolicyContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostSavingsInfoForPolicyContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostSavingsInfoForPolicyContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostSavingsInfoForPolicyContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FetchTieringCostSavingsInfoForProtectedItemContent : Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostInfoContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostSavingsInfoForProtectedItemContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostSavingsInfoForProtectedItemContent>
    {
        public FetchTieringCostSavingsInfoForProtectedItemContent(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType sourceTierType, Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType targetTierType, string containerName, string protectedItemName) : base (default(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType), default(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType)) { }
        public string ContainerName { get { throw null; } }
        public string ProtectedItemName { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostSavingsInfoForProtectedItemContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostSavingsInfoForProtectedItemContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostSavingsInfoForProtectedItemContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostSavingsInfoForProtectedItemContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostSavingsInfoForProtectedItemContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostSavingsInfoForProtectedItemContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostSavingsInfoForProtectedItemContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FetchTieringCostSavingsInfoForVaultContent : Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostInfoContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostSavingsInfoForVaultContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostSavingsInfoForVaultContent>
    {
        public FetchTieringCostSavingsInfoForVaultContent(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType sourceTierType, Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType targetTierType) : base (default(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType), default(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType)) { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostSavingsInfoForVaultContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostSavingsInfoForVaultContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostSavingsInfoForVaultContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostSavingsInfoForVaultContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostSavingsInfoForVaultContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostSavingsInfoForVaultContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FetchTieringCostSavingsInfoForVaultContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileShareBackupContent : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareBackupContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareBackupContent>
    {
        public FileShareBackupContent() { }
        public System.DateTimeOffset? RecoveryPointExpireOn { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareBackupContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareBackupContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareBackupContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareBackupContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareBackupContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareBackupContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareBackupContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileShareCopyOption : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareCopyOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileShareCopyOption(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareCopyOption CreateCopy { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareCopyOption FailOnConflict { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareCopyOption Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareCopyOption Overwrite { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareCopyOption Skip { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareCopyOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareCopyOption left, Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareCopyOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareCopyOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareCopyOption left, Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareCopyOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FileShareProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareProtectableItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareProtectableItem>
    {
        public FileShareProtectableItem() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupFileShareType? AzureFileShareType { get { throw null; } set { } }
        public string ParentContainerFabricId { get { throw null; } set { } }
        public string ParentContainerFriendlyName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareProtectableItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareProtectableItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareProtectableItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareProtectableItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareProtectableItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareProtectableItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareProtectableItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileshareProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectedItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileshareProtectedItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileshareProtectedItem>
    {
        public FileshareProtectedItem() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.FileshareProtectedItemExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails> KpisHealths { get { throw null; } }
        public System.DateTimeOffset? LastBackupOn { get { throw null; } set { } }
        public string LastBackupStatus { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? ProtectionState { get { throw null; } set { } }
        public string ProtectionStatus { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.FileshareProtectedItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileshareProtectedItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileshareProtectedItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.FileshareProtectedItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileshareProtectedItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileshareProtectedItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileshareProtectedItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileshareProtectedItemExtendedInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileshareProtectedItemExtendedInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileshareProtectedItemExtendedInfo>
    {
        public FileshareProtectedItemExtendedInfo() { }
        public System.DateTimeOffset? OldestRecoverOn { get { throw null; } set { } }
        public string PolicyState { get { throw null; } set { } }
        public int? RecoveryPointCount { get { throw null; } set { } }
        public string ResourceState { get { throw null; } }
        public System.DateTimeOffset? ResourceStateSyncOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.FileshareProtectedItemExtendedInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileshareProtectedItemExtendedInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileshareProtectedItemExtendedInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.FileshareProtectedItemExtendedInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileshareProtectedItemExtendedInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileshareProtectedItemExtendedInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileshareProtectedItemExtendedInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileShareProtectionPolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionPolicy, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareProtectionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareProtectionPolicy>
    {
        public FileShareProtectionPolicy() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupSchedulePolicy SchedulePolicy { get { throw null; } set { } }
        public string TimeZone { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.VaultRetentionPolicy VaultRetentionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType? WorkLoadType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareProtectionPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareProtectionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareProtectionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareProtectionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareProtectionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareProtectionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareProtectionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileShareProvisionIlrContent : Azure.ResourceManager.RecoveryServicesBackup.Models.IlrContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareProvisionIlrContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareProvisionIlrContent>
    {
        public FileShareProvisionIlrContent() { }
        public string RecoveryPointId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareProvisionIlrContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareProvisionIlrContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareProvisionIlrContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareProvisionIlrContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareProvisionIlrContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareProvisionIlrContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareProvisionIlrContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FileShareRecoveryPoint : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericRecoveryPoint, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryPoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryPoint>
    {
        public FileShareRecoveryPoint() { }
        public System.Uri FileShareSnapshotUri { get { throw null; } set { } }
        public System.DateTimeOffset? RecoveryPointOn { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointProperties RecoveryPointProperties { get { throw null; } set { } }
        public int? RecoveryPointSizeInGB { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierInformation> RecoveryPointTierDetails { get { throw null; } }
        public string RecoveryPointType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryPoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryPoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryPoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryPoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryPoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryPoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryPoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileShareRecoveryType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileShareRecoveryType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryType AlternateLocation { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryType Offline { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryType OriginalLocation { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryType RestoreDisks { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryType left, Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryType left, Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class FileShareRestoreContent : Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreContent>
    {
        public FileShareRestoreContent() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareCopyOption? CopyOptions { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryType? RecoveryType { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreFileSpecs> RestoreFileSpecs { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreType? RestoreRequestType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.TargetAfsRestoreInfo TargetDetails { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct FileShareRestoreType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public FileShareRestoreType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreType FullShareRestore { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreType ItemLevelRestore { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreType left, Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreType left, Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRestoreType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GenericContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionContainer, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericContainer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericContainer>
    {
        public GenericContainer() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.GenericContainerExtendedInfo ExtendedInformation { get { throw null; } set { } }
        public string FabricName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.GenericContainer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericContainer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericContainer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.GenericContainer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericContainer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericContainer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericContainer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GenericContainerExtendedInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericContainerExtendedInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericContainerExtendedInfo>
    {
        public GenericContainerExtendedInfo() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ContainerIdentityInfo ContainerIdentityInfo { get { throw null; } set { } }
        public string RawCertData { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> ServiceEndpoints { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.GenericContainerExtendedInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericContainerExtendedInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericContainerExtendedInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.GenericContainerExtendedInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericContainerExtendedInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericContainerExtendedInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericContainerExtendedInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GenericProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectedItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericProtectedItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericProtectedItem>
    {
        public GenericProtectedItem() { }
        public string FabricName { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public string PolicyState { get { throw null; } set { } }
        public long? ProtectedItemId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? ProtectionState { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> SourceAssociations { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.GenericProtectedItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericProtectedItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericProtectedItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.GenericProtectedItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericProtectedItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericProtectedItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericProtectedItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GenericProtectionPolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionPolicy, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericProtectionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericProtectionPolicy>
    {
        public GenericProtectionPolicy() { }
        public string FabricName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicy> SubProtectionPolicy { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.GenericProtectionPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericProtectionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericProtectionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.GenericProtectionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericProtectionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericProtectionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericProtectionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GenericRecoveryPoint : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericRecoveryPoint, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericRecoveryPoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericRecoveryPoint>
    {
        public GenericRecoveryPoint() { }
        public string FriendlyName { get { throw null; } set { } }
        public string RecoveryPointAdditionalInfo { get { throw null; } set { } }
        public System.DateTimeOffset? RecoveryPointOn { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointProperties RecoveryPointProperties { get { throw null; } set { } }
        public string RecoveryPointType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.GenericRecoveryPoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericRecoveryPoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericRecoveryPoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.GenericRecoveryPoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericRecoveryPoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericRecoveryPoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.GenericRecoveryPoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IaasClassicComputeVmContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmContainer, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasClassicComputeVmContainer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasClassicComputeVmContainer>
    {
        public IaasClassicComputeVmContainer() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasClassicComputeVmContainer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasClassicComputeVmContainer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasClassicComputeVmContainer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasClassicComputeVmContainer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasClassicComputeVmContainer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasClassicComputeVmContainer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasClassicComputeVmContainer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IaasClassicComputeVmProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectableItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasClassicComputeVmProtectableItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasClassicComputeVmProtectableItem>
    {
        public IaasClassicComputeVmProtectableItem() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasClassicComputeVmProtectableItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasClassicComputeVmProtectableItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasClassicComputeVmProtectableItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasClassicComputeVmProtectableItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasClassicComputeVmProtectableItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasClassicComputeVmProtectableItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasClassicComputeVmProtectableItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IaasClassicComputeVmProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasClassicComputeVmProtectedItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasClassicComputeVmProtectedItem>
    {
        public IaasClassicComputeVmProtectedItem() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasClassicComputeVmProtectedItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasClassicComputeVmProtectedItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasClassicComputeVmProtectedItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasClassicComputeVmProtectedItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasClassicComputeVmProtectedItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasClassicComputeVmProtectedItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasClassicComputeVmProtectedItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IaasComputeVmContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmContainer, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasComputeVmContainer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasComputeVmContainer>
    {
        public IaasComputeVmContainer() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasComputeVmContainer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasComputeVmContainer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasComputeVmContainer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasComputeVmContainer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasComputeVmContainer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasComputeVmContainer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasComputeVmContainer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IaasComputeVmProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectableItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasComputeVmProtectableItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasComputeVmProtectableItem>
    {
        public IaasComputeVmProtectableItem() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasComputeVmProtectableItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasComputeVmProtectableItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasComputeVmProtectableItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasComputeVmProtectableItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasComputeVmProtectableItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasComputeVmProtectableItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasComputeVmProtectableItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IaasComputeVmProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasComputeVmProtectedItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasComputeVmProtectedItem>
    {
        public IaasComputeVmProtectedItem() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasComputeVmProtectedItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasComputeVmProtectedItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasComputeVmProtectedItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasComputeVmProtectedItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasComputeVmProtectedItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasComputeVmProtectedItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasComputeVmProtectedItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IaasVmBackupContent : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupContent>
    {
        public IaasVmBackupContent() { }
        public System.DateTimeOffset? RecoveryPointExpireOn { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IaasVmBackupExtendedProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupExtendedProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupExtendedProperties>
    {
        public IaasVmBackupExtendedProperties() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.DiskExclusionProperties DiskExclusionProperties { get { throw null; } set { } }
        public string LinuxVmApplicationName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupExtendedProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupExtendedProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupExtendedProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupExtendedProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupExtendedProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupExtendedProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupExtendedProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IaasVmBackupJob : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericJob, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJob>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJob>
    {
        public IaasVmBackupJob() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.JobSupportedAction> ActionsInfo { get { throw null; } }
        public string ContainerName { get { throw null; } set { } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmErrorInfo> ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public bool? IsUserTriggered { get { throw null; } set { } }
        public string VirtualMachineVersion { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJob System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJob System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IaasVmBackupJobExtendedInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobExtendedInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobExtendedInfo>
    {
        public IaasVmBackupJobExtendedInfo() { }
        public string DynamicErrorMessage { get { throw null; } set { } }
        public string EstimatedRemainingDurationValue { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> InternalPropertyBag { get { throw null; } }
        public double? ProgressPercentage { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> PropertyBag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobTaskDetails> TasksList { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobExtendedInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobExtendedInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobExtendedInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobExtendedInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobExtendedInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobExtendedInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobExtendedInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IaasVmBackupJobTaskDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobTaskDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobTaskDetails>
    {
        public IaasVmBackupJobTaskDetails() { }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public string InstanceId { get { throw null; } set { } }
        public double? ProgressPercentage { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        public string TaskExecutionDetails { get { throw null; } set { } }
        public string TaskId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobTaskDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobTaskDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobTaskDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobTaskDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobTaskDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobTaskDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobTaskDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IaasVmBackupJobV2 : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericJob, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobV2>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobV2>
    {
        public IaasVmBackupJobV2() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.JobSupportedAction> ActionsInfo { get { throw null; } }
        public string ContainerName { get { throw null; } set { } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmErrorInfo> ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public string VirtualMachineVersion { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobV2 System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobV2>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobV2>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobV2 System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobV2>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobV2>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupJobV2>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IaasVmContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionContainer, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmContainer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmContainer>
    {
        public IaasVmContainer() { }
        public string ResourceGroup { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualMachineId { get { throw null; } set { } }
        public string VirtualMachineVersion { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmContainer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmContainer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmContainer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmContainer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmContainer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmContainer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmContainer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IaasVmErrorInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmErrorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmErrorInfo>
    {
        public IaasVmErrorInfo() { }
        public int? ErrorCode { get { throw null; } }
        public string ErrorString { get { throw null; } }
        public string ErrorTitle { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Recommendations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmErrorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmErrorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmErrorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmErrorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmErrorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmErrorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmErrorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IaasVmHealthDetails : Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthDetails, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmHealthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmHealthDetails>
    {
        public IaasVmHealthDetails() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmHealthDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmHealthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmHealthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmHealthDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmHealthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmHealthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmHealthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IaasVmIlrRegistrationContent : Azure.ResourceManager.RecoveryServicesBackup.Models.IlrContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmIlrRegistrationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmIlrRegistrationContent>
    {
        public IaasVmIlrRegistrationContent() { }
        public string InitiatorName { get { throw null; } set { } }
        public string RecoveryPointId { get { throw null; } set { } }
        public bool? RenewExistingRegistration { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualMachineId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmIlrRegistrationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmIlrRegistrationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmIlrRegistrationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmIlrRegistrationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmIlrRegistrationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmIlrRegistrationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmIlrRegistrationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IaasVmPolicyType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmPolicyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IaasVmPolicyType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmPolicyType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmPolicyType V1 { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmPolicyType V2 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmPolicyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmPolicyType left, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmPolicyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmPolicyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmPolicyType left, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmPolicyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IaasVmProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectableItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectableItem>
    {
        public IaasVmProtectableItem() { }
        public string ResourceGroup { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualMachineId { get { throw null; } set { } }
        public string VirtualMachineVersion { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectableItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectableItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectableItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectableItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectableItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectableItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectableItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IaasVmProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectedItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItem>
    {
        public IaasVmProtectedItem() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmBackupExtendedProperties ExtendedProperties { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmHealthDetails> HealthDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus? HealthStatus { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails> KpisHealths { get { throw null; } }
        public System.DateTimeOffset? LastBackupOn { get { throw null; } }
        public string LastBackupStatus { get { throw null; } set { } }
        public string PolicyType { get { throw null; } }
        public string ProtectedItemDataId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? ProtectionState { get { throw null; } set { } }
        public string ProtectionStatus { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualMachineId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IaasVmProtectedItemExtendedInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemExtendedInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemExtendedInfo>
    {
        public IaasVmProtectedItemExtendedInfo() { }
        public bool? IsPolicyInconsistent { get { throw null; } set { } }
        public System.DateTimeOffset? NewestRecoveryPointInArchive { get { throw null; } set { } }
        public System.DateTimeOffset? OldestRecoverOn { get { throw null; } set { } }
        public System.DateTimeOffset? OldestRecoveryPointInArchive { get { throw null; } set { } }
        public System.DateTimeOffset? OldestRecoveryPointInVault { get { throw null; } set { } }
        public int? RecoveryPointCount { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemExtendedInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemExtendedInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemExtendedInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemExtendedInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemExtendedInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemExtendedInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemExtendedInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IaasVmProtectedItemHealthStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IaasVmProtectedItemHealthStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus ActionRequired { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus ActionSuggested { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus Passed { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectedItemHealthStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IaasVmProtectionPolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionPolicy, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectionPolicy>
    {
        public IaasVmProtectionPolicy() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.InstantRPAdditionalDetails InstantRPDetails { get { throw null; } set { } }
        public int? InstantRPRetentionRangeInDays { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmPolicyType? PolicyType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupSchedulePolicy SchedulePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmSnapshotConsistencyType? SnapshotConsistencyType { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupTieringPolicy> TieringPolicy { get { throw null; } }
        public string TimeZone { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectionPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmProtectionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IaasVmRecoveryPoint : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericRecoveryPoint, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmRecoveryPoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmRecoveryPoint>
    {
        public IaasVmRecoveryPoint() { }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public bool? IsInstantIlrSessionActive { get { throw null; } set { } }
        public bool? IsManagedVirtualMachine { get { throw null; } set { } }
        public bool? IsPrivateAccessEnabledOnAnyDisk { get { throw null; } set { } }
        public bool? IsSourceVmEncrypted { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.KeyAndSecretDetails KeyAndSecret { get { throw null; } set { } }
        public bool? OriginalStorageAccountOption { get { throw null; } set { } }
        public string OSType { get { throw null; } set { } }
        public string RecoveryPointAdditionalInfo { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointDiskConfiguration RecoveryPointDiskConfiguration { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointMoveReadinessInfo> RecoveryPointMoveReadinessInfo { get { throw null; } }
        public System.DateTimeOffset? RecoveryPointOn { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointProperties RecoveryPointProperties { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierInformationV2> RecoveryPointTierDetails { get { throw null; } }
        public string RecoveryPointType { get { throw null; } set { } }
        public string SecurityType { get { throw null; } set { } }
        public string SourceVmStorageType { get { throw null; } set { } }
        public string VirtualMachineSize { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmRecoveryPoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmRecoveryPoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmRecoveryPoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmRecoveryPoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmRecoveryPoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmRecoveryPoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmRecoveryPoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IaasVmRestoreContent : Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmRestoreContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmRestoreContent>
    {
        public IaasVmRestoreContent() { }
        public string AffinityGroup { get { throw null; } set { } }
        public string DiskEncryptionSetId { get { throw null; } set { } }
        public bool? DoesCreateNewCloudService { get { throw null; } set { } }
        public bool? DoesRestoreWithManagedDisks { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.VmEncryptionDetails EncryptionDetails { get { throw null; } set { } }
        public Azure.ResourceManager.Resources.Models.ExtendedLocation ExtendedLocation { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.IdentityBasedRestoreDetails IdentityBasedRestoreDetails { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupIdentityInfo IdentityInfo { get { throw null; } set { } }
        public bool? OriginalStorageAccountOption { get { throw null; } set { } }
        public string RecoveryPointId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryType? RecoveryType { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Region { get { throw null; } set { } }
        public System.Collections.Generic.IList<int> RestoreDiskLunList { get { throw null; } }
        public Azure.Core.ResourceIdentifier SecuredVmOSDiskEncryptionSetId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageAccountId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SubnetId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupTargetDiskNetworkAccessSettings TargetDiskNetworkAccessSettings { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetDomainNameId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetResourceGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetVirtualMachineId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VirtualNetworkId { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Zones { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmRestoreContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmRestoreContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmRestoreContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmRestoreContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmRestoreContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmRestoreContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmRestoreContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class IaasVmRestoreWithRehydrationContent : Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmRestoreContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmRestoreWithRehydrationContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmRestoreWithRehydrationContent>
    {
        public IaasVmRestoreWithRehydrationContent() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointRehydrationInfo RecoveryPointRehydrationInfo { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmRestoreWithRehydrationContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmRestoreWithRehydrationContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmRestoreWithRehydrationContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmRestoreWithRehydrationContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmRestoreWithRehydrationContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmRestoreWithRehydrationContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmRestoreWithRehydrationContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IaasVmSnapshotConsistencyType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmSnapshotConsistencyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IaasVmSnapshotConsistencyType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmSnapshotConsistencyType OnlyCrashConsistent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmSnapshotConsistencyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmSnapshotConsistencyType left, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmSnapshotConsistencyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmSnapshotConsistencyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmSnapshotConsistencyType left, Azure.ResourceManager.RecoveryServicesBackup.Models.IaasVmSnapshotConsistencyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class IdentityBasedRestoreDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IdentityBasedRestoreDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IdentityBasedRestoreDetails>
    {
        public IdentityBasedRestoreDetails() { }
        public string ObjectType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetStorageAccountId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IdentityBasedRestoreDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IdentityBasedRestoreDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IdentityBasedRestoreDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IdentityBasedRestoreDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IdentityBasedRestoreDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IdentityBasedRestoreDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IdentityBasedRestoreDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class IlrContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IlrContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IlrContent>
    {
        protected IlrContent() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IlrContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IlrContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IlrContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.IlrContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IlrContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IlrContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.IlrContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InfrastructureEncryptionState : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.InfrastructureEncryptionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InfrastructureEncryptionState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.InfrastructureEncryptionState Disabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.InfrastructureEncryptionState Enabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.InfrastructureEncryptionState Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.InfrastructureEncryptionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.InfrastructureEncryptionState left, Azure.ResourceManager.RecoveryServicesBackup.Models.InfrastructureEncryptionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.InfrastructureEncryptionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.InfrastructureEncryptionState left, Azure.ResourceManager.RecoveryServicesBackup.Models.InfrastructureEncryptionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InquiryStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InquiryStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryStatus Success { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class InquiryValidation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryValidation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryValidation>
    {
        public InquiryValidation() { }
        public string AdditionalDetail { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupErrorDetail ErrorDetail { get { throw null; } set { } }
        public System.BinaryData ProtectableItemCount { get { throw null; } }
        public string Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryValidation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryValidation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryValidation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryValidation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryValidation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryValidation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryValidation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class InstantRPAdditionalDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.InstantRPAdditionalDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.InstantRPAdditionalDetails>
    {
        public InstantRPAdditionalDetails() { }
        public string AzureBackupRGNamePrefix { get { throw null; } set { } }
        public string AzureBackupRGNameSuffix { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.InstantRPAdditionalDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.InstantRPAdditionalDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.InstantRPAdditionalDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.InstantRPAdditionalDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.InstantRPAdditionalDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.InstantRPAdditionalDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.InstantRPAdditionalDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum JobSupportedAction
    {
        Invalid = 0,
        Cancellable = 1,
        Retriable = 2,
    }
    public partial class KekDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.KekDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.KekDetails>
    {
        public KekDetails() { }
        public string KeyBackupData { get { throw null; } set { } }
        public System.Uri KeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier KeyVaultId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.KekDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.KekDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.KekDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.KekDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.KekDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.KekDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.KekDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyAndSecretDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.KeyAndSecretDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.KeyAndSecretDetails>
    {
        public KeyAndSecretDetails() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BekDetails BekDetails { get { throw null; } set { } }
        public string EncryptionMechanism { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.KekDetails KekDetails { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.KeyAndSecretDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.KeyAndSecretDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.KeyAndSecretDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.KeyAndSecretDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.KeyAndSecretDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.KeyAndSecretDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.KeyAndSecretDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KpiResourceHealthDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails>
    {
        public KpiResourceHealthDetails() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthDetails> ResourceHealthDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthStatus? ResourceHealthStatus { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LastBackupStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LastBackupStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus IRPending { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus Unhealthy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct LastUpdateStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public LastUpdateStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus Failed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus FirstInitialization { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus Initialized { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus NotEnabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus PartiallyFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus PartiallySucceeded { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.LastUpdateStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class LogSchedulePolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupSchedulePolicy, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.LogSchedulePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.LogSchedulePolicy>
    {
        public LogSchedulePolicy() { }
        public int? ScheduleFrequencyInMins { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.LogSchedulePolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.LogSchedulePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.LogSchedulePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.LogSchedulePolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.LogSchedulePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.LogSchedulePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.LogSchedulePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LongTermRetentionPolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRetentionPolicy, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.LongTermRetentionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.LongTermRetentionPolicy>
    {
        public LongTermRetentionPolicy() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.DailyRetentionSchedule DailySchedule { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.MonthlyRetentionSchedule MonthlySchedule { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WeeklyRetentionSchedule WeeklySchedule { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.YearlyRetentionSchedule YearlySchedule { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.LongTermRetentionPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.LongTermRetentionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.LongTermRetentionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.LongTermRetentionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.LongTermRetentionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.LongTermRetentionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.LongTermRetentionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class LongTermSchedulePolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupSchedulePolicy, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.LongTermSchedulePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.LongTermSchedulePolicy>
    {
        public LongTermSchedulePolicy() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.LongTermSchedulePolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.LongTermSchedulePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.LongTermSchedulePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.LongTermSchedulePolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.LongTermSchedulePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.LongTermSchedulePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.LongTermSchedulePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MabBackupJob : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericJob, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJob>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJob>
    {
        public MabBackupJob() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.JobSupportedAction> ActionsInfo { get { throw null; } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.MabErrorInfo> ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJobExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public string MabServerName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType? MabServerType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType? WorkloadType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJob System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJob System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MabBackupJobExtendedInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJobExtendedInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJobExtendedInfo>
    {
        public MabBackupJobExtendedInfo() { }
        public string DynamicErrorMessage { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> PropertyBag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJobTaskDetails> TasksList { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJobExtendedInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJobExtendedInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJobExtendedInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJobExtendedInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJobExtendedInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJobExtendedInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJobExtendedInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MabBackupJobTaskDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJobTaskDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJobTaskDetails>
    {
        public MabBackupJobTaskDetails() { }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        public string Status { get { throw null; } set { } }
        public string TaskId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJobTaskDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJobTaskDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJobTaskDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJobTaskDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJobTaskDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJobTaskDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabBackupJobTaskDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MabContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionContainer, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainer>
    {
        public MabContainer() { }
        public string AgentVersion { get { throw null; } set { } }
        public bool? CanReRegister { get { throw null; } set { } }
        public string ContainerHealthState { get { throw null; } set { } }
        public long? ContainerId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainerExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainerHealthDetails> MabContainerHealthDetails { get { throw null; } }
        public long? ProtectedItemCount { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MabContainerExtendedInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainerExtendedInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainerExtendedInfo>
    {
        public MabContainerExtendedInfo() { }
        public System.Collections.Generic.IList<string> BackupItems { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupItemType? BackupItemType { get { throw null; } set { } }
        public string LastBackupStatus { get { throw null; } set { } }
        public System.DateTimeOffset? LastRefreshedOn { get { throw null; } set { } }
        public string PolicyName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainerExtendedInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainerExtendedInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainerExtendedInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainerExtendedInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainerExtendedInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainerExtendedInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainerExtendedInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MabContainerHealthDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainerHealthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainerHealthDetails>
    {
        public MabContainerHealthDetails() { }
        public int? Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Recommendations { get { throw null; } }
        public string Title { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainerHealthDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainerHealthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainerHealthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainerHealthDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainerHealthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainerHealthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabContainerHealthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MabErrorInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabErrorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabErrorInfo>
    {
        public MabErrorInfo() { }
        public string ErrorString { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Recommendations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.MabErrorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabErrorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabErrorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.MabErrorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabErrorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabErrorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabErrorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MabFileFolderProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectedItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabFileFolderProtectedItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabFileFolderProtectedItem>
    {
        public MabFileFolderProtectedItem() { }
        public string ComputerName { get { throw null; } set { } }
        public long? DeferredDeleteSyncTimeInUTC { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.MabFileFolderProtectedItemExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public System.DateTimeOffset? LastBackupOn { get { throw null; } set { } }
        public string LastBackupStatus { get { throw null; } set { } }
        public string ProtectionState { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.MabFileFolderProtectedItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabFileFolderProtectedItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabFileFolderProtectedItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.MabFileFolderProtectedItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabFileFolderProtectedItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabFileFolderProtectedItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabFileFolderProtectedItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MabFileFolderProtectedItemExtendedInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabFileFolderProtectedItemExtendedInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabFileFolderProtectedItemExtendedInfo>
    {
        public MabFileFolderProtectedItemExtendedInfo() { }
        public System.DateTimeOffset? LastRefreshedOn { get { throw null; } set { } }
        public System.DateTimeOffset? OldestRecoverOn { get { throw null; } set { } }
        public int? RecoveryPointCount { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.MabFileFolderProtectedItemExtendedInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabFileFolderProtectedItemExtendedInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabFileFolderProtectedItemExtendedInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.MabFileFolderProtectedItemExtendedInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabFileFolderProtectedItemExtendedInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabFileFolderProtectedItemExtendedInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabFileFolderProtectedItemExtendedInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MabProtectionPolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionPolicy, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabProtectionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabProtectionPolicy>
    {
        public MabProtectionPolicy() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupSchedulePolicy SchedulePolicy { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.MabProtectionPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabProtectionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabProtectionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.MabProtectionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabProtectionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabProtectionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MabProtectionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MabServerType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MabServerType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType AzureBackupServerContainer { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType AzureSqlContainer { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType Cluster { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType DpmContainer { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType GenericContainer { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType IaasVmContainer { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType IaasVmServiceContainer { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType MabContainer { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType SqlAvailabilityGroupWorkLoadContainer { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType StorageContainer { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType Unknown { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType VCenter { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType VmAppContainer { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType Windows { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType left, Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType left, Azure.ResourceManager.RecoveryServicesBackup.Models.MabServerType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MonthlyRetentionSchedule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MonthlyRetentionSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MonthlyRetentionSchedule>
    {
        public MonthlyRetentionSchedule() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDuration RetentionDuration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDay> RetentionScheduleDailyDaysOfTheMonth { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionScheduleFormat? RetentionScheduleFormatType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WeeklyRetentionFormat RetentionScheduleWeekly { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.DateTimeOffset> RetentionTimes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.MonthlyRetentionSchedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MonthlyRetentionSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MonthlyRetentionSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.MonthlyRetentionSchedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MonthlyRetentionSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MonthlyRetentionSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MonthlyRetentionSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MoveRPAcrossTiersContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MoveRPAcrossTiersContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MoveRPAcrossTiersContent>
    {
        public MoveRPAcrossTiersContent() { }
        public string ObjectType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType? SourceTierType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType? TargetTierType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.MoveRPAcrossTiersContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MoveRPAcrossTiersContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MoveRPAcrossTiersContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.MoveRPAcrossTiersContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MoveRPAcrossTiersContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MoveRPAcrossTiersContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.MoveRPAcrossTiersContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PointInTimeRange : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PointInTimeRange>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PointInTimeRange>
    {
        public PointInTimeRange() { }
        public System.DateTimeOffset? EndOn { get { throw null; } set { } }
        public System.DateTimeOffset? StartOn { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.PointInTimeRange System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PointInTimeRange>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PointInTimeRange>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.PointInTimeRange System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PointInTimeRange>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PointInTimeRange>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PointInTimeRange>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PreBackupValidation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PreBackupValidation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PreBackupValidation>
    {
        public PreBackupValidation() { }
        public string Code { get { throw null; } set { } }
        public string Message { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.PreBackupValidation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PreBackupValidation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PreBackupValidation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.PreBackupValidation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PreBackupValidation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PreBackupValidation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PreBackupValidation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PrepareDataMoveContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PrepareDataMoveContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PrepareDataMoveContent>
    {
        public PrepareDataMoveContent(Azure.Core.ResourceIdentifier targetResourceId, Azure.Core.AzureLocation targetRegion, Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel dataMoveLevel) { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel DataMoveLevel { get { throw null; } }
        public bool? IgnoreMoved { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> SourceContainerArmIds { get { throw null; } }
        public Azure.Core.AzureLocation TargetRegion { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.PrepareDataMoveContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PrepareDataMoveContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PrepareDataMoveContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.PrepareDataMoveContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PrepareDataMoveContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PrepareDataMoveContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PrepareDataMoveContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PreValidateEnableBackupContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupContent>
    {
        public PreValidateEnableBackupContent() { }
        public string Properties { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDataSourceType? ResourceType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VaultId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PreValidateEnableBackupResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupResult>
    {
        internal PreValidateEnableBackupResult() { }
        public string ContainerName { get { throw null; } }
        public string ErrorCode { get { throw null; } }
        public string ErrorMessage { get { throw null; } }
        public string ProtectedItemName { get { throw null; } }
        public string Recommendation { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupValidationStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.PreValidateEnableBackupResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateEndpointConnectionStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.PrivateEndpointConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateEndpointConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.PrivateEndpointConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.PrivateEndpointConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.PrivateEndpointConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.PrivateEndpointConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.PrivateEndpointConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.PrivateEndpointConnectionStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.PrivateEndpointConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.PrivateEndpointConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.PrivateEndpointConnectionStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.PrivateEndpointConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class ProtectableContainer : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainer>
    {
        protected ProtectableContainer() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupManagementType? BackupManagementType { get { throw null; } set { } }
        public string ContainerId { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public string HealthStatus { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProtectableContainerResource : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainerResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainerResource>
    {
        public ProtectableContainerResource(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainer Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainerResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainerResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainerResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainerResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainerResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainerResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainerResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProtectedItemState : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProtectedItemState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState BackupsSuspended { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState IRPending { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState Protected { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState ProtectionError { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState ProtectionPaused { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState ProtectionStopped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState left, Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState left, Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProvisionIlrConnectionContent : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ProvisionIlrConnectionContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ProvisionIlrConnectionContent>
    {
        public ProvisionIlrConnectionContent(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.IlrContent Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.ProvisionIlrConnectionContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ProvisionIlrConnectionContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ProvisionIlrConnectionContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.ProvisionIlrConnectionContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ProvisionIlrConnectionContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ProvisionIlrConnectionContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ProvisionIlrConnectionContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RecoveryMode : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RecoveryMode(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryMode FileRecovery { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryMode Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryMode RecoveryUsingSnapshot { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryMode SnapshotAttach { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryMode SnapshotAttachAndRecover { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryMode WorkloadRecovery { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryMode left, Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryMode left, Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RecoveryPointDiskConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointDiskConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointDiskConfiguration>
    {
        public RecoveryPointDiskConfiguration() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.DiskInformation> ExcludedDiskList { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.DiskInformation> IncludedDiskList { get { throw null; } }
        public int? NumberOfDisksAttachedToVm { get { throw null; } set { } }
        public int? NumberOfDisksIncludedInBackup { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointDiskConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointDiskConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointDiskConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointDiskConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointDiskConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointDiskConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointDiskConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryPointMoveReadinessInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointMoveReadinessInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointMoveReadinessInfo>
    {
        public RecoveryPointMoveReadinessInfo() { }
        public string AdditionalInfo { get { throw null; } set { } }
        public bool? IsReadyForMove { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointMoveReadinessInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointMoveReadinessInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointMoveReadinessInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointMoveReadinessInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointMoveReadinessInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointMoveReadinessInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointMoveReadinessInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryPointProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointProperties>
    {
        public RecoveryPointProperties() { }
        public System.DateTimeOffset? ExpireOn { get { throw null; } set { } }
        public bool? IsSoftDeleted { get { throw null; } set { } }
        public string RuleName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryPointRehydrationInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointRehydrationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointRehydrationInfo>
    {
        public RecoveryPointRehydrationInfo() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RehydrationPriority? RehydrationPriority { get { throw null; } set { } }
        public System.TimeSpan? RehydrationRetentionDuration { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointRehydrationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointRehydrationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointRehydrationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointRehydrationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointRehydrationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointRehydrationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointRehydrationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryPointsRecommendedForMoveContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointsRecommendedForMoveContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointsRecommendedForMoveContent>
    {
        public RecoveryPointsRecommendedForMoveContent() { }
        public System.Collections.Generic.IList<string> ExcludedRPList { get { throw null; } }
        public string ObjectType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointsRecommendedForMoveContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointsRecommendedForMoveContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointsRecommendedForMoveContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointsRecommendedForMoveContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointsRecommendedForMoveContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointsRecommendedForMoveContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointsRecommendedForMoveContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryPointTierInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierInformation>
    {
        public RecoveryPointTierInformation() { }
        public System.Collections.Generic.IDictionary<string, string> ExtendedInfo { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierStatus? Status { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierType? TierType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryPointTierInformationV2 : Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierInformation, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierInformationV2>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierInformationV2>
    {
        public RecoveryPointTierInformationV2() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierInformationV2 System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierInformationV2>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierInformationV2>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierInformationV2 System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierInformationV2>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierInformationV2>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierInformationV2>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public enum RecoveryPointTierStatus
    {
        Invalid = 0,
        Valid = 1,
        Disabled = 2,
        Deleted = 3,
        Rehydrated = 4,
    }
    public enum RecoveryPointTierType
    {
        Invalid = 0,
        InstantRP = 1,
        HardenedRP = 2,
        ArchivedRP = 3,
    }
    public partial class RecoveryServicesBackupPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryServicesBackupPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryServicesBackupPrivateLinkServiceConnectionState>
    {
        public RecoveryServicesBackupPrivateLinkServiceConnectionState() { }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public string ActionRequired { get { throw null; } set { } }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.PrivateEndpointConnectionStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryServicesBackupPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryServicesBackupPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryServicesBackupPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryServicesBackupPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryServicesBackupPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryServicesBackupPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryServicesBackupPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RecoveryServiceVaultProtectionIntent : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionIntent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryServiceVaultProtectionIntent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryServiceVaultProtectionIntent>
    {
        public RecoveryServiceVaultProtectionIntent() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryServiceVaultProtectionIntent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryServiceVaultProtectionIntent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryServiceVaultProtectionIntent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryServiceVaultProtectionIntent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryServiceVaultProtectionIntent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryServiceVaultProtectionIntent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryServiceVaultProtectionIntent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RehydrationPriority : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.RehydrationPriority>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RehydrationPriority(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RehydrationPriority High { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RehydrationPriority Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.RehydrationPriority other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.RehydrationPriority left, Azure.ResourceManager.RecoveryServicesBackup.Models.RehydrationPriority right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.RehydrationPriority (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.RehydrationPriority left, Azure.ResourceManager.RecoveryServicesBackup.Models.RehydrationPriority right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceGuardOperationDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceGuardOperationDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceGuardOperationDetail>
    {
        public ResourceGuardOperationDetail() { }
        public Azure.Core.ResourceIdentifier DefaultResourceId { get { throw null; } set { } }
        public string VaultCriticalOperation { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceGuardOperationDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceGuardOperationDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceGuardOperationDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceGuardOperationDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceGuardOperationDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceGuardOperationDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceGuardOperationDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceGuardProxyProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceGuardProxyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceGuardProxyProperties>
    {
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public ResourceGuardProxyProperties() { }
        public ResourceGuardProxyProperties(Azure.Core.ResourceIdentifier resourceGuardResourceId) { }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceGuardOperationDetail> ResourceGuardOperationDetails { get { throw null; } }
        public Azure.Core.ResourceIdentifier ResourceGuardResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceGuardProxyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceGuardProxyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceGuardProxyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceGuardProxyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceGuardProxyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceGuardProxyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceGuardProxyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ResourceHealthDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthDetails>
    {
        public ResourceHealthDetails() { }
        public int? Code { get { throw null; } }
        public string Message { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> Recommendations { get { throw null; } }
        public string Title { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ResourceHealthStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ResourceHealthStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthStatus PersistentDegraded { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthStatus PersistentUnhealthy { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthStatus TransientDegraded { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthStatus TransientUnhealthy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceHealthStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ResourceProtectionIntent : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionIntent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceProtectionIntent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceProtectionIntent>
    {
        public ResourceProtectionIntent() { }
        public string FriendlyName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceProtectionIntent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceProtectionIntent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceProtectionIntent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceProtectionIntent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceProtectionIntent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceProtectionIntent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.ResourceProtectionIntent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RestoreContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreContent>
    {
        protected RestoreContent() { }
        public System.Collections.Generic.IList<string> ResourceGuardOperationRequests { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RestoreFileSpecs : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreFileSpecs>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreFileSpecs>
    {
        public RestoreFileSpecs() { }
        public string FileSpecType { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        public string TargetFolderPath { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreFileSpecs System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreFileSpecs>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreFileSpecs>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreFileSpecs System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreFileSpecs>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreFileSpecs>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreFileSpecs>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RestoreOverwriteOption : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreOverwriteOption>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RestoreOverwriteOption(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreOverwriteOption FailOnConflict { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreOverwriteOption Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreOverwriteOption Overwrite { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreOverwriteOption other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreOverwriteOption left, Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreOverwriteOption right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreOverwriteOption (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreOverwriteOption left, Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreOverwriteOption right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RestorePointType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RestorePointType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType Differential { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType Full { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType Incremental { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType Log { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType SnapshotCopyOnlyFull { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType SnapshotFull { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType left, Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType left, Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class RetentionDuration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDuration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDuration>
    {
        public RetentionDuration() { }
        public int? Count { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDurationType? DurationType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDuration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDuration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDuration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDuration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDuration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDuration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDuration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RetentionDurationType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDurationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RetentionDurationType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDurationType Days { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDurationType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDurationType Months { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDurationType Weeks { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDurationType Years { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDurationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDurationType left, Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDurationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDurationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDurationType left, Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDurationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RetentionScheduleFormat : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionScheduleFormat>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RetentionScheduleFormat(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionScheduleFormat Daily { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionScheduleFormat Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionScheduleFormat Weekly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionScheduleFormat other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionScheduleFormat left, Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionScheduleFormat right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionScheduleFormat (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionScheduleFormat left, Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionScheduleFormat right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ScheduleRunType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.ScheduleRunType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ScheduleRunType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ScheduleRunType Daily { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ScheduleRunType Hourly { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ScheduleRunType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.ScheduleRunType Weekly { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.ScheduleRunType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.ScheduleRunType left, Azure.ResourceManager.RecoveryServicesBackup.Models.ScheduleRunType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.ScheduleRunType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.ScheduleRunType left, Azure.ResourceManager.RecoveryServicesBackup.Models.ScheduleRunType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SecurityPinContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SecurityPinContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SecurityPinContent>
    {
        public SecurityPinContent() { }
        public System.Collections.Generic.IList<string> ResourceGuardOperationRequests { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.SecurityPinContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SecurityPinContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SecurityPinContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.SecurityPinContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SecurityPinContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SecurityPinContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SecurityPinContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SimpleRetentionPolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRetentionPolicy, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SimpleRetentionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SimpleRetentionPolicy>
    {
        public SimpleRetentionPolicy() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDuration RetentionDuration { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.SimpleRetentionPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SimpleRetentionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SimpleRetentionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.SimpleRetentionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SimpleRetentionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SimpleRetentionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SimpleRetentionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SimpleSchedulePolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupSchedulePolicy, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SimpleSchedulePolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SimpleSchedulePolicy>
    {
        public SimpleSchedulePolicy() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupHourlySchedule HourlySchedule { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDayOfWeek> ScheduleRunDays { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ScheduleRunType? ScheduleRunFrequency { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.DateTimeOffset> ScheduleRunTimes { get { throw null; } }
        public int? ScheduleWeeklyFrequency { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.SimpleSchedulePolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SimpleSchedulePolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SimpleSchedulePolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.SimpleSchedulePolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SimpleSchedulePolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SimpleSchedulePolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SimpleSchedulePolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SimpleSchedulePolicyV2 : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupSchedulePolicy, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SimpleSchedulePolicyV2>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SimpleSchedulePolicyV2>
    {
        public SimpleSchedulePolicyV2() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupHourlySchedule HourlySchedule { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ScheduleRunType? ScheduleRunFrequency { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.DateTimeOffset> ScheduleRunTimes { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWeeklySchedule WeeklySchedule { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.SimpleSchedulePolicyV2 System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SimpleSchedulePolicyV2>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SimpleSchedulePolicyV2>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.SimpleSchedulePolicyV2 System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SimpleSchedulePolicyV2>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SimpleSchedulePolicyV2>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SimpleSchedulePolicyV2>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SnapshotBackupAdditionalDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SnapshotBackupAdditionalDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SnapshotBackupAdditionalDetails>
    {
        public SnapshotBackupAdditionalDetails() { }
        public string InstantRPDetails { get { throw null; } set { } }
        public int? InstantRpRetentionRangeInDays { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.UserAssignedManagedIdentityDetails UserAssignedManagedIdentityDetails { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.SnapshotBackupAdditionalDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SnapshotBackupAdditionalDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SnapshotBackupAdditionalDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.SnapshotBackupAdditionalDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SnapshotBackupAdditionalDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SnapshotBackupAdditionalDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SnapshotBackupAdditionalDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SnapshotRestoreContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SnapshotRestoreContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SnapshotRestoreContent>
    {
        public SnapshotRestoreContent() { }
        public string LogPointInTimeForDBRecovery { get { throw null; } set { } }
        public bool? SkipAttachAndMount { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.SnapshotRestoreContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SnapshotRestoreContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SnapshotRestoreContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.SnapshotRestoreContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SnapshotRestoreContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SnapshotRestoreContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SnapshotRestoreContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SoftDeleteFeatureState : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.SoftDeleteFeatureState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SoftDeleteFeatureState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SoftDeleteFeatureState AlwaysON { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SoftDeleteFeatureState Disabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SoftDeleteFeatureState Enabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SoftDeleteFeatureState Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.SoftDeleteFeatureState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.SoftDeleteFeatureState left, Azure.ResourceManager.RecoveryServicesBackup.Models.SoftDeleteFeatureState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.SoftDeleteFeatureState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.SoftDeleteFeatureState left, Azure.ResourceManager.RecoveryServicesBackup.Models.SoftDeleteFeatureState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlAvailabilityGroupWorkloadProtectionContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainer, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlAvailabilityGroupWorkloadProtectionContainer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlAvailabilityGroupWorkloadProtectionContainer>
    {
        public SqlAvailabilityGroupWorkloadProtectionContainer() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.SqlAvailabilityGroupWorkloadProtectionContainer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlAvailabilityGroupWorkloadProtectionContainer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlAvailabilityGroupWorkloadProtectionContainer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.SqlAvailabilityGroupWorkloadProtectionContainer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlAvailabilityGroupWorkloadProtectionContainer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlAvailabilityGroupWorkloadProtectionContainer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlAvailabilityGroupWorkloadProtectionContainer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionContainer, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlContainer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlContainer>
    {
        public SqlContainer() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.SqlContainer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlContainer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlContainer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.SqlContainer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlContainer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlContainer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlContainer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlDataDirectory : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectory>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectory>
    {
        public SqlDataDirectory() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryType? DirectoryType { get { throw null; } set { } }
        public string LogicalName { get { throw null; } set { } }
        public string Path { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectory System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectory>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectory>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectory System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectory>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectory>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectory>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlDataDirectoryMapping : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryMapping>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryMapping>
    {
        public SqlDataDirectoryMapping() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryType? MappingType { get { throw null; } set { } }
        public string SourceLogicalName { get { throw null; } set { } }
        public string SourcePath { get { throw null; } set { } }
        public string TargetPath { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryMapping System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryMapping>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryMapping>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryMapping System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryMapping>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryMapping>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryMapping>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SqlDataDirectoryType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SqlDataDirectoryType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryType Data { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryType Log { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryType left, Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryType left, Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SqlProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectedItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectedItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectedItem>
    {
        public SqlProtectedItem() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectedItemExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public string ProtectedItemDataId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectedItemState? ProtectionState { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectedItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectedItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectedItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectedItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectedItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectedItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectedItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlProtectedItemExtendedInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectedItemExtendedInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectedItemExtendedInfo>
    {
        public SqlProtectedItemExtendedInfo() { }
        public System.DateTimeOffset? OldestRecoverOn { get { throw null; } set { } }
        public string PolicyState { get { throw null; } set { } }
        public int? RecoveryPointCount { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectedItemExtendedInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectedItemExtendedInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectedItemExtendedInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectedItemExtendedInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectedItemExtendedInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectedItemExtendedInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectedItemExtendedInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SqlProtectionPolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionPolicy, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectionPolicy>
    {
        public SqlProtectionPolicy() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRetentionPolicy RetentionPolicy { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectionPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlProtectionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageBackupJob : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericJob, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJob>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJob>
    {
        public StorageBackupJob() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.JobSupportedAction> ActionsInfo { get { throw null; } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageErrorInfo> ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJobExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public bool? IsUserTriggered { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public string StorageAccountVersion { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJob System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJob System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageBackupJobExtendedInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJobExtendedInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJobExtendedInfo>
    {
        public StorageBackupJobExtendedInfo() { }
        public string DynamicErrorMessage { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> PropertyBag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJobTaskDetails> TasksList { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJobExtendedInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJobExtendedInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJobExtendedInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJobExtendedInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJobExtendedInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJobExtendedInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJobExtendedInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageBackupJobTaskDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJobTaskDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJobTaskDetails>
    {
        public StorageBackupJobTaskDetails() { }
        public string Status { get { throw null; } set { } }
        public string TaskId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJobTaskDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJobTaskDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJobTaskDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJobTaskDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJobTaskDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJobTaskDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageBackupJobTaskDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionContainer, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageContainer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageContainer>
    {
        public StorageContainer() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.AcquireStorageAccountLock? AcquireStorageAccountLock { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadOperationType? OperationType { get { throw null; } set { } }
        public long? ProtectedItemCount { get { throw null; } set { } }
        public string ResourceGroup { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
        public string StorageAccountVersion { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.StorageContainer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageContainer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageContainer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.StorageContainer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageContainer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageContainer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageContainer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageErrorInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageErrorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageErrorInfo>
    {
        public StorageErrorInfo() { }
        public int? ErrorCode { get { throw null; } set { } }
        public string ErrorString { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Recommendations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.StorageErrorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageErrorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageErrorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.StorageErrorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageErrorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageErrorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageErrorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageProtectableContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainer, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageProtectableContainer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageProtectableContainer>
    {
        public StorageProtectableContainer() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.StorageProtectableContainer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageProtectableContainer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageProtectableContainer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.StorageProtectableContainer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageProtectableContainer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageProtectableContainer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.StorageProtectableContainer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SubProtectionPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicy>
    {
        public SubProtectionPolicy() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType? PolicyType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRetentionPolicy RetentionPolicy { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupSchedulePolicy SchedulePolicy { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.SnapshotBackupAdditionalDetails SnapshotBackupAdditionalDetails { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.BackupTieringPolicy> TieringPolicy { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct SubProtectionPolicyType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public SubProtectionPolicyType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType CopyOnlyFull { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType Differential { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType Full { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType Incremental { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType Log { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType SnapshotCopyOnlyFull { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType SnapshotFull { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType left, Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType left, Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicyType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TargetAfsRestoreInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TargetAfsRestoreInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TargetAfsRestoreInfo>
    {
        public TargetAfsRestoreInfo() { }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.TargetAfsRestoreInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TargetAfsRestoreInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TargetAfsRestoreInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.TargetAfsRestoreInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TargetAfsRestoreInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TargetAfsRestoreInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TargetAfsRestoreInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TargetRestoreInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TargetRestoreInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TargetRestoreInfo>
    {
        public TargetRestoreInfo() { }
        public string ContainerId { get { throw null; } set { } }
        public string DatabaseName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreOverwriteOption? OverwriteOption { get { throw null; } set { } }
        public string TargetDirectoryForFileRestore { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.TargetRestoreInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TargetRestoreInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TargetRestoreInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.TargetRestoreInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TargetRestoreInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TargetRestoreInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TargetRestoreInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class TieringCostInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostInfo>
    {
        protected TieringCostInfo() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TieringCostRehydrationInfo : Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostRehydrationInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostRehydrationInfo>
    {
        internal TieringCostRehydrationInfo() { }
        public long RehydrationSizeInBytes { get { throw null; } }
        public double RetailRehydrationCostPerGBPerMonth { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostRehydrationInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostRehydrationInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostRehydrationInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostRehydrationInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostRehydrationInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostRehydrationInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostRehydrationInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TieringCostSavingInfo : Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostInfo, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostSavingInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostSavingInfo>
    {
        internal TieringCostSavingInfo() { }
        public double RetailSourceTierCostPerGBPerMonth { get { throw null; } }
        public double RetailTargetTierCostPerGBPerMonth { get { throw null; } }
        public long SourceTierSizeReductionInBytes { get { throw null; } }
        public long TargetTierSizeIncreaseInBytes { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostSavingInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostSavingInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostSavingInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostSavingInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostSavingInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostSavingInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringCostSavingInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct TieringMode : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.TieringMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public TieringMode(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.TieringMode DoNotTier { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.TieringMode Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.TieringMode TierAfter { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.TieringMode TierRecommended { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.TieringMode other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.TieringMode left, Azure.ResourceManager.RecoveryServicesBackup.Models.TieringMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.TieringMode (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.TieringMode left, Azure.ResourceManager.RecoveryServicesBackup.Models.TieringMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class TokenInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TokenInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TokenInformation>
    {
        internal TokenInformation() { }
        public long? ExpiryTimeInUtcTicks { get { throw null; } }
        public string SecurityPin { get { throw null; } }
        public string Token { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.TokenInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TokenInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TokenInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.TokenInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TokenInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TokenInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TokenInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TriggerBackupContent : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerBackupContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerBackupContent>
    {
        public TriggerBackupContent(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupContent Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerBackupContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerBackupContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerBackupContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerBackupContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerBackupContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerBackupContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerBackupContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TriggerDataMoveContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerDataMoveContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerDataMoveContent>
    {
        public TriggerDataMoveContent(Azure.Core.ResourceIdentifier sourceResourceId, Azure.Core.AzureLocation sourceRegion, Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel dataMoveLevel, string correlationId) { }
        public string CorrelationId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.DataMoveLevel DataMoveLevel { get { throw null; } }
        public bool? DoesPauseGC { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> SourceContainerArmIds { get { throw null; } }
        public Azure.Core.AzureLocation SourceRegion { get { throw null; } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerDataMoveContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerDataMoveContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerDataMoveContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerDataMoveContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerDataMoveContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerDataMoveContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerDataMoveContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TriggerRestoreContent : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerRestoreContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerRestoreContent>
    {
        public TriggerRestoreContent(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreContent Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerRestoreContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerRestoreContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerRestoreContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerRestoreContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerRestoreContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerRestoreContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.TriggerRestoreContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UnlockDeleteContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteContent>
    {
        public UnlockDeleteContent() { }
        public System.Collections.Generic.IList<string> ResourceGuardOperationRequests { get { throw null; } }
        public string ResourceToBeDeleted { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UnlockDeleteResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteResult>
    {
        internal UnlockDeleteResult() { }
        public System.DateTimeOffset? UnlockDeleteExpireOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.UnlockDeleteResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class UserAssignedManagedIdentityDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.UserAssignedManagedIdentityDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.UserAssignedManagedIdentityDetails>
    {
        public UserAssignedManagedIdentityDetails() { }
        public string IdentityArmId { get { throw null; } set { } }
        public string IdentityName { get { throw null; } set { } }
        public Azure.ResourceManager.Models.UserAssignedIdentity UserAssignedIdentityProperties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.UserAssignedManagedIdentityDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.UserAssignedManagedIdentityDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.UserAssignedManagedIdentityDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.UserAssignedManagedIdentityDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.UserAssignedManagedIdentityDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.UserAssignedManagedIdentityDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.UserAssignedManagedIdentityDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VaultBackupJob : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericJob, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultBackupJob>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultBackupJob>
    {
        public VaultBackupJob() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.JobSupportedAction> ActionsInfo { get { throw null; } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultBackupJobErrorInfo> ErrorDetails { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, string> ExtendedInfoPropertyBag { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VaultBackupJob System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultBackupJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultBackupJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VaultBackupJob System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultBackupJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultBackupJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultBackupJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VaultBackupJobErrorInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultBackupJobErrorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultBackupJobErrorInfo>
    {
        public VaultBackupJobErrorInfo() { }
        public int? ErrorCode { get { throw null; } set { } }
        public string ErrorString { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Recommendations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VaultBackupJobErrorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultBackupJobErrorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultBackupJobErrorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VaultBackupJobErrorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultBackupJobErrorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultBackupJobErrorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultBackupJobErrorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VaultDedupState : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultDedupState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VaultDedupState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VaultDedupState Disabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VaultDedupState Enabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VaultDedupState Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.VaultDedupState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.VaultDedupState left, Azure.ResourceManager.RecoveryServicesBackup.Models.VaultDedupState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.VaultDedupState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.VaultDedupState left, Azure.ResourceManager.RecoveryServicesBackup.Models.VaultDedupState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VaultRetentionPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultRetentionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultRetentionPolicy>
    {
        public VaultRetentionPolicy(Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRetentionPolicy vaultRetention, int snapshotRetentionInDays) { }
        public int SnapshotRetentionInDays { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupRetentionPolicy VaultRetention { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VaultRetentionPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultRetentionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultRetentionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VaultRetentionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultRetentionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultRetentionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultRetentionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VaultSubResourceType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultSubResourceType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VaultSubResourceType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VaultSubResourceType AzureBackup { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VaultSubResourceType AzureBackupSecondary { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VaultSubResourceType AzureSiteRecovery { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.VaultSubResourceType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.VaultSubResourceType left, Azure.ResourceManager.RecoveryServicesBackup.Models.VaultSubResourceType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.VaultSubResourceType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.VaultSubResourceType left, Azure.ResourceManager.RecoveryServicesBackup.Models.VaultSubResourceType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VaultXcoolState : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.VaultXcoolState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VaultXcoolState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VaultXcoolState Disabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VaultXcoolState Enabled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VaultXcoolState Invalid { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.VaultXcoolState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.VaultXcoolState left, Azure.ResourceManager.RecoveryServicesBackup.Models.VaultXcoolState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.VaultXcoolState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.VaultXcoolState left, Azure.ResourceManager.RecoveryServicesBackup.Models.VaultXcoolState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VmAppContainerProtectableContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.ProtectableContainer, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmAppContainerProtectableContainer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmAppContainerProtectableContainer>
    {
        public VmAppContainerProtectableContainer() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmAppContainerProtectableContainer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmAppContainerProtectableContainer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmAppContainerProtectableContainer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmAppContainerProtectableContainer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmAppContainerProtectableContainer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmAppContainerProtectableContainer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmAppContainerProtectableContainer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmAppContainerProtectionContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainer, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmAppContainerProtectionContainer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmAppContainerProtectionContainer>
    {
        public VmAppContainerProtectionContainer() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmAppContainerProtectionContainer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmAppContainerProtectionContainer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmAppContainerProtectionContainer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmAppContainerProtectionContainer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmAppContainerProtectionContainer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmAppContainerProtectionContainer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmAppContainerProtectionContainer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmEncryptionDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmEncryptionDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmEncryptionDetails>
    {
        public VmEncryptionDetails() { }
        public bool? IsEncryptionEnabled { get { throw null; } set { } }
        public System.Uri KekUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier KekVaultId { get { throw null; } set { } }
        public System.Uri SecretKeyUri { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SecretKeyVaultId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmEncryptionDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmEncryptionDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmEncryptionDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmEncryptionDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmEncryptionDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmEncryptionDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmEncryptionDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmResourceFeatureSupportContent : Azure.ResourceManager.RecoveryServicesBackup.Models.FeatureSupportContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportContent>
    {
        public VmResourceFeatureSupportContent() { }
        public string VmSize { get { throw null; } set { } }
        public string VmSku { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmResourceFeatureSupportResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportResult>
    {
        internal VmResourceFeatureSupportResult() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportStatus? SupportStatus { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmResourceFeatureSupportStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmResourceFeatureSupportStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportStatus DefaultOff { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportStatus DefaultOn { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportStatus NotSupported { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportStatus Supported { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.VmResourceFeatureSupportStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VmWorkloadItem : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadItem>
    {
        public VmWorkloadItem() { }
        public bool? IsAutoProtectable { get { throw null; } set { } }
        public string ParentName { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
        public int? SubInquiredItemCount { get { throw null; } set { } }
        public int? SubWorkloadItemCount { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmWorkloadProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectableItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectableItem>
    {
        public VmWorkloadProtectableItem() { }
        public bool? IsAutoProtectable { get { throw null; } set { } }
        public bool? IsAutoProtected { get { throw null; } set { } }
        public bool? IsProtectable { get { throw null; } set { } }
        public string ParentName { get { throw null; } set { } }
        public string ParentUniqueName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.PreBackupValidation PreBackupValidation { get { throw null; } set { } }
        public string ServerName { get { throw null; } set { } }
        public int? SubInquiredItemCount { get { throw null; } set { } }
        public int? SubProtectableItemCount { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectableItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectableItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectableItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectableItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectableItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectableItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectableItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmWorkloadProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectedItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItem>
    {
        public VmWorkloadProtectedItem() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.KpiResourceHealthDetails> KpisHealths { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupErrorDetail LastBackupErrorDetail { get { throw null; } set { } }
        public System.DateTimeOffset? LastBackupOn { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.LastBackupStatus? LastBackupStatus { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.DistributedNodesInfo> NodesList { get { throw null; } }
        public string ParentName { get { throw null; } set { } }
        public string ParentType { get { throw null; } set { } }
        public string ProtectedItemDataSourceId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus? ProtectedItemHealthStatus { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionState? ProtectionState { get { throw null; } set { } }
        public string ProtectionStatus { get { throw null; } }
        public string ServerName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmWorkloadProtectedItemExtendedInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemExtendedInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemExtendedInfo>
    {
        public VmWorkloadProtectedItemExtendedInfo() { }
        public System.DateTimeOffset? NewestRecoveryPointInArchive { get { throw null; } set { } }
        public System.DateTimeOffset? OldestRecoverOn { get { throw null; } set { } }
        public System.DateTimeOffset? OldestRecoveryPointInArchive { get { throw null; } set { } }
        public System.DateTimeOffset? OldestRecoveryPointInVault { get { throw null; } set { } }
        public string PolicyState { get { throw null; } set { } }
        public string RecoveryModel { get { throw null; } set { } }
        public int? RecoveryPointCount { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemExtendedInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemExtendedInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemExtendedInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemExtendedInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemExtendedInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemExtendedInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemExtendedInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmWorkloadProtectedItemHealthStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmWorkloadProtectedItemHealthStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus Healthy { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus IRPending { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus NotReachable { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus Unhealthy { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus left, Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItemHealthStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VmWorkloadProtectionPolicy : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionPolicy, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectionPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectionPolicy>
    {
        public VmWorkloadProtectionPolicy() { }
        public bool? DoesMakePolicyConsistent { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupCommonSettings Settings { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.SubProtectionPolicy> SubProtectionPolicy { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType? WorkLoadType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectionPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectionPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectionPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectionPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectionPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectionPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectionPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmWorkloadSapAseDatabaseProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectableItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseDatabaseProtectableItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseDatabaseProtectableItem>
    {
        public VmWorkloadSapAseDatabaseProtectableItem() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseDatabaseProtectableItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseDatabaseProtectableItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseDatabaseProtectableItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseDatabaseProtectableItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseDatabaseProtectableItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseDatabaseProtectableItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseDatabaseProtectableItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmWorkloadSapAseDatabaseProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseDatabaseProtectedItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseDatabaseProtectedItem>
    {
        public VmWorkloadSapAseDatabaseProtectedItem() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseDatabaseProtectedItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseDatabaseProtectedItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseDatabaseProtectedItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseDatabaseProtectedItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseDatabaseProtectedItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseDatabaseProtectedItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseDatabaseProtectedItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmWorkloadSapAseDatabaseWorkloadItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseDatabaseWorkloadItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseDatabaseWorkloadItem>
    {
        public VmWorkloadSapAseDatabaseWorkloadItem() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseDatabaseWorkloadItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseDatabaseWorkloadItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseDatabaseWorkloadItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseDatabaseWorkloadItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseDatabaseWorkloadItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseDatabaseWorkloadItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseDatabaseWorkloadItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmWorkloadSapAseSystemProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectableItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseSystemProtectableItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseSystemProtectableItem>
    {
        public VmWorkloadSapAseSystemProtectableItem() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseSystemProtectableItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseSystemProtectableItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseSystemProtectableItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseSystemProtectableItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseSystemProtectableItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseSystemProtectableItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseSystemProtectableItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmWorkloadSapAseSystemWorkloadItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseSystemWorkloadItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseSystemWorkloadItem>
    {
        public VmWorkloadSapAseSystemWorkloadItem() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseSystemWorkloadItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseSystemWorkloadItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseSystemWorkloadItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseSystemWorkloadItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseSystemWorkloadItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseSystemWorkloadItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapAseSystemWorkloadItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmWorkloadSapHanaDatabaseProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectableItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDatabaseProtectableItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDatabaseProtectableItem>
    {
        public VmWorkloadSapHanaDatabaseProtectableItem() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDatabaseProtectableItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDatabaseProtectableItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDatabaseProtectableItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDatabaseProtectableItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDatabaseProtectableItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDatabaseProtectableItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDatabaseProtectableItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmWorkloadSapHanaDatabaseProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDatabaseProtectedItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDatabaseProtectedItem>
    {
        public VmWorkloadSapHanaDatabaseProtectedItem() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDatabaseProtectedItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDatabaseProtectedItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDatabaseProtectedItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDatabaseProtectedItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDatabaseProtectedItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDatabaseProtectedItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDatabaseProtectedItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmWorkloadSapHanaDatabaseWorkloadItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDatabaseWorkloadItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDatabaseWorkloadItem>
    {
        public VmWorkloadSapHanaDatabaseWorkloadItem() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDatabaseWorkloadItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDatabaseWorkloadItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDatabaseWorkloadItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDatabaseWorkloadItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDatabaseWorkloadItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDatabaseWorkloadItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDatabaseWorkloadItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmWorkloadSapHanaDBInstance : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectableItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDBInstance>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDBInstance>
    {
        public VmWorkloadSapHanaDBInstance() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDBInstance System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDBInstance>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDBInstance>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDBInstance System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDBInstance>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDBInstance>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDBInstance>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmWorkloadSapHanaDBInstanceProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDBInstanceProtectedItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDBInstanceProtectedItem>
    {
        public VmWorkloadSapHanaDBInstanceProtectedItem() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDBInstanceProtectedItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDBInstanceProtectedItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDBInstanceProtectedItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDBInstanceProtectedItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDBInstanceProtectedItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDBInstanceProtectedItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaDBInstanceProtectedItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class VmWorkloadSapHanaHsr : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectableItem
    {
        public VmWorkloadSapHanaHsr() { }
    }
    public partial class VmWorkloadSapHanaHsrProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectableItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaHsrProtectableItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaHsrProtectableItem>
    {
        public VmWorkloadSapHanaHsrProtectableItem() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaHsrProtectableItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaHsrProtectableItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaHsrProtectableItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaHsrProtectableItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaHsrProtectableItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaHsrProtectableItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaHsrProtectableItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmWorkloadSapHanaSystemProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectableItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaSystemProtectableItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaSystemProtectableItem>
    {
        public VmWorkloadSapHanaSystemProtectableItem() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaSystemProtectableItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaSystemProtectableItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaSystemProtectableItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaSystemProtectableItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaSystemProtectableItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaSystemProtectableItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaSystemProtectableItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmWorkloadSapHanaSystemWorkloadItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaSystemWorkloadItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaSystemWorkloadItem>
    {
        public VmWorkloadSapHanaSystemWorkloadItem() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaSystemWorkloadItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaSystemWorkloadItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaSystemWorkloadItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaSystemWorkloadItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaSystemWorkloadItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaSystemWorkloadItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSapHanaSystemWorkloadItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmWorkloadSqlAvailabilityGroupProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectableItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlAvailabilityGroupProtectableItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlAvailabilityGroupProtectableItem>
    {
        public VmWorkloadSqlAvailabilityGroupProtectableItem() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.DistributedNodesInfo> NodesList { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlAvailabilityGroupProtectableItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlAvailabilityGroupProtectableItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlAvailabilityGroupProtectableItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlAvailabilityGroupProtectableItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlAvailabilityGroupProtectableItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlAvailabilityGroupProtectableItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlAvailabilityGroupProtectableItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmWorkloadSqlDatabaseProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectableItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlDatabaseProtectableItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlDatabaseProtectableItem>
    {
        public VmWorkloadSqlDatabaseProtectableItem() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlDatabaseProtectableItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlDatabaseProtectableItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlDatabaseProtectableItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlDatabaseProtectableItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlDatabaseProtectableItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlDatabaseProtectableItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlDatabaseProtectableItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmWorkloadSqlDatabaseProtectedItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectedItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlDatabaseProtectedItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlDatabaseProtectedItem>
    {
        public VmWorkloadSqlDatabaseProtectedItem() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlDatabaseProtectedItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlDatabaseProtectedItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlDatabaseProtectedItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlDatabaseProtectedItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlDatabaseProtectedItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlDatabaseProtectedItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlDatabaseProtectedItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmWorkloadSqlDatabaseWorkloadItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlDatabaseWorkloadItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlDatabaseWorkloadItem>
    {
        public VmWorkloadSqlDatabaseWorkloadItem() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlDatabaseWorkloadItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlDatabaseWorkloadItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlDatabaseWorkloadItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlDatabaseWorkloadItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlDatabaseWorkloadItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlDatabaseWorkloadItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlDatabaseWorkloadItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmWorkloadSqlInstanceProtectableItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadProtectableItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlInstanceProtectableItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlInstanceProtectableItem>
    {
        public VmWorkloadSqlInstanceProtectableItem() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlInstanceProtectableItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlInstanceProtectableItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlInstanceProtectableItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlInstanceProtectableItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlInstanceProtectableItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlInstanceProtectableItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlInstanceProtectableItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VmWorkloadSqlInstanceWorkloadItem : Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadItem, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlInstanceWorkloadItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlInstanceWorkloadItem>
    {
        public VmWorkloadSqlInstanceWorkloadItem() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectory> DataDirectoryPaths { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlInstanceWorkloadItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlInstanceWorkloadItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlInstanceWorkloadItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlInstanceWorkloadItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlInstanceWorkloadItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlInstanceWorkloadItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.VmWorkloadSqlInstanceWorkloadItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WeeklyRetentionFormat : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WeeklyRetentionFormat>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WeeklyRetentionFormat>
    {
        public WeeklyRetentionFormat() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDayOfWeek> DaysOfTheWeek { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWeekOfMonth> WeeksOfTheMonth { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WeeklyRetentionFormat System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WeeklyRetentionFormat>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WeeklyRetentionFormat>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WeeklyRetentionFormat System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WeeklyRetentionFormat>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WeeklyRetentionFormat>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WeeklyRetentionFormat>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WeeklyRetentionSchedule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WeeklyRetentionSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WeeklyRetentionSchedule>
    {
        public WeeklyRetentionSchedule() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDayOfWeek> DaysOfTheWeek { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDuration RetentionDuration { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.DateTimeOffset> RetentionTimes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WeeklyRetentionSchedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WeeklyRetentionSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WeeklyRetentionSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WeeklyRetentionSchedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WeeklyRetentionSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WeeklyRetentionSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WeeklyRetentionSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadAutoProtectionIntent : Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryServiceVaultProtectionIntent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadAutoProtectionIntent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadAutoProtectionIntent>
    {
        public WorkloadAutoProtectionIntent() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadAutoProtectionIntent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadAutoProtectionIntent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadAutoProtectionIntent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadAutoProtectionIntent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadAutoProtectionIntent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadAutoProtectionIntent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadAutoProtectionIntent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadBackupContent : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupContent>
    {
        public WorkloadBackupContent() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupType? BackupType { get { throw null; } set { } }
        public bool? EnableCompression { get { throw null; } set { } }
        public System.DateTimeOffset? RecoveryPointExpireOn { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadBackupJob : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericJob, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJob>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJob>
    {
        public WorkloadBackupJob() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.JobSupportedAction> ActionsInfo { get { throw null; } }
        public System.TimeSpan? Duration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadErrorInfo> ErrorDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJobExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public string WorkloadType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJob System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJob>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJob>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJob System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJob>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJob>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJob>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadBackupJobExtendedInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJobExtendedInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJobExtendedInfo>
    {
        public WorkloadBackupJobExtendedInfo() { }
        public string DynamicErrorMessage { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> PropertyBag { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJobTaskDetails> TasksList { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJobExtendedInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJobExtendedInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJobExtendedInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJobExtendedInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJobExtendedInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJobExtendedInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJobExtendedInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadBackupJobTaskDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJobTaskDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJobTaskDetails>
    {
        public WorkloadBackupJobTaskDetails() { }
        public string Status { get { throw null; } set { } }
        public string TaskId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJobTaskDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJobTaskDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJobTaskDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJobTaskDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJobTaskDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJobTaskDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadBackupJobTaskDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadContainer : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionContainer, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainer>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainer>
    {
        public WorkloadContainer() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerExtendedInfo ExtendedInfo { get { throw null; } set { } }
        public System.DateTimeOffset? LastUpdatedOn { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadOperationType? OperationType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupWorkloadType? WorkloadType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainer System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainer>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainer>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainer System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainer>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainer>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainer>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadContainerAutoProtectionIntent : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericProtectionIntent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerAutoProtectionIntent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerAutoProtectionIntent>
    {
        public WorkloadContainerAutoProtectionIntent() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerAutoProtectionIntent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerAutoProtectionIntent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerAutoProtectionIntent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerAutoProtectionIntent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerAutoProtectionIntent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerAutoProtectionIntent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerAutoProtectionIntent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadContainerExtendedInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerExtendedInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerExtendedInfo>
    {
        public WorkloadContainerExtendedInfo() { }
        public string HostServerName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerInquiryInfo InquiryInfo { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.DistributedNodesInfo> NodesList { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerExtendedInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerExtendedInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerExtendedInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerExtendedInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerExtendedInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerExtendedInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerExtendedInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadContainerInquiryInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerInquiryInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerInquiryInfo>
    {
        public WorkloadContainerInquiryInfo() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupErrorDetail ErrorDetail { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadInquiryDetails> InquiryDetails { get { throw null; } }
        public string Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerInquiryInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerInquiryInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerInquiryInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerInquiryInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerInquiryInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerInquiryInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadContainerInquiryInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadErrorInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadErrorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadErrorInfo>
    {
        public WorkloadErrorInfo() { }
        public string AdditionalDetails { get { throw null; } set { } }
        public int? ErrorCode { get { throw null; } set { } }
        public string ErrorString { get { throw null; } set { } }
        public string ErrorTitle { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> Recommendations { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadErrorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadErrorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadErrorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadErrorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadErrorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadErrorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadErrorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadInquiryDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadInquiryDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadInquiryDetails>
    {
        public WorkloadInquiryDetails() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.InquiryValidation InquiryValidation { get { throw null; } set { } }
        public long? ItemCount { get { throw null; } set { } }
        public string WorkloadInquiryDetailsType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadInquiryDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadInquiryDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadInquiryDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadInquiryDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadInquiryDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadInquiryDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadInquiryDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class WorkloadItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItem>
    {
        protected WorkloadItem() { }
        public string BackupManagementType { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus? ProtectionState { get { throw null; } set { } }
        public string WorkloadType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadItemResource : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemResource>
    {
        public WorkloadItemResource(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItem Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadItemType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadItemType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType SapAseDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType SapAseSystem { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType SapHanaDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType SapHanaDBInstance { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType SapHanaSystem { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType SqlDatabase { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType SqlInstance { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType left, Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType left, Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkloadOperationType : System.IEquatable<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadOperationType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkloadOperationType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadOperationType Invalid { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadOperationType Register { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadOperationType Rehydrate { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadOperationType Reregister { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadOperationType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadOperationType left, Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadOperationType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadOperationType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadOperationType left, Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadOperationType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkloadPointInTimeRecoveryPoint : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRecoveryPoint, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadPointInTimeRecoveryPoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadPointInTimeRecoveryPoint>
    {
        public WorkloadPointInTimeRecoveryPoint() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.PointInTimeRange> TimeRanges { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadPointInTimeRecoveryPoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadPointInTimeRecoveryPoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadPointInTimeRecoveryPoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadPointInTimeRecoveryPoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadPointInTimeRecoveryPoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadPointInTimeRecoveryPoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadPointInTimeRecoveryPoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadPointInTimeRestoreContent : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRestoreContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadPointInTimeRestoreContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadPointInTimeRestoreContent>
    {
        public WorkloadPointInTimeRestoreContent() { }
        public System.DateTimeOffset? PointInTime { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadPointInTimeRestoreContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadPointInTimeRestoreContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadPointInTimeRestoreContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadPointInTimeRestoreContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadPointInTimeRestoreContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadPointInTimeRestoreContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadPointInTimeRestoreContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class WorkloadProtectableItem : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItem>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItem>
    {
        protected WorkloadProtectableItem() { }
        public string BackupManagementType { get { throw null; } set { } }
        public string FriendlyName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.BackupProtectionStatus? ProtectionState { get { throw null; } set { } }
        public string WorkloadType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItem System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItem>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItem>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItem System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItem>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItem>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItem>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadProtectableItemResource : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItemResource>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItemResource>
    {
        public WorkloadProtectableItemResource(Azure.Core.AzureLocation location) { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItem Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItemResource System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItemResource>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItemResource>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItemResource System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItemResource>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItemResource>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadProtectableItemResource>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadRecoveryPoint : Azure.ResourceManager.RecoveryServicesBackup.Models.BackupGenericRecoveryPoint, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRecoveryPoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRecoveryPoint>
    {
        public WorkloadRecoveryPoint() { }
        public System.DateTimeOffset? RecoveryPointCreatedOn { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointMoveReadinessInfo> RecoveryPointMoveReadinessInfo { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointProperties RecoveryPointProperties { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointTierInformationV2> RecoveryPointTierDetails { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RestorePointType? RestorePointType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRecoveryPoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRecoveryPoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRecoveryPoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRecoveryPoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRecoveryPoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRecoveryPoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRecoveryPoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadRestoreContent : Azure.ResourceManager.RecoveryServicesBackup.Models.RestoreContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRestoreContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRestoreContent>
    {
        public WorkloadRestoreContent() { }
        public System.Collections.Generic.IDictionary<string, string> PropertyBag { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryMode? RecoveryMode { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.FileShareRecoveryType? RecoveryType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.SnapshotRestoreContent SnapshotRestoreParameters { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier SourceResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.TargetRestoreInfo TargetInfo { get { throw null; } set { } }
        public string TargetResourceGroupName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetVirtualMachineId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.UserAssignedManagedIdentityDetails UserAssignedManagedIdentityDetails { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRestoreContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRestoreContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRestoreContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRestoreContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRestoreContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRestoreContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRestoreContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadSapAsePointInTimeRecoveryPoint : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadPointInTimeRecoveryPoint, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAsePointInTimeRecoveryPoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAsePointInTimeRecoveryPoint>
    {
        public WorkloadSapAsePointInTimeRecoveryPoint() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAsePointInTimeRecoveryPoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAsePointInTimeRecoveryPoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAsePointInTimeRecoveryPoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAsePointInTimeRecoveryPoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAsePointInTimeRecoveryPoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAsePointInTimeRecoveryPoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAsePointInTimeRecoveryPoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadSapAsePointInTimeRestoreContent : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAseRestoreContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAsePointInTimeRestoreContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAsePointInTimeRestoreContent>
    {
        public WorkloadSapAsePointInTimeRestoreContent() { }
        public System.DateTimeOffset? PointInTime { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAsePointInTimeRestoreContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAsePointInTimeRestoreContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAsePointInTimeRestoreContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAsePointInTimeRestoreContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAsePointInTimeRestoreContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAsePointInTimeRestoreContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAsePointInTimeRestoreContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadSapAseRecoveryPoint : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRecoveryPoint, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAseRecoveryPoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAseRecoveryPoint>
    {
        public WorkloadSapAseRecoveryPoint() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAseRecoveryPoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAseRecoveryPoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAseRecoveryPoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAseRecoveryPoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAseRecoveryPoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAseRecoveryPoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAseRecoveryPoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadSapAseRestoreContent : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRestoreContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAseRestoreContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAseRestoreContent>
    {
        public WorkloadSapAseRestoreContent() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAseRestoreContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAseRestoreContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAseRestoreContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAseRestoreContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAseRestoreContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAseRestoreContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapAseRestoreContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadSapHanaPointInTimeRecoveryPoint : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadPointInTimeRecoveryPoint, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaPointInTimeRecoveryPoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaPointInTimeRecoveryPoint>
    {
        public WorkloadSapHanaPointInTimeRecoveryPoint() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaPointInTimeRecoveryPoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaPointInTimeRecoveryPoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaPointInTimeRecoveryPoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaPointInTimeRecoveryPoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaPointInTimeRecoveryPoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaPointInTimeRecoveryPoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaPointInTimeRecoveryPoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadSapHanaPointInTimeRestoreContent : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRestoreContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaPointInTimeRestoreContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaPointInTimeRestoreContent>
    {
        public WorkloadSapHanaPointInTimeRestoreContent() { }
        public System.DateTimeOffset? PointInTime { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaPointInTimeRestoreContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaPointInTimeRestoreContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaPointInTimeRestoreContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaPointInTimeRestoreContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaPointInTimeRestoreContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaPointInTimeRestoreContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaPointInTimeRestoreContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadSapHanaPointInTimeRestoreWithRehydrateContent : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaPointInTimeRestoreContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaPointInTimeRestoreWithRehydrateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaPointInTimeRestoreWithRehydrateContent>
    {
        public WorkloadSapHanaPointInTimeRestoreWithRehydrateContent() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointRehydrationInfo RecoveryPointRehydrationInfo { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaPointInTimeRestoreWithRehydrateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaPointInTimeRestoreWithRehydrateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaPointInTimeRestoreWithRehydrateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaPointInTimeRestoreWithRehydrateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaPointInTimeRestoreWithRehydrateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaPointInTimeRestoreWithRehydrateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaPointInTimeRestoreWithRehydrateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadSapHanaRecoveryPoint : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRecoveryPoint, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRecoveryPoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRecoveryPoint>
    {
        public WorkloadSapHanaRecoveryPoint() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRecoveryPoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRecoveryPoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRecoveryPoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRecoveryPoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRecoveryPoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRecoveryPoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRecoveryPoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadSapHanaRestoreContent : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRestoreContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRestoreContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRestoreContent>
    {
        public WorkloadSapHanaRestoreContent() { }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRestoreContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRestoreContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRestoreContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRestoreContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRestoreContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRestoreContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRestoreContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadSapHanaRestoreWithRehydrateContent : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRestoreContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRestoreWithRehydrateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRestoreWithRehydrateContent>
    {
        public WorkloadSapHanaRestoreWithRehydrateContent() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointRehydrationInfo RecoveryPointRehydrationInfo { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRestoreWithRehydrateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRestoreWithRehydrateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRestoreWithRehydrateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRestoreWithRehydrateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRestoreWithRehydrateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRestoreWithRehydrateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSapHanaRestoreWithRehydrateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadSqlAutoProtectionIntent : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadAutoProtectionIntent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlAutoProtectionIntent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlAutoProtectionIntent>
    {
        public WorkloadSqlAutoProtectionIntent() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadItemType? WorkloadItemType { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlAutoProtectionIntent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlAutoProtectionIntent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlAutoProtectionIntent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlAutoProtectionIntent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlAutoProtectionIntent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlAutoProtectionIntent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlAutoProtectionIntent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadSqlPointInTimeRecoveryPoint : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRecoveryPoint, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlPointInTimeRecoveryPoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlPointInTimeRecoveryPoint>
    {
        public WorkloadSqlPointInTimeRecoveryPoint() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.PointInTimeRange> TimeRanges { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlPointInTimeRecoveryPoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlPointInTimeRecoveryPoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlPointInTimeRecoveryPoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlPointInTimeRecoveryPoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlPointInTimeRecoveryPoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlPointInTimeRecoveryPoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlPointInTimeRecoveryPoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadSqlPointInTimeRestoreContent : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRestoreContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlPointInTimeRestoreContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlPointInTimeRestoreContent>
    {
        public WorkloadSqlPointInTimeRestoreContent() { }
        public System.DateTimeOffset? PointInTime { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlPointInTimeRestoreContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlPointInTimeRestoreContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlPointInTimeRestoreContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlPointInTimeRestoreContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlPointInTimeRestoreContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlPointInTimeRestoreContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlPointInTimeRestoreContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadSqlPointInTimeRestoreWithRehydrateContent : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlPointInTimeRestoreContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlPointInTimeRestoreWithRehydrateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlPointInTimeRestoreWithRehydrateContent>
    {
        public WorkloadSqlPointInTimeRestoreWithRehydrateContent() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointRehydrationInfo RecoveryPointRehydrationInfo { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlPointInTimeRestoreWithRehydrateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlPointInTimeRestoreWithRehydrateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlPointInTimeRestoreWithRehydrateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlPointInTimeRestoreWithRehydrateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlPointInTimeRestoreWithRehydrateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlPointInTimeRestoreWithRehydrateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlPointInTimeRestoreWithRehydrateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadSqlRecoveryPoint : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRecoveryPoint, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRecoveryPoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRecoveryPoint>
    {
        public WorkloadSqlRecoveryPoint() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRecoveryPointExtendedInfo ExtendedInfo { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRecoveryPoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRecoveryPoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRecoveryPoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRecoveryPoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRecoveryPoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRecoveryPoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRecoveryPoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadSqlRecoveryPointExtendedInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRecoveryPointExtendedInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRecoveryPointExtendedInfo>
    {
        public WorkloadSqlRecoveryPointExtendedInfo() { }
        public System.DateTimeOffset? DataDirectoryInfoCapturedOn { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectory> DataDirectoryPaths { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRecoveryPointExtendedInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRecoveryPointExtendedInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRecoveryPointExtendedInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRecoveryPointExtendedInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRecoveryPointExtendedInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRecoveryPointExtendedInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRecoveryPointExtendedInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadSqlRestoreContent : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadRestoreContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRestoreContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRestoreContent>
    {
        public WorkloadSqlRestoreContent() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.SqlDataDirectoryMapping> AlternateDirectoryPaths { get { throw null; } }
        public bool? IsNonRecoverable { get { throw null; } set { } }
        public bool? ShouldUseAlternateTargetLocation { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRestoreContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRestoreContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRestoreContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRestoreContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRestoreContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRestoreContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRestoreContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkloadSqlRestoreWithRehydrateContent : Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRestoreContent, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRestoreWithRehydrateContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRestoreWithRehydrateContent>
    {
        public WorkloadSqlRestoreWithRehydrateContent() { }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RecoveryPointRehydrationInfo RecoveryPointRehydrationInfo { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRestoreWithRehydrateContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRestoreWithRehydrateContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRestoreWithRehydrateContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRestoreWithRehydrateContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRestoreWithRehydrateContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRestoreWithRehydrateContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.WorkloadSqlRestoreWithRehydrateContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class YearlyRetentionSchedule : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.YearlyRetentionSchedule>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.YearlyRetentionSchedule>
    {
        public YearlyRetentionSchedule() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupMonthOfYear> MonthsOfYear { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionDuration RetentionDuration { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesBackup.Models.BackupDay> RetentionScheduleDailyDaysOfTheMonth { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.RetentionScheduleFormat? RetentionScheduleFormatType { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesBackup.Models.WeeklyRetentionFormat RetentionScheduleWeekly { get { throw null; } set { } }
        public System.Collections.Generic.IList<System.DateTimeOffset> RetentionTimes { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.YearlyRetentionSchedule System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.YearlyRetentionSchedule>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesBackup.Models.YearlyRetentionSchedule>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesBackup.Models.YearlyRetentionSchedule System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.YearlyRetentionSchedule>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.YearlyRetentionSchedule>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesBackup.Models.YearlyRetentionSchedule>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
