namespace Azure.ResourceManager.Grafana
{
    public partial class AzureResourceManagerGrafanaContext : System.ClientModel.Primitives.ModelReaderWriterContext
    {
        internal AzureResourceManagerGrafanaContext() { }
        public static Azure.ResourceManager.Grafana.AzureResourceManagerGrafanaContext Default { get { throw null; } }
        protected override bool TryGetTypeBuilderCore(System.Type type, out System.ClientModel.Primitives.ModelReaderWriterTypeBuilder builder) { throw null; }
    }
    public static partial class GrafanaExtensions
    {
        public static Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource GetGrafanaPrivateEndpointConnectionResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource GetGrafanaPrivateLinkResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource> GetManagedGrafana(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource>> GetManagedGrafanaAsync(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource, string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Grafana.ManagedGrafanaResource GetManagedGrafanaResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
        public static Azure.ResourceManager.Grafana.ManagedGrafanaCollection GetManagedGrafanas(this Azure.ResourceManager.Resources.ResourceGroupResource resourceGroupResource) { throw null; }
        public static Azure.Pageable<Azure.ResourceManager.Grafana.ManagedGrafanaResource> GetManagedGrafanas(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.AsyncPageable<Azure.ResourceManager.Grafana.ManagedGrafanaResource> GetManagedGrafanasAsync(this Azure.ResourceManager.Resources.SubscriptionResource subscriptionResource, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelResource GetManagedPrivateEndpointModelResource(this Azure.ResourceManager.ArmClient client, Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class GrafanaPrivateEndpointConnectionCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource>, System.Collections.IEnumerable
    {
        protected GrafanaPrivateEndpointConnectionCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string privateEndpointConnectionName, Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GrafanaPrivateEndpointConnectionData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData>
    {
        public GrafanaPrivateEndpointConnectionData() { }
        public Azure.ResourceManager.Grafana.Models.GrafanaPrivateLinkServiceConnectionState ConnectionState { get { throw null; } set { } }
        public System.Collections.Generic.IList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateEndpointId { get { throw null; } }
        public Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointConnectionProvisioningState? ProvisioningState { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GrafanaPrivateEndpointConnectionResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GrafanaPrivateEndpointConnectionResource() { }
        public virtual Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string privateEndpointConnectionName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class GrafanaPrivateLinkResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResourceData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected GrafanaPrivateLinkResource() { }
        public virtual Azure.ResourceManager.Grafana.GrafanaPrivateLinkResourceData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string privateLinkResourceName) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Grafana.GrafanaPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.GrafanaPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GrafanaPrivateLinkResourceCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource>, System.Collections.IEnumerable
    {
        protected GrafanaPrivateLinkResourceCollection() { }
        public virtual Azure.Response<bool> Exists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource> Get(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource>> GetAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource> GetIfExists(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource>> GetIfExistsAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class GrafanaPrivateLinkResourceData : Azure.ResourceManager.Models.ResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResourceData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResourceData>
    {
        public GrafanaPrivateLinkResourceData() { }
        public string GroupId { get { throw null; } }
        public Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState? ProvisioningState { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> RequiredMembers { get { throw null; } }
        public System.Collections.Generic.IList<string> RequiredZoneNames { get { throw null; } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.GrafanaPrivateLinkResourceData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResourceData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResourceData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.GrafanaPrivateLinkResourceData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResourceData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResourceData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResourceData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedGrafanaCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Grafana.ManagedGrafanaResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Grafana.ManagedGrafanaResource>, System.Collections.IEnumerable
    {
        protected ManagedGrafanaCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Grafana.ManagedGrafanaResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.Grafana.ManagedGrafanaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Grafana.ManagedGrafanaResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string workspaceName, Azure.ResourceManager.Grafana.ManagedGrafanaData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource> Get(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Grafana.ManagedGrafanaResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Grafana.ManagedGrafanaResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource>> GetAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Grafana.ManagedGrafanaResource> GetIfExists(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Grafana.ManagedGrafanaResource>> GetIfExistsAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Grafana.ManagedGrafanaResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Grafana.ManagedGrafanaResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Grafana.ManagedGrafanaResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Grafana.ManagedGrafanaResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedGrafanaData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.ManagedGrafanaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.ManagedGrafanaData>
    {
        public ManagedGrafanaData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Grafana.Models.ManagedGrafanaProperties Properties { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.ManagedGrafanaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.ManagedGrafanaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.ManagedGrafanaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.ManagedGrafanaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.ManagedGrafanaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.ManagedGrafanaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.ManagedGrafanaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedGrafanaResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.ManagedGrafanaData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.ManagedGrafanaData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedGrafanaResource() { }
        public virtual Azure.ResourceManager.Grafana.ManagedGrafanaData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.Models.EnterpriseDetails> CheckEnterpriseDetails(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.Models.EnterpriseDetails>> CheckEnterpriseDetailsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Grafana.Models.GrafanaAvailablePlugin> FetchAvailablePlugins(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Grafana.Models.GrafanaAvailablePlugin> FetchAvailablePluginsAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource> GetGrafanaPrivateEndpointConnection(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource>> GetGrafanaPrivateEndpointConnectionAsync(string privateEndpointConnectionName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionCollection GetGrafanaPrivateEndpointConnections() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource> GetGrafanaPrivateLinkResource(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource>> GetGrafanaPrivateLinkResourceAsync(string privateLinkResourceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Grafana.GrafanaPrivateLinkResourceCollection GetGrafanaPrivateLinkResources() { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelResource> GetManagedPrivateEndpointModel(string managedPrivateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelResource>> GetManagedPrivateEndpointModelAsync(string managedPrivateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelCollection GetManagedPrivateEndpointModels() { throw null; }
        public virtual Azure.ResourceManager.ArmOperation RefreshManagedPrivateEndpoint(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> RefreshManagedPrivateEndpointAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Grafana.ManagedGrafanaData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.ManagedGrafanaData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.ManagedGrafanaData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.ManagedGrafanaData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.ManagedGrafanaData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.ManagedGrafanaData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.ManagedGrafanaData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource> Update(Azure.ResourceManager.Grafana.Models.ManagedGrafanaPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource>> UpdateAsync(Azure.ResourceManager.Grafana.Models.ManagedGrafanaPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
    public partial class ManagedPrivateEndpointModelCollection : Azure.ResourceManager.ArmCollection, System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelResource>, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelResource>, System.Collections.IEnumerable
    {
        protected ManagedPrivateEndpointModelCollection() { }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelResource> CreateOrUpdate(Azure.WaitUntil waitUntil, string managedPrivateEndpointName, Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelResource>> CreateOrUpdateAsync(Azure.WaitUntil waitUntil, string managedPrivateEndpointName, Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelData data, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<bool> Exists(string managedPrivateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<bool>> ExistsAsync(string managedPrivateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelResource> Get(string managedPrivateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Pageable<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelResource> GetAll(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelResource> GetAllAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelResource>> GetAsync(string managedPrivateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.NullableResponse<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelResource> GetIfExists(string managedPrivateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.NullableResponse<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelResource>> GetIfExistsAsync(string managedPrivateEndpointName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        System.Collections.Generic.IAsyncEnumerator<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelResource> System.Collections.Generic.IAsyncEnumerable<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken) { throw null; }
        System.Collections.Generic.IEnumerator<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelResource> System.Collections.Generic.IEnumerable<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelResource>.GetEnumerator() { throw null; }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { throw null; }
    }
    public partial class ManagedPrivateEndpointModelData : Azure.ResourceManager.Models.TrackedResourceData, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelData>
    {
        public ManagedPrivateEndpointModelData(Azure.Core.AzureLocation location) { }
        public Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointConnectionState ConnectionState { get { throw null; } }
        public System.Collections.Generic.IList<string> GroupIds { get { throw null; } }
        public Azure.Core.ResourceIdentifier PrivateLinkResourceId { get { throw null; } set { } }
        public string PrivateLinkResourceRegion { get { throw null; } set { } }
        public string PrivateLinkServicePrivateIP { get { throw null; } }
        public System.Uri PrivateLinkServiceUri { get { throw null; } set { } }
        public Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState? ProvisioningState { get { throw null; } }
        public string RequestMessage { get { throw null; } set { } }
        protected override void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedPrivateEndpointModelResource : Azure.ResourceManager.ArmResource, System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelData>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelData>
    {
        public static readonly Azure.Core.ResourceType ResourceType;
        protected ManagedPrivateEndpointModelResource() { }
        public virtual Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelData Data { get { throw null; } }
        public virtual bool HasData { get { throw null; } }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelResource> AddTag(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelResource>> AddTagAsync(string key, string value, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public static Azure.Core.ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string managedPrivateEndpointName) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation Delete(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation> DeleteAsync(Azure.WaitUntil waitUntil, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelResource> Get(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelResource>> GetAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelResource> RemoveTag(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelResource>> RemoveTagAsync(string key, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelResource> SetTags(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelResource>> SetTagsAsync(System.Collections.Generic.IDictionary<string, string> tags, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelData System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelData>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelData>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelData>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelData>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelData>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        public virtual Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelResource> Update(Azure.WaitUntil waitUntil, Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointModelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.ResourceManager.ArmOperation<Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelResource>> UpdateAsync(Azure.WaitUntil waitUntil, Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointModelPatch patch, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Grafana.Mocking
{
    public partial class MockableGrafanaArmClient : Azure.ResourceManager.ArmResource
    {
        protected MockableGrafanaArmClient() { }
        public virtual Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionResource GetGrafanaPrivateEndpointConnectionResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Grafana.GrafanaPrivateLinkResource GetGrafanaPrivateLinkResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Grafana.ManagedGrafanaResource GetManagedGrafanaResource(Azure.Core.ResourceIdentifier id) { throw null; }
        public virtual Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelResource GetManagedPrivateEndpointModelResource(Azure.Core.ResourceIdentifier id) { throw null; }
    }
    public partial class MockableGrafanaResourceGroupResource : Azure.ResourceManager.ArmResource
    {
        protected MockableGrafanaResourceGroupResource() { }
        public virtual Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource> GetManagedGrafana(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual System.Threading.Tasks.Task<Azure.Response<Azure.ResourceManager.Grafana.ManagedGrafanaResource>> GetManagedGrafanaAsync(string workspaceName, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.ResourceManager.Grafana.ManagedGrafanaCollection GetManagedGrafanas() { throw null; }
    }
    public partial class MockableGrafanaSubscriptionResource : Azure.ResourceManager.ArmResource
    {
        protected MockableGrafanaSubscriptionResource() { }
        public virtual Azure.Pageable<Azure.ResourceManager.Grafana.ManagedGrafanaResource> GetManagedGrafanas(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
        public virtual Azure.AsyncPageable<Azure.ResourceManager.Grafana.ManagedGrafanaResource> GetManagedGrafanasAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) { throw null; }
    }
}
namespace Azure.ResourceManager.Grafana.Models
{
    public static partial class ArmGrafanaModelFactory
    {
        public static Azure.ResourceManager.Grafana.Models.EnterpriseDetails EnterpriseDetails(Azure.ResourceManager.Grafana.Models.SaasSubscriptionDetails saasSubscriptionDetails = null, Azure.ResourceManager.Grafana.Models.MarketplaceTrialQuota marketplaceTrialQuota = null) { throw null; }
        public static Azure.ResourceManager.Grafana.Models.GrafanaAvailablePlugin GrafanaAvailablePlugin(string pluginId = null, string name = null) { throw null; }
        public static Azure.ResourceManager.Grafana.Models.GrafanaPlugin GrafanaPlugin(string pluginId = null) { throw null; }
        public static Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData GrafanaPrivateEndpointConnectionData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.Core.ResourceIdentifier privateEndpointId = null, Azure.ResourceManager.Grafana.Models.GrafanaPrivateLinkServiceConnectionState connectionState = null, System.Collections.Generic.IEnumerable<string> groupIds = null, Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointConnectionProvisioningState? provisioningState = default(Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointConnectionProvisioningState?)) { throw null; }
        public static Azure.ResourceManager.Grafana.GrafanaPrivateLinkResourceData GrafanaPrivateLinkResourceData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState? provisioningState = default(Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState?), string groupId = null, System.Collections.Generic.IEnumerable<string> requiredMembers = null, System.Collections.Generic.IEnumerable<string> requiredZoneNames = null) { throw null; }
        public static Azure.ResourceManager.Grafana.ManagedGrafanaData ManagedGrafanaData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), string skuName = null, Azure.ResourceManager.Grafana.Models.ManagedGrafanaProperties properties = null, Azure.ResourceManager.Models.ManagedServiceIdentity identity = null) { throw null; }
        public static Azure.ResourceManager.Grafana.Models.ManagedGrafanaProperties ManagedGrafanaProperties(Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState? provisioningState = default(Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState?), string grafanaVersion = null, string endpoint = null, Azure.ResourceManager.Grafana.Models.GrafanaPublicNetworkAccess? publicNetworkAccess = default(Azure.ResourceManager.Grafana.Models.GrafanaPublicNetworkAccess?), Azure.ResourceManager.Grafana.Models.GrafanaZoneRedundancy? zoneRedundancy = default(Azure.ResourceManager.Grafana.Models.GrafanaZoneRedundancy?), Azure.ResourceManager.Grafana.Models.GrafanaApiKey? apiKey = default(Azure.ResourceManager.Grafana.Models.GrafanaApiKey?), Azure.ResourceManager.Grafana.Models.DeterministicOutboundIP? deterministicOutboundIP = default(Azure.ResourceManager.Grafana.Models.DeterministicOutboundIP?), System.Collections.Generic.IEnumerable<string> outboundIPs = null, System.Collections.Generic.IEnumerable<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData> privateEndpointConnections = null, Azure.ResourceManager.Grafana.Models.AutoGeneratedDomainNameLabelScope? autoGeneratedDomainNameLabelScope = default(Azure.ResourceManager.Grafana.Models.AutoGeneratedDomainNameLabelScope?), System.Collections.Generic.IEnumerable<Azure.ResourceManager.Grafana.Models.MonitorWorkspaceIntegration> monitorWorkspaceIntegrations = null, Azure.ResourceManager.Grafana.Models.EnterpriseConfigurations enterpriseConfigurations = null, Azure.ResourceManager.Grafana.Models.Smtp grafanaConfigurationsSmtp = null, System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Grafana.Models.GrafanaPlugin> grafanaPlugins = null, string grafanaMajorVersion = null) { throw null; }
        public static Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointConnectionState ManagedPrivateEndpointConnectionState(Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointConnectionStatus? status = default(Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointConnectionStatus?), string description = null) { throw null; }
        public static Azure.ResourceManager.Grafana.ManagedPrivateEndpointModelData ManagedPrivateEndpointModelData(Azure.Core.ResourceIdentifier id = null, string name = null, Azure.Core.ResourceType resourceType = default(Azure.Core.ResourceType), Azure.ResourceManager.Models.SystemData systemData = null, System.Collections.Generic.IDictionary<string, string> tags = null, Azure.Core.AzureLocation location = default(Azure.Core.AzureLocation), Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState? provisioningState = default(Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState?), Azure.Core.ResourceIdentifier privateLinkResourceId = null, string privateLinkResourceRegion = null, System.Collections.Generic.IEnumerable<string> groupIds = null, string requestMessage = null, Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointConnectionState connectionState = null, System.Uri privateLinkServiceUri = null, string privateLinkServicePrivateIP = null) { throw null; }
        public static Azure.ResourceManager.Grafana.Models.MarketplaceTrialQuota MarketplaceTrialQuota(Azure.ResourceManager.Grafana.Models.AvailablePromotion? availablePromotion = default(Azure.ResourceManager.Grafana.Models.AvailablePromotion?), Azure.Core.ResourceIdentifier grafanaResourceId = null, System.DateTimeOffset? trialStartOn = default(System.DateTimeOffset?), System.DateTimeOffset? trialEndOn = default(System.DateTimeOffset?)) { throw null; }
        public static Azure.ResourceManager.Grafana.Models.SaasSubscriptionDetails SaasSubscriptionDetails(string planId = null, string offerId = null, string publisherId = null, Azure.ResourceManager.Grafana.Models.SubscriptionTerm term = null) { throw null; }
        public static Azure.ResourceManager.Grafana.Models.SubscriptionTerm SubscriptionTerm(string termUnit = null, System.DateTimeOffset? startOn = default(System.DateTimeOffset?), System.DateTimeOffset? endOn = default(System.DateTimeOffset?)) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AutoGeneratedDomainNameLabelScope : System.IEquatable<Azure.ResourceManager.Grafana.Models.AutoGeneratedDomainNameLabelScope>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AutoGeneratedDomainNameLabelScope(string value) { throw null; }
        public static Azure.ResourceManager.Grafana.Models.AutoGeneratedDomainNameLabelScope TenantReuse { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Grafana.Models.AutoGeneratedDomainNameLabelScope other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Grafana.Models.AutoGeneratedDomainNameLabelScope left, Azure.ResourceManager.Grafana.Models.AutoGeneratedDomainNameLabelScope right) { throw null; }
        public static implicit operator Azure.ResourceManager.Grafana.Models.AutoGeneratedDomainNameLabelScope (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Grafana.Models.AutoGeneratedDomainNameLabelScope left, Azure.ResourceManager.Grafana.Models.AutoGeneratedDomainNameLabelScope right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct AvailablePromotion : System.IEquatable<Azure.ResourceManager.Grafana.Models.AvailablePromotion>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AvailablePromotion(string value) { throw null; }
        public static Azure.ResourceManager.Grafana.Models.AvailablePromotion FreeTrial { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.AvailablePromotion None { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Grafana.Models.AvailablePromotion other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Grafana.Models.AvailablePromotion left, Azure.ResourceManager.Grafana.Models.AvailablePromotion right) { throw null; }
        public static implicit operator Azure.ResourceManager.Grafana.Models.AvailablePromotion (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Grafana.Models.AvailablePromotion left, Azure.ResourceManager.Grafana.Models.AvailablePromotion right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct DeterministicOutboundIP : System.IEquatable<Azure.ResourceManager.Grafana.Models.DeterministicOutboundIP>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public DeterministicOutboundIP(string value) { throw null; }
        public static Azure.ResourceManager.Grafana.Models.DeterministicOutboundIP Disabled { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.DeterministicOutboundIP Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Grafana.Models.DeterministicOutboundIP other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Grafana.Models.DeterministicOutboundIP left, Azure.ResourceManager.Grafana.Models.DeterministicOutboundIP right) { throw null; }
        public static implicit operator Azure.ResourceManager.Grafana.Models.DeterministicOutboundIP (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Grafana.Models.DeterministicOutboundIP left, Azure.ResourceManager.Grafana.Models.DeterministicOutboundIP right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class EnterpriseConfigurations : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.EnterpriseConfigurations>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.EnterpriseConfigurations>
    {
        public EnterpriseConfigurations() { }
        public Azure.ResourceManager.Grafana.Models.MarketplaceAutoRenew? MarketplaceAutoRenew { get { throw null; } set { } }
        public string MarketplacePlanId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.Models.EnterpriseConfigurations System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.EnterpriseConfigurations>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.EnterpriseConfigurations>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.Models.EnterpriseConfigurations System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.EnterpriseConfigurations>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.EnterpriseConfigurations>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.EnterpriseConfigurations>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class EnterpriseDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.EnterpriseDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.EnterpriseDetails>
    {
        internal EnterpriseDetails() { }
        public Azure.ResourceManager.Grafana.Models.MarketplaceTrialQuota MarketplaceTrialQuota { get { throw null; } }
        public Azure.ResourceManager.Grafana.Models.SaasSubscriptionDetails SaasSubscriptionDetails { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.Models.EnterpriseDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.EnterpriseDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.EnterpriseDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.Models.EnterpriseDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.EnterpriseDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.EnterpriseDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.EnterpriseDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GrafanaApiKey : System.IEquatable<Azure.ResourceManager.Grafana.Models.GrafanaApiKey>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GrafanaApiKey(string value) { throw null; }
        public static Azure.ResourceManager.Grafana.Models.GrafanaApiKey Disabled { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaApiKey Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Grafana.Models.GrafanaApiKey other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Grafana.Models.GrafanaApiKey left, Azure.ResourceManager.Grafana.Models.GrafanaApiKey right) { throw null; }
        public static implicit operator Azure.ResourceManager.Grafana.Models.GrafanaApiKey (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Grafana.Models.GrafanaApiKey left, Azure.ResourceManager.Grafana.Models.GrafanaApiKey right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GrafanaAvailablePlugin : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.GrafanaAvailablePlugin>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.GrafanaAvailablePlugin>
    {
        internal GrafanaAvailablePlugin() { }
        public string Name { get { throw null; } }
        public string PluginId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.Models.GrafanaAvailablePlugin System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.GrafanaAvailablePlugin>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.GrafanaAvailablePlugin>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.Models.GrafanaAvailablePlugin System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.GrafanaAvailablePlugin>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.GrafanaAvailablePlugin>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.GrafanaAvailablePlugin>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class GrafanaPlugin : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.GrafanaPlugin>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.GrafanaPlugin>
    {
        public GrafanaPlugin() { }
        public string PluginId { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.Models.GrafanaPlugin System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.GrafanaPlugin>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.GrafanaPlugin>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.Models.GrafanaPlugin System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.GrafanaPlugin>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.GrafanaPlugin>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.GrafanaPlugin>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GrafanaPrivateEndpointConnectionProvisioningState : System.IEquatable<Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointConnectionProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GrafanaPrivateEndpointConnectionProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointConnectionProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointConnectionProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointConnectionProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointConnectionProvisioningState Succeeded { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointConnectionProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointConnectionProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointConnectionProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointConnectionProvisioningState left, Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointConnectionProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GrafanaPrivateEndpointServiceConnectionStatus : System.IEquatable<Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointServiceConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GrafanaPrivateEndpointServiceConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointServiceConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointServiceConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointServiceConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointServiceConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointServiceConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointServiceConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointServiceConnectionStatus left, Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointServiceConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class GrafanaPrivateLinkServiceConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.GrafanaPrivateLinkServiceConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.GrafanaPrivateLinkServiceConnectionState>
    {
        public GrafanaPrivateLinkServiceConnectionState() { }
        public string ActionsRequired { get { throw null; } set { } }
        public string Description { get { throw null; } set { } }
        public Azure.ResourceManager.Grafana.Models.GrafanaPrivateEndpointServiceConnectionStatus? Status { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.Models.GrafanaPrivateLinkServiceConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.GrafanaPrivateLinkServiceConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.GrafanaPrivateLinkServiceConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.Models.GrafanaPrivateLinkServiceConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.GrafanaPrivateLinkServiceConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.GrafanaPrivateLinkServiceConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.GrafanaPrivateLinkServiceConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GrafanaProvisioningState : System.IEquatable<Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GrafanaProvisioningState(string value) { throw null; }
        public static Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState Accepted { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState Canceled { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState Creating { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState Deleted { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState Deleting { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState Failed { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState NotSpecified { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState Succeeded { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState Updating { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState left, Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState right) { throw null; }
        public static implicit operator Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState left, Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GrafanaPublicNetworkAccess : System.IEquatable<Azure.ResourceManager.Grafana.Models.GrafanaPublicNetworkAccess>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GrafanaPublicNetworkAccess(string value) { throw null; }
        public static Azure.ResourceManager.Grafana.Models.GrafanaPublicNetworkAccess Disabled { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaPublicNetworkAccess Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Grafana.Models.GrafanaPublicNetworkAccess other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Grafana.Models.GrafanaPublicNetworkAccess left, Azure.ResourceManager.Grafana.Models.GrafanaPublicNetworkAccess right) { throw null; }
        public static implicit operator Azure.ResourceManager.Grafana.Models.GrafanaPublicNetworkAccess (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Grafana.Models.GrafanaPublicNetworkAccess left, Azure.ResourceManager.Grafana.Models.GrafanaPublicNetworkAccess right) { throw null; }
        public override string ToString() { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct GrafanaZoneRedundancy : System.IEquatable<Azure.ResourceManager.Grafana.Models.GrafanaZoneRedundancy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public GrafanaZoneRedundancy(string value) { throw null; }
        public static Azure.ResourceManager.Grafana.Models.GrafanaZoneRedundancy Disabled { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.GrafanaZoneRedundancy Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Grafana.Models.GrafanaZoneRedundancy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Grafana.Models.GrafanaZoneRedundancy left, Azure.ResourceManager.Grafana.Models.GrafanaZoneRedundancy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Grafana.Models.GrafanaZoneRedundancy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Grafana.Models.GrafanaZoneRedundancy left, Azure.ResourceManager.Grafana.Models.GrafanaZoneRedundancy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedGrafanaPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.ManagedGrafanaPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.ManagedGrafanaPatch>
    {
        public ManagedGrafanaPatch() { }
        public Azure.ResourceManager.Models.ManagedServiceIdentity Identity { get { throw null; } set { } }
        public Azure.ResourceManager.Grafana.Models.ManagedGrafanaPatchProperties Properties { get { throw null; } set { } }
        public string SkuName { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.Models.ManagedGrafanaPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.ManagedGrafanaPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.ManagedGrafanaPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.Models.ManagedGrafanaPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.ManagedGrafanaPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.ManagedGrafanaPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.ManagedGrafanaPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedGrafanaPatchProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.ManagedGrafanaPatchProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.ManagedGrafanaPatchProperties>
    {
        public ManagedGrafanaPatchProperties() { }
        public Azure.ResourceManager.Grafana.Models.GrafanaApiKey? ApiKey { get { throw null; } set { } }
        public Azure.ResourceManager.Grafana.Models.DeterministicOutboundIP? DeterministicOutboundIP { get { throw null; } set { } }
        public Azure.ResourceManager.Grafana.Models.EnterpriseConfigurations EnterpriseConfigurations { get { throw null; } set { } }
        public Azure.ResourceManager.Grafana.Models.Smtp GrafanaConfigurationsSmtp { get { throw null; } set { } }
        public string GrafanaMajorVersion { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Grafana.Models.GrafanaPlugin> GrafanaPlugins { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Grafana.Models.MonitorWorkspaceIntegration> MonitorWorkspaceIntegrations { get { throw null; } }
        public Azure.ResourceManager.Grafana.Models.GrafanaPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Grafana.Models.GrafanaZoneRedundancy? ZoneRedundancy { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.Models.ManagedGrafanaPatchProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.ManagedGrafanaPatchProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.ManagedGrafanaPatchProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.Models.ManagedGrafanaPatchProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.ManagedGrafanaPatchProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.ManagedGrafanaPatchProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.ManagedGrafanaPatchProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedGrafanaProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.ManagedGrafanaProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.ManagedGrafanaProperties>
    {
        public ManagedGrafanaProperties() { }
        public Azure.ResourceManager.Grafana.Models.GrafanaApiKey? ApiKey { get { throw null; } set { } }
        public Azure.ResourceManager.Grafana.Models.AutoGeneratedDomainNameLabelScope? AutoGeneratedDomainNameLabelScope { get { throw null; } set { } }
        public Azure.ResourceManager.Grafana.Models.DeterministicOutboundIP? DeterministicOutboundIP { get { throw null; } set { } }
        public string Endpoint { get { throw null; } }
        public Azure.ResourceManager.Grafana.Models.EnterpriseConfigurations EnterpriseConfigurations { get { throw null; } set { } }
        public Azure.ResourceManager.Grafana.Models.Smtp GrafanaConfigurationsSmtp { get { throw null; } set { } }
        public string GrafanaMajorVersion { get { throw null; } set { } }
        public System.Collections.Generic.IDictionary<string, Azure.ResourceManager.Grafana.Models.GrafanaPlugin> GrafanaPlugins { get { throw null; } }
        public string GrafanaVersion { get { throw null; } }
        public System.Collections.Generic.IList<Azure.ResourceManager.Grafana.Models.MonitorWorkspaceIntegration> MonitorWorkspaceIntegrations { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<string> OutboundIPs { get { throw null; } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.Grafana.GrafanaPrivateEndpointConnectionData> PrivateEndpointConnections { get { throw null; } }
        public Azure.ResourceManager.Grafana.Models.GrafanaProvisioningState? ProvisioningState { get { throw null; } }
        public Azure.ResourceManager.Grafana.Models.GrafanaPublicNetworkAccess? PublicNetworkAccess { get { throw null; } set { } }
        public Azure.ResourceManager.Grafana.Models.GrafanaZoneRedundancy? ZoneRedundancy { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.Models.ManagedGrafanaProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.ManagedGrafanaProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.ManagedGrafanaProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.Models.ManagedGrafanaProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.ManagedGrafanaProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.ManagedGrafanaProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.ManagedGrafanaProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class ManagedPrivateEndpointConnectionState : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointConnectionState>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointConnectionState>
    {
        internal ManagedPrivateEndpointConnectionState() { }
        public string Description { get { throw null; } }
        public Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointConnectionStatus? Status { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointConnectionState System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointConnectionState>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointConnectionState>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointConnectionState System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointConnectionState>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointConnectionState>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointConnectionState>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct ManagedPrivateEndpointConnectionStatus : System.IEquatable<Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointConnectionStatus>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public ManagedPrivateEndpointConnectionStatus(string value) { throw null; }
        public static Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointConnectionStatus Approved { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointConnectionStatus Disconnected { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointConnectionStatus Pending { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointConnectionStatus Rejected { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointConnectionStatus other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointConnectionStatus left, Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointConnectionStatus right) { throw null; }
        public static implicit operator Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointConnectionStatus (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointConnectionStatus left, Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointConnectionStatus right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class ManagedPrivateEndpointModelPatch : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointModelPatch>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointModelPatch>
    {
        public ManagedPrivateEndpointModelPatch() { }
        public System.Collections.Generic.IDictionary<string, string> Tags { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointModelPatch System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointModelPatch>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointModelPatch>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointModelPatch System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointModelPatch>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointModelPatch>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.ManagedPrivateEndpointModelPatch>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct MarketplaceAutoRenew : System.IEquatable<Azure.ResourceManager.Grafana.Models.MarketplaceAutoRenew>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public MarketplaceAutoRenew(string value) { throw null; }
        public static Azure.ResourceManager.Grafana.Models.MarketplaceAutoRenew Disabled { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.MarketplaceAutoRenew Enabled { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Grafana.Models.MarketplaceAutoRenew other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Grafana.Models.MarketplaceAutoRenew left, Azure.ResourceManager.Grafana.Models.MarketplaceAutoRenew right) { throw null; }
        public static implicit operator Azure.ResourceManager.Grafana.Models.MarketplaceAutoRenew (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Grafana.Models.MarketplaceAutoRenew left, Azure.ResourceManager.Grafana.Models.MarketplaceAutoRenew right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class MarketplaceTrialQuota : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.MarketplaceTrialQuota>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.MarketplaceTrialQuota>
    {
        internal MarketplaceTrialQuota() { }
        public Azure.ResourceManager.Grafana.Models.AvailablePromotion? AvailablePromotion { get { throw null; } }
        public Azure.Core.ResourceIdentifier GrafanaResourceId { get { throw null; } }
        public System.DateTimeOffset? TrialEndOn { get { throw null; } }
        public System.DateTimeOffset? TrialStartOn { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.Models.MarketplaceTrialQuota System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.MarketplaceTrialQuota>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.MarketplaceTrialQuota>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.Models.MarketplaceTrialQuota System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.MarketplaceTrialQuota>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.MarketplaceTrialQuota>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.MarketplaceTrialQuota>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class MonitorWorkspaceIntegration : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.MonitorWorkspaceIntegration>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.MonitorWorkspaceIntegration>
    {
        public MonitorWorkspaceIntegration() { }
        public Azure.Core.ResourceIdentifier MonitorWorkspaceResourceId { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.Models.MonitorWorkspaceIntegration System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.MonitorWorkspaceIntegration>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.MonitorWorkspaceIntegration>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.Models.MonitorWorkspaceIntegration System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.MonitorWorkspaceIntegration>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.MonitorWorkspaceIntegration>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.MonitorWorkspaceIntegration>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class SaasSubscriptionDetails : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.SaasSubscriptionDetails>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.SaasSubscriptionDetails>
    {
        internal SaasSubscriptionDetails() { }
        public string OfferId { get { throw null; } }
        public string PlanId { get { throw null; } }
        public string PublisherId { get { throw null; } }
        public Azure.ResourceManager.Grafana.Models.SubscriptionTerm Term { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.Models.SaasSubscriptionDetails System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.SaasSubscriptionDetails>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.SaasSubscriptionDetails>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.Models.SaasSubscriptionDetails System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.SaasSubscriptionDetails>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.SaasSubscriptionDetails>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.SaasSubscriptionDetails>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    public partial class Smtp : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.Smtp>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.Smtp>
    {
        public Smtp() { }
        public bool? Enabled { get { throw null; } set { } }
        public string FromAddress { get { throw null; } set { } }
        public string FromName { get { throw null; } set { } }
        public string Host { get { throw null; } set { } }
        public string Password { get { throw null; } set { } }
        public bool? SkipVerify { get { throw null; } set { } }
        public Azure.ResourceManager.Grafana.Models.StartTLSPolicy? StartTLSPolicy { get { throw null; } set { } }
        public string User { get { throw null; } set { } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.Models.Smtp System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.Smtp>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.Smtp>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.Models.Smtp System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.Smtp>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.Smtp>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.Smtp>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public readonly partial struct StartTLSPolicy : System.IEquatable<Azure.ResourceManager.Grafana.Models.StartTLSPolicy>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public StartTLSPolicy(string value) { throw null; }
        public static Azure.ResourceManager.Grafana.Models.StartTLSPolicy MandatoryStartTLS { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.StartTLSPolicy NoStartTLS { get { throw null; } }
        public static Azure.ResourceManager.Grafana.Models.StartTLSPolicy OpportunisticStartTLS { get { throw null; } }
        public bool Equals(Azure.ResourceManager.Grafana.Models.StartTLSPolicy other) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj) { throw null; }
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode() { throw null; }
        public static bool operator ==(Azure.ResourceManager.Grafana.Models.StartTLSPolicy left, Azure.ResourceManager.Grafana.Models.StartTLSPolicy right) { throw null; }
        public static implicit operator Azure.ResourceManager.Grafana.Models.StartTLSPolicy (string value) { throw null; }
        public static bool operator !=(Azure.ResourceManager.Grafana.Models.StartTLSPolicy left, Azure.ResourceManager.Grafana.Models.StartTLSPolicy right) { throw null; }
        public override string ToString() { throw null; }
    }
    public partial class SubscriptionTerm : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.SubscriptionTerm>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.SubscriptionTerm>
    {
        internal SubscriptionTerm() { }
        public System.DateTimeOffset? EndOn { get { throw null; } }
        public System.DateTimeOffset? StartOn { get { throw null; } }
        public string TermUnit { get { throw null; } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.Models.SubscriptionTerm System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.SubscriptionTerm>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.Grafana.Models.SubscriptionTerm>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.Grafana.Models.SubscriptionTerm System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.SubscriptionTerm>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.SubscriptionTerm>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.Grafana.Models.SubscriptionTerm>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw null; }
    }
}
