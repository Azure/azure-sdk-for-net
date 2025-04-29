namespace Azure.ResourceManager.RecoveryServicesDataReplication
{
    public partial class AzureResourceManagerRecoveryServicesDataReplicationContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerRecoveryServicesDataReplicationContext() { }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.AzureResourceManagerRecoveryServicesDataReplicationContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DataReplicationEmailConfigurationCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationResource>, System.Collections.IEnumerable
    {
        protected DataReplicationEmailConfigurationCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string emailConfigurationName, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string emailConfigurationName, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string emailConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string emailConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationResource> Get(string emailConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationResource>> GetAsync(string emailConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationResource> GetIfExists(string emailConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationResource>> GetIfExistsAsync(string emailConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataReplicationEmailConfigurationData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData>
    {
        public DataReplicationEmailConfigurationData() { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEmailConfigurationProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationEmailConfigurationResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataReplicationEmailConfigurationResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string emailConfigurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataReplicationEventCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventResource>, System.Collections.IEnumerable
    {
        protected DataReplicationEventCollection() { }
        public virtual Azure.Response<bool> Exists(string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventResource> Get(string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventResource> GetAll(string odataOptions = null, string continuationToken = null, int? pageSize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventResource> GetAllAsync(string odataOptions = null, string continuationToken = null, int? pageSize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventResource>> GetAsync(string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventResource> GetIfExists(string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventResource>> GetIfExistsAsync(string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataReplicationEventData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventData>
    {
        internal DataReplicationEventData() { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationEventResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataReplicationEventResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string eventName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationExtensionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionResource>, System.Collections.IEnumerable
    {
        protected DataReplicationExtensionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string replicationExtensionName, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string replicationExtensionName, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string replicationExtensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string replicationExtensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionResource> Get(string replicationExtensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionResource>> GetAsync(string replicationExtensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionResource> GetIfExists(string replicationExtensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionResource>> GetIfExistsAsync(string replicationExtensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataReplicationExtensionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionData>
    {
        public DataReplicationExtensionData() { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationExtensionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationExtensionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataReplicationExtensionResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string replicationExtensionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataReplicationFabricAgentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentResource>, System.Collections.IEnumerable
    {
        protected DataReplicationFabricAgentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fabricAgentName, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fabricAgentName, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fabricAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fabricAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentResource> Get(string fabricAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentResource>> GetAsync(string fabricAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentResource> GetIfExists(string fabricAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentResource>> GetIfExistsAsync(string fabricAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataReplicationFabricAgentData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentData>
    {
        public DataReplicationFabricAgentData() { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricAgentProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationFabricAgentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataReplicationFabricAgentResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fabricName, string fabricAgentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataReplicationFabricCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource>, System.Collections.IEnumerable
    {
        protected DataReplicationFabricCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fabricName, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fabricName, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource> Get(string fabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource> GetAll(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource> GetAllAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource>> GetAsync(string fabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource> GetIfExists(string fabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource>> GetIfExistsAsync(string fabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataReplicationFabricData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricData>
    {
        public DataReplicationFabricData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationFabricResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataReplicationFabricResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fabricName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentResource> GetDataReplicationFabricAgent(string fabricAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentResource>> GetDataReplicationFabricAgentAsync(string fabricAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentCollection GetDataReplicationFabricAgents() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataReplicationJobCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobResource>, System.Collections.IEnumerable
    {
        protected DataReplicationJobCollection() { }
        public virtual Azure.Response<bool> Exists(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobResource> Get(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobResource> GetAll(string odataOptions = null, string continuationToken = null, int? pageSize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobResource> GetAllAsync(string odataOptions = null, string continuationToken = null, int? pageSize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobResource>> GetAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobResource> GetIfExists(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobResource>> GetIfExistsAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataReplicationJobData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobData>
    {
        internal DataReplicationJobData() { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationJobResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataReplicationJobResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string jobName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationPolicyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyResource>, System.Collections.IEnumerable
    {
        protected DataReplicationPolicyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string policyName, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string policyName, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyResource> Get(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyResource>> GetAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyResource> GetIfExists(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyResource>> GetIfExistsAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataReplicationPolicyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData>
    {
        public DataReplicationPolicyData() { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationPolicyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataReplicationPolicyResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string policyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataReplicationPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected DataReplicationPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataReplicationPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionData>
    {
        public DataReplicationPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationPrivateEndpointConnectionProxyCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyResource>, System.Collections.IEnumerable
    {
        protected DataReplicationPrivateEndpointConnectionProxyCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionProxyName, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionProxyName, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyResource> Get(string privateEndpointConnectionProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyResource>> GetAsync(string privateEndpointConnectionProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyResource> GetIfExists(string privateEndpointConnectionProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyResource>> GetIfExistsAsync(string privateEndpointConnectionProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataReplicationPrivateEndpointConnectionProxyData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyData>
    {
        public DataReplicationPrivateEndpointConnectionProxyData() { }
        public Azure.ETag? ETag { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionProxyProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationPrivateEndpointConnectionProxyResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataReplicationPrivateEndpointConnectionProxyResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string privateEndpointConnectionProxyName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyResource> Validate(Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyResource>> ValidateAsync(Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataReplicationPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataReplicationPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataReplicationPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataReplicationPrivateLinkResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected DataReplicationPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResource> GetIfExists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResource>> GetIfExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataReplicationPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResourceData>
    {
        internal DataReplicationPrivateLinkResourceData() { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkResourceProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationProtectedItemCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource>, System.Collections.IEnumerable
    {
        protected DataReplicationProtectedItemCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string protectedItemName, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string protectedItemName, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string protectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string protectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource> Get(string protectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource> GetAll(string odataOptions = null, string continuationToken = null, int? pageSize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource> GetAllAsync(string odataOptions = null, string continuationToken = null, int? pageSize = default(int?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource>> GetAsync(string protectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource> GetIfExists(string protectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource>> GetIfExistsAsync(string protectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataReplicationProtectedItemData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData>
    {
        public DataReplicationProtectedItemData() { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationProtectedItemResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataReplicationProtectedItemResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string protectedItemName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? forceDelete = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? forceDelete = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointResource> GetDataReplicationRecoveryPoint(string recoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointResource>> GetDataReplicationRecoveryPointAsync(string recoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointCollection GetDataReplicationRecoveryPoints() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailover> PlannedFailover(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailover body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailover>> PlannedFailoverAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailover body, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataReplicationRecoveryPointCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointResource>, System.Collections.IEnumerable
    {
        protected DataReplicationRecoveryPointCollection() { }
        public virtual Azure.Response<bool> Exists(string recoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string recoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointResource> Get(string recoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointResource>> GetAsync(string recoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointResource> GetIfExists(string recoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointResource>> GetIfExistsAsync(string recoveryPointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataReplicationRecoveryPointData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointData>
    {
        internal DataReplicationRecoveryPointData() { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointProperties Properties { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationRecoveryPointResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataReplicationRecoveryPointResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string protectedItemName, string recoveryPointName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationVaultCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource>, System.Collections.IEnumerable
    {
        protected DataReplicationVaultCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string vaultName, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource> Get(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource> GetAll(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource> GetAllAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource>> GetAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource> GetIfExists(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource>> GetIfExistsAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataReplicationVaultData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultData>
    {
        public DataReplicationVaultData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultProperties Properties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationVaultResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataReplicationVaultResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationResource> GetDataReplicationEmailConfiguration(string emailConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationResource>> GetDataReplicationEmailConfigurationAsync(string emailConfigurationName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationCollection GetDataReplicationEmailConfigurations() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventResource> GetDataReplicationEvent(string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventResource>> GetDataReplicationEventAsync(string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventCollection GetDataReplicationEvents() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionResource> GetDataReplicationExtension(string replicationExtensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionResource>> GetDataReplicationExtensionAsync(string replicationExtensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionCollection GetDataReplicationExtensions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobResource> GetDataReplicationJob(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobResource>> GetDataReplicationJobAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobCollection GetDataReplicationJobs() { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyCollection GetDataReplicationPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyResource> GetDataReplicationPolicy(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyResource>> GetDataReplicationPolicyAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionResource> GetDataReplicationPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionResource>> GetDataReplicationPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyCollection GetDataReplicationPrivateEndpointConnectionProxies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyResource> GetDataReplicationPrivateEndpointConnectionProxy(string privateEndpointConnectionProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyResource>> GetDataReplicationPrivateEndpointConnectionProxyAsync(string privateEndpointConnectionProxyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionCollection GetDataReplicationPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResource> GetDataReplicationPrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResource>> GetDataReplicationPrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResourceCollection GetDataReplicationPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource> GetDataReplicationProtectedItem(string protectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource>> GetDataReplicationProtectedItemAsync(string protectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemCollection GetDataReplicationProtectedItems() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class RecoveryServicesDataReplicationExtensions
    {
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationResource GetDataReplicationEmailConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventResource GetDataReplicationEventResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionResource GetDataReplicationExtensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource> GetDataReplicationFabric(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentResource GetDataReplicationFabricAgentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource>> GetDataReplicationFabricAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource GetDataReplicationFabricResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricCollection GetDataReplicationFabrics(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource> GetDataReplicationFabrics(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource> GetDataReplicationFabricsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobResource GetDataReplicationJobResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyResource GetDataReplicationPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyResource GetDataReplicationPrivateEndpointConnectionProxyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionResource GetDataReplicationPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResource GetDataReplicationPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource GetDataReplicationProtectedItemResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointResource GetDataReplicationRecoveryPointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource> GetDataReplicationVault(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource>> GetDataReplicationVaultAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource GetDataReplicationVaultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultCollection GetDataReplicationVaults(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource> GetDataReplicationVaults(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource> GetDataReplicationVaultsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityResult> PostCheckNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityResult>> PostCheckNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflight> PostDeploymentPreflight(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deploymentId, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflight body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflight>> PostDeploymentPreflightAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deploymentId, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflight body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.RecoveryServicesDataReplication.Mocking
{
    public partial class MockableRecoveryServicesDataReplicationArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableRecoveryServicesDataReplicationArmClient() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationResource GetDataReplicationEmailConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventResource GetDataReplicationEventResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionResource GetDataReplicationExtensionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentResource GetDataReplicationFabricAgentResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource GetDataReplicationFabricResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobResource GetDataReplicationJobResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyResource GetDataReplicationPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyResource GetDataReplicationPrivateEndpointConnectionProxyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionResource GetDataReplicationPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResource GetDataReplicationPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource GetDataReplicationProtectedItemResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointResource GetDataReplicationRecoveryPointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource GetDataReplicationVaultResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableRecoveryServicesDataReplicationResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableRecoveryServicesDataReplicationResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource> GetDataReplicationFabric(string fabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource>> GetDataReplicationFabricAsync(string fabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricCollection GetDataReplicationFabrics() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource> GetDataReplicationVault(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource>> GetDataReplicationVaultAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultCollection GetDataReplicationVaults() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflight> PostDeploymentPreflight(string deploymentId, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflight body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflight>> PostDeploymentPreflightAsync(string deploymentId, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflight body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class MockableRecoveryServicesDataReplicationSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableRecoveryServicesDataReplicationSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource> GetDataReplicationFabrics(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource> GetDataReplicationFabricsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource> GetDataReplicationVaults(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource> GetDataReplicationVaultsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityResult> PostCheckNameAvailability(Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityResult>> PostCheckNameAvailabilityAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.RecoveryServicesDataReplication.Models
{
    public partial class AffectedObjectDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AffectedObjectDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AffectedObjectDetails>
    {
        internal AffectedObjectDetails() { }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.AffectedObjectDetailsType? Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.AffectedObjectDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AffectedObjectDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AffectedObjectDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.AffectedObjectDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AffectedObjectDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AffectedObjectDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AffectedObjectDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AffectedObjectDetailsType : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AffectedObjectDetailsType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AffectedObjectDetailsType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.AffectedObjectDetailsType Object { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.AffectedObjectDetailsType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.AffectedObjectDetailsType left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.AffectedObjectDetailsType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.AffectedObjectDetailsType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.AffectedObjectDetailsType left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.AffectedObjectDetailsType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public static partial class ArmRecoveryServicesDataReplicationModelFactory
    {
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.AffectedObjectDetails AffectedObjectDetails(string description = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.AffectedObjectDetailsType? type = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.AffectedObjectDetailsType?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciFabricCustomProperties AzStackHciFabricCustomProperties(Azure.Core.ResourceIdentifier azStackHciSiteId = null, System.Collections.Generic.IEnumerable<string> applianceName = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciClusterProperties cluster = null, Azure.Core.ResourceIdentifier fabricResourceId = null, Azure.Core.ResourceIdentifier fabricContainerId = null, Azure.Core.ResourceIdentifier migrationSolutionId = null, System.Uri migrationHubUri = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData DataReplicationEmailConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEmailConfigurationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEmailConfigurationProperties DataReplicationEmailConfigurationProperties(bool sendToOwners = false, System.Collections.Generic.IEnumerable<string> customEmailAddresses = null, string locale = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? provisioningState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationErrorInfo DataReplicationErrorInfo(string code = null, string type = null, string severity = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string message = null, string causes = null, string recommendation = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventData DataReplicationEventData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventProperties DataReplicationEventProperties(Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), string resourceName = null, string eventType = null, string eventName = null, System.DateTimeOffset? occurredOn = default(System.DateTimeOffset?), string severity = null, string description = null, string correlationId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthErrorInfo> healthErrors = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventCustomProperties customProperties = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? provisioningState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationExtensionData DataReplicationExtensionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationExtensionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationExtensionProperties DataReplicationExtensionProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? provisioningState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState?), Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationExtensionCustomProperties customProperties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricAgentData DataReplicationFabricAgentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricAgentProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricAgentProperties DataReplicationFabricAgentProperties(string correlationId = null, string machineId = null, string machineName = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationIdentity authenticationIdentity = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationIdentity resourceAccessIdentity = null, bool? isResponsive = default(bool?), System.DateTimeOffset? lastHeartbeatOn = default(System.DateTimeOffset?), string versionNumber = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? provisioningState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthErrorInfo> healthErrors = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricAgentCustomProperties customProperties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricData DataReplicationFabricData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricPatch DataReplicationFabricPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricProperties DataReplicationFabricProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? provisioningState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState?), string serviceEndpoint = null, Azure.Core.ResourceIdentifier serviceResourceId = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthStatus? health = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthErrorInfo> healthErrors = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricCustomProperties customProperties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthErrorInfo DataReplicationHealthErrorInfo(Azure.Core.ResourceType? affectedResourceType = default(Azure.Core.ResourceType?), System.Collections.Generic.IEnumerable<string> affectedResourceCorrelationIds = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationInnerHealthErrorInfo> childErrors = null, string code = null, string healthCategory = null, string category = null, string severity = null, string source = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), bool? isCustomerResolvable = default(bool?), string summary = null, string message = null, string causes = null, string recommendation = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationInnerHealthErrorInfo DataReplicationInnerHealthErrorInfo(string code = null, string healthCategory = null, string category = null, string severity = null, string source = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), bool? isCustomerResolvable = default(bool?), string summary = null, string message = null, string causes = null, string recommendation = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobCustomProperties DataReplicationJobCustomProperties(string instanceType = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.AffectedObjectDetails affectedObjectDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobData DataReplicationJobData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobProperties DataReplicationJobProperties(string displayName = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobState? state = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobState?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string objectId = null, string objectName = null, string objectInternalId = null, string objectInternalName = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobObjectType? objectType = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobObjectType?), string replicationProviderId = null, string sourceFabricProviderId = null, string targetFabricProviderId = null, System.Collections.Generic.IEnumerable<string> allowedActions = null, string activityId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTask> tasks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationErrorInfo> errors = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobCustomProperties customProperties = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? provisioningState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityResult DataReplicationNameAvailabilityResult(bool? isNameAvailable = default(bool?), string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData DataReplicationPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyProperties DataReplicationPolicyProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? provisioningState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState?), Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyCustomProperties customProperties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionData DataReplicationPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionProperties DataReplicationPrivateEndpointConnectionProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? provisioningState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState?), Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateEndpointConnectionProxyData DataReplicationPrivateEndpointConnectionProxyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionProxyProperties properties = null, Azure.ETag? etag = default(Azure.ETag?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionProxyProperties DataReplicationPrivateEndpointConnectionProxyProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? provisioningState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState?), Azure.ResourceManager.RecoveryServicesDataReplication.Models.RemotePrivateEndpoint remotePrivateEndpoint = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPrivateLinkResourceData DataReplicationPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkResourceProperties DataReplicationPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? provisioningState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData DataReplicationProtectedItemData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemPatch DataReplicationProtectedItemPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemCustomPropertiesUpdate customProperties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemProperties DataReplicationProtectedItemProperties(string policyName = null, string replicationExtensionName = null, string correlationId = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? provisioningState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState?), Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState? protectionState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState?), string protectionStateDescription = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTestFailoverState? testFailoverState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTestFailoverState?), string testFailoverStateDescription = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationResynchronizationState? resynchronizationState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationResynchronizationState?), string fabricObjectId = null, string fabricObjectName = null, string sourceFabricProviderId = null, string targetFabricProviderId = null, string fabricId = null, string targetFabricId = null, string fabricAgentId = null, string targetFabricAgentId = null, bool? isResyncRequired = default(bool?), System.DateTimeOffset? lastSuccessfulPlannedFailoverOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastSuccessfulUnplannedFailoverOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastSuccessfulTestFailoverOn = default(System.DateTimeOffset?), Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties currentJob = null, System.Collections.Generic.IEnumerable<string> allowedJobs = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties lastFailedEnableProtectionJob = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties lastFailedPlannedFailoverJob = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties lastTestFailoverJob = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthStatus? replicationHealth = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthErrorInfo> healthErrors = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemCustomProperties customProperties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointData DataReplicationRecoveryPointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointProperties DataReplicationRecoveryPointProperties(System.DateTimeOffset recoveryPointOn = default(System.DateTimeOffset), Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointType recoveryPointType = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointType), Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointCustomProperties customProperties = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? provisioningState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTask DataReplicationTask(string taskName = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTaskState? state = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTaskState?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string customInstanceType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobData> childrenJobs = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultData DataReplicationVaultData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultPatch DataReplicationVaultPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultProperties DataReplicationVaultProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? provisioningState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState?), Azure.Core.ResourceIdentifier serviceResourceId = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultType? vaultType = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultType?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverJobCustomProperties FailoverJobCustomProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.AffectedObjectDetails affectedObjectDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties> protectedItemDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties FailoverProtectedItemProperties(string protectedItemName = null, string vmName = null, string testVmName = null, string recoveryPointId = null, System.DateTimeOffset? recoveryPointOn = default(System.DateTimeOffset?), string networkName = null, string subnet = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVMigrateFabricCustomProperties HyperVMigrateFabricCustomProperties(Azure.Core.ResourceIdentifier hyperVSiteId = null, Azure.Core.ResourceIdentifier fabricResourceId = null, Azure.Core.ResourceIdentifier fabricContainerId = null, Azure.Core.ResourceIdentifier migrationSolutionId = null, System.Uri migrationHubUri = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciEventCustomProperties HyperVToAzStackHciEventCustomProperties(string eventSourceFriendlyName = null, string protectedItemFriendlyName = null, string sourceApplianceName = null, string targetApplianceName = null, string serverType = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciNicInput HyperVToAzStackHciNicInput(string nicId = null, string networkName = null, string targetNetworkId = null, string testNetworkId = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection selectionTypeForFailover = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection), bool? isStaticIPMigrationEnabled = default(bool?), bool? isMacMigrationEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedDiskProperties HyperVToAzStackHciProtectedDiskProperties(Azure.Core.ResourceIdentifier storageContainerId = null, string storageContainerLocalPath = null, string sourceDiskId = null, string sourceDiskName = null, string seedDiskName = null, string testMigrateDiskName = null, string migrateDiskName = null, bool? isOSDisk = default(bool?), long? capacityInBytes = default(long?), bool? isDynamic = default(bool?), string diskType = null, long? diskBlockSize = default(long?), long? diskLogicalSectorSize = default(long?), long? diskPhysicalSectorSize = default(long?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedItemCustomProperties HyperVToAzStackHciProtectedItemCustomProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation? activeLocation = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation?), Azure.Core.ResourceIdentifier targetHciClusterId = null, Azure.Core.ResourceIdentifier targetArcClusterCustomLocationId = null, string targetAzStackHciClusterName = null, Azure.Core.ResourceIdentifier fabricDiscoveryMachineId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciDiskInput> disksToInclude = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciNicInput> nicsToInclude = null, string sourceVmName = null, int? sourceCpuCores = default(int?), double? sourceMemoryInMegaBytes = default(double?), string targetVmName = null, Azure.Core.ResourceIdentifier targetResourceGroupId = null, Azure.Core.ResourceIdentifier storageContainerId = null, string hyperVGeneration = null, string targetNetworkId = null, string testNetworkId = null, int? targetCpuCores = default(int?), bool? isDynamicRam = default(bool?), Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemDynamicMemoryConfig dynamicMemoryConfig = null, int? targetMemoryInMegaBytes = default(int?), string runAsAccountId = null, string sourceFabricAgentName = null, string targetFabricAgentName = null, string sourceApplianceName = null, string targetApplianceName = null, string osType = null, string osName = null, string firmwareType = null, string targetLocation = null, string customLocationRegion = null, string failoverRecoveryPointId = null, System.DateTimeOffset? lastRecoveryPointReceivedOn = default(System.DateTimeOffset?), string lastRecoveryPointId = null, int? initialReplicationProgressPercentage = default(int?), int? resyncProgressPercentage = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedDiskProperties> protectedDisks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedNicProperties> protectedNics = null, string targetVmBiosId = null, System.DateTimeOffset? lastReplicationUpdateOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedNicProperties HyperVToAzStackHciProtectedNicProperties(string nicId = null, string macAddress = null, string networkName = null, string targetNetworkId = null, string testNetworkId = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection? selectionTypeForFailover = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciRecoveryPointCustomProperties HyperVToAzStackHciRecoveryPointCustomProperties(System.Collections.Generic.IEnumerable<string> diskIds = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciReplicationExtensionCustomProperties HyperVToAzStackHciReplicationExtensionCustomProperties(Azure.Core.ResourceIdentifier hyperVFabricArmId = null, Azure.Core.ResourceIdentifier hyperVSiteId = null, Azure.Core.ResourceIdentifier azStackHciFabricArmId = null, Azure.Core.ResourceIdentifier azStackHciSiteId = null, string storageAccountId = null, string storageAccountSasSecretName = null, System.Uri asrServiceUri = null, System.Uri rcmServiceUri = null, System.Uri gatewayServiceUri = null, string sourceGatewayServiceId = null, string targetGatewayServiceId = null, string sourceStorageContainerName = null, string targetStorageContainerName = null, string resourceLocation = null, string subscriptionId = null, string resourceGroup = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties ProtectedItemJobProperties(string scenarioName = null, string id = null, string name = null, string displayName = null, string state = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverCleanupJobCustomProperties TestFailoverCleanupJobCustomProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.AffectedObjectDetails affectedObjectDetails = null, string comments = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverJobCustomProperties TestFailoverJobCustomProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.AffectedObjectDetails affectedObjectDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties> protectedItemDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciEventCustomProperties VMwareToAzStackHciEventCustomProperties(string eventSourceFriendlyName = null, string protectedItemFriendlyName = null, string sourceApplianceName = null, string targetApplianceName = null, string serverType = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciNicInput VMwareToAzStackHciNicInput(string nicId = null, string label = null, string networkName = null, string targetNetworkId = null, string testNetworkId = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection selectionTypeForFailover = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection), bool? isStaticIPMigrationEnabled = default(bool?), bool? isMacMigrationEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedDiskProperties VMwareToAzStackHciProtectedDiskProperties(Azure.Core.ResourceIdentifier storageContainerId = null, string storageContainerLocalPath = null, string sourceDiskId = null, string sourceDiskName = null, string seedDiskName = null, string testMigrateDiskName = null, string migrateDiskName = null, bool? isOSDisk = default(bool?), long? capacityInBytes = default(long?), bool? isDynamic = default(bool?), string diskType = null, long? diskBlockSize = default(long?), long? diskLogicalSectorSize = default(long?), long? diskPhysicalSectorSize = default(long?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedItemCustomProperties VMwareToAzStackHciProtectedItemCustomProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation? activeLocation = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation?), Azure.Core.ResourceIdentifier targetHciClusterId = null, Azure.Core.ResourceIdentifier targetArcClusterCustomLocationId = null, string targetAzStackHciClusterName = null, Azure.Core.ResourceIdentifier storageContainerId = null, Azure.Core.ResourceIdentifier targetResourceGroupId = null, string targetLocation = null, string customLocationRegion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciDiskInput> disksToInclude = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciNicInput> nicsToInclude = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedDiskProperties> protectedDisks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedNicProperties> protectedNics = null, string targetVmBiosId = null, string targetVmName = null, string hyperVGeneration = null, string targetNetworkId = null, string testNetworkId = null, int? targetCpuCores = default(int?), bool? isDynamicRam = default(bool?), Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemDynamicMemoryConfig dynamicMemoryConfig = null, int? targetMemoryInMegaBytes = default(int?), string osType = null, string osName = null, string firmwareType = null, Azure.Core.ResourceIdentifier fabricDiscoveryMachineId = null, string sourceVmName = null, int? sourceCpuCores = default(int?), double? sourceMemoryInMegaBytes = default(double?), string runAsAccountId = null, string sourceFabricAgentName = null, string targetFabricAgentName = null, string sourceApplianceName = null, string targetApplianceName = null, string failoverRecoveryPointId = null, System.DateTimeOffset? lastRecoveryPointReceivedOn = default(System.DateTimeOffset?), string lastRecoveryPointId = null, int? initialReplicationProgressPercentage = default(int?), int? migrationProgressPercentage = default(int?), int? resumeProgressPercentage = default(int?), int? resyncProgressPercentage = default(int?), long? resyncRetryCount = default(long?), bool? resyncRequired = default(bool?), Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzureMigrateResyncState? resyncState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzureMigrateResyncState?), bool? performAutoResync = default(bool?), long? resumeRetryCount = default(long?), System.DateTimeOffset? lastReplicationUpdateOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedNicProperties VMwareToAzStackHciProtectedNicProperties(string nicId = null, string macAddress = null, string label = null, bool? isPrimaryNic = default(bool?), string networkName = null, string targetNetworkId = null, string testNetworkId = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection? selectionTypeForFailover = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciRecoveryPointCustomProperties VMwareToAzStackHciRecoveryPointCustomProperties(System.Collections.Generic.IEnumerable<string> diskIds = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciReplicationExtensionCustomProperties VMwareToAzStackHciReplicationExtensionCustomProperties(Azure.Core.ResourceIdentifier vmwareFabricArmId = null, Azure.Core.ResourceIdentifier vmwareSiteId = null, Azure.Core.ResourceIdentifier azStackHciFabricArmId = null, Azure.Core.ResourceIdentifier azStackHciSiteId = null, string storageAccountId = null, string storageAccountSasSecretName = null, System.Uri asrServiceUri = null, System.Uri rcmServiceUri = null, System.Uri gatewayServiceUri = null, string sourceGatewayServiceId = null, string targetGatewayServiceId = null, string sourceStorageContainerName = null, string targetStorageContainerName = null, string resourceLocation = null, string subscriptionId = null, string resourceGroup = null) { throw null; }
    }
    public partial class AzStackHciClusterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciClusterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciClusterProperties>
    {
        public AzStackHciClusterProperties(string clusterName, string resourceName, string storageAccountName, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.StorageContainerProperties> storageContainers) { }
        public string ClusterName { get { throw null; } set { } }
        public string ResourceName { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.StorageContainerProperties> StorageContainers { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciClusterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciClusterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciClusterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciClusterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciClusterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciClusterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciClusterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzStackHciFabricCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciFabricCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciFabricCustomProperties>
    {
        public AzStackHciFabricCustomProperties(Azure.Core.ResourceIdentifier azStackHciSiteId, Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciClusterProperties cluster, Azure.Core.ResourceIdentifier migrationSolutionId) { }
        public System.Collections.Generic.IReadOnlyList<string> ApplianceName { get { throw null; } }
        public Azure.Core.ResourceIdentifier AzStackHciSiteId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciClusterProperties Cluster { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier FabricContainerId { get { throw null; } }
        public Azure.Core.ResourceIdentifier FabricResourceId { get { throw null; } }
        public System.Uri MigrationHubUri { get { throw null; } }
        public Azure.Core.ResourceIdentifier MigrationSolutionId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciFabricCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciFabricCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciFabricCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciFabricCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciFabricCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciFabricCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciFabricCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationDiskControllerInputs : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationDiskControllerInputs>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationDiskControllerInputs>
    {
        public DataReplicationDiskControllerInputs(string controllerName, int controllerId, int controllerLocation) { }
        public int ControllerId { get { throw null; } set { } }
        public int ControllerLocation { get { throw null; } set { } }
        public string ControllerName { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationDiskControllerInputs System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationDiskControllerInputs>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationDiskControllerInputs>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationDiskControllerInputs System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationDiskControllerInputs>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationDiskControllerInputs>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationDiskControllerInputs>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationEmailConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEmailConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEmailConfigurationProperties>
    {
        public DataReplicationEmailConfigurationProperties(bool sendToOwners) { }
        public System.Collections.Generic.IList<string> CustomEmailAddresses { get { throw null; } }
        public string Locale { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? ProvisioningState { get { throw null; } }
        public bool SendToOwners { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEmailConfigurationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEmailConfigurationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEmailConfigurationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEmailConfigurationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEmailConfigurationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEmailConfigurationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEmailConfigurationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationErrorInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationErrorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationErrorInfo>
    {
        internal DataReplicationErrorInfo() { }
        public string Causes { get { throw null; } }
        public string Code { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string Message { get { throw null; } }
        public string Recommendation { get { throw null; } }
        public string Severity { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationErrorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationErrorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationErrorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationErrorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationErrorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationErrorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationErrorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DataReplicationEventCustomProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventCustomProperties>
    {
        protected DataReplicationEventCustomProperties() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationEventProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventProperties>
    {
        internal DataReplicationEventProperties() { }
        public string CorrelationId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventCustomProperties CustomProperties { get { throw null; } }
        public string Description { get { throw null; } }
        public string EventName { get { throw null; } }
        public string EventType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthErrorInfo> HealthErrors { get { throw null; } }
        public System.DateTimeOffset? OccurredOn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? ProvisioningState { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public string Severity { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DataReplicationExtensionCustomProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationExtensionCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationExtensionCustomProperties>
    {
        protected DataReplicationExtensionCustomProperties() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationExtensionCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationExtensionCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationExtensionCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationExtensionCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationExtensionCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationExtensionCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationExtensionCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationExtensionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationExtensionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationExtensionProperties>
    {
        public DataReplicationExtensionProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationExtensionCustomProperties customProperties) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationExtensionCustomProperties CustomProperties { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationExtensionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationExtensionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationExtensionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationExtensionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationExtensionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationExtensionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationExtensionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DataReplicationFabricAgentCustomProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricAgentCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricAgentCustomProperties>
    {
        protected DataReplicationFabricAgentCustomProperties() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricAgentCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricAgentCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricAgentCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricAgentCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricAgentCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricAgentCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricAgentCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationFabricAgentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricAgentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricAgentProperties>
    {
        public DataReplicationFabricAgentProperties(string machineId, string machineName, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationIdentity authenticationIdentity, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationIdentity resourceAccessIdentity, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricAgentCustomProperties customProperties) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationIdentity AuthenticationIdentity { get { throw null; } set { } }
        public string CorrelationId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricAgentCustomProperties CustomProperties { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthErrorInfo> HealthErrors { get { throw null; } }
        public bool? IsResponsive { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeatOn { get { throw null; } }
        public string MachineId { get { throw null; } set { } }
        public string MachineName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationIdentity ResourceAccessIdentity { get { throw null; } set { } }
        public string VersionNumber { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricAgentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricAgentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricAgentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricAgentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricAgentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricAgentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricAgentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DataReplicationFabricCustomProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricCustomProperties>
    {
        protected DataReplicationFabricCustomProperties() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationFabricPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricPatch>
    {
        public DataReplicationFabricPatch() { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationFabricProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricProperties>
    {
        public DataReplicationFabricProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricCustomProperties customProperties) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricCustomProperties CustomProperties { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthStatus? Health { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthErrorInfo> HealthErrors { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? ProvisioningState { get { throw null; } }
        public string ServiceEndpoint { get { throw null; } }
        public Azure.Core.ResourceIdentifier ServiceResourceId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationHealthErrorInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthErrorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthErrorInfo>
    {
        internal DataReplicationHealthErrorInfo() { }
        public System.Collections.Generic.IReadOnlyList<string> AffectedResourceCorrelationIds { get { throw null; } }
        public Azure.Core.ResourceType? AffectedResourceType { get { throw null; } }
        public string Category { get { throw null; } }
        public string Causes { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationInnerHealthErrorInfo> ChildErrors { get { throw null; } }
        public string Code { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string HealthCategory { get { throw null; } }
        public bool? IsCustomerResolvable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Recommendation { get { throw null; } }
        public string Severity { get { throw null; } }
        public string Source { get { throw null; } }
        public string Summary { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthErrorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthErrorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthErrorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthErrorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthErrorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthErrorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthErrorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataReplicationHealthStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataReplicationHealthStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthStatus Critical { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthStatus Normal { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthStatus Warning { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthStatus left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthStatus left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataReplicationIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationIdentity>
    {
        public DataReplicationIdentity(System.Guid tenantId, string applicationId, string objectId, string audience, string aadAuthority) { }
        public string AadAuthority { get { throw null; } set { } }
        public string ApplicationId { get { throw null; } set { } }
        public string Audience { get { throw null; } set { } }
        public string ObjectId { get { throw null; } set { } }
        public System.Guid TenantId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationInnerHealthErrorInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationInnerHealthErrorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationInnerHealthErrorInfo>
    {
        internal DataReplicationInnerHealthErrorInfo() { }
        public string Category { get { throw null; } }
        public string Causes { get { throw null; } }
        public string Code { get { throw null; } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public string HealthCategory { get { throw null; } }
        public bool? IsCustomerResolvable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Recommendation { get { throw null; } }
        public string Severity { get { throw null; } }
        public string Source { get { throw null; } }
        public string Summary { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationInnerHealthErrorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationInnerHealthErrorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationInnerHealthErrorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationInnerHealthErrorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationInnerHealthErrorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationInnerHealthErrorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationInnerHealthErrorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DataReplicationJobCustomProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobCustomProperties>
    {
        protected DataReplicationJobCustomProperties() { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.AffectedObjectDetails AffectedObjectDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataReplicationJobObjectType : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobObjectType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataReplicationJobObjectType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobObjectType AvsDiskPool { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobObjectType Fabric { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobObjectType FabricAgent { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobObjectType Policy { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobObjectType ProtectedItem { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobObjectType RecoveryPlan { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobObjectType ReplicationExtension { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobObjectType Vault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobObjectType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobObjectType left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobObjectType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobObjectType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobObjectType left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobObjectType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataReplicationJobProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobProperties>
    {
        internal DataReplicationJobProperties() { }
        public string ActivityId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> AllowedActions { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobCustomProperties CustomProperties { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationErrorInfo> Errors { get { throw null; } }
        public string ObjectId { get { throw null; } }
        public string ObjectInternalId { get { throw null; } }
        public string ObjectInternalName { get { throw null; } }
        public string ObjectName { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobObjectType? ObjectType { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? ProvisioningState { get { throw null; } }
        public string ReplicationProviderId { get { throw null; } }
        public string SourceFabricProviderId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobState? State { get { throw null; } }
        public string TargetFabricProviderId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTask> Tasks { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataReplicationJobState : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataReplicationJobState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobState Cancelling { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobState CompletedWithErrors { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobState CompletedWithInformation { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobState CompletedWithWarnings { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobState Failed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobState Pending { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobState Started { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobState left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobState left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataReplicationNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityContent>
    {
        public DataReplicationNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityContent System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityContent>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityContent>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityContent System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityContent>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityContent>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityContent>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationNameAvailabilityResult : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityResult>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityResult>
    {
        internal DataReplicationNameAvailabilityResult() { }
        public bool? IsNameAvailable { get { throw null; } }
        public string Message { get { throw null; } }
        public string Reason { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DataReplicationPolicyCustomProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyCustomProperties>
    {
        protected DataReplicationPolicyCustomProperties() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationPolicyProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyProperties>
    {
        public DataReplicationPolicyProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyCustomProperties customProperties) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyCustomProperties CustomProperties { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationPrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionProperties>
    {
        public DataReplicationPrivateEndpointConnectionProperties() { }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationPrivateEndpointConnectionProxyProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionProxyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionProxyProperties>
    {
        public DataReplicationPrivateEndpointConnectionProxyProperties() { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.RemotePrivateEndpoint RemotePrivateEndpoint { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionProxyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionProxyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionProxyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionProxyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionProxyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionProxyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionProxyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataReplicationPrivateEndpointConnectionStatus : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataReplicationPrivateEndpointConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionStatus left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionStatus left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataReplicationPrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkResourceProperties>
    {
        internal DataReplicationPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredZoneNames { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationPrivateLinkServiceConnection : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceConnection>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceConnection>
    {
        public DataReplicationPrivateLinkServiceConnection() { }
        public System.Collections.Generic.IList<string> GroupIds { get { throw null; } }
        public string Name { get { throw null; } set { } }
        public string RequestMessage { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceConnection System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceConnection>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceConnection>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceConnection System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceConnection>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceConnection>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceConnection>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceConnectionState>
    {
        public DataReplicationPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateEndpointConnectionStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationPrivateLinkServiceProxy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceProxy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceProxy>
    {
        public DataReplicationPrivateLinkServiceProxy() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GroupConnectivityInformation> GroupConnectivityInformation { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier RemotePrivateEndpointConnectionId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceConnectionState RemotePrivateLinkServiceConnectionState { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceProxy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceProxy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceProxy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceProxy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceProxy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceProxy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceProxy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DataReplicationProtectedItemCustomProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemCustomProperties>
    {
        protected DataReplicationProtectedItemCustomProperties() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DataReplicationProtectedItemCustomPropertiesUpdate : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemCustomPropertiesUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemCustomPropertiesUpdate>
    {
        protected DataReplicationProtectedItemCustomPropertiesUpdate() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemCustomPropertiesUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemCustomPropertiesUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemCustomPropertiesUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemCustomPropertiesUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemCustomPropertiesUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemCustomPropertiesUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemCustomPropertiesUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationProtectedItemPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemPatch>
    {
        public DataReplicationProtectedItemPatch() { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemCustomPropertiesUpdate CustomProperties { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationProtectedItemProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemProperties>
    {
        public DataReplicationProtectedItemProperties(string policyName, string replicationExtensionName, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemCustomProperties customProperties) { }
        public System.Collections.Generic.IReadOnlyList<string> AllowedJobs { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties CurrentJob { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemCustomProperties CustomProperties { get { throw null; } set { } }
        public string FabricAgentId { get { throw null; } }
        public string FabricId { get { throw null; } }
        public string FabricObjectId { get { throw null; } }
        public string FabricObjectName { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthErrorInfo> HealthErrors { get { throw null; } }
        public bool? IsResyncRequired { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties LastFailedEnableProtectionJob { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties LastFailedPlannedFailoverJob { get { throw null; } }
        public System.DateTimeOffset? LastSuccessfulPlannedFailoverOn { get { throw null; } }
        public System.DateTimeOffset? LastSuccessfulTestFailoverOn { get { throw null; } }
        public System.DateTimeOffset? LastSuccessfulUnplannedFailoverOn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties LastTestFailoverJob { get { throw null; } }
        public string PolicyName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState? ProtectionState { get { throw null; } }
        public string ProtectionStateDescription { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? ProvisioningState { get { throw null; } }
        public string ReplicationExtensionName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthStatus? ReplicationHealth { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationResynchronizationState? ResynchronizationState { get { throw null; } }
        public string SourceFabricProviderId { get { throw null; } }
        public string TargetFabricAgentId { get { throw null; } }
        public string TargetFabricId { get { throw null; } }
        public string TargetFabricProviderId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTestFailoverState? TestFailoverState { get { throw null; } }
        public string TestFailoverStateDescription { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataReplicationProtectionState : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataReplicationProtectionState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState CancelFailoverFailedOnPrimary { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState CancelFailoverFailedOnRecovery { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState CancelFailoverInProgressOnPrimary { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState CancelFailoverInProgressOnRecovery { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState CancelFailoverStatesBegin { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState CancelFailoverStatesEnd { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState ChangeRecoveryPointCompleted { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState ChangeRecoveryPointFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState ChangeRecoveryPointInitiated { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState ChangeRecoveryPointStatesBegin { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState ChangeRecoveryPointStatesEnd { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState CommitFailoverCompleted { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState CommitFailoverFailedOnPrimary { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState CommitFailoverFailedOnRecovery { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState CommitFailoverInProgressOnPrimary { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState CommitFailoverInProgressOnRecovery { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState CommitFailoverStatesBegin { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState CommitFailoverStatesEnd { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState DisablingFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState DisablingProtection { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState EnablingFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState EnablingProtection { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState InitialReplicationCompletedOnPrimary { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState InitialReplicationCompletedOnRecovery { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState InitialReplicationFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState InitialReplicationInProgress { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState InitialReplicationStatesBegin { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState InitialReplicationStatesEnd { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState MarkedForDeletion { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState PlannedFailoverCompleted { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState PlannedFailoverCompleting { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState PlannedFailoverCompletionFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState PlannedFailoverFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState PlannedFailoverInitiated { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState PlannedFailoverTransitionStatesBegin { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState PlannedFailoverTransitionStatesEnd { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState Protected { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState ProtectedStatesBegin { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState ProtectedStatesEnd { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState ReprotectFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState ReprotectInitiated { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState ReprotectStatesBegin { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState ReprotectStatesEnd { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState UnplannedFailoverCompleted { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState UnplannedFailoverCompleting { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState UnplannedFailoverCompletionFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState UnplannedFailoverFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState UnplannedFailoverInitiated { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState UnplannedFailoverTransitionStatesBegin { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState UnplannedFailoverTransitionStatesEnd { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState UnprotectedStatesBegin { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState UnprotectedStatesEnd { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataReplicationProvisioningState : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataReplicationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public abstract partial class DataReplicationRecoveryPointCustomProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointCustomProperties>
    {
        protected DataReplicationRecoveryPointCustomProperties() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationRecoveryPointProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointProperties>
    {
        internal DataReplicationRecoveryPointProperties() { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointCustomProperties CustomProperties { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? ProvisioningState { get { throw null; } }
        public System.DateTimeOffset RecoveryPointOn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointType RecoveryPointType { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataReplicationRecoveryPointType : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataReplicationRecoveryPointType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointType ApplicationConsistent { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointType CrashConsistent { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointType left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointType left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataReplicationResynchronizationState : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationResynchronizationState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataReplicationResynchronizationState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationResynchronizationState None { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationResynchronizationState ResynchronizationCompleted { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationResynchronizationState ResynchronizationFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationResynchronizationState ResynchronizationInitiated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationResynchronizationState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationResynchronizationState left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationResynchronizationState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationResynchronizationState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationResynchronizationState left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationResynchronizationState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataReplicationTask : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTask>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTask>
    {
        internal DataReplicationTask() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationJobData> ChildrenJobs { get { throw null; } }
        public string CustomInstanceType { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTaskState? State { get { throw null; } }
        public string TaskName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTask System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTask>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTask>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTask System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTask>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTask>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTask>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataReplicationTaskState : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTaskState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataReplicationTaskState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTaskState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTaskState Failed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTaskState Pending { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTaskState Skipped { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTaskState Started { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTaskState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTaskState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTaskState left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTaskState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTaskState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTaskState left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTaskState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataReplicationTestFailoverState : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTestFailoverState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataReplicationTestFailoverState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTestFailoverState MarkedForDeletion { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTestFailoverState None { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTestFailoverState TestFailoverCleanupCompleting { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTestFailoverState TestFailoverCleanupInitiated { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTestFailoverState TestFailoverCompleted { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTestFailoverState TestFailoverCompleting { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTestFailoverState TestFailoverCompletionFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTestFailoverState TestFailoverFailed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTestFailoverState TestFailoverInitiated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTestFailoverState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTestFailoverState left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTestFailoverState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTestFailoverState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTestFailoverState left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTestFailoverState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DataReplicationVaultPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultPatch>
    {
        public DataReplicationVaultPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationVaultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultProperties>
    {
        public DataReplicationVaultProperties() { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.Core.ResourceIdentifier ServiceResourceId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultType? VaultType { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataReplicationVaultType : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataReplicationVaultType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultType DisasterRecovery { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultType Migrate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultType left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultType left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeploymentPreflight : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflight>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflight>
    {
        public DeploymentPreflight() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightResourceInfo> Resources { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflight System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflight>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflight>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflight System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflight>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflight>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflight>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentPreflightResourceInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightResourceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightResourceInfo>
    {
        public DeploymentPreflightResourceInfo() { }
        public string ApiVersion { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        public System.BinaryData Properties { get { throw null; } set { } }
        public Azure.Core.ResourceType? Type { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightResourceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightResourceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightResourceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightResourceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightResourceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightResourceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightResourceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FailoverJobCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverJobCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverJobCustomProperties>
    {
        internal FailoverJobCustomProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties> ProtectedItemDetails { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverJobCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverJobCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverJobCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverJobCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverJobCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverJobCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverJobCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FailoverProtectedItemProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties>
    {
        internal FailoverProtectedItemProperties() { }
        public string NetworkName { get { throw null; } }
        public string ProtectedItemName { get { throw null; } }
        public string RecoveryPointId { get { throw null; } }
        public System.DateTimeOffset? RecoveryPointOn { get { throw null; } }
        public string Subnet { get { throw null; } }
        public string TestVmName { get { throw null; } }
        public string VmName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GroupConnectivityInformation : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GroupConnectivityInformation>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GroupConnectivityInformation>
    {
        public GroupConnectivityInformation() { }
        public System.Collections.Generic.IList<string> CustomerVisibleFqdns { get { throw null; } }
        public string GroupId { get { throw null; } set { } }
        public string InternalFqdn { get { throw null; } set { } }
        public string MemberName { get { throw null; } set { } }
        public string PrivateLinkServiceArmRegion { get { throw null; } set { } }
        public string RedirectMapId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.GroupConnectivityInformation System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GroupConnectivityInformation>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GroupConnectivityInformation>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.GroupConnectivityInformation System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GroupConnectivityInformation>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GroupConnectivityInformation>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GroupConnectivityInformation>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HyperVMigrateFabricCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVMigrateFabricCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVMigrateFabricCustomProperties>
    {
        public HyperVMigrateFabricCustomProperties(Azure.Core.ResourceIdentifier hyperVSiteId, Azure.Core.ResourceIdentifier migrationSolutionId) { }
        public Azure.Core.ResourceIdentifier FabricContainerId { get { throw null; } }
        public Azure.Core.ResourceIdentifier FabricResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier HyperVSiteId { get { throw null; } set { } }
        public System.Uri MigrationHubUri { get { throw null; } }
        public Azure.Core.ResourceIdentifier MigrationSolutionId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVMigrateFabricCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVMigrateFabricCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVMigrateFabricCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVMigrateFabricCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVMigrateFabricCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVMigrateFabricCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVMigrateFabricCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HyperVToAzStackHciDiskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciDiskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciDiskInput>
    {
        public HyperVToAzStackHciDiskInput(string diskId, long diskSizeGB, string diskFileFormat, bool isOSDisk) { }
        public long? DiskBlockSize { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationDiskControllerInputs DiskController { get { throw null; } set { } }
        public string DiskFileFormat { get { throw null; } set { } }
        public string DiskId { get { throw null; } set { } }
        public string DiskIdentifier { get { throw null; } set { } }
        public long? DiskLogicalSectorSize { get { throw null; } set { } }
        public long? DiskPhysicalSectorSize { get { throw null; } set { } }
        public long DiskSizeGB { get { throw null; } set { } }
        public bool? IsDynamic { get { throw null; } set { } }
        public bool IsOSDisk { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageContainerId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciDiskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciDiskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciDiskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciDiskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciDiskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciDiskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciDiskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HyperVToAzStackHciEventCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciEventCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciEventCustomProperties>
    {
        internal HyperVToAzStackHciEventCustomProperties() { }
        public string EventSourceFriendlyName { get { throw null; } }
        public string ProtectedItemFriendlyName { get { throw null; } }
        public string ServerType { get { throw null; } }
        public string SourceApplianceName { get { throw null; } }
        public string TargetApplianceName { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciEventCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciEventCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciEventCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciEventCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciEventCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciEventCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciEventCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HyperVToAzStackHciNicInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciNicInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciNicInput>
    {
        public HyperVToAzStackHciNicInput(string nicId, Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection selectionTypeForFailover) { }
        public bool? IsMacMigrationEnabled { get { throw null; } set { } }
        public bool? IsStaticIPMigrationEnabled { get { throw null; } set { } }
        public string NetworkName { get { throw null; } }
        public string NicId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection SelectionTypeForFailover { get { throw null; } set { } }
        public string TargetNetworkId { get { throw null; } set { } }
        public string TestNetworkId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciNicInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciNicInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciNicInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciNicInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciNicInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciNicInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciNicInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HyperVToAzStackHciPlannedFailoverCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPlannedFailoverCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPlannedFailoverCustomProperties>
    {
        public HyperVToAzStackHciPlannedFailoverCustomProperties(bool shutdownSourceVm) { }
        public bool ShutdownSourceVm { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPlannedFailoverCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPlannedFailoverCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPlannedFailoverCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPlannedFailoverCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPlannedFailoverCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPlannedFailoverCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPlannedFailoverCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HyperVToAzStackHciPolicyCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPolicyCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPolicyCustomProperties>
    {
        public HyperVToAzStackHciPolicyCustomProperties(int recoveryPointHistoryInMinutes, int crashConsistentFrequencyInMinutes, int appConsistentFrequencyInMinutes) { }
        public int AppConsistentFrequencyInMinutes { get { throw null; } set { } }
        public int CrashConsistentFrequencyInMinutes { get { throw null; } set { } }
        public int RecoveryPointHistoryInMinutes { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPolicyCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPolicyCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPolicyCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPolicyCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPolicyCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPolicyCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPolicyCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HyperVToAzStackHciProtectedDiskProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedDiskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedDiskProperties>
    {
        internal HyperVToAzStackHciProtectedDiskProperties() { }
        public long? CapacityInBytes { get { throw null; } }
        public long? DiskBlockSize { get { throw null; } }
        public long? DiskLogicalSectorSize { get { throw null; } }
        public long? DiskPhysicalSectorSize { get { throw null; } }
        public string DiskType { get { throw null; } }
        public bool? IsDynamic { get { throw null; } }
        public bool? IsOSDisk { get { throw null; } }
        public string MigrateDiskName { get { throw null; } }
        public string SeedDiskName { get { throw null; } }
        public string SourceDiskId { get { throw null; } }
        public string SourceDiskName { get { throw null; } }
        public Azure.Core.ResourceIdentifier StorageContainerId { get { throw null; } }
        public string StorageContainerLocalPath { get { throw null; } }
        public string TestMigrateDiskName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedDiskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedDiskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedDiskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedDiskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedDiskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedDiskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedDiskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HyperVToAzStackHciProtectedItemCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedItemCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedItemCustomProperties>
    {
        public HyperVToAzStackHciProtectedItemCustomProperties(Azure.Core.ResourceIdentifier targetHciClusterId, Azure.Core.ResourceIdentifier targetArcClusterCustomLocationId, Azure.Core.ResourceIdentifier fabricDiscoveryMachineId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciDiskInput> disksToInclude, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciNicInput> nicsToInclude, Azure.Core.ResourceIdentifier targetResourceGroupId, Azure.Core.ResourceIdentifier storageContainerId, string hyperVGeneration, string runAsAccountId, string sourceFabricAgentName, string targetFabricAgentName, string customLocationRegion) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation? ActiveLocation { get { throw null; } }
        public string CustomLocationRegion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciDiskInput> DisksToInclude { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemDynamicMemoryConfig DynamicMemoryConfig { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier FabricDiscoveryMachineId { get { throw null; } set { } }
        public string FailoverRecoveryPointId { get { throw null; } }
        public string FirmwareType { get { throw null; } }
        public string HyperVGeneration { get { throw null; } set { } }
        public int? InitialReplicationProgressPercentage { get { throw null; } }
        public bool? IsDynamicRam { get { throw null; } set { } }
        public string LastRecoveryPointId { get { throw null; } }
        public System.DateTimeOffset? LastRecoveryPointReceivedOn { get { throw null; } }
        public System.DateTimeOffset? LastReplicationUpdateOn { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciNicInput> NicsToInclude { get { throw null; } }
        public string OSName { get { throw null; } }
        public string OSType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedDiskProperties> ProtectedDisks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedNicProperties> ProtectedNics { get { throw null; } }
        public int? ResyncProgressPercentage { get { throw null; } }
        public string RunAsAccountId { get { throw null; } set { } }
        public string SourceApplianceName { get { throw null; } }
        public int? SourceCpuCores { get { throw null; } }
        public string SourceFabricAgentName { get { throw null; } set { } }
        public double? SourceMemoryInMegaBytes { get { throw null; } }
        public string SourceVmName { get { throw null; } }
        public Azure.Core.ResourceIdentifier StorageContainerId { get { throw null; } set { } }
        public string TargetApplianceName { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetArcClusterCustomLocationId { get { throw null; } set { } }
        public string TargetAzStackHciClusterName { get { throw null; } }
        public int? TargetCpuCores { get { throw null; } set { } }
        public string TargetFabricAgentName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetHciClusterId { get { throw null; } set { } }
        public string TargetLocation { get { throw null; } }
        public int? TargetMemoryInMegaBytes { get { throw null; } set { } }
        public string TargetNetworkId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetResourceGroupId { get { throw null; } set { } }
        public string TargetVmBiosId { get { throw null; } }
        public string TargetVmName { get { throw null; } set { } }
        public string TestNetworkId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedItemCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedItemCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedItemCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedItemCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedItemCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedItemCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedItemCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HyperVToAzStackHciProtectedItemCustomPropertiesUpdate : Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemCustomPropertiesUpdate, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedItemCustomPropertiesUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedItemCustomPropertiesUpdate>
    {
        public HyperVToAzStackHciProtectedItemCustomPropertiesUpdate() { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemDynamicMemoryConfig DynamicMemoryConfig { get { throw null; } set { } }
        public bool? IsDynamicRam { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciNicInput> NicsToInclude { get { throw null; } }
        public string OSType { get { throw null; } set { } }
        public int? TargetCpuCores { get { throw null; } set { } }
        public int? TargetMemoryInMegaBytes { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedItemCustomPropertiesUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedItemCustomPropertiesUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedItemCustomPropertiesUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedItemCustomPropertiesUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedItemCustomPropertiesUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedItemCustomPropertiesUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedItemCustomPropertiesUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HyperVToAzStackHciProtectedNicProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedNicProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedNicProperties>
    {
        internal HyperVToAzStackHciProtectedNicProperties() { }
        public string MacAddress { get { throw null; } }
        public string NetworkName { get { throw null; } }
        public string NicId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection? SelectionTypeForFailover { get { throw null; } }
        public string TargetNetworkId { get { throw null; } }
        public string TestNetworkId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedNicProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedNicProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedNicProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedNicProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedNicProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedNicProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedNicProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HyperVToAzStackHciRecoveryPointCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciRecoveryPointCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciRecoveryPointCustomProperties>
    {
        internal HyperVToAzStackHciRecoveryPointCustomProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> DiskIds { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciRecoveryPointCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciRecoveryPointCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciRecoveryPointCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciRecoveryPointCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciRecoveryPointCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciRecoveryPointCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciRecoveryPointCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HyperVToAzStackHciReplicationExtensionCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationExtensionCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciReplicationExtensionCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciReplicationExtensionCustomProperties>
    {
        public HyperVToAzStackHciReplicationExtensionCustomProperties(Azure.Core.ResourceIdentifier hyperVFabricArmId, Azure.Core.ResourceIdentifier azStackHciFabricArmId) { }
        public System.Uri AsrServiceUri { get { throw null; } }
        public Azure.Core.ResourceIdentifier AzStackHciFabricArmId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AzStackHciSiteId { get { throw null; } }
        public System.Uri GatewayServiceUri { get { throw null; } }
        public Azure.Core.ResourceIdentifier HyperVFabricArmId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier HyperVSiteId { get { throw null; } }
        public System.Uri RcmServiceUri { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceLocation { get { throw null; } }
        public string SourceGatewayServiceId { get { throw null; } }
        public string SourceStorageContainerName { get { throw null; } }
        public string StorageAccountId { get { throw null; } set { } }
        public string StorageAccountSasSecretName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } }
        public string TargetGatewayServiceId { get { throw null; } }
        public string TargetStorageContainerName { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciReplicationExtensionCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciReplicationExtensionCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciReplicationExtensionCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciReplicationExtensionCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciReplicationExtensionCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciReplicationExtensionCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciReplicationExtensionCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlannedFailover : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailover>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailover>
    {
        public PlannedFailover(Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverCustomProperties PlannedFailoverCustomProperties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailover System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailover>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailover>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailover System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailover>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailover>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailover>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class PlannedFailoverCustomProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverCustomProperties>
    {
        protected PlannedFailoverCustomProperties() { }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlannedFailoverProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverProperties>
    {
        public PlannedFailoverProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverCustomProperties customProperties) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverCustomProperties CustomProperties { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProtectedItemActiveLocation : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProtectedItemActiveLocation(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation Primary { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation Recovery { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ProtectedItemDynamicMemoryConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemDynamicMemoryConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemDynamicMemoryConfig>
    {
        public ProtectedItemDynamicMemoryConfig(long maximumMemoryInMegaBytes, long minimumMemoryInMegaBytes, int targetMemoryBufferPercentage) { }
        public long MaximumMemoryInMegaBytes { get { throw null; } set { } }
        public long MinimumMemoryInMegaBytes { get { throw null; } set { } }
        public int TargetMemoryBufferPercentage { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemDynamicMemoryConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemDynamicMemoryConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemDynamicMemoryConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemDynamicMemoryConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemDynamicMemoryConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemDynamicMemoryConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemDynamicMemoryConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ProtectedItemJobProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties>
    {
        internal ProtectedItemJobProperties() { }
        public string DisplayName { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public string Id { get { throw null; } }
        public string Name { get { throw null; } }
        public string ScenarioName { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string State { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemotePrivateEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.RemotePrivateEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.RemotePrivateEndpoint>
    {
        public RemotePrivateEndpoint(string id) { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.RemotePrivateEndpointConnectionDetails> ConnectionDetails { get { throw null; } }
        public string Id { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceConnection> ManualPrivateLinkServiceConnections { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceConnection> PrivateLinkServiceConnections { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPrivateLinkServiceProxy> PrivateLinkServiceProxies { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.RemotePrivateEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.RemotePrivateEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.RemotePrivateEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.RemotePrivateEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.RemotePrivateEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.RemotePrivateEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.RemotePrivateEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class RemotePrivateEndpointConnectionDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.RemotePrivateEndpointConnectionDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.RemotePrivateEndpointConnectionDetails>
    {
        public RemotePrivateEndpointConnectionDetails() { }
        public string GroupId { get { throw null; } set { } }
        public string Id { get { throw null; } set { } }
        public string LinkIdentifier { get { throw null; } set { } }
        public string MemberName { get { throw null; } set { } }
        public string PrivateIPAddress { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.RemotePrivateEndpointConnectionDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.RemotePrivateEndpointConnectionDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.RemotePrivateEndpointConnectionDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.RemotePrivateEndpointConnectionDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.RemotePrivateEndpointConnectionDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.RemotePrivateEndpointConnectionDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.RemotePrivateEndpointConnectionDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageContainerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.StorageContainerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.StorageContainerProperties>
    {
        public StorageContainerProperties(string name, string clusterSharedVolumePath) { }
        public string ClusterSharedVolumePath { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.StorageContainerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.StorageContainerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.StorageContainerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.StorageContainerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.StorageContainerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.StorageContainerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.StorageContainerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TestFailoverCleanupJobCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverCleanupJobCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverCleanupJobCustomProperties>
    {
        internal TestFailoverCleanupJobCustomProperties() { }
        public string Comments { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverCleanupJobCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverCleanupJobCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverCleanupJobCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverCleanupJobCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverCleanupJobCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverCleanupJobCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverCleanupJobCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TestFailoverJobCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationJobCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverJobCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverJobCustomProperties>
    {
        internal TestFailoverJobCustomProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties> ProtectedItemDetails { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverJobCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverJobCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverJobCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverJobCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverJobCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverJobCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverJobCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VmNicSelection : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VmNicSelection(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection NotSelected { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection SelectedByDefault { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection SelectedByUser { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection SelectedByUserOverride { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class VMwareFabricAgentCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricAgentCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareFabricAgentCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareFabricAgentCustomProperties>
    {
        public VMwareFabricAgentCustomProperties(string biosId, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationIdentity marsAuthenticationIdentity) { }
        public string BiosId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationIdentity MarsAuthenticationIdentity { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareFabricAgentCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareFabricAgentCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareFabricAgentCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareFabricAgentCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareFabricAgentCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareFabricAgentCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareFabricAgentCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMwareMigrateFabricCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareMigrateFabricCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareMigrateFabricCustomProperties>
    {
        public VMwareMigrateFabricCustomProperties(Azure.Core.ResourceIdentifier vmwareSiteId, Azure.Core.ResourceIdentifier migrationSolutionId) { }
        public Azure.Core.ResourceIdentifier MigrationSolutionId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VmwareSiteId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareMigrateFabricCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareMigrateFabricCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareMigrateFabricCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareMigrateFabricCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareMigrateFabricCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareMigrateFabricCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareMigrateFabricCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMwareToAzStackHciDiskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciDiskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciDiskInput>
    {
        public VMwareToAzStackHciDiskInput(string diskId, long diskSizeGB, string diskFileFormat, bool isOSDisk) { }
        public long? DiskBlockSize { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationDiskControllerInputs DiskController { get { throw null; } set { } }
        public string DiskFileFormat { get { throw null; } set { } }
        public string DiskId { get { throw null; } set { } }
        public string DiskIdentifier { get { throw null; } set { } }
        public long? DiskLogicalSectorSize { get { throw null; } set { } }
        public long? DiskPhysicalSectorSize { get { throw null; } set { } }
        public long DiskSizeGB { get { throw null; } set { } }
        public bool? IsDynamic { get { throw null; } set { } }
        public bool IsOSDisk { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageContainerId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciDiskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciDiskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciDiskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciDiskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciDiskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciDiskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciDiskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMwareToAzStackHciEventCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciEventCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciEventCustomProperties>
    {
        internal VMwareToAzStackHciEventCustomProperties() { }
        public string EventSourceFriendlyName { get { throw null; } }
        public string ProtectedItemFriendlyName { get { throw null; } }
        public string ServerType { get { throw null; } }
        public string SourceApplianceName { get { throw null; } }
        public string TargetApplianceName { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciEventCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciEventCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciEventCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciEventCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciEventCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciEventCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciEventCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMwareToAzStackHciNicInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciNicInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciNicInput>
    {
        public VMwareToAzStackHciNicInput(string nicId, string label, Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection selectionTypeForFailover) { }
        public bool? IsMacMigrationEnabled { get { throw null; } set { } }
        public bool? IsStaticIPMigrationEnabled { get { throw null; } set { } }
        public string Label { get { throw null; } set { } }
        public string NetworkName { get { throw null; } }
        public string NicId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection SelectionTypeForFailover { get { throw null; } set { } }
        public string TargetNetworkId { get { throw null; } set { } }
        public string TestNetworkId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciNicInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciNicInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciNicInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciNicInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciNicInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciNicInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciNicInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMwareToAzStackHciPlannedFailoverCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPlannedFailoverCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPlannedFailoverCustomProperties>
    {
        public VMwareToAzStackHciPlannedFailoverCustomProperties(bool shutdownSourceVm) { }
        public bool ShutdownSourceVm { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPlannedFailoverCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPlannedFailoverCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPlannedFailoverCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPlannedFailoverCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPlannedFailoverCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPlannedFailoverCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPlannedFailoverCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMwareToAzStackHciPolicyCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPolicyCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPolicyCustomProperties>
    {
        public VMwareToAzStackHciPolicyCustomProperties(int recoveryPointHistoryInMinutes, int crashConsistentFrequencyInMinutes, int appConsistentFrequencyInMinutes) { }
        public int AppConsistentFrequencyInMinutes { get { throw null; } set { } }
        public int CrashConsistentFrequencyInMinutes { get { throw null; } set { } }
        public int RecoveryPointHistoryInMinutes { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPolicyCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPolicyCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPolicyCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPolicyCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPolicyCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPolicyCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPolicyCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMwareToAzStackHciProtectedDiskProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedDiskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedDiskProperties>
    {
        internal VMwareToAzStackHciProtectedDiskProperties() { }
        public long? CapacityInBytes { get { throw null; } }
        public long? DiskBlockSize { get { throw null; } }
        public long? DiskLogicalSectorSize { get { throw null; } }
        public long? DiskPhysicalSectorSize { get { throw null; } }
        public string DiskType { get { throw null; } }
        public bool? IsDynamic { get { throw null; } }
        public bool? IsOSDisk { get { throw null; } }
        public string MigrateDiskName { get { throw null; } }
        public string SeedDiskName { get { throw null; } }
        public string SourceDiskId { get { throw null; } }
        public string SourceDiskName { get { throw null; } }
        public Azure.Core.ResourceIdentifier StorageContainerId { get { throw null; } }
        public string StorageContainerLocalPath { get { throw null; } }
        public string TestMigrateDiskName { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedDiskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedDiskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedDiskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedDiskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedDiskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedDiskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedDiskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMwareToAzStackHciProtectedItemCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedItemCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedItemCustomProperties>
    {
        public VMwareToAzStackHciProtectedItemCustomProperties(Azure.Core.ResourceIdentifier targetHciClusterId, Azure.Core.ResourceIdentifier targetArcClusterCustomLocationId, Azure.Core.ResourceIdentifier storageContainerId, Azure.Core.ResourceIdentifier targetResourceGroupId, string customLocationRegion, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciDiskInput> disksToInclude, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciNicInput> nicsToInclude, string hyperVGeneration, Azure.Core.ResourceIdentifier fabricDiscoveryMachineId, string runAsAccountId, string sourceFabricAgentName, string targetFabricAgentName) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation? ActiveLocation { get { throw null; } }
        public string CustomLocationRegion { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciDiskInput> DisksToInclude { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemDynamicMemoryConfig DynamicMemoryConfig { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier FabricDiscoveryMachineId { get { throw null; } set { } }
        public string FailoverRecoveryPointId { get { throw null; } }
        public string FirmwareType { get { throw null; } }
        public string HyperVGeneration { get { throw null; } set { } }
        public int? InitialReplicationProgressPercentage { get { throw null; } }
        public bool? IsDynamicRam { get { throw null; } set { } }
        public string LastRecoveryPointId { get { throw null; } }
        public System.DateTimeOffset? LastRecoveryPointReceivedOn { get { throw null; } }
        public System.DateTimeOffset? LastReplicationUpdateOn { get { throw null; } }
        public int? MigrationProgressPercentage { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciNicInput> NicsToInclude { get { throw null; } }
        public string OSName { get { throw null; } }
        public string OSType { get { throw null; } }
        public bool? PerformAutoResync { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedDiskProperties> ProtectedDisks { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedNicProperties> ProtectedNics { get { throw null; } }
        public int? ResumeProgressPercentage { get { throw null; } }
        public long? ResumeRetryCount { get { throw null; } }
        public int? ResyncProgressPercentage { get { throw null; } }
        public bool? ResyncRequired { get { throw null; } }
        public long? ResyncRetryCount { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzureMigrateResyncState? ResyncState { get { throw null; } }
        public string RunAsAccountId { get { throw null; } set { } }
        public string SourceApplianceName { get { throw null; } }
        public int? SourceCpuCores { get { throw null; } }
        public string SourceFabricAgentName { get { throw null; } set { } }
        public double? SourceMemoryInMegaBytes { get { throw null; } }
        public string SourceVmName { get { throw null; } }
        public Azure.Core.ResourceIdentifier StorageContainerId { get { throw null; } set { } }
        public string TargetApplianceName { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetArcClusterCustomLocationId { get { throw null; } set { } }
        public string TargetAzStackHciClusterName { get { throw null; } }
        public int? TargetCpuCores { get { throw null; } set { } }
        public string TargetFabricAgentName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetHciClusterId { get { throw null; } set { } }
        public string TargetLocation { get { throw null; } }
        public int? TargetMemoryInMegaBytes { get { throw null; } set { } }
        public string TargetNetworkId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetResourceGroupId { get { throw null; } set { } }
        public string TargetVmBiosId { get { throw null; } }
        public string TargetVmName { get { throw null; } set { } }
        public string TestNetworkId { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedItemCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedItemCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedItemCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedItemCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedItemCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedItemCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedItemCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMwareToAzStackHciProtectedItemCustomPropertiesUpdate : Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemCustomPropertiesUpdate, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedItemCustomPropertiesUpdate>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedItemCustomPropertiesUpdate>
    {
        public VMwareToAzStackHciProtectedItemCustomPropertiesUpdate() { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemDynamicMemoryConfig DynamicMemoryConfig { get { throw null; } set { } }
        public bool? IsDynamicRam { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciNicInput> NicsToInclude { get { throw null; } }
        public string OSType { get { throw null; } set { } }
        public int? TargetCpuCores { get { throw null; } set { } }
        public int? TargetMemoryInMegaBytes { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedItemCustomPropertiesUpdate System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedItemCustomPropertiesUpdate>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedItemCustomPropertiesUpdate>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedItemCustomPropertiesUpdate System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedItemCustomPropertiesUpdate>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedItemCustomPropertiesUpdate>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedItemCustomPropertiesUpdate>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMwareToAzStackHciProtectedNicProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedNicProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedNicProperties>
    {
        internal VMwareToAzStackHciProtectedNicProperties() { }
        public bool? IsPrimaryNic { get { throw null; } }
        public string Label { get { throw null; } }
        public string MacAddress { get { throw null; } }
        public string NetworkName { get { throw null; } }
        public string NicId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection? SelectionTypeForFailover { get { throw null; } }
        public string TargetNetworkId { get { throw null; } }
        public string TestNetworkId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedNicProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedNicProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedNicProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedNicProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedNicProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedNicProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedNicProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMwareToAzStackHciRecoveryPointCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciRecoveryPointCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciRecoveryPointCustomProperties>
    {
        internal VMwareToAzStackHciRecoveryPointCustomProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> DiskIds { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciRecoveryPointCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciRecoveryPointCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciRecoveryPointCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciRecoveryPointCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciRecoveryPointCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciRecoveryPointCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciRecoveryPointCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMwareToAzStackHciReplicationExtensionCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationExtensionCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciReplicationExtensionCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciReplicationExtensionCustomProperties>
    {
        public VMwareToAzStackHciReplicationExtensionCustomProperties(Azure.Core.ResourceIdentifier vmwareFabricArmId, Azure.Core.ResourceIdentifier azStackHciFabricArmId) { }
        public System.Uri AsrServiceUri { get { throw null; } }
        public Azure.Core.ResourceIdentifier AzStackHciFabricArmId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AzStackHciSiteId { get { throw null; } }
        public System.Uri GatewayServiceUri { get { throw null; } }
        public System.Uri RcmServiceUri { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceLocation { get { throw null; } }
        public string SourceGatewayServiceId { get { throw null; } }
        public string SourceStorageContainerName { get { throw null; } }
        public string StorageAccountId { get { throw null; } set { } }
        public string StorageAccountSasSecretName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } }
        public string TargetGatewayServiceId { get { throw null; } }
        public string TargetStorageContainerName { get { throw null; } }
        public Azure.Core.ResourceIdentifier VmwareFabricArmId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VmwareSiteId { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciReplicationExtensionCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciReplicationExtensionCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciReplicationExtensionCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciReplicationExtensionCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciReplicationExtensionCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciReplicationExtensionCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciReplicationExtensionCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct VMwareToAzureMigrateResyncState : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzureMigrateResyncState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public VMwareToAzureMigrateResyncState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzureMigrateResyncState None { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzureMigrateResyncState PreparedForResynchronization { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzureMigrateResyncState StartedResynchronization { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzureMigrateResyncState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzureMigrateResyncState left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzureMigrateResyncState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzureMigrateResyncState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzureMigrateResyncState left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzureMigrateResyncState right) { throw null; }
        public override string ToString() { throw null; }
    }
}
