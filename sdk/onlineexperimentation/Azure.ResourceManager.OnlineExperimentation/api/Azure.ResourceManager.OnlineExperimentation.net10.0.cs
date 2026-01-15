namespace Azure.ResourceManager.OnlineExperimentation
{
    public partial class AzureResourceManagerOnlineExperimentationContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerOnlineExperimentationContext() { }
        public static Azure.ResourceManager.OnlineExperimentation.AzureResourceManagerOnlineExperimentationContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class OnlineExperimentationExtensions
    {
        public static Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionResource GetOnlineExperimentationPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkResource GetOnlineExperimentationPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource> GetOnlineExperimentationWorkspace(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource>> GetOnlineExperimentationWorkspaceAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource GetOnlineExperimentationWorkspaceResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceCollection GetOnlineExperimentationWorkspaces(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource> GetOnlineExperimentationWorkspaces(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource> GetOnlineExperimentationWorkspacesAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineExperimentationPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected OnlineExperimentationPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OnlineExperimentationPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionData>
    {
        public OnlineExperimentationPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.OnlineExperimentation.Models.PrivateEndpointConnectionProperties Properties { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnlineExperimentationPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OnlineExperimentationPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class OnlineExperimentationPrivateLinkCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected OnlineExperimentationPrivateLinkCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkResource> GetIfExists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkResource>> GetIfExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OnlineExperimentationPrivateLinkData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkData>
    {
        internal OnlineExperimentationPrivateLinkData() { }
        public Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateLinkResourceProperties Properties { get { throw null; } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnlineExperimentationPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OnlineExperimentationPrivateLinkResource() { }
        public virtual Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnlineExperimentationWorkspaceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource>, System.Collections.IEnumerable
    {
        protected OnlineExperimentationWorkspaceCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource> GetIfExists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource>> GetIfExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class OnlineExperimentationWorkspaceData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceData>
    {
        public OnlineExperimentationWorkspaceData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSku Sku { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.Models.ResourceData JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.Models.ResourceData PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnlineExperimentationWorkspaceResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected OnlineExperimentationWorkspaceResource() { }
        public virtual Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionResource> GetOnlineExperimentationPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionResource>> GetOnlineExperimentationPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionCollection GetOnlineExperimentationPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkResource> GetOnlineExperimentationPrivateLink(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkResource>> GetOnlineExperimentationPrivateLinkAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkCollection GetOnlineExperimentationPrivateLinks() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspacePatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.OnlineExperimentation.Mocking
{
    public partial class MockableOnlineExperimentationArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableOnlineExperimentationArmClient() { }
        public virtual Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionResource GetOnlineExperimentationPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkResource GetOnlineExperimentationPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource GetOnlineExperimentationWorkspaceResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableOnlineExperimentationResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableOnlineExperimentationResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource> GetOnlineExperimentationWorkspace(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource>> GetOnlineExperimentationWorkspaceAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceCollection GetOnlineExperimentationWorkspaces() { throw null; }
    }
    public partial class MockableOnlineExperimentationSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableOnlineExperimentationSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource> GetOnlineExperimentationWorkspaces(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceResource> GetOnlineExperimentationWorkspacesAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.OnlineExperimentation.Models
{
    public static partial class ArmOnlineExperimentationModelFactory
    {
        public static Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionData OnlineExperimentationPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.OnlineExperimentation.Models.PrivateEndpointConnectionProperties properties = null) { throw null; }
        public static Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateLinkData OnlineExperimentationPrivateLinkData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateLinkResourceProperties properties = null) { throw null; }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateLinkResourceProperties OnlineExperimentationPrivateLinkResourceProperties(string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationWorkspaceData OnlineExperimentationWorkspaceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSku sku = null) { throw null; }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspacePatch OnlineExperimentationWorkspacePatch(Azure.ResourceManager.Models.ManagedServiceIdentity identity = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSku sku = null, Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspacePatchProperties properties = null) { throw null; }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceProperties OnlineExperimentationWorkspaceProperties(System.Guid? workspaceId = default(System.Guid?), Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationProvisioningState? provisioningState = default(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationProvisioningState?), Azure.Core.ResourceIdentifier logAnalyticsWorkspaceResourceId = null, Azure.Core.ResourceIdentifier logsExporterStorageAccountResourceId = null, Azure.Core.ResourceIdentifier appConfigurationResourceId = null, Azure.ResourceManager.OnlineExperimentation.Models.CustomerManagedKeyEncryption customerManagedKeyEncryption = null, System.Uri endpoint = null, Azure.ResourceManager.OnlineExperimentation.Models.PublicNetworkAccessType? publicNetworkAccess = default(Azure.ResourceManager.OnlineExperimentation.Models.PublicNetworkAccessType?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionData> privateEndpointConnections = null) { throw null; }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSku OnlineExperimentationWorkspaceSku(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName name = default(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName), Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuTier? tier = default(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuTier?)) { throw null; }
        public static Azure.ResourceManager.OnlineExperimentation.Models.PrivateEndpointConnectionProperties PrivateEndpointConnectionProperties(System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.ResourceManager.Resources.Models.SubResource privateEndpoint = null, Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateLinkServiceConnectionState privateLinkServiceConnectionState = null, Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateEndpointConnectionProvisioningState?)) { throw null; }
    }
    public partial class CustomerManagedKeyEncryption : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.CustomerManagedKeyEncryption>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.CustomerManagedKeyEncryption>
    {
        public CustomerManagedKeyEncryption() { }
        public Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentity KeyEncryptionKeyIdentity { get { throw null; } set { } }
        public System.Uri KeyEncryptionKeyUri { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.OnlineExperimentation.Models.CustomerManagedKeyEncryption JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.OnlineExperimentation.Models.CustomerManagedKeyEncryption PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.OnlineExperimentation.Models.CustomerManagedKeyEncryption System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.CustomerManagedKeyEncryption>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.CustomerManagedKeyEncryption>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OnlineExperimentation.Models.CustomerManagedKeyEncryption System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.CustomerManagedKeyEncryption>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.CustomerManagedKeyEncryption>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.CustomerManagedKeyEncryption>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class KeyEncryptionKeyIdentity : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentity>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentity>
    {
        public KeyEncryptionKeyIdentity() { }
        public System.Guid? FederatedClientId { get { throw null; } set { } }
        public Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentityType? IdentityType { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier UserAssignedIdentityResourceId { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentity JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentity PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentity System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentity>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentity>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentity System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentity>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentity>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentity>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct KeyEncryptionKeyIdentityType : System.IEquatable<Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentityType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public KeyEncryptionKeyIdentityType(string value) { throw null; }
        public static Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentityType SystemAssignedIdentity { get { throw null; } }
        public static Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentityType UserAssignedIdentity { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentityType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentityType left, Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentityType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentityType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentityType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentityType left, Azure.ResourceManager.OnlineExperimentation.Models.KeyEncryptionKeyIdentityType right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OnlineExperimentationPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OnlineExperimentationPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateEndpointConnectionProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateEndpointConnectionProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OnlineExperimentationPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OnlineExperimentationPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateEndpointServiceConnectionStatus other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateEndpointServiceConnectionStatus? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OnlineExperimentationPrivateLinkResourceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateLinkResourceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateLinkResourceProperties>
    {
        internal OnlineExperimentationPrivateLinkResourceProperties() { }
        public string GroupId { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        protected virtual Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateLinkResourceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateLinkResourceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateLinkResourceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateLinkResourceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateLinkResourceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateLinkResourceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateLinkResourceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateLinkResourceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateLinkResourceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnlineExperimentationPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateLinkServiceConnectionState>
    {
        public OnlineExperimentationPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateLinkServiceConnectionState JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateLinkServiceConnectionState PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OnlineExperimentationProvisioningState : System.IEquatable<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OnlineExperimentationProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationProvisioningState other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationProvisioningState left, Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationProvisioningState (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationProvisioningState? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationProvisioningState left, Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class OnlineExperimentationWorkspacePatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspacePatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspacePatch>
    {
        public OnlineExperimentationWorkspacePatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspacePatchProperties Properties { get { throw null; } set { } }
        public Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSku Sku { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspacePatch JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspacePatch PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspacePatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspacePatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspacePatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspacePatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspacePatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspacePatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspacePatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnlineExperimentationWorkspacePatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspacePatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspacePatchProperties>
    {
        public OnlineExperimentationWorkspacePatchProperties() { }
        public Azure.ResourceManager.OnlineExperimentation.Models.CustomerManagedKeyEncryption CustomerManagedKeyEncryption { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LogAnalyticsWorkspaceResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LogsExporterStorageAccountResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.OnlineExperimentation.Models.PublicNetworkAccessType? PublicNetworkAccess { get { throw null; } set { } }
        protected virtual Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspacePatchProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspacePatchProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspacePatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspacePatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspacePatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspacePatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspacePatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspacePatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspacePatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnlineExperimentationWorkspaceProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceProperties>
    {
        public OnlineExperimentationWorkspaceProperties(Azure.Core.ResourceIdentifier logAnalyticsWorkspaceResourceId, Azure.Core.ResourceIdentifier logsExporterStorageAccountResourceId, Azure.Core.ResourceIdentifier appConfigurationResourceId) { }
        public Azure.Core.ResourceIdentifier AppConfigurationResourceId { get { throw null; } set { } }
        public Azure.ResourceManager.OnlineExperimentation.Models.CustomerManagedKeyEncryption CustomerManagedKeyEncryption { get { throw null; } set { } }
        public System.Uri Endpoint { get { throw null; } }
        public Azure.Core.ResourceIdentifier LogAnalyticsWorkspaceResourceId { get { throw null; } set { } }
        public Azure.Core.ResourceIdentifier LogsExporterStorageAccountResourceId { get { throw null; } set { } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.OnlineExperimentation.OnlineExperimentationPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.OnlineExperimentation.Models.PublicNetworkAccessType? PublicNetworkAccess { get { throw null; } set { } }
        public System.Guid? WorkspaceId { get { throw null; } }
        protected virtual Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class OnlineExperimentationWorkspaceSku : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSku>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSku>
    {
        public OnlineExperimentationWorkspaceSku(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName name) { }
        public Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName Name { get { throw null; } set { } }
        public Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuTier? Tier { get { throw null; } }
        protected virtual Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSku JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSku PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSku System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSku>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSku>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSku System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSku>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSku>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSku>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OnlineExperimentationWorkspaceSkuName : System.IEquatable<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OnlineExperimentationWorkspaceSkuName(string value) { throw null; }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName D0 { get { throw null; } }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName F0 { get { throw null; } }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName P0 { get { throw null; } }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName S0 { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName left, Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName right) { throw null; }
        public static implicit operator Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName left, Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuName right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct OnlineExperimentationWorkspaceSkuTier : System.IEquatable<Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuTier>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public OnlineExperimentationWorkspaceSkuTier(string value) { throw null; }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuTier Developer { get { throw null; } }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuTier Free { get { throw null; } }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuTier Premium { get { throw null; } }
        public static Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuTier Standard { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuTier other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuTier left, Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuTier right) { throw null; }
        public static implicit operator Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuTier (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuTier? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuTier left, Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationWorkspaceSkuTier right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class PrivateEndpointConnectionProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.PrivateEndpointConnectionProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.PrivateEndpointConnectionProperties>
    {
        public PrivateEndpointConnectionProperties(Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateLinkServiceConnectionState privateLinkServiceConnectionState) { }
        public System.Collections.Generic.IReadOnlyList<string> GroupIds { get { throw null; } }
        public Azure.ResourceManager.Resources.Models.SubResource PrivateEndpoint { get { throw null; } set { } }
        public Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get { throw null; } set { } }
        public Azure.ResourceManager.OnlineExperimentation.Models.OnlineExperimentationPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected virtual Azure.ResourceManager.OnlineExperimentation.Models.PrivateEndpointConnectionProperties JsonModelCreateCore(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        protected virtual Azure.ResourceManager.OnlineExperimentation.Models.PrivateEndpointConnectionProperties PersistableModelCreateCore(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        protected virtual System.BinaryData PersistableModelWriteCore(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        Azure.ResourceManager.OnlineExperimentation.Models.PrivateEndpointConnectionProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.PrivateEndpointConnectionProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.OnlineExperimentation.Models.PrivateEndpointConnectionProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.OnlineExperimentation.Models.PrivateEndpointConnectionProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.PrivateEndpointConnectionProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.PrivateEndpointConnectionProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.OnlineExperimentation.Models.PrivateEndpointConnectionProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct PublicNetworkAccessType : System.IEquatable<Azure.ResourceManager.OnlineExperimentation.Models.PublicNetworkAccessType>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public PublicNetworkAccessType(string value) { throw null; }
        public static Azure.ResourceManager.OnlineExperimentation.Models.PublicNetworkAccessType Disabled { get { throw null; } }
        public static Azure.ResourceManager.OnlineExperimentation.Models.PublicNetworkAccessType Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.OnlineExperimentation.Models.PublicNetworkAccessType other) { throw null; }
        public override bool Equals(object obj) { throw null; }
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.OnlineExperimentation.Models.PublicNetworkAccessType left, Azure.ResourceManager.OnlineExperimentation.Models.PublicNetworkAccessType right) { throw null; }
        public static implicit operator Azure.ResourceManager.OnlineExperimentation.Models.PublicNetworkAccessType (string value) { throw null; }
        public static implicit operator Azure.ResourceManager.OnlineExperimentation.Models.PublicNetworkAccessType? (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.OnlineExperimentation.Models.PublicNetworkAccessType left, Azure.ResourceManager.OnlineExperimentation.Models.PublicNetworkAccessType right) { throw null; }
        public override string ToString() { throw null; }
    }
}
