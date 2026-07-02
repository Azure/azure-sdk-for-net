namespace Azure.ResourceManager.Databricks
{
    public partial class AccessConnectorCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Databricks.AccessConnectorResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Databricks.AccessConnectorResource>, System.Collections.IEnumerable
    {
        protected AccessConnectorCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Databricks.AccessConnectorResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.Databricks.AccessConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Databricks.AccessConnectorResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string connectorName, Azure.ResourceManager.Databricks.AccessConnectorData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.AccessConnectorResource> Get(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Databricks.AccessConnectorResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Databricks.AccessConnectorResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.AccessConnectorResource>> GetAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Databricks.AccessConnectorResource> GetIfExists(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Databricks.AccessConnectorResource>> GetIfExistsAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Databricks.AccessConnectorResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Databricks.AccessConnectorResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Databricks.AccessConnectorResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Databricks.AccessConnectorResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class AccessConnectorData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.AccessConnectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.AccessConnectorData>
    {
        public AccessConnectorData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.AccessConnectorProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.AccessConnectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.AccessConnectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.AccessConnectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.AccessConnectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.AccessConnectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.AccessConnectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.AccessConnectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessConnectorResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.AccessConnectorData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.AccessConnectorData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected AccessConnectorResource() { }
        public virtual Azure.ResourceManager.Databricks.AccessConnectorData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.AccessConnectorResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.AccessConnectorResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string connectorName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.AccessConnectorResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.AccessConnectorResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.AccessConnectorResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.AccessConnectorResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.AccessConnectorResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.AccessConnectorResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Databricks.AccessConnectorData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.AccessConnectorData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.AccessConnectorData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.AccessConnectorData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.AccessConnectorData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.AccessConnectorData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.AccessConnectorData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Databricks.AccessConnectorResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Databricks.Models.AccessConnectorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Databricks.AccessConnectorResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Databricks.Models.AccessConnectorPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class AzureResourceManagerDatabricksContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerDatabricksContext() { }
        public static Azure.ResourceManager.Databricks.AzureResourceManagerDatabricksContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class DatabricksExtensions
    {
        public static Azure.Response<Azure.ResourceManager.Databricks.AccessConnectorResource> GetAccessConnector(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.AccessConnectorResource>> GetAccessConnectorAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Databricks.AccessConnectorResource GetAccessConnectorResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Databricks.AccessConnectorCollection GetAccessConnectors(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Databricks.AccessConnectorResource> GetAccessConnectors(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Databricks.AccessConnectorResource> GetAccessConnectorsAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Databricks.DatabricksPrivateLinkResource GetDatabricksPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource> GetDatabricksWorkspace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource>> GetDatabricksWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Databricks.DatabricksWorkspaceResource GetDatabricksWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Databricks.DatabricksWorkspaceCollection GetDatabricksWorkspaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource> GetDatabricksWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource> GetDatabricksWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Databricks.PrivateEndpointConnectionResource GetPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Databricks.VirtualNetworkPeeringResource GetVirtualNetworkPeeringResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class DatabricksPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData>
    {
        public DatabricksPrivateEndpointConnectionData(Azure.ResourceManager.Databricks.Models.PrivateEndpointConnectionProperties properties) { }
        public Azure.ResourceManager.Databricks.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
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
        public Azure.ResourceManager.Databricks.Models.GroupIdInformationProperties Properties { get { throw null; } }
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
        public DatabricksWorkspaceData(Azure.Core.AzureLocation location, Azure.ResourceManager.Databricks.Models.ComputeMode computeMode) { }
        public Azure.ResourceManager.Databricks.Models.WorkspacePropertiesAccessConnector AccessConnector { get { throw null; } set { } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Databricks.Models.WorkspaceProviderAuthorization> Authorizations { get { throw null; } }
        public Azure.ResourceManager.Databricks.Models.ComputeMode ComputeMode { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.CreatedBy CreatedBy { get { throw null; } set { } }
        public System.DateTimeOffset? CreatedOn { get { throw null; } }
        public Azure.ResourceManager.Databricks.Models.DefaultCatalogProperties DefaultCatalog { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.DefaultStorageFirewall? DefaultStorageFirewall { get { throw null; } set { } }
        public string DiskEncryptionSetId { get { throw null; } }
        public Azure.ResourceManager.Databricks.Models.EncryptionEntities EncryptionEntities { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.EnhancedSecurityCompliance EnhancedSecurityCompliance { get { throw null; } set { } }
        public bool? IsUcEnabled { get { throw null; } }
        public Azure.ResourceManager.Databricks.Models.ManagedIdentityConfiguration ManagedDiskIdentity { get { throw null; } set { } }
        public string ManagedResourceGroupId { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.WorkspaceCustomProperties Parameters { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Databricks.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Databricks.Models.PublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.RequiredNsgRules? RequiredNsgRules { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.DatabricksSku Sku { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.ManagedIdentityConfiguration StorageAccountIdentity { get { throw null; } set { } }
        public string UiDefinitionUri { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.CreatedBy UpdatedBy { get { throw null; } set { } }
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
        public virtual Azure.Response<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResource> GetDatabricksPrivateLinkResource(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.DatabricksPrivateLinkResource>> GetDatabricksPrivateLinkResourceAsync(string groupId, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Databricks.DatabricksPrivateLinkResourceCollection GetDatabricksPrivateLinkResources() { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Databricks.Models.OutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpoints(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Databricks.Models.OutboundEnvironmentEndpoint> GetOutboundNetworkDependenciesEndpointsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.PrivateEndpointConnectionResource> GetPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.PrivateEndpointConnectionResource>> GetPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Databricks.PrivateEndpointConnectionCollection GetPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.VirtualNetworkPeeringResource> GetVirtualNetworkPeering(string peeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.VirtualNetworkPeeringResource>> GetVirtualNetworkPeeringAsync(string peeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Databricks.VirtualNetworkPeeringCollection GetVirtualNetworkPeerings() { throw null; }
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
    public partial class PrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Databricks.PrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Databricks.PrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected PrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Databricks.PrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Databricks.PrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.PrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Databricks.PrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Databricks.PrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.PrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Databricks.PrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Databricks.PrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Databricks.PrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Databricks.PrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Databricks.PrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Databricks.PrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class PrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected PrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.PrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.PrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Databricks.PrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Databricks.PrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class VirtualNetworkPeeringCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Databricks.VirtualNetworkPeeringResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Databricks.VirtualNetworkPeeringResource>, System.Collections.IEnumerable
    {
        protected VirtualNetworkPeeringCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Databricks.VirtualNetworkPeeringResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string peeringName, Azure.ResourceManager.Databricks.VirtualNetworkPeeringData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Databricks.VirtualNetworkPeeringResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string peeringName, Azure.ResourceManager.Databricks.VirtualNetworkPeeringData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string peeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string peeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.VirtualNetworkPeeringResource> Get(string peeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Databricks.VirtualNetworkPeeringResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Databricks.VirtualNetworkPeeringResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.VirtualNetworkPeeringResource>> GetAsync(string peeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Databricks.VirtualNetworkPeeringResource> GetIfExists(string peeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Databricks.VirtualNetworkPeeringResource>> GetIfExistsAsync(string peeringName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Databricks.VirtualNetworkPeeringResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Databricks.VirtualNetworkPeeringResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Databricks.VirtualNetworkPeeringResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Databricks.VirtualNetworkPeeringResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class VirtualNetworkPeeringData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.VirtualNetworkPeeringData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.VirtualNetworkPeeringData>
    {
        public VirtualNetworkPeeringData() { }
        public bool? AllowForwardedTraffic { get { throw null; } set { } }
        public bool? AllowGatewayTransit { get { throw null; } set { } }
        public bool? AllowVirtualNetworkAccess { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> DatabricksAddressPrefixes { get { throw null; } }
        public string DatabricksVirtualNetworkId { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.PeeringState? PeeringState { get { throw null; } }
        public Azure.ResourceManager.Databricks.Models.PeeringProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IList<string> RemoteAddressPrefixes { get { throw null; } }
        public string RemoteVirtualNetworkId { get { throw null; } set { } }
        public bool? UseRemoteGateways { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.VirtualNetworkPeeringData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.VirtualNetworkPeeringData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.VirtualNetworkPeeringData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.VirtualNetworkPeeringData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.VirtualNetworkPeeringData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.VirtualNetworkPeeringData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.VirtualNetworkPeeringData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class VirtualNetworkPeeringResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.VirtualNetworkPeeringData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.VirtualNetworkPeeringData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected VirtualNetworkPeeringResource() { }
        public virtual Azure.ResourceManager.Databricks.VirtualNetworkPeeringData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string peeringName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.VirtualNetworkPeeringResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.VirtualNetworkPeeringResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Databricks.VirtualNetworkPeeringData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.VirtualNetworkPeeringData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.VirtualNetworkPeeringData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.VirtualNetworkPeeringData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.VirtualNetworkPeeringData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.VirtualNetworkPeeringData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.VirtualNetworkPeeringData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Databricks.VirtualNetworkPeeringResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Databricks.VirtualNetworkPeeringData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Databricks.VirtualNetworkPeeringResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Databricks.VirtualNetworkPeeringData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Databricks.Mocking
{
    public partial class MockableDatabricksArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableDatabricksArmClient() { }
        public virtual Azure.ResourceManager.Databricks.AccessConnectorResource GetAccessConnectorResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Databricks.DatabricksPrivateLinkResource GetDatabricksPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Databricks.DatabricksWorkspaceResource GetDatabricksWorkspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Databricks.PrivateEndpointConnectionResource GetPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Databricks.VirtualNetworkPeeringResource GetVirtualNetworkPeeringResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableDatabricksResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDatabricksResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.AccessConnectorResource> GetAccessConnector(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.AccessConnectorResource>> GetAccessConnectorAsync(string connectorName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Databricks.AccessConnectorCollection GetAccessConnectors() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource> GetDatabricksWorkspace(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource>> GetDatabricksWorkspaceAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Databricks.DatabricksWorkspaceCollection GetDatabricksWorkspaces() { throw null; }
    }
    public partial class MockableDatabricksSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableDatabricksSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Databricks.AccessConnectorResource> GetAccessConnectors(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Databricks.AccessConnectorResource> GetAccessConnectorsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource> GetDatabricksWorkspaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Databricks.DatabricksWorkspaceResource> GetDatabricksWorkspacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Databricks.Models
{
    public partial class AccessConnectorPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.AccessConnectorPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.AccessConnectorPatch>
    {
        public AccessConnectorPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.Databricks.Models.AccessConnectorPatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.AccessConnectorPatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.AccessConnectorPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.AccessConnectorPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.AccessConnectorPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.AccessConnectorPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.AccessConnectorPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.AccessConnectorPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.AccessConnectorPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class AccessConnectorProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.AccessConnectorProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.AccessConnectorProperties>
    {
        public AccessConnectorProperties() { }
        public Azure.ResourceManager.Databricks.Models.ProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> ReferedBy { get { throw null; } }
        protected virtual Azure.ResourceManager.Databricks.Models.AccessConnectorProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.AccessConnectorProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.AccessConnectorProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.AccessConnectorProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.AccessConnectorProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.AccessConnectorProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.AccessConnectorProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.AccessConnectorProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.AccessConnectorProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public static partial class ArmDatabricksModelFactory
    {
        public static Azure.ResourceManager.Databricks.AccessConnectorData AccessConnectorData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Databricks.Models.AccessConnectorProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.AccessConnectorPatch AccessConnectorPatch(System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.AccessConnectorProperties AccessConnectorProperties(Azure.ResourceManager.Databricks.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Databricks.Models.ProvisioningState?), System.Collections.Generic.IEnumerable<string> referedBy = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.ComplianceSecurityProfile ComplianceSecurityProfile(System.Collections.Generic.IEnumerable<string> complianceStandards = null, Azure.ResourceManager.Databricks.Models.ComplianceSecurityProfileValue? value = default(Azure.ResourceManager.Databricks.Models.ComplianceSecurityProfileValue?)) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.CreatedBy CreatedBy(string oid = null, string puid = null, string applicationId = null) { throw null; }
        public static Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData DatabricksPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Databricks.Models.PrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Databricks.DatabricksPrivateLinkResourceData DatabricksPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Databricks.Models.GroupIdInformationProperties properties = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionState DatabricksPrivateLinkServiceConnectionState(Azure.ResourceManager.Databricks.Models.PrivateLinkServiceConnectionStatus status = default(Azure.ResourceManager.Databricks.Models.PrivateLinkServiceConnectionStatus), string description = null, string actionsRequired = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksSku DatabricksSku(string name = null, string tier = null) { throw null; }
        public static Azure.ResourceManager.Databricks.DatabricksWorkspaceData DatabricksWorkspaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Databricks.Models.ComputeMode computeMode = default(Azure.ResourceManager.Databricks.Models.ComputeMode), string managedResourceGroupId = null, Azure.ResourceManager.Databricks.Models.WorkspaceCustomProperties parameters = null, Azure.ResourceManager.Databricks.Models.ProvisioningState? provisioningState = default(Azure.ResourceManager.Databricks.Models.ProvisioningState?), string uiDefinitionUri = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Databricks.Models.WorkspaceProviderAuthorization> authorizations = null, Azure.ResourceManager.Databricks.Models.CreatedBy createdBy = null, Azure.ResourceManager.Databricks.Models.CreatedBy updatedBy = null, System.DateTimeOffset? createdOn = default(System.DateTimeOffset?), string workspaceId = null, string workspaceUri = null, Azure.ResourceManager.Databricks.Models.ManagedIdentityConfiguration storageAccountIdentity = null, Azure.ResourceManager.Databricks.Models.ManagedIdentityConfiguration managedDiskIdentity = null, string diskEncryptionSetId = null, Azure.ResourceManager.Databricks.Models.EnhancedSecurityCompliance enhancedSecurityCompliance = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Databricks.DatabricksPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.Databricks.Models.PublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Databricks.Models.PublicNetworkAccess?), Azure.ResourceManager.Databricks.Models.RequiredNsgRules? requiredNsgRules = default(Azure.ResourceManager.Databricks.Models.RequiredNsgRules?), Azure.ResourceManager.Databricks.Models.DefaultCatalogProperties defaultCatalog = null, bool? isUcEnabled = default(bool?), Azure.ResourceManager.Databricks.Models.WorkspacePropertiesAccessConnector accessConnector = null, Azure.ResourceManager.Databricks.Models.DefaultStorageFirewall? defaultStorageFirewall = default(Azure.ResourceManager.Databricks.Models.DefaultStorageFirewall?), Azure.ResourceManager.Databricks.Models.EncryptionEntities encryptionEntities = null, Azure.ResourceManager.Databricks.Models.DatabricksSku sku = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DatabricksWorkspacePatch DatabricksWorkspacePatch(System.Collections.Generic.IDictionary<string, string> tags = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DefaultCatalogProperties DefaultCatalogProperties(Azure.ResourceManager.Databricks.Models.InitialType? initialType = default(Azure.ResourceManager.Databricks.Models.InitialType?), string initialName = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.Encryption Encryption(Azure.ResourceManager.Databricks.Models.KeySource? keySource = default(Azure.ResourceManager.Databricks.Models.KeySource?), string keyName = null, string keyVersion = null, string keyVaultUri = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.EncryptionEntities EncryptionEntities(Azure.ResourceManager.Databricks.Models.EncryptionV2 managedServices = null, Azure.ResourceManager.Databricks.Models.ManagedDiskEncryption managedDisk = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.EncryptionV2 EncryptionV2(Azure.ResourceManager.Databricks.Models.EncryptionKeySource keySource = default(Azure.ResourceManager.Databricks.Models.EncryptionKeySource), Azure.ResourceManager.Databricks.Models.EncryptionV2KeyVaultProperties keyVaultProperties = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.EncryptionV2KeyVaultProperties EncryptionV2KeyVaultProperties(string keyVaultUri = null, string keyName = null, string keyVersion = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.EndpointDependency EndpointDependency(string domainName = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Databricks.Models.EndpointDetail> endpointDetails = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.EndpointDetail EndpointDetail(string ipAddress = null, int? port = default(int?), double? latency = default(double?), bool? isAccessible = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.EnhancedSecurityCompliance EnhancedSecurityCompliance(Azure.ResourceManager.Databricks.Models.AutomaticClusterUpdateValue? automaticClusterUpdateValue = default(Azure.ResourceManager.Databricks.Models.AutomaticClusterUpdateValue?), Azure.ResourceManager.Databricks.Models.ComplianceSecurityProfile complianceSecurityProfile = null, Azure.ResourceManager.Databricks.Models.EnhancedSecurityMonitoringValue? enhancedSecurityMonitoringValue = default(Azure.ResourceManager.Databricks.Models.EnhancedSecurityMonitoringValue?)) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.GroupIdInformationProperties GroupIdInformationProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.ManagedDiskEncryption ManagedDiskEncryption(Azure.ResourceManager.Databricks.Models.EncryptionKeySource keySource = default(Azure.ResourceManager.Databricks.Models.EncryptionKeySource), Azure.ResourceManager.Databricks.Models.ManagedDiskEncryptionKeyVaultProperties keyVaultProperties = null, bool? isRotationToLatestKeyVersionEnabled = default(bool?)) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.ManagedDiskEncryptionKeyVaultProperties ManagedDiskEncryptionKeyVaultProperties(string keyVaultUri = null, string keyName = null, string keyVersion = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.ManagedIdentityConfiguration ManagedIdentityConfiguration(string principalId = null, string tenantId = null, string type = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.OutboundEnvironmentEndpoint OutboundEnvironmentEndpoint(string category = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Databricks.Models.EndpointDependency> endpoints = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.PrivateEndpointConnectionProperties PrivateEndpointConnectionProperties(string privateEndpointId = null, System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Databricks.VirtualNetworkPeeringData VirtualNetworkPeeringData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, bool? allowVirtualNetworkAccess = default(bool?), bool? allowForwardedTraffic = default(bool?), bool? allowGatewayTransit = default(bool?), bool? useRemoteGateways = default(bool?), Azure.ResourceManager.Databricks.Models.PeeringState? peeringState = default(Azure.ResourceManager.Databricks.Models.PeeringState?), Azure.ResourceManager.Databricks.Models.PeeringProvisioningState? provisioningState = default(Azure.ResourceManager.Databricks.Models.PeeringProvisioningState?), string databricksVirtualNetworkId = null, System.Collections.Generic.IEnumerable<string> databricksAddressPrefixes = null, string remoteVirtualNetworkId = null, System.Collections.Generic.IEnumerable<string> remoteAddressPrefixes = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.WorkspaceCustomBooleanParameterValue WorkspaceCustomBooleanParameterValue(Azure.ResourceManager.Databricks.Models.CustomParameterType? type = default(Azure.ResourceManager.Databricks.Models.CustomParameterType?), bool isEnabled = false) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.WorkspaceCustomObjectParameterValue WorkspaceCustomObjectParameterValue(Azure.ResourceManager.Databricks.Models.CustomParameterType? type = default(Azure.ResourceManager.Databricks.Models.CustomParameterType?), System.BinaryData value = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.WorkspaceCustomProperties WorkspaceCustomProperties(Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue amlWorkspaceId = null, Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue customVirtualNetworkId = null, Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue customPublicSubnetName = null, Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue customPrivateSubnetName = null, Azure.ResourceManager.Databricks.Models.WorkspaceNoPublicIPBooleanParameterValue enableNoPublicIp = null, Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue loadBalancerBackendPoolName = null, Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue loadBalancerId = null, Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue natGatewayName = null, Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue publicIpName = null, Azure.ResourceManager.Databricks.Models.WorkspaceCustomBooleanParameterValue prepareEncryption = null, Azure.ResourceManager.Databricks.Models.WorkspaceEncryptionParameterValue encryption = null, Azure.ResourceManager.Databricks.Models.WorkspaceCustomBooleanParameterValue requireInfrastructureEncryption = null, Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue storageAccountName = null, Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue storageAccountSkuName = null, Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue vnetAddressPrefix = null, Azure.ResourceManager.Databricks.Models.WorkspaceCustomObjectParameterValue resourceTags = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.WorkspaceCustomStringParameterValue WorkspaceCustomStringParameterValue(Azure.ResourceManager.Databricks.Models.CustomParameterType? type = default(Azure.ResourceManager.Databricks.Models.CustomParameterType?), string value = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.WorkspaceEncryptionParameterValue WorkspaceEncryptionParameterValue(Azure.ResourceManager.Databricks.Models.CustomParameterType? type = default(Azure.ResourceManager.Databricks.Models.CustomParameterType?), Azure.ResourceManager.Databricks.Models.Encryption value = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.WorkspaceNoPublicIPBooleanParameterValue WorkspaceNoPublicIPBooleanParameterValue(Azure.ResourceManager.Databricks.Models.CustomParameterType? type = default(Azure.ResourceManager.Databricks.Models.CustomParameterType?), bool isEnabled = false) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.WorkspacePropertiesAccessConnector WorkspacePropertiesAccessConnector(Azure.Core.ResourceIdentifier id = null, Azure.ResourceManager.Databricks.Models.IdentityType identityType = default(Azure.ResourceManager.Databricks.Models.IdentityType), Azure.Core.ResourceIdentifier userAssignedIdentityId = null) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.WorkspaceProviderAuthorization WorkspaceProviderAuthorization(string principalId = null, string roleDefinitionId = null) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutomaticClusterUpdateValue : System.IEquatable<Azure.ResourceManager.Databricks.Models.AutomaticClusterUpdateValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutomaticClusterUpdateValue(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.AutomaticClusterUpdateValue Disabled { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.AutomaticClusterUpdateValue Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.AutomaticClusterUpdateValue other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.AutomaticClusterUpdateValue left, Azure.ResourceManager.Databricks.Models.AutomaticClusterUpdateValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.AutomaticClusterUpdateValue (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.AutomaticClusterUpdateValue? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.AutomaticClusterUpdateValue left, Azure.ResourceManager.Databricks.Models.AutomaticClusterUpdateValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ComplianceSecurityProfile : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.ComplianceSecurityProfile>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.ComplianceSecurityProfile>
    {
        public ComplianceSecurityProfile() { }
        public System.Collections.Generic.IList<string> ComplianceStandards { get { throw null; } }
        public Azure.ResourceManager.Databricks.Models.ComplianceSecurityProfileValue? Value { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Databricks.Models.ComplianceSecurityProfile JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.ComplianceSecurityProfile PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.ComplianceSecurityProfile System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.ComplianceSecurityProfile>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.ComplianceSecurityProfile>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.ComplianceSecurityProfile System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.ComplianceSecurityProfile>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.ComplianceSecurityProfile>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.ComplianceSecurityProfile>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComplianceSecurityProfileValue : System.IEquatable<Azure.ResourceManager.Databricks.Models.ComplianceSecurityProfileValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComplianceSecurityProfileValue(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.ComplianceSecurityProfileValue Disabled { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.ComplianceSecurityProfileValue Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.ComplianceSecurityProfileValue other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.ComplianceSecurityProfileValue left, Azure.ResourceManager.Databricks.Models.ComplianceSecurityProfileValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.ComplianceSecurityProfileValue (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.ComplianceSecurityProfileValue? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.ComplianceSecurityProfileValue left, Azure.ResourceManager.Databricks.Models.ComplianceSecurityProfileValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ComputeMode : System.IEquatable<Azure.ResourceManager.Databricks.Models.ComputeMode>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ComputeMode(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.ComputeMode Hybrid { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.ComputeMode Serverless { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.ComputeMode other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.ComputeMode left, Azure.ResourceManager.Databricks.Models.ComputeMode right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.ComputeMode (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.ComputeMode? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.ComputeMode left, Azure.ResourceManager.Databricks.Models.ComputeMode right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class CreatedBy : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.CreatedBy>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.CreatedBy>
    {
        public CreatedBy() { }
        public string ApplicationId { get { throw null; } }
        public string Oid { get { throw null; } }
        public string Puid { get { throw null; } }
        protected virtual Azure.ResourceManager.Databricks.Models.CreatedBy JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.CreatedBy PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.CreatedBy System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.CreatedBy>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.CreatedBy>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.CreatedBy System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.CreatedBy>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.CreatedBy>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.CreatedBy>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct CustomParameterType : System.IEquatable<Azure.ResourceManager.Databricks.Models.CustomParameterType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public CustomParameterType(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.CustomParameterType Bool { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.CustomParameterType Object { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.CustomParameterType String { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.CustomParameterType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.CustomParameterType left, Azure.ResourceManager.Databricks.Models.CustomParameterType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.CustomParameterType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.CustomParameterType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.CustomParameterType left, Azure.ResourceManager.Databricks.Models.CustomParameterType right) { throw null; }
        public override string ToString() { throw null; }
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
        public DatabricksPrivateLinkServiceConnectionState(Azure.ResourceManager.Databricks.Models.PrivateLinkServiceConnectionStatus status) { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.PrivateLinkServiceConnectionStatus Status { get { throw null; } set { } }
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
    public partial class DefaultCatalogProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DefaultCatalogProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DefaultCatalogProperties>
    {
        public DefaultCatalogProperties() { }
        public string InitialName { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.InitialType? InitialType { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Databricks.Models.DefaultCatalogProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.DefaultCatalogProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.DefaultCatalogProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DefaultCatalogProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.DefaultCatalogProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.DefaultCatalogProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DefaultCatalogProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DefaultCatalogProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.DefaultCatalogProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DefaultStorageFirewall : System.IEquatable<Azure.ResourceManager.Databricks.Models.DefaultStorageFirewall>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DefaultStorageFirewall(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.DefaultStorageFirewall Disabled { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.DefaultStorageFirewall Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.DefaultStorageFirewall other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.DefaultStorageFirewall left, Azure.ResourceManager.Databricks.Models.DefaultStorageFirewall right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DefaultStorageFirewall (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.DefaultStorageFirewall? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.DefaultStorageFirewall left, Azure.ResourceManager.Databricks.Models.DefaultStorageFirewall right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class Encryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.Encryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.Encryption>
    {
        public Encryption() { }
        public string KeyName { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.KeySource? KeySource { get { throw null; } set { } }
        public string KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Databricks.Models.Encryption JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.Encryption PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.Encryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.Encryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.Encryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.Encryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.Encryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.Encryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.Encryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EncryptionEntities : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.EncryptionEntities>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.EncryptionEntities>
    {
        public EncryptionEntities() { }
        public Azure.ResourceManager.Databricks.Models.ManagedDiskEncryption ManagedDisk { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.EncryptionV2 ManagedServices { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Databricks.Models.EncryptionEntities JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.EncryptionEntities PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.EncryptionEntities System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.EncryptionEntities>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.EncryptionEntities>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.EncryptionEntities System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.EncryptionEntities>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.EncryptionEntities>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.EncryptionEntities>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EncryptionKeySource : System.IEquatable<Azure.ResourceManager.Databricks.Models.EncryptionKeySource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EncryptionKeySource(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.EncryptionKeySource MicrosoftKeyvault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.EncryptionKeySource other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.EncryptionKeySource left, Azure.ResourceManager.Databricks.Models.EncryptionKeySource right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.EncryptionKeySource (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.EncryptionKeySource? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.EncryptionKeySource left, Azure.ResourceManager.Databricks.Models.EncryptionKeySource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EncryptionV2 : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.EncryptionV2>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.EncryptionV2>
    {
        public EncryptionV2(Azure.ResourceManager.Databricks.Models.EncryptionKeySource keySource) { }
        public Azure.ResourceManager.Databricks.Models.EncryptionKeySource KeySource { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.EncryptionV2KeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Databricks.Models.EncryptionV2 JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.EncryptionV2 PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.EncryptionV2 System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.EncryptionV2>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.EncryptionV2>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.EncryptionV2 System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.EncryptionV2>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.EncryptionV2>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.EncryptionV2>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EncryptionV2KeyVaultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.EncryptionV2KeyVaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.EncryptionV2KeyVaultProperties>
    {
        public EncryptionV2KeyVaultProperties(string keyVaultUri, string keyName, string keyVersion) { }
        public string KeyName { get { throw null; } set { } }
        public string KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Databricks.Models.EncryptionV2KeyVaultProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.EncryptionV2KeyVaultProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.EncryptionV2KeyVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.EncryptionV2KeyVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.EncryptionV2KeyVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.EncryptionV2KeyVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.EncryptionV2KeyVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.EncryptionV2KeyVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.EncryptionV2KeyVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EndpointDependency : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.EndpointDependency>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.EndpointDependency>
    {
        internal EndpointDependency() { }
        public string DomainName { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Databricks.Models.EndpointDetail> EndpointDetails { get { throw null; } }
        protected virtual Azure.ResourceManager.Databricks.Models.EndpointDependency JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.EndpointDependency PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.EndpointDependency System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.EndpointDependency>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.EndpointDependency>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.EndpointDependency System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.EndpointDependency>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.EndpointDependency>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.EndpointDependency>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EndpointDetail : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.EndpointDetail>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.EndpointDetail>
    {
        internal EndpointDetail() { }
        public string IpAddress { get { throw null; } }
        public bool? IsAccessible { get { throw null; } }
        public double? Latency { get { throw null; } }
        public int? Port { get { throw null; } }
        protected virtual Azure.ResourceManager.Databricks.Models.EndpointDetail JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.EndpointDetail PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.EndpointDetail System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.EndpointDetail>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.EndpointDetail>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.EndpointDetail System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.EndpointDetail>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.EndpointDetail>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.EndpointDetail>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnhancedSecurityCompliance : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.EnhancedSecurityCompliance>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.EnhancedSecurityCompliance>
    {
        public EnhancedSecurityCompliance() { }
        public Azure.ResourceManager.Databricks.Models.AutomaticClusterUpdateValue? AutomaticClusterUpdateValue { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.ComplianceSecurityProfile ComplianceSecurityProfile { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.EnhancedSecurityMonitoringValue? EnhancedSecurityMonitoringValue { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Databricks.Models.EnhancedSecurityCompliance JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.EnhancedSecurityCompliance PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.EnhancedSecurityCompliance System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.EnhancedSecurityCompliance>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.EnhancedSecurityCompliance>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.EnhancedSecurityCompliance System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.EnhancedSecurityCompliance>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.EnhancedSecurityCompliance>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.EnhancedSecurityCompliance>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct EnhancedSecurityMonitoringValue : System.IEquatable<Azure.ResourceManager.Databricks.Models.EnhancedSecurityMonitoringValue>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public EnhancedSecurityMonitoringValue(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.EnhancedSecurityMonitoringValue Disabled { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.EnhancedSecurityMonitoringValue Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.EnhancedSecurityMonitoringValue other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.EnhancedSecurityMonitoringValue left, Azure.ResourceManager.Databricks.Models.EnhancedSecurityMonitoringValue right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.EnhancedSecurityMonitoringValue (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.EnhancedSecurityMonitoringValue? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.EnhancedSecurityMonitoringValue left, Azure.ResourceManager.Databricks.Models.EnhancedSecurityMonitoringValue right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GroupIdInformationProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.GroupIdInformationProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.GroupIdInformationProperties>
    {
        internal GroupIdInformationProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        protected virtual Azure.ResourceManager.Databricks.Models.GroupIdInformationProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.GroupIdInformationProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.GroupIdInformationProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.GroupIdInformationProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.GroupIdInformationProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.GroupIdInformationProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.GroupIdInformationProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.GroupIdInformationProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.GroupIdInformationProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct IdentityType : System.IEquatable<Azure.ResourceManager.Databricks.Models.IdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public IdentityType(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.IdentityType SystemAssigned { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.IdentityType UserAssigned { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.IdentityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.IdentityType left, Azure.ResourceManager.Databricks.Models.IdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.IdentityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.IdentityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.IdentityType left, Azure.ResourceManager.Databricks.Models.IdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct InitialType : System.IEquatable<Azure.ResourceManager.Databricks.Models.InitialType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public InitialType(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.InitialType HiveMetastore { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.InitialType UnityCatalog { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.InitialType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.InitialType left, Azure.ResourceManager.Databricks.Models.InitialType right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.InitialType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.InitialType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.InitialType left, Azure.ResourceManager.Databricks.Models.InitialType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeySource : System.IEquatable<Azure.ResourceManager.Databricks.Models.KeySource>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeySource(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.KeySource Default { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.KeySource MicrosoftKeyvault { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.KeySource other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.KeySource left, Azure.ResourceManager.Databricks.Models.KeySource right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.KeySource (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.KeySource? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.KeySource left, Azure.ResourceManager.Databricks.Models.KeySource right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedDiskEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.ManagedDiskEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.ManagedDiskEncryption>
    {
        public ManagedDiskEncryption(Azure.ResourceManager.Databricks.Models.EncryptionKeySource keySource, Azure.ResourceManager.Databricks.Models.ManagedDiskEncryptionKeyVaultProperties keyVaultProperties) { }
        public bool? IsRotationToLatestKeyVersionEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.EncryptionKeySource KeySource { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.ManagedDiskEncryptionKeyVaultProperties KeyVaultProperties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Databricks.Models.ManagedDiskEncryption JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.ManagedDiskEncryption PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.ManagedDiskEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.ManagedDiskEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.ManagedDiskEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.ManagedDiskEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.ManagedDiskEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.ManagedDiskEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.ManagedDiskEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedDiskEncryptionKeyVaultProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.ManagedDiskEncryptionKeyVaultProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.ManagedDiskEncryptionKeyVaultProperties>
    {
        public ManagedDiskEncryptionKeyVaultProperties(string keyVaultUri, string keyName, string keyVersion) { }
        public string KeyName { get { throw null; } set { } }
        public string KeyVaultUri { get { throw null; } set { } }
        public string KeyVersion { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Databricks.Models.ManagedDiskEncryptionKeyVaultProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.ManagedDiskEncryptionKeyVaultProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.ManagedDiskEncryptionKeyVaultProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.ManagedDiskEncryptionKeyVaultProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.ManagedDiskEncryptionKeyVaultProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.ManagedDiskEncryptionKeyVaultProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.ManagedDiskEncryptionKeyVaultProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.ManagedDiskEncryptionKeyVaultProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.ManagedDiskEncryptionKeyVaultProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedIdentityConfiguration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.ManagedIdentityConfiguration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.ManagedIdentityConfiguration>
    {
        public ManagedIdentityConfiguration() { }
        public string PrincipalId { get { throw null; } }
        public string TenantId { get { throw null; } }
        public string Type { get { throw null; } }
        protected virtual Azure.ResourceManager.Databricks.Models.ManagedIdentityConfiguration JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.ManagedIdentityConfiguration PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.ManagedIdentityConfiguration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.ManagedIdentityConfiguration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.ManagedIdentityConfiguration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.ManagedIdentityConfiguration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.ManagedIdentityConfiguration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.ManagedIdentityConfiguration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.ManagedIdentityConfiguration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OutboundEnvironmentEndpoint : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.OutboundEnvironmentEndpoint>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.OutboundEnvironmentEndpoint>
    {
        internal OutboundEnvironmentEndpoint() { }
        public string Category { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Databricks.Models.EndpointDependency> Endpoints { get { throw null; } }
        protected virtual Azure.ResourceManager.Databricks.Models.OutboundEnvironmentEndpoint JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.OutboundEnvironmentEndpoint PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.OutboundEnvironmentEndpoint System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.OutboundEnvironmentEndpoint>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.OutboundEnvironmentEndpoint>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.OutboundEnvironmentEndpoint System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.OutboundEnvironmentEndpoint>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.OutboundEnvironmentEndpoint>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.OutboundEnvironmentEndpoint>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PeeringProvisioningState : System.IEquatable<Azure.ResourceManager.Databricks.Models.PeeringProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PeeringProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.PeeringProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.PeeringProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.PeeringProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.PeeringProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.PeeringProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.PeeringProvisioningState left, Azure.ResourceManager.Databricks.Models.PeeringProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.PeeringProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.PeeringProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.PeeringProvisioningState left, Azure.ResourceManager.Databricks.Models.PeeringProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PeeringState : System.IEquatable<Azure.ResourceManager.Databricks.Models.PeeringState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PeeringState(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.PeeringState Connected { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.PeeringState Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.PeeringState Initiated { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.PeeringState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.PeeringState left, Azure.ResourceManager.Databricks.Models.PeeringState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.PeeringState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.PeeringState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.PeeringState left, Azure.ResourceManager.Databricks.Models.PeeringState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.PrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.PrivateEndpointConnectionProperties>
    {
        public PrivateEndpointConnectionProperties(Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionState privateLinkServiceConnectionState) { }
        public System.Collections.Generic.IList<string> GroupIds { get { throw null; } }
        public string PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Databricks.Models.DatabricksPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.DatabricksPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.Databricks.Models.PrivateEndpointConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.PrivateEndpointConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.PrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.PrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.PrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.PrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.PrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.PrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.PrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PrivateLinkServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.Databricks.Models.PrivateLinkServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PrivateLinkServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.PrivateLinkServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.PrivateLinkServiceConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.PrivateLinkServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.PrivateLinkServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.PrivateLinkServiceConnectionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.PrivateLinkServiceConnectionStatus left, Azure.ResourceManager.Databricks.Models.PrivateLinkServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.PrivateLinkServiceConnectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.PrivateLinkServiceConnectionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.PrivateLinkServiceConnectionStatus left, Azure.ResourceManager.Databricks.Models.PrivateLinkServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ProvisioningState : System.IEquatable<Azure.ResourceManager.Databricks.Models.ProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.ProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.ProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.ProvisioningState Created { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.ProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.ProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.ProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.ProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.ProvisioningState Ready { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.ProvisioningState Running { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.ProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.ProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.ProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.ProvisioningState left, Azure.ResourceManager.Databricks.Models.ProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.ProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.ProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.ProvisioningState left, Azure.ResourceManager.Databricks.Models.ProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Databricks.Models.PublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.PublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.PublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.PublicNetworkAccess other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.PublicNetworkAccess left, Azure.ResourceManager.Databricks.Models.PublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.PublicNetworkAccess (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.PublicNetworkAccess? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.PublicNetworkAccess left, Azure.ResourceManager.Databricks.Models.PublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct RequiredNsgRules : System.IEquatable<Azure.ResourceManager.Databricks.Models.RequiredNsgRules>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public RequiredNsgRules(string value) { throw null; }
        public static Azure.ResourceManager.Databricks.Models.RequiredNsgRules AllRules { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.RequiredNsgRules NoAzureDatabricksRules { get { throw null; } }
        public static Azure.ResourceManager.Databricks.Models.RequiredNsgRules NoAzureServiceRules { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Databricks.Models.RequiredNsgRules other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Databricks.Models.RequiredNsgRules left, Azure.ResourceManager.Databricks.Models.RequiredNsgRules right) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.RequiredNsgRules (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.Databricks.Models.RequiredNsgRules? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Databricks.Models.RequiredNsgRules left, Azure.ResourceManager.Databricks.Models.RequiredNsgRules right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class WorkspaceCustomBooleanParameterValue : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.WorkspaceCustomBooleanParameterValue>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspaceCustomBooleanParameterValue>
    {
        public WorkspaceCustomBooleanParameterValue(bool isEnabled) { }
        public bool IsEnabled { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.CustomParameterType? Type { get { throw null; } set { } }
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
        public Azure.ResourceManager.Databricks.Models.CustomParameterType? Type { get { throw null; } }
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
        public Azure.ResourceManager.Databricks.Models.CustomParameterType? Type { get { throw null; } set { } }
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
        public Azure.ResourceManager.Databricks.Models.CustomParameterType? Type { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.Encryption Value { get { throw null; } set { } }
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
        public Azure.ResourceManager.Databricks.Models.CustomParameterType? Type { get { throw null; } set { } }
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
    public partial class WorkspacePropertiesAccessConnector : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.WorkspacePropertiesAccessConnector>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspacePropertiesAccessConnector>
    {
        public WorkspacePropertiesAccessConnector(Azure.Core.ResourceIdentifier id, Azure.ResourceManager.Databricks.Models.IdentityType identityType) { }
        public Azure.Core.ResourceIdentifier Id { get { throw null; } set { } }
        public Azure.ResourceManager.Databricks.Models.IdentityType IdentityType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentityId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Databricks.Models.WorkspacePropertiesAccessConnector JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.WorkspacePropertiesAccessConnector PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.WorkspacePropertiesAccessConnector System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.WorkspacePropertiesAccessConnector>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.WorkspacePropertiesAccessConnector>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.WorkspacePropertiesAccessConnector System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspacePropertiesAccessConnector>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspacePropertiesAccessConnector>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspacePropertiesAccessConnector>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class WorkspaceProviderAuthorization : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.WorkspaceProviderAuthorization>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspaceProviderAuthorization>
    {
        public WorkspaceProviderAuthorization(string principalId, string roleDefinitionId) { }
        public string PrincipalId { get { throw null; } set { } }
        public string RoleDefinitionId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Databricks.Models.WorkspaceProviderAuthorization JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Databricks.Models.WorkspaceProviderAuthorization PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.Databricks.Models.WorkspaceProviderAuthorization System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.WorkspaceProviderAuthorization>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Databricks.Models.WorkspaceProviderAuthorization>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Databricks.Models.WorkspaceProviderAuthorization System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspaceProviderAuthorization>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspaceProviderAuthorization>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Databricks.Models.WorkspaceProviderAuthorization>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
