namespace Azure.ResourceManager.RecoveryServicesDataReplication
{
    public partial class DataReplicationDraCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraResource>, System.Collections.IEnumerable
    {
        protected DataReplicationDraCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string fabricAgentName, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string fabricAgentName, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string fabricAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string fabricAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraResource> Get(string fabricAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraResource>> GetAsync(string fabricAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraResource> GetIfExists(string fabricAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraResource>> GetIfExistsAsync(string fabricAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataReplicationDraData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraData>
    {
        public DataReplicationDraData(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationDraProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationDraProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationDraResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataReplicationDraResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string fabricName, string fabricAgentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public DataReplicationEmailConfigurationData(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEmailConfigurationProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEmailConfigurationProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationEmailConfigurationResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataReplicationEmailConfigurationResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string emailConfigurationName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataReplicationEventCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventResource>, System.Collections.IEnumerable
    {
        protected DataReplicationEventCollection() { }
        public virtual Azure.Response<bool> Exists(string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventResource> Get(string eventName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventResource> GetAll(string filter = null, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventResource> GetAllAsync(string filter = null, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationEventResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataReplicationEventResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string eventName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public DataReplicationFabricData(Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationFabricResource : Azure.ResourceManager.ArmResource
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
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraResource> GetDataReplicationDra(string fabricAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraResource>> GetDataReplicationDraAsync(string fabricAgentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraCollection GetDataReplicationDras() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public DataReplicationPolicyData(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationPolicyResource : Azure.ResourceManager.ArmResource
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataReplicationProtectedItemCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource>, System.Collections.IEnumerable
    {
        protected DataReplicationProtectedItemCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string protectedItemName, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string protectedItemName, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string protectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string protectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource> Get(string protectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource>> GetAsync(string protectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource> GetIfExists(string protectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource>> GetIfExistsAsync(string protectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataReplicationProtectedItemData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData>
    {
        public DataReplicationProtectedItemData(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationProtectedItemResource : Azure.ResourceManager.ArmResource
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
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModel> PlannedFailover(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModel body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModel>> PlannedFailoverAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModel body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationRecoveryPointResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataReplicationRecoveryPointResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string protectedItemName, string recoveryPointName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataReplicationReplicationExtensionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionResource>, System.Collections.IEnumerable
    {
        protected DataReplicationReplicationExtensionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string replicationExtensionName, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string replicationExtensionName, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string replicationExtensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string replicationExtensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionResource> Get(string replicationExtensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionResource>> GetAsync(string replicationExtensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionResource> GetIfExists(string replicationExtensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionResource>> GetIfExistsAsync(string replicationExtensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataReplicationReplicationExtensionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionData>
    {
        public DataReplicationReplicationExtensionData(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationReplicationExtensionProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationReplicationExtensionProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationReplicationExtensionResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataReplicationReplicationExtensionResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string replicationExtensionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
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
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultProperties Properties { get { throw null; } set { } }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationVaultResource : Azure.ResourceManager.ArmResource
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
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyCollection GetDataReplicationPolicies() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyResource> GetDataReplicationPolicy(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyResource>> GetDataReplicationPolicyAsync(string policyName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource> GetDataReplicationProtectedItem(string protectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource>> GetDataReplicationProtectedItemAsync(string protectedItemName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemCollection GetDataReplicationProtectedItems() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionResource> GetDataReplicationReplicationExtension(string replicationExtensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionResource>> GetDataReplicationReplicationExtensionAsync(string replicationExtensionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionCollection GetDataReplicationReplicationExtensions() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowResource> GetDataReplicationWorkflow(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowResource>> GetDataReplicationWorkflowAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowCollection GetDataReplicationWorkflows() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DataReplicationWorkflowCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowResource>, System.Collections.IEnumerable
    {
        protected DataReplicationWorkflowCollection() { }
        public virtual Azure.Response<bool> Exists(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowResource> Get(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowResource> GetAll(string filter = null, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowResource> GetAllAsync(string filter = null, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowResource>> GetAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowResource> GetIfExists(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowResource>> GetIfExistsAsync(string jobName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DataReplicationWorkflowData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowData>
    {
        internal DataReplicationWorkflowData() { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowProperties Properties { get { throw null; } }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationWorkflowResource : Azure.ResourceManager.ArmResource
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DataReplicationWorkflowResource() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string vaultName, string jobName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class RecoveryServicesDataReplicationExtensions
    {
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityResult> CheckDataReplicationNameAvailability(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityResult>> CheckDataReplicationNameAvailabilityAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightModel> DeploymentPreflight(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deploymentId, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightModel body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightModel>> DeploymentPreflightAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string deploymentId, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightModel body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraResource GetDataReplicationDraResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationResource GetDataReplicationEmailConfigurationResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventResource GetDataReplicationEventResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource> GetDataReplicationFabric(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource>> GetDataReplicationFabricAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string fabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource GetDataReplicationFabricResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricCollection GetDataReplicationFabrics(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource> GetDataReplicationFabrics(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource> GetDataReplicationFabricsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyResource GetDataReplicationPolicyResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource GetDataReplicationProtectedItemResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointResource GetDataReplicationRecoveryPointResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionResource GetDataReplicationReplicationExtensionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource> GetDataReplicationVault(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource>> GetDataReplicationVaultAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource GetDataReplicationVaultResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultCollection GetDataReplicationVaults(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource> GetDataReplicationVaults(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource> GetDataReplicationVaultsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowResource GetDataReplicationWorkflowResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
}
namespace Azure.ResourceManager.RecoveryServicesDataReplication.Mocking
{
    public partial class MockableRecoveryServicesDataReplicationArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableRecoveryServicesDataReplicationArmClient() { }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraResource GetDataReplicationDraResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationResource GetDataReplicationEmailConfigurationResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventResource GetDataReplicationEventResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource GetDataReplicationFabricResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyResource GetDataReplicationPolicyResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemResource GetDataReplicationProtectedItemResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointResource GetDataReplicationRecoveryPointResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionResource GetDataReplicationReplicationExtensionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource GetDataReplicationVaultResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowResource GetDataReplicationWorkflowResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableRecoveryServicesDataReplicationResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableRecoveryServicesDataReplicationResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightModel> DeploymentPreflight(string deploymentId, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightModel body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightModel>> DeploymentPreflightAsync(string deploymentId, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightModel body = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource> GetDataReplicationFabric(string fabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource>> GetDataReplicationFabricAsync(string fabricName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricCollection GetDataReplicationFabrics() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource> GetDataReplicationVault(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource>> GetDataReplicationVaultAsync(string vaultName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultCollection GetDataReplicationVaults() { throw null; }
    }
    public partial class MockableRecoveryServicesDataReplicationSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableRecoveryServicesDataReplicationSubscriptionResource() { }
        public virtual Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityResult> CheckDataReplicationNameAvailability(Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityResult>> CheckDataReplicationNameAvailabilityAsync(Azure.Core.AzureLocation location, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityContent content = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource> GetDataReplicationFabrics(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricResource> GetDataReplicationFabricsAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource> GetDataReplicationVaults(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultResource> GetDataReplicationVaultsAsync(string continuationToken = null, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.RecoveryServicesDataReplication.Models
{
    public static partial class ArmRecoveryServicesDataReplicationModelFactory
    {
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciFabricModelCustomProperties AzStackHciFabricModelCustomProperties(Azure.Core.ResourceIdentifier azStackHciSiteId = null, System.Collections.Generic.IEnumerable<string> applianceName = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciClusterProperties cluster = null, Azure.Core.ResourceIdentifier fabricResourceId = null, string fabricContainerId = null, Azure.Core.ResourceIdentifier migrationSolutionId = null, System.Uri migrationHubUri = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationDraData DataReplicationDraData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationDraProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationDraProperties DataReplicationDraProperties(string correlationId = null, string machineId = null, string machineName = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationIdentity authenticationIdentity = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationIdentity resourceAccessIdentity = null, bool? isResponsive = default(bool?), System.DateTimeOffset? lastHeartbeatOn = default(System.DateTimeOffset?), string versionNumber = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? provisioningState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthErrorInfo> healthErrors = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DraModelCustomProperties customProperties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEmailConfigurationData DataReplicationEmailConfigurationData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEmailConfigurationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationErrorInfo DataReplicationErrorInfo(string code = null, string errorModelType = null, string severity = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string message = null, string causes = null, string recommendation = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationEventData DataReplicationEventData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventProperties DataReplicationEventProperties(Azure.Core.ResourceType? resourceType = default(Azure.Core.ResourceType?), string resourceName = null, string eventType = null, string eventName = null, System.DateTimeOffset? occurredOn = default(System.DateTimeOffset?), string severity = null, string description = null, string correlationId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthErrorInfo> healthErrors = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.EventModelCustomProperties customProperties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationFabricData DataReplicationFabricData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricPatch DataReplicationFabricPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricProperties DataReplicationFabricProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? provisioningState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState?), string serviceEndpoint = null, Azure.Core.ResourceIdentifier serviceResourceId = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthStatus? health = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthErrorInfo> healthErrors = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.FabricModelCustomProperties customProperties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthErrorInfo DataReplicationHealthErrorInfo(string affectedResourceType = null, System.Collections.Generic.IEnumerable<string> affectedResourceCorrelationIds = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationInnerHealthErrorInfo> childErrors = null, string code = null, string healthCategory = null, string category = null, string severity = null, string source = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), bool? isCustomerResolvable = default(bool?), string summary = null, string message = null, string causes = null, string recommendation = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationInnerHealthErrorInfo DataReplicationInnerHealthErrorInfo(string code = null, string healthCategory = null, string category = null, string severity = null, string source = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), bool? isCustomerResolvable = default(bool?), string summary = null, string message = null, string causes = null, string recommendation = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityResult DataReplicationNameAvailabilityResult(bool? isNameAvailable = default(bool?), string reason = null, string message = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationPolicyData DataReplicationPolicyData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyProperties DataReplicationPolicyProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? provisioningState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState?), Azure.ResourceManager.RecoveryServicesDataReplication.Models.PolicyModelCustomProperties customProperties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationProtectedItemData DataReplicationProtectedItemData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemProperties DataReplicationProtectedItemProperties(string policyName = null, string replicationExtensionName = null, string correlationId = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? provisioningState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState?), Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState? protectionState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectionState?), string protectionStateDescription = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTestFailoverState? testFailoverState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTestFailoverState?), string testFailoverStateDescription = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationResynchronizationState? resynchronizationState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationResynchronizationState?), string fabricObjectId = null, string fabricObjectName = null, string sourceFabricProviderId = null, string targetFabricProviderId = null, string fabricId = null, string targetFabricId = null, string draId = null, string targetDraId = null, bool? isResyncRequired = default(bool?), System.DateTimeOffset? lastSuccessfulPlannedFailoverOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastSuccessfulUnplannedFailoverOn = default(System.DateTimeOffset?), System.DateTimeOffset? lastSuccessfulTestFailoverOn = default(System.DateTimeOffset?), Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties currentJob = null, System.Collections.Generic.IEnumerable<string> allowedJobs = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties lastFailedEnableProtectionJob = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties lastFailedPlannedFailoverJob = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties lastTestFailoverJob = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthStatus? replicationHealth = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthStatus?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthErrorInfo> healthErrors = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelCustomProperties customProperties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationRecoveryPointData DataReplicationRecoveryPointData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointProperties DataReplicationRecoveryPointProperties(System.DateTimeOffset recoveryPointOn = default(System.DateTimeOffset), Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointType recoveryPointType = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointType), Azure.ResourceManager.RecoveryServicesDataReplication.Models.RecoveryPointModelCustomProperties customProperties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationReplicationExtensionData DataReplicationReplicationExtensionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationReplicationExtensionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationReplicationExtensionProperties DataReplicationReplicationExtensionProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? provisioningState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState?), Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationExtensionModelCustomProperties customProperties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTask DataReplicationTask(string taskName = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTaskState? state = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTaskState?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string customInstanceType = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowData> childrenWorkflows = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationVaultData DataReplicationVaultData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultPatch DataReplicationVaultPatch(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultProperties DataReplicationVaultProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? provisioningState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState?), Azure.Core.ResourceIdentifier serviceResourceId = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationReplicationVaultType? vaultType = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationReplicationVaultType?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowData DataReplicationWorkflowData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowProperties properties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowProperties DataReplicationWorkflowProperties(string displayName = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowState? state = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowState?), System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?), string objectId = null, string objectName = null, string objectInternalId = null, string objectInternalName = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType? objectType = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType?), string replicationProviderId = null, string sourceFabricProviderId = null, string targetFabricProviderId = null, System.Collections.Generic.IEnumerable<string> allowedActions = null, string activityId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTask> tasks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationErrorInfo> errors = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowModelCustomProperties customProperties = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties FailoverProtectedItemProperties(string protectedItemName = null, string vmName = null, string testVmName = null, string recoveryPointId = null, System.DateTimeOffset? recoveryPointOn = default(System.DateTimeOffset?), string networkName = null, string subnet = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverWorkflowModelCustomProperties FailoverWorkflowModelCustomProperties(System.Collections.Generic.IReadOnlyDictionary<string, string> affectedObjectDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties> protectedItemDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVMigrateFabricModelCustomProperties HyperVMigrateFabricModelCustomProperties(Azure.Core.ResourceIdentifier hyperVSiteId = null, Azure.Core.ResourceIdentifier fabricResourceId = null, string fabricContainerId = null, Azure.Core.ResourceIdentifier migrationSolutionId = null, System.Uri migrationHubUri = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciEventModelCustomProperties HyperVToAzStackHciEventModelCustomProperties(string eventSourceFriendlyName = null, string protectedItemFriendlyName = null, string sourceApplianceName = null, string targetApplianceName = null, string serverType = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciNicInput HyperVToAzStackHciNicInput(string nicId = null, string networkName = null, string targetNetworkId = null, string testNetworkId = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection selectionTypeForFailover = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedDiskProperties HyperVToAzStackHciProtectedDiskProperties(Azure.Core.ResourceIdentifier storageContainerId = null, string storageContainerLocalPath = null, string sourceDiskId = null, string sourceDiskName = null, string seedDiskName = null, string testMigrateDiskName = null, string migrateDiskName = null, bool? isOSDisk = default(bool?), long? capacityInBytes = default(long?), bool? isDynamic = default(bool?), string diskType = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedItemModelCustomProperties HyperVToAzStackHciProtectedItemModelCustomProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation? activeLocation = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation?), Azure.Core.ResourceIdentifier targetHciClusterId = null, Azure.Core.ResourceIdentifier targetArcClusterCustomLocationId = null, string targetAzStackHciClusterName = null, Azure.Core.ResourceIdentifier fabricDiscoveryMachineId = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciDiskInput> disksToInclude = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciNicInput> nicsToInclude = null, string sourceVmName = null, int? sourceCpuCores = default(int?), double? sourceMemoryInMegaBytes = default(double?), string targetVmName = null, Azure.Core.ResourceIdentifier targetResourceGroupId = null, Azure.Core.ResourceIdentifier storageContainerId = null, string hyperVGeneration = null, string targetNetworkId = null, string testNetworkId = null, int? targetCpuCores = default(int?), bool? isDynamicRam = default(bool?), Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemDynamicMemoryConfig dynamicMemoryConfig = null, int? targetMemoryInMegaBytes = default(int?), string runAsAccountId = null, string sourceDraName = null, string targetDraName = null, string sourceApplianceName = null, string targetApplianceName = null, string osType = null, string osName = null, string firmwareType = null, string targetLocation = null, string customLocationRegion = null, string failoverRecoveryPointId = null, System.DateTimeOffset? lastRecoveryPointReceived = default(System.DateTimeOffset?), string lastRecoveryPointId = null, int? initialReplicationProgressPercentage = default(int?), int? resyncProgressPercentage = default(int?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedDiskProperties> protectedDisks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedNicProperties> protectedNics = null, string targetVmBiosId = null, System.DateTimeOffset? lastReplicationUpdateOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedNicProperties HyperVToAzStackHciProtectedNicProperties(string nicId = null, string macAddress = null, string networkName = null, string targetNetworkId = null, string testNetworkId = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection? selectionTypeForFailover = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciRecoveryPointModelCustomProperties HyperVToAzStackHciRecoveryPointModelCustomProperties(System.Collections.Generic.IEnumerable<string> diskIds = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciReplicationExtensionModelCustomProperties HyperVToAzStackHciReplicationExtensionModelCustomProperties(Azure.Core.ResourceIdentifier hyperVFabricArmId = null, Azure.Core.ResourceIdentifier hyperVSiteId = null, Azure.Core.ResourceIdentifier azStackHciFabricArmId = null, Azure.Core.ResourceIdentifier azStackHciSiteId = null, string storageAccountId = null, string storageAccountSasSecretName = null, System.Uri asrServiceUri = null, System.Uri rcmServiceUri = null, System.Uri gatewayServiceUri = null, string sourceGatewayServiceId = null, string targetGatewayServiceId = null, string sourceStorageContainerName = null, string targetStorageContainerName = null, string resourceLocation = null, string subscriptionId = null, string resourceGroup = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties ProtectedItemJobProperties(string scenarioName = null, string id = null, string name = null, string displayName = null, string state = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverCleanupWorkflowModelCustomProperties TestFailoverCleanupWorkflowModelCustomProperties(System.Collections.Generic.IReadOnlyDictionary<string, string> affectedObjectDetails = null, string comments = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverWorkflowModelCustomProperties TestFailoverWorkflowModelCustomProperties(System.Collections.Generic.IReadOnlyDictionary<string, string> affectedObjectDetails = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties> protectedItemDetails = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciNicInput VMwareToAzStackHciNicInput(string nicId = null, string label = null, string networkName = null, string targetNetworkId = null, string testNetworkId = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection selectionTypeForFailover = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedDiskProperties VMwareToAzStackHciProtectedDiskProperties(Azure.Core.ResourceIdentifier storageContainerId = null, string storageContainerLocalPath = null, string sourceDiskId = null, string sourceDiskName = null, string seedDiskName = null, string testMigrateDiskName = null, string migrateDiskName = null, bool? isOSDisk = default(bool?), long? capacityInBytes = default(long?), bool? isDynamic = default(bool?), string diskType = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedItemModelCustomProperties VMwareToAzStackHciProtectedItemModelCustomProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation? activeLocation = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemActiveLocation?), Azure.Core.ResourceIdentifier targetHciClusterId = null, Azure.Core.ResourceIdentifier targetArcClusterCustomLocationId = null, string targetAzStackHciClusterName = null, Azure.Core.ResourceIdentifier storageContainerId = null, Azure.Core.ResourceIdentifier targetResourceGroupId = null, string targetLocation = null, string customLocationRegion = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciDiskInput> disksToInclude = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciNicInput> nicsToInclude = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedDiskProperties> protectedDisks = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedNicProperties> protectedNics = null, string targetVmBiosId = null, string targetVmName = null, string hyperVGeneration = null, string targetNetworkId = null, string testNetworkId = null, int? targetCpuCores = default(int?), bool? isDynamicRam = default(bool?), Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemDynamicMemoryConfig dynamicMemoryConfig = null, int? targetMemoryInMegaBytes = default(int?), string osType = null, string osName = null, string firmwareType = null, Azure.Core.ResourceIdentifier fabricDiscoveryMachineId = null, string sourceVmName = null, int? sourceCpuCores = default(int?), double? sourceMemoryInMegaBytes = default(double?), string runAsAccountId = null, string sourceDraName = null, string targetDraName = null, string sourceApplianceName = null, string targetApplianceName = null, string failoverRecoveryPointId = null, System.DateTimeOffset? lastRecoveryPointReceived = default(System.DateTimeOffset?), string lastRecoveryPointId = null, int? initialReplicationProgressPercentage = default(int?), int? migrationProgressPercentage = default(int?), int? resumeProgressPercentage = default(int?), int? resyncProgressPercentage = default(int?), long? resyncRetryCount = default(long?), bool? resyncRequired = default(bool?), Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzureMigrateResyncState? resyncState = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzureMigrateResyncState?), bool? performAutoResync = default(bool?), long? resumeRetryCount = default(long?), System.DateTimeOffset? lastReplicationUpdateOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedNicProperties VMwareToAzStackHciProtectedNicProperties(string nicId = null, string macAddress = null, string label = null, bool? isPrimaryNic = default(bool?), string networkName = null, string targetNetworkId = null, string testNetworkId = null, Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection? selectionTypeForFailover = default(Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection?)) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciReplicationExtensionModelCustomProperties VMwareToAzStackHciReplicationExtensionModelCustomProperties(Azure.Core.ResourceIdentifier vmwareFabricArmId = null, Azure.Core.ResourceIdentifier vmwareSiteId = null, Azure.Core.ResourceIdentifier azStackHciFabricArmId = null, Azure.Core.ResourceIdentifier azStackHciSiteId = null, Azure.Core.ResourceIdentifier storageAccountId = null, string storageAccountSasSecretName = null, System.Uri asrServiceUri = null, System.Uri rcmServiceUri = null, System.Uri gatewayServiceUri = null, string sourceGatewayServiceId = null, string targetGatewayServiceId = null, string sourceStorageContainerName = null, string targetStorageContainerName = null, string resourceLocation = null, string subscriptionId = null, string resourceGroup = null) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowModelCustomProperties WorkflowModelCustomProperties(string instanceType = null, System.Collections.Generic.IReadOnlyDictionary<string, string> affectedObjectDetails = null) { throw null; }
    }
    public partial class AzStackHciClusterProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciClusterProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciClusterProperties>
    {
        public AzStackHciClusterProperties(string clusterName, string resourceName, string storageAccountName, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.StorageContainerProperties> storageContainers) { }
        public string ClusterName { get { throw null; } set { } }
        public string ResourceName { get { throw null; } set { } }
        public string StorageAccountName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.StorageContainerProperties> StorageContainers { get { throw null; } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciClusterProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciClusterProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciClusterProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciClusterProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciClusterProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciClusterProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciClusterProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AzStackHciFabricModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.FabricModelCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciFabricModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciFabricModelCustomProperties>
    {
        public AzStackHciFabricModelCustomProperties(Azure.Core.ResourceIdentifier azStackHciSiteId, Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciClusterProperties cluster, Azure.Core.ResourceIdentifier migrationSolutionId) { }
        public System.Collections.Generic.IReadOnlyList<string> ApplianceName { get { throw null; } }
        public Azure.Core.ResourceIdentifier AzStackHciSiteId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciClusterProperties Cluster { get { throw null; } set { } }
        public string FabricContainerId { get { throw null; } }
        public Azure.Core.ResourceIdentifier FabricResourceId { get { throw null; } }
        public System.Uri MigrationHubUri { get { throw null; } }
        public Azure.Core.ResourceIdentifier MigrationSolutionId { get { throw null; } set { } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciFabricModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciFabricModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciFabricModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciFabricModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciFabricModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciFabricModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.AzStackHciFabricModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationDraProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationDraProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationDraProperties>
    {
        public DataReplicationDraProperties(string machineId, string machineName, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationIdentity authenticationIdentity, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationIdentity resourceAccessIdentity, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DraModelCustomProperties customProperties) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationIdentity AuthenticationIdentity { get { throw null; } set { } }
        public string CorrelationId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DraModelCustomProperties CustomProperties { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthErrorInfo> HealthErrors { get { throw null; } }
        public bool? IsResponsive { get { throw null; } }
        public System.DateTimeOffset? LastHeartbeatOn { get { throw null; } }
        public string MachineId { get { throw null; } set { } }
        public string MachineName { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationIdentity ResourceAccessIdentity { get { throw null; } set { } }
        public string VersionNumber { get { throw null; } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationDraProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationDraProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationDraProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationDraProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationDraProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationDraProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationDraProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationEmailConfigurationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEmailConfigurationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEmailConfigurationProperties>
    {
        public DataReplicationEmailConfigurationProperties(bool sendToOwners) { }
        public System.Collections.Generic.IList<string> CustomEmailAddresses { get { throw null; } }
        public string Locale { get { throw null; } set { } }
        public bool SendToOwners { get { throw null; } set { } }
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
        public string ErrorModelType { get { throw null; } }
        public string Message { get { throw null; } }
        public string Recommendation { get { throw null; } }
        public string Severity { get { throw null; } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationErrorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationErrorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationErrorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationErrorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationErrorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationErrorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationErrorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationEventProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventProperties>
    {
        internal DataReplicationEventProperties() { }
        public string CorrelationId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.EventModelCustomProperties CustomProperties { get { throw null; } }
        public string Description { get { throw null; } }
        public string EventName { get { throw null; } }
        public string EventType { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthErrorInfo> HealthErrors { get { throw null; } }
        public System.DateTimeOffset? OccurredOn { get { throw null; } }
        public string ResourceName { get { throw null; } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } }
        public string Severity { get { throw null; } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationEventProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationFabricPatch : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricPatch>
    {
        public DataReplicationFabricPatch() { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationFabricProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationFabricProperties>
    {
        public DataReplicationFabricProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.FabricModelCustomProperties customProperties) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.FabricModelCustomProperties CustomProperties { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthStatus? Health { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationHealthErrorInfo> HealthErrors { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? ProvisioningState { get { throw null; } }
        public string ServiceEndpoint { get { throw null; } }
        public Azure.Core.ResourceIdentifier ServiceResourceId { get { throw null; } }
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
        public string AffectedResourceType { get { throw null; } }
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
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationInnerHealthErrorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationInnerHealthErrorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationInnerHealthErrorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationInnerHealthErrorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationInnerHealthErrorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationInnerHealthErrorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationInnerHealthErrorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationNameAvailabilityContent : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityContent>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityContent>
    {
        public DataReplicationNameAvailabilityContent() { }
        public string Name { get { throw null; } set { } }
        public Azure.Core.ResourceType? ResourceType { get { throw null; } set { } }
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
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityResult System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityResult>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityResult>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityResult System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityResult>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityResult>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationNameAvailabilityResult>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationPolicyProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyProperties>
    {
        public DataReplicationPolicyProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.PolicyModelCustomProperties customProperties) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.PolicyModelCustomProperties CustomProperties { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationPolicyProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationProtectedItemProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProtectedItemProperties>
    {
        public DataReplicationProtectedItemProperties(string policyName, string replicationExtensionName, Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelCustomProperties customProperties) { }
        public System.Collections.Generic.IReadOnlyList<string> AllowedJobs { get { throw null; } }
        public string CorrelationId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties CurrentJob { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelCustomProperties CustomProperties { get { throw null; } set { } }
        public string DraId { get { throw null; } }
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
        public string TargetDraId { get { throw null; } }
        public string TargetFabricId { get { throw null; } }
        public string TargetFabricProviderId { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTestFailoverState? TestFailoverState { get { throw null; } }
        public string TestFailoverStateDescription { get { throw null; } }
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
    public partial class DataReplicationRecoveryPointProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointProperties>
    {
        internal DataReplicationRecoveryPointProperties() { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.RecoveryPointModelCustomProperties CustomProperties { get { throw null; } }
        public System.DateTimeOffset RecoveryPointOn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationRecoveryPointType RecoveryPointType { get { throw null; } }
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
    public partial class DataReplicationReplicationExtensionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationReplicationExtensionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationReplicationExtensionProperties>
    {
        public DataReplicationReplicationExtensionProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationExtensionModelCustomProperties customProperties) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationExtensionModelCustomProperties CustomProperties { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationProvisioningState? ProvisioningState { get { throw null; } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationReplicationExtensionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationReplicationExtensionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationReplicationExtensionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationReplicationExtensionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationReplicationExtensionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationReplicationExtensionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationReplicationExtensionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataReplicationReplicationVaultType : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationReplicationVaultType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataReplicationReplicationVaultType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationReplicationVaultType DisasterRecovery { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationReplicationVaultType Migrate { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationReplicationVaultType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationReplicationVaultType left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationReplicationVaultType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationReplicationVaultType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationReplicationVaultType left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationReplicationVaultType right) { throw null; }
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
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.DataReplicationWorkflowData> ChildrenWorkflows { get { throw null; } }
        public string CustomInstanceType { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTaskState? State { get { throw null; } }
        public string TaskName { get { throw null; } }
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
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
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
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationReplicationVaultType? VaultType { get { throw null; } set { } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DataReplicationWorkflowProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowProperties>
    {
        internal DataReplicationWorkflowProperties() { }
        public string ActivityId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> AllowedActions { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowModelCustomProperties CustomProperties { get { throw null; } }
        public string DisplayName { get { throw null; } }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationErrorInfo> Errors { get { throw null; } }
        public string ObjectId { get { throw null; } }
        public string ObjectInternalId { get { throw null; } }
        public string ObjectInternalName { get { throw null; } }
        public string ObjectName { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType? ObjectType { get { throw null; } }
        public string ReplicationProviderId { get { throw null; } }
        public string SourceFabricProviderId { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowState? State { get { throw null; } }
        public string TargetFabricProviderId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationTask> Tasks { get { throw null; } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DataReplicationWorkflowState : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DataReplicationWorkflowState(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowState Cancelled { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowState Cancelling { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowState CompletedWithErrors { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowState CompletedWithInformation { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowState CompletedWithWarnings { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowState Failed { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowState Pending { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowState Started { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowState left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowState right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowState left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationWorkflowState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DeploymentPreflightModel : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightModel>
    {
        public DeploymentPreflightModel() { }
        public System.Collections.Generic.IList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightResourceInfo> Resources { get { throw null; } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DeploymentPreflightResourceInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightResourceInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightResourceInfo>
    {
        public DeploymentPreflightResourceInfo() { }
        public string ApiVersion { get { throw null; } set { } }
        public Azure.Core.ResourceType? DeploymentPreflightResourceType { get { throw null; } set { } }
        public Azure.Core.AzureLocation? Location { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightResourceInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightResourceInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightResourceInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightResourceInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightResourceInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightResourceInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DeploymentPreflightResourceInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class DraModelCustomProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DraModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DraModelCustomProperties>
    {
        protected DraModelCustomProperties() { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DraModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DraModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DraModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.DraModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DraModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DraModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.DraModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class EventModelCustomProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.EventModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.EventModelCustomProperties>
    {
        protected EventModelCustomProperties() { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.EventModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.EventModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.EventModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.EventModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.EventModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.EventModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.EventModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class FabricModelCustomProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FabricModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FabricModelCustomProperties>
    {
        protected FabricModelCustomProperties() { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.FabricModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FabricModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FabricModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.FabricModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FabricModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FabricModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FabricModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class FailoverWorkflowModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowModelCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverWorkflowModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverWorkflowModelCustomProperties>
    {
        internal FailoverWorkflowModelCustomProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties> ProtectedItemDetails { get { throw null; } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverWorkflowModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverWorkflowModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverWorkflowModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverWorkflowModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverWorkflowModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverWorkflowModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverWorkflowModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GeneralDraModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.DraModelCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralDraModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralDraModelCustomProperties>
    {
        public GeneralDraModelCustomProperties() { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralDraModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralDraModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralDraModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralDraModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralDraModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralDraModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralDraModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GeneralFabricModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.FabricModelCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralFabricModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralFabricModelCustomProperties>
    {
        public GeneralFabricModelCustomProperties() { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralFabricModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralFabricModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralFabricModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralFabricModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralFabricModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralFabricModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralFabricModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GeneralPlannedFailoverModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralPlannedFailoverModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralPlannedFailoverModelCustomProperties>
    {
        public GeneralPlannedFailoverModelCustomProperties() { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralPlannedFailoverModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralPlannedFailoverModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralPlannedFailoverModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralPlannedFailoverModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralPlannedFailoverModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralPlannedFailoverModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralPlannedFailoverModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GeneralPolicyModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.PolicyModelCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralPolicyModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralPolicyModelCustomProperties>
    {
        public GeneralPolicyModelCustomProperties() { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralPolicyModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralPolicyModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralPolicyModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralPolicyModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralPolicyModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralPolicyModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralPolicyModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GeneralProtectedItemModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralProtectedItemModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralProtectedItemModelCustomProperties>
    {
        public GeneralProtectedItemModelCustomProperties() { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralProtectedItemModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralProtectedItemModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralProtectedItemModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralProtectedItemModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralProtectedItemModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralProtectedItemModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralProtectedItemModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GeneralReplicationExtensionModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationExtensionModelCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralReplicationExtensionModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralReplicationExtensionModelCustomProperties>
    {
        public GeneralReplicationExtensionModelCustomProperties() { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralReplicationExtensionModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralReplicationExtensionModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralReplicationExtensionModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralReplicationExtensionModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralReplicationExtensionModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralReplicationExtensionModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.GeneralReplicationExtensionModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HyperVMigrateFabricModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.FabricModelCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVMigrateFabricModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVMigrateFabricModelCustomProperties>
    {
        public HyperVMigrateFabricModelCustomProperties(Azure.Core.ResourceIdentifier hyperVSiteId, Azure.Core.ResourceIdentifier migrationSolutionId) { }
        public string FabricContainerId { get { throw null; } }
        public Azure.Core.ResourceIdentifier FabricResourceId { get { throw null; } }
        public Azure.Core.ResourceIdentifier HyperVSiteId { get { throw null; } set { } }
        public System.Uri MigrationHubUri { get { throw null; } }
        public Azure.Core.ResourceIdentifier MigrationSolutionId { get { throw null; } set { } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVMigrateFabricModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVMigrateFabricModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVMigrateFabricModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVMigrateFabricModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVMigrateFabricModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVMigrateFabricModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVMigrateFabricModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HyperVToAzStackHciDiskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciDiskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciDiskInput>
    {
        public HyperVToAzStackHciDiskInput(string diskId, long diskSizeGB, string diskFileFormat, bool isOSDisk) { }
        public string DiskFileFormat { get { throw null; } set { } }
        public string DiskId { get { throw null; } set { } }
        public long DiskSizeGB { get { throw null; } set { } }
        public bool? IsDynamic { get { throw null; } set { } }
        public bool IsOSDisk { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier StorageContainerId { get { throw null; } set { } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciDiskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciDiskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciDiskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciDiskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciDiskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciDiskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciDiskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HyperVToAzStackHciEventModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.EventModelCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciEventModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciEventModelCustomProperties>
    {
        internal HyperVToAzStackHciEventModelCustomProperties() { }
        public string EventSourceFriendlyName { get { throw null; } }
        public string ProtectedItemFriendlyName { get { throw null; } }
        public string ServerType { get { throw null; } }
        public string SourceApplianceName { get { throw null; } }
        public string TargetApplianceName { get { throw null; } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciEventModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciEventModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciEventModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciEventModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciEventModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciEventModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciEventModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HyperVToAzStackHciNicInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciNicInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciNicInput>
    {
        public HyperVToAzStackHciNicInput(string nicId, string targetNetworkId, string testNetworkId, Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection selectionTypeForFailover) { }
        public string NetworkName { get { throw null; } }
        public string NicId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection SelectionTypeForFailover { get { throw null; } set { } }
        public string TargetNetworkId { get { throw null; } set { } }
        public string TestNetworkId { get { throw null; } set { } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciNicInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciNicInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciNicInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciNicInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciNicInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciNicInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciNicInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HyperVToAzStackHciPlannedFailoverModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPlannedFailoverModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPlannedFailoverModelCustomProperties>
    {
        public HyperVToAzStackHciPlannedFailoverModelCustomProperties(bool shutdownSourceVm) { }
        public bool ShutdownSourceVm { get { throw null; } set { } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPlannedFailoverModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPlannedFailoverModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPlannedFailoverModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPlannedFailoverModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPlannedFailoverModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPlannedFailoverModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPlannedFailoverModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HyperVToAzStackHciPolicyModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.PolicyModelCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPolicyModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPolicyModelCustomProperties>
    {
        public HyperVToAzStackHciPolicyModelCustomProperties(int recoveryPointHistoryInMinutes, int crashConsistentFrequencyInMinutes, int appConsistentFrequencyInMinutes) { }
        public int AppConsistentFrequencyInMinutes { get { throw null; } set { } }
        public int CrashConsistentFrequencyInMinutes { get { throw null; } set { } }
        public int RecoveryPointHistoryInMinutes { get { throw null; } set { } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPolicyModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPolicyModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPolicyModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPolicyModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPolicyModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPolicyModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciPolicyModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HyperVToAzStackHciProtectedDiskProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedDiskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedDiskProperties>
    {
        internal HyperVToAzStackHciProtectedDiskProperties() { }
        public long? CapacityInBytes { get { throw null; } }
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
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedDiskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedDiskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedDiskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedDiskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedDiskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedDiskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedDiskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HyperVToAzStackHciProtectedItemModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedItemModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedItemModelCustomProperties>
    {
        public HyperVToAzStackHciProtectedItemModelCustomProperties(Azure.Core.ResourceIdentifier targetHciClusterId, Azure.Core.ResourceIdentifier targetArcClusterCustomLocationId, Azure.Core.ResourceIdentifier fabricDiscoveryMachineId, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciDiskInput> disksToInclude, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciNicInput> nicsToInclude, Azure.Core.ResourceIdentifier targetResourceGroupId, Azure.Core.ResourceIdentifier storageContainerId, string hyperVGeneration, string runAsAccountId, string sourceDraName, string targetDraName, string customLocationRegion) { }
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
        public System.DateTimeOffset? LastRecoveryPointReceived { get { throw null; } }
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
        public string SourceDraName { get { throw null; } set { } }
        public double? SourceMemoryInMegaBytes { get { throw null; } }
        public string SourceVmName { get { throw null; } }
        public Azure.Core.ResourceIdentifier StorageContainerId { get { throw null; } set { } }
        public string TargetApplianceName { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetArcClusterCustomLocationId { get { throw null; } set { } }
        public string TargetAzStackHciClusterName { get { throw null; } }
        public int? TargetCpuCores { get { throw null; } set { } }
        public string TargetDraName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetHciClusterId { get { throw null; } set { } }
        public string TargetLocation { get { throw null; } }
        public int? TargetMemoryInMegaBytes { get { throw null; } set { } }
        public string TargetNetworkId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetResourceGroupId { get { throw null; } set { } }
        public string TargetVmBiosId { get { throw null; } }
        public string TargetVmName { get { throw null; } set { } }
        public string TestNetworkId { get { throw null; } set { } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedItemModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedItemModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedItemModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedItemModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedItemModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedItemModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedItemModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedNicProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedNicProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedNicProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedNicProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedNicProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedNicProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciProtectedNicProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HyperVToAzStackHciRecoveryPointModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.RecoveryPointModelCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciRecoveryPointModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciRecoveryPointModelCustomProperties>
    {
        internal HyperVToAzStackHciRecoveryPointModelCustomProperties() { }
        public System.Collections.Generic.IReadOnlyList<string> DiskIds { get { throw null; } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciRecoveryPointModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciRecoveryPointModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciRecoveryPointModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciRecoveryPointModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciRecoveryPointModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciRecoveryPointModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciRecoveryPointModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class HyperVToAzStackHciReplicationExtensionModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationExtensionModelCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciReplicationExtensionModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciReplicationExtensionModelCustomProperties>
    {
        public HyperVToAzStackHciReplicationExtensionModelCustomProperties(Azure.Core.ResourceIdentifier hyperVFabricArmId, Azure.Core.ResourceIdentifier azStackHciFabricArmId) { }
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
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciReplicationExtensionModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciReplicationExtensionModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciReplicationExtensionModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciReplicationExtensionModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciReplicationExtensionModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciReplicationExtensionModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.HyperVToAzStackHciReplicationExtensionModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlannedFailoverModel : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModel>
    {
        public PlannedFailoverModel(Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelProperties properties) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelCustomProperties PlannedFailoverModelCustomProperties { get { throw null; } set { } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class PlannedFailoverModelCustomProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelCustomProperties>
    {
        protected PlannedFailoverModelCustomProperties() { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class PlannedFailoverModelProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelProperties>
    {
        public PlannedFailoverModelProperties(Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelCustomProperties customProperties) { }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelCustomProperties CustomProperties { get { throw null; } set { } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class PolicyModelCustomProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PolicyModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PolicyModelCustomProperties>
    {
        protected PolicyModelCustomProperties() { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.PolicyModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PolicyModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PolicyModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.PolicyModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PolicyModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PolicyModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.PolicyModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemJobProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ProtectedItemModelCustomProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelCustomProperties>
    {
        protected ProtectedItemModelCustomProperties() { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class RecoveryPointModelCustomProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.RecoveryPointModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.RecoveryPointModelCustomProperties>
    {
        protected RecoveryPointModelCustomProperties() { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.RecoveryPointModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.RecoveryPointModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.RecoveryPointModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.RecoveryPointModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.RecoveryPointModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.RecoveryPointModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.RecoveryPointModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public abstract partial class ReplicationExtensionModelCustomProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationExtensionModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationExtensionModelCustomProperties>
    {
        protected ReplicationExtensionModelCustomProperties() { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationExtensionModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationExtensionModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationExtensionModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationExtensionModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationExtensionModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationExtensionModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationExtensionModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class StorageContainerProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.StorageContainerProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.StorageContainerProperties>
    {
        public StorageContainerProperties(string name, string clusterSharedVolumePath) { }
        public string ClusterSharedVolumePath { get { throw null; } set { } }
        public string Name { get { throw null; } set { } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.StorageContainerProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.StorageContainerProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.StorageContainerProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.StorageContainerProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.StorageContainerProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.StorageContainerProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.StorageContainerProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TestFailoverCleanupWorkflowModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowModelCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverCleanupWorkflowModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverCleanupWorkflowModelCustomProperties>
    {
        internal TestFailoverCleanupWorkflowModelCustomProperties() { }
        public string Comments { get { throw null; } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverCleanupWorkflowModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverCleanupWorkflowModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverCleanupWorkflowModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverCleanupWorkflowModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverCleanupWorkflowModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverCleanupWorkflowModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverCleanupWorkflowModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class TestFailoverWorkflowModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowModelCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverWorkflowModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverWorkflowModelCustomProperties>
    {
        internal TestFailoverWorkflowModelCustomProperties() { }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.RecoveryServicesDataReplication.Models.FailoverProtectedItemProperties> ProtectedItemDetails { get { throw null; } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverWorkflowModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverWorkflowModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverWorkflowModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverWorkflowModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverWorkflowModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverWorkflowModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.TestFailoverWorkflowModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public partial class VMwareDraModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.DraModelCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareDraModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareDraModelCustomProperties>
    {
        public VMwareDraModelCustomProperties(string biosId, Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationIdentity marsAuthenticationIdentity) { }
        public string BiosId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.DataReplicationIdentity MarsAuthenticationIdentity { get { throw null; } set { } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareDraModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareDraModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareDraModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareDraModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareDraModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareDraModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareDraModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMwareMigrateFabricModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.FabricModelCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareMigrateFabricModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareMigrateFabricModelCustomProperties>
    {
        public VMwareMigrateFabricModelCustomProperties(Azure.Core.ResourceIdentifier vMwareSiteId, Azure.Core.ResourceIdentifier migrationSolutionId) { }
        public Azure.Core.ResourceIdentifier MigrationSolutionId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VMwareSiteId { get { throw null; } set { } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareMigrateFabricModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareMigrateFabricModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareMigrateFabricModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareMigrateFabricModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareMigrateFabricModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareMigrateFabricModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareMigrateFabricModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMwareToAzStackHciDiskInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciDiskInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciDiskInput>
    {
        public VMwareToAzStackHciDiskInput(string diskId, long diskSizeGB, string diskFileFormat, bool isOSDisk) { }
        public string DiskFileFormat { get { throw null; } set { } }
        public string DiskId { get { throw null; } set { } }
        public long DiskSizeGB { get { throw null; } set { } }
        public bool? IsDynamic { get { throw null; } set { } }
        public bool IsOSDisk { get { throw null; } set { } }
        public string StorageContainerId { get { throw null; } set { } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciDiskInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciDiskInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciDiskInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciDiskInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciDiskInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciDiskInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciDiskInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMwareToAzStackHciNicInput : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciNicInput>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciNicInput>
    {
        public VMwareToAzStackHciNicInput(string nicId, string label, string targetNetworkId, string testNetworkId, Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection selectionTypeForFailover) { }
        public string Label { get { throw null; } set { } }
        public string NetworkName { get { throw null; } }
        public string NicId { get { throw null; } set { } }
        public Azure.ResourceManager.RecoveryServicesDataReplication.Models.VmNicSelection SelectionTypeForFailover { get { throw null; } set { } }
        public string TargetNetworkId { get { throw null; } set { } }
        public string TestNetworkId { get { throw null; } set { } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciNicInput System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciNicInput>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciNicInput>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciNicInput System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciNicInput>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciNicInput>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciNicInput>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMwareToAzStackHciPlannedFailoverModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.PlannedFailoverModelCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPlannedFailoverModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPlannedFailoverModelCustomProperties>
    {
        public VMwareToAzStackHciPlannedFailoverModelCustomProperties(bool shutdownSourceVm) { }
        public bool ShutdownSourceVm { get { throw null; } set { } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPlannedFailoverModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPlannedFailoverModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPlannedFailoverModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPlannedFailoverModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPlannedFailoverModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPlannedFailoverModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPlannedFailoverModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMwareToAzStackHciPolicyModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.PolicyModelCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPolicyModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPolicyModelCustomProperties>
    {
        public VMwareToAzStackHciPolicyModelCustomProperties(int recoveryPointHistoryInMinutes, int crashConsistentFrequencyInMinutes, int appConsistentFrequencyInMinutes) { }
        public int AppConsistentFrequencyInMinutes { get { throw null; } set { } }
        public int CrashConsistentFrequencyInMinutes { get { throw null; } set { } }
        public int RecoveryPointHistoryInMinutes { get { throw null; } set { } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPolicyModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPolicyModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPolicyModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPolicyModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPolicyModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPolicyModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciPolicyModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMwareToAzStackHciProtectedDiskProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedDiskProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedDiskProperties>
    {
        internal VMwareToAzStackHciProtectedDiskProperties() { }
        public long? CapacityInBytes { get { throw null; } }
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
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedDiskProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedDiskProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedDiskProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedDiskProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedDiskProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedDiskProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedDiskProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMwareToAzStackHciProtectedItemModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.ProtectedItemModelCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedItemModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedItemModelCustomProperties>
    {
        public VMwareToAzStackHciProtectedItemModelCustomProperties(Azure.Core.ResourceIdentifier targetHciClusterId, Azure.Core.ResourceIdentifier targetArcClusterCustomLocationId, Azure.Core.ResourceIdentifier storageContainerId, Azure.Core.ResourceIdentifier targetResourceGroupId, string customLocationRegion, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciDiskInput> disksToInclude, System.Collections.Generic.IEnumerable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciNicInput> nicsToInclude, string hyperVGeneration, Azure.Core.ResourceIdentifier fabricDiscoveryMachineId, string runAsAccountId, string sourceDraName, string targetDraName) { }
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
        public System.DateTimeOffset? LastRecoveryPointReceived { get { throw null; } }
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
        public string SourceDraName { get { throw null; } set { } }
        public double? SourceMemoryInMegaBytes { get { throw null; } }
        public string SourceVmName { get { throw null; } }
        public Azure.Core.ResourceIdentifier StorageContainerId { get { throw null; } set { } }
        public string TargetApplianceName { get { throw null; } }
        public Azure.Core.ResourceIdentifier TargetArcClusterCustomLocationId { get { throw null; } set { } }
        public string TargetAzStackHciClusterName { get { throw null; } }
        public int? TargetCpuCores { get { throw null; } set { } }
        public string TargetDraName { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetHciClusterId { get { throw null; } set { } }
        public string TargetLocation { get { throw null; } }
        public int? TargetMemoryInMegaBytes { get { throw null; } set { } }
        public string TargetNetworkId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier TargetResourceGroupId { get { throw null; } set { } }
        public string TargetVmBiosId { get { throw null; } }
        public string TargetVmName { get { throw null; } set { } }
        public string TestNetworkId { get { throw null; } set { } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedItemModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedItemModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedItemModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedItemModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedItemModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedItemModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedItemModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedNicProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedNicProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedNicProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedNicProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedNicProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedNicProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciProtectedNicProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VMwareToAzStackHciReplicationExtensionModelCustomProperties : Azure.ResourceManager.RecoveryServicesDataReplication.Models.ReplicationExtensionModelCustomProperties, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciReplicationExtensionModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciReplicationExtensionModelCustomProperties>
    {
        public VMwareToAzStackHciReplicationExtensionModelCustomProperties(Azure.Core.ResourceIdentifier vmwareFabricArmId, Azure.Core.ResourceIdentifier azStackHciFabricArmId) { }
        public System.Uri AsrServiceUri { get { throw null; } }
        public Azure.Core.ResourceIdentifier AzStackHciFabricArmId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AzStackHciSiteId { get { throw null; } }
        public System.Uri GatewayServiceUri { get { throw null; } }
        public System.Uri RcmServiceUri { get { throw null; } }
        public string ResourceGroup { get { throw null; } }
        public string ResourceLocation { get { throw null; } }
        public string SourceGatewayServiceId { get { throw null; } }
        public string SourceStorageContainerName { get { throw null; } }
        public Azure.Core.ResourceIdentifier StorageAccountId { get { throw null; } set { } }
        public string StorageAccountSasSecretName { get { throw null; } set { } }
        public string SubscriptionId { get { throw null; } }
        public string TargetGatewayServiceId { get { throw null; } }
        public string TargetStorageContainerName { get { throw null; } }
        public Azure.Core.ResourceIdentifier VmwareFabricArmId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier VmwareSiteId { get { throw null; } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciReplicationExtensionModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciReplicationExtensionModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciReplicationExtensionModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciReplicationExtensionModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciReplicationExtensionModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciReplicationExtensionModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.VMwareToAzStackHciReplicationExtensionModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
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
    public abstract partial class WorkflowModelCustomProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowModelCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowModelCustomProperties>
    {
        protected WorkflowModelCustomProperties() { }
        public System.Collections.Generic.IReadOnlyDictionary<string, string> AffectedObjectDetails { get { throw null; } }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowModelCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowModelCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowModelCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowModelCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowModelCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowModelCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowModelCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct WorkflowObjectType : System.IEquatable<Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public WorkflowObjectType(string value) { throw null; }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType AvsDiskPool { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType Dra { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType Fabric { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType Policy { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType ProtectedItem { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType RecoveryPlan { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType ReplicationExtension { get { throw null; } }
        public static Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType Vault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType right) { throw null; }
        public static implicit operator Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType left, Azure.ResourceManager.RecoveryServicesDataReplication.Models.WorkflowObjectType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
