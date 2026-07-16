namespace Azure.ResourceManager.SreAgent
{
    public partial class AgentConnectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SreAgent.AgentConnectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SreAgent.AgentConnectorResource>, System.Collections.IEnumerable
    {
        protected AgentConnectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SreAgent.AgentConnectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.SreAgent.AgentConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SreAgent.AgentConnectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.SreAgent.AgentConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SreAgent.AgentConnectorResource> Get(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SreAgent.AgentConnectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SreAgent.AgentConnectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SreAgent.AgentConnectorResource>> GetAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SreAgent.AgentConnectorResource> GetIfExists(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SreAgent.AgentConnectorResource>> GetIfExistsAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SreAgent.AgentConnectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SreAgent.AgentConnectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SreAgent.AgentConnectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SreAgent.AgentConnectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AgentConnectorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.AgentConnectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.AgentConnectorData>
    {
        public AgentConnectorData() { }
        public Azure.ResourceManager.SreAgent.Models.AgentConnectorProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SreAgent.AgentConnectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.AgentConnectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.AgentConnectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.AgentConnectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.AgentConnectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.AgentConnectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.AgentConnectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentConnectorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.AgentConnectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.AgentConnectorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AgentConnectorResource() { }
        public virtual Azure.ResourceManager.SreAgent.AgentConnectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string agentName, string connectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SreAgent.AgentConnectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SreAgent.AgentConnectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SreAgent.AgentConnectorResource> GetSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SreAgent.AgentConnectorResource>> GetSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.SreAgent.AgentConnectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.AgentConnectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.AgentConnectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.AgentConnectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.AgentConnectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.AgentConnectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.AgentConnectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SreAgent.AgentConnectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SreAgent.AgentConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SreAgent.AgentConnectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SreAgent.AgentConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AgentSpaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SreAgent.AgentSpaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SreAgent.AgentSpaceResource>, System.Collections.IEnumerable
    {
        protected AgentSpaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SreAgent.AgentSpaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string agentSpaceName, Azure.ResourceManager.SreAgent.AgentSpaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SreAgent.AgentSpaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string agentSpaceName, Azure.ResourceManager.SreAgent.AgentSpaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string agentSpaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string agentSpaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SreAgent.AgentSpaceResource> Get(string agentSpaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SreAgent.AgentSpaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SreAgent.AgentSpaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SreAgent.AgentSpaceResource>> GetAsync(string agentSpaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SreAgent.AgentSpaceResource> GetIfExists(string agentSpaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SreAgent.AgentSpaceResource>> GetIfExistsAsync(string agentSpaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SreAgent.AgentSpaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SreAgent.AgentSpaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SreAgent.AgentSpaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SreAgent.AgentSpaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AgentSpaceConnectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SreAgent.AgentSpaceConnectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SreAgent.AgentSpaceConnectorResource>, System.Collections.IEnumerable
    {
        protected AgentSpaceConnectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SreAgent.AgentSpaceConnectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.SreAgent.AgentSpaceConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SreAgent.AgentSpaceConnectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.SreAgent.AgentSpaceConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SreAgent.AgentSpaceConnectorResource> Get(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SreAgent.AgentSpaceConnectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SreAgent.AgentSpaceConnectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SreAgent.AgentSpaceConnectorResource>> GetAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SreAgent.AgentSpaceConnectorResource> GetIfExists(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SreAgent.AgentSpaceConnectorResource>> GetIfExistsAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SreAgent.AgentSpaceConnectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SreAgent.AgentSpaceConnectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SreAgent.AgentSpaceConnectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SreAgent.AgentSpaceConnectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AgentSpaceConnectorData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.AgentSpaceConnectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.AgentSpaceConnectorData>
    {
        public AgentSpaceConnectorData() { }
        public Azure.ResourceManager.SreAgent.Models.AgentSpaceConnectorProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SreAgent.AgentSpaceConnectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.AgentSpaceConnectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.AgentSpaceConnectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.AgentSpaceConnectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.AgentSpaceConnectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.AgentSpaceConnectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.AgentSpaceConnectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentSpaceConnectorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.AgentSpaceConnectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.AgentSpaceConnectorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AgentSpaceConnectorResource() { }
        public virtual Azure.ResourceManager.SreAgent.AgentSpaceConnectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string agentSpaceName, string connectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SreAgent.AgentSpaceConnectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SreAgent.AgentSpaceConnectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SreAgent.AgentSpaceConnectorResource> GetSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SreAgent.AgentSpaceConnectorResource>> GetSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.SreAgent.AgentSpaceConnectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.AgentSpaceConnectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.AgentSpaceConnectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.AgentSpaceConnectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.AgentSpaceConnectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.AgentSpaceConnectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.AgentSpaceConnectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SreAgent.AgentSpaceConnectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SreAgent.AgentSpaceConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SreAgent.AgentSpaceConnectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SreAgent.AgentSpaceConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AgentSpaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.AgentSpaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.AgentSpaceData>
    {
        public AgentSpaceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.SreAgent.Models.AgentSpaceProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SreAgent.AgentSpaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.AgentSpaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.AgentSpaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.AgentSpaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.AgentSpaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.AgentSpaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.AgentSpaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentSpaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.AgentSpaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.AgentSpaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AgentSpaceResource() { }
        public virtual Azure.ResourceManager.SreAgent.AgentSpaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.SreAgent.AgentSpaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SreAgent.AgentSpaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string agentSpaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SreAgent.AgentSpaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SreAgent.AgentSpaceConnectorResource> GetAgentSpaceConnector(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SreAgent.AgentSpaceConnectorResource>> GetAgentSpaceConnectorAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SreAgent.AgentSpaceConnectorCollection GetAgentSpaceConnectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SreAgent.Models.AgentSpaceConnectorList> GetAllSecrets(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SreAgent.Models.AgentSpaceConnectorList>> GetAllSecretsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SreAgent.AgentSpaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SreAgent.AgentSpaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SreAgent.AgentSpaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SreAgent.AgentSpaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SreAgent.AgentSpaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.SreAgent.AgentSpaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.AgentSpaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.AgentSpaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.AgentSpaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.AgentSpaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.AgentSpaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.AgentSpaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SreAgent.AgentSpaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SreAgent.Models.AgentSpacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SreAgent.AgentSpaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SreAgent.Models.AgentSpacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerSreAgentContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerSreAgentContext() { }
        public static Azure.ResourceManager.SreAgent.AzureResourceManagerSreAgentContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class SreAgentCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SreAgent.SreAgentResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SreAgent.SreAgentResource>, System.Collections.IEnumerable
    {
        protected SreAgentCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SreAgent.SreAgentResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string agentName, Azure.ResourceManager.SreAgent.SreAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SreAgent.SreAgentResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string agentName, Azure.ResourceManager.SreAgent.SreAgentData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SreAgent.SreAgentResource> Get(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SreAgent.SreAgentResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SreAgent.SreAgentResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SreAgent.SreAgentResource>> GetAsync(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.SreAgent.SreAgentResource> GetIfExists(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.SreAgent.SreAgentResource>> GetIfExistsAsync(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.SreAgent.SreAgentResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.SreAgent.SreAgentResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.SreAgent.SreAgentResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.SreAgent.SreAgentResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class SreAgentData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.SreAgentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.SreAgentData>
    {
        public SreAgentData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.SreAgent.Models.AgentProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SreAgent.SreAgentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.SreAgentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.SreAgentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.SreAgentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.SreAgentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.SreAgentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.SreAgentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class SreAgentExtensions
    {
        public static Azure.ResourceManager.SreAgent.AgentConnectorResource GetAgentConnectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SreAgent.AgentSpaceResource> GetAgentSpace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string agentSpaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SreAgent.AgentSpaceResource>> GetAgentSpaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string agentSpaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SreAgent.AgentSpaceConnectorResource GetAgentSpaceConnectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SreAgent.AgentSpaceResource GetAgentSpaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SreAgent.AgentSpaceCollection GetAgentSpaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SreAgent.AgentSpaceResource> GetAgentSpaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SreAgent.AgentSpaceResource> GetAgentSpacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SreAgent.Models.SupportedAgentModel> GetByLocation(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SreAgent.Models.SupportedAgentModel> GetByLocationAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Response<Azure.ResourceManager.SreAgent.SreAgentResource> GetSreAgent(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SreAgent.SreAgentResource>> GetSreAgentAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.SreAgent.SreAgentResource GetSreAgentResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.SreAgent.SreAgentCollection GetSreAgents(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.SreAgent.SreAgentResource> GetSreAgents(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.SreAgent.SreAgentResource> GetSreAgentsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class SreAgentResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.SreAgentData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.SreAgentData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected SreAgentResource() { }
        public virtual Azure.ResourceManager.SreAgent.SreAgentData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.SreAgent.SreAgentResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SreAgent.SreAgentResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string agentName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SreAgent.SreAgentResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SreAgent.AgentConnectorResource> GetAgentConnector(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SreAgent.AgentConnectorResource>> GetAgentConnectorAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SreAgent.AgentConnectorCollection GetAgentConnectors() { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SreAgent.SreAgentResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SreAgent.Models.AgentConnectorList> GetWithSecretsByAgent(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SreAgent.Models.AgentConnectorList>> GetWithSecretsByAgentAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SreAgent.SreAgentResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SreAgent.SreAgentResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SreAgent.SreAgentResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SreAgent.SreAgentResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SreAgent.SreAgentResource> Start(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SreAgent.SreAgentResource>> StartAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SreAgent.SreAgentResource> Stop(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SreAgent.SreAgentResource>> StopAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.SreAgent.SreAgentData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.SreAgentData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.SreAgentData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.SreAgentData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.SreAgentData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.SreAgentData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.SreAgentData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SreAgent.SreAgentResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.SreAgent.Models.SreAgentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.SreAgent.SreAgentResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.SreAgent.Models.SreAgentPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SreAgent.Mocking
{
    public partial class MockableSreAgentArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableSreAgentArmClient() { }
        public virtual Azure.ResourceManager.SreAgent.AgentConnectorResource GetAgentConnectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SreAgent.AgentSpaceConnectorResource GetAgentSpaceConnectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SreAgent.AgentSpaceResource GetAgentSpaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.SreAgent.SreAgentResource GetSreAgentResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableSreAgentResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSreAgentResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.SreAgent.AgentSpaceResource> GetAgentSpace(string agentSpaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SreAgent.AgentSpaceResource>> GetAgentSpaceAsync(string agentSpaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SreAgent.AgentSpaceCollection GetAgentSpaces() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.SreAgent.SreAgentResource> GetSreAgent(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.SreAgent.SreAgentResource>> GetSreAgentAsync(string agentName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.SreAgent.SreAgentCollection GetSreAgents() { throw null; }
    }
    public partial class MockableSreAgentSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableSreAgentSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.SreAgent.AgentSpaceResource> GetAgentSpaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SreAgent.AgentSpaceResource> GetAgentSpacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SreAgent.Models.SupportedAgentModel> GetByLocation(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SreAgent.Models.SupportedAgentModel> GetByLocationAsync(Azure.Core.AzureLocation location, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.SreAgent.SreAgentResource> GetSreAgents(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.SreAgent.SreAgentResource> GetSreAgentsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.SreAgent.Models
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentAccessLevel : System.IEquatable<Azure.ResourceManager.SreAgent.Models.AgentAccessLevel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentAccessLevel(string value) { throw null; }
        public static Azure.ResourceManager.SreAgent.Models.AgentAccessLevel High { get { throw null; } }
        public static Azure.ResourceManager.SreAgent.Models.AgentAccessLevel Low { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SreAgent.Models.AgentAccessLevel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SreAgent.Models.AgentAccessLevel left, Azure.ResourceManager.SreAgent.Models.AgentAccessLevel right) { throw null; }
        public static implicit operator Azure.ResourceManager.SreAgent.Models.AgentAccessLevel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SreAgent.Models.AgentAccessLevel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SreAgent.Models.AgentAccessLevel left, Azure.ResourceManager.SreAgent.Models.AgentAccessLevel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentActionConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentActionConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentActionConfiguration>
    {
        public AgentActionConfiguration() { }
        public Azure.ResourceManager.SreAgent.Models.AgentAccessLevel? AccessLevel { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier Identity { get { throw null; } set { } }
        public Azure.ResourceManager.SreAgent.Models.AgentMode? Mode { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.SreAgent.Models.AgentActionConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SreAgent.Models.AgentActionConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SreAgent.Models.AgentActionConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentActionConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentActionConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.Models.AgentActionConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentActionConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentActionConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentActionConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentConnectorList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentConnectorList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentConnectorList>
    {
        internal AgentConnectorList() { }
        public System.Uri NextLink { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SreAgent.AgentConnectorData> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.SreAgent.Models.AgentConnectorList JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SreAgent.Models.AgentConnectorList PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SreAgent.Models.AgentConnectorList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentConnectorList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentConnectorList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.Models.AgentConnectorList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentConnectorList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentConnectorList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentConnectorList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentConnectorProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentConnectorProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentConnectorProperties>
    {
        public AgentConnectorProperties() { }
        public string DataConnectorType { get { throw null; } set { } }
        public string DataSource { get { throw null; } set { } }
        public string DeploymentError { get { throw null; } }
        public System.Uri Endpoint { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ExtendedProperties { get { throw null; } }
        public Azure.Core.ResourceIdentifier Identity { get { throw null; } set { } }
        public Azure.ResourceManager.SreAgent.Models.AgentConnectorProvisioningState? ProvisioningState { get { throw null; } }
        public string Source { get { throw null; } }
        protected virtual Azure.ResourceManager.SreAgent.Models.AgentConnectorProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SreAgent.Models.AgentConnectorProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SreAgent.Models.AgentConnectorProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentConnectorProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentConnectorProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.Models.AgentConnectorProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentConnectorProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentConnectorProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentConnectorProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentConnectorProvisioningState : System.IEquatable<Azure.ResourceManager.SreAgent.Models.AgentConnectorProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentConnectorProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.SreAgent.Models.AgentConnectorProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.SreAgent.Models.AgentConnectorProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.SreAgent.Models.AgentConnectorProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.SreAgent.Models.AgentConnectorProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.SreAgent.Models.AgentConnectorProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SreAgent.Models.AgentConnectorProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SreAgent.Models.AgentConnectorProvisioningState left, Azure.ResourceManager.SreAgent.Models.AgentConnectorProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SreAgent.Models.AgentConnectorProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SreAgent.Models.AgentConnectorProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SreAgent.Models.AgentConnectorProvisioningState left, Azure.ResourceManager.SreAgent.Models.AgentConnectorProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentIdentity>
    {
        public AgentIdentity(string initialSponsorGroupId) { }
        public System.Guid? ClientId { get { throw null; } }
        public string InitialSponsorGroupId { get { throw null; } set { } }
        public bool? IsEnabled { get { throw null; } }
        protected virtual Azure.ResourceManager.SreAgent.Models.AgentIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SreAgent.Models.AgentIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SreAgent.Models.AgentIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.Models.AgentIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentIncidentManagementConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentIncidentManagementConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentIncidentManagementConfiguration>
    {
        public AgentIncidentManagementConfiguration() { }
        public string ConnectionKey { get { throw null; } set { } }
        public string ConnectionName { get { throw null; } set { } }
        public string ConnectionUri { get { throw null; } set { } }
        public string OboUser { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.SreAgent.Models.AgentIncidentManagementConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SreAgent.Models.AgentIncidentManagementConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SreAgent.Models.AgentIncidentManagementConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentIncidentManagementConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentIncidentManagementConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.Models.AgentIncidentManagementConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentIncidentManagementConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentIncidentManagementConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentIncidentManagementConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentKnowledgeGraphConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentKnowledgeGraphConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentKnowledgeGraphConfiguration>
    {
        public AgentKnowledgeGraphConfiguration() { }
        public Azure.Core.ResourceIdentifier Identity { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.Core.ResourceIdentifier> ManagedResources { get { throw null; } }
        protected virtual Azure.ResourceManager.SreAgent.Models.AgentKnowledgeGraphConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SreAgent.Models.AgentKnowledgeGraphConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SreAgent.Models.AgentKnowledgeGraphConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentKnowledgeGraphConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentKnowledgeGraphConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.Models.AgentKnowledgeGraphConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentKnowledgeGraphConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentKnowledgeGraphConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentKnowledgeGraphConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentMode : System.IEquatable<Azure.ResourceManager.SreAgent.Models.AgentMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentMode(string value) { throw null; }
        public static Azure.ResourceManager.SreAgent.Models.AgentMode Autonomous { get { throw null; } }
        public static Azure.ResourceManager.SreAgent.Models.AgentMode ReadOnly { get { throw null; } }
        public static Azure.ResourceManager.SreAgent.Models.AgentMode Review { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SreAgent.Models.AgentMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SreAgent.Models.AgentMode left, Azure.ResourceManager.SreAgent.Models.AgentMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.SreAgent.Models.AgentMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SreAgent.Models.AgentMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SreAgent.Models.AgentMode left, Azure.ResourceManager.SreAgent.Models.AgentMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentPatchProperties>
    {
        public AgentPatchProperties() { }
        public Azure.ResourceManager.SreAgent.Models.AgentActionConfiguration ActionConfiguration { get { throw null; } set { } }
        public string AgentIdentityInitialSponsorGroupId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AgentSpaceId { get { throw null; } set { } }
        public Azure.ResourceManager.SreAgent.Models.SreAgentDefaultModel DefaultModel { get { throw null; } set { } }
        public Azure.ResourceManager.SreAgent.Models.AgentIncidentManagementConfiguration IncidentManagementConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.SreAgent.Models.AgentKnowledgeGraphConfiguration KnowledgeGraphConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.SreAgent.Models.ApplicationInsightsConfiguration LogApplicationInsightsConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.SreAgent.Models.AgentUpgradeChannel? UpgradeChannel { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.SreAgent.Models.AgentPatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SreAgent.Models.AgentPatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SreAgent.Models.AgentPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.Models.AgentPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentPowerState : System.IEquatable<Azure.ResourceManager.SreAgent.Models.AgentPowerState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentPowerState(string value) { throw null; }
        public static Azure.ResourceManager.SreAgent.Models.AgentPowerState Running { get { throw null; } }
        public static Azure.ResourceManager.SreAgent.Models.AgentPowerState Stopped { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SreAgent.Models.AgentPowerState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SreAgent.Models.AgentPowerState left, Azure.ResourceManager.SreAgent.Models.AgentPowerState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SreAgent.Models.AgentPowerState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SreAgent.Models.AgentPowerState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SreAgent.Models.AgentPowerState left, Azure.ResourceManager.SreAgent.Models.AgentPowerState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentProperties>
    {
        public AgentProperties() { }
        public Azure.ResourceManager.SreAgent.Models.AgentActionConfiguration ActionConfiguration { get { throw null; } set { } }
        public string AgentEndpoint { get { throw null; } }
        public Azure.ResourceManager.SreAgent.Models.AgentIdentity AgentIdentity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier AgentSpaceId { get { throw null; } set { } }
        public Azure.ResourceManager.SreAgent.Models.SreAgentDefaultModel DefaultModel { get { throw null; } set { } }
        public Azure.ResourceManager.SreAgent.Models.AgentIncidentManagementConfiguration IncidentManagementConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.SreAgent.Models.AgentKnowledgeGraphConfiguration KnowledgeGraphConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.SreAgent.Models.ApplicationInsightsConfiguration LogApplicationInsightsConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.SreAgent.Models.AgentPowerState? PowerState { get { throw null; } }
        public Azure.ResourceManager.SreAgent.Models.AgentProvisioningState? ProvisioningState { get { throw null; } }
        public string RunningState { get { throw null; } }
        public Azure.ResourceManager.SreAgent.Models.AgentUpgradeChannel? UpgradeChannel { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.SreAgent.Models.AgentProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SreAgent.Models.AgentProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SreAgent.Models.AgentProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.Models.AgentProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentProvisioningState : System.IEquatable<Azure.ResourceManager.SreAgent.Models.AgentProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.SreAgent.Models.AgentProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.SreAgent.Models.AgentProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.SreAgent.Models.AgentProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.SreAgent.Models.AgentProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.SreAgent.Models.AgentProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SreAgent.Models.AgentProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SreAgent.Models.AgentProvisioningState left, Azure.ResourceManager.SreAgent.Models.AgentProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SreAgent.Models.AgentProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SreAgent.Models.AgentProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SreAgent.Models.AgentProvisioningState left, Azure.ResourceManager.SreAgent.Models.AgentProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class AgentSpaceComplianceStatus : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentSpaceComplianceStatus>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentSpaceComplianceStatus>
    {
        internal AgentSpaceComplianceStatus() { }
        public System.Collections.Generic.IReadOnlyList<string> ComplianceIssues { get { throw null; } }
        public bool IsCompliant { get { throw null; } }
        public System.DateTimeOffset? LastComplianceCheckOn { get { throw null; } }
        protected virtual Azure.ResourceManager.SreAgent.Models.AgentSpaceComplianceStatus JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SreAgent.Models.AgentSpaceComplianceStatus PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SreAgent.Models.AgentSpaceComplianceStatus System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentSpaceComplianceStatus>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentSpaceComplianceStatus>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.Models.AgentSpaceComplianceStatus System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentSpaceComplianceStatus>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentSpaceComplianceStatus>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentSpaceComplianceStatus>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentSpaceConnectorList : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentSpaceConnectorList>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentSpaceConnectorList>
    {
        internal AgentSpaceConnectorList() { }
        public System.Uri NextLink { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SreAgent.AgentSpaceConnectorData> Value { get { throw null; } }
        protected virtual Azure.ResourceManager.SreAgent.Models.AgentSpaceConnectorList JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SreAgent.Models.AgentSpaceConnectorList PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SreAgent.Models.AgentSpaceConnectorList System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentSpaceConnectorList>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentSpaceConnectorList>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.Models.AgentSpaceConnectorList System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentSpaceConnectorList>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentSpaceConnectorList>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentSpaceConnectorList>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentSpaceConnectorProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentSpaceConnectorProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentSpaceConnectorProperties>
    {
        public AgentSpaceConnectorProperties() { }
        public string DataConnectorType { get { throw null; } set { } }
        public string DataSource { get { throw null; } set { } }
        public string DeploymentError { get { throw null; } }
        public System.Uri Endpoint { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, System.BinaryData> ExtendedProperties { get { throw null; } }
        public Azure.Core.ResourceIdentifier Identity { get { throw null; } set { } }
        public Azure.ResourceManager.SreAgent.Models.AgentConnectorProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.SreAgent.Models.AgentSpaceConnectorProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SreAgent.Models.AgentSpaceConnectorProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SreAgent.Models.AgentSpaceConnectorProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentSpaceConnectorProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentSpaceConnectorProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.Models.AgentSpaceConnectorProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentSpaceConnectorProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentSpaceConnectorProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentSpaceConnectorProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentSpacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentSpacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentSpacePatch>
    {
        public AgentSpacePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.SreAgent.Models.AgentSpacePatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.SreAgent.Models.AgentSpacePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SreAgent.Models.AgentSpacePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SreAgent.Models.AgentSpacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentSpacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentSpacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.Models.AgentSpacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentSpacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentSpacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentSpacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentSpacePatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentSpacePatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentSpacePatchProperties>
    {
        public AgentSpacePatchProperties() { }
        public string Description { get { throw null; } set { } }
        public int? MaxAgentCount { get { throw null; } set { } }
        public Azure.ResourceManager.SreAgent.Models.GenevaActionsPolicyPatch PoliciesGenevaActionsConfiguration { get { throw null; } set { } }
        public string ServiceTreeId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.SreAgent.Models.AgentSpacePatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SreAgent.Models.AgentSpacePatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SreAgent.Models.AgentSpacePatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentSpacePatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentSpacePatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.Models.AgentSpacePatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentSpacePatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentSpacePatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentSpacePatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AgentSpaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentSpaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentSpaceProperties>
    {
        public AgentSpaceProperties() { }
        public Azure.ResourceManager.SreAgent.Models.AgentSpaceComplianceStatus ComplianceStatus { get { throw null; } }
        public int? CurrentAgentCount { get { throw null; } }
        public string Description { get { throw null; } set { } }
        public System.DateTimeOffset? LastPolicyPropagation { get { throw null; } }
        public int? MaxAgentCount { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<string> MemberAgents { get { throw null; } }
        public Azure.ResourceManager.SreAgent.Models.GenevaActionsPolicy PoliciesGenevaActionsConfiguration { get { throw null; } set { } }
        public Azure.ResourceManager.SreAgent.Models.AgentSpaceProvisioningState? ProvisioningState { get { throw null; } }
        public string ServiceTreeId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.SreAgent.Models.AgentSpaceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SreAgent.Models.AgentSpaceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SreAgent.Models.AgentSpaceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentSpaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.AgentSpaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.Models.AgentSpaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentSpaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentSpaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.AgentSpaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentSpaceProvisioningState : System.IEquatable<Azure.ResourceManager.SreAgent.Models.AgentSpaceProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentSpaceProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.SreAgent.Models.AgentSpaceProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.SreAgent.Models.AgentSpaceProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.SreAgent.Models.AgentSpaceProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.SreAgent.Models.AgentSpaceProvisioningState InProgress { get { throw null; } }
        public static Azure.ResourceManager.SreAgent.Models.AgentSpaceProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SreAgent.Models.AgentSpaceProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SreAgent.Models.AgentSpaceProvisioningState left, Azure.ResourceManager.SreAgent.Models.AgentSpaceProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.SreAgent.Models.AgentSpaceProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SreAgent.Models.AgentSpaceProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SreAgent.Models.AgentSpaceProvisioningState left, Azure.ResourceManager.SreAgent.Models.AgentSpaceProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AgentUpgradeChannel : System.IEquatable<Azure.ResourceManager.SreAgent.Models.AgentUpgradeChannel>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AgentUpgradeChannel(string value) { throw null; }
        public static Azure.ResourceManager.SreAgent.Models.AgentUpgradeChannel Preview { get { throw null; } }
        public static Azure.ResourceManager.SreAgent.Models.AgentUpgradeChannel Stable { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SreAgent.Models.AgentUpgradeChannel other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SreAgent.Models.AgentUpgradeChannel left, Azure.ResourceManager.SreAgent.Models.AgentUpgradeChannel right) { throw null; }
        public static implicit operator Azure.ResourceManager.SreAgent.Models.AgentUpgradeChannel (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SreAgent.Models.AgentUpgradeChannel? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SreAgent.Models.AgentUpgradeChannel left, Azure.ResourceManager.SreAgent.Models.AgentUpgradeChannel right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ApplicationInsightsConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.ApplicationInsightsConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.ApplicationInsightsConfiguration>
    {
        public ApplicationInsightsConfiguration() { }
        public System.Guid? AppId { get { throw null; } set { } }
        public string ConnectionString { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.SreAgent.Models.ApplicationInsightsConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SreAgent.Models.ApplicationInsightsConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SreAgent.Models.ApplicationInsightsConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.ApplicationInsightsConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.ApplicationInsightsConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.Models.ApplicationInsightsConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.ApplicationInsightsConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.ApplicationInsightsConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.ApplicationInsightsConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmSreAgentModelFactory
    {
        public static Azure.ResourceManager.SreAgent.Models.AgentActionConfiguration AgentActionConfiguration(Azure.Core.ResourceIdentifier identity = null, Azure.ResourceManager.SreAgent.Models.AgentMode? mode = default(Azure.ResourceManager.SreAgent.Models.AgentMode?), Azure.ResourceManager.SreAgent.Models.AgentAccessLevel? accessLevel = default(Azure.ResourceManager.SreAgent.Models.AgentAccessLevel?)) { throw null; }
        public static Azure.ResourceManager.SreAgent.AgentConnectorData AgentConnectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.SreAgent.Models.AgentConnectorProperties properties = null) { throw null; }
        public static Azure.ResourceManager.SreAgent.Models.AgentConnectorList AgentConnectorList(System.Collections.Generic.IEnumerable<Azure.ResourceManager.SreAgent.AgentConnectorData> value = null, System.Uri nextLink = null) { throw null; }
        public static Azure.ResourceManager.SreAgent.Models.AgentConnectorProperties AgentConnectorProperties(System.Uri endpoint = null, string dataSource = null, Azure.Core.ResourceIdentifier identity = null, Azure.ResourceManager.SreAgent.Models.AgentConnectorProvisioningState? provisioningState = default(Azure.ResourceManager.SreAgent.Models.AgentConnectorProvisioningState?), string deploymentError = null, System.Collections.Generic.IDictionary<string, System.BinaryData> extendedProperties = null, string dataConnectorType = null, string source = null) { throw null; }
        public static Azure.ResourceManager.SreAgent.Models.AgentIdentity AgentIdentity(bool? isEnabled = default(bool?), System.Guid? clientId = default(System.Guid?), string initialSponsorGroupId = null) { throw null; }
        public static Azure.ResourceManager.SreAgent.Models.AgentIncidentManagementConfiguration AgentIncidentManagementConfiguration(string type = null, string connectionName = null, string connectionUri = null, string connectionKey = null, string oboUser = null) { throw null; }
        public static Azure.ResourceManager.SreAgent.Models.AgentKnowledgeGraphConfiguration AgentKnowledgeGraphConfiguration(Azure.Core.ResourceIdentifier identity = null, System.Collections.Generic.IEnumerable<Azure.Core.ResourceIdentifier> managedResources = null) { throw null; }
        public static Azure.ResourceManager.SreAgent.Models.AgentPatchProperties AgentPatchProperties(Azure.Core.ResourceIdentifier agentSpaceId = null, Azure.ResourceManager.SreAgent.Models.AgentKnowledgeGraphConfiguration knowledgeGraphConfiguration = null, Azure.ResourceManager.SreAgent.Models.AgentActionConfiguration actionConfiguration = null, Azure.ResourceManager.SreAgent.Models.ApplicationInsightsConfiguration logApplicationInsightsConfiguration = null, Azure.ResourceManager.SreAgent.Models.AgentIncidentManagementConfiguration incidentManagementConfiguration = null, Azure.ResourceManager.SreAgent.Models.AgentUpgradeChannel? upgradeChannel = default(Azure.ResourceManager.SreAgent.Models.AgentUpgradeChannel?), string agentIdentityInitialSponsorGroupId = null, Azure.ResourceManager.SreAgent.Models.SreAgentDefaultModel defaultModel = null) { throw null; }
        public static Azure.ResourceManager.SreAgent.Models.AgentProperties AgentProperties(Azure.ResourceManager.SreAgent.Models.AgentProvisioningState? provisioningState = default(Azure.ResourceManager.SreAgent.Models.AgentProvisioningState?), string agentEndpoint = null, string runningState = null, Azure.ResourceManager.SreAgent.Models.AgentPowerState? powerState = default(Azure.ResourceManager.SreAgent.Models.AgentPowerState?), Azure.Core.ResourceIdentifier agentSpaceId = null, Azure.ResourceManager.SreAgent.Models.AgentKnowledgeGraphConfiguration knowledgeGraphConfiguration = null, Azure.ResourceManager.SreAgent.Models.AgentActionConfiguration actionConfiguration = null, Azure.ResourceManager.SreAgent.Models.ApplicationInsightsConfiguration logApplicationInsightsConfiguration = null, Azure.ResourceManager.SreAgent.Models.AgentIncidentManagementConfiguration incidentManagementConfiguration = null, Azure.ResourceManager.SreAgent.Models.AgentUpgradeChannel? upgradeChannel = default(Azure.ResourceManager.SreAgent.Models.AgentUpgradeChannel?), Azure.ResourceManager.SreAgent.Models.AgentIdentity agentIdentity = null, Azure.ResourceManager.SreAgent.Models.SreAgentDefaultModel defaultModel = null) { throw null; }
        public static Azure.ResourceManager.SreAgent.Models.AgentSpaceComplianceStatus AgentSpaceComplianceStatus(bool isCompliant = false, System.Collections.Generic.IEnumerable<string> complianceIssues = null, System.DateTimeOffset? lastComplianceCheckOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.SreAgent.AgentSpaceConnectorData AgentSpaceConnectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.SreAgent.Models.AgentSpaceConnectorProperties properties = null) { throw null; }
        public static Azure.ResourceManager.SreAgent.Models.AgentSpaceConnectorList AgentSpaceConnectorList(System.Collections.Generic.IEnumerable<Azure.ResourceManager.SreAgent.AgentSpaceConnectorData> value = null, System.Uri nextLink = null) { throw null; }
        public static Azure.ResourceManager.SreAgent.Models.AgentSpaceConnectorProperties AgentSpaceConnectorProperties(System.Uri endpoint = null, string dataSource = null, Azure.Core.ResourceIdentifier identity = null, Azure.ResourceManager.SreAgent.Models.AgentConnectorProvisioningState? provisioningState = default(Azure.ResourceManager.SreAgent.Models.AgentConnectorProvisioningState?), string deploymentError = null, System.Collections.Generic.IDictionary<string, System.BinaryData> extendedProperties = null, string dataConnectorType = null) { throw null; }
        public static Azure.ResourceManager.SreAgent.AgentSpaceData AgentSpaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.SreAgent.Models.AgentSpaceProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.SreAgent.Models.AgentSpacePatch AgentSpacePatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.SreAgent.Models.AgentSpacePatchProperties properties = null) { throw null; }
        public static Azure.ResourceManager.SreAgent.Models.AgentSpacePatchProperties AgentSpacePatchProperties(string description = null, Azure.ResourceManager.SreAgent.Models.GenevaActionsPolicyPatch policiesGenevaActionsConfiguration = null, int? maxAgentCount = default(int?), string serviceTreeId = null) { throw null; }
        public static Azure.ResourceManager.SreAgent.Models.AgentSpaceProperties AgentSpaceProperties(Azure.ResourceManager.SreAgent.Models.AgentSpaceProvisioningState? provisioningState = default(Azure.ResourceManager.SreAgent.Models.AgentSpaceProvisioningState?), int? currentAgentCount = default(int?), System.Collections.Generic.IEnumerable<string> memberAgents = null, System.DateTimeOffset? lastPolicyPropagation = default(System.DateTimeOffset?), Azure.ResourceManager.SreAgent.Models.AgentSpaceComplianceStatus complianceStatus = null, string description = null, Azure.ResourceManager.SreAgent.Models.GenevaActionsPolicy policiesGenevaActionsConfiguration = null, int? maxAgentCount = default(int?), string serviceTreeId = null) { throw null; }
        public static Azure.ResourceManager.SreAgent.Models.ApplicationInsightsConfiguration ApplicationInsightsConfiguration(System.Guid? appId = default(System.Guid?), string connectionString = null) { throw null; }
        public static Azure.ResourceManager.SreAgent.Models.GenevaActionConfig GenevaActionConfig(string actionName = null, string extension = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SreAgent.Models.GenevaActionParameterInfo> actionParameters = null, bool? isApprovalRequired = default(bool?)) { throw null; }
        public static Azure.ResourceManager.SreAgent.Models.GenevaActionParameterInfo GenevaActionParameterInfo(string name = null, string type = null) { throw null; }
        public static Azure.ResourceManager.SreAgent.Models.GenevaActionsPolicy GenevaActionsPolicy(System.Uri acisEndpoint = null, System.Guid? clientId = default(System.Guid?), string certificateSubjectName = null, Azure.ResourceManager.SreAgent.Models.GenevaActionAuthenticationMode? authenticationMode = default(Azure.ResourceManager.SreAgent.Models.GenevaActionAuthenticationMode?), string extensionName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SreAgent.Models.GenevaActionConfig> allowedActions = null, string certificateSubjectAlternativeName = null) { throw null; }
        public static Azure.ResourceManager.SreAgent.Models.GenevaActionsPolicyPatch GenevaActionsPolicyPatch(System.Uri acisEndpoint = null, System.Guid? clientId = default(System.Guid?), string certificateSubjectName = null, Azure.ResourceManager.SreAgent.Models.GenevaActionAuthenticationMode? authenticationMode = default(Azure.ResourceManager.SreAgent.Models.GenevaActionAuthenticationMode?), string extensionName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.SreAgent.Models.GenevaActionConfig> allowedActions = null) { throw null; }
        public static Azure.ResourceManager.SreAgent.SreAgentData SreAgentData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.SreAgent.Models.AgentProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.SreAgent.Models.SreAgentDefaultModel SreAgentDefaultModel(string provider = null, string name = null) { throw null; }
        public static Azure.ResourceManager.SreAgent.Models.SreAgentPatch SreAgentPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.SreAgent.Models.AgentPatchProperties properties = null) { throw null; }
        public static Azure.ResourceManager.SreAgent.Models.SupportedAgentModel SupportedAgentModel(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.SreAgent.Models.SupportedAgentModelProperties properties = null) { throw null; }
        public static Azure.ResourceManager.SreAgent.Models.SupportedAgentModelProperties SupportedAgentModelProperties(string provider = null, string providerDisplayName = null, string model = null, string modelDisplayName = null, string multiplier = null, bool isDefault = false) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GenevaActionAuthenticationMode : System.IEquatable<Azure.ResourceManager.SreAgent.Models.GenevaActionAuthenticationMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GenevaActionAuthenticationMode(string value) { throw null; }
        public static Azure.ResourceManager.SreAgent.Models.GenevaActionAuthenticationMode OAuth { get { throw null; } }
        public static Azure.ResourceManager.SreAgent.Models.GenevaActionAuthenticationMode WSTrust { get { throw null; } }
        public bool Equals(Azure.ResourceManager.SreAgent.Models.GenevaActionAuthenticationMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.SreAgent.Models.GenevaActionAuthenticationMode left, Azure.ResourceManager.SreAgent.Models.GenevaActionAuthenticationMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.SreAgent.Models.GenevaActionAuthenticationMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.SreAgent.Models.GenevaActionAuthenticationMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.SreAgent.Models.GenevaActionAuthenticationMode left, Azure.ResourceManager.SreAgent.Models.GenevaActionAuthenticationMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GenevaActionConfig : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.GenevaActionConfig>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.GenevaActionConfig>
    {
        public GenevaActionConfig() { }
        public string ActionName { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SreAgent.Models.GenevaActionParameterInfo> ActionParameters { get { throw null; } }
        public string Extension { get { throw null; } set { } }
        public bool? IsApprovalRequired { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.SreAgent.Models.GenevaActionConfig JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SreAgent.Models.GenevaActionConfig PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SreAgent.Models.GenevaActionConfig System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.GenevaActionConfig>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.GenevaActionConfig>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.Models.GenevaActionConfig System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.GenevaActionConfig>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.GenevaActionConfig>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.GenevaActionConfig>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GenevaActionParameterInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.GenevaActionParameterInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.GenevaActionParameterInfo>
    {
        public GenevaActionParameterInfo() { }
        public string Name { get { throw null; } set { } }
        public string Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.SreAgent.Models.GenevaActionParameterInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SreAgent.Models.GenevaActionParameterInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SreAgent.Models.GenevaActionParameterInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.GenevaActionParameterInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.GenevaActionParameterInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.Models.GenevaActionParameterInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.GenevaActionParameterInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.GenevaActionParameterInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.GenevaActionParameterInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GenevaActionsPolicy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.GenevaActionsPolicy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.GenevaActionsPolicy>
    {
        public GenevaActionsPolicy(string extensionName) { }
        public System.Uri AcisEndpoint { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SreAgent.Models.GenevaActionConfig> AllowedActions { get { throw null; } }
        public Azure.ResourceManager.SreAgent.Models.GenevaActionAuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string CertificateSubjectAlternativeName { get { throw null; } }
        public string CertificateSubjectName { get { throw null; } set { } }
        public System.Guid? ClientId { get { throw null; } set { } }
        public string ExtensionName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.SreAgent.Models.GenevaActionsPolicy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SreAgent.Models.GenevaActionsPolicy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SreAgent.Models.GenevaActionsPolicy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.GenevaActionsPolicy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.GenevaActionsPolicy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.Models.GenevaActionsPolicy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.GenevaActionsPolicy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.GenevaActionsPolicy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.GenevaActionsPolicy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GenevaActionsPolicyPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.GenevaActionsPolicyPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.GenevaActionsPolicyPatch>
    {
        public GenevaActionsPolicyPatch() { }
        public System.Uri AcisEndpoint { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.SreAgent.Models.GenevaActionConfig> AllowedActions { get { throw null; } }
        public Azure.ResourceManager.SreAgent.Models.GenevaActionAuthenticationMode? AuthenticationMode { get { throw null; } set { } }
        public string CertificateSubjectName { get { throw null; } set { } }
        public System.Guid? ClientId { get { throw null; } set { } }
        public string ExtensionName { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.SreAgent.Models.GenevaActionsPolicyPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SreAgent.Models.GenevaActionsPolicyPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SreAgent.Models.GenevaActionsPolicyPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.GenevaActionsPolicyPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.GenevaActionsPolicyPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.Models.GenevaActionsPolicyPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.GenevaActionsPolicyPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.GenevaActionsPolicyPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.GenevaActionsPolicyPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SreAgentDefaultModel : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.SreAgentDefaultModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.SreAgentDefaultModel>
    {
        public SreAgentDefaultModel() { }
        public string Name { get { throw null; } set { } }
        public string Provider { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.SreAgent.Models.SreAgentDefaultModel JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SreAgent.Models.SreAgentDefaultModel PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SreAgent.Models.SreAgentDefaultModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.SreAgentDefaultModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.SreAgentDefaultModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.Models.SreAgentDefaultModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.SreAgentDefaultModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.SreAgentDefaultModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.SreAgentDefaultModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SreAgentPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.SreAgentPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.SreAgentPatch>
    {
        public SreAgentPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.SreAgent.Models.AgentPatchProperties Properties { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.SreAgent.Models.SreAgentPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SreAgent.Models.SreAgentPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SreAgent.Models.SreAgentPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.SreAgentPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.SreAgentPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.Models.SreAgentPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.SreAgentPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.SreAgentPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.SreAgentPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupportedAgentModel : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.SupportedAgentModel>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.SupportedAgentModel>
    {
        internal SupportedAgentModel() { }
        public Azure.ResourceManager.SreAgent.Models.SupportedAgentModelProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SreAgent.Models.SupportedAgentModel System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.SupportedAgentModel>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.SupportedAgentModel>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.Models.SupportedAgentModel System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.SupportedAgentModel>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.SupportedAgentModel>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.SupportedAgentModel>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SupportedAgentModelProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.SupportedAgentModelProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.SupportedAgentModelProperties>
    {
        internal SupportedAgentModelProperties() { }
        public bool IsDefault { get { throw null; } }
        public string Model { get { throw null; } }
        public string ModelDisplayName { get { throw null; } }
        public string Multiplier { get { throw null; } }
        public string Provider { get { throw null; } }
        public string ProviderDisplayName { get { throw null; } }
        protected virtual Azure.ResourceManager.SreAgent.Models.SupportedAgentModelProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.SreAgent.Models.SupportedAgentModelProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.SreAgent.Models.SupportedAgentModelProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.SupportedAgentModelProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SreAgent.Models.SupportedAgentModelProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SreAgent.Models.SupportedAgentModelProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.SupportedAgentModelProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.SupportedAgentModelProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SreAgent.Models.SupportedAgentModelProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
