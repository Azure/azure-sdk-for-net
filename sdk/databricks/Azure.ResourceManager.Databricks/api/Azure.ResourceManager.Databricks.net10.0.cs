namespace Azure.ResourceManager.Databricks
{
    public partial class AzureResourceManagerDatabricksContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerDatabricksContext() { }
        public static Azure.ResourceManager.Databricks.AzureResourceManagerDatabricksContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public partial class DatabricksAccessConnectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource>, System.Collections.IEnumerable
    {
        protected DatabricksAccessConnectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.Databricks.DatabricksAccessConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.Databricks.DatabricksAccessConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource> Get(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource>> GetAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource> GetIfExists(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource>> GetIfExistsAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatabricksAccessConnectorData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksAccessConnectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksAccessConnectorData>
    {
        public DatabricksAccessConnectorData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.DatabricksAccessConnectorProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.DatabricksAccessConnectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksAccessConnectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksAccessConnectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.DatabricksAccessConnectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksAccessConnectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksAccessConnectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksAccessConnectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabricksAccessConnectorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksAccessConnectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksAccessConnectorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabricksAccessConnectorResource() { }
        public virtual Azure.ResourceManager.Databricks.DatabricksAccessConnectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string connectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Databricks.DatabricksAccessConnectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksAccessConnectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksAccessConnectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.DatabricksAccessConnectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksAccessConnectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksAccessConnectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksAccessConnectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Databricks.Models.DatabricksAccessConnectorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Databricks.Models.DatabricksAccessConnectorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public static partial class DatabricksExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource> GetDatabricksAccessConnector(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource>> GetDatabricksAccessConnectorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource GetDatabricksAccessConnectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Databricks.DatabricksAccessConnectorCollection GetDatabricksAccessConnectors(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource> GetDatabricksAccessConnectors(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource> GetDatabricksAccessConnectorsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionResource GetDatabricksPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Databricks.DatabricksPrivateLinkResource GetDatabricksPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringResource GetDatabricksVirtualNetworkPeeringResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource> GetDatabricksWorkspace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource>> GetDatabricksWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Databricks.DatabricksWorkspaceResource GetDatabricksWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Databricks.DatabricksWorkspaceCollection GetDatabricksWorkspaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource> GetDatabricksWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource> GetDatabricksWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabricksPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected DatabricksPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatabricksPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData>
    {
        public DatabricksPrivateEndpointConnectionData(Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProperties properties) { }
        public Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabricksPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabricksPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabricksPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabricksPrivateLinkResource() { }
        public virtual Azure.ResourceManager.Databricks.DatabricksPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string groupId) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Databricks.DatabricksPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.DatabricksPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabricksPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected DatabricksPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResource> Get(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResource>> GetAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResource> GetIfExists(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResource>> GetIfExistsAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatabricksPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResourceData>
    {
        internal DatabricksPrivateLinkResourceData() { }
        public Azure.ResourceManager.Databricks.Models.DatabricksGroupIdInformationProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.DatabricksPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.DatabricksPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabricksVirtualNetworkPeeringCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringResource>, System.Collections.IEnumerable
    {
        protected DatabricksVirtualNetworkPeeringCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string peeringName, Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string peeringName, Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string peeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string peeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringResource> Get(string peeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringResource>> GetAsync(string peeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringResource> GetIfExists(string peeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringResource>> GetIfExistsAsync(string peeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatabricksVirtualNetworkPeeringData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringData>
    {
        public DatabricksVirtualNetworkPeeringData() { }
        public bool? AllowForwardedTraffic { get { throw null; } set { } }
        public bool? AllowGatewayTransit { get { throw null; } set { } }
        public bool? AllowVirtualNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DatabricksAddressPrefixes { get { throw null; } }
        public Azure.Core.ResourceIdentifier DatabricksVirtualNetworkId { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.DatabricksVirtualNetworkPeeringState? PeeringState { get { throw null; } }
        public Azure.ResourceManager.Databricks.Models.DatabricksVirtualNetworkPeeringProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<string> RemoteAddressPrefixes { get { throw null; } }
        public Azure.Core.ResourceIdentifier RemoteVirtualNetworkId { get { throw null; } set { } }
        public bool? UseRemoteGateways { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabricksVirtualNetworkPeeringResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabricksVirtualNetworkPeeringResource() { }
        public virtual Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string peeringName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class DatabricksWorkspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource>, System.Collections.IEnumerable
    {
        protected DatabricksWorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.Databricks.DatabricksWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.Databricks.DatabricksWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource> GetIfExists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource>> GetIfExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class DatabricksWorkspaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksWorkspaceData>
    {
        public DatabricksWorkspaceData(Azure.Core.AzureLocation location, Azure.ResourceManager.Databricks.Models.DatabricksComputeMode computeMode) { }
        public Azure.ResourceManager.Databricks.Models.DatabricksWorkspaceAccessConnectorInfo AccessConnector { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Databricks.Models.DatabricksWorkspaceProviderAuthorization> Authorizations { get { throw null; } }
        public Azure.ResourceManager.Databricks.Models.DatabricksComputeMode ComputeMode { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.DatabricksCreatedBy CreatedBy { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Databricks.Models.DatabricksDefaultCatalogProperties DefaultCatalog { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.DatabricksDefaultStorageFirewall? DefaultStorageFirewall { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier DiskEncryptionSetId { get { throw null; } }
        public Azure.ResourceManager.Databricks.Models.DatabricksEncryptionEntities EncryptionEntities { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.DatabricksEnhancedSecurityCompliance EnhancedSecurityCompliance { get { throw null; } set { } }
        public bool? IsUcEnabled { get { throw null; } }
        public Azure.ResourceManager.Databricks.Models.DatabricksManagedIdentityConfiguration ManagedDiskIdentity { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier ManagedResourceGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.WorkspaceCustomProperties Parameters { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Databricks.Models.DatabricksProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Databricks.Models.DatabricksPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.DatabricksRequiredNsgRules? RequiredNsgRules { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.DatabricksSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.DatabricksManagedIdentityConfiguration StorageAccountIdentity { get { throw null; } set { } }
        public string UiDefinitionUri { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.DatabricksCreatedBy UpdatedBy { get { throw null; } set { } }
        public string WorkspaceId { get { throw null; } }
        public string WorkspaceUri { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.DatabricksWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.DatabricksWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabricksWorkspaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksWorkspaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected DatabricksWorkspaceResource() { }
        public virtual Azure.ResourceManager.Databricks.DatabricksWorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, bool? forceDeletion = default(bool?), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionResource> GetDatabricksPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionResource>> GetDatabricksPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionCollection GetDatabricksPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResource> GetDatabricksPrivateLinkResource(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResource>> GetDatabricksPrivateLinkResourceAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Databricks.DatabricksPrivateLinkResourceCollection GetDatabricksPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringResource> GetDatabricksVirtualNetworkPeering(string peeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringResource>> GetDatabricksVirtualNetworkPeeringAsync(string peeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringCollection GetDatabricksVirtualNetworkPeerings() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Databricks.Models.DatabricksOutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Databricks.Models.DatabricksOutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Databricks.DatabricksWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.DatabricksWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Databricks.Models.DatabricksWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Databricks.Models.DatabricksWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Databricks.Mocking
{
    public partial class MockableDatabricksArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDatabricksArmClient() { }
        public virtual Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource GetDatabricksAccessConnectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionResource GetDatabricksPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Databricks.DatabricksPrivateLinkResource GetDatabricksPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringResource GetDatabricksVirtualNetworkPeeringResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Databricks.DatabricksWorkspaceResource GetDatabricksWorkspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDatabricksResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDatabricksResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource> GetDatabricksAccessConnector(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource>> GetDatabricksAccessConnectorAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Databricks.DatabricksAccessConnectorCollection GetDatabricksAccessConnectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource> GetDatabricksWorkspace(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource>> GetDatabricksWorkspaceAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Databricks.DatabricksWorkspaceCollection GetDatabricksWorkspaces() { throw null; }
    }
    public partial class MockableDatabricksSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDatabricksSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource> GetDatabricksAccessConnectors(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Databricks.DatabricksAccessConnectorResource> GetDatabricksAccessConnectorsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource> GetDatabricksWorkspaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource> GetDatabricksWorkspacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Databricks.Models
{
    public static partial class ArmDatabricksModelFactory
    {
        public static Azure.ResourceManager.Databricks.DatabricksAccessConnectorData DatabricksAccessConnectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Databricks.Models.DatabricksAccessConnectorProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksAccessConnectorPatch DatabricksAccessConnectorPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksAccessConnectorProperties DatabricksAccessConnectorProperties(Azure.ResourceManager.Databricks.Models.DatabricksProvisioningState? provisioningState = default(Azure.ResourceManager.Databricks.Models.DatabricksProvisioningState?), System.Collections.Generic.IEnumerable<string> referredBy = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksComplianceSecurityProfile DatabricksComplianceSecurityProfile(System.Collections.Generic.IEnumerable<string> complianceStandards = null, Azure.ResourceManager.Databricks.Models.DatabricksComplianceSecurityProfileValue? value = default(Azure.ResourceManager.Databricks.Models.DatabricksComplianceSecurityProfileValue?)) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksCreatedBy DatabricksCreatedBy(System.Guid? oid = default(System.Guid?), string puid = null, System.Guid? applicationId = default(System.Guid?)) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksDefaultCatalogProperties DatabricksDefaultCatalogProperties(Azure.ResourceManager.Databricks.Models.DatabricksInitialCatalogType? initialType = default(Azure.ResourceManager.Databricks.Models.DatabricksInitialCatalogType?), string initialName = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksEncryption DatabricksEncryption(Azure.ResourceManager.Databricks.Models.DatabricksKeySource? keySource = default(Azure.ResourceManager.Databricks.Models.DatabricksKeySource?), string keyName = null, string keyVersion = null, string keyVaultUri = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksEncryptionEntities DatabricksEncryptionEntities(Azure.ResourceManager.Databricks.Models.DatabricksEncryptionV2 managedServices = null, Azure.ResourceManager.Databricks.Models.DatabricksManagedDiskEncryption managedDisk = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksEncryptionV2 DatabricksEncryptionV2(Azure.ResourceManager.Databricks.Models.DatabricksEncryptionKeySource keySource = default(Azure.ResourceManager.Databricks.Models.DatabricksEncryptionKeySource), Azure.ResourceManager.Databricks.Models.DatabricksEncryptionV2KeyVaultProperties keyVaultProperties = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksEncryptionV2KeyVaultProperties DatabricksEncryptionV2KeyVaultProperties(string keyVaultUri = null, string keyName = null, string keyVersion = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksEndpointDependency DatabricksEndpointDependency(string domainName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Databricks.Models.DatabricksEndpointDetail> endpointDetails = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksEndpointDetail DatabricksEndpointDetail(string ipAddress = null, int? port = default(int?), double? latency = default(double?), bool? isAccessible = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksEnhancedSecurityCompliance DatabricksEnhancedSecurityCompliance(Azure.ResourceManager.Databricks.Models.DatabricksAutomaticClusterUpdateValue? automaticClusterUpdateValue = default(Azure.ResourceManager.Databricks.Models.DatabricksAutomaticClusterUpdateValue?), Azure.ResourceManager.Databricks.Models.DatabricksComplianceSecurityProfile complianceSecurityProfile = null, Azure.ResourceManager.Databricks.Models.DatabricksEnhancedSecurityMonitoringValue? enhancedSecurityMonitoringValue = default(Azure.ResourceManager.Databricks.Models.DatabricksEnhancedSecurityMonitoringValue?)) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksGroupIdInformationProperties DatabricksGroupIdInformationProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksManagedDiskEncryption DatabricksManagedDiskEncryption(Azure.ResourceManager.Databricks.Models.DatabricksEncryptionKeySource keySource = default(Azure.ResourceManager.Databricks.Models.DatabricksEncryptionKeySource), Azure.ResourceManager.Databricks.Models.DatabricksManagedDiskEncryptionKeyVaultProperties keyVaultProperties = null, bool? isRotationToLatestKeyVersionEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksManagedDiskEncryptionKeyVaultProperties DatabricksManagedDiskEncryptionKeyVaultProperties(string keyVaultUri = null, string keyName = null, string keyVersion = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksManagedIdentityConfiguration DatabricksManagedIdentityConfiguration(System.Guid? principalId = default(System.Guid?), System.Guid? tenantId = default(System.Guid?), string type = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksOutboundEnvironmentEndpoint DatabricksOutboundEnvironmentEndpoint(string category = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Databricks.Models.DatabricksEndpointDependency> endpoints = null) { throw null; }
        public static Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData DatabricksPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProperties DatabricksPrivateEndpointConnectionProperties(Azure.Core.ResourceIdentifier privateEndpointId = null, System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Databricks.DatabricksPrivateLinkResourceData DatabricksPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Databricks.Models.DatabricksGroupIdInformationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionState DatabricksPrivateLinkServiceConnectionState(Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionStatus status = default(Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionStatus), string description = null, string actionsRequired = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksSku DatabricksSku(string name = null, string tier = null) { throw null; }
        public static Azure.ResourceManager.Databricks.DatabricksVirtualNetworkPeeringData DatabricksVirtualNetworkPeeringData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, bool? allowVirtualNetworkAccess = default(bool?), bool? allowForwardedTraffic = default(bool?), bool? allowGatewayTransit = default(bool?), bool? useRemoteGateways = default(bool?), Azure.ResourceManager.Databricks.Models.DatabricksVirtualNetworkPeeringState? peeringState = default(Azure.ResourceManager.Databricks.Models.DatabricksVirtualNetworkPeeringState?), Azure.ResourceManager.Databricks.Models.DatabricksVirtualNetworkPeeringProvisioningState? provisioningState = default(Azure.ResourceManager.Databricks.Models.DatabricksVirtualNetworkPeeringProvisioningState?), Azure.Core.ResourceIdentifier databricksVirtualNetworkId = null, System.Collections.Generic.IEnumerable<string> databricksAddressPrefixes = null, Azure.Core.ResourceIdentifier remoteVirtualNetworkId = null, System.Collections.Generic.IEnumerable<string> remoteAddressPrefixes = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksWorkspaceAccessConnectorInfo DatabricksWorkspaceAccessConnectorInfo(Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.Databricks.Models.DatabricksIdentityType identityType = default(Azure.ResourceManager.Databricks.Models.DatabricksIdentityType), Azure.Core.ResourceIdentifier userAssignedIdentityId = null) { throw null; }
        public static Azure.ResourceManager.Databricks.DatabricksWorkspaceData DatabricksWorkspaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Databricks.Models.DatabricksComputeMode computeMode = default(Azure.ResourceManager.Databricks.Models.DatabricksComputeMode), Azure.Core.ResourceIdentifier managedResourceGroupId = null, Azure.ResourceManager.Databricks.Models.WorkspaceCustomProperties parameters = null, Azure.ResourceManager.Databricks.Models.DatabricksProvisioningState? provisioningState = default(Azure.ResourceManager.Databricks.Models.DatabricksProvisioningState?), string uiDefinitionUri = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Databricks.Models.DatabricksWorkspaceProviderAuthorization> authorizations = null, Azure.ResourceManager.Databricks.Models.DatabricksCreatedBy createdBy = null, Azure.ResourceManager.Databricks.Models.DatabricksCreatedBy updatedBy = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string workspaceId = null, string workspaceUri = null, Azure.ResourceManager.Databricks.Models.DatabricksManagedIdentityConfiguration storageAccountIdentity = null, Azure.ResourceManager.Databricks.Models.DatabricksManagedIdentityConfiguration managedDiskIdentity = null, Azure.Core.ResourceIdentifier diskEncryptionSetId = null, Azure.ResourceManager.Databricks.Models.DatabricksEnhancedSecurityCompliance enhancedSecurityCompliance = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.Databricks.Models.DatabricksPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Databricks.Models.DatabricksPublicNetworkAccess?), Azure.ResourceManager.Databricks.Models.DatabricksRequiredNsgRules? requiredNsgRules = default(Azure.ResourceManager.Databricks.Models.DatabricksRequiredNsgRules?), Azure.ResourceManager.Databricks.Models.DatabricksDefaultCatalogProperties defaultCatalog = null, bool? isUcEnabled = default(bool?), Azure.ResourceManager.Databricks.Models.DatabricksWorkspaceAccessConnectorInfo accessConnector = null, Azure.ResourceManager.Databricks.Models.DatabricksDefaultStorageFirewall? defaultStorageFirewall = default(Azure.ResourceManager.Databricks.Models.DatabricksDefaultStorageFirewall?), Azure.ResourceManager.Databricks.Models.DatabricksEncryptionEntities encryptionEntities = null, Azure.ResourceManager.Databricks.Models.DatabricksSku sku = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksWorkspacePatch DatabricksWorkspacePatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksWorkspaceProviderAuthorization DatabricksWorkspaceProviderAuthorization(System.Guid principalId = default(System.Guid), System.Guid roleDefinitionId = default(System.Guid)) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.WorkspaceCustomBooleanParameterValue WorkspaceCustomBooleanParameterValue(Azure.ResourceManager.Databricks.Models.DatabricksCustomParameterType? type = default(Azure.ResourceManager.Databricks.Models.DatabricksCustomParameterType?), bool isEnabled = false) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.WorkspaceCustomObjectParameterValue WorkspaceCustomObjectParameterValue(Azure.ResourceManager.Databricks.Models.DatabricksCustomParameterType? type = default(Azure.ResourceManager.Databricks.Models.DatabricksCustomParameterType?), System.BinaryData value = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.WorkspaceCustomProperties WorkspaceCustomProperties(Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue amlWorkspaceId = null, Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue customVirtualNetworkId = null, Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue customPublicSubnetName = null, Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue customPrivateSubnetName = null, Azure.ResourceManager.Databricks.Models.WorkspaceNoPublicIPBooleanParameterValue enableNoPublicIp = null, Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue loadBalancerBackendPoolName = null, Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue loadBalancerId = null, Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue natGatewayName = null, Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue publicIpName = null, Azure.ResourceManager.Databricks.Models.WorkspaceCustomBooleanParameterValue prepareEncryption = null, Azure.ResourceManager.Databricks.Models.WorkspaceEncryptionParameterValue encryption = null, Azure.ResourceManager.Databricks.Models.WorkspaceCustomBooleanParameterValue requireInfrastructureEncryption = null, Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue storageAccountName = null, Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue storageAccountSkuName = null, Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue vnetAddressPrefix = null, Azure.ResourceManager.Databricks.Models.WorkspaceCustomObjectParameterValue resourceTags = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue WorkspaceCustomStringParameterValue(Azure.ResourceManager.Databricks.Models.DatabricksCustomParameterType? type = default(Azure.ResourceManager.Databricks.Models.DatabricksCustomParameterType?), string value = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.WorkspaceEncryptionParameterValue WorkspaceEncryptionParameterValue(Azure.ResourceManager.Databricks.Models.DatabricksCustomParameterType? type = default(Azure.ResourceManager.Databricks.Models.DatabricksCustomParameterType?), Azure.ResourceManager.Databricks.Models.DatabricksEncryption value = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.WorkspaceNoPublicIPBooleanParameterValue WorkspaceNoPublicIPBooleanParameterValue(Azure.ResourceManager.Databricks.Models.DatabricksCustomParameterType? type = default(Azure.ResourceManager.Databricks.Models.DatabricksCustomParameterType?), bool isEnabled = false) { throw null; }
    }
    public partial class DatabricksAccessConnectorPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksAccessConnectorPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksAccessConnectorPatch>
    {
        public DatabricksAccessConnectorPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksAccessConnectorPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksAccessConnectorPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.DatabricksAccessConnectorPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksAccessConnectorPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksAccessConnectorPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.DatabricksAccessConnectorPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksAccessConnectorPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksAccessConnectorPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksAccessConnectorPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabricksAccessConnectorProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksAccessConnectorProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksAccessConnectorProperties>
    {
        public DatabricksAccessConnectorProperties() { }
        public Azure.ResourceManager.Databricks.Models.DatabricksProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ReferredBy { get { throw null; } }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksAccessConnectorProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksAccessConnectorProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.DatabricksAccessConnectorProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksAccessConnectorProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksAccessConnectorProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.DatabricksAccessConnectorProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksAccessConnectorProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksAccessConnectorProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksAccessConnectorProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabricksAutomaticClusterUpdateValue : System.IEquatable<Azure.ResourceManager.Databricks.Models.DatabricksAutomaticClusterUpdateValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabricksAutomaticClusterUpdateValue(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksAutomaticClusterUpdateValue Disabled { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksAutomaticClusterUpdateValue Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.DatabricksAutomaticClusterUpdateValue other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.DatabricksAutomaticClusterUpdateValue left, Azure.ResourceManager.Databricks.Models.DatabricksAutomaticClusterUpdateValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksAutomaticClusterUpdateValue (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksAutomaticClusterUpdateValue? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.DatabricksAutomaticClusterUpdateValue left, Azure.ResourceManager.Databricks.Models.DatabricksAutomaticClusterUpdateValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabricksComplianceSecurityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksComplianceSecurityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksComplianceSecurityProfile>
    {
        public DatabricksComplianceSecurityProfile() { }
        public System.Collections.Generic.IList<string> ComplianceStandards { get { throw null; } }
        public Azure.ResourceManager.Databricks.Models.DatabricksComplianceSecurityProfileValue? Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksComplianceSecurityProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksComplianceSecurityProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.DatabricksComplianceSecurityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksComplianceSecurityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksComplianceSecurityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.DatabricksComplianceSecurityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksComplianceSecurityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksComplianceSecurityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksComplianceSecurityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabricksComplianceSecurityProfileValue : System.IEquatable<Azure.ResourceManager.Databricks.Models.DatabricksComplianceSecurityProfileValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabricksComplianceSecurityProfileValue(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksComplianceSecurityProfileValue Disabled { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksComplianceSecurityProfileValue Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.DatabricksComplianceSecurityProfileValue other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.DatabricksComplianceSecurityProfileValue left, Azure.ResourceManager.Databricks.Models.DatabricksComplianceSecurityProfileValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksComplianceSecurityProfileValue (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksComplianceSecurityProfileValue? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.DatabricksComplianceSecurityProfileValue left, Azure.ResourceManager.Databricks.Models.DatabricksComplianceSecurityProfileValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabricksComputeMode : System.IEquatable<Azure.ResourceManager.Databricks.Models.DatabricksComputeMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabricksComputeMode(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksComputeMode Hybrid { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksComputeMode Serverless { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.DatabricksComputeMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.DatabricksComputeMode left, Azure.ResourceManager.Databricks.Models.DatabricksComputeMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksComputeMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksComputeMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.DatabricksComputeMode left, Azure.ResourceManager.Databricks.Models.DatabricksComputeMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabricksCreatedBy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksCreatedBy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksCreatedBy>
    {
        public DatabricksCreatedBy() { }
        public System.Guid? ApplicationId { get { throw null; } }
        public System.Guid? Oid { get { throw null; } }
        public string Puid { get { throw null; } }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksCreatedBy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksCreatedBy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.DatabricksCreatedBy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksCreatedBy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksCreatedBy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.DatabricksCreatedBy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksCreatedBy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksCreatedBy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksCreatedBy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabricksCustomParameterType : System.IEquatable<Azure.ResourceManager.Databricks.Models.DatabricksCustomParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabricksCustomParameterType(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksCustomParameterType Bool { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksCustomParameterType Object { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksCustomParameterType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.DatabricksCustomParameterType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.DatabricksCustomParameterType left, Azure.ResourceManager.Databricks.Models.DatabricksCustomParameterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksCustomParameterType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksCustomParameterType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.DatabricksCustomParameterType left, Azure.ResourceManager.Databricks.Models.DatabricksCustomParameterType right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabricksDefaultCatalogProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksDefaultCatalogProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksDefaultCatalogProperties>
    {
        public DatabricksDefaultCatalogProperties() { }
        public string InitialName { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.DatabricksInitialCatalogType? InitialType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksDefaultCatalogProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksDefaultCatalogProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.DatabricksDefaultCatalogProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksDefaultCatalogProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksDefaultCatalogProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.DatabricksDefaultCatalogProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksDefaultCatalogProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksDefaultCatalogProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksDefaultCatalogProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabricksDefaultStorageFirewall : System.IEquatable<Azure.ResourceManager.Databricks.Models.DatabricksDefaultStorageFirewall>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabricksDefaultStorageFirewall(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksDefaultStorageFirewall Disabled { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksDefaultStorageFirewall Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.DatabricksDefaultStorageFirewall other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.DatabricksDefaultStorageFirewall left, Azure.ResourceManager.Databricks.Models.DatabricksDefaultStorageFirewall right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksDefaultStorageFirewall (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksDefaultStorageFirewall? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.DatabricksDefaultStorageFirewall left, Azure.ResourceManager.Databricks.Models.DatabricksDefaultStorageFirewall right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabricksEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksEncryption>
    {
        public DatabricksEncryption() { }
        public string KeyName { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.DatabricksKeySource? KeySource { get { throw null; } set { } }
        public string KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksEncryption JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksEncryption PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.DatabricksEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.DatabricksEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabricksEncryptionEntities : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksEncryptionEntities>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksEncryptionEntities>
    {
        public DatabricksEncryptionEntities() { }
        public Azure.ResourceManager.Databricks.Models.DatabricksManagedDiskEncryption ManagedDisk { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.DatabricksEncryptionV2 ManagedServices { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksEncryptionEntities JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksEncryptionEntities PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.DatabricksEncryptionEntities System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksEncryptionEntities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksEncryptionEntities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.DatabricksEncryptionEntities System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksEncryptionEntities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksEncryptionEntities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksEncryptionEntities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabricksEncryptionKeySource : System.IEquatable<Azure.ResourceManager.Databricks.Models.DatabricksEncryptionKeySource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabricksEncryptionKeySource(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksEncryptionKeySource MicrosoftKeyvault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.DatabricksEncryptionKeySource other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.DatabricksEncryptionKeySource left, Azure.ResourceManager.Databricks.Models.DatabricksEncryptionKeySource right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksEncryptionKeySource (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksEncryptionKeySource? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.DatabricksEncryptionKeySource left, Azure.ResourceManager.Databricks.Models.DatabricksEncryptionKeySource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabricksEncryptionV2 : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksEncryptionV2>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksEncryptionV2>
    {
        public DatabricksEncryptionV2(Azure.ResourceManager.Databricks.Models.DatabricksEncryptionKeySource keySource) { }
        public Azure.ResourceManager.Databricks.Models.DatabricksEncryptionKeySource KeySource { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.DatabricksEncryptionV2KeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksEncryptionV2 JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksEncryptionV2 PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.DatabricksEncryptionV2 System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksEncryptionV2>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksEncryptionV2>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.DatabricksEncryptionV2 System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksEncryptionV2>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksEncryptionV2>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksEncryptionV2>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabricksEncryptionV2KeyVaultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksEncryptionV2KeyVaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksEncryptionV2KeyVaultProperties>
    {
        public DatabricksEncryptionV2KeyVaultProperties(string keyVaultUri, string keyName, string keyVersion) { }
        public string KeyName { get { throw null; } set { } }
        public string KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksEncryptionV2KeyVaultProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksEncryptionV2KeyVaultProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.DatabricksEncryptionV2KeyVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksEncryptionV2KeyVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksEncryptionV2KeyVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.DatabricksEncryptionV2KeyVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksEncryptionV2KeyVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksEncryptionV2KeyVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksEncryptionV2KeyVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabricksEndpointDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksEndpointDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksEndpointDependency>
    {
        internal DatabricksEndpointDependency() { }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Databricks.Models.DatabricksEndpointDetail> EndpointDetails { get { throw null; } }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksEndpointDependency JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksEndpointDependency PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.DatabricksEndpointDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksEndpointDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksEndpointDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.DatabricksEndpointDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksEndpointDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksEndpointDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksEndpointDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabricksEndpointDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksEndpointDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksEndpointDetail>
    {
        internal DatabricksEndpointDetail() { }
        public string IpAddress { get { throw null; } }
        public bool? IsAccessible { get { throw null; } }
        public double? Latency { get { throw null; } }
        public int? Port { get { throw null; } }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksEndpointDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksEndpointDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.DatabricksEndpointDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksEndpointDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksEndpointDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.DatabricksEndpointDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksEndpointDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksEndpointDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksEndpointDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabricksEnhancedSecurityCompliance : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksEnhancedSecurityCompliance>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksEnhancedSecurityCompliance>
    {
        public DatabricksEnhancedSecurityCompliance() { }
        public Azure.ResourceManager.Databricks.Models.DatabricksAutomaticClusterUpdateValue? AutomaticClusterUpdateValue { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.DatabricksComplianceSecurityProfile ComplianceSecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.DatabricksEnhancedSecurityMonitoringValue? EnhancedSecurityMonitoringValue { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksEnhancedSecurityCompliance JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksEnhancedSecurityCompliance PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.DatabricksEnhancedSecurityCompliance System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksEnhancedSecurityCompliance>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksEnhancedSecurityCompliance>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.DatabricksEnhancedSecurityCompliance System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksEnhancedSecurityCompliance>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksEnhancedSecurityCompliance>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksEnhancedSecurityCompliance>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabricksEnhancedSecurityMonitoringValue : System.IEquatable<Azure.ResourceManager.Databricks.Models.DatabricksEnhancedSecurityMonitoringValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabricksEnhancedSecurityMonitoringValue(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksEnhancedSecurityMonitoringValue Disabled { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksEnhancedSecurityMonitoringValue Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.DatabricksEnhancedSecurityMonitoringValue other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.DatabricksEnhancedSecurityMonitoringValue left, Azure.ResourceManager.Databricks.Models.DatabricksEnhancedSecurityMonitoringValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksEnhancedSecurityMonitoringValue (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksEnhancedSecurityMonitoringValue? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.DatabricksEnhancedSecurityMonitoringValue left, Azure.ResourceManager.Databricks.Models.DatabricksEnhancedSecurityMonitoringValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabricksGroupIdInformationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksGroupIdInformationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksGroupIdInformationProperties>
    {
        internal DatabricksGroupIdInformationProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksGroupIdInformationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksGroupIdInformationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.DatabricksGroupIdInformationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksGroupIdInformationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksGroupIdInformationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.DatabricksGroupIdInformationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksGroupIdInformationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksGroupIdInformationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksGroupIdInformationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabricksIdentityType : System.IEquatable<Azure.ResourceManager.Databricks.Models.DatabricksIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabricksIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksIdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksIdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.DatabricksIdentityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.DatabricksIdentityType left, Azure.ResourceManager.Databricks.Models.DatabricksIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksIdentityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksIdentityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.DatabricksIdentityType left, Azure.ResourceManager.Databricks.Models.DatabricksIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabricksInitialCatalogType : System.IEquatable<Azure.ResourceManager.Databricks.Models.DatabricksInitialCatalogType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabricksInitialCatalogType(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksInitialCatalogType HiveMetastore { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksInitialCatalogType UnityCatalog { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.DatabricksInitialCatalogType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.DatabricksInitialCatalogType left, Azure.ResourceManager.Databricks.Models.DatabricksInitialCatalogType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksInitialCatalogType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksInitialCatalogType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.DatabricksInitialCatalogType left, Azure.ResourceManager.Databricks.Models.DatabricksInitialCatalogType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabricksKeySource : System.IEquatable<Azure.ResourceManager.Databricks.Models.DatabricksKeySource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabricksKeySource(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksKeySource Default { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksKeySource MicrosoftKeyvault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.DatabricksKeySource other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.DatabricksKeySource left, Azure.ResourceManager.Databricks.Models.DatabricksKeySource right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksKeySource (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksKeySource? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.DatabricksKeySource left, Azure.ResourceManager.Databricks.Models.DatabricksKeySource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabricksManagedDiskEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksManagedDiskEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksManagedDiskEncryption>
    {
        public DatabricksManagedDiskEncryption(Azure.ResourceManager.Databricks.Models.DatabricksEncryptionKeySource keySource, Azure.ResourceManager.Databricks.Models.DatabricksManagedDiskEncryptionKeyVaultProperties keyVaultProperties) { }
        public bool? IsRotationToLatestKeyVersionEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.DatabricksEncryptionKeySource KeySource { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.DatabricksManagedDiskEncryptionKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksManagedDiskEncryption JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksManagedDiskEncryption PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.DatabricksManagedDiskEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksManagedDiskEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksManagedDiskEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.DatabricksManagedDiskEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksManagedDiskEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksManagedDiskEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksManagedDiskEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabricksManagedDiskEncryptionKeyVaultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksManagedDiskEncryptionKeyVaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksManagedDiskEncryptionKeyVaultProperties>
    {
        public DatabricksManagedDiskEncryptionKeyVaultProperties(string keyVaultUri, string keyName, string keyVersion) { }
        public string KeyName { get { throw null; } set { } }
        public string KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksManagedDiskEncryptionKeyVaultProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksManagedDiskEncryptionKeyVaultProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.DatabricksManagedDiskEncryptionKeyVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksManagedDiskEncryptionKeyVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksManagedDiskEncryptionKeyVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.DatabricksManagedDiskEncryptionKeyVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksManagedDiskEncryptionKeyVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksManagedDiskEncryptionKeyVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksManagedDiskEncryptionKeyVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabricksManagedIdentityConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksManagedIdentityConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksManagedIdentityConfiguration>
    {
        public DatabricksManagedIdentityConfiguration() { }
        public System.Guid? PrincipalId { get { throw null; } }
        public System.Guid? TenantId { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksManagedIdentityConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksManagedIdentityConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.DatabricksManagedIdentityConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksManagedIdentityConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksManagedIdentityConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.DatabricksManagedIdentityConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksManagedIdentityConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksManagedIdentityConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksManagedIdentityConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabricksOutboundEnvironmentEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksOutboundEnvironmentEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksOutboundEnvironmentEndpoint>
    {
        internal DatabricksOutboundEnvironmentEndpoint() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Databricks.Models.DatabricksEndpointDependency> Endpoints { get { throw null; } }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksOutboundEnvironmentEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksOutboundEnvironmentEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.DatabricksOutboundEnvironmentEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksOutboundEnvironmentEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksOutboundEnvironmentEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.DatabricksOutboundEnvironmentEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksOutboundEnvironmentEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksOutboundEnvironmentEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksOutboundEnvironmentEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabricksPrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProperties>
    {
        public DatabricksPrivateEndpointConnectionProperties(Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionState privateLinkServiceConnectionState) { }
        public System.Collections.Generic.IList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabricksPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabricksPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabricksPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionState>
    {
        public DatabricksPrivateLinkServiceConnectionState(Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionStatus status) { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionStatus Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabricksPrivateLinkServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabricksPrivateLinkServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionStatus left, Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionStatus left, Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabricksProvisioningState : System.IEquatable<Azure.ResourceManager.Databricks.Models.DatabricksProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabricksProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksProvisioningState Ready { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.DatabricksProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.DatabricksProvisioningState left, Azure.ResourceManager.Databricks.Models.DatabricksProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.DatabricksProvisioningState left, Azure.ResourceManager.Databricks.Models.DatabricksProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabricksPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Databricks.Models.DatabricksPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabricksPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.DatabricksPublicNetworkAccess other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.DatabricksPublicNetworkAccess left, Azure.ResourceManager.Databricks.Models.DatabricksPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksPublicNetworkAccess (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksPublicNetworkAccess? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.DatabricksPublicNetworkAccess left, Azure.ResourceManager.Databricks.Models.DatabricksPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabricksRequiredNsgRules : System.IEquatable<Azure.ResourceManager.Databricks.Models.DatabricksRequiredNsgRules>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabricksRequiredNsgRules(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksRequiredNsgRules AllRules { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksRequiredNsgRules NoAzureDatabricksRules { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksRequiredNsgRules NoAzureServiceRules { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.DatabricksRequiredNsgRules other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.DatabricksRequiredNsgRules left, Azure.ResourceManager.Databricks.Models.DatabricksRequiredNsgRules right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksRequiredNsgRules (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksRequiredNsgRules? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.DatabricksRequiredNsgRules left, Azure.ResourceManager.Databricks.Models.DatabricksRequiredNsgRules right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabricksSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksSku>
    {
        public DatabricksSku(string name) { }
        public string Name { get { throw null; } set { } }
        public string Tier { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.DatabricksSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.DatabricksSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabricksVirtualNetworkPeeringProvisioningState : System.IEquatable<Azure.ResourceManager.Databricks.Models.DatabricksVirtualNetworkPeeringProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabricksVirtualNetworkPeeringProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksVirtualNetworkPeeringProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksVirtualNetworkPeeringProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksVirtualNetworkPeeringProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksVirtualNetworkPeeringProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.DatabricksVirtualNetworkPeeringProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.DatabricksVirtualNetworkPeeringProvisioningState left, Azure.ResourceManager.Databricks.Models.DatabricksVirtualNetworkPeeringProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksVirtualNetworkPeeringProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksVirtualNetworkPeeringProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.DatabricksVirtualNetworkPeeringProvisioningState left, Azure.ResourceManager.Databricks.Models.DatabricksVirtualNetworkPeeringProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DatabricksVirtualNetworkPeeringState : System.IEquatable<Azure.ResourceManager.Databricks.Models.DatabricksVirtualNetworkPeeringState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DatabricksVirtualNetworkPeeringState(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksVirtualNetworkPeeringState Connected { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksVirtualNetworkPeeringState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DatabricksVirtualNetworkPeeringState Initiated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.DatabricksVirtualNetworkPeeringState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.DatabricksVirtualNetworkPeeringState left, Azure.ResourceManager.Databricks.Models.DatabricksVirtualNetworkPeeringState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksVirtualNetworkPeeringState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DatabricksVirtualNetworkPeeringState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.DatabricksVirtualNetworkPeeringState left, Azure.ResourceManager.Databricks.Models.DatabricksVirtualNetworkPeeringState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class DatabricksWorkspaceAccessConnectorInfo : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksWorkspaceAccessConnectorInfo>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksWorkspaceAccessConnectorInfo>
    {
        public DatabricksWorkspaceAccessConnectorInfo(Azure.Core.ResourceIdentifier id, Azure.ResourceManager.Databricks.Models.DatabricksIdentityType identityType) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.DatabricksIdentityType IdentityType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentityId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksWorkspaceAccessConnectorInfo JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksWorkspaceAccessConnectorInfo PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.DatabricksWorkspaceAccessConnectorInfo System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksWorkspaceAccessConnectorInfo>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksWorkspaceAccessConnectorInfo>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.DatabricksWorkspaceAccessConnectorInfo System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksWorkspaceAccessConnectorInfo>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksWorkspaceAccessConnectorInfo>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksWorkspaceAccessConnectorInfo>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabricksWorkspacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksWorkspacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksWorkspacePatch>
    {
        public DatabricksWorkspacePatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksWorkspacePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksWorkspacePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.DatabricksWorkspacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksWorkspacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksWorkspacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.DatabricksWorkspacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksWorkspacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksWorkspacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksWorkspacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class DatabricksWorkspaceProviderAuthorization : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksWorkspaceProviderAuthorization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksWorkspaceProviderAuthorization>
    {
        public DatabricksWorkspaceProviderAuthorization(System.Guid principalId, System.Guid roleDefinitionId) { }
        public System.Guid PrincipalId { get { throw null; } set { } }
        public System.Guid RoleDefinitionId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksWorkspaceProviderAuthorization JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.DatabricksWorkspaceProviderAuthorization PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.DatabricksWorkspaceProviderAuthorization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksWorkspaceProviderAuthorization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DatabricksWorkspaceProviderAuthorization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.DatabricksWorkspaceProviderAuthorization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksWorkspaceProviderAuthorization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksWorkspaceProviderAuthorization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DatabricksWorkspaceProviderAuthorization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceCustomBooleanParameterValue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.WorkspaceCustomBooleanParameterValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspaceCustomBooleanParameterValue>
    {
        public WorkspaceCustomBooleanParameterValue(bool isEnabled) { }
        public bool IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.DatabricksCustomParameterType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Databricks.Models.WorkspaceCustomBooleanParameterValue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.WorkspaceCustomBooleanParameterValue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.WorkspaceCustomBooleanParameterValue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.WorkspaceCustomBooleanParameterValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.WorkspaceCustomBooleanParameterValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.WorkspaceCustomBooleanParameterValue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspaceCustomBooleanParameterValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspaceCustomBooleanParameterValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspaceCustomBooleanParameterValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceCustomObjectParameterValue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.WorkspaceCustomObjectParameterValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspaceCustomObjectParameterValue>
    {
        internal WorkspaceCustomObjectParameterValue() { }
        public Azure.ResourceManager.Databricks.Models.DatabricksCustomParameterType? Type { get { throw null; } }
        public System.BinaryData Value { get { throw null; } }
        protected virtual Azure.ResourceManager.Databricks.Models.WorkspaceCustomObjectParameterValue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.WorkspaceCustomObjectParameterValue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.WorkspaceCustomObjectParameterValue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.WorkspaceCustomObjectParameterValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.WorkspaceCustomObjectParameterValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.WorkspaceCustomObjectParameterValue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspaceCustomObjectParameterValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspaceCustomObjectParameterValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspaceCustomObjectParameterValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceCustomProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.WorkspaceCustomProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspaceCustomProperties>
    {
        public WorkspaceCustomProperties() { }
        public Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue AmlWorkspaceId { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue CustomPrivateSubnetName { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue CustomPublicSubnetName { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue CustomVirtualNetworkId { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.WorkspaceNoPublicIPBooleanParameterValue EnableNoPublicIp { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.WorkspaceEncryptionParameterValue Encryption { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue LoadBalancerBackendPoolName { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue LoadBalancerId { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue NatGatewayName { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.WorkspaceCustomBooleanParameterValue PrepareEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue PublicIpName { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.WorkspaceCustomBooleanParameterValue RequireInfrastructureEncryption { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.WorkspaceCustomObjectParameterValue ResourceTags { get { throw null; } }
        public Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue StorageAccountName { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue StorageAccountSkuName { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue VnetAddressPrefix { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Databricks.Models.WorkspaceCustomProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.WorkspaceCustomProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.WorkspaceCustomProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.WorkspaceCustomProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.WorkspaceCustomProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.WorkspaceCustomProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspaceCustomProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspaceCustomProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspaceCustomProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceCustomStringParameterValue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue>
    {
        public WorkspaceCustomStringParameterValue(string value) { }
        public Azure.ResourceManager.Databricks.Models.DatabricksCustomParameterType? Type { get { throw null; } set { } }
        public string Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceEncryptionParameterValue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.WorkspaceEncryptionParameterValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspaceEncryptionParameterValue>
    {
        public WorkspaceEncryptionParameterValue() { }
        public Azure.ResourceManager.Databricks.Models.DatabricksCustomParameterType? Type { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.DatabricksEncryption Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Databricks.Models.WorkspaceEncryptionParameterValue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.WorkspaceEncryptionParameterValue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.WorkspaceEncryptionParameterValue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.WorkspaceEncryptionParameterValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.WorkspaceEncryptionParameterValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.WorkspaceEncryptionParameterValue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspaceEncryptionParameterValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspaceEncryptionParameterValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspaceEncryptionParameterValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceNoPublicIPBooleanParameterValue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.WorkspaceNoPublicIPBooleanParameterValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspaceNoPublicIPBooleanParameterValue>
    {
        public WorkspaceNoPublicIPBooleanParameterValue(bool isEnabled) { }
        public bool IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.DatabricksCustomParameterType? Type { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Databricks.Models.WorkspaceNoPublicIPBooleanParameterValue JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.WorkspaceNoPublicIPBooleanParameterValue PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.WorkspaceNoPublicIPBooleanParameterValue System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.WorkspaceNoPublicIPBooleanParameterValue>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.WorkspaceNoPublicIPBooleanParameterValue>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.WorkspaceNoPublicIPBooleanParameterValue System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspaceNoPublicIPBooleanParameterValue>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspaceNoPublicIPBooleanParameterValue>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspaceNoPublicIPBooleanParameterValue>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
